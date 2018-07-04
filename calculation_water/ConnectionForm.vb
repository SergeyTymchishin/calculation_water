Public Class ConnectionForm
    Public serverName As String
    Public isLocal As Boolean = False
    Public User As String = Environment.UserDomainName + "\" + Environment.UserName
    Public Pass As String = ""

    Private Sub button1_Click(sender As Object, e As EventArgs) Handles button1.Click
        serverName = textBox1.Text
        User = textBox2.Text
        Pass = textBox3.Text
        Close()
    End Sub

    Private Sub button2_Click(sender As Object, e As EventArgs) Handles button2.Click
        Close()
    End Sub

    Private Sub ConnectionForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' textBox1.Text = "id-modes1.id.irkutskenergo.ru"
        comboBox1.SelectedIndex = 1
        textBox2.Text = Environment.UserDomainName + "\" + Environment.UserName
    End Sub

    Private Sub comboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboBox1.SelectedIndexChanged
        If (comboBox1.SelectedIndex = 1) Then
            isLocal = False
            groupBox1.Enabled = False
        Else
            isLocal = True
            groupBox1.Enabled = True
        End If
    End Sub
End Class