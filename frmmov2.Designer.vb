<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmmov2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmmov2))
        Me.TSOpciones = New System.Windows.Forms.ToolStrip
        Me.TSBSaveNew = New System.Windows.Forms.ToolStripButton
        Me.TSBSaveExit = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.TSBSalir = New System.Windows.Forms.ToolStripButton
        Me.LBUSER = New System.Windows.Forms.LinkLabel
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.CBMOVI = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Lbtotal = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.gridmovi = New System.Windows.Forms.DataGrid
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.CHNUMERO = New System.Windows.Forms.CheckBox
        Me.CBFAC = New System.Windows.Forms.ComboBox
        Me.TXTFAC = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.CBFAM = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.CBUSU = New System.Windows.Forms.ComboBox
        Me.CBPROVE = New System.Windows.Forms.ComboBox
        Me.LBCLIENTE = New System.Windows.Forms.Label
        Me.CBCLIENTE = New System.Windows.Forms.ComboBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.DTFECHAA = New System.Windows.Forms.DateTimePicker
        Me.Label8 = New System.Windows.Forms.Label
        Me.DTFECHADE = New System.Windows.Forms.DateTimePicker
        Me.Label7 = New System.Windows.Forms.Label
        Me.LblDescripcion = New System.Windows.Forms.Label
        Me.TxtCodigo = New System.Windows.Forms.TextBox
        Me.TXTCODE = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.ChBoxUbi = New System.Windows.Forms.CheckBox
        Me.CHCODE = New System.Windows.Forms.CheckBox
        Me.CHFAM = New System.Windows.Forms.CheckBox
        Me.CHUSU = New System.Windows.Forms.CheckBox
        Me.CHFAC = New System.Windows.Forms.CheckBox
        Me.CHPROV = New System.Windows.Forms.CheckBox
        Me.CHCLIENTE = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Cbalm = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.CBUBI = New System.Windows.Forms.ComboBox
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.ComboBox2 = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TSOpciones.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.gridmovi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'TSOpciones
        '
        Me.TSOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSBSaveNew, Me.TSBSaveExit, Me.ToolStripSeparator2, Me.TSBSalir})
        Me.TSOpciones.Location = New System.Drawing.Point(0, 0)
        Me.TSOpciones.Name = "TSOpciones"
        Me.TSOpciones.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.TSOpciones.Size = New System.Drawing.Size(854, 25)
        Me.TSOpciones.TabIndex = 12
        Me.TSOpciones.Text = "ToolStrip1"
        '
        'TSBSaveNew
        '
        Me.TSBSaveNew.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TSBSaveNew.Image = Global.VisionTec.My.Resources.Resources.search__2_
        Me.TSBSaveNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBSaveNew.Name = "TSBSaveNew"
        Me.TSBSaveNew.Size = New System.Drawing.Size(67, 22)
        Me.TSBSaveNew.Text = "BUSCAR"
        Me.TSBSaveNew.ToolTipText = "Guardar y Nuevo"
        '
        'TSBSaveExit
        '
        Me.TSBSaveExit.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TSBSaveExit.Image = Global.VisionTec.My.Resources.Resources._1366681757_print
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
        'LBUSER
        '
        Me.LBUSER.AutoSize = True
        Me.LBUSER.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.LBUSER.Location = New System.Drawing.Point(32, 449)
        Me.LBUSER.Name = "LBUSER"
        Me.LBUSER.Size = New System.Drawing.Size(10, 13)
        Me.LBUSER.TabIndex = 130
        Me.LBUSER.TabStop = True
        Me.LBUSER.Text = "."
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.CBMOVI)
        Me.GroupBox5.Controls.Add(Me.Label3)
        Me.GroupBox5.Location = New System.Drawing.Point(201, 29)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(310, 47)
        Me.GroupBox5.TabIndex = 129
        Me.GroupBox5.TabStop = False
        '
        'CBMOVI
        '
        Me.CBMOVI.FormattingEnabled = True
        Me.CBMOVI.Location = New System.Drawing.Point(74, 17)
        Me.CBMOVI.Name = "CBMOVI"
        Me.CBMOVI.Size = New System.Drawing.Size(218, 21)
        Me.CBMOVI.TabIndex = 28
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(32, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 12)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "TIPO"
        '
        'Lbtotal
        '
        Me.Lbtotal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbtotal.AutoSize = True
        Me.Lbtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbtotal.ForeColor = System.Drawing.Color.Blue
        Me.Lbtotal.Location = New System.Drawing.Point(759, 326)
        Me.Lbtotal.Name = "Lbtotal"
        Me.Lbtotal.Size = New System.Drawing.Size(9, 12)
        Me.Lbtotal.TabIndex = 128
        Me.Lbtotal.Text = "."
        '
        'Label10
        '
        Me.Label10.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(612, 326)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(140, 12)
        Me.Label10.TabIndex = 127
        Me.Label10.Text = "TOTAL EN MOVIMIENTOS"
        '
        'gridmovi
        '
        Me.gridmovi.AllowDrop = True
        Me.gridmovi.AlternatingBackColor = System.Drawing.Color.Lavender
        Me.gridmovi.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridmovi.BackColor = System.Drawing.Color.WhiteSmoke
        Me.gridmovi.BackgroundColor = System.Drawing.Color.LightGray
        Me.gridmovi.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.gridmovi.CaptionBackColor = System.Drawing.Color.LightSteelBlue
        Me.gridmovi.CaptionForeColor = System.Drawing.Color.MidnightBlue
        Me.gridmovi.DataMember = ""
        Me.gridmovi.FlatMode = True
        Me.gridmovi.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.gridmovi.ForeColor = System.Drawing.Color.MidnightBlue
        Me.gridmovi.GridLineColor = System.Drawing.Color.Gainsboro
        Me.gridmovi.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None
        Me.gridmovi.HeaderBackColor = System.Drawing.Color.MidnightBlue
        Me.gridmovi.HeaderFont = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.gridmovi.HeaderForeColor = System.Drawing.Color.WhiteSmoke
        Me.gridmovi.LinkColor = System.Drawing.Color.Teal
        Me.gridmovi.Location = New System.Drawing.Point(24, 323)
        Me.gridmovi.Name = "gridmovi"
        Me.gridmovi.ParentRowsBackColor = System.Drawing.Color.Gainsboro
        Me.gridmovi.ParentRowsForeColor = System.Drawing.Color.MidnightBlue
        Me.gridmovi.ReadOnly = True
        Me.gridmovi.RowHeadersVisible = False
        Me.gridmovi.RowHeaderWidth = 10
        Me.gridmovi.SelectionBackColor = System.Drawing.Color.CadetBlue
        Me.gridmovi.SelectionForeColor = System.Drawing.Color.WhiteSmoke
        Me.gridmovi.Size = New System.Drawing.Size(812, 110)
        Me.gridmovi.TabIndex = 126
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.CHNUMERO)
        Me.GroupBox3.Controls.Add(Me.CBFAC)
        Me.GroupBox3.Controls.Add(Me.TXTFAC)
        Me.GroupBox3.Location = New System.Drawing.Point(201, 156)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(626, 75)
        Me.GroupBox3.TabIndex = 124
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "NOTA O FACTURA"
        '
        'CHNUMERO
        '
        Me.CHNUMERO.AutoSize = True
        Me.CHNUMERO.Location = New System.Drawing.Point(284, 30)
        Me.CHNUMERO.Name = "CHNUMERO"
        Me.CHNUMERO.Size = New System.Drawing.Size(146, 17)
        Me.CHNUMERO.TabIndex = 17
        Me.CHNUMERO.Text = "ESPECIFICAR NUMERO"
        Me.CHNUMERO.UseVisualStyleBackColor = True
        '
        'CBFAC
        '
        Me.CBFAC.FormattingEnabled = True
        Me.CBFAC.Location = New System.Drawing.Point(56, 24)
        Me.CBFAC.Name = "CBFAC"
        Me.CBFAC.Size = New System.Drawing.Size(130, 21)
        Me.CBFAC.TabIndex = 39
        '
        'TXTFAC
        '
        Me.TXTFAC.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTFAC.Location = New System.Drawing.Point(468, 29)
        Me.TXTFAC.Name = "TXTFAC"
        Me.TXTFAC.Size = New System.Drawing.Size(128, 18)
        Me.TXTFAC.TabIndex = 15
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(211, 127)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(52, 12)
        Me.Label9.TabIndex = 123
        Me.Label9.Text = "FAMILIA"
        '
        'CBFAM
        '
        Me.CBFAM.FormattingEnabled = True
        Me.CBFAM.Location = New System.Drawing.Point(281, 123)
        Me.CBFAM.Name = "CBFAM"
        Me.CBFAM.Size = New System.Drawing.Size(126, 21)
        Me.CBFAM.TabIndex = 122
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(423, 98)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 12)
        Me.Label6.TabIndex = 121
        Me.Label6.Text = "USUARIO"
        '
        'CBUSU
        '
        Me.CBUSU.FormattingEnabled = True
        Me.CBUSU.Location = New System.Drawing.Point(485, 94)
        Me.CBUSU.Name = "CBUSU"
        Me.CBUSU.Size = New System.Drawing.Size(126, 21)
        Me.CBUSU.TabIndex = 120
        '
        'CBPROVE
        '
        Me.CBPROVE.FormattingEnabled = True
        Me.CBPROVE.Location = New System.Drawing.Point(679, 94)
        Me.CBPROVE.Name = "CBPROVE"
        Me.CBPROVE.Size = New System.Drawing.Size(126, 21)
        Me.CBPROVE.TabIndex = 118
        '
        'LBCLIENTE
        '
        Me.LBCLIENTE.AutoSize = True
        Me.LBCLIENTE.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBCLIENTE.Location = New System.Drawing.Point(13, 280)
        Me.LBCLIENTE.Name = "LBCLIENTE"
        Me.LBCLIENTE.Size = New System.Drawing.Size(46, 12)
        Me.LBCLIENTE.TabIndex = 117
        Me.LBCLIENTE.Text = "SALIDA"
        Me.LBCLIENTE.Visible = False
        '
        'CBCLIENTE
        '
        Me.CBCLIENTE.FormattingEnabled = True
        Me.CBCLIENTE.Location = New System.Drawing.Point(69, 276)
        Me.CBCLIENTE.Name = "CBCLIENTE"
        Me.CBCLIENTE.Size = New System.Drawing.Size(126, 21)
        Me.CBCLIENTE.TabIndex = 116
        Me.CBCLIENTE.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.DTFECHAA)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.DTFECHADE)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Location = New System.Drawing.Point(518, 29)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(308, 47)
        Me.GroupBox2.TabIndex = 115
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "FECHA"
        '
        'DTFECHAA
        '
        Me.DTFECHAA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTFECHAA.Location = New System.Drawing.Point(174, 16)
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
        Me.DTFECHADE.Location = New System.Drawing.Point(46, 16)
        Me.DTFECHADE.Name = "DTFECHADE"
        Me.DTFECHADE.Size = New System.Drawing.Size(90, 20)
        Me.DTFECHADE.TabIndex = 23
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(21, 21)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(20, 12)
        Me.Label7.TabIndex = 25
        Me.Label7.Text = "DE"
        '
        'LblDescripcion
        '
        Me.LblDescripcion.AutoSize = True
        Me.LblDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDescripcion.ForeColor = System.Drawing.Color.Blue
        Me.LblDescripcion.Location = New System.Drawing.Point(629, 128)
        Me.LblDescripcion.Name = "LblDescripcion"
        Me.LblDescripcion.Size = New System.Drawing.Size(9, 12)
        Me.LblDescripcion.TabIndex = 114
        Me.LblDescripcion.Text = "."
        '
        'TxtCodigo
        '
        Me.TxtCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCodigo.Location = New System.Drawing.Point(485, 124)
        Me.TxtCodigo.Name = "TxtCodigo"
        Me.TxtCodigo.Size = New System.Drawing.Size(126, 18)
        Me.TxtCodigo.TabIndex = 112
        '
        'TXTCODE
        '
        Me.TXTCODE.AutoSize = True
        Me.TXTCODE.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCODE.Location = New System.Drawing.Point(430, 127)
        Me.TXTCODE.Name = "TXTCODE"
        Me.TXTCODE.Size = New System.Drawing.Size(49, 12)
        Me.TXTCODE.TabIndex = 113
        Me.TXTCODE.Text = "CODIGO"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CheckBox1)
        Me.GroupBox1.Controls.Add(Me.ChBoxUbi)
        Me.GroupBox1.Controls.Add(Me.CHCODE)
        Me.GroupBox1.Controls.Add(Me.CHFAM)
        Me.GroupBox1.Controls.Add(Me.CHUSU)
        Me.GroupBox1.Controls.Add(Me.CHFAC)
        Me.GroupBox1.Controls.Add(Me.CHPROV)
        Me.GroupBox1.Controls.Add(Me.CHCLIENTE)
        Me.GroupBox1.Location = New System.Drawing.Point(24, 82)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(171, 167)
        Me.GroupBox1.TabIndex = 111
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "BUSQUEDA"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(107, 179)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(56, 17)
        Me.CheckBox1.TabIndex = 18
        Me.CheckBox1.Text = "RUTA"
        Me.CheckBox1.UseVisualStyleBackColor = True
        Me.CheckBox1.Visible = False
        '
        'ChBoxUbi
        '
        Me.ChBoxUbi.AutoSize = True
        Me.ChBoxUbi.Location = New System.Drawing.Point(15, 121)
        Me.ChBoxUbi.Name = "ChBoxUbi"
        Me.ChBoxUbi.Size = New System.Drawing.Size(84, 17)
        Me.ChBoxUbi.TabIndex = 17
        Me.ChBoxUbi.Text = "UBICACION"
        Me.ChBoxUbi.UseVisualStyleBackColor = True
        '
        'CHCODE
        '
        Me.CHCODE.AutoSize = True
        Me.CHCODE.Location = New System.Drawing.Point(15, 52)
        Me.CHCODE.Name = "CHCODE"
        Me.CHCODE.Size = New System.Drawing.Size(150, 17)
        Me.CHCODE.TabIndex = 16
        Me.CHCODE.Text = "CODIGO DE PRODUCTO"
        Me.CHCODE.UseVisualStyleBackColor = True
        '
        'CHFAM
        '
        Me.CHFAM.AutoSize = True
        Me.CHFAM.Location = New System.Drawing.Point(15, 142)
        Me.CHFAM.Name = "CHFAM"
        Me.CHFAM.Size = New System.Drawing.Size(67, 17)
        Me.CHFAM.TabIndex = 15
        Me.CHFAM.Text = "FAMILIA"
        Me.CHFAM.UseVisualStyleBackColor = True
        '
        'CHUSU
        '
        Me.CHUSU.AutoSize = True
        Me.CHUSU.Location = New System.Drawing.Point(15, 29)
        Me.CHUSU.Name = "CHUSU"
        Me.CHUSU.Size = New System.Drawing.Size(75, 17)
        Me.CHUSU.TabIndex = 14
        Me.CHUSU.Text = "USUARIO"
        Me.CHUSU.UseVisualStyleBackColor = True
        '
        'CHFAC
        '
        Me.CHFAC.AutoSize = True
        Me.CHFAC.Location = New System.Drawing.Point(15, 75)
        Me.CHFAC.Name = "CHFAC"
        Me.CHFAC.Size = New System.Drawing.Size(120, 17)
        Me.CHFAC.TabIndex = 13
        Me.CHFAC.Text = "NOTA O FACTURA"
        Me.CHFAC.UseVisualStyleBackColor = True
        '
        'CHPROV
        '
        Me.CHPROV.AutoSize = True
        Me.CHPROV.Location = New System.Drawing.Point(15, 98)
        Me.CHPROV.Name = "CHPROV"
        Me.CHPROV.Size = New System.Drawing.Size(94, 17)
        Me.CHPROV.TabIndex = 12
        Me.CHPROV.Text = "PROVEEDOR"
        Me.CHPROV.UseVisualStyleBackColor = True
        '
        'CHCLIENTE
        '
        Me.CHCLIENTE.AutoSize = True
        Me.CHCLIENTE.Enabled = False
        Me.CHCLIENTE.Location = New System.Drawing.Point(107, 155)
        Me.CHCLIENTE.Name = "CHCLIENTE"
        Me.CHCLIENTE.Size = New System.Drawing.Size(64, 17)
        Me.CHCLIENTE.TabIndex = 11
        Me.CHCLIENTE.Text = "SALIDA"
        Me.CHCLIENTE.UseVisualStyleBackColor = True
        Me.CHCLIENTE.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(41, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 12)
        Me.Label1.TabIndex = 132
        Me.Label1.Text = "ALMACEN"
        '
        'Cbalm
        '
        Me.Cbalm.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cbalm.FormattingEnabled = True
        Me.Cbalm.Location = New System.Drawing.Point(39, 47)
        Me.Cbalm.Name = "Cbalm"
        Me.Cbalm.Size = New System.Drawing.Size(132, 20)
        Me.Cbalm.TabIndex = 131
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(620, 98)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 12)
        Me.Label2.TabIndex = 133
        Me.Label2.Text = "PROVEE"
        '
        'GroupBox4
        '
        Me.GroupBox4.Location = New System.Drawing.Point(201, 237)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(310, 60)
        Me.GroupBox4.TabIndex = 125
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "UBICACION"
        Me.GroupBox4.Visible = False
        '
        'CBUBI
        '
        Me.CBUBI.Enabled = False
        Me.CBUBI.FormattingEnabled = True
        Me.CBUBI.Location = New System.Drawing.Point(277, 94)
        Me.CBUBI.Name = "CBUBI"
        Me.CBUBI.Size = New System.Drawing.Size(130, 21)
        Me.CBUBI.TabIndex = 39
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.ComboBox2)
        Me.GroupBox6.Location = New System.Drawing.Point(518, 237)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(308, 60)
        Me.GroupBox6.TabIndex = 126
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "CLIENTE"
        Me.GroupBox6.Visible = False
        '
        'ComboBox2
        '
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(70, 24)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(208, 21)
        Me.ComboBox2.TabIndex = 39
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(205, 98)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 12)
        Me.Label4.TabIndex = 134
        Me.Label4.Text = "UBICACION"
        '
        'frmmov2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(854, 479)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.CBUBI)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Cbalm)
        Me.Controls.Add(Me.LBUSER)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.Lbtotal)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.gridmovi)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.CBFAM)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.CBUSU)
        Me.Controls.Add(Me.CBPROVE)
        Me.Controls.Add(Me.LBCLIENTE)
        Me.Controls.Add(Me.CBCLIENTE)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.LblDescripcion)
        Me.Controls.Add(Me.TxtCodigo)
        Me.Controls.Add(Me.TXTCODE)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TSOpciones)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmmov2"
        Me.Text = "MOVIMIENTOS"
        Me.TSOpciones.ResumeLayout(False)
        Me.TSOpciones.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.gridmovi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TSOpciones As System.Windows.Forms.ToolStrip
    Friend WithEvents TSBSaveNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBSaveExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TSBSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents LBUSER As System.Windows.Forms.LinkLabel
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents CBMOVI As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Lbtotal As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Private WithEvents gridmovi As System.Windows.Forms.DataGrid
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents CHNUMERO As System.Windows.Forms.CheckBox
    Friend WithEvents CBFAC As System.Windows.Forms.ComboBox
    Friend WithEvents TXTFAC As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents CBFAM As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CBUSU As System.Windows.Forms.ComboBox
    Friend WithEvents CBPROVE As System.Windows.Forms.ComboBox
    Friend WithEvents LBCLIENTE As System.Windows.Forms.Label
    Friend WithEvents CBCLIENTE As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents DTFECHAA As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents DTFECHADE As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents LblDescripcion As System.Windows.Forms.Label
    Friend WithEvents TxtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents TXTCODE As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CHCODE As System.Windows.Forms.CheckBox
    Friend WithEvents CHFAM As System.Windows.Forms.CheckBox
    Friend WithEvents CHUSU As System.Windows.Forms.CheckBox
    Friend WithEvents CHFAC As System.Windows.Forms.CheckBox
    Friend WithEvents CHPROV As System.Windows.Forms.CheckBox
    Friend WithEvents CHCLIENTE As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Cbalm As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ChBoxUbi As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents CBUBI As System.Windows.Forms.ComboBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
