Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Windows.Documents
Imports CapaEntidad


Public Class CD_Venta



    Private _cadenaConexion As String = ConfigurationManager.ConnectionStrings("MiConexion").ConnectionString

    Public Sub ProbarConexion()
        ' Crear una nueva conexión SQL utilizando la cadena de conexión
        Dim conn As New SqlConnection(_cadenaConexion)

        Try
            ' Intentar abrir la conexión
            conn.Open()
            ' Mostrar mensaje si la conexión fue exitosa
            MessageBox.Show("Conectado correctamente")
        Catch ex As Exception
            ' Mostrar el mensaje de error en caso de fallo
            MessageBox.Show("Error al conectar: " & ex.Message)
        Finally
            ' Cerrar la conexión
            conn.Close()
        End Try
    End Sub


    Public Sub CrearVenta(ByVal venta As Venta)



        Dim query As String = "INSERT INTO Ventas (IdCliente, Fecha, Total) VALUES (@IdCliente, @Fecha, @precioTotal)"

        Using connection As New SqlConnection(_cadenaConexion)
            Using command As New SqlCommand(query, connection)
                ' Agregas los parámetros para el cliente y la fecha
                command.Parameters.AddWithValue("@IdCliente", venta.IdCliente)
                command.Parameters.AddWithValue("@Fecha", venta.Fecha) ' Pasas la fecha como DateTime
                command.Parameters.AddWithValue("@precioTotal", venta.Total)

                connection.Open()
                command.ExecuteNonQuery()
            End Using
        End Using

    End Sub


    Public Function getUltimoId() As Integer


        Dim conexion As New SqlConnection(_cadenaConexion)
        conexion.Open()
        Dim query As String = "select TOP(1) Id from Ventas order by Id desc"
        Dim cmd As New SqlCommand(query, conexion)

        Dim resultado As Integer = cmd.ExecuteScalar()




        conexion.Close()

        Return resultado

    End Function


    Public Function CalcularTotal(ByVal venta As Venta)
        Dim lista = venta.ListaItems
        Dim total As Integer

        For Each item As VentaItem In lista


            total += item.TotalItem

        Next



        Return total



    End Function

    Public Sub InsertItems(items As List(Of VentaItem), IdVenta As Integer)

        For Each item In items
            Dim precioTotal As Integer = precioTotal * item.Cantidad
            Dim conexion As New SqlConnection(_cadenaConexion)
            conexion.Open()
            Dim query As String = "  insert into ventasitems(IDVenta, IDProducto, PrecioUnitario, Cantidad, PrecioTotal) values(" & IdVenta & ", " & item.IdProducto & ", " & item.PrecioUnitario & ", " & item.Cantidad & ", " & precioTotal & ")"
            Dim cmd As New SqlCommand(query, conexion)

            cmd.ExecuteNonQuery()
            conexion.Close()

        Next


    End Sub



    Public Function DameProducto(producto As Producto) As Decimal

        Dim id = producto.Id

        Dim conexion As New SqlConnection(_cadenaConexion)
        conexion.Open()
        Dim query As String = "select Precio from Productos where id = " & id & " "
        Dim cmd As New SqlCommand(query, conexion)

        Dim resultado As Integer = cmd.ExecuteScalar()




        conexion.Close()

        Return resultado


    End Function


    Public Function ListarVentas() As DataSet

        Dim conexion As New SqlConnection(_cadenaConexion)
        conexion.Open()
        Dim query As String = "select v.ID, c.Cliente, c.Telefono, v.Fecha, v.Total from ventas v
join clientes c on v.IDCliente = c.ID"

        Dim adapter As SqlDataAdapter
        Dim dataset As New DataSet()

        adapter = New SqlDataAdapter(query, conexion)
        adapter.Fill(dataset, "Ventas")

        Return dataset


    End Function


    Public Function buscarCliente(ByVal nombre As String) As Integer



        Dim conexion As New SqlConnection(_cadenaConexion)
        conexion.Open()
        Dim query As String = "SELECT ID FROM clientes where Cliente = '" & nombre & "'"

        Dim cmd As New SqlCommand(query, conexion)
        Dim resultado As Integer = cmd.ExecuteScalar()

        conexion.Close()

        Return resultado

    End Function


    Public Function buscarProducto(ByVal nombre As String)

        Dim conexion As New SqlConnection(_cadenaConexion)
        conexion.Open()
        Dim query As String = "SELECT ID FROM Productos where Nombre = '" & nombre & "'"

        Dim cmd As New SqlCommand(query, conexion)
        Dim resultado As Integer = cmd.ExecuteScalar()

        conexion.Close()

        Return resultado


    End Function



    Public Function ObtenerProductos() As List(Of Producto)

        Dim productos As New List(Of Producto)()
        Dim connectionStrings As String = _cadenaConexion
        Dim query As String = "select ID, Nombre, Precio, Categoria from productos"

        Try
            Using connection As New SqlConnection(connectionStrings)
                Using command As New SqlCommand(query, connection)
                    connection.Open()
                    Using reader As SqlDataReader = command.ExecuteReader()
                        While reader.Read()

                            Dim producto As New Producto()
                            producto.Id = Convert.ToInt32(reader("ID"))
                            producto.Nombre = reader("Nombre").ToString()
                            producto.PrecioUnitario = Convert.ToDecimal(reader("Precio"))
                            producto.Categoria = reader("Categoria").ToString()

                            productos.Add(producto)
                        End While
                    End Using

                    connection.Close()

                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al obtener productos: " & ex.Message)
        End Try

        Return productos

    End Function



    Public Function ObtenerClientes() As List(Of Cliente)

        Dim clientes As New List(Of Cliente)()

        Dim connectionStrings As String = _cadenaConexion
        Dim query As String = "select ID, Cliente from clientes"

        Using connection As New SqlConnection(connectionStrings)
            Using command As New SqlCommand(query, connection)
                connection.Open()
                Using reader As SqlDataReader = command.ExecuteReader()
                    While reader.Read()

                        Dim cliente As New Cliente()

                        cliente.Id = Convert.ToInt32(reader("ID"))
                        cliente.Nombre = reader("Cliente").ToString()


                        clientes.Add(cliente)
                    End While
                End Using
            End Using
        End Using

        Return clientes

    End Function



    Public Sub Eliminar(ByVal venta As Venta)

        Using conexion As New SqlConnection(_cadenaConexion)
            Try
                conexion.Open()


                Dim query As String = "DELETE FROM Ventas WHERE Id = @Id"
                Using cmd As New SqlCommand(query, conexion)

                    cmd.Parameters.AddWithValue("@Id", venta.Id)


                    cmd.ExecuteNonQuery()
                End Using

                MessageBox.Show("Venta eliminada exitosamente.")
            Catch ex As Exception

                MessageBox.Show("Ocurrió un error al eliminar la venta: " & ex.Message)
            Finally

                conexion.Close()
            End Try
        End Using


    End Sub


    Public Function ObtenerTodasLasVentas() As List(Of Venta)
        Dim ventas As New List(Of Venta)


        Using connection As New SqlConnection(_cadenaConexion)

            Dim query As String = "select v.ID, c.Cliente, c.Telefono, v.Fecha, v.Total from ventas v join clientes c on v.IDCliente = c.ID"

            'SE FILTRA SOLO POR IMPORTE TOTAL
            Using command As New SqlCommand(query, connection)

                connection.Open()

                Using reader As SqlDataReader = command.ExecuteReader()
                    While reader.Read()

                        Dim producto As New Venta() With {
                            .Id = reader("ID"),
                            .Total = Convert.ToInt32(reader("Total"))
                        }

                        ventas.Add(producto)
                    End While
                End Using
            End Using
        End Using

        '
        Return ventas
    End Function



End Class
