Imports MySql.Data.MySqlClient


Public Class WebForm1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim koneksi As New MySqlConnection("data source=localhost; user=root; pwd=''; initial catalog=db_mahasiswa_c")
        If TextBox1.Text = "" Then
            MsgBox("NIM Harus diinputkan", MsgBoxStyle.Information)
        ElseIf TextBox2.Text = "" Then
            MsgBox("Nama harus diinputkan", MsgBoxStyle.Information)
        ElseIf RadioButtonList1.Text = "" Then
            MsgBox("jenis kelamin harus diinputkan", MsgBoxStyle.Information)
        ElseIf DropDownList1.Text = "" Then
            MsgBox("agama harus di inputkan", MsgBoxStyle.Information)
        ElseIf Calendar1.SelectedDate = Nothing Then
            MsgBox("tanggal lahir harus di inputkan", MsgBoxStyle.Information)
        ElseIf CheckBoxList1.Text = "" Then
            MsgBox("hobby harus di isi", MsgBoxStyle.Information)
        ElseIf TextBox3.Text = "" Then
            MsgBox("jumlah saudara harus diisi", MsgBoxStyle.Information)
        ElseIf Not IsNumeric(TextBox3.Text) Then
            MsgBox("jumlah saudara harus diisi angka", MsgBoxStyle.Information)
        ElseIf TextBox4.Text = " " Then
            MsgBox("keterangan harus diisi", MsgBoxStyle.Information)
        ElseIf Not TextBox4.Text.All(Function(c) Char.IsLetter(c)) Then
            MsgBox("keterangan harus di isi charakter")
        Else
            Try
                koneksi.Open()
                Dim tanggal As String = Calendar1.SelectedDate.ToString("yyyy-MM-dd")
                Dim input As String = "INSERT INTO mahasiswa(nim, nama, jenis_kelamin, agama, tanggal, hobby, jumlah_saudara, keterangan) VALUES ('" & TextBox1.Text & "', '" & TextBox2.Text & "', '" & RadioButtonList1.Text & "', '" & DropDownList1.Text & "', '" & tanggal & "','" & CheckBoxList1.Text & "', '" & TextBox3.Text & "', '" & TextBox4.Text & "')"
                Dim command As New MySqlCommand(input, koneksi)
                Dim reader As MySqlDataReader = command.ExecuteReader
                MsgBox("Data Berhasil di input")
                TextBox1.Text = ""
                TextBox2.Text = ""
                TextBox3.Text = ""
                RadioButtonList1.SelectedValue = Nothing
                DropDownList1.SelectedIndex = -1
                Calendar1.SelectedDate = Nothing
                CheckBoxList1.SelectedValue = Nothing

            Catch ex As Exception
                MsgBox("error" & ex.Message)
            Finally
                koneksi.Close()
            End Try
        End If
    End Sub
End Class