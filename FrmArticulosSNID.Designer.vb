<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmArticulosSNID
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmArticulosSNID))
        Me.Label7 = New System.Windows.Forms.Label
        Me.TxtCosto = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.TXTCANT = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.DGSNASIGNAR = New System.Windows.Forms.DataGridView
        Me.FECHASURT = New System.Windows.Forms.DateTimePicker
        Me.TXTDESCRIPCION = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtID = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.TSOpciones = New System.Windows.Forms.ToolStrip
        Me.TSBSaveNew = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.TSBSalir = New System.Windows.Forms.ToolStripButton
        Me.cbprefolio = New System.Windows.Forms.ComboBox
        Me.DGASIGNADO = New System.Windows.Forms.DataGridView
        Me.LBUSER = New System.Windows.Forms.LinkLabel
        Me.txtdescripcionSN = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.BTNBUSC = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.TxtFolio = New System.Windows.Forms.TextBox
        Me.CBALM = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.TxtFact = New System.Windows.Forms.TextBox
        Me.Chkfact = New System.Windows.Forms.CheckBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.TxtProveedor = New System.Windows.Forms.TextBox
        Me.TxtCantEti = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        CType(Me.DGSNASIGNAR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TSOpciones.SuspendLayout()
        CType(Me.DGASIGNADO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(413, 208)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 17)
        Me.Label7.TabIndex = 74
        Me.Label7.Text = "COSTO"
        '
        'TxtCosto
        '
        Me.TxtCosto.Enabled = False
        Me.TxtCosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCosto.Location = New System.Drawing.Point(472, 204)
        Me.TxtCosto.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtCosto.Name = "TxtCosto"
        Me.TxtCosto.Size = New System.Drawing.Size(105, 20)
        Me.TxtCosto.TabIndex = 73
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(620, 208)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(194, 46)
        Me.Button1.TabIndex = 72
        Me.Button1.Text = "ASIGNAR"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TXTCANT
        '
        Me.TXTCANT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCANT.Location = New System.Drawing.Point(685, 266)
        Me.TXTCANT.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TXTCANT.Name = "TXTCANT"
        Me.TXTCANT.Size = New System.Drawing.Size(105, 23)
        Me.TXTCANT.TabIndex = 57
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(594, 270)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 17)
        Me.Label2.TabIndex = 65
        Me.Label2.Text = "CANTIDAD"
        '
        'DGSNASIGNAR
        '
        Me.DGSNASIGNAR.AllowUserToAddRows = False
        Me.DGSNASIGNAR.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.NullValue = "NA"
        Me.DGSNASIGNAR.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DGSNASIGNAR.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DGSNASIGNAR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGSNASIGNAR.Location = New System.Drawing.Point(45, 94)
        Me.DGSNASIGNAR.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DGSNASIGNAR.Name = "DGSNASIGNAR"
        Me.DGSNASIGNAR.RowHeadersWidth = 20
        Me.DGSNASIGNAR.Size = New System.Drawing.Size(788, 102)
        Me.DGSNASIGNAR.TabIndex = 64
        '
        'FECHASURT
        '
        Me.FECHASURT.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.FECHASURT.Location = New System.Drawing.Point(685, 44)
        Me.FECHASURT.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.FECHASURT.Name = "FECHASURT"
        Me.FECHASURT.Size = New System.Drawing.Size(130, 22)
        Me.FECHASURT.TabIndex = 62
        '
        'TXTDESCRIPCION
        '
        Me.TXTDESCRIPCION.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTDESCRIPCION.Location = New System.Drawing.Point(269, 235)
        Me.TXTDESCRIPCION.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TXTDESCRIPCION.Name = "TXTDESCRIPCION"
        Me.TXTDESCRIPCION.Size = New System.Drawing.Size(308, 23)
        Me.TXTDESCRIPCION.TabIndex = 58
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(55, 240)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(198, 17)
        Me.Label5.TabIndex = 57
        Me.Label5.Text = "DESCRIPCION PRESTASHOP"
        '
        'TxtID
        '
        Me.TxtID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtID.Location = New System.Drawing.Point(269, 203)
        Me.TxtID.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtID.Name = "TxtID"
        Me.TxtID.Size = New System.Drawing.Size(97, 23)
        Me.TxtID.TabIndex = 4
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(237, 208)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(21, 17)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "ID"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label3.Location = New System.Drawing.Point(181, 50)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 17)
        Me.Label3.TabIndex = 61
        Me.Label3.Text = "PREFOLIO"
        '
        'TSOpciones
        '
        Me.TSOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSBSaveNew, Me.ToolStripSeparator2, Me.TSBSalir})
        Me.TSOpciones.Location = New System.Drawing.Point(0, 0)
        Me.TSOpciones.Name = "TSOpciones"
        Me.TSOpciones.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.TSOpciones.Size = New System.Drawing.Size(877, 25)
        Me.TSOpciones.TabIndex = 58
        Me.TSOpciones.Text = "ToolStrip1"
        '
        'TSBSaveNew
        '
        Me.TSBSaveNew.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TSBSaveNew.Image = Global.VisionTec.My.Resources.Resources.save
        Me.TSBSaveNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBSaveNew.Name = "TSBSaveNew"
        Me.TSBSaveNew.Size = New System.Drawing.Size(88, 22)
        Me.TSBSaveNew.Text = "GUARDAR"
        Me.TSBSaveNew.ToolTipText = "Guardar y Nuevo"
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
        'cbprefolio
        '
        Me.cbprefolio.FormattingEnabled = True
        Me.cbprefolio.Location = New System.Drawing.Point(269, 46)
        Me.cbprefolio.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cbprefolio.Name = "cbprefolio"
        Me.cbprefolio.Size = New System.Drawing.Size(175, 24)
        Me.cbprefolio.TabIndex = 55
        '
        'DGASIGNADO
        '
        Me.DGASIGNADO.AllowUserToAddRows = False
        Me.DGASIGNADO.AllowUserToDeleteRows = False
        DataGridViewCellStyle2.NullValue = "NA"
        Me.DGASIGNADO.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.DGASIGNADO.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DGASIGNADO.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.DGASIGNADO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGASIGNADO.ColumnHeadersVisible = False
        Me.DGASIGNADO.Location = New System.Drawing.Point(45, 316)
        Me.DGASIGNADO.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DGASIGNADO.Name = "DGASIGNADO"
        Me.DGASIGNADO.RowHeadersWidth = 20
        Me.DGASIGNADO.Size = New System.Drawing.Size(788, 102)
        Me.DGASIGNADO.TabIndex = 80
        '
        'LBUSER
        '
        Me.LBUSER.AutoSize = True
        Me.LBUSER.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBUSER.Location = New System.Drawing.Point(55, 459)
        Me.LBUSER.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LBUSER.Name = "LBUSER"
        Me.LBUSER.Size = New System.Drawing.Size(12, 17)
        Me.LBUSER.TabIndex = 78
        Me.LBUSER.TabStop = True
        Me.LBUSER.Text = "."
        '
        'txtdescripcionSN
        '
        Me.txtdescripcionSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdescripcionSN.Location = New System.Drawing.Point(269, 266)
        Me.txtdescripcionSN.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtdescripcionSN.Name = "txtdescripcionSN"
        Me.txtdescripcionSN.Size = New System.Drawing.Size(308, 23)
        Me.txtdescripcionSN.TabIndex = 82
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(82, 270)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(170, 17)
        Me.Label1.TabIndex = 81
        Me.Label1.Text = "DESCRIPCION ENTRADA"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(624, 437)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(194, 46)
        Me.Button2.TabIndex = 83
        Me.Button2.Text = "DESHACER ASIGNACION"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'BTNBUSC
        '
        Me.BTNBUSC.Location = New System.Drawing.Point(376, 203)
        Me.BTNBUSC.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BTNBUSC.Name = "BTNBUSC"
        Me.BTNBUSC.Size = New System.Drawing.Size(25, 26)
        Me.BTNBUSC.TabIndex = 84
        Me.BTNBUSC.Text = "?"
        Me.BTNBUSC.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(50, 74)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(95, 17)
        Me.Label4.TabIndex = 85
        Me.Label4.Text = "SIN ASIGNAR"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(50, 297)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 17)
        Me.Label6.TabIndex = 86
        Me.Label6.Text = "ASIGNADOS"
        '
        'TxtFolio
        '
        Me.TxtFolio.Enabled = False
        Me.TxtFolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFolio.Location = New System.Drawing.Point(119, 430)
        Me.TxtFolio.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtFolio.Name = "TxtFolio"
        Me.TxtFolio.Size = New System.Drawing.Size(97, 23)
        Me.TxtFolio.TabIndex = 87
        '
        'CBALM
        '
        Me.CBALM.FormattingEnabled = True
        Me.CBALM.Location = New System.Drawing.Point(296, 428)
        Me.CBALM.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CBALM.Name = "CBALM"
        Me.CBALM.Size = New System.Drawing.Size(175, 24)
        Me.CBALM.TabIndex = 88
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(27, 434)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(81, 17)
        Me.Label8.TabIndex = 89
        Me.Label8.Text = "FOLIO ENT"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(249, 434)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(36, 17)
        Me.Label9.TabIndex = 90
        Me.Label9.Text = "ALM"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(211, 466)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(72, 17)
        Me.Label10.TabIndex = 92
        Me.Label10.Text = "FACTURA"
        '
        'TxtFact
        '
        Me.TxtFact.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFact.Location = New System.Drawing.Point(296, 462)
        Me.TxtFact.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtFact.MaxLength = 20
        Me.TxtFact.Name = "TxtFact"
        Me.TxtFact.Size = New System.Drawing.Size(175, 23)
        Me.TxtFact.TabIndex = 91
        '
        'Chkfact
        '
        Me.Chkfact.AutoSize = True
        Me.Chkfact.Checked = True
        Me.Chkfact.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chkfact.Location = New System.Drawing.Point(480, 466)
        Me.Chkfact.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Chkfact.Name = "Chkfact"
        Me.Chkfact.Size = New System.Drawing.Size(78, 21)
        Me.Chkfact.TabIndex = 93
        Me.Chkfact.Text = "Factura"
        Me.Chkfact.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(188, 498)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(96, 17)
        Me.Label12.TabIndex = 95
        Me.Label12.Text = "PROVEEDOR"
        '
        'TxtProveedor
        '
        Me.TxtProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtProveedor.Location = New System.Drawing.Point(296, 494)
        Me.TxtProveedor.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtProveedor.MaxLength = 20
        Me.TxtProveedor.Name = "TxtProveedor"
        Me.TxtProveedor.Size = New System.Drawing.Size(175, 23)
        Me.TxtProveedor.TabIndex = 94
        '
        'TxtCantEti
        '
        Me.TxtCantEti.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCantEti.Location = New System.Drawing.Point(576, 494)
        Me.TxtCantEti.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtCantEti.Name = "TxtCantEti"
        Me.TxtCantEti.Size = New System.Drawing.Size(39, 23)
        Me.TxtCantEti.TabIndex = 96
        Me.TxtCantEti.Text = "1"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(480, 498)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(86, 17)
        Me.Label13.TabIndex = 97
        Me.Label13.Text = "ETIQUETAS"
        '
        'FrmArticulosSNID
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(877, 526)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.TxtCantEti)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TxtProveedor)
        Me.Controls.Add(Me.Chkfact)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TxtFact)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.CBALM)
        Me.Controls.Add(Me.TxtFolio)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtCosto)
        Me.Controls.Add(Me.BTNBUSC)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.txtdescripcionSN)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TXTDESCRIPCION)
        Me.Controls.Add(Me.DGASIGNADO)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.LBUSER)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TxtID)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.DGSNASIGNAR)
        Me.Controls.Add(Me.TXTCANT)
        Me.Controls.Add(Me.FECHASURT)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TSOpciones)
        Me.Controls.Add(Me.cbprefolio)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "FrmArticulosSNID"
        Me.Text = "ENTRADA A ARTICULOS SIN ID"
        CType(Me.DGSNASIGNAR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TSOpciones.ResumeLayout(False)
        Me.TSOpciones.PerformLayout()
        CType(Me.DGASIGNADO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtCosto As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TXTCANT As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DGSNASIGNAR As System.Windows.Forms.DataGridView
    Friend WithEvents FECHASURT As System.Windows.Forms.DateTimePicker
    Friend WithEvents TxtID As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TSOpciones As System.Windows.Forms.ToolStrip
    Friend WithEvents TSBSaveNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TSBSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents cbprefolio As System.Windows.Forms.ComboBox
    Friend WithEvents TXTDESCRIPCION As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DGASIGNADO As System.Windows.Forms.DataGridView
    Friend WithEvents LBUSER As System.Windows.Forms.LinkLabel
    Friend WithEvents txtdescripcionSN As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents BTNBUSC As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtFolio As System.Windows.Forms.TextBox
    Friend WithEvents CBALM As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxtFact As System.Windows.Forms.TextBox
    Friend WithEvents Chkfact As System.Windows.Forms.CheckBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TxtProveedor As System.Windows.Forms.TextBox
    Friend WithEvents TxtCantEti As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
End Class
