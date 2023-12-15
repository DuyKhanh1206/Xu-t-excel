using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using System.Drawing;
using System.ComponentModel;

namespace KaTool
{
    class AppData
    {
		/// <summary>
		/// 実行Exe保存ディレクトリ
		/// </summary>
        public string ExeDir { get; private set; }
		/// <summary>
		/// 実行Exe名称(.exeなし)
		/// </summary>
		public string ExeName { get; private set; }
		/// <summary>
		/// ログファイル格納ディレクトリ
		/// </summary>
		public string LogDir { get; private set; }
		/// <summary>
		/// システムINIファイル
		/// </summary>
		public string SystemIniFile { get; private set; }

		public double[] MagnifyList = new double[] { 16.0, 8.0, 4.0, 2.0, 1.0, 0.8, 0.6, 0.5, 0.4, 0.3, 0.28, 0.26, 0.24, 0.22, 0.2, 0.18, 0.16, 0.14, 0.12, 0.1, 0.05, 0.01 };

        private static AppData _singleton = new AppData();
        public static AppData getInstance()
        {
            return _singleton;
        }
		public AppData()
		{
			//アプリケーションソフト情報
			Assembly myAsm = Assembly.GetEntryAssembly();
			string path = myAsm.Location;
			//this.ExeDir = path.Substring(0, path.LastIndexOf("\\") + 1);
            this.ExeDir = System.IO.Directory.GetCurrentDirectory();
			this.ExeName = path.Substring(path.LastIndexOf("\\") + 1, path.LastIndexOf(".") - path.LastIndexOf("\\") - 1);
			this.LogDir = Path.Combine(this.ExeDir, "LogFile");
			if (!Directory.Exists(this.LogDir))
				Directory.CreateDirectory(this.LogDir);
			this.SystemIniFile = this.ExeName +  ".ini";
		}


		/// <summary>
		/// 
		/// </summary>
		public IFormForceCancel ActiveForm
		{
		    get
		    {
		        return _activeForm;
		    }
		    set
		    {
		        _activeForm = value;
		    }
		}
		IFormForceCancel _activeForm;

		public class Parameters
		{
			#region システム
			/// <summary>
			/// システム
			/// </summary>
			private const string Category_System = "システム";
			/// <summary>アプリケーション名</summary>
			[Category(Category_System)]
			[Description("アプリケーション名")]
			public string ApplicationName { get; set; }
            #endregion

			#region メインフォーム
			/// <summary>
			/// メインフォーム
			/// </summary>
			private const string Category_MainForm = "メインフォーム";
			/// <summary>部品表ファイル</summary>
			[Category(Category_MainForm)]
			[Description("部品表ファイル")]
			public string BuhinListFile { get; set; }
			/// <summary>購入依頼ファイル保存先</summary>
			[Category(Category_MainForm)]
			[Description("購入依頼ファイル保存先")]
			public string KounyuIraiFileSaveFolder { get; set; }
			/// <summary>申請書番号</summary>
			[Category(Category_MainForm)]
			[Description("申請書番号")]
			public string ShinseisyoNumber { get; set; }
			/// <summary>手配台帳ファイル</summary>
			[Category(Category_MainForm)]
			[Description("手配台帳ファイル")]
			public string TehaiDaityoFile { get; set; }

			/// <summary>部品表ファイルCombo</summary>
			[Category(Category_MainForm)]
			[Description("部品表ファイルCombo")]

            public bool chkStyleAddButton { get; set; }

            /// <summary>部品表ファイルCombo</summary>
            [Category(Category_MainForm)]
            [Description("スタイルコンボボックス")]
            
            public string[] BuhinListFiles { get; set; }
			#endregion

			#region データベース
			/// <summary>
			/// データベース
			/// </summary>
			private const string Category_Database = "データベース";
			/// <summary>部品表ファイル</summary>
			[Category(Category_Database)]
			[Description("DSNファイル")]
			public string Db_DsnFile { get; set; }
			#endregion

			#region 作番検索の条件
			/// <summary>
			/// 作番検索の条件
			/// </summary>
			private const string Category_Search = "作番検索の条件";
			/// <summary>セグメントID</summary>
			[Category(Category_Search)]
			[Description("セグメントID")]
			public int SSrh_SegmentID { get; set; }
			/// <summary>注番</summary>
			[Category(Category_Search)]
			[Description("注番")]
			public string SSrh_ProductionOrderNumber { get; set; }
			/// <summary>作番№</summary>
			[Category(Category_Search)]
			[Description("作番№")]
			public string SSrh_ProductionNumber { get; set; }
			/// <summary>作番名称</summary>
			[Category(Category_Search)]
			[Description("作番名称")]
			public string SSrh_ProductionName { get; set; }
			/// <summary>取引先</summary>
			[Category(Category_Search)]
			[Description("取引先")]
			public string SSrh_ClientName { get; set; }
			/// <summary>取引先/担当者</summary>
			[Category(Category_Search)]
			[Description("取引先/担当者")]
			public string SSrh_AccountRep { get; set; }
			/// <summary>表示する</summary>
			[Category(Category_Search)]
			[Description("表示する")]
			public bool SSrh_ShipORInspDateEnable { get; set; }
			#endregion

			#region 購入手配台帳
			/// <summary>
			/// 購入手配台帳
			/// </summary>
			private const string Category_Kounyu = "購入手配台帳";
			/// <summary>部品表ファイル</summary>
			[Category(Category_Kounyu)]
			[Description("購入手配者")]
			public string Kounyu_CreateName { get; set; }
			#endregion

			/// <summary>
			/// コンストラクタ
			/// </summary>
			public Parameters()
            {
				string currDir = System.IO.Directory.GetCurrentDirectory();

				//システム
				this.ApplicationName = "購入依頼ファイル生成";
				//メインフォーム
				this.BuhinListFile = "";
				this.KounyuIraiFileSaveFolder = "";
				this.ShinseisyoNumber = "";
				this.TehaiDaityoFile = "";
				this.BuhinListFiles = new string[10];
				//データベース
				this.Db_DsnFile = "./CostManage.dsn";
				//作番検索の条件
				this.SSrh_SegmentID = 0;
				this.SSrh_ProductionOrderNumber = "";
				this.SSrh_ProductionNumber = "";
				this.SSrh_ProductionName = "";
				this.SSrh_ClientName = "";
				this.SSrh_AccountRep = "";
				this.SSrh_ShipORInspDateEnable = false;
				//購入手配台帳
				this.Kounyu_CreateName = "";
			}
			/// <summary>
			/// コピー
			/// </summary>
			/// <returns></returns>
			public Parameters Copy()
			{
				//
				Parameters param = (Parameters)this.MemberwiseClone();
				//システム
				param.ApplicationName = this.ApplicationName;
				//システム終了
				param.BuhinListFile = this.BuhinListFile;
				param.KounyuIraiFileSaveFolder = this.KounyuIraiFileSaveFolder;
				param.ShinseisyoNumber = this.ShinseisyoNumber;
				param.TehaiDaityoFile = this.TehaiDaityoFile;

				if (param.BuhinListFiles == null)
					param.BuhinListFiles = new string[10];
				for (int i=0; i<this.BuhinListFiles.Length; i++)
					param.BuhinListFiles[i] = this.BuhinListFiles[i];

				//データベース
				param.Db_DsnFile = this.Db_DsnFile;

				//作番検索の条件
				param.SSrh_SegmentID = this.SSrh_SegmentID;
				param.SSrh_ProductionOrderNumber = this.SSrh_ProductionOrderNumber;
				param.SSrh_ProductionNumber = this.SSrh_ProductionNumber;
				param.SSrh_ProductionName = this.SSrh_ProductionName;
				param.SSrh_ClientName = this.SSrh_ClientName;
				param.SSrh_AccountRep = this.SSrh_AccountRep;
				param.SSrh_ShipORInspDateEnable = this.SSrh_ShipORInspDateEnable;

				//購入手配台帳
				param.Kounyu_CreateName = this.Kounyu_CreateName;

				return param;
			}
			/// <summary>
			/// 更新
			/// </summary>
			/// <param name="param"></param>
			public void Update(Parameters param)
			{
				//システム
				this.ApplicationName = param.ApplicationName;
				//メインフォーム
				this.BuhinListFile = param.BuhinListFile;
				this.KounyuIraiFileSaveFolder = param.KounyuIraiFileSaveFolder;
				this.ShinseisyoNumber = param.ShinseisyoNumber;
				this.TehaiDaityoFile = param.TehaiDaityoFile;

				for (int i = 0; i < param.BuhinListFiles.Length; i++)
					this.BuhinListFiles[i] = param.BuhinListFiles[i];

				//データベース
				this.Db_DsnFile = param.Db_DsnFile;

				//作番検索の条件
				this.SSrh_SegmentID = param.SSrh_SegmentID;
				this.SSrh_ProductionOrderNumber = param.SSrh_ProductionOrderNumber;
				this.SSrh_ProductionNumber = param.SSrh_ProductionNumber;
				this.SSrh_ProductionName = param.SSrh_ProductionName;
				this.SSrh_ClientName = param.SSrh_ClientName;
				this.SSrh_AccountRep = param.SSrh_AccountRep;
				this.SSrh_ShipORInspDateEnable = param.SSrh_ShipORInspDateEnable;

				//購入手配台帳
				this.Kounyu_CreateName = param.Kounyu_CreateName;
			}
			/// <summary>
			/// 比較
			/// </summary>
			/// <param name="param">比較するデータ</param>
			/// <returns>true:一致 false:不一致</returns>
			public bool Compare(Parameters param)
			{
				//システム
				if (this.ApplicationName != param.ApplicationName)
					return false;
				//メインフォーム
				if (this.BuhinListFile != param.BuhinListFile)
					return false;
				if (this.KounyuIraiFileSaveFolder != param.KounyuIraiFileSaveFolder)
					return false;
				if (this.ShinseisyoNumber != param.ShinseisyoNumber)
					return false;
				if (this.TehaiDaityoFile != param.TehaiDaityoFile)
					return false;
				for (int i = 0; i < this.BuhinListFiles.Length; i++ )
				{
					if (this.BuhinListFiles[i] != param.BuhinListFiles[i])
						return false;
				}

				//データベース
				if (this.Db_DsnFile != param.Db_DsnFile)
					return false;

				//作番検索の条件
				if (this.SSrh_SegmentID != param.SSrh_SegmentID)
					return false;
				if (this.SSrh_ProductionOrderNumber != param.SSrh_ProductionOrderNumber)
					return false;
				if (this.SSrh_ProductionNumber != param.SSrh_ProductionNumber)
					return false;
				if (this.SSrh_ProductionName != param.SSrh_ProductionName)
					return false;
				if (this.SSrh_ClientName != param.SSrh_ClientName)
					return false;
				if (this.SSrh_AccountRep != param.SSrh_AccountRep)
					return false;
				if (this.SSrh_ShipORInspDateEnable != param.SSrh_ShipORInspDateEnable)
					return false;

				//購入手配台帳
				if (this.Kounyu_CreateName != param.Kounyu_CreateName)
					return false;

				return true;
			}
			/// <summary>
			/// ロード
			/// </summary>
			public void Load()
			{
				Fujita.Misc.IniFileAccess ini = new Fujita.Misc.IniFileAccess();
				string sPath = Path.Combine(@"C:\", AppData.getInstance().SystemIniFile);
				string sSection;
				//システム
				sSection = Category_System;
				//this.ApplicationName = ini.GetIni(sSection, GetNameClass.GetName(() => ApplicationName), this.ApplicationName, sPath);
				//メインフォーム
				sSection = Category_MainForm;
				this.BuhinListFile = ini.GetIni(sSection, GetNameClass.GetName(() => BuhinListFile), this.BuhinListFile, sPath);
				this.KounyuIraiFileSaveFolder = ini.GetIni(sSection, GetNameClass.GetName(() => KounyuIraiFileSaveFolder), this.KounyuIraiFileSaveFolder, sPath);
				this.ShinseisyoNumber = ini.GetIni(sSection, GetNameClass.GetName(() => ShinseisyoNumber), this.ShinseisyoNumber, sPath);
				this.TehaiDaityoFile = ini.GetIni(sSection, GetNameClass.GetName(() => TehaiDaityoFile), this.TehaiDaityoFile, sPath);

                this.chkStyleAddButton = ini.GetIni(sSection, GetNameClass.GetName(() => chkStyleAddButton), this.chkStyleAddButton, sPath);

                for (int i = 0; i < this.BuhinListFiles.Length; i++)
				{
					string key = string.Format("{0}_{1}", GetNameClass.GetName(() => BuhinListFiles), i);
					this.BuhinListFiles[i] = ini.GetIni(sSection, key, this.BuhinListFiles[i], sPath);
				}

				//データベース
				sSection = Category_Database;
				this.Db_DsnFile = ini.GetIni(sSection, GetNameClass.GetName(() => Db_DsnFile), this.Db_DsnFile, sPath);

				//作番検索の条件
				sSection = Category_Search;
				this.SSrh_SegmentID = ini.GetIni(sSection, GetNameClass.GetName(() => SSrh_SegmentID), this.SSrh_SegmentID, sPath);
				this.SSrh_ProductionOrderNumber = ini.GetIni(sSection, GetNameClass.GetName(() => SSrh_ProductionOrderNumber), this.SSrh_ProductionOrderNumber, sPath);
				this.SSrh_ProductionNumber = ini.GetIni(sSection, GetNameClass.GetName(() => SSrh_ProductionNumber), this.SSrh_ProductionNumber, sPath);
				this.SSrh_ProductionName = ini.GetIni(sSection, GetNameClass.GetName(() => SSrh_ProductionName), this.SSrh_ProductionName, sPath);
				this.SSrh_ClientName = ini.GetIni(sSection, GetNameClass.GetName(() => SSrh_ClientName), this.SSrh_ClientName, sPath);
				this.SSrh_AccountRep = ini.GetIni(sSection, GetNameClass.GetName(() => SSrh_AccountRep), this.SSrh_AccountRep, sPath);
				this.SSrh_ShipORInspDateEnable = ini.GetIni(sSection, GetNameClass.GetName(() => SSrh_ShipORInspDateEnable), this.SSrh_ShipORInspDateEnable, sPath);

               


                //購入手配台帳
                sSection = Category_Kounyu;
				this.Kounyu_CreateName = ini.GetIni(sSection, GetNameClass.GetName(() => Kounyu_CreateName), this.Kounyu_CreateName, sPath);
			}
			/// <summary>
			/// セーブ
			/// </summary>
			public void Save()
			{
				Fujita.Misc.IniFileAccess ini = new Fujita.Misc.IniFileAccess();
				string sPath = Path.Combine(@"C:\", AppData.getInstance().SystemIniFile);
				string sSection;
                //システム
				sSection = Category_System;
				//ini.SetIni(sSection, GetNameClass.GetName(() => ApplicationName), this.ApplicationName, sPath);
				//メインフォーム
				sSection = Category_MainForm;
				ini.SetIni(sSection, GetNameClass.GetName(() => BuhinListFile), this.BuhinListFile, sPath);
				ini.SetIni(sSection, GetNameClass.GetName(() => KounyuIraiFileSaveFolder), this.KounyuIraiFileSaveFolder, sPath);
				ini.SetIni(sSection, GetNameClass.GetName(() => ShinseisyoNumber), this.ShinseisyoNumber, sPath);
				ini.SetIni(sSection, GetNameClass.GetName(() => TehaiDaityoFile), this.TehaiDaityoFile, sPath);

                ini.SetIni(sSection, GetNameClass.GetName(() => chkStyleAddButton), this.chkStyleAddButton, sPath);
                for (int i = 0; i < this.BuhinListFiles.Length; i++)
				{
					string key = string.Format("{0}_{1}", GetNameClass.GetName(() => BuhinListFiles), i);
					ini.SetIni(sSection, key, this.BuhinListFiles[i], sPath);
				}

				//データベース
				sSection = Category_Database;
				ini.SetIni(sSection, GetNameClass.GetName(() => Db_DsnFile), this.Db_DsnFile, sPath);

				//作番検索の条件
				sSection = Category_Search;
				ini.SetIni(sSection, GetNameClass.GetName(() => SSrh_SegmentID), this.SSrh_SegmentID, sPath);
				ini.SetIni(sSection, GetNameClass.GetName(() => SSrh_ProductionOrderNumber), this.SSrh_ProductionOrderNumber, sPath);
				ini.SetIni(sSection, GetNameClass.GetName(() => SSrh_ProductionNumber), this.SSrh_ProductionNumber, sPath);
				ini.SetIni(sSection, GetNameClass.GetName(() => SSrh_ProductionName), this.SSrh_ProductionName, sPath);
				ini.SetIni(sSection, GetNameClass.GetName(() => SSrh_ClientName), this.SSrh_ClientName, sPath);
				ini.SetIni(sSection, GetNameClass.GetName(() => SSrh_AccountRep), this.SSrh_AccountRep, sPath);
				ini.SetIni(sSection, GetNameClass.GetName(() => SSrh_ShipORInspDateEnable), this.SSrh_ShipORInspDateEnable, sPath);
                //addbutton

				//購入手配台帳
				sSection = Category_Kounyu;
				ini.SetIni(sSection, GetNameClass.GetName(() => Kounyu_CreateName), this.Kounyu_CreateName, sPath);
			}
			/// <summary>
			/// 
			/// </summary>
			/// <param name="dir"></param>
			/// <returns></returns>
			public string GetFullPath(string dir)
			{
				string s = dir;
				if ("" == Path.GetDirectoryName(dir))
					s = Path.Combine(AppData.getInstance().ExeDir, dir);
				if (!Directory.Exists(s))
					Directory.CreateDirectory(s);
				return s;
			}


		}
        public Parameters param = new Parameters();
    }
}
