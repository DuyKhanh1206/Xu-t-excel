using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace OutputKounyuList
{
    public class clsExcelWriteDaicyo
    {
        public string ErrorMessage { get; private set; }

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
        /// 台帳に登録する
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="datas"></param>
        /// <param name="KounyuFile"></param>
        /// <returns></returns>
        public bool Save(string fileName, List<string> datas, out string KounyuFile)
        {
            KounyuFile = "";
            if (datas.Count <= 0)
                return false;

            try
            {
                InitExcelApp();
                OpenExcelWorkbook(fileName);

                Excel.Range range;
                int line = 2;

                oWkSheet = oExcelWkBookOut.Sheets[1];
                oWkSheet.Select();

                while (true)
                {
                    //申請番号
                    range = oWkSheet.get_Range("B" + line.ToString());
                    if (range.Text == "")
                    {
                        KounyuFile = "A-" + (line - 1).ToString("00000");
                        range.Value = KounyuFile;
                        Marshal.ReleaseComObject(range);
                        //作番
                        range = oWkSheet.get_Range("C" + line.ToString());
                        range.Value = datas[0];
                        Marshal.ReleaseComObject(range);
                        //作番名称
                        range = oWkSheet.get_Range("D" + line.ToString());
                        range.Value = datas[1];
                        Marshal.ReleaseComObject(range);
                        //購入品名
                        range = oWkSheet.get_Range("E" + line.ToString());
                        range.Value = datas[2];
                        Marshal.ReleaseComObject(range);
                        //依頼先
                        range = oWkSheet.get_Range("F" + line.ToString());
                        range.Value = datas[3];
                        Marshal.ReleaseComObject(range);
                        //金額
                        range = oWkSheet.get_Range("G" + line.ToString());
                        range.Value = datas[4];
                        Marshal.ReleaseComObject(range);
                        //見積№
                        range = oWkSheet.get_Range("H" + line.ToString());
                        range.Value = datas[5];
                        Marshal.ReleaseComObject(range);
                        //作成日
                        range = oWkSheet.get_Range("I" + line.ToString());
                        range.Value = datas[6];
                        Marshal.ReleaseComObject(range);
                        //作成者
                        range = oWkSheet.get_Range("J" + line.ToString());
                        range.Value = datas[7];
                        Marshal.ReleaseComObject(range);
                        //備考
                        range = oWkSheet.get_Range("K" + line.ToString());
                        range.Value = datas[8];
                        Marshal.ReleaseComObject(range);
                        break;
                    }
                    line++;
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
        /// <summary>
        /// 台帳登録した申請書を印刷する
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="datas"></param>
        /// <param name="kounyuNumber"></param>
        /// <returns></returns>
        public bool Print(string fileName, List<string> datas, string kounyuNumber)
        {
            if (datas.Count <= 0)
                return false;

            try
            {
                InitExcelApp();
                OpenExcelWorkbook(fileName);

                Excel.Range range;

                //金額
                int TotalSum = int.Parse(datas[4].Replace(",", ""));
                int sheetNo;
                if (TotalSum < 1000000)
                    sheetNo = 2;
                else
                    sheetNo = 3;//v3003 100万前後でシート番号を変更
                //else if (TotalSum < 3000000)
                //    sheetNo = 3;
                //else
                //    sheetNo = 4;

                oWkSheet = oExcelWkBookOut.Sheets[sheetNo];
                oWkSheet.Select();

                //申請番号
                range = oWkSheet.get_Range("AS1");
                range.Value = kounyuNumber;
                Marshal.ReleaseComObject(range);
                //作番
                range = oWkSheet.get_Range("AT1");
                range.Value = datas[0];
                Marshal.ReleaseComObject(range);
                //作番名称
                range = oWkSheet.get_Range("AU1");
                range.Value = datas[1];
                Marshal.ReleaseComObject(range);
                //購入品名
                range = oWkSheet.get_Range("AV1");
                range.Value = datas[2];
                Marshal.ReleaseComObject(range);
                //依頼先
                range = oWkSheet.get_Range("AW1");
                range.Value = datas[3];
                Marshal.ReleaseComObject(range);
                //金額
                range = oWkSheet.get_Range("AX1");
                range.Value = datas[4];
                Marshal.ReleaseComObject(range);
                //見積№
                range = oWkSheet.get_Range("AY1");
                range.Value = datas[5];
                Marshal.ReleaseComObject(range);
                //作成日
                range = oWkSheet.get_Range("AZ1");
                range.Value = datas[6];
                Marshal.ReleaseComObject(range);
                //作成者
                range = oWkSheet.get_Range("BA1");
                range.Value = datas[7];
                Marshal.ReleaseComObject(range);
                //備考
                range = oWkSheet.get_Range("BB1");
                range.Value = datas[8];
                Marshal.ReleaseComObject(range);

                oExcelWkBookOut.SaveAs(fileName);

                oWkSheet.PrintOutEx();
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
