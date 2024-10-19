Imports System.Data.SqlClient
Imports CapaEntidad

Public Class CD_Producto

    Private _cadenaConexion As String = "Data Source=DESKTOP-90UV9EI;Initial Catalog=pruebademo;Integrated Security=True"

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

    Public Sub Insertar(ByVal producto As Producto)


        Dim conexion As New SqlConnection(_cadenaConexion)
        conexion.Open()
        Dim query As String = "insert into productos(Nombre, Precio, Categoria) values('" & producto.Nombre & "', '" & producto.PrecioUnitario & "', '" & producto.Categoria & "')"
        Dim cmd As New SqlCommand(query, conexion)

        cmd.ExecuteNonQuery()
        conexion.Close()
        MessageBox.Show("Producto registrado")

    End Sub

    Public Sub Actualizar(ByVal producto As Producto)

        Dim conexion As New SqlConnection(_cadenaConexion)
        conexion.Open()
        Dim query As String = "update productos set Nombre = '" & producto.Nombre & "', Precio = '" & producto.PrecioUnitario & "', Categoria = '" & producto.Categoria & "' where id = " & producto.Id & ""
        Dim cmd As New SqlCommand(query, conexion)

        cmd.ExecuteNonQuery()
        conexion.Close()
        MessageBox.Show("Producto Actualizado")


    End Sub

    Public Sub Eliminar(ByVal producto As Producto)

        Dim conexion As New SqlConnection(_cadenaConexion)
        conexion.Open()
        Dim query As String = "delete from productos where id = '" & producto.Id & "'"
        Dim cmd As New SqlCommand(query, conexion)

        cmd.ExecuteNonQuery()
        conexion.Close()
        MessageBox.Show("Cliente Eliminado")


    End Sub


    Public Sub CargarProductosPredefinidos()
        Using conexion As New SqlConnection(_cadenaConexion)
            conexion.Open()


            Dim insertQuery1 As String = "INSERT INTO productos (Nombre, Precio, Categoria) VALUES ('Leche', 100, 'Lacteos')"
            Dim cmdInsert1 As New SqlCommand(insertQuery1, conexion)
            cmdInsert1.ExecuteNonQuery()

            Dim insertQuery2 As String = "INSERT INTO productos (Nombre, Precio, Categoria) VALUES ('Coca-Cola', 200, 'Gaseosas')"
            Dim cmdInsert2 As New SqlCommand(insertQuery2, conexion)
            cmdInsert2.ExecuteNonQuery()

            Dim insertQuery3 As String = "INSERT INTO productos (Nombre, Precio, Categoria) VALUES ('Harina', 50, 'Almacen')"
            Dim cmdInsert3 As New SqlCommand(insertQuery3, conexion)
            cmdInsert3.ExecuteNonQuery()

            Dim insertQuery4 As String = "INSERT INTO productos (Nombre, Precio, Categoria) VALUES ('Iphone XS', 2500, 'Electronicos')"
            Dim cmdInsert4 As New SqlCommand(insertQuery4, conexion)
            cmdInsert4.ExecuteNonQuery()

            Dim insertQuery5 As String = "INSERT INTO productos (Nombre, Precio, Categoria) VALUES ('Televisor 50 pulg.', 4000, 'Electronicos')"
            Dim cmdInsert5 As New SqlCommand(insertQuery5, conexion)
            cmdInsert5.ExecuteNonQuery()

            Dim insertQuery6 As String = "INSERT INTO productos (Nombre, Precio, Categoria) VALUES ('Pringles Cheddar', 20, 'Almacen')"
            Dim cmdInsert6 As New SqlCommand(insertQuery6, conexion)
            cmdInsert6.ExecuteNonQuery()

            Dim insertQuery7 As String = "INSERT INTO productos (Nombre, Precio, Categoria) VALUES ('Carne picada x kg', 10, 'Carniceria')"
            Dim cmdInsert7 As New SqlCommand(insertQuery7, conexion)
            cmdInsert7.ExecuteNonQuery()

            Dim insertQuery8 As String = "INSERT INTO productos (Nombre, Precio, Categoria) VALUES ('Pollo x kg', 5, 'Carniceria')"
            Dim cmdInsert8 As New SqlCommand(insertQuery8, conexion)
            cmdInsert8.ExecuteNonQuery()


            Dim insertQuery9 As String = "INSERT INTO productos (Nombre, Precio, Categoria) VALUES ('Jamon crudo x 100gr', 25, 'Fiambreria')"
            Dim cmdInsert9 As New SqlCommand(insertQuery9, conexion)
            cmdInsert9.ExecuteNonQuery()


            Dim insertQuery10 As String = "INSERT INTO productos (Nombre, Precio, Categoria) VALUES ('Aceite', 8, 'Almacen')"
            Dim cmdInsert10 As New SqlCommand(insertQuery10, conexion)
            cmdInsert10.ExecuteNonQuery()



        End Using
    End Sub



    Public Sub BorrarProductos()

        Using conexion As New SqlConnection(_cadenaConexion)
            conexion.Open()


            Dim insertQuery As String = "Truncate table productos"
            Dim cmdInsert As New SqlCommand(insertQuery, conexion)
            cmdInsert.ExecuteNonQuery()
        End Using


    End Sub



    Public Function ListarProductos() As DataSet

        Dim conexion As New SqlConnection(_cadenaConexion)
        conexion.Open()
        Dim query As String = "SELECT * FROM PRODUCTOS"

        Dim adapter As SqlDataAdapter
        Dim dataset As New DataSet()

        adapter = New SqlDataAdapter(query, conexion)
        adapter.Fill(dataset, "Productos")

        Return dataset


    End Function




End Class
