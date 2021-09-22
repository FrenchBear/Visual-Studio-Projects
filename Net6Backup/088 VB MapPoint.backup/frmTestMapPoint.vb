' MapPoint
' Essais de génération de route et optimisation en VB avec MapPoint
' 2003-10-26    PV
' 2012-02-25	PV  VS2010  For now, MapPoint is not installed...


Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Code généré par le Concepteur Windows Form "

    Public Sub New()
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Ajoutez une initialisation quelconque après l'appel InitializeComponent()

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
    Friend WithEvents lstTrace As System.Windows.Forms.ListBox
    Friend WithEvents btnGrenoble As System.Windows.Forms.Button
    Friend WithEvents btnRoute As System.Windows.Forms.Button
    Friend WithEvents MappointControl1 As AxMapPoint.AxMappointControl
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.MappointControl1 = New AxMapPoint.AxMappointControl
        Me.lstTrace = New System.Windows.Forms.ListBox
        Me.btnGrenoble = New System.Windows.Forms.Button
        Me.btnRoute = New System.Windows.Forms.Button
        CType(Me.MappointControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MappointControl1
        '
        Me.MappointControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MappointControl1.Enabled = True
        Me.MappointControl1.Location = New System.Drawing.Point(8, 8)
        Me.MappointControl1.Name = "MappointControl1"
        Me.MappointControl1.OcxState = CType(resources.GetObject("MappointControl1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.MappointControl1.Size = New System.Drawing.Size(368, 488)
        Me.MappointControl1.TabIndex = 0
        '
        'lstTrace
        '
        Me.lstTrace.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstTrace.Location = New System.Drawing.Point(384, 40)
        Me.lstTrace.Name = "lstTrace"
        Me.lstTrace.Size = New System.Drawing.Size(240, 459)
        Me.lstTrace.TabIndex = 1
        '
        'btnGrenoble
        '
        Me.btnGrenoble.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGrenoble.Location = New System.Drawing.Point(384, 8)
        Me.btnGrenoble.Name = "btnGrenoble"
        Me.btnGrenoble.Size = New System.Drawing.Size(75, 23)
        Me.btnGrenoble.TabIndex = 2
        Me.btnGrenoble.Text = "PushPin"
        '
        'btnRoute
        '
        Me.btnRoute.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRoute.Location = New System.Drawing.Point(472, 8)
        Me.btnRoute.Name = "btnRoute"
        Me.btnRoute.Size = New System.Drawing.Size(75, 23)
        Me.btnRoute.TabIndex = 3
        Me.btnRoute.Text = "Route"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(632, 502)
        Me.Controls.Add(Me.btnRoute)
        Me.Controls.Add(Me.btnGrenoble)
        Me.Controls.Add(Me.lstTrace)
        Me.Controls.Add(Me.MappointControl1)
        Me.Name = "Form1"
        Me.Text = "Test MapPoint"
        CType(Me.MappointControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Trace("Form1_Load; appel MappointControl1.NewMap geoMapEurope")
        'MappointControl1.NewMap(MapPoint.GeoMapRegion.geoMapEurope)
        Trace("Form1_Load; appel MappointControl1.NewMap geoMapNorthAmerica")
        MappointControl1.NewMap(MapPoint.GeoMapRegion.geoMapNorthAmerica)
    End Sub

    Private Sub Form1_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Trace("Form1_Closing")
        MappointControl1.ActiveMap.Saved = True
    End Sub

    Private Sub btnGrenoble_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrenoble.Click
        Dim oMap As MapPoint.Map
        oMap = MappointControl1.ActiveMap

        Trace("AddPushpin")
        'oMap.AddPushpin(oMap.FindResults("GRenoble, 38000")(1))
        oMap.AddPushpin(oMap.FindResults("Des Moines,IA")(1))
        Trace("Après AddPushPin")
    End Sub

    Private Sub btnRoute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRoute.Click
        Dim objMap As MapPoint.Map
        objMap = MappointControl1.ActiveMap

        Dim objRoute As MapPoint.Route
        objRoute = objMap.ActiveRoute

        'AjouteWayPoint(objMap, objRoute, "Grenoble, 38000")
        'AjouteWayPoint(objMap, objRoute, "Bourg-en-Bresse, 01000")
        'AjouteWayPoint(objMap, objRoute, "Chambéry, 73000")
        'AjouteWayPoint(objMap, objRoute, "Lyon, 69000")
        'AjouteWayPoint(objMap, objRoute, "Annecy, 74000")
        'AjouteWayPoint(objMap, objRoute, "Grenoble, 38000")

        AjouteWayPoint(objMap, objRoute, "Des Moines, IA")
        AjouteWayPoint(objMap, objRoute, "Northfield, MN")

        Trace("Appel objRoute.Waypoints.Optimize")
        objRoute.Waypoints.Optimize()
        Trace("Appel objRoute.Calculate")
        objRoute.Calculate()
        Trace("Calcul terminé, distance = " & objRoute.Distance)
        Trace("Durée conduite = " & objRoute.DrivingTime)
    End Sub

    Sub AjouteWayPoint(ByRef objMap As MapPoint.Map, ByRef objRoute As MapPoint.Route, ByRef sAdresse As String)
        Trace("Ajout WayPoint '" & sAdresse & "'")
        objRoute.Waypoints.Add(objMap.FindResults(sAdresse).Item(1))
    End Sub



    Sub Trace(ByRef sMsg As String)
        lstTrace.Items.Add(sMsg)
        lstTrace.SelectedIndex = lstTrace.Items.Count - 1
    End Sub





    Private Sub MappointControl1_AfterRedraw(ByVal sender As Object, ByVal e As System.EventArgs) Handles MappointControl1.AfterRedraw
        Trace("MappointControl1_AfterRedraw")
    End Sub

    Private Sub MappointControl1_AfterViewChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles MappointControl1.AfterViewChange
        Trace("MappointControl1_AfterViewChange")
    End Sub

    Private Sub MappointControl1_DataMapChange(ByVal sender As Object, ByVal e As AxMapPoint._IMappointCtrlEvents_DataMapChangeEvent) Handles MappointControl1.DataMapChange
        Trace("MappointControl1_DataMapChange")
    End Sub

    Private Sub MappointControl1_NewDataSet(ByVal sender As Object, ByVal e As AxMapPoint._IMappointCtrlEvents_NewDataSetEvent) Handles MappointControl1.NewDataSet
        Trace("MappointControl1_NewDataSet")
    End Sub

    Private Sub MappointControl1_ReadyStateChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles MappointControl1.ReadyStateChange
        Trace("MappointControl1_ReadyStateChange")
        Select Case MappointControl1.ReadyState
            Case MapPoint.tagREADYSTATE.READYSTATE_COMPLETE : Trace("ReadyState = READYSTATE_COMPLETE")
            Case MapPoint.tagREADYSTATE.READYSTATE_INTERACTIVE : Trace("ReadyState = READYSTATE_INTERACTIVE")
            Case MapPoint.tagREADYSTATE.READYSTATE_LOADED : Trace("ReadyState = READYSTATE_LOADED")
            Case MapPoint.tagREADYSTATE.READYSTATE_LOADING : Trace("ReadyState = READYSTATE_LOADING")
            Case MapPoint.tagREADYSTATE.READYSTATE_UNINITIALIZED : Trace("ReadyState = READYSTATE_UNINITIALIZED")
        End Select
    End Sub

    Private Sub MappointControl1_RouteAfterCalculate(ByVal sender As Object, ByVal e As AxMapPoint._IMappointCtrlEvents_RouteAfterCalculateEvent) Handles MappointControl1.RouteAfterCalculate
        Trace("MappointControl1_RouteAfterCalculate")
    End Sub

    Private Sub MappointControl1_RouteAfterOptimize(ByVal sender As Object, ByVal e As AxMapPoint._IMappointCtrlEvents_RouteAfterOptimizeEvent) Handles MappointControl1.RouteAfterOptimize
        Trace("MappointControl1_RouteAfterCalculate")
    End Sub

    Private Sub MappointControl1_SelectionChange(ByVal sender As Object, ByVal e As AxMapPoint._IMappointCtrlEvents_SelectionChangeEvent) Handles MappointControl1.SelectionChange
        Trace("MappointControl1_RouteSelectionChange")
    End Sub

End Class
