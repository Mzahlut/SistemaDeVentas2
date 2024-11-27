Imports CapaDatos
Imports CapaEntidad
Imports CapaNegocio
Imports ClosedXML.Excel

Public Class FrmVentas


    Dim negocioVenta As New CN_Venta()

    Dim primeraCarga As Boolean = True

    Private Sub FrmVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If primeraCarga Then


            Cargar()

            CargarProductosEnComboBox()
            CargarClientesEnComboBox()

            primeraCarga = False

        End If

    End Sub




    Private Sub CargarProductosEnComboBox()

        Dim productos As List(Of Producto) = negocioVenta.ObtenerProductos()

        cboProducts.Items.Clear()


        For Each producto As Producto In productos
            cboProducts.Items.Add(New With {
            .Id = producto.Id,
            .Nombre = producto.Nombre
        })
        Next

        cboProducts.DataSource = productos
        cboProducts.DisplayMember = "Nombre"
        cboProducts.ValueMember = "Id"
    End Sub

    Private Sub CargarClientesEnComboBox()

        Dim clientes As List(Of Cliente) = negocioVenta.ObtenerClientes()


        cboClients.Items.Clear()


        For Each cliente As Cliente In clientes
            cboClients.Items.Add(New With {
            .Id = cliente.Id,
            .Nombre = cliente.Nombre
        })
        Next


        cboClients.DataSource = clientes
        cboClients.DisplayMember = "Nombre"
        cboClients.ValueMember = "Id"
    End Sub




    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Dim venta As New Venta()

        Dim productoSeleccionado As Producto = CType(cboProducts.SelectedItem, Producto)
        Dim clienteSeleccionado As Cliente = CType(cboClients.SelectedItem, Cliente)


        If productoSeleccionado Is Nothing OrElse clienteSeleccionado Is Nothing Then
            MessageBox.Show("Por favor, seleccione un cliente y un producto.")
            Return
        End If

        ' Obtener el IdCliente y la fecha
        venta.Id = txtIndex.Text
        venta.IdCliente = clienteSeleccionado.Id
        venta.Fecha = Date.Now()

        Dim cantidad As Integer


        If Integer.TryParse(txtCantidad.Text, cantidad) AndAlso cantidad > 0 Then

            venta.Total = cantidad * productoSeleccionado.PrecioUnitario
        Else

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

        Dim productoSeleccionado As Producto = CType(cboProducts.SelectedItem, Producto)
        Dim clienteSeleccionado As Cliente = CType(cboClients.SelectedItem, Cliente)
        Dim venta As New Venta()





        Dim idVenta As Integer
        If Integer.TryParse(dgvVentas.CurrentRow.Cells("ID").Value.ToString(), idVenta) Then
            txtIndex.Text = idVenta.ToString()
        End If


        cboClients.SelectedItem = clienteSeleccionado.Id
        cboProducts.SelectedItem = productoSeleccionado.Id


        Dim idCliente As Integer = CInt(dgvVentas.CurrentRow.Cells("ID").Value)
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
            dt.Columns.Add("Cliente", GetType(String))
            dt.Columns.Add("Telefono", GetType(String))
            dt.Columns.Add("Fecha", GetType(String))
            dt.Columns.Add("Total", GetType(String))


            For Each row As DataGridViewRow In dgvVentas.Rows
                If row.Visible Then
                    dt.Rows.Add(New Object() {
                        If(row.Cells("Cliente").Value IsNot Nothing, row.Cells("Cliente").Value.ToString(), ""),
                        If(row.Cells("Telefono").Value IsNot Nothing, row.Cells("Telefono").Value.ToString(), ""),
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

        Dim frmVentas = Me
        Dim frmProductos = New FrmProductos()
        frmVentas.Hide()
        frmProductos.Show()

    End Sub

    Private Sub VentasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VentasToolStripMenuItem.Click

        Dim frmVentas = Me
        Dim frmClientes = New Form1()

        frmVentas.Hide()
        frmClientes.Show()

    End Sub

    Private Sub RegistrarVentaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistrarVentaToolStripMenuItem.Click

        Dim FrmVentas = Me
        Dim frmRegister = New FrmRegister()

        frmRegister.LimpiarTablaVentas()

        FrmVentas.Hide()
        frmRegister.Show()

    End Sub

    Private Sub FrmVentas(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub



End Class