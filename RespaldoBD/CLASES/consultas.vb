Imports MySql.Data.MySqlClient
Imports ClosedXML.Excel

Public Class consultas
    Public Shared Function getProductos() As DataTable
        Try
            Dim con As MySqlConnection = conexion.conection
            Dim dt As New DataTable
            Dim where As String = ""
            If Form1.categoria <> "" Or Form1.marca <> "" Or Form1.nombre <> "" Or Form1.modelo <> "" Then
                Dim type As Boolean = False
                Dim brand As Boolean = False
                Dim name As Boolean = False
                If Form1.categoria <> "" Then
                    where = "type =" & "'" & Form1.categoria & "'"
                    type = True
                End If
                If Form1.marca <> "" Then
                    If type = True Then
                        where = where & " AND brand=" & "'" & Form1.marca & "'"
                        brand = True
                    Else
                        where = "brand=" & "'" & Form1.marca & "'"
                        brand = True
                    End If
                End If
                If Form1.nombre <> "" Then
                    If brand = True Or type = True Then
                        where = where & " AND name= " & "'" & Form1.nombre & "'"
                        name = True
                    Else
                        where = "name=" & "'" & Form1.nombre & "'"
                        name = True
                    End If
                End If
                If Form1.modelo <> "" Then
                    If name = True Or brand = True Or type = True Then
                        where = where & " AND model=" & "'" & Form1.modelo & "'"
                    Else
                        where = "model=" & "'" & Form1.modelo & "'"
                    End If
                End If

            End If
            Dim cmd As MySqlCommand = New MySqlCommand(String.Format("SELECT * FROM products WHERE " + where + " "), con)
            Dim adap As New MySqlDataAdapter(cmd)
            adap.Fill(dt)
            con.Close()
            Return dt
        Catch ex As Exception
            MsgBox("Es probable que no se indicara algun parametro")
        End Try

    End Function

    Public Shared Function categoria() As DataTable
        Dim con As MySqlConnection = conexion.conection
        Dim dt As New DataTable
        Dim cmd As MySqlCommand = New MySqlCommand(String.Format("SELECT DISTINCT type FROM products"), con)
        Dim adap As New MySqlDataAdapter(cmd)
        adap.Fill(dt)
        con.Close()
        Return dt

    End Function
    Public Shared Function getAll() As DataTable
        Dim con As MySqlConnection = conexion.conection
        Dim dt As New DataTable
        Dim cmd As MySqlCommand = New MySqlCommand(String.Format("SELECT * FROM products"), con)
        Dim adap As New MySqlDataAdapter(cmd)
        adap.Fill(dt)
        con.Close()
        Return dt

    End Function

    Public Shared Sub saveDB()
        Dim conn As MySqlConnection = conexion.conection
        Dim cmd As MySqlCommand = New MySqlCommand
        cmd.Connection = conn
        Dim namae As String = InputBox("Nombre del Backup?")
        Dim user As String = Environment.UserName
        Dim mb As MySqlBackup = New MySqlBackup(cmd)
        mb.ExportToFile("C:\users/" & user & "/documents/" & namae & ".sql")
        conn.Close()

    End Sub




End Class
