Imports ModesApiFactory = ModesApiExternal.ModesApiFactory
Imports ModesApiExternal.ModesApiFactory
Imports Modes
Imports Modes.BusinessLogic
Imports Modes.NetAccess
Imports System.Collections.Generic
Imports System.Globalization





Public Class Main
    Private api_ As ModesApiExternal.IApiExternal = Nothing
    Private isConnected_ As Boolean
    Public isConnected As Boolean = isConnected_
    Private isConnectedAIISKUE_ As Boolean
    Public isConnectedAIISKUE As Boolean = isConnectedAIISKUE_
    Public server As String = "id-modes1.id.irkutskenergo.ru"
    Public HourAIISKUE As Integer = 25

    Class IGO_Cover
        Public IGO As IGenObject
        Public DisplayName As String
        Property DisplayNameALL() As String
            Get
                Return DisplayName
            End Get
            Set(ByVal value As String)
                DisplayName = value
            End Set
        End Property
        Sub New(IGO_ As IGenObject, DisplayName_ As String)
            IGO = IGO_
            DisplayName = DisplayName_
        End Sub
    End Class

#Region "Подключение к modes-centre"
    Private Sub ModescentreToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModescentreToolStripMenuItem.Click  ' ff
        If (isConnected) Then
            ModescentreToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control
            ModesApiFactory.CloseConnection()
            outputEventsBox.Text = outputEventsBox.Text + DateTime.Now.ToString + "  " + "Отключение от сервера modes-centre." + vbCrLf
            isConnected = False
        Else
            Dim f1 As New ConnectionForm
            f1.Controls("TextBox1").Text = server
            f1.Text = "Подключение к серверу Modes-centre."
            If (f1.ShowDialog() <> DialogResult.OK) Then Return
            outputEventsBox.Text = outputEventsBox.Text + DateTime.Now.ToString + "  " + "Подключение к серверу modes-centre(" + f1.serverName + ")." + vbCrLf
            If (f1.isLocal) Then
                ModesApiFactory.Initialize(f1.serverName, f1.User, f1.Pass)
            Else
                ModesApiFactory.Initialize(server)
                If (ModesApiFactory.IsInitilized) Then
                    outputEventsBox.Text = outputEventsBox.Text + DateTime.Now.ToString + "  " + "Подключение к серверу modes-centre(" + f1.serverName + ") прошло успешно." + vbCrLf
                    api_ = ModesApiFactory.GetModesApi()
                    ModescentreToolStripMenuItem.BackColor = Color.Lime
                    isConnected = True
                Else
                    outputEventsBox.Text = outputEventsBox.Text + DateTime.Now.ToString + "  " + "Подключение к серверу modes-centre(" + f1.serverName + ") прошло безуспешно." + vbCrLf
                End If
            End If
        End If
    End Sub
#End Region

#Region "Подключение к AIIS KUE"
    Private Sub AIISKUEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AIISKUEToolStripMenuItem.Click
        If (isConnectedAIISKUE) Then
            AIISKUEToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control
            'OracleConnection1.Close()
            isConnectedAIISKUE = False
        Else
            Dim f1 As New ConnectionForm
            f1.Controls("TextBox1").Text = "AIISKUE"
            f1.Text = "Подключение к серверу АИИС КУЭ."
            If (f1.ShowDialog() <> DialogResult.OK) Then Return
            If (f1.isLocal) Then

            Else
                'OracleConnection1.ConnectionString = ""
                'OracleConnection1.Open()
                'If OracleConnection1.State = ConnectionState.Open Then

                'AIISKUEToolStripMenuItem.BackColor = Color.Lime
                'isConnectedAIISKUE = True
                'End If
            End If
        End If

    End Sub
#End Region

    Private Sub toolStripButton1_Click(sender As Object, e As EventArgs) Handles toolStripButton1.Click
        outputEventsBox.Clear()
    End Sub

    Private Sub ButtonModes_Click(sender As Object, e As EventArgs) Handles ButtonModes.Click
        'Date.LocalHqToSystemEx   внутренне представление начала суток планирования
        If Not (isConnected) Then
            outputEventsBox.Text = outputEventsBox.Text + DateTime.Now.ToString + "  " + "Необходимо подключение к серверу modes-centre)." + vbCrLf
            Return
        End If
        Dim dt_ As DateTime = PGDate.Value.Date.LocalHqToSystemEx
        Dim syncZone As SyncZone = syncZone.First
        Dim ts As IModesTimeSlice
        If api_ IsNot Nothing Then
            ts = api_.GetModesTimeSlice(dt_, syncZone, TreeContent.PGObjects, False)
            PGObjects.Items.Clear()
            For Each IGO As IGenObject In ts.GenTree
                ExpandTree(PGObjects.Items, IGO, "")
            Next
            If (PGObjects.Items.Count > 0) Then PGObjects.SelectedIndex = 0
            outputEventsBox.Text = outputEventsBox.Text + DateTime.Now.ToString + "  " + "Получено дерево оборудования УИ ГЭС на " + dt_ + "." + vbCrLf
        Else
            outputEventsBox.Text = outputEventsBox.Text + DateTime.Now.ToString + "  " + "Не получено дерево оборудования УИ ГЭС на " + dt_ + "." + vbCrLf
            Return
        End If
    End Sub

    Sub ExpandTree(list As IList, IGO As IGenObject, Level As String)
        list.Add(New IGO_Cover(IGO_:=IGO, DisplayName_:=String.Format("{0} {1}; Тип: {2}", Level, IGO.Description, IGO.GenObjType.Description)))
        For Each it As IGenObject In IGO.Children
            ExpandTree(list, it, Level + "  ")
        Next
    End Sub

    Sub DataGridPlanConstruction(dtStart As DateTime, dtEnd As DateTime, intreval As Double)
        dataGridModes.Rows.Clear()
        dataGridModes.Columns.Clear()
        Dim col1 As DataGridViewTextBoxColumn
        While (dtStart <= dtEnd)
            col1 = New DataGridViewTextBoxColumn()
            col1.HeaderText = dtStart.ToString("HH:mm") 'col1.HeaderText = dtStart.ToString("dd HH:mm")
            col1.Width = 55
            dataGridModes.Columns.Add(col1)
            dtStart = dtStart.AddMinutes(intreval)
        End While
    End Sub

    Private Sub PGActual_Click(sender As Object, e As EventArgs) Handles PGActual.Click
        If Not (isConnected) Then
            outputEventsBox.Text = outputEventsBox.Text + DateTime.Now.ToString + "  " + "Необходимо подключение к серверу modes-centre." + vbCrLf
            Return
        End If
        Dim dt_ As DateTime = PGDate.Value.Date.LocalHqToSystemEx
        Dim syncZone As SyncZone = syncZone.First
        Dim Values As IList(Of Modes.PlanValueItem)
        Dim max, min As DateTime
        Dim interval As Integer
        If PGObjects.SelectedItem IsNot Nothing And TypeOf PGObjects.SelectedItem Is IGO_Cover Then
            Values = api_.GetPlanValuesActual(dt_, PGDate.Value.Date.AddDays(1).SystemToLocalHqEx(), (PGObjects.SelectedItem).IGO)
            If Values.Count = 0 Then
                outputEventsBox.Text = outputEventsBox.Text + DateTime.Now.ToString + "  " + String.Format("На {0} нет плановых графиков.  - ", PGDate.Value.Date.ToShortDateString()) + (PGObjects.SelectedItem).IGO.Description + vbCrLf
                Return
            End If
            outputEventsBox.Text = outputEventsBox.Text + DateTime.Now.ToString + "  " + "Получены данные оборудования - " + (PGObjects.SelectedItem).IGO.Description + "." + vbCrLf
            min = Values.Min(Function(x) x.DT).SystemToLocalHqEx()
            max = Values.Max(Function(x) x.DT).SystemToLocalHqEx()
            interval = 60
            DataGridPlanConstruction(min, max, interval)
            dataGridModes.Visible = True
            For Each IT In api_.GetPlanFactors().OrderBy(Function(x) x.Id)
                dataGridModes.Rows.Add()
                dataGridModes.Rows(IT.Id).Cells(0).Value = IT.Description
            Next
            For Each it In Values
                Dim col As Int32 = Convert.ToInt32((it.DT.SystemToLocalHqEx() - min).TotalMinutes / interval) + 1
                dataGridModes.Rows(it.ObjFactor).Cells(col).Value = it.Value.ToString()
            Next
        Else
            outputEventsBox.Text = outputEventsBox.Text + DateTime.Now.ToString + "  " + "Необходимо выбрать оборудование УИ ГЭС." + vbCrLf
            Return
        End If
    End Sub

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Tini.SetSection("Config") ' Задаем ключевое поле для ini
        NumericUpDown1.Value = CDbl(Trim(Tini.LoadValue("Napor")))
        Tini.SetSection("Connection")
        server = Microsoft.VisualBasic.Strings.Left(Trim(Tini.LoadValue("ServerModes")), Trim(Tini.LoadValue("ServerModes")).Length - 1)


    End Sub

    Private Sub Main_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If (isConnected) Then
            ModescentreToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control
            ModesApiFactory.CloseConnection()
            outputEventsBox.Text = outputEventsBox.Text + DateTime.Now.ToString + "  " + "Отключение от сервера modes-centre." + vbCrLf
            isConnected = False
        End If
        Tini.SetSection("Config") ' Задаем ключевое поле для ini
        Tini.SaveValue("Napor", NumericUpDown1.Value.ToString)


    End Sub

    Private Sub ButtonModesAUTO_Click(sender As Object, e As EventArgs) Handles ButtonModesAUTO.Click
        If Not (isConnected) Then
            outputEventsBox.Text = DateTime.Now.ToString + "  " + "Подключение к серверу modes-centre(" + server + ")." + vbCrLf + outputEventsBox.Text
            ModesApiFactory.Initialize(server)
            If (ModesApiFactory.IsInitilized) Then
                outputEventsBox.Text = DateTime.Now.ToString + "  " + "Подключение к серверу modes-centre(" + server + ") прошло успешно." + vbCrLf + outputEventsBox.Text
                api_ = ModesApiFactory.GetModesApi()
                ModescentreToolStripMenuItem.BackColor = Color.Lime
                isConnected = True
            Else
                outputEventsBox.Text = DateTime.Now.ToString + "  " + "Подключение к серверу modes-centre(" + server + ") прошло безуспешно." + vbCrLf + outputEventsBox.Text
                Return
            End If
        End If

        Dim dt_ As DateTime = PGDate.Value.Date.LocalHqToSystemEx
        Dim syncZone As SyncZone = syncZone.First
        Dim Values As IList(Of Modes.PlanValueItem)
        Dim max, min As DateTime
        Dim interval As Integer
        Dim ts As IModesTimeSlice
        Dim Children() As IGenObject
        Dim ii As Integer

        If api_ IsNot Nothing Then
            ts = api_.GetModesTimeSlice(dt_, syncZone, TreeContent.PGObjects, False)
            'Children = {ts.GenTree(0).Children(0)}
            'ii = 0
            'For Each xx As IGenObject In ts.GenTree(0).Children(0).Children
            ' ReDim Preserve Children(UBound(Children) + 1)
            '  Children(ii + 1) = xx
            '   ii += 1
            'Next
            Children = {ts.GenTree(0).Children(0), ts.GenTree(0).Children(0).Children(0), ts.GenTree(0).Children(0).Children(8), ts.GenTree(0).Children(0).Children(2), ts.GenTree(0).Children(0).Children(1), ts.GenTree(0).Children(0).Children(9), ts.GenTree(0).Children(0).Children(6), ts.GenTree(0).Children(0).Children(7), ts.GenTree(0).Children(0).Children(3), ts.GenTree(0).Children(0).Children(4), ts.GenTree(0).Children(0).Children(5)}
            outputEventsBox.Text = DateTime.Now.ToString + "  " + "Получено дерево оборудования УИ ГЭС на " + Format(PGDate.Value.Date, "d MMMM yyyy") + "." + vbCrLf + outputEventsBox.Text
        Else
            outputEventsBox.Text = DateTime.Now.ToString + "  " + "Не получено дерево оборудования УИ ГЭС на " + Format(PGDate.Value.Date, "d MMMM yyyy") + "." + vbCrLf + outputEventsBox.Text
            Return
        End If
        ii = -1
        For Each ChildrenN As IGenObject In Children
            Values = api_.GetPlanValuesActual(dt_, PGDate.Value.Date.AddDays(1).SystemToLocalHqEx(), ChildrenN)
            If Values.Count = 0 Then
                outputEventsBox.Text = DateTime.Now.ToString + "  " + String.Format("На {0} нет плановых графиков.  - ", PGDate.Value.Date.ToShortDateString()) + (PGObjects.SelectedItem).IGO.Description + vbCrLf + outputEventsBox.Text
                Return
            End If
            outputEventsBox.Text = DateTime.Now.ToString + "  " + "Получены данные оборудования - " + ChildrenN.Description + "." + vbCrLf + outputEventsBox.Text
            min = Values.Min(Function(x) x.DT).SystemToLocalHqEx()
            max = Values.Max(Function(x) x.DT).SystemToLocalHqEx()
            If ii = -1 Then
                interval = 60
                DataGridPlanConstruction(min, max, interval)
                dataGridModes.Visible = True
            End If
            ii += 1
            dataGridModes.Rows.Add()
            dataGridModes.Rows(ii).Cells(0).Value = ChildrenN.Description
            For Each it In Values.Where(Function(x) x.ObjFactor = 0)
                Dim col As Int32 = Convert.ToInt32((it.DT.SystemToLocalHqEx() - min).TotalMinutes / interval) + 1
                dataGridModes.Rows(ii).Cells(col).Value = it.Value.ToString()
            Next
        Next
    End Sub
    ' запрос данных АИИС КУЭ
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim col As DataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        Try
            outputEventsBox.Text = DateTime.Now.ToString + "  " + "Создаем таблицу данных AIIS KUE." + vbCrLf + outputEventsBox.Text
            DataGridAIISKUE.Rows.Clear() 'очистка строк
            DataGridAIISKUE.Columns.Clear() 'очистка столбцов
            Tini.SetSection("Columns AIIS KUE") ' Задаем ключевое поле для ini
            'Begin Формируем таблицу 24х16
            For i = 1 To 24
                col = New DataGridViewTextBoxColumn()
                col.HeaderText = i
                col.Width = 60
                DataGridAIISKUE.Columns.Add(col)
            Next
            For i = 1 To 24
                DataGridAIISKUE.Rows.Add()
                DataGridAIISKUE.Rows(i - 1).HeaderCell.Value = Trim(Tini.LoadValue("ROW_" & i))
            Next
            'End Формируем таблицу 24х16
        Catch ex As Exception
            outputEventsBox.Text = DateTime.Now.ToString + "  " + String.Format("Error: {0}", ex) + vbCrLf + outputEventsBox.Text
            Return
        End Try
        'Подключение к базе данных AIIS KUE Irkutsk
        'Dim DataBase As String = "(DESCRIPTION =(ADDRESS_LIST =(ADDRESS = (PROTOCOL = TCP) (Host = 172.16.0.68) (Port = 1521)))(CONNECT_DATA = (SID = ORCL)))"
        Tini.SetSection("Connection")
        Dim DataBase As String = Microsoft.VisualBasic.Strings.Left(Trim(Tini.LoadValue("DataBaseAiisKUE")), Trim(Tini.LoadValue("DataBaseAiisKUE")).Length - 1)
        Dim User As String = Microsoft.VisualBasic.Strings.Left(Trim(Tini.LoadValue("UserAiisKUE")), Trim(Tini.LoadValue("UserAiisKUE")).Length - 1)
        Dim Password As String = Microsoft.VisualBasic.Strings.Left(Trim(Tini.LoadValue("PasswordAiisKUE")), Trim(Tini.LoadValue("PasswordAiisKUE")).Length - 1)
        Dim ConnString As String = "Provider=Microsoft OLE DB Provider for Oracle;User ID=" + User + ";Password=" + Password + ";Data Source=" + DataBase + ";"
        Dim Con As New OleDb.OleDbConnection(ConnString) ' Переменная для подключения базы
        Dim SqlCom As OleDb.OleDbCommand ' Переменная для Sql запросов
        Dim DT As New Data.DataTable ' Таблица для хранения результатов запроса
        Dim DA As OleDb.OleDbDataAdapter
        Dim dt_ As String = Format(PGDate.Value.Date, "dd-MM-yy")
        Try
            DT.Clear() 'Очищаем таблицу
            Dim s As String = "SELECT GEN_1,GEN_2,GEN_3,GEN_4,GEN_5,GEN_6,GEN_7,GEN_8,GEN_9,GEN_10,GEN_11,GEN_12,GEN_13,GEN_14,GEN_15,GEN_16 " _
                & "FROM (select  sum(VAL)/1000 as GEN_1, Trunc((N_INTER_RAS+1)/2,0) as Ind from CNT.BUF_V_INT where SYB_RNK=2 and N_OB=20800001 and N_FID=1 and N_GR_TY=1 and DD_MM_YYYY=TO_DATE('" + dt_ + "','DD-MM-YY') group BY Trunc((N_INTER_RAS+1)/2,0) HAVING COUNT(*)=2)  G1 " _
                & "INNER JOIN (select  sum(VAL)/1000 as GEN_2, Trunc((N_INTER_RAS+1)/2,0) as Ind from CNT.BUF_V_INT where SYB_RNK=2 and N_OB=20800001 and N_FID=2 and N_GR_TY=1 and DD_MM_YYYY=TO_DATE('" + dt_ + "','DD-MM-YY') group BY Trunc((N_INTER_RAS+1)/2,0) HAVING COUNT(*)=2) G2 on G1.Ind=G2.Ind " _
                & "INNER JOIN (select  sum(VAL)/1000 as GEN_3, Trunc((N_INTER_RAS+1)/2,0) as Ind from CNT.BUF_V_INT where SYB_RNK=2 and N_OB=20800001 and N_FID=3 and N_GR_TY=1 and DD_MM_YYYY=TO_DATE('" + dt_ + "','DD-MM-YY') group BY Trunc((N_INTER_RAS+1)/2,0) HAVING COUNT(*)=2) G3 on G1.Ind=G3.Ind " _
                & "INNER JOIN (select  sum(VAL)/1000 as GEN_4, Trunc((N_INTER_RAS+1)/2,0) as Ind from CNT.BUF_V_INT where SYB_RNK=2 and N_OB=20800001 and N_FID=4 and N_GR_TY=1 and DD_MM_YYYY=TO_DATE('" + dt_ + "','DD-MM-YY') group BY Trunc((N_INTER_RAS+1)/2,0) HAVING COUNT(*)=2) G4 on G1.Ind=G4.Ind " _
                & "INNER JOIN (select  sum(VAL)/1000 as GEN_5, Trunc((N_INTER_RAS+1)/2,0) as Ind from CNT.BUF_V_INT where SYB_RNK=2 and N_OB=20800001 and N_FID=5 and N_GR_TY=1 and DD_MM_YYYY=TO_DATE('" + dt_ + "','DD-MM-YY') group BY Trunc((N_INTER_RAS+1)/2,0) HAVING COUNT(*)=2) G5 on G1.Ind=G5.Ind " _
                & "INNER JOIN (select  sum(VAL)/1000 as GEN_6, Trunc((N_INTER_RAS+1)/2,0) as Ind from CNT.BUF_V_INT where SYB_RNK=2 and N_OB=20800001 and N_FID=6 and N_GR_TY=1 and DD_MM_YYYY=TO_DATE('" + dt_ + "','DD-MM-YY') group BY Trunc((N_INTER_RAS+1)/2,0) HAVING COUNT(*)=2) G6 on G1.Ind=G6.Ind " _
                & "INNER JOIN (select  sum(VAL)/1000 as GEN_7, Trunc((N_INTER_RAS+1)/2,0) as Ind from CNT.BUF_V_INT where SYB_RNK=2 and N_OB=20800001 and N_FID=7 and N_GR_TY=1 and DD_MM_YYYY=TO_DATE('" + dt_ + "','DD-MM-YY') group BY Trunc((N_INTER_RAS+1)/2,0) HAVING COUNT(*)=2) G7 on G1.Ind=G7.Ind " _
                & "INNER JOIN (select  sum(VAL)/1000 as GEN_8, Trunc((N_INTER_RAS+1)/2,0) as Ind from CNT.BUF_V_INT where SYB_RNK=2 and N_OB=20800001 and N_FID=8 and N_GR_TY=1 and DD_MM_YYYY=TO_DATE('" + dt_ + "','DD-MM-YY') group BY Trunc((N_INTER_RAS+1)/2,0) HAVING COUNT(*)=2) G8 on G1.Ind=G8.Ind " _
                & "INNER JOIN (select  sum(VAL)/1000 as GEN_9, Trunc((N_INTER_RAS+1)/2,0) as Ind from CNT.BUF_V_INT where SYB_RNK=2 and N_OB=20800001 and N_FID=9 and N_GR_TY=1 and DD_MM_YYYY=TO_DATE('" + dt_ + "','DD-MM-YY') group BY Trunc((N_INTER_RAS+1)/2,0) HAVING COUNT(*)=2) G9 on G1.Ind=G9.Ind " _
                & "INNER JOIN (select  sum(VAL)/1000 as GEN_10, Trunc((N_INTER_RAS+1)/2,0) as Ind from CNT.BUF_V_INT where SYB_RNK=2 and N_OB=20800001 and N_FID=10 and N_GR_TY=1 and DD_MM_YYYY=TO_DATE('" + dt_ + "','DD-MM-YY') group BY Trunc((N_INTER_RAS+1)/2,0) HAVING COUNT(*)=2) G10 on G1.Ind=G10.Ind " _
                & "INNER JOIN (select  sum(VAL)/1000 as GEN_11, Trunc((N_INTER_RAS+1)/2,0) as Ind from CNT.BUF_V_INT where SYB_RNK=2 and N_OB=20800001 and N_FID=11 and N_GR_TY=1 and DD_MM_YYYY=TO_DATE('" + dt_ + "','DD-MM-YY') group BY Trunc((N_INTER_RAS+1)/2,0) HAVING COUNT(*)=2) G11 on G1.Ind=G11.Ind " _
                & "INNER JOIN (select  sum(VAL)/1000 as GEN_12, Trunc((N_INTER_RAS+1)/2,0) as Ind from CNT.BUF_V_INT where SYB_RNK=2 and N_OB=20800001 and N_FID=12 and N_GR_TY=1 and DD_MM_YYYY=TO_DATE('" + dt_ + "','DD-MM-YY') group BY Trunc((N_INTER_RAS+1)/2,0) HAVING COUNT(*)=2) G12 on G1.Ind=G12.Ind " _
                & "INNER JOIN (select  sum(VAL)/1000 as GEN_13, Trunc((N_INTER_RAS+1)/2,0) as Ind from CNT.BUF_V_INT where SYB_RNK=2 and N_OB=20800001 and N_FID=13 and N_GR_TY=1 and DD_MM_YYYY=TO_DATE('" + dt_ + "','DD-MM-YY') group BY Trunc((N_INTER_RAS+1)/2,0) HAVING COUNT(*)=2) G13 on G1.Ind=G13.Ind " _
                & "INNER JOIN (select  sum(VAL)/1000 as GEN_14, Trunc((N_INTER_RAS+1)/2,0) as Ind from CNT.BUF_V_INT where SYB_RNK=2 and N_OB=20800001 and N_FID=14 and N_GR_TY=1 and DD_MM_YYYY=TO_DATE('" + dt_ + "','DD-MM-YY') group BY Trunc((N_INTER_RAS+1)/2,0) HAVING COUNT(*)=2) G14 on G1.Ind=G14.Ind " _
                & "INNER JOIN (select  sum(VAL)/1000 as GEN_15, Trunc((N_INTER_RAS+1)/2,0) as Ind from CNT.BUF_V_INT where SYB_RNK=2 and N_OB=20800001 and N_FID=15 and N_GR_TY=1 and DD_MM_YYYY=TO_DATE('" + dt_ + "','DD-MM-YY') group BY Trunc((N_INTER_RAS+1)/2,0) HAVING COUNT(*)=2) G15 on G1.Ind=G15.Ind " _
                & "INNER JOIN (select  sum(VAL)/1000 as GEN_16, Trunc((N_INTER_RAS+1)/2,0) as Ind from CNT.BUF_V_INT where SYB_RNK=2 and N_OB=20800001 and N_FID=16 and N_GR_TY=1 and DD_MM_YYYY=TO_DATE('" + dt_ + "','DD-MM-YY') group BY Trunc((N_INTER_RAS+1)/2,0) HAVING COUNT(*)=2) G16 on G1.Ind=G16.Ind"
            SqlCom = New OleDb.OleDbCommand(s, Con) ' Указываем строку запроса и привязываем к соединению
            outputEventsBox.Text = DateTime.Now.ToString + "  " + "Подключение к серверу AIIS KUE (" + DataBase + ")." + vbCrLf + outputEventsBox.Text
            Con.Open() ' Открываем соединение
            If Con.State = ConnectionState.Open Then
                outputEventsBox.Text = DateTime.Now.ToString + "  " + "Подключение к серверу AIIS KUE (" + DataBase + ") прошло успешно." + vbCrLf + outputEventsBox.Text
            Else
                outputEventsBox.Text = DateTime.Now.ToString + "  " + "Подключение к серверу AIIS KUE (" + DataBase + ") прошло безуспешно." + vbCrLf + outputEventsBox.Text
                Return
            End If
            SqlCom.CommandType = CommandType.Text
            SqlCom.ExecuteNonQuery() 'Выполняем запрос
            DA = New OleDb.OleDbDataAdapter(SqlCom) 'Через адаптер получаем результаты запроса
            DA.Fill(DT) 'Заполняем таблицу результатми
            'Заполняем Grid результатми
            outputEventsBox.Text = DateTime.Now.ToString + "  " + "Получены данные AIIS KUE за " + Format(PGDate.Value.Date, "d MMMM yyyy") + " ." + vbCrLf + outputEventsBox.Text
            For Each row As DataRow In DT.Rows
                For Each col1 As DataColumn In DT.Columns
                    DataGridAIISKUE.Rows(DT.Columns.IndexOf(col1)).Cells(DT.Rows.IndexOf(row)).Value = row(col1)
                    If DT.Columns.IndexOf(col1) < 4 Then
                        DataGridAIISKUE.Rows(DT.Columns.IndexOf(col1)).DefaultCellStyle.BackColor = Color.FromArgb(&HFF, &HAD, &HFF, &H2F)
                        DataGridAIISKUE.Rows(17).Cells(DT.Rows.IndexOf(row)).Value += row(col1)
                    Else
                        DataGridAIISKUE.Rows(DT.Columns.IndexOf(col1)).DefaultCellStyle.BackColor = Color.FromArgb(&HFF, &HEF, &HAF, &H8C)
                        DataGridAIISKUE.Rows(18).Cells(DT.Rows.IndexOf(row)).Value += row(col1)
                    End If
                    DataGridAIISKUE.Rows(19).Cells(DT.Rows.IndexOf(row)).Value += row(col1)
                Next
            Next


            HourAIISKUE = 25
            For j = 1 To 24
                If DataGridAIISKUE.Rows(19).Cells(j - 1).Value IsNot Nothing Then
                ElseIf HourAIISKUE > j Then
                    HourAIISKUE = j
                End If
            Next
            DataGridAIISKUE.Rows(21).Cells(0).Value = DataGridAIISKUE.Rows(17).Cells(0).Value
            DataGridAIISKUE.Rows(22).Cells(0).Value = DataGridAIISKUE.Rows(18).Cells(0).Value
            DataGridAIISKUE.Rows(23).Cells(0).Value = DataGridAIISKUE.Rows(19).Cells(0).Value
            For j = 1 To HourAIISKUE - 2
                DataGridAIISKUE.Rows(21).Cells(j).Value = DataGridAIISKUE.Rows(21).Cells(j - 1).Value + DataGridAIISKUE.Rows(17).Cells(j).Value
                DataGridAIISKUE.Rows(22).Cells(j).Value = DataGridAIISKUE.Rows(22).Cells(j - 1).Value + DataGridAIISKUE.Rows(18).Cells(j).Value
                DataGridAIISKUE.Rows(23).Cells(j).Value = DataGridAIISKUE.Rows(23).Cells(j - 1).Value + DataGridAIISKUE.Rows(19).Cells(j).Value
            Next

            DataGridAIISKUE.Rows(17).DefaultCellStyle.BackColor = Color.FromArgb(&HFF, &HAB, &HCD, &HEF)
            DataGridAIISKUE.Rows(18).DefaultCellStyle.BackColor = Color.FromArgb(&HFF, &HAB, &HCD, &HEF)
            DataGridAIISKUE.Rows(19).DefaultCellStyle.BackColor = Color.FromArgb(&HFF, &HAB, &HCD, &HEF)
            DataGridAIISKUE.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
            DataGridAIISKUE.Visible = True
            TabControl1.SelectedTab = TabPage1
            Button1.Enabled = False
            Button3.Enabled = True
        Catch ex As Exception
            outputEventsBox.Text = DateTime.Now.ToString + "  " + String.Format("Error: {0}", ex) + vbCrLf + outputEventsBox.Text
        Finally
            Con.Close() ' Закрываем соединение
        End Try
    End Sub
    ' запрос данных Modes-centre
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
       
        'Плдключение к modes-centre
        If Not (isConnected) Then
            outputEventsBox.Text = DateTime.Now.ToString + "  " + "Подключение к серверу modes-centre(" + server + ")." + vbCrLf + outputEventsBox.Text
            ModesApiFactory.Initialize(server)
            If (ModesApiFactory.IsInitilized) Then
                outputEventsBox.Text = DateTime.Now.ToString + "  " + "Подключение к серверу modes-centre(" + server + ") прошло успешно." + vbCrLf + outputEventsBox.Text
                api_ = ModesApiFactory.GetModesApi()
                ModescentreToolStripMenuItem.BackColor = Color.Lime
                isConnected = True
            Else
                outputEventsBox.Text = DateTime.Now.ToString + "  " + "Подключение к серверу modes-centre(" + server + ") прошло безуспешно." + vbCrLf + outputEventsBox.Text
                Return
            End If
        End If
        Dim dt_ As DateTime = PGDate.Value.Date.LocalHqToSystemEx
        Dim syncZone As SyncZone = syncZone.First
        Dim Values As IList(Of Modes.PlanValueItem)
        Dim Values2 As IList(Of Modes.PlanValueItem)
        Dim max, min As DateTime
        Dim interval As Integer
        Dim ts As IModesTimeSlice
        Dim Children() As IGenObject
        Dim ii As Integer
        If api_ IsNot Nothing Then
            ts = api_.GetModesTimeSlice(dt_, syncZone, TreeContent.PGObjects, False)
            Children = {ts.GenTree(0).Children(0), ts.GenTree(0).Children(0).Children(0), ts.GenTree(0).Children(0).Children(8), ts.GenTree(0).Children(0).Children(2), ts.GenTree(0).Children(0).Children(1), ts.GenTree(0).Children(0).Children(9), ts.GenTree(0).Children(0).Children(6), ts.GenTree(0).Children(0).Children(7), ts.GenTree(0).Children(0).Children(3), ts.GenTree(0).Children(0).Children(4), ts.GenTree(0).Children(0).Children(5)}
            outputEventsBox.Text = DateTime.Now.ToString + "  " + "Получено дерево оборудования УИ ГЭС на " + Format(PGDate.Value.Date, "d MMMM yyyy") + "." + vbCrLf + outputEventsBox.Text
        Else
            outputEventsBox.Text = DateTime.Now.ToString + "  " + "Не получено дерево оборудования УИ ГЭС на " + Format(PGDate.Value.Date, "d MMMM yyyy") + "." + vbCrLf + outputEventsBox.Text
            Return
        End If
        ii = -1
        For Each ChildrenN As IGenObject In Children
            ' ПБР
            Values = api_.GetPlanValuesActual(dt_, PGDate.Value.Date.AddDays(1).SystemToLocalHqEx(), ChildrenN)
            If Values.Count = 0 Then
                outputEventsBox.Text = DateTime.Now.ToString + "  " + String.Format("На {0} нет актуальных плановых графиков.  - ", PGDate.Value.Date.ToShortDateString()) + (PGObjects.SelectedItem).IGO.Description + vbCrLf + outputEventsBox.Text
                Return
            End If
            outputEventsBox.Text = DateTime.Now.ToString + "  " + "Получены актуальные данные оборудования - " + ChildrenN.Description + "." + vbCrLf + outputEventsBox.Text
            min = Values.Min(Function(x) x.DT).SystemToLocalHqEx()
            max = Values.Max(Function(x) x.DT).SystemToLocalHqEx()
            If ii = -1 Then
                interval = 60
                DataGridPlanConstruction(min, max, interval)
            End If
            ii += 1
            dataGridModes.Rows.Add()
            dataGridModes.Rows(ii).HeaderCell.Value = dataGridModes.Rows.Count.ToString + " " + ChildrenN.Description
            dataGridModes.Rows(ii).HeaderCell.ToolTipText = "Актуальные данные " + ChildrenN.Description + " на " + Format(PGDate.Value.Date, "d MMMM yyyy")
            dataGridModes.Rows(ii).DefaultCellStyle.BackColor = Color.FromArgb(&HFF, &HAD, &HFF, &H2F)
            For Each it In Values.Where(Function(x) x.ObjFactor = 0)
                Dim col As Int32 = Convert.ToInt32((it.DT.SystemToLocalHqEx() - min).TotalMinutes / interval)
                dataGridModes.Rows(ii).Cells(col).Value = it.Value
            Next
        Next
        ' ППБР
        dataGridModes.Rows.Add()
        ii = 12
        For Each ChildrenN As IGenObject In Children
            Dim ccv As IList(Of IGenObject) = {ChildrenN}
            Values2 = api_.GetPlanByDay(dt_, {PlanType.ППБР}, ccv)
            If Values2.Count = 0 Then
                outputEventsBox.Text = DateTime.Now.ToString + "  " + String.Format("На {0} нет ППБР графиков.  - ", PGDate.Value.Date.ToShortDateString()) + ts.GenTree(0).Children(0).Description + vbCrLf + outputEventsBox.Text
                Return
            End If
            outputEventsBox.Text = DateTime.Now.ToString + "  " + "Получены ППБР данные оборудования - " + ChildrenN.Description + "." + vbCrLf + outputEventsBox.Text
            dataGridModes.Rows.Add()
            dataGridModes.Rows(ii).HeaderCell.Value = dataGridModes.Rows.Count.ToString + " " + PlanType.ППБР.ToString + " " + ChildrenN.Description
            dataGridModes.Rows(ii).DefaultCellStyle.BackColor = Color.FromArgb(&HFF, &HEF, &HAF, &H8C)
            dataGridModes.Rows(ii).HeaderCell.ToolTipText = PlanType.ППБР.ToString + ChildrenN.Description + " на " + Format(PGDate.Value.Date, "d MMMM yyyy")
            dataGridModes.Rows(ii).Cells(0).Value = dataGridModes.Rows(ii - 12).Cells(0).Value
            For Each it In Values2.Where(Function(x) x.ObjFactor = 0)
                Dim col As Int32 = Convert.ToInt32((it.DT.SystemToLocalHqEx() - min).TotalMinutes / interval)
                dataGridModes.Rows(ii).Cells(col).Value = it.Value
            Next
            ii += 1
        Next
        'Считаем энергию ПБР
        dataGridModes.Rows.Add()
        For i = 1 To 11
            dataGridModes.Rows.Add()
            dataGridModes.Rows(dataGridModes.Rows.Count - 1).HeaderCell.Value = dataGridModes.Rows.Count.ToString + " W " + dataGridModes.Rows(i - 1).HeaderCell.Value
            For j = 1 To 24
                dataGridModes.Rows(dataGridModes.Rows.Count - 1).Cells(j).Value = (dataGridModes.Rows(i - 1).Cells(j - 1).Value + dataGridModes.Rows(i - 1).Cells(j).Value) / 2
            Next
        Next
        'Считаем энергию ППБР
        dataGridModes.Rows.Add()
        For i = 1 To 11
            dataGridModes.Rows.Add()
            dataGridModes.Rows(dataGridModes.Rows.Count - 1).HeaderCell.Value = dataGridModes.Rows.Count.ToString + " W " + dataGridModes.Rows(i + 11).HeaderCell.Value
            For j = 1 To 24
                dataGridModes.Rows(dataGridModes.Rows.Count - 1).Cells(j).Value = (dataGridModes.Rows(i + 11).Cells(j - 1).Value + dataGridModes.Rows(i + 11).Cells(j).Value) / 2
            Next
        Next

        dataGridModes.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        dataGridModes.Visible = True
        TabControl1.SelectedTab = TabPage2
        Button3.Enabled = False
        Button6.Enabled = True
    End Sub
   
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim col As DataGridViewTextBoxColumn
        DataGridreport2.Rows.Clear() 'очистка строк
        DataGridreport2.Columns.Clear() 'очистка столбцов
        DataGridreport2.TopLeftHeaderCell.Value = ""
        'Заполняем заголовки столбцов
        For i = 0 To 24
            col = New DataGridViewTextBoxColumn()
            col.HeaderText = Format(i - 1, "00").ToString + " " & ":00 " + vbCrLf + Format(i, "00").ToString + " " & ":00"
            If i = 0 Then col.HeaderText = "Итого:"
            col.Width = 70
            DataGridreport2.Columns.Add(col)
        Next
        'Заполняем заголовки строк
        Tini.SetSection("report2") ' Задаем ключевое поле для ini
        For i = 1 To 17
            DataGridreport2.Rows.Add()
            DataGridreport2.Rows(i - 1).HeaderCell.Value = Trim(Tini.LoadValue("ROW_" & i))
            Select Case i
                Case 1 To 2
                    'DataGridreport2.Rows(i - 1).DefaultCellStyle.BackColor = Color.Yellow
                Case 3 To 8
                    DataGridreport2.Rows(i - 1).DefaultCellStyle.BackColor = Color.FromArgb(&HFF, 255, 240, 230)
                Case 9 To 14
                    DataGridreport2.Rows(i - 1).DefaultCellStyle.BackColor = Color.FromArgb(&HFF, 0, 255, 255)
            End Select
        Next
        'Заполняем цвета АИИС КУЭ
        For j = 1 To HourAIISKUE - 1
            DataGridreport2.Rows(0).Cells(j).Style.BackColor = Color.FromArgb(&HFF, &HFF, &HFF, &HBB)
            DataGridreport2.Rows(1).Cells(j).Style.BackColor = Color.FromArgb(&HFF, &HFF, &HFF, &HBB)
        Next
        'Заполняем цвета Модес после данных АИИС КУЭ
        For j = HourAIISKUE To 24
            DataGridreport2.Rows(0).Cells(j).Style.BackColor = Color.FromArgb(&HFF, &HFF, &HFF, &H0)
            DataGridreport2.Rows(1).Cells(j).Style.BackColor = Color.FromArgb(&HFF, &HFF, &HFF, &H0)
        Next
        '################   Begin Заполняем состав оборудования ###############################
        Tini.SetSection("Config") ' Задаем ключевое поле для ini заполняем кол-во ген
        For j = 1 To 24
            Dim a1 As Double
            If Double.TryParse(Trim(Tini.LoadValue("G220_H" & j)), a1) Then
                If a1 >= 0 And a1 <= 4 Then
                    DataGridreport2.Rows(0).Cells(j).Value() = a1
                Else
                    DataGridreport2.Rows(0).Cells(j).ToolTipText = "Сохраненное значение в базе '" + a1.ToString + "', не удовлетворяет условиям, заменено на автоматически рассчитанное."
                    DataGridreport2.Rows(0).Cells(j).Value = System.Math.Max((System.Math.Round(CDbl(dataGridModes.Rows(37).Cells(j).Value) / 200)), (System.Math.Floor(CDbl(dataGridModes.Rows(37).Cells(j).Value) / 240) + 1))
                    DataGridreport2.Rows(0).Cells(j).Style.BackColor = Color.Pink
                End If
            Else
                DataGridreport2.Rows(0).Cells(j).ToolTipText = "Сохраненное значение в базе '" + a1.ToString + "', не удовлетворяет условиям, заменено на автоматически рассчитанное."
                DataGridreport2.Rows(0).Cells(j).Value = System.Math.Max((System.Math.Round(CDbl(dataGridModes.Rows(37).Cells(j).Value) / 200)), (System.Math.Floor(CDbl(dataGridModes.Rows(37).Cells(j).Value) / 240) + 1))
                DataGridreport2.Rows(0).Cells(j).Style.BackColor = Color.Red
            End If
            ' DataGridreport2.Rows(0).Cells(j).Value() = CDbl(Trim(Tini.LoadValue("G220_H" & j)))
            If Double.TryParse(Trim(Tini.LoadValue("G500_H" & j)), a1) Then
                If a1 >= 0 And a1 <= 12 Then
                    DataGridreport2.Rows(1).Cells(j).Value() = a1
                Else
                    DataGridreport2.Rows(1).Cells(j).ToolTipText = "Сохраненное значение в базе '" + a1.ToString + "', не удовлетворяет условиям, заменено на автоматически рассчитанное."
                    DataGridreport2.Rows(1).Cells(j).Value = System.Math.Max((System.Math.Round(CDbl(dataGridModes.Rows(40).Cells(j).Value) / 200)), (System.Math.Floor(CDbl(dataGridModes.Rows(40).Cells(j).Value) / 240) + 1))
                    DataGridreport2.Rows(1).Cells(j).Style.BackColor = Color.Pink
                End If
            Else
                DataGridreport2.Rows(1).Cells(j).ToolTipText = "Сохраненное значение в базе '" + a1.ToString + "', не удовлетворяет условиям, заменено на автоматически рассчитанное."
                DataGridreport2.Rows(1).Cells(j).Value = System.Math.Max((System.Math.Round(CDbl(dataGridModes.Rows(40).Cells(j).Value) / 200)), (System.Math.Floor(CDbl(dataGridModes.Rows(40).Cells(j).Value) / 240) + 1))
                DataGridreport2.Rows(1).Cells(j).Style.BackColor = Color.Red
            End If
            'DataGridreport2.Rows(1).Cells(j).Value() = CDbl(Trim(Tini.LoadValue("G500_H" & j)))
        Next
        '################   End Заполняем состав оборудования ###############################
        'Заполняем данные АИИС КУЭ
        For j = 1 To HourAIISKUE - 1
            DataGridreport2.Rows(2).Cells(j).Value() = DataGridAIISKUE.Rows(19).Cells(j - 1).Value()
            DataGridreport2.Rows(5).Cells(j).Value() = DataGridAIISKUE.Rows(19).Cells(j - 1).Value()
            'Вода по данным АИИС КУЭ
            For i = 1 To 16
                DataGridreport2.Rows(8).Cells(j).Value() += WaterP(DataGridAIISKUE.Rows(i - 1).Cells(j - 1).Value(), NumericUpDown1.Value)
                DataGridreport2.Rows(11).Cells(j).Value() += WaterP(DataGridAIISKUE.Rows(i - 1).Cells(j - 1).Value(), NumericUpDown1.Value)
            Next
        Next
        'Заполняем данные Модес после данных АИИС КУЭ
        For j = HourAIISKUE To 24
            DataGridreport2.Rows(2).Cells(j).Value() = dataGridModes.Rows(36).Cells(j).Value()
            DataGridreport2.Rows(5).Cells(j).Value() = dataGridModes.Rows(24).Cells(j).Value()
            'Вода по данным Modes
            If dataGridModes.Rows(37).Cells(j).Value() / DataGridreport2.Rows(0).Cells(j).Value() <= 240 And dataGridModes.Rows(40).Cells(j).Value() / DataGridreport2.Rows(1).Cells(j).Value() <= 240 Then
                DataGridreport2.Rows(8).Cells(j).Value() = WaterP(dataGridModes.Rows(37).Cells(j).Value() / DataGridreport2.Rows(0).Cells(j).Value(), NumericUpDown1.Value) * DataGridreport2.Rows(0).Cells(j).Value() + WaterP(dataGridModes.Rows(40).Cells(j).Value() / DataGridreport2.Rows(1).Cells(j).Value(), NumericUpDown1.Value) * DataGridreport2.Rows(1).Cells(j).Value()
            Else
                DataGridreport2.Rows(8).Cells(j).Value() = WaterP(dataGridModes.Rows(37).Cells(j).Value() / DataGridreport2.Rows(0).Cells(j).Value(), NumericUpDown1.Value) * DataGridreport2.Rows(0).Cells(j).Value() + WaterP(dataGridModes.Rows(40).Cells(j).Value() / DataGridreport2.Rows(1).Cells(j).Value(), NumericUpDown1.Value) * DataGridreport2.Rows(1).Cells(j).Value()
                DataGridreport2.Rows(8).Cells(j).ToolTipText = "Проверьте состав оборудования, расчет воды не верен."
                DataGridreport2.Rows(8).Cells(j).Style.BackColor = Color.Pink
            End If
            If dataGridModes.Rows(25).Cells(j).Value() / DataGridreport2.Rows(0).Cells(j).Value() <= 240 And dataGridModes.Rows(28).Cells(j).Value() / DataGridreport2.Rows(1).Cells(j).Value() <= 240 Then
                DataGridreport2.Rows(11).Cells(j).Value() = WaterP(dataGridModes.Rows(25).Cells(j).Value() / DataGridreport2.Rows(0).Cells(j).Value(), NumericUpDown1.Value) * DataGridreport2.Rows(0).Cells(j).Value() + WaterP(dataGridModes.Rows(28).Cells(j).Value() / DataGridreport2.Rows(1).Cells(j).Value(), NumericUpDown1.Value) * DataGridreport2.Rows(1).Cells(j).Value()
            Else
                DataGridreport2.Rows(11).Cells(j).Value() = WaterP(dataGridModes.Rows(25).Cells(j).Value() / DataGridreport2.Rows(0).Cells(j).Value(), NumericUpDown1.Value) * DataGridreport2.Rows(0).Cells(j).Value() + WaterP(dataGridModes.Rows(28).Cells(j).Value() / DataGridreport2.Rows(1).Cells(j).Value(), NumericUpDown1.Value) * DataGridreport2.Rows(1).Cells(j).Value()
                DataGridreport2.Rows(11).Cells(j).ToolTipText = "Проверьте состав оборудования, расчет воды не верен."
                DataGridreport2.Rows(11).Cells(j).Style.BackColor = Color.Pink
            End If
        Next

        For j = 1 To 24
            'Заполняем данные Модес
            DataGridreport2.Rows(3).Cells(j).Value() = dataGridModes.Rows(36).Cells(j).Value() 'ППБР
            DataGridreport2.Rows(6).Cells(j).Value() = dataGridModes.Rows(24).Cells(j).Value() 'ПБР
            'Вода по данным Modes
            If dataGridModes.Rows(37).Cells(j).Value() / DataGridreport2.Rows(0).Cells(j).Value() <= 240 And dataGridModes.Rows(40).Cells(j).Value() / DataGridreport2.Rows(1).Cells(j).Value() <= 240 Then
                DataGridreport2.Rows(9).Cells(j).Value() = WaterP(dataGridModes.Rows(37).Cells(j).Value() / DataGridreport2.Rows(0).Cells(j).Value(), NumericUpDown1.Value) * DataGridreport2.Rows(0).Cells(j).Value() + WaterP(dataGridModes.Rows(40).Cells(j).Value() / DataGridreport2.Rows(1).Cells(j).Value(), NumericUpDown1.Value) * DataGridreport2.Rows(1).Cells(j).Value()
            Else
                DataGridreport2.Rows(9).Cells(j).Value() = WaterP(dataGridModes.Rows(37).Cells(j).Value() / DataGridreport2.Rows(0).Cells(j).Value(), NumericUpDown1.Value) * DataGridreport2.Rows(0).Cells(j).Value() + WaterP(dataGridModes.Rows(40).Cells(j).Value() / DataGridreport2.Rows(1).Cells(j).Value(), NumericUpDown1.Value) * DataGridreport2.Rows(1).Cells(j).Value()
                DataGridreport2.Rows(9).Cells(j).ToolTipText = "Проверьте состав оборудования, расчет воды не верен."
                DataGridreport2.Rows(9).Cells(j).Style.BackColor = Color.Pink
            End If
            If dataGridModes.Rows(25).Cells(j).Value() / DataGridreport2.Rows(0).Cells(j).Value() <= 240 And dataGridModes.Rows(28).Cells(j).Value() / DataGridreport2.Rows(1).Cells(j).Value() <= 240 Then
                DataGridreport2.Rows(12).Cells(j).Value() = WaterP(dataGridModes.Rows(25).Cells(j).Value() / DataGridreport2.Rows(0).Cells(j).Value(), NumericUpDown1.Value) * DataGridreport2.Rows(0).Cells(j).Value() + WaterP(dataGridModes.Rows(28).Cells(j).Value() / DataGridreport2.Rows(1).Cells(j).Value(), NumericUpDown1.Value) * DataGridreport2.Rows(1).Cells(j).Value()
            Else
                DataGridreport2.Rows(12).Cells(j).Value() = WaterP(dataGridModes.Rows(25).Cells(j).Value() / DataGridreport2.Rows(0).Cells(j).Value(), NumericUpDown1.Value) * DataGridreport2.Rows(0).Cells(j).Value() + WaterP(dataGridModes.Rows(28).Cells(j).Value() / DataGridreport2.Rows(1).Cells(j).Value(), NumericUpDown1.Value) * DataGridreport2.Rows(1).Cells(j).Value()
                DataGridreport2.Rows(12).Cells(j).ToolTipText = "Проверьте состав оборудования, расчет воды не верен."
                DataGridreport2.Rows(12).Cells(j).Style.BackColor = Color.Pink
            End If
            'Заполняем данные отклонений
            DataGridreport2.Rows(4).Cells(j).Value() = DataGridreport2.Rows(2).Cells(j).Value() - DataGridreport2.Rows(3).Cells(j).Value()
            DataGridreport2.Rows(7).Cells(j).Value() = DataGridreport2.Rows(5).Cells(j).Value() - DataGridreport2.Rows(6).Cells(j).Value()
            ' Добавлено 09122016
            DataGridreport2.Rows(15).Cells(j).Value() = System.Math.Round(System.Math.Abs(DataGridreport2.Rows(2).Cells(j).Value() - DataGridreport2.Rows(3).Cells(j).Value()), 1)
            DataGridreport2.Rows(16).Cells(j).Value() = System.Math.Round(System.Math.Abs(DataGridreport2.Rows(5).Cells(j).Value() - DataGridreport2.Rows(6).Cells(j).Value()), 1)
            ' Добавлено 09122016
            DataGridreport2.Rows(10).Cells(j).Value() = DataGridreport2.Rows(2).Cells(j).Value() - DataGridreport2.Rows(3).Cells(j).Value()
            DataGridreport2.Rows(13).Cells(j).Value() = DataGridreport2.Rows(5).Cells(j).Value() - DataGridreport2.Rows(6).Cells(j).Value()
            'Заполняем данные Итога
            DataGridreport2.Rows(2).Cells(0).Value() += DataGridreport2.Rows(2).Cells(j).Value()
            DataGridreport2.Rows(3).Cells(0).Value() += DataGridreport2.Rows(3).Cells(j).Value()
            DataGridreport2.Rows(4).Cells(0).Value() += DataGridreport2.Rows(4).Cells(j).Value()
            DataGridreport2.Rows(5).Cells(0).Value() += DataGridreport2.Rows(5).Cells(j).Value()
            DataGridreport2.Rows(6).Cells(0).Value() += DataGridreport2.Rows(6).Cells(j).Value()
            DataGridreport2.Rows(7).Cells(0).Value() += DataGridreport2.Rows(7).Cells(j).Value()
            DataGridreport2.Rows(8).Cells(0).Value() += DataGridreport2.Rows(8).Cells(j).Value() / 24
            DataGridreport2.Rows(9).Cells(0).Value() += DataGridreport2.Rows(9).Cells(j).Value() / 24

            DataGridreport2.Rows(11).Cells(0).Value() += DataGridreport2.Rows(11).Cells(j).Value() / 24
            DataGridreport2.Rows(12).Cells(0).Value() += DataGridreport2.Rows(12).Cells(j).Value() / 24


            ' Добавлено 09122016
            DataGridreport2.Rows(15).Cells(0).Value() += DataGridreport2.Rows(15).Cells(j).Value()
            DataGridreport2.Rows(16).Cells(0).Value() += DataGridreport2.Rows(16).Cells(j).Value()
            ' Добавлено 09122016
        Next
        DataGridreport2.Rows(10).Cells(0).Value() = DataGridreport2.Rows(8).Cells(0).Value() - DataGridreport2.Rows(9).Cells(0).Value()
        DataGridreport2.Rows(13).Cells(0).Value() = DataGridreport2.Rows(11).Cells(0).Value() - DataGridreport2.Rows(12).Cells(0).Value()

        
        DataGridreport2.Visible = True
        DataGridreport2.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders

        TextBox1.Text = Format(DataGridreport2.Rows(2).Cells(0).Value, "00.0")
        TextBox3.Text = Format(DataGridreport2.Rows(3).Cells(0).Value, "00.0")
        TextBox2.Text = Format(DataGridreport2.Rows(4).Cells(0).Value, "00.0")

        TextBox4.Text = Format(DataGridreport2.Rows(8).Cells(0).Value, "00.0")
        TextBox6.Text = Format(DataGridreport2.Rows(9).Cells(0).Value, "00.0")
        TextBox5.Text = Format(DataGridreport2.Rows(10).Cells(0).Value, "00.0")

        TextBox7.Text = Format(DataGridreport2.Rows(5).Cells(0).Value, "00.0")
        TextBox9.Text = Format(DataGridreport2.Rows(6).Cells(0).Value, "00.0")
        TextBox8.Text = Format(DataGridreport2.Rows(7).Cells(0).Value, "00.0")

        TextBox10.Text = Format(DataGridreport2.Rows(11).Cells(0).Value, "00.0")
        TextBox12.Text = Format(DataGridreport2.Rows(12).Cells(0).Value, "00.0")
        TextBox11.Text = Format(DataGridreport2.Rows(13).Cells(0).Value, "00.0")

        TabControl1.SelectedTab = TabPage6
        Button1.Enabled = True
    End Sub

    Private Sub DataGridreport2_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridreport2.CellEndEdit
        If e.RowIndex = 0 Then
            Tini.SetSection("Config") ' Задаем ключевое поле для ini заполняем кол-во ген
            Tini.SaveValue("G220_H" + (e.ColumnIndex).ToString, DataGridreport2.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString)
        End If
        If e.RowIndex = 1 Then
            Tini.SetSection("Config") ' Задаем ключевое поле для ini заполняем кол-во ген
            Tini.SaveValue("G500_H" + (e.ColumnIndex).ToString, DataGridreport2.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString)
        End If
    End Sub

    Private Sub X_Click(sender As Object, e As EventArgs) Handles X.Click
        If DataGridreport2.RowCount > 1 And DataGridreport2.ColumnCount >= 24 Then
            Tini.SetSection("Config") ' Задаем ключевое поле для ini заполняем кол-во ген
            For j = 1 To 24
                Tini.SaveValue("G220_H" & j, "")
                Tini.SaveValue("G500_H" & j, "")
                DataGridreport2.Rows(0).Cells(j).Value = Nothing
                DataGridreport2.Rows(1).Cells(j).Value = Nothing
            Next
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If DataGridreport2.RowCount > 1 And DataGridreport2.ColumnCount >= 24 Then
            Tini.SetSection("Config") ' Задаем ключевое поле для ini заполняем кол-во ген
            For j = 1 To 24
                DataGridreport2.Rows(0).Cells(j).Value = System.Math.Max((System.Math.Round(CDbl(dataGridModes.Rows(37).Cells(j).Value) / 200)), (System.Math.Floor(CDbl(dataGridModes.Rows(37).Cells(j).Value) / 240) + 1))
                DataGridreport2.Rows(1).Cells(j).Value = System.Math.Max((System.Math.Round(CDbl(dataGridModes.Rows(40).Cells(j).Value) / 200)), (System.Math.Floor(CDbl(dataGridModes.Rows(40).Cells(j).Value) / 240) + 1))
                Tini.SaveValue("G220_H" & j, DataGridreport2.Rows(0).Cells(j).Value)
                Tini.SaveValue("G500_H" & j, DataGridreport2.Rows(1).Cells(j).Value)
            Next
        End If
    End Sub
End Class
