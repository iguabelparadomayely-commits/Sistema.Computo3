Imports System.Data.SqlClient

Public Class Conexion

  Protected conn As SqlConnection

  Public Sub New()
        Me.conn = New SqlConnection("Data Source=DESKTOP-87M8LVL;Initial Catalog=dbsistema;Integrated Security=True;TrustServerCertificate=True")
    End Sub

End Class
