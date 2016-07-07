using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.ConnectionUI;


namespace DB.R.Core
{
    public class DataConnectionUITool
    {

        public static string SetConnenctUI()
        {
            string conntionstr = "";
            var dialog = new DataConnectionDialog();
            dialog.DataSources.Add(DataSource.AccessDataSource);
            dialog.DataSources.Add(DataSource.OdbcDataSource);
            dialog.DataSources.Add(DataSource.OracleDataSource);
            dialog.DataSources.Add(DataSource.SqlDataSource);
            dialog.DataSources.Add(DataSource.SqlFileDataSource);

            //  dialog.SelectedDataProvider=DataProvider.SqlDataProvider;
            //dialog.SelectedDataSource=DataSource.SqlDataSource;
            DataSource.AddStandardDataSources(dialog);
            if (DataConnectionDialog.Show(dialog) == DialogResult.OK)
            {
                conntionstr = dialog.ConnectionString;
            }
            return conntionstr;

        }

        ///
        /// 测试连接数据库是否成功
        ///
        ///
        public static bool ConnectionTest(string connectionString)
        {
            SqlConnection mySqlConnection; //mySqlConnection   is   a   SqlConnection   object 
            string ConnectionString = "";
            bool IsCanConnectioned = false;

            //获取数据库连接字符串
            ConnectionString = connectionString;
            //创建连接对象
            mySqlConnection = new SqlConnection(ConnectionString);
            //ConnectionTimeout 在.net 1.x 可以设置 在.net 2.0后是只读属性，则需要在连接字符串设置
            //如：server=.;uid=sa;pwd=;database=PMIS;Integrated Security=SSPI; Connection Timeout=30
            //mySqlConnection.ConnectionTimeout = 1;//设置连接超时的时间
            try
            {
                //Open DataBase
                //打开数据库
                mySqlConnection.Open();
                IsCanConnectioned = true;
            }
            catch
            {
                //Can not Open DataBase
                //打开不成功 则连接不成功
                IsCanConnectioned = false;
            }
            finally
            {
                //Close DataBase
                //关闭数据库连接
                mySqlConnection.Close();
            }
            //mySqlConnection   is   a   SqlConnection   object 
            if (mySqlConnection.State == ConnectionState.Closed || mySqlConnection.State == ConnectionState.Broken)
            {
                //Connection   is   not   available  
                return IsCanConnectioned;
            }
            else
            {
                //Connection   is   available  
                return IsCanConnectioned;
            }
        }



    }
}
