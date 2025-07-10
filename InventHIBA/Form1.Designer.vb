<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tabInventario = New System.Windows.Forms.TabPage()
        Me.lblResultados = New System.Windows.Forms.Label()
        Me.cmbTipoInventario = New System.Windows.Forms.ComboBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.dgvInventario = New System.Windows.Forms.DataGridView()
        Me.txtNombreInventario = New System.Windows.Forms.TextBox()
        Me.txtCantidadInventario = New System.Windows.Forms.TextBox()
        Me.txtCodigoInventario = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tabEntradas = New System.Windows.Forms.TabPage()
        Me.txtFactura = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtOC = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.txtPU = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtLoteEntradas = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtOPEntradas = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtComentariosEntradas = New System.Windows.Forms.RichTextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtFolioEntradas = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dtpFechaEntradas = New System.Windows.Forms.DateTimePicker()
        Me.cmbUnidadEntrada = New System.Windows.Forms.ComboBox()
        Me.txtCantidadStockEntradas = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtCantidadEntradas = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtProveedorEntradas = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtNombreEntradas = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dgvEntradas = New System.Windows.Forms.DataGridView()
        Me.txtCodigoEntradas = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tabSalidas = New System.Windows.Forms.TabPage()
        Me.txtLoteSalidas = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtOPSalidas = New System.Windows.Forms.TextBox()
        Me.txtComentariosSalidas = New System.Windows.Forms.RichTextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtFolioSalidas = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.dtpFechaSalidas = New System.Windows.Forms.DateTimePicker()
        Me.cmbUnidadSalidas = New System.Windows.Forms.ComboBox()
        Me.txtCantidadStockSalidas = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtCantidadSalidas = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtDestinoSalidas = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtNombreSalidas = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.dgvSalidas = New System.Windows.Forms.DataGridView()
        Me.txtCodigoSalidas = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.tabRepMen = New System.Windows.Forms.TabPage()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.dtpFinal = New System.Windows.Forms.DateTimePicker()
        Me.dtpInicio = New System.Windows.Forms.DateTimePicker()
        Me.dgvReporteSalidas = New System.Windows.Forms.DataGridView()
        Me.dgvReporte = New System.Windows.Forms.DataGridView()
        Me.tabRepEsp = New System.Windows.Forms.TabPage()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.dgvReporteSalidasEsp = New System.Windows.Forms.DataGridView()
        Me.dgvReporteEntradasEsp = New System.Windows.Forms.DataGridView()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.btnImprimirInv = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnEliminarInventario = New System.Windows.Forms.Button()
        Me.btnEditarInventario = New System.Windows.Forms.Button()
        Me.btnLimpiarInventario = New System.Windows.Forms.Button()
        Me.btnBuscarInventario = New System.Windows.Forms.Button()
        Me.btnGuardarInventario = New System.Windows.Forms.Button()
        Me.btnReportarEntrada = New System.Windows.Forms.Button()
        Me.btnEliminarEntradas = New System.Windows.Forms.Button()
        Me.btnLimpiarEntradas = New System.Windows.Forms.Button()
        Me.btnBuscarEntradas = New System.Windows.Forms.Button()
        Me.btnGuardarEntradas = New System.Windows.Forms.Button()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.btnReportarSalidas = New System.Windows.Forms.Button()
        Me.btnEliminarSalidas = New System.Windows.Forms.Button()
        Me.btnLimpiarSalidas = New System.Windows.Forms.Button()
        Me.btnBuscarSalidas = New System.Windows.Forms.Button()
        Me.btnGuardarSalidas = New System.Windows.Forms.Button()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.btnReportarMesSalidas = New System.Windows.Forms.Button()
        Me.btnReportarMesEntradas = New System.Windows.Forms.Button()
        Me.btnLimpiarReporteMensual = New System.Windows.Forms.Button()
        Me.btnRango = New System.Windows.Forms.Button()
        Me.btnImprimirMensual = New System.Windows.Forms.Button()
        Me.btnLimpiarReporteEspecifico = New System.Windows.Forms.Button()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.btnImprimirMesEsp = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.tabInventario.SuspendLayout()
        CType(Me.dgvInventario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabEntradas.SuspendLayout()
        CType(Me.dgvEntradas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabSalidas.SuspendLayout()
        CType(Me.dgvSalidas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabRepMen.SuspendLayout()
        CType(Me.dgvReporteSalidas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvReporte, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabRepEsp.SuspendLayout()
        CType(Me.dgvReporteSalidasEsp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvReporteEntradasEsp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tabInventario)
        Me.TabControl1.Controls.Add(Me.tabEntradas)
        Me.TabControl1.Controls.Add(Me.tabSalidas)
        Me.TabControl1.Controls.Add(Me.tabRepMen)
        Me.TabControl1.Controls.Add(Me.tabRepEsp)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1809, 971)
        Me.TabControl1.TabIndex = 0
        '
        'tabInventario
        '
        Me.tabInventario.BackColor = System.Drawing.Color.White
        Me.tabInventario.Controls.Add(Me.lblResultados)
        Me.tabInventario.Controls.Add(Me.cmbTipoInventario)
        Me.tabInventario.Controls.Add(Me.Label28)
        Me.tabInventario.Controls.Add(Me.btnImprimirInv)
        Me.tabInventario.Controls.Add(Me.PictureBox1)
        Me.tabInventario.Controls.Add(Me.btnEliminarInventario)
        Me.tabInventario.Controls.Add(Me.btnEditarInventario)
        Me.tabInventario.Controls.Add(Me.btnLimpiarInventario)
        Me.tabInventario.Controls.Add(Me.btnBuscarInventario)
        Me.tabInventario.Controls.Add(Me.dgvInventario)
        Me.tabInventario.Controls.Add(Me.btnGuardarInventario)
        Me.tabInventario.Controls.Add(Me.txtNombreInventario)
        Me.tabInventario.Controls.Add(Me.txtCantidadInventario)
        Me.tabInventario.Controls.Add(Me.txtCodigoInventario)
        Me.tabInventario.Controls.Add(Me.Label5)
        Me.tabInventario.Controls.Add(Me.Label2)
        Me.tabInventario.Controls.Add(Me.Label1)
        Me.tabInventario.Location = New System.Drawing.Point(4, 47)
        Me.tabInventario.Name = "tabInventario"
        Me.tabInventario.Padding = New System.Windows.Forms.Padding(3)
        Me.tabInventario.Size = New System.Drawing.Size(1801, 920)
        Me.tabInventario.TabIndex = 0
        Me.tabInventario.Text = "Inventario"
        '
        'lblResultados
        '
        Me.lblResultados.AutoSize = True
        Me.lblResultados.Location = New System.Drawing.Point(6, 582)
        Me.lblResultados.Name = "lblResultados"
        Me.lblResultados.Size = New System.Drawing.Size(197, 39)
        Me.lblResultados.TabIndex = 53
        Me.lblResultados.Text = "Resultados:"
        '
        'cmbTipoInventario
        '
        Me.cmbTipoInventario.FormattingEnabled = True
        Me.cmbTipoInventario.Items.AddRange(New Object() {"PIEZAS", "CONSUMIBLES", "HERRAMIENTA", "QUÍMICOS", "ESTRUCTURAL", "ACCESORIOS", "CONEXIONES"})
        Me.cmbTipoInventario.Location = New System.Drawing.Point(180, 154)
        Me.cmbTipoInventario.Name = "cmbTipoInventario"
        Me.cmbTipoInventario.Size = New System.Drawing.Size(319, 46)
        Me.cmbTipoInventario.TabIndex = 51
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(3, 154)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(176, 39)
        Me.Label28.TabIndex = 50
        Me.Label28.Text = "Inventario:"
        '
        'dgvInventario
        '
        Me.dgvInventario.BackgroundColor = System.Drawing.Color.White
        Me.dgvInventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInventario.Location = New System.Drawing.Point(508, 7)
        Me.dgvInventario.Name = "dgvInventario"
        Me.dgvInventario.RowHeadersWidth = 51
        Me.dgvInventario.RowTemplate.Height = 24
        Me.dgvInventario.Size = New System.Drawing.Size(1287, 879)
        Me.dgvInventario.TabIndex = 10
        '
        'txtNombreInventario
        '
        Me.txtNombreInventario.Location = New System.Drawing.Point(180, 331)
        Me.txtNombreInventario.Name = "txtNombreInventario"
        Me.txtNombreInventario.Size = New System.Drawing.Size(319, 45)
        Me.txtNombreInventario.TabIndex = 8
        '
        'txtCantidadInventario
        '
        Me.txtCantidadInventario.Location = New System.Drawing.Point(180, 433)
        Me.txtCantidadInventario.Name = "txtCantidadInventario"
        Me.txtCantidadInventario.Size = New System.Drawing.Size(319, 45)
        Me.txtCantidadInventario.TabIndex = 7
        '
        'txtCodigoInventario
        '
        Me.txtCodigoInventario.Location = New System.Drawing.Point(180, 238)
        Me.txtCodigoInventario.Name = "txtCodigoInventario"
        Me.txtCodigoInventario.Size = New System.Drawing.Size(319, 45)
        Me.txtCodigoInventario.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(0, 334)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(147, 39)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Nombre:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 436)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(111, 39)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Stock:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 241)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(135, 39)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Código:"
        '
        'tabEntradas
        '
        Me.tabEntradas.BackColor = System.Drawing.Color.White
        Me.tabEntradas.Controls.Add(Me.txtFactura)
        Me.tabEntradas.Controls.Add(Me.Label33)
        Me.tabEntradas.Controls.Add(Me.txtOC)
        Me.tabEntradas.Controls.Add(Me.Label32)
        Me.tabEntradas.Controls.Add(Me.txtPU)
        Me.tabEntradas.Controls.Add(Me.Label31)
        Me.tabEntradas.Controls.Add(Me.txtLoteEntradas)
        Me.tabEntradas.Controls.Add(Me.Label29)
        Me.tabEntradas.Controls.Add(Me.txtOPEntradas)
        Me.tabEntradas.Controls.Add(Me.Label12)
        Me.tabEntradas.Controls.Add(Me.txtComentariosEntradas)
        Me.tabEntradas.Controls.Add(Me.Label11)
        Me.tabEntradas.Controls.Add(Me.Label10)
        Me.tabEntradas.Controls.Add(Me.txtFolioEntradas)
        Me.tabEntradas.Controls.Add(Me.Label9)
        Me.tabEntradas.Controls.Add(Me.dtpFechaEntradas)
        Me.tabEntradas.Controls.Add(Me.cmbUnidadEntrada)
        Me.tabEntradas.Controls.Add(Me.txtCantidadStockEntradas)
        Me.tabEntradas.Controls.Add(Me.Label8)
        Me.tabEntradas.Controls.Add(Me.txtCantidadEntradas)
        Me.tabEntradas.Controls.Add(Me.Label7)
        Me.tabEntradas.Controls.Add(Me.txtProveedorEntradas)
        Me.tabEntradas.Controls.Add(Me.Label6)
        Me.tabEntradas.Controls.Add(Me.txtNombreEntradas)
        Me.tabEntradas.Controls.Add(Me.Label4)
        Me.tabEntradas.Controls.Add(Me.dgvEntradas)
        Me.tabEntradas.Controls.Add(Me.txtCodigoEntradas)
        Me.tabEntradas.Controls.Add(Me.Label3)
        Me.tabEntradas.Controls.Add(Me.btnReportarEntrada)
        Me.tabEntradas.Controls.Add(Me.btnEliminarEntradas)
        Me.tabEntradas.Controls.Add(Me.btnLimpiarEntradas)
        Me.tabEntradas.Controls.Add(Me.btnBuscarEntradas)
        Me.tabEntradas.Controls.Add(Me.btnGuardarEntradas)
        Me.tabEntradas.Controls.Add(Me.PictureBox3)
        Me.tabEntradas.Location = New System.Drawing.Point(4, 47)
        Me.tabEntradas.Name = "tabEntradas"
        Me.tabEntradas.Padding = New System.Windows.Forms.Padding(3)
        Me.tabEntradas.Size = New System.Drawing.Size(1801, 920)
        Me.tabEntradas.TabIndex = 1
        Me.tabEntradas.Text = "Entradas"
        '
        'txtFactura
        '
        Me.txtFactura.Location = New System.Drawing.Point(474, 313)
        Me.txtFactura.Name = "txtFactura"
        Me.txtFactura.Size = New System.Drawing.Size(212, 45)
        Me.txtFactura.TabIndex = 49
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(317, 316)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(141, 39)
        Me.Label33.TabIndex = 48
        Me.Label33.Text = "Factura:"
        '
        'txtOC
        '
        Me.txtOC.Location = New System.Drawing.Point(474, 364)
        Me.txtOC.Name = "txtOC"
        Me.txtOC.Size = New System.Drawing.Size(212, 45)
        Me.txtOC.TabIndex = 47
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(366, 367)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(77, 39)
        Me.Label32.TabIndex = 46
        Me.Label32.Text = "OC:"
        '
        'txtPU
        '
        Me.txtPU.Location = New System.Drawing.Point(474, 415)
        Me.txtPU.Name = "txtPU"
        Me.txtPU.Size = New System.Drawing.Size(212, 45)
        Me.txtPU.TabIndex = 45
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(366, 418)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(74, 39)
        Me.Label31.TabIndex = 44
        Me.Label31.Text = "PU:"
        '
        'txtLoteEntradas
        '
        Me.txtLoteEntradas.Location = New System.Drawing.Point(474, 466)
        Me.txtLoteEntradas.Name = "txtLoteEntradas"
        Me.txtLoteEntradas.Size = New System.Drawing.Size(212, 45)
        Me.txtLoteEntradas.TabIndex = 43
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(366, 469)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(92, 39)
        Me.Label29.TabIndex = 42
        Me.Label29.Text = "Lote:"
        '
        'txtOPEntradas
        '
        Me.txtOPEntradas.Location = New System.Drawing.Point(207, 211)
        Me.txtOPEntradas.Name = "txtOPEntradas"
        Me.txtOPEntradas.Size = New System.Drawing.Size(479, 45)
        Me.txtOPEntradas.TabIndex = 41
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(2, 214)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(75, 39)
        Me.Label12.TabIndex = 40
        Me.Label12.Text = "OP:"
        '
        'txtComentariosEntradas
        '
        Me.txtComentariosEntradas.Location = New System.Drawing.Point(9, 367)
        Me.txtComentariosEntradas.Name = "txtComentariosEntradas"
        Me.txtComentariosEntradas.Size = New System.Drawing.Size(325, 279)
        Me.txtComentariosEntradas.TabIndex = 39
        Me.txtComentariosEntradas.Text = ""
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(2, 319)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(219, 39)
        Me.Label11.TabIndex = 38
        Me.Label11.Text = "Comentarios:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(357, 571)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(101, 39)
        Me.Label10.TabIndex = 37
        Me.Label10.Text = "Folio:"
        '
        'txtFolioEntradas
        '
        Me.txtFolioEntradas.Location = New System.Drawing.Point(474, 568)
        Me.txtFolioEntradas.Name = "txtFolioEntradas"
        Me.txtFolioEntradas.Size = New System.Drawing.Size(212, 45)
        Me.txtFolioEntradas.TabIndex = 36
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(347, 520)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(111, 39)
        Me.Label9.TabIndex = 35
        Me.Label9.Text = "Stock:"
        '
        'dtpFechaEntradas
        '
        Me.dtpFechaEntradas.Location = New System.Drawing.Point(207, 262)
        Me.dtpFechaEntradas.Name = "dtpFechaEntradas"
        Me.dtpFechaEntradas.Size = New System.Drawing.Size(479, 45)
        Me.dtpFechaEntradas.TabIndex = 34
        '
        'cmbUnidadEntrada
        '
        Me.cmbUnidadEntrada.FormattingEnabled = True
        Me.cmbUnidadEntrada.Items.AddRange(New Object() {"Piezas", "Metros", "Centímetros", "Pulgadas", "Galones", "Litros", "Kilográmos"})
        Me.cmbUnidadEntrada.Location = New System.Drawing.Point(365, 159)
        Me.cmbUnidadEntrada.Name = "cmbUnidadEntrada"
        Me.cmbUnidadEntrada.Size = New System.Drawing.Size(321, 46)
        Me.cmbUnidadEntrada.TabIndex = 33
        '
        'txtCantidadStockEntradas
        '
        Me.txtCantidadStockEntradas.Location = New System.Drawing.Point(474, 517)
        Me.txtCantidadStockEntradas.Name = "txtCantidadStockEntradas"
        Me.txtCantidadStockEntradas.Size = New System.Drawing.Size(212, 45)
        Me.txtCantidadStockEntradas.TabIndex = 32
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(2, 265)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(121, 39)
        Me.Label8.TabIndex = 31
        Me.Label8.Text = "Fecha:"
        '
        'txtCantidadEntradas
        '
        Me.txtCantidadEntradas.Location = New System.Drawing.Point(207, 160)
        Me.txtCantidadEntradas.Name = "txtCantidadEntradas"
        Me.txtCantidadEntradas.Size = New System.Drawing.Size(152, 45)
        Me.txtCantidadEntradas.TabIndex = 30
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(2, 163)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(163, 39)
        Me.Label7.TabIndex = 29
        Me.Label7.Text = "Cantidad:"
        '
        'txtProveedorEntradas
        '
        Me.txtProveedorEntradas.Location = New System.Drawing.Point(207, 108)
        Me.txtProveedorEntradas.Name = "txtProveedorEntradas"
        Me.txtProveedorEntradas.Size = New System.Drawing.Size(479, 45)
        Me.txtProveedorEntradas.TabIndex = 28
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(2, 111)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(183, 39)
        Me.Label6.TabIndex = 27
        Me.Label6.Text = "Proveedor:"
        '
        'txtNombreEntradas
        '
        Me.txtNombreEntradas.Location = New System.Drawing.Point(207, 57)
        Me.txtNombreEntradas.Name = "txtNombreEntradas"
        Me.txtNombreEntradas.Size = New System.Drawing.Size(479, 45)
        Me.txtNombreEntradas.TabIndex = 26
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(2, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(147, 39)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Nombre:"
        '
        'dgvEntradas
        '
        Me.dgvEntradas.BackgroundColor = System.Drawing.Color.White
        Me.dgvEntradas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEntradas.Location = New System.Drawing.Point(692, 0)
        Me.dgvEntradas.Name = "dgvEntradas"
        Me.dgvEntradas.RowHeadersWidth = 51
        Me.dgvEntradas.RowTemplate.Height = 24
        Me.dgvEntradas.Size = New System.Drawing.Size(1109, 914)
        Me.dgvEntradas.TabIndex = 19
        '
        'txtCodigoEntradas
        '
        Me.txtCodigoEntradas.Location = New System.Drawing.Point(207, 6)
        Me.txtCodigoEntradas.Name = "txtCodigoEntradas"
        Me.txtCodigoEntradas.Size = New System.Drawing.Size(479, 45)
        Me.txtCodigoEntradas.TabIndex = 17
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(2, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(135, 39)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Código:"
        '
        'tabSalidas
        '
        Me.tabSalidas.BackColor = System.Drawing.Color.White
        Me.tabSalidas.Controls.Add(Me.txtLoteSalidas)
        Me.tabSalidas.Controls.Add(Me.Label30)
        Me.tabSalidas.Controls.Add(Me.Label21)
        Me.tabSalidas.Controls.Add(Me.txtOPSalidas)
        Me.tabSalidas.Controls.Add(Me.txtComentariosSalidas)
        Me.tabSalidas.Controls.Add(Me.Label13)
        Me.tabSalidas.Controls.Add(Me.Label14)
        Me.tabSalidas.Controls.Add(Me.txtFolioSalidas)
        Me.tabSalidas.Controls.Add(Me.Label15)
        Me.tabSalidas.Controls.Add(Me.dtpFechaSalidas)
        Me.tabSalidas.Controls.Add(Me.cmbUnidadSalidas)
        Me.tabSalidas.Controls.Add(Me.txtCantidadStockSalidas)
        Me.tabSalidas.Controls.Add(Me.Label16)
        Me.tabSalidas.Controls.Add(Me.txtCantidadSalidas)
        Me.tabSalidas.Controls.Add(Me.Label17)
        Me.tabSalidas.Controls.Add(Me.txtDestinoSalidas)
        Me.tabSalidas.Controls.Add(Me.Label18)
        Me.tabSalidas.Controls.Add(Me.txtNombreSalidas)
        Me.tabSalidas.Controls.Add(Me.Label19)
        Me.tabSalidas.Controls.Add(Me.dgvSalidas)
        Me.tabSalidas.Controls.Add(Me.txtCodigoSalidas)
        Me.tabSalidas.Controls.Add(Me.Label20)
        Me.tabSalidas.Controls.Add(Me.btnReportarSalidas)
        Me.tabSalidas.Controls.Add(Me.btnEliminarSalidas)
        Me.tabSalidas.Controls.Add(Me.btnLimpiarSalidas)
        Me.tabSalidas.Controls.Add(Me.btnBuscarSalidas)
        Me.tabSalidas.Controls.Add(Me.btnGuardarSalidas)
        Me.tabSalidas.Controls.Add(Me.PictureBox4)
        Me.tabSalidas.Location = New System.Drawing.Point(4, 47)
        Me.tabSalidas.Name = "tabSalidas"
        Me.tabSalidas.Size = New System.Drawing.Size(1801, 920)
        Me.tabSalidas.TabIndex = 2
        Me.tabSalidas.Text = "Salidas"
        '
        'txtLoteSalidas
        '
        Me.txtLoteSalidas.Location = New System.Drawing.Point(474, 316)
        Me.txtLoteSalidas.Name = "txtLoteSalidas"
        Me.txtLoteSalidas.Size = New System.Drawing.Size(212, 45)
        Me.txtLoteSalidas.TabIndex = 69
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(366, 319)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(92, 39)
        Me.Label30.TabIndex = 68
        Me.Label30.Text = "Lote:"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(2, 214)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(75, 39)
        Me.Label21.TabIndex = 67
        Me.Label21.Text = "OP:"
        '
        'txtOPSalidas
        '
        Me.txtOPSalidas.Location = New System.Drawing.Point(207, 211)
        Me.txtOPSalidas.Name = "txtOPSalidas"
        Me.txtOPSalidas.Size = New System.Drawing.Size(479, 45)
        Me.txtOPSalidas.TabIndex = 66
        '
        'txtComentariosSalidas
        '
        Me.txtComentariosSalidas.Location = New System.Drawing.Point(9, 367)
        Me.txtComentariosSalidas.Name = "txtComentariosSalidas"
        Me.txtComentariosSalidas.Size = New System.Drawing.Size(325, 279)
        Me.txtComentariosSalidas.TabIndex = 65
        Me.txtComentariosSalidas.Text = ""
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(2, 319)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(219, 39)
        Me.Label13.TabIndex = 64
        Me.Label13.Text = "Comentarios:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(357, 421)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(101, 39)
        Me.Label14.TabIndex = 63
        Me.Label14.Text = "Folio:"
        '
        'txtFolioSalidas
        '
        Me.txtFolioSalidas.Location = New System.Drawing.Point(474, 418)
        Me.txtFolioSalidas.Name = "txtFolioSalidas"
        Me.txtFolioSalidas.Size = New System.Drawing.Size(212, 45)
        Me.txtFolioSalidas.TabIndex = 62
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(347, 370)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(111, 39)
        Me.Label15.TabIndex = 61
        Me.Label15.Text = "Stock:"
        '
        'dtpFechaSalidas
        '
        Me.dtpFechaSalidas.Location = New System.Drawing.Point(207, 262)
        Me.dtpFechaSalidas.Name = "dtpFechaSalidas"
        Me.dtpFechaSalidas.Size = New System.Drawing.Size(479, 45)
        Me.dtpFechaSalidas.TabIndex = 60
        '
        'cmbUnidadSalidas
        '
        Me.cmbUnidadSalidas.FormattingEnabled = True
        Me.cmbUnidadSalidas.Items.AddRange(New Object() {"Piezas", "Metros", "Centímetros", "Pulgadas", "Galones", "Litros", "Kilográmos"})
        Me.cmbUnidadSalidas.Location = New System.Drawing.Point(365, 159)
        Me.cmbUnidadSalidas.Name = "cmbUnidadSalidas"
        Me.cmbUnidadSalidas.Size = New System.Drawing.Size(321, 46)
        Me.cmbUnidadSalidas.TabIndex = 59
        '
        'txtCantidadStockSalidas
        '
        Me.txtCantidadStockSalidas.Location = New System.Drawing.Point(474, 367)
        Me.txtCantidadStockSalidas.Name = "txtCantidadStockSalidas"
        Me.txtCantidadStockSalidas.Size = New System.Drawing.Size(212, 45)
        Me.txtCantidadStockSalidas.TabIndex = 58
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(2, 265)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(121, 39)
        Me.Label16.TabIndex = 57
        Me.Label16.Text = "Fecha:"
        '
        'txtCantidadSalidas
        '
        Me.txtCantidadSalidas.Location = New System.Drawing.Point(207, 160)
        Me.txtCantidadSalidas.Name = "txtCantidadSalidas"
        Me.txtCantidadSalidas.Size = New System.Drawing.Size(152, 45)
        Me.txtCantidadSalidas.TabIndex = 56
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(2, 163)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(163, 39)
        Me.Label17.TabIndex = 55
        Me.Label17.Text = "Cantidad:"
        '
        'txtDestinoSalidas
        '
        Me.txtDestinoSalidas.Location = New System.Drawing.Point(207, 108)
        Me.txtDestinoSalidas.Name = "txtDestinoSalidas"
        Me.txtDestinoSalidas.Size = New System.Drawing.Size(479, 45)
        Me.txtDestinoSalidas.TabIndex = 54
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(2, 111)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(161, 39)
        Me.Label18.TabIndex = 53
        Me.Label18.Text = "Personal:"
        '
        'txtNombreSalidas
        '
        Me.txtNombreSalidas.Location = New System.Drawing.Point(207, 57)
        Me.txtNombreSalidas.Name = "txtNombreSalidas"
        Me.txtNombreSalidas.Size = New System.Drawing.Size(479, 45)
        Me.txtNombreSalidas.TabIndex = 52
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(2, 60)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(147, 39)
        Me.Label19.TabIndex = 51
        Me.Label19.Text = "Nombre:"
        '
        'dgvSalidas
        '
        Me.dgvSalidas.BackgroundColor = System.Drawing.Color.White
        Me.dgvSalidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSalidas.Location = New System.Drawing.Point(692, 0)
        Me.dgvSalidas.Name = "dgvSalidas"
        Me.dgvSalidas.RowHeadersWidth = 51
        Me.dgvSalidas.RowTemplate.Height = 24
        Me.dgvSalidas.Size = New System.Drawing.Size(1109, 917)
        Me.dgvSalidas.TabIndex = 46
        '
        'txtCodigoSalidas
        '
        Me.txtCodigoSalidas.Location = New System.Drawing.Point(207, 6)
        Me.txtCodigoSalidas.Name = "txtCodigoSalidas"
        Me.txtCodigoSalidas.Size = New System.Drawing.Size(479, 45)
        Me.txtCodigoSalidas.TabIndex = 44
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(2, 9)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(135, 39)
        Me.Label20.TabIndex = 43
        Me.Label20.Text = "Código:"
        '
        'tabRepMen
        '
        Me.tabRepMen.BackColor = System.Drawing.Color.White
        Me.tabRepMen.Controls.Add(Me.PictureBox5)
        Me.tabRepMen.Controls.Add(Me.btnReportarMesSalidas)
        Me.tabRepMen.Controls.Add(Me.btnReportarMesEntradas)
        Me.tabRepMen.Controls.Add(Me.btnLimpiarReporteMensual)
        Me.tabRepMen.Controls.Add(Me.btnRango)
        Me.tabRepMen.Controls.Add(Me.btnImprimirMensual)
        Me.tabRepMen.Controls.Add(Me.Label25)
        Me.tabRepMen.Controls.Add(Me.Label24)
        Me.tabRepMen.Controls.Add(Me.Label23)
        Me.tabRepMen.Controls.Add(Me.Label22)
        Me.tabRepMen.Controls.Add(Me.dtpFinal)
        Me.tabRepMen.Controls.Add(Me.dtpInicio)
        Me.tabRepMen.Controls.Add(Me.dgvReporteSalidas)
        Me.tabRepMen.Controls.Add(Me.dgvReporte)
        Me.tabRepMen.Location = New System.Drawing.Point(4, 47)
        Me.tabRepMen.Name = "tabRepMen"
        Me.tabRepMen.Size = New System.Drawing.Size(1801, 920)
        Me.tabRepMen.TabIndex = 3
        Me.tabRepMen.Text = "Reporte Mensual"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(674, 66)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(205, 39)
        Me.Label25.TabIndex = 7
        Me.Label25.Text = "ENTRADAS"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(1344, 66)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(163, 39)
        Me.Label24.TabIndex = 6
        Me.Label24.Text = "SALIDAS"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(3, 232)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(207, 39)
        Me.Label23.TabIndex = 5
        Me.Label23.Text = "Fecha FInal:"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(3, 128)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(219, 39)
        Me.Label22.TabIndex = 4
        Me.Label22.Text = "Fecha Inicial:"
        '
        'dtpFinal
        '
        Me.dtpFinal.Location = New System.Drawing.Point(3, 274)
        Me.dtpFinal.Name = "dtpFinal"
        Me.dtpFinal.Size = New System.Drawing.Size(438, 45)
        Me.dtpFinal.TabIndex = 3
        '
        'dtpInicio
        '
        Me.dtpInicio.Location = New System.Drawing.Point(3, 170)
        Me.dtpInicio.Name = "dtpInicio"
        Me.dtpInicio.Size = New System.Drawing.Size(438, 45)
        Me.dtpInicio.TabIndex = 2
        '
        'dgvReporteSalidas
        '
        Me.dgvReporteSalidas.BackgroundColor = System.Drawing.Color.White
        Me.dgvReporteSalidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReporteSalidas.Location = New System.Drawing.Point(1135, 128)
        Me.dgvReporteSalidas.Name = "dgvReporteSalidas"
        Me.dgvReporteSalidas.RowHeadersWidth = 51
        Me.dgvReporteSalidas.RowTemplate.Height = 24
        Me.dgvReporteSalidas.Size = New System.Drawing.Size(663, 743)
        Me.dgvReporteSalidas.TabIndex = 1
        '
        'dgvReporte
        '
        Me.dgvReporte.BackgroundColor = System.Drawing.Color.White
        Me.dgvReporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReporte.Location = New System.Drawing.Point(447, 128)
        Me.dgvReporte.Name = "dgvReporte"
        Me.dgvReporte.RowHeadersWidth = 51
        Me.dgvReporte.RowTemplate.Height = 24
        Me.dgvReporte.Size = New System.Drawing.Size(682, 743)
        Me.dgvReporte.TabIndex = 0
        '
        'tabRepEsp
        '
        Me.tabRepEsp.BackColor = System.Drawing.Color.White
        Me.tabRepEsp.Controls.Add(Me.btnLimpiarReporteEspecifico)
        Me.tabRepEsp.Controls.Add(Me.PictureBox6)
        Me.tabRepEsp.Controls.Add(Me.btnImprimirMesEsp)
        Me.tabRepEsp.Controls.Add(Me.Label26)
        Me.tabRepEsp.Controls.Add(Me.Label27)
        Me.tabRepEsp.Controls.Add(Me.dgvReporteSalidasEsp)
        Me.tabRepEsp.Controls.Add(Me.dgvReporteEntradasEsp)
        Me.tabRepEsp.Location = New System.Drawing.Point(4, 47)
        Me.tabRepEsp.Name = "tabRepEsp"
        Me.tabRepEsp.Size = New System.Drawing.Size(1801, 920)
        Me.tabRepEsp.TabIndex = 4
        Me.tabRepEsp.Text = "Reporte Específico"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(488, 66)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(205, 39)
        Me.Label26.TabIndex = 55
        Me.Label26.Text = "ENTRADAS"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(1351, 66)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(163, 39)
        Me.Label27.TabIndex = 54
        Me.Label27.Text = "SALIDAS"
        '
        'dgvReporteSalidasEsp
        '
        Me.dgvReporteSalidasEsp.BackgroundColor = System.Drawing.Color.White
        Me.dgvReporteSalidasEsp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReporteSalidasEsp.Location = New System.Drawing.Point(1006, 128)
        Me.dgvReporteSalidasEsp.Name = "dgvReporteSalidasEsp"
        Me.dgvReporteSalidasEsp.RowHeadersWidth = 51
        Me.dgvReporteSalidasEsp.RowTemplate.Height = 24
        Me.dgvReporteSalidasEsp.Size = New System.Drawing.Size(792, 765)
        Me.dgvReporteSalidasEsp.TabIndex = 53
        '
        'dgvReporteEntradasEsp
        '
        Me.dgvReporteEntradasEsp.BackgroundColor = System.Drawing.Color.White
        Me.dgvReporteEntradasEsp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReporteEntradasEsp.Location = New System.Drawing.Point(194, 128)
        Me.dgvReporteEntradasEsp.Name = "dgvReporteEntradasEsp"
        Me.dgvReporteEntradasEsp.RowHeadersWidth = 51
        Me.dgvReporteEntradasEsp.RowTemplate.Height = 24
        Me.dgvReporteEntradasEsp.Size = New System.Drawing.Size(806, 765)
        Me.dgvReporteEntradasEsp.TabIndex = 52
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.InventHIBA.My.Resources.Resources.Picture1
        Me.PictureBox2.Location = New System.Drawing.Point(1827, 57)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(215, 926)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 1
        Me.PictureBox2.TabStop = False
        '
        'btnImprimirInv
        '
        Me.btnImprimirInv.Image = Global.InventHIBA.My.Resources.Resources.btnImprimir
        Me.btnImprimirInv.Location = New System.Drawing.Point(180, 507)
        Me.btnImprimirInv.Name = "btnImprimirInv"
        Me.btnImprimirInv.Size = New System.Drawing.Size(59, 52)
        Me.btnImprimirInv.TabIndex = 49
        Me.btnImprimirInv.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.InventHIBA.My.Resources.Resources.LogoInvenTEHIBA
        Me.PictureBox1.Location = New System.Drawing.Point(-4, -30)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(506, 155)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 15
        Me.PictureBox1.TabStop = False
        '
        'btnEliminarInventario
        '
        Me.btnEliminarInventario.Image = Global.InventHIBA.My.Resources.Resources.btnEliminar
        Me.btnEliminarInventario.Location = New System.Drawing.Point(440, 507)
        Me.btnEliminarInventario.Name = "btnEliminarInventario"
        Me.btnEliminarInventario.Size = New System.Drawing.Size(59, 52)
        Me.btnEliminarInventario.TabIndex = 14
        Me.btnEliminarInventario.UseVisualStyleBackColor = True
        '
        'btnEditarInventario
        '
        Me.btnEditarInventario.Image = Global.InventHIBA.My.Resources.Resources.btnEditar
        Me.btnEditarInventario.Location = New System.Drawing.Point(375, 507)
        Me.btnEditarInventario.Name = "btnEditarInventario"
        Me.btnEditarInventario.Size = New System.Drawing.Size(59, 52)
        Me.btnEditarInventario.TabIndex = 13
        Me.btnEditarInventario.UseVisualStyleBackColor = True
        '
        'btnLimpiarInventario
        '
        Me.btnLimpiarInventario.Image = Global.InventHIBA.My.Resources.Resources.Limpiar
        Me.btnLimpiarInventario.Location = New System.Drawing.Point(310, 507)
        Me.btnLimpiarInventario.Name = "btnLimpiarInventario"
        Me.btnLimpiarInventario.Size = New System.Drawing.Size(59, 52)
        Me.btnLimpiarInventario.TabIndex = 12
        Me.btnLimpiarInventario.UseVisualStyleBackColor = True
        '
        'btnBuscarInventario
        '
        Me.btnBuscarInventario.Image = Global.InventHIBA.My.Resources.Resources.btnBuscar
        Me.btnBuscarInventario.Location = New System.Drawing.Point(245, 507)
        Me.btnBuscarInventario.Name = "btnBuscarInventario"
        Me.btnBuscarInventario.Size = New System.Drawing.Size(59, 52)
        Me.btnBuscarInventario.TabIndex = 11
        Me.btnBuscarInventario.UseVisualStyleBackColor = True
        '
        'btnGuardarInventario
        '
        Me.btnGuardarInventario.Image = Global.InventHIBA.My.Resources.Resources.save
        Me.btnGuardarInventario.Location = New System.Drawing.Point(363, 582)
        Me.btnGuardarInventario.Name = "btnGuardarInventario"
        Me.btnGuardarInventario.Size = New System.Drawing.Size(125, 119)
        Me.btnGuardarInventario.TabIndex = 9
        Me.btnGuardarInventario.UseVisualStyleBackColor = True
        '
        'btnReportarEntrada
        '
        Me.btnReportarEntrada.Image = Global.InventHIBA.My.Resources.Resources.reportar
        Me.btnReportarEntrada.Location = New System.Drawing.Point(561, 677)
        Me.btnReportarEntrada.Name = "btnReportarEntrada"
        Me.btnReportarEntrada.Size = New System.Drawing.Size(125, 119)
        Me.btnReportarEntrada.TabIndex = 24
        Me.btnReportarEntrada.UseVisualStyleBackColor = True
        '
        'btnEliminarEntradas
        '
        Me.btnEliminarEntradas.Image = Global.InventHIBA.My.Resources.Resources.btnEliminar
        Me.btnEliminarEntradas.Location = New System.Drawing.Point(627, 619)
        Me.btnEliminarEntradas.Name = "btnEliminarEntradas"
        Me.btnEliminarEntradas.Size = New System.Drawing.Size(59, 52)
        Me.btnEliminarEntradas.TabIndex = 23
        Me.btnEliminarEntradas.UseVisualStyleBackColor = True
        '
        'btnLimpiarEntradas
        '
        Me.btnLimpiarEntradas.Image = Global.InventHIBA.My.Resources.Resources.Limpiar
        Me.btnLimpiarEntradas.Location = New System.Drawing.Point(527, 619)
        Me.btnLimpiarEntradas.Name = "btnLimpiarEntradas"
        Me.btnLimpiarEntradas.Size = New System.Drawing.Size(59, 52)
        Me.btnLimpiarEntradas.TabIndex = 21
        Me.btnLimpiarEntradas.UseVisualStyleBackColor = True
        '
        'btnBuscarEntradas
        '
        Me.btnBuscarEntradas.Image = Global.InventHIBA.My.Resources.Resources.btnBuscar
        Me.btnBuscarEntradas.Location = New System.Drawing.Point(430, 619)
        Me.btnBuscarEntradas.Name = "btnBuscarEntradas"
        Me.btnBuscarEntradas.Size = New System.Drawing.Size(59, 52)
        Me.btnBuscarEntradas.TabIndex = 20
        Me.btnBuscarEntradas.UseVisualStyleBackColor = True
        '
        'btnGuardarEntradas
        '
        Me.btnGuardarEntradas.Image = Global.InventHIBA.My.Resources.Resources.save
        Me.btnGuardarEntradas.Location = New System.Drawing.Point(430, 677)
        Me.btnGuardarEntradas.Name = "btnGuardarEntradas"
        Me.btnGuardarEntradas.Size = New System.Drawing.Size(125, 119)
        Me.btnGuardarEntradas.TabIndex = 18
        Me.btnGuardarEntradas.UseVisualStyleBackColor = True
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.InventHIBA.My.Resources.Resources.TEHIBA_logo
        Me.PictureBox3.Location = New System.Drawing.Point(-1, 652)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(425, 160)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 15
        Me.PictureBox3.TabStop = False
        '
        'btnReportarSalidas
        '
        Me.btnReportarSalidas.Image = Global.InventHIBA.My.Resources.Resources.reportar
        Me.btnReportarSalidas.Location = New System.Drawing.Point(561, 527)
        Me.btnReportarSalidas.Name = "btnReportarSalidas"
        Me.btnReportarSalidas.Size = New System.Drawing.Size(125, 119)
        Me.btnReportarSalidas.TabIndex = 50
        Me.btnReportarSalidas.UseVisualStyleBackColor = True
        '
        'btnEliminarSalidas
        '
        Me.btnEliminarSalidas.Image = Global.InventHIBA.My.Resources.Resources.btnEliminar
        Me.btnEliminarSalidas.Location = New System.Drawing.Point(627, 469)
        Me.btnEliminarSalidas.Name = "btnEliminarSalidas"
        Me.btnEliminarSalidas.Size = New System.Drawing.Size(59, 52)
        Me.btnEliminarSalidas.TabIndex = 49
        Me.btnEliminarSalidas.UseVisualStyleBackColor = True
        '
        'btnLimpiarSalidas
        '
        Me.btnLimpiarSalidas.Image = Global.InventHIBA.My.Resources.Resources.Limpiar
        Me.btnLimpiarSalidas.Location = New System.Drawing.Point(527, 469)
        Me.btnLimpiarSalidas.Name = "btnLimpiarSalidas"
        Me.btnLimpiarSalidas.Size = New System.Drawing.Size(59, 52)
        Me.btnLimpiarSalidas.TabIndex = 48
        Me.btnLimpiarSalidas.UseVisualStyleBackColor = True
        '
        'btnBuscarSalidas
        '
        Me.btnBuscarSalidas.Image = Global.InventHIBA.My.Resources.Resources.btnBuscar
        Me.btnBuscarSalidas.Location = New System.Drawing.Point(430, 469)
        Me.btnBuscarSalidas.Name = "btnBuscarSalidas"
        Me.btnBuscarSalidas.Size = New System.Drawing.Size(59, 52)
        Me.btnBuscarSalidas.TabIndex = 47
        Me.btnBuscarSalidas.UseVisualStyleBackColor = True
        '
        'btnGuardarSalidas
        '
        Me.btnGuardarSalidas.Image = Global.InventHIBA.My.Resources.Resources.save
        Me.btnGuardarSalidas.Location = New System.Drawing.Point(430, 527)
        Me.btnGuardarSalidas.Name = "btnGuardarSalidas"
        Me.btnGuardarSalidas.Size = New System.Drawing.Size(125, 119)
        Me.btnGuardarSalidas.TabIndex = 45
        Me.btnGuardarSalidas.UseVisualStyleBackColor = True
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = Global.InventHIBA.My.Resources.Resources.TEHIBA_logo
        Me.PictureBox4.Location = New System.Drawing.Point(121, 652)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(434, 155)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox4.TabIndex = 42
        Me.PictureBox4.TabStop = False
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = Global.InventHIBA.My.Resources.Resources.TEHIBA_logo
        Me.PictureBox5.Location = New System.Drawing.Point(3, 499)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(438, 171)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox5.TabIndex = 53
        Me.PictureBox5.TabStop = False
        '
        'btnReportarMesSalidas
        '
        Me.btnReportarMesSalidas.Image = Global.InventHIBA.My.Resources.Resources.reportar
        Me.btnReportarMesSalidas.Location = New System.Drawing.Point(1673, 3)
        Me.btnReportarMesSalidas.Name = "btnReportarMesSalidas"
        Me.btnReportarMesSalidas.Size = New System.Drawing.Size(125, 119)
        Me.btnReportarMesSalidas.TabIndex = 52
        Me.btnReportarMesSalidas.UseVisualStyleBackColor = True
        '
        'btnReportarMesEntradas
        '
        Me.btnReportarMesEntradas.Image = Global.InventHIBA.My.Resources.Resources.reportar
        Me.btnReportarMesEntradas.Location = New System.Drawing.Point(1004, 3)
        Me.btnReportarMesEntradas.Name = "btnReportarMesEntradas"
        Me.btnReportarMesEntradas.Size = New System.Drawing.Size(125, 119)
        Me.btnReportarMesEntradas.TabIndex = 51
        Me.btnReportarMesEntradas.UseVisualStyleBackColor = True
        '
        'btnLimpiarReporteMensual
        '
        Me.btnLimpiarReporteMensual.Image = Global.InventHIBA.My.Resources.Resources.Limpiar
        Me.btnLimpiarReporteMensual.Location = New System.Drawing.Point(382, 441)
        Me.btnLimpiarReporteMensual.Name = "btnLimpiarReporteMensual"
        Me.btnLimpiarReporteMensual.Size = New System.Drawing.Size(59, 52)
        Me.btnLimpiarReporteMensual.TabIndex = 50
        Me.btnLimpiarReporteMensual.UseVisualStyleBackColor = True
        '
        'btnRango
        '
        Me.btnRango.Image = Global.InventHIBA.My.Resources.Resources.btnBuscar
        Me.btnRango.Location = New System.Drawing.Point(382, 383)
        Me.btnRango.Name = "btnRango"
        Me.btnRango.Size = New System.Drawing.Size(59, 52)
        Me.btnRango.TabIndex = 49
        Me.btnRango.UseVisualStyleBackColor = True
        '
        'btnImprimirMensual
        '
        Me.btnImprimirMensual.Image = Global.InventHIBA.My.Resources.Resources.btnImprimir
        Me.btnImprimirMensual.Location = New System.Drawing.Point(382, 325)
        Me.btnImprimirMensual.Name = "btnImprimirMensual"
        Me.btnImprimirMensual.Size = New System.Drawing.Size(59, 52)
        Me.btnImprimirMensual.TabIndex = 48
        Me.btnImprimirMensual.UseVisualStyleBackColor = True
        '
        'btnLimpiarReporteEspecifico
        '
        Me.btnLimpiarReporteEspecifico.Image = Global.InventHIBA.My.Resources.Resources.Limpiar
        Me.btnLimpiarReporteEspecifico.Location = New System.Drawing.Point(3, 260)
        Me.btnLimpiarReporteEspecifico.Name = "btnLimpiarReporteEspecifico"
        Me.btnLimpiarReporteEspecifico.Size = New System.Drawing.Size(185, 126)
        Me.btnLimpiarReporteEspecifico.TabIndex = 58
        Me.btnLimpiarReporteEspecifico.UseVisualStyleBackColor = True
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = Global.InventHIBA.My.Resources.Resources.LogoInvenTEHIBA
        Me.PictureBox6.Location = New System.Drawing.Point(763, -33)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(486, 155)
        Me.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox6.TabIndex = 57
        Me.PictureBox6.TabStop = False
        '
        'btnImprimirMesEsp
        '
        Me.btnImprimirMesEsp.Image = Global.InventHIBA.My.Resources.Resources.btnImprimir
        Me.btnImprimirMesEsp.Location = New System.Drawing.Point(3, 128)
        Me.btnImprimirMesEsp.Name = "btnImprimirMesEsp"
        Me.btnImprimirMesEsp.Size = New System.Drawing.Size(185, 126)
        Me.btnImprimirMesEsp.TabIndex = 56
        Me.btnImprimirMesEsp.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Firebrick
        Me.ClientSize = New System.Drawing.Size(1924, 1035)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.TabControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "InvenTEHIBA"
        Me.TabControl1.ResumeLayout(False)
        Me.tabInventario.ResumeLayout(False)
        Me.tabInventario.PerformLayout()
        CType(Me.dgvInventario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabEntradas.ResumeLayout(False)
        Me.tabEntradas.PerformLayout()
        CType(Me.dgvEntradas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabSalidas.ResumeLayout(False)
        Me.tabSalidas.PerformLayout()
        CType(Me.dgvSalidas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabRepMen.ResumeLayout(False)
        Me.tabRepMen.PerformLayout()
        CType(Me.dgvReporteSalidas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvReporte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabRepEsp.ResumeLayout(False)
        Me.tabRepEsp.PerformLayout()
        CType(Me.dgvReporteSalidasEsp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvReporteEntradasEsp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents tabInventario As TabPage
    Friend WithEvents tabEntradas As TabPage
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents tabSalidas As TabPage
    Friend WithEvents tabRepMen As TabPage
    Friend WithEvents tabRepEsp As TabPage
    Friend WithEvents Label5 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnGuardarInventario As Button
    Friend WithEvents txtNombreInventario As TextBox
    Friend WithEvents txtCantidadInventario As TextBox
    Friend WithEvents txtCodigoInventario As TextBox
    Friend WithEvents dgvInventario As DataGridView
    Friend WithEvents btnEliminarInventario As Button
    Friend WithEvents btnEditarInventario As Button
    Friend WithEvents btnLimpiarInventario As Button
    Friend WithEvents btnBuscarInventario As Button
    Friend WithEvents txtCantidadEntradas As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtProveedorEntradas As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtNombreEntradas As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents btnReportarEntrada As Button
    Friend WithEvents btnEliminarEntradas As Button
    Friend WithEvents btnLimpiarEntradas As Button
    Friend WithEvents btnBuscarEntradas As Button
    Friend WithEvents dgvEntradas As DataGridView
    Friend WithEvents btnGuardarEntradas As Button
    Friend WithEvents txtCodigoEntradas As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents cmbUnidadEntrada As ComboBox
    Friend WithEvents txtCantidadStockEntradas As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents dtpFechaEntradas As DateTimePicker
    Friend WithEvents Label9 As Label
    Friend WithEvents txtComentariosEntradas As RichTextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents txtFolioEntradas As TextBox
    Friend WithEvents txtOPEntradas As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents txtOPSalidas As TextBox
    Friend WithEvents txtComentariosSalidas As RichTextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents txtFolioSalidas As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents dtpFechaSalidas As DateTimePicker
    Friend WithEvents cmbUnidadSalidas As ComboBox
    Friend WithEvents txtCantidadStockSalidas As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents txtCantidadSalidas As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents txtDestinoSalidas As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents txtNombreSalidas As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents btnReportarSalidas As Button
    Friend WithEvents btnEliminarSalidas As Button
    Friend WithEvents btnLimpiarSalidas As Button
    Friend WithEvents btnBuscarSalidas As Button
    Friend WithEvents dgvSalidas As DataGridView
    Friend WithEvents btnGuardarSalidas As Button
    Friend WithEvents txtCodigoSalidas As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents dgvReporteSalidas As DataGridView
    Friend WithEvents dgvReporte As DataGridView
    Friend WithEvents Label22 As Label
    Friend WithEvents dtpFinal As DateTimePicker
    Friend WithEvents dtpInicio As DateTimePicker
    Friend WithEvents Label25 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents btnReportarMesSalidas As Button
    Friend WithEvents btnReportarMesEntradas As Button
    Friend WithEvents btnLimpiarReporteMensual As Button
    Friend WithEvents btnRango As Button
    Friend WithEvents btnImprimirMensual As Button
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents Label26 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents dgvReporteSalidasEsp As DataGridView
    Friend WithEvents dgvReporteEntradasEsp As DataGridView
    Friend WithEvents btnImprimirMesEsp As Button
    Friend WithEvents PictureBox6 As PictureBox
    Friend WithEvents btnImprimirInv As Button
    Friend WithEvents btnLimpiarReporteEspecifico As Button
    Friend WithEvents cmbTipoInventario As ComboBox
    Friend WithEvents Label28 As Label
    Friend WithEvents lblResultados As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents txtLoteEntradas As TextBox
    Friend WithEvents txtLoteSalidas As TextBox
    Friend WithEvents Label30 As Label
    Friend WithEvents txtFactura As TextBox
    Friend WithEvents Label33 As Label
    Friend WithEvents txtOC As TextBox
    Friend WithEvents Label32 As Label
    Friend WithEvents txtPU As TextBox
    Friend WithEvents Label31 As Label
End Class
