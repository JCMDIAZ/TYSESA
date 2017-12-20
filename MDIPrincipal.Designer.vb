<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MDIPrincipal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MDIPrincipal))
        Me.MenuStrip = New System.Windows.Forms.MenuStrip
        Me.MnuArchivo = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuReconexion = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.MnuSalir = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuCatalogos = New System.Windows.Forms.ToolStripMenuItem
        Me.AlmacenesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AsignacionDeRutaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExpendedorasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClientesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ProveedoresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ProductosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RutasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SecundariosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TiposToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.UnidadesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EmpleadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.UsuariosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CategoriasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.UsuariosMovilesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolsMenu = New System.Windows.Forms.ToolStripMenuItem
        Me.EntradasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SalidasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.InventariosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PedidosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RevisarPedidosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.WebServiceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EtiquetasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.UbicacionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AsigarArticulosSINIDToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GuardaFotosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ImprimirBarcodesSINIDToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PedidosToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.WindowsMenu = New System.Windows.Forms.ToolStripMenuItem
        Me.InventariosToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.Movimientos2ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DiferenciasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.BuscarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NoSurtidosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.InventariosToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.ProductosMovsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Movimientos3ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SurtidoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpMenu = New System.Windows.Forms.ToolStripMenuItem
        Me.ContentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ContadorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.BorrarFoliosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.IndexToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SearchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AyudaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Stb = New System.Windows.Forms.StatusStrip
        Me.StbUSER = New System.Windows.Forms.ToolStripStatusLabel
        Me.StbCAT = New System.Windows.Forms.ToolStripStatusLabel
        Me.stbempresa = New System.Windows.Forms.ToolStripStatusLabel
        Me.StbIP = New System.Windows.Forms.ToolStripStatusLabel
        Me.StbDate = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip.SuspendLayout()
        Me.Stb.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.BackColor = System.Drawing.SystemColors.Control
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuArchivo, Me.MnuCatalogos, Me.ToolsMenu, Me.WindowsMenu, Me.HelpMenu, Me.AyudaToolStripMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.MdiWindowListItem = Me.WindowsMenu
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(728, 24)
        Me.MenuStrip.TabIndex = 5
        Me.MenuStrip.Text = "MenuStrip"
        '
        'MnuArchivo
        '
        Me.MnuArchivo.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuReconexion, Me.ToolStripSeparator3, Me.MnuSalir})
        Me.MnuArchivo.ForeColor = System.Drawing.Color.Black
        Me.MnuArchivo.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder
        Me.MnuArchivo.Name = "MnuArchivo"
        Me.MnuArchivo.Size = New System.Drawing.Size(60, 20)
        Me.MnuArchivo.Text = "&Archivo"
        '
        'MnuReconexion
        '
        Me.MnuReconexion.Name = "MnuReconexion"
        Me.MnuReconexion.Size = New System.Drawing.Size(193, 22)
        Me.MnuReconexion.Text = "&Reconexion con Server"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(190, 6)
        '
        'MnuSalir
        '
        Me.MnuSalir.Name = "MnuSalir"
        Me.MnuSalir.Size = New System.Drawing.Size(193, 22)
        Me.MnuSalir.Text = "&Salir"
        '
        'MnuCatalogos
        '
        Me.MnuCatalogos.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AlmacenesToolStripMenuItem, Me.AsignacionDeRutaToolStripMenuItem, Me.ExpendedorasToolStripMenuItem, Me.ClientesToolStripMenuItem, Me.ProveedoresToolStripMenuItem, Me.ProductosToolStripMenuItem, Me.RutasToolStripMenuItem, Me.SecundariosToolStripMenuItem, Me.EmpleadosToolStripMenuItem})
        Me.MnuCatalogos.ForeColor = System.Drawing.Color.Black
        Me.MnuCatalogos.Name = "MnuCatalogos"
        Me.MnuCatalogos.Size = New System.Drawing.Size(72, 20)
        Me.MnuCatalogos.Text = "&Catalogos"
        '
        'AlmacenesToolStripMenuItem
        '
        Me.AlmacenesToolStripMenuItem.Name = "AlmacenesToolStripMenuItem"
        Me.AlmacenesToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.AlmacenesToolStripMenuItem.Text = "&Almacenes"
        '
        'AsignacionDeRutaToolStripMenuItem
        '
        Me.AsignacionDeRutaToolStripMenuItem.Name = "AsignacionDeRutaToolStripMenuItem"
        Me.AsignacionDeRutaToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.AsignacionDeRutaToolStripMenuItem.Text = "As&ignacion de Ruta"
        '
        'ExpendedorasToolStripMenuItem
        '
        Me.ExpendedorasToolStripMenuItem.Name = "ExpendedorasToolStripMenuItem"
        Me.ExpendedorasToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.ExpendedorasToolStripMenuItem.Text = "C&liente Ruta"
        '
        'ClientesToolStripMenuItem
        '
        Me.ClientesToolStripMenuItem.Name = "ClientesToolStripMenuItem"
        Me.ClientesToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.ClientesToolStripMenuItem.Text = "&Clientes"
        '
        'ProveedoresToolStripMenuItem
        '
        Me.ProveedoresToolStripMenuItem.Name = "ProveedoresToolStripMenuItem"
        Me.ProveedoresToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.ProveedoresToolStripMenuItem.Text = "&Proveedores"
        '
        'ProductosToolStripMenuItem
        '
        Me.ProductosToolStripMenuItem.Name = "ProductosToolStripMenuItem"
        Me.ProductosToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.ProductosToolStripMenuItem.Text = "Pro&ductos"
        '
        'RutasToolStripMenuItem
        '
        Me.RutasToolStripMenuItem.Name = "RutasToolStripMenuItem"
        Me.RutasToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.RutasToolStripMenuItem.Text = "&Rutas"
        '
        'SecundariosToolStripMenuItem
        '
        Me.SecundariosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TiposToolStripMenuItem, Me.UnidadesToolStripMenuItem})
        Me.SecundariosToolStripMenuItem.Name = "SecundariosToolStripMenuItem"
        Me.SecundariosToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.SecundariosToolStripMenuItem.Text = "&Secundarios"
        '
        'TiposToolStripMenuItem
        '
        Me.TiposToolStripMenuItem.Name = "TiposToolStripMenuItem"
        Me.TiposToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.TiposToolStripMenuItem.Text = "&Familias"
        '
        'UnidadesToolStripMenuItem
        '
        Me.UnidadesToolStripMenuItem.Name = "UnidadesToolStripMenuItem"
        Me.UnidadesToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.UnidadesToolStripMenuItem.Text = "&Unidades de Medida"
        '
        'EmpleadosToolStripMenuItem
        '
        Me.EmpleadosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UsuariosToolStripMenuItem, Me.CategoriasToolStripMenuItem, Me.UsuariosMovilesToolStripMenuItem})
        Me.EmpleadosToolStripMenuItem.Name = "EmpleadosToolStripMenuItem"
        Me.EmpleadosToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.EmpleadosToolStripMenuItem.Text = "&Usuarios"
        '
        'UsuariosToolStripMenuItem
        '
        Me.UsuariosToolStripMenuItem.Name = "UsuariosToolStripMenuItem"
        Me.UsuariosToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.UsuariosToolStripMenuItem.Text = "&Usuarios de Sistema"
        '
        'CategoriasToolStripMenuItem
        '
        Me.CategoriasToolStripMenuItem.Name = "CategoriasToolStripMenuItem"
        Me.CategoriasToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.CategoriasToolStripMenuItem.Text = "&Categorias"
        '
        'UsuariosMovilesToolStripMenuItem
        '
        Me.UsuariosMovilesToolStripMenuItem.Name = "UsuariosMovilesToolStripMenuItem"
        Me.UsuariosMovilesToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.UsuariosMovilesToolStripMenuItem.Text = "Choferes"
        '
        'ToolsMenu
        '
        Me.ToolsMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EntradasToolStripMenuItem, Me.SalidasToolStripMenuItem, Me.InventariosToolStripMenuItem, Me.PedidosToolStripMenuItem, Me.WebServiceToolStripMenuItem, Me.EtiquetasToolStripMenuItem, Me.UbicacionesToolStripMenuItem, Me.AsigarArticulosSINIDToolStripMenuItem, Me.GuardaFotosToolStripMenuItem, Me.ImprimirBarcodesSINIDToolStripMenuItem, Me.PedidosToolStripMenuItem1})
        Me.ToolsMenu.ForeColor = System.Drawing.Color.Black
        Me.ToolsMenu.Name = "ToolsMenu"
        Me.ToolsMenu.Size = New System.Drawing.Size(74, 20)
        Me.ToolsMenu.Text = "&Operacion"
        '
        'EntradasToolStripMenuItem
        '
        Me.EntradasToolStripMenuItem.Name = "EntradasToolStripMenuItem"
        Me.EntradasToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.EntradasToolStripMenuItem.Text = "&Entradas"
        Me.EntradasToolStripMenuItem.Visible = False
        '
        'SalidasToolStripMenuItem
        '
        Me.SalidasToolStripMenuItem.Name = "SalidasToolStripMenuItem"
        Me.SalidasToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.SalidasToolStripMenuItem.Text = "&Salidas"
        Me.SalidasToolStripMenuItem.Visible = False
        '
        'InventariosToolStripMenuItem
        '
        Me.InventariosToolStripMenuItem.Name = "InventariosToolStripMenuItem"
        Me.InventariosToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.InventariosToolStripMenuItem.Text = "&Inventarios"
        Me.InventariosToolStripMenuItem.Visible = False
        '
        'PedidosToolStripMenuItem
        '
        Me.PedidosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RevisarPedidosToolStripMenuItem})
        Me.PedidosToolStripMenuItem.Name = "PedidosToolStripMenuItem"
        Me.PedidosToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.PedidosToolStripMenuItem.Text = "&Reparar Recargas"
        '
        'RevisarPedidosToolStripMenuItem
        '
        Me.RevisarPedidosToolStripMenuItem.Enabled = False
        Me.RevisarPedidosToolStripMenuItem.Name = "RevisarPedidosToolStripMenuItem"
        Me.RevisarPedidosToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.RevisarPedidosToolStripMenuItem.Text = "Revisar Pedidos"
        Me.RevisarPedidosToolStripMenuItem.Visible = False
        '
        'WebServiceToolStripMenuItem
        '
        Me.WebServiceToolStripMenuItem.Name = "WebServiceToolStripMenuItem"
        Me.WebServiceToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.WebServiceToolStripMenuItem.Text = "&Conexion MySQL"
        Me.WebServiceToolStripMenuItem.Visible = False
        '
        'EtiquetasToolStripMenuItem
        '
        Me.EtiquetasToolStripMenuItem.Name = "EtiquetasToolStripMenuItem"
        Me.EtiquetasToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.EtiquetasToolStripMenuItem.Text = "&Venta"
        Me.EtiquetasToolStripMenuItem.Visible = False
        '
        'UbicacionesToolStripMenuItem
        '
        Me.UbicacionesToolStripMenuItem.Name = "UbicacionesToolStripMenuItem"
        Me.UbicacionesToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.UbicacionesToolStripMenuItem.Text = "&Ubicaciones"
        Me.UbicacionesToolStripMenuItem.Visible = False
        '
        'AsigarArticulosSINIDToolStripMenuItem
        '
        Me.AsigarArticulosSINIDToolStripMenuItem.Name = "AsigarArticulosSINIDToolStripMenuItem"
        Me.AsigarArticulosSINIDToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.AsigarArticulosSINIDToolStripMenuItem.Text = "Asigar Articulos SIN I&D"
        Me.AsigarArticulosSINIDToolStripMenuItem.Visible = False
        '
        'GuardaFotosToolStripMenuItem
        '
        Me.GuardaFotosToolStripMenuItem.Name = "GuardaFotosToolStripMenuItem"
        Me.GuardaFotosToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.GuardaFotosToolStripMenuItem.Text = "&GuardaFotos"
        Me.GuardaFotosToolStripMenuItem.Visible = False
        '
        'ImprimirBarcodesSINIDToolStripMenuItem
        '
        Me.ImprimirBarcodesSINIDToolStripMenuItem.Name = "ImprimirBarcodesSINIDToolStripMenuItem"
        Me.ImprimirBarcodesSINIDToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.ImprimirBarcodesSINIDToolStripMenuItem.Text = "Imprimir Barcodes SIN ID"
        Me.ImprimirBarcodesSINIDToolStripMenuItem.Visible = False
        '
        'PedidosToolStripMenuItem1
        '
        Me.PedidosToolStripMenuItem1.Name = "PedidosToolStripMenuItem1"
        Me.PedidosToolStripMenuItem1.Size = New System.Drawing.Size(206, 22)
        Me.PedidosToolStripMenuItem1.Text = "&Pedidos"
        Me.PedidosToolStripMenuItem1.Visible = False
        '
        'WindowsMenu
        '
        Me.WindowsMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InventariosToolStripMenuItem1, Me.Movimientos2ToolStripMenuItem, Me.DiferenciasToolStripMenuItem, Me.InventariosToolStripMenuItem2, Me.ProductosMovsToolStripMenuItem, Me.Movimientos3ToolStripMenuItem, Me.SurtidoToolStripMenuItem})
        Me.WindowsMenu.ForeColor = System.Drawing.Color.Black
        Me.WindowsMenu.Name = "WindowsMenu"
        Me.WindowsMenu.Size = New System.Drawing.Size(130, 20)
        Me.WindowsMenu.Text = "&Reportes Y Consultas"
        '
        'InventariosToolStripMenuItem1
        '
        Me.InventariosToolStripMenuItem1.Name = "InventariosToolStripMenuItem1"
        Me.InventariosToolStripMenuItem1.Size = New System.Drawing.Size(172, 22)
        Me.InventariosToolStripMenuItem1.Text = "&Movimientos ALM"
        Me.InventariosToolStripMenuItem1.Visible = False
        '
        'Movimientos2ToolStripMenuItem
        '
        Me.Movimientos2ToolStripMenuItem.Name = "Movimientos2ToolStripMenuItem"
        Me.Movimientos2ToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.Movimientos2ToolStripMenuItem.Text = "Movimientos"
        '
        'DiferenciasToolStripMenuItem
        '
        Me.DiferenciasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BuscarToolStripMenuItem, Me.NoSurtidosToolStripMenuItem})
        Me.DiferenciasToolStripMenuItem.Name = "DiferenciasToolStripMenuItem"
        Me.DiferenciasToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.DiferenciasToolStripMenuItem.Text = "&Pedidos"
        Me.DiferenciasToolStripMenuItem.Visible = False
        '
        'BuscarToolStripMenuItem
        '
        Me.BuscarToolStripMenuItem.Name = "BuscarToolStripMenuItem"
        Me.BuscarToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.BuscarToolStripMenuItem.Text = "&Buscar"
        Me.BuscarToolStripMenuItem.Visible = False
        '
        'NoSurtidosToolStripMenuItem
        '
        Me.NoSurtidosToolStripMenuItem.Enabled = False
        Me.NoSurtidosToolStripMenuItem.Name = "NoSurtidosToolStripMenuItem"
        Me.NoSurtidosToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.NoSurtidosToolStripMenuItem.Text = "&Pendientes"
        '
        'InventariosToolStripMenuItem2
        '
        Me.InventariosToolStripMenuItem2.Name = "InventariosToolStripMenuItem2"
        Me.InventariosToolStripMenuItem2.Size = New System.Drawing.Size(172, 22)
        Me.InventariosToolStripMenuItem2.Text = "&Reporte del Dia"
        '
        'ProductosMovsToolStripMenuItem
        '
        Me.ProductosMovsToolStripMenuItem.DoubleClickEnabled = True
        Me.ProductosMovsToolStripMenuItem.Name = "ProductosMovsToolStripMenuItem"
        Me.ProductosMovsToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.ProductosMovsToolStripMenuItem.Text = "Productos Movs"
        Me.ProductosMovsToolStripMenuItem.Visible = False
        '
        'Movimientos3ToolStripMenuItem
        '
        Me.Movimientos3ToolStripMenuItem.Name = "Movimientos3ToolStripMenuItem"
        Me.Movimientos3ToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.Movimientos3ToolStripMenuItem.Text = "&Reportes"
        Me.Movimientos3ToolStripMenuItem.Visible = False
        '
        'SurtidoToolStripMenuItem
        '
        Me.SurtidoToolStripMenuItem.Name = "SurtidoToolStripMenuItem"
        Me.SurtidoToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.SurtidoToolStripMenuItem.Text = "S&urtido-Ruta"
        '
        'HelpMenu
        '
        Me.HelpMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ContentsToolStripMenuItem, Me.ContadorToolStripMenuItem, Me.BorrarFoliosToolStripMenuItem, Me.IndexToolStripMenuItem, Me.SearchToolStripMenuItem, Me.ToolStripSeparator8, Me.AboutToolStripMenuItem})
        Me.HelpMenu.ForeColor = System.Drawing.Color.Black
        Me.HelpMenu.Name = "HelpMenu"
        Me.HelpMenu.Size = New System.Drawing.Size(61, 20)
        Me.HelpMenu.Text = "&Utilerias"
        '
        'ContentsToolStripMenuItem
        '
        Me.ContentsToolStripMenuItem.Name = "ContentsToolStripMenuItem"
        Me.ContentsToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.ContentsToolStripMenuItem.Text = "&Configuracion"
        Me.ContentsToolStripMenuItem.Visible = False
        '
        'ContadorToolStripMenuItem
        '
        Me.ContadorToolStripMenuItem.Name = "ContadorToolStripMenuItem"
        Me.ContadorToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.ContadorToolStripMenuItem.Text = "Impresiones"
        '
        'BorrarFoliosToolStripMenuItem
        '
        Me.BorrarFoliosToolStripMenuItem.Name = "BorrarFoliosToolStripMenuItem"
        Me.BorrarFoliosToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.BorrarFoliosToolStripMenuItem.Text = "Borrar Folios"
        Me.BorrarFoliosToolStripMenuItem.Visible = False
        '
        'IndexToolStripMenuItem
        '
        Me.IndexToolStripMenuItem.Image = CType(resources.GetObject("IndexToolStripMenuItem.Image"), System.Drawing.Image)
        Me.IndexToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black
        Me.IndexToolStripMenuItem.Name = "IndexToolStripMenuItem"
        Me.IndexToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.IndexToolStripMenuItem.Text = "&Índice"
        Me.IndexToolStripMenuItem.Visible = False
        '
        'SearchToolStripMenuItem
        '
        Me.SearchToolStripMenuItem.Image = CType(resources.GetObject("SearchToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SearchToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black
        Me.SearchToolStripMenuItem.Name = "SearchToolStripMenuItem"
        Me.SearchToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.SearchToolStripMenuItem.Text = "&Buscar"
        Me.SearchToolStripMenuItem.Visible = False
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(147, 6)
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.AboutToolStripMenuItem.Text = "&Acerca de..."
        Me.AboutToolStripMenuItem.Visible = False
        '
        'AyudaToolStripMenuItem
        '
        Me.AyudaToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.AyudaToolStripMenuItem.Name = "AyudaToolStripMenuItem"
        Me.AyudaToolStripMenuItem.Size = New System.Drawing.Size(53, 20)
        Me.AyudaToolStripMenuItem.Text = "A&yuda"
        Me.AyudaToolStripMenuItem.Visible = False
        '
        'Stb
        '
        Me.Stb.BackColor = System.Drawing.SystemColors.Control
        Me.Stb.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StbUSER, Me.StbCAT, Me.stbempresa, Me.StbIP, Me.StbDate})
        Me.Stb.Location = New System.Drawing.Point(0, 422)
        Me.Stb.Name = "Stb"
        Me.Stb.Padding = New System.Windows.Forms.Padding(2, 0, 14, 0)
        Me.Stb.Size = New System.Drawing.Size(728, 22)
        Me.Stb.TabIndex = 7
        Me.Stb.Text = "StatusStrip"
        '
        'StbUSER
        '
        Me.StbUSER.ForeColor = System.Drawing.Color.Black
        Me.StbUSER.Name = "StbUSER"
        Me.StbUSER.Size = New System.Drawing.Size(42, 17)
        Me.StbUSER.Text = "Estado"
        '
        'StbCAT
        '
        Me.StbCAT.ForeColor = System.Drawing.Color.Black
        Me.StbCAT.Name = "StbCAT"
        Me.StbCAT.Size = New System.Drawing.Size(58, 17)
        Me.StbCAT.Text = "Categoria"
        '
        'stbempresa
        '
        Me.stbempresa.ForeColor = System.Drawing.Color.Black
        Me.stbempresa.Name = "stbempresa"
        Me.stbempresa.Size = New System.Drawing.Size(52, 17)
        Me.stbempresa.Text = "Empresa"
        '
        'StbIP
        '
        Me.StbIP.ForeColor = System.Drawing.Color.Black
        Me.StbIP.Name = "StbIP"
        Me.StbIP.Size = New System.Drawing.Size(17, 17)
        Me.StbIP.Text = "IP"
        '
        'StbDate
        '
        Me.StbDate.ForeColor = System.Drawing.Color.Black
        Me.StbDate.Name = "StbDate"
        Me.StbDate.Size = New System.Drawing.Size(38, 17)
        Me.StbDate.Text = "Fecha"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1080
        '
        'MDIPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.VisionTec.My.Resources.Resources._2561
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(728, 444)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.Stb)
        Me.DoubleBuffered = True
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip
        Me.Name = "MDIPrincipal"
        Me.Text = "Control de Almacen"
        Me.TransparencyKey = System.Drawing.Color.White
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.Stb.ResumeLayout(False)
        Me.Stb.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ContentsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IndexToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SearchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WindowsMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents StbUSER As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Stb As System.Windows.Forms.StatusStrip
    Friend WithEvents MnuSalir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuArchivo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents MnuCatalogos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolsMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuReconexion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents EmpleadosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SecundariosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TiposToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UnidadesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AyudaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClientesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AlmacenesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProveedoresToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProductosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SalidasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InventariosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InventariosToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DiferenciasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InventariosToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PedidosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BuscarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NoSurtidosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContadorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RevisarPedidosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProductosMovsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CategoriasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EntradasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Movimientos2ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BorrarFoliosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Movimientos3ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StbCAT As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents stbempresa As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StbIP As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StbDate As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents WebServiceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EtiquetasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UbicacionesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AsigarArticulosSINIDToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GuardaFotosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImprimirBarcodesSINIDToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RutasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UsuariosMovilesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AsignacionDeRutaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExpendedorasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UsuariosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SurtidoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PedidosToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem

End Class
