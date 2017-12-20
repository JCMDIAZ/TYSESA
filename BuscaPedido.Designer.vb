<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BuscaPedido
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BuscaPedido))
        Me.TSOpciones = New System.Windows.Forms.ToolStrip
        Me.TSBSaveNew = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.TSBSaveExit = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.TSBSalir = New System.Windows.Forms.ToolStripButton
        Me.Label3 = New System.Windows.Forms.Label
        Me.CBCLIENTE = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.CBALM = New System.Windows.Forms.ComboBox
        Me.Txtpedido = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.DGBP = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.CHCODE = New System.Windows.Forms.CheckBox
        Me.CHPED = New System.Windows.Forms.CheckBox
        Me.CHUSU = New System.Windows.Forms.CheckBox
        Me.CHSUR = New System.Windows.Forms.CheckBox
        Me.CHALM = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.CBUSU = New System.Windows.Forms.ComboBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.DTFECHAA = New System.Windows.Forms.DateTimePicker
        Me.Label8 = New System.Windows.Forms.Label
        Me.DTFECHADE = New System.Windows.Forms.DateTimePicker
        Me.Label7 = New System.Windows.Forms.Label
        Me.DGDP = New System.Windows.Forms.DataGridView
        Me.LblDescripcion = New System.Windows.Forms.Label
        Me.TxtCodigo = New System.Windows.Forms.TextBox
        Me.TXTCODE = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.LBCLIENTE = New System.Windows.Forms.LinkLabel
        Me.LBPED = New System.Windows.Forms.LinkLabel
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.TSOpciones.SuspendLayout()
        CType(Me.DGBP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DGDP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TSOpciones
        '
        Me.TSOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSBSaveNew, Me.ToolStripButton1, Me.TSBSaveExit, Me.ToolStripSeparator2, Me.TSBSalir})
        Me.TSOpciones.Location = New System.Drawing.Point(0, 0)
        Me.TSOpciones.Name = "TSOpciones"
        Me.TSOpciones.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.TSOpciones.Size = New System.Drawing.Size(1165, 25)
        Me.TSOpciones.TabIndex = 6
        Me.TSOpciones.Text = "ToolStrip1"
        '
        'TSBSaveNew
        '
        Me.TSBSaveNew.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TSBSaveNew.Image = Global.VisionTec.My.Resources.Resources.search__2_
        Me.TSBSaveNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBSaveNew.Name = "TSBSaveNew"
        Me.TSBSaveNew.Size = New System.Drawing.Size(77, 22)
        Me.TSBSaveNew.Text = "BUSCAR"
        Me.TSBSaveNew.ToolTipText = "Guardar y Nuevo"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton1.Image = Global.VisionTec.My.Resources.Resources.accept
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(112, 22)
        Me.ToolStripButton1.Text = "SELECCIONAR"
        '
        'TSBSaveExit
        '
        Me.TSBSaveExit.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TSBSaveExit.Image = Global.VisionTec.My.Resources.Resources._1366681746_print
        Me.TSBSaveExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBSaveExit.Name = "TSBSaveExit"
        Me.TSBSaveExit.Size = New System.Drawing.Size(90, 22)
        Me.TSBSaveExit.Text = "IMPRIMIR"
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
        Me.TSBSalir.Size = New System.Drawing.Size(65, 22)
        Me.TSBSalir.Text = "SALIR"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label3.Location = New System.Drawing.Point(292, 60)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 17)
        Me.Label3.TabIndex = 45
        Me.Label3.Text = "CLIENTE"
        '
        'CBCLIENTE
        '
        Me.CBCLIENTE.FormattingEnabled = True
        Me.CBCLIENTE.Location = New System.Drawing.Point(370, 55)
        Me.CBCLIENTE.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CBCLIENTE.Name = "CBCLIENTE"
        Me.CBCLIENTE.Size = New System.Drawing.Size(175, 24)
        Me.CBCLIENTE.TabIndex = 43
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(573, 60)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 17)
        Me.Label5.TabIndex = 52
        Me.Label5.Text = "ALMACEN"
        '
        'CBALM
        '
        Me.CBALM.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBALM.FormattingEnabled = True
        Me.CBALM.Location = New System.Drawing.Point(659, 55)
        Me.CBALM.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CBALM.Name = "CBALM"
        Me.CBALM.Size = New System.Drawing.Size(175, 25)
        Me.CBALM.TabIndex = 49
        '
        'Txtpedido
        '
        Me.Txtpedido.Enabled = False
        Me.Txtpedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtpedido.Location = New System.Drawing.Point(659, 126)
        Me.Txtpedido.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Txtpedido.Name = "Txtpedido"
        Me.Txtpedido.Size = New System.Drawing.Size(105, 23)
        Me.Txtpedido.TabIndex = 50
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(587, 130)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(60, 17)
        Me.Label11.TabIndex = 51
        Me.Label11.Text = "PEDIDO"
        '
        'DGBP
        '
        Me.DGBP.AllowUserToAddRows = False
        Me.DGBP.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.NullValue = "NA"
        Me.DGBP.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DGBP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DGBP.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.DGBP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGBP.ColumnHeadersVisible = False
        Me.DGBP.Location = New System.Drawing.Point(37, 240)
        Me.DGBP.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DGBP.Name = "DGBP"
        Me.DGBP.RowHeadersWidth = 20
        Me.DGBP.Size = New System.Drawing.Size(1079, 74)
        Me.DGBP.TabIndex = 53
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CHCODE)
        Me.GroupBox1.Controls.Add(Me.CHPED)
        Me.GroupBox1.Controls.Add(Me.CHUSU)
        Me.GroupBox1.Controls.Add(Me.CHSUR)
        Me.GroupBox1.Controls.Add(Me.CHALM)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 39)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(235, 178)
        Me.GroupBox1.TabIndex = 54
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "BUSQUEDA"
        '
        'CHCODE
        '
        Me.CHCODE.AutoSize = True
        Me.CHCODE.Location = New System.Drawing.Point(21, 142)
        Me.CHCODE.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CHCODE.Name = "CHCODE"
        Me.CHCODE.Size = New System.Drawing.Size(191, 21)
        Me.CHCODE.TabIndex = 17
        Me.CHCODE.Text = "CODIGO DE PRODUCTO"
        Me.CHCODE.UseVisualStyleBackColor = True
        '
        'CHPED
        '
        Me.CHPED.AutoSize = True
        Me.CHPED.Location = New System.Drawing.Point(21, 85)
        Me.CHPED.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CHPED.Name = "CHPED"
        Me.CHPED.Size = New System.Drawing.Size(82, 21)
        Me.CHPED.TabIndex = 16
        Me.CHPED.Text = "PEDIDO"
        Me.CHPED.UseVisualStyleBackColor = True
        '
        'CHUSU
        '
        Me.CHUSU.AutoSize = True
        Me.CHUSU.Location = New System.Drawing.Point(21, 57)
        Me.CHUSU.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CHUSU.Name = "CHUSU"
        Me.CHUSU.Size = New System.Drawing.Size(92, 21)
        Me.CHUSU.TabIndex = 14
        Me.CHUSU.Text = "USUARIO"
        Me.CHUSU.UseVisualStyleBackColor = True
        '
        'CHSUR
        '
        Me.CHSUR.AutoSize = True
        Me.CHSUR.Location = New System.Drawing.Point(21, 114)
        Me.CHSUR.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CHSUR.Name = "CHSUR"
        Me.CHSUR.Size = New System.Drawing.Size(141, 21)
        Me.CHSUR.TabIndex = 13
        Me.CHSUR.Text = "FECHA SURTIDO"
        Me.CHSUR.UseVisualStyleBackColor = True
        '
        'CHALM
        '
        Me.CHALM.AutoSize = True
        Me.CHALM.Location = New System.Drawing.Point(21, 28)
        Me.CHALM.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CHALM.Name = "CHALM"
        Me.CHALM.Size = New System.Drawing.Size(95, 21)
        Me.CHALM.TabIndex = 12
        Me.CHALM.Text = "ALMACEN"
        Me.CHALM.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label1.Location = New System.Drawing.Point(576, 96)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 17)
        Me.Label1.TabIndex = 56
        Me.Label1.Text = "USUARIO"
        '
        'CBUSU
        '
        Me.CBUSU.FormattingEnabled = True
        Me.CBUSU.Location = New System.Drawing.Point(659, 91)
        Me.CBUSU.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CBUSU.Name = "CBUSU"
        Me.CBUSU.Size = New System.Drawing.Size(175, 24)
        Me.CBUSU.TabIndex = 55
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.DTFECHAA)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.DTFECHADE)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Location = New System.Drawing.Point(275, 96)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(270, 121)
        Me.GroupBox2.TabIndex = 57
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "FECHA"
        '
        'DTFECHAA
        '
        Me.DTFECHAA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTFECHAA.Location = New System.Drawing.Point(94, 69)
        Me.DTFECHAA.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DTFECHAA.Name = "DTFECHAA"
        Me.DTFECHAA.Size = New System.Drawing.Size(119, 22)
        Me.DTFECHAA.TabIndex = 24
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(48, 70)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(15, 15)
        Me.Label8.TabIndex = 26
        Me.Label8.Text = "A"
        '
        'DTFECHADE
        '
        Me.DTFECHADE.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTFECHADE.Location = New System.Drawing.Point(94, 30)
        Me.DTFECHADE.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DTFECHADE.Name = "DTFECHADE"
        Me.DTFECHADE.Size = New System.Drawing.Size(119, 22)
        Me.DTFECHADE.TabIndex = 23
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(39, 36)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(26, 15)
        Me.Label7.TabIndex = 25
        Me.Label7.Text = "DE"
        '
        'DGDP
        '
        Me.DGDP.AllowUserToAddRows = False
        Me.DGDP.AllowUserToDeleteRows = False
        DataGridViewCellStyle2.NullValue = "NA"
        Me.DGDP.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.DGDP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DGDP.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.DGDP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGDP.ColumnHeadersVisible = False
        Me.DGDP.Location = New System.Drawing.Point(37, 374)
        Me.DGDP.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DGDP.Name = "DGDP"
        Me.DGDP.RowHeadersWidth = 20
        Me.DGDP.Size = New System.Drawing.Size(1079, 139)
        Me.DGDP.TabIndex = 58
        '
        'LblDescripcion
        '
        Me.LblDescripcion.AutoSize = True
        Me.LblDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDescripcion.ForeColor = System.Drawing.Color.Blue
        Me.LblDescripcion.Location = New System.Drawing.Point(574, 202)
        Me.LblDescripcion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDescripcion.Name = "LblDescripcion"
        Me.LblDescripcion.Size = New System.Drawing.Size(11, 15)
        Me.LblDescripcion.TabIndex = 61
        Me.LblDescripcion.Text = "."
        '
        'TxtCodigo
        '
        Me.TxtCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCodigo.Location = New System.Drawing.Point(659, 160)
        Me.TxtCodigo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtCodigo.Name = "TxtCodigo"
        Me.TxtCodigo.Size = New System.Drawing.Size(167, 23)
        Me.TxtCodigo.TabIndex = 59
        '
        'TXTCODE
        '
        Me.TXTCODE.AutoSize = True
        Me.TXTCODE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCODE.Location = New System.Drawing.Point(583, 164)
        Me.TXTCODE.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.TXTCODE.Name = "TXTCODE"
        Me.TXTCODE.Size = New System.Drawing.Size(63, 17)
        Me.TXTCODE.TabIndex = 60
        Me.TXTCODE.Text = "CODIGO"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(40, 226)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 62
        Me.Label2.Text = "PEDIDOS"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(39, 359)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 63
        Me.Label4.Text = "DETALLE"
        '
        'LBCLIENTE
        '
        Me.LBCLIENTE.AutoSize = True
        Me.LBCLIENTE.Location = New System.Drawing.Point(61, 330)
        Me.LBCLIENTE.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LBCLIENTE.Name = "LBCLIENTE"
        Me.LBCLIENTE.Size = New System.Drawing.Size(12, 17)
        Me.LBCLIENTE.TabIndex = 64
        Me.LBCLIENTE.TabStop = True
        Me.LBCLIENTE.Text = "."
        Me.LBCLIENTE.Visible = False
        '
        'LBPED
        '
        Me.LBPED.AutoSize = True
        Me.LBPED.Location = New System.Drawing.Point(292, 330)
        Me.LBPED.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LBPED.Name = "LBPED"
        Me.LBPED.Size = New System.Drawing.Size(12, 17)
        Me.LBPED.TabIndex = 65
        Me.LBPED.TabStop = True
        Me.LBPED.Text = "."
        Me.LBPED.Visible = False
        '
        'ComboBox1
        '
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(659, 330)
        Me.ComboBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(175, 25)
        Me.ComboBox1.TabIndex = 66
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(583, 334)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 17)
        Me.Label6.TabIndex = 67
        Me.Label6.Text = "ESTADO"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(864, 324)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(147, 34)
        Me.Button1.TabIndex = 68
        Me.Button1.Text = "Guardar Estado"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'BuscaPedido
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1165, 546)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.LBPED)
        Me.Controls.Add(Me.LBCLIENTE)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LblDescripcion)
        Me.Controls.Add(Me.TxtCodigo)
        Me.Controls.Add(Me.TXTCODE)
        Me.Controls.Add(Me.DGDP)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CBUSU)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DGBP)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.CBALM)
        Me.Controls.Add(Me.Txtpedido)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CBCLIENTE)
        Me.Controls.Add(Me.TSOpciones)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "BuscaPedido"
        Me.Text = "Buscar Pedido"
        Me.TSOpciones.ResumeLayout(False)
        Me.TSOpciones.PerformLayout()
        CType(Me.DGBP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.DGDP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TSOpciones As System.Windows.Forms.ToolStrip
    Friend WithEvents TSBSaveNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBSaveExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TSBSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CBCLIENTE As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CBALM As System.Windows.Forms.ComboBox
    Friend WithEvents Txtpedido As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents DGBP As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CHPED As System.Windows.Forms.CheckBox
    Friend WithEvents CHUSU As System.Windows.Forms.CheckBox
    Friend WithEvents CHSUR As System.Windows.Forms.CheckBox
    Friend WithEvents CHALM As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CBUSU As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents DTFECHAA As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents DTFECHADE As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents DGDP As System.Windows.Forms.DataGridView
    Friend WithEvents CHCODE As System.Windows.Forms.CheckBox
    Friend WithEvents LblDescripcion As System.Windows.Forms.Label
    Friend WithEvents TxtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents TXTCODE As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents LBCLIENTE As System.Windows.Forms.LinkLabel
    Friend WithEvents LBPED As System.Windows.Forms.LinkLabel
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
