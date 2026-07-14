Imports System.Net.Security
Imports Capa.Entidad
Imports Capa.Negocio

Public Class FrmCategoria

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
      Dim Neg As New NCategoria
      Dim Tabla As DataTable = Neg.Listar()
      DgvListado.DataSource = Tabla
      LblTotal.Text = "Total Registros: " & Tabla.Rows.Count
      Me.Formato()
            Me.Limpiar()
        Catch ex As Exception
      MsgBox(ex.Message)
    End Try

  End Sub

  Private Sub Buscar()

    Try
      Dim Neg As New Negocio.NCategoria
      Dim Valor As String = TxtValor.Text
      Dim Tabla As DataTable = Neg.Buscar(Valor)
      DgvListado.DataSource = Tabla
      LblTotal.Text = "Total Registros: " & Tabla.Rows.Count
      Me.Formato()
    Catch ex As Exception
      MsgBox(ex.Message)
    End Try
  End Sub



  Private Sub FrmCategoria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    Me.Listar()
  End Sub

  Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
    Me.Buscar()
  End Sub

  Private Sub BtnInsertar_Click(sender As Object, e As EventArgs) Handles BtnInsertar.Click
        If Me.ValidateChildren = True And TxtNombre.Text <> "" Then
            Dim Obj As New Entidad.Categoria
            Dim neg As New Negocio.NCategoria

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
    Private Sub Limpiar()
        btnActualizar.Visible = False
        TxtValor.Clear()
        TxtId.Clear()
        TxtNombre.Clear()
        TxtDescripcion.Clear()
    End Sub
    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Me.Limpiar()
        TabGeneral.SelectedIndex = 0
    End Sub


    Private Sub DgvListado_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvListado.CellDoubleClick

        TxtId.Text = DgvListado.SelectedCells.Item(1).Value
        TxtNombre.Text = DgvListado.SelectedCells.Item(2).Value
        TxtDescripcion.Text = DgvListado.SelectedCells.Item(3).Value

        TabGeneral.SelectedIndex = 1
        BtnInsertar.Visible = False
        btnActualizar.Visible = True
    End Sub

    Private Sub btnActualizar_Click_1(sender As Object, e As EventArgs) Handles btnActualizar.Click
        If Me.ValidateChildren = True And TxtNombre.Text <> "" And TxtId.Text <> "" Then
            Dim Obj As New Entidad.Categoria
            Dim neg As New Negocio.NCategoria


            Obj.Idcategoria = TxtId.Text
            Obj.Nombre = TxtNombre.Text
            Obj.Descripcion = TxtDescripcion.Text

            If (neg.Actualizar(Obj)) Then
                MsgBox("Se ha actualizado correctamente", vbOKOnly + vbInformation, "Actualización correcta")
                Me.Listar()
                TabGeneral.SelectedIndex = 0
            Else
                MsgBox("No se ha podido actualizar correctamente", vbOKOnly + vbCritical, "Actualizacion Incorrecta")
            End If
        Else
            MsgBox("Ingrese todos los datos requeridos(*)", MsgBoxStyle.OkOnly + vbCritical, "falta ingresar datos")
        End If
    End Sub
End Class