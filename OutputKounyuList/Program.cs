using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using KaTool;

namespace OutputKounyuList
{
	static class Program
	{
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main()
		{
            //System.Threading.Mutex mutex = new System.Threading.Mutex(false, "OutputKounyuList");
            //if (!mutex.WaitOne(0, false))
            //{
            //    string msgStr = "アプリケーションは既に起動されています。";
            //    MessageBox.Show(msgStr, AppData.getInstance().param.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

#if DEBUG
			System.IO.Directory.SetCurrentDirectory(@"..\..\..\exe\");
			System.Diagnostics.Debug.WriteLine(System.IO.Directory.GetCurrentDirectory());
#else
			Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
			System.Threading.Thread.GetDomain().UnhandledException += new UnhandledExceptionEventHandler(Program_UnhandledException);
#endif

			try
			{
				if (true == readyApplication())
				{
                    MainForm formMain = new MainForm();
					Application.Run(formMain);
				}
				termApplication();
			}
			finally
			{
                //mutex.ReleaseMutex();
                //mutex.Close();
            }
		}

		/// <summary>
		/// 初期処理
		/// </summary>
		static private bool readyApplication()
		{
			//string errorStr;
			//ロギング初期化
			//LogingDllWrap.LogingDll.Loging_Init("-CarrierInspection", "MAIN");
			//LogingDllWrap.LogingDll.Loging_SetLogString("============================== システム　起動 ==============================");

			//システムパラメータのロード
			AppData.getInstance().param.Load();

			return true;
		}
		/// <summary>
		/// 終了処理
		/// </summary>
		static private void termApplication()
		{
			//システムパラメータのセーブ
			AppData.getInstance().param.Save();

			//LogingDllWrap.LogingDll.Loging_SetLogString("============================== システム　終了 ==============================");
		}

		#region 例外処理
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
		{
			ShowErrorMessage(e.Exception, "ThreadException による例外通知です。");
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		static void Program_UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			Exception ex = e.ExceptionObject as Exception;
			if (ex != null)
			{
				ShowErrorMessage(ex, "UnhandledException による例外通知です。");
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		/// <param name="message"></param>
		public static void ShowErrorMessage(Exception e, string message)
		{
			System.Diagnostics.Trace.WriteLine(e.Message);
			System.Diagnostics.Trace.WriteLine(message);
			try
			{
				System.Text.StringBuilder sb = new System.Text.StringBuilder();
				sb.AppendLine(message);
				sb.AppendLine();
				sb.AppendLine("アプリケーションでエラーが発生しました。");
				sb.AppendLine();
				sb.AppendLine("【エラー内容】");
				sb.AppendLine(e.Message);
				sb.AppendLine();
				sb.AppendLine("【スタックトレース】");
				sb.AppendLine(e.StackTrace);
				sb.AppendLine();

				string dir = AppData.getInstance().LogDir;
				string filename = string.Format("Exception-{0}.log", DateTime.Now.ToString("yyyyMMdd-HHmmss-fff", System.Globalization.DateTimeFormatInfo.InvariantInfo));
				string path = System.IO.Path.Combine(dir, filename);

				if (!System.IO.Directory.Exists(dir))
				{
					System.IO.Directory.CreateDirectory(dir);
				}
				using (System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.Create, System.IO.FileAccess.Write))
				using (System.IO.StreamWriter sw = new System.IO.StreamWriter(fs, System.Text.Encoding.GetEncoding("Shift-JIS")))
				{
					sw.Write(sb.ToString());
				}

				sb.AppendLine();
				sb.AppendLine("システムを終了します。");

				var result = MessageBox.Show(sb.ToString(), AppData.getInstance().param.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (Exception exc)
			{
				System.Diagnostics.Trace.WriteLine(exc.Message);
			}
			finally
			{
				Environment.Exit(-1);
				//Application.Exit();
			}
		}
		#endregion

	}
}
