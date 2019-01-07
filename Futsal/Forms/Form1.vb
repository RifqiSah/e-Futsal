Public Class Form1
    'Declare the variables
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer

    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or 33554432
            Return cp
        End Get
    End Property

    Private Sub PreVentFlicker()
        With Me
            .SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
            .SetStyle(ControlStyles.UserPaint, True)
            .SetStyle(ControlStyles.AllPaintingInWmPaint, True)
            .UpdateStyles()
        End With
    End Sub

    Private Sub Panel1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseDown
        drag = True
        mousex = Windows.Forms.Cursor.Position.X - Me.Left
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub

    Private Sub Panel1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseMove
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub Panel1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseUp
        drag = False
    End Sub

    Private Sub GantiKonten(ByVal n As Integer)
        pan1.Visible = (n = 1)
        pan2.Visible = (n = 2)
        pan3.Visible = (n = 3)
        pan4.Visible = (n = 4)
        pan5.Visible = (n = 5)
        pan6.Visible = (n = 6)

        If n = 4 Then
            TabControl2.SelectTab(0)
            vidPlay.URL = Application.StartupPath() & "\media\Passing.mp4"
            vidPlay.Ctlcontrols.play()
        Else
            vidPlay.Ctlcontrols.stop()
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Application.Exit()
    End Sub

    Private Sub lblMenu1_Click(sender As Object, e As EventArgs) Handles lblMenu1.Click
        imgMenuLine.Left = lblMenu1.Left
        imgMenuLine.Width = lblMenu1.Width

        GantiKonten(1)
    End Sub

    Private Sub lblMenu2_Click(sender As Object, e As EventArgs) Handles lblMenu2.Click
        imgMenuLine.Left = lblMenu2.Left
        imgMenuLine.Width = lblMenu2.Width

        GantiKonten(2)
    End Sub

    Private Sub lblMenu3_Click(sender As Object, e As EventArgs) Handles lblMenu3.Click
        imgMenuLine.Left = lblMenu3.Left
        imgMenuLine.Width = lblMenu3.Width

        GantiKonten(3)
    End Sub

    Private Sub lblMenu4_Click(sender As Object, e As EventArgs) Handles lblMenu4.Click
        imgMenuLine.Left = lblMenu4.Left
        imgMenuLine.Width = lblMenu4.Width

        GantiKonten(4)
    End Sub

    Private Sub lblMenu5_Click(sender As Object, e As EventArgs) Handles lblMenu5.Click
        imgMenuLine.Left = lblMenu5.Left
        imgMenuLine.Width = lblMenu5.Width

        GantiKonten(5)
    End Sub

    Private Sub lblMenu6_Click(sender As Object, e As EventArgs) Handles lblMenu6.Click
        imgMenuLine.Left = lblMenu6.Left
        imgMenuLine.Width = lblMenu6.Width

        GantiKonten(6)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim R As Integer = 0
        Dim G As Integer = 0
        Dim B As Integer = 0
        Dim A As Integer = 50

        PreVentFlicker()

        pan1.BackColor = Color.FromArgb(A, R, G, B)
        pan2.BackColor = Color.FromArgb(A, R, G, B)
        pan3.BackColor = Color.FromArgb(A, R, G, B)
        pan4.BackColor = Color.FromArgb(A, R, G, B)
        pan5.BackColor = Color.FromArgb(A, R, G, B)
        pan6.BackColor = Color.FromArgb(A, R, G, B)

        vidPlay.stretchToFit = True
    End Sub

    Private Sub TabControl2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl2.SelectedIndexChanged
        vidPlay.Ctlcontrols.stop()

        ' Passing
        If TabControl2.SelectedIndex = 0 Then vidPlay.URL = Application.StartupPath() & "\media\Passing.mp4"

        ' Dribbling
        If TabControl2.SelectedIndex = 1 Then vidPlay.URL = Application.StartupPath() & "\media\Dribble.mp4"

        ' Shooting 
        If TabControl2.SelectedIndex = 2 Then vidPlay.URL = Application.StartupPath() & "\media\Shooting.mp4"

        vidPlay.Ctlcontrols.play()
    End Sub
End Class
