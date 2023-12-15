using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace OutputKounyuList
{
	public class clsExcelReadBuhinList
	{
		public string ErrorMessage { get; private set; }
		public clsExcelReadBuhinList()
		{
		}

		Excel.Application oExcelApp = null;
		Excel.Workbook oExcelWkBookOut = null;
		Excel.Worksheet oWkSheet = null;

		private void InitExcelApp()
		{
			oExcelApp = new Excel.Application();
			oExcelApp.DisplayAlerts = false;
			oExcelApp.Visible = false;
		}
		private void OpenExcelWorkbook(string fileName)
		{
			oExcelWkBookOut = oExcelApp.Workbooks.Open(fileName);
			oWkSheet = oExcelWkBookOut.Sheets[1];
			oWkSheet.Select();
		}
		private void TermExcelApp()
		{
			if (oWkSheet != null)
			{
				Marshal.ReleaseComObject(oWkSheet);
				oWkSheet = null;
			}
			if (oExcelWkBookOut != null)
			{
				oExcelWkBookOut.Close();
				Marshal.ReleaseComObject(oExcelWkBookOut);
				oExcelWkBookOut = null;
			}
			if (oExcelApp != null)
			{
				oExcelApp.Quit();
				Marshal.ReleaseComObject(oExcelApp);
				oExcelApp = null;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="fileName"></param>
		/// <param name="datas"></param>
		/// <returns></returns>
		public bool Load(string fileName, ref List<clsBuhinData> datas )
		{
			datas.Clear();

			try
			{
				InitExcelApp();
				OpenExcelWorkbook(fileName);

				int line = 1;
				while (true)
				{
					Excel.Range range;
					int iTehai;
					line += 1;

					//手配数
					string tehaiSuu;
					range = oWkSheet.get_Range("P" + line.ToString());
					tehaiSuu = range.Text;
					if (tehaiSuu != "")
					{
						tehaiSuu = string.Format("{0}", range.Value);
					}
					Marshal.ReleaseComObject(range);
					range = null;
					tehaiSuu = tehaiSuu.Trim();
					if (tehaiSuu == "")
					{
						continue;
					}
					if (tehaiSuu.ToUpper() == "END")
					{
						break;
					}
					if (int.TryParse(tehaiSuu, out iTehai) == false)
					{
						ErrorMessage = string.Format("手配数には数値を入力して下さい。\n[手配済数:" + "Line" + line.ToString() + "]");
						return false;
					}
					if (iTehai == 0)
					{
						continue;
					}

					//品名
					string hinmei;
					if (GetText("品名", "C" + line.ToString(), out hinmei) == false)
						return false;
					//メーカー
					string maker;
					if (GetText("メーカー", "F" + line.ToString(), out maker) == false)
						return false;
					//型式
					string model;
					if (GetText("型式", "G" + line.ToString(), out model) == false)
						return false;

					//手配者
					string user;
					if (GetText("手配者", "J" + line.ToString(), out user) == false)
						return false;
					//納期
					string nouki;
					if (GetText_Date("納期", "K" + line.ToString(), out nouki) == false)
						return false;
					//購入先
					string kounyusaki;
					if (GetText("購入先", "L" + line.ToString(), out kounyusaki) == false)
						return false;
					//単位
					string tani;
					if (GetText("単位", "M" + line.ToString(), out tani) == false)
						return false;
					//単価
					string tanka;
					if (GetText_Num("単価", "N" + line.ToString(), out tanka) == false)
						return false;
					if (tanka != "")
					{
						double iTanka;
						if (double.TryParse(tanka, out iTanka) == false)
						{
							ErrorMessage = string.Format("単価には数値を入力して下さい。\n[単価:" + "Line" + line.ToString() + "]");
							return false;
						}
					}
                    string comment = "";
                    if (GetText("備考", "H" + line.ToString(), out comment) == false)
                        return false;
                    //System.Windows.Forms.MessageBox.Show(comment);

                    //手配済み数
                    string tehaiZumiSuu;
					range = oWkSheet.get_Range("I" + line.ToString());
					tehaiZumiSuu = range.Text;
					Marshal.ReleaseComObject(range);
					range = null;
					tehaiZumiSuu = tehaiZumiSuu.Trim();
					if (tehaiZumiSuu != "")
					{
						if (int.TryParse(tehaiZumiSuu, out iTehai) == false)
						{
							ErrorMessage = string.Format("手配済数には数値を入力して下さい。\n[手配済数:" + "Line" + line.ToString() + "]");
							return false;
						}
					}
					datas.Add(new clsBuhinData(line, user, hinmei, model, maker, tanka, tani, tehaiSuu, nouki, kounyusaki, tehaiZumiSuu, comment));
				}
			}
			catch (Exception exc)
			{
				ErrorMessage = string.Format("部品表ファイル入力：システムエラー\n" + exc.Message);
				return false;
			}
			finally
			{
				TermExcelApp();
				GC.Collect();
			}

			return true;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="fileName"></param>
		/// <param name="datas"></param>
		/// <returns></returns>
		public bool Save(string fileName, List<clsBuhinData> datas)
		{
			try
			{
				InitExcelApp();
				OpenExcelWorkbook(fileName);

				int line;
				foreach(clsBuhinData data in datas)
				{
					Excel.Range range;

					line = data.RowNo;

					//手配数
					range = oWkSheet.get_Range("P" + line.ToString());
					range.Value = "";
					Marshal.ReleaseComObject(range);

					//手配済み数
					range = oWkSheet.get_Range("I" + line.ToString());
					int newZumiCnt = 0;
					CalcTehaiZumi(data.TehaiZumi, data.TehaiSuuryo, line, out newZumiCnt);
					range.Value = newZumiCnt;
					Marshal.ReleaseComObject(range);
				}

				if (datas.Count > 0)
					oExcelWkBookOut.SaveAs(fileName);
			}
			catch (Exception exc)
			{
				ErrorMessage = string.Format("部品表ファイル出力：システムエラー\n" + exc.Message);
				return false;
			}
			finally
			{
				TermExcelApp();
				GC.Collect();
			}

			return true;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="item"></param>
		/// <param name="cell"></param>
		/// <param name="str"></param>
		/// <returns></returns>
		private bool GetText(string item, string cell, out string str)
		{
			Excel.Range range = oWkSheet.get_Range(cell, Type.Missing);
			str = range.Text;
			Marshal.ReleaseComObject(range);
			range = null;
			str = str.Trim();
			if (str == "")
			{
				ErrorMessage = string.Format("未入力です。\n[" + item + ":" + cell + "]");
				return false;
			}
			return true;
		}

		private bool GetText_Date(string item, string cell, out string str)
		{
			Excel.Range range = oWkSheet.get_Range(cell, Type.Missing);
			string strTm = string.Format("{0}", range.Value);
			Marshal.ReleaseComObject(range);
			range = null;
			DateTime tm;
			try
			{
				tm = DateTime.Parse(strTm);
			}
			catch (Exception)
			{
				ErrorMessage = string.Format("日付フォーマットではありません。\n[" + item + ":" + cell + "]");
				str = "";
				return false;
			}
			str = tm.ToString("yyyy/MM/dd");
			str = str.Trim();
			if (str == "")
			{
				ErrorMessage = string.Format("未入力です。\n[" + item + ":" + cell + "]");
				return false;
			}
			return true;
		}

		private bool GetText_Num(string item, string cell, out string str)
		{
			Excel.Range range = oWkSheet.get_Range(cell, Type.Missing);
			if (range.Value != null)
				str = string.Format("{0}", range.Value);
			else
				str = "";
			Marshal.ReleaseComObject(range);
			range = null;
			str = str.Trim();
			if (str == "")
			{
				ErrorMessage = string.Format("未入力です。\n[" + item + ":" + cell + "]");
				return false;
			}
			return true;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="tehaiZumiSuu"></param>
		/// <param name="tehaiSuu"></param>
		/// <param name="line"></param>
		/// <param name="newZumiCnt"></param>
		private void CalcTehaiZumi(string tehaiZumiSuu, int tehaiSuu, int line, out int newZumiCnt)
		{
			newZumiCnt = 0;

			int tehaiZumiCnt;
			tehaiZumiCnt = 0;
			if (tehaiZumiSuu != "")
			{
				tehaiZumiCnt = int.Parse(tehaiZumiSuu);
			}
			newZumiCnt = tehaiZumiCnt + tehaiSuu;
		}
	}
}
