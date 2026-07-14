

Public Class FrmRol

  Private Sub Formato()
    DgvListado.Columns(0).Visible = False
    DgvListado.Columns(0).Width = 100
    DgvListado.Columns(1).Width = 50
    DgvListado.Columns(2).Width = 150
    DgvListado.Columns(3).Width = 400
    DgvListado.Columns(4).Width = 100
  End Sub

  Private Sub Listar()
    Try
      Dim Neg As New Negocio.NRol
      Dim Tabla As DataTable = Neg.Listar()
      DgvListado.DataSource = Tabla
      LblTotal.Text = "Total Registros: " & Tabla.Rows.Count
      Me.Formato()
    Catch ex As Exception
      MsgBox(ex.Message)
    End Try
  End Sub

  Private Sub Buscar()
    Try
      Dim Neg As New Negocio.NRol
      Dim Valor As String = TxtValor.Text
      Dim Tabla As DataTable = Neg.Buscar(Valor)
      DgvListado.DataSource = Tabla
      LblTotal.Text = "Total Registros: " & Tabla.Rows.Count
      Me.Formato()
    Catch ex As Exception
      MsgBox(ex.Message)
    End Try
  End Sub



  Private Sub BtnCancelar_Click(sender As Object, e As EventArgs)

  End Sub


  Private Sub TxtNombre_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)

  End Sub

  Private Sub FrmRol_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    Me.Listar()
  End Sub

  Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
    Me.Buscar()
  End Sub

  Private Sub BtnInsertar_Click_1(sender As Object, e As EventArgs) Handles BtnInsertar.Click
        If Me.ValidateChildren = True And TxtNombre.Text <> "" Then
            Dim Obj As New Entidad.Rol
            Dim neg As New Negocio.NRol

            Obj.Nombre = TxtNombre.Text
            Obj.Descripcion = TxtDescripcion.Text

            If (neg.Insertar(Obj)) Then
                MsgBox("Se ha registrado correctamente", vbOKOnly + vbInformation, "Registro Correcto")
                Me.Listar()
            Else
                MsgBox("No se ha registrado Correctamente", vbOKOnly + vbCritical, "Registro Incorrecto")
            End If
        Else
            MsgBox("Ingrese todos los datos requeridos(*)", MsgBoxStyle.OkOnly + vbCritical, "falta ingresar datos")
        End If
    End Sub

  Private Sub BtnCancelar_Click_1(sender As Object, e As EventArgs) Handles BtnCancelar.Click

  End Sub
End Class