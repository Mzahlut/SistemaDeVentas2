Imports CapaDatos
Imports CapaEntidad

Public Class CN_Producto

    Dim datosProducto As New CD_Producto()

    Public Function ValidateData(producto As Producto) As Boolean

        Dim resultado As Boolean = True



        If producto.Nombre = "" Then
            resultado = False
            MessageBox.Show("El nombre es obligatorio")
        End If

        If producto.PrecioUnitario = 0 Then
            resultado = False
            MessageBox.Show("El precio es obligatorio")
        End If

        If producto.Categoria = "" Then
            resultado = False
            MessageBox.Show("La categoria es obligatoria")
        End If


        Return resultado


    End Function

    Public Sub PruebaSQL()

        datosProducto.ProbarConexion()

    End Sub




    Public Sub Insertar(producto As Producto)

        datosProducto.Insertar(producto)

    End Sub


    Public Sub Acualizar(producto As Producto)

        datosProducto.Actualizar(producto)

    End Sub


    Public Sub Eliminar(producto As Producto)

        If MessageBox.Show("¿Estas seguro de querer eliminar a este cliente?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            datosProducto.Eliminar(producto)

        End If


    End Sub

    Public Function Listar() As DataSet
        Return datosProducto.ListarProductos()
    End Function


    Public Sub CargarProductosPredefinidos()

        datosProducto.CargarProductosPredefinidos()

    End Sub


    Public Sub BorrarProductos()

        datosProducto.BorrarProductos()

    End Sub

End Class
