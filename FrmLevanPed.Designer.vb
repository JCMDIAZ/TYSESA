<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLevanPed
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLevanPed))
        Me.DGDETALLE = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.LblArticulos = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.LBLTOTART = New System.Windows.Forms.Label
        Me.LBLTTOTALART = New System.Windows.Forms.Label
        Me.LblTRuta = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.LblRuta = New System.Windows.Forms.Label
        Me.lbltotal = New System.Windows.Forms.Label
        Me.BtnBorrarPro = New System.Windows.Forms.Button
        Me.BtnAgregaPedido = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.LblProducto = New System.Windows.Forms.Label
        Me.TxtProd = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DTPFaSurtir = New System.Windows.Forms.DateTimePicker
        Me.TBoxBuscaCod = New System.Windows.Forms.TextBox
        Me.TBoxBuscaAlter = New System.Windows.Forms.TextBox
        Me.TBoxBuscaDescrip = New System.Windows.Forms.TextBox
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.DGPROD = New System.Windows.Forms.DataGridView
        Me.cbCliente = New System.Windows.Forms.ComboBox
        Me.txtCantidad = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtFolioPed = New System.Windows.Forms.TextBox
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.TSOpciones = New System.Windows.Forms.ToolStrip
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.TSBSaveExit = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton
        CType(Me.DGDETALLE, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DGPROD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TSOpciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'DGDETALLE
        '
        Me.DGDETALLE.AllowUserToAddRows = False
        Me.DGDETALLE.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.NullValue = "NA"
        Me.DGDETALLE.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DGDETALLE.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DGDETALLE.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.DGDETALLE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGDETALLE.Location = New System.Drawing.Point(537, 42)
        Me.DGDETALLE.Name = "DGDETALLE"
        Me.DGDETALLE.ReadOnly = True
        Me.DGDETALLE.RowHeadersWidth = 20
        Me.DGDETALLE.RowTemplate.Height = 24
        Me.DGDETALLE.Size = New System.Drawing.Size(564, 307)
        Me.DGDETALLE.TabIndex = 33
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TBoxBuscaCod)
        Me.GroupBox1.Controls.Add(Me.TBoxBuscaAlter)
        Me.GroupBox1.Controls.Add(Me.TBoxBuscaDescrip)
        Me.GroupBox1.Controls.Add(Me.LblArticulos)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.LBLTOTART)
        Me.GroupBox1.Controls.Add(Me.LBLTTOTALART)
        Me.GroupBox1.Controls.Add(Me.LblTRuta)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.LblRuta)
        Me.GroupBox1.Controls.Add(Me.lbltotal)
        Me.GroupBox1.Controls.Add(Me.BtnBorrarPro)
        Me.GroupBox1.Controls.Add(Me.BtnAgregaPedido)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.LblProducto)
        Me.GroupBox1.Controls.Add(Me.TxtProd)
        Me.GroupBox1.Controls.Add(Me.DGDETALLE)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.DTPFaSurtir)
        Me.GroupBox1.Controls.Add(Me.LinkLabel1)
        Me.GroupBox1.Controls.Add(Me.DGPROD)
        Me.GroupBox1.Controls.Add(Me.cbCliente)
        Me.GroupBox1.Controls.Add(Me.txtCantidad)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtFolioPed)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1121, 376)
        Me.GroupBox1.TabIndex = 35
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Pedidos a Rutas"
        '
        'LblArticulos
        '
        Me.LblArticulos.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.LblArticulos.ForeColor = System.Drawing.Color.DodgerBlue
        Me.LblArticulos.Location = New System.Drawing.Point(617, 352)
        Me.LblArticulos.Name = "LblArticulos"
        Me.LblArticulos.Size = New System.Drawing.Size(43, 12)
        Me.LblArticulos.TabIndex = 65
        Me.LblArticulos.Text = "0"
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(534, 352)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(92, 13)
        Me.Label7.TabIndex = 64
        Me.Label7.Text = "No. de Articulos:"
        '
        'LBLTOTART
        '
        Me.LBLTOTART.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.LBLTOTART.ForeColor = System.Drawing.Color.Black
        Me.LBLTOTART.Location = New System.Drawing.Point(879, 353)
        Me.LBLTOTART.Name = "LBLTOTART"
        Me.LBLTOTART.Size = New System.Drawing.Size(92, 13)
        Me.LBLTOTART.TabIndex = 43
        Me.LBLTOTART.Text = "Total de Articulos:"
        '
        'LBLTTOTALART
        '
        Me.LBLTTOTALART.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.LBLTTOTALART.ForeColor = System.Drawing.Color.DodgerBlue
        Me.LBLTTOTALART.Location = New System.Drawing.Point(970, 353)
        Me.LBLTTOTALART.Name = "LBLTTOTALART"
        Me.LBLTTOTALART.Size = New System.Drawing.Size(43, 12)
        Me.LBLTTOTALART.TabIndex = 44
        Me.LBLTTOTALART.Text = "0"
        '
        'LblTRuta
        '
        Me.LblTRuta.AutoSize = True
        Me.LblTRuta.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTRuta.ForeColor = System.Drawing.Color.Olive
        Me.LblTRuta.Location = New System.Drawing.Point(339, 60)
        Me.LblTRuta.Name = "LblTRuta"
        Me.LblTRuta.Size = New System.Drawing.Size(56, 12)
        Me.LblTRuta.TabIndex = 63
        Me.LblTRuta.Text = "NO TIENE"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(1017, 353)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 13)
        Me.Label6.TabIndex = 45
        Me.Label6.Text = "Total:"
        '
        'LblRuta
        '
        Me.LblRuta.AutoSize = True
        Me.LblRuta.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRuta.ForeColor = System.Drawing.Color.Olive
        Me.LblRuta.Location = New System.Drawing.Point(299, 60)
        Me.LblRuta.Name = "LblRuta"
        Me.LblRuta.Size = New System.Drawing.Size(39, 12)
        Me.LblRuta.TabIndex = 62
        Me.LblRuta.Text = "RUTA:"
        '
        'lbltotal
        '
        Me.lbltotal.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.lbltotal.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lbltotal.Location = New System.Drawing.Point(1047, 353)
        Me.lbltotal.Name = "lbltotal"
        Me.lbltotal.Size = New System.Drawing.Size(43, 12)
        Me.lbltotal.TabIndex = 46
        Me.lbltotal.Text = "0"
        '
        'BtnBorrarPro
        '
        Me.BtnBorrarPro.BackColor = System.Drawing.Color.LightSteelBlue
        Me.BtnBorrarPro.Enabled = False
        Me.BtnBorrarPro.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnBorrarPro.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBorrarPro.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnBorrarPro.Location = New System.Drawing.Point(984, 13)
        Me.BtnBorrarPro.Name = "BtnBorrarPro"
        Me.BtnBorrarPro.Size = New System.Drawing.Size(117, 26)
        Me.BtnBorrarPro.TabIndex = 61
        Me.BtnBorrarPro.Text = "Borrar Producto"
        Me.BtnBorrarPro.UseVisualStyleBackColor = False
        '
        'BtnAgregaPedido
        '
        Me.BtnAgregaPedido.BackColor = System.Drawing.Color.DarkKhaki
        Me.BtnAgregaPedido.Enabled = False
        Me.BtnAgregaPedido.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnAgregaPedido.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAgregaPedido.Location = New System.Drawing.Point(400, 128)
        Me.BtnAgregaPedido.Name = "BtnAgregaPedido"
        Me.BtnAgregaPedido.Size = New System.Drawing.Size(117, 26)
        Me.BtnAgregaPedido.TabIndex = 60
        Me.BtnAgregaPedido.Text = "Agregar a Pedido"
        Me.BtnAgregaPedido.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(564, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 12)
        Me.Label3.TabIndex = 59
        Me.Label3.Text = "Detalle del Pedido:"
        '
        'LblProducto
        '
        Me.LblProducto.AutoSize = True
        Me.LblProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblProducto.Location = New System.Drawing.Point(18, 112)
        Me.LblProducto.Name = "LblProducto"
        Me.LblProducto.Size = New System.Drawing.Size(54, 12)
        Me.LblProducto.TabIndex = 58
        Me.LblProducto.Text = "Producto:"
        '
        'TxtProd
        '
        Me.TxtProd.Enabled = False
        Me.TxtProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtProd.Location = New System.Drawing.Point(74, 109)
        Me.TxtProd.MaxLength = 15
        Me.TxtProd.Name = "TxtProd"
        Me.TxtProd.Size = New System.Drawing.Size(282, 18)
        Me.TxtProd.TabIndex = 57
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(135, 151)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(54, 12)
        Me.Label18.TabIndex = 56
        Me.Label18.Text = "Descripcion"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(77, 151)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(35, 12)
        Me.Label16.TabIndex = 55
        Me.Label16.Text = "Alterno"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(19, 151)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(34, 12)
        Me.Label13.TabIndex = 54
        Me.Label13.Text = "Codigo"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(408, 112)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 12)
        Me.Label2.TabIndex = 53
        Me.Label2.Text = "Cantidad:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(38, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 12)
        Me.Label1.TabIndex = 52
        Me.Label1.Text = "Folio:"
        '
        'DTPFaSurtir
        '
        Me.DTPFaSurtir.CustomFormat = "dd/MM/yyyy"
        Me.DTPFaSurtir.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPFaSurtir.Location = New System.Drawing.Point(433, 21)
        Me.DTPFaSurtir.Name = "DTPFaSurtir"
        Me.DTPFaSurtir.Size = New System.Drawing.Size(84, 20)
        Me.DTPFaSurtir.TabIndex = 51
        Me.DTPFaSurtir.Value = New Date(2017, 3, 3, 12, 1, 10, 0)
        '
        'TBoxBuscaCod
        '
        Me.TBoxBuscaCod.Location = New System.Drawing.Point(19, 163)
        Me.TBoxBuscaCod.Name = "TBoxBuscaCod"
        Me.TBoxBuscaCod.Size = New System.Drawing.Size(51, 20)
        Me.TBoxBuscaCod.TabIndex = 50
        '
        'TBoxBuscaAlter
        '
        Me.TBoxBuscaAlter.Location = New System.Drawing.Point(77, 163)
        Me.TBoxBuscaAlter.Name = "TBoxBuscaAlter"
        Me.TBoxBuscaAlter.Size = New System.Drawing.Size(51, 20)
        Me.TBoxBuscaAlter.TabIndex = 49
        '
        'TBoxBuscaDescrip
        '
        Me.TBoxBuscaDescrip.Location = New System.Drawing.Point(135, 163)
        Me.TBoxBuscaDescrip.Name = "TBoxBuscaDescrip"
        Me.TBoxBuscaDescrip.Size = New System.Drawing.Size(130, 20)
        Me.TBoxBuscaDescrip.TabIndex = 48
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.LinkLabel1.Location = New System.Drawing.Point(271, 166)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(107, 13)
        Me.LinkLabel1.TabIndex = 47
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "BUSCA PRODUCTO"
        '
        'DGPROD
        '
        Me.DGPROD.AllowUserToAddRows = False
        Me.DGPROD.AllowUserToDeleteRows = False
        DataGridViewCellStyle2.NullValue = "NA"
        Me.DGPROD.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.DGPROD.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DGPROD.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.DGPROD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGPROD.Location = New System.Drawing.Point(16, 189)
        Me.DGPROD.MultiSelect = False
        Me.DGPROD.Name = "DGPROD"
        Me.DGPROD.ReadOnly = True
        Me.DGPROD.RowHeadersWidth = 20
        Me.DGPROD.RowTemplate.Height = 28
        Me.DGPROD.Size = New System.Drawing.Size(501, 160)
        Me.DGPROD.TabIndex = 46
        '
        'cbCliente
        '
        Me.cbCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCliente.FormattingEnabled = True
        Me.cbCliente.Location = New System.Drawing.Point(74, 57)
        Me.cbCliente.Margin = New System.Windows.Forms.Padding(2)
        Me.cbCliente.Name = "cbCliente"
        Me.cbCliente.Size = New System.Drawing.Size(218, 20)
        Me.cbCliente.TabIndex = 1
        '
        'txtCantidad
        '
        Me.txtCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidad.Location = New System.Drawing.Point(468, 109)
        Me.txtCantidad.MaxLength = 15
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(47, 18)
        Me.txtCantidad.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(351, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 12)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Fecha a Surtir:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(26, 60)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 12)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Cliente"
        '
        'txtFolioPed
        '
        Me.txtFolioPed.Enabled = False
        Me.txtFolioPed.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtFolioPed.Location = New System.Drawing.Point(74, 24)
        Me.txtFolioPed.MaxLength = 15
        Me.txtFolioPed.Name = "txtFolioPed"
        Me.txtFolioPed.Size = New System.Drawing.Size(58, 20)
        Me.txtFolioPed.TabIndex = 4
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'TSOpciones
        '
        Me.TSOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton2, Me.ToolStripSeparator2, Me.TSBSaveExit, Me.ToolStripSeparator3, Me.ToolStripButton3, Me.ToolStripSeparator4, Me.ToolStripButton4, Me.ToolStripSeparator1, Me.ToolStripButton5})
        Me.TSOpciones.Location = New System.Drawing.Point(0, 0)
        Me.TSOpciones.Name = "TSOpciones"
        Me.TSOpciones.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.TSOpciones.Size = New System.Drawing.Size(1136, 25)
        Me.TSOpciones.TabIndex = 38
        Me.TSOpciones.Text = "ToolStrip1"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton2.Image = Global.VisionTec.My.Resources.Resources.save
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(76, 22)
        Me.ToolStripButton2.Text = "GUARDAR"
        Me.ToolStripButton2.ToolTipText = "Guardar y Nuevo"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'TSBSaveExit
        '
        Me.TSBSaveExit.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TSBSaveExit.Image = Global.VisionTec.My.Resources.Resources.remove_from_database1
        Me.TSBSaveExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBSaveExit.Name = "TSBSaveExit"
        Me.TSBSaveExit.Size = New System.Drawing.Size(81, 22)
        Me.TSBSaveExit.Text = "CANCELAR"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
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
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton4.Image = Global.VisionTec.My.Resources.Resources._1366681757_print
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(79, 22)
        Me.ToolStripButton4.Text = "IMPRIMIR"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton5.Image = Global.VisionTec.My.Resources.Resources.delete
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(57, 22)
        Me.ToolStripButton5.Text = "SALIR"
        '
        'FrmLevanPed
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1136, 416)
        Me.Controls.Add(Me.TSOpciones)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmLevanPed"
        Me.Text = "Levanta Pedidos"
        CType(Me.DGDETALLE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DGPROD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TSOpciones.ResumeLayout(False)
        Me.TSOpciones.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DGDETALLE As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cbCliente As System.Windows.Forms.ComboBox
    Friend WithEvents txtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtFolioPed As System.Windows.Forms.TextBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents TSOpciones As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TSBSaveExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents DTPFaSurtir As System.Windows.Forms.DateTimePicker
    Friend WithEvents TBoxBuscaCod As System.Windows.Forms.TextBox
    Friend WithEvents TBoxBuscaAlter As System.Windows.Forms.TextBox
    Friend WithEvents TBoxBuscaDescrip As System.Windows.Forms.TextBox
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents DGPROD As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents LblProducto As System.Windows.Forms.Label
    Friend WithEvents TxtProd As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BtnAgregaPedido As System.Windows.Forms.Button
    Friend WithEvents BtnBorrarPro As System.Windows.Forms.Button
    Friend WithEvents LblRuta As System.Windows.Forms.Label
    Friend WithEvents LblTRuta As System.Windows.Forms.Label
    Friend WithEvents LBLTOTART As System.Windows.Forms.Label
    Friend WithEvents LBLTTOTALART As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lbltotal As System.Windows.Forms.Label
    Friend WithEvents LblArticulos As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
