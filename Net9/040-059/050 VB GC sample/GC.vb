﻿' Play with .Net GC
'
' 2001 PV
'
' 2006-10-01 	PV		VS2005
' 2012-02-25	PV		VS2010
' 2021-09-18 	PV		VS2022, Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9

Option Explicit On
Option Strict On

#Disable Warning IDE0059 ' Unnecessary assignment of a value
#Disable Warning CA1816 ' Dispose methods should call SuppressFinalize

'=====================================================================
'  File:      GC.vb
'
'  Summary:   Demonstrates how the garbage collector works.
'
'---------------------------------------------------------------------
'  This file is part of the Microsoft .NET Framework SDK Code Samples.
'
'  Copyright (C) 2000 Microsoft Corporation.  All rights reserved.
'
'This source code is intended only as a supplement to Microsoft
'Development Tools and/or on-line documentation.  See these other
'materials for detailed information regarding Microsoft code samples.
'
'THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
'KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
'IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
'PARTICULAR PURPOSE.
'=====================================================================*/

Imports System.Console
Imports System.Threading
Imports Microsoft.VisualBasic.ControlChars

Public Module ModMain

    ' Note that deriving from Object is optional since it is always implied
    Public Class BaseObj
        Inherits Object

        Private ReadOnly name As String   ' Each object has a name to help identify it

        Public Sub New(name As String)
            MyBase.New()
            Me.name = name
            Display("BaseObj Constructor")
        End Sub

        Public Sub Display(status As String)
            Application.Display($"Obj({name}): {status}")
        End Sub

        ' A Finalize method is the closest thing to a destructor but many of the
        ' semantics are different. The demos in this application demonstrate this.
        Protected Overrides Sub Finalize()
            Display("BaseObj Finalize")

            ' If possible, do not have a Finalize method for your class. Finalize
            ' methods usually run when the heap is low on available storage
            ' and needs to be garbage collected. This can hurt application
            ' performance significantly.

            ' If you must implement a Finalize method, make it run fast, avoid
            ' synchronizing on other threads, do not block, and
            ' avoid raising any exceptions (although the Finalizer thread
            ' automatically recovers from any unhandled exceptions).

            ' NOTE: In the future, exceptions may be caught using an
            ' AppDomain-registered unhandled Finalize Exception Handler

            ' While discouraged, you may call methods on object's referred
            ' to by this object. However, you must be aware that the other
            ' objects may have already had their Finalize method called
            ' causing these objects to be in an unpredictable state.
            ' This is because the system does not guarantees that
            ' Finalizers will be called in any particular order.
        End Sub

    End Class

    '///////////////////////////////////////////////////////////////////////////////

    ' This class shows how to derive a class from another class and how base class
    ' Finalize methods are NOT automatically called. By contrast, base class
    ' destructors (in unmanaged code) are automatically called.
    ' This is one example of how destructors and Finalize methods differ.
    Public Class DerivedObj
        Inherits BaseObj

        Public Sub New(s As String)
            MyBase.New(s)
            Display("DerivedObj Constructor")
        End Sub

        Protected Overrides Sub Finalize()
            Display("DerivedObj Finalize")

            ' The GC has a special thread dedicated to executing Finalize
            ' methods. You can tell that this thread is different from the
            ' application's main thread by comparing the thread's hash codes.
            Display("Finalize thread's hash code: " & Thread.CurrentThread.GetHashCode())

            ' BaseObj's Finalize is NOT called unless you execute the line below
            MyBase.Finalize()
        End Sub

    End Class

    '///////////////////////////////////////////////////////////////////////////////

    ' This class shows how an object can resurrect itself
    Public Class ResurrectObj
        Inherits BaseObj

        ' Indicates if object should resurrect itself when collected
        Private allowResurrection As Boolean = True   ' Assume resurrection

        Public Sub New(s As String)
            MyBase.New(s)
            Display("ResurrectObj Constructor")
        End Sub

        Public Sub SetResurrection(allowResurrection As Boolean)
            Me.allowResurrection = allowResurrection
        End Sub

        Protected Overrides Sub Finalize()
            Display("ResurrectObj Finalize")
            If allowResurrection Then
                Display("This object is being resurrected")
                ' Resurrect this object by making something refer to it
                Application.ResObjHolder = Me

                ' When the GC calls an object's Finalize method, it assumes that
                ' there is no need to ever call it again. However, we've now
                ' resurrected this object and the line below forces the GC to call
                ' this object's Finalize again when the object is destroyed again.
                ' BEWARE: If ReRegisterForFinalize is called multiple times, the
                ' object's Finalize method will be called multiple times.
                GC.ReRegisterForFinalize(Me)

                ' If this object contains a member referencing another object,
                ' The other object may have been finalized before this object
                ' gets resurrected. Note that resurrecting this object forces
                ' the referenced object to be resurrected as well. This object
                ' can continue to use the referenced object even though it was
                ' finalized.
            Else
                Display("This object is NOT being resurrected")
            End If
        End Sub

    End Class

    '///////////////////////////////////////////////////////////////////////////////

    ' This class shows how the GC improves performance using generations
    Public Class GenObj
        Inherits BaseObj

        Public Sub New(s As String)
            MyBase.New(s)
            Display("GenObj Constructor")
        End Sub

        Public Sub DisplayGeneration()
            Display($"Generation: {GC.GetGeneration(Me)}")
        End Sub

    End Class

    '///////////////////////////////////////////////////////////////////////////////

    ' This class shows the proper way to implement explicit cleanup.
    Public Class DisposeObj
        Inherits BaseObj

        Public Sub New(s As String)
            MyBase.New(s)
            Display("DisposeObj Constructor")
        End Sub

        ' When an object of this type wants to be explicitly cleaned-up, the user
        ' of this object should call Dispose at the desired code location.
        Public Sub Dispose()
            Display("DisposeObj Dispose")
            ' Usually Dispose() calls Finalize so that you can
            ' implement all the cleanup code in one place.
            Finalize()

            ' Tell the garbage collector that the object doesn't require any
            ' cleanup when collected since Dispose was called explicitly.
            GC.SuppressFinalize(Me)
        End Sub

        ' Put the object cleanup code in the Finalize method
        Protected Overrides Sub Finalize()
            Display("DisposeObj Finalize")
            ' This function can be called by Dispose() or by the GC
            ' If called by Dispose, the application's thread executes this code
            ' If called by the GC, then a special GC thread executes this code
        End Sub

    End Class

    '///////////////////////////////////////////////////////////////////////////////

    ' This class represents the application itself
    Public Class Application
        Private Shared indent As Integer '= 0

        Public Overloads Shared Sub Display(s As String)
            Dim x As Integer
            For x = 0 To (indent * 3) - 1
                Write(" ")
            Next
            WriteLine(s)
        End Sub

        Public Overloads Shared Sub Display(preIndent As Integer, s As String, postIndent As Integer)
            indent += preIndent
            Display(s)
            indent += postIndent
        End Sub

        Public Overloads Shared Sub Collect()
            Display(0, "Forcing a garbage collection", 0)
            GC.Collect()
        End Sub

        Public Overloads Shared Sub Collect(generation As Integer)
            Display(0, "Forcing a garbage collection of generation " & generation, 0)
            GC.Collect(generation)
        End Sub

        Public Shared Sub WaitForFinalizers()
            Display(0, "Waiting for Finalizers to complete", 1)
            GC.WaitForPendingFinalizers()
            Display(-1, "Finalizers are complete", 0)
        End Sub

        ' This method demonstrates how the GC works.
        Private Shared Sub Introduction()
            Display(0, CrLf & CrLf & "Demo start: Introduction to Garbage Collection.", 1)

            ' Create a new DerivedObj in the managed heap
            ' Note: Both BaseObj and DerivedObj constructors are called
            Dim obj As New DerivedObj("Introduction")

            obj = Nothing ' We no longer need this object

            ' The object is unreachable so forcing a GC causes it to be finalized.
            Collect()

            ' Wait for the GC's Finalize thread to finish
            ' executing all queued Finalize methods.

            WaitForFinalizers()

            ' NOTE: The GC calls the most-derived (farthest away from
            ' the Object base class) Finalize only.
            ' Base class Finalize functions are called only if the most-derived
            ' Finalize method explicitly calls its base class's Finalize method.

            ' This is the same test as above with one slight variation

            obj = New DerivedObj("Introduction")
            ' obj = Nothing ' Variation: this line is commented out

            Collect()
            WaitForFinalizers()

            ' Notice that we get identical results as above: the Finalize method
            ' runs because the jitter's optimizer knows that obj is not
            ' referenced later in this function.

            Display(-1, "Demo stop: Introduction to Garbage Collection.", 0)
        End Sub

        ' This reference is accessed in the ResurrectObj.Finalize method and
        ' is used to create a strong reference to an object (resurrecting it).
        Friend Shared ResObjHolder As ResurrectObj    ' Defaults to Nothing

        ' This method demonstrates how the GC supports resurrection.
        ' NOTE: Resurrection is discouraged.
        Private Shared Sub ResurrectionDemo()
            Display(0, CrLf & CrLf & "Demo start: Object Resurrection.", 1)

            ' Create a ResurrectionObj
            Dim obj As New ResurrectObj("Resurrection")

            ' Destroy all strong references to the new ResurrectionObj
            obj = Nothing

            ' Force the GC to determine that the object is unreachable.
            Collect()
            WaitForFinalizers() ' You should see the Finalize method called.

            ' However, the ResurrectionObj's Finalize method
            ' resurrects the object keeping it alive. It does this by placing a
            ' reference to the dying-object in Application.ResObjHolder

            ' You can see that ResurrectionObj still exists because
            ' the following line doesn't raise an exception.
            ResObjHolder.Display("Still alive after Finalize called")

            ' Prevent the ResurrectionObj object from resurrecting itself again,
            ResObjHolder.SetResurrection(False)

            ' Now, let's destroy this last reference to the ResurrectionObj
            ResObjHolder = Nothing

            ' Force the GC to determine that the object is unreachable.
            Collect()
            WaitForFinalizers() ' You should see the Finalize method called.
            Display(-1, "Demo stop: Object Resurrection.", 0)
        End Sub

        ' This method demonstrates how to implement a type that allows its users
        ' to explicitly dispose/close the object. For many object's this paradigm
        ' is strongly encouranged.
        Private Shared Sub DisposeDemo()
            Display(0, CrLf & CrLf & "Demo start: Disposing an object versus Finalize.", 1)
            Dim obj As New DisposeObj("Explicitly disposed")
            obj.Dispose() ' Explicitly cleanup this object, Finalize should run
            obj = Nothing
            Collect()
            WaitForFinalizers() ' Finalize should NOT run (it was suppressed)

            obj = New DisposeObj("Implicitly disposed")
            obj = Nothing
            Collect()
            WaitForFinalizers() ' No explicit cleanup, Finalize SHOULD run
            Display(-1, "Demo stop: Disposing an object versus Finalize.", 0)
        End Sub

        ' This method demonstrates the unbalanced nature of ReRegisterForFinalize
        ' and SuppressFinalize. The main point is if your code makes multiple
        ' calls to ReRegisterForFinalize (without intervening calls to
        ' SuppressFinalize) the Finalize method may get called multiple times.
        Private Shared Sub FinalizationQDemo()
            Display(0, CrLf & "Demo start: Suppressing and ReRegistering for Finalize.", 1)
            ' Since this object has a Finalize method, a reference to the object
            ' will be added to the finalization queue.
            Dim obj As New BaseObj("Finalization Queue")

            ' Add another 2 references onto the finalization queue
            ' NOTE: Don't do this in a normal app. This is only for demo purposes.
            GC.ReRegisterForFinalize(obj)
            GC.ReRegisterForFinalize(obj)

            ' There are now 3 references to this object on the finalization queue.

            ' Set a bit flag on this object indicating that it should NOT be finalized.
            GC.SuppressFinalize(obj)

            ' There are now 3 references to this object on the finalization queue.
            ' If the object were unreachable, the 1st call to this object's Finalize
            ' method will be discarded but the 2nd & 3rd calls to Finalize will execute.

            ' Sets the same bit effectively doing nothing!
            GC.SuppressFinalize(obj)

            obj = Nothing   ' Remove the strong reference to the object.

            ' Force a GC so that the object gets finalized
            Collect()

            ' NOTE: Finalize is called twice because only the 1st call is suppressed!
            WaitForFinalizers()
            Display(-1, "Demo stop: Suppressing and ReRegistering for Finalize.", 0)
        End Sub

        ' This method demonstrates how objects are promoted between generations.
        ' Applications could take advantage of this info to improve performance
        ' but most applications will ignore this information.
        Private Shared Sub GenerationDemo()
            Display(0, CrLf & CrLf & "Demo start: Understanding Generations.", 1)

            ' Let's see how many generations the managed heap supports (we know it's 2)
            Display("Maximum GC generations: " & GC.MaxGeneration)

            ' Create a new BaseObj in the heap
            Dim obj As New GenObj("Generation")

            ' Since this object is newly created, it should be in generation 0
            obj.DisplayGeneration()  ' Displays 0

            ' Performing a GC promotes the object's generation
            Collect()
            obj.DisplayGeneration()  ' Displays 1

            Collect()
            obj.DisplayGeneration()  ' Displays 2

            Collect()
            obj.DisplayGeneration()  ' Displays 2   (max generation)

            obj = Nothing             ' Destroy the strong reference to this object

            Collect(0)             ' Collect objects in generation 0
            WaitForFinalizers()    ' We should see nothing

            Collect(1)             ' Collect objects in generation 1
            WaitForFinalizers()    ' We should see nothing

            Collect(2)             ' Same as Collect()
            WaitForFinalizers()    ' Now, we should see the Finalize method run

            Display(-1, "Demo stop: Understanding Generations.", 0)
        End Sub

        ' This method demonstrates how weak references (WR) work. A WR allows
        ' the GC to collect objects if the managed heap is low on memory.
        ' WRs are useful to apps that have large amounts of easily-reconstructed
        ' data that they want to keep around to improve performance. But, if the
        ' system is low on memory, the objects can be destroyed and replaced when
        ' the app knows that it needs it again.
        Private Shared Sub WeakRefDemo(trackResurrection As Boolean)
            If trackResurrection Then
                Display(0, CrLf & CrLf & "Demo start: WeakReferences that track resurrections.", 1)
            Else
                Display(0, CrLf & CrLf & "Demo start: WeakReferences that do not track resurrections.", 1)
            End If

            ' Create an object
            Dim obj As New BaseObj("WeakRef")

            ' Create a WeakReference object that refers to the new object
            Dim wr As New WeakReference(obj, trackResurrection)

            ' The object is still reachable, so it is not finalized.
            Collect()
            WaitForFinalizers() ' The Finalize method should NOT execute
            obj.Display("Still exists")

            ' Let's remove the strong reference to the object
            obj = Nothing     ' Destroy strong reference to this object

            ' The following line creates a strong reference to the object
            obj = CType(wr.Target, BaseObj)
            If obj IsNot Nothing Then
                Display("Strong reference to object obtained: True")
            Else
                Display("Strong reference to object obtained: False")
            End If

            obj = Nothing     ' Destroy strong reference to this object again.

            ' The GC considers the object to be unreachable and collects it.
            Collect()
            WaitForFinalizers()  ' Finalize should run.

            ' This object resurrects itself when its Finalize method is called.
            ' If wr is NOT tracking resurrection, wr thinks the object is dead
            ' If wr is tracking resurrection, wr thinks the object is still alive

            ' NOTE: If the object referred to by wr doesn't have a Finalize method,
            ' then wr would think that the object is dead regardless of whether
            ' wr is tracking resurrection or not. For example:
            '    Object obj = new Object()   ' Object doesn't have a Finalize method
            '    WeakReference wr = new WeakReference(obj, true)
            '    obj = Nothing
            '    Collect
            '    WaitForFinalizers       ' Does nothing
            '    obj = wr.Target  ' returns Nothing

            ' The following line attempts to create a strong reference to the object
            obj = CType(wr.Target, BaseObj)
            If obj IsNot Nothing Then
                Display("Strong reference to object obtained: True")
            Else
                Display("Strong reference to object obtained: False")
            End If

            If obj IsNot Nothing Then
                ' The strong reference was obtained so this wr must be
                ' tracking resurrection. At this point we have a strong
                ' reference to an object that has been finalized but its memory
                ' has not yet been reclaimed by the collector.
                obj.Display("See, I'm still alive")

                obj = Nothing ' Destroy the strong reference to the object

                ' Collect reclaims the object's memory since this object
                ' has no Finalize method registered for it anymore.
                Collect()
                WaitForFinalizers()  ' We should see nothing here

                obj = CType(wr.Target, BaseObj)  ' This now returns Nothing
                If obj IsNot Nothing Then
                    Display("Strong reference to object obtained: True")
                Else
                    Display("Strong reference to object obtained: False")
                End If
            End If

            ' Cleanup everything about this demo so there is no affect on the next demo
            obj = Nothing           ' Destroy strong reference (if it exists)
            wr = Nothing            ' Destroy the WeakReference object (optional)
            Collect()
            WaitForFinalizers()

            ' NOTE: You are dicouraged from using the WeakReference.IsAlive property
            ' because the object may be killed immediately after IsAlive returns
            ' making the return value incorrect. If the Target property returns
            ' a non-Nothing value, then the object is alive and will stay alive
            ' since you have a reference to it. If Target returns Nothing, then the
            ' object is dead.
            If trackResurrection Then
                Display(-1, "Demo stop: WeakReferences that track resurrections.", 0)
            Else
                Display(-1, "Demo stop: WeakReferences that do not track resurrections.", 0)
            End If
        End Sub

        Public Shared Sub Main()
            Dim args() As String = Environment.GetCommandLineArgs

            Display("To fully understand this sample, you should step through the")
            Display("code in the debugger while monitoring the output generated." & CrLf)
            Display("NOTE: The demos in this application assume that no garbage")
            Display("      collections occur naturally. To ensure this, the sample")
            Display("      objects are small in size and few are allocated." & CrLf)
            Display("Main thread's hash code: " & Thread.CurrentThread.GetHashCode())

            Introduction()      ' GC introduction
            ResurrectionDemo()  ' Demos object resurrection
            DisposeDemo()       ' Demos the use of Dispose & Finalize
            FinalizationQDemo() ' Demos the use of SuppressFinalize & ReRegisterForFinalize
            GenerationDemo()    ' Demos GC generations
            WeakRefDemo(False)  ' Demos WeakReferences without resurrection tracking
            WeakRefDemo(True)   ' Demos WeakReferences with resurrection tracking

            ' Demos Finalize on Shutdown symantics (this demo is inline)
            Display(0, CrLf & CrLf & "Demo start: Finalize on shutdown.", 1)

            ' Normally, when an application terminates, the GC does NOT collect and run finalizers.
            ' The line below forces the GC to do complete object cleanup
            'GC.RequestFinalizeOnShutdown() ' For default behavior, comment out this line
            ' NOTE: Once you request FinalizeOnShutdown, you cannot change your mind.

            ' When Main returns, obj will have its Finalize method called.
            Dim obj As New BaseObj("Shutdown")

            ' This is the last line of code executed before the application terminates.
            Display(-1, "Demo stop: Finalize on shutdown (application is now terminating)", 0)
            Environment.ExitCode = 0

            'Console.ReadLine()
        End Sub

    End Class

End Module

'//////////////////////////////// End of File /////////////////////////////////
