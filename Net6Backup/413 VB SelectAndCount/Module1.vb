﻿' 413 VB SelectAndCount
' 2011-10-23    PV

Module Module1

    Sub Main()
        Dim st As String = "absinthe anis armagnac bière byhrr champagne chartreuse cidre cocktail cointreau cognac gin marc martini pastis pernod picon rhum ricard suze vin vodka whisky"
        Dim n = st.Split(" ").Select(Function(s As String) (s.Length Mod 2) = 0).Count(AddressOf True.Equals)
        Console.WriteLine("Nb de noms de longueur paire: {0}", n)
        Dim n2 = st.Split(" ").Select(Function(s) s.StartsWith("c")).Count(AddressOf True.Equals)
        Console.WriteLine("Nb de noms commençant par c: {0}", n2)
        Console.ReadLine()
    End Sub

End Module