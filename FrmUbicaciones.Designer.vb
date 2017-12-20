<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmUbicaciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmUbicaciones))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.TXTNOMBRE = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TXTZONA = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.TXTUBI = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TSOpciones = New System.Windows.Forms.ToolStrip
        Me.TSBSaveNew = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.TSBSalir = New System.Windows.Forms.ToolStripButton
        Me.DGUBI = New System.Windows.Forms.DataGridView
        Me.cbalm = New System.Windows.Forms.ComboBox
        Me.lbalmacen = New System.Windows.Forms.Label
        Me.CHKSTATUS = New System.Windows.Forms.CheckBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.TxtOff = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.TxtAltura = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.TxtArea = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel
        Me.TBoxBuscaUBI = New System.Windows.Forms.TextBox
        Me.GroupBox2.SuspendLayout()
        Me.TSOpciones.SuspendLayout()
        CType(Me.DGUBI, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TXTNOMBRE)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.TXTZONA)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.TXTUBI)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Location = New System.Drawing.Point(10, 68)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(293, 97)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Detalle"
        '
        'TXTNOMBRE
        '
        Me.TXTNOMBRE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTNOMBRE.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTNOMBRE.Location = New System.Drawing.Point(132, 18)
        Me.TXTNOMBRE.Name = "TXTNOMBRE"
        Me.TXTNOMBRE.Size = New System.Drawing.Size(110, 18)
        Me.TXTNOMBRE.TabIndex = 18
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(82, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 12)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "ZONA"
        '
        'TXTZONA
        '
        Me.TXTZONA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTZONA.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTZONA.Location = New System.Drawing.Point(132, 63)
        Me.TXTZONA.Name = "TXTZONA"
        Me.TXTZONA.Size = New System.Drawing.Size(110, 18)
        Me.TXTZONA.TabIndex = 4
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(66, 21)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 12)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "NOMBRE"
        '
        'TXTUBI
        '
        Me.TXTUBI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTUBI.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTUBI.Location = New System.Drawing.Point(132, 40)
        Me.TXTUBI.Name = "TXTUBI"
        Me.TXTUBI.Size = New System.Drawing.Size(110, 18)
        Me.TXTUBI.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(34, 43)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(85, 12)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "ABREVIATURA"
        '
        'TSOpciones
        '
        Me.TSOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSBSaveNew, Me.ToolStripSeparator4, Me.ToolStripButton1, Me.ToolStripSeparator1, Me.ToolStripButton3, Me.ToolStripSeparator2, Me.TSBSalir})
        Me.TSOpciones.Location = New System.Drawing.Point(0, 0)
        Me.TSOpciones.Name = "TSOpciones"
        Me.TSOpciones.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.TSOpciones.Size = New System.Drawing.Size(646, 25)
        Me.TSOpciones.TabIndex = 13
        Me.TSOpciones.Text = "ToolStrip1"
        '
        'TSBSaveNew
        '
        Me.TSBSaveNew.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TSBSaveNew.Image = Global.VisionTec.My.Resources.Resources.save
        Me.TSBSaveNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBSaveNew.Name = "TSBSaveNew"
        Me.TSBSaveNew.Size = New System.Drawing.Size(109, 22)
        Me.TSBSaveNew.Text = "Guardar y Nuevo"
        Me.TSBSaveNew.ToolTipText = "Guardar y Nuevo"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton1.Image = Global.VisionTec.My.Resources.Resources._1366681757_print
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(129, 22)
        Me.ToolStripButton1.Text = "Imprime Ubicaciones"
        Me.ToolStripButton1.ToolTipText = "Guardar y Nuevo"
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
        Me.ToolStripButton3.ToolTipText = "Limpia para Capturar Nuevo Producto"
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
        'DGUBI
        '
        Me.DGUBI.AllowUserToAddRows = False
        Me.DGUBI.AllowUserToDeleteRows = False
        Me.DGUBI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGUBI.Location = New System.Drawing.Point(12, 203)
        Me.DGUBI.MultiSelect = False
        Me.DGUBI.Name = "DGUBI"
        Me.DGUBI.ReadOnly = True
        Me.DGUBI.RowTemplate.Height = 24
        Me.DGUBI.Size = New System.Drawing.Size(622, 206)
        Me.DGUBI.TabIndex = 15
        '
        'cbalm
        '
        Me.cbalm.FormattingEnabled = True
        Me.cbalm.Location = New System.Drawing.Point(245, 41)
        Me.cbalm.Name = "cbalm"
        Me.cbalm.Size = New System.Drawing.Size(134, 21)
        Me.cbalm.TabIndex = 82
        '
        'lbalmacen
        '
        Me.lbalmacen.AutoSize = True
        Me.lbalmacen.Location = New System.Drawing.Point(183, 44)
        Me.lbalmacen.Name = "lbalmacen"
        Me.lbalmacen.Size = New System.Drawing.Size(58, 13)
        Me.lbalmacen.TabIndex = 81
        Me.lbalmacen.Text = "ALMACEN"
        '
        'CHKSTATUS
        '
        Me.CHKSTATUS.AutoSize = True
        Me.CHKSTATUS.Location = New System.Drawing.Point(398, 43)
        Me.CHKSTATUS.Name = "CHKSTATUS"
        Me.CHKSTATUS.Size = New System.Drawing.Size(76, 17)
        Me.CHKSTATUS.TabIndex = 83
        Me.CHKSTATUS.Text = "ESTATUS"
        Me.CHKSTATUS.UseVisualStyleBackColor = True
        Me.CHKSTATUS.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.TxtOff)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.TxtAltura)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.TxtArea)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Location = New System.Drawing.Point(319, 68)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(315, 97)
        Me.GroupBox1.TabIndex = 84
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Capacidad"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(223, 70)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(24, 12)
        Me.Label12.TabIndex = 18
        Me.Label12.Text = "mts"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(54, 70)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(47, 12)
        Me.Label13.TabIndex = 17
        Me.Label13.Text = "OFFSET"
        '
        'TxtOff
        '
        Me.TxtOff.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtOff.Location = New System.Drawing.Point(105, 67)
        Me.TxtOff.MaxLength = 15
        Me.TxtOff.Name = "TxtOff"
        Me.TxtOff.Size = New System.Drawing.Size(112, 18)
        Me.TxtOff.TabIndex = 16
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(223, 46)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(24, 12)
        Me.Label14.TabIndex = 15
        Me.Label14.Text = "mts"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(223, 21)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(30, 12)
        Me.Label15.TabIndex = 14
        Me.Label15.Text = "mts2"
        '
        'TxtAltura
        '
        Me.TxtAltura.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAltura.Location = New System.Drawing.Point(105, 43)
        Me.TxtAltura.MaxLength = 15
        Me.TxtAltura.Name = "TxtAltura"
        Me.TxtAltura.Size = New System.Drawing.Size(112, 18)
        Me.TxtAltura.TabIndex = 12
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(52, 46)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(49, 12)
        Me.Label16.TabIndex = 13
        Me.Label16.Text = "ALTURA"
        '
        'TxtArea
        '
        Me.TxtArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtArea.Location = New System.Drawing.Point(105, 19)
        Me.TxtArea.MaxLength = 15
        Me.TxtArea.Name = "TxtArea"
        Me.TxtArea.Size = New System.Drawing.Size(112, 18)
        Me.TxtArea.TabIndex = 10
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(64, 22)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(36, 12)
        Me.Label17.TabIndex = 11
        Me.Label17.Text = "AREA"
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.LinkLabel2.Location = New System.Drawing.Point(193, 180)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(104, 13)
        Me.LinkLabel2.TabIndex = 117
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "BUSCA UBICACION"
        '
        'TBoxBuscaUBI
        '
        Me.TBoxBuscaUBI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TBoxBuscaUBI.Location = New System.Drawing.Point(12, 177)
        Me.TBoxBuscaUBI.Name = "TBoxBuscaUBI"
        Me.TBoxBuscaUBI.Size = New System.Drawing.Size(167, 20)
        Me.TBoxBuscaUBI.TabIndex = 116
        '
        'FrmUbicaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(646, 431)
        Me.Controls.Add(Me.LinkLabel2)
        Me.Controls.Add(Me.TBoxBuscaUBI)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.CHKSTATUS)
        Me.Controls.Add(Me.cbalm)
        Me.Controls.Add(Me.lbalmacen)
        Me.Controls.Add(Me.DGUBI)
        Me.Controls.Add(Me.TSOpciones)
        Me.Controls.Add(Me.GroupBox2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmUbicaciones"
        Me.Text = "UBICACIONES"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TSOpciones.ResumeLayout(False)
        Me.TSOpciones.PerformLayout()
        CType(Me.DGUBI, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TXTZONA As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TXTUBI As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TSOpciones As System.Windows.Forms.ToolStrip
    Friend WithEvents TSBSaveNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TSBSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents DGUBI As System.Windows.Forms.DataGridView
    Friend WithEvents cbalm As System.Windows.Forms.ComboBox
    Friend WithEvents lbalmacen As System.Windows.Forms.Label
    Friend WithEvents CHKSTATUS As System.Windows.Forms.CheckBox
    Friend WithEvents TXTNOMBRE As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TxtOff As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TxtAltura As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TxtArea As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents TBoxBuscaUBI As System.Windows.Forms.TextBox
End Class
