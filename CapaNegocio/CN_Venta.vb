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


    Public Function GetId() As Integer

        Dim ultimoId = datosVenta.getUltimoId()

        If ultimoId <= 0 Then



        End If

        Return ultimoId

    End Function


    Public Function CalcularTotal(venta As Venta)



        Return datosVenta.CalcularTotal(venta)

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

    Public Function Filtrar(searchValue As String, searchField As String) As List(Of Venta)

        Dim productos As List(Of Venta) = datosVenta.ObtenerTodasLasVentas()

        ' Verifica si el searchValue es un número válido si el campo de búsqueda es "Precio"
        Dim esNumero As Boolean = Decimal.TryParse(searchValue, New Decimal())

        ' Filtrar los productos en función del campo seleccionado
        Dim ventasFiltradas As List(Of Venta) = productos.Where(
            Function(p)
                Select Case searchField

                    Case "Total"
                        ' Solo realiza la comparación si el valor de búsqueda es un número válido
                        If esNumero Then
                            Dim total As Decimal = CDec(searchValue) ' Convertimos el valor a Decimal
                            Return p.Total = total ' Comparamos el precio
                        Else
                            Return False ' Si no es un número, no coincide
                        End If

                    Case Else
                        Return False
                End Select
            End Function
        ).ToList()

        Return ventasFiltradas
    End Function


End Class
