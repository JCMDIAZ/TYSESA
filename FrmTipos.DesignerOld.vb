<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTipos
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
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTipos))
        Me.TSOpciones = New System.Windows.Forms.ToolStrip
        Me.TSBSaveNew = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.TSBSalir = New System.Windows.Forms.ToolStripButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TxtCodigo = New System.Windows.Forms.TextBox
        Me.ChBoxModificar = New System.Windows.Forms.CheckBox
        Me.ChActivo = New System.Windows.Forms.CheckBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtDescripcion = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DGFAM1 = New System.Windows.Forms.DataGridView
        Me.DGFAM = New System.Windows.Forms.DataGridView
        Me.GeneralesDataSet = New VisionTec.generalesDataSet
        Me.InventariosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.InventariosTableAdapter = New VisionTec.generalesDataSetTableAdapters.InventariosTableAdapter
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel
        Me.TBoxBuscaFamilia = New System.Windows.Forms.TextBox
        Me.TSOpciones.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DGFAM1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGFAM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GeneralesDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InventariosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TSOpciones
        '
        Me.TSOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSBSaveNew, Me.ToolStripSeparator1, Me.ToolStripButton3, Me.ToolStripSeparator2, Me.TSBSalir})
        Me.TSOpciones.Location = New System.Drawing.Point(0, 0)
        Me.TSOpciones.Name = "TSOpciones"
        Me.TSOpciones.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.TSOpciones.Size = New System.Drawing.Size(364, 25)
        Me.TSOpciones.TabIndex = 5
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
        Me.GroupBox1.Controls.Add(Me.TxtCodigo)
        Me.GroupBox1.Controls.Add(Me.ChBoxModificar)
        Me.GroupBox1.Controls.Add(Me.ChActivo)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.TxtDescripcion)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(19, 29)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(326, 122)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Familias"
        '
        'TxtCodigo
        '
        Me.TxtCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCodigo.Location = New System.Drawing.Point(121, 19)
        Me.TxtCodigo.Name = "TxtCodigo"
        Me.TxtCodigo.Size = New System.Drawing.Size(158, 18)
        Me.TxtCodigo.TabIndex = 0
        '
        'ChBoxModificar
        '
        Me.ChBoxModificar.AutoSize = True
        Me.ChBoxModificar.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.ChBoxModificar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChBoxModificar.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ChBoxModificar.Location = New System.Drawing.Point(201, 19)
        Me.ChBoxModificar.Name = "ChBoxModificar"
        Me.ChBoxModificar.Size = New System.Drawing.Size(119, 24)
        Me.ChBoxModificar.TabIndex = 52
        Me.ChBoxModificar.Text = "MODIFICAR"
        Me.ChBoxModificar.UseVisualStyleBackColor = False
        Me.ChBoxModificar.Visible = False
        '
        'ChActivo
        '
        Me.ChActivo.AutoSize = True
        Me.ChActivo.Checked = True
        Me.ChActivo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChActivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChActivo.Location = New System.Drawing.Point(103, 98)
        Me.ChActivo.Name = "ChActivo"
        Me.ChActivo.Size = New System.Drawing.Size(60, 16)
        Me.ChActivo.TabIndex = 46
        Me.ChActivo.Text = "ACTIVO"
        Me.ChActivo.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(121, 74)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(158, 18)
        Me.TextBox1.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(41, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 12)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Abreviatura"
        '
        'TxtDescripcion
        '
        Me.TxtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDescripcion.Location = New System.Drawing.Point(121, 46)
        Me.TxtDescripcion.Name = "TxtDescripcion"
        Me.TxtDescripcion.Size = New System.Drawing.Size(158, 18)
        Me.TxtDescripcion.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(41, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Descripcion"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(70, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Clave"
        '
        'DGFAM1
        '
        Me.DGFAM1.AllowUserToAddRows = False
        Me.DGFAM1.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.NullValue = "NA"
        Me.DGFAM1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DGFAM1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DGFAM1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGFAM1.Location = New System.Drawing.Point(36, 193)
        Me.DGFAM1.Name = "DGFAM1"
        Me.DGFAM1.ReadOnly = True
        Me.DGFAM1.RowHeadersWidth = 20
        Me.DGFAM1.RowTemplate.Height = 24
        Me.DGFAM1.Size = New System.Drawing.Size(295, 164)
        Me.DGFAM1.TabIndex = 30
        Me.DGFAM1.Visible = False
        '
        'DGFAM
        '
        Me.DGFAM.AllowUserToAddRows = False
        Me.DGFAM.AllowUserToDeleteRows = False
        Me.DGFAM.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGFAM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGFAM.Location = New System.Drawing.Point(19, 185)
        Me.DGFAM.MultiSelect = False
        Me.DGFAM.Name = "DGFAM"
        Me.DGFAM.ReadOnly = True
        Me.DGFAM.Size = New System.Drawing.Size(326, 272)
        Me.DGFAM.TabIndex = 31
        '
        'GeneralesDataSet
        '
        Me.GeneralesDataSet.DataSetName = "generalesDataSet"
        Me.GeneralesDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'InventariosBindingSource
        '
        Me.InventariosBindingSource.DataMember = "Inventarios"
        Me.InventariosBindingSource.DataSource = Me.GeneralesDataSet
        '
        'InventariosTableAdapter
        '
        Me.InventariosTableAdapter.ClearBeforeFill = True
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.LinkLabel2.Location = New System.Drawing.Point(226, 162)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(87, 13)
        Me.LinkLabel2.TabIndex = 45
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "BUSCA FAMILIA"
        '
        'TBoxBuscaFamilia
        '
        Me.TBoxBuscaFamilia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TBoxBuscaFamilia.Location = New System.Drawing.Point(52, 159)
        Me.TBoxBuscaFamilia.Name = "TBoxBuscaFamilia"
        Me.TBoxBuscaFamilia.Size = New System.Drawing.Size(167, 20)
        Me.TBoxBuscaFamilia.TabIndex = 44
        '
        'FrmTipos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(364, 469)
        Me.Controls.Add(Me.LinkLabel2)
        Me.Controls.Add(Me.TBoxBuscaFamilia)
        Me.Controls.Add(Me.DGFAM)
        Me.Controls.Add(Me.DGFAM1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TSOpciones)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmTipos"
        Me.Text = "Familias"
        Me.TSOpciones.ResumeLayout(False)
        Me.TSOpciones.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DGFAM1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGFAM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GeneralesDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InventariosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TSOpciones As System.Windows.Forms.ToolStrip
    Friend WithEvents TSBSaveNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TSBSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents GeneralesDataSet As VisionTec.generalesDataSet
    Friend WithEvents InventariosBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents InventariosTableAdapter As VisionTec.generalesDataSetTableAdapters.InventariosTableAdapter
    Friend WithEvents DGFAM1 As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ChActivo As System.Windows.Forms.CheckBox
    Friend WithEvents DGFAM As System.Windows.Forms.DataGridView
    Friend WithEvents ChBoxModificar As System.Windows.Forms.CheckBox
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents TBoxBuscaFamilia As System.Windows.Forms.TextBox
End Class
