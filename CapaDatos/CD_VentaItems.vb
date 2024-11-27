Imports System.Configuration
Imports System.Data.SqlClient
Imports CapaEntidad

Public Class CD_VentaItems


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


    Public Sub InsertarItem(ByVal ventaItem As VentaItem)


        Dim conexion As New SqlConnection(_cadenaConexion)
        conexion.Open()
        Dim query As String = "insert into ventasitems (IdVenta, IdProducto, PrecioUnitario, Cantidad, PrecioTotal) values(" & ventaItem.IdVenta & "," & ventaItem.IdProducto & "," & ventaItem.PrecioUnitario & "," & ventaItem.Cantidad & ", " & ventaItem.TotalItem & ")"
        Dim cmd As New SqlCommand(query, conexion)

        cmd.ExecuteNonQuery()
        conexion.Close()
        MessageBox.Show("Producto registrado")

    End Sub

    Public Function ListarItems() As DataSet

        Dim conexion As New SqlConnection(_cadenaConexion)
        conexion.Open()
        Dim query As String = "select  p.Nombre, v.PrecioUnitario, v.Cantidad, v.PrecioTotal from ventasitems v inner join
productos p on v.IDProducto = p.ID"

        Dim adapter As SqlDataAdapter
        Dim dataset As New DataSet()

        adapter = New SqlDataAdapter(query, conexion)
        adapter.Fill(dataset, "ventasitems")

        Return dataset

    End Function


    Public Sub Eliminar(ByVal item As VentaItem)

        Dim conexion As New SqlConnection(_cadenaConexion)
        conexion.Open()
        Dim query As String = "delete from ventasitems where IDProducto = '" & item.IdProducto & "'"
        Dim cmd As New SqlCommand(query, conexion)

        cmd.ExecuteNonQuery()
        conexion.Close()
        MessageBox.Show("Producto Eliminado")


    End Sub

    Public Function CalcularTotal(items As List(Of VentaItem)) As Integer

        Dim total As Integer = 0

        For Each item As VentaItem In items

            total = item.TotalItem + total

        Next

        Return total

    End Function

    Public Sub EliminarItems()

        Dim conexion As New SqlConnection(_cadenaConexion)
        conexion.Open()
        Dim query As String = "truncate table ventasitems"
        Dim cmd As New SqlCommand(query, conexion)

        cmd.ExecuteNonQuery()
        conexion.Close()
        

    End Sub


End Class
