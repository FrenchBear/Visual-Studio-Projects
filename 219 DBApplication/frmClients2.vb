Public Class frmClients2

    Private Sub frmClients2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.LignesDeCommandeTableAdapter.Fill(Me.TotoDataSet.LignesDeCommande)
        'TODO: Delete this line of code to remove the default AutoFill for 'TotoDataSet.Commandes'.
        Me.CommandesTableAdapter.Fill(Me.TotoDataSet.Commandes)
        'TODO: Delete this line of code to remove the default AutoFill for 'TotoDataSet.Clients'.
        Me.ClientsTableAdapter.Fill(Me.TotoDataSet.Clients)

    End Sub
End Class