<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmProductos
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
        Label6 = New Label()
        Label5 = New Label()
        Label4 = New Label()
        Label3 = New Label()
        dgvProducts = New DataGridView()
        txtPrice = New TextBox()
        txtCliente = New TextBox()
        MenuStrip1 = New MenuStrip()
        MenusToolStripMenuItem = New ToolStripMenuItem()
        ProductosToolStripMenuItem = New ToolStripMenuItem()
        VentasToolStripMenuItem = New ToolStripMenuItem()
        RegistrarVentaToolStripMenuItem = New ToolStripMenuItem()
        txtIndex = New TextBox()
        txtCategoria = New TextBox()
        btnExcel = New Button()
        cboSearch = New ComboBox()
        txtSearch = New TextBox()
        btnClear = New Button()
        CType(dgvProducts, ComponentModel.ISupportInitialize).BeginInit()
        MenuStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' btnDelete
        ' 
        btnDelete.Location = New Point(12, 307)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(75, 23)
        btnDelete.TabIndex = 23
        btnDelete.Text = "Eliminar"
        btnDelete.UseVisualStyleBackColor = True
        ' 
        ' btnSave
        ' 
        btnSave.Location = New Point(12, 278)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(75, 23)
        btnSave.TabIndex = 22
        btnSave.Text = "Guardar"
        btnSave.UseVisualStyleBackColor = True
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(12, 209)
        Label6.Name = "Label6"
        Label6.Size = New Size(58, 15)
        Label6.TabIndex = 21
        Label6.Text = "Categoria"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(12, 155)
        Label5.Name = "Label5"
        Label5.Size = New Size(40, 15)
        Label5.TabIndex = 20
        Label5.Text = "Precio"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(12, 94)
        Label4.Name = "Label4"
        Label4.Size = New Size(56, 15)
        Label4.TabIndex = 19
        Label4.Text = "Producto"
        ' 
        ' Label3
        ' 
        Label3.BackColor = SystemColors.Control
        Label3.Font = New Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point)
        Label3.Location = New Point(228, 56)
        Label3.Name = "Label3"
        Label3.Size = New Size(112, 35)
        Label3.TabIndex = 18
        Label3.Text = "Productos"
        ' 
        ' dgvProducts
        ' 
        dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvProducts.Location = New Point(228, 94)
        dgvProducts.Name = "dgvProducts"
        dgvProducts.RowTemplate.Height = 25
        dgvProducts.Size = New Size(864, 336)
        dgvProducts.TabIndex = 17
        ' 
        ' txtPrice
        ' 
        txtPrice.Location = New Point(12, 178)
        txtPrice.Name = "txtPrice"
        txtPrice.Size = New Size(191, 23)
        txtPrice.TabIndex = 15
        ' 
        ' txtCliente
        ' 
        txtCliente.Location = New Point(12, 118)
        txtCliente.Name = "txtCliente"
        txtCliente.Size = New Size(191, 23)
        txtCliente.TabIndex = 14
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
        MenusToolStripMenuItem.Size = New Size(73, 20)
        MenusToolStripMenuItem.Text = "Productos"
        ' 
        ' ProductosToolStripMenuItem
        ' 
        ProductosToolStripMenuItem.Name = "ProductosToolStripMenuItem"
        ProductosToolStripMenuItem.Size = New Size(116, 22)
        ProductosToolStripMenuItem.Text = "Clientes"
        ' 
        ' VentasToolStripMenuItem
        ' 
        VentasToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {RegistrarVentaToolStripMenuItem})
        VentasToolStripMenuItem.Name = "VentasToolStripMenuItem"
        VentasToolStripMenuItem.Size = New Size(116, 22)
        VentasToolStripMenuItem.Text = "Ventas"
        ' 
        ' RegistrarVentaToolStripMenuItem
        ' 
        RegistrarVentaToolStripMenuItem.Name = "RegistrarVentaToolStripMenuItem"
        RegistrarVentaToolStripMenuItem.Size = New Size(152, 22)
        RegistrarVentaToolStripMenuItem.Text = "Registrar Venta"
        ' 
        ' txtIndex
        ' 
        txtIndex.Location = New Point(179, 83)
        txtIndex.Name = "txtIndex"
        txtIndex.Size = New Size(24, 23)
        txtIndex.TabIndex = 25
        ' 
        ' txtCategoria
        ' 
        txtCategoria.Location = New Point(12, 232)
        txtCategoria.Name = "txtCategoria"
        txtCategoria.Size = New Size(191, 23)
        txtCategoria.TabIndex = 26
        ' 
        ' btnExcel
        ' 
        btnExcel.Location = New Point(12, 407)
        btnExcel.Name = "btnExcel"
        btnExcel.Size = New Size(120, 23)
        btnExcel.TabIndex = 38
        btnExcel.Text = "Descargar excel"
        btnExcel.UseVisualStyleBackColor = True
        ' 
        ' cboSearch
        ' 
        cboSearch.FormattingEnabled = True
        cboSearch.Location = New Point(698, 56)
        cboSearch.Name = "cboSearch"
        cboSearch.Size = New Size(171, 23)
        cboSearch.TabIndex = 41
        ' 
        ' txtSearch
        ' 
        txtSearch.Location = New Point(875, 56)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(171, 23)
        txtSearch.TabIndex = 43
        ' 
        ' btnClear
        ' 
        btnClear.Location = New Point(621, 55)
        btnClear.Name = "btnClear"
        btnClear.Size = New Size(71, 23)
        btnClear.TabIndex = 45
        btnClear.Text = "Limpiar"
        btnClear.UseVisualStyleBackColor = True
        ' 
        ' FrmProductos
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1104, 442)
        Controls.Add(btnClear)
        Controls.Add(txtSearch)
        Controls.Add(cboSearch)
        Controls.Add(btnExcel)
        Controls.Add(txtCategoria)
        Controls.Add(btnDelete)
        Controls.Add(btnSave)
        Controls.Add(Label6)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(dgvProducts)
        Controls.Add(txtPrice)
        Controls.Add(txtCliente)
        Controls.Add(MenuStrip1)
        Controls.Add(txtIndex)
        Name = "FrmProductos"
        Text = "FrmProductos"
        CType(dgvProducts, ComponentModel.ISupportInitialize).EndInit()
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnDelete As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents dgvProducts As DataGridView
    Friend WithEvents txtPrice As TextBox
    Friend WithEvents txtCliente As TextBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents MenusToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProductosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VentasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents txtIndex As TextBox
    Friend WithEvents txtCategoria As TextBox
    Friend WithEvents btnExcel As Button
    Friend WithEvents RegistrarVentaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents cboSearch As ComboBox
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents btnClear As Button
End Class
