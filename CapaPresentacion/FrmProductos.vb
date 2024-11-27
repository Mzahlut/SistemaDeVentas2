Imports CapaEntidad
Imports CapaNegocio
Imports ClosedXML.Excel

Public Class FrmProductos

    Dim negocioProducto As New CN_Producto()

    Dim primeraCarga As Boolean = True
    Private Sub FrmProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If primeraCarga Then


            negocioProducto.BorrarProductos()
            negocioProducto.CargarProductosPredefinidos()
            cboSearch.Items.Add("Nombre")
            cboSearch.Items.Add("Precio")
            cboSearch.Items.Add("Categoria")
            Load()

            primeraCarga = False

        End If


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
        cboSearch.SelectedIndex = 0
        txtSearch.Text = ""

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
        txtPrice.Text = dgvProducts.CurrentRow.Cells("PrecioUnitario").Value
        txtCategoria.Text = dgvProducts.CurrentRow.Cells("Categoria").Value


    End Sub

    Private Sub ProductosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductosToolStripMenuItem.Click

        Dim frmProductos = Me
        Dim frmClientes = New Form1()
        frmProductos.Hide()
        frmClientes.Show()



    End Sub

    Private Sub VentasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VentasToolStripMenuItem.Click

        Dim frmProductos = Me
        Dim frmVentas = New FrmVentas()

        frmProductos.Hide()
        frmVentas.Show()

    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click

        If dgvProducts.Rows.Count < 1 Then

            MessageBox.Show("No hay registros que descargar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        Else

            Dim dt As New DataTable()
            dt.Columns.Add("Id", GetType(String))
            dt.Columns.Add("Nombre", GetType(String))
            dt.Columns.Add("PrecioUnitario", GetType(String))
            dt.Columns.Add("Categoria", GetType(String))


            For Each row As DataGridViewRow In dgvProducts.Rows

                dt.Rows.Add(New Object() {
                        If(row.Cells("Id").Value IsNot Nothing, row.Cells("Id").Value.ToString(), ""),
                        If(row.Cells("Nombre").Value IsNot Nothing, row.Cells("Nombre").Value.ToString(), ""),
                        If(row.Cells("PrecioUnitario").Value IsNot Nothing, row.Cells("PrecioUnitario").Value.ToString(), ""),
                        If(row.Cells("Categoria").Value IsNot Nothing, row.Cells("Categoria").Value.ToString(), "")
                    })

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

    Private Sub RegistrarVentaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistrarVentaToolStripMenuItem.Click

        Dim frmRegister = New FrmRegister()
        Dim frmProductos = Me


        frmRegister.LimpiarTablaVentas()

        frmProductos.Hide()
        frmRegister.Show()


    End Sub

    Private Sub FrmProductos_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged

        ' Obtener el texto de búsqueda y el campo seleccionado
        Dim searchValue As String = txtSearch.Text.ToLower()
        Dim searchField As String = cboSearch.SelectedItem.ToString()

        ' Llamar al método de negocio para filtrar los clientes
        Dim clientesFiltrados As List(Of Producto) = negocioProducto.Filtrar(searchValue, searchField)

        ' Actualizar el DataGridView con los resultados filtrados
        dgvProducts.DataSource = clientesFiltrados


    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click

        Clear()

    End Sub
End Class