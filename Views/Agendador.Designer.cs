namespace AgendadorOperaCloud
{
    partial class Agendador
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Agendador));
            chk_ativo = new CheckBox();
            cmb_Tipo_agend = new ComboBox();
            label1 = new Label();
            tab_controle = new TabControl();
            tabPage1 = new TabPage();
            gbx_agendados = new GroupBox();
            btn_excluir = new Button();
            btn_salvarEdicao = new Button();
            btn_editar = new Button();
            btn_adicionar = new Button();
            dgv_agendados = new DataGridView();
            gbx_agendador = new GroupBox();
            cmb_resortAgenda = new ComboBox();
            label5 = new Label();
            btn_pasta = new Button();
            dtpk_ExecutarEm_hora = new DateTimePicker();
            dtpk_ExecutarEm_data = new DateTimePicker();
            label2 = new Label();
            label7 = new Label();
            txt_pasta = new TextBox();
            gbx_repetir = new GroupBox();
            label3 = new Label();
            gpb_dias = new GroupBox();
            chk_sabado = new CheckBox();
            chk_sexta = new CheckBox();
            chk_quinta = new CheckBox();
            chk_quarta = new CheckBox();
            chk_terca = new CheckBox();
            chk_segunda = new CheckBox();
            chk_domingo = new CheckBox();
            rdb_NaoRepetir = new RadioButton();
            rdb_intervalo = new RadioButton();
            rdb_TodosMeses = new RadioButton();
            rdb_DiasSemana = new RadioButton();
            dtpk_intervalo = new DateTimePicker();
            lbl_repetir = new Label();
            dtpk_DiasMeses = new NumericUpDown();
            tabPage2 = new TabPage();
            btn_pesquisarLog = new Button();
            dtp_DataFinalLog = new DateTimePicker();
            label8 = new Label();
            dtp_DataInicialLog = new DateTimePicker();
            label4 = new Label();
            btn_excluirlog = new Button();
            chk_LogsErros = new CheckBox();
            cmb_JobsLogs = new ComboBox();
            label6 = new Label();
            btn_visualizarlog = new Button();
            dgv_Logs = new DataGridView();
            tabPage3 = new TabPage();
            groupBox1 = new GroupBox();
            groupBox3 = new GroupBox();
            label13 = new Label();
            btn_serviceReiniciar = new Button();
            btn_serviceParar = new Button();
            btn_serviceIniciar = new Button();
            lbl_servicoStatus = new Label();
            label12 = new Label();
            lbl_servico = new Label();
            lbl_servicoPID = new Label();
            label10 = new Label();
            label9 = new Label();
            button1 = new Button();
            groupBox2 = new GroupBox();
            dgv_jobsExec = new DataGridView();
            timer1 = new System.Windows.Forms.Timer(components);
            tab_controle.SuspendLayout();
            tabPage1.SuspendLayout();
            gbx_agendados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_agendados).BeginInit();
            gbx_agendador.SuspendLayout();
            gbx_repetir.SuspendLayout();
            gpb_dias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtpk_DiasMeses).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_Logs).BeginInit();
            tabPage3.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_jobsExec).BeginInit();
            SuspendLayout();
            // 
            // chk_ativo
            // 
            chk_ativo.AutoSize = true;
            chk_ativo.Checked = true;
            chk_ativo.CheckState = CheckState.Checked;
            chk_ativo.Location = new Point(457, 35);
            chk_ativo.Name = "chk_ativo";
            chk_ativo.Size = new Size(54, 19);
            chk_ativo.TabIndex = 0;
            chk_ativo.Text = "Ativo";
            chk_ativo.UseVisualStyleBackColor = true;
            // 
            // cmb_Tipo_agend
            // 
            cmb_Tipo_agend.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmb_Tipo_agend.DropDownHeight = 200;
            cmb_Tipo_agend.DropDownWidth = 250;
            cmb_Tipo_agend.FormattingEnabled = true;
            cmb_Tipo_agend.IntegralHeight = false;
            cmb_Tipo_agend.Location = new Point(27, 33);
            cmb_Tipo_agend.MaxDropDownItems = 10;
            cmb_Tipo_agend.Name = "cmb_Tipo_agend";
            cmb_Tipo_agend.Size = new Size(183, 23);
            cmb_Tipo_agend.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 15);
            label1.Name = "label1";
            label1.Size = new Size(128, 15);
            label1.TabIndex = 2;
            label1.Text = "Tipo de Agendamento:";
            // 
            // tab_controle
            // 
            tab_controle.Controls.Add(tabPage1);
            tab_controle.Controls.Add(tabPage2);
            tab_controle.Controls.Add(tabPage3);
            tab_controle.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            tab_controle.Location = new Point(12, 12);
            tab_controle.Name = "tab_controle";
            tab_controle.SelectedIndex = 0;
            tab_controle.Size = new Size(562, 563);
            tab_controle.TabIndex = 3;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(gbx_agendados);
            tabPage1.Controls.Add(gbx_agendador);
            tabPage1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(554, 535);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "      Agendador      ";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // gbx_agendados
            // 
            gbx_agendados.Controls.Add(btn_excluir);
            gbx_agendados.Controls.Add(btn_salvarEdicao);
            gbx_agendados.Controls.Add(btn_editar);
            gbx_agendados.Controls.Add(btn_adicionar);
            gbx_agendados.Controls.Add(dgv_agendados);
            gbx_agendados.Location = new Point(12, 338);
            gbx_agendados.Name = "gbx_agendados";
            gbx_agendados.Size = new Size(529, 188);
            gbx_agendados.TabIndex = 18;
            gbx_agendados.TabStop = false;
            gbx_agendados.Text = "Agendados";
            // 
            // btn_excluir
            // 
            btn_excluir.Location = new Point(435, 156);
            btn_excluir.Name = "btn_excluir";
            btn_excluir.Size = new Size(75, 23);
            btn_excluir.TabIndex = 20;
            btn_excluir.Text = "Excluir";
            btn_excluir.UseVisualStyleBackColor = true;
            btn_excluir.Click += btn_excluir_Click;
            // 
            // btn_salvarEdicao
            // 
            btn_salvarEdicao.Location = new Point(240, 156);
            btn_salvarEdicao.Name = "btn_salvarEdicao";
            btn_salvarEdicao.Size = new Size(86, 23);
            btn_salvarEdicao.TabIndex = 32;
            btn_salvarEdicao.Text = "Salvar Edição";
            btn_salvarEdicao.UseVisualStyleBackColor = true;
            btn_salvarEdicao.Visible = false;
            btn_salvarEdicao.Click += btn_salvarEdicao_Click;
            // 
            // btn_editar
            // 
            btn_editar.Location = new Point(343, 156);
            btn_editar.Name = "btn_editar";
            btn_editar.Size = new Size(75, 23);
            btn_editar.TabIndex = 19;
            btn_editar.Text = "Editar";
            btn_editar.UseVisualStyleBackColor = true;
            btn_editar.Click += btn_editar_Click;
            // 
            // btn_adicionar
            // 
            btn_adicionar.Location = new Point(247, 156);
            btn_adicionar.Name = "btn_adicionar";
            btn_adicionar.Size = new Size(75, 23);
            btn_adicionar.TabIndex = 18;
            btn_adicionar.Text = "Adicionar";
            btn_adicionar.UseVisualStyleBackColor = true;
            btn_adicionar.Click += btn_adicionar_Click;
            // 
            // dgv_agendados
            // 
            dgv_agendados.AllowUserToAddRows = false;
            dgv_agendados.AllowUserToDeleteRows = false;
            dgv_agendados.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgv_agendados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgv_agendados.DefaultCellStyle = dataGridViewCellStyle2;
            dgv_agendados.EditMode = DataGridViewEditMode.EditOnKeystroke;
            dgv_agendados.Location = new Point(14, 23);
            dgv_agendados.MultiSelect = false;
            dgv_agendados.Name = "dgv_agendados";
            dgv_agendados.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgv_agendados.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgv_agendados.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            dgv_agendados.RowTemplate.Height = 25;
            dgv_agendados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_agendados.Size = new Size(501, 121);
            dgv_agendados.TabIndex = 17;
            // 
            // gbx_agendador
            // 
            gbx_agendador.Controls.Add(cmb_resortAgenda);
            gbx_agendador.Controls.Add(label5);
            gbx_agendador.Controls.Add(btn_pasta);
            gbx_agendador.Controls.Add(cmb_Tipo_agend);
            gbx_agendador.Controls.Add(dtpk_ExecutarEm_hora);
            gbx_agendador.Controls.Add(chk_ativo);
            gbx_agendador.Controls.Add(dtpk_ExecutarEm_data);
            gbx_agendador.Controls.Add(label2);
            gbx_agendador.Controls.Add(label7);
            gbx_agendador.Controls.Add(label1);
            gbx_agendador.Controls.Add(txt_pasta);
            gbx_agendador.Controls.Add(gbx_repetir);
            gbx_agendador.Location = new Point(12, 6);
            gbx_agendador.Name = "gbx_agendador";
            gbx_agendador.Size = new Size(529, 329);
            gbx_agendador.TabIndex = 16;
            gbx_agendador.TabStop = false;
            // 
            // cmb_resortAgenda
            // 
            cmb_resortAgenda.FormattingEnabled = true;
            cmb_resortAgenda.Items.AddRange(new object[] { "DCWB", "ECWB" });
            cmb_resortAgenda.Location = new Point(244, 33);
            cmb_resortAgenda.Name = "cmb_resortAgenda";
            cmb_resortAgenda.Size = new Size(183, 23);
            cmb_resortAgenda.TabIndex = 14;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(244, 15);
            label5.Name = "label5";
            label5.Size = new Size(43, 15);
            label5.TabIndex = 15;
            label5.Text = "Resort:";
            // 
            // btn_pasta
            // 
            btn_pasta.Location = new Point(445, 289);
            btn_pasta.Name = "btn_pasta";
            btn_pasta.Size = new Size(70, 25);
            btn_pasta.TabIndex = 21;
            btn_pasta.Text = "Selecionar";
            btn_pasta.UseVisualStyleBackColor = true;
            btn_pasta.Click += btn_pasta_Click;
            // 
            // dtpk_ExecutarEm_hora
            // 
            dtpk_ExecutarEm_hora.CustomFormat = "HH:mm";
            dtpk_ExecutarEm_hora.Format = DateTimePickerFormat.Custom;
            dtpk_ExecutarEm_hora.Location = new Point(154, 81);
            dtpk_ExecutarEm_hora.MinDate = new DateTime(2024, 3, 1, 0, 0, 0, 0);
            dtpk_ExecutarEm_hora.Name = "dtpk_ExecutarEm_hora";
            dtpk_ExecutarEm_hora.ShowUpDown = true;
            dtpk_ExecutarEm_hora.Size = new Size(56, 23);
            dtpk_ExecutarEm_hora.TabIndex = 24;
            dtpk_ExecutarEm_hora.Value = new DateTime(2024, 3, 15, 0, 0, 0, 0);
            // 
            // dtpk_ExecutarEm_data
            // 
            dtpk_ExecutarEm_data.CustomFormat = "dd/MM/yyyy";
            dtpk_ExecutarEm_data.Format = DateTimePickerFormat.Custom;
            dtpk_ExecutarEm_data.Location = new Point(27, 81);
            dtpk_ExecutarEm_data.MinDate = new DateTime(2024, 3, 1, 0, 0, 0, 0);
            dtpk_ExecutarEm_data.Name = "dtpk_ExecutarEm_data";
            dtpk_ExecutarEm_data.Size = new Size(121, 23);
            dtpk_ExecutarEm_data.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 65);
            label2.Name = "label2";
            label2.Size = new Size(75, 15);
            label2.TabIndex = 4;
            label2.Text = "Executar em:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(14, 275);
            label7.Name = "label7";
            label7.Size = new Size(173, 15);
            label7.TabIndex = 15;
            label7.Text = "Pasta do arquivo de integração:";
            // 
            // txt_pasta
            // 
            txt_pasta.Location = new Point(14, 291);
            txt_pasta.Name = "txt_pasta";
            txt_pasta.ReadOnly = true;
            txt_pasta.Size = new Size(425, 23);
            txt_pasta.TabIndex = 14;
            // 
            // gbx_repetir
            // 
            gbx_repetir.Controls.Add(label3);
            gbx_repetir.Controls.Add(gpb_dias);
            gbx_repetir.Controls.Add(rdb_NaoRepetir);
            gbx_repetir.Controls.Add(rdb_intervalo);
            gbx_repetir.Controls.Add(rdb_TodosMeses);
            gbx_repetir.Controls.Add(rdb_DiasSemana);
            gbx_repetir.Controls.Add(dtpk_intervalo);
            gbx_repetir.Controls.Add(lbl_repetir);
            gbx_repetir.Controls.Add(dtpk_DiasMeses);
            gbx_repetir.Location = new Point(14, 113);
            gbx_repetir.Name = "gbx_repetir";
            gbx_repetir.Size = new Size(501, 156);
            gbx_repetir.TabIndex = 12;
            gbx_repetir.TabStop = false;
            gbx_repetir.Text = "Repetir a execução:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(416, 90);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 25;
            label3.Text = "dia(s).";
            // 
            // gpb_dias
            // 
            gpb_dias.Controls.Add(chk_sabado);
            gpb_dias.Controls.Add(chk_sexta);
            gpb_dias.Controls.Add(chk_quinta);
            gpb_dias.Controls.Add(chk_quarta);
            gpb_dias.Controls.Add(chk_terca);
            gpb_dias.Controls.Add(chk_segunda);
            gpb_dias.Controls.Add(chk_domingo);
            gpb_dias.Location = new Point(3, 42);
            gpb_dias.Name = "gpb_dias";
            gpb_dias.Size = new Size(494, 37);
            gpb_dias.TabIndex = 31;
            gpb_dias.TabStop = false;
            // 
            // chk_sabado
            // 
            chk_sabado.AutoSize = true;
            chk_sabado.Location = new Point(351, 12);
            chk_sabado.Name = "chk_sabado";
            chk_sabado.Size = new Size(65, 19);
            chk_sabado.TabIndex = 6;
            chk_sabado.Text = "Sábado";
            chk_sabado.UseVisualStyleBackColor = true;
            // 
            // chk_sexta
            // 
            chk_sexta.AutoSize = true;
            chk_sexta.Location = new Point(282, 12);
            chk_sexta.Name = "chk_sexta";
            chk_sexta.Size = new Size(65, 19);
            chk_sexta.TabIndex = 5;
            chk_sexta.Text = "6º Feira";
            chk_sexta.UseVisualStyleBackColor = true;
            // 
            // chk_quinta
            // 
            chk_quinta.AutoSize = true;
            chk_quinta.Location = new Point(214, 12);
            chk_quinta.Name = "chk_quinta";
            chk_quinta.Size = new Size(65, 19);
            chk_quinta.TabIndex = 4;
            chk_quinta.Text = "5º Feira";
            chk_quinta.UseVisualStyleBackColor = true;
            // 
            // chk_quarta
            // 
            chk_quarta.AutoSize = true;
            chk_quarta.Location = new Point(146, 12);
            chk_quarta.Name = "chk_quarta";
            chk_quarta.Size = new Size(65, 19);
            chk_quarta.TabIndex = 3;
            chk_quarta.Text = "4º Feira";
            chk_quarta.UseVisualStyleBackColor = true;
            // 
            // chk_terca
            // 
            chk_terca.AutoSize = true;
            chk_terca.Location = new Point(79, 13);
            chk_terca.Name = "chk_terca";
            chk_terca.Size = new Size(65, 19);
            chk_terca.TabIndex = 2;
            chk_terca.Text = "3º Feira";
            chk_terca.UseVisualStyleBackColor = true;
            // 
            // chk_segunda
            // 
            chk_segunda.AutoSize = true;
            chk_segunda.Location = new Point(13, 13);
            chk_segunda.Name = "chk_segunda";
            chk_segunda.Size = new Size(65, 19);
            chk_segunda.TabIndex = 1;
            chk_segunda.Text = "2º Feira";
            chk_segunda.UseVisualStyleBackColor = true;
            // 
            // chk_domingo
            // 
            chk_domingo.AutoSize = true;
            chk_domingo.Location = new Point(416, 11);
            chk_domingo.Name = "chk_domingo";
            chk_domingo.Size = new Size(76, 19);
            chk_domingo.TabIndex = 0;
            chk_domingo.Text = "Domingo";
            chk_domingo.UseVisualStyleBackColor = true;
            // 
            // rdb_NaoRepetir
            // 
            rdb_NaoRepetir.AutoSize = true;
            rdb_NaoRepetir.Checked = true;
            rdb_NaoRepetir.Location = new Point(411, 13);
            rdb_NaoRepetir.Name = "rdb_NaoRepetir";
            rdb_NaoRepetir.Size = new Size(84, 19);
            rdb_NaoRepetir.TabIndex = 30;
            rdb_NaoRepetir.TabStop = true;
            rdb_NaoRepetir.Tag = "0";
            rdb_NaoRepetir.Text = "Não repetir";
            rdb_NaoRepetir.UseVisualStyleBackColor = true;
            rdb_NaoRepetir.CheckedChanged += radioButton_CheckedChanged;
            // 
            // rdb_intervalo
            // 
            rdb_intervalo.AutoSize = true;
            rdb_intervalo.Location = new Point(16, 122);
            rdb_intervalo.Name = "rdb_intervalo";
            rdb_intervalo.Size = new Size(194, 19);
            rdb_intervalo.TabIndex = 29;
            rdb_intervalo.Tag = "3";
            rdb_intervalo.Text = "Diariamente, à cada intervalo de";
            rdb_intervalo.UseVisualStyleBackColor = true;
            rdb_intervalo.CheckedChanged += radioButton_CheckedChanged;
            // 
            // rdb_TodosMeses
            // 
            rdb_TodosMeses.AutoSize = true;
            rdb_TodosMeses.Location = new Point(16, 88);
            rdb_TodosMeses.Name = "rdb_TodosMeses";
            rdb_TodosMeses.Size = new Size(349, 19);
            rdb_TodosMeses.TabIndex = 28;
            rdb_TodosMeses.Tag = "2";
            rdb_TodosMeses.Text = "Repetir a execução todos os mêses no mesmo horário, a cada";
            rdb_TodosMeses.UseVisualStyleBackColor = true;
            rdb_TodosMeses.CheckedChanged += radioButton_CheckedChanged;
            // 
            // rdb_DiasSemana
            // 
            rdb_DiasSemana.AutoSize = true;
            rdb_DiasSemana.Location = new Point(16, 24);
            rdb_DiasSemana.Name = "rdb_DiasSemana";
            rdb_DiasSemana.Size = new Size(211, 19);
            rdb_DiasSemana.TabIndex = 27;
            rdb_DiasSemana.Tag = "1";
            rdb_DiasSemana.Text = "Dias da semana no mesmo horário:";
            rdb_DiasSemana.UseVisualStyleBackColor = true;
            rdb_DiasSemana.CheckedChanged += radioButton_CheckedChanged;
            // 
            // dtpk_intervalo
            // 
            dtpk_intervalo.CustomFormat = "HH:mm";
            dtpk_intervalo.Format = DateTimePickerFormat.Custom;
            dtpk_intervalo.Location = new Point(213, 120);
            dtpk_intervalo.MinDate = new DateTime(2024, 3, 1, 0, 0, 0, 0);
            dtpk_intervalo.Name = "dtpk_intervalo";
            dtpk_intervalo.ShowUpDown = true;
            dtpk_intervalo.Size = new Size(52, 23);
            dtpk_intervalo.TabIndex = 6;
            dtpk_intervalo.Value = new DateTime(2024, 3, 15, 0, 0, 0, 0);
            // 
            // lbl_repetir
            // 
            lbl_repetir.AutoSize = true;
            lbl_repetir.Location = new Point(271, 124);
            lbl_repetir.Name = "lbl_repetir";
            lbl_repetir.Size = new Size(103, 15);
            lbl_repetir.TabIndex = 7;
            lbl_repetir.Text = "horas ou minutos.";
            // 
            // dtpk_DiasMeses
            // 
            dtpk_DiasMeses.Location = new Point(369, 87);
            dtpk_DiasMeses.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
            dtpk_DiasMeses.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            dtpk_DiasMeses.Name = "dtpk_DiasMeses";
            dtpk_DiasMeses.Size = new Size(41, 23);
            dtpk_DiasMeses.TabIndex = 26;
            dtpk_DiasMeses.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(btn_pesquisarLog);
            tabPage2.Controls.Add(dtp_DataFinalLog);
            tabPage2.Controls.Add(label8);
            tabPage2.Controls.Add(dtp_DataInicialLog);
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(btn_excluirlog);
            tabPage2.Controls.Add(chk_LogsErros);
            tabPage2.Controls.Add(cmb_JobsLogs);
            tabPage2.Controls.Add(label6);
            tabPage2.Controls.Add(btn_visualizarlog);
            tabPage2.Controls.Add(dgv_Logs);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(554, 535);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "  Controle de Logs  ";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // btn_pesquisarLog
            // 
            btn_pesquisarLog.Location = new Point(466, 35);
            btn_pesquisarLog.Name = "btn_pesquisarLog";
            btn_pesquisarLog.Size = new Size(69, 23);
            btn_pesquisarLog.TabIndex = 28;
            btn_pesquisarLog.Text = "Pesquisar";
            btn_pesquisarLog.UseVisualStyleBackColor = true;
            btn_pesquisarLog.Click += btn_pesquisarLog_Click;
            // 
            // dtp_DataFinalLog
            // 
            dtp_DataFinalLog.CustomFormat = "dd/MM/yyyy";
            dtp_DataFinalLog.Format = DateTimePickerFormat.Custom;
            dtp_DataFinalLog.Location = new Point(356, 35);
            dtp_DataFinalLog.MinDate = new DateTime(2024, 3, 1, 0, 0, 0, 0);
            dtp_DataFinalLog.Name = "dtp_DataFinalLog";
            dtp_DataFinalLog.Size = new Size(104, 23);
            dtp_DataFinalLog.TabIndex = 26;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(356, 17);
            label8.Name = "label8";
            label8.Size = new Size(64, 15);
            label8.TabIndex = 27;
            label8.Text = "Data Final:";
            // 
            // dtp_DataInicialLog
            // 
            dtp_DataInicialLog.CustomFormat = "dd/MM/yyyy";
            dtp_DataInicialLog.Format = DateTimePickerFormat.Custom;
            dtp_DataInicialLog.Location = new Point(246, 35);
            dtp_DataInicialLog.MinDate = new DateTime(2024, 3, 1, 0, 0, 0, 0);
            dtp_DataInicialLog.Name = "dtp_DataInicialLog";
            dtp_DataInicialLog.Size = new Size(104, 23);
            dtp_DataInicialLog.TabIndex = 24;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(246, 17);
            label4.Name = "label4";
            label4.Size = new Size(71, 15);
            label4.TabIndex = 25;
            label4.Text = "Data Inicial:";
            // 
            // btn_excluirlog
            // 
            btn_excluirlog.Location = new Point(423, 495);
            btn_excluirlog.Name = "btn_excluirlog";
            btn_excluirlog.Size = new Size(112, 23);
            btn_excluirlog.TabIndex = 23;
            btn_excluirlog.Text = "Excluir Log";
            btn_excluirlog.UseVisualStyleBackColor = true;
            btn_excluirlog.Click += btn_excluirlog_Click;
            // 
            // chk_LogsErros
            // 
            chk_LogsErros.AutoSize = true;
            chk_LogsErros.Location = new Point(432, 73);
            chk_LogsErros.Name = "chk_LogsErros";
            chk_LogsErros.Size = new Size(109, 19);
            chk_LogsErros.TabIndex = 22;
            chk_LogsErros.Text = "Logs com Erros";
            chk_LogsErros.UseVisualStyleBackColor = true;
            // 
            // cmb_JobsLogs
            // 
            cmb_JobsLogs.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmb_JobsLogs.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmb_JobsLogs.DropDownHeight = 400;
            cmb_JobsLogs.DropDownWidth = 350;
            cmb_JobsLogs.FormattingEnabled = true;
            cmb_JobsLogs.IntegralHeight = false;
            cmb_JobsLogs.Location = new Point(19, 35);
            cmb_JobsLogs.Name = "cmb_JobsLogs";
            cmb_JobsLogs.Size = new Size(221, 23);
            cmb_JobsLogs.TabIndex = 20;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(19, 17);
            label6.Name = "label6";
            label6.Size = new Size(96, 15);
            label6.TabIndex = 21;
            label6.Text = "Selecione o Job:";
            // 
            // btn_visualizarlog
            // 
            btn_visualizarlog.Location = new Point(294, 495);
            btn_visualizarlog.Name = "btn_visualizarlog";
            btn_visualizarlog.Size = new Size(112, 23);
            btn_visualizarlog.TabIndex = 19;
            btn_visualizarlog.Text = "Visualizar";
            btn_visualizarlog.UseVisualStyleBackColor = true;
            btn_visualizarlog.Click += btn_visualizarlog_Click;
            // 
            // dgv_Logs
            // 
            dgv_Logs.AllowUserToAddRows = false;
            dgv_Logs.AllowUserToDeleteRows = false;
            dgv_Logs.AllowUserToOrderColumns = true;
            dgv_Logs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Logs.Location = new Point(19, 101);
            dgv_Logs.MultiSelect = false;
            dgv_Logs.Name = "dgv_Logs";
            dgv_Logs.ReadOnly = true;
            dgv_Logs.RowTemplate.Height = 25;
            dgv_Logs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_Logs.Size = new Size(516, 379);
            dgv_Logs.TabIndex = 18;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(groupBox1);
            tabPage3.Controls.Add(button1);
            tabPage3.Controls.Add(groupBox2);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(554, 535);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "  Serviço  ";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(groupBox3);
            groupBox1.Controls.Add(lbl_servicoStatus);
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(lbl_servico);
            groupBox1.Controls.Add(lbl_servicoPID);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(label9);
            groupBox1.Location = new Point(11, 14);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(526, 93);
            groupBox1.TabIndex = 17;
            groupBox1.TabStop = false;
            groupBox1.Text = "Serviços";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label13);
            groupBox3.Controls.Add(btn_serviceReiniciar);
            groupBox3.Controls.Add(btn_serviceParar);
            groupBox3.Controls.Add(btn_serviceIniciar);
            groupBox3.Location = new Point(252, 19);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(265, 61);
            groupBox3.TabIndex = 26;
            groupBox3.TabStop = false;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(107, 0);
            label13.Name = "label13";
            label13.Size = new Size(40, 15);
            label13.TabIndex = 25;
            label13.Text = "Ações";
            // 
            // btn_serviceReiniciar
            // 
            btn_serviceReiniciar.Location = new Point(97, 24);
            btn_serviceReiniciar.Name = "btn_serviceReiniciar";
            btn_serviceReiniciar.Size = new Size(75, 23);
            btn_serviceReiniciar.TabIndex = 20;
            btn_serviceReiniciar.Text = "Reiniciar";
            btn_serviceReiniciar.UseVisualStyleBackColor = true;
            btn_serviceReiniciar.Click += btn_serviceReiniciar_Click;
            // 
            // btn_serviceParar
            // 
            btn_serviceParar.Location = new Point(178, 24);
            btn_serviceParar.Name = "btn_serviceParar";
            btn_serviceParar.Size = new Size(75, 23);
            btn_serviceParar.TabIndex = 19;
            btn_serviceParar.Text = "Parar";
            btn_serviceParar.UseVisualStyleBackColor = true;
            btn_serviceParar.Click += btn_serviceParar_Click;
            // 
            // btn_serviceIniciar
            // 
            btn_serviceIniciar.Location = new Point(16, 24);
            btn_serviceIniciar.Name = "btn_serviceIniciar";
            btn_serviceIniciar.Size = new Size(75, 23);
            btn_serviceIniciar.TabIndex = 18;
            btn_serviceIniciar.Text = "Iniciar";
            btn_serviceIniciar.UseVisualStyleBackColor = true;
            btn_serviceIniciar.Click += btn_serviceIniciar_Click;
            // 
            // lbl_servicoStatus
            // 
            lbl_servicoStatus.AutoSize = true;
            lbl_servicoStatus.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_servicoStatus.Location = new Point(53, 51);
            lbl_servicoStatus.Name = "lbl_servicoStatus";
            lbl_servicoStatus.Size = new Size(12, 15);
            lbl_servicoStatus.TabIndex = 24;
            lbl_servicoStatus.Text = "-";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(53, 29);
            label12.Name = "label12";
            label12.Size = new Size(42, 15);
            label12.TabIndex = 23;
            label12.Text = "Status";
            // 
            // lbl_servico
            // 
            lbl_servico.AutoSize = true;
            lbl_servico.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_servico.Location = new Point(120, 51);
            lbl_servico.Name = "lbl_servico";
            lbl_servico.Size = new Size(12, 15);
            lbl_servico.TabIndex = 22;
            lbl_servico.Text = "-";
            // 
            // lbl_servicoPID
            // 
            lbl_servicoPID.AutoSize = true;
            lbl_servicoPID.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_servicoPID.Location = new Point(6, 51);
            lbl_servicoPID.Name = "lbl_servicoPID";
            lbl_servicoPID.Size = new Size(12, 15);
            lbl_servicoPID.TabIndex = 21;
            lbl_servicoPID.Text = "-";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(6, 29);
            label10.Name = "label10";
            label10.Size = new Size(27, 15);
            label10.TabIndex = 17;
            label10.Text = "PID";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(120, 29);
            label9.Name = "label9";
            label9.Size = new Size(49, 15);
            label9.TabIndex = 16;
            label9.Text = "Serviço";
            // 
            // button1
            // 
            button1.Location = new Point(453, 109);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 5;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Visible = false;
            button1.Click += button1_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgv_jobsExec);
            groupBox2.Location = new Point(12, 126);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(529, 395);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Jobs sendo executados neste momento";
            // 
            // dgv_jobsExec
            // 
            dgv_jobsExec.AllowUserToAddRows = false;
            dgv_jobsExec.AllowUserToDeleteRows = false;
            dgv_jobsExec.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_jobsExec.Location = new Point(14, 27);
            dgv_jobsExec.MultiSelect = false;
            dgv_jobsExec.Name = "dgv_jobsExec";
            dgv_jobsExec.ReadOnly = true;
            dgv_jobsExec.RowTemplate.Height = 25;
            dgv_jobsExec.Size = new Size(502, 353);
            dgv_jobsExec.TabIndex = 0;
            // 
            // timer1
            // 
            timer1.Interval = 3000;
            timer1.Tick += timer1_Tick;
            // 
            // Agendador
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(585, 587);
            Controls.Add(tab_controle);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Agendador";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "     Deville Agendador Opera Cloud";
            Load += Agendador_Load;
            tab_controle.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            gbx_agendados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_agendados).EndInit();
            gbx_agendador.ResumeLayout(false);
            gbx_agendador.PerformLayout();
            gbx_repetir.ResumeLayout(false);
            gbx_repetir.PerformLayout();
            gpb_dias.ResumeLayout(false);
            gpb_dias.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtpk_DiasMeses).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_Logs).EndInit();
            tabPage3.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_jobsExec).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private CheckBox chk_ativo;
        private ComboBox cmb_Tipo_agend;
        private Label label1;
        private TabControl tab_controle;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private DateTimePicker dtpk_ExecutarEm_data;
        private Label label2;
        private Label lbl_repetir;
        private DateTimePicker dtpk_intervalo;
        private GroupBox gbx_repetir;
        private CheckBox chk_domingo;
        private CheckBox chk_sabado;
        private CheckBox chk_sexta;
        private CheckBox chk_quinta;
        private CheckBox chk_quarta;
        private CheckBox chk_terca;
        private CheckBox chk_segunda;
        private ComboBox cmb_resortAgenda;
        private Label label5;
        private DataGridView dgv_agendados;
        private GroupBox gbx_agendador;
        private DataGridView dgv_Logs;
        private GroupBox gbx_agendados;
        private Button btn_excluir;
        private Button btn_editar;
        private Button btn_adicionar;
        private ComboBox cmb_JobsLogs;
        private Label label6;
        private Button btn_visualizarlog;
        private CheckBox chk_LogsErros;
        private TabPage tabPage3;
        private Label label7;
        private TextBox txt_pasta;
        private Button btn_pasta;
        private DateTimePicker dtpk_ExecutarEm_hora;
        private NumericUpDown dtpk_DiasMeses;
        private RadioButton rdb_intervalo;
        private RadioButton rdb_TodosMeses;
        private RadioButton rdb_DiasSemana;
        private RadioButton rdb_NaoRepetir;
        private GroupBox gpb_dias;
        private Button btn_salvarEdicao;
        private Label label3;
        private Button btn_excluirlog;
        private DateTimePicker dtp_DataFinalLog;
        private Label label8;
        private DateTimePicker dtp_DataInicialLog;
        private Label label4;
        private Button btn_pesquisarLog;
        private GroupBox groupBox2;
        private Button button1;
        private GroupBox groupBox1;
        private Label label9;
        private Button btn_serviceReiniciar;
        private Button btn_serviceParar;
        private Button btn_serviceIniciar;
        private Label label10;
        private Label lbl_servicoStatus;
        private Label label12;
        private Label lbl_servico;
        private Label lbl_servicoPID;
        private GroupBox groupBox3;
        private Label label13;
        private DataGridView dgv_jobsExec;
        private System.Windows.Forms.Timer timer1;
    }
}