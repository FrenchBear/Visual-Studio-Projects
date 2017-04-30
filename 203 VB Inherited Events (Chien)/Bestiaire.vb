Module MainModule
    Dim WithEvents rex As Chien

    Sub Main()
        rex = New Chien("Médor")
        rex.Exciter()
        rex.Enerver()
        rex = Nothing

        Dim mChiens As New Meute(Of Chien)(New Chien("Athos"))
        mChiens.Add(New Chien("Pollux"))
        mChiens.Add(New Chien("Titus"))
        mChiens.Add(New Chiot("Pif"))
        mChiens.Enerver()

        Dim a1, a2 As Animal
        a1 = New Chien("Athos")
        a2 = New Chiot("Pif")

        a1.Crier()
        a2.Crier()

        a1.Jouer()
        a2.Jouer()

        a1.Lécher()
        a2.Lécher()

        Console.WriteLine()
        Console.Write("(Pause)")
        Console.ReadLine()
    End Sub

    Private Sub Rex_Aboyer() Handles rex.Aboyer
        Console.WriteLine("Rex aboie")
    End Sub

    Private Sub Rex_Meurt() Handles rex.Meurt
        Console.WriteLine("Rex est mort")
    End Sub

    Private Sub Rex_Mordre() Handles rex.Mordre
        Console.WriteLine("Rex a mordu")
    End Sub

    Private Sub Rex_Nait() Handles rex.Nait
        Console.WriteLine("Rex est né le " & rex.NéLe)
    End Sub
End Module


Public MustInherit Class EtreVivant
    Public NéLe As Date
    Event Nait()
    Event Meurt()

    Protected Sub New()
        NéLe = Now
        RaiseEvent Nait()
    End Sub

    Protected Overrides Sub Finalize()
        RaiseEvent Meurt()
    End Sub

    Private Sub EtreVivant_Meurt() Handles Me.Meurt
        Console.WriteLine("Un être vivant est mort")
    End Sub

    Private Sub EtreVivant_Nait() Handles Me.Nait
        Console.WriteLine("Un être vivant est né")
    End Sub
End Class


Public Class Animal : Inherits EtreVivant
    Public Race As String
    Event Mordre()

    Public Sub New(ByVal sRace As String)
        MyBase.New()
        Race = sRace
    End Sub

    Sub Enerver()
        RaiseEvent Mordre()
    End Sub

    Overridable Sub Crier()
        Console.WriteLine("Un animal de race " & Race & " crie.")
    End Sub

    Overridable Sub Lécher()
        Console.WriteLine("Un animal de race " & Race & " lèche.")
    End Sub

    Sub Jouer()
        Console.WriteLine("Un animal de race " & Race & " joue.")
    End Sub


    Private Sub Animal_Meurt() Handles Me.Meurt
        Console.WriteLine("Un animal de race " & Race & " est mort")
    End Sub

    Private Sub Animal_Mordre() Handles Me.Mordre
        Console.WriteLine("Un animal de race " & Race & " a mordu")
    End Sub

    Private Sub Animal_Nait() Handles Me.Nait
        Console.WriteLine("Un animal de race " & Race & " est né")
    End Sub
End Class


Public Class Chien : Inherits Animal
    Sub New(ByVal sNom As String)
        MyBase.New("Canis")
        Nom = sNom
    End Sub

    Protected Nom As String

    Event Aboyer()

    Sub Exciter()
        RaiseEvent Aboyer()
    End Sub

    Overrides Sub Crier()
        Console.WriteLine(Nom & ": Wouaf !")
    End Sub

    NotOverridable Overrides Sub Lécher()
        Console.WriteLine("Le chien " & Nom & " lèche")
    End Sub

    Overloads Sub Jouer()
        Console.WriteLine("Le chien " & Nom & " joue.")
    End Sub


    Private Sub Chien_Aboyer() Handles Me.Aboyer
        Console.WriteLine("Le chien " & Nom & " a aboyé")
    End Sub

    Private Sub Chien_Meurt() Handles Me.Meurt
        Console.WriteLine("Le chien " & Nom & " est mort")
    End Sub

    Private Sub Chien_Mordre() Handles Me.Mordre
        Console.WriteLine("Le chien " & Nom & " a mordu")
    End Sub

    Private Sub Chien_Nait() Handles Me.Nait
        Console.WriteLine("Le chien " & Nom & " est né")
    End Sub
End Class


Class Chiot : Inherits Chien
    Sub New(ByVal sNom As String)
        MyBase.New(sNom)
    End Sub

    Overrides Sub Crier()
        Console.WriteLine(Nom & ": Wif !  Wif !")
    End Sub

    'Overrides Sub Lécher()
    '    Console.WriteLine("Le chiot " & nom & " lèche")
    'End Sub

    Overloads Sub Jouer()
        Console.WriteLine("Le chiot " & Nom & " joue.")
    End Sub
End Class


Friend Class Loup : Inherits Animal
    Sub New()
        MyBase.New("Lupus")
    End Sub
End Class