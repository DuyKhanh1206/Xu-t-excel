using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.Odbc;

namespace KaTool
{
    
    class DBManager
    {
        private OdbcConnection _odbcConn;
        private OdbcTransaction _odbcTransaction;

        public string LastError { get; private set; }

        /// <summary>
        /// 接続文字列　（例[dsnファイル]：@"FileDSN=c:\work\spec.dsn;"
        /// </summary>
        public string ConnectionString { get; private set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="dsnFile"></param>
        public DBManager(string dsnFile)
        {
            ConnectionString = "FileDSN=" + dsnFile;
            _odbcConn = new OdbcConnection(ConnectionString);
        }

        #region データベースOpen/Close
        /// <summary>
        /// DBオープン
        /// </summary>
        /// <returns></returns>
        public void DbOpen()
        {            
            try
            {
                //_odbcConn.ConnectionTimeout = 1;
                _odbcConn.Open();               
            }
            catch(Exception exc)              
            {               
                System.Windows.Forms.MessageBox.Show(string.Format("\r\nデータベース間に接続はありません。 データベースを接続してください"));
                throw exc;              
            }
        }
        /// <summary>
        /// DBクローズ
        /// </summary>
        /// <returns></returns>
        public void DbClose()
        {
            try
            {
                this._odbcConn.Close();
                this._odbcConn.Dispose();
            }
            catch(Exception exc)
            {
                throw exc;
            }
        }
        #endregion


        #region トランザクション
        /// <summary>
        /// 
        /// </summary>
        public void TranBegin()
        {
            try
            {
                if (_odbcConn != null)
                {
                    _odbcTransaction = _odbcConn.BeginTransaction();
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void TranCommit()
        {
            try
            {
                if (_odbcTransaction != null && _odbcTransaction.Connection != null)
                {
                    _odbcTransaction.Commit();
                    _odbcTransaction.Dispose();
                    _odbcTransaction = null;
                }
            }
            catch(Exception exc)
            {
                throw exc;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void TranRollback()
        {
            try
            {
                if (_odbcTransaction != null && _odbcTransaction.Connection != null)
                {
                    _odbcTransaction.Rollback();
                    _odbcTransaction.Dispose();
                    _odbcTransaction = null;
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
        #endregion


        /// <summary>
        /// SQL実行（返りあり）　SELECT
        /// </summary>
        /// <param name="sqlString"></param>
        /// <param name="outReader"></param>
        /// <returns></returns>
        public void Execute(string sqlString, out OdbcDataReader outReader)
        {
            outReader = null;
            try
            {
                //SQL実行
                OdbcCommand cmd = new OdbcCommand();
                cmd.Connection = _odbcConn;
                cmd.Transaction = _odbcTransaction;
                cmd.CommandText = sqlString;
                outReader = cmd.ExecuteReader();
            }
            catch(Exception exc)
            {
                throw exc;
            }
        }

        /// <summary>
        /// SQL実行（返りなし）　INSERT/UPDATE/DELETE
        /// </summary>
        /// <param name="sqlString"></param>
        /// <returns></returns>
        public void ExecuteNonQuery(string sqlString)
        {
            try
            {
                //SQL実行
                OdbcCommand cmd = new OdbcCommand();
                cmd.Connection = _odbcConn;
                cmd.Transaction = _odbcTransaction;
                cmd.CommandText = sqlString;
                cmd.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }


        #region 操作サンプル
        private void Sample()
        {
            System.Data.Odbc.OdbcDataReader odbcReader;

            DBManager db = new DBManager("DSNファイル");
            try
            {
                db.DbOpen();
                db.TranBegin();

                db.Execute("SQL文", out odbcReader);

                while (odbcReader.Read())
                {
                    string keyNo = odbcReader.GetString(0);
                    string lotNo = odbcReader.GetString(1);
                    string data = odbcReader.GetString(2);
                    string number = odbcReader.GetString(3);
                }

                db.TranCommit();
            }
            catch (Exception exc)
            {
                db.TranRollback();
                this.LastError = exc.Message;
            }
            finally
            {
                db.DbClose();
            }
        }
        #endregion
    }
}
