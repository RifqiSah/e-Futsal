Public Class Form2
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TopMost = True

        vidPlay.uiMode = "none"
        vidPlay.URL = Application.StartupPath() & "\media\Opening.mp4"
        vidPlay.Ctlcontrols.play()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Application.Exit()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Visible = False
        vidPlay.Ctlcontrols.stop()
        Form1.Show()
    End Sub
End Class