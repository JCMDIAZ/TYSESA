Imports System.IO
Imports System.Data
Imports System.Data.SqlClient

Public Class FrmUnidad
    Private CodUM As String

    Private Sub TSBSaveNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSaveNew.Click
        '===============================================================
        ' Los campos que no permiten nulos en la BD son Codigo y Nombre
        '===============================================================
        If Me.TxtCodigo.Text = Nothing And Me.TxtDescripcion.Text = Nothing Then
            MsgBox("Error, los campos son obligatorios")
            If Me.TxtCodigo.Text = Nothing Then
                Me.TxtCodigo.Focus()
            End If
            If Me.TxtDescripcion.Text = Nothing Then
                Me.TxtDescripcion.Focus()
            End If
        Else
            Dim regcod As String = ""
            If CodUM = "" Then
                Dim SqlSel1 As New SqlCommand("SELECT Clave as Clave, nombre as Descripcion, Abreviatura as Abreviatura, Activo FROM UNIDADDEMEDIDA where clave = '" & Me.TxtCodigo.Text.Trim & "' ORDER BY Clave  ", SqlCnn)
                Dim SqlRead1 As SqlDataReader
                Try
                    SqlRead1 = SqlSel1.ExecuteReader
                    While (SqlRead1.Read)
                        regcod = SqlRead1.GetString(0).ToString
                    End While
                    SqlRead1.Close()
                Catch ex As SqlException
                    MsgBox(ex.Message.ToString)
                End Try

                If regcod <> "" Then
                    MsgBox("La Clave:  " & Me.TxtCodigo.Text.Trim & " Ya existe")
                    Exit Sub
                End If

                regcod = ""
                Dim SqlSel2 As New SqlCommand("SELECT Clave as Clave, nombre as Descripcion, Abreviatura as Abreviatura, Activo FROM UNIDADDEMEDIDA where nombre = '" & Me.TxtDescripcion.Text.Trim & "' and clave <> '" & Me.TxtCodigo.Text.Trim & "' ORDER BY Clave  ", SqlCnn)
                Dim SqlRead2 As SqlDataReader
                Try
                    SqlRead2 = SqlSel2.ExecuteReader
                    While (SqlRead2.Read)
                        regcod = SqlRead2.GetString(1).ToString
                    End While
                    SqlRead2.Close()
                Catch ex As SqlException
                    MsgBox(ex.Message.ToString)
                End Try

                If regcod <> "" Then
                    MsgBox("La Descripcion:  " & Me.TxtDescripcion.Text.Trim & " Ya existe")
                    Exit Sub
                End If

                regcod = ""
                Dim SqlSel3 As New SqlCommand("SELECT Clave as Clave, nombre as Descripcion, Abreviatura as Abreviatura, Activo FROM UNIDADDEMEDIDA where Abreviatura = '" & Me.TextBox1.Text.Trim & "' ORDER BY Clave  ", SqlCnn)
                Dim SqlRead3 As SqlDataReader
                Try
                    SqlRead3 = SqlSel3.ExecuteReader
                    While (SqlRead3.Read)
                        regcod = SqlRead3.GetString(2).ToString
                    End While
                    SqlRead3.Close()
                Catch ex As SqlException
                    MsgBox(ex.Message.ToString)
                End Try

                If regcod <> "" Then
                    MsgBox("La Abreviatura:  " & Me.TextBox1.Text.Trim & " Ya existe")
                    Exit Sub
                End If
            Else
                regcod = ""
                Dim SqlSel2 As New SqlCommand("SELECT Clave as Clave, nombre as Descripcion, Abreviatura as Abreviatura, Activo FROM UNIDADDEMEDIDA where nombre = '" & Me.TxtDescripcion.Text.Trim & "' and Clave <> '" & Me.TxtCodigo.Text.Trim & "' ORDER BY Clave  ", SqlCnn)
                Dim SqlRead2 As SqlDataReader
                Try
                    SqlRead2 = SqlSel2.ExecuteReader
                    While (SqlRead2.Read)
                        regcod = SqlRead2.GetString(1).ToString
                    End While
                    SqlRead2.Close()
                Catch ex As SqlException
                    MsgBox(ex.Message.ToString)
                End Try

                If regcod <> "" Then
                    MsgBox("La Descripcion:  " & Me.TxtDescripcion.Text.Trim & " Ya existe")
                    Exit Sub
                End If

                regcod = ""
                Dim SqlSel3 As New SqlCommand("SELECT Clave as Clave, nombre as Descripcion, Abreviatura as Abreviatura, Activo FROM UNIDADDEMEDIDA where Abreviatura = '" & Me.TextBox1.Text.Trim & "' and Clave <> '" & Me.TxtCodigo.Text.Trim & "' ORDER BY Clave  ", SqlCnn)
                Dim SqlRead3 As SqlDataReader
                Try
                    SqlRead3 = SqlSel3.ExecuteReader
                    While (SqlRead3.Read)
                        regcod = SqlRead3.GetString(2).ToString
                    End While
                    SqlRead3.Close()
                Catch ex As SqlException
                    MsgBox(ex.Message.ToString)
                End Try

                If regcod <> "" Then
                    MsgBox("La Abreviatura:  " & Me.TextBox1.Text.Trim & " Ya existe")
                    Exit Sub
                End If
            End If

            guardayactu()
            MsgBox("Unidad Agregada y/o Actualizada")
            CargaGrid()

        End If
    End Sub

    Sub pongamayus()
        For Each c As Control In Me.GroupBox1.Controls
            If TypeOf c Is TextBox Then
                Dim Tboxtem As TextBox = CType(c, TextBox)
                Tboxtem.CharacterCasing = CharacterCasing.Upper
            Else
            End If
        Next
    End Sub

    Private Sub FrmUnidad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pongamayus()
        CargaGrid()
    End Sub
    Private Sub CargaGrid()

        Dim SqlSel As New SqlDataAdapter("SELECT Clave as Clave, nombre as Descripcion, Abreviatura as Abreviatura, Activo FROM unidaddemedida", SqlCnn)
        Dim DS As New DataTable
        Try
            SqlSel.Fill(DS)
            With Me.DGUM
                .DataSource = DS
            End With
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

    End Sub

    Private Sub guardayactu()
        Dim codigo As String
        Dim descripcion As String
        Dim abrev As String

        codigo = Me.TxtCodigo.Text
        descripcion = Me.TxtDescripcion.Text
        abrev = Me.TextBox1.Text

        Dim SqlInsEmp As New SqlCommand
        Dim CmdStr As New String("IF EXISTS(SELECT * FROM unidaddemedida WHERE clave = '" & codigo & "') " & _
                                "BEGIN " & _
                                "UPDATE unidaddemedida SET nombre = '" & descripcion & "', abreviatura = '" & abrev & "', Activo = '" & Me.ChActivo.Checked & "' WHERE clave = '" & codigo & "' " & _
                                "END " & _
                                "ELSE " & _
                                "INSERT INTO unidaddemedida (clave, nombre, abreviatura, Activo) " & _
                                "VALUES ('" & codigo & "','" & descripcion & "','" & abrev & "','" & Me.ChActivo.Checked & "') ")

        With SqlInsEmp
            .CommandText = CmdStr
            .Connection = SqlCnn
        End With

        Try
            SqlInsEmp.ExecuteNonQuery()
        Catch ex As Exception
            Error1 = 1
            MsgBox(ex.Message.ToString)
        End Try


        Return

    End Sub

    Private Sub TSBSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSalir.Click
        Me.Close()
    End Sub

    Private Sub DGUM_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGUM.CellClick
        If e.RowIndex > -1 Then
            Dim UMId As String
            Dim UMDESC As String
            Dim UMABR As String
            Dim value As Object = DGUM.Rows(e.RowIndex).Cells(1).Value
            If value.GetType Is GetType(DBNull) Then Return


            UMId = CType(value, String)

            Dim value1 As Object = DGUM.Rows(e.RowIndex).Cells(0).Value
            Dim value2 As Object = DGUM.Rows(e.RowIndex).Cells(2).Value

            If DGUM.Rows(e.RowIndex).Cells(3).Value Is DBNull.Value Then
                Me.ChActivo.Checked = False
            Else
                If DGUM.Rows(e.RowIndex).Cells(3).Value = True Then
                    Me.ChActivo.Checked = True
                Else
                    Me.ChActivo.Checked = False
                End If
            End If
            CodUM = CType(value1, String)
            UMDESC = CType(value1, String)
            UMABR = CType(value2, String)

            Me.TxtCodigo.Text = UMDESC
            Me.TxtDescripcion.Text = UMId
            Me.TextBox1.Text = UMABR
            Me.TxtCodigo.Enabled = False
        End If
    End Sub


    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        Me.TxtCodigo.Text = ""
        Me.TxtDescripcion.Text = ""
        Me.TextBox1.Text = ""
        CodUM = ""
        Me.ChActivo.Checked = False
        Me.TxtCodigo.Enabled = True
    End Sub

    Private Sub DGUM_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGUM.CellContentClick

    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        'Dim SqlSel As New SqlDataAdapter("SELECT FROM Clientes WHERE  Razon like '%" & TextBox2.Text & "%'", SqlCnn)
        Dim SqlSel As New SqlDataAdapter("SELECT * FROM unidaddemedida WHERE NOMBRE like '%" & Me.TBoxBuscaUM.Text & "%' ORDER BY nombre", SqlCnn)

        Dim DS1 As New DataTable
        Try
            SqlSel.Fill(DS1)
            With Me.DGUM
                .DataSource = DS1
            End With
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

    End Sub
End Class

