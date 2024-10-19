Imports CapaDatos
Imports CapaEntidad

Public Class CN_Venta

    Dim datosVenta As New CD_Venta()

    Public Function ValidateData(venta As Venta) As Boolean

        Dim resultado As Boolean = True



        If venta.Id = 0 Then
            resultado = False
            MessageBox.Show("El nombre es obligatorio")
        End If


        If venta.Total <= 0 Then
            resultado = False
            MessageBox.Show("La categoria es obligatoria")
        End If


        Return resultado


    End Function

    Public Sub PruebaSQL()

        datosVenta.ProbarConexion()

    End Sub

    Public Sub CrearVenta(venta As Venta)

        datosVenta.CrearVenta(venta)

        Dim ultimoId As Integer = datosVenta.getUltimoId()

        datosVenta.InsertItems(venta.ListaItems, ultimoId)

        MessageBox.Show("Venta registrada")


    End Sub


    Public Function DameCliente(ByVal nombre As String) As Integer

        Dim IdCliente As Integer

        Return IdCliente = datosVenta.buscarCliente(nombre)

    End Function


    Public Function DameProducto(ByVal nombre As String) As Decimal

        Dim IdProducto As Integer

        Return IdProducto = datosVenta.buscarProducto(nombre)


    End Function


    Public Function DameProducto(producto As Producto)

        datosVenta.DameProducto(producto)

    End Function


    Public Function Listar() As DataSet
        Return datosVenta.ListarVentas()
    End Function


    Public Function ObtenerProductos() As List(Of Producto)
        Return datosVenta.ObtenerProductos()
    End Function

    Public Function ObtenerClientes() As List(Of Cliente)

        Return datosVenta.ObtenerClientes()

    End Function

    Public Sub Eliminar(venta As Venta)

        If MessageBox.Show("¿Estas seguro de querer eliminar a esta Venta?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            datosVenta.Eliminar(venta)

        End If


    End Sub

End Class
