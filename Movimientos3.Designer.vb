<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RP
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RP))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Cbalm = New System.Windows.Forms.ComboBox
        Me.CHPROV = New System.Windows.Forms.CheckBox
        Me.CBPROVE = New System.Windows.Forms.ComboBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.DTFECHAA = New System.Windows.Forms.DateTimePicker
        Me.Label8 = New System.Windows.Forms.Label
        Me.DTFECHADE = New System.Windows.Forms.DateTimePicker
        Me.Label7 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.CHPROD = New System.Windows.Forms.CheckBox
        Me.CHGLOBAL = New System.Windows.Forms.CheckBox
        Me.CHKFAMP = New System.Windows.Forms.CheckBox
        Me.CHKFOL = New System.Windows.Forms.CheckBox
        Me.CHKCLI = New System.Windows.Forms.CheckBox
        Me.CHFAM = New System.Windows.Forms.CheckBox
        Me.CHFAC = New System.Windows.Forms.CheckBox
        Me.TSOpciones = New System.Windows.Forms.ToolStrip
        Me.TSBSaveExit = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.TSBSalir = New System.Windows.Forms.ToolStripButton
        Me.Label2 = New System.Windows.Forms.Label
        Me.LBCLIENTE = New System.Windows.Forms.Label
        Me.CBCLIENTE = New System.Windows.Forms.ComboBox
        Me.CBMOVI = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TXTCODIGO = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.LBLDESCRIPCION = New System.Windows.Forms.LinkLabel
        Me.CbFAM = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TSOpciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(213, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 12)
        Me.Label1.TabIndex = 154
        Me.Label1.Text = "ALMACEN"
        '
        'Cbalm
        '
        Me.Cbalm.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cbalm.FormattingEnabled = True
        Me.Cbalm.Location = New System.Drawing.Point(297, 49)
        Me.Cbalm.Name = "Cbalm"
        Me.Cbalm.Size = New System.Drawing.Size(126, 20)
        Me.Cbalm.TabIndex = 153
        '
        'CHPROV
        '
        Me.CHPROV.AutoSize = True
        Me.CHPROV.Location = New System.Drawing.Point(16, 37)
        Me.CHPROV.Name = "CHPROV"
        Me.CHPROV.Size = New System.Drawing.Size(85, 17)
        Me.CHPROV.TabIndex = 133
        Me.CHPROV.Text = "ENTRADAS"
        Me.CHPROV.UseVisualStyleBackColor = True
        '
        'CBPROVE
        '
        Me.CBPROVE.FormattingEnabled = True
        Me.CBPROVE.Location = New System.Drawing.Point(297, 167)
        Me.CBPROVE.Name = "CBPROVE"
        Me.CBPROVE.Size = New System.Drawing.Size(126, 21)
        Me.CBPROVE.TabIndex = 142
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.DTFECHAA)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.DTFECHADE)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Location = New System.Drawing.Point(190, 75)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(291, 47)
        Me.GroupBox2.TabIndex = 139
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "FECHA"
        '
        'DTFECHAA
        '
        Me.DTFECHAA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTFECHAA.Location = New System.Drawing.Point(173, 18)
        Me.DTFECHAA.Name = "DTFECHAA"
        Me.DTFECHAA.Size = New System.Drawing.Size(90, 20)
        Me.DTFECHAA.TabIndex = 24
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(154, 21)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(13, 12)
        Me.Label8.TabIndex = 26
        Me.Label8.Text = "A"
        '
        'DTFECHADE
        '
        Me.DTFECHADE.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTFECHADE.Location = New System.Drawing.Point(58, 18)
        Me.DTFECHADE.Name = "DTFECHADE"
        Me.DTFECHADE.Size = New System.Drawing.Size(90, 20)
        Me.DTFECHADE.TabIndex = 23
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(32, 21)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(20, 12)
        Me.Label7.TabIndex = 25
        Me.Label7.Text = "DE"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CheckBox1)
        Me.GroupBox1.Controls.Add(Me.CHPROD)
        Me.GroupBox1.Controls.Add(Me.CHGLOBAL)
        Me.GroupBox1.Controls.Add(Me.CHKFAMP)
        Me.GroupBox1.Controls.Add(Me.CHKFOL)
        Me.GroupBox1.Controls.Add(Me.CHKCLI)
        Me.GroupBox1.Controls.Add(Me.CHFAM)
        Me.GroupBox1.Controls.Add(Me.CHFAC)
        Me.GroupBox1.Controls.Add(Me.CHPROV)
        Me.GroupBox1.Location = New System.Drawing.Point(22, 37)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(151, 267)
        Me.GroupBox1.TabIndex = 135
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "BUSQUEDA"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(16, 180)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(74, 17)
        Me.CheckBox1.TabIndex = 139
        Me.CheckBox1.Text = "ENT -SAL"
        Me.CheckBox1.UseVisualStyleBackColor = True
        Me.CheckBox1.Visible = False
        '
        'CHPROD
        '
        Me.CHPROD.AutoSize = True
        Me.CHPROD.Location = New System.Drawing.Point(16, 133)
        Me.CHPROD.Name = "CHPROD"
        Me.CHPROD.Size = New System.Drawing.Size(87, 17)
        Me.CHPROD.TabIndex = 138
        Me.CHPROD.Text = "PRODUCTO"
        Me.CHPROD.UseVisualStyleBackColor = True
        '
        'CHGLOBAL
        '
        Me.CHGLOBAL.AutoSize = True
        Me.CHGLOBAL.Location = New System.Drawing.Point(16, 158)
        Me.CHGLOBAL.Name = "CHGLOBAL"
        Me.CHGLOBAL.Size = New System.Drawing.Size(101, 17)
        Me.CHGLOBAL.TabIndex = 137
        Me.CHGLOBAL.Text = "RUTA GLOBAL"
        Me.CHGLOBAL.UseVisualStyleBackColor = True
        Me.CHGLOBAL.Visible = False
        '
        'CHKFAMP
        '
        Me.CHKFAMP.AutoSize = True
        Me.CHKFAMP.Location = New System.Drawing.Point(16, 205)
        Me.CHKFAMP.Name = "CHKFAMP"
        Me.CHKFAMP.Size = New System.Drawing.Size(87, 17)
        Me.CHKFAMP.TabIndex = 136
        Me.CHKFAMP.Text = "PROV - FAM"
        Me.CHKFAMP.UseVisualStyleBackColor = True
        Me.CHKFAMP.Visible = False
        '
        'CHKFOL
        '
        Me.CHKFOL.AutoSize = True
        Me.CHKFOL.Location = New System.Drawing.Point(16, 85)
        Me.CHKFOL.Name = "CHKFOL"
        Me.CHKFOL.Size = New System.Drawing.Size(57, 17)
        Me.CHKFOL.TabIndex = 135
        Me.CHKFOL.Text = "FOLIO"
        Me.CHKFOL.UseVisualStyleBackColor = True
        '
        'CHKCLI
        '
        Me.CHKCLI.AutoSize = True
        Me.CHKCLI.Location = New System.Drawing.Point(16, 61)
        Me.CHKCLI.Name = "CHKCLI"
        Me.CHKCLI.Size = New System.Drawing.Size(104, 17)
        Me.CHKCLI.TabIndex = 134
        Me.CHKCLI.Text = "SALIDAS RUTA"
        Me.CHKCLI.UseVisualStyleBackColor = True
        '
        'CHFAM
        '
        Me.CHFAM.AutoSize = True
        Me.CHFAM.Location = New System.Drawing.Point(16, 229)
        Me.CHFAM.Name = "CHFAM"
        Me.CHFAM.Size = New System.Drawing.Size(129, 17)
        Me.CHFAM.TabIndex = 15
        Me.CHFAM.Text = "ENTRADA DETALLE"
        Me.CHFAM.UseVisualStyleBackColor = True
        Me.CHFAM.Visible = False
        '
        'CHFAC
        '
        Me.CHFAC.AutoSize = True
        Me.CHFAC.Location = New System.Drawing.Point(16, 109)
        Me.CHFAC.Name = "CHFAC"
        Me.CHFAC.Size = New System.Drawing.Size(120, 17)
        Me.CHFAC.TabIndex = 13
        Me.CHFAC.Text = "NOTA O FACTURA"
        Me.CHFAC.UseVisualStyleBackColor = True
        '
        'TSOpciones
        '
        Me.TSOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSBSaveExit, Me.ToolStripSeparator2, Me.TSBSalir})
        Me.TSOpciones.Location = New System.Drawing.Point(0, 0)
        Me.TSOpciones.Name = "TSOpciones"
        Me.TSOpciones.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.TSOpciones.Size = New System.Drawing.Size(508, 25)
        Me.TSOpciones.TabIndex = 134
        Me.TSOpciones.Text = "ToolStrip1"
        '
        'TSBSaveExit
        '
        Me.TSBSaveExit.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TSBSaveExit.Image = Global.VisionTec.My.Resources.Resources._1366681746_print
        Me.TSBSaveExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBSaveExit.Name = "TSBSaveExit"
        Me.TSBSaveExit.Size = New System.Drawing.Size(79, 22)
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
        Me.TSBSalir.Size = New System.Drawing.Size(57, 22)
        Me.TSBSalir.Text = "SALIR"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(202, 172)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 12)
        Me.Label2.TabIndex = 155
        Me.Label2.Text = "PROVEEDOR"
        '
        'LBCLIENTE
        '
        Me.LBCLIENTE.AutoSize = True
        Me.LBCLIENTE.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBCLIENTE.Location = New System.Drawing.Point(238, 204)
        Me.LBCLIENTE.Name = "LBCLIENTE"
        Me.LBCLIENTE.Size = New System.Drawing.Size(35, 12)
        Me.LBCLIENTE.TabIndex = 157
        Me.LBCLIENTE.Text = "RUTA"
        '
        'CBCLIENTE
        '
        Me.CBCLIENTE.FormattingEnabled = True
        Me.CBCLIENTE.Location = New System.Drawing.Point(297, 200)
        Me.CBCLIENTE.Name = "CBCLIENTE"
        Me.CBCLIENTE.Size = New System.Drawing.Size(126, 21)
        Me.CBCLIENTE.TabIndex = 156
        '
        'CBMOVI
        '
        Me.CBMOVI.FormattingEnabled = True
        Me.CBMOVI.Location = New System.Drawing.Point(297, 136)
        Me.CBMOVI.Name = "CBMOVI"
        Me.CBMOVI.Size = New System.Drawing.Size(126, 21)
        Me.CBMOVI.TabIndex = 158
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(198, 140)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 12)
        Me.Label3.TabIndex = 159
        Me.Label3.Text = "MOVIMIENTO"
        '
        'TXTCODIGO
        '
        Me.TXTCODIGO.Location = New System.Drawing.Point(297, 232)
        Me.TXTCODIGO.Name = "TXTCODIGO"
        Me.TXTCODIGO.Size = New System.Drawing.Size(126, 20)
        Me.TXTCODIGO.TabIndex = 160
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(225, 236)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 12)
        Me.Label4.TabIndex = 161
        Me.Label4.Text = "CODIGO"
        '
        'LBLDESCRIPCION
        '
        Me.LBLDESCRIPCION.AutoSize = True
        Me.LBLDESCRIPCION.Location = New System.Drawing.Point(246, 258)
        Me.LBLDESCRIPCION.Name = "LBLDESCRIPCION"
        Me.LBLDESCRIPCION.Size = New System.Drawing.Size(10, 13)
        Me.LBLDESCRIPCION.TabIndex = 162
        Me.LBLDESCRIPCION.TabStop = True
        Me.LBLDESCRIPCION.Text = "."
        '
        'CbFAM
        '
        Me.CbFAM.Enabled = False
        Me.CbFAM.FormattingEnabled = True
        Me.CbFAM.Location = New System.Drawing.Point(297, 284)
        Me.CbFAM.Name = "CbFAM"
        Me.CbFAM.Size = New System.Drawing.Size(126, 21)
        Me.CbFAM.TabIndex = 163
        Me.CbFAM.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(221, 288)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 12)
        Me.Label5.TabIndex = 164
        Me.Label5.Text = "FAMILIA"
        Me.Label5.Visible = False
        '
        'RP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(508, 334)
        Me.Controls.Add(Me.CbFAM)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.LBLDESCRIPCION)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TXTCODIGO)
        Me.Controls.Add(Me.CBMOVI)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LBCLIENTE)
        Me.Controls.Add(Me.CBCLIENTE)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Cbalm)
        Me.Controls.Add(Me.CBPROVE)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TSOpciones)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "RP"
        Me.Text = "REPORTES"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TSOpciones.ResumeLayout(False)
        Me.TSOpciones.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Cbalm As System.Windows.Forms.ComboBox
    Friend WithEvents CHPROV As System.Windows.Forms.CheckBox
    Friend WithEvents CBPROVE As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents DTFECHAA As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents DTFECHADE As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CHFAM As System.Windows.Forms.CheckBox
    Friend WithEvents CHFAC As System.Windows.Forms.CheckBox
    Friend WithEvents TSOpciones As System.Windows.Forms.ToolStrip
    Friend WithEvents TSBSaveExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TSBSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents CHKFOL As System.Windows.Forms.CheckBox
    Friend WithEvents CHKCLI As System.Windows.Forms.CheckBox
    Friend WithEvents CHKFAMP As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LBCLIENTE As System.Windows.Forms.Label
    Friend WithEvents CBCLIENTE As System.Windows.Forms.ComboBox
    Friend WithEvents CBMOVI As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CHGLOBAL As System.Windows.Forms.CheckBox
    Friend WithEvents CHPROD As System.Windows.Forms.CheckBox
    Friend WithEvents TXTCODIGO As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LBLDESCRIPCION As System.Windows.Forms.LinkLabel
    Friend WithEvents CbFAM As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
End Class
