using DevExpress.XtraBars.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using YFClientDevExpressDemo.User;

namespace YFClientDevExpressDemo.MenuLoad
{
    public partial class MenuMainForm : Form
    {
        string connString = GetAppSettingsKeyValue("conString");
        OleDbConnection conn;

        public MenuMainForm()
        {
            InitializeComponent();
        }

        private void MenuMainForm_Load(object sender, EventArgs e)
        {
            conn = new OleDbConnection(connString);
            User.User.Id = "000";
        }

        private void buttonLoadMenu_Click(object sender, EventArgs e)
        {
            TimeSpan ts1 = new TimeSpan(DateTime.Now.Ticks);
            LoadMenu();
            TimeSpan ts2 = new TimeSpan(DateTime.Now.Ticks);
            string spanTotalSeconds = ts2.Subtract(ts1).Duration().TotalSeconds.ToString();
            Debug.WriteLine("加载菜单用时：" + spanTotalSeconds);
        }

        #region 菜单
        /// <summary>
        /// 加载菜单
        /// </summary>
        private void LoadMenu()
        {
            //获取菜单
            List<Menu> menus = GetMenus();

            //加载菜单
            menus.ForEach(u =>
            {
                //顶级父菜单
                AccordionControlElement parentACE = new AccordionControlElement()
                {
                    Name = u.ID.ToString(),
                    Text = u.Name,
                    Style = ElementStyle.Group
                };
                AddChildElement(parentACE, u); // 添加菜单子节点

                xtControl.Elements.Add(parentACE); //把菜单添加到控件
            });
        }

        /// <summary>
        /// 添加菜单子节点
        /// </summary>
        /// <param name="element"></param>
        /// <param name="menu"></param>
        private void AddChildElement(AccordionControlElement element, Menu menu)
        {
            menu.ChildMenus.ForEach(u =>
            {
                AccordionControlElement ace = new AccordionControlElement()
                {
                    Name = u.ID.ToString(),
                    Text = u.Name,
                    Style = (u.ChildMenus == null || u.ChildMenus.Count() == 0) ? ElementStyle.Item : ElementStyle.Group
                };
                AddChildElement(ace, u);
                element.Elements.Add(ace);
            });
        }

        /// <summary>
        /// 获取菜单
        /// </summary>
        private List<Menu> GetMenus()
        {
            string sql;
            OleDbCommand cmd;
            OleDbDataReader read;

            xtControl.Clear(); // 清空列表 
            if (conn.State == ConnectionState.Closed)
                DbConnect();

            if (conn.State == ConnectionState.Open)
            {
                sql = "select z.zjid id, z.parent_id, z.zjname, z.xh from (select tag from user_permission where yscode = :yscode " +
                    "and permissionstyle = 0) t, zj z where t.tag = z.zjid";
                cmd = new OleDbCommand(sql, conn);
                cmd.Parameters.Add(new OleDbParameter(":yscode", User.User.Id));
                read = cmd.ExecuteReader();

                //读取菜单列表
                List<Menu> menus = new List<Menu>();

                while (read.Read())
                {
                    //Menu menu = new Menu()
                    //{
                    //    ID = Convert.ToInt32(read[0].ToString()),
                    //    ParentID = Convert.ToInt32(read[1].ToString()),
                    //    Name = read[2].ToString(),
                    //    xh = Convert.ToInt32(read[3])
                    //};
                    menus.Add(new Menu()
                    {
                        ID = Convert.ToInt32(read[0].ToString()),
                        ParentID = Convert.ToInt32(read[1].ToString()),
                        Name = read[2].ToString(),
                        xh = Convert.ToInt32(read[3])
                    });
                }

                AddParentMenu(menus);

                // 黄毅：判断是否有父菜单并加入集合
                //for (int i = menus.Count - 1; i >= 0; i--)
                //{
                //    //TimeSpan ts1 = new TimeSpan(DateTime.Now.Ticks);
                //    List<Menu> parentMenus = GetParentMenus(menus[i]);
                //    //TimeSpan ts2 = new TimeSpan(DateTime.Now.Ticks);
                //    //Debug.WriteLine("GetParentMenus用时：" + ts2.Subtract(ts1).Duration().TotalSeconds.ToString());

                //    if (parentMenus.Count > 0)
                //    {
                //        foreach (Menu pm in parentMenus)
                //        {
                //            if (menus.Where(u => u.ID == pm.ID).ToList().Count == 0)
                //                menus.Add(pm);
                //        }
                //    }
                //}

                // 黄毅：排序
                menus = menus.OrderBy(u => u.xh).ToList();//升序

                DbDisconnect(); // 断开数据库

                return GetMenus(menus);
            }
            else
            {
                return null;
            }
        }

        private void AddParentMenu(List<Menu> menus)
        {
            string sql;
            OleDbCommand cmd;
            OleDbDataReader read = null;

            // 获取缺失的父菜单ID
            List<int> parentsId = GetMissingParentIds(menus);
            sql = "select  zjid id , parent_id, zjname, xh from zj where zjid in (:zjid)";

            while (parentsId.Count > 0)
            {
                List<Menu> parentsMenus = new List<Menu>();
                string condition = string.Join(",", parentsId.ToArray());
                cmd = new OleDbCommand(sql, conn);
                cmd.Parameters.Add(new OleDbParameter(":zjid", condition));

                if (conn.State == ConnectionState.Closed)
                    DbConnect();

                if (conn.State == ConnectionState.Open)
                {
                    read = cmd.ExecuteReader();
                }

                while (read.Read())
                {
                    parentsMenus.Add(new Menu()
                    {
                        ID = Convert.ToInt32(read[0].ToString()),
                        ParentID = Convert.ToInt32(read[1].ToString()),
                        Name = read[2].ToString(),
                        xh = Convert.ToInt32(read[3])
                    });
                }
                menus.AddRange(parentsMenus.ToArray());
                parentsId = GetMissingParentIds(parentsMenus);
            }
        }

        /// <summary>
        /// 加载父菜单
        /// </summary>
        /// <param name="menu">子菜单</param>
        /// <returns></returns>
        private List<Menu> GetParentMenus(Menu menu)
        {
            List<Menu> parentMenus = new List<Menu>();
            IDataReader read = null;
            Menu tempMenu = null;
            string sql = "select  zjid id , parent_id, zjname, xh from zj where zjid = :zjid";
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            cmd.Parameters.Add(new OleDbParameter(":zjid", menu.ParentID));
            if (conn.State == ConnectionState.Closed)
                DbConnect();

            if (conn.State == ConnectionState.Open)
            {
                read = cmd.ExecuteReader();
            }

            while (read.Read())
            {
                tempMenu = new Menu()
                {
                    ID = Convert.ToInt32(read[0].ToString()),
                    ParentID = Convert.ToInt32(read[1].ToString()),
                    Name = read[2].ToString(),
                    xh = Convert.ToInt32(read[3])
                };
                parentMenus.Add(tempMenu);
                if (tempMenu.ID == 0)
                    break;
                sql = "select  zjid id ,parent_id,zjname, xh from zj where zjid = :zjid";
                cmd = new OleDbCommand(sql, conn);
                cmd.Parameters.Add(new OleDbParameter(":zjid", tempMenu.ParentID));
                read = cmd.ExecuteReader();
            }

            DbDisconnect();
            return parentMenus;
        }

        private List<int> GetMissingParentIds(List<Menu> menus)
        {
            List<int> parentIds = new List<int>();
            menus.ForEach(u =>
            {
                if (u.ParentID != 0 && !parentIds.Contains(u.ParentID) && menus.Where(m => m.ID == u.ParentID).ToList().Count == 0)
                    parentIds.Add(u.ParentID);
            });

            return parentIds;
        }

        /// <summary>
        /// 获取菜单树
        /// </summary>
        /// <param name="menuList"></param>
        /// <returns></returns>
        private List<Menu> GetMenus(List<Menu> menuList)
        {
            // 先获取顶级父菜单ParentID == 0
            List<Menu> menus = menuList.Where(u => u.ParentID == 0).ToList();

            menus.ForEach(u =>
            {
                u.AddChildMenus(menuList);
            });
            return menus;
        }
        #endregion

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
    }
}
