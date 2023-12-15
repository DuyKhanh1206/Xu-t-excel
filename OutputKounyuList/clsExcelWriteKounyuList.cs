using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace OutputKounyuList
{
	public class clsExcelWriteKounyuList
	{
		public string ErrorMessage { get; private set; }
		public clsExcelWriteKounyuList()
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
		private void WriteHeader()
		{
			Excel.Range range;
			range = oWkSheet.get_Range("A1");
			range.Value = "手配者";
			WriteLine(range);
			Marshal.ReleaseComObject(range);
			range = oWkSheet.get_Range("B1");
			range.Value = "品名";
			WriteLine(range);
			Marshal.ReleaseComObject(range);
			range = oWkSheet.get_Range("C1");
			range.Value = "仕様";
			WriteLine(range);
			Marshal.ReleaseComObject(range);
			range = oWkSheet.get_Range("D1");
			range.Value = "メーカー";
			WriteLine(range);
			Marshal.ReleaseComObject(range);
			range = oWkSheet.get_Range("E1");
			range.Value = "単価";
			WriteLine(range);
			Marshal.ReleaseComObject(range);
			range = oWkSheet.get_Range("F1");
			range.Value = "数量";
			WriteLine(range);
			Marshal.ReleaseComObject(range);
			range = oWkSheet.get_Range("G1");
			range.Value = "単位";
			WriteLine(range);
			Marshal.ReleaseComObject(range);
			range = oWkSheet.get_Range("H1");
			range.Value = "納期";
			WriteLine(range);
			Marshal.ReleaseComObject(range);
			range = oWkSheet.get_Range("I1");
			range.Value = "コメント";
			WriteLine(range);
			Marshal.ReleaseComObject(range);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="range"></param>
		private void WriteLine(Excel.Range range)
		{
			range.Borders.get_Item(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous;
			range.Borders.get_Item(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous;
			range.Borders.get_Item(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous;
			range.Borders.get_Item(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="fileName"></param>
		/// <param name="datas"></param>
		/// <returns></returns>
		public bool Save(string fileName, List<clsBuhinData> datas, bool chkValue)
		{
			if (datas.Count<=0)
				return false;

			try
			{
				InitExcelApp();

				//ブック追加
				oExcelWkBookOut = oExcelApp.Workbooks.Add();
				//デフォルトシート[sheet2,sheet3]を削除
				((Excel.Worksheet)oExcelWkBookOut.Sheets[3]).Delete();
				((Excel.Worksheet)oExcelWkBookOut.Sheets[2]).Delete();

				Excel.Range range;
				string kounyuSaki;
				int pt;

				pt = 2;
				kounyuSaki = datas[0].KounyuSaki;
				oWkSheet = oExcelWkBookOut.Sheets[1];
				//シート名変更
				oWkSheet.Name = datas[0].KounyuSaki;
				//１行目：ヘッダ           dòng tiêu đề
				WriteHeader();
				for (int i = 0; i < datas.Count; i++)
				{
					if (kounyuSaki != datas[i].KounyuSaki)
					{
						pt = 2;
						//シート追加
						oExcelWkBookOut.Sheets.Add();
						kounyuSaki = datas[i].KounyuSaki;
						oWkSheet = oExcelWkBookOut.Sheets[1];
						//シート名変更
						oWkSheet.Name = datas[i].KounyuSaki;
						//１行目：ヘッダ
						WriteHeader();
					}                   // ghi data vào excel
					//手配者
					range = oWkSheet.get_Range("A" + pt.ToString());
					range.Value = datas[i].UserName;
					WriteLine(range);
					Marshal.ReleaseComObject(range);
					//品名
					range = oWkSheet.get_Range("B" + pt.ToString());
					range.Value = datas[i].Hinmei;
					WriteLine(range);
					Marshal.ReleaseComObject(range);
					//型式
					range = oWkSheet.get_Range("C" + pt.ToString());
					range.Value = datas[i].Model;
					WriteLine(range);
					Marshal.ReleaseComObject(range);
					//メーカー
					range = oWkSheet.get_Range("D" + pt.ToString());
					range.Value = datas[i].Maker;
					WriteLine(range);
					Marshal.ReleaseComObject(range);
					//単価
					range = oWkSheet.get_Range("E" + pt.ToString());
					range.Value = datas[i].Tanka;
					WriteLine(range);
					Marshal.ReleaseComObject(range);
					//手配数
					range = oWkSheet.get_Range("F" + pt.ToString());
					range.Value = datas[i].TehaiSuuryo;
					WriteLine(range);
					Marshal.ReleaseComObject(range);
					//単価
					range = oWkSheet.get_Range("G" + pt.ToString());
					range.Value = datas[i].Tani;
					WriteLine(range);
					Marshal.ReleaseComObject(range);
					//納期
					range = oWkSheet.get_Range("H" + pt.ToString());
					range.Value = datas[i].Nouki;
					WriteLine(range);
					Marshal.ReleaseComObject(range);
					//コメント
					range = oWkSheet.get_Range("I" + pt.ToString());
                    range.Value = chkValue ? datas[i].Comment : "";
					WriteLine(range);
					Marshal.ReleaseComObject(range);
					pt += 1;
				}

				oExcelWkBookOut.SaveAs(fileName);
			}
			catch (Exception exc)
			{
				ErrorMessage = string.Format("購入依頼ファイル出力：システムエラー\n" + exc.Message);
				return false;
			}
			finally
			{
				TermExcelApp();
				GC.Collect();
			}

			return true;
		}
	}
}
