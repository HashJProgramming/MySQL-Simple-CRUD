Imports mysql.Data.MySqlClient
Module Module1
    Public cm As New MySqlCommand
    Public con As New MySqlConnection
    Public dr As MySqlDataReader
    Public list As ListViewItem

    Sub connection()
        Try
            con = New MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=secretdb")
            con.Open()
        Catch ex As Exception
            MsgBox("Database failed to connect!")

            Application.Exit()
        End Try

    End Sub
End Module
