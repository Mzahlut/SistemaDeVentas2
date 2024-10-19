<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        txtName = New TextBox()
        txtPhone = New TextBox()
        txtEmail = New TextBox()
        dgvClients = New DataGridView()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        btnSave = New Button()
        btnDelete = New Button()
        MenuStrip1 = New MenuStrip()
        MenusToolStripMenuItem = New ToolStripMenuItem()
        ProductosToolStripMenuItem = New ToolStripMenuItem()
        VentasToolStripMenuItem = New ToolStripMenuItem()
        txtIndex = New TextBox()
        btnExcel = New Button()
        CType(dgvClients, ComponentModel.ISupportInitialize).BeginInit()
        MenuStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' txtName
        ' 
        txtName.Location = New Point(12, 117)
        txtName.Name = "txtName"
        txtName.Size = New Size(191, 23)
        txtName.TabIndex = 2
        ' 
        ' txtPhone
        ' 
        txtPhone.Location = New Point(12, 176)
        txtPhone.Name = "txtPhone"
        txtPhone.Size = New Size(191, 23)
        txtPhone.TabIndex = 3
        ' 
        ' txtEmail
        ' 
        txtEmail.Location = New Point(12, 243)
        txtEmail.Name = "txtEmail"
        txtEmail.Size = New Size(191, 23)
        txtEmail.TabIndex = 4
        ' 
        ' dgvClients
        ' 
        dgvClients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvClients.Location = New Point(228, 99)
        dgvClients.Name = "dgvClients"
        dgvClients.RowTemplate.Height = 25
        dgvClients.Size = New Size(864, 336)
        dgvClients.TabIndex = 5
        ' 
        ' Label3
        ' 
        Label3.BackColor = SystemColors.Control
        Label3.Font = New Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point)
        Label3.Location = New Point(228, 46)
        Label3.Name = "Label3"
        Label3.Size = New Size(98, 35)
        Label3.TabIndex = 6
        Label3.Text = "Clientes"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(13, 91)
        Label4.Name = "Label4"
        Label4.Size = New Size(51, 15)
        Label4.TabIndex = 7
        Label4.Text = "Nombre"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(12, 152)
        Label5.Name = "Label5"
        Label5.Size = New Size(52, 15)
        Label5.TabIndex = 8
        Label5.Text = "Telefono"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(12, 214)
        Label6.Name = "Label6"
        Label6.Size = New Size(43, 15)
        Label6.TabIndex = 9
        Label6.Text = "Correo"
        ' 
        ' btnSave
        ' 
        btnSave.Location = New Point(12, 283)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(75, 28)
        btnSave.TabIndex = 10
        btnSave.Text = "Guardar"
        btnSave.UseVisualStyleBackColor = True
        ' 
        ' btnDelete
        ' 
        btnDelete.Location = New Point(12, 312)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(75, 28)
        btnDelete.TabIndex = 11
        btnDelete.Text = "Eliminar"
        btnDelete.UseVisualStyleBackColor = True
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.Items.AddRange(New ToolStripItem() {MenusToolStripMenuItem})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Size = New Size(1104, 24)
        MenuStrip1.TabIndex = 12
        MenuStrip1.Text = "MenuStrip1"
        ' 
        ' MenusToolStripMenuItem
        ' 
        MenusToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {ProductosToolStripMenuItem, VentasToolStripMenuItem})
        MenusToolStripMenuItem.Name = "MenusToolStripMenuItem"
        MenusToolStripMenuItem.Size = New Size(61, 20)
        MenusToolStripMenuItem.Text = "Clientes"
        ' 
        ' ProductosToolStripMenuItem
        ' 
        ProductosToolStripMenuItem.Name = "ProductosToolStripMenuItem"
        ProductosToolStripMenuItem.Size = New Size(180, 22)
        ProductosToolStripMenuItem.Text = "Productos"
        ' 
        ' VentasToolStripMenuItem
        ' 
        VentasToolStripMenuItem.Name = "VentasToolStripMenuItem"
        VentasToolStripMenuItem.Size = New Size(180, 22)
        VentasToolStripMenuItem.Text = "Ventas"
        ' 
        ' txtIndex
        ' 
        txtIndex.Location = New Point(179, 88)
        txtIndex.Name = "txtIndex"
        txtIndex.Size = New Size(24, 23)
        txtIndex.TabIndex = 13
        ' 
        ' btnExcel
        ' 
        btnExcel.Location = New Point(13, 407)
        btnExcel.Name = "btnExcel"
        btnExcel.Size = New Size(120, 23)
        btnExcel.TabIndex = 39
        btnExcel.Text = "Descargar excel"
        btnExcel.UseVisualStyleBackColor = True
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        AutoSize = True
        ClientSize = New Size(1104, 442)
        Controls.Add(btnExcel)
        Controls.Add(txtIndex)
        Controls.Add(btnDelete)
        Controls.Add(btnSave)
        Controls.Add(Label6)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(dgvClients)
        Controls.Add(txtEmail)
        Controls.Add(txtPhone)
        Controls.Add(txtName)
        Controls.Add(MenuStrip1)
        Name = "Form1"
        Text = "Form1"
        CType(dgvClients, ComponentModel.ISupportInitialize).EndInit()
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents txtName As TextBox
    Friend WithEvents txtPhone As TextBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents dgvClients As DataGridView
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents MenusToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProductosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VentasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents txtIndex As TextBox
    Friend WithEvents btnExcel As Button
End Class
