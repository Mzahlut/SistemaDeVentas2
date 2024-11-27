Imports CapaDatos
Imports CapaEntidad

Public Class CN_VentaItem


    Dim datosItem = New CD_VentaItems()

    Public Function ValidateData(ventaItem As VentaItem) As Boolean

        Dim resultado As Boolean = True



        If ventaItem.IdProducto <= 0 Then
            resultado = False
            MessageBox.Show("El producto no existe")
        End If

        If ventaItem.Cantidad <= 0 Then
            resultado = False
            MessageBox.Show("Agrege al menos un producto")
        End If


        Return resultado


    End Function

    Public Sub PruebaSQL()

        datosItem.ProbarConexion()

    End Sub


    Public Sub InsertarItem(ByVal ventaItem As VentaItem)

        datosItem.InsertarItem(ventaItem)

    End Sub


    Public Function ListarItems() As DataSet

        Return datosItem.ListarItems()

    End Function





    Public Function CalcularTotal(items As List(Of VentaItem)) As Integer

        Dim total As Integer

        total = datosItem.CalcularTotal(items)

        Return total

    End Function

    Public Sub Eliminar(ByVal item As VentaItem)

        datosItem.Eliminar(item)

    End Sub

    Public Sub EliminarItems()

        datosItem.EliminarItems()

    End Sub

End Class
