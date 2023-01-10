' AnalyseAD
' 10/02/2004 PV
' Analyse et représente visuellement les objets AD computer et les OUs dans lesquels ils sont stockés
' 11/02/04 1.1  Présentation en tableau
' 01/10/2006 PV VS 2005
' 2023-01-10	PV		Net7

Imports System.ComponentModel
Imports System.Text
Imports System.Text.RegularExpressions
Imports VB = Microsoft.VisualBasic

#Disable Warning IDE1006 ' Naming Styles

Public Class frmAnalyse
    Inherits Form

#Region " Code généré par le Concepteur Windows Form "

    Public Sub New()
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        Visible = True

        'Ajoutez une initialisation quelconque après l'appel InitializeComponent()
        IEDoc.Navigate("about:blank")
        RefreshIE()
        Me.AcceptButton = btnAnalyse

        r95 = New Regex("^FR[A-Z]{3}95[0-9]{2}$")
        r98 = New Regex("^FR[A-Z]{3}98[0-9]{2}$")
        r00 = New Regex("^FR[A-Z]{3}[0-9]{4}$")
        rNum = New Regex("^FR[A-Z]{3}([0-9]{4})$")

        'Init()
        'Affiche()
    End Sub

    'La méthode substituée Dispose du formulaire pour nettoyer la liste des composants.
    Protected Overloads Overrides Sub Dispose(disposing As Boolean)
        If disposing Then
            components?.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    Private components As IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée en utilisant le Concepteur Windows Form.
    'Ne la modifiez pas en utilisant l'éditeur de code.
    Friend WithEvents lblAnalyse As Label

    Friend WithEvents btnAnalyse As Button
    Friend WithEvents txtSite As TextBox
    Friend WithEvents lblLégende As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents tabHTML As TabPage
    Friend WithEvents tabListe As TabPage
    Friend WithEvents chPoste As ColumnHeader
    Friend WithEvents chSite As ColumnHeader
    Friend WithEvents chOU As ColumnHeader
    Friend WithEvents chDescription As ColumnHeader
    Friend WithEvents lvListe As ListView
    Friend WithEvents chWhenCreated As ColumnHeader
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents cmdCopie As ToolStripMenuItem
    Friend WithEvents IEDoc As WebBrowser
    Friend WithEvents chWhenChanged As ColumnHeader

    <DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New Container()
        Dim resources As New ComponentResourceManager(GetType(frmAnalyse))
        Me.btnAnalyse = New Button()
        Me.lblAnalyse = New Label()
        Me.txtSite = New TextBox()
        Me.lblLégende = New Label()
        Me.TabControl1 = New TabControl()
        Me.tabHTML = New TabPage()
        Me.IEDoc = New WebBrowser()
        Me.tabListe = New TabPage()
        Me.lvListe = New ListView()
        Me.chPoste = New ColumnHeader()
        Me.chSite = New ColumnHeader()
        Me.chOU = New ColumnHeader()
        Me.chDescription = New ColumnHeader()
        Me.chWhenCreated = New ColumnHeader()
        Me.chWhenChanged = New ColumnHeader()
        Me.ContextMenuStrip1 = New ContextMenuStrip(Me.components)
        Me.cmdCopie = New ToolStripMenuItem()
        Me.TabControl1.SuspendLayout()
        Me.tabHTML.SuspendLayout()
        Me.tabListe.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAnalyse
        '
        Me.btnAnalyse.Location = New Point(932, 11)
        Me.btnAnalyse.Name = "btnAnalyse"
        Me.btnAnalyse.Size = New Size(180, 56)
        Me.btnAnalyse.TabIndex = 2
        Me.btnAnalyse.Text = "&Analyser"
        '
        'lblAnalyse
        '
        Me.lblAnalyse.AutoSize = True
        Me.lblAnalyse.Location = New Point(10, 19)
        Me.lblAnalyse.Name = "lblAnalyse"
        Me.lblAnalyse.Size = New Size(493, 32)
        Me.lblAnalyse.TabIndex = 0
        Me.lblAnalyse.Text = "Site à analyser dans Workstations && Printers :"
        '
        'txtSite
        '
        Me.txtSite.Location = New Point(586, 11)
        Me.txtSite.Name = "txtSite"
        Me.txtSite.Size = New Size(326, 39)
        Me.txtSite.TabIndex = 1
        '
        'lblLégende
        '
        Me.lblLégende.AutoSize = True
        Me.lblLégende.Location = New Point(10, 79)
        Me.lblLégende.Name = "lblLégende"
        Me.lblLégende.Size = New Size(762, 32)
        Me.lblLégende.TabIndex = 3
        Me.lblLégende.Text = "ou=Workstations && Printers,ou=fr,dc=eame,dc=global,dc=sgs,dc=com"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((AnchorStyles.Top Or AnchorStyles.Bottom) _
            Or AnchorStyles.Left) _
            Or AnchorStyles.Right), AnchorStyles)
        Me.TabControl1.Controls.Add(Me.tabHTML)
        Me.TabControl1.Controls.Add(Me.tabListe)
        Me.TabControl1.Location = New Point(10, 117)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New Size(1410, 1019)
        Me.TabControl1.TabIndex = 5
        '
        'tabHTML
        '
        Me.tabHTML.Controls.Add(Me.IEDoc)
        Me.tabHTML.Location = New Point(8, 46)
        Me.tabHTML.Name = "tabHTML"
        Me.tabHTML.Size = New Size(1394, 965)
        Me.tabHTML.TabIndex = 0
        Me.tabHTML.Text = "Synthèse en couleurs"
        '
        'IEDoc
        '
        Me.IEDoc.Dock = DockStyle.Fill
        Me.IEDoc.Location = New Point(0, 0)
        Me.IEDoc.MinimumSize = New Size(20, 20)
        Me.IEDoc.Name = "IEDoc"
        Me.IEDoc.Size = New Size(1394, 965)
        Me.IEDoc.TabIndex = 0
        '
        'tabListe
        '
        Me.tabListe.Controls.Add(Me.lvListe)
        Me.tabListe.Location = New Point(8, 46)
        Me.tabListe.Name = "tabListe"
        Me.tabListe.Size = New Size(1680, 1345)
        Me.tabListe.TabIndex = 1
        Me.tabListe.Text = "Liste"
        '
        'lvListe
        '
        Me.lvListe.Anchor = CType((((AnchorStyles.Top Or AnchorStyles.Bottom) _
            Or AnchorStyles.Left) _
            Or AnchorStyles.Right), AnchorStyles)
        Me.lvListe.Columns.AddRange(New ColumnHeader() {Me.chPoste, Me.chSite, Me.chOU, Me.chDescription, Me.chWhenCreated, Me.chWhenChanged})
        Me.lvListe.FullRowSelect = True
        Me.lvListe.GridLines = True
        Me.lvListe.Location = New Point(20, 19)
        Me.lvListe.Name = "lvListe"
        Me.lvListe.Size = New Size(1623, 1236)
        Me.lvListe.TabIndex = 0
        Me.lvListe.UseCompatibleStateImageBehavior = False
        Me.lvListe.View = View.Details
        '
        'chPoste
        '
        Me.chPoste.Text = "Computer"
        Me.chPoste.Width = 80
        '
        'chSite
        '
        Me.chSite.Text = "Site"
        Me.chSite.Width = 48
        '
        'chOU
        '
        Me.chOU.Text = "OU"
        Me.chOU.Width = 56
        '
        'chDescription
        '
        Me.chDescription.Text = "Description"
        Me.chDescription.Width = 260
        '
        'chWhenCreated
        '
        Me.chWhenCreated.Text = "WhenCreated"
        Me.chWhenCreated.Width = 115
        '
        'chWhenChanged
        '
        Me.chWhenChanged.Text = "WhenChanged"
        Me.chWhenChanged.Width = 115
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New Size(32, 32)
        Me.ContextMenuStrip1.Items.AddRange(New ToolStripItem() {Me.cmdCopie})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New Size(290, 42)
        '
        'cmdCopie
        '
        Me.cmdCopie.Name = "cmdCopie"
        Me.cmdCopie.Size = New Size(289, 38)
        Me.cmdCopie.Text = "Copie toute la liste"
        '
        'frmAnalyse
        '
        Me.AutoScaleBaseSize = New Size(12, 32)
        Me.ClientSize = New Size(1431, 1140)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.lblLégende)
        Me.Controls.Add(Me.txtSite)
        Me.Controls.Add(Me.lblAnalyse)
        Me.Controls.Add(Me.btnAnalyse)
        Me.Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Me.Name = "frmAnalyse"
        Me.Text = "Analyse les objets Computer dans AD"
        Me.TabControl1.ResumeLayout(False)
        Me.tabHTML.ResumeLayout(False)
        Me.tabListe.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    ' Point de départ de l'analyse
    Const sStartSite As String = "ou=Workstations & Printers,ou=fr,dc=eame,dc=global,dc=sgs,dc=com"

    ' Expressions régulières pour séparer les machines en listes séparées
    ReadOnly r00, r95, r98 As Regex

    ReadOnly rNum As Regex                   ' Pour extraire le n°

    ' Un site
    Class SiteAD
        Public sSite As String            ' Le code du site
        Public sComment As String         ' Description du site
        Public slOU As SortedList         ' La liste des sous-OUs du site
        Public slComp00 As SortedList     ' et celle des machines 2000-XP
        Public slComp95 As SortedList     ' et celle des machines 95
        Public slComp98 As SortedList     ' et celle des machines 98
        Public slCompXX As SortedList     ' et celle des machines invalides
    End Class

    ' La liste des sites, lisée par site. clé=code site en minuscules, ex: cch
    ReadOnly slSitesAD As New SortedList

    ' Un ordinateur, dans les listes slComp
    Class Computer
        Public iRang As Integer         ' Partie numérique du nom
        Public sComputer As String      ' Nom de l'ordinateur (CN)
        Public sPos As String           ' Position dans l'arbre AD
        Public sDescription As String   ' Commentaire AD de l'objet
    End Class

    ' La chaîne finale
    Dim sHTML As StringBuilder

    ' Les couleurs utilisées pour les sous-OU
    ReadOnly tColor As Color() = {Color.Pink, Color.Gold, Color.Chartreuse, Color.Aqua, Color.Violet, Color.LightCoral, Color.CornflowerBlue, Color.Wheat, Color.LightGray, Color.OrangeRed, Color.MediumOrchid, Color.LightGray}

    ' Lancement de l'analyse
    Private Sub btnAnalyse_Click(sender As Object, e As EventArgs) Handles btnAnalyse.Click
        IEDoc.Document.Body.InnerHtml = "Analyse en cours..."
        RefreshIE()

        ' On réinitialise la liste
        lvListe.Items.Clear()
        iColTri = -1

        Dim sPos As String = sStartSite
        If txtSite.Text <> "" Then sPos = "ou=" & txtSite.Text & "," & sPos
        lblLégende.Text = "Analyse de: " & Replace(sPos, "&", "&&") & " :"
        lblLégende.Refresh()

#Const ModeTEST = False

#If ModeTEST Then
    Test()
#Else
        If Not ListeOU(txtSite.Text, sPos) Then Exit Sub
        RécupCommentOU()
#End If

        Affiche()
    End Sub

    ' Parcours récursif de AD
    ' Retour false en cas de pb lors de l'accès
    Function ListeOU(sOU As String, sStart As String) As Boolean
        Dim objOU As Object
        Try
            objOU = GetObject("LDAP://" & sStart)
        Catch e As Exception
            MsgBox("Échec lors de l'accès à l'objet Active Directory" & vbCrLf & "LDAP://" & sStart & vbCrLf & vbCrLf & e.Source & ": " & e.Message, MsgBoxStyle.Exclamation)
            IEDoc.Document.Body.InnerHtml = "Échec lors de l'accès à l'objet Active Directory"
            Return False
        End Try

        Dim objX As Object
        For Each objX In objOU
            If objX.class = "computer" Then
                aj(sOU, objX.cn, objX.description, objX.whencreated, objX.whenchanged)
            End If
        Next

        For Each objX In objOU
            If objX.class = "organizationalUnit" Then
                ListeOU(sOU & "\" & objX.ou, "ou=" & objX.ou & "," & sStart)
            End If
        Next

        Return True
    End Function

    Sub RécupCommentOU()
        Dim objOU As Object
        objOU = GetObject("LDAP://" & sStartSite)

        Dim objX As Object
        For Each objX In objOU
            If objX.class = "organizationalUnit" Then
                If slSitesAD.ContainsKey(LCase(objX.ou)) Then
                    Dim sSite As SiteAD
                    sSite = CType(slSitesAD(LCase(objX.ou)), SiteAD)
                    sSite.sComment = objX.description
                End If
            End If
        Next

    End Sub

    Sub Test()
        aj("\bas", "FRBAS0001", "HP Omnibook Xe3, Pascal Carreno", "", "")
        aj("\bas", "FRBAS0002", "IBM M42, Serge Rébillou", "", "")
        aj("\bas", "FRBAS0003", "HP VL6, IT", "", "")
        aj("\bas", "FRBAS0004", "HP VL400, Patrick Jolit", "", "")
        aj("\bas", "FRBAS0005", "IBM M42, Gilles Pensec", "", "")
        aj("\bas", "FRBAS0006", "IBM M42, Pascal Carreno", "", "")
        aj("\bas", "FRBAS0007", "HP VL400, Chimistes OGC", "", "")
        aj("\bas", "FRBAS0008", "HP VL400, Jerome Lebeau", "", "")
        aj("\bas", "FRBAS0009", "IBM T30, Inspecteurs OGC", "", "")
        aj("\bas", "FRBAS0010", "IBM T30, Inspecteurs OGC", "", "")
        aj("\bas", "FRBAS0011", "Toshiba T8000, Inspecteurs OGC", "", "")
        aj("\bas", "FRBAS0012", "Toshiba SP3000, Isabelle Foucart", "", "")
        aj("\bas", "FRBAS0013", "IBM M42, Dominique Leviol", "", "")
        aj("\bas", "FRBAS0014", "HP VL400, Céline Schlur", "", "")
        aj("\bas", "FRBAS0015", "HP VL400, Chimistes Crepin", "", "")
        aj("\bas", "FRBAS0016", "HP VL400, Contrôleurs Usine Saipol", "", "")
        aj("\bas", "FRBAS0017", "IBM T40, Serge Rébillou", "", "")
        aj("\bay", "FRBAY0001", "HP , Carole Foury tba", "", "")
        aj("\bay", "FRBAY0002", "HP , Contrôleurs AGR", "", "")
        aj("\bay", "FRBAY0003", "T8000 , Gilles Pensec", "", "")
        aj("\bay", "FRBAY0004", "IBM M42, Nathalie Berque", "", "")
        aj("\bea", "FRBEA0001", "IBM M42, Laurent MICHELET", "", "")
        aj("\bea", "FRBEA0002", "IBM M42, Aurelie AUCLAIR", "", "")
        aj("\bea", "FRBEA0003", "IBM M42, Florence FAUVERNIER", "", "")
        aj("\bor", "FRBOR0001", "IBM T40, Serge REBILLOU (Prêt,"","")", "", "")
        aj("\bro", "FRBRO0001", "Taïwanais, Christophe BALIGAN", "", "")
        aj("\bro", "FRBRO0004", "IBM M42, Fabien TOLLET", "", "")
        aj("\bro", "FRBRO0005", "IBM M42, Loïc THOMAS", "", "")
        aj("\bro", "FRBRO0006", "IBM T30, Thierry PARZYS", "", "")
        aj("\bro", "FRBRO0007", "IBM T30, Sandrine JUMEAU", "", "")
        aj("\bro", "FRBRO9801", "HP Vectra XE310MT, Isabelle PUGET", "", "")
        aj("\bro", "FRBRO9802", "HP Vectra XE310MT, Anne BELLARD", "", "")
        aj("\bro", "FRBRO9803", "HP Vectra XE310MT, Laure BUFFARD", "", "")
        aj("\cch", "FRCCH003B", "Machine virtuelle Windows 2000 de FRCCH0003", "", "")
        aj("\cch", "FRCCH0047", "IBM M42, Emmanuelle Courbet", "", "")
        aj("\cch", "FRCCH0049", "IBM M42, Karim (Pret KOLAZEC,"","")", "", "")
        aj("\cch", "FRCCH0052", "???", "", "")
        aj("\cch", "FRCCH0064", "IBM T40, Alexandre MUGNIER", "", "")
        aj("\cch", "FRCCH0066", "IBM M42, Prestataire KEYRUS Jeanine SCHUKROU", "", "")
        aj("\cch", "FRCCH0067", "IBM T40, Abder SERIDJI", "", "")
        aj("\cch", "FRCCH0092", "IBM M42, ne pas toucher", "", "")
        aj("\cch", "FRCCH0094", "IBM M42, juridique stagiaire", "", "")
        aj("\cch", "FRCCH0113", "??", "", "")
        aj("\cch", "FRCCH0118", "IBM M42, T LAPORTE", "", "")
        aj("\cch", "FRCCH0120", "IBM M42, Test basculement EAME Evry", "", "")
        aj("\cch", "FRCCH0124", "IBM M42 C voirin", "", "")
        aj("\cch", "FRCCH0132", "IBM T30, Libre RETAIL STORE CHECK", "", "")
        aj("\cch", "FRCCH0138", "IBMT40, Prêt du service Informatique", "", "")
        aj("\cch", "FRCCH0156", "HP Vectra, Rachel_Blandin", "", "")
        aj("\cch", "FRCCH0157", "HP Vectra, A.S.BOIXIERE", "", "")
        aj("\cch", "FRCCH0161", "HP VECTRA VL400, Self Service Scanner", "", "")
        aj("\cch", "FRCCH0191", "IBM T30, Virginie BALLIGUAND", "", "")
        aj("\cch", "FRCCH0214", "Toshiba Satellite 4030CDS, Olivier Boinot", "", "")
        aj("\cch", "FRCCH9506", "TOSHIBA 4030 CDS, Olivier BOINOT", "", "")
        aj("\cch", "FRCCH9802", "Portable toshiba tecra 8100 Armelle Cariou", "", "")
        aj("\cch", "FRCCH9806", "TOSHIBA TECRA 8100, Sylvain JEOFFROY", "", "")
        aj("\cch", "FRCCTVPN", "Ordi test vpn", "", "")
        aj("\cch\aud", "FRCCH0022", "IBM T30, Paul CHAYEB", "", "")
        aj("\cch\aud", "FRCCH0071", "IBM T30, Christine CHAMBELLAND", "", "")
        aj("\cch\aud", "FRCCH0072", "HP Vectra, Christine CHAMBELLAND", "", "")
        aj("\cch\aud", "FRCCH0129", "IBMT40, Sylvain CHEMIN", "", "")
        aj("\cch\aud", "FRCCH9503", "Portable toshiba, S. CHEMIN", "", "")
        aj("\cch\cts", "FRCCH0116", "IBM M42, M Serie", "", "")
        aj("\cch\fin", "FRCCH0017", "IBM M42, Eric Sarfati", "", "")
        aj("\cch\fin", "FRCCH0021", "IBM M42, Françoise Heurtier (NT4,"","")", "", "")
        aj("\cch\fin", "FRCCH0024", "IBM M42, Claire DUBOIS", "", "")
        aj("\cch\fin", "FRCCH0025", "IBM M42, Cédric Limbertie", "", "")
        aj("\cch\fin", "FRCCH0026", "HP Vectra, Laurence Boulanger", "", "")
        aj("\cch\fin", "FRCCH0027", "IBM T30, Jérome RAVET", "", "")
        aj("\cch\fin", "FRCCH0044", "IBM M42, Anne PATINO", "", "")
        aj("\cch\fin", "FRCCH0055", "IBM M42, Thomas ROLLIN", "", "")
        aj("\cch\fin", "FRCCH0056", "IBM M42, Monique BOUBLI", "", "")
        aj("\cch\fin", "FRCCH0057", "IBM M42, Anne PATINO", "", "")
        aj("\cch\fin", "FRCCH0058", "IBM M42, Béatrice LANGLET", "", "")
        aj("\cch\fin", "FRCCH0059", "IBM M42, Virgine FORTES", "", "")
        aj("\cch\fin", "FRCCH0060", "IBM M42, Elise TARDIVEL", "", "")
        aj("\cch\fin", "FRCCH0061", "IBM M42, Christelle NEGRE", "", "")
        aj("\cch\fin", "FRCCH0062", "IBM M42, Cecile Breton", "", "")
        aj("\cch\fin", "FRCCH0070", "IBM M42, Thierry CHIVRAC", "", "")
        aj("\cch\fin", "FRCCH0073", "hp vectra Fabrice Dall'Angelo", "", "")
        aj("\cch\fin", "FRCCH0074", "hp vectra E Garin", "", "")
        aj("\cch\fin", "FRCCH0075", "hp vectra V Maurellet", "", "")
        aj("\cch\fin", "FRCCH0078", "IBM T30 E Garin", "", "")
        aj("\cch\fin", "FRCCH0081", "IBM M42, L Chausi", "", "")
        aj("\cch\fin", "FRCCH0117", "IBM M42, C Limbertie", "", "")
        aj("\cch\fin", "FRCCH0122", "IBM M42, Karl LACROIX", "", "")
        aj("\cch\fin", "FRCCH0179", "COMPAQ EVO N600C, Nathalie LAGE", "", "")
        aj("\cch\fin", "FRCCH0180", "IBM 42, Teresinha LIMBERTIE", "", "")
        aj("\cch\fin", "FRCCH0181", "HP VECTRA, Fatou KAMARA", "", "")
        aj("\cch\fin", "FRCCH0182", "HP VECTRA, Sylvie BALBASTRO", "", "")
        aj("\cch\fin", "FRCCH0223", "IBM, sylvie_pigeon", "", "")
        aj("\cch\fin", "FRCCH0224", "IBM michel_csanki", "", "")
        aj("\cch\fin", "FRCCH0230", "IBM M42, C Brossard", "", "")
        aj("\cch\fin", "FRCCH0231", "IBM M42, P Duquesnoy", "", "")
        aj("\cch\fin", "FRCCH0232", "IBM M42, C Boulanger", "", "")
        aj("\cch\fin", "FRCCH9803", "HP Vectra, Cécile BRETON", "", "")
        aj("\cch\hr", "FRCCH0009", "HP Omnibook XE3, Véronique COTELLE", "", "")
        aj("\cch\hr", "FRCCH0023", "IBM T30, Francis BERGERON", "", "")
        aj("\cch\hr", "FRCCH0029", "IBM M42, Catherine Bainvelzweig", "", "")
        aj("\cch\hr", "FRCCH0053", "IBM T40, JL Bouteloup", "", "")
        aj("\cch\it", "FRCCH0001", "Dell Latitude C400, Pierre Violent", "", "")
        aj("\cch\it", "FRCCH0002", "IBM T30, Xavier Wurmser", "", "")
        aj("\cch\it", "FRCCH0003", "IBM M42, Pierre VIOLENT", "", "")
        aj("\cch\it", "FRCCH0004", "IBM M42, Julien Roux", "", "")
        aj("\cch\it", "FRCCH0006", "HP Vectra,  Jean Cacan", "", "")
        aj("\cch\it", "FRCCH0007", "HP Vectra, Gilles Schwoebel", "", "")
        aj("\cch\it", "FRCCH0008", "Ordinateur de Sonia Likibi", "", "")
        aj("\cch\it", "FRCCH0010", "HP, Fayçal Bengatta", "", "")
        aj("\cch\it", "FRCCH0011", "Ordinateur de Thierry Mackel", "", "")
        aj("\cch\it", "FRCCH0012", "IBM M42, Pierre VIOLENT", "", "")
        aj("\cch\it", "FRCCH0013", "IBM M42, Help Desk 01", "", "")
        aj("\cch\it", "FRCCH0014", "IBM M42, Help Desk 02", "", "")
        aj("\cch\it", "FRCCH0015", "IBM M42, Help Desk 03", "", "")
        aj("\cch\it", "FRCCH0016", "IBM M42, Help Desk 04", "", "")
        aj("\cch\it", "FRCCH0018", "IBM T30, Michel Magnier", "", "")
        aj("\cch\it", "FRCCH0028", "IBM M42, Radhia Ben Younes", "", "")
        aj("\cch\it", "FRCCH0035", "Machine NT4 au Help Desk", "", "")
        aj("\cch\it", "FRCCH0036", "HP VECTRA, Salle Préparation (GOST,"","")", "", "")
        aj("\cch\it", "FRCCH0037", "IBM M42, Rodrigue Coffi", "", "")
        aj("\cch\it", "FRCCH9805", "Libre Service HelpDesk", "", "")
        aj("\cch\it", "FRCCH9999", "Essais Olivier Jourdan", "", "")
        aj("\cch\lgl", "FRCCH0068", "IBM T40, Patrick SCHWARTZ", "", "")
        aj("\cch\lgl", "FRCCH0089", "HP Omnibook, P SCHWARTZ", "", "")
        aj("\cch\lgl", "FRCCH0095", "hp vectra, N. AGUSTINA", "", "")
        aj("\cch\mgt", "FRCCH0005", "Portable HP, P.Delater", "", "")
        aj("\cch\mgt", "FRCCH0048", "IBM M42, Hayette BOUGUEROUCHE", "", "")
        aj("\cch\mgt", "FRCCH0069", "IBM M42, Sylvie NELLENBACH", "", "")
        aj("\cch\mgt", "FRCCH0139", "HP VECTRA, Pascal DELATER", "", "")
        aj("\cch\mgt", "FRCCH9501", "HP Vectra VE Myette Rapina", "", "")
        aj("\cch\mgt", "FRCCH9804", "HP Vectra, Julio MARTINEZ", "", "")
        aj("\cch\ogc", "FRCCH0030", "HP VECTRA, Naïma GRONDIN", "", "")
        aj("\cch\ogc", "FRCCH0054", "HP OMNIBOOK Eric hauss", "", "")
        aj("\cch\ssc", "FRCCH0019", "IBM T30, Fabrice Egloff", "", "")
        aj("\cch\ssc", "FRCCH0020", "IBM T30, Arnaud LOPEZ", "", "")
        aj("\cch\ssc", "FRCCH0032", "Marie Laure Pouteau (Expert Technique ICS,"","")", "", "")
        aj("\cch\ssc", "FRCCH0033", "IBM M42 Auditeur ICS", "", "")
        aj("\cch\ssc", "FRCCH0034", "IBM M42 Catherine Lemarie ICS", "", "")
        aj("\cch\ssc", "FRCCH0038", "IBM M42, Nicolas POISSON", "", "")
        aj("\cch\ssc", "FRCCH0039", "IBM T40, Lysiane HUSER", "", "")
        aj("\cch\ssc", "FRCCH0041", "IBM T30 François SECCHI", "", "")
        aj("\cch\ssc", "FRCCH0042", "IBM T40, Véronique LOMBREY", "", "")
        aj("\cch\ssc", "FRCCH0043", "HP Vectra 420TD, Phillipe FUSILLER", "", "")
        aj("\cch\ssc", "FRCCH0046", "IBM T40, Mickael GENDROT", "", "")
        aj("\cch\ssc", "FRCCH0050", "IBM M42, Véronique MADRANGE", "", "")
        aj("\cch\ssc", "FRCCH0051", "IBM T40, Philippe FUSILLER", "", "")
        aj("\cch\ssc", "FRCCH0063", "IBM M42, Samia GARECHE", "", "")
        aj("\cch\ssc", "FRCCH0065", "IBM T40, Laurent DROUHARD", "", "")
        aj("\cch\ssc", "FRCCH0076", "TOSHIBA Portable Tetra 8100 C Plichard(auditeur ICS,"","")", "", "")
        aj("\cch\ssc", "FRCCH0077", "IBM M42,  P Abry", "", "")
        aj("\cch\ssc", "FRCCH0079", "IBM M42, V Filippi", "", "")
        aj("\cch\ssc", "FRCCH0080", "Toshiba portable Tecra, V Fraysse", "", "")
        aj("\cch\ssc", "FRCCH0082", "IBM M42, K Rosa", "", "")
        aj("\cch\ssc", "FRCCH0083", "IBM M42, A Aguiar", "", "")
        aj("\cch\ssc", "FRCCH0084", "IBM M42, A Boulesteix", "", "")
        aj("\cch\ssc", "FRCCH0085", "IBM M42, S Dalboussiere", "", "")
        aj("\cch\ssc", "FRCCH0086", "IBM M42, T de Parceveaux", "", "")
        aj("\cch\ssc", "FRCCH0087", "Toshiba portable Tecra, L Croguennec", "", "")
        aj("\cch\ssc", "FRCCH0088", "IBM M42, C Cahuet", "", "")
        aj("\cch\ssc", "FRCCH0090", "IBM M42, V Villeneuve", "", "")
        aj("\cch\ssc", "FRCCH0091", "Portable HP, S Langlois", "", "")
        aj("\cch\ssc", "FRCCH0093", "IBM M42, C Pavlovic", "", "")
        aj("\cch\ssc", "FRCCH0096", "IBM M42, R Defer", "", "")
        aj("\cch\ssc", "FRCCH0097", "IBM T40, C Gatty", "", "")
        aj("\cch\ssc", "FRCCH0098", "HP Omnibook, L Montariol", "", "")
        aj("\cch\ssc", "FRCCH0099", "HP portable, T de Parceveaux", "", "")
        aj("\cch\ssc", "FRCCH0100", "Tecra portable, S Dalboussière", "", "")
        aj("\cch\ssc", "FRCCH0101", "HP Vectra, Nathalie MATHA", "", "")
        aj("\cch\ssc", "FRCCH0102", "HP Omnibook, Antoine SAILLY", "", "")
        aj("\cch\ssc", "FRCCH0103", "Toshiba Tecra 8100, Alain SOUBRIER", "", "")
        aj("\cch\ssc", "FRCCH0104", "HP Omnibook portable, Stephanie Langlois", "", "")
        aj("\cch\ssc", "FRCCH0105", "Toshiba tecra portable, C LEBIGOT", "", "")
        aj("\cch\ssc", "FRCCH0106", "Toshiba portable, auditeur ics", "", "")
        aj("\cch\ssc", "FRCCH0107", "IBM M42, F Margue", "", "")
        aj("\cch\ssc", "FRCCH0108", "IBM M42, V Jovanovic", "", "")
        aj("\cch\ssc", "FRCCH0109", "IBM M42, F Perrot", "", "")
        aj("\cch\ssc", "FRCCH0110", "Toshiba portable, C Blot", "", "")
        aj("\cch\ssc", "FRCCH0111", "HP VECTRA, Kathleen HOAREAU-MINNI", "", "")
        aj("\cch\ssc", "FRCCH0112", "IBM M42, F Tirel", "", "")
        aj("\cch\ssc", "FRCCH0114", "IBM M42, C Fourmentraux", "", "")
        aj("\cch\ssc", "FRCCH0115", "HP Vectra, S Gareche", "", "")
        aj("\cch\ssc", "FRCCH0119", "IBM M42,  Christine BLUNEAU MOREAU", "", "")
        aj("\cch\ssc", "FRCCH0121", "IBM M42, Katia BRIOLET", "", "")
        aj("\cch\ssc", "FRCCH0123", "IBM T40, Luis DA-SILVA", "", "")
        aj("\cch\ssc", "FRCCH0125", "HP Vectra, Anne ANDREOLI", "", "")
        aj("\cch\ssc", "FRCCH0126", "IBM M42, Catherine CORBEL", "", "")
        aj("\cch\ssc", "FRCCH0127", "Vectra vl 420 dt N Agustina", "", "")
        aj("\cch\ssc", "FRCCH0128", "IBM M42, Nadia MEREAU", "", "")
        aj("\cch\ssc", "FRCCH0130", "IBM M42, Catherine CHEBERT", "", "")
        aj("\cch\ssc", "FRCCH0131", "Compaq Armada E500, Valerie FRAYSSE", "", "")
        aj("\cch\ssc", "FRCCH0133", "IBM M42, Luis DA SILVA E SERA", "", "")
        aj("\cch\ssc", "FRCCH0134", "IBM M42,Cécile DA ROSA FERREIRA", "", "")
        aj("\cch\ssc", "FRCCH0135", "HP Vectra, Valerie JOLIBOIS", "", "")
        aj("\cch\ssc", "FRCCH0136", "IBM M42,  Alexandre MUGNIER", "", "")
        aj("\cch\ssc", "FRCCH0137", "IBM T40, Gilles CAYZAC", "", "")
        aj("\cch\ssc", "FRCCH0140", "HP Omnibook, Sandrine LUCBERNET", "", "")
        aj("\cch\ssc", "FRCCH0142", "IBM T30, Christophe PLICHARD", "", "")
        aj("\cch\ssc", "FRCCH0144", "IBM M42, Ali  AHMED", "", "")
        aj("\cch\ssc", "FRCCH0145", "IBM M42, Intérimaire 1 ICS", "", "")
        aj("\cch\ssc", "FRCCH0162", "IBMT30, Etienne NOUAT", "", "")
        aj("\cch\ssc", "FRCCH0163", "TOSHIBA TECRA 8100, Jean SABLON", "", "")
        aj("\cch\ssc", "FRCCH0170", "IBM T30, Céline RAFFARD", "", "")
        aj("\cch\ssc", "FRCCH0171", "IBM M42, Valérie JOLIBOIS", "", "")
        aj("\cch\ssc", "FRCCH0192", "IBM T30, Flore LAPORTE FAURET", "", "")
        aj("\cch\ssc", "FRCCH0193", "TOSHIBA, Jean-Michel DELINDE", "", "")
        aj("\cch\ssc", "FRCCH0194", "HP OMNIBOOK XE3, Géraldine ROFFIDAL", "", "")
        aj("\cch\ssc", "FRCCH0213", "IBM T40, Luis Da Silva E Serra", "", "")
        aj("\cch\ssc", "FRCCH0218", "HP Ominbook, S Bonzom", "", "")
        aj("\cch\ssc", "FRCCH0221", "HP, interimaire02_ics", "", "")
        aj("\cch\ssc", "FRCCH0222", "Arnaud LOPEZ", "", "")
        aj("\cch\ssc", "FRCCH0225", "IBM T30, Denis CAPPEAU", "", "")
        aj("\cch\ssc", "FRCCH0226", "IBM T40, Sylvain AST", "", "")
        aj("\cch\ssc", "FRCCH0227", "IBM T30, Vanessa DESROCHES", "", "")
        aj("\cch\ssc", "FRCCH0228", "IBM T30, Emmanuelle DARPEIX", "", "")
        aj("\cch\ssc", "FRCCH0229", "IBM T30, Pascal DERMINOT", "", "")
        aj("\cch\ssc", "FRCCH9504", "COMPAQ ARMADA E500, Marlène DUDZIK", "", "")
        aj("\cch\ssc", "FRCCH9505", "HP VECTRA, Clara RANDRIAMAHOLY", "", "")
        aj("\cch\ssc", "FRCCH9801", "Toshiba tecra 8110 Mireille BARBE", "", "")
        aj("\cch\tas", "FRCCH0040", "HP Vectra VL 420 MT, Jocelyne CONNAN", "", "")
        aj("\cch\tas", "FRCCH0045", "HP Vectra, S AIT ALI", "", "")
        aj("\cch\tas", "FRCCH0141", "HP Vectra, TAS vide 2 (MPEREZ,"","")", "", "")
        aj("\cch\tas", "FRCCH0143", "Hp vectra, I maddah", "", "")
        aj("\cch\tas", "FRCCH0146", "HP Vectra, L Masson", "", "")
        aj("\cch\tas", "FRCCH0147", "HP Vectra, N Brasselet", "", "")
        aj("\cch\tas", "FRCCH0148", "HP Vectra, J Cambonie", "", "")
        aj("\cch\tas", "FRCCH0149", "HP Vectra, G Villeneuve", "", "")
        aj("\cch\tas", "FRCCH0150", "HP Vectra, V Bollini", "", "")
        aj("\cch\tas", "FRCCH0151", "HP Vectra, JC Becamel", "", "")
        aj("\cch\tas", "FRCCH0152", "HP Vectra, S.PICHERIT", "", "")
        aj("\cch\tas", "FRCCH0154", "HP Vectra, P Elkouby", "", "")
        aj("\cch\tas", "FRCCH0155", "HP VECTRA, Patrick TURLURE", "", "")
        aj("\cch\tas", "FRCCH0158", "HP Vectra, Sami_TIDMINT", "", "")
        aj("\cch\tas", "FRCCH0159", "HP Vectra, Melanie_Bernard", "", "")
        aj("\cch\tas", "FRCCH0160", "HP Vectra, Jean-Christ_THEREAU", "", "")
        aj("\cch\tas", "FRCCH0164", "HP Vectra, Marlou_LEE", "", "")
        aj("\cch\tas", "FRCCH0165", "HP Vectra, samia_ait-ali", "", "")
        aj("\cch\tas", "FRCCH0166", "HP Vectra,catherine_couture", "", "")
        aj("\cch\tas", "FRCCH0167", "HP Vectra, Catherine_bonamy", "", "")
        aj("\cch\tas", "FRCCH0168", "HP Vectra, toumany_sidibe", "", "")
        aj("\cch\tas", "FRCCH0169", "HP Vectra, francisco_ordonez", "", "")
        aj("\cch\tas", "FRCCH0172", "HP Vectra, stephanie_hoenen", "", "")
        aj("\cch\tas", "FRCCH0173", "HP Vectra, catherine_mathieux", "", "")
        aj("\cch\tas", "FRCCH0174", "HP Vectra, dorothee_guerry", "", "")
        aj("\cch\tas", "FRCCH0175", "HP Vectra, christiane hazebroucq", "", "")
        aj("\cch\tas", "FRCCH0176", "HP Vectra, cem_ecevit", "", "")
        aj("\cch\tas", "FRCCH0177", "HP Vectra, aidee_n'diaye", "", "")
        aj("\cch\tas", "FRCCH0178", "PC Portable HP Omnibook, amedee_belfodil", "", "")
        aj("\cch\tas", "FRCCH0183", "HP Vectra, raby_sy", "", "")
        aj("\cch\tas", "FRCCH0184", "HP Vectra, suzan_guclu", "", "")
        aj("\cch\tas", "FRCCH0185", "HP Vectra, elizabeth_calvet", "", "")
        aj("\cch\tas", "FRCCH0186", "HP Vectra, A PASQUET", "", "")
        aj("\cch\tas", "FRCCH0187", "HP Vectra,  F RAKOTOMAVO", "", "")
        aj("\cch\tas", "FRCCH0188", "HP Vectra, M LEBON", "", "")
        aj("\cch\tas", "FRCCH0189", "HP Vectra, M PEREZ", "", "")
        aj("\cch\tas", "FRCCH0190", "HP Vectra, C MACORAL", "", "")
        aj("\cch\tas", "FRCCH0195", "HP Vectra, A ROUGEAUX", "", "")
        aj("\cch\tas", "FRCCH0196", "HP Vectra,  E ANTON", "", "")
        aj("\cch\tas", "FRCCH0197", "HP Vectra, S DESANTIS", "", "")
        aj("\cch\tas", "FRCCH0198", "HP Vectra, C DUMOULIN", "", "")
        aj("\cch\tas", "FRCCH0199", "HP Vectra, P HOUL", "", "")
        aj("\cch\tas", "FRCCH0200", "HP Vectra, L MARQUES", "", "")
        aj("\cch\tas", "FRCCH0201", "HP Vectra, F DELIBES", "", "")
        aj("\cch\tas", "FRCCH0202", "HP Vectra, M PULLIAT", "", "")
        aj("\cch\tas", "FRCCH0203", "HP portable, J CONNAN", "", "")
        aj("\cch\tas", "FRCCH0204", "HP VECTRA, A FLAMANT", "", "")
        aj("\cch\tas", "FRCCH0205", "HP VECTRA, M PUY", "", "")
        aj("\cch\tas", "FRCCH0206", "HP VECTRA, E NGO TONA", "", "")
        aj("\cch\tas", "FRCCH0207", "HP VECTRA, S VALETTE", "", "")
        aj("\cch\tas", "FRCCH0208", "HP VECTRA, F MONDESIR", "", "")
        aj("\cch\tas", "FRCCH0209", "HP Vectra, monique_uhalde", "", "")
        aj("\cch\tas", "FRCCH0210", "HP Vectra, vivianne_thomas", "", "")
        aj("\cch\tas", "FRCCH0211", "HP Vectra, jean-claude_dralez", "", "")
        aj("\cch\tas", "FRCCH0212", "HP Vectra, claude_fite", "", "")
        aj("\cch\tas", "FRCCH0215", "HP Vectra, nathalie_simon", "", "")
        aj("\cch\tas", "FRCCH0216", "HP Vectra, suzanne_szafranski", "", "")
        aj("\cch\tas", "FRCCH0217", "HP Vectra, amedee_belfodil", "", "")
        aj("\cch\tas", "FRCCH0219", "HP Vectra, comite_entreprise-TA", "", "")
        aj("\cch\tas", "FRCCH0220", "HP Vectra, L Lemoign", "", "")
        aj("\cha", "FRCHA0001", "Portable Claude Jaussin", "", "")
        aj("\cha", "FRCHA0003", "ordi Dominique Parrot", "", "")
        aj("\cha", "FRCHA0004", "", "", "")
        aj("\cli", "FRCLI0001", "Micro 2 de K. Kaci", "", "")
        aj("\cli", "FRCLI0002", "Micro de P. Imbault", "", "")
        aj("\cli", "FRCLI0003", "micro W98 P. imbault", "", "")
        aj("\cli", "FRCLI0007", "Micro de Super Kamal", "", "")
        aj("\cli", "FRCLI0008", "Micro de M. Munoz", "", "")
        aj("\cli", "FRCLI0009", "Saisie CPG N°2", "", "")
        aj("\cli", "FRCLI0010", "", "", "")
        aj("\cli", "FRCLI0011", "HP Vectra, Saisie CPG 1", "", "")
        aj("\cli", "FRCLI0012", "HP Vectra, david_vilbert", "", "")
        aj("\cli", "FRCLI0013", "PC Portable Toshiba, karine_vrigneau", "", "")
        aj("\cli", "FRCLI0014", "HP Vectra, catherine_mathieu", "", "")
        aj("\cli", "FRCLI0015", "IBM , sandrine_duchesne", "", "")
        aj("\cli", "FRCLI0016", "PC Taïwannais P III 600, fabienne_blin", "", "")
        aj("\cli", "FRCLI0017", "IBM, diem_pham", "", "")
        aj("\cli", "FRCLI0018", "IBM, caroline_doucet", "", "")
        aj("\cli", "FRCLI0019", "HP , SAISIE MICROBIO", "", "")
        aj("\cli", "FRCLI0020", "HP charlie_remy", "", "")
        aj("\cli", "FRCLI0021", "HP, segolene_oudin", "", "")
        aj("\cli", "FRCLI0022", "Portable IBM T30, anne_hays", "", "")
        aj("\cli", "FRCLI0023", "HP, chrystelle_hubert", "", "")
        aj("\cli", "FRCLI0024", "IBM M40, celine_meyer", "", "")
        aj("\cli", "FRCLI0025", "IBM M40, audrey_taine", "", "")
        aj("\cli", "FRCLI0026", "IBM T30, marie-cecile_krief", "", "")
        aj("\cli", "FRCLI0027", "HP, karine_peixoto", "", "")
        aj("\cli", "FRCLI0028", "Portable IBM R30, marie-rose_munoz", "", "")
        aj("\cli", "FRCLI0029", "HP, juliette_darosa", "", "")
        aj("\cli", "FRCLI0030", "IBM M40, beatrice_miguel", "", "")
        aj("\cli", "FRCLI0031", "HP, saisie 3ème Etage", "", "")
        aj("\cli", "FRCLI0032", "HP, evelyne_mence", "", "")
        aj("\cli", "FRCLI0033", "HP, Saisie 3ème", "", "")
        aj("\cli", "FRCLI0034", "IBM M40, Labo Poste Correcteur", "", "")
        aj("\cli", "FRCLI0035", "HP IPC, rozenne_boheas", "", "")
        aj("\cli", "FRCLI0036", "HP, sylvie_meurillon", "", "")
        aj("\cli", "FRCLI0037", "HP Vectra, Saisie 2ème", "", "")
        aj("\cli", "FRCLI0038", "HP IPC, odile_simonnet", "", "")
        aj("\cli", "FRCLI0039", "IBM M40, olivier_juif", "", "")
        aj("\cli", "FRCLI0040", "IBM M40, delphine_demay", "", "")
        aj("\cli", "FRCLI0041", "à rechercher!!!!RDC", "", "")
        aj("\cli", "FRCLI0042", "à rechercher!!!!RDC", "", "")
        aj("\cli", "FRCLI0043", "IBM T30, patrick_reboul", "", "")
        aj("\cli", "FRCLI0044", "IBM T30, bernard_vivancos", "", "")
        aj("\cli", "FRCLI0045", "HP Vectra, chantal_lebeau", "", "")
        aj("\cli", "FRCLI0046", "IBM M40, afonso", "", "")
        aj("\cli", "FRCLI0047", "HP Vectra, jocelyne_poinsteau", "", "")
        aj("\cli", "FRCLI0048", "HP Vectra, annick_proux", "", "")
        aj("\cli", "FRCLI0049", "", "", "")
        aj("\cli", "FRCLI0050", "", "", "")
        aj("\cli", "FRCLI0051", "", "", "")
        aj("\cli", "FRCLI0052", "", "", "")
        aj("\cli", "FRCLI0053", "", "", "")
        aj("\cli", "FRCLI0054", "", "", "")
        aj("\cli", "FRCLI0055", "", "", "")
        aj("\cli", "FRCLI0056", "", "", "")
        aj("\cli", "FRCLI0057", "", "", "")
        aj("\cli", "FRCLI0058", "", "", "")
        aj("\cli", "FRCLI0059", "", "", "")
        aj("\dun", "FRDUN0001", "HP Anne Marie Renau Tba", "", "")
        aj("\dun", "FRDUN0002", "HP VLI8 PII 400 Luis Arribas tba", "", "")
        aj("\dun", "FRDUN0003", "Toshiba SP6000, Thierry MOTTE", "", "")
        aj("\dun", "FRDUN0004", "IBM M42, Nathalie BERQUE", "", "")
        aj("\equ", "FREQU0001", "T40, Denis ADE", "", "")
        aj("\evr", "frevr0001", "IBM T30, Christian DEMANZE", "", "")
        aj("\evr", "frevr0002", "ZETAFAX", "", "")
        aj("\evr", "FREVR0003", "IBMT40, Arnaud MARGUERITTE", "", "")
        aj("\evr", "FREVR0004", "IBM T40, José CORREIA", "", "")
        aj("\evr", "FREVR0005", "IBM M42, Chimie élémentaire 1", "", "")
        aj("\evr", "FREVR0006", "IBM M42, Chimie élémentaire 2", "", "")
        aj("\evr", "FREVR0007", "IBM M42, Tania Di GIOIA", "", "")
        aj("\evr", "FREVR0008", "IBM M42, Stéphanie LAUQUIN", "", "")
        aj("\evr", "FREVR0009", "IBM M42, Chimie élémentaire", "", "")
        aj("\evr", "FREVR0010", "IBM M42, Chimie élémentaire", "", "")
        aj("\evr", "FREVR0011", "IBM M42, Stéphanie LAUQUIN", "", "")
        aj("\evr", "FREVR0012", "IBM M42, PC SKALAR BD05", "", "")
        aj("\evr", "FREVR0013", "IBM M42, PC HTC GESTION LWE", "", "")
        aj("\evr", "FREVR0014", "IBM M42, PC COT Eaux Naturelles", "", "")
        aj("\evr", "FREVR0015", "IBM M42, PC Eaux Naturelles", "", "")
        aj("\leh", "FRLEH0001", "IBM M42, Secrétariat Industrie HARFLEUR", "", "")
        aj("\lro", "FRLRO0001", "Toshiba SP4200, Contrôleur AGR", "", "")
        aj("\mtz", "FRMTZ0001", "IBM M42, Franck ROTELLA", "", "")
        aj("\osy", "FROSY0001", "IBM T30, En attente Nom Utilisateur (Alphatest,"","")", "", "")
        aj("\osy", "FROSY0002", "IBM M42, Frédéric LAUTI (Alphatest,"","")", "", "")
        aj("\osy", "FROSY0003", "IBM T30,  Jean-Paul Berteaux (Alphatest,"","")", "", "")
        aj("\osy", "FROSY0004", "IBM T30, Attente non Utilisateur (Alphatest,"","")", "", "")
        aj("\osy", "FROSY0005", "IBM M42, Christophe POISSON", "", "")
        aj("\pdb", "FRPDB0001", "HP VECTRA XE310, Nathalie Young", "", "")
        aj("\pdb", "FRPDB0002", "Type inconnu, Yves Jacolin", "", "")
        aj("\pdb", "FRPDB0003", "HP Vectra XE310, Laurent MACARIO", "", "")
        aj("\qxb", "FRQXB0001", "IBM T30, Jean-Louis BENEDETTI", "", "")
        aj("\qxb", "FRQXB0002", "IBM M42, Céline MICHEL", "", "")
        aj("\qxb", "FRQXB0003", "IBM M42, Celine Michel", "", "")
        aj("\qxb", "FRQXB0004", "IBM M42, Fabrice Antiquario", "", "")
        aj("\qxb", "FRQXB0005", "IBM T40, Jérome VANNESSON", "", "")
        aj("\qxb", "FRQXB0006", "IBM M42, Jocelyne LEFEVRE", "", "")
        aj("\qxb", "FRQXB0007", "IBM M42, Luc VAUFREYDAZ", "", "")
        aj("\qxb", "FRQXB0008", "IBM M42, Sylvie MONSERRAT", "", "")
        aj("\qxb", "FRQXB0009", "IBM M42, Magalie COUZON", "", "")
        aj("\qxb", "FRQXB0010", "IBM M42, Bruno DULISCOUET", "", "")
        aj("\qxb", "FRQXB0011", "HP VECTRA, Pc_Labo Peinture", "", "")
        aj("\qxb", "FRQXB0012", "HP Vectra VL, Josiane PASQUET", "", "")
        aj("\qxb", "FRQXB0013", "IBM T30, Marc BLUMET", "", "")
        aj("\qxb", "FRQXB0014", "IBM M42, Michèle GEORGES", "", "")
        aj("\qxb", "FRQXB0015", "IBM T30, Valérie MIDENA", "", "")
        aj("\qxb", "FRQXB0016", "HP Vectra, Josiane JONCQUER", "", "")
        aj("\qxb", "FRQXB0017", "IBM T30, Frederique LORMER", "", "")
        aj("\qxb", "FRQXB0018", "IBM T30, Magali BEDOC", "", "")
        aj("\qxb", "FRQXB9501", "HP Vectra, Stagiaire", "", "")
        aj("\qxb", "FRQXB9502", "HP Vectra VL, Laboratoire Golf", "", "")
        aj("\qxb", "FRQXB9503", "Hp Vectra, Labo test saisie", "", "")
        aj("\qxb", "FRQXB9801", "HP Vectra VL 420 FT, Ancien poste Jocelyne LEFEVRE", "", "")
        aj("\qxb", "FRQXB9802", "Portable, Magali COUZON, accès RS-6000", "", "")
        aj("\rou", "FRCCH0031", "IBM T30, Cédric ADAM (Rouen,"","")", "", "")
        aj("\rou", "FRROU0001", "IBM T40, Stépane Joly", "", "")
        aj("\rou", "FRROU0002", "IBM M42 , Claudine Corbou", "", "")
        aj("\rou", "FRROU0003", "IBM M42, Isabelle Celdran", "", "")
        aj("\rou", "FRROU0004", "HP, Marc Iacono", "", "")
        aj("\rou", "FRROU0005", "IBM M42, Gerard Michel", "", "")
        aj("\rou", "FRROU0006", "HP, Nathalie Quertier", "", "")
        aj("\rou", "FRROU0007", "IBM M42, Jocelyne Bataille", "", "")
        aj("\rou", "FRROU0008", "IBM T30, Xavier Bourguignon", "", "")
        aj("\rou", "FRROU0009", "HP, Pascale Hossin", "", "")
        aj("\rou", "FRROU0010", "HP Vectra, Eva Marti Plaza", "", "")
        aj("\rou", "FRROU0011", "IBM M42, Armelle Leroux", "", "")
        aj("\rou", "FRROU0012", "IBM M42, Laurence Lefevre", "", "")
        aj("\rou", "FRROU0013", "Toshiba Sat, Pascal Chaplot", "", "")
        aj("\rou", "FRROU0014", "HP, Eric Lacaille", "", "")
        aj("\rou", "FRROU0015", "IBM M42, Patrick moury", "", "")
        aj("\rou", "FRROU0016", "IBM M42, Sophie Pezier", "", "")
        aj("\rou", "FRROU0017", "Toshiba 1900, Andrea Baietto", "", "")
        aj("\rou", "FRROU0018", "HP VL400, Christelle Desfosses", "", "")
        aj("\rou", "FRROU0019", "Toshiba, Jeremy lacour", "", "")
        aj("\rou", "FRROU0020", "IBM M42, Franck Dupont", "", "")
        aj("\rou", "FRROU0021", "Toshiba 1400, Franck Dupont", "", "")
        aj("\rou", "FRROU0022", "HP, Gael Mauvieux", "", "")
        aj("\rou", "FRROU0023", "IBM T40, Marc Iacono", "", "")
        aj("\rou", "FRROU0024", "Toshiba 1900, Patrick Moury", "", "")
        aj("\rou", "FRROU0025", "IBM M42, Silo Elie 1", "", "")
        aj("\rou", "FRROU0026", "IBM M42, Silo Elie 2", "", "")
        aj("\rou", "FRROU0027", "IBM T30, Vincent Poudevigne", "", "")
        aj("\set", "FRSET0001", "IBM M42, Olivier Blanchet", "", "")
        aj("\set", "FRSET0002", "IBM M42, Carole Foury", "", "")
        aj("\set", "FRSET0003", "IBM T40, Pierre Deschamps", "", "")
        aj("\xxx", "FRXXX0001", "PC de P.Delater chez lui (HP Vectra,"","")", "", "")
    End Sub

    ' Interface IE
    ' Initialisation propre du document IE
    Private Sub IEDoc_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles IEDoc.DocumentCompleted
        If IEDoc.Document Is Nothing Then Exit Sub

        Dim d = IEDoc.Document
        ' 2021-09-19 Removed after switching to WebBrowser.  ToDo: Fix it
        'IEDoc.TheaterMode = True
        'd.createStyleSheet.cssText =
        '  "BODY      {color: #000000; font: 10pt Tahoma, Arial;}" &
        '  "TD        {color: #000000; font: 8pt Tahoma, Arial;}" &
        '  "H1        {color: #FF3300; font: 13pt Tahoma, Arial; font-weight:bold; border-bottom-style: solid; border-bottom-width: 2px}" &
        '  "A:link    {color: #0000FF; font: 10pt Tahoma, Arial; font-weight:bold}" &
        '  "A:visited {color: #FF00FF; font: 10pt Tahoma, Arial; font-weight:bold}"
        'd.body.Style.marginTop = "4pt"
        d.Body.InnerHtml = "Selectionnez le site à analyser (exemple: cch) et cliquez sur le bouton Analyser."
    End Sub

    ' Utilitaire: rafaîchit la fenêtre IE
    Sub RefreshIE()
        Do
            Application.DoEvents()
        Loop Until IEDoc.ReadyState = WebBrowserReadyState.Complete
    End Sub

    ' Affichage HTML
    Sub Affiche()
        sHTML = New StringBuilder
        Dim enumSites As IDictionaryEnumerator = slSitesAD.GetEnumerator()
        While enumSites.MoveNext
            AfficheUnSite(CType(enumSites.Value, SiteAD))
        End While
        IEDoc.Document.Body.InnerHtml = sHTML.ToString
        sHTML = Nothing
    End Sub

    Function sColorWeb(i As Integer) As String
        i = i Mod tColor.Length
        Return "#" & String.Format("{0:X02}{1:X02}{2:X02}", tColor(i).R, tColor(i).G, tColor(i).B)
    End Function

    Sub AfficheUnSite(s As SiteAD)
        sHTML.Append("<H1>Site: " & s.sSite & " " & s.sComment & "</H1>" & vbCrLf)

        ' La liste des sous-OUs
        sHTML.Append("<table border=""1"" cellspacing=""0"" style=""border-collapse: collapse; margin-top:5"" bordercolor=""#000000""><tr>" & vbCrLf)
        Dim enumOU As IDictionaryEnumerator = s.slOU.GetEnumerator()
        Dim i As Integer
        While enumOU.MoveNext
            sHTML.Append("<td width=""60"" bgcolor=""" & sColorWeb(i) & """>")
            sHTML.Append(CType(enumOU.Key, String))
            sHTML.Append("</td>" & vbCrLf)
            i += 1
        End While
        sHTML.Append("</tr></table><br>" & vbCrLf)

        If Not (s.slComp00 Is Nothing) Then AfficheMachines(s.slOU, s.slComp00, s.sSite, False)
        If Not (s.slComp95 Is Nothing) Then AfficheMachines(s.slOU, s.slComp95, s.sSite, False)
        If Not (s.slComp98 Is Nothing) Then AfficheMachines(s.slOU, s.slComp98, s.sSite, False)
        If Not (s.slCompXX Is Nothing) Then AfficheMachines(s.slOU, s.slCompXX, s.sSite, True)

        sHTML.Append("<BR><BR>" & vbCrLf)
    End Sub

    Sub AfficheMachines(slOU As SortedList, slComputers As SortedList, sSite As String, bListeXX As Boolean)
        ' Si la liste est vide, on dégage sans traitement
        If slComputers.Count = 0 Then Exit Sub

        If bListeXX Then sHTML.Append("<BR>" & vbCrLf)

        sHTML.Append("<table border=""1"" cellspacing=""0"" style=""border-collapse: collapse; margin-top:5"" bordercolor=""#000000"">" & vbCrLf)

        ' On détermine le mini et le maxi de la collection à afficher
        Dim iMin, iMax As Integer
        Dim m As Match
        iMin = 9999
        iMax = 0
        Dim iComp As Integer = 0     ' Pour la listeXX
        Dim enumComp As IDictionaryEnumerator = slComputers.GetEnumerator()
        While enumComp.MoveNext
            If bListeXX Then
                iComp += 1
            Else
                m = rNum.Match(CType(enumComp.Key, String))
                iComp = CInt(m.Groups(1).Value)  ' L'indice 0 est le match de la chaîne complète
            End If
            iMin = Math.Min(iMin, iComp)
            iMax = Math.Max(iMax, iComp)
        End While

        ' iMin0 = début d'affichage. L'affichage commence aux valeurs 1,11,21,31...
        Dim iMin0 As Integer
        iMin0 = iMin - (iMin - 1) Mod 10

        ' On remplit le tableau de compupters.
        ' iRang-1 donne le rang de l'OU dans slOU de façon
        ' à afficher avec la bonne couleur, ou 0 s'il n'y a pas d'ordinateur, ou -1 si inconnu
        Dim tComp(iMax - iMin0 + 11) As Computer
        iComp = 0
        enumComp = slComputers.GetEnumerator()
        While enumComp.MoveNext
            If bListeXX Then
                iComp += 1
            Else
                m = rNum.Match(CType(enumComp.Key, String))
                iComp = CInt(m.Groups(1).Value)  ' L'indice 0 est le match de la chaîne complète
            End If
            Dim theComputer As Computer
            theComputer = CType(enumComp.Value, Computer)
            Dim iRang As Integer = slOU.IndexOfKey(theComputer.sPos)
            If iRang >= 0 Then iRang += 1
            theComputer.iRang = iRang
            tComp(iComp - iMin0) = theComputer
        End While

        ' Affichage HTML...
        Dim iMin00 As Integer = iMin0
        Dim ic As Integer, j As Integer
        Do
            sHTML.Append("<tr>" & vbCrLf)
            For i As Integer = 0 To 9
                j = iMin00 + i
                If j > iMax Then Exit For

                sHTML.Append("<td width=""60"" ")
                If tComp(j - iMin0) Is Nothing Then
                    ic = 0
                Else
                    ic = tComp(j - iMin0).iRang
                    If tComp(j - iMin0).sDescription <> "" Then
                        sHTML.Append("title=""" & Replace(tComp(j - iMin0).sDescription, """", "'") & """ ")
                    End If
                End If

                If ic > 0 Then
                    sHTML.Append("bgcolor=""" & sColorWeb(ic - 1) & """>")
                ElseIf ic < 0 Then
                    sHTML.Append("bgcolor=""#666666""><font color=""#FFFFFF"">")
                Else
                    sHTML.Append("><font color=""#CCCCCC"">")
                End If

                If j >= iMin0 And j <= iMax Then
                    If tComp(j - iMin0) IsNot Nothing Then
                        sHTML.Append(tComp(j - iMin0).sComputer)
                    Else
                        sHTML.Append("fr" & LCase(sSite) & String.Format("{0:D04}", j))
                    End If
                Else
                    sHTML.Append("&nbsp;")
                End If

                sHTML.Append("</td>")

            Next
            iMin00 += 10
            sHTML.Append("</tr>" & vbCrLf)
        Loop Until iMin00 > iMax

        sHTML.Append("</table>" & vbCrLf)
    End Sub

    ' Ajout d'une machine
    Sub aj(sPos As String, sComputer As String, sDescription As String, sWhenCreated As String, sWhenChanged As String)
        sPos = LCase(sPos)
        If VB.Left(sPos, 1) = "\" Then sPos = Mid(sPos, 2)

        ' On détermine la clé du site, la partie avant le premier \
        Dim sKey As String
        Dim pBS As Integer
        pBS = sPos.IndexOf("\"c)
        If pBS < 0 Then pBS = Len(sPos)
        sKey = VB.Left(sPos, pBS)

        ' Ajout à la liste
        Dim lvi As ListViewItem
        lvi = lvListe.Items.Add(sComputer)
        lvi.SubItems.Add(UCase(sKey))
        lvi.SubItems.Add(sPos)
        lvi.SubItems.Add(sDescription)
        lvi.SubItems.Add(sWhenCreated)
        lvi.SubItems.Add(sWhenChanged)

        ' On recherche le site dans slSitesAD en le créant si besoin est
        Dim sad As SiteAD
        If slSitesAD.ContainsKey(sKey) Then
            sad = slSitesAD(sKey)
        Else
            sad = New SiteAD With {
                .sSite = UCase(sKey),
                .slOU = New SortedList,
                .slComp00 = New SortedList,
                .slComp95 = New SortedList,
                .slComp98 = New SortedList,
                .slCompXX = New SortedList
            }
            slSitesAD.Add(sKey, sad)
        End If

        ' Mise à jour de la liste des sous-OUs du site
        If Not sad.slOU.Contains(sPos) Then sad.slOU.Add(sPos, Nothing)

        ' Analyse du nom de machine de façon à l'ajouter dans la bonne liste
        sComputer = UCase(sComputer)

        Dim theComputer As Computer
        theComputer = New Computer
        With theComputer
            .sComputer = sComputer
            .sPos = sPos
            .sDescription = sDescription
        End With

        If r95.Match(sComputer).Success And StrComp(sKey, Mid(sComputer, 3, 3), CompareMethod.Text) = 0 Then
            If Not sad.slComp95.ContainsKey(sComputer) Then sad.slComp95.Add(sComputer, theComputer)
        ElseIf r98.Match(sComputer).Success And StrComp(sKey, Mid(sComputer, 3, 3), CompareMethod.Text) = 0 Then
            If Not sad.slComp98.ContainsKey(sComputer) Then sad.slComp98.Add(sComputer, theComputer)
        ElseIf r00.Match(sComputer).Success And StrComp(sKey, Mid(sComputer, 3, 3), CompareMethod.Text) = 0 And Mid(sComputer, 6, 2) <> "99" And Mid(sComputer, 6, 4) <> "0000" Then
            If Not sad.slComp00.ContainsKey(sComputer) Then sad.slComp00.Add(sComputer, theComputer)
        Else
            If Not sad.slCompXX.ContainsKey(sComputer) Then sad.slCompXX.Add(sComputer, theComputer)
        End If

    End Sub

    ' Interface utilisateur de la liste
    Private iColTri As Integer = -1     ' Colonne de tri

    Private iSensTri As Integer         ' Ordre 1=ascendant, -1=descendant


    ' Copie dans le presse-papiers
    Private Sub cmdCopie_Click(sender As Object, e As EventArgs) Handles cmdCopie.Click
        Dim sbPP As New StringBuilder
        For i As Integer = 0 To lvListe.Columns.Count - 1
            If i > 0 Then sbPP.Append(Chr(9))
            sbPP.Append(lvListe.Columns(i).Text)
        Next
        sbPP.Append(vbCrLf)
        For Each lvi As ListViewItem In lvListe.Items
            sbPP.Append(lvi.Text)
            For i As Integer = 1 To lvi.SubItems.Count - 1
                sbPP.Append(vbTab & lvi.SubItems(i).Text)
            Next
            sbPP.Append(vbCrLf)
        Next
        Clipboard.SetDataObject(sbPP.ToString)
    End Sub

    Private Sub lvListe_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lvListe.ColumnClick
        If iColTri <> e.Column Then
            iColTri = e.Column
            iSensTri = 1
        Else
            iSensTri = -iSensTri
        End If
        lvListe.ListViewItemSorter = New ListViewItemComparer(iColTri, iSensTri)
    End Sub

End Class

' Implémentation du tri de la liste par n'importe quelle colonne
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
