Imports CapaEntidad
Imports CapaNegocio


Public Class FrmRegister


    Dim negocioVenta As New CN_Venta()
    Dim negocioVentaItem As New CN_VentaItem()
    Dim negocioCliente As New CN_Cliente()
    Dim listaItems As New List(Of VentaItem)

    Dim cargandoClientes As Boolean = True
    Dim primeraCarga As Boolean = True

    Private Sub FrmRegister_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If primeraCarga Then

            Cargar()
            'negocioCliente.CargarClientesPredefinidos()
            CargarClientesEnComboBox()
            CargarProductosEnComboBox()


            primeraCarga = False
        End If
    End Sub



    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Dim ventaItem As New VentaItem()


        Dim productoSeleccionado As Producto = CType(cboProducts.SelectedItem, Producto)
        ventaItem.IdVenta = negocioVenta.GetId()
        ventaItem.Producto = productoSeleccionado
        ventaItem.IdProducto = productoSeleccionado.Id
        ventaItem.PrecioUnitario = productoSeleccionado.PrecioUnitario
        ventaItem.Cantidad = Convert.ToInt32(txtCantidad.Text)
        ventaItem.TotalItem = productoSeleccionado.PrecioUnitario * ventaItem.Cantidad

        listaItems.Add(ventaItem)


        negocioVentaItem.InsertarItem(ventaItem)

        Cargar()

        cboClients.Enabled = False







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


    Private Sub Cargar()

        dgvItems.DataSource = negocioVentaItem.ListarItems().Tables("ventasitems")

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        If txtIndex.Text = "" Then Exit Sub
        Dim productoSeleccionado As Producto = CType(cboProducts.SelectedItem, Producto)



        Dim item As New VentaItem()
        item.IdProducto = productoSeleccionado.Id - 1
        negocioVentaItem.Eliminar(item)
        Cargar()
        Clear()

    End Sub


    Private Sub Clear()

        txtIndex.Text = ""
        cboClients.SelectedIndex = 1
        cboProducts.SelectedIndex = 1

    End Sub


    Private Sub dgvItems_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvItems.CellDoubleClick

        Dim idProductoSeleccionado As Integer = Convert.ToInt32(dgvItems.Rows(e.RowIndex).Cells("IdProducto").Value)


        txtIndex.Text = idProductoSeleccionado.ToString()
        cboProducts.SelectedIndex = dgvItems.CurrentRow.Cells("IdProducto").Value

    End Sub

    Private Sub btnVenta_Click(sender As Object, e As EventArgs) Handles btnVenta.Click

        Dim venta As New Venta()
        Dim clienteSeleccionado As Cliente = CType(cboClients.SelectedItem, Cliente)
        venta.IdCliente = clienteSeleccionado.Id
        venta.Fecha = Date.Now()
        venta.ListaItems = listaItems
        venta.Total = negocioVentaItem.CalcularTotal(listaItems)


        negocioVenta.CrearVenta(venta)

        dgvItems.DataSource = Nothing

        negocioVentaItem.EliminarItems()
        cboClients.DataSource = Nothing  '
        cboClients.Items.Clear()
        cboClients.SelectedIndex = -1

        cboProducts.DataSource = Nothing
        cboProducts.Items.Clear()
        cboProducts.SelectedIndex = -1

        Dim frmRegistrarVenta = Me
        Dim frmVentas As New FrmVentas()

        frmRegistrarVenta.Hide()
        frmVentas.Show()



    End Sub

    Private Sub cboClients_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboClients.SelectedIndexChanged

        If Not cargandoClientes AndAlso cboClients.SelectedIndex <> -1 Then
            ' Deshabilitar el ComboBox para que no se pueda cambiar el valor después de la selección
            cboClients.Enabled = False
        End If


    End Sub

    Public Sub LimpiarTablaVentas()
        dgvItems.DataSource = Nothing
        dgvItems.Rows.Clear() ' Opcional, para asegurarse de que todas las filas estén vacías
    End Sub

    Private Sub ProductosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductosToolStripMenuItem.Click


        Dim frmRegister = Me
        Dim frmProductos = New FrmProductos()

        frmRegister.Hide()
        frmProductos.Show()

    End Sub

    Private Sub VentasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VentasToolStripMenuItem.Click

        Dim frmRegister = Me
        Dim frmProdctos = New FrmProductos()

        frmRegister.Hide()

        frmProdctos.Show()

    End Sub

    Private Sub VentasToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles VentasToolStripMenuItem1.Click

        Dim frmRegister = Me
        Dim frmVentas = New FrmVentas()
        Dim frmClientes = New Form1()

        frmRegister.Hide()
        frmVentas.Show()


    End Sub

    Private Sub FrmRegister_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub


End Class