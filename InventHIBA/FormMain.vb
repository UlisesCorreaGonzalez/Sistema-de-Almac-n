Public Class FormMain
    ' Diccionario de usuarios y contraseñas
    Private ReadOnly usuarios As New Dictionary(Of String, (Password As String, AccessLevel As Integer)) From {
        {"Admin", ("Admin#2024", 1)},
        {"Almacen", ("Almacen#123", 2)},
        {"Operador", ("Opera$567", 3)},
        {"Consulta", ("Consult@2024", 4)}
    }

    ' Variable compartida para guardar la IP ingresada
    Public Shared IPIngresada As String

    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.AcceptButton = btnLogin
        txtContraseña.PasswordChar = "*"c
        ' Cargar la IP previamente guardada (si existe)
        txtIP.Text = My.Settings.LastIP
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim usuario = txtUsuario.Text.Trim()
        Dim contraseña = txtContraseña.Text

        If ValidarCredenciales(usuario, contraseña) Then
            AbrirInventario(usuarios(usuario).AccessLevel)
        Else
            MostrarErrorLogin()
        End If
    End Sub

    Private Function ValidarCredenciales(usuario As String, contraseña As String) As Boolean
        If String.IsNullOrEmpty(usuario) OrElse String.IsNullOrEmpty(contraseña) Then
            MessageBox.Show("Ingrese usuario y contraseña", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Return usuarios.ContainsKey(usuario) AndAlso usuarios(usuario).Password = contraseña
    End Function

    Private Sub MostrarErrorLogin()
        MessageBox.Show("Credenciales incorrectas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        txtContraseña.Clear()
        txtUsuario.Focus()
    End Sub

    Private Sub AbrirInventario(nivelAcceso As Integer)
        ' Obtener la IP desde el txtIP
        IPIngresada = txtIP.Text.Trim()

        ' Validar que la IP no esté vacía
        If String.IsNullOrEmpty(IPIngresada) Then
            MessageBox.Show("Por favor, ingresa una IP válida.", "IP requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Guardar la IP en la configuración de usuario
        My.Settings.LastIP = IPIngresada
        My.Settings.Save()

        ' Abrir el formulario de inventario
        Dim formInventario As New Form1()
        formInventario.Tag = nivelAcceso
        formInventario.Show()
        Me.Hide()
    End Sub


    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Application.Exit()
    End Sub

    Private Sub FormMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            Application.Exit()
        End If
    End Sub

    Private Sub btnVer_Click(sender As Object, e As EventArgs) Handles btnVer.Click
        If txtContraseña.PasswordChar = Chr(0) Then
            txtContraseña.PasswordChar = "*"c
        Else
            txtContraseña.PasswordChar = Chr(0)
        End If
    End Sub

    Private Sub btnImprimirInv_Click(sender As Object, e As EventArgs) Handles btnImprimirInv.Click
        Dim soporte As New FormSoporte()
        soporte.Show()
    End Sub
End Class
