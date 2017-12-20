<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPedidos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPedidos))
        Me.TSOpciones = New System.Windows.Forms.ToolStrip
        Me.TSBSaveNew = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.TSBSalir = New System.Windows.Forms.ToolStripButton
        Me.Txtobs = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.OFDImagen = New System.Windows.Forms.OpenFileDialog
        Me.cbruta = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.DGfalta = New System.Windows.Forms.DataGridView
        Me.TSOpciones.SuspendLayout()
        CType(Me.DGfalta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TSOpciones
        '
        Me.TSOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSBSaveNew, Me.ToolStripButton1, Me.ToolStripSeparator2, Me.TSBSalir})
        Me.TSOpciones.Location = New System.Drawing.Point(0, 0)
        Me.TSOpciones.Name = "TSOpciones"
        Me.TSOpciones.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.TSOpciones.Size = New System.Drawing.Size(665, 25)
        Me.TSOpciones.TabIndex = 5
        Me.TSOpciones.Text = "ToolStrip1"
        '
        'TSBSaveNew
        '
        Me.TSBSaveNew.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TSBSaveNew.Image = Global.VisionTec.My.Resources.Resources.save
        Me.TSBSaveNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBSaveNew.Name = "TSBSaveNew"
        Me.TSBSaveNew.Size = New System.Drawing.Size(73, 22)
        Me.TSBSaveNew.Text = "VALIDAR"
        Me.TSBSaveNew.ToolTipText = "Guardar y Nuevo"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold)
        Me.ToolStripButton1.Image = Global.VisionTec.My.Resources.Resources._1366681757_print
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(159, 22)
        Me.ToolStripButton1.Text = "IMPRESION DE FALTANTE"
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
        'Txtobs
        '
        Me.Txtobs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtobs.Location = New System.Drawing.Point(154, 67)
        Me.Txtobs.Name = "Txtobs"
        Me.Txtobs.Size = New System.Drawing.Size(368, 20)
        Me.Txtobs.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(51, 69)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "OBSERVACIONES"
        '
        'OFDImagen
        '
        Me.OFDImagen.Filter = "Archivos de Imagen |*.jpg"
        '
        'cbruta
        '
        Me.cbruta.FormattingEnabled = True
        Me.cbruta.Location = New System.Drawing.Point(154, 39)
        Me.cbruta.Name = "cbruta"
        Me.cbruta.Size = New System.Drawing.Size(132, 21)
        Me.cbruta.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label3.Location = New System.Drawing.Point(112, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "RUTA"
        '
        'DGfalta
        '
        Me.DGfalta.AllowUserToAddRows = False
        Me.DGfalta.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.NullValue = "NA"
        Me.DGfalta.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DGfalta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DGfalta.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.DGfalta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGfalta.ColumnHeadersVisible = False
        Me.DGfalta.Location = New System.Drawing.Point(36, 125)
        Me.DGfalta.Name = "DGfalta"
        Me.DGfalta.RowHeadersWidth = 20
        Me.DGfalta.RowTemplate.Height = 24
        Me.DGfalta.Size = New System.Drawing.Size(591, 204)
        Me.DGfalta.TabIndex = 35
        '
        'FrmPedidos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(665, 421)
        Me.Controls.Add(Me.DGfalta)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TSOpciones)
        Me.Controls.Add(Me.Txtobs)
        Me.Controls.Add(Me.cbruta)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmPedidos"
        Me.Text = "FALTANTES"
        Me.TSOpciones.ResumeLayout(False)
        Me.TSOpciones.PerformLayout()
        CType(Me.DGfalta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TSOpciones As System.Windows.Forms.ToolStrip
    Friend WithEvents TSBSaveNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TSBSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents Txtobs As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents OFDImagen As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbruta As System.Windows.Forms.ComboBox
    Friend WithEvents DGfalta As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
End Class
