' App.vb
' Essais de la bibliothèque C# en VB
'
' 2001-02-03    PV
' 2012-02-25	PV		VS2010
' 2021-09-18 	PV		VS2022, Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9
' 2026-01-19	PV		Net10

Imports System.Console
Imports MaBibliotheque

Namespace EssaisILDasm
    Friend Class MyApp

        Public Shared Sub Main()

            MaClasseDerivee.MaMethodeStatique()

            Dim d As MaClasseDerivee
            d = New MaClasseDerivee()
            AddHandler d.Bip, AddressOf D_Bip

            ' Try+Catch
            Try
                MaClasseDerivee.TrucDangereux(35)
            Catch
                WriteLine("Echec a l'appel de d.TrucDangereux(35)")
            End Try

            Try
                MaClasseDerivee.TrucDangereux(0)
            Catch e As Exception
                WriteLine("Échec à l'appel de d.TrucDangereux(0): {0}", e.Message)
            End Try
            WriteLine()

            ' Appel de méthodes virtuelles
            ActionBase(d, 2)
            d.MyBaseAction()
            Dim b As New MaClasseDeBase(d)
            b.Action()
            WriteLine()

            ' Evénements
            d.MaMethodeBruyante1(3)
            ActionInterface(d)
            WriteLine()

            ' Indexers
            WriteLine("Index 0: {0}", d(0))
            WriteLine("Index ""A"": {0}", d("A"))
            WriteLine("Index 'A': {0}", d(CChar("A")))
            WriteLine("Index 3,4: {0}", d(3, 4))
            WriteLine("Index 3,""Z"": {0}", d(3, "Z"))
            WriteLine()

            ' Enum
            Dim j As Jour = Jour.Mardi
            WriteLine("j = {0}", j)
            j = CType(j + 1, Jour)
            WriteLine("j = {0}", j)
            WriteLine()

            ' Types valeur
            Dim x As DBInt = DBInt.op_Implicit(123)
            Dim y As DBInt = DBInt.Null
            Dim z As DBInt = DBInt.op_Addition(x, y)

            WriteLine("x = {0}", x)
            WriteLine("y = {0}", y)
            WriteLine("z = {0}", z)

            ReadLine()
        End Sub

        Protected Shared Sub ActionBase(b As MaClasseDeBase, iVal As Integer)
            b.MembreDeBase = iVal
            b.Action()
        End Sub

        Public Shared Sub ActionInterface(IMI As IMonInterface)
            IMI.MaMethodeBruyante1(1)
            IMI.MaMethodeBruyante2(1)
        End Sub

        Private Shared Sub D_Bip(e As Object, sMsg As String)
            WriteLine("D_Bip(): {0}", sMsg)
        End Sub

    End Class

End Namespace
