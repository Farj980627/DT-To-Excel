Imports ClosedXML.Excel
Imports itextsharp.text.pdf
Imports itextsharp.text
Imports IWshRuntimeLibrary
Imports MySql.Data.MySqlClient


Public Class Form1
    Public Shared nombre, categoria, modelo, marca As String
    Dim user As String = Environment.UserName
    Private Sub btnCategoria_Click(sender As Object, e As EventArgs) Handles btnCategoria.Click
        If lblCategoria.Text = "" Or lblCategoria.Text = "lblCategoria" Then
            lblCategoria.Text = cbCategoria.Text
            lblCategoria.Visible = True
            categoria = lblCategoria.Text
            btnCategoria.Text = "Eliminar"
            btnCategoria.ForeColor = Color.Red
        Else
            lblCategoria.Text = ""
            cbCategoria.SelectedIndex = 0
            categoria = lblCategoria.Text
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
        'create name for the file
        Dim namae As String = InputBox("Nombre del Reporte?")
        'create an excel
        Dim workbook = New XLWorkbook()
        workbook.Worksheets.Add(consultas.getProductos, "productos")
        workbook.SaveAs("C:\Users\" & user & "\Documents\" & namae & ".xlsx")
        'create an PDF
        Dim doc As Document = New Document(PageSize.A4.Rotate)
        Dim writer As PdfWriter = PdfWriter.GetInstance(doc, New System.IO.FileStream("C:\Users\" & user & "\Documents\" & namae & ".pdf", System.IO.FileMode.Create))
        doc.AddTitle("Reporte Productos")
        doc.Open()
        doc.Add(New Paragraph("TABLA"))
        doc.Add(Chunk.NEWLINE)
        Dim table As PdfPTable = New PdfPTable(DataGridView1.Columns.Count)
        table.WidthPercentage = 100
        For i As Integer = 0 To DataGridView1.Columns.Count - 1 Step +1
            Dim cell As PdfPCell = New PdfPCell()
            cell.AddElement(New Chunk(DataGridView1.Columns(i).Name.ToString()))
            cell.BorderWidth = 1
            cell.Colspan = 1
            cell.PaddingTop = 1
            table.AddCell(cell)
        Next
        For i As Integer = 0 To DataGridView1.Rows.Count - 2 Step +1
            For j As Integer = 0 To DataGridView1.Columns.Count - 1 Step +1
                Dim cell As PdfPCell = New PdfPCell()
                cell.AddElement(New Chunk(DataGridView1.Rows(i).Cells(j).Value.ToString()))
                cell.BorderColor = BaseColor.BLACK
                cell.BorderWidth = 1
                cell.PaddingTop = -7
                cell.PaddingLeft = 7
                table.AddCell(cell)
            Next
        Next
        doc.Add(table)
        doc.Close()
        writer.Close()
        MessageBox.Show("¡Archivos generados correctamente!")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        consultas.saveDB()
        MsgBox("Archivo Generado")
    End Sub

    Private Sub btnGuardarTodo_Click(sender As Object, e As EventArgs) Handles btnGuardarTodo.Click
        'create name for the file
        Dim namae As String = InputBox("Nombre del Reporte?")
        'create an excel
        Dim workbook = New XLWorkbook()
        workbook.Worksheets.Add(consultas.getAll, "productos")
        workbook.SaveAs("C:\Users\" & user & "\Documents\" & namae & ".xlsx")
        'create an PDF
        Dim doc As Document = New Document(PageSize.A4.Rotate)
        Dim writer As PdfWriter = PdfWriter.GetInstance(doc, New System.IO.FileStream("C:\Users\" & user & "\Documents\" & namae & ".pdf", System.IO.FileMode.Create))
        doc.AddTitle("Reporte Productos")
        doc.Open()
        doc.Add(New Paragraph("TABLA"))
        doc.Add(Chunk.NEWLINE)
        DataGridView1.DataSource = consultas.getAll
        Dim table As PdfPTable = New PdfPTable(DataGridView1.Columns.Count)
        table.WidthPercentage = 100
        For i As Integer = 0 To DataGridView1.Columns.Count - 1 Step +1
            Dim cell As PdfPCell = New PdfPCell()
            cell.AddElement(New Chunk(DataGridView1.Columns(i).Name.ToString()))
            cell.BorderWidth = 1
            cell.Colspan = 1
            cell.PaddingTop = 1
            table.AddCell(cell)
        Next
        For i As Integer = 0 To DataGridView1.Rows.Count - 2 Step +1
            For j As Integer = 0 To DataGridView1.Columns.Count - 1 Step +1
                Dim cell As PdfPCell = New PdfPCell()
                cell.AddElement(New Chunk(DataGridView1.Rows(i).Cells(j).Value.ToString()))
                cell.BorderColor = BaseColor.BLACK
                cell.BorderWidth = 1
                cell.PaddingTop = -7
                cell.PaddingLeft = 7
                table.AddCell(cell)
            Next
        Next
        doc.Add(table)
        doc.Close()
        writer.Close()
        MessageBox.Show("¡Archivos generados correctamente!")
        DataGridView1.DataSource = ""
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        TabControl1.SelectedIndex = 1
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        TabControl1.SelectedIndex = 0
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
            txtNombre.Text = ""
            nombre = lblNombre.Text
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
            txtMarca.Text = ""
            marca = lblMarca.Text
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
            txtModelo.Text = ""
            modelo = lblModelo.Text
            btnModelo.Text = "Agregar"
            btnModelo.ForeColor = Color.FromArgb(186, 247, 249)
        End If

    End Sub
End Class
