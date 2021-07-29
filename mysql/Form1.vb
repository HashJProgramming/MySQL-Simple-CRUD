Imports mysql.Data.MySqlClient
Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GunaTextBox1.Text = Nothing
        GunaTextBox2.Text = Nothing
        GunaTextBox3.Text = Nothing
        GunaTextBox4.Text = Nothing
        GunaTextBox5.Text = Nothing
        GunaTextBox6.Text = Nothing
        GunaTextBox7.Text = Nothing

        connection()
        listview()

    End Sub
    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click
        ' Try/ Login 
        Try
            con.Close()

            connection()

            Dim command As New MySqlCommand("SELECT `username`, `password` FROM `Users` WHERE `username` = @username AND `password` = @password", con)

            command.Parameters.Add("@username", MySqlDbType.VarChar).Value = GunaTextBox1.Text
            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = GunaTextBox2.Text

            Dim adapter As New MySqlDataAdapter(command)
            Dim table As New DataTable()

            adapter.Fill(table)

            If table.Rows.Count = 0 Then

                MessageBox.Show("Invalid Username Or Password")

            Else

                MessageBox.Show("Logged In")


            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    ' Refresh Listview and Deploy all Data
    Sub listview()
        con.Close()
        connection()

        Try
            ListView1.Items.Clear()
            cm = New MySqlCommand("SELECT * FROM `employee`", con)
            dr = cm.ExecuteReader(CommandBehavior.CloseConnection)
            While dr.Read
                list = ListView1.Items.Add(dr("ID").ToString)
                list.SubItems.Add(dr("Record").ToString)
            End While
            dr.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub GunaButton2_Click(sender As Object, e As EventArgs) Handles GunaButton2.Click
        ' Refresh Listview and Deploy all Data
        listview()
    End Sub

    Private Sub GunaButton3_Click(sender As Object, e As EventArgs) Handles GunaButton3.Click
        ' Insert Data 
        Try
            connection()
            Dim command As New MySqlCommand("INSERT INTO `Users`(`Username`, `Password`) VALUES (@username,@password)", con)
            command.Parameters.Add("@username", MySqlDbType.VarChar).Value = GunaTextBox3.Text
            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = GunaTextBox4.Text
            command.ExecuteNonQuery()
            MsgBox("Done")
            listview()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub GunaButton4_Click(sender As Object, e As EventArgs) Handles GunaButton4.Click
        ' Update Data 
        Try
            Dim command As MySqlCommand
            con.Open()
            command = con.CreateCommand()
            command.CommandText = "UPDATE `Users` SET username = @username, password = @password WHERE username = @username;"
            command.Parameters.AddWithValue("@username", GunaTextBox5.Text)
            command.Parameters.AddWithValue("@password", GunaTextBox6.Text)
            command.ExecuteNonQuery()
            MsgBox("Done !")
            listview()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub GunaButton5_Click(sender As Object, e As EventArgs) Handles GunaButton5.Click
        'Delete Data
        Try
            Dim command As New MySqlCommand
            con.Open()
            command = con.CreateCommand()
            command.CommandText = "DELETE FROM `Users` WHERE username = @username;"
            command.Parameters.AddWithValue("@username", GunaTextBox7.Text)
            command.ExecuteNonQuery()
            MsgBox("Done !")
            listview()
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub
End Class
