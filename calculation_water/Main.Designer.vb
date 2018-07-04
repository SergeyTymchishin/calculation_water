<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
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

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ModescentreToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AIISKUEToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GlobalPanel = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox12 = New System.Windows.Forms.TextBox()
        Me.TextBox9 = New System.Windows.Forms.TextBox()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.TextBox11 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox10 = New System.Windows.Forms.TextBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.TextBox8 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.ButtonModesAUTO = New System.Windows.Forms.Button()
        Me.PGActual = New System.Windows.Forms.Button()
        Me.PGObjects = New System.Windows.Forms.ComboBox()
        Me.PGDate = New System.Windows.Forms.DateTimePicker()
        Me.label23 = New System.Windows.Forms.Label()
        Me.ButtonModes = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.DataGridAIISKUE = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.dataGridModes = New System.Windows.Forms.DataGridView()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.DataGridreport2 = New System.Windows.Forms.DataGridView()
        Me.tabControl2 = New System.Windows.Forms.TabControl()
        Me.tabPage4 = New System.Windows.Forms.TabPage()
        Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.toolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.outputEventsBox = New System.Windows.Forms.TextBox()
        Me.X = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        Me.GlobalPanel.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.DataGridAIISKUE, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.dataGridModes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage6.SuspendLayout()
        CType(Me.DataGridreport2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabControl2.SuspendLayout()
        Me.tabPage4.SuspendLayout()
        Me.toolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ModescentreToolStripMenuItem, Me.AIISKUEToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(958, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ModescentreToolStripMenuItem
        '
        Me.ModescentreToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control
        Me.ModescentreToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ModescentreToolStripMenuItem.Name = "ModescentreToolStripMenuItem"
        Me.ModescentreToolStripMenuItem.Size = New System.Drawing.Size(93, 20)
        Me.ModescentreToolStripMenuItem.Text = "modes-centre"
        '
        'AIISKUEToolStripMenuItem
        '
        Me.AIISKUEToolStripMenuItem.Name = "AIISKUEToolStripMenuItem"
        Me.AIISKUEToolStripMenuItem.Size = New System.Drawing.Size(63, 20)
        Me.AIISKUEToolStripMenuItem.Text = "AIIS KUE"
        '
        'GlobalPanel
        '
        Me.GlobalPanel.Controls.Add(Me.Panel1)
        Me.GlobalPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GlobalPanel.Location = New System.Drawing.Point(0, 24)
        Me.GlobalPanel.Name = "GlobalPanel"
        Me.GlobalPanel.Size = New System.Drawing.Size(958, 784)
        Me.GlobalPanel.TabIndex = 3
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.X)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.TextBox12)
        Me.Panel1.Controls.Add(Me.TextBox9)
        Me.Panel1.Controls.Add(Me.TextBox6)
        Me.Panel1.Controls.Add(Me.TextBox11)
        Me.Panel1.Controls.Add(Me.TextBox3)
        Me.Panel1.Controls.Add(Me.TextBox10)
        Me.Panel1.Controls.Add(Me.TextBox5)
        Me.Panel1.Controls.Add(Me.TextBox8)
        Me.Panel1.Controls.Add(Me.TextBox4)
        Me.Panel1.Controls.Add(Me.TextBox7)
        Me.Panel1.Controls.Add(Me.TextBox2)
        Me.Panel1.Controls.Add(Me.TextBox1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.NumericUpDown1)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Button6)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.ButtonModesAUTO)
        Me.Panel1.Controls.Add(Me.PGActual)
        Me.Panel1.Controls.Add(Me.PGObjects)
        Me.Panel1.Controls.Add(Me.PGDate)
        Me.Panel1.Controls.Add(Me.label23)
        Me.Panel1.Controls.Add(Me.ButtonModes)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(284, 607)
        Me.Panel1.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label3.Location = New System.Drawing.Point(76, 410)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(142, 25)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Актуальные"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label2.Location = New System.Drawing.Point(112, 259)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 25)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "ППБР "
        '
        'TextBox12
        '
        Me.TextBox12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.TextBox12.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.TextBox12.Location = New System.Drawing.Point(180, 514)
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.ReadOnly = True
        Me.TextBox12.Size = New System.Drawing.Size(100, 22)
        Me.TextBox12.TabIndex = 14
        Me.TextBox12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox9
        '
        Me.TextBox9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.TextBox9.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.TextBox9.Location = New System.Drawing.Point(180, 438)
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.ReadOnly = True
        Me.TextBox9.Size = New System.Drawing.Size(100, 22)
        Me.TextBox9.TabIndex = 14
        Me.TextBox9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox6
        '
        Me.TextBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.TextBox6.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.TextBox6.Location = New System.Drawing.Point(180, 363)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.ReadOnly = True
        Me.TextBox6.Size = New System.Drawing.Size(100, 22)
        Me.TextBox6.TabIndex = 14
        Me.TextBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox11
        '
        Me.TextBox11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.TextBox11.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.TextBox11.Location = New System.Drawing.Point(93, 489)
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.ReadOnly = True
        Me.TextBox11.Size = New System.Drawing.Size(100, 22)
        Me.TextBox11.TabIndex = 14
        Me.TextBox11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox3
        '
        Me.TextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.TextBox3.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.TextBox3.Location = New System.Drawing.Point(180, 287)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.Size = New System.Drawing.Size(100, 22)
        Me.TextBox3.TabIndex = 14
        Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox10
        '
        Me.TextBox10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.TextBox10.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.TextBox10.Location = New System.Drawing.Point(15, 514)
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.ReadOnly = True
        Me.TextBox10.Size = New System.Drawing.Size(100, 22)
        Me.TextBox10.TabIndex = 14
        Me.TextBox10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox5
        '
        Me.TextBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.TextBox5.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.TextBox5.Location = New System.Drawing.Point(93, 338)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.ReadOnly = True
        Me.TextBox5.Size = New System.Drawing.Size(100, 22)
        Me.TextBox5.TabIndex = 14
        Me.TextBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox8
        '
        Me.TextBox8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.TextBox8.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.TextBox8.Location = New System.Drawing.Point(93, 466)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.ReadOnly = True
        Me.TextBox8.Size = New System.Drawing.Size(100, 22)
        Me.TextBox8.TabIndex = 14
        Me.TextBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox4
        '
        Me.TextBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.TextBox4.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.TextBox4.Location = New System.Drawing.Point(15, 363)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.ReadOnly = True
        Me.TextBox4.Size = New System.Drawing.Size(100, 22)
        Me.TextBox4.TabIndex = 14
        Me.TextBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox7
        '
        Me.TextBox7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.TextBox7.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.TextBox7.Location = New System.Drawing.Point(15, 438)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.ReadOnly = True
        Me.TextBox7.Size = New System.Drawing.Size(100, 22)
        Me.TextBox7.TabIndex = 14
        Me.TextBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.TextBox2.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.TextBox2.Location = New System.Drawing.Point(93, 315)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(100, 22)
        Me.TextBox2.TabIndex = 14
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.TextBox1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.TextBox1.Location = New System.Drawing.Point(15, 287)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(100, 22)
        Me.TextBox1.TabIndex = 14
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.Location = New System.Drawing.Point(42, 226)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 20)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Напор"
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.DecimalPlaces = 2
        Me.NumericUpDown1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.NumericUpDown1.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.NumericUpDown1.Location = New System.Drawing.Point(105, 222)
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {886, 0, 0, 65536})
        Me.NumericUpDown1.Minimum = New Decimal(New Integer() {86, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(113, 26)
        Me.NumericUpDown1.TabIndex = 12
        Me.NumericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NumericUpDown1.Value = New Decimal(New Integer() {875, 0, 0, 65536})
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(36, 135)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(182, 23)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "Данные АИИС КУЭ"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Enabled = False
        Me.Button6.Location = New System.Drawing.Point(36, 193)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(182, 23)
        Me.Button6.TabIndex = 10
        Me.Button6.Text = "Отклонения"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Enabled = False
        Me.Button3.Location = New System.Drawing.Point(36, 164)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(182, 23)
        Me.Button3.TabIndex = 10
        Me.Button3.Text = "Данные Modes-centre"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'ButtonModesAUTO
        '
        Me.ButtonModesAUTO.Enabled = False
        Me.ButtonModesAUTO.Location = New System.Drawing.Point(36, 106)
        Me.ButtonModesAUTO.Name = "ButtonModesAUTO"
        Me.ButtonModesAUTO.Size = New System.Drawing.Size(182, 23)
        Me.ButtonModesAUTO.TabIndex = 10
        Me.ButtonModesAUTO.Text = "Авто. получение актуальныч ПГ"
        Me.ButtonModesAUTO.UseVisualStyleBackColor = True
        '
        'PGActual
        '
        Me.PGActual.Enabled = False
        Me.PGActual.Location = New System.Drawing.Point(36, 77)
        Me.PGActual.Name = "PGActual"
        Me.PGActual.Size = New System.Drawing.Size(182, 23)
        Me.PGActual.TabIndex = 10
        Me.PGActual.Text = "Получить актуальный ПГ"
        Me.PGActual.UseVisualStyleBackColor = True
        '
        'PGObjects
        '
        Me.PGObjects.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PGObjects.DisplayMember = "DisplayNameALL"
        Me.PGObjects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PGObjects.Enabled = False
        Me.PGObjects.FormattingEnabled = True
        Me.PGObjects.Location = New System.Drawing.Point(0, 50)
        Me.PGObjects.Name = "PGObjects"
        Me.PGObjects.Size = New System.Drawing.Size(284, 21)
        Me.PGObjects.TabIndex = 9
        '
        'PGDate
        '
        Me.PGDate.Location = New System.Drawing.Point(0, 21)
        Me.PGDate.Name = "PGDate"
        Me.PGDate.Size = New System.Drawing.Size(137, 20)
        Me.PGDate.TabIndex = 8
        '
        'label23
        '
        Me.label23.AutoSize = True
        Me.label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.label23.Location = New System.Drawing.Point(12, 3)
        Me.label23.Name = "label23"
        Me.label23.Size = New System.Drawing.Size(89, 15)
        Me.label23.TabIndex = 7
        Me.label23.Text = "Целевая дата"
        '
        'ButtonModes
        '
        Me.ButtonModes.Enabled = False
        Me.ButtonModes.Location = New System.Drawing.Point(143, 21)
        Me.ButtonModes.Name = "ButtonModes"
        Me.ButtonModes.Size = New System.Drawing.Size(137, 23)
        Me.ButtonModes.TabIndex = 6
        Me.ButtonModes.Text = "Дерево оборудования"
        Me.ButtonModes.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage6)
        Me.TabControl1.Location = New System.Drawing.Point(286, 27)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 1
        Me.TabControl1.Size = New System.Drawing.Size(672, 613)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.DataGridAIISKUE)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(664, 587)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Данные АИИС КУЭ"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'DataGridAIISKUE
        '
        Me.DataGridAIISKUE.AllowUserToAddRows = False
        Me.DataGridAIISKUE.AllowUserToDeleteRows = False
        Me.DataGridAIISKUE.AllowUserToResizeRows = False
        Me.DataGridAIISKUE.BackgroundColor = System.Drawing.Color.White
        Me.DataGridAIISKUE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridAIISKUE.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1})
        Me.DataGridAIISKUE.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridAIISKUE.Location = New System.Drawing.Point(3, 3)
        Me.DataGridAIISKUE.Name = "DataGridAIISKUE"
        Me.DataGridAIISKUE.ReadOnly = True
        Me.DataGridAIISKUE.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridAIISKUE.Size = New System.Drawing.Size(658, 581)
        Me.DataGridAIISKUE.TabIndex = 3
        Me.DataGridAIISKUE.Visible = False
        '
        'DataGridViewTextBoxColumn1
        '
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Red
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn1.HeaderText = "Характеристика"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.dataGridModes)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(664, 587)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Данные Modes-centre"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'dataGridModes
        '
        Me.dataGridModes.AllowUserToAddRows = False
        Me.dataGridModes.AllowUserToDeleteRows = False
        Me.dataGridModes.AllowUserToResizeRows = False
        Me.dataGridModes.BackgroundColor = System.Drawing.Color.White
        Me.dataGridModes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataGridModes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dataGridModes.Location = New System.Drawing.Point(3, 3)
        Me.dataGridModes.Name = "dataGridModes"
        Me.dataGridModes.ReadOnly = True
        Me.dataGridModes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dataGridModes.Size = New System.Drawing.Size(658, 581)
        Me.dataGridModes.TabIndex = 2
        Me.dataGridModes.Visible = False
        '
        'TabPage6
        '
        Me.TabPage6.Controls.Add(Me.DataGridreport2)
        Me.TabPage6.Location = New System.Drawing.Point(4, 22)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage6.Size = New System.Drawing.Size(664, 587)
        Me.TabPage6.TabIndex = 4
        Me.TabPage6.Text = "Отклонения"
        Me.TabPage6.UseVisualStyleBackColor = True
        '
        'DataGridreport2
        '
        Me.DataGridreport2.AllowUserToAddRows = False
        Me.DataGridreport2.AllowUserToDeleteRows = False
        Me.DataGridreport2.AllowUserToResizeRows = False
        Me.DataGridreport2.BackgroundColor = System.Drawing.Color.White
        Me.DataGridreport2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridreport2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridreport2.Location = New System.Drawing.Point(3, 3)
        Me.DataGridreport2.Name = "DataGridreport2"
        Me.DataGridreport2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DataGridreport2.Size = New System.Drawing.Size(658, 581)
        Me.DataGridreport2.TabIndex = 3
        Me.DataGridreport2.Visible = False
        '
        'tabControl2
        '
        Me.tabControl2.Controls.Add(Me.tabPage4)
        Me.tabControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.tabControl2.Location = New System.Drawing.Point(0, 637)
        Me.tabControl2.Name = "tabControl2"
        Me.tabControl2.SelectedIndex = 0
        Me.tabControl2.Size = New System.Drawing.Size(958, 171)
        Me.tabControl2.TabIndex = 5
        '
        'tabPage4
        '
        Me.tabPage4.Controls.Add(Me.toolStrip1)
        Me.tabPage4.Controls.Add(Me.outputEventsBox)
        Me.tabPage4.Location = New System.Drawing.Point(4, 22)
        Me.tabPage4.Name = "tabPage4"
        Me.tabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage4.Size = New System.Drawing.Size(950, 145)
        Me.tabPage4.TabIndex = 1
        Me.tabPage4.Text = "События"
        Me.tabPage4.UseVisualStyleBackColor = True
        '
        'toolStrip1
        '
        Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripButton1})
        Me.toolStrip1.Location = New System.Drawing.Point(3, 3)
        Me.toolStrip1.Name = "toolStrip1"
        Me.toolStrip1.Size = New System.Drawing.Size(944, 25)
        Me.toolStrip1.TabIndex = 1
        Me.toolStrip1.Text = "toolStrip1"
        '
        'toolStripButton1
        '
        Me.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolStripButton1.Image = CType(resources.GetObject("toolStripButton1.Image"), System.Drawing.Image)
        Me.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolStripButton1.Name = "toolStripButton1"
        Me.toolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.toolStripButton1.Text = "Очистить список событий"
        '
        'outputEventsBox
        '
        Me.outputEventsBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.outputEventsBox.Location = New System.Drawing.Point(3, 31)
        Me.outputEventsBox.Multiline = True
        Me.outputEventsBox.Name = "outputEventsBox"
        Me.outputEventsBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.outputEventsBox.Size = New System.Drawing.Size(944, 111)
        Me.outputEventsBox.TabIndex = 0
        '
        'X
        '
        Me.X.Location = New System.Drawing.Point(242, 193)
        Me.X.Name = "X"
        Me.X.Size = New System.Drawing.Size(18, 23)
        Me.X.TabIndex = 16
        Me.X.Text = "X"
        Me.X.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(224, 193)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(18, 23)
        Me.Button2.TabIndex = 16
        Me.Button2.Text = "A"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(958, 808)
        Me.Controls.Add(Me.tabControl2)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.GlobalPanel)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Main"
        Me.Text = "ПАО ""ИркутскЭнерго"" Усть-Илимская ГЭС"""
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GlobalPanel.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.DataGridAIISKUE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dataGridModes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage6.ResumeLayout(False)
        CType(Me.DataGridreport2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabControl2.ResumeLayout(False)
        Me.tabPage4.ResumeLayout(False)
        Me.tabPage4.PerformLayout()
        Me.toolStrip1.ResumeLayout(False)
        Me.toolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ModescentreToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AIISKUEToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents GlobalPanel As System.Windows.Forms.Panel
    Private WithEvents tabControl2 As System.Windows.Forms.TabControl
    Private WithEvents tabPage4 As System.Windows.Forms.TabPage
    Private WithEvents toolStrip1 As System.Windows.Forms.ToolStrip
    Private WithEvents toolStripButton1 As System.Windows.Forms.ToolStripButton
    Private WithEvents outputEventsBox As System.Windows.Forms.TextBox
    Private WithEvents TabPage1 As System.Windows.Forms.TabPage
    Private WithEvents TabPage2 As System.Windows.Forms.TabPage
    Private WithEvents TabControl1 As System.Windows.Forms.TabControl
    Private WithEvents dataGridModes As System.Windows.Forms.DataGridView
    Private WithEvents ButtonModes As System.Windows.Forms.Button
    Private WithEvents PGDate As System.Windows.Forms.DateTimePicker
    Private WithEvents label23 As System.Windows.Forms.Label
    Private WithEvents PGObjects As System.Windows.Forms.ComboBox
    Private WithEvents PGActual As System.Windows.Forms.Button
    Private WithEvents ButtonModesAUTO As System.Windows.Forms.Button
    Private WithEvents Button1 As System.Windows.Forms.Button
    Private WithEvents Button3 As System.Windows.Forms.Button
    Private WithEvents DataGridAIISKUE As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
    Private WithEvents DataGridreport2 As System.Windows.Forms.DataGridView
    Private WithEvents Button6 As System.Windows.Forms.Button
    Private WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBox12 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox9 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox11 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox10 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox8 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents X As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button

End Class
