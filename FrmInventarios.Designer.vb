<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInventarios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmInventarios))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.LblUbiAct = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.CBUBI = New System.Windows.Forms.ComboBox
        Me.LblCanAlm = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Txtubi = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtCodigo = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtCantidad = New System.Windows.Forms.TextBox
        Me.LBUM = New System.Windows.Forms.Label
        Me.DTIME1 = New System.Windows.Forms.DateTimePicker
        Me.LblDescripcion = New System.Windows.Forms.Label
        Me.LBCLIENTE = New System.Windows.Forms.Label
        Me.CBALMI = New System.Windows.Forms.ComboBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.DGINV = New System.Windows.Forms.DataGridView
        Me.TSOpciones = New System.Windows.Forms.ToolStrip
        Me.TSBSaveNew = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.TSBSaveExit = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.TSBSalir = New System.Windows.Forms.ToolStripButton
        Me.Label5 = New System.Windows.Forms.Label
        Me.LBFAM = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Txtprev = New System.Windows.Forms.TextBox
        Me.lbcosto = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.LBUSER = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Txtcosto = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel
        Me.TBoxBuscaUBI = New System.Windows.Forms.TextBox
        Me.GroupBox1.SuspendLayout()
        CType(Me.DGINV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TSOpciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LblUbiAct)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.CBUBI)
        Me.GroupBox1.Controls.Add(Me.LblCanAlm)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Txtubi)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TxtCodigo)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.TxtCantidad)
        Me.GroupBox1.Controls.Add(Me.LBUM)
        Me.GroupBox1.Controls.Add(Me.DTIME1)
        Me.GroupBox1.Controls.Add(Me.LblDescripcion)
        Me.GroupBox1.Location = New System.Drawing.Point(21, 53)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(518, 125)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'LblUbiAct
        '
        Me.LblUbiAct.AutoSize = True
        Me.LblUbiAct.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblUbiAct.ForeColor = System.Drawing.Color.Blue
        Me.LblUbiAct.Location = New System.Drawing.Point(266, 44)
        Me.LblUbiAct.Name = "LblUbiAct"
        Me.LblUbiAct.Size = New System.Drawing.Size(9, 12)
        Me.LblUbiAct.TabIndex = 117
        Me.LblUbiAct.Text = "."
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(322, 15)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(38, 12)
        Me.Label11.TabIndex = 116
        Me.Label11.Text = "FECHA"
        Me.Label11.Visible = False
        '
        'CBUBI
        '
        Me.CBUBI.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CBUBI.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CBUBI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBUBI.FormattingEnabled = True
        Me.CBUBI.Location = New System.Drawing.Point(132, 40)
        Me.CBUBI.Name = "CBUBI"
        Me.CBUBI.Size = New System.Drawing.Size(126, 21)
        Me.CBUBI.TabIndex = 115
        '
        'LblCanAlm
        '
        Me.LblCanAlm.AutoSize = True
        Me.LblCanAlm.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCanAlm.Location = New System.Drawing.Point(135, 101)
        Me.LblCanAlm.Name = "LblCanAlm"
        Me.LblCanAlm.Size = New System.Drawing.Size(0, 12)
        Me.LblCanAlm.TabIndex = 114
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(71, 71)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(58, 12)
        Me.Label10.TabIndex = 39
        Me.Label10.Text = "CANTIDAD:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(245, 71)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(30, 12)
        Me.Label9.TabIndex = 38
        Me.Label9.Text = "PZAS"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(31, 101)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(98, 12)
        Me.Label8.TabIndex = 37
        Me.Label8.Text = "CANTIDAD MAXIMA"
        '
        'Txtubi
        '
        Me.Txtubi.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtubi.Location = New System.Drawing.Point(324, 65)
        Me.Txtubi.Name = "Txtubi"
        Me.Txtubi.Size = New System.Drawing.Size(168, 20)
        Me.Txtubi.TabIndex = 34
        Me.Txtubi.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 12)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "DIRECCION UBICACION"
        '
        'TxtCodigo
        '
        Me.TxtCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCodigo.Location = New System.Drawing.Point(132, 15)
        Me.TxtCodigo.Name = "TxtCodigo"
        Me.TxtCodigo.Size = New System.Drawing.Size(126, 18)
        Me.TxtCodigo.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(86, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 12)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "CODIGO"
        '
        'TxtCantidad
        '
        Me.TxtCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TxtCantidad.Location = New System.Drawing.Point(132, 67)
        Me.TxtCantidad.Name = "TxtCantidad"
        Me.TxtCantidad.Size = New System.Drawing.Size(93, 20)
        Me.TxtCantidad.TabIndex = 15
        '
        'LBUM
        '
        Me.LBUM.AutoSize = True
        Me.LBUM.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBUM.ForeColor = System.Drawing.Color.Blue
        Me.LBUM.Location = New System.Drawing.Point(266, 18)
        Me.LBUM.Name = "LBUM"
        Me.LBUM.Size = New System.Drawing.Size(9, 12)
        Me.LBUM.TabIndex = 16
        Me.LBUM.Text = "."
        '
        'DTIME1
        '
        Me.DTIME1.Enabled = False
        Me.DTIME1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTIME1.Location = New System.Drawing.Point(324, 31)
        Me.DTIME1.Name = "DTIME1"
        Me.DTIME1.Size = New System.Drawing.Size(90, 20)
        Me.DTIME1.TabIndex = 10
        Me.DTIME1.Visible = False
        '
        'LblDescripcion
        '
        Me.LblDescripcion.AutoSize = True
        Me.LblDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDescripcion.ForeColor = System.Drawing.Color.Blue
        Me.LblDescripcion.Location = New System.Drawing.Point(182, 101)
        Me.LblDescripcion.Name = "LblDescripcion"
        Me.LblDescripcion.Size = New System.Drawing.Size(9, 12)
        Me.LblDescripcion.TabIndex = 13
        Me.LblDescripcion.Text = "."
        '
        'LBCLIENTE
        '
        Me.LBCLIENTE.AutoSize = True
        Me.LBCLIENTE.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBCLIENTE.Location = New System.Drawing.Point(40, 36)
        Me.LBCLIENTE.Name = "LBCLIENTE"
        Me.LBCLIENTE.Size = New System.Drawing.Size(112, 12)
        Me.LBCLIENTE.TabIndex = 33
        Me.LBCLIENTE.Text = "ALMACEN DE SURTIDO"
        '
        'CBALMI
        '
        Me.CBALMI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBALMI.FormattingEnabled = True
        Me.CBALMI.Location = New System.Drawing.Point(156, 32)
        Me.CBALMI.Name = "CBALMI"
        Me.CBALMI.Size = New System.Drawing.Size(126, 21)
        Me.CBALMI.TabIndex = 32
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(52, 311)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(126, 20)
        Me.TextBox1.TabIndex = 36
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(582, 301)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "FECHA"
        Me.Label2.Visible = False
        '
        'DGINV
        '
        Me.DGINV.AllowUserToAddRows = False
        Me.DGINV.AllowUserToDeleteRows = False
        Me.DGINV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGINV.Location = New System.Drawing.Point(21, 217)
        Me.DGINV.MultiSelect = False
        Me.DGINV.Name = "DGINV"
        Me.DGINV.ReadOnly = True
        Me.DGINV.RowTemplate.Height = 28
        Me.DGINV.Size = New System.Drawing.Size(518, 188)
        Me.DGINV.TabIndex = 1
        '
        'TSOpciones
        '
        Me.TSOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSBSaveNew, Me.ToolStripSeparator4, Me.ToolStripButton3, Me.ToolStripSeparator1, Me.TSBSaveExit, Me.ToolStripSeparator2, Me.TSBSalir})
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
        Me.TSBSaveNew.Image = Global.VisionTec.My.Resources.Resources.save
        Me.TSBSaveNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBSaveNew.Name = "TSBSaveNew"
        Me.TSBSaveNew.Size = New System.Drawing.Size(66, 22)
        Me.TSBSaveNew.Text = "Guardar"
        Me.TSBSaveNew.ToolTipText = "Guardar y Nuevo"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton3.Image = Global.VisionTec.My.Resources.Resources._1366681822_edit_clear
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(72, 22)
        Me.ToolStripButton3.Text = "LIMPIAR"
        Me.ToolStripButton3.ToolTipText = "Limpia para Capturar Nuevo Producto"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'TSBSaveExit
        '
        Me.TSBSaveExit.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TSBSaveExit.Image = Global.VisionTec.My.Resources.Resources.remove_from_database1
        Me.TSBSaveExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBSaveExit.Name = "TSBSaveExit"
        Me.TSBSaveExit.Size = New System.Drawing.Size(59, 22)
        Me.TSBSaveExit.Text = "Borrar"
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
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(50, 296)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 12)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "CANTIDAD"
        '
        'LBFAM
        '
        Me.LBFAM.AutoSize = True
        Me.LBFAM.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBFAM.ForeColor = System.Drawing.Color.Blue
        Me.LBFAM.Location = New System.Drawing.Point(343, 320)
        Me.LBFAM.Name = "LBFAM"
        Me.LBFAM.Size = New System.Drawing.Size(9, 12)
        Me.LBFAM.TabIndex = 17
        Me.LBFAM.Text = "."
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(226, 296)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 12)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "CANT PREVIA"
        '
        'Txtprev
        '
        Me.Txtprev.AcceptsReturn = True
        Me.Txtprev.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtprev.Location = New System.Drawing.Point(314, 293)
        Me.Txtprev.Name = "Txtprev"
        Me.Txtprev.Size = New System.Drawing.Size(74, 18)
        Me.Txtprev.TabIndex = 20
        '
        'lbcosto
        '
        Me.lbcosto.AutoSize = True
        Me.lbcosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbcosto.ForeColor = System.Drawing.Color.Blue
        Me.lbcosto.Location = New System.Drawing.Point(690, 359)
        Me.lbcosto.Name = "lbcosto"
        Me.lbcosto.Size = New System.Drawing.Size(9, 12)
        Me.lbcosto.TabIndex = 21
        Me.lbcosto.Text = "."
        Me.lbcosto.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(602, 359)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 12)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "COSTO INV"
        Me.Label7.Visible = False
        '
        'LBUSER
        '
        Me.LBUSER.AutoSize = True
        Me.LBUSER.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBUSER.ForeColor = System.Drawing.Color.Blue
        Me.LBUSER.Location = New System.Drawing.Point(34, 406)
        Me.LBUSER.Name = "LBUSER"
        Me.LBUSER.Size = New System.Drawing.Size(9, 12)
        Me.LBUSER.TabIndex = 23
        Me.LBUSER.Text = "."
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(402, 262)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(56, 23)
        Me.Button1.TabIndex = 111
        Me.Button1.Text = "Buscar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Txtcosto
        '
        Me.Txtcosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtcosto.Location = New System.Drawing.Point(314, 264)
        Me.Txtcosto.Name = "Txtcosto"
        Me.Txtcosto.Size = New System.Drawing.Size(74, 18)
        Me.Txtcosto.TabIndex = 112
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(266, 267)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 12)
        Me.Label4.TabIndex = 113
        Me.Label4.Text = "COSTO"
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.LinkLabel2.Location = New System.Drawing.Point(202, 192)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(149, 13)
        Me.LinkLabel2.TabIndex = 115
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Busca Producto en Ubicacion"
        '
        'TBoxBuscaUBI
        '
        Me.TBoxBuscaUBI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TBoxBuscaUBI.Location = New System.Drawing.Point(21, 189)
        Me.TBoxBuscaUBI.Name = "TBoxBuscaUBI"
        Me.TBoxBuscaUBI.Size = New System.Drawing.Size(167, 20)
        Me.TBoxBuscaUBI.TabIndex = 114
        '
        'FrmInventarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(575, 434)
        Me.Controls.Add(Me.LinkLabel2)
        Me.Controls.Add(Me.TBoxBuscaUBI)
        Me.Controls.Add(Me.LBUSER)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lbcosto)
        Me.Controls.Add(Me.TSOpciones)
        Me.Controls.Add(Me.DGINV)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.LBCLIENTE)
        Me.Controls.Add(Me.CBALMI)
        Me.Controls.Add(Me.Txtcosto)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Txtprev)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.LBFAM)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmInventarios"
        Me.Text = "Inventarios de Ubicaciones"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DGINV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TSOpciones.ResumeLayout(False)
        Me.TSOpciones.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DGINV As System.Windows.Forms.DataGridView
    Friend WithEvents TSOpciones As System.Windows.Forms.ToolStrip
    Friend WithEvents TSBSaveNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBSaveExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TSBSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents DTIME1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents LBCLIENTE As System.Windows.Forms.Label
    Friend WithEvents CBALMI As System.Windows.Forms.ComboBox
    Friend WithEvents TxtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents LblDescripcion As System.Windows.Forms.Label
    Friend WithEvents TxtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Txtubi As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LBUM As System.Windows.Forms.Label
    Friend WithEvents LBFAM As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Txtprev As System.Windows.Forms.TextBox
    Friend WithEvents lbcosto As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents LBUSER As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Txtcosto As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents LblCanAlm As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents CBUBI As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents TBoxBuscaUBI As System.Windows.Forms.TextBox
    Friend WithEvents LblUbiAct As System.Windows.Forms.Label
End Class
