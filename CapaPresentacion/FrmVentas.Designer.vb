<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmVentas
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
        btnDelete = New Button()
        btnSave = New Button()
        Label5 = New Label()
        Label4 = New Label()
        Label3 = New Label()
        dgvVentas = New DataGridView()
        MenuStrip1 = New MenuStrip()
        MenusToolStripMenuItem = New ToolStripMenuItem()
        ProductosToolStripMenuItem = New ToolStripMenuItem()
        VentasToolStripMenuItem = New ToolStripMenuItem()
        txtIndex = New TextBox()
        Label1 = New Label()
        txtCantidad = New TextBox()
        cboClients = New ComboBox()
        cboProducts = New ComboBox()
        btnExcel = New Button()
        CType(dgvVentas, ComponentModel.ISupportInitialize).BeginInit()
        MenuStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' btnDelete
        ' 
        btnDelete.Location = New Point(12, 303)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(75, 28)
        btnDelete.TabIndex = 23
        btnDelete.Text = "Eliminar"
        btnDelete.UseVisualStyleBackColor = True
        ' 
        ' btnSave
        ' 
        btnSave.Location = New Point(12, 270)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(75, 28)
        btnSave.TabIndex = 22
        btnSave.Text = "Agregar"
        btnSave.UseVisualStyleBackColor = True
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(12, 163)
        Label5.Name = "Label5"
        Label5.Size = New Size(56, 15)
        Label5.TabIndex = 20
        Label5.Text = "Producto"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(12, 107)
        Label4.Name = "Label4"
        Label4.Size = New Size(44, 15)
        Label4.TabIndex = 19
        Label4.Text = "Cliente"
        ' 
        ' Label3
        ' 
        Label3.BackColor = SystemColors.Control
        Label3.Font = New Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point)
        Label3.Location = New Point(228, 65)
        Label3.Name = "Label3"
        Label3.Size = New Size(98, 35)
        Label3.TabIndex = 18
        Label3.Text = "Ventas"
        ' 
        ' dgvVentas
        ' 
        dgvVentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvVentas.Location = New Point(228, 103)
        dgvVentas.Name = "dgvVentas"
        dgvVentas.RowTemplate.Height = 25
        dgvVentas.Size = New Size(864, 336)
        dgvVentas.TabIndex = 17
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.Items.AddRange(New ToolStripItem() {MenusToolStripMenuItem})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Size = New Size(1104, 24)
        MenuStrip1.TabIndex = 24
        MenuStrip1.Text = "MenuStrip1"
        ' 
        ' MenusToolStripMenuItem
        ' 
        MenusToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {ProductosToolStripMenuItem, VentasToolStripMenuItem})
        MenusToolStripMenuItem.Name = "MenusToolStripMenuItem"
        MenusToolStripMenuItem.Size = New Size(53, 20)
        MenusToolStripMenuItem.Text = "Ventas"
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
        VentasToolStripMenuItem.Text = "Clientes"
        ' 
        ' txtIndex
        ' 
        txtIndex.Location = New Point(179, 92)
        txtIndex.Name = "txtIndex"
        txtIndex.Size = New Size(24, 23)
        txtIndex.TabIndex = 25
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(12, 217)
        Label1.Name = "Label1"
        Label1.Size = New Size(55, 15)
        Label1.TabIndex = 31
        Label1.Text = "Cantidad"
        ' 
        ' txtCantidad
        ' 
        txtCantidad.Location = New Point(12, 241)
        txtCantidad.Name = "txtCantidad"
        txtCantidad.Size = New Size(44, 23)
        txtCantidad.TabIndex = 34
        ' 
        ' cboClients
        ' 
        cboClients.FormattingEnabled = True
        cboClients.Location = New Point(12, 137)
        cboClients.Name = "cboClients"
        cboClients.Size = New Size(191, 23)
        cboClients.TabIndex = 35
        ' 
        ' cboProducts
        ' 
        cboProducts.FormattingEnabled = True
        cboProducts.Location = New Point(12, 191)
        cboProducts.Name = "cboProducts"
        cboProducts.Size = New Size(191, 23)
        cboProducts.TabIndex = 36
        ' 
        ' btnExcel
        ' 
        btnExcel.Location = New Point(12, 407)
        btnExcel.Name = "btnExcel"
        btnExcel.Size = New Size(120, 23)
        btnExcel.TabIndex = 37
        btnExcel.Text = "Descargar excel"
        btnExcel.UseVisualStyleBackColor = True
        ' 
        ' FrmVentas
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1104, 442)
        Controls.Add(btnExcel)
        Controls.Add(cboProducts)
        Controls.Add(cboClients)
        Controls.Add(txtCantidad)
        Controls.Add(Label1)
        Controls.Add(btnDelete)
        Controls.Add(btnSave)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(dgvVentas)
        Controls.Add(MenuStrip1)
        Controls.Add(txtIndex)
        Name = "FrmVentas"
        Text = "FrmVentas"
        CType(dgvVentas, ComponentModel.ISupportInitialize).EndInit()
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnDelete As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents dgvVentas As DataGridView
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents MenusToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProductosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VentasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents txtIndex As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtCantidad As TextBox
    Friend WithEvents cboClients As ComboBox
    Friend WithEvents cboProducts As ComboBox
    Friend WithEvents btnExcel As Button
End Class
