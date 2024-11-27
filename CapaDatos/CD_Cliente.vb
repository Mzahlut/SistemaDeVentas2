Imports System.Configuration
Imports System.Data.SqlClient
Imports CapaPresentacion
Imports CapaEntidad


Public Class CD_Cliente



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






    Public Sub Insertar(ByVal cliente As Cliente)

        Dim conexion As New SqlConnection(_cadenaConexion)
        conexion.Open()
        Dim query As String = "insert into clientes(Cliente, Telefono, Correo) values('" & cliente.Nombre & "', '" & cliente.Telefono & "', '" & cliente.Email & "')"
        Dim cmd As New SqlCommand(query, conexion)

        cmd.ExecuteNonQuery()
        conexion.Close()
        MessageBox.Show("Cliente Registrado")


    End Sub

    Public Sub Actualizar(ByVal cliente As Cliente)

        Dim conexion As New SqlConnection(_cadenaConexion)
        conexion.Open()
        Dim query As String = "update clientes set Cliente = '" & cliente.Nombre & "', Telefono = '" & cliente.Telefono & "', Correo = '" & cliente.Email & "' where id = " & cliente.Id & ""
        Dim cmd As New SqlCommand(query, conexion)

        cmd.ExecuteNonQuery()
        conexion.Close()
        MessageBox.Show("Cliente Actualizado")


    End Sub

    Public Sub Eliminar(ByVal cliente As Cliente)

        Dim conexion As New SqlConnection(_cadenaConexion)
        conexion.Open()
        Dim query As String = "delete from clientes where id = '"& cliente.id &"'"
        Dim cmd As New SqlCommand(query, conexion)

        cmd.ExecuteNonQuery()
        conexion.Close()
        MessageBox.Show("Cliente Eliminado")


    End Sub

    Public Function CargarDatosCliente() As List(Of Cliente)

        Dim conexion As New SqlConnection(_cadenaConexion)
        conexion.Open()
        Dim query As String = "SELECT COLUMN_NAME 
                                FROM INFORMATION_SCHEMA.COLUMNS
                                WHERE TABLE_NAME = 'clientes';"
        Dim cmd As New SqlCommand(query, conexion)

        cmd.ExecuteNonQuery()
        conexion.Close()


    End Function

    Public Function ListarClientes() As DataSet

        Dim conexion As New SqlConnection(_cadenaConexion)
        conexion.Open()
        Dim query As String = "select ID, Cliente as Nombre, Telefono, Correo as Email from clientes"

        Dim adapter As SqlDataAdapter
        Dim dataset As New DataSet()

        adapter = New SqlDataAdapter(query, conexion)
        adapter.Fill(dataset, "Clientes")

        Return dataset


    End Function


    Public Sub CargarClientesPredefinidos()
        Using conexion As New SqlConnection(_cadenaConexion)
            conexion.Open()


            Dim insertQuery1 As String = "INSERT INTO Clientes (Cliente, Telefono, Correo) VALUES ('Martin', '1122974706', 'mzahlut@gmail.com')"
            Dim cmdInsert1 As New SqlCommand(insertQuery1, conexion)
            cmdInsert1.ExecuteNonQuery()

            Dim insertQuery2 As String = "INSERT INTO Clientes (Cliente, Telefono, Correo) VALUES ('Federico', '1133456678', 'fede@gmail.com')"
            Dim cmdInsert2 As New SqlCommand(insertQuery2, conexion)
            cmdInsert2.ExecuteNonQuery()

            Dim insertQuery3 As String = "INSERT INTO Clientes (Cliente, Telefono, Correo) VALUES ('Julieta', '1144560098', 'juuu@gmail.com')"
            Dim cmdInsert3 As New SqlCommand(insertQuery3, conexion)
            cmdInsert3.ExecuteNonQuery()

            Dim insertQuery4 As String = "INSERT INTO Clientes (Cliente, Telefono, Correo) VALUES ('Martina', 1190076889, 'martu@gmail.com')"
            Dim cmdInsert4 As New SqlCommand(insertQuery4, conexion)
            cmdInsert4.ExecuteNonQuery()

            Dim insertQuery5 As String = "INSERT INTO Clientes (Cliente, Telefono, Correo) VALUES ('Adrian', '1199098971', 'adrianleguizamon@gmail.com')"
            Dim cmdInsert5 As New SqlCommand(insertQuery5, conexion)
            cmdInsert5.ExecuteNonQuery()




        End Using
    End Sub

    Public Sub BorrarClientes()

        Using conexion As New SqlConnection(_cadenaConexion)
            conexion.Open()


            Dim insertQuery As String = "Truncate table Clientes"
            Dim cmdInsert As New SqlCommand(insertQuery, conexion)
            cmdInsert.ExecuteNonQuery()
        End Using


    End Sub

    Public Function ObtenerTodosLosClientes() As List(Of Cliente)
        Dim clientes As New List(Of Cliente)


        Using connection As New SqlConnection(_cadenaConexion)

            Dim query As String = "SELECT Id, Cliente, Telefono, Correo FROM Clientes"


            Using command As New SqlCommand(query, connection)

                connection.Open()

                Using reader As SqlDataReader = command.ExecuteReader()
                    While reader.Read()

                        Dim cliente As New Cliente() With {
                            .Id = reader("ID"),
                            .Nombre = reader("Cliente").ToString(),
                            .Telefono = reader("Telefono").ToString(),
                            .Email = reader("Correo").ToString()
                        }

                        clientes.Add(cliente)
                    End While
                End Using
            End Using
        End Using

        '
        Return clientes
    End Function



End Class

