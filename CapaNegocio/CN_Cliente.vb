Imports CapaDatos
Imports CapaEntidad


Public Class CN_Cliente

    Dim datosCliente As New CD_Cliente()



    Public Function ValidateData(cliente As Cliente) As Boolean

        Dim resultado As Boolean = True



        If cliente.Nombre = "" Then
            resultado = False
            MessageBox.Show("El nombre es obligatorio")
        End If

        If cliente.Telefono = "" Then
            resultado = False
            MessageBox.Show("El telefono es obligatorio")
        End If

        If cliente.Email = "" Then
            resultado = False
            MessageBox.Show("El Email es obligatorio")
        End If


        Return resultado


    End Function

    Public Function Filtrar(searchValue As String, searchField As String) As List(Of Cliente)

        Dim clientes As List(Of Cliente) = datosCliente.ObtenerTodosLosClientes()

        Dim clientesFiltrados As List(Of Cliente) = clientes.Where(
            Function(c)
                Select Case searchField
                    Case "Cliente"
                        Return c.Nombre.ToLower().Contains(searchValue.ToLower())
                    Case "Telefono"
                        Return c.Telefono.ToLower().Contains(searchValue.ToLower())
                    Case "Correo"
                        Return c.Email.ToLower().Contains(searchValue.ToLower())
                    Case Else
                        Return False
                End Select
            End Function
        ).ToList()

        Return clientesFiltrados
    End Function


    Public Sub PruebaSQL()

        datosCliente.ProbarConexion()

    End Sub

    Public Sub Insertar(cliente As Cliente)

        datosCliente.Insertar(cliente)

    End Sub

    Public Sub Acualizar(cliente As Cliente)

        datosCliente.Actualizar(cliente)

    End Sub

    Public Sub Eliminar(cliente As Cliente)

        If MessageBox.Show("¿Estas seguro de querer eliminar a este cliente?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            datosCliente.Eliminar(cliente)

        End If


    End Sub


    Public Function Listar() As DataSet
        Return datosCliente.ListarClientes()
    End Function


    Public Sub CargarClientesPredefinidos()

        datosCliente.CargarClientesPredefinidos()

    End Sub

    Public Sub BorrarClientes()

        datosCliente.BorrarClientes()

    End Sub

End Class
