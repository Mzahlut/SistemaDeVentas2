Imports System.Windows.Documents

Public Class VentaItem


    Private _Id As Integer
    Private _IdVenta As Integer
    Private _IdProducto As Integer
    Private _cantidad As Integer
    Private _precioUnitario As Decimal
    Private _totalItem As Decimal
    Private _producto As Producto




    Public Property Producto As Producto
        Get
            Return _producto
        End Get
        Set(value As Producto)
            _producto = value
        End Set
    End Property

    Public Property Cantidad As Integer
        Get
            Return _cantidad
        End Get
        Set(value As Integer)
            _cantidad = value
        End Set
    End Property

    Public Property PrecioUnitario As Decimal
        Get
            Return _precioUnitario
        End Get
        Set(value As Decimal)
            _precioUnitario = value
        End Set
    End Property

    Public Property TotalItem As Decimal
        Get
            Return _totalItem
        End Get
        Set(value As Decimal)
            _totalItem = value
        End Set
    End Property

    Public Property Id As Integer
        Get
            Return _Id
        End Get
        Set(value As Integer)
            _Id = value
        End Set
    End Property

    Public Property IdVenta As Integer
        Get
            Return _IdVenta
        End Get
        Set(value As Integer)
            _IdVenta = value
        End Set
    End Property

    Public Property IdProducto As Integer
        Get
            Return _IdProducto
        End Get
        Set(value As Integer)
            _IdProducto = value
        End Set
    End Property
End Class
