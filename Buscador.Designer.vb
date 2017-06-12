<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Buscador
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Buscador))
        Me.DGbusca = New System.Windows.Forms.DataGridView
        Me.TSOpciones = New System.Windows.Forms.ToolStrip
        Me.TSBSaveNew = New System.Windows.Forms.ToolStripButton
        Me.TSBSaveExit = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.TSBSalir = New System.Windows.Forms.ToolStripButton
        Me.TxtCodigo = New System.Windows.Forms.TextBox
        Me.TxtDescripcion = New System.Windows.Forms.TextBox
        Me.Txtalterno = New System.Windows.Forms.TextBox
        Me.lbform = New System.Windows.Forms.LinkLabel
        Me.Button1 = New System.Windows.Forms.Button
        CType(Me.DGbusca, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TSOpciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'DGbusca
        '
        Me.DGbusca.AllowUserToAddRows = False
        Me.DGbusca.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.NullValue = "NA"
        Me.DGbusca.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DGbusca.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DGbusca.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.DGbusca.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGbusca.ColumnHeadersVisible = False
        Me.DGbusca.Location = New System.Drawing.Point(39, 86)
        Me.DGbusca.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DGbusca.Name = "DGbusca"
        Me.DGbusca.RowHeadersWidth = 20
        Me.DGbusca.Size = New System.Drawing.Size(620, 334)
        Me.DGbusca.TabIndex = 30
        '
        'TSOpciones
        '
        Me.TSOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSBSaveNew, Me.TSBSaveExit, Me.ToolStripSeparator2, Me.TSBSalir})
        Me.TSOpciones.Location = New System.Drawing.Point(0, 0)
        Me.TSOpciones.Name = "TSOpciones"
        Me.TSOpciones.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.TSOpciones.Size = New System.Drawing.Size(704, 25)
        Me.TSOpciones.TabIndex = 31
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
        'TSBSaveExit
        '
        Me.TSBSaveExit.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TSBSaveExit.Image = Global.VisionTec.My.Resources.Resources._1366681822_edit_clear
        Me.TSBSaveExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBSaveExit.Name = "TSBSaveExit"
        Me.TSBSaveExit.Size = New System.Drawing.Size(81, 22)
        Me.TSBSaveExit.Text = "LIMPIAR"
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
        'TxtCodigo
        '
        Me.TxtCodigo.Enabled = False
        Me.TxtCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCodigo.Location = New System.Drawing.Point(39, 46)
        Me.TxtCodigo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtCodigo.MaxLength = 4
        Me.TxtCodigo.Name = "TxtCodigo"
        Me.TxtCodigo.Size = New System.Drawing.Size(164, 20)
        Me.TxtCodigo.TabIndex = 32
        '
        'TxtDescripcion
        '
        Me.TxtDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDescripcion.Location = New System.Drawing.Point(212, 46)
        Me.TxtDescripcion.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtDescripcion.Name = "TxtDescripcion"
        Me.TxtDescripcion.Size = New System.Drawing.Size(359, 20)
        Me.TxtDescripcion.TabIndex = 33
        '
        'Txtalterno
        '
        Me.Txtalterno.Enabled = False
        Me.Txtalterno.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtalterno.Location = New System.Drawing.Point(580, 46)
        Me.Txtalterno.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Txtalterno.MaxLength = 15
        Me.Txtalterno.Name = "Txtalterno"
        Me.Txtalterno.Size = New System.Drawing.Size(77, 20)
        Me.Txtalterno.TabIndex = 34
        '
        'lbform
        '
        Me.lbform.AutoSize = True
        Me.lbform.Location = New System.Drawing.Point(48, 437)
        Me.lbform.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbform.Name = "lbform"
        Me.lbform.Size = New System.Drawing.Size(77, 17)
        Me.lbform.TabIndex = 35
        Me.lbform.TabStop = True
        Me.lbform.Text = "LinkLabel1"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(440, 427)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(200, 36)
        Me.Button1.TabIndex = 36
        Me.Button1.Text = "SELECCIONAR"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Buscador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(704, 473)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lbform)
        Me.Controls.Add(Me.Txtalterno)
        Me.Controls.Add(Me.TxtDescripcion)
        Me.Controls.Add(Me.TxtCodigo)
        Me.Controls.Add(Me.TSOpciones)
        Me.Controls.Add(Me.DGbusca)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "Buscador"
        Me.Text = "Buscador"
        CType(Me.DGbusca, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TSOpciones.ResumeLayout(False)
        Me.TSOpciones.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DGbusca As System.Windows.Forms.DataGridView
    Friend WithEvents TSOpciones As System.Windows.Forms.ToolStrip
    Friend WithEvents TSBSaveNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBSaveExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TSBSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents TxtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents TxtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Txtalterno As System.Windows.Forms.TextBox
    Friend WithEvents lbform As System.Windows.Forms.LinkLabel
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
