<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConnectionForm
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
        Me.label2 = New System.Windows.Forms.Label()
        Me.comboBox1 = New System.Windows.Forms.ComboBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.textBox1 = New System.Windows.Forms.TextBox()
        Me.button2 = New System.Windows.Forms.Button()
        Me.button1 = New System.Windows.Forms.Button()
        Me.textBox2 = New System.Windows.Forms.TextBox()
        Me.textBox3 = New System.Windows.Forms.TextBox()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.label4 = New System.Windows.Forms.Label()
        Me.label3 = New System.Windows.Forms.Label()
        Me.groupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(3, 33)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(94, 13)
        Me.label2.TabIndex = 18
        Me.label2.Text = "Аутентификация:"
        '
        'comboBox1
        '
        Me.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboBox1.FormattingEnabled = True
        Me.comboBox1.Items.AddRange(New Object() {"Локальная", "Доменная"})
        Me.comboBox1.Location = New System.Drawing.Point(108, 30)
        Me.comboBox1.Name = "comboBox1"
        Me.comboBox1.Size = New System.Drawing.Size(211, 21)
        Me.comboBox1.TabIndex = 17
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(3, 6)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(77, 13)
        Me.label1.TabIndex = 16
        Me.label1.Text = "Имя сервера:"
        '
        'textBox1
        '
        Me.textBox1.Location = New System.Drawing.Point(108, 4)
        Me.textBox1.Name = "textBox1"
        Me.textBox1.Size = New System.Drawing.Size(211, 20)
        Me.textBox1.TabIndex = 15
        '
        'button2
        '
        Me.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.button2.Location = New System.Drawing.Point(244, 141)
        Me.button2.Name = "button2"
        Me.button2.Size = New System.Drawing.Size(75, 23)
        Me.button2.TabIndex = 14
        Me.button2.Text = "Отмена"
        Me.button2.UseVisualStyleBackColor = True
        '
        'button1
        '
        Me.button1.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.button1.Location = New System.Drawing.Point(163, 141)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(75, 23)
        Me.button1.TabIndex = 13
        Me.button1.Text = "ОК"
        Me.button1.UseVisualStyleBackColor = True
        '
        'textBox2
        '
        Me.textBox2.Location = New System.Drawing.Point(102, 23)
        Me.textBox2.Name = "textBox2"
        Me.textBox2.Size = New System.Drawing.Size(205, 20)
        Me.textBox2.TabIndex = 10
        '
        'textBox3
        '
        Me.textBox3.Location = New System.Drawing.Point(102, 49)
        Me.textBox3.Name = "textBox3"
        Me.textBox3.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.textBox3.Size = New System.Drawing.Size(205, 20)
        Me.textBox3.TabIndex = 11
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.label4)
        Me.groupBox1.Controls.Add(Me.label3)
        Me.groupBox1.Controls.Add(Me.textBox2)
        Me.groupBox1.Controls.Add(Me.textBox3)
        Me.groupBox1.Enabled = False
        Me.groupBox1.Location = New System.Drawing.Point(6, 57)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(313, 78)
        Me.groupBox1.TabIndex = 19
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Данные пользователя"
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(6, 52)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(48, 13)
        Me.label4.TabIndex = 13
        Me.label4.Text = "Пароль:"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(6, 26)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(83, 13)
        Me.label3.TabIndex = 12
        Me.label3.Text = "Пользователь:"
        '
        'ConnectionForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(328, 175)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.comboBox1)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.textBox1)
        Me.Controls.Add(Me.button2)
        Me.Controls.Add(Me.button1)
        Me.Controls.Add(Me.groupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ConnectionForm"
        Me.Text = "Окно подключения"
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents comboBox1 As System.Windows.Forms.ComboBox
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents textBox1 As System.Windows.Forms.TextBox
    Private WithEvents button2 As System.Windows.Forms.Button
    Private WithEvents button1 As System.Windows.Forms.Button
    Private WithEvents textBox2 As System.Windows.Forms.TextBox
    Private WithEvents textBox3 As System.Windows.Forms.TextBox
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents label3 As System.Windows.Forms.Label
End Class
