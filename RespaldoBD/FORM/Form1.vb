Imports ClosedXML.Excel
Public Class Form1
    Public Shared nombre, categoria, modelo, marca As String

    Private Sub btnCategoria_Click(sender As Object, e As EventArgs) Handles btnCategoria.Click
        If lblCategoria.Text = "" Or lblCategoria.Text = "lblCategoria" Then
            lblCategoria.Text = cbCategoria.Text
            lblCategoria.Visible = True
            categoria = lblCategoria.Text
            btnCategoria.Text = "Eliminar"
            btnCategoria.ForeColor = Color.Red
        Else
            lblCategoria.Text = ""
            btnCategoria.Text = "Agregar"
            btnCategoria.ForeColor = Color.FromArgb(186, 247, 249)

        End If

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        DataGridView1.DataSource = consultas.getProductos
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbCategoria.DataSource = consultas.categoria
        cbCategoria.DisplayMember = "type"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim workbook = New XLWorkbook()
        workbook.Worksheets.Add(consultas.getProductos, "productos")
        workbook.SaveAs("C:\Users\Abisai\Documents\myExcelFile.xlsx")
    End Sub

    Private Sub btnNombre_Click(sender As Object, e As EventArgs) Handles btnNombre.Click
        If lblNombre.Text = "" Or lblNombre.Text = "lblNombre" Then
            lblNombre.Text = txtNombre.Text
            lblNombre.Visible = True
            nombre = lblNombre.Text
            btnNombre.Text = "Eliminar"
            btnNombre.ForeColor = Color.Red
        Else
            lblNombre.Text = ""
            btnNombre.Text = "Agregar"
            btnNombre.ForeColor = Color.FromArgb(186, 247, 249)
        End If

    End Sub

    Private Sub btnMarca_Click(sender As Object, e As EventArgs) Handles btnMarca.Click
        If lblMarca.Text = "" Or lblMarca.Text = "lblMarca" Then
            lblMarca.Text = txtMarca.Text
            lblMarca.Visible = True
            marca = lblMarca.Text
            btnMarca.Text = "Eliminar"
            btnMarca.ForeColor = Color.Red
        Else
            lblMarca.Text = ""
            btnMarca.Text = "Agregar"
            btnMarca.ForeColor = Color.FromArgb(186, 247, 249)
        End If

    End Sub

    Private Sub btnModelo_Click(sender As Object, e As EventArgs) Handles btnModelo.Click
        If lblModelo.Text = "" Or lblModelo.Text = "lblModelo" Then
            lblModelo.Text = txtModelo.Text
            lblModelo.Visible = True
            modelo = lblModelo.Text
            btnModelo.Text = "Eliminar"
            btnModelo.ForeColor = Color.Red
        Else
            lblModelo.Text = ""
            btnModelo.Text = "Agregar"
            btnModelo.ForeColor = Color.FromArgb(186, 247, 249)
        End If

    End Sub
End Class
