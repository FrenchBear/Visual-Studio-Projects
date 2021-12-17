' modPCL - Analyseur PCL du convertisseur PCL -> TIF
' 2003-07-17    PV
' 2003-08-07    PV  Gestion des s�quences ~()
' 2012-02-25	PV  VS2010
' 2017-05-02    PV  GitHub et VS2017
' 2021-09-19    PV  VS2022, Net6

Module modPCL

    Enum EtatPCL
        epclPrint
        epclEscape
        epclEscapeEt
        epclEscapeParOuvr
        epclEscapeEtoile
        epclData38pX
        epclData40sW
        epclData42gW
        epclData42bW
        epclData42bV
        epclTilda
        epclTildaParOuvr
    End Enum

    Dim epclEtat As EtatPCL                 ' Etat courant de l'automate

    Dim epclNextEtat As EtatPCL
    Dim iDataCount As Integer               ' Nb d'octets de s�quences de donn�es
    Dim sFactor As String                   ' Facteur de r�p�tition des commandes PCL
    Dim bMainFunction As Byte               ' Fonction qui suit imm�diatement Esc */&/(
    Private tbData() As Byte                ' Flot de donn�es transparentes

    Sub InitEtatPCL()
        epclEtat = EtatPCL.epclPrint
        iDataCount = 0
    End Sub

    Sub AnaPCL(b As Byte)
        If bLearningMacro Then
            PCLLearn(b)
        End If

        Select Case epclEtat
            Case EtatPCL.epclPrint
                If b = 27 Then
                    epclEtat = EtatPCL.epclEscape
                    If Not bLearningMacro Then PCLFlushText()
                ElseIf b = 126 Then   ' Tilda
                    epclEtat = EtatPCL.epclTilda
                Else
                    If Not bLearningMacro Then PCLPrint(b)
                End If

            Case EtatPCL.epclTilda
                If b = 40 Then        ' Parenth�se ouvrante
                    epclEtat = EtatPCL.epclTildaParOuvr
                    If Not bLearningMacro Then
                        PCLFlushText()
                        TildaClearBuffer()
                    End If
                Else
                    epclEtat = EtatPCL.epclPrint
                    If Not bLearningMacro Then
                        PCLPrint(126)     ' Tilda
                        PCLPrint(b)
                    End If
                End If

            Case EtatPCL.epclTildaParOuvr
                If b = 41 Then        ' Parenth�se fermante
                    epclEtat = EtatPCL.epclPrint
                    If Not bLearningMacro Then TildaExecute()
                Else
                    If Not bLearningMacro Then TildaLearn(b)
                End If

            Case EtatPCL.epclEscape
                If b = 38 Then
                    epclEtat = EtatPCL.epclEscapeEt
                    InitPCLEscape()
                    bMainFunction = Asc("?")
                ElseIf b = 40 Then
                    InitPCLEscape()
                    epclEtat = EtatPCL.epclEscapeParOuvr
                    bMainFunction = Asc("?")
                ElseIf b = 42 Then
                    InitPCLEscape()
                    epclEtat = EtatPCL.epclEscapeEtoile
                    bMainFunction = Asc("?")
                ElseIf b = 57 Then     ' Esc 9 ???
                    epclEtat = EtatPCL.epclPrint
                    ' On mange le caract�re et on revient en mode print
                Else
                    Stop
                End If

            Case EtatPCL.epclData38pX, EtatPCL.epclData40sW, EtatPCL.epclData42gW, EtatPCL.epclData42bW, EtatPCL.epclData42bV
                If Not bLearningMacro Then tbData(tbData.GetLength(0) - iDataCount) = b
                iDataCount -= 1
                If iDataCount = 0 Then
                    ' On traite les donn�es
                    If Not bLearningMacro Then
                        Select Case epclEtat
                            Case EtatPCL.epclData42bW : PCL42bWData(tbData)
                            Case Else
                                PCLError("S�quence de donn�es transparente {0} non prise en charge", epclEtat.ToString)
                        End Select
                    End If
                    ' retour � l'�tat epclPrint
                    epclEtat = EtatPCL.epclPrint
                End If

            Case EtatPCL.epclEscapeEt, EtatPCL.epclEscapeEtoile, EtatPCL.epclEscapeParOuvr
                AnaPCLEscape(b)
        End Select
    End Sub

    Sub InitPCLEscape()
        sFactor = ""
    End Sub

    Sub AnaPCLEscape(b As Byte)
        If b >= Asc("0") And b <= Asc("9") Or b = Asc(".") Or b = Asc("+") Or b = Asc("-") Then
            sFactor &= Chr(b)
            Exit Sub
        End If

        ' Cas d'une s�quence termin�e par une minuscule suivie de Echap ou Entr�e ou EOF (0x1b=26) -> on resynchronise en silence
        If b = 27 Then
            epclEtat = EtatPCL.epclEscape
            Exit Sub
        End If
        If b = 13 Or b = 26 Then
            epclEtat = EtatPCL.epclPrint
            If b <> 26 Then If Not bLearningMacro Then PCLPrint(b)
            Exit Sub
        End If

        ' Si majuscule, on passe � l'�tat print � la fin de la fonction
        ' (sauf si la fonction d�cide de passer en mode data)
        If b >= Asc("@") And b <= Asc("Z") Then
            epclNextEtat = EtatPCL.epclPrint
        Else
            epclNextEtat = epclEtat
        End If

        If b >= Asc("a") And b <= Asc("z") Then b -= 32
        If b >= Asc("@") And b <= Asc("Z") Then
            PCLFunction(epclEtat, Chr(bMainFunction), Chr(b), sFactor)
            InitPCLEscape()
        Else
            PCLError("Fonction PCL <Esc>" & Chr(bMainFunction) & Chr(b) & " inconnue")
        End If

        ' bMainFunction est d�fini apr�s le traitement de cette m�me fonction, et en minuscules
        If bMainFunction = Asc("?") Then
            bMainFunction = b
            If b >= Asc("@") And b <= Asc("Z") Then bMainFunction += 32
        End If

        epclEtat = epclNextEtat
    End Sub

    Sub PCLFunction(epclEtat As EtatPCL, cMainFunction As Char, cFunction As Char, sFactor As String)
        TraceWrite("<Esc>")
        Select Case epclEtat
            Case EtatPCL.epclEscapeEt : TraceWrite("&")
            Case EtatPCL.epclEscapeParOuvr : TraceWrite("(")
            Case EtatPCL.epclEscapeEtoile : TraceWrite("*")
            Case Else : Stop
        End Select
        If cMainFunction <> "?" Then TraceWrite(cMainFunction)
        TraceWrite("{0}{1} ", sFactor, cFunction)

        ' En mode m�morisation de macro, la seule s�quence interpret�e est la fin d'enregistrement, <Esc>&f1X
        If bLearningMacro Then
            If epclEtat = EtatPCL.epclEscapeEt And cMainFunction = "f"c And cFunction = "X"c And Val(sFactor) = 1 Then
                PCLStopLearning()
            End If
        Else
            Select Case epclEtat
                Case EtatPCL.epclEscapeEt : PCL38(cMainFunction, cFunction, sFactor)
                Case EtatPCL.epclEscapeParOuvr : PCL40(cMainFunction, cFunction, sFactor)
                Case EtatPCL.epclEscapeEtoile : PCL42(cMainFunction, cFunction, sFactor)
                Case Else : Stop
            End Select
        End If

        TraceWriteLine()

        'cas des s�quences suivies d'un flot d'octets
        If epclEtat = EtatPCL.epclEscapeEt And cMainFunction = "p" And cFunction = "X" Or
           epclEtat = EtatPCL.epclEscapeParOuvr And cMainFunction = "s" And cFunction = "W" Or
           epclEtat = EtatPCL.epclEscapeEtoile And cMainFunction = "g" And cFunction = "W" Or
           epclEtat = EtatPCL.epclEscapeEtoile And cMainFunction = "b" And cFunction = "W" Or
           epclEtat = EtatPCL.epclEscapeEtoile And cMainFunction = "b" And cFunction = "V" _
           Then
            iDataCount = Val(sFactor)

            If iDataCount <= 0 Then
                PCLError("S�quence data " & cMainFunction & cFunction & " de longueur 0")
                Exit Sub    ' On ne change pas d'�tat
            End If

            Select Case cMainFunction & cFunction
                Case "pX" : epclNextEtat = EtatPCL.epclData38pX
                Case "sW" : epclNextEtat = EtatPCL.epclData40sW
                Case "gW" : epclNextEtat = EtatPCL.epclData42gW
                Case "bW" : epclNextEtat = EtatPCL.epclData42bW
                Case "bV" : epclNextEtat = EtatPCL.epclData42bV
                Case Else : Stop
            End Select

            TraceWriteLine("<{0} octets de donn�es>", iDataCount)
            If Not bLearningMacro Then ReDim tbData(iDataCount - 1)

        End If
    End Sub

    ' Fonctions Esc &
    Sub PCL38(cMainFunction As Char, cFunction As Char, sFactor As String)
        Select Case cMainFunction & cFunction
            Case "?F" : PCL38F()
            Case "fY" : PCL38fY(Val(sFactor))
            Case "fX" : PCL38fX(Val(sFactor))
            Case "?A" : PCL38A()
            Case "aH" : PCL38aH(sFactor)
            Case "aV" : PCL38aV(sFactor)
            Case "aL" : PCL38aL(Val(sFactor))
            Case "?L" : PCL38L()
            Case "lX" : PCL38lX(Val(sFactor))
            Case "lD" : PCL38lD(Val(sFactor))
            Case "lP" : PCL38lP(Val(sFactor))
            Case "lU" : PCL38lU(Val(sFactor))
            Case "lZ" : PCL38lZ(Val(sFactor))
            Case "lE" : PCL38lE(Val(sFactor))
            Case "lL" : PCL38lL(Val(sFactor))
            Case "?D" : PCL38D()
            Case "dD" : PCL38dD(Val(sFactor))
            Case "d@" : PCL38dArobas()
            Case Else
                PCLError("PCL38: Fonction <Esc>&" & cMainFunction & sFactor & cFunction & " non trait�e")
        End Select
    End Sub

    ' Fonctions Esc (
    Sub PCL40(cMainFunction As Char, cFunction As Char, sFactor As String)
        Select Case cMainFunction & cFunction
            Case "?U" : PCL40U(Val(sFactor))
            Case "?S" : PCL40S()
            Case "sP" : PCL40sP(Val(sFactor))
            Case "sH" : PCL40sH(Val(sFactor))
            Case "sV" : PCL40sV(Val(sFactor))
            Case "sB" : PCL40sB(Val(sFactor))
            Case "sS" : PCL40sS(Val(sFactor))
            Case "sT" : PCL40sT(Val(sFactor))
            Case Else
                PCLError("PCL40: Fonction <Esc>(" & cMainFunction & sFactor & cFunction & " non trait�e")
        End Select
    End Sub

    ' Fonctions Esc *
    Sub PCL42(cMainFunction As Char, cFunction As Char, sFactor As String)
        Select Case cMainFunction & cFunction
            Case "?C" : PCL42C()
            Case "cA" : PCL42cA(Val(sFactor))
            Case "cB" : PCL42cB(Val(sFactor))
            Case "cH" : PCL42cH(Val(sFactor))
            Case "cV" : PCL42cV(Val(sFactor))
            Case "cP" : PCL42cP(Val(sFactor))
            Case "?T" : PCL42T()
            Case "tR" : PCL42tR(Val(sFactor))
            Case "?R" : PCL42R()
            Case "rA" : PCL42rA(Val(sFactor))
            Case "rB" : PCL42rB()
            Case "rS" : PCL42rS(Val(sFactor))
            Case "rT" : PCL42rT(Val(sFactor))
            Case "?B" : PCL42B()
            Case "bW" : PCL42bW(Val(sFactor))
            Case "?P" : PCL42P()
            Case "pX" : PCL42pX(Val(sFactor))
            Case "pY" : PCL42pY(Val(sFactor))
            Case Else
                PCLError("PCL42: Fonction <Esc>*" & cMainFunction & sFactor & cFunction & " non trait�e")
        End Select
    End Sub

End Module

Module modMacros
    Public bLearningMacro As Boolean

    Private Class PCLMacro
        Public sMacroText As New Text.StringBuilder
        Public bIsRunning As Boolean
    End Class

    Private macCurrentMacro As PCLMacro   ' macro en cours d'enregistrement
    Private iMacroID As Integer           ' dernier ID rencontr�
    Private ReadOnly colMacros As New Hashtable    ' Macros stock�es en m�moire

    Sub PCLLearn(b As Byte)
        Debug.Assert(bLearningMacro = True)
        macCurrentMacro.sMacroText.Append(Chr(b))
    End Sub

    Sub PCLStopLearning()
        If bDebugMacros Then WriteLine("Fin enregistrement macro")
        bLearningMacro = False
        macCurrentMacro = Nothing
    End Sub

    ' <Esc>&F
    Sub PCL38F()
        TraceWrite("[Info: <Esc>&f]")
    End Sub

    ' <Esc>&f#Y
    Sub PCL38fY(iId As Integer)
        TraceWrite("[Macros ID #{0}]", iId)
        iMacroID = iId
    End Sub

    ' <Esc>&f#X
    Sub PCL38fX(iFonction As Integer)
        Select Case iFonction
            Case 0
                TraceWrite("[Macro: Start Macro Def.]")
                If bDebugMacros Then WriteLine("D�but enregistrement macro {0}", iMacroID)
                If colMacros.ContainsKey(iMacroID) Then
                    If bDebugMacros Then WriteLine("Effacement de la pr�c�dente macro {0}", iMacroID)
                    colMacros.Remove(iMacroID)
                End If
                macCurrentMacro = New PCLMacro
                colMacros.Add(iMacroID, macCurrentMacro)
                bLearningMacro = True

            Case 1 : TraceWrite("[Macro: Stop Macro Def.]")
        ' Rien puisqu'on n'est pas en mode learning

            Case 2 : TraceWrite("[Macro: Execute Macro]")
                ' M�morise �tat
                RunMacro("Execute")
        ' Restaure etat

            Case 3 : TraceWrite("[Macro: Call Macro]")
                RunMacro("Call")

            Case 4 : TraceWrite("[Macro: Enable Overlay]")
            Case 5 : TraceWrite("[Macro: Disable Overlay]")
            Case 6 : TraceWrite("[Macro: Delete All Macros]")
            Case 7 : TraceWrite("[Macro: Delete All Temp Macros]")
            Case 8 : TraceWrite("[Macro: Delete Macros Id]")
            Case 9 : TraceWrite("[Macro: Make Temporary]")
            Case 10 : TraceWrite("[Macro: Make Permanent]")
        End Select
    End Sub

    ' Ex�cute une macro
    Private Sub RunMacro(sAction As String)
        Dim m As PCLMacro
        Dim iId As Integer = iMacroID
        If bDebugMacros Then WriteLine("D�but {0} macro {1}", sAction, iMacroID)
        m = CType(colMacros(iMacroID), PCLMacro)
        If m.bIsRunning Then
            PCLError("Blocage anti-r�cursivit� !")
            Exit Sub
        End If
        m.bIsRunning = True
        For i As Integer = 0 To m.sMacroText.Length - 1
            AnaPCL(Asc(m.sMacroText.Chars(i)))
        Next
        If bDebugMacros Then WriteLine("Fin {0} macro {1}", sAction, iId)
        m.bIsRunning = False
    End Sub

    ' Liste les IDs de macros et leur taille
    Public Sub TraceMacros()
        Dim myEnumerator As IDictionaryEnumerator = colMacros.GetEnumerator()
        WriteLine("Macro Size")
        While (myEnumerator.MoveNext())
            WriteLine("{0}     {1}", myEnumerator.Key, CType(myEnumerator.Value, PCLMacro).sMacroText.Length)
        End While
    End Sub

End Module

Module modPCLError

    Sub PCLError(s As String)
        WriteLine("Erreur PCL pos {0}: {1}", GetPosition, s)
    End Sub

    Sub PCLError(format As String, arg0 As Object)
        Console.Write("Erreur PCL pos {0}: ", GetPosition)
        WriteLine(format, arg0)
    End Sub

End Module

Module modTilda
    Dim sTildaText As System.Text.StringBuilder

    Sub TildaClearBuffer()
        sTildaText = New Text.StringBuilder
    End Sub

    Sub TildaLearn(b As Byte)
        sTildaText.Append(Chr(b))
    End Sub

    Sub TildaExecute()
        If bDebugTilda Then WriteLine("<Ex�cution s�quence tilda '{0}'>", sTildaText.ToString)
        Dim tsCmd() As String = Split(sTildaText.ToString, " ".ToCharArray)
        Select Case LCase(tsCmd(0))
            Case "photo"
                PCLTildaIns�rePhoto(tsCmd(1))

            Case Else
                PCLError("Commade tilda inconnue: {0}", sTildaText.ToString)
        End Select

    End Sub

End Module