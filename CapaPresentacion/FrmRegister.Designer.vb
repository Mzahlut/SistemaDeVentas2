<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRegister
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
        dgvItems = New DataGridView()
        MenuStrip1 = New MenuStrip()
        MenusToolStripMenuItem = New ToolStripMenuItem()
        ProductosToolStripMenuItem = New ToolStripMenuItem()
        VentasToolStripMenuItem = New ToolStripMenuItem()
        VentasToolStripMenuItem1 = New ToolStripMenuItem()
        cboProducts = New ComboBox()
        cboClients = New ComboBox()
        txtIndex = New TextBox()
        txtCantidad = New TextBox()
        btnVenta = New FontAwesome.Sharp.IconButton()
        CType(dgvItems, ComponentModel.ISupportInitialize).BeginInit()
        MenuStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' btnDelete
        ' 
        btnDelete.Location = New Point(12, 291)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(75, 28)
        btnDelete.TabIndex = 43
        btnDelete.Text = "Eliminar"
        btnDelete.UseVisualStyleBackColor = True
        ' 
        ' btnSave
        ' 
        btnSave.Location = New Point(12, 257)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(75, 28)
        btnSave.TabIndex = 42
        btnSave.Text = "Agregar"
        btnSave.UseVisualStyleBackColor = True
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(12, 165)
        Label5.Name = "Label5"
        Label5.Size = New Size(56, 15)
        Label5.TabIndex = 41
        Label5.Text = "Producto"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(12, 109)
        Label4.Name = "Label4"
        Label4.Size = New Size(44, 15)
        Label4.TabIndex = 40
        Label4.Text = "Cliente"
        ' 
        ' Label3
        ' 
        Label3.BackColor = SystemColors.Control
        Label3.Font = New Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point)
        Label3.Location = New Point(228, 58)
        Label3.Name = "Label3"
        Label3.Size = New Size(106, 35)
        Label3.TabIndex = 39
        Label3.Text = "Productos"
        ' 
        ' dgvItems
        ' 
        dgvItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvItems.Location = New Point(228, 96)
        dgvItems.Name = "dgvItems"
        dgvItems.RowTemplate.Height = 25
        dgvItems.Size = New Size(864, 336)
        dgvItems.TabIndex = 38
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.Items.AddRange(New ToolStripItem() {MenusToolStripMenuItem})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Size = New Size(1104, 24)
        MenuStrip1.TabIndex = 44
        MenuStrip1.Text = "MenuStrip1"
        ' 
        ' MenusToolStripMenuItem
        ' 
        MenusToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {ProductosToolStripMenuItem, VentasToolStripMenuItem, VentasToolStripMenuItem1})
        MenusToolStripMenuItem.Name = "MenusToolStripMenuItem"
        MenusToolStripMenuItem.Size = New Size(97, 20)
        MenusToolStripMenuItem.Text = "Registrar venta"
        ' 
        ' ProductosToolStripMenuItem
        ' 
        ProductosToolStripMenuItem.Name = "ProductosToolStripMenuItem"
        ProductosToolStripMenuItem.Size = New Size(128, 22)
        ProductosToolStripMenuItem.Text = "Productos"
        ' 
        ' VentasToolStripMenuItem
        ' 
        VentasToolStripMenuItem.Name = "VentasToolStripMenuItem"
        VentasToolStripMenuItem.Size = New Size(128, 22)
        VentasToolStripMenuItem.Text = "Clientes"
        ' 
        ' VentasToolStripMenuItem1
        ' 
        VentasToolStripMenuItem1.Name = "VentasToolStripMenuItem1"
        VentasToolStripMenuItem1.Size = New Size(128, 22)
        VentasToolStripMenuItem1.Text = "Ventas"
        ' 
        ' cboProducts
        ' 
        cboProducts.FormattingEnabled = True
        cboProducts.Location = New Point(12, 193)
        cboProducts.Name = "cboProducts"
        cboProducts.Size = New Size(191, 23)
        cboProducts.TabIndex = 49
        ' 
        ' cboClients
        ' 
        cboClients.FormattingEnabled = True
        cboClients.Location = New Point(12, 139)
        cboClients.Name = "cboClients"
        cboClients.Size = New Size(191, 23)
        cboClients.TabIndex = 48
        ' 
        ' txtIndex
        ' 
        txtIndex.Location = New Point(179, 94)
        txtIndex.Name = "txtIndex"
        txtIndex.Size = New Size(24, 23)
        txtIndex.TabIndex = 45
        ' 
        ' txtCantidad
        ' 
        txtCantidad.Location = New Point(12, 228)
        txtCantidad.Name = "txtCantidad"
        txtCantidad.Size = New Size(35, 23)
        txtCantidad.TabIndex = 50
        ' 
        ' btnVenta
        ' 
        btnVenta.IconChar = FontAwesome.Sharp.IconChar.Plus
        btnVenta.IconColor = Color.ForestGreen
        btnVenta.IconFont = FontAwesome.Sharp.IconFont.Solid
        btnVenta.IconSize = 30
        btnVenta.Location = New Point(12, 359)
        btnVenta.Name = "btnVenta"
        btnVenta.Size = New Size(87, 71)
        btnVenta.TabIndex = 51
        btnVenta.Text = "Crear"
        btnVenta.TextImageRelation = TextImageRelation.ImageAboveText
        btnVenta.UseVisualStyleBackColor = True
        ' 
        ' FrmRegister
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1104, 442)
        Controls.Add(btnVenta)
        Controls.Add(txtCantidad)
        Controls.Add(btnDelete)
        Controls.Add(btnSave)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(dgvItems)
        Controls.Add(MenuStrip1)
        Controls.Add(cboProducts)
        Controls.Add(cboClients)
        Controls.Add(txtIndex)
        Name = "FrmRegister"
        Text = "FrmRegister"
        CType(dgvItems, ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents dgvItems As DataGridView
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents MenusToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProductosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VentasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VentasToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents cboProducts As ComboBox
    Friend WithEvents cboClients As ComboBox
    Friend WithEvents txtIndex As TextBox
    Friend WithEvents txtCantidad As TextBox
    Public WithEvents btnVenta As FontAwesome.Sharp.IconButton
End Class
