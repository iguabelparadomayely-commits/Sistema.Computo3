Imports Capa.Entidad
Imports Capa.Datos

Public Class NRol

  Public Function Listar() As DataTable
    Try
      Dim Datos As New DRol
      Dim Tabla As New DataTable

      Tabla = Datos.Listar()
      Return Tabla
    Catch ex As Exception
      MsgBox(ex.Message)
      Return Nothing
    End Try
  End Function

  Public Function Buscar(Valor As String) As DataTable
    Try
      Dim Datos As New DRol
      Dim Tabla As New DataTable
      Tabla = Datos.Buscar(Valor)
      Return Tabla
    Catch ex As Exception
      MsgBox(ex.Message)
      Return Nothing
    End Try
  End Function
    Public Function Insertar(obj As Rol) As Boolean
        Try
            Dim Datos As New DRol
            Datos.Insertar(obj)
            Return True

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False

        End Try
    End Function

End Class
