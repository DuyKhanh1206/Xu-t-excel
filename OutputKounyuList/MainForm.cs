using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using KaTool;
using System.Drawing.Printing;
using System.Diagnostics;

namespace OutputKounyuList
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            this.Text = AppData.getInstance().param.ApplicationName;
            lblCompany.Text = Application.CompanyName;
            toolVersion.Text = Application.ProductVersion;
        }

        #region Load/Closing
        /// <summary>
        /// Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            txtBuhinFile.Text = AppData.getInstance().param.BuhinListFile;
            txtKounyuFileOutputFolder.Text = AppData.getInstance().param.KounyuIraiFileSaveFolder;
            txtTehaiDaityo.Text = AppData.getInstance().param.TehaiDaityoFile;

            txtBuhinFile.Select(txtBuhinFile.Text.Length, 0);
            txtKounyuFileOutputFolder.Select(txtKounyuFileOutputFolder.Text.Length, 0);
            txtTehaiDaityo.Select(txtTehaiDaityo.Text.Length, 0);

            chkCommentOnOff.Checked = AppData.getInstance().param.chkStyleAddButton;

            for (int i = 0; i < AppData.getInstance().param.BuhinListFiles.Length; i++)
            {
                if (AppData.getInstance().param.BuhinListFiles[i] != "")
                {
                    cmbBuhinFile.Items.Add(AppData.getInstance().param.BuhinListFiles[i]);
                }
            }
            if (cmbBuhinFile.Items.Count == 0)
            {
                cmbBuhinFile.Items.Add(AppData.getInstance().param.BuhinListFile);
            }
            cmbBuhinFile.SelectedIndex = 0;

            //作成日
            txtCreateDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
            //作成者
            txtCreateName.Text = AppData.getInstance().param.Kounyu_CreateName;
        }
        /// <summary>
        /// Closing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            AppData.getInstance().param.BuhinListFile = txtBuhinFile.Text;
            AppData.getInstance().param.KounyuIraiFileSaveFolder = txtKounyuFileOutputFolder.Text;
            AppData.getInstance().param.TehaiDaityoFile = txtTehaiDaityo.Text;
            AppData.getInstance().param.chkStyleAddButton = chkCommentOnOff.Checked;
            for (int i = 0; i < cmbBuhinFile.Items.Count; i++)
                AppData.getInstance().param.BuhinListFiles[i] = cmbBuhinFile.Items[i].ToString();
            //作成者
            AppData.getInstance().param.Kounyu_CreateName = txtCreateName.Text;
        }
        #endregion

        #region ドラッグ＆ドロップ
        private void textBox_DragEnter(object sender, DragEventArgs e)
        {
            //ファイルがドラッグされている場合、カーソルを変更する
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }
        private void textBox_DragDrop(object sender, DragEventArgs e)
        {
            //ドロップされたファイルの一覧を取得
            string[] fileName = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (fileName.Length <= 0)
            {
                return;
            }
            // ドロップ先がTextBoxであるかチェック
            TextBox txtTarget = sender as TextBox;
            if (txtTarget != null)
            {
                int flg = int.Parse((string)txtTarget.Tag);
                if (flg == 0)
                {
                    if (File.Exists(fileName[0]) == false)
                    {
                        MessageBox.Show("ファイルではありません。");
                        return;
                    }
                }
                else
                {
                    if (Directory.Exists(fileName[0]) == false)
                    {
                        MessageBox.Show("フォルダではありません。");
                        return;
                    }
                }
                //TextBoxの内容をファイル名に変更
                txtTarget.Text = fileName[0];
                txtTarget.Select(txtTarget.Text.Length, 0);
            }

            ComboBox cmbTarget = sender as ComboBox;
            if (cmbTarget != null)
            {
                int flg = int.Parse((string)cmbTarget.Tag);
                if (flg == 0)
                {
                    if (File.Exists(fileName[0]) == false)
                    {
                        MessageBox.Show("ファイルではありません。");
                        return;
                    }
                }
                //
                ResetCmbBuhinListFiles(fileName[0]);
                txtBuhinFile.Text = cmbBuhinFile.Text;
                txtBuhinFile.Select(txtBuhinFile.Text.Length, 0);
            }

            ListBox lstTarget = sender as ListBox;
            if (lstTarget != null)
            {
                int flg = int.Parse((string)lstTarget.Tag);
                if (flg == 0)
                {
                    if (File.Exists(fileName[0]) == false)
                    {
                        MessageBox.Show("ファイルではありません。");
                        return;
                    }
                }
                lstTarget.Items.Add(fileName[0]);
            }
        }
        #endregion

        /// <summary>
        /// 部品手配リスト
        /// </summary>
        List<clsBuhinData> _clsBuhinDatas = new List<clsBuhinData>();

        #region 部品表から手配リストを取り込む　ボタン
        /// <summary>
        /// 部品表から手配リストを取り込む　ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetBuhinList_Click(object sender, EventArgs e)
        {
            if (File.Exists(txtBuhinFile.Text) == false)
            {
                MessageBox.Show("部品表ファイルが存在しません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool result;
            Cursor.Current = Cursors.WaitCursor;
            //部品表からリストを取得
            clsExcelReadBuhinList buhinList = new clsExcelReadBuhinList();
            result = buhinList.Load(txtBuhinFile.Text, ref _clsBuhinDatas);
            if (result == false)
            {
                lvTotal.Items.Clear();
                _clsBuhinDatas.Clear();
                Cursor.Current = Cursors.Default;
                MessageBox.Show(buhinList.ErrorMessage, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GC.Collect();
                return;
            }
            else if (_clsBuhinDatas.Count == 0)
            {
                lvTotal.Items.Clear();
                //手配数がなかった
                Cursor.Current = Cursors.Default;
                MessageBox.Show("手配数の入力がありませんでした。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                GC.Collect();
                return;
            }

            //購入先毎にソートする
            _clsBuhinDatas.Sort((a, b) =>
            {
                int ret = b.KounyuSaki.CompareTo(a.KounyuSaki);
                if (ret != 0)
                    return ret;
                if (a.RowNo > b.RowNo)
                    return 1;
                if (a.RowNo < b.RowNo)
                    return -1;
                return 0;
            });

            DisplaySumList();
            MessageBox.Show("部品表ファイルから、手配リストを取り込みました。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GC.Collect();
        }
        #endregion

        #region 部品表の手配済数を更新する　ボタン
        /// <summary>
        /// 部品表の手配済数を更新する　ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateTehaiZumi_Click(object sender, EventArgs e)
        {
            if (_clsBuhinDatas.Count <= 0)
            {
                MessageBox.Show("手配リストが取り込まれていません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool result;
            Cursor.Current = Cursors.WaitCursor;
            clsExcelReadBuhinList buhinList = new clsExcelReadBuhinList();
            result = buhinList.Save(txtBuhinFile.Text, _clsBuhinDatas);
            if (result == true)
            {
                lvTotal.Items.Clear();
                _clsBuhinDatas.Clear();
                Cursor.Current = Cursors.Default;
                MessageBox.Show("手配済数を更新しました。\nおよび、手配数をクリアしました。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(buhinList.ErrorMessage, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            GC.Collect();
        }
        #endregion

        #region 台帳登録 ＆ 印刷 ＆ 購入依頼ファイル生成　ボタン
        /// <summary>
        /// 購入依頼ファイルを生成する　ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateFile_Click(object sender, EventArgs e)
        {
            if (_clsBuhinDatas.Count <= 0)//data
            {
                MessageBox.Show("手配リストが取り込まれていません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);// data chưa đk nạp
                return;
            }

            if (Directory.Exists(txtKounyuFileOutputFolder.Text) == false)
            {
                MessageBox.Show("購入依頼ファイルを出力するフォルダが存在しません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error); // thư mục xuất ra tệp k tồn tại
                return;
            }
            if (txtProductionNumber.Text == "")
            {
                MessageBox.Show("作番が入力されていません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);// chưa nhập số sản phẩm
                return;
            }
            if (txtProductionName.Text == "")
            {
                MessageBox.Show("作番名称が入力されていません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);// chưa nhập tên sản phẩm
                return;
            }
            if (txtKounyuName.Text == "")
            {
                MessageBox.Show("購入品名が入力されていません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);//Tên sản phẩm đã mua chưa được nhập
                return;
            }
            if (txtIraiSaki.Text == "")
            {
                MessageBox.Show("依頼先が入力されていません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);//Đích yêu cầu chưa được nhập
                return;
            }
            if (txtTotalSum.Text == "")
            {
                MessageBox.Show("金額が入力されていません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);//Chưa nhập số tiền
                return;
            }
            if (txtMitumoriNumber.Text == "")
            {
                MessageBox.Show("見積№が入力されていません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);//Số báo giá chưa được nhập
                return;
            }
            if (txtCreateDate.Text == "")
            {
                MessageBox.Show("作成日が入力されていません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);// ngày chưa được nhập
                return;
            }
            if (txtCreateName.Text == "")
            {
                MessageBox.Show("作成者が入力されていません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);// tên ng mua chưa đk nhập
                return;
            }

            Cursor.Current = Cursors.WaitCursor;

            bool result = true;
            string kounyuNumber;

            //台帳登録＆印刷
            List<string> lstDatas = new List<string>();
            lstDatas.Add(txtProductionNumber.Text);
            lstDatas.Add(txtProductionName.Text);
            lstDatas.Add(txtKounyuName.Text);
            lstDatas.Add(txtIraiSaki.Text);
            lstDatas.Add(txtTotalSum.Text);
            lstDatas.Add(txtMitumoriNumber.Text);
            lstDatas.Add(txtCreateDate.Text);
            lstDatas.Add(txtCreateName.Text);
            lstDatas.Add(txtBiko.Text);
            clsExcelWriteDaicyo daicyo = new clsExcelWriteDaicyo();
            //台帳登録      viết vào sổ cái
            result = daicyo.Save(txtTehaiDaityo.Text, lstDatas, out kounyuNumber);
            if (result == true)
                //申請書印刷 in mẫu đơn
                result = daicyo.Print(txtTehaiDaityo.Text, lstDatas, kounyuNumber);
            Cursor.Current = Cursors.Default;
            if (result == true)
            {
                MessageBox.Show("台帳登録 と 印刷 が完了しました。\n　" + kounyuNumber + "\n次に、購入依頼ファイルの出力を開始します。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(daicyo.ErrorMessage, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Cursor.Current = Cursors.WaitCursor;

            string kounyuFile = kounyuNumber + ".xlsx";
            string kounyuFilePath = Path.Combine(txtKounyuFileOutputFolder.Text, kounyuFile);
            if (File.Exists(kounyuFilePath) == true)
            {
                DialogResult res = MessageBox.Show(kounyuFile + " ファイルは存在します。\n上書きしてよいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == System.Windows.Forms.DialogResult.No)
                    return;
            }

            //PDF印刷
            PrintPDF();

            //購入依頼ファイルの作成
            clsExcelWriteKounyuList kounyuList = new clsExcelWriteKounyuList();
            result = kounyuList.Save(kounyuFilePath, _clsBuhinDatas, chkCommentOnOff.Checked);
            Cursor.Current = Cursors.Default;
            if (result == true)
            {
                MessageBox.Show("購入依頼ファイルを出力しました。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(kounyuList.ErrorMessage, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            GC.Collect();
        }
        /// <summary>
        /// PDF出力
        /// </summary>
        private void PrintPDF()
        {
            for (int i = 0; i < lstPDF.Items.Count; i++)
            {
                ProcessStartInfo info = new ProcessStartInfo();
                info.Verb = "print";
                info.FileName = lstPDF.Items[i].ToString();
                info.CreateNoWindow = true;
                info.WindowStyle = ProcessWindowStyle.Hidden;

                Process p = new Process();
                p.StartInfo = info;
                p.Start();
            }
        }
        private void btnClearPDF_Click(object sender, EventArgs e)
        {
            lstPDF.Items.Clear();
        }

        #endregion

        #region 「参照」ボタン
        /// <summary>
        /// 部品表ファイルの　参照ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFileBuhin_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                string iniDir;
                iniDir = (txtBuhinFile.Text.Trim() != "") ? Path.GetDirectoryName(txtBuhinFile.Text) : "";
                if (Directory.Exists(iniDir) == true)
                    dlg.InitialDirectory = iniDir;
                DialogResult res = dlg.ShowDialog();
                if (res == System.Windows.Forms.DialogResult.OK)
                {
                    txtBuhinFile.Text = dlg.FileName;
                    ResetCmbBuhinListFiles(dlg.FileName);
                }
            }
        }
        /// <summary>
        /// 購入依頼ファイル出力フォルダ　参照ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dlg = new FolderBrowserDialog())
            {
                string iniDir;
                iniDir = txtKounyuFileOutputFolder.Text.Trim();
                if (Directory.Exists(iniDir) == true)
                    dlg.SelectedPath = iniDir;
                DialogResult res = dlg.ShowDialog();
                if (res == System.Windows.Forms.DialogResult.OK)
                    txtKounyuFileOutputFolder.Text = dlg.SelectedPath;
            }
        }
        /// <summary>
        /// 手配台帳ファイルの　参照ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFileTehaiDaityo_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                string iniDir;
                iniDir = (txtTehaiDaityo.Text.Trim() != "") ? Path.GetDirectoryName(txtTehaiDaityo.Text) : "";
                if (Directory.Exists(iniDir) == true)
                    dlg.InitialDirectory = iniDir;
                DialogResult res = dlg.ShowDialog();
                if (res == System.Windows.Forms.DialogResult.OK)
                    txtTehaiDaityo.Text = dlg.FileName;
            }
        }
        #endregion

        #region 「起動」ボタン
        /// <summary>
        /// 「部品表ファイル」　起動ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExecBuhinFile_Click(object sender, EventArgs e)
        {
            if (File.Exists(txtBuhinFile.Text) == false)
            {
                MessageBox.Show("部品表ファイルが存在しません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ExecExcelFile(txtBuhinFile.Text);
        }
        /// <summary>
        /// 「手配台帳ファイル」　起動ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExecTehaiDaityo_Click(object sender, EventArgs e)
        {
            if (File.Exists(txtTehaiDaityo.Text) == false)
            {
                MessageBox.Show("手配台帳ファイルが存在しません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ExecExcelFile(txtTehaiDaityo.Text);
        }
        /// <summary>
        /// Excel起動
        /// </summary>
        /// <param name="fileName"></param>
        private void ExecExcelFile(string fileName)
        {
            if (fileName == "")
                return;
            if (File.Exists(fileName) == false)
                return;

            System.Diagnostics.Process p = System.Diagnostics.Process.Start("excel.exe", "\"" + fileName + "\"");
        }
        #endregion

        #region  「手配リスト」　クリアボタン
        /// <summary>
        /// 手配リスト　クリアボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearBuhinList_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("手配リストをクリアします。\nよろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == System.Windows.Forms.DialogResult.No)
                return;
            lvTotal.Items.Clear();
            _clsBuhinDatas.Clear();
        }
        #endregion

        /// <summary>
        /// 手配リスト表示
        /// </summary>
        private void DisplaySumList()
        {
            txtIraiSaki.Text = "";
            lvTotal.Items.Clear();
            if (_clsBuhinDatas.Count <= 0)
                return;
            string kounyuSaki = _clsBuhinDatas[0].KounyuSaki;
            double sum;
            double totalsum;

            totalsum = 0;
            sum = 0;
            foreach (clsBuhinData d in _clsBuhinDatas)
            {
                if (kounyuSaki != d.KounyuSaki)
                {
                    //
                    if (txtIraiSaki.Text != "")
                        txtIraiSaki.Text += ",";
                    txtIraiSaki.Text += kounyuSaki;

                    totalsum += sum;
                    lvTotal.Items.Insert(0, new ListViewItem(new string[] { kounyuSaki, sum.ToString("###,##0.00") }));
                    kounyuSaki = d.KounyuSaki;
                    sum = 0;
                }
                sum += (d.Tanka * d.TehaiSuuryo);
            }

            //
            if (txtIraiSaki.Text != "")
                txtIraiSaki.Text += ",";
            txtIraiSaki.Text += kounyuSaki;

            //最後用
            totalsum += sum;
            lvTotal.Items.Insert(0, new ListViewItem(new string[] { kounyuSaki, sum.ToString("###,##0.00") }));
            //トータル合計
            lvTotal.Items.Add(new ListViewItem(new string[] { "＝＝＝総合計＝＝＝", totalsum.ToString("###,##0.00") }));

            //
            txtTotalSum.Text = totalsum.ToString("###,##0");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        private void ResetCmbBuhinListFiles(string fileName)
        {
            cmbBuhinFile.Items.Insert(0, fileName);
            cmbBuhinFile.SelectedIndex = 0;
            for (int i = 1; i < cmbBuhinFile.Items.Count; i++)
            {
                if (cmbBuhinFile.Items[0].ToString() == cmbBuhinFile.Items[i].ToString())
                {
                    cmbBuhinFile.Items.RemoveAt(i);
                    i--;
                }
            }
            for (int i = cmbBuhinFile.Items.Count - 1; i >= 10; i--)
                cmbBuhinFile.Items.RemoveAt(i);
        }

        private bool flg = false;
        private void cmbBuhinFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flg == true)
                return;
            flg = true;
            ResetCmbBuhinListFiles(cmbBuhinFile.Text);
            flg = false;
            txtBuhinFile.Text = cmbBuhinFile.Text;
            txtBuhinFile.Select(txtBuhinFile.Text.Length, 0);
        }

        private void toolVersionHistory_Click(object sender, EventArgs e)
        {
            frmVersionHistory frm = new frmVersionHistory();
            frm.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            using (frmSearch fm = new frmSearch())
            {
                DialogResult res = fm.ShowDialog();
                if (res == DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;
                    CreateDgvColumn();
                    CreateListProductions();
                    this.Cursor = Cursors.Default;
                }
            }
        }

        /// <summary>
        /// 作番一覧ヘッダ
        /// </summary>
        private void CreateDgvColumn()
        {
            dgvProducts.Columns.Clear();
            dgvProducts.Columns.Add("column1", "作番");
            dgvProducts.Columns.Add("column2", "数");
            dgvProducts.Columns.Add("column3", "名称");
            dgvProducts.Columns.Add("column4", "納期");
            dgvProducts.Columns.Add("column5", "納入日");
            dgvProducts.Columns.Add("column6", "検収日");
            dgvProducts.Columns[0].Width = 120;
            dgvProducts.Columns[1].Width = 50;
            dgvProducts.Columns[2].Width = 400;
            dgvProducts.Columns[3].Width = 110;
            dgvProducts.Columns[4].Width = 110;
            dgvProducts.Columns[5].Width = 110;
        }
        /// <summary>
        /// 作番一覧の作成
        /// </summary>
        private void CreateListProductions()
        {
            System.Data.Odbc.OdbcDataReader odbcReader;
            DBManager db = new DBManager(AppData.getInstance().param.Db_DsnFile);
            try
            {
                bool setWhere = false; ;

                db.DbOpen();
                db.TranBegin();

                string sqlStr = "select production_number,quantity,production_name,delivery_date,ship_date,inspection_date from production p left join client c on p.client_id=c.client_id ";
                //セグメントID
                if (AppData.getInstance().param.SSrh_SegmentID != 0)
                {
                    setWhere = true;
                    sqlStr += "where ";
                    sqlStr += " segment_id=" + AppData.getInstance().param.SSrh_SegmentID.ToString();
                }
                //注番
                if (AppData.getInstance().param.SSrh_ProductionOrderNumber != "")
                {
                    if (setWhere == false)
                    {
                        setWhere = true;
                        sqlStr += "where ";
                    }
                    else
                    {
                        sqlStr += " and ";
                    }
                    sqlStr += " production_order_number like '%" + AppData.getInstance().param.SSrh_ProductionOrderNumber + "%'";
                }
                //作番№
                if (AppData.getInstance().param.SSrh_ProductionNumber != "")
                {
                    if (setWhere == false)
                    {
                        setWhere = true;
                        sqlStr += "where ";
                    }
                    else
                    {
                        sqlStr += " and ";
                    }
                    sqlStr += " production_number like '%" + AppData.getInstance().param.SSrh_ProductionNumber + "%'";
                }
                //作番名称
                if (AppData.getInstance().param.SSrh_ProductionName != "")
                {
                    if (setWhere == false)
                    {
                        setWhere = true;
                        sqlStr += "where ";
                    }
                    else
                    {
                        sqlStr += " and ";
                    }
                    sqlStr += " production_name like '%" + AppData.getInstance().param.SSrh_ProductionName + "%'";
                }
                //取引先
                if (AppData.getInstance().param.SSrh_ClientName != "")
                {
                    if (setWhere == false)
                    {
                        setWhere = true;
                        sqlStr += "where ";
                    }
                    else
                    {
                        sqlStr += " and ";
                    }
                    sqlStr += " client_name like '%" + AppData.getInstance().param.SSrh_ClientName + "%'";
                }
                //取引先/担当者
                if (AppData.getInstance().param.SSrh_AccountRep != "")
                {
                    if (setWhere == false)
                    {
                        setWhere = true;
                        sqlStr += "where ";
                    }
                    else
                    {
                        sqlStr += " and ";
                    }
                    sqlStr += " account_rep like '%" + AppData.getInstance().param.SSrh_AccountRep + "%'";
                }
                //表示する
                if (AppData.getInstance().param.SSrh_ShipORInspDateEnable == false)
                {
                    if (setWhere == false)
                    {
                        setWhere = true;
                        sqlStr += "where ";
                    }
                    else
                    {
                        sqlStr += " and ";
                    }
                    sqlStr += "product_state=1";
                }
                sqlStr += " order by production_number";
                db.Execute(sqlStr, out odbcReader);

                while (odbcReader.Read())
                {
                    string s0 = odbcReader.GetString(0);
                    string s1 = odbcReader.GetString(1);
                    string s2 = odbcReader.GetString(2);
                    string s3 = "";
                    try
                    {
                        s3 = odbcReader.GetString(3).Replace("-", "/");
                    }
                    catch
                    {
                    }
                    string s4 = "";
                    if (odbcReader.IsDBNull(4) == false)
                    {
                        DateTime dt = odbcReader.GetDateTime(4);
                        s4 = dt.ToString("yyyy/MM/dd");
                    }
                    string s5 = "";
                    if (odbcReader.IsDBNull(5) == false)
                    {
                        DateTime dt = odbcReader.GetDateTime(5);
                        s5 = dt.ToString("yyyy/MM/dd");
                    }
                    dgvProducts.Rows.Add(s0, s1, s2, s3, s4, s5);
                }

                db.TranCommit();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                db.TranRollback();
            }
            finally
            {
                db.DbClose();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetProduction_Click(object sender, EventArgs e)
        {
            txtProductionNumber.Text = (string)dgvProducts.SelectedCells[0].Value;
            txtProductionName.Text = (string)dgvProducts.SelectedCells[2].Value;
        }

        private void chkCommentOnOff_CheckedChanged(object sender, EventArgs e)
        {
            chkCommentOnOff.BackColor = chkCommentOnOff.Checked == true ? Color.GreenYellow : Color.LightGray;
        }
    }
}
