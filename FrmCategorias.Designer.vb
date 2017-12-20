<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCategorias
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCategorias))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ChBoxAsigCliRuta = New System.Windows.Forms.CheckBox
        Me.ChBoxAsigRut = New System.Windows.Forms.CheckBox
        Me.cat = New System.Windows.Forms.CheckBox
        Me.um = New System.Windows.Forms.CheckBox
        Me.fam = New System.Windows.Forms.CheckBox
        Me.cod = New System.Windows.Forms.CheckBox
        Me.pro = New System.Windows.Forms.CheckBox
        Me.alm = New System.Windows.Forms.CheckBox
        Me.cli = New System.Windows.Forms.CheckBox
        Me.usu = New System.Windows.Forms.CheckBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.ChBoxUbicaciones = New System.Windows.Forms.CheckBox
        Me.ChBoxReparaRecar = New System.Windows.Forms.CheckBox
        Me.rpe = New System.Windows.Forms.CheckBox
        Me.ped = New System.Windows.Forms.CheckBox
        Me.inv = New System.Windows.Forms.CheckBox
        Me.sal = New System.Windows.Forms.CheckBox
        Me.ent = New System.Windows.Forms.CheckBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.ChBoxSurtidoRuta = New System.Windows.Forms.CheckBox
        Me.movl = New System.Windows.Forms.CheckBox
        Me.cpm = New System.Windows.Forms.CheckBox
        Me.cre = New System.Windows.Forms.CheckBox
        Me.cin = New System.Windows.Forms.CheckBox
        Me.cpe = New System.Windows.Forms.CheckBox
        Me.mov = New System.Windows.Forms.CheckBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.borrfol = New System.Windows.Forms.CheckBox
        Me.con = New System.Windows.Forms.CheckBox
        Me.TSOpciones = New System.Windows.Forms.ToolStrip
        Me.TSBSaveNew = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.TSBSalir = New System.Windows.Forms.ToolStripButton
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.imp = New System.Windows.Forms.CheckBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.TSOpciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ChBoxAsigCliRuta)
        Me.GroupBox1.Controls.Add(Me.ChBoxAsigRut)
        Me.GroupBox1.Controls.Add(Me.cat)
        Me.GroupBox1.Controls.Add(Me.um)
        Me.GroupBox1.Controls.Add(Me.fam)
        Me.GroupBox1.Controls.Add(Me.cod)
        Me.GroupBox1.Controls.Add(Me.pro)
        Me.GroupBox1.Controls.Add(Me.alm)
        Me.GroupBox1.Controls.Add(Me.cli)
        Me.GroupBox1.Controls.Add(Me.usu)
        Me.GroupBox1.Location = New System.Drawing.Point(21, 80)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(168, 268)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "CATALOGOS"
        '
        'ChBoxAsigCliRuta
        '
        Me.ChBoxAsigCliRuta.AutoSize = True
        Me.ChBoxAsigCliRuta.Location = New System.Drawing.Point(20, 116)
        Me.ChBoxAsigCliRuta.Name = "ChBoxAsigCliRuta"
        Me.ChBoxAsigCliRuta.Size = New System.Drawing.Size(139, 17)
        Me.ChBoxAsigCliRuta.TabIndex = 11
        Me.ChBoxAsigCliRuta.Text = "Asignacion Cliente-Ruta"
        Me.ChBoxAsigCliRuta.UseVisualStyleBackColor = True
        '
        'ChBoxAsigRut
        '
        Me.ChBoxAsigRut.AutoSize = True
        Me.ChBoxAsigRut.Location = New System.Drawing.Point(20, 94)
        Me.ChBoxAsigRut.Name = "ChBoxAsigRut"
        Me.ChBoxAsigRut.Size = New System.Drawing.Size(119, 17)
        Me.ChBoxAsigRut.TabIndex = 10
        Me.ChBoxAsigRut.Text = "Asignacion de Ruta"
        Me.ChBoxAsigRut.UseVisualStyleBackColor = True
        '
        'cat
        '
        Me.cat.AutoSize = True
        Me.cat.Location = New System.Drawing.Point(20, 49)
        Me.cat.Name = "cat"
        Me.cat.Size = New System.Drawing.Size(76, 17)
        Me.cat.TabIndex = 3
        Me.cat.Text = "Categorias"
        Me.cat.UseVisualStyleBackColor = True
        '
        'um
        '
        Me.um.AutoSize = True
        Me.um.Location = New System.Drawing.Point(20, 227)
        Me.um.Name = "um"
        Me.um.Size = New System.Drawing.Size(123, 17)
        Me.um.TabIndex = 9
        Me.um.Text = "Unidades de medida"
        Me.um.UseVisualStyleBackColor = True
        '
        'fam
        '
        Me.fam.AutoSize = True
        Me.fam.Location = New System.Drawing.Point(20, 206)
        Me.fam.Name = "fam"
        Me.fam.Size = New System.Drawing.Size(63, 17)
        Me.fam.TabIndex = 8
        Me.fam.Text = "Familias"
        Me.fam.UseVisualStyleBackColor = True
        '
        'cod
        '
        Me.cod.AutoSize = True
        Me.cod.Location = New System.Drawing.Point(20, 184)
        Me.cod.Name = "cod"
        Me.cod.Size = New System.Drawing.Size(74, 17)
        Me.cod.TabIndex = 7
        Me.cod.Text = "Productos"
        Me.cod.UseVisualStyleBackColor = True
        '
        'pro
        '
        Me.pro.AutoSize = True
        Me.pro.Location = New System.Drawing.Point(20, 162)
        Me.pro.Name = "pro"
        Me.pro.Size = New System.Drawing.Size(86, 17)
        Me.pro.TabIndex = 6
        Me.pro.Text = "Proveedores"
        Me.pro.UseVisualStyleBackColor = True
        '
        'alm
        '
        Me.alm.AutoSize = True
        Me.alm.Location = New System.Drawing.Point(20, 72)
        Me.alm.Name = "alm"
        Me.alm.Size = New System.Drawing.Size(78, 17)
        Me.alm.TabIndex = 5
        Me.alm.Text = "Almacenes"
        Me.alm.UseVisualStyleBackColor = True
        '
        'cli
        '
        Me.cli.AutoSize = True
        Me.cli.Location = New System.Drawing.Point(20, 139)
        Me.cli.Name = "cli"
        Me.cli.Size = New System.Drawing.Size(63, 17)
        Me.cli.TabIndex = 4
        Me.cli.Text = "Clientes"
        Me.cli.UseVisualStyleBackColor = True
        '
        'usu
        '
        Me.usu.AutoSize = True
        Me.usu.Location = New System.Drawing.Point(20, 28)
        Me.usu.Name = "usu"
        Me.usu.Size = New System.Drawing.Size(67, 17)
        Me.usu.TabIndex = 2
        Me.usu.Text = "Usuarios"
        Me.usu.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ChBoxUbicaciones)
        Me.GroupBox2.Controls.Add(Me.ChBoxReparaRecar)
        Me.GroupBox2.Controls.Add(Me.rpe)
        Me.GroupBox2.Controls.Add(Me.ped)
        Me.GroupBox2.Controls.Add(Me.inv)
        Me.GroupBox2.Controls.Add(Me.sal)
        Me.GroupBox2.Controls.Add(Me.ent)
        Me.GroupBox2.Location = New System.Drawing.Point(212, 80)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(158, 133)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "OPERACION"
        '
        'ChBoxUbicaciones
        '
        Me.ChBoxUbicaciones.AutoSize = True
        Me.ChBoxUbicaciones.Location = New System.Drawing.Point(19, 94)
        Me.ChBoxUbicaciones.Name = "ChBoxUbicaciones"
        Me.ChBoxUbicaciones.Size = New System.Drawing.Size(85, 17)
        Me.ChBoxUbicaciones.TabIndex = 16
        Me.ChBoxUbicaciones.Text = "Ubicaciones"
        Me.ChBoxUbicaciones.UseVisualStyleBackColor = True
        '
        'ChBoxReparaRecar
        '
        Me.ChBoxReparaRecar.AutoSize = True
        Me.ChBoxReparaRecar.Location = New System.Drawing.Point(19, 63)
        Me.ChBoxReparaRecar.Name = "ChBoxReparaRecar"
        Me.ChBoxReparaRecar.Size = New System.Drawing.Size(119, 17)
        Me.ChBoxReparaRecar.TabIndex = 15
        Me.ChBoxReparaRecar.Text = "Reapara Recargas "
        Me.ChBoxReparaRecar.UseVisualStyleBackColor = True
        '
        'rpe
        '
        Me.rpe.AutoSize = True
        Me.rpe.Location = New System.Drawing.Point(107, 83)
        Me.rpe.Name = "rpe"
        Me.rpe.Size = New System.Drawing.Size(103, 17)
        Me.rpe.TabIndex = 14
        Me.rpe.Text = "Revisar Pedidos"
        Me.rpe.UseVisualStyleBackColor = True
        Me.rpe.Visible = False
        '
        'ped
        '
        Me.ped.AutoSize = True
        Me.ped.Location = New System.Drawing.Point(107, 66)
        Me.ped.Name = "ped"
        Me.ped.Size = New System.Drawing.Size(64, 17)
        Me.ped.TabIndex = 13
        Me.ped.Text = "Pedidos"
        Me.ped.UseVisualStyleBackColor = True
        Me.ped.Visible = False
        '
        'inv
        '
        Me.inv.AutoSize = True
        Me.inv.Location = New System.Drawing.Point(19, 28)
        Me.inv.Name = "inv"
        Me.inv.Size = New System.Drawing.Size(78, 17)
        Me.inv.TabIndex = 12
        Me.inv.Text = "Inventarios"
        Me.inv.UseVisualStyleBackColor = True
        '
        'sal
        '
        Me.sal.AutoSize = True
        Me.sal.Location = New System.Drawing.Point(107, 50)
        Me.sal.Name = "sal"
        Me.sal.Size = New System.Drawing.Size(60, 17)
        Me.sal.TabIndex = 11
        Me.sal.Text = "Salidas"
        Me.sal.UseVisualStyleBackColor = True
        Me.sal.Visible = False
        '
        'ent
        '
        Me.ent.AutoSize = True
        Me.ent.Location = New System.Drawing.Point(107, 35)
        Me.ent.Name = "ent"
        Me.ent.Size = New System.Drawing.Size(68, 17)
        Me.ent.TabIndex = 10
        Me.ent.Text = "Entradas"
        Me.ent.UseVisualStyleBackColor = True
        Me.ent.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ChBoxSurtidoRuta)
        Me.GroupBox3.Controls.Add(Me.movl)
        Me.GroupBox3.Controls.Add(Me.cpm)
        Me.GroupBox3.Controls.Add(Me.cre)
        Me.GroupBox3.Controls.Add(Me.cin)
        Me.GroupBox3.Controls.Add(Me.cpe)
        Me.GroupBox3.Controls.Add(Me.mov)
        Me.GroupBox3.Location = New System.Drawing.Point(375, 80)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(175, 133)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "CONSULTAS Y REPORTES"
        '
        'ChBoxSurtidoRuta
        '
        Me.ChBoxSurtidoRuta.AutoSize = True
        Me.ChBoxSurtidoRuta.Location = New System.Drawing.Point(21, 94)
        Me.ChBoxSurtidoRuta.Name = "ChBoxSurtidoRuta"
        Me.ChBoxSurtidoRuta.Size = New System.Drawing.Size(85, 17)
        Me.ChBoxSurtidoRuta.TabIndex = 21
        Me.ChBoxSurtidoRuta.Text = "Surtido-Ruta"
        Me.ChBoxSurtidoRuta.UseVisualStyleBackColor = True
        '
        'movl
        '
        Me.movl.AutoSize = True
        Me.movl.Location = New System.Drawing.Point(133, 40)
        Me.movl.Name = "movl"
        Me.movl.Size = New System.Drawing.Size(125, 17)
        Me.movl.TabIndex = 20
        Me.movl.Text = "Movimientos Locales"
        Me.movl.UseVisualStyleBackColor = True
        Me.movl.Visible = False
        '
        'cpm
        '
        Me.cpm.AutoSize = True
        Me.cpm.Location = New System.Drawing.Point(124, 94)
        Me.cpm.Name = "cpm"
        Me.cpm.Size = New System.Drawing.Size(103, 17)
        Me.cpm.TabIndex = 19
        Me.cpm.Text = "Productos Movs"
        Me.cpm.UseVisualStyleBackColor = True
        Me.cpm.Visible = False
        '
        'cre
        '
        Me.cre.AutoSize = True
        Me.cre.Location = New System.Drawing.Point(124, 76)
        Me.cre.Name = "cre"
        Me.cre.Size = New System.Drawing.Size(64, 17)
        Me.cre.TabIndex = 18
        Me.cre.Text = "Reorder"
        Me.cre.UseVisualStyleBackColor = True
        Me.cre.Visible = False
        '
        'cin
        '
        Me.cin.AutoSize = True
        Me.cin.Location = New System.Drawing.Point(21, 63)
        Me.cin.Name = "cin"
        Me.cin.Size = New System.Drawing.Size(78, 17)
        Me.cin.TabIndex = 17
        Me.cin.Text = "Inventarios"
        Me.cin.UseVisualStyleBackColor = True
        '
        'cpe
        '
        Me.cpe.AutoSize = True
        Me.cpe.Location = New System.Drawing.Point(133, 53)
        Me.cpe.Name = "cpe"
        Me.cpe.Size = New System.Drawing.Size(64, 17)
        Me.cpe.TabIndex = 16
        Me.cpe.Text = "Pedidos"
        Me.cpe.UseVisualStyleBackColor = True
        Me.cpe.Visible = False
        '
        'mov
        '
        Me.mov.AutoSize = True
        Me.mov.Location = New System.Drawing.Point(21, 28)
        Me.mov.Name = "mov"
        Me.mov.Size = New System.Drawing.Size(129, 17)
        Me.mov.TabIndex = 15
        Me.mov.Text = "Movimientos Almacen"
        Me.mov.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.borrfol)
        Me.GroupBox4.Controls.Add(Me.con)
        Me.GroupBox4.Location = New System.Drawing.Point(212, 243)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(158, 83)
        Me.GroupBox4.TabIndex = 8
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "SERVER"
        Me.GroupBox4.Visible = False
        '
        'borrfol
        '
        Me.borrfol.AutoSize = True
        Me.borrfol.Location = New System.Drawing.Point(19, 46)
        Me.borrfol.Name = "borrfol"
        Me.borrfol.Size = New System.Drawing.Size(84, 17)
        Me.borrfol.TabIndex = 21
        Me.borrfol.Text = "Borrar Folios"
        Me.borrfol.UseVisualStyleBackColor = True
        '
        'con
        '
        Me.con.AutoSize = True
        Me.con.Location = New System.Drawing.Point(19, 23)
        Me.con.Name = "con"
        Me.con.Size = New System.Drawing.Size(69, 17)
        Me.con.TabIndex = 20
        Me.con.Text = "Contador"
        Me.con.UseVisualStyleBackColor = True
        '
        'TSOpciones
        '
        Me.TSOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSBSaveNew, Me.ToolStripSeparator1, Me.ToolStripButton3, Me.ToolStripSeparator2, Me.TSBSalir})
        Me.TSOpciones.Location = New System.Drawing.Point(0, 0)
        Me.TSOpciones.Name = "TSOpciones"
        Me.TSOpciones.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.TSOpciones.Size = New System.Drawing.Size(575, 25)
        Me.TSOpciones.TabIndex = 9
        Me.TSOpciones.Text = "ToolStrip1"
        '
        'TSBSaveNew
        '
        Me.TSBSaveNew.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TSBSaveNew.Image = CType(resources.GetObject("TSBSaveNew.Image"), System.Drawing.Image)
        Me.TSBSaveNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBSaveNew.Name = "TSBSaveNew"
        Me.TSBSaveNew.Size = New System.Drawing.Size(76, 22)
        Me.TSBSaveNew.Text = "GUARDAR"
        Me.TSBSaveNew.ToolTipText = "Guardar y Nuevo"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton3.Image = Global.VisionTec.My.Resources.Resources._1366681822_edit_clear
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(72, 22)
        Me.ToolStripButton3.Text = "LIMPIAR"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'TSBSalir
        '
        Me.TSBSalir.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TSBSalir.Image = CType(resources.GetObject("TSBSalir.Image"), System.Drawing.Image)
        Me.TSBSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBSalir.Name = "TSBSalir"
        Me.TSBSalir.Size = New System.Drawing.Size(57, 22)
        Me.TSBSalir.Text = "SALIR"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(32, 41)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox1.TabIndex = 0
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(226, 41)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 1
        '
        'imp
        '
        Me.imp.AutoSize = True
        Me.imp.Location = New System.Drawing.Point(396, 264)
        Me.imp.Name = "imp"
        Me.imp.Size = New System.Drawing.Size(71, 17)
        Me.imp.TabIndex = 21
        Me.imp.Text = "Impresion"
        Me.imp.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(170, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Categoria"
        '
        'FrmCategorias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(575, 371)
        Me.Controls.Add(Me.imp)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.TSOpciones)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmCategorias"
        Me.Text = "CATEGORIAS"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.TSOpciones.ResumeLayout(False)
        Me.TSOpciones.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents um As System.Windows.Forms.CheckBox
    Friend WithEvents fam As System.Windows.Forms.CheckBox
    Friend WithEvents cod As System.Windows.Forms.CheckBox
    Friend WithEvents pro As System.Windows.Forms.CheckBox
    Friend WithEvents alm As System.Windows.Forms.CheckBox
    Friend WithEvents cli As System.Windows.Forms.CheckBox
    Friend WithEvents usu As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rpe As System.Windows.Forms.CheckBox
    Friend WithEvents ped As System.Windows.Forms.CheckBox
    Friend WithEvents inv As System.Windows.Forms.CheckBox
    Friend WithEvents sal As System.Windows.Forms.CheckBox
    Friend WithEvents ent As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cpm As System.Windows.Forms.CheckBox
    Friend WithEvents cre As System.Windows.Forms.CheckBox
    Friend WithEvents cin As System.Windows.Forms.CheckBox
    Friend WithEvents cpe As System.Windows.Forms.CheckBox
    Friend WithEvents mov As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents con As System.Windows.Forms.CheckBox
    Friend WithEvents TSOpciones As System.Windows.Forms.ToolStrip
    Friend WithEvents TSBSaveNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TSBSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents cat As System.Windows.Forms.CheckBox
    Friend WithEvents imp As System.Windows.Forms.CheckBox
    Friend WithEvents movl As System.Windows.Forms.CheckBox
    Friend WithEvents borrfol As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ChBoxAsigCliRuta As System.Windows.Forms.CheckBox
    Friend WithEvents ChBoxAsigRut As System.Windows.Forms.CheckBox
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ChBoxUbicaciones As System.Windows.Forms.CheckBox
    Friend WithEvents ChBoxReparaRecar As System.Windows.Forms.CheckBox
    Friend WithEvents ChBoxSurtidoRuta As System.Windows.Forms.CheckBox
End Class
