using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace YFClientDevExpressDemo.dataBaseTest
{
    public partial class dataBaseTest : Form
    {
        string connString = GetAppSettingsKeyValue("conString");
        OleDbConnection conn;

        public dataBaseTest()
        {
            InitializeComponent();
            conn = new OleDbConnection(connString);
            initTreeListTest();
        }

        public void initTreeListTest()
        {
            treeListTest.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[]
            {
                new DevExpress.XtraTreeList.Columns.TreeListColumn()
                {
                    FieldName = "PERMISSIONNAME",
                    Caption = "名称",
                    Visible = true
                },
                new DevExpress.XtraTreeList.Columns.TreeListColumn()
                {
                    FieldName = "CREATOR",
                    Caption = "创建人",
                    Visible = true
                },
                new DevExpress.XtraTreeList.Columns.TreeListColumn()
                {
                    FieldName = "CREATIONTIME",
                    Caption = "创建时间",
                    Visible = true
                },
                new DevExpress.XtraTreeList.Columns.TreeListColumn()
                {
                    FieldName = "ENABLED",
                    Caption = "启用",
                    Visible = true
                },
                new DevExpress.XtraTreeList.Columns.TreeListColumn()
                {
                    FieldName = "PERMISSIONSTYLE",
                    Caption = "类型",
                    Visible = true
                },
                new DevExpress.XtraTreeList.Columns.TreeListColumn()
                {
                    FieldName = "DESCRIPTION",
                    Caption = "描述",
                    Visible = true
                },
                new DevExpress.XtraTreeList.Columns.TreeListColumn()
                {
                    FieldName = "TAG",
                    Caption = "备注",
                    Visible = true
                }
            });

            treeListTest.OptionsView.AutoWidth = false;
            // 自动调整最佳列宽
            treeListTest.BestFitColumns();
        }

        # region 数据库操作 连接/关闭
        /// <summary>
        /// 连接数据库
        /// </summary>
        private void DbConnect()
        {
            while (conn.State != ConnectionState.Open)
            {
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    //MessageUtil.ShowError(ex.Message.ToString());
                    DialogResult result = MessageBox.Show(ex.Message.ToString(), "服务器连接失败", MessageBoxButtons.AbortRetryIgnore);
                    if (result == DialogResult.Ignore)
                        break;
                    else if (result == DialogResult.Abort)
                        this.Close();
                }
                finally
                {
                }
            }

        }

        /// <summary>
        /// 断开数据库连接
        /// </summary>
        private void DbDisconnect()
        {
            try
            {
                conn.Close();
                //Console.WriteLine(conn.State.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                // MessageUtil.ShowError(ex.Message.ToString());
            }
            finally
            {
                //conn.Close();
            }
        }
        #endregion

        #region 通用函数
        /// <summary>
        /// 获取配置文件值
        /// </summary>
        /// <param name="keyName"></param>
        /// <returns></returns>
        public static string GetAppSettingsKeyValue(string keyName)
        {
            return ConfigurationManager.AppSettings.Get(keyName);
        }

        /// <summary>
        /// 利用反射来判断对象是否包含某个属性
        /// </summary>
        /// <param name="instance">object</param>
        /// <param name="propertyName">需要判断的属性</param>
        /// <returns>是否包含</returns>
        public static bool ContainProperty(object instance, string propertyName)
        {
            if (instance != null && !string.IsNullOrEmpty(propertyName))
            {
                PropertyInfo _findedPropertyInfo = instance.GetType().GetProperty(propertyName);
                return (_findedPropertyInfo != null);
            }
            return false;
        }

        /// <summary>
        /// 获取类中的属性值
        /// </summary>
        /// <param name="FieldName">属性名</param>
        /// <param name="obj">目标对象</param>
        /// <returns>返回值</returns>
        public string GetModelValue(string FieldName, object obj)
        {
            try
            {
                Type Ts = obj.GetType();
                object o = Ts.GetProperty(FieldName).GetValue(obj, null);
                string Value = Convert.ToString(o);
                if (string.IsNullOrEmpty(Value)) return null;
                return Value;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 设置类中的属性值
        /// </summary>
        /// <param name="FieldName">字段名</param>
        /// <param name="Value">值</param>
        /// <param name="obj">目标对象</param>
        /// <returns>是否设置成功</returns>
        public bool SetModelValue(string FieldName, string Value, object obj)
        {
            try
            {
                Type Ts = obj.GetType();
                object v = Convert.ChangeType(Value, Ts.GetProperty(FieldName).PropertyType);
                Ts.GetProperty(FieldName).SetValue(obj, v, null);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        private void buttonLoad_Click(object sender, EventArgs e)
        {

            OleDbDataAdapter adp = new OleDbDataAdapter("select * from permission", conn);
            DataSet ds = new DataSet();
            if (conn.State == ConnectionState.Closed)
                DbConnect();
            if (conn.State == ConnectionState.Open)
            {
                adp.Fill(ds);
            }

            treeListTest.DataSource = ds.Tables[0];
            treeListTest.KeyFieldName = "PERMISSIONID";
            treeListTest.ParentFieldName = "PARENTPERMISSTION";
            treeListTest.BestFitColumns();
        }
    }
}
