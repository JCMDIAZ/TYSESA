<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEmpleados
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEmpleados))
        Me.GpoEmpleados = New System.Windows.Forms.GroupBox
        Me.Chkact = New System.Windows.Forms.CheckBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Txtcpass = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Txtpass = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cbCategoria = New System.Windows.Forms.ComboBox
        Me.TxtNombre = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtCodigo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.OPFImagen = New System.Windows.Forms.OpenFileDialog
        Me.DGUsuarios = New System.Windows.Forms.DataGridView
        Me.TSOpciones = New System.Windows.Forms.ToolStrip
        Me.TSBSaveNew = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.TSBSalir = New System.Windows.Forms.ToolStripButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.lbalmacen2 = New System.Windows.Forms.LinkLabel
        Me.lbalmacen = New System.Windows.Forms.LinkLabel
        Me.DGalmusu = New System.Windows.Forms.DataGridView
        Me.DGAlmacen = New System.Windows.Forms.DataGridView
        Me.DelBtn = New System.Windows.Forms.Button
        Me.AddBtn = New System.Windows.Forms.Button
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel
        Me.TBoxBuscaUsua = New System.Windows.Forms.TextBox
        Me.GpoEmpleados.SuspendLayout()
        CType(Me.DGUsuarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TSOpciones.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DGalmusu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGAlmacen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GpoEmpleados
        '
        Me.GpoEmpleados.Controls.Add(Me.Chkact)
        Me.GpoEmpleados.Controls.Add(Me.Label4)
        Me.GpoEmpleados.Controls.Add(Me.Txtcpass)
        Me.GpoEmpleados.Controls.Add(Me.Label5)
        Me.GpoEmpleados.Controls.Add(Me.Txtpass)
        Me.GpoEmpleados.Controls.Add(Me.Label7)
        Me.GpoEmpleados.Controls.Add(Me.cbCategoria)
        Me.GpoEmpleados.Controls.Add(Me.TxtNombre)
        Me.GpoEmpleados.Controls.Add(Me.Label2)
        Me.GpoEmpleados.Controls.Add(Me.TxtCodigo)
        Me.GpoEmpleados.Controls.Add(Me.Label1)
        Me.GpoEmpleados.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GpoEmpleados.Location = New System.Drawing.Point(12, 53)
        Me.GpoEmpleados.Name = "GpoEmpleados"
        Me.GpoEmpleados.Size = New System.Drawing.Size(250, 197)
        Me.GpoEmpleados.TabIndex = 5
        Me.GpoEmpleados.TabStop = False
        '
        'Chkact
        '
        Me.Chkact.AutoSize = True
        Me.Chkact.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chkact.Location = New System.Drawing.Point(172, 163)
        Me.Chkact.Name = "Chkact"
        Me.Chkact.Size = New System.Drawing.Size(56, 17)
        Me.Chkact.TabIndex = 23
        Me.Chkact.Text = "Activo"
        Me.Chkact.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 109)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 13)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Conf. Password"
        '
        'Txtcpass
        '
        Me.Txtcpass.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtcpass.Location = New System.Drawing.Point(94, 106)
        Me.Txtcpass.Name = "Txtcpass"
        Me.Txtcpass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.Txtcpass.Size = New System.Drawing.Size(133, 20)
        Me.Txtcpass.TabIndex = 21
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(36, 81)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 13)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Password"
        '
        'Txtpass
        '
        Me.Txtpass.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtpass.Location = New System.Drawing.Point(94, 78)
        Me.Txtpass.Name = "Txtpass"
        Me.Txtpass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.Txtpass.Size = New System.Drawing.Size(133, 20)
        Me.Txtpass.TabIndex = 17
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(38, 139)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Categoria"
        '
        'cbCategoria
        '
        Me.cbCategoria.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCategoria.FormattingEnabled = True
        Me.cbCategoria.Location = New System.Drawing.Point(94, 136)
        Me.cbCategoria.Name = "cbCategoria"
        Me.cbCategoria.Size = New System.Drawing.Size(133, 21)
        Me.cbCategoria.TabIndex = 11
        '
        'TxtNombre
        '
        Me.TxtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNombre.Location = New System.Drawing.Point(94, 50)
        Me.TxtNombre.MaxLength = 10
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(133, 20)
        Me.TxtNombre.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(45, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Nombre"
        '
        'TxtCodigo
        '
        Me.TxtCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCodigo.Enabled = False
        Me.TxtCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCodigo.Location = New System.Drawing.Point(94, 24)
        Me.TxtCodigo.Name = "TxtCodigo"
        Me.TxtCodigo.Size = New System.Drawing.Size(133, 20)
        Me.TxtCodigo.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(50, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Codigo"
        '
        'OPFImagen
        '
        Me.OPFImagen.Filter = "Archivos de Imagen |*.jpg"
        '
        'DGUsuarios
        '
        Me.DGUsuarios.AllowUserToAddRows = False
        Me.DGUsuarios.AllowUserToDeleteRows = False
        Me.DGUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader
        Me.DGUsuarios.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGUsuarios.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGUsuarios.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGUsuarios.Location = New System.Drawing.Point(279, 58)
        Me.DGUsuarios.MultiSelect = False
        Me.DGUsuarios.Name = "DGUsuarios"
        Me.DGUsuarios.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGUsuarios.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DGUsuarios.Size = New System.Drawing.Size(215, 192)
        Me.DGUsuarios.TabIndex = 6
        '
        'TSOpciones
        '
        Me.TSOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSBSaveNew, Me.ToolStripSeparator1, Me.ToolStripButton3, Me.ToolStripSeparator2, Me.TSBSalir})
        Me.TSOpciones.Location = New System.Drawing.Point(0, 0)
        Me.TSOpciones.Name = "TSOpciones"
        Me.TSOpciones.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.TSOpciones.Size = New System.Drawing.Size(506, 25)
        Me.TSOpciones.TabIndex = 10
        Me.TSOpciones.Text = "ToolStrip1"
        '
        'TSBSaveNew
        '
        Me.TSBSaveNew.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TSBSaveNew.Image = Global.VisionTec.My.Resources.Resources.save
        Me.TSBSaveNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBSaveNew.Name = "TSBSaveNew"
        Me.TSBSaveNew.Size = New System.Drawing.Size(66, 22)
        Me.TSBSaveNew.Text = "Guardar"
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
        Me.TSBSalir.Image = Global.VisionTec.My.Resources.Resources.delete
        Me.TSBSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBSalir.Name = "TSBSalir"
        Me.TSBSalir.Size = New System.Drawing.Size(48, 22)
        Me.TSBSalir.Text = "Salir"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.lbalmacen2)
        Me.GroupBox1.Controls.Add(Me.lbalmacen)
        Me.GroupBox1.Controls.Add(Me.DGalmusu)
        Me.GroupBox1.Controls.Add(Me.DGAlmacen)
        Me.GroupBox1.Controls.Add(Me.DelBtn)
        Me.GroupBox1.Controls.Add(Me.AddBtn)
        Me.GroupBox1.Controls.Add(Me.LinkLabel1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 256)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(482, 224)
        Me.GroupBox1.TabIndex = 26
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos de Almacen"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(287, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(143, 12)
        Me.Label3.TabIndex = 34
        Me.Label3.Text = "ALMACENES ASIGNADOS"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(89, 36)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 12)
        Me.Label6.TabIndex = 33
        Me.Label6.Text = "ALMACENES"
        '
        'lbalmacen2
        '
        Me.lbalmacen2.AutoSize = True
        Me.lbalmacen2.Location = New System.Drawing.Point(219, 195)
        Me.lbalmacen2.Name = "lbalmacen2"
        Me.lbalmacen2.Size = New System.Drawing.Size(10, 13)
        Me.lbalmacen2.TabIndex = 32
        Me.lbalmacen2.TabStop = True
        Me.lbalmacen2.Text = "."
        '
        'lbalmacen
        '
        Me.lbalmacen.AutoSize = True
        Me.lbalmacen.Location = New System.Drawing.Point(236, 54)
        Me.lbalmacen.Name = "lbalmacen"
        Me.lbalmacen.Size = New System.Drawing.Size(10, 13)
        Me.lbalmacen.TabIndex = 31
        Me.lbalmacen.TabStop = True
        Me.lbalmacen.Text = "."
        '
        'DGalmusu
        '
        Me.DGalmusu.AllowUserToAddRows = False
        Me.DGalmusu.AllowUserToDeleteRows = False
        Me.DGalmusu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader
        Me.DGalmusu.BackgroundColor = System.Drawing.Color.White
        Me.DGalmusu.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.DGalmusu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGalmusu.ColumnHeadersVisible = False
        Me.DGalmusu.Location = New System.Drawing.Point(284, 63)
        Me.DGalmusu.MultiSelect = False
        Me.DGalmusu.Name = "DGalmusu"
        Me.DGalmusu.ReadOnly = True
        Me.DGalmusu.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.DGalmusu.RowHeadersVisible = False
        Me.DGalmusu.Size = New System.Drawing.Size(146, 145)
        Me.DGalmusu.TabIndex = 30
        '
        'DGAlmacen
        '
        Me.DGAlmacen.AllowUserToAddRows = False
        Me.DGAlmacen.AllowUserToDeleteRows = False
        Me.DGAlmacen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader
        Me.DGAlmacen.BackgroundColor = System.Drawing.Color.White
        Me.DGAlmacen.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.DGAlmacen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGAlmacen.ColumnHeadersVisible = False
        Me.DGAlmacen.Location = New System.Drawing.Point(51, 63)
        Me.DGAlmacen.MultiSelect = False
        Me.DGAlmacen.Name = "DGAlmacen"
        Me.DGAlmacen.ReadOnly = True
        Me.DGAlmacen.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.DGAlmacen.RowHeadersVisible = False
        Me.DGAlmacen.Size = New System.Drawing.Size(146, 145)
        Me.DGAlmacen.TabIndex = 29
        '
        'DelBtn
        '
        Me.DelBtn.Image = Global.VisionTec.My.Resources.Resources.back
        Me.DelBtn.Location = New System.Drawing.Point(218, 146)
        Me.DelBtn.Name = "DelBtn"
        Me.DelBtn.Size = New System.Drawing.Size(44, 42)
        Me.DelBtn.TabIndex = 28
        Me.DelBtn.UseVisualStyleBackColor = True
        '
        'AddBtn
        '
        Me.AddBtn.Image = Global.VisionTec.My.Resources.Resources._next
        Me.AddBtn.Location = New System.Drawing.Point(218, 83)
        Me.AddBtn.Name = "AddBtn"
        Me.AddBtn.Size = New System.Drawing.Size(44, 42)
        Me.AddBtn.TabIndex = 27
        Me.AddBtn.UseVisualStyleBackColor = True
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(236, 195)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(10, 13)
        Me.LinkLabel1.TabIndex = 25
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "."
        Me.LinkLabel1.Visible = False
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.LinkLabel2.Location = New System.Drawing.Point(409, 30)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(95, 13)
        Me.LinkLabel2.TabIndex = 41
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "BUSCA USUARIO"
        '
        'TBoxBuscaUsua
        '
        Me.TBoxBuscaUsua.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TBoxBuscaUsua.Location = New System.Drawing.Point(235, 27)
        Me.TBoxBuscaUsua.Name = "TBoxBuscaUsua"
        Me.TBoxBuscaUsua.Size = New System.Drawing.Size(167, 20)
        Me.TBoxBuscaUsua.TabIndex = 40
        '
        'FrmEmpleados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(506, 496)
        Me.Controls.Add(Me.LinkLabel2)
        Me.Controls.Add(Me.TBoxBuscaUsua)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TSOpciones)
        Me.Controls.Add(Me.DGUsuarios)
        Me.Controls.Add(Me.GpoEmpleados)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmEmpleados"
        Me.Text = "Usuarios"
        Me.GpoEmpleados.ResumeLayout(False)
        Me.GpoEmpleados.PerformLayout()
        CType(Me.DGUsuarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TSOpciones.ResumeLayout(False)
        Me.TSOpciones.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DGalmusu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGAlmacen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GpoEmpleados As System.Windows.Forms.GroupBox
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents OPFImagen As System.Windows.Forms.OpenFileDialog
    Friend WithEvents DGUsuarios As System.Windows.Forms.DataGridView
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cbCategoria As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Txtpass As System.Windows.Forms.TextBox
    Friend WithEvents TSOpciones As System.Windows.Forms.ToolStrip
    Friend WithEvents TSBSaveNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TSBSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Txtcpass As System.Windows.Forms.TextBox
    Friend WithEvents Chkact As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents lbalmacen2 As System.Windows.Forms.LinkLabel
    Friend WithEvents lbalmacen As System.Windows.Forms.LinkLabel
    Friend WithEvents DGalmusu As System.Windows.Forms.DataGridView
    Friend WithEvents DGAlmacen As System.Windows.Forms.DataGridView
    Friend WithEvents DelBtn As System.Windows.Forms.Button
    Friend WithEvents AddBtn As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents TBoxBuscaUsua As System.Windows.Forms.TextBox
End Class
