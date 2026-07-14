Public Class Rol
  Private _Idrol As Integer
  Private _Nombre As String
  Private _Descripcion As String
  Private _Estado As Boolean

  Public Property Idrol As Integer
    Get
      Return _Idrol
    End Get
    Set(value As Integer)
      _Idrol = value
    End Set
  End Property

  Public Property Nombre As String
    Get
      Return _Nombre
    End Get
    Set(value As String)
      _Nombre = value
    End Set
  End Property

  Public Property Descripcion As String
    Get
      Return _Descripcion
    End Get
    Set(value As String)
      _Descripcion = value
    End Set
  End Property

  Public Property Estado As Boolean
    Get
      Return _Estado
    End Get
    Set(value As Boolean)
      _Estado = value
    End Set
  End Property
End Class
