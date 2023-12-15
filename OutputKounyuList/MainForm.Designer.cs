namespace OutputKounyuList
{
	partial class MainForm
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.txtBuhinFile = new System.Windows.Forms.TextBox();
            this.btnCreateFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtKounyuFileOutputFolder = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbBuhinFile = new System.Windows.Forms.ComboBox();
            this.lvTotal = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnUpdateTehaiZumi = new System.Windows.Forms.Button();
            this.btnGetBuhinList = new System.Windows.Forms.Button();
            this.btnClearBuhinList = new System.Windows.Forms.Button();
            this.btnExecBuhinFile = new System.Windows.Forms.Button();
            this.btnFileBuhin = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnFolder = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblCompany = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolVersion = new System.Windows.Forms.ToolStripSplitButton();
            this.toolVersionHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnExecTehaiDaityo = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnFileTehaiDaityo = new System.Windows.Forms.Button();
            this.txtTehaiDaityo = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.btnSetProduction = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.chkCommentOnOff = new System.Windows.Forms.CheckBox();
            this.lstPDF = new System.Windows.Forms.ListBox();
            this.txtTotalSum = new System.Windows.Forms.TextBox();
            this.btnClearPDF = new System.Windows.Forms.Button();
            this.txtCreateName = new System.Windows.Forms.TextBox();
            this.txtCreateDate = new System.Windows.Forms.TextBox();
            this.txtIraiSaki = new System.Windows.Forms.TextBox();
            this.txtBiko = new System.Windows.Forms.TextBox();
            this.txtMitumoriNumber = new System.Windows.Forms.TextBox();
            this.txtKounyuName = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtProductionName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtProductionNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBuhinFile
            // 
            this.txtBuhinFile.AllowDrop = true;
            this.txtBuhinFile.Location = new System.Drawing.Point(220, 20);
            this.txtBuhinFile.Name = "txtBuhinFile";
            this.txtBuhinFile.Size = new System.Drawing.Size(160, 31);
            this.txtBuhinFile.TabIndex = 2;
            this.txtBuhinFile.Tag = "0";
            this.txtBuhinFile.Visible = false;
            this.txtBuhinFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox_DragDrop);
            this.txtBuhinFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBox_DragEnter);
            // 
            // btnCreateFile
            // 
            this.btnCreateFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateFile.BackColor = System.Drawing.Color.GreenYellow;
            this.btnCreateFile.Location = new System.Drawing.Point(252, 370);
            this.btnCreateFile.Margin = new System.Windows.Forms.Padding(4);
            this.btnCreateFile.Name = "btnCreateFile";
            this.btnCreateFile.Size = new System.Drawing.Size(438, 47);
            this.btnCreateFile.TabIndex = 21;
            this.btnCreateFile.Text = "③台帳登録 ＆ 印刷 ＆ 購入依頼ファイル生成";
            this.btnCreateFile.UseVisualStyleBackColor = false;
            this.btnCreateFile.Click += new System.EventHandler(this.btnCreateFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "部品表ファイル";
            // 
            // txtKounyuFileOutputFolder
            // 
            this.txtKounyuFileOutputFolder.AllowDrop = true;
            this.txtKounyuFileOutputFolder.Location = new System.Drawing.Point(11, 54);
            this.txtKounyuFileOutputFolder.Name = "txtKounyuFileOutputFolder";
            this.txtKounyuFileOutputFolder.Size = new System.Drawing.Size(366, 31);
            this.txtKounyuFileOutputFolder.TabIndex = 1;
            this.txtKounyuFileOutputFolder.Tag = "1";
            this.txtKounyuFileOutputFolder.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox_DragDrop);
            this.txtKounyuFileOutputFolder.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBox_DragEnter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(250, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "購入依頼ファイル保存先フォルダ";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cmbBuhinFile);
            this.groupBox1.Controls.Add(this.lvTotal);
            this.groupBox1.Controls.Add(this.btnUpdateTehaiZumi);
            this.groupBox1.Controls.Add(this.btnGetBuhinList);
            this.groupBox1.Controls.Add(this.btnClearBuhinList);
            this.groupBox1.Controls.Add(this.btnExecBuhinFile);
            this.groupBox1.Controls.Add(this.btnFileBuhin);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtBuhinFile);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(478, 360);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "入力［部品表］";
            // 
            // cmbBuhinFile
            // 
            this.cmbBuhinFile.AllowDrop = true;
            this.cmbBuhinFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbBuhinFile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBuhinFile.FormattingEnabled = true;
            this.cmbBuhinFile.Location = new System.Drawing.Point(10, 53);
            this.cmbBuhinFile.Name = "cmbBuhinFile";
            this.cmbBuhinFile.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbBuhinFile.Size = new System.Drawing.Size(375, 32);
            this.cmbBuhinFile.TabIndex = 3;
            this.cmbBuhinFile.Tag = "0";
            this.cmbBuhinFile.SelectedIndexChanged += new System.EventHandler(this.cmbBuhinFile_SelectedIndexChanged);
            this.cmbBuhinFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox_DragDrop);
            this.cmbBuhinFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBox_DragEnter);
            // 
            // lvTotal
            // 
            this.lvTotal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvTotal.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvTotal.FullRowSelect = true;
            this.lvTotal.HideSelection = false;
            this.lvTotal.Location = new System.Drawing.Point(10, 139);
            this.lvTotal.Name = "lvTotal";
            this.lvTotal.Size = new System.Drawing.Size(461, 166);
            this.lvTotal.TabIndex = 6;
            this.lvTotal.UseCompatibleStateImageBehavior = false;
            this.lvTotal.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "購入先";
            this.columnHeader1.Width = 240;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "合計金額";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader2.Width = 150;
            // 
            // btnUpdateTehaiZumi
            // 
            this.btnUpdateTehaiZumi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateTehaiZumi.BackColor = System.Drawing.Color.GreenYellow;
            this.btnUpdateTehaiZumi.Location = new System.Drawing.Point(165, 311);
            this.btnUpdateTehaiZumi.Name = "btnUpdateTehaiZumi";
            this.btnUpdateTehaiZumi.Size = new System.Drawing.Size(307, 42);
            this.btnUpdateTehaiZumi.TabIndex = 8;
            this.btnUpdateTehaiZumi.Text = "④部品表の手配済数を更新する";
            this.btnUpdateTehaiZumi.UseVisualStyleBackColor = false;
            this.btnUpdateTehaiZumi.Click += new System.EventHandler(this.btnUpdateTehaiZumi_Click);
            // 
            // btnGetBuhinList
            // 
            this.btnGetBuhinList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetBuhinList.BackColor = System.Drawing.Color.GreenYellow;
            this.btnGetBuhinList.Location = new System.Drawing.Point(10, 91);
            this.btnGetBuhinList.Name = "btnGetBuhinList";
            this.btnGetBuhinList.Size = new System.Drawing.Size(461, 42);
            this.btnGetBuhinList.TabIndex = 5;
            this.btnGetBuhinList.Text = "②部品表から手配リストを取り込む";
            this.btnGetBuhinList.UseVisualStyleBackColor = false;
            this.btnGetBuhinList.Click += new System.EventHandler(this.btnGetBuhinList_Click);
            // 
            // btnClearBuhinList
            // 
            this.btnClearBuhinList.Location = new System.Drawing.Point(10, 322);
            this.btnClearBuhinList.Name = "btnClearBuhinList";
            this.btnClearBuhinList.Size = new System.Drawing.Size(118, 31);
            this.btnClearBuhinList.TabIndex = 7;
            this.btnClearBuhinList.Text = "クリア";
            this.btnClearBuhinList.UseVisualStyleBackColor = true;
            this.btnClearBuhinList.Click += new System.EventHandler(this.btnClearBuhinList_Click);
            // 
            // btnExecBuhinFile
            // 
            this.btnExecBuhinFile.BackColor = System.Drawing.Color.GreenYellow;
            this.btnExecBuhinFile.Location = new System.Drawing.Point(134, 20);
            this.btnExecBuhinFile.Name = "btnExecBuhinFile";
            this.btnExecBuhinFile.Size = new System.Drawing.Size(80, 31);
            this.btnExecBuhinFile.TabIndex = 1;
            this.btnExecBuhinFile.Text = "①起動";
            this.btnExecBuhinFile.UseVisualStyleBackColor = false;
            this.btnExecBuhinFile.Click += new System.EventHandler(this.btnExecBuhinFile_Click);
            // 
            // btnFileBuhin
            // 
            this.btnFileBuhin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFileBuhin.Location = new System.Drawing.Point(391, 54);
            this.btnFileBuhin.Name = "btnFileBuhin";
            this.btnFileBuhin.Size = new System.Drawing.Size(80, 31);
            this.btnFileBuhin.TabIndex = 4;
            this.btnFileBuhin.Text = "参照";
            this.btnFileBuhin.UseVisualStyleBackColor = true;
            this.btnFileBuhin.Click += new System.EventHandler(this.btnFileBuhin_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnFolder);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtKounyuFileOutputFolder);
            this.groupBox2.Location = new System.Drawing.Point(22, 484);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(469, 93);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "出力［購入依頼］";
            // 
            // btnFolder
            // 
            this.btnFolder.Location = new System.Drawing.Point(383, 54);
            this.btnFolder.Name = "btnFolder";
            this.btnFolder.Size = new System.Drawing.Size(80, 31);
            this.btnFolder.TabIndex = 2;
            this.btnFolder.Text = "参照";
            this.btnFolder.UseVisualStyleBackColor = true;
            this.btnFolder.Click += new System.EventHandler(this.btnFolder_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblCompany,
            this.toolVersion});
            this.statusStrip1.Location = new System.Drawing.Point(0, 684);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1204, 27);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = false;
            this.lblCompany.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblCompany.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(150, 22);
            this.lblCompany.Text = "Fujita Device Co.,Ltd.";
            // 
            // toolVersion
            // 
            this.toolVersion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolVersion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolVersionHistory});
            this.toolVersion.Image = ((System.Drawing.Image)(resources.GetObject("toolVersion.Image")));
            this.toolVersion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolVersion.Name = "toolVersion";
            this.toolVersion.Size = new System.Drawing.Size(71, 25);
            this.toolVersion.Text = "変更履歴";
            // 
            // toolVersionHistory
            // 
            this.toolVersionHistory.Name = "toolVersionHistory";
            this.toolVersionHistory.Size = new System.Drawing.Size(122, 22);
            this.toolVersionHistory.Text = "変更履歴";
            this.toolVersionHistory.Click += new System.EventHandler(this.toolVersionHistory_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.btnExecTehaiDaityo);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.btnFileTehaiDaityo);
            this.groupBox3.Controls.Add(this.txtTehaiDaityo);
            this.groupBox3.Location = new System.Drawing.Point(22, 378);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(468, 100);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "参照［手配台帳］";
            // 
            // btnExecTehaiDaityo
            // 
            this.btnExecTehaiDaityo.Location = new System.Drawing.Point(150, 20);
            this.btnExecTehaiDaityo.Name = "btnExecTehaiDaityo";
            this.btnExecTehaiDaityo.Size = new System.Drawing.Size(80, 31);
            this.btnExecTehaiDaityo.TabIndex = 1;
            this.btnExecTehaiDaityo.Text = "起動";
            this.btnExecTehaiDaityo.UseVisualStyleBackColor = false;
            this.btnExecTehaiDaityo.Click += new System.EventHandler(this.btnExecTehaiDaityo_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "手配台帳ファイル";
            // 
            // btnFileTehaiDaityo
            // 
            this.btnFileTehaiDaityo.Location = new System.Drawing.Point(382, 54);
            this.btnFileTehaiDaityo.Name = "btnFileTehaiDaityo";
            this.btnFileTehaiDaityo.Size = new System.Drawing.Size(80, 31);
            this.btnFileTehaiDaityo.TabIndex = 3;
            this.btnFileTehaiDaityo.Text = "参照";
            this.btnFileTehaiDaityo.UseVisualStyleBackColor = true;
            this.btnFileTehaiDaityo.Click += new System.EventHandler(this.btnFileTehaiDaityo_Click);
            // 
            // txtTehaiDaityo
            // 
            this.txtTehaiDaityo.AllowDrop = true;
            this.txtTehaiDaityo.Location = new System.Drawing.Point(10, 54);
            this.txtTehaiDaityo.Name = "txtTehaiDaityo";
            this.txtTehaiDaityo.Size = new System.Drawing.Size(366, 31);
            this.txtTehaiDaityo.TabIndex = 2;
            this.txtTehaiDaityo.Tag = "0";
            this.txtTehaiDaityo.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox_DragDrop);
            this.txtTehaiDaityo.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBox_DragEnter);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.BackColor = System.Drawing.Color.LightYellow;
            this.richTextBox1.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.richTextBox1.Location = new System.Drawing.Point(22, 583);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(469, 83);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgvProducts);
            this.groupBox4.Controls.Add(this.btnSetProduction);
            this.groupBox4.Controls.Add(this.btnSearch);
            this.groupBox4.Location = new System.Drawing.Point(496, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(696, 224);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "作番検索";
            // 
            // dgvProducts
            // 
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Location = new System.Drawing.Point(102, 30);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.RowTemplate.Height = 21;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.Size = new System.Drawing.Size(588, 188);
            this.dgvProducts.TabIndex = 1;
            // 
            // btnSetProduction
            // 
            this.btnSetProduction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnSetProduction.Location = new System.Drawing.Point(16, 183);
            this.btnSetProduction.Name = "btnSetProduction";
            this.btnSetProduction.Size = new System.Drawing.Size(80, 35);
            this.btnSetProduction.TabIndex = 2;
            this.btnSetProduction.Text = "vSETv";
            this.btnSetProduction.UseVisualStyleBackColor = false;
            this.btnSetProduction.Click += new System.EventHandler(this.btnSetProduction_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Cyan;
            this.btnSearch.Location = new System.Drawing.Point(16, 30);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(80, 55);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "検索";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.chkCommentOnOff);
            this.groupBox5.Controls.Add(this.lstPDF);
            this.groupBox5.Controls.Add(this.txtTotalSum);
            this.groupBox5.Controls.Add(this.btnClearPDF);
            this.groupBox5.Controls.Add(this.txtCreateName);
            this.groupBox5.Controls.Add(this.txtCreateDate);
            this.groupBox5.Controls.Add(this.txtIraiSaki);
            this.groupBox5.Controls.Add(this.txtBiko);
            this.groupBox5.Controls.Add(this.txtMitumoriNumber);
            this.groupBox5.Controls.Add(this.txtKounyuName);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.txtProductionName);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.txtProductionNumber);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.btnCreateFile);
            this.groupBox5.Location = new System.Drawing.Point(496, 242);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(696, 424);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "手配台帳への登録データ";
            // 
            // chkCommentOnOff
            // 
            this.chkCommentOnOff.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkCommentOnOff.Location = new System.Drawing.Point(101, 372);
            this.chkCommentOnOff.Name = "chkCommentOnOff";
            this.chkCommentOnOff.Size = new System.Drawing.Size(141, 46);
            this.chkCommentOnOff.TabIndex = 3;
            this.chkCommentOnOff.Text = "CommentOnOff";
            this.chkCommentOnOff.UseVisualStyleBackColor = true;
            this.chkCommentOnOff.CheckedChanged += new System.EventHandler(this.chkCommentOnOff_CheckedChanged);
            // 
            // lstPDF
            // 
            this.lstPDF.AllowDrop = true;
            this.lstPDF.FormattingEnabled = true;
            this.lstPDF.ItemHeight = 24;
            this.lstPDF.Location = new System.Drawing.Point(443, 252);
            this.lstPDF.Name = "lstPDF";
            this.lstPDF.Size = new System.Drawing.Size(247, 100);
            this.lstPDF.TabIndex = 20;
            this.lstPDF.Tag = "0";
            this.lstPDF.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox_DragDrop);
            this.lstPDF.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBox_DragEnter);
            // 
            // txtTotalSum
            // 
            this.txtTotalSum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalSum.BackColor = System.Drawing.Color.LightGray;
            this.txtTotalSum.Location = new System.Drawing.Point(524, 141);
            this.txtTotalSum.Name = "txtTotalSum";
            this.txtTotalSum.Size = new System.Drawing.Size(166, 31);
            this.txtTotalSum.TabIndex = 9;
            // 
            // btnClearPDF
            // 
            this.btnClearPDF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearPDF.Location = new System.Drawing.Point(610, 215);
            this.btnClearPDF.Name = "btnClearPDF";
            this.btnClearPDF.Size = new System.Drawing.Size(80, 31);
            this.btnClearPDF.TabIndex = 17;
            this.btnClearPDF.Text = "クリア";
            this.btnClearPDF.UseVisualStyleBackColor = true;
            this.btnClearPDF.Click += new System.EventHandler(this.btnClearPDF_Click);
            // 
            // txtCreateName
            // 
            this.txtCreateName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCreateName.BackColor = System.Drawing.Color.LightGray;
            this.txtCreateName.Location = new System.Drawing.Point(312, 215);
            this.txtCreateName.Name = "txtCreateName";
            this.txtCreateName.Size = new System.Drawing.Size(86, 31);
            this.txtCreateName.TabIndex = 15;
            // 
            // txtCreateDate
            // 
            this.txtCreateDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCreateDate.BackColor = System.Drawing.Color.LightGray;
            this.txtCreateDate.Location = new System.Drawing.Point(102, 215);
            this.txtCreateDate.Name = "txtCreateDate";
            this.txtCreateDate.Size = new System.Drawing.Size(140, 31);
            this.txtCreateDate.TabIndex = 13;
            // 
            // txtIraiSaki
            // 
            this.txtIraiSaki.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIraiSaki.BackColor = System.Drawing.Color.LightGray;
            this.txtIraiSaki.Location = new System.Drawing.Point(102, 141);
            this.txtIraiSaki.Name = "txtIraiSaki";
            this.txtIraiSaki.Size = new System.Drawing.Size(368, 31);
            this.txtIraiSaki.TabIndex = 7;
            // 
            // txtBiko
            // 
            this.txtBiko.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBiko.Location = new System.Drawing.Point(102, 252);
            this.txtBiko.Multiline = true;
            this.txtBiko.Name = "txtBiko";
            this.txtBiko.Size = new System.Drawing.Size(335, 111);
            this.txtBiko.TabIndex = 19;
            // 
            // txtMitumoriNumber
            // 
            this.txtMitumoriNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMitumoriNumber.Location = new System.Drawing.Point(102, 178);
            this.txtMitumoriNumber.Name = "txtMitumoriNumber";
            this.txtMitumoriNumber.Size = new System.Drawing.Size(588, 31);
            this.txtMitumoriNumber.TabIndex = 11;
            // 
            // txtKounyuName
            // 
            this.txtKounyuName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKounyuName.Location = new System.Drawing.Point(102, 104);
            this.txtKounyuName.Name = "txtKounyuName";
            this.txtKounyuName.Size = new System.Drawing.Size(588, 31);
            this.txtKounyuName.TabIndex = 5;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(443, 218);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(105, 24);
            this.label13.TabIndex = 16;
            this.label13.Text = "印刷するPDF";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(248, 218);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 24);
            this.label11.TabIndex = 14;
            this.label11.Text = "作成者";
            // 
            // txtProductionName
            // 
            this.txtProductionName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProductionName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtProductionName.Location = new System.Drawing.Point(102, 67);
            this.txtProductionName.Name = "txtProductionName";
            this.txtProductionName.Size = new System.Drawing.Size(588, 31);
            this.txtProductionName.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(38, 218);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 24);
            this.label10.TabIndex = 12;
            this.label10.Text = "作成日";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(476, 144);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 24);
            this.label8.TabIndex = 8;
            this.label8.Text = "金額";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(54, 255);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 24);
            this.label12.TabIndex = 18;
            this.label12.Text = "備考";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(38, 144);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 24);
            this.label7.TabIndex = 6;
            this.label7.Text = "依頼先";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(38, 181);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 24);
            this.label9.TabIndex = 10;
            this.label9.Text = "見積№";
            // 
            // txtProductionNumber
            // 
            this.txtProductionNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProductionNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtProductionNumber.Location = new System.Drawing.Point(102, 30);
            this.txtProductionNumber.Name = "txtProductionNumber";
            this.txtProductionNumber.Size = new System.Drawing.Size(588, 31);
            this.txtProductionNumber.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "購入品名";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 24);
            this.label5.TabIndex = 2;
            this.label5.Text = "作番名称";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(54, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 24);
            this.label6.TabIndex = 0;
            this.label6.Text = "作番";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1204, 711);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(880, 300);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtBuhinFile;
		private System.Windows.Forms.Button btnCreateFile;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtKounyuFileOutputFolder;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel lblCompany;
		private System.Windows.Forms.Button btnFileBuhin;
		private System.Windows.Forms.Button btnFolder;
		private System.Windows.Forms.Button btnExecBuhinFile;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnFileTehaiDaityo;
		private System.Windows.Forms.TextBox txtTehaiDaityo;
		private System.Windows.Forms.Button btnExecTehaiDaityo;
		private System.Windows.Forms.ListView lvTotal;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.Button btnGetBuhinList;
		private System.Windows.Forms.Button btnClearBuhinList;
		private System.Windows.Forms.Button btnUpdateTehaiZumi;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.ComboBox cmbBuhinFile;
		private System.Windows.Forms.ToolStripSplitButton toolVersion;
		private System.Windows.Forms.ToolStripMenuItem toolVersionHistory;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Button btnSetProduction;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ListBox lstPDF;
        private System.Windows.Forms.TextBox txtTotalSum;
        private System.Windows.Forms.Button btnClearPDF;
        private System.Windows.Forms.TextBox txtCreateName;
        private System.Windows.Forms.TextBox txtCreateDate;
        private System.Windows.Forms.TextBox txtIraiSaki;
        private System.Windows.Forms.TextBox txtBiko;
        private System.Windows.Forms.TextBox txtMitumoriNumber;
        private System.Windows.Forms.TextBox txtKounyuName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtProductionName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtProductionNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkCommentOnOff;
    }
}

