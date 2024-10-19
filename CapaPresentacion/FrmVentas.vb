Imports CapaDatos
Imports CapaEntidad
Imports CapaNegocio
Imports ClosedXML.Excel

Public Class FrmVentas


    Dim negocioVenta As New CN_Venta()

    Private Sub FrmVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Cargar()

        CargarProductosEnComboBox()

        CargarClientesEnComboBox()


    End Sub




    Private Sub CargarProductosEnComboBox()
        ' Llamar al método de la capa de negocio para obtener la lista de productos
        Dim productos As List(Of Producto) = negocioVenta.ObtenerProductos()

        ' Limpiar el ComboBox antes de llenarlo
        cboProducts.Items.Clear()

        ' Llenar el ComboBox con los productos
        For Each producto As Producto In productos
            cboProducts.Items.Add(New With {
            .Id = producto.Id,
            .Nombre = producto.Nombre
        })
        Next

        ' Establecer DisplayMember y ValueMember
        cboProducts.DataSource = productos
        cboProducts.DisplayMember = "Nombre"
        cboProducts.ValueMember = "Id"
    End Sub

    Private Sub CargarClientesEnComboBox()
        ' Llamar al método de la capa de negocio para obtener la lista de clientes
        Dim clientes As List(Of Cliente) = negocioVenta.ObtenerClientes()

        ' Limpiar el ComboBox antes de llenarlo
        cboClients.Items.Clear()

        ' Llenar el ComboBox con los clientes
        For Each cliente As Cliente In clientes
            cboClients.Items.Add(New With {
            .Id = cliente.Id,
            .Nombre = cliente.Nombre
        })
        Next

        ' Establecer DisplayMember y ValueMember
        cboClients.DataSource = clientes
        cboClients.DisplayMember = "Nombre"
        cboClients.ValueMember = "Id"
    End Sub




    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Dim venta As New Venta()

        Dim productoSeleccionado As Producto = CType(cboProducts.SelectedItem, Producto)
        Dim clienteSeleccionado As Cliente = CType(cboClients.SelectedItem, Cliente)

        ' Validar que se haya seleccionado un producto y un cliente
        If productoSeleccionado Is Nothing OrElse clienteSeleccionado Is Nothing Then
            MessageBox.Show("Por favor, seleccione un cliente y un producto.")
            Return
        End If

        ' Obtener el IdCliente y la fecha
        venta.IdCliente = clienteSeleccionado.Id
        venta.Fecha = Date.Now()

        ' Declarar la cantidad
        Dim cantidad As Integer

        ' Validar la cantidad ingresada
        If Integer.TryParse(txtCantidad.Text, cantidad) AndAlso cantidad > 0 Then
            ' Calcular el total basado en el precio unitario del producto
            venta.Total = cantidad * productoSeleccionado.PrecioUnitario
        Else
            ' Si la cantidad es inválida, mostrar mensaje de error
            MessageBox.Show("Por favor, ingrese una cantidad válida.")
            Return
        End If



        ' Crear la venta
        negocioVenta.CrearVenta(venta)

        Cargar()


    End Sub

    Private Sub Clear()

        txtIndex.Text = ""
        cboClients.SelectedIndex = 1
        txtCantidad.Text = ""


    End Sub


    Private Sub Cargar()

        dgvVentas.DataSource = negocioVenta.Listar().Tables("Ventas")

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click


        If txtIndex.Text = "" Then Exit Sub

        Dim venta As New Venta()
        venta.Id = txtIndex.Text
        negocioVenta.Eliminar(venta)
        Cargar()
        Clear()


    End Sub



    Private Sub dgvVentas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvVentas.CellDoubleClick

        ' Asignar el valor del ID a txtIndex
        txtIndex.Text = dgvVentas.CurrentRow.Cells("Id").Value.ToString()

        ' Seleccionar el cliente en el ComboBox basado en el valor de "IdCliente"
        Dim idCliente As Integer = CInt(dgvVentas.CurrentRow.Cells("IdCliente").Value)
        For Each cliente As Cliente In cboClients.Items
            If cliente.Id = idCliente Then
                cboClients.SelectedItem = cliente
                Exit For
            End If
        Next


    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click

        If dgvVentas.Rows.Count < 1 Then

            MessageBox.Show("No hay registros que descargar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        Else

            Dim dt As New DataTable()
            dt.Columns.Add("ID", GetType(String))
            dt.Columns.Add("IDCliente", GetType(String))
            dt.Columns.Add("Fecha", GetType(String))
            dt.Columns.Add("Total", GetType(String))


            For Each row As DataGridViewRow In dgvVentas.Rows
                If row.Visible Then
                    dt.Rows.Add(New Object() {
                        If(row.Cells("ID").Value IsNot Nothing, row.Cells("ID").Value.ToString(), ""),
                        If(row.Cells("IDCliente").Value IsNot Nothing, row.Cells("IDCliente").Value.ToString(), ""),
                        If(row.Cells("Fecha").Value IsNot Nothing, row.Cells("Fecha").Value.ToString(), ""),
                        If(row.Cells("Total").Value IsNot Nothing, row.Cells("Total").Value.ToString(), "")
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

    Private Sub ProductosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductosToolStripMenuItem.Click

        Dim frmProductos = New FrmProductos()

        frmProductos.Show()

    End Sub

    Private Sub VentasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VentasToolStripMenuItem.Click

        Dim frmClientes = New Form1()

        frmClientes.Show()

    End Sub
End Class