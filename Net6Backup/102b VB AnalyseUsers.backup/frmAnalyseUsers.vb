' AnalyseUsers
' 12/02/2004 PV
' Analyse les comptes utilisateur dans AD
' 01/10/2006 PV VS 2005

Imports VB = Microsoft.VisualBasic

#Disable Warning IDE1006 ' Naming Styles

Public Class frmAnalyseUsers
    Inherits Form

#Region " Code g�n�r� par le Concepteur Windows Form "

    Public Sub New()
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        Visible = True

        'Ajoutez une initialisation quelconque apr�s l'appel InitializeComponent()
        Me.AcceptButton = btnAnalyse
    End Sub

    'La m�thode substitu�e Dispose du formulaire pour nettoyer la liste des composants.
    Protected Overloads Overrides Sub Dispose(disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    Private components As System.ComponentModel.IContainer

    'REMARQUE�: la proc�dure suivante est requise par le Concepteur Windows Form
    'Elle peut �tre modifi�e en utilisant le Concepteur Windows Form.
    'Ne la modifiez pas en utilisant l'�diteur de code.
    Friend WithEvents lblAnalyse As Label

    Friend WithEvents btnAnalyse As Button
    Friend WithEvents txtSite As TextBox
    Friend WithEvents lblL�gende As Label
    Friend WithEvents lvUsers As ListView
    Friend WithEvents chCN As ColumnHeader
    Friend WithEvents chAccount As ColumnHeader
    Friend WithEvents chOU As ColumnHeader
    Friend WithEvents chRemarques As ColumnHeader
    Friend WithEvents gbTester As GroupBox
    Friend WithEvents chkScriptOuverture As CheckBox
    Friend WithEvents chkCompteD�sactiv� As CheckBox
    Friend WithEvents chkChangeMDPInterdit As CheckBox
    Friend WithEvents chkMdPExpir� As CheckBox
    Friend WithEvents chkGrpfr_allusers_g As CheckBox
    Friend WithEvents chkGrpSite As CheckBox
    Friend WithEvents chkGrpBusiness As CheckBox
    Friend WithEvents chkCompteVerrouill� As CheckBox
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents sbStatus As ToolStripStatusLabel
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents cmdCopie As ToolStripMenuItem
    Friend WithEvents chkMdpPeutExpirer As CheckBox

    <DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAnalyseUsers))
        Me.btnAnalyse = New System.Windows.Forms.Button()
        Me.lblAnalyse = New System.Windows.Forms.Label()
        Me.txtSite = New System.Windows.Forms.TextBox()
        Me.lblL�gende = New System.Windows.Forms.Label()
        Me.lvUsers = New System.Windows.Forms.ListView()
        Me.chCN = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chOU = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chAccount = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chRemarques = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.gbTester = New System.Windows.Forms.GroupBox()
        Me.chkMdpPeutExpirer = New System.Windows.Forms.CheckBox()
        Me.chkCompteVerrouill� = New System.Windows.Forms.CheckBox()
        Me.chkGrpBusiness = New System.Windows.Forms.CheckBox()
        Me.chkGrpSite = New System.Windows.Forms.CheckBox()
        Me.chkGrpfr_allusers_g = New System.Windows.Forms.CheckBox()
        Me.chkMdPExpir� = New System.Windows.Forms.CheckBox()
        Me.chkChangeMDPInterdit = New System.Windows.Forms.CheckBox()
        Me.chkCompteD�sactiv� = New System.Windows.Forms.CheckBox()
        Me.chkScriptOuverture = New System.Windows.Forms.CheckBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.sbStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmdCopie = New System.Windows.Forms.ToolStripMenuItem()
        Me.gbTester.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAnalyse
        '
        Me.btnAnalyse.Location = New System.Drawing.Point(552, 15)
        Me.btnAnalyse.Name = "btnAnalyse"
        Me.btnAnalyse.Size = New System.Drawing.Size(150, 42)
        Me.btnAnalyse.TabIndex = 2
        Me.btnAnalyse.Text = "&Analyser"
        '
        'lblAnalyse
        '
        Me.lblAnalyse.AutoSize = True
        Me.lblAnalyse.Location = New System.Drawing.Point(8, 22)
        Me.lblAnalyse.Name = "lblAnalyse"
        Me.lblAnalyse.Size = New System.Drawing.Size(239, 25)
        Me.lblAnalyse.TabIndex = 0
        Me.lblAnalyse.Text = "Site � analyser dans fr :"
        '
        'txtSite
        '
        Me.txtSite.Location = New System.Drawing.Point(264, 15)
        Me.txtSite.Name = "txtSite"
        Me.txtSite.Size = New System.Drawing.Size(272, 31)
        Me.txtSite.TabIndex = 1
        '
        'lblL�gende
        '
        Me.lblL�gende.AutoSize = True
        Me.lblL�gende.Location = New System.Drawing.Point(8, 59)
        Me.lblL�gende.Name = "lblL�gende"
        Me.lblL�gende.Size = New System.Drawing.Size(61, 25)
        Me.lblL�gende.TabIndex = 3
        Me.lblL�gende.Text = "ou=fr"
        '
        'lvUsers
        '
        Me.lvUsers.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvUsers.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chCN, Me.chOU, Me.chAccount, Me.chRemarques})
        Me.lvUsers.HideSelection = False
        Me.lvUsers.Location = New System.Drawing.Point(8, 207)
        Me.lvUsers.Name = "lvUsers"
        Me.lvUsers.Size = New System.Drawing.Size(1461, 350)
        Me.lvUsers.TabIndex = 4
        Me.lvUsers.UseCompatibleStateImageBehavior = False
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
        'gbTester
        '
        Me.gbTester.Controls.Add(Me.chkMdpPeutExpirer)
        Me.gbTester.Controls.Add(Me.chkCompteVerrouill�)
        Me.gbTester.Controls.Add(Me.chkGrpBusiness)
        Me.gbTester.Controls.Add(Me.chkGrpSite)
        Me.gbTester.Controls.Add(Me.chkGrpfr_allusers_g)
        Me.gbTester.Controls.Add(Me.chkMdPExpir�)
        Me.gbTester.Controls.Add(Me.chkChangeMDPInterdit)
        Me.gbTester.Controls.Add(Me.chkCompteD�sactiv�)
        Me.gbTester.Controls.Add(Me.chkScriptOuverture)
        Me.gbTester.Location = New System.Drawing.Point(712, 7)
        Me.gbTester.Name = "gbTester"
        Me.gbTester.Size = New System.Drawing.Size(752, 185)
        Me.gbTester.TabIndex = 6
        Me.gbTester.TabStop = False
        Me.gbTester.Text = "&Tester"
        '
        'chkMdpPeutExpirer
        '
        Me.chkMdpPeutExpirer.Location = New System.Drawing.Point(8, 148)
        Me.chkMdpPeutExpirer.Name = "chkMdpPeutExpirer"
        Me.chkMdpPeutExpirer.Size = New System.Drawing.Size(312, 29)
        Me.chkMdpPeutExpirer.TabIndex = 8
        Me.chkMdpPeutExpirer.Text = "MdP peut expirer"
        '
        'chkCompteVerrouill�
        '
        Me.chkCompteVerrouill�.Checked = True
        Me.chkCompteVerrouill�.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCompteVerrouill�.Location = New System.Drawing.Point(344, 30)
        Me.chkCompteVerrouill�.Name = "chkCompteVerrouill�"
        Me.chkCompteVerrouill�.Size = New System.Drawing.Size(312, 29)
        Me.chkCompteVerrouill�.TabIndex = 7
        Me.chkCompteVerrouill�.Text = "Compte verrouill�"
        '
        'chkGrpBusiness
        '
        Me.chkGrpBusiness.Checked = True
        Me.chkGrpBusiness.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkGrpBusiness.Location = New System.Drawing.Point(344, 118)
        Me.chkGrpBusiness.Name = "chkGrpBusiness"
        Me.chkGrpBusiness.Size = New System.Drawing.Size(384, 30)
        Me.chkGrpBusiness.TabIndex = 6
        Me.chkGrpBusiness.Text = "Attach� � 1 groupe business"
        '
        'chkGrpSite
        '
        Me.chkGrpSite.Checked = True
        Me.chkGrpSite.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkGrpSite.Location = New System.Drawing.Point(344, 89)
        Me.chkGrpSite.Name = "chkGrpSite"
        Me.chkGrpSite.Size = New System.Drawing.Size(384, 29)
        Me.chkGrpSite.TabIndex = 5
        Me.chkGrpSite.Text = "Attach� � 1 groupe site"
        '
        'chkGrpfr_allusers_g
        '
        Me.chkGrpfr_allusers_g.Checked = True
        Me.chkGrpfr_allusers_g.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkGrpfr_allusers_g.Location = New System.Drawing.Point(344, 59)
        Me.chkGrpfr_allusers_g.Name = "chkGrpfr_allusers_g"
        Me.chkGrpfr_allusers_g.Size = New System.Drawing.Size(384, 30)
        Me.chkGrpfr_allusers_g.TabIndex = 4
        Me.chkGrpfr_allusers_g.Text = "Attach� au groupe fr_allusers_g"
        '
        'chkMdPExpir�
        '
        Me.chkMdPExpir�.Checked = True
        Me.chkMdPExpir�.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkMdPExpir�.Location = New System.Drawing.Point(8, 118)
        Me.chkMdPExpir�.Name = "chkMdPExpir�"
        Me.chkMdPExpir�.Size = New System.Drawing.Size(312, 30)
        Me.chkMdPExpir�.TabIndex = 3
        Me.chkMdPExpir�.Text = "MdP expir�"
        '
        'chkChangeMDPInterdit
        '
        Me.chkChangeMDPInterdit.Checked = True
        Me.chkChangeMDPInterdit.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkChangeMDPInterdit.Location = New System.Drawing.Point(8, 89)
        Me.chkChangeMDPInterdit.Name = "chkChangeMDPInterdit"
        Me.chkChangeMDPInterdit.Size = New System.Drawing.Size(312, 29)
        Me.chkChangeMDPInterdit.TabIndex = 2
        Me.chkChangeMDPInterdit.Text = "Changement MdP interdit"
        '
        'chkCompteD�sactiv�
        '
        Me.chkCompteD�sactiv�.Checked = True
        Me.chkCompteD�sactiv�.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCompteD�sactiv�.Location = New System.Drawing.Point(8, 59)
        Me.chkCompteD�sactiv�.Name = "chkCompteD�sactiv�"
        Me.chkCompteD�sactiv�.Size = New System.Drawing.Size(248, 30)
        Me.chkCompteD�sactiv�.TabIndex = 1
        Me.chkCompteD�sactiv�.Text = "Compte d�sactiv�"
        '
        'chkScriptOuverture
        '
        Me.chkScriptOuverture.Checked = True
        Me.chkScriptOuverture.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkScriptOuverture.Location = New System.Drawing.Point(8, 30)
        Me.chkScriptOuverture.Name = "chkScriptOuverture"
        Me.chkScriptOuverture.Size = New System.Drawing.Size(248, 29)
        Me.chkScriptOuverture.TabIndex = 0
        Me.chkScriptOuverture.Text = "Script d'ouverture"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sbStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 591)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1477, 22)
        Me.StatusStrip1.TabIndex = 7
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'sbStatus
        '
        Me.sbStatus.Name = "sbStatus"
        Me.sbStatus.Size = New System.Drawing.Size(1462, 12)
        Me.sbStatus.Spring = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmdCopie})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(301, 86)
        '
        'cmdCopie
        '
        Me.cmdCopie.Name = "cmdCopie"
        Me.cmdCopie.Size = New System.Drawing.Size(300, 38)
        Me.cmdCopie.Text = "Copie liste enti�re"
        '
        'frmAnalyseUsers
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(10, 24)
        Me.ClientSize = New System.Drawing.Size(1477, 613)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.gbTester)
        Me.Controls.Add(Me.lvUsers)
        Me.Controls.Add(Me.lblL�gende)
        Me.Controls.Add(Me.txtSite)
        Me.Controls.Add(Me.lblAnalyse)
        Me.Controls.Add(Me.btnAnalyse)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAnalyseUsers"
        Me.Text = "Analyse les objets User dans AD"
        Me.gbTester.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    ' Point de d�part de l'analyse
    Const sStartOU As String = "ou=fr,dc=eame,dc=global,dc=sgs,dc=com"

    ' Liste des code-sites d�finis dans Workstations & Printers
    Dim slSites As SortedList

    ' Liste des groupes business
    ReadOnly tsBusiness As String() = New String() {"agr", "aud", "fin", "hr", "ind", "it", "lab", "lgl", "lif", "mgt", "min", "ogc", "ssc cts", "tas"}

    ' Attributs de comptes. Piqu� sur http://msdn.microsoft.com/library/default.asp?url=/library/en-us/adsi/adsi/ads_user_flag_enum.asp
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
    Private Sub btnAnalyse_Click(sender As System.Object, e As EventArgs) Handles btnAnalyse.Click
        btnAnalyse.Enabled = False
        lvUsers.Items.Clear()

        Dim sPos As String = sStartOU
        If txtSite.Text <> "" Then sPos = "ou=" & txtSite.Text & "," & sPos
        lblL�gende.Text = "Analyse de: " & Replace(sPos, "&", "&&") & " :"
        lblL�gende.Refresh()

        ' On commence par r�cup�rer la liste des sites
        R�cupListeSites()

        AnalyseOU(txtSite.Text, sPos)
        btnAnalyse.Enabled = True
    End Sub

    Sub R�cupListeSites()
        Dim objOU As Object
        Try
            objOU = GetObject("LDAP://ou=Workstations & Printers," & sStartOU)
        Catch e As Exception
            MsgBox("�chec lors de l'acc�s � l'objet Active Directory LDAP://ou=Workstations & Printers," & sStartOU & vbCrLf & vbCrLf & e.Source & ": " & e.Message)
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

    ' Parcours r�cursif de AD
    ' Retour false en cas de pb lors de l'acc�s
    Sub AnalyseOU(sPos As String, sStart As String)
        Dim objOU As Object
        Try
            objOU = GetObject("LDAP://" & sStart)
        Catch e As Exception
            MsgBox("�chec lors de l'acc�s � l'objet Active Directory LDAP://" & sStart & vbCrLf & vbCrLf & e.Source & ": " & e.Message)
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

    Sub AnalyseUser(sPos As String, u As Object)
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

        ' Compte verrouill�
        If chkCompteVerrouill�.Checked Then
            If u.IsAccountLocked Then
                sAnalyse += ", Compte verrouill�"
            End If
        End If

        ' Bits particuliers...
        Dim iUserAccountControl As Integer
        iUserAccountControl = u.Get("userAccountControl")
        'If u.cn = "Jean-Raoul DUG�TEAU" Then Stop
        If chkCompteD�sactiv�.Checked And (iUserAccountControl And ADS_USER_FLAG_ENUM.ADS_UF_ACCOUNTDISABLE) Then sAnalyse += ", Compte d�sactiv�"
        If chkMdPExpir�.Checked And (iUserAccountControl And ADS_USER_FLAG_ENUM.ADS_UF_PASSWORD_EXPIRED) Then sAnalyse += ", Le mot de passe a expir�"
        If chkMdpPeutExpirer.Checked And (iUserAccountControl And ADS_USER_FLAG_ENUM.ADS_UF_DONT_EXPIRE_PASSWD) = 0 Then sAnalyse += ", Le mot de passe peut expirer"

        ' L'utilisateur ne peut pas changer le mot de passe (le bit ADS_USER_FLAG_ENUM.ADS_UF_PASSWD_CANT_CHANGE est toujours � 0...)
        If chkChangeMDPInterdit.Checked Then
            Dim oUser As Object
            oUser = GetObject("WinNT://EAME/" + u.sAMAccountName)
            If (oUser.Get("userFlags") And ADS_USER_FLAG_ENUM.ADS_UF_PASSWD_CANT_CHANGE) <> 0 Then
                sAnalyse += ", Changement de MdP interdit"
            End If
        End If

        ' R�cup�ration de la liste des groupes
        Dim tMemberOf As Object
        Try
            tMemberOf = u.GetEx("memberOf")
        Catch ex As Exception
            tMemberOf = New String() {}
        End Try

        ' Test du rattachement au groupe fr_allusers_g
        Dim sGroupe As String
        If chkGrpfr_allusers_g.Checked Then
            Dim bTrouv� As Boolean
            bTrouv� = False
            For Each sGroupe In tMemberOf
                If InStr(sGroupe, "=fr_allusers_g", CompareMethod.Text) <> 0 Then
                    bTrouv� = True
                    Exit For
                End If
            Next
            If Not bTrouv� Then
                sAnalyse += ", Pas membre de fr_allusers_g"
            End If
        End If

        ' Test du rattachement � un groupe site
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
            If iNbSites = 0 Then sAnalyse += ", Rattach� � aucun groupe-site"
            If iNbSites > 1 Then sAnalyse += ", Rattach� � " & iNbSites & " groupe-sites: " & Mid(sSites, 3)
        End If

        ' Test du rattachement � un groupe business
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
            If iNbBusiness = 0 Then sAnalyse += ", Rattach� � aucun groupe-business"
        End If

        ' Int�gration de l'analyse dans la liste
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
    Private Sub cmdCopie_Click(sender As System.Object, e As EventArgs) Handles cmdCopie.Click
        Dim sbPP As New Text.StringBuilder
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

' Impl�mentation du tri de la liste par n'importe quelle colonne
Class ListViewItemComparer
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
        If col < 4 Then
            Return sens * [String].Compare(CType(x, ListViewItem).SubItems(col).Text, CType(y, ListViewItem).SubItems(col).Text)
        Else
            Return sens * [DateTime].Compare(CType(x, ListViewItem).SubItems(col).Text, CType(y, ListViewItem).SubItems(col).Text)
        End If
    End Function

End Class