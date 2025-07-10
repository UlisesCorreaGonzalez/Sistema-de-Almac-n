Public Class FormSoporte
    Private Sub FormSoporte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnWhatsApp.FlatStyle = FlatStyle.Flat
        btnWhatsApp.FlatAppearance.BorderSize = 0
        btnWhatsApp.BackColor = Color.Transparent
        btnWhatsApp.FlatAppearance.MouseDownBackColor = Color.Transparent
        btnWhatsApp.FlatAppearance.MouseOverBackColor = Color.Transparent

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("https://mail.google.com/mail/?view=cm&fs=1&to=kodevadev@gmail.com&su=Soporte%20KODEVA&body=Hola%2C%20necesito%20ayuda%20con%20el%20sistema...")
    End Sub

    Private Sub btnWhatsApp_Click(sender As Object, e As EventArgs) Handles btnWhatsApp.Click
        Dim numero As String = "5214437216707" ' ← Tu número con lada, sin espacios ni signos
        Dim mensaje As String = "Hola, necesito ayuda con el sistema de KODEVA"
        Dim url As String = "https://wa.me/" & numero & "?text=" & Uri.EscapeDataString(mensaje)
        Process.Start(url)
    End Sub

End Class