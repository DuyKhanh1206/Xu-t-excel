using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;

namespace OutputKounyuList
{
	public class clsBuhinData
	{
		/// <summary>
		/// 行番号
		/// </summary>
		public int RowNo { get; private set; }
		/// <summary>
		/// 手配者
		/// </summary>
		public string UserName { get; private set; }
		/// <summary>
		/// 品名・名称
		/// </summary>
		public string Hinmei { get; private set; }
		/// <summary>
		/// 型式・仕様
		/// </summary>
		public string Model { get; private set; }
		/// <summary>
		/// メーカー
		/// </summary>
		public string Maker { get; private set; }
		/// <summary>
		/// 単価
		/// </summary>
		public double Tanka { get; private set; }
		/// <summary>
		/// 単位
		/// </summary>
		public string Tani { get; private set; }
		/// <summary>
		/// 手配数
		/// </summary>
		public int TehaiSuuryo { get; private set; }
		/// <summary>
		/// 納期
		/// </summary>
		public string Nouki { get; private set; }
		/// <summary>
		/// 購入先
		/// </summary>
		public string KounyuSaki { get; private set; }
		/// <summary>
		/// 手配済み数
		/// </summary>
		public string TehaiZumi { get; private set; }
        /// <summary>
        /// コメント
        /// </summary>
        public string Comment { get; private set; }


        public clsBuhinData(int rowno, string user, string hinmei, string model, string maker, string tanka, string tani, string tehaisuuryo, string nouki, string konyusaki, string tehaizumi, string comment)
		{
			this.RowNo = rowno;
			this.UserName = user;
			this.Hinmei = hinmei;
			this.Model = model;
			this.Maker = maker;
			this.Tanka = 0;
			double d;
			if (double.TryParse(tanka, out d) == true)
				this.Tanka = d;
			this.Tani = tani;
			this.TehaiSuuryo = 0;
			int i;
			if (int.TryParse(tehaisuuryo, out i) == true)
				this.TehaiSuuryo = i;
			this.Nouki = nouki;
			string s1 = konyusaki.ToUpper();
			this.KounyuSaki = Zenkaku2Hankaku(s1);
			this.TehaiZumi = tehaizumi;
            this.Comment = comment;
		}

		static string Zenkaku2Hankaku(string s)
		{
			string s4 = Microsoft.VisualBasic.Strings.StrConv(s, Microsoft.VisualBasic.VbStrConv.Narrow, 0x411);
			return s4;
		}
		static string Hankaku2Zenkaku(string s)
		{
			string s3 = Microsoft.VisualBasic.Strings.StrConv(s, Microsoft.VisualBasic.VbStrConv.Wide, 0x411);
			return s3;
		}

	}
}
