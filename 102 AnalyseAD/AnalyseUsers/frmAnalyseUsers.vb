' AnalyseUsers
' 12/02/2004 PV
' Analyse les comptes utilisateur dans AD
' 01/10/2006 PV VS 2005

Imports VB = Microsoft.VisualBasic
Imports System.Text.RegularExpressions


Public Class frmAnalyseUsers
    Inherits System.Windows.Forms.Form

#Region " Code généré par le Concepteur Windows Form "

    Public Sub New()
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        Visible = True

        'Ajoutez une initialisation quelconque après l'appel InitializeComponent()
        Me.AcceptButton = btnAnalyse
    End Sub

    'La méthode substituée Dispose du formulaire pour nettoyer la liste des composants.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requis par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée en utilisant le Concepteur Windows Form.  
    'Ne la modifiez pas en utilisant l'éditeur de code.
    Friend WithEvents lblAnalyse As System.Windows.Forms.Label
    Friend WithEvents btnAnalyse As System.Windows.Forms.Button
    Friend WithEvents txtSite As System.Windows.Forms.TextBox
    Friend WithEvents lblLégende As System.Windows.Forms.Label
    Friend WithEvents mnuMiste As System.Windows.Forms.ContextMenu
    Friend WithEvents cmdCopie As System.Windows.Forms.MenuItem
    Friend WithEvents lvUsers As System.Windows.Forms.ListView
    Friend WithEvents chCN As System.Windows.Forms.ColumnHeader
    Friend WithEvents chAccount As System.Windows.Forms.ColumnHeader
    Friend WithEvents sbStatus As System.Windows.Forms.StatusBar
    Friend WithEvents chOU As System.Windows.Forms.ColumnHeader
    Friend WithEvents chRemarques As System.Windows.Forms.ColumnHeader
    Friend WithEvents gbTester As System.Windows.Forms.GroupBox
    Friend WithEvents chkScriptOuverture As System.Windows.Forms.CheckBox
    Friend WithEvents chkCompteDésactivé As System.Windows.Forms.CheckBox
    Friend WithEvents chkChangeMDPInterdit As System.Windows.Forms.CheckBox
    Friend WithEvents chkMdPExpiré As System.Windows.Forms.CheckBox
    Friend WithEvents chkGrpfr_allusers_g As System.Windows.Forms.CheckBox
    Friend WithEvents chkGrpSite As System.Windows.Forms.CheckBox
    Friend WithEvents chkGrpBusiness As System.Windows.Forms.CheckBox
    Friend WithEvents chkCompteVerrouillé As System.Windows.Forms.CheckBox
    Friend WithEvents chkMdpPeutExpirer As System.Windows.Forms.CheckBox

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmAnalyseUsers))
        Me.btnAnalyse = New System.Windows.Forms.Button
        Me.lblAnalyse = New System.Windows.Forms.Label
        Me.txtSite = New System.Windows.Forms.TextBox
        Me.lblLégende = New System.Windows.Forms.Label
        Me.mnuMiste = New System.Windows.Forms.ContextMenu
        Me.cmdCopie = New System.Windows.Forms.MenuItem
        Me.lvUsers = New System.Windows.Forms.ListView
        Me.chCN = New System.Windows.Forms.ColumnHeader
        Me.chOU = New System.Windows.Forms.ColumnHeader
        Me.chAccount = New System.Windows.Forms.ColumnHeader
        Me.chRemarques = New System.Windows.Forms.ColumnHeader
        Me.sbStatus = New System.Windows.Forms.StatusBar
        Me.gbTester = New System.Windows.Forms.GroupBox
        Me.chkCompteVerrouillé = New System.Windows.Forms.CheckBox
        Me.chkGrpBusiness = New System.Windows.Forms.CheckBox
        Me.chkGrpSite = New System.Windows.Forms.CheckBox
        Me.chkGrpfr_allusers_g = New System.Windows.Forms.CheckBox
        Me.chkMdPExpiré = New System.Windows.Forms.CheckBox
        Me.chkChangeMDPInterdit = New System.Windows.Forms.CheckBox
        Me.chkCompteDésactivé = New System.Windows.Forms.CheckBox
        Me.chkScriptOuverture = New System.Windows.Forms.CheckBox
        Me.chkMdpPeutExpirer = New System.Windows.Forms.CheckBox
        Me.gbTester.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAnalyse
        '
        Me.btnAnalyse.Location = New System.Drawing.Point(276, 8)
        Me.btnAnalyse.Name = "btnAnalyse"
        Me.btnAnalyse.TabIndex = 2
        Me.btnAnalyse.Text = "&Analyser"
        '
        'lblAnalyse
        '
        Me.lblAnalyse.AutoSize = True
        Me.lblAnalyse.Location = New System.Drawing.Point(4, 12)
        Me.lblAnalyse.Name = "lblAnalyse"
        Me.lblAnalyse.Size = New System.Drawing.Size(123, 16)
        Me.lblAnalyse.TabIndex = 0
        Me.lblAnalyse.Text = "Site à analyser dans fr :"
        '
        'txtSite
        '
        Me.txtSite.Location = New System.Drawing.Point(132, 8)
        Me.txtSite.Name = "txtSite"
        Me.txtSite.Size = New System.Drawing.Size(136, 20)
        Me.txtSite.TabIndex = 1
        Me.txtSite.Text = ""
        '
        'lblLégende
        '
        Me.lblLégende.AutoSize = True
        Me.lblLégende.Location = New System.Drawing.Point(4, 32)
        Me.lblLégende.Name = "lblLégende"
        Me.lblLégende.Size = New System.Drawing.Size(30, 16)
        Me.lblLégende.TabIndex = 3
        Me.lblLégende.Text = "ou=fr"
        '
        'mnuMiste
        '
        Me.mnuMiste.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.cmdCopie})
        '
        'cmdCopie
        '
        Me.cmdCopie.Index = 0
        Me.cmdCopie.Text = "&Copie la liste entière"
        '
        'lvUsers
        '
        Me.lvUsers.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvUsers.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chCN, Me.chOU, Me.chAccount, Me.chRemarques})
        Me.lvUsers.ContextMenu = Me.mnuMiste
        Me.lvUsers.Location = New System.Drawing.Point(4, 112)
        Me.lvUsers.Name = "lvUsers"
        Me.lvUsers.Size = New System.Drawing.Size(728, 328)
        Me.lvUsers.TabIndex = 4
        Me.lvUsers.View = System.Windows.Forms.View.Details
        '
        'chCN
        '
        Me.chCN.Text = "CN"
        Me.chCN.Width = 141
        '
        'chOU
        '
        Me.chOU.Text = "OU"
        Me.chOU.Width = 111
        '
        'chAccount
        '
        Me.chAccount.Text = "Account"
        Me.chAccount.Width = 135
        '
        'chRemarques
        '
        Me.chRemarques.Text = "Remarques"
        Me.chRemarques.Width = 307
        '
        'sbStatus
        '
        Me.sbStatus.Location = New System.Drawing.Point(0, 448)
        Me.sbStatus.Name = "sbStatus"
        Me.sbStatus.Size = New System.Drawing.Size(736, 22)
        Me.sbStatus.TabIndex = 5
        '
        'gbTester
        '
        Me.gbTester.Controls.Add(Me.chkMdpPeutExpirer)
        Me.gbTester.Controls.Add(Me.chkCompteVerrouillé)
        Me.gbTester.Controls.Add(Me.chkGrpBusiness)
        Me.gbTester.Controls.Add(Me.chkGrpSite)
        Me.gbTester.Controls.Add(Me.chkGrpfr_allusers_g)
        Me.gbTester.Controls.Add(Me.chkMdPExpiré)
        Me.gbTester.Controls.Add(Me.chkChangeMDPInterdit)
        Me.gbTester.Controls.Add(Me.chkCompteDésactivé)
        Me.gbTester.Controls.Add(Me.chkScriptOuverture)
        Me.gbTester.Location = New System.Drawing.Point(356, 4)
        Me.gbTester.Name = "gbTester"
        Me.gbTester.Size = New System.Drawing.Size(376, 100)
        Me.gbTester.TabIndex = 6
        Me.gbTester.TabStop = False
        Me.gbTester.Text = "&Tester"
        '
        'chkCompteVerrouillé
        '
        Me.chkCompteVerrouillé.Checked = True
        Me.chkCompteVerrouillé.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCompteVerrouillé.Location = New System.Drawing.Point(172, 16)
        Me.chkCompteVerrouillé.Name = "chkCompteVerrouillé"
        Me.chkCompteVerrouillé.Size = New System.Drawing.Size(156, 16)
        Me.chkCompteVerrouillé.TabIndex = 7
        Me.chkCompteVerrouillé.Text = "Compte verrouillé"
        '
        'chkGrpBusiness
        '
        Me.chkGrpBusiness.Checked = True
        Me.chkGrpBusiness.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkGrpBusiness.Location = New System.Drawing.Point(172, 64)
        Me.chkGrpBusiness.Name = "chkGrpBusiness"
        Me.chkGrpBusiness.Size = New System.Drawing.Size(192, 16)
        Me.chkGrpBusiness.TabIndex = 6
        Me.chkGrpBusiness.Text = "Attaché à 1 groupe business"
        '
        'chkGrpSite
        '
        Me.chkGrpSite.Checked = True
        Me.chkGrpSite.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkGrpSite.Location = New System.Drawing.Point(172, 48)
        Me.chkGrpSite.Name = "chkGrpSite"
        Me.chkGrpSite.Size = New System.Drawing.Size(192, 16)
        Me.chkGrpSite.TabIndex = 5
        Me.chkGrpSite.Text = "Attaché à 1 groupe site"
        '
        'chkGrpfr_allusers_g
        '
        Me.chkGrpfr_allusers_g.Checked = True
        Me.chkGrpfr_allusers_g.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkGrpfr_allusers_g.Location = New System.Drawing.Point(172, 32)
        Me.chkGrpfr_allusers_g.Name = "chkGrpfr_allusers_g"
        Me.chkGrpfr_allusers_g.Size = New System.Drawing.Size(192, 16)
        Me.chkGrpfr_allusers_g.TabIndex = 4
        Me.chkGrpfr_allusers_g.Text = "Attaché au groupe fr_allusers_g"
        '
        'chkMdPExpiré
        '
        Me.chkMdPExpiré.Checked = True
        Me.chkMdPExpiré.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkMdPExpiré.Location = New System.Drawing.Point(4, 64)
        Me.chkMdPExpiré.Name = "chkMdPExpiré"
        Me.chkMdPExpiré.Size = New System.Drawing.Size(156, 16)
        Me.chkMdPExpiré.TabIndex = 3
        Me.chkMdPExpiré.Text = "MdP expiré"
        '
        'chkChangeMDPInterdit
        '
        Me.chkChangeMDPInterdit.Checked = True
        Me.chkChangeMDPInterdit.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkChangeMDPInterdit.Location = New System.Drawing.Point(4, 48)
        Me.chkChangeMDPInterdit.Name = "chkChangeMDPInterdit"
        Me.chkChangeMDPInterdit.Size = New System.Drawing.Size(156, 16)
        Me.chkChangeMDPInterdit.TabIndex = 2
        Me.chkChangeMDPInterdit.Text = "Changement MdP interdit"
        '
        'chkCompteDésactivé
        '
        Me.chkCompteDésactivé.Checked = True
        Me.chkCompteDésactivé.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCompteDésactivé.Location = New System.Drawing.Point(4, 32)
        Me.chkCompteDésactivé.Name = "chkCompteDésactivé"
        Me.chkCompteDésactivé.Size = New System.Drawing.Size(124, 16)
        Me.chkCompteDésactivé.TabIndex = 1
        Me.chkCompteDésactivé.Text = "Compte désactivé"
        '
        'chkScriptOuverture
        '
        Me.chkScriptOuverture.Checked = True
        Me.chkScriptOuverture.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkScriptOuverture.Location = New System.Drawing.Point(4, 16)
        Me.chkScriptOuverture.Name = "chkScriptOuverture"
        Me.chkScriptOuverture.Size = New System.Drawing.Size(124, 16)
        Me.chkScriptOuverture.TabIndex = 0
        Me.chkScriptOuverture.Text = "Script d'ouverture"
        '
        'chkMdpPeutExpirer
        '
        Me.chkMdpPeutExpirer.Location = New System.Drawing.Point(4, 80)
        Me.chkMdpPeutExpirer.Name = "chkMdpPeutExpirer"
        Me.chkMdpPeutExpirer.Size = New System.Drawing.Size(156, 16)
        Me.chkMdpPeutExpirer.TabIndex = 8
        Me.chkMdpPeutExpirer.Text = "MdP peut expirer"
        '
        'frmAnalyseUsers
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(736, 470)
        Me.Controls.Add(Me.gbTester)
        Me.Controls.Add(Me.sbStatus)
        Me.Controls.Add(Me.lvUsers)
        Me.Controls.Add(Me.lblLégende)
        Me.Controls.Add(Me.txtSite)
        Me.Controls.Add(Me.lblAnalyse)
        Me.Controls.Add(Me.btnAnalyse)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAnalyseUsers"
        Me.Text = "Analyse les objets User dans AD"
        Me.gbTester.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    ' Point de départ de l'analyse
    Const sStartOU As String = "ou=fr,dc=eame,dc=global,dc=sgs,dc=com"

    ' Liste des code-sites définis dans Workstations & Printers
    Dim slSites As SortedList

    ' Liste des groupes business
    Dim tsBusiness As String() = New String() {"agr", "aud", "fin", "hr", "ind", "it", "lab", "lgl", "lif", "mgt", "min", "ogc", "ssc cts", "tas"}


    ' Attributs de comptes. Piqué sur http://msdn.microsoft.com/library/default.asp?url=/library/en-us/adsi/adsi/ads_user_flag_enum.asp
    Enum ADS_USER_FLAG_ENUM
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
    Private Sub btnAnalyse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnalyse.Click
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

    Sub RécupListeSites()
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
    Sub AnalyseOU(ByVal sPos As String, ByVal sStart As String)
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

    Sub AnalyseUser(ByVal sPos As String, ByVal u As Object)
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
            tMemberOf = New String() {}
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
    Private Sub cmdCopie_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCopie.Click
        Dim sbPP As New System.Text.StringBuilder
        For i As Integer = 0 To lvUsers.Columns.Count - 1
            If i > 0 Then sbPP.Append(vbTab)
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

    Private Sub lvUsers_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvUsers.ColumnClick
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
Class ListViewItemComparer
    Implements IComparer

    Private col As Integer
    Private sens As Integer

    Public Sub New()
        col = 0
        sens = 1
    End Sub

    Public Sub New(ByVal column As Integer)
        col = column
        sens = 1
    End Sub

    Public Sub New(ByVal column As Integer, ByVal sensdetri As Integer)
        col = column
        sens = sensdetri
    End Sub

    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
        If col < 4 Then
            Return sens * [String].Compare(CType(x, ListViewItem).SubItems(col).Text, CType(y, ListViewItem).SubItems(col).Text)
        Else
            Return sens * [DateTime].Compare(CType(x, ListViewItem).SubItems(col).Text, CType(y, ListViewItem).SubItems(col).Text)
        End If
    End Function
End Class

