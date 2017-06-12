<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class printport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(printport))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.CBFOLIOS = New System.Windows.Forms.ComboBox
        Me.BTNFOLIO = New System.Windows.Forms.Button
        Me.Lblfolio = New System.Windows.Forms.LinkLabel
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument
        Me.Button2 = New System.Windows.Forms.Button
        Me.lbcant = New System.Windows.Forms.LinkLabel
        Me.CheckBox3 = New System.Windows.Forms.CheckBox
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.RadioButton3 = New System.Windows.Forms.RadioButton
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.ChBoxTimpr = New System.Windows.Forms.CheckBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.CBoxImpresoras = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Txtlote = New System.Windows.Forms.TextBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.PrintDocument2 = New System.Drawing.Printing.PrintDocument
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 6000
        '
        'CBFOLIOS
        '
        Me.CBFOLIOS.FormattingEnabled = True
        Me.CBFOLIOS.Location = New System.Drawing.Point(74, 28)
        Me.CBFOLIOS.Name = "CBFOLIOS"
        Me.CBFOLIOS.Size = New System.Drawing.Size(119, 21)
        Me.CBFOLIOS.TabIndex = 0
        '
        'BTNFOLIO
        '
        Me.BTNFOLIO.Location = New System.Drawing.Point(82, 68)
        Me.BTNFOLIO.Name = "BTNFOLIO"
        Me.BTNFOLIO.Size = New System.Drawing.Size(98, 39)
        Me.BTNFOLIO.TabIndex = 1
        Me.BTNFOLIO.Text = "PRINT FOLIO"
        Me.BTNFOLIO.UseVisualStyleBackColor = True
        '
        'Lblfolio
        '
        Me.Lblfolio.AutoSize = True
        Me.Lblfolio.Enabled = False
        Me.Lblfolio.Location = New System.Drawing.Point(202, 184)
        Me.Lblfolio.Name = "Lblfolio"
        Me.Lblfolio.Size = New System.Drawing.Size(41, 13)
        Me.Lblfolio.TabIndex = 2
        Me.Lblfolio.TabStop = True
        Me.Lblfolio.Text = "no folio"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Enabled = False
        Me.CheckBox1.Location = New System.Drawing.Point(45, 158)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(177, 17)
        Me.CheckBox1.TabIndex = 3
        Me.CheckBox1.Text = "HABILITA REPORTES SALIDA"
        Me.CheckBox1.UseVisualStyleBackColor = True
        Me.CheckBox1.Visible = False
        '
        'Button1
        '
        Me.Button1.Enabled = False
        Me.Button1.Location = New System.Drawing.Point(6, 147)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(30, 24)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "BORRAR FOLIOS"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(58, 85)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(137, 17)
        Me.CheckBox2.TabIndex = 5
        Me.CheckBox2.Text = "HABILITA IMPRESION"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'PrintDocument1
        '
        '
        'Button2
        '
        Me.Button2.Enabled = False
        Me.Button2.Location = New System.Drawing.Point(87, 169)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(86, 36)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "BARCODE"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'lbcant
        '
        Me.lbcant.AutoSize = True
        Me.lbcant.Enabled = False
        Me.lbcant.Location = New System.Drawing.Point(17, 184)
        Me.lbcant.Name = "lbcant"
        Me.lbcant.Size = New System.Drawing.Size(41, 13)
        Me.lbcant.TabIndex = 7
        Me.lbcant.TabStop = True
        Me.lbcant.Text = "no folio"
        Me.lbcant.Visible = False
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Enabled = False
        Me.CheckBox3.Location = New System.Drawing.Point(45, 137)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(173, 17)
        Me.CheckBox3.TabIndex = 8
        Me.CheckBox3.Text = "DOBLE IMPRESION SALIDAS"
        Me.CheckBox3.UseVisualStyleBackColor = True
        Me.CheckBox3.Visible = False
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(26, 65)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(50, 17)
        Me.RadioButton1.TabIndex = 9
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "4 X 4"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RadioButton3)
        Me.GroupBox1.Controls.Add(Me.RadioButton2)
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Location = New System.Drawing.Point(166, 110)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(80, 94)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Etiqueta"
        Me.GroupBox1.Visible = False
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Location = New System.Drawing.Point(26, 19)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(50, 17)
        Me.RadioButton3.TabIndex = 11
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Text = "4 X 6"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(26, 42)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(50, 17)
        Me.RadioButton2.TabIndex = 10
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "4 X 2"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.LinkLabel1)
        Me.GroupBox2.Controls.Add(Me.ChBoxTimpr)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.CBoxImpresoras)
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Txtlote)
        Me.GroupBox2.Controls.Add(Me.GroupBox1)
        Me.GroupBox2.Controls.Add(Me.CheckBox2)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Location = New System.Drawing.Point(281, 16)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(258, 211)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "ETIQUETAS"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Enabled = False
        Me.LinkLabel1.Location = New System.Drawing.Point(6, 184)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(41, 13)
        Me.LinkLabel1.TabIndex = 13
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "no folio"
        '
        'ChBoxTimpr
        '
        Me.ChBoxTimpr.AutoSize = True
        Me.ChBoxTimpr.Location = New System.Drawing.Point(63, 13)
        Me.ChBoxTimpr.Name = "ChBoxTimpr"
        Me.ChBoxTimpr.Size = New System.Drawing.Size(126, 17)
        Me.ChBoxTimpr.TabIndex = 15
        Me.ChBoxTimpr.Text = "Todas las Impresoras"
        Me.ChBoxTimpr.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(78, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(109, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Selecciona Impresora"
        '
        'CBoxImpresoras
        '
        Me.CBoxImpresoras.FormattingEnabled = True
        Me.CBoxImpresoras.Location = New System.Drawing.Point(30, 56)
        Me.CBoxImpresoras.Name = "CBoxImpresoras"
        Me.CBoxImpresoras.Size = New System.Drawing.Size(196, 21)
        Me.CBoxImpresoras.TabIndex = 13
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Enabled = False
        Me.Label1.Location = New System.Drawing.Point(38, 131)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "CODIGO"
        '
        'Txtlote
        '
        Me.Txtlote.Enabled = False
        Me.Txtlote.Location = New System.Drawing.Point(87, 130)
        Me.Txtlote.Name = "Txtlote"
        Me.Txtlote.Size = New System.Drawing.Size(100, 20)
        Me.Txtlote.TabIndex = 11
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.CheckBox3)
        Me.GroupBox3.Controls.Add(Me.CheckBox1)
        Me.GroupBox3.Controls.Add(Me.lbcant)
        Me.GroupBox3.Controls.Add(Me.Lblfolio)
        Me.GroupBox3.Controls.Add(Me.BTNFOLIO)
        Me.GroupBox3.Controls.Add(Me.CBFOLIOS)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 16)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(262, 211)
        Me.GroupBox3.TabIndex = 12
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "REPORTES PEDIDOS"
        '
        'PrintDocument2
        '
        '
        'printport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(554, 241)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "printport"
        Me.Text = "PUERTO DE IMPRESION"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents CBFOLIOS As System.Windows.Forms.ComboBox
    Friend WithEvents BTNFOLIO As System.Windows.Forms.Button
    Friend WithEvents Lblfolio As System.Windows.Forms.LinkLabel
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents lbcant As System.Windows.Forms.LinkLabel
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Txtlote As System.Windows.Forms.TextBox
    Friend WithEvents PrintDocument2 As System.Drawing.Printing.PrintDocument
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CBoxImpresoras As System.Windows.Forms.ComboBox
    Friend WithEvents ChBoxTimpr As System.Windows.Forms.CheckBox
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
End Class
