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

    Public Function Filtrar(searchValue As String, searchField As String) As List(Of Producto)

        Dim productos As List(Of Producto) = datosProducto.ObtenerTodosLosProductos()

        ' Verifica si el searchValue es un número válido si el campo de búsqueda es "Precio"
        Dim esNumero As Boolean = Decimal.TryParse(searchValue, New Decimal())

        ' Filtrar los productos en función del campo seleccionado
        Dim productosFiltrados As List(Of Producto) = productos.Where(
            Function(p)
                Select Case searchField
                    Case "Nombre"
                        Return p.Nombre.ToLower().Contains(searchValue.ToLower())
                    Case "Precio"
                        ' Solo realiza la comparación si el valor de búsqueda es un número válido
                        If esNumero Then
                            Dim precioBuscar As Decimal = CDec(searchValue) ' Convertimos el valor a Decimal
                            Return p.PrecioUnitario = precioBuscar ' Comparamos el precio
                        Else
                            Return False ' Si no es un número, no coincide
                        End If
                    Case "Categoria"
                        Return p.Categoria.ToLower().Contains(searchValue.ToLower())
                    Case Else
                        Return False
                End Select
            End Function
        ).ToList()

        Return productosFiltrados
    End Function

End Class
