using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KaTool;

namespace OutputKounyuList
{
    public partial class frmSearch : Form
    {
        /// <summary>
        /// セグメント名称
        /// </summary>
        private List<string> _lstSegmentNames = new List<string>();
        /// <summary>
        /// セグメントID
        /// </summary>
        private List<int> _lstSegmentIds = new List<int>();
        
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public frmSearch()
        {
            InitializeComponent();
        }

        #region Load/Close
        /// <summary>
        /// Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmSearch_Load(object sender, EventArgs e)
        {
            //セグメントリスト
            CreateListSegment();
            //セグメントComboリスト
            CreateCmbSegment();
            //初期値データ
            Data2Windows();
        }
        /// <summary>
        /// Close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmSearch_FormClosed(object sender, FormClosedEventArgs e)
        {
            Window2Data();
        }
        #endregion

        #region ボタン
        /// <summary>
        /// 検索ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        #endregion

        #region セグメント
        /// <summary>
        /// セグメント一覧を生成する
        /// DBから取得
        /// </summary>
        private void CreateListSegment()
        {
            System.Data.Odbc.OdbcDataReader odbcReader;
            DBManager db = new DBManager(AppData.getInstance().param.Db_DsnFile);
            try
            {
                db.DbOpen();
                db.TranBegin();

                db.Execute("select segment_id,segment_name from segment", out odbcReader);

                _lstSegmentIds.Add(0);
                _lstSegmentNames.Add("");
                while (odbcReader.Read())
                {
                    int id = int.Parse(odbcReader.GetString(0));
                    _lstSegmentIds.Add(id);
                    _lstSegmentNames.Add(odbcReader.GetString(1));
                }

                db.TranCommit();
            }
            catch (Exception)
            {
                db.TranRollback();
            }
            finally
            {
                db.DbClose();
            }
        }
        /// <summary>
        /// セグメントComboリストを生成する
        /// </summary>
        private void CreateCmbSegment()
        {
            foreach (string value in _lstSegmentNames)
                cmbSegment.Items.Add(value);
        }
        #endregion

        #region Data2Win
        /// <summary>
        /// 初期のDefault値を設定する
        /// </summary>
        private void Data2Windows()
        {
            //セグメント
            cmbSegment.SelectedIndex = _lstSegmentIds.FindIndex(x => x == AppData.getInstance().param.SSrh_SegmentID);
            //注番
            txtProductionOrderNumber.Text = AppData.getInstance().param.SSrh_ProductionOrderNumber;
            //作番№
            txtProductionNumber.Text = AppData.getInstance().param.SSrh_ProductionNumber;
            //作番名称
            txtProductionName.Text = AppData.getInstance().param.SSrh_ProductionName;
            //取引先
            txtClientName.Text = AppData.getInstance().param.SSrh_ClientName;
            //取引先/担当者
            txtAccountRep.Text = AppData.getInstance().param.SSrh_AccountRep;
            //表示する
            chkShipORInspDateEnable.Checked = AppData.getInstance().param.SSrh_ShipORInspDateEnable;
        }
        /// <summary>
        /// Window設定値を保持する
        /// </summary>
        private void Window2Data()
        {
            //セグメント
            AppData.getInstance().param.SSrh_SegmentID = _lstSegmentIds[cmbSegment.SelectedIndex];
            //注番
            AppData.getInstance().param.SSrh_ProductionOrderNumber = txtProductionOrderNumber.Text;
            //作番№
            AppData.getInstance().param.SSrh_ProductionNumber = txtProductionNumber.Text;
            //作番名称
            AppData.getInstance().param.SSrh_ProductionName = txtProductionName.Text;
            //取引先
            AppData.getInstance().param.SSrh_ClientName = txtClientName.Text;
            //取引先/担当者
            AppData.getInstance().param.SSrh_AccountRep = txtAccountRep.Text;
            //表示する
            AppData.getInstance().param.SSrh_ShipORInspDateEnable = chkShipORInspDateEnable.Checked;
        }
        #endregion
    }
}
