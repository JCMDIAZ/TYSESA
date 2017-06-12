<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAsignacionRuta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAsignacionRuta))
        Me.TSOpciones = New System.Windows.Forms.ToolStrip
        Me.TSBSalir = New System.Windows.Forms.ToolStripButton
        Me.CmbRuta = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.DGEmpAsig = New System.Windows.Forms.DataGridView
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.DelBtn = New System.Windows.Forms.Button
        Me.AddBtn = New System.Windows.Forms.Button
        Me.lbquitarut = New System.Windows.Forms.LinkLabel
        Me.lbagregarut = New System.Windows.Forms.LinkLabel
        Me.TSOpciones.SuspendLayout()
        CType(Me.DGEmpAsig, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TSOpciones
        '
        Me.TSOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSBSalir})
        Me.TSOpciones.Location = New System.Drawing.Point(0, 0)
        Me.TSOpciones.Name = "TSOpciones"
        Me.TSOpciones.Size = New System.Drawing.Size(345, 25)
        Me.TSOpciones.TabIndex = 13
        Me.TSOpciones.Text = "ToolStrip1"
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
        'CmbRuta
        '
        Me.CmbRuta.FormattingEnabled = True
        Me.CmbRuta.Location = New System.Drawing.Point(378, 56)
        Me.CmbRuta.Name = "CmbRuta"
        Me.CmbRuta.Size = New System.Drawing.Size(175, 21)
        Me.CmbRuta.TabIndex = 14
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(54, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 12)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "CHOFER"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(436, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 12)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "RUTA"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(111, 37)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(163, 21)
        Me.ComboBox1.TabIndex = 17
        '
        'DGEmpAsig
        '
        Me.DGEmpAsig.AllowUserToAddRows = False
        Me.DGEmpAsig.AllowUserToDeleteRows = False
        Me.DGEmpAsig.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGEmpAsig.ColumnHeadersVisible = False
        Me.DGEmpAsig.Location = New System.Drawing.Point(208, 98)
        Me.DGEmpAsig.MultiSelect = False
        Me.DGEmpAsig.Name = "DGEmpAsig"
        Me.DGEmpAsig.ReadOnly = True
        Me.DGEmpAsig.RowHeadersVisible = False
        Me.DGEmpAsig.Size = New System.Drawing.Size(95, 150)
        Me.DGEmpAsig.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(25, 78)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(123, 12)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "RUTAS NO ASIGNADA"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(203, 78)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 12)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "RUTA ASIGNADAS"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.ColumnHeadersVisible = False
        Me.DataGridView1.Location = New System.Drawing.Point(36, 98)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(95, 150)
        Me.DataGridView1.TabIndex = 21
        '
        'DelBtn
        '
        Me.DelBtn.Image = Global.VisionTec.My.Resources.Resources.back
        Me.DelBtn.Location = New System.Drawing.Point(146, 182)
        Me.DelBtn.Name = "DelBtn"
        Me.DelBtn.Size = New System.Drawing.Size(44, 42)
        Me.DelBtn.TabIndex = 30
        Me.DelBtn.UseVisualStyleBackColor = True
        '
        'AddBtn
        '
        Me.AddBtn.Image = Global.VisionTec.My.Resources.Resources._next
        Me.AddBtn.Location = New System.Drawing.Point(146, 119)
        Me.AddBtn.Name = "AddBtn"
        Me.AddBtn.Size = New System.Drawing.Size(44, 42)
        Me.AddBtn.TabIndex = 29
        Me.AddBtn.UseVisualStyleBackColor = True
        '
        'lbquitarut
        '
        Me.lbquitarut.AutoSize = True
        Me.lbquitarut.Location = New System.Drawing.Point(146, 239)
        Me.lbquitarut.Name = "lbquitarut"
        Me.lbquitarut.Size = New System.Drawing.Size(10, 13)
        Me.lbquitarut.TabIndex = 34
        Me.lbquitarut.TabStop = True
        Me.lbquitarut.Text = "."
        '
        'lbagregarut
        '
        Me.lbagregarut.AutoSize = True
        Me.lbagregarut.Location = New System.Drawing.Point(146, 98)
        Me.lbagregarut.Name = "lbagregarut"
        Me.lbagregarut.Size = New System.Drawing.Size(10, 13)
        Me.lbagregarut.TabIndex = 33
        Me.lbagregarut.TabStop = True
        Me.lbagregarut.Text = "."
        '
        'FrmAsignacionRuta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(345, 286)
        Me.Controls.Add(Me.lbquitarut)
        Me.Controls.Add(Me.lbagregarut)
        Me.Controls.Add(Me.DelBtn)
        Me.Controls.Add(Me.AddBtn)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CmbRuta)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DGEmpAsig)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.TSOpciones)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmAsignacionRuta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Asignacion de Ruta a Empleado"
        Me.TSOpciones.ResumeLayout(False)
        Me.TSOpciones.PerformLayout()
        CType(Me.DGEmpAsig, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TSOpciones As System.Windows.Forms.ToolStrip
    Friend WithEvents TSBSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents CmbRuta As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents DGEmpAsig As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents DelBtn As System.Windows.Forms.Button
    Friend WithEvents AddBtn As System.Windows.Forms.Button
    Friend WithEvents lbquitarut As System.Windows.Forms.LinkLabel
    Friend WithEvents lbagregarut As System.Windows.Forms.LinkLabel
End Class
