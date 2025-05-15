' Analyseur de s�quences PCL
' 2003-07-16    PV
' 2003-08-07    PV  Fichier g�n�r� en param�tre; s�quences tilda
' 2012-02-25	PV  VS2010
' 2017-05-02    PV  GitHub et VS2017

Imports System.IO

Module modMainAnaPCL
    Dim nbCar As Integer = 0

    Public Function GetPosition() As Integer
        Return nbCar
    End Function

    Sub Main()
        Console.WriteLine("AnalysePCL 1.1")

        If InStr(Microsoft.VisualBasic.Command(), "-?") <> 0 Then
            Console.WriteLine("D�codage de PCL et Génération de TIFF")
            Console.WriteLine("P.VIOLENT Juillet-Ao�t 2003")
            Console.WriteLine()
            Console.WriteLine("Usage : APCL [-?] [-dp][-dm][-dt] [-v] [-c] fichier.pcl")
            Console.WriteLine("Génère le fichier image.tiff")
            Console.WriteLine()
            Console.WriteLine("Options :")
            Console.WriteLine("-?   affiche ce texte")
            Console.WriteLine("-dp  debug PCL, -dm  debug macros, -dp  debug chrono, -dt  debug Tilda")
            Console.WriteLine("-v   verbose")
            Console.WriteLine("-c   couleur: d�sactive l'option r�duction N&B")

            Exit Sub
        End If

        If InStr(Microsoft.VisualBasic.Command(), "-dp") <> 0 Then bDebugPCL = True
        If InStr(Microsoft.VisualBasic.Command(), "-dm") <> 0 Then bDebugMacros = True
        If InStr(Microsoft.VisualBasic.Command(), "-dt") <> 0 Then bDebugTilda = True

        If InStr(Microsoft.VisualBasic.Command(), "-v") <> 0 Then bVerbose = True

        If InStr(Microsoft.VisualBasic.Command(), "-c") <> 0 Then bTIFFCouleur = True

        Dim tsArg() As String
        tsArg = Split(Microsoft.VisualBasic.Command, " ".ToCharArray)

        Dim sNomficPCL As String = ""
        For Each s As String In tsArg
            If Left(s, 1) <> "-" Then
                If sNomficPCL = "" Then
                    sNomficPCL = s
                Else
                    sNomficImage = s
                End If
            End If
        Next

        If sNomficPCL = "" Then
            Console.WriteLine("Nom du fichier PCL non pr�cis�.")
            Exit Sub
        End If

        If sNomficImage = "" Then
            If StrComp(Right(sNomficPCL, 4), ".pcl", CompareMethod.Text) = 0 Then
                sNomficImage = Left(sNomficPCL, Len(sNomficPCL) - 4) & ".tif"
            Else
                sNomficImage = sNomficPCL & ".tif"
            End If
        End If
        If StrComp(Right(sNomficImage, 4), ".tif", CompareMethod.Text) <> 0 And StrComp(Right(sNomficImage, 5), ".tiff", CompareMethod.Text) <> 0 Then
            sNomficImage &= ".tif"
        End If

        Dim t As Single
        t = Microsoft.VisualBasic.DateAndTime.Timer
        PCLInitJob()
        If Not Analyse(sNomficPCL) Then Exit Sub
        PCLFlushText()
        PCLFlushPage()
        Console.WriteLine("�criture du fichier {0}", sNomficImage)
        RGOutput()
        t = Microsoft.VisualBasic.DateAndTime.Timer - t

        If bDebugMacros Then TraceMacros()
        If bVerbose Then Console.WriteLine("Fin, Nb Car: {0}, Durée analyse: {1:f1}s", nbCar, t)

        If bDebugMacros Or bDebugPCL Or bVerbose Or bDebugTilda Then
            Console.WriteLine("[Entr�e] pour continuer...")
            Console.ReadLine()
        End If
    End Sub

    Function Analyse(sNomFic As String) As Boolean
        Dim fs As FileStream
        Dim b As Byte
        Console.WriteLine("Analyse de {0}", sNomFic)
        Try
            fs = New FileStream(sNomFic, FileMode.Open, FileAccess.Read)
        Catch ex As Exception
            Console.WriteLine("Echec � l'ouverture de {0}: {1}", sNomFic, ex.Message)
            Return False
        End Try

        Dim r As New BinaryReader(fs)
        InitEtatPCL()
        Do
            Try
                b = r.ReadByte
            Catch
                Exit Do
            End Try
            nbCar += 1
            AnaPCL(b)
        Loop
        r.Close()
        fs.Close()
        Return True
    End Function

End Module

Module modDebug
    Public bDebugPCL As Boolean = False
    Public bDebugMacros As Boolean = False
    Public bVerbose As Boolean = False
    Public bDebugTilda As Boolean = False

    Public Sub TraceWrite(s As String)
        If bDebugPCL Then Console.Write(s)
    End Sub

    Public Sub TraceWrite(format As String, arg0 As Object)
        If bDebugPCL Then Console.Write(format, arg0)
    End Sub

    Public Sub TraceWrite(format As String, arg0 As Object, arg1 As Object)
        If bDebugPCL Then Console.Write(format, arg0, arg1)
    End Sub

    Public Sub TraceWriteLine()
        If bDebugPCL Then Console.WriteLine()
    End Sub

    Public Sub TraceWriteLine(s As String)
        If bDebugPCL Then Console.WriteLine(s)
    End Sub

    Public Sub TraceWriteLine(format As String, arg0 As Object)
        If bDebugPCL Then Console.WriteLine(format, arg0)
    End Sub

    Public Sub TraceWriteLine(format As String, arg0 As Object, arg1 As Object)
        If bDebugPCL Then Console.WriteLine(format, arg0, arg1)
    End Sub

    Public Sub TraceWriteLine(format As String, arg0 As Object, arg1 As Object, arg2 As Object)
        If bDebugPCL Then Console.WriteLine(format, arg0, arg1, arg2)
    End Sub

End Module