
Imports System.Data.SqlClient
Imports System.Data
Public Class FrmCategorias

    Private Sub FrmCategorias_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadcategorias()
    End Sub
    Private Function loadcategorias()

        Dim SqlSelDes As New SqlCommand("SELECT Categoria FROM Categorias ORDER BY Categoria", SqlCnn)
        Dim SqlRead As SqlDataReader
        'Dim code As New String(Nothing)

        Try
            SqlRead = SqlSelDes.ExecuteReader
            While SqlRead.Read
                Me.ComboBox1.Items.Add(SqlRead.GetString(0))
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

        'Return code

    End Function

    Private Sub TSBSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSalir.Click
        Me.Close()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        cargacategoria()
    End Sub
    Private Function cargacategoria()

        'Dim SqlSelDes As New SqlCommand("SELECT categoria,usu,cat,clie,alm,pro,cod,fam,um,ent,sal,inv,ped,rpe,mov,MovL,cpe,cin,cre,cpm,con,imp,BorrFol FROM Categorias Where Categoria = '" & Me.ComboBox1.Text & "'", SqlCnn)
        Dim SqlSelDes As New SqlCommand("SELECT categoria,usu,cat,alm,AsigRut,AsigClieRuta,clie,pro,cod,fam,um,ent,sal,inv,ped,rpe,mov,MovL,cpe,cin,cre,cpm,con,imp,BorrFol,RepCar,Ubi,SurtiRut FROM Categorias Where Categoria = '" & Me.ComboBox1.Text & "'", SqlCnn)
        Dim SqlRead As SqlDataReader
        'Dim code As New String(Nothing)

        Try
            SqlRead = SqlSelDes.ExecuteReader
            While SqlRead.Read
                'Me.TextBox1.Text = SqlRead.GetString(0)
                'Me.usu.Checked = SqlRead.GetBoolean(1)
                'Me.cat.Checked = SqlRead.GetBoolean(2)
                'Me.cli.Checked = SqlRead.GetBoolean(3)
                'Me.alm.Checked = SqlRead.GetBoolean(4)
                'Me.pro.Checked = SqlRead.GetBoolean(5)
                'Me.cod.Checked = SqlRead.GetBoolean(6)
                'Me.fam.Checked = SqlRead.GetBoolean(7)
                'Me.um.Checked = SqlRead.GetBoolean(8)
                'Me.ent.Checked = SqlRead.GetBoolean(9)
                'Me.sal.Checked = SqlRead.GetBoolean(10)
                'Me.inv.Checked = SqlRead.GetBoolean(11)
                'Me.ped.Checked = SqlRead.GetBoolean(12)
                'Me.rpe.Checked = SqlRead.GetBoolean(13)
                'Me.mov.Checked = SqlRead.GetBoolean(14)
                'Me.movl.Checked = SqlRead.GetBoolean(15)
                'Me.cpe.Checked = SqlRead.GetBoolean(16)
                'Me.cin.Checked = SqlRead.GetBoolean(17)
                'Me.cre.Checked = SqlRead.GetBoolean(18)
                'Me.cpm.Checked = SqlRead.GetBoolean(19)
                'Me.con.Checked = SqlRead.GetBoolean(20)
                'Me.imp.Checked = SqlRead.GetBoolean(21)
                'Me.borrfol.Checked = SqlRead.GetBoolean(22)

                Me.TextBox1.Text = SqlRead.GetString(0)
                Me.usu.Checked = SqlRead.GetBoolean(1)
                Me.cat.Checked = SqlRead.GetBoolean(2)
                Me.alm.Checked = SqlRead.GetBoolean(3)
                If SqlRead.GetValue(4) Is DBNull.Value Then
                    Me.ChBoxAsigRut.Checked = False
                Else
                    Me.ChBoxAsigRut.Checked = SqlRead.GetBoolean(4)
                End If
                If SqlRead.GetValue(5) Is DBNull.Value Then
                    Me.ChBoxAsigCliRuta.Checked = False
                Else
                    Me.ChBoxAsigCliRuta.Checked = SqlRead.GetBoolean(5)
                End If

                Me.cli.Checked = SqlRead.GetBoolean(6)
                Me.pro.Checked = SqlRead.GetBoolean(7)
                Me.cod.Checked = SqlRead.GetBoolean(8)
                Me.fam.Checked = SqlRead.GetBoolean(9)
                Me.um.Checked = SqlRead.GetBoolean(10)
                Me.ent.Checked = SqlRead.GetBoolean(11)
                Me.sal.Checked = SqlRead.GetBoolean(12)
                Me.inv.Checked = SqlRead.GetBoolean(13)
                Me.ped.Checked = SqlRead.GetBoolean(14)
                Me.rpe.Checked = SqlRead.GetBoolean(15)
                Me.mov.Checked = SqlRead.GetBoolean(16)
                Me.movl.Checked = SqlRead.GetBoolean(17)
                Me.cpe.Checked = SqlRead.GetBoolean(18)
                Me.cin.Checked = SqlRead.GetBoolean(19)
                Me.cre.Checked = SqlRead.GetBoolean(20)
                Me.cpm.Checked = SqlRead.GetBoolean(21)
                Me.con.Checked = SqlRead.GetBoolean(22)
                Me.imp.Checked = SqlRead.GetBoolean(23)
                Me.borrfol.Checked = SqlRead.GetBoolean(24)
                If SqlRead.GetValue(25) Is DBNull.Value Then
                    Me.ChBoxReparaRecar.Checked = False
                Else
                    Me.ChBoxReparaRecar.Checked = SqlRead.GetBoolean(25)
                End If
                If SqlRead.GetValue(26) Is DBNull.Value Then
                    Me.ChBoxUbicaciones.Checked = False
                Else
                    Me.ChBoxUbicaciones.Checked = SqlRead.GetBoolean(26)
                End If
                If SqlRead.GetValue(27) Is DBNull.Value Then
                    Me.ChBoxSurtidoRuta.Checked = False
                Else
                    Me.ChBoxSurtidoRuta.Checked = SqlRead.GetBoolean(27)
                End If
            End While
            SqlRead.Close()
        Catch ex As SqlException
            MsgBox(ex.Message.ToString)
        End Try

        'Return code

    End Function
    Private Function guarda() As String
        Dim folio As String
        Dim Sqlcat As New SqlCommand("DECLARE @categoria nchar(30) " & _
        "DECLARE @usu bit " & _
        "DECLARE @cat bit " & _
        "DECLARE @alm bit " & _
        "DECLARE @AsigRut bit " & _
        "DECLARE @AsigCliRuta bit " & _
        "DECLARE @clie bit " & _
        "DECLARE @pro bit " & _
        "DECLARE @cod bit " & _
        "DECLARE @fam bit " & _
        "DECLARE @um bit " & _
        "DECLARE @ent bit " & _
        "DECLARE @sal bit " & _
        "DECLARE @inv bit " & _
        "DECLARE @ped bit " & _
        "DECLARE @rpe bit " & _
        "DECLARE @mov bit " & _
        "DECLARE @movl bit " & _
        "DECLARE @cpe bit " & _
        "DECLARE @cin bit " & _
        "DECLARE @cre bit " & _
        "DECLARE @cpm bit " & _
        "DECLARE @con bit " & _
        "DECLARE @imp bit " & _
        "DECLARE @bf bit " & _
        "DECLARE @RepCar bit " & _
        "DECLARE @Ubi bit " & _
        "DECLARE @SurteRut bit " & _
        "SET @categoria = '" & Me.TextBox1.Text & "' " & _
        "SET @usu = '" & Me.usu.Checked & "' " & _
        "SET @cat = '" & Me.cat.Checked & "' " & _
        "SET @alm = '" & Me.alm.Checked & "' " & _
        "SET @AsigRut = '" & Me.ChBoxAsigRut.Checked & "' " & _
        "SET @AsigCliRuta = '" & Me.ChBoxAsigCliRuta.Checked & "' " & _
        "SET @clie = '" & Me.cli.Checked & "' " & _
        "SET @pro = '" & Me.pro.Checked & "' " & _
        "SET @cod = '" & Me.cod.Checked & "' " & _
        "SET @fam = '" & Me.fam.Checked & "' " & _
        "SET @um = '" & Me.um.Checked & "' " & _
        "SET @ent = '" & Me.ent.Checked & "' " & _
        "SET @sal = '" & Me.sal.Checked & "' " & _
        "SET @inv = '" & Me.inv.Checked & "' " & _
        "SET @ped = '" & Me.ped.Checked & "' " & _
        "SET @rpe = '" & Me.rpe.Checked & "' " & _
        "SET @mov = '" & Me.mov.Checked & "' " & _
        "SET @movl = '" & Me.movl.Checked & "' " & _
        "SET @cpe = '" & Me.cpe.Checked & "' " & _
        "SET @cin = '" & Me.cin.Checked & "' " & _
        "SET @cre = '" & Me.cre.Checked & "' " & _
        "SET @cpm = '" & Me.cpm.Checked & "' " & _
        "SET @con = '" & Me.con.Checked & "' " & _
        "SET @imp = '" & Me.imp.Checked & "' " & _
        "SET @bf = '" & Me.borrfol.Checked & "' " & _
        "SET @RepCar = '" & Me.ChBoxReparaRecar.Checked & "' " & _
        "SET @Ubi = '" & Me.ChBoxUbicaciones.Checked & "' " & _
        "SET @SurteRut = '" & Me.ChBoxSurtidoRuta.Checked & "' " & _
        "IF EXISTS(SELECT * FROM Categorias WHERE categoria = '" & Me.TextBox1.Text & "') " & _
        "BEGIN " & _
        "UPDATE Categorias SET usu = @usu,cat = @cat, alm = @alm, AsigRut = @AsigRut, AsigClieRuta = @AsigCliRuta, clie = @clie, pro = @pro, cod = @cod, fam = @fam, um = @um," & _
        "ent = @ent, sal = @sal, inv = @inv, ped = @ped, rpe = @rpe, mov = @mov, MovL = @movl, cpe = @cpe, cin = @cin, cre = @cre, cpm = @cpm, RepCar = @RepCar, Ubi = @Ubi, SurtiRut = @SurteRut, " & _
        "con = @con, imp = @imp, borrfol = @bf WHERE categoria = @categoria " & _
        "END " & _
        "ELSE " & _
        "BEGIN " & _
        "INSERT INTO Categorias VALUES(@categoria,@usu,@cat,@alm, @AsigRut, @AsigCliRuta, @clie,@pro,@cod,@fam,@um,@ent,@sal,@inv,@ped,@rpe,@mov,@movl,@cpe,@cin,@cre,@cpm,@con,@imp,@bf,@RepCar,@Ubi,@SurteRut) " & _
        "End ", SqlCnn)

        Dim SqlRead As SqlDataReader
        Try
            SqlRead = Sqlcat.ExecuteReader
            While SqlRead.Read
                folio = SqlRead.GetValue(0)
            End While
            SqlRead.Close()
            folio = "1"
        Catch ex As SqlException
            folio = "0"
            MsgBox(ex.Message.ToString)
        End Try
        Return folio
    End Function


    Private Sub TSBSaveNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSaveNew.Click
        Dim siguar As String
        siguar = guarda()
        If siguar = "1" Then
            MsgBox("Se guardaron los cambios")
        End If
        Me.ComboBox1.Items.Clear()
        loadcategorias()
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        For Each c As Control In Me.Controls
            If TypeOf c Is TextBox Then
                Dim Chtextem As TextBox = CType(c, TextBox)
                Chtextem.Text = ""
            Else
            End If
        Next

        For Each c As Control In Me.Controls
            If TypeOf c Is CheckBox Then
                Dim Chboxtem As CheckBox = CType(c, CheckBox)
                Chboxtem.Checked = False
            Else
            End If
        Next

        For Each c As Control In Me.GroupBox1.Controls
            If TypeOf c Is CheckBox Then
                Dim Chboxtem As CheckBox = CType(c, CheckBox)
                Chboxtem.Checked = False
            Else
            End If
        Next

        For Each c As Control In Me.GroupBox2.Controls
            If TypeOf c Is CheckBox Then
                Dim Chboxtem As CheckBox = CType(c, CheckBox)
                Chboxtem.Checked = False
            Else
            End If
        Next

        For Each c As Control In Me.GroupBox3.Controls
            If TypeOf c Is CheckBox Then
                Dim Chboxtem As CheckBox = CType(c, CheckBox)
                Chboxtem.Checked = False
            Else
            End If
        Next

        For Each c As Control In Me.GroupBox4.Controls
            If TypeOf c Is CheckBox Then
                Dim Chboxtem As CheckBox = CType(c, CheckBox)
                Chboxtem.Checked = False
            Else
            End If
        Next

    End Sub
End Class