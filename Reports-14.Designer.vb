<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Reports_14
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Reports_14))
        Me.CRVUbi = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'CRVUbi
        '
        Me.CRVUbi.ActiveViewIndex = -1
        Me.CRVUbi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRVUbi.DisplayGroupTree = False
        Me.CRVUbi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CRVUbi.Location = New System.Drawing.Point(0, 0)
        Me.CRVUbi.Name = "CRVUbi"
        Me.CRVUbi.SelectionFormula = ""
        Me.CRVUbi.Size = New System.Drawing.Size(975, 521)
        Me.CRVUbi.TabIndex = 2
        Me.CRVUbi.ViewTimeSelectionFormula = ""
        '
        'Reports_14
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(975, 521)
        Me.Controls.Add(Me.CRVUbi)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Reports_14"
        Me.Text = "Reportes de Ubicaciones"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CRVUbi As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
