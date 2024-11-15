' AnalyseUsers
' Analyse les comptes utilisateur dans AD
'
' 2004-02-12    PV
' 2006-10-01 	PV		VS 2005
' 2021-09-19 	PV		VS2022; Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9

Imports System.ComponentModel
Imports System.Text
Imports VB = Microsoft.VisualBasic

#Disable Warning IDE1006 ' Naming Styles

Public Class frmAnalyseUsers
    Inherits Form

#Region " Code généré par le Concepteur Windows Form "

    Public Sub New()
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        Visible = True

        'Ajoutez une initialisation quelconque après l'appel InitializeComponent()
        AcceptButton = btnAnalyse
    End Sub

    'La méthode substituée Dispose du formulaire pour nettoyer la liste des composants.
    Protected Overloads Overrides Sub Dispose(disposing As Boolean)
        If disposing Then
            components?.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    Private components As Container

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée en utilisant le Concepteur Windows Form.
    'Ne la modifiez pas en utilisant l'éditeur de code.
    Friend WithEvents lblAnalyse As Label

    Friend WithEvents btnAnalyse As Button
    Friend WithEvents txtSite As TextBox
    Friend WithEvents lblLégende As Label
    Friend WithEvents lvUsers As ListView
    Friend WithEvents chCN As ColumnHeader
    Friend WithEvents chAccount As ColumnHeader
    Friend WithEvents chOU As ColumnHeader
    Friend WithEvents chRemarques As ColumnHeader
    Friend WithEvents gbTester As GroupBox
    Friend WithEvents chkScriptOuverture As CheckBox
    Friend WithEvents chkCompteDésactivé As CheckBox
    Friend WithEvents chkChangeMDPInterdit As CheckBox
    Friend WithEvents chkMdPExpiré As CheckBox
    Friend WithEvents chkGrpfr_allusers_g As CheckBox
    Friend WithEvents chkGrpSite As CheckBox
    Friend WithEvents chkGrpBusiness As CheckBox
    Friend WithEvents chkCompteVerrouillé As CheckBox
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents sbStatus As ToolStripStatusLabel
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents cmdCopie As ToolStripMenuItem
    Friend WithEvents chkMdpPeutExpirer As CheckBox

    <DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New Container()
        Dim resources As New ComponentResourceManager(GetType(frmAnalyseUsers))
        btnAnalyse = New Button()
        lblAnalyse = New Label()
        txtSite = New TextBox()
        lblLégende = New Label()
        lvUsers = New ListView()
        chCN = New ColumnHeader()
        chOU = New ColumnHeader()
        chAccount = New ColumnHeader()
        chRemarques = New ColumnHeader()
        gbTester = New GroupBox()
        chkMdpPeutExpirer = New CheckBox()
        chkCompteVerrouillé = New CheckBox()
        chkGrpBusiness = New CheckBox()
        chkGrpSite = New CheckBox()
        chkGrpfr_allusers_g = New CheckBox()
        chkMdPExpiré = New CheckBox()
        chkChangeMDPInterdit = New CheckBox()
        chkCompteDésactivé = New CheckBox()
        chkScriptOuverture = New CheckBox()
        StatusStrip1 = New StatusStrip()
        sbStatus = New ToolStripStatusLabel()
        ContextMenuStrip1 = New ContextMenuStrip(components)
        cmdCopie = New ToolStripMenuItem()
        gbTester.SuspendLayout()
        StatusStrip1.SuspendLayout()
        ContextMenuStrip1.SuspendLayout()
        SuspendLayout()
        '
        'btnAnalyse
        '
        btnAnalyse.Location = New Point(552, 15)
        btnAnalyse.Name = "btnAnalyse"
        btnAnalyse.Size = New Size(150, 42)
        btnAnalyse.TabIndex = 2
        btnAnalyse.Text = "&Analyser"
        '
        'lblAnalyse
        '
        lblAnalyse.AutoSize = True
        lblAnalyse.Location = New Point(8, 22)
        lblAnalyse.Name = "lblAnalyse"
        lblAnalyse.Size = New Size(239, 25)
        lblAnalyse.TabIndex = 0
        lblAnalyse.Text = "Site à analyser dans fr :"
        '
        'txtSite
        '
        txtSite.Location = New Point(264, 15)
        txtSite.Name = "txtSite"
        txtSite.Size = New Size(272, 31)
        txtSite.TabIndex = 1
        '
        'lblLégende
        '
        lblLégende.AutoSize = True
        lblLégende.Location = New Point(8, 59)
        lblLégende.Name = "lblLégende"
        lblLégende.Size = New Size(61, 25)
        lblLégende.TabIndex = 3
        lblLégende.Text = "ou=fr"
        '
        'lvUsers
        '
        lvUsers.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom _
            Or AnchorStyles.Left _
            Or AnchorStyles.Right
        lvUsers.Columns.AddRange((New ColumnHeader() {chCN, chOU, chAccount, chRemarques}))
        lvUsers.HideSelection = False
        lvUsers.Location = New Point(8, 207)
        lvUsers.Name = "lvUsers"
        lvUsers.Size = New Size(1461, 350)
        lvUsers.TabIndex = 4
        lvUsers.UseCompatibleStateImageBehavior = False
        lvUsers.View = View.Details
        '
        'chCN
        '
        chCN.Text = "CN"
        chCN.Width = 141
        '
        'chOU
        '
        chOU.Text = "OU"
        chOU.Width = 111
        '
        'chAccount
        '
        chAccount.Text = "Account"
        chAccount.Width = 135
        '
        'chRemarques
        '
        chRemarques.Text = "Remarques"
        chRemarques.Width = 307
        '
        'gbTester
        '
        gbTester.Controls.Add(chkMdpPeutExpirer)
        gbTester.Controls.Add(chkCompteVerrouillé)
        gbTester.Controls.Add(chkGrpBusiness)
        gbTester.Controls.Add(chkGrpSite)
        gbTester.Controls.Add(chkGrpfr_allusers_g)
        gbTester.Controls.Add(chkMdPExpiré)
        gbTester.Controls.Add(chkChangeMDPInterdit)
        gbTester.Controls.Add(chkCompteDésactivé)
        gbTester.Controls.Add(chkScriptOuverture)
        gbTester.Location = New Point(712, 7)
        gbTester.Name = "gbTester"
        gbTester.Size = New Size(752, 185)
        gbTester.TabIndex = 6
        gbTester.TabStop = False
        gbTester.Text = "&Tester"
        '
        'chkMdpPeutExpirer
        '
        chkMdpPeutExpirer.Location = New Point(8, 148)
        chkMdpPeutExpirer.Name = "chkMdpPeutExpirer"
        chkMdpPeutExpirer.Size = New Size(312, 29)
        chkMdpPeutExpirer.TabIndex = 8
        chkMdpPeutExpirer.Text = "MdP peut expirer"
        '
        'chkCompteVerrouillé
        '
        chkCompteVerrouillé.Checked = True
        chkCompteVerrouillé.CheckState = CheckState.Checked
        chkCompteVerrouillé.Location = New Point(344, 30)
        chkCompteVerrouillé.Name = "chkCompteVerrouillé"
        chkCompteVerrouillé.Size = New Size(312, 29)
        chkCompteVerrouillé.TabIndex = 7
        chkCompteVerrouillé.Text = "Compte verrouillé"
        '
        'chkGrpBusiness
        '
        chkGrpBusiness.Checked = True
        chkGrpBusiness.CheckState = CheckState.Checked
        chkGrpBusiness.Location = New Point(344, 118)
        chkGrpBusiness.Name = "chkGrpBusiness"
        chkGrpBusiness.Size = New Size(384, 30)
        chkGrpBusiness.TabIndex = 6
        chkGrpBusiness.Text = "Attaché à 1 groupe business"
        '
        'chkGrpSite
        '
        chkGrpSite.Checked = True
        chkGrpSite.CheckState = CheckState.Checked
        chkGrpSite.Location = New Point(344, 89)
        chkGrpSite.Name = "chkGrpSite"
        chkGrpSite.Size = New Size(384, 29)
        chkGrpSite.TabIndex = 5
        chkGrpSite.Text = "Attaché à 1 groupe site"
        '
        'chkGrpfr_allusers_g
        '
        chkGrpfr_allusers_g.Checked = True
        chkGrpfr_allusers_g.CheckState = CheckState.Checked
        chkGrpfr_allusers_g.Location = New Point(344, 59)
        chkGrpfr_allusers_g.Name = "chkGrpfr_allusers_g"
        chkGrpfr_allusers_g.Size = New Size(384, 30)
        chkGrpfr_allusers_g.TabIndex = 4
        chkGrpfr_allusers_g.Text = "Attaché au groupe fr_allusers_g"
        '
        'chkMdPExpiré
        '
        chkMdPExpiré.Checked = True
        chkMdPExpiré.CheckState = CheckState.Checked
        chkMdPExpiré.Location = New Point(8, 118)
        chkMdPExpiré.Name = "chkMdPExpiré"
        chkMdPExpiré.Size = New Size(312, 30)
        chkMdPExpiré.TabIndex = 3
        chkMdPExpiré.Text = "MdP expiré"
        '
        'chkChangeMDPInterdit
        '
        chkChangeMDPInterdit.Checked = True
        chkChangeMDPInterdit.CheckState = CheckState.Checked
        chkChangeMDPInterdit.Location = New Point(8, 89)
        chkChangeMDPInterdit.Name = "chkChangeMDPInterdit"
        chkChangeMDPInterdit.Size = New Size(312, 29)
        chkChangeMDPInterdit.TabIndex = 2
        chkChangeMDPInterdit.Text = "Changement MdP interdit"
        '
        'chkCompteDésactivé
        '
        chkCompteDésactivé.Checked = True
        chkCompteDésactivé.CheckState = CheckState.Checked
        chkCompteDésactivé.Location = New Point(8, 59)
        chkCompteDésactivé.Name = "chkCompteDésactivé"
        chkCompteDésactivé.Size = New Size(248, 30)
        chkCompteDésactivé.TabIndex = 1
        chkCompteDésactivé.Text = "Compte désactivé"
        '
        'chkScriptOuverture
        '
        chkScriptOuverture.Checked = True
        chkScriptOuverture.CheckState = CheckState.Checked
        chkScriptOuverture.Location = New Point(8, 30)
        chkScriptOuverture.Name = "chkScriptOuverture"
        chkScriptOuverture.Size = New Size(248, 29)
        chkScriptOuverture.TabIndex = 0
        chkScriptOuverture.Text = "Script d'ouverture"
        '
        'StatusStrip1
        '
        StatusStrip1.ImageScalingSize = New Size(32, 32)
        StatusStrip1.Items.AddRange(New ToolStripItem() {sbStatus})
        StatusStrip1.Location = New Point(0, 591)
        StatusStrip1.Name = "StatusStrip1"
        StatusStrip1.Size = New Size(1477, 22)
        StatusStrip1.TabIndex = 7
        StatusStrip1.Text = "StatusStrip1"
        '
        'sbStatus
        '
        sbStatus.Name = "sbStatus"
        sbStatus.Size = New Size(1462, 12)
        sbStatus.Spring = True
        '
        'ContextMenuStrip1
        '
        ContextMenuStrip1.ImageScalingSize = New Size(32, 32)
        ContextMenuStrip1.Items.AddRange(New ToolStripItem() {cmdCopie})
        ContextMenuStrip1.Name = "ContextMenuStrip1"
        ContextMenuStrip1.Size = New Size(301, 86)
        '
        'cmdCopie
        '
        cmdCopie.Name = "cmdCopie"
        cmdCopie.Size = New Size(300, 38)
        cmdCopie.Text = "Copie liste entière"
        '
        'frmAnalyseUsers
        '
        AutoScaleBaseSize = New Size(10, 24)
        ClientSize = New Size(1477, 613)
        Controls.Add(StatusStrip1)
        Controls.Add(gbTester)
        Controls.Add(lvUsers)
        Controls.Add(lblLégende)
        Controls.Add(txtSite)
        Controls.Add(lblAnalyse)
        Controls.Add(btnAnalyse)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "frmAnalyseUsers"
        Text = "Analyse les objets User dans AD"
        gbTester.ResumeLayout(False)
        StatusStrip1.ResumeLayout(False)
        StatusStrip1.PerformLayout()
        ContextMenuStrip1.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()

    End Sub

#End Region

    ' Point de départ de l'analyse
    Private Const sStartOU As String = "ou=fr,dc=eame,dc=global,dc=sgs,dc=com"

    ' Liste des code-sites définis dans Workstations & Printers
    Private slSites As SortedList

    ' Liste des groupes business
    Private ReadOnly tsBusiness As String() = New String() {"agr", "aud", "fin", "hr", "ind", "it", "lab", "lgl", "lif", "mgt", "min", "ogc", "ssc cts", "tas"}

    ' Attributs de comptes. Piqué sur http://msdn.microsoft.com/library/default.asp?url=/library/en-us/adsi/adsi/ads_user_flag_enum.asp
    Public Enum ADS_USER_FLAG_ENUM
        ADS_UF_SCRIPT = &H1
        ADS_UF_ACCOUNTDISABLE = &H2
        ADS_UF_HOMEDIR_REQUIRED = &H8
        ADS_UF_LOCKOUT = &H10
        ADS_UF_PASSWD_NOTREQD = &H20
        ADS_UF_PASSWD_CANT_CHANGE = &H40
        ADS_UF_ENCRYPTED_TEXT_PASSWORD_ALLOWED = &H80
        ADS_UF_TEMP_DUPLICATE_ACCOUNT = &H100
        ADS_UF_NORMAL_ACCOUNT = &H200
        ADS_UF_INTERDOMAIN_TRUST_ACCOUNT = &H800
        ADS_UF_WORKSTATION_TRUST_ACCOUNT = &H1000
        ADS_UF_SERVER_TRUST_ACCOUNT = &H2000
        ADS_UF_DONT_EXPIRE_PASSWD = &H10000
        ADS_UF_MNS_LOGON_ACCOUNT = &H20000
        ADS_UF_SMARTCARD_REQUIRED = &H40000
        ADS_UF_TRUSTED_FOR_DELEGATION = &H80000
        ADS_UF_NOT_DELEGATED = &H100000
        ADS_UF_USE_DES_KEY_ONLY = &H200000
        ADS_UF_DONT_REQUIRE_PREAUTH = &H400000
        ADS_UF_PASSWORD_EXPIRED = &H800000
        ADS_UF_TRUSTED_TO_AUTHENTICATE_FOR_DELEGATION = &H1000000
    End Enum

    ' Lancement de l'analyse
    Private Sub btnAnalyse_Click(sender As Object, e As EventArgs) Handles btnAnalyse.Click
        btnAnalyse.Enabled = False
        lvUsers.Items.Clear()

        Dim sPos As String = sStartOU
        If txtSite.Text <> "" Then sPos = "ou=" & txtSite.Text & "," & sPos
        lblLégende.Text = "Analyse de: " & Replace(sPos, "&", "&&") & " :"
        lblLégende.Refresh()

        ' On commence par récupérer la liste des sites
        RécupListeSites()

        AnalyseOU(txtSite.Text, sPos)
        btnAnalyse.Enabled = True
    End Sub

    Public Sub RécupListeSites()
        Dim objOU As Object
        Try
            objOU = GetObject("LDAP://ou=Workstations & Printers," & sStartOU)
        Catch e As Exception
            MsgBox("Échec lors de l'accès à l'objet Active Directory LDAP://ou=Workstations & Printers," & sStartOU & vbCrLf & vbCrLf & e.Source & ": " & e.Message)
            Exit Sub
        End Try

        slSites = New SortedList
        Dim objX As Object
        For Each objX In objOU
            If objX.class = "organizationalUnit" Then
                slSites.Add(LCase(objX.ou), LCase(objX.ou))
            End If
        Next
    End Sub

    ' Parcours récursif de AD
    ' Retour false en cas de pb lors de l'accès
    Public Sub AnalyseOU(sPos As String, sStart As String)
        Dim objOU As Object
        Try
            objOU = GetObject("LDAP://" & sStart)
        Catch e As Exception
            MsgBox("Échec lors de l'accès à l'objet Active Directory LDAP://" & sStart & vbCrLf & vbCrLf & e.Source & ": " & e.Message)
            Exit Sub
        End Try

        Dim objX As Object
        For Each objX In objOU
            If objX.class = "user" Then AnalyseUser(sPos, objX)
        Next

        For Each objX In objOU
            If objX.class = "organizationalUnit" AndAlso objX.ou <> "global" Then
                AnalyseOU(sPos & "\" & objX.ou, "ou=""" & objX.ou & """," & sStart)
            End If
        Next
    End Sub

    Public Sub AnalyseUser(sPos As String, u As Object)
        Dim lvi As ListViewItem

        lvi = lvUsers.Items.Add(u.cn)
        lvi.UseItemStyleForSubItems = False
        lvi.SubItems.Add(sPos)
        lvi.SubItems.Add(u.sAMAccountName)
        sbStatus.Text = lvUsers.Items.Count & " utilisateurs"

        Dim sAnalyse As String
        sAnalyse = ""

        ' Test du script d'ouverture
        If chkScriptOuverture.Checked Then
            If StrComp(u.scriptPath, "fr\sgs.bat", CompareMethod.Text) <> 0 And InStr(u.CN, "(LIMS)", CompareMethod.Text) = 0 And LCase(VB.Left(u.sAMAccountName, 6)) <> "admfr_" Then
                sAnalyse += ", Script invalide "
                If u.scriptPath = "" Then
                    sAnalyse += "(vide)"
                Else
                    sAnalyse += "(" & u.scriptPath & ")"
                End If
            End If
        End If

        ' Compte verrouillé
        If chkCompteVerrouillé.Checked Then
            If u.IsAccountLocked Then
                sAnalyse += ", Compte verrouillé"
            End If
        End If

        ' Bits particuliers...
        Dim iUserAccountControl As Integer
        iUserAccountControl = u.Get("userAccountControl")
        'If u.cn = "Jean-Raoul DUGÂTEAU" Then Stop
        If chkCompteDésactivé.Checked And (iUserAccountControl And ADS_USER_FLAG_ENUM.ADS_UF_ACCOUNTDISABLE) Then sAnalyse += ", Compte désactivé"
        If chkMdPExpiré.Checked And (iUserAccountControl And ADS_USER_FLAG_ENUM.ADS_UF_PASSWORD_EXPIRED) Then sAnalyse += ", Le mot de passe a expiré"
        If chkMdpPeutExpirer.Checked And (iUserAccountControl And ADS_USER_FLAG_ENUM.ADS_UF_DONT_EXPIRE_PASSWD) = 0 Then sAnalyse += ", Le mot de passe peut expirer"

        ' L'utilisateur ne peut pas changer le mot de passe (le bit ADS_USER_FLAG_ENUM.ADS_UF_PASSWD_CANT_CHANGE est toujours à 0...)
        If chkChangeMDPInterdit.Checked Then
            Dim oUser As Object
            oUser = GetObject("WinNT://EAME/" + u.sAMAccountName)
            If (oUser.Get("userFlags") And ADS_USER_FLAG_ENUM.ADS_UF_PASSWD_CANT_CHANGE) <> 0 Then
                sAnalyse += ", Changement de MdP interdit"
            End If
        End If

        ' Récupération de la liste des groupes
        Dim tMemberOf As Object
        Try
            tMemberOf = u.GetEx("memberOf")
        Catch ex As Exception
            tMemberOf = Array.Empty(Of String)()
        End Try

        ' Test du rattachement au groupe fr_allusers_g
        Dim sGroupe As String
        If chkGrpfr_allusers_g.Checked Then
            Dim bTrouvé As Boolean
            bTrouvé = False
            For Each sGroupe In tMemberOf
                If InStr(sGroupe, "=fr_allusers_g", CompareMethod.Text) <> 0 Then
                    bTrouvé = True
                    Exit For
                End If
            Next
            If Not bTrouvé Then
                sAnalyse += ", Pas membre de fr_allusers_g"
            End If
        End If

        ' Test du rattachement à un groupe site
        If chkGrpSite.Checked Then
            Dim iNbSites As Integer
            Dim sSites As String
            iNbSites = 0
            sSites = ""
            For Each sGroupe In tMemberOf
                For Each s1 As Object In slSites
                    If InStr(sGroupe, "=fr" & s1.value & "_g", CompareMethod.Text) <> 0 Then
                        sSites = sSites & ", " & s1.value
                        iNbSites += 1
                    End If
                Next
            Next
            If iNbSites = 0 Then sAnalyse += ", Rattaché à aucun groupe-site"
            If iNbSites > 1 Then sAnalyse += ", Rattaché à " & iNbSites & " groupe-sites: " & Mid(sSites, 3)
        End If

        ' Test du rattachement à un groupe business
        If chkGrpBusiness.Checked Then
            Dim iNbBusiness As Integer
            iNbBusiness = 0
            For Each sGroupe In tMemberOf
                For Each b1 As String In tsBusiness
                    If InStr(sGroupe, "=fr_" & b1 & "_g", CompareMethod.Text) <> 0 Then
                        iNbBusiness += 1
                    End If
                Next
            Next
            If iNbBusiness = 0 Then sAnalyse += ", Rattaché à aucun groupe-business"
        End If

        ' Intégration de l'analyse dans la liste
        Dim x As ListViewItem.ListViewSubItem
        If Len(sAnalyse) > 0 Then
            x = lvi.SubItems.Add(Mid(sAnalyse, 3))
            x.BackColor = Color.LightPink
        End If
    End Sub

    ' Interface utilisateur de la liste
    Private iColTri As Integer = -1     ' Colonne de tri

    Private iSensTri As Integer         ' Ordre 1=ascendant, -1=descendant

    ' Copie dans le presse-papiers
    Private Sub cmdCopie_Click(sender As Object, e As EventArgs) Handles cmdCopie.Click
        Dim sbPP As New StringBuilder
        For i As Integer = 0 To lvUsers.Columns.Count - 1
            If i > 0 Then sbPP.Append(Chr(9))
            sbPP.Append(lvUsers.Columns(i).Text)
        Next
        sbPP.Append(vbCrLf)
        For Each lvi As ListViewItem In lvUsers.Items
            sbPP.Append(lvi.Text)
            For i As Integer = 1 To lvi.SubItems.Count - 1
                sbPP.Append(vbTab & lvi.SubItems(i).Text)
            Next
            sbPP.Append(vbCrLf)
        Next
        Clipboard.SetDataObject(sbPP.ToString)
    End Sub

    Private Sub lvUsers_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lvUsers.ColumnClick
        If iColTri <> e.Column Then
            iColTri = e.Column
            iSensTri = 1
        Else
            iSensTri = -iSensTri
        End If
        lvUsers.ListViewItemSorter = New ListViewItemComparer(iColTri, iSensTri)
    End Sub

End Class

' Implémentation du tri de la liste par n'importe quelle colonne
Friend Class ListViewItemComparer
    Implements IComparer

    Private ReadOnly col As Integer
    Private ReadOnly sens As Integer

    Public Sub New()
        col = 0
        sens = 1
    End Sub

    Public Sub New(column As Integer)
        col = column
        sens = 1
    End Sub

    Public Sub New(column As Integer, sensdetri As Integer)
        col = column
        sens = sensdetri
    End Sub

    Public Function Compare(x As Object, y As Object) As Integer Implements IComparer.Compare
        Return If(col < 4,
            sens * String.Compare(CType(x, ListViewItem).SubItems(col).Text, CType(y, ListViewItem).SubItems(col).Text),
            sens * Date.Compare(CType(x, ListViewItem).SubItems(col).Text, CType(y, ListViewItem).SubItems(col).Text))
    End Function

End Class
