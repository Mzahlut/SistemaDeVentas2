Imports System.Windows.Controls
Imports CapaEntidad
Imports CapaNegocio
Imports ClosedXML.Excel

Public Class Form1


    Dim NegocioCliente As New CN_Cliente()
    Dim negocioProducto As New CN_Producto()
    Dim primeraCarga As Boolean = True
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        If primeraCarga Then

            NegocioCliente.BorrarClientes()

            NegocioCliente.CargarClientesPredefinidos()
            negocioProducto.CargarProductosPredefinidos()


            cboSearch.Items.Add("Cliente")
            cboSearch.Items.Add("Telefono")
            cboSearch.Items.Add("Correo")
            cboSearch.SelectedIndex = 0 ' Selecciona Nombre por defecto

            Load()


            primeraCarga = False
        End If



    End Sub




    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Dim cliente As New Cliente()

        'cliente.Id = txtIndex.Text
        cliente.Nombre = txtName.Text
        cliente.Telefono = txtPhone.Text
        cliente.Email = txtEmail.Text

        Dim validacion = NegocioCliente.ValidateData(cliente)

        If validacion = False Then
            Exit Sub
        End If

        If cliente.Id = 0 Then

            NegocioCliente.Insertar(cliente)

        Else

            NegocioCliente.Acualizar(cliente)

        End If


        Clear()



        Load()



    End Sub

    Private Sub Clear()

        txtIndex.Text = ""
        txtName.Text = ""
        txtPhone.Text = ""
        txtEmail.Text = ""
        cboSearch.SelectedIndex = 0
        txtSearch.Text = ""

    End Sub


    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        If txtIndex.Text = "" Then Exit Sub

        Dim cliente As New Cliente()
        cliente.Id = txtIndex.Text
        NegocioCliente.Eliminar(cliente)
        Load()
        Clear()

    End Sub




    Private Sub Load()

        dgvClients.DataSource = NegocioCliente.Listar().Tables("Clientes")

    End Sub


    Private Sub dgvClients_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvClients.CellDoubleClick


        txtIndex.Text = dgvClients.CurrentRow.Cells("ID").Value
        txtName.Text = dgvClients.CurrentRow.Cells("Nombre").Value
        txtPhone.Text = dgvClients.CurrentRow.Cells("Telefono").Value
        txtEmail.Text = dgvClients.CurrentRow.Cells("Email").Value






    End Sub

    Private Sub ProductosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductosToolStripMenuItem.Click

        Dim frmClientes = Me
        Dim frmProductos = New FrmProductos()
        frmProductos.Show()
        Me.Hide()




    End Sub

    Private Sub VentasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VentasToolStripMenuItem.Click

        Dim frmClientes = Me
        Dim frmVenta = New FrmVentas()
        frmVenta.Show()
        Me.Hide()

    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click

        If dgvClients.Rows.Count < 1 Then

            MessageBox.Show("No hay registros que descargar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        Else

            Dim dt As New DataTable()
            dt.Columns.Add("Id", GetType(String))
            dt.Columns.Add("Nombre", GetType(String))
            dt.Columns.Add("Telefono", GetType(String))
            dt.Columns.Add("Email", GetType(String))


            For Each row As DataGridViewRow In dgvClients.Rows
                If row.Visible Then
                    dt.Rows.Add(New Object() {
                        If(row.Cells("Id").Value IsNot Nothing, row.Cells("Id").Value.ToString(), ""),
                        If(row.Cells("Nombre").Value IsNot Nothing, row.Cells("Nombre").Value.ToString(), ""),
                        If(row.Cells("Telefono").Value IsNot Nothing, row.Cells("Telefono").Value.ToString(), ""),
                        If(row.Cells("Email").Value IsNot Nothing, row.Cells("Email").Value.ToString(), "")
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

    Private Sub RegistrarVentaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistrarVentaToolStripMenuItem.Click

        Dim frmRegister = New FrmRegister()
        Dim frmClientes = Me


        frmRegister.LimpiarTablaVentas()
        frmRegister.Show()
        Me.Hide()



    End Sub


    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged

        Dim searchValue As String = txtSearch.Text.ToLower()
        Dim searchField As String = cboSearch.SelectedItem.ToString()


        Dim clientesFiltrados As List(Of Cliente) = NegocioCliente.Filtrar(searchValue, searchField)


        dgvClients.DataSource = clientesFiltrados
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs)

        cboSearch.SelectedIndex = -1
        txtSearch.Text = ""

        txtSearch.Focus()

    End Sub


End Class
