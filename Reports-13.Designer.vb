<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Reports_13
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Reports_13))
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.DTPDe = New System.Windows.Forms.DateTimePicker()
        Me.DTPA = New System.Windows.Forms.DateTimePicker()
        Me.LblDe = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Cbalm = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(16, 69)
        Me.CrystalReportViewer1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(1103, 464)
        Me.CrystalReportViewer1.TabIndex = 1
        Me.CrystalReportViewer1.ToolPanelWidth = 267
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'DTPDe
        '
        Me.DTPDe.CustomFormat = "dd/MM/yyyy"
        Me.DTPDe.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPDe.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPDe.Location = New System.Drawing.Point(121, 14)
        Me.DTPDe.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DTPDe.Name = "DTPDe"
        Me.DTPDe.Size = New System.Drawing.Size(180, 24)
        Me.DTPDe.TabIndex = 2
        '
        'DTPA
        '
        Me.DTPA.CustomFormat = "dd/MM/yyyy"
        Me.DTPA.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPA.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPA.Location = New System.Drawing.Point(369, 14)
        Me.DTPA.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DTPA.Name = "DTPA"
        Me.DTPA.Size = New System.Drawing.Size(184, 24)
        Me.DTPA.TabIndex = 3
        Me.DTPA.Visible = False
        '
        'LblDe
        '
        Me.LblDe.AutoSize = True
        Me.LblDe.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDe.Location = New System.Drawing.Point(72, 16)
        Me.LblDe.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDe.Name = "LblDe"
        Me.LblDe.Size = New System.Drawing.Size(49, 25)
        Me.LblDe.TabIndex = 4
        Me.LblDe.Text = "Dia"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(333, 16)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 25)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "A"
        Me.Label1.Visible = False
        '
        'Cbalm
        '
        Me.Cbalm.FormattingEnabled = True
        Me.Cbalm.Location = New System.Drawing.Point(777, 17)
        Me.Cbalm.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Cbalm.Name = "Cbalm"
        Me.Cbalm.Size = New System.Drawing.Size(152, 24)
        Me.Cbalm.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(648, 16)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 25)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Almacen:"
        '
        'Reports_13
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1136, 533)
        Me.Controls.Add(Me.DTPA)
        Me.Controls.Add(Me.DTPDe)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Cbalm)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LblDe)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "Reports_13"
        Me.Text = "REPORTE EXISTENCIAS"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents DTPDe As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTPA As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblDe As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Cbalm As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
