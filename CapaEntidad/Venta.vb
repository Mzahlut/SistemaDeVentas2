Public Class Venta

    Private _id As Integer
    Private _IdCliente As Integer
    Private _cliente As Cliente
    Private _fecha As Date
    Private _total As Decimal
    Private _listaItems As List(Of VentaItem)

    Public Sub New()
        _listaItems = New List(Of VentaItem)() ' Inicializamos la lista
    End Sub


    Public Property Id As Integer
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
        End Set
    End Property

    Public Property Cliente As Cliente
        Get
            Return _cliente
        End Get
        Set(value As Cliente)
            _cliente = value
        End Set
    End Property

    Public Property Fecha As Date
        Get
            Return _fecha
        End Get
        Set(value As Date)
            _fecha = value
        End Set
    End Property


    Public Property Total As Decimal
        Get
            Return _total
        End Get
        Set(value As Decimal)
            _total = value
        End Set
    End Property

    Public Property IdCliente As Integer
        Get
            Return _IdCliente
        End Get
        Set(value As Integer)
            _IdCliente = value
        End Set
    End Property

    Public Property ListaItems As List(Of VentaItem)
        Get
            Return _listaItems
        End Get
        Set(value As List(Of VentaItem))
            _listaItems = value
        End Set
    End Property
End Class
