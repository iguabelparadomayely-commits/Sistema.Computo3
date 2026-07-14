Imports System.Data.SqlClient
Imports Capa.Entidad

Public Class DCategoria

  Inherits Conexion
  Public Function Listar() As DataTable

    Try

      Dim Resultado As SqlDataReader
      Dim Tabla As New DataTable

      Dim Comando As New SqlCommand("categoria_listar", MyBase.conn)
      Comando.CommandType = CommandType.StoredProcedure

      MyBase.conn.Open()
      Resultado = Comando.ExecuteReader()
      Tabla.Load(Resultado)
      MyBase.conn.Close()

      Return Tabla

    Catch ex As Exception
      Throw ex
    End Try


  End Function

  Public Function Buscar(Valor As String) As DataTable

        Try

            Dim Resultado As SqlDataReader
            Dim Tabla As New DataTable

            Dim Comando As New SqlCommand("categoria_buscar", MyBase.conn)
            Comando.CommandType = CommandType.StoredProcedure
            Comando.Parameters.Add("@valor", SqlDbType.VarChar).Value = Valor

            MyBase.conn.Open()
            Resultado = Comando.ExecuteReader()
            Tabla.Load(Resultado)
            MyBase.conn.Close()

            Return Tabla

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Insertar(Obj As Categoria)
        Try

            Dim Comando As New SqlCommand("categoria_insertar", MyBase.conn)
            Comando.CommandType = CommandType.StoredProcedure
            Comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = Obj.Nombre
            Comando.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = Obj.Descripcion

            MyBase.conn.Open()
            Comando.ExecuteNonQuery()
            MyBase.conn.Close()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub Actulizar(Obj As Categoria)
        Try

            Dim Comando As New SqlCommand("categoria_actualizar", MyBase.conn)
            Comando.CommandType = CommandType.StoredProcedure
            Comando.Parameters.Add("@idcategoria", SqlDbType.Int).Value = Obj.Idcategoria
            Comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = Obj.Nombre
            Comando.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = Obj.Descripcion

            MyBase.conn.Open()
            Comando.ExecuteNonQuery()
            MyBase.conn.Close()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
