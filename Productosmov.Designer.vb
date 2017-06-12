<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PRODUCTOS
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PRODUCTOS))
        Me.LBCLIENTE = New System.Windows.Forms.Label
        Me.CBCLIENTE = New System.Windows.Forms.ComboBox
        Me.LblDescripcion = New System.Windows.Forms.Label
        Me.TxtCodigo = New System.Windows.Forms.TextBox
        Me.TXTCODE = New System.Windows.Forms.Label
        Me.DTFECHAA = New System.Windows.Forms.DateTimePicker
        Me.Label8 = New System.Windows.Forms.Label
        Me.DTFECHADE = New System.Windows.Forms.DateTimePicker
        Me.Label7 = New System.Windows.Forms.Label
        Me.gridmovi = New System.Windows.Forms.DataGrid
        Me.TSOpciones = New System.Windows.Forms.ToolStrip
        Me.TSBSaveExit = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.TSBSalir = New System.Windows.Forms.ToolStripButton
        CType(Me.gridmovi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TSOpciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'LBCLIENTE
        '
        Me.LBCLIENTE.AutoSize = True
        Me.LBCLIENTE.Enabled = False
        Me.LBCLIENTE.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBCLIENTE.Location = New System.Drawing.Point(60, 156)
        Me.LBCLIENTE.Name = "LBCLIENTE"
        Me.LBCLIENTE.Size = New System.Drawing.Size(51, 12)
        Me.LBCLIENTE.TabIndex = 33
        Me.LBCLIENTE.Text = "CLIENTE"
        Me.LBCLIENTE.Visible = False
        '
        'CBCLIENTE
        '
        Me.CBCLIENTE.Enabled = False
        Me.CBCLIENTE.FormattingEnabled = True
        Me.CBCLIENTE.Location = New System.Drawing.Point(118, 152)
        Me.CBCLIENTE.Name = "CBCLIENTE"
        Me.CBCLIENTE.Size = New System.Drawing.Size(126, 21)
        Me.CBCLIENTE.TabIndex = 32
        Me.CBCLIENTE.Visible = False
        '
        'LblDescripcion
        '
        Me.LblDescripcion.AutoSize = True
        Me.LblDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDescripcion.ForeColor = System.Drawing.Color.Blue
        Me.LblDescripcion.Location = New System.Drawing.Point(64, 115)
        Me.LblDescripcion.Name = "LblDescripcion"
        Me.LblDescripcion.Size = New System.Drawing.Size(9, 12)
        Me.LblDescripcion.TabIndex = 36
        Me.LblDescripcion.Text = "."
        '
        'TxtCodigo
        '
        Me.TxtCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCodigo.Location = New System.Drawing.Point(100, 81)
        Me.TxtCodigo.Name = "TxtCodigo"
        Me.TxtCodigo.Size = New System.Drawing.Size(126, 18)
        Me.TxtCodigo.TabIndex = 34
        '
        'TXTCODE
        '
        Me.TXTCODE.AutoSize = True
        Me.TXTCODE.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCODE.Location = New System.Drawing.Point(43, 84)
        Me.TXTCODE.Name = "TXTCODE"
        Me.TXTCODE.Size = New System.Drawing.Size(49, 12)
        Me.TXTCODE.TabIndex = 35
        Me.TXTCODE.Text = "CODIGO"
        '
        'DTFECHAA
        '
        Me.DTFECHAA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTFECHAA.Location = New System.Drawing.Point(163, 45)
        Me.DTFECHAA.Name = "DTFECHAA"
        Me.DTFECHAA.Size = New System.Drawing.Size(90, 20)
        Me.DTFECHAA.TabIndex = 38
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(144, 50)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(13, 12)
        Me.Label8.TabIndex = 40
        Me.Label8.Text = "A"
        '
        'DTFECHADE
        '
        Me.DTFECHADE.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTFECHADE.Location = New System.Drawing.Point(48, 45)
        Me.DTFECHADE.Name = "DTFECHADE"
        Me.DTFECHADE.Size = New System.Drawing.Size(90, 20)
        Me.DTFECHADE.TabIndex = 37
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(22, 50)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(20, 12)
        Me.Label7.TabIndex = 39
        Me.Label7.Text = "DE"
        '
        'gridmovi
        '
        Me.gridmovi.AllowDrop = True
        Me.gridmovi.AlternatingBackColor = System.Drawing.Color.Lavender
        Me.gridmovi.BackColor = System.Drawing.Color.WhiteSmoke
        Me.gridmovi.BackgroundColor = System.Drawing.Color.LightGray
        Me.gridmovi.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.gridmovi.CaptionBackColor = System.Drawing.Color.LightSteelBlue
        Me.gridmovi.CaptionForeColor = System.Drawing.Color.MidnightBlue
        Me.gridmovi.DataMember = ""
        Me.gridmovi.Enabled = False
        Me.gridmovi.FlatMode = True
        Me.gridmovi.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.gridmovi.ForeColor = System.Drawing.Color.MidnightBlue
        Me.gridmovi.GridLineColor = System.Drawing.Color.Gainsboro
        Me.gridmovi.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None
        Me.gridmovi.HeaderBackColor = System.Drawing.Color.MidnightBlue
        Me.gridmovi.HeaderFont = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.gridmovi.HeaderForeColor = System.Drawing.Color.WhiteSmoke
        Me.gridmovi.LinkColor = System.Drawing.Color.Teal
        Me.gridmovi.Location = New System.Drawing.Point(280, 152)
        Me.gridmovi.Name = "gridmovi"
        Me.gridmovi.ParentRowsBackColor = System.Drawing.Color.Gainsboro
        Me.gridmovi.ParentRowsForeColor = System.Drawing.Color.MidnightBlue
        Me.gridmovi.ReadOnly = True
        Me.gridmovi.RowHeadersVisible = False
        Me.gridmovi.RowHeaderWidth = 10
        Me.gridmovi.SelectionBackColor = System.Drawing.Color.CadetBlue
        Me.gridmovi.SelectionForeColor = System.Drawing.Color.WhiteSmoke
        Me.gridmovi.Size = New System.Drawing.Size(99, 15)
        Me.gridmovi.TabIndex = 107
        Me.gridmovi.Visible = False
        '
        'TSOpciones
        '
        Me.TSOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSBSaveExit, Me.ToolStripSeparator2, Me.TSBSalir})
        Me.TSOpciones.Location = New System.Drawing.Point(0, 0)
        Me.TSOpciones.Name = "TSOpciones"
        Me.TSOpciones.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.TSOpciones.Size = New System.Drawing.Size(297, 25)
        Me.TSOpciones.TabIndex = 108
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
        'PRODUCTOS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(297, 148)
        Me.Controls.Add(Me.TSOpciones)
        Me.Controls.Add(Me.gridmovi)
        Me.Controls.Add(Me.DTFECHAA)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.DTFECHADE)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.LblDescripcion)
        Me.Controls.Add(Me.TxtCodigo)
        Me.Controls.Add(Me.TXTCODE)
        Me.Controls.Add(Me.LBCLIENTE)
        Me.Controls.Add(Me.CBCLIENTE)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "PRODUCTOS"
        Me.Text = "Movimientos Productos"
        CType(Me.gridmovi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TSOpciones.ResumeLayout(False)
        Me.TSOpciones.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LBCLIENTE As System.Windows.Forms.Label
    Friend WithEvents CBCLIENTE As System.Windows.Forms.ComboBox
    Friend WithEvents LblDescripcion As System.Windows.Forms.Label
    Friend WithEvents TxtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents TXTCODE As System.Windows.Forms.Label
    Friend WithEvents DTFECHAA As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents DTFECHADE As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Private WithEvents gridmovi As System.Windows.Forms.DataGrid
    Friend WithEvents TSOpciones As System.Windows.Forms.ToolStrip
    Friend WithEvents TSBSaveExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TSBSalir As System.Windows.Forms.ToolStripButton
End Class
