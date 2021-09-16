' App.vb
' Essais de la bibliothèque C# en VB
' 2001-02-03    PV
' 2012-02-25	PV  VS2010

Imports MaBibliotheque

Namespace EssaisILDasm

    Class MyApp

        Public Shared Sub Main()

            MaClasseDerivee.MaMethodeStatique()

            Dim d As MaClasseDerivee
            d = New MaClasseDerivee()
            AddHandler d.Bip, AddressOf D_Bip

            ' Try+Catch
            Try
                d.TrucDangereux(35)
            Catch
                Console.WriteLine("Echec a l'appel de d.TrucDangereux(35)")
            End Try

            Try
                d.TrucDangereux(0)
            Catch e As Exception
                Console.WriteLine("Échec à l'appel de d.TrucDangereux(0): {0}", e.Message)
            End Try
            Console.WriteLine()

            ' Appel de méthodes virtuelles
            ActionBase(d, 2)
            d.MyBaseAction()
            Dim b As MaClasseDeBase = New MaClasseDeBase(d)
            b.Action()
            Console.WriteLine()

            ' Evénements
            d.MaMethodeBruyante1(3)
            ActionInterface(d)
            Console.WriteLine()

            ' Indexers
            Console.WriteLine("Index 0: {0}", d(0))
            Console.WriteLine("Index ""A"": {0}", d("A"))
            Console.WriteLine("Index 'A': {0}", d(CChar("A")))
            Console.WriteLine("Index 3,4: {0}", d(3, 4))
            Console.WriteLine("Index 3,""Z"": {0}", d(3, "Z"))
            Console.WriteLine()

            ' Enum
            Dim j As Jour = Jour.Mardi
            Console.WriteLine("j = {0}", j)
            j = CType(j + 1, Jour)
            Console.WriteLine("j = {0}", j)
            Console.WriteLine()

            ' Types valeur
            Dim x As DBInt = DBInt.op_Implicit(123)
            Dim y As DBInt = DBInt.Null
            Dim z As DBInt = DBInt.op_Addition(x, y)

            Console.WriteLine("x = {0}", x)
            Console.WriteLine("y = {0}", y)
            Console.WriteLine("z = {0}", z)

            Console.ReadLine()
        End Sub

        Protected Shared Sub ActionBase(b As MaClasseDeBase, iVal As Integer)
            b.MembreDeBase = iVal
            b.Action()
        End Sub

        Public Shared Sub ActionInterface(IMI As MonInterface)
            IMI.MaMethodeBruyante1(1)
            IMI.MaMethodeBruyante2(1)
        End Sub

        Private Shared Sub D_Bip(e As Object, sMsg As String)
            Console.WriteLine("D_Bip(): {0}", sMsg)
        End Sub

    End Class

End Namespace