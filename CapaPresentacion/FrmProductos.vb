Imports CapaEntidad
Imports CapaNegocio
Imports ClosedXML.Excel

Public Class FrmProductos

    Dim negocioProducto As New CN_Producto()

    Private Sub FrmProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'se cargan los productos de manera predeterminada
        negocioProducto.CargarProductosPredefinidos()
        Load()


    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Dim producto As New Producto()

        'cliente.Id = txtIndex.Text
        producto.Nombre = txtCliente.Text
        producto.PrecioUnitario = txtPrice.Text
        producto.Categoria = txtCategoria.Text

        Dim validacion = negocioProducto.ValidateData(producto)

        If validacion = False Then
            Exit Sub
        End If

        If producto.Id = 0 Then

            negocioProducto.Insertar(producto)

        Else

            negocioProducto.Acualizar(producto)

        End If


        Clear()



        Load()



    End Sub


    Private Sub Clear()

        txtIndex.Text = ""
        txtCliente.Text = ""
        txtPrice.Text = ""
        txtCategoria.Text = ""

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        If txtIndex.Text = "" Then Exit Sub

        Dim producto As New Producto()
        producto.Id = txtIndex.Text
        negocioProducto.Eliminar(producto)
        Load()
        Clear()


    End Sub




    Private Sub Load()

        dgvProducts.DataSource = negocioProducto.Listar().Tables("Productos")

    End Sub


    Private Sub dgvProducts_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProducts.CellDoubleClick


        txtIndex.Text = dgvProducts.CurrentRow.Cells("ID").Value
        txtCliente.Text = dgvProducts.CurrentRow.Cells("Nombre").Value
        txtPrice.Text = dgvProducts.CurrentRow.Cells("Precio").Value
        txtCategoria.Text = dgvProducts.CurrentRow.Cells("Categoria").Value


    End Sub

    Private Sub ProductosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductosToolStripMenuItem.Click

        Dim frmClientes = New Form1()

        frmClientes.Show()



    End Sub

    Private Sub VentasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VentasToolStripMenuItem.Click

        Dim frmVentas = New FrmVentas()

        frmVentas.Show()

    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click

        If dgvProducts.Rows.Count < 1 Then

            MessageBox.Show("No hay registros que descargar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        Else

            Dim dt As New DataTable()
            dt.Columns.Add("Id", GetType(String))
            dt.Columns.Add("Nombre", GetType(String))
            dt.Columns.Add("Precio", GetType(String))
            dt.Columns.Add("Categoria", GetType(String))


            For Each row As DataGridViewRow In dgvProducts.Rows
                If row.Visible Then
                    dt.Rows.Add(New Object() {
                        If(row.Cells("Id").Value IsNot Nothing, row.Cells("Id").Value.ToString(), ""),
                        If(row.Cells("Nombre").Value IsNot Nothing, row.Cells("Nombre").Value.ToString(), ""),
                        If(row.Cells("Precio").Value IsNot Nothing, row.Cells("Precio").Value.ToString(), ""),
                        If(row.Cells("Categoria").Value IsNot Nothing, row.Cells("Categoria").Value.ToString(), "")
                    })
                End If
            Next



            Dim saveFile As New SaveFileDialog()
            saveFile.FileName = String.Format("Reporte_productos_{0}.xlsx", DateTime.Now.ToString("ddMMyyyyHHmmss"))
            saveFile.Filter = "Excel Files | *.xlsx"

            If saveFile.ShowDialog() = DialogResult.OK Then
                Try
                    Dim wb As New XLWorkbook()
                    Dim hoja = wb.Worksheets.Add(dt, "Informe")
                    hoja.ColumnsUsed().AdjustToContents()
                    wb.SaveAs(saveFile.FileName)

                    MessageBox.Show("Reporte generado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Catch ex As Exception
                    MessageBox.Show("Error al generar el reporte", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End Try
            End If

        End If



    End Sub





End Class