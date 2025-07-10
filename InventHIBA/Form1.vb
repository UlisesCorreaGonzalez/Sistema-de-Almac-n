Imports System.Data
Imports System.IO
Imports OfficeOpenXml
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.ComponentModel
Imports System.Text


Public Class Form1
    Private dtInventario As DataTable
    Private dtEntradas As DataTable
    Private dtSalidas As DataTable
    Private dtReporteEntradas As DataTable
    Private dtReporteSalidas As DataTable
    Private dtReporteEntradasEsp As DataTable
    Private dtReporteSalidasEsp As DataTable

    Private excelFilePath As String = "\\192.168.1.198\InventarioCompartido\InventHIBA.xlsx"
    '------------------------------------------------
    '---------------------------------------- Accesos
    '------------------------------------------------
    Private Sub ConfigurarAccesos(nivel As Integer)
        ' Habilitar/deshabilitar controles según el nivel de acceso
        Select Case nivel
            Case 1 ' Administrador - acceso completo
                ' Todos los controles habilitados

            Case 2 ' Operador - puede registrar entradas no modificar inventario
                btnEliminarInventario.Enabled = False
                btnEditarInventario.Enabled = False
                btnEliminarEntradas.Enabled = False
                btnEliminarSalidas.Enabled = False

            Case 3 ' Operador - puede registrar entradas no modificar inventario
                btnEliminarInventario.Enabled = False
                btnEditarInventario.Enabled = False
                btnGuardarInventario.Enabled = False
                btnEliminarEntradas.Enabled = False
                btnEliminarSalidas.Enabled = False

            Case 4 ' Consulta - solo ver información
                btnEliminarInventario.Enabled = False
                btnEditarInventario.Enabled = False
                btnGuardarInventario.Enabled = False
                btnGuardarEntradas.Enabled = False
                btnEliminarEntradas.Enabled = False
                btnGuardarSalidas.Enabled = False
                btnEliminarSalidas.Enabled = False
        End Select
    End Sub


    '------------------------------------------------
    '------------------------------------------Inicio
    '------------------------------------------------
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Obtener la IP desde FormMain
        Dim ip As String = FormMain.IPIngresada
        excelFilePath = $"\\{ip}\InventarioCompartido\InventHIBA.xlsx"

        ' Verificar si el archivo existe
        If Not File.Exists(excelFilePath) Then
            MessageBox.Show("No se encontró el archivo en la ruta: " & excelFilePath, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
            FormMain.Show()
            Return
        End If
        dgvInventario.AutoGenerateColumns = True
        dgvInventario.AllowUserToAddRows = False
        ' Para permitir filtrar por "TODOS" los tipos
        cmbTipoInventario.Items.Insert(0, "TODOS")
        cmbTipoInventario.SelectedIndex = 0
        ' Obtener el nivel de acceso (1: Admin, 2: Operador, 3: Consulta)
        Dim nivelAcceso As Integer = If(Tag IsNot Nothing, CInt(Tag), 3) ' Por defecto modo consulta

        ' Configurar controles según el nivel de acceso
        ConfigurarAccesos(nivelAcceso)


        ' Maximizar el formulario al cargar
        Me.WindowState = FormWindowState.Maximized

        ' Configurar el contexto de la licencia de EPPlus
        ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial

        ' Inicializar DataTables
        dtInventario = New DataTable()
        dtInventario.Columns.Add("Código")
        dtInventario.Columns.Add("Nombre")
        dtInventario.Columns.Add("Cantidad en Stock", GetType(Integer))
        dtInventario.Columns.Add("Tipo") ' Nueva columna para el tipo de inventario
        dgvInventario.DataSource = dtInventario

        dtEntradas = New DataTable()
        dtEntradas.Columns.Add("Folio", GetType(Integer))
        dtEntradas.Columns.Add("Código")
        dtEntradas.Columns.Add("Nombre")
        dtEntradas.Columns.Add("Cantidad", GetType(Integer))
        dtEntradas.Columns.Add("Unidad") ' Nuevo campo para la unidad
        dtEntradas.Columns.Add("OP") ' Nuevo campo para la OP
        dtEntradas.Columns.Add("Proveedor")
        dtEntradas.Columns.Add("Fecha")
        dtEntradas.Columns.Add("Factura")
        dtEntradas.Columns.Add("OC")
        dtEntradas.Columns.Add("PU")
        dtEntradas.Columns.Add("Lote")
        dtEntradas.Columns.Add("Comentarios")
        dtEntradas.Columns.Add("Stock Anterior", GetType(Integer)) ' Nueva columna para el stock anterior
        dtEntradas.Columns.Add("Stock Actual", GetType(Integer))   ' Nueva columna para el stock actual
        dgvEntradas.DataSource = dtEntradas

        dtSalidas = New DataTable()
        dtSalidas.Columns.Add("Folio", GetType(Integer))
        dtSalidas.Columns.Add("Código")
        dtSalidas.Columns.Add("Nombre")
        dtSalidas.Columns.Add("Cantidad", GetType(Integer))
        dtSalidas.Columns.Add("Unidad") ' Nuevo campo para la unidad
        dtSalidas.Columns.Add("OP") ' Nuevo campo para la OP
        dtSalidas.Columns.Add("Personal")
        dtSalidas.Columns.Add("Fecha")
        dtSalidas.Columns.Add("Lote")
        dtSalidas.Columns.Add("Comentarios")
        dtSalidas.Columns.Add("Stock Anterior", GetType(Integer)) ' Nueva columna para el stock anterior
        dtSalidas.Columns.Add("Stock Actual", GetType(Integer))   ' Nueva columna para el stock actual
        dgvSalidas.DataSource = dtSalidas

        dtReporteEntradas = New DataTable()
        dtReporteEntradas.Columns.Add("Folio", GetType(Integer))
        dtReporteEntradas.Columns.Add("Código")
        dtReporteEntradas.Columns.Add("Nombre")
        dtReporteEntradas.Columns.Add("Cantidad", GetType(Integer))
        dtReporteEntradas.Columns.Add("Unidad") ' Nuevo campo para la unidad
        dtReporteEntradas.Columns.Add("OP") ' Nuevo campo para la OP
        dtReporteEntradas.Columns.Add("Proveedor")
        dtReporteEntradas.Columns.Add("Fecha")
        dtReporteEntradas.Columns.Add("Factura")
        dtReporteEntradas.Columns.Add("OC")
        dtReporteEntradas.Columns.Add("PU")
        dtReporteEntradas.Columns.Add("Lote")
        dtReporteEntradas.Columns.Add("Comentarios")
        dtReporteEntradas.Columns.Add("Stock Anterior", GetType(Integer)) ' Nueva columna para el stock anterior
        dtReporteEntradas.Columns.Add("Stock Actual", GetType(Integer))   ' Nueva columna para el stock actual
        dgvReporte.DataSource = dtReporteEntradas

        dtReporteSalidas = New DataTable()
        dtReporteSalidas.Columns.Add("Folio", GetType(Integer))
        dtReporteSalidas.Columns.Add("Código")
        dtReporteSalidas.Columns.Add("Nombre")
        dtReporteSalidas.Columns.Add("Cantidad", GetType(Integer))
        dtReporteSalidas.Columns.Add("Unidad") ' Nuevo campo para la unidad
        dtReporteSalidas.Columns.Add("OP") ' Nuevo campo para la OP
        dtReporteSalidas.Columns.Add("Personal")
        dtReporteSalidas.Columns.Add("Fecha")
        dtReporteSalidas.Columns.Add("Lote")
        dtReporteSalidas.Columns.Add("Comentarios")
        dtReporteSalidas.Columns.Add("Stock Anterior", GetType(Integer)) ' Nueva columna para el stock anterior
        dtReporteSalidas.Columns.Add("Stock Actual", GetType(Integer))   ' Nueva columna para el stock actual
        dgvReporteSalidas.DataSource = dtReporteSalidas

        dtReporteEntradasEsp = New DataTable()
        dtReporteEntradasEsp.Columns.Add("Folio", GetType(Integer))
        dtReporteEntradasEsp.Columns.Add("Código")
        dtReporteEntradasEsp.Columns.Add("Nombre")
        dtReporteEntradasEsp.Columns.Add("Cantidad", GetType(Integer))
        dtReporteEntradasEsp.Columns.Add("Unidad") ' Nuevo campo para la unidad
        dtReporteEntradasEsp.Columns.Add("OP") ' Nuevo campo para la OP
        dtReporteEntradasEsp.Columns.Add("Proveedor")
        dtReporteEntradasEsp.Columns.Add("Fecha")
        dtReporteEntradasEsp.Columns.Add("Factura")
        dtReporteEntradasEsp.Columns.Add("OC")
        dtReporteEntradasEsp.Columns.Add("PU")
        dtReporteEntradasEsp.Columns.Add("Lote")
        dtReporteEntradasEsp.Columns.Add("Comentarios")
        dtReporteEntradasEsp.Columns.Add("Stock Anterior", GetType(Integer)) ' Nueva columna para el stock anterior
        dtReporteEntradasEsp.Columns.Add("Stock Actual", GetType(Integer))   ' Nueva columna para el stock actual
        dgvReporteEntradasEsp.DataSource = dtReporteEntradasEsp

        dtReporteSalidasEsp = New DataTable()
        dtReporteSalidasEsp.Columns.Add("Folio", GetType(Integer))
        dtReporteSalidasEsp.Columns.Add("Código")
        dtReporteSalidasEsp.Columns.Add("Nombre")
        dtReporteSalidasEsp.Columns.Add("Cantidad", GetType(Integer))
        dtReporteSalidasEsp.Columns.Add("Unidad") ' Nuevo campo para la unidad
        dtReporteSalidasEsp.Columns.Add("OP") ' Nuevo campo para la OP
        dtReporteSalidasEsp.Columns.Add("Personal")
        dtReporteSalidasEsp.Columns.Add("Fecha")
        dtReporteSalidasEsp.Columns.Add("Lote")
        dtReporteSalidasEsp.Columns.Add("Comentarios")
        dtReporteSalidasEsp.Columns.Add("Stock Anterior", GetType(Integer)) ' Nueva columna para el stock anterior
        dtReporteSalidasEsp.Columns.Add("Stock Actual", GetType(Integer))   ' Nueva columna para el stock actual
        dgvReporteSalidasEsp.DataSource = dtReporteSalidasEsp

        ' Ajustar automáticamente el tamaño de las columnas al contenido
        dgvInventario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        dgvEntradas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        dgvSalidas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        dgvReporte.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        dgvReporteSalidas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        dgvReporteEntradasEsp.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        dgvReporteSalidasEsp.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        ' Llenar el ComboBox con opciones de unidades
        cmbUnidadEntrada.Items.AddRange({"Caja", "Paquete"})
        cmbUnidadEntrada.SelectedIndex = 0 ' Seleccionar la primera opción por defecto
        cmbUnidadSalidas.Items.AddRange({"Caja", "Paquete"})
        cmbUnidadSalidas.SelectedIndex = 0 ' Seleccionar la primera opción por defecto

        ' Leer datos del archivo de Excel al iniciar
        LeerExcel()
    End Sub
    Private Function GenerarFolio() As Integer
        Dim file As New FileInfo(excelFilePath)
        If Not file.Exists Then
            MessageBox.Show("El archivo de Excel no existe.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return -1
        End If

        Using package As New ExcelPackage(file)
            ' Obtener la hoja "Config"
            Dim worksheetConfig = package.Workbook.Worksheets.FirstOrDefault(Function(ws) ws.Name = "Config")
            If worksheetConfig Is Nothing Then
                ' Si no existe la hoja, crearla
                worksheetConfig = package.Workbook.Worksheets.Add("Config")
                worksheetConfig.Cells("A1").Value = 0 ' Iniciar el contador en 0
            End If

            ' Obtener el último folio
            Dim ultimoFolio As Integer = Convert.ToInt32(worksheetConfig.Cells("A1").Value)

            ' Incrementar el folio
            ultimoFolio += 1

            ' Guardar el nuevo folio en la hoja "Config"
            worksheetConfig.Cells("A1").Value = ultimoFolio

            ' Guardar los cambios en el archivo de Excel
            package.Save()

            Return ultimoFolio
        End Using
    End Function

    Private Sub LeerExcel()
        Try
            Dim file As New FileInfo(excelFilePath)
            If Not file.Exists Then
                MessageBox.Show("El archivo de Excel no existe.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Using package As New ExcelPackage(file)
                ' Leer la hoja "Inventario"
                Dim worksheetInventario = package.Workbook.Worksheets.FirstOrDefault(Function(ws) ws.Name = "Inventario")
                If worksheetInventario IsNot Nothing Then
                    dtInventario.Rows.Clear() ' Limpiar datos existentes
                    For i As Integer = 2 To worksheetInventario.Dimension.End.Row
                        Try
                            Dim codigo As String = worksheetInventario.Cells(i, 1).Text
                            Dim nombre As String = worksheetInventario.Cells(i, 2).Text
                            Dim cantidad As Integer
                            Dim tipo As String = If(worksheetInventario.Cells(i, 4).Text, "PIEZAS") ' Valor por defecto si no existe

                            ' Validar que la cantidad sea un número válido
                            If Integer.TryParse(worksheetInventario.Cells(i, 3).Text, cantidad) Then
                                dtInventario.Rows.Add(codigo, nombre, cantidad, tipo)
                            Else
                                MessageBox.Show($"Error en la fila {i} (Inventario): La cantidad no es un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        Catch ex As Exception
                            MessageBox.Show($"Error en la fila {i} (Inventario): {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    Next
                End If

                ' Leer la hoja "Entradas"
                Dim worksheetEntradas = package.Workbook.Worksheets.FirstOrDefault(Function(ws) ws.Name = "Entradas")
                If worksheetEntradas IsNot Nothing Then
                    dtEntradas.Rows.Clear() ' Limpiar datos existentes
                    For i As Integer = 2 To worksheetEntradas.Dimension.End.Row
                        Try
                            Dim folio As String = worksheetEntradas.Cells(i, 1).Text
                            Dim codigo As String = worksheetEntradas.Cells(i, 2).Text
                            Dim nombre As String = worksheetEntradas.Cells(i, 3).Text
                            Dim cantidad As Integer
                            Dim unidad As String = worksheetEntradas.Cells(i, 5).Text ' Leer la unidad
                            Dim op As String = worksheetEntradas.Cells(i, 6).Text ' Leer la OP
                            Dim proveedor As String = worksheetEntradas.Cells(i, 7).Text
                            Dim fecha As String = worksheetEntradas.Cells(i, 8).Text
                            Dim factura As String = worksheetEntradas.Cells(i, 9).Text
                            Dim oc As String = worksheetEntradas.Cells(i, 10).Text
                            Dim pu As String = worksheetEntradas.Cells(i, 11).Text
                            Dim lote As String = worksheetEntradas.Cells(i, 12).Text
                            Dim comentarios As String = worksheetEntradas.Cells(i, 13).Text
                            Dim stockAnterior As Integer
                            Dim stockActual As Integer

                            ' Validar que la cantidad sea un número válido
                            If Not Integer.TryParse(worksheetEntradas.Cells(i, 4).Text, cantidad) Then
                                MessageBox.Show($"Error en la fila {i} (Entradas): La cantidad no es un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Continue For
                            End If

                            ' Validar que el stock anterior sea un número válido
                            If Not Integer.TryParse(worksheetEntradas.Cells(i, 14).Text, stockAnterior) Then
                                MessageBox.Show($"Error en la fila {i} (Entradas): El stock anterior no es un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Continue For
                            End If

                            ' Validar que el stock actual sea un número válido
                            If Not Integer.TryParse(worksheetEntradas.Cells(i, 15).Text, stockActual) Then
                                MessageBox.Show($"Error en la fila {i} (Entradas): El stock actual no es un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Continue For
                            End If

                            dtEntradas.Rows.Add(folio, codigo, nombre, cantidad, unidad, op, proveedor, fecha, factura, oc, pu, lote, comentarios, stockAnterior, stockActual)
                        Catch ex As Exception
                            MessageBox.Show($"Error en la fila {i} (Entradas): {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    Next
                End If

                ' Leer la hoja "Salidas"
                Dim worksheetSalidas = package.Workbook.Worksheets.FirstOrDefault(Function(ws) ws.Name = "Salidas")
                If worksheetSalidas IsNot Nothing Then
                    dtSalidas.Rows.Clear() ' Limpiar datos existentes
                    For i As Integer = 2 To worksheetSalidas.Dimension.End.Row
                        Try
                            Dim folio As String = worksheetSalidas.Cells(i, 1).Text
                            Dim codigo As String = worksheetSalidas.Cells(i, 2).Text
                            Dim nombre As String = worksheetSalidas.Cells(i, 3).Text
                            Dim cantidad As Integer
                            Dim unidad As String = worksheetSalidas.Cells(i, 5).Text ' Leer la unidad
                            Dim op As String = worksheetSalidas.Cells(i, 6).Text ' Leer la OP
                            Dim proveedor As String = worksheetSalidas.Cells(i, 7).Text
                            Dim fecha As String = worksheetSalidas.Cells(i, 8).Text
                            Dim lote As String = worksheetSalidas.Cells(i, 9).Text
                            Dim comentarios As String = worksheetSalidas.Cells(i, 10).Text
                            Dim stockAnterior As Integer
                            Dim stockActual As Integer

                            ' Validar que la cantidad sea un número válido
                            If Not Integer.TryParse(worksheetSalidas.Cells(i, 4).Text, cantidad) Then
                                MessageBox.Show($"Error en la fila {i} (Salidas): La cantidad no es un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Continue For
                            End If

                            ' Validar que el stock anterior sea un número válido
                            If Not Integer.TryParse(worksheetSalidas.Cells(i, 11).Text, stockAnterior) Then
                                MessageBox.Show($"Error en la fila {i} (Salidas): El stock anterior no es un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Continue For
                            End If

                            ' Validar que el stock actual sea un número válido
                            If Not Integer.TryParse(worksheetSalidas.Cells(i, 12).Text, stockActual) Then
                                MessageBox.Show($"Error en la fila {i} (Salidas): El stock actual no es un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Continue For
                            End If

                            dtSalidas.Rows.Add(folio, codigo, nombre, cantidad, unidad, op, proveedor, fecha, lote, comentarios, stockAnterior, stockActual)
                        Catch ex As Exception
                            MessageBox.Show($"Error en la fila {i} (Salidas): {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    Next
                End If

                ' Hoja de Reporte Mensual
                Dim worksheetReporteEntradas = package.Workbook.Worksheets.FirstOrDefault(Function(ws) ws.Name = "Reporte Mensual ENtradas")
                If worksheetReporteEntradas IsNot Nothing Then
                    dtReporteEntradas.Rows.Clear() ' Limpiar datos existentes
                    For i As Integer = 2 To worksheetReporteEntradas.Dimension.End.Row
                        Try
                            Dim folio As String = worksheetReporteEntradas.Cells(i, 1).Text
                            Dim codigo As String = worksheetReporteEntradas.Cells(i, 2).Text
                            Dim nombre As String = worksheetReporteEntradas.Cells(i, 3).Text
                            Dim cantidad As Integer
                            Dim unidad As String = worksheetReporteEntradas.Cells(i, 5).Text ' Leer la unidad
                            Dim op As String = worksheetReporteEntradas.Cells(i, 6).Text ' Leer la OP
                            Dim proveedor As String = worksheetReporteEntradas.Cells(i, 7).Text
                            Dim fecha As String = worksheetReporteEntradas.Cells(i, 8).Text
                            Dim factura As String = worksheetReporteEntradas.Cells(i, 9).Text
                            Dim oc As String = worksheetReporteEntradas.Cells(i, 10).Text
                            Dim pu As String = worksheetReporteEntradas.Cells(i, 11).Text
                            Dim lote As String = worksheetReporteEntradas.Cells(i, 12).Text
                            Dim comentarios As String = worksheetReporteEntradas.Cells(i, 13).Text
                            Dim stockAnterior As Integer
                            Dim stockActual As Integer

                            ' Validar que la cantidad sea un número válido
                            If Not Integer.TryParse(worksheetReporteEntradas.Cells(i, 4).Text, cantidad) Then
                                MessageBox.Show($"Error en la fila {i} (Reporte ENtradas): La cantidad no es un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Continue For
                            End If

                            ' Validar que el stock anterior sea un número válido
                            If Not Integer.TryParse(worksheetReporteEntradas.Cells(i, 14).Text, stockAnterior) Then
                                MessageBox.Show($"Error en la fila {i} (Reporte ENtradas): El stock anterior no es un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Continue For
                            End If

                            ' Validar que el stock actual sea un número válido
                            If Not Integer.TryParse(worksheetReporteEntradas.Cells(i, 15).Text, stockActual) Then
                                MessageBox.Show($"Error en la fila {i} (Reporte ENtradas): El stock actual no es un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Continue For
                            End If

                            dtReporteEntradas.Rows.Add(folio, codigo, nombre, cantidad, unidad, op, proveedor, fecha, factura, oc, pu, lote, comentarios, stockAnterior, stockActual)
                        Catch ex As Exception
                            MessageBox.Show($"Error en la fila {i} (Reporte ENtradas): {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    Next
                End If

                ' Hoja de Reporte Mensual Salidas
                Dim worksheetReporteSalidas = package.Workbook.Worksheets.FirstOrDefault(Function(ws) ws.Name = "Reporte Mensual Salidas")
                If worksheetReporteSalidas IsNot Nothing Then
                    dtReporteSalidas.Rows.Clear() ' Limpiar datos existentes
                    For i As Integer = 2 To worksheetReporteSalidas.Dimension.End.Row
                        Try
                            Dim folio As String = worksheetReporteSalidas.Cells(i, 1).Text
                            Dim codigo As String = worksheetReporteSalidas.Cells(i, 2).Text
                            Dim nombre As String = worksheetReporteSalidas.Cells(i, 3).Text
                            Dim cantidad As Integer
                            Dim unidad As String = worksheetReporteSalidas.Cells(i, 5).Text ' Leer la unidad
                            Dim op As String = worksheetReporteSalidas.Cells(i, 6).Text ' Leer la OP
                            Dim personal As String = worksheetReporteSalidas.Cells(i, 7).Text
                            Dim fecha As String = worksheetReporteSalidas.Cells(i, 8).Text
                            Dim lote As String = worksheetReporteSalidas.Cells(i, 9).Text
                            Dim comentarios As String = worksheetReporteSalidas.Cells(i, 10).Text
                            Dim stockAnterior As Integer
                            Dim stockActual As Integer

                            ' Validar que la cantidad sea un número válido
                            If Not Integer.TryParse(worksheetReporteSalidas.Cells(i, 4).Text, cantidad) Then
                                MessageBox.Show($"Error en la fila {i} (Reporte Salidas): La cantidad no es un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Continue For
                            End If

                            ' Validar que el stock anterior sea un número válido
                            If Not Integer.TryParse(worksheetReporteSalidas.Cells(i, 11).Text, stockAnterior) Then
                                MessageBox.Show($"Error en la fila {i} (Reporte Salidas): El stock anterior no es un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Continue For
                            End If

                            ' Validar que el stock actual sea un número válido
                            If Not Integer.TryParse(worksheetReporteSalidas.Cells(i, 12).Text, stockActual) Then
                                MessageBox.Show($"Error en la fila {i} (Reporte Salidas): El stock actual no es un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Continue For
                            End If

                            dtReporteSalidas.Rows.Add(folio, codigo, nombre, cantidad, unidad, op, personal, fecha, lote, comentarios, stockAnterior, stockActual)
                        Catch ex As Exception
                            MessageBox.Show($"Error en la fila {i} (Reporte Salidas): {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    Next
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al leer el archivo de Excel: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GuardarEnExcel(dt As DataTable, hoja As String)
        Try
            Dim directorio As String = Path.GetDirectoryName(excelFilePath)

            ' Verificar si la carpeta compartida existe
            If Not Directory.Exists(directorio) Then
                MessageBox.Show("La ruta compartida no está disponible. Verifica la conexión a la carpeta: " & directorio,
                            "Error de red", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Dim file As New FileInfo(excelFilePath)
            Dim archivoNuevo As Boolean = Not file.Exists

            Using package As New ExcelPackage(file)
                ' Buscar hoja o crear una nueva si no existe
                Dim worksheet = package.Workbook.Worksheets.FirstOrDefault(Function(ws) ws.Name = hoja)
                If worksheet Is Nothing Then worksheet = package.Workbook.Worksheets.Add(hoja)

                worksheet.Cells.Clear()

                ' Escribir encabezados
                For i As Integer = 0 To dt.Columns.Count - 1
                    worksheet.Cells(1, i + 1).Value = dt.Columns(i).ColumnName
                Next

                ' Escribir datos
                For i As Integer = 0 To dt.Rows.Count - 1
                    For j As Integer = 0 To dt.Columns.Count - 1
                        worksheet.Cells(i + 2, j + 1).Value = dt.Rows(i)(j).ToString()
                    Next
                Next

                package.Save()
            End Using

            If archivoNuevo Then
                MessageBox.Show("El archivo de Excel fue creado por primera vez en la carpeta compartida.",
                            "Archivo creado", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show("Error al guardar en Excel: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    '------------------------------------------------
    '--------------------------------------INVENTARIO
    '------------------------------------------------

    Private Sub btnGuardarInventario_Click(sender As Object, e As EventArgs) Handles btnGuardarInventario.Click
        Try
            Dim codigo As String = txtCodigoInventario.Text.Trim()
            Dim nombre As String = txtNombreInventario.Text.Trim()
            Dim cantidad As Integer
            Dim tipoInventario As String = cmbTipoInventario.SelectedItem?.ToString() ' Obtenemos el tipo seleccionado

            ' Validación de tipo de inventario
            If String.IsNullOrEmpty(tipoInventario) OrElse tipoInventario = "TODOS" Then
                MessageBox.Show("Debe seleccionar un tipo de inventario válido (Piezas, Consumibles o Herramienta).",
                          "Tipo inválido",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Error)
                cmbTipoInventario.Focus()
                Return
            End If

            ' Validación de cantidad
            If Not Integer.TryParse(txtCantidadInventario.Text, cantidad) Then
                MessageBox.Show("Cantidad debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtCantidadInventario.Focus()
                Return
            End If

            ' Validación de campos obligatorios
            If String.IsNullOrEmpty(codigo) Then
                MessageBox.Show("El código es obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtCodigoInventario.Focus()
                Return
            End If

            If String.IsNullOrEmpty(nombre) Then
                MessageBox.Show("El nombre es obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtNombreInventario.Focus()
                Return
            End If

            ' Verificar si el código ya existe en el inventario
            Dim filaExistente = dtInventario.Select("Código = '" & codigo & "'")
            If filaExistente.Length > 0 Then
                MessageBox.Show("El código ya está registrado. No se permiten duplicados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtCodigoInventario.Focus()
                Return
            End If

            ' Agregar la nueva fila al inventario con el tipo
            dtInventario.Rows.Add(codigo, nombre, cantidad, tipoInventario)

            ' Actualizar el DataGridView
            ActualizarVistaInventario()

            ' Guardar en Excel
            GuardarEnExcel(dtInventario, "Inventario")

            ' Limpiar campos después de guardar
            LimpiarCamposInventario()

            MessageBox.Show("Producto guardado correctamente en el inventario.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error al guardar en inventario: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LimpiarCamposInventario()
        txtCodigoInventario.Clear()
        txtNombreInventario.Clear()
        txtCantidadInventario.Clear()
        ' Seleccionar el primer tipo válido (no "TODOS")
        If cmbTipoInventario.Items.Count > 1 Then
            cmbTipoInventario.SelectedIndex = 1 ' Asumiendo que "TODOS" es el índice 0
        End If
    End Sub
    Private Sub btnEliminarInventario_Click(sender As Object, e As EventArgs) Handles btnEliminarInventario.Click
        Try
            ' Verificar si hay filas seleccionadas
            If dgvInventario.SelectedRows.Count = 0 Then
                MessageBox.Show("Por favor, seleccione al menos un producto para eliminar.",
                          "Selección requerida",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Information)
                Return
            End If

            ' Obtener la fila seleccionada
            Dim filaSeleccionada As DataGridViewRow = dgvInventario.SelectedRows(0)

            ' Verificar si la fila es válida
            If filaSeleccionada Is Nothing OrElse filaSeleccionada.IsNewRow Then
                MessageBox.Show("La fila seleccionada no es válida.",
                          "Error de selección",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Error)
                Return
            End If

            ' Obtener datos del producto
            Dim codigo As String = filaSeleccionada.Cells("Código").Value?.ToString()
            Dim nombre As String = filaSeleccionada.Cells("Nombre").Value?.ToString()
            Dim cantidad As String = filaSeleccionada.Cells("Cantidad en Stock").Value?.ToString()
            Dim tipo As String = filaSeleccionada.Cells("Tipo").Value?.ToString()

            ' Validar datos obtenidos
            If String.IsNullOrEmpty(codigo) OrElse String.IsNullOrEmpty(nombre) Then
                MessageBox.Show("No se pudieron obtener los datos completos del producto.",
                          "Error de datos",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Error)
                Return
            End If

            ' Mostrar confirmación con todos los detalles
            Dim mensajeConfirmacion As String = $"¿Está seguro de eliminar este producto?" & vbCrLf & vbCrLf &
                                         $"Código: {codigo}" & vbCrLf &
                                         $"Nombre: {nombre}" & vbCrLf &
                                         $"Cantidad: {cantidad}" & vbCrLf &
                                         $"Tipo: {tipo}" & vbCrLf & vbCrLf &
                                         "Esta acción no se puede deshacer."

            Dim confirmacion As DialogResult = MessageBox.Show(mensajeConfirmacion,
                                                        "Confirmar eliminación",
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Warning,
                                                        MessageBoxDefaultButton.Button2)

            If confirmacion <> DialogResult.Yes Then
                Return
            End If

            ' Validación de seguridad (contraseña)
            Dim password As String = InputBox("Ingrese la contraseña de administrador para confirmar:",
                                        "Autenticación requerida")

            If password <> "Admin#2024" Then ' Considera usar una forma más segura de almacenar contraseñas
                MessageBox.Show("Contraseña incorrecta. Operación cancelada.",
                          "Acceso denegado",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Stop)
                Return
            End If

            ' Eliminar del DataTable
            Dim filasEncontradas = dtInventario.Select($"Código = '{codigo}'")

            If filasEncontradas.Length > 0 Then
                ' Verificar si hay existencias antes de eliminar
                Dim stockActual As Integer = Convert.ToInt32(filasEncontradas(0)("Cantidad en Stock"))

                If stockActual > 0 Then
                    Dim confirmacionStock As DialogResult = MessageBox.Show($"El producto aún tiene {stockActual} unidades en stock." & vbCrLf &
                                                                     "¿Desea eliminarlo de todos modos?",
                                                                     "Stock existente",
                                                                     MessageBoxButtons.YesNo,
                                                                     MessageBoxIcon.Question)

                    If confirmacionStock <> DialogResult.Yes Then
                        Return
                    End If
                End If

                dtInventario.Rows.Remove(filasEncontradas(0))
            End If

            ' Actualizar la vista y guardar cambios
            ActualizarVistaInventario()
            GuardarEnExcel(dtInventario, "Inventario")

            ' Mensaje de éxito con detalles
            MessageBox.Show($"Producto eliminado exitosamente:" & vbCrLf & vbCrLf &
                      $"Código: {codigo}" & vbCrLf &
                      $"Nombre: {nombre}",
                      "Eliminación completada",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show($"Error al intentar eliminar el producto: {ex.Message}",
                      "Error crítico",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Error)
            ' Considera registrar el error en un log
        End Try
    End Sub
    Private Sub btnEditarInventario_Click(sender As Object, e As EventArgs) Handles btnEditarInventario.Click
        Try
            ' Verificar selección
            If dgvInventario.SelectedRows.Count = 0 OrElse dgvInventario.SelectedRows(0).IsNewRow Then
                MessageBox.Show("Seleccione un registro válido para editar.",
                          "Selección requerida",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Warning)
                Return
            End If

            ' Obtener fila seleccionada
            Dim filaSeleccionada As DataGridViewRow = dgvInventario.SelectedRows(0)

            ' Obtener datos actuales
            Dim codigo As String = filaSeleccionada.Cells("Código").Value?.ToString()
            Dim nombreActual As String = filaSeleccionada.Cells("Nombre").Value?.ToString()
            Dim cantidadActual As Integer = Convert.ToInt32(filaSeleccionada.Cells("Cantidad en Stock").Value)
            Dim tipoActual As String = filaSeleccionada.Cells("Tipo").Value?.ToString()

            ' Validar datos obtenidos
            If String.IsNullOrEmpty(codigo) OrElse String.IsNullOrEmpty(nombreActual) Then
                MessageBox.Show("No se pudieron obtener los datos completos del producto.",
                          "Error de datos",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Error)
                Return
            End If

            ' Obtener nuevos valores de los controles
            Dim nuevoNombre As String = txtNombreInventario.Text.Trim()
            Dim nuevaCantidad As Integer
            Dim nuevoTipo As String = cmbTipoInventario.SelectedItem?.ToString()

            ' Validar nuevos valores
            If String.IsNullOrEmpty(nuevoNombre) Then
                MessageBox.Show("El nombre no puede estar vacío.",
                          "Validación",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Warning)
                Return
            End If

            If Not Integer.TryParse(txtCantidadInventario.Text, nuevaCantidad) OrElse nuevaCantidad < 0 Then
                MessageBox.Show("Ingrese una cantidad válida (número entero positivo).",
                          "Validación",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Warning)
                Return
            End If

            ' Mostrar resumen de cambios
            Dim cambios As New StringBuilder()
            cambios.AppendLine("Resumen de cambios:")
            cambios.AppendLine($"Código: {codigo}")

            If nombreActual <> nuevoNombre Then
                cambios.AppendLine($"Nombre: {nombreActual} → {nuevoNombre}")
            End If

            If cantidadActual <> nuevaCantidad Then
                cambios.AppendLine($"Cantidad: {cantidadActual} → {nuevaCantidad}")
            End If

            If tipoActual <> nuevoTipo Then
                cambios.AppendLine($"Tipo: {tipoActual} → {nuevoTipo}")
            End If

            ' Si no hay cambios reales
            If nombreActual = nuevoNombre AndAlso cantidadActual = nuevaCantidad AndAlso tipoActual = nuevoTipo Then
                MessageBox.Show("No se detectaron cambios para guardar.",
                          "Sin cambios",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Information)
                Return
            End If

            ' Confirmación de cambios
            Dim confirmacion As DialogResult = MessageBox.Show(
            $"¿Confirmar los siguientes cambios?" & vbCrLf & vbCrLf &
            cambios.ToString() & vbCrLf &
            "Esta acción modificará permanentemente el registro.",
            "Confirmar edición",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button2)

            If confirmacion <> DialogResult.Yes Then
                Return
            End If

            ' Validación de seguridad
            Dim password As String = InputBox("Ingrese la contraseña de administrador para confirmar:",
                                        "Autenticación requerida")

            If password <> "Admin#2024" Then
                MessageBox.Show("Contraseña incorrecta. Operación cancelada.",
                          "Acceso denegado",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Stop)
                Return
            End If

            ' Buscar y actualizar el registro
            Dim filas = dtInventario.Select($"Código = '{codigo}'")
            If filas.Length > 0 Then
                Dim fila As DataRow = filas(0)
                fila("Nombre") = nuevoNombre
                fila("Cantidad en Stock") = nuevaCantidad
                fila("Tipo") = nuevoTipo

                ' Guardar cambios
                GuardarEnExcel(dtInventario, "Inventario")
                ActualizarVistaInventario()

                ' Mensaje de éxito
                MessageBox.Show($"Producto actualizado correctamente:" & vbCrLf & vbCrLf &
                          cambios.ToString(),
                          "Edición exitosa",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Information)
            Else
                MessageBox.Show("No se encontró el registro a editar.",
                          "Error",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show($"Error al editar el producto: {ex.Message}",
                      "Error crítico",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Error)
            ' Considera registrar el error en un log
        End Try
    End Sub

    Private Sub ActualizarVistaInventario()
        ' Forzar actualización del DataGridView
        dgvInventario.DataSource = Nothing
        dgvInventario.DataSource = dtInventario
        dgvInventario.Refresh()

        ' Ajustar columnas automáticamente
        dgvInventario.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
    End Sub
    Private Sub dgvInventario_SelectionChanged(sender As Object, e As EventArgs) Handles dgvInventario.SelectionChanged
        If dgvInventario.SelectedRows.Count > 0 AndAlso Not dgvInventario.SelectedRows(0).IsNewRow Then
            Dim fila = dgvInventario.SelectedRows(0)
            txtCodigoInventario.Text = fila.Cells("Código").Value?.ToString()
            txtNombreInventario.Text = fila.Cells("Nombre").Value?.ToString()
            txtCantidadInventario.Text = fila.Cells("Cantidad en Stock").Value?.ToString()

            ' Seleccionar el tipo correspondiente en el ComboBox
            Dim tipo = fila.Cells("Tipo").Value?.ToString()
            If tipo IsNot Nothing AndAlso cmbTipoInventario.Items.Contains(tipo) Then
                cmbTipoInventario.SelectedItem = tipo
            End If
        End If
    End Sub

    Private Sub btnLimpiarInventario_Click(sender As Object, e As EventArgs) Handles btnLimpiarInventario.Click
        txtCodigoInventario.Clear()
        txtNombreInventario.Clear()
        txtCantidadInventario.Clear()
        cmbTipoInventario.SelectedIndex = 0 ' Seleccionar "TODOS"
        AplicarFiltroInventario("") ' Limpiar filtros    
    End Sub
    Private Sub btnBuscarInventario_Click(sender As Object, e As EventArgs) Handles btnBuscarInventario.Click
        Try
            ' Obtener los valores de los campos de búsqueda
            Dim codigo As String = txtCodigoInventario.Text.Trim()
            Dim nombre As String = txtNombreInventario.Text.Trim()
            Dim cantidad As String = txtCantidadInventario.Text.Trim()
            Dim tipo As String = cmbTipoInventario.SelectedItem?.ToString() ' Nuevo: filtro por tipo

            ' Construir la consulta de filtrado de forma segura
            Dim condiciones As New List(Of String)

            If Not String.IsNullOrEmpty(codigo) Then
                condiciones.Add($"Código LIKE '%{EscapeLikeValue(codigo)}%'")
            End If

            If Not String.IsNullOrEmpty(nombre) Then
                condiciones.Add($"Nombre LIKE '%{EscapeLikeValue(nombre)}%'")
            End If

            If Not String.IsNullOrEmpty(cantidad) AndAlso IsNumeric(cantidad) Then
                condiciones.Add($"[Cantidad en Stock] = {Convert.ToInt32(cantidad)}")
            End If

            If Not String.IsNullOrEmpty(tipo) AndAlso tipo <> "TODOS" Then
                condiciones.Add($"Tipo = '{tipo}'")
            End If

            ' Combinar todas las condiciones con AND
            Dim filtro As String = String.Join(" AND ", condiciones)

            ' Aplicar el filtro
            AplicarFiltroInventario(filtro)

        Catch ex As Exception
            MessageBox.Show($"Error al buscar en el inventario: {ex.Message}",
                      "Error",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Error)
        End Try
    End Sub

    ' Método auxiliar para escapar caracteres especiales en búsquedas LIKE
    Private Function EscapeLikeValue(value As String) As String
        Dim sb As New StringBuilder(value)
        sb.Replace("[", "[[]")
        sb.Replace("%", "[%]")
        sb.Replace("_", "[_]")
        Return sb.ToString()
    End Function

    ' Método para aplicar el filtro al DataGridView
    Private Sub AplicarFiltroInventario(filtro As String)
        Try
            ' Aplicar el filtro al DataTable
            dtInventario.DefaultView.RowFilter = filtro

            ' Mostrar mensaje si no hay resultados
            If dtInventario.DefaultView.Count = 0 Then
                MessageBox.Show("No se encontraron productos con los criterios especificados.",
                          "Búsqueda sin resultados",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Information)
            End If

            ' Actualizar contador de resultados
            lblResultados.Text = $"Resultados: {dtInventario.DefaultView.Count} items"

        Catch ex As EvaluateException
            MessageBox.Show("Los criterios de búsqueda no son válidos.",
                      "Error en filtro",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show($"Error al aplicar el filtro: {ex.Message}",
                      "Error",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnImprimirInv_Click(sender As Object, e As EventArgs) Handles btnImprimirInv.Click
        Try
            ' Obtener el tipo de inventario seleccionado
            Dim tipoSeleccionado As String = cmbTipoInventario.SelectedItem?.ToString()

            ' Crear cuadro de diálogo para guardar
            Dim saveFileDialog As New SaveFileDialog()
            saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf"
            saveFileDialog.Title = "Guardar Inventario como PDF"

            ' Nombre del archivo según el tipo
            If String.IsNullOrEmpty(tipoSeleccionado) OrElse tipoSeleccionado = "TODOS" Then
                saveFileDialog.FileName = $"Inventario_Completo_{DateTime.Now:yyyyMMdd}.pdf"
            Else
                saveFileDialog.FileName = $"Inventario_{tipoSeleccionado}_{DateTime.Now:yyyyMMdd}.pdf"
            End If

            If saveFileDialog.ShowDialog() = DialogResult.OK Then
                ' Crear documento PDF horizontal
                Dim doc As New Document(PageSize.A4.Rotate())
                Dim writer As PdfWriter = PdfWriter.GetInstance(doc, New FileStream(saveFileDialog.FileName, FileMode.Create))

                doc.Open()

                ' Agregar logo
                Try
                    Dim logo As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(My.Resources.TEHIBA_logo, System.Drawing.Imaging.ImageFormat.Jpeg)
                    logo.ScaleToFit(200, 100)
                    logo.Alignment = iTextSharp.text.Image.ALIGN_CENTER
                    doc.Add(logo)
                Catch ex As Exception
                    ' Continuar sin logo si hay error
                End Try

                ' Título del reporte según el tipo
                Dim tituloReporte As String
                If String.IsNullOrEmpty(tipoSeleccionado) OrElse tipoSeleccionado = "TODOS" Then
                    tituloReporte = "Reporte de Inventario Completo"
                Else
                    tituloReporte = $"Reporte de Inventario - {tipoSeleccionado}"
                End If

                doc.Add(New Paragraph(tituloReporte, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16)))
                doc.Add(New Paragraph($"Fecha: {DateTime.Now:dd/MM/yyyy HH:mm}", FontFactory.GetFont(FontFactory.HELVETICA, 12)))
                doc.Add(New Paragraph(" ")) ' Espacio

                ' Filtrar datos según el tipo seleccionado
                Dim datosParaImprimir As IEnumerable(Of DataRow)

                If String.IsNullOrEmpty(tipoSeleccionado) OrElse tipoSeleccionado = "TODOS" Then
                    datosParaImprimir = dtInventario.Rows.Cast(Of DataRow)()
                Else
                    datosParaImprimir = dtInventario.Select($"Tipo = '{tipoSeleccionado}'")
                End If

                ' Crear tabla PDF
                Dim columnasVisibles As Integer = dgvInventario.Columns.Count
                Dim tableInventario As New PdfPTable(columnasVisibles)
                tableInventario.WidthPercentage = 100

                ' Agregar encabezados
                For Each column As DataGridViewColumn In dgvInventario.Columns
                    If column.Visible Then
                        Dim headerCell As New PdfPCell(New Phrase(column.HeaderText, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10)))
                        headerCell.BackgroundColor = New BaseColor(149, 26, 0) ' Color marrón
                        headerCell.HorizontalAlignment = Element.ALIGN_CENTER
                        tableInventario.AddCell(headerCell)
                    End If
                Next

                ' Agregar datos filtrados
                For Each row As DataRow In datosParaImprimir
                    For Each col As DataColumn In dtInventario.Columns
                        Dim cellValue As String = If(row.IsNull(col), String.Empty, row(col).ToString())
                        Dim cellPhrase As New Phrase(cellValue, FontFactory.GetFont(FontFactory.HELVETICA, 10))
                        Dim dataCell As New PdfPCell(cellPhrase)
                        dataCell.HorizontalAlignment = Element.ALIGN_CENTER
                        tableInventario.AddCell(dataCell)
                    Next
                Next

                doc.Add(tableInventario)

                ' Total de productos
                doc.Add(New Paragraph(" "))
                doc.Add(New Paragraph($"Total de productos: {datosParaImprimir.Count()}",
                           FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)))

                ' Cerrar documento
                doc.Close()

                MessageBox.Show($"Reporte generado exitosamente en:{vbCrLf}{saveFileDialog.FileName}",
                          "Éxito",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show($"Error al generar el PDF:{vbCrLf}{ex.Message}",
                      "Error",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Error)
        End Try
    End Sub
    Private Function VerificarDatosParaImprimir() As Boolean
        Dim tipoSeleccionado As String = cmbTipoInventario.SelectedItem?.ToString()

        If String.IsNullOrEmpty(tipoSeleccionado) Then
            MessageBox.Show("Seleccione un tipo de inventario.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Dim conteo As Integer
        If tipoSeleccionado = "TODOS" Then
            conteo = dtInventario.Rows.Count
        Else
            conteo = dtInventario.Select($"Tipo = '{tipoSeleccionado}'").Length
        End If

        If conteo = 0 Then
            MessageBox.Show($"No hay productos del tipo {tipoSeleccionado} para imprimir.",
                      "Sin datos",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Information)
            Return False
        End If

        Return True
    End Function

    '------------------------------------------------
    '--------------------------------------- Entradas
    '------------------------------------------------
    Private Sub btnGuardarEntradas_Click(sender As Object, e As EventArgs) Handles btnGuardarEntradas.Click
        Try
            ' Generar folio automático
            Dim folio As Integer = GenerarFolio()
            If folio = -1 Then Return ' Si hubo un error, salir

            ' Resto del código para guardar la entrada...
            Dim codigo As String = txtCodigoEntradas.Text.Trim()
            Dim cantidad As Integer
            If Not Integer.TryParse(txtCantidadEntradas.Text, cantidad) Then
                MessageBox.Show("Cantidad debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            Dim unidad As String = cmbUnidadEntrada.SelectedItem.ToString()
            Dim op As String = txtOPEntradas.Text.Trim()
            Dim proveedor As String = txtProveedorEntradas.Text.Trim()
            Dim fecha As String = dtpFechaEntradas.Value.ToShortDateString()
            Dim factura As String = txtFactura.Text.Trim()
            Dim oc As String = txtOC.Text.Trim()
            Dim pu As String = txtPU.Text.Trim()
            Dim lote As String = txtLoteEntradas.Text.Trim()
            Dim comentarios As String = txtComentariosEntradas.Text.Trim()

            ' Verificar si existe en el inventario
            Dim filaInventario = dtInventario.Select("Código = '" & codigo & "'")
            If filaInventario.Length = 0 Then
                MessageBox.Show("La pieza no está dada de alta en el inventario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Obtener el stock anterior
            Dim stockAnterior As Integer = Convert.ToInt32(filaInventario(0)("Cantidad en Stock"))

            ' Actualizar stock en el inventario
            Dim stockActual As Integer = stockAnterior + cantidad
            filaInventario(0)("Cantidad en Stock") = stockActual

            ' Actualizar el DataGridView de inventario
            dgvInventario.Refresh()

            ' Guardar en DataTable de entradas
            dtEntradas.Rows.Add(folio, codigo, txtNombreEntradas.Text, cantidad, unidad, op, proveedor, fecha, factura, oc, pu, lote, comentarios, stockAnterior, stockActual)
            dtReporteEntradas.Rows.Add(folio, codigo, txtNombreEntradas.Text, cantidad, unidad, op, proveedor, fecha, factura, oc, pu, lote, comentarios, stockAnterior, stockActual)

            ' Guardar cambios en el archivo de Excel
            GuardarEnExcel(dtInventario, "Inventario")
            GuardarEnExcel(dtEntradas, "Entradas")
            GuardarEnExcel(dtReporteEntradas, "Reporte Mensual ENtradas")

            MessageBox.Show("Guardado correctamente en Entradas y mandado al Reporte Mensual. Folio: " & folio, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Private Sub txtCodigoEntradas_TextChanged(sender As Object, e As EventArgs) Handles txtCodigoEntradas.TextChanged
        Dim codigo As String = txtCodigoEntradas.Text.Trim()

        If String.IsNullOrEmpty(codigo) Then
            ' Si el campo está vacío, habilitar los campos y limpiarlos
            txtNombreEntradas.Clear()
            txtCantidadStockEntradas.Clear()
            txtNombreEntradas.ReadOnly = False
            txtCantidadStockEntradas.ReadOnly = False
            Return
        End If

        ' Buscar el código en el inventario
        Dim filaInventario = dtInventario.Select("Código = '" & codigo & "'")
        If filaInventario.Length > 0 Then
            ' Si el código existe, llenar los campos y deshabilitarlos
            txtNombreEntradas.Text = filaInventario(0)("Nombre").ToString()
            txtCantidadStockEntradas.Text = filaInventario(0)("Cantidad en Stock").ToString()
            txtNombreEntradas.ReadOnly = True
            txtCantidadStockEntradas.ReadOnly = True
        Else
            ' Si el código no existe, habilitar los campos y limpiarlos
            txtNombreEntradas.Clear()
            txtCantidadStockEntradas.Clear()
            txtNombreEntradas.ReadOnly = False
            txtCantidadStockEntradas.ReadOnly = False
        End If
    End Sub

    Private Sub btnBuscarEntradas_Click(sender As Object, e As EventArgs) Handles btnBuscarEntradas.Click
        Try
            ' Obtener los valores de los campos de búsqueda
            Dim folio As String = txtFolioEntradas.Text.Trim() ' Nuevo campo para buscar por folio
            Dim codigo As String = txtCodigoEntradas.Text.Trim()
            Dim nombre As String = txtNombreEntradas.Text.Trim()
            Dim proveedor As String = txtProveedorEntradas.Text.Trim()
            Dim fecha As String = If(dtpFechaEntradas.Checked, dtpFechaEntradas.Value.ToShortDateString(), Nothing)
            Dim factura As String = txtFactura.Text.Trim()
            Dim oc As String = txtOC.Text.Trim()
            Dim pu As String = txtPU.Text.Trim()
            Dim lote As String = txtLoteEntradas.Text.Trim()
            Dim op As String = txtOPEntradas.Text.Trim()

            ' Construir la consulta de filtrado
            Dim filtro As String = ""

            ' Agregar el folio al filtro si no está vacío
            If Not String.IsNullOrEmpty(folio) Then
                filtro &= $"Folio = '{folio}' AND "
            End If

            If Not String.IsNullOrEmpty(codigo) Then
                filtro &= $"Código = '{codigo}' AND "
            End If

            If Not String.IsNullOrEmpty(nombre) Then
                filtro &= $"Nombre = '{nombre}' AND "
            End If

            If Not String.IsNullOrEmpty(proveedor) Then
                filtro &= $"Proveedor = '{proveedor}' AND "
            End If

            If Not String.IsNullOrEmpty(fecha) Then
                filtro &= $"Fecha = '{fecha}' AND "
            End If

            If Not String.IsNullOrEmpty(factura) Then
                filtro &= $"Factura = '{factura}' AND "
            End If

            If Not String.IsNullOrEmpty(oc) Then
                filtro &= $"OC = '{oc}' AND "
            End If

            If Not String.IsNullOrEmpty(pu) Then
                filtro &= $"PU = '{pu}' AND "
            End If

            If Not String.IsNullOrEmpty(lote) Then
                filtro &= $"Lote = '{lote}' AND "
            End If

            If Not String.IsNullOrEmpty(lote) Then
                filtro &= $"Lote = '{lote}' AND "
            End If

            ' Eliminar el último "AND " si hay un filtro
            If filtro.Length > 0 Then
                filtro = filtro.Substring(0, filtro.Length - 5) ' Eliminar " AND "
            End If

            ' Aplicar el filtro al DataTable de entradas
            Dim filasFiltradas As DataRow() = dtEntradas.Select(filtro)

            ' Crear un nuevo DataTable con las filas filtradas
            Dim dtFiltrado As DataTable = dtEntradas.Clone()
            For Each fila As DataRow In filasFiltradas
                dtFiltrado.ImportRow(fila)
            Next

            ' Mostrar los resultados en el DataGridView
            dgvEntradas.DataSource = dtFiltrado

            ' Si no se encontraron resultados, mostrar un mensaje
            If dtFiltrado.Rows.Count = 0 Then
                MessageBox.Show("No se encontraron entradas que coincidan con los criterios de búsqueda.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Error al buscar entradas: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnLimpiarEntradas_Click(sender As Object, e As EventArgs) Handles btnLimpiarEntradas.Click
        ' Restablecer el DataGridView para mostrar todas las entradas
        dgvEntradas.DataSource = dtEntradas

        ' Limpiar los campos de búsqueda (opcional)
        txtFolioEntradas.Clear() ' Limpiar el campo de folio
        txtCodigoEntradas.Clear()
        txtNombreEntradas.Clear()
        txtProveedorEntradas.Clear()
        txtFactura.Clear()
        txtOC.Clear()
        txtPU.Clear()
        txtLoteEntradas.Clear()
        txtCantidadEntradas.Clear()
        txtOPEntradas.Clear()
        txtComentariosEntradas.Clear()
        dtpFechaEntradas.Checked = False

        ' Mostrar un mensaje informativo (opcional)
        MessageBox.Show("Filtro limpiado. Mostrando todas las entradas.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnEliminarEntradas_Click(sender As Object, e As EventArgs) Handles btnEliminarEntradas.Click
        Try
            ' Verificar si se ha seleccionado una fila en el DataGridView de Entradas
            If dgvEntradas.SelectedRows.Count = 0 Then
                MessageBox.Show("Por favor, selecciona una entrada para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Obtener la fila seleccionada
            Dim filaSeleccionada As DataGridViewRow = dgvEntradas.SelectedRows(0)

            ' Obtener datos de la entrada
            Dim codigo As String = filaSeleccionada.Cells("Código").Value.ToString()
            Dim nombre As String = filaSeleccionada.Cells("Nombre").Value.ToString()
            Dim cantidad As Integer = Convert.ToInt32(filaSeleccionada.Cells("Cantidad").Value)
            Dim folio As Integer = Convert.ToInt32(filaSeleccionada.Cells("Folio").Value)
            Dim fecha As String = filaSeleccionada.Cells("Fecha").Value.ToString()
            Dim factura As String = filaSeleccionada.Cells("Factura").Value.ToString()
            Dim oc As String = filaSeleccionada.Cells("OC").Value.ToString()
            Dim pu As String = filaSeleccionada.Cells("PU").Value.ToString()
            Dim lote As String = filaSeleccionada.Cells("Lote").Value.ToString()
            Dim proveedor As String = filaSeleccionada.Cells("Proveedor").Value.ToString()

            ' Mostrar mensaje de confirmación con detalles
            Dim confirmacion As DialogResult = MessageBox.Show($"¿Está seguro que desea eliminar esta entrada?" & vbCrLf & vbCrLf &
                                                         $"Folio: {folio}" & vbCrLf &
                                                         $"Código: {codigo}" & vbCrLf &
                                                         $"Nombre: {nombre}" & vbCrLf &
                                                         $"Cantidad: {cantidad}" & vbCrLf &
                                                         $"Proveedor: {proveedor}" & vbCrLf &
                                                         $"Fecha: {fecha}" & vbCrLf & vbCrLf &
                                                         $"Factura: {factura}" & vbCrLf & vbCrLf &
                                                         $"OC: {oc}" & vbCrLf & vbCrLf &
                                                         $"PU: {pu}" & vbCrLf & vbCrLf &
                                                         $"Lote: {lote}" & vbCrLf & vbCrLf &
                                                         "Esta acción también actualizará el inventario.",
                                                         "Confirmar eliminación de entrada",
                                                         MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Warning)

            If confirmacion <> DialogResult.Yes Then
                Return ' Si el usuario no confirma, salir del método
            End If

            ' Solicitar contraseña
            Dim password As String = InputBox("Ingrese la contraseña de administrador para confirmar la eliminación:", "Validación de contraseña")

            ' Verificar contraseña (la contraseña es "123")
            If password <> "Admin#2024" Then
                MessageBox.Show("Contraseña incorrecta. La eliminación ha sido cancelada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Confirmación final con impacto en inventario
            Dim stockAnterior As Integer = Convert.ToInt32(filaSeleccionada.Cells("Stock Anterior").Value)
            Dim stockActual As Integer = Convert.ToInt32(filaSeleccionada.Cells("Stock Actual").Value)

            Dim confirmacionFinal As DialogResult = MessageBox.Show($"ESTA ACCIÓN MODIFICARÁ EL INVENTARIO:" & vbCrLf & vbCrLf &
                                                              $"Stock actual: {stockActual}" & vbCrLf &
                                                              $"Se revertirá a: {stockAnterior}" & vbCrLf & vbCrLf &
                                                              "¿Desea continuar con la eliminación?",
                                                              "Confirmación final - Impacto en Inventario",
                                                              MessageBoxButtons.YesNo,
                                                              MessageBoxIcon.Exclamation)

            If confirmacionFinal <> DialogResult.Yes Then
                MessageBox.Show("Eliminación cancelada. No se realizaron cambios en el inventario.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            ' Buscar la entrada en la tabla dtEntradas y eliminarla
            Dim filaEntrada = dtEntradas.Select("Código = '" & codigo & "' AND Folio = " & folio)
            If filaEntrada.Length > 0 Then
                dtEntradas.Rows.Remove(filaEntrada(0))
            End If

            ' Buscar el producto en el inventario
            Dim filaInventario = dtInventario.Select("Código = '" & codigo & "'")
            If filaInventario.Length > 0 Then
                ' Revertir el stock a su valor anterior
                filaInventario(0)("Cantidad en Stock") = stockAnterior
                dgvInventario.Refresh()
            End If

            ' Marcar como "Eliminado" en el reporte de entradas
            Dim filaReporte = dtReporteEntradas.Select("Código = '" & codigo & "' AND Folio = " & folio)
            If filaReporte.Length > 0 Then
                filaReporte(0)("Comentarios") = "Eliminado el " & DateTime.Now.ToString("dd/MM/yyyy")
            End If

            ' Actualizar vistas
            dgvEntradas.Refresh()
            dgvReporte.Refresh()

            ' Guardar cambios
            GuardarEnExcel(dtEntradas, "Entradas")
            GuardarEnExcel(dtInventario, "Inventario")
            GuardarEnExcel(dtReporteEntradas, "Reporte Mensual ENtradas")

            MessageBox.Show($"Entrada eliminada correctamente." & vbCrLf &
                      $"Inventario actualizado: {nombre} ahora tiene {stockAnterior} unidades.",
                      "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error al eliminar la entrada: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CopiarFilaAOtroDataGridView(fila As DataGridViewRow, dgvDestino As DataGridView)
        ' Crear una nueva fila en el DataGridView de destino
        Dim nuevaFila As DataGridViewRow = CType(fila.Clone(), DataGridViewRow)

        ' Copiar los valores de cada celda
        For i As Integer = 0 To fila.Cells.Count - 1
            nuevaFila.Cells(i).Value = fila.Cells(i).Value
        Next

        ' Agregar la nueva fila al DataGridView de destino
        dgvDestino.Rows.Add(nuevaFila)
    End Sub

    Private Sub btnReportarEntrada_Click(sender As Object, e As EventArgs) Handles btnReportarEntrada.Click
        Try
            ' Verificar si se ha seleccionado una fila en dgvEntradas
            If dgvEntradas.SelectedRows.Count = 0 Then
                MessageBox.Show("Por favor, selecciona un registro en la tabla de entradas.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Obtener la fila seleccionada en dgvEntradas
            Dim filaSeleccionada As DataGridViewRow = dgvEntradas.SelectedRows(0)

            ' Verificar si dgvReporteEntradasEsp está vinculado a un DataTable
            If dgvReporteEntradasEsp.DataSource IsNot Nothing AndAlso TypeOf dgvReporteEntradasEsp.DataSource Is DataTable Then
                Dim dtDestino As DataTable = CType(dgvReporteEntradasEsp.DataSource, DataTable)

                ' Crear una nueva fila en el DataTable de destino
                Dim nuevaFila As DataRow = dtDestino.NewRow()

                ' Copiar los valores de cada celda
                For i As Integer = 0 To filaSeleccionada.Cells.Count - 1
                    nuevaFila(i) = filaSeleccionada.Cells(i).Value
                Next

                ' Agregar la nueva fila al DataTable de destino
                dtDestino.Rows.Add(nuevaFila)

                ' Actualizar el DataGridView para reflejar los cambios
                dgvReporteEntradasEsp.Refresh()
            Else
                MessageBox.Show("El DataGridView de destino no está vinculado a un DataTable.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            MessageBox.Show("Registro reportado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error al reportar la entrada: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '------------------------------------------------
    '---------------------------------------- Salidas
    '------------------------------------------------
    Private Sub btnGuardarSalidas_Click(sender As Object, e As EventArgs) Handles btnGuardarSalidas.Click
        Try
            ' Generar folio automático
            Dim folio As Integer = GenerarFolio()
            If folio = -1 Then Return ' Si hubo un error, salir

            ' Resto del código para guardar la salida...
            Dim codigo As String = txtCodigoSalidas.Text.Trim()
            Dim cantidad As Integer
            If Not Integer.TryParse(txtCantidadSalidas.Text, cantidad) Then
                MessageBox.Show("Cantidad debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            Dim unidad As String = cmbUnidadSalidas.SelectedItem.ToString()
            Dim op As String = txtOPSalidas.Text.Trim()
            Dim destino As String = txtDestinoSalidas.Text.Trim()
            Dim fecha As String = dtpFechaSalidas.Value.ToShortDateString()
            Dim lote As String = txtLoteSalidas.Text.Trim()
            Dim comentarios As String = txtComentariosSalidas.Text.Trim()

            ' Verificar si existe en el inventario
            Dim filaInventario = dtInventario.Select("Código = '" & codigo & "'")
            If filaInventario.Length = 0 Then
                MessageBox.Show("La pieza no está dada de alta en el inventario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Obtener el stock anterior
            Dim stockAnterior As Integer = Convert.ToInt32(filaInventario(0)("Cantidad en Stock"))

            ' Validar que haya suficiente stock
            If stockAnterior < cantidad Then
                MessageBox.Show("No hay suficiente stock para realizar la salida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Actualizar stock en el inventario
            Dim stockActual As Integer = stockAnterior - cantidad
            filaInventario(0)("Cantidad en Stock") = stockActual

            ' Actualizar el DataGridView de inventario
            dgvInventario.Refresh()

            ' Guardar en DataTable de salidas
            dtSalidas.Rows.Add(folio, codigo, txtNombreSalidas.Text, cantidad, unidad, op, destino, fecha, lote, comentarios, stockAnterior, stockActual)
            dtReporteSalidas.Rows.Add(folio, codigo, txtNombreSalidas.Text, cantidad, unidad, op, destino, fecha, lote, comentarios, stockAnterior, stockActual)

            ' Guardar cambios en el archivo de Excel
            GuardarEnExcel(dtInventario, "Inventario")
            GuardarEnExcel(dtSalidas, "Salidas")
            GuardarEnExcel(dtReporteSalidas, "Reporte Mensual Salidas")

            MessageBox.Show("Guardado correctamente en Salidas y mandado al Reporte Mensual. Folio: " & folio, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub txtCodigoSalidas_TextChanged(sender As Object, e As EventArgs) Handles txtCodigoSalidas.TextChanged
        Dim codigo As String = txtCodigoSalidas.Text.Trim()

        If String.IsNullOrEmpty(codigo) Then
            ' Si el campo está vacío, habilitar los campos y limpiarlos
            txtNombreSalidas.Clear()
            txtCantidadStockSalidas.Clear()
            txtNombreSalidas.ReadOnly = False
            txtCantidadStockSalidas.ReadOnly = False
            Return
        End If

        ' Buscar el código en el inventario
        Dim filaInventario = dtInventario.Select("Código = '" & codigo & "'")
        If filaInventario.Length > 0 Then
            ' Si el código existe, llenar los campos y deshabilitarlos
            txtNombreSalidas.Text = filaInventario(0)("Nombre").ToString()
            txtCantidadStockSalidas.Text = filaInventario(0)("Cantidad en Stock").ToString()
            txtNombreSalidas.ReadOnly = True
            txtCantidadStockSalidas.ReadOnly = True
        Else
            ' Si el código no existe, habilitar los campos y limpiarlos
            txtNombreSalidas.Clear()
            txtCantidadStockSalidas.Clear()
            txtNombreSalidas.ReadOnly = False
            txtCantidadStockSalidas.ReadOnly = False
        End If
    End Sub
    Private Sub btnBuscarSalidas_Click(sender As Object, e As EventArgs) Handles btnBuscarSalidas.Click
        Try
            ' Obtener los valores de los campos de búsqueda
            Dim folio As String = txtFolioSalidas.Text.Trim() ' Nuevo campo para buscar por folio
            Dim codigo As String = txtCodigoSalidas.Text.Trim()
            Dim nombre As String = txtNombreSalidas.Text.Trim()
            Dim personal As String = txtDestinoSalidas.Text.Trim()
            Dim fecha As String = If(dtpFechaSalidas.Checked, dtpFechaSalidas.Value.ToShortDateString(), Nothing)
            Dim lote As String = txtLoteSalidas.Text.Trim()
            Dim op As String = txtOPSalidas.Text.Trim()

            ' Construir la consulta de filtrado
            Dim filtro As String = ""

            ' Agregar el folio al filtro si no está vacío
            If Not String.IsNullOrEmpty(folio) Then
                filtro &= $"Folio = '{folio}' AND "
            End If

            If Not String.IsNullOrEmpty(codigo) Then
                filtro &= $"Código = '{codigo}' AND "
            End If

            If Not String.IsNullOrEmpty(nombre) Then
                filtro &= $"Nombre = '{nombre}' AND "
            End If

            If Not String.IsNullOrEmpty(personal) Then
                filtro &= $"Personal = '{personal}' AND "
            End If

            If Not String.IsNullOrEmpty(fecha) Then
                filtro &= $"Fecha = '{fecha}' AND "
            End If

            If Not String.IsNullOrEmpty(lote) Then
                filtro &= $"Lote = '{lote}' AND "
            End If

            If Not String.IsNullOrEmpty(op) Then
                filtro &= $"OP = '{op}' AND "
            End If

            ' Eliminar el último "AND " si hay un filtro
            If filtro.Length > 0 Then
                filtro = filtro.Substring(0, filtro.Length - 5) ' Eliminar " AND "
            End If

            ' Aplicar el filtro al DataTable de salidas
            Dim filasFiltradas As DataRow() = dtSalidas.Select(filtro)

            ' Crear un nuevo DataTable con las filas filtradas
            Dim dtFiltrado As DataTable = dtSalidas.Clone()
            For Each fila As DataRow In filasFiltradas
                dtFiltrado.ImportRow(fila)
            Next

            ' Mostrar los resultados en el DataGridView
            dgvSalidas.DataSource = dtFiltrado

            ' Si no se encontraron resultados, mostrar un mensaje
            If dtFiltrado.Rows.Count = 0 Then
                MessageBox.Show("No se encontraron salidas que coincidan con los criterios de búsqueda.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Error al buscar salidas: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnLimpiarSalidas_Click(sender As Object, e As EventArgs) Handles btnLimpiarSalidas.Click
        ' Restablecer el DataGridView para mostrar todas las salidas
        dgvSalidas.DataSource = dtSalidas

        ' Limpiar los campos de búsqueda (opcional)
        txtFolioSalidas.Clear() ' Limpiar el campo de folio
        txtCodigoSalidas.Clear()
        txtNombreSalidas.Clear()
        txtDestinoSalidas.Clear()
        txtOPSalidas.Clear()
        txtComentariosSalidas.Clear()
        txtCantidadSalidas.Clear()
        txtLoteSalidas.Clear()
        dtpFechaSalidas.Checked = False

        ' Mostrar un mensaje informativo (opcional)
        MessageBox.Show("Filtro limpiado. Mostrando todas las salidas.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnEliminarSalidas_Click(sender As Object, e As EventArgs) Handles btnEliminarSalidas.Click
        Try
            ' Verificar si se ha seleccionado una fila en el DataGridView de Salidas
            If dgvSalidas.SelectedRows.Count = 0 Then
                MessageBox.Show("Por favor, selecciona una salida para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Obtener la fila seleccionada
            Dim filaSeleccionada As DataGridViewRow = dgvSalidas.SelectedRows(0)

            ' Obtener datos de la salida
            Dim codigo As String = filaSeleccionada.Cells("Código").Value.ToString()
            Dim nombre As String = filaSeleccionada.Cells("Nombre").Value.ToString()
            Dim cantidad As Integer = Convert.ToInt32(filaSeleccionada.Cells("Cantidad").Value)
            Dim folio As Integer = Convert.ToInt32(filaSeleccionada.Cells("Folio").Value)
            Dim fecha As String = filaSeleccionada.Cells("Fecha").Value.ToString()
            Dim lote As String = filaSeleccionada.Cells("Lote").Value.ToString()
            Dim personal As String = filaSeleccionada.Cells("Personal").Value.ToString()
            Dim stockAnterior As Integer = Convert.ToInt32(filaSeleccionada.Cells("Stock Anterior").Value)
            Dim stockActual As Integer = Convert.ToInt32(filaSeleccionada.Cells("Stock Actual").Value)

            ' Mostrar mensaje de confirmación con detalles
            Dim confirmacion As DialogResult = MessageBox.Show($"¿Está seguro que desea eliminar esta salida?" & vbCrLf & vbCrLf &
                                                         $"Folio: {folio}" & vbCrLf &
                                                         $"Código: {codigo}" & vbCrLf &
                                                         $"Nombre: {nombre}" & vbCrLf &
                                                         $"Cantidad: {cantidad}" & vbCrLf &
                                                         $"Personal: {personal}" & vbCrLf &
                                                         $"Fecha: {fecha}" & vbCrLf & vbCrLf &
                                                         $"Lote: {lote}" & vbCrLf &
                                                         "Esta acción también actualizará el inventario.",
                                                         "Confirmar eliminación de salida",
                                                         MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Warning)

            If confirmacion <> DialogResult.Yes Then
                Return ' Si el usuario no confirma, salir del método
            End If

            ' Solicitar contraseña
            Dim password As String = InputBox("Ingrese la contraseña del administrador para confirmar la eliminación:", "Validación de contraseña")

            ' Verificar contraseña (la contraseña es "123")
            If password <> "Admin#2024" Then
                MessageBox.Show("Contraseña incorrecta. La eliminación ha sido cancelada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Confirmación final con impacto en inventario
            Dim confirmacionFinal As DialogResult = MessageBox.Show($"ESTA ACCIÓN MODIFICARÁ EL INVENTARIO:" & vbCrLf & vbCrLf &
                                                              $"Stock actual: {stockActual}" & vbCrLf &
                                                              $"Se actualizará a: {stockAnterior + cantidad}" & vbCrLf & vbCrLf &
                                                              "¿Desea continuar con la eliminación?",
                                                              "Confirmación final - Impacto en Inventario",
                                                              MessageBoxButtons.YesNo,
                                                              MessageBoxIcon.Exclamation)

            If confirmacionFinal <> DialogResult.Yes Then
                MessageBox.Show("Eliminación cancelada. No se realizaron cambios en el inventario.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            ' Buscar la salida en la tabla dtSalidas y eliminarla
            Dim filaSalida = dtSalidas.Select("Código = '" & codigo & "' AND Folio = " & folio)
            If filaSalida.Length > 0 Then
                dtSalidas.Rows.Remove(filaSalida(0))
            End If

            ' Buscar el producto en el inventario
            Dim filaInventario = dtInventario.Select("Código = '" & codigo & "'")
            If filaInventario.Length > 0 Then
                ' Revertir el stock sumando la cantidad eliminada
                filaInventario(0)("Cantidad en Stock") = stockActual + cantidad
                dgvInventario.Refresh()
            End If

            ' Marcar como "Eliminado" en el reporte de salidas
            Dim filaReporte = dtReporteSalidas.Select("Código = '" & codigo & "' AND Folio = " & folio)
            If filaReporte.Length > 0 Then
                filaReporte(0)("Comentarios") = "Eliminado el " & DateTime.Now.ToString("dd/MM/yyyy")
            End If

            ' Actualizar vistas
            dgvSalidas.Refresh()
            dgvReporteSalidas.Refresh()

            ' Guardar cambios
            GuardarEnExcel(dtSalidas, "Salidas")
            GuardarEnExcel(dtInventario, "Inventario")
            GuardarEnExcel(dtReporteSalidas, "Reporte Mensual Salidas")

            MessageBox.Show($"Salida eliminada correctamente." & vbCrLf &
                      $"Inventario actualizado: {nombre} ahora tiene {stockActual + cantidad} unidades.",
                      "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error al eliminar la salida: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnReportarSalidas_Click(sender As Object, e As EventArgs) Handles btnReportarSalidas.Click
        Try
            ' Verificar si se ha seleccionado una fila en dgvSalidas
            If dgvSalidas.SelectedRows.Count = 0 Then
                MessageBox.Show("Por favor, selecciona un registro en la tabla de salidas.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Obtener la fila seleccionada en dgvSalidas
            Dim filaSeleccionada As DataGridViewRow = dgvSalidas.SelectedRows(0)

            ' Verificar si dgvReporteSalidasEsp está vinculado a un DataTable
            If dgvReporteSalidasEsp.DataSource IsNot Nothing AndAlso TypeOf dgvReporteSalidasEsp.DataSource Is DataTable Then
                Dim dtDestino As DataTable = CType(dgvReporteSalidasEsp.DataSource, DataTable)

                ' Crear una nueva fila en el DataTable de destino
                Dim nuevaFila As DataRow = dtDestino.NewRow()

                ' Copiar los valores de cada celda
                For i As Integer = 0 To filaSeleccionada.Cells.Count - 1
                    nuevaFila(i) = filaSeleccionada.Cells(i).Value
                Next

                ' Agregar la nueva fila al DataTable de destino
                dtDestino.Rows.Add(nuevaFila)

                ' Actualizar el DataGridView para reflejar los cambios
                dgvReporteSalidasEsp.Refresh()
            Else
                MessageBox.Show("El DataGridView de destino no está vinculado a un DataTable.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            MessageBox.Show("Registro reportado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error al reportar la salida: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    '------------------------------------------------
    '-------------------------------- Reporte Mensual
    '------------------------------------------------
    Private Sub btnImprimirMensual_Click(sender As Object, e As EventArgs) Handles btnImprimirMensual.Click
        Try
            ' Crear un cuadro de diálogo para guardar el archivo
            Dim saveFileDialog As New SaveFileDialog()
            saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf"
            saveFileDialog.Title = "Guardar PDF"
            saveFileDialog.FileName = "ReporteMensual.pdf"

            If saveFileDialog.ShowDialog() = DialogResult.OK Then
                ' Crear el documento PDF en formato horizontal
                Dim doc As New Document(PageSize.A4.Rotate()) ' Horizontal
                Dim writer As PdfWriter = PdfWriter.GetInstance(doc, New FileStream(saveFileDialog.FileName, FileMode.Create))

                doc.Open()

                ' Agregar la imagen desde los recursos del proyecto
                Try
                    ' Obtener la imagen desde los recursos
                    Dim logo As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(My.Resources.TEHIBA_logo, System.Drawing.Imaging.ImageFormat.Jpeg)
                    logo.ScaleToFit(200, 100) ' Ajustar el tamaño de la imagen
                    logo.Alignment = iTextSharp.text.Image.ALIGN_CENTER
                    doc.Add(logo)
                Catch ex As Exception
                    MessageBox.Show("Error al cargar la imagen: " & ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Try

                ' Agregar un título y la fecha
                doc.Add(New Paragraph("Reporte Mensual de Entradas y Salidas", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14)))
                doc.Add(New Paragraph("Fecha: " & DateTime.Now.ToString("dd/MM/yyyy HH:mm"), FontFactory.GetFont(FontFactory.HELVETICA, 12)))
                doc.Add(New Paragraph(" ")) ' Espacio en blanco

                ' Agregar título para la tabla de Entradas
                doc.Add(New Paragraph("Entradas", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)))
                doc.Add(New Paragraph(" ")) ' Espacio en blanco

                ' Crear una tabla para las Entradas
                Dim tableEntradas As New PdfPTable(dgvReporte.Columns.Count)
                tableEntradas.WidthPercentage = 100

                ' Agregar encabezados de las columnas (Entradas)
                For Each column As DataGridViewColumn In dgvReporte.Columns
                    Dim headerCell As New PdfPCell(New Phrase(column.HeaderText, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10)))
                    headerCell.BackgroundColor = New BaseColor(149, 26, 0) ' Color de fondo (marrón)
                    headerCell.HorizontalAlignment = Element.ALIGN_CENTER
                    tableEntradas.AddCell(headerCell)
                Next

                ' Agregar los datos de cada fila (Entradas)
                For Each row As DataGridViewRow In dgvReporte.Rows
                    If Not row.IsNewRow Then
                        For Each cell As DataGridViewCell In row.Cells
                            Dim cellValue As String = If(cell.Value IsNot Nothing, cell.Value.ToString(), "")
                            Dim cellPhrase As New Phrase(cellValue, FontFactory.GetFont(FontFactory.HELVETICA, 10))
                            Dim dataCell As New PdfPCell(cellPhrase)
                            dataCell.HorizontalAlignment = Element.ALIGN_CENTER
                            tableEntradas.AddCell(dataCell)
                        Next
                    End If
                Next

                ' Agregar la tabla de Entradas al documento
                doc.Add(tableEntradas)
                doc.Add(New Paragraph(" ")) ' Espacio en blanco

                ' Agregar título para la tabla de Salidas
                doc.Add(New Paragraph("Salidas", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)))
                doc.Add(New Paragraph(" ")) ' Espacio en blanco

                ' Crear una tabla para las Salidas
                Dim tableSalidas As New PdfPTable(dgvReporteSalidas.Columns.Count)
                tableSalidas.WidthPercentage = 100

                ' Agregar encabezados de las columnas (Salidas)
                For Each column As DataGridViewColumn In dgvReporteSalidas.Columns
                    Dim headerCell As New PdfPCell(New Phrase(column.HeaderText, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10)))
                    headerCell.BackgroundColor = New BaseColor(149, 26, 0) ' Color de fondo (marrón)
                    headerCell.HorizontalAlignment = Element.ALIGN_CENTER
                    tableSalidas.AddCell(headerCell)
                Next

                ' Agregar los datos de cada fila (Salidas)
                For Each row As DataGridViewRow In dgvReporteSalidas.Rows
                    If Not row.IsNewRow Then
                        For Each cell As DataGridViewCell In row.Cells
                            Dim cellValue As String = If(cell.Value IsNot Nothing, cell.Value.ToString(), "")
                            Dim cellPhrase As New Phrase(cellValue, FontFactory.GetFont(FontFactory.HELVETICA, 10))
                            Dim dataCell As New PdfPCell(cellPhrase)
                            dataCell.HorizontalAlignment = Element.ALIGN_CENTER
                            tableSalidas.AddCell(dataCell)
                        Next
                    End If
                Next

                ' Agregar la tabla de Salidas al documento
                doc.Add(tableSalidas)

                ' Cerrar el documento
                doc.Close()

                MessageBox.Show("Reporte PDF guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Error al generar el reporte: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FiltrarDataGridViewPorRango(dgv As DataGridView, fechaInicio As DateTime, fechaFinal As DateTime)
        ' Recorrer todas las filas del DataGridView
        For Each row As DataGridViewRow In dgv.Rows
            ' Verificar si la fila no es nueva
            If Not row.IsNewRow Then
                ' Obtener el valor de la celda que contiene la fecha (ajusta el nombre de la columna según tu caso)
                Dim fechaCelda As DateTime
                If DateTime.TryParse(row.Cells("Fecha").Value.ToString(), fechaCelda) Then
                    ' Mostrar u ocultar la fila según el rango de fechas
                    If fechaCelda >= fechaInicio AndAlso fechaCelda <= fechaFinal Then
                        row.Visible = True ' Mostrar la fila
                    Else
                        row.Visible = False ' Ocultar la fila
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub btnRango_Click(sender As Object, e As EventArgs) Handles btnRango.Click
        Try
            ' Obtener las fechas seleccionadas
            Dim fechaInicio As DateTime = dtpInicio.Value
            Dim fechaFinal As DateTime = dtpFinal.Value

            ' Asegurarse de que la fecha final sea mayor o igual a la fecha de inicio
            If fechaFinal < fechaInicio Then
                MessageBox.Show("La fecha final debe ser mayor o igual a la fecha de inicio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Filtrar dgvReporte (Entradas)
            FiltrarDataGridView(dgvReporte, fechaInicio, fechaFinal)

            ' Filtrar dgvReporteSalidas (Salidas)
            FiltrarDataGridView(dgvReporteSalidas, fechaInicio, fechaFinal)

            MessageBox.Show("Datos filtrados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error al filtrar los datos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FiltrarDataGridView(dgv As DataGridView, fechaInicio As DateTime, fechaFinal As DateTime)
        ' Verificar si el DataGridView está vinculado a un DataTable
        If dgv.DataSource IsNot Nothing AndAlso TypeOf dgv.DataSource Is DataTable Then
            Dim dt As DataTable = CType(dgv.DataSource, DataTable)

            ' Aplicar filtro a la vista del DataTable
            dt.DefaultView.RowFilter = $"Fecha >= #{fechaInicio.ToString("yyyy-MM-dd")}# AND Fecha <= #{fechaFinal.ToString("yyyy-MM-dd")}#"
        Else
            MessageBox.Show("El DataGridView no está vinculado a un DataTable.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub LimpiarFiltroDataGridView(dgv As DataGridView)
        ' Verificar si el DataGridView está vinculado a un DataTable
        If dgv.DataSource IsNot Nothing AndAlso TypeOf dgv.DataSource Is DataTable Then
            Dim dt As DataTable = CType(dgv.DataSource, DataTable)

            ' Limpiar el filtro de la vista del DataTable
            dt.DefaultView.RowFilter = ""
        Else
            ' Si no está vinculado a un DataTable, mostrar todas las filas manualmente
            For Each row As DataGridViewRow In dgv.Rows
                row.Visible = True
            Next
        End If
    End Sub
    Private Sub btnLimpiarReporteMensual_Click(sender As Object, e As EventArgs) Handles btnLimpiarReporteMensual.Click
        Try
            ' Limpiar el filtro de fechas en dgvReporte (Entradas)
            LimpiarFiltroDataGridView(dgvReporte)

            ' Limpiar el filtro de fechas en dgvReporteSalidas (Salidas)
            LimpiarFiltroDataGridView(dgvReporteSalidas)

            MessageBox.Show("Filtro de fechas limpiado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error al limpiar el filtro: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnReportarMesEntradas_Click(sender As Object, e As EventArgs) Handles btnReportarMesEntradas.Click
        Try
            ' Obtener las fechas seleccionadas
            Dim fechaInicio As DateTime = dtpInicio.Value
            Dim fechaFinal As DateTime = dtpFinal.Value

            ' Asegurarse de que la fecha final sea mayor o igual a la fecha de inicio
            If fechaFinal < fechaInicio Then
                MessageBox.Show("La fecha final debe ser mayor o igual a la fecha de inicio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Verificar si la tabla fuente (dtReporteEntradas) tiene datos
            If dtReporteEntradas Is Nothing OrElse dtReporteEntradas.Rows.Count = 0 Then
                MessageBox.Show("No hay datos en la tabla de reporte de entradas.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Filtrar los registros de dtReporteEntradas dentro del rango de fechas
            Dim filtro As String = $"Fecha >= #{fechaInicio.ToString("yyyy-MM-dd")}# AND Fecha <= #{fechaFinal.ToString("yyyy-MM-dd")}#"
            Dim filasFiltradas As DataRow() = dtReporteEntradas.Select(filtro)

            ' Verificar si hay registros filtrados
            If filasFiltradas.Length = 0 Then
                MessageBox.Show("No hay registros en el rango de fechas seleccionado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Copiar las filas filtradas a dtReporteEntradasEsp
            For Each fila As DataRow In filasFiltradas
                Dim nuevaFila As DataRow = dtReporteEntradasEsp.NewRow()
                nuevaFila.ItemArray = fila.ItemArray ' Copiar los valores de la fila
                dtReporteEntradasEsp.Rows.Add(nuevaFila)
            Next

            ' Actualizar el DataGridView que muestra dtReporteEntradasEsp (si está vinculado)
            If dgvReporteEntradasEsp.DataSource IsNot Nothing AndAlso TypeOf dgvReporteEntradasEsp.DataSource Is DataTable Then
                dgvReporteEntradasEsp.Refresh()
            End If

            MessageBox.Show("Registros filtrados copiados correctamente a la tabla de reporte específico.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error al copiar los datos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnReportarMesSalidas_Click(sender As Object, e As EventArgs) Handles btnReportarMesSalidas.Click
        Try
            ' Obtener las fechas seleccionadas
            Dim fechaInicio As DateTime = dtpInicio.Value
            Dim fechaFinal As DateTime = dtpFinal.Value

            ' Asegurarse de que la fecha final sea mayor o igual a la fecha de inicio
            If fechaFinal < fechaInicio Then
                MessageBox.Show("La fecha final debe ser mayor o igual a la fecha de inicio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Verificar si la tabla fuente (dtReporteSalidas) tiene datos
            If dtReporteSalidas Is Nothing OrElse dtReporteSalidas.Rows.Count = 0 Then
                MessageBox.Show("No hay datos en la tabla de reporte de salidas.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Filtrar los registros de dtReporteSalidas dentro del rango de fechas
            Dim filtro As String = $"Fecha >= #{fechaInicio.ToString("yyyy-MM-dd")}# AND Fecha <= #{fechaFinal.ToString("yyyy-MM-dd")}#"
            Dim filasFiltradas As DataRow() = dtReporteSalidas.Select(filtro)

            ' Verificar si hay registros filtrados
            If filasFiltradas.Length = 0 Then
                MessageBox.Show("No hay registros en el rango de fechas seleccionado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Limpiar la tabla de destino (dtReporteSalidasEsp) antes de copiar los datos
            dtReporteSalidasEsp.Clear()

            ' Copiar las filas filtradas a dtReporteSalidasEsp
            For Each fila As DataRow In filasFiltradas
                Dim nuevaFila As DataRow = dtReporteSalidasEsp.NewRow()
                nuevaFila.ItemArray = fila.ItemArray ' Copiar los valores de la fila
                dtReporteSalidasEsp.Rows.Add(nuevaFila)
            Next

            ' Actualizar el DataGridView que muestra dtReporteSalidasEsp (si está vinculado)
            If dgvReporteSalidasEsp.DataSource IsNot Nothing AndAlso TypeOf dgvReporteSalidasEsp.DataSource Is DataTable Then
                dgvReporteSalidasEsp.Refresh()
            End If

            MessageBox.Show("Registros filtrados copiados correctamente a la tabla de reporte específico.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error al copiar los datos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '------------------------------------------------
    '--------------------- Reporte Mensual Específico
    '------------------------------------------------

    Private Sub btnImprimirMesEsp_Click(sender As Object, e As EventArgs) Handles btnImprimirMesEsp.Click
        Try
            ' Crear un cuadro de diálogo para guardar el archivo
            Dim saveFileDialog As New SaveFileDialog()
            saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf"
            saveFileDialog.Title = "Guardar PDF"
            saveFileDialog.FileName = "ReporteEspecifico.pdf"

            If saveFileDialog.ShowDialog() = DialogResult.OK Then
                ' Crear el documento PDF en formato horizontal
                Dim doc As New Document(PageSize.A4.Rotate()) ' Horizontal
                Dim writer As PdfWriter = PdfWriter.GetInstance(doc, New FileStream(saveFileDialog.FileName, FileMode.Create))

                doc.Open()

                ' Agregar la imagen desde los recursos del proyecto
                Try
                    ' Obtener la imagen desde los recursos
                    Dim logo As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(My.Resources.TEHIBA_logo, System.Drawing.Imaging.ImageFormat.Jpeg)
                    logo.ScaleToFit(200, 100) ' Ajustar el tamaño de la imagen
                    logo.Alignment = iTextSharp.text.Image.ALIGN_CENTER
                    doc.Add(logo)
                Catch ex As Exception
                    MessageBox.Show("Error al cargar la imagen: " & ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Try

                ' Agregar un título y la fecha
                doc.Add(New Paragraph("Reporte Específico de Entradas y Salidas", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14)))
                doc.Add(New Paragraph("Fecha: " & DateTime.Now.ToString("dd/MM/yyyy HH:mm"), FontFactory.GetFont(FontFactory.HELVETICA, 12)))
                doc.Add(New Paragraph(" ")) ' Espacio en blanco

                ' Agregar título para la tabla de Entradas
                doc.Add(New Paragraph("Entradas Específicas", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)))
                doc.Add(New Paragraph(" ")) ' Espacio en blanco

                ' Crear una tabla para las Entradas Específicas
                Dim tableEntradasEsp As New PdfPTable(dgvReporteEntradasEsp.Columns.Count)
                tableEntradasEsp.WidthPercentage = 100

                ' Agregar encabezados de las columnas (Entradas Específicas)
                For Each column As DataGridViewColumn In dgvReporteEntradasEsp.Columns
                    Dim headerCell As New PdfPCell(New Phrase(column.HeaderText, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10)))
                    headerCell.BackgroundColor = New BaseColor(149, 26, 0) ' Color de fondo (marrón)
                    headerCell.HorizontalAlignment = Element.ALIGN_CENTER
                    tableEntradasEsp.AddCell(headerCell)
                Next

                ' Agregar los datos de cada fila (Entradas Específicas)
                For Each row As DataGridViewRow In dgvReporteEntradasEsp.Rows
                    If Not row.IsNewRow Then
                        For Each cell As DataGridViewCell In row.Cells
                            Dim cellValue As String = If(cell.Value IsNot Nothing, cell.Value.ToString(), "")
                            Dim cellPhrase As New Phrase(cellValue, FontFactory.GetFont(FontFactory.HELVETICA, 10))
                            Dim dataCell As New PdfPCell(cellPhrase)
                            dataCell.HorizontalAlignment = Element.ALIGN_CENTER
                            tableEntradasEsp.AddCell(dataCell)
                        Next
                    End If
                Next

                ' Agregar la tabla de Entradas Específicas al documento
                doc.Add(tableEntradasEsp)
                doc.Add(New Paragraph(" ")) ' Espacio en blanco

                ' Agregar título para la tabla de Salidas
                doc.Add(New Paragraph("Salidas Específicas", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)))
                doc.Add(New Paragraph(" ")) ' Espacio en blanco

                ' Crear una tabla para las Salidas Específicas
                Dim tableSalidasEsp As New PdfPTable(dgvReporteSalidasEsp.Columns.Count)
                tableSalidasEsp.WidthPercentage = 100

                ' Agregar encabezados de las columnas (Salidas Específicas)
                For Each column As DataGridViewColumn In dgvReporteSalidasEsp.Columns
                    Dim headerCell As New PdfPCell(New Phrase(column.HeaderText, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10)))
                    headerCell.BackgroundColor = New BaseColor(149, 26, 0) ' Color de fondo (marrón)
                    headerCell.HorizontalAlignment = Element.ALIGN_CENTER
                    tableSalidasEsp.AddCell(headerCell)
                Next

                ' Agregar los datos de cada fila (Salidas Específicas)
                For Each row As DataGridViewRow In dgvReporteSalidasEsp.Rows
                    If Not row.IsNewRow Then
                        For Each cell As DataGridViewCell In row.Cells
                            Dim cellValue As String = If(cell.Value IsNot Nothing, cell.Value.ToString(), "")
                            Dim cellPhrase As New Phrase(cellValue, FontFactory.GetFont(FontFactory.HELVETICA, 10))
                            Dim dataCell As New PdfPCell(cellPhrase)
                            dataCell.HorizontalAlignment = Element.ALIGN_CENTER
                            tableSalidasEsp.AddCell(dataCell)
                        Next
                    End If
                Next

                ' Agregar la tabla de Salidas Específicas al documento
                doc.Add(tableSalidasEsp)

                ' Cerrar el documento
                doc.Close()

                MessageBox.Show("Reporte PDF guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Error al generar el reporte: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnLimpiarReporteEspecifico_Click(sender As Object, e As EventArgs) Handles btnLimpiarReporteEspecifico.Click
        Try
            ' Mostrar confirmación antes de limpiar
            Dim confirmacion As DialogResult = MessageBox.Show("¿Está seguro que desea limpiar todos los reportes específicos?",
                                                         "Confirmar limpieza",
                                                         MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Question)

            If confirmacion = DialogResult.Yes Then
                ' Limpiar DataTables asociados
                dtReporteEntradasEsp.Clear()
                dtReporteSalidasEsp.Clear()

                ' Actualizar los DataGridViews
                dgvReporteEntradasEsp.DataSource = dtReporteEntradasEsp
                dgvReporteSalidasEsp.DataSource = dtReporteSalidasEsp

                ' Opcional: Ajustar columnas automáticamente
                dgvReporteEntradasEsp.AutoResizeColumns()
                dgvReporteSalidasEsp.AutoResizeColumns()

                MessageBox.Show("Reportes específicos limpiados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Operación cancelada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show($"Error al limpiar los reportes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '------------------------------------------------
    '------------------------------- Cerrado efectivo
    '------------------------------------------------
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            Dim result As DialogResult = MessageBox.Show("¿Está seguro que desea salir del sistema?",
                                                      "Confirmar salida",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Question)

            If result = DialogResult.No Then
                e.Cancel = True ' Cancela el cierre
            Else
                Application.Exit() ' Cierra completamente la aplicación
            End If
        End If
    End Sub

End Class
