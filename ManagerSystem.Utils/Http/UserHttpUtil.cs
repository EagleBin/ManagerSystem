using ManagerSystem.Entity.SystemManager;
using ManagerSystem.Utils.Global;
using ManagerSystem.Utils.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ManagerSystem.Utils.Http
{
    public class UserHttpUtil : HttpUtil
    {

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static int AddUser(User user)
        {
            var ret = Post<User>(UrlConfig.USER_ADDUSER, user);
            return int.Parse(ret);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool UpdateUser(User user)
        {
            var result = Put<User>(UrlConfig.USER_UPDATEUSER,user);
            return int.Parse(result) != 0;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeleteUser(int id)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["id"] = id.ToString();
            var result = Delete(UrlConfig.USER_DELETEUSER, data);
            return int.Parse(result) != 0;
        }

        /// <summary>
        /// 查询单个
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static User GetUser(int id)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["id"] = id.ToString();
            var result_str = Get(UrlConfig.USER_GETUSER, data);
            var result_user = StrToObject<User>(result_str);
            return result_user;
        }

        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        public static PageRequest<User> GetAllUser()
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            var result_str = Get(UrlConfig.USER_GETAllUSER, data);
            var result_users = StrToObject<PageRequest<User>>(result_str);
            return result_users;
        }

        /// <summary>
        /// 分页查询列表
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static PageRequest<User> GetUsers(string account, string phoneNum, string status, string startDate, string endDate, int pageNum, int pageSize, int depId = 0)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["account"] = account;
            data["phoneNum"] = phoneNum;
            data["status"] = status;
            data["startDate"] = startDate;
            data["endDate"] = endDate;
            data["pageNum"] = pageNum;
            data["pageSize"] = pageSize;
            data["depId"] = depId;
            var str = Get(UrlConfig.USER_GETUSERS, data);
            var users = StrToObject<PageRequest<User>>(str);
            return users;
        }

        /// <summary>
        /// 获取登录用户信息
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static User GetLoginUser(string account, string password)
        {
            try
            {
                Dictionary<string, object> data = new Dictionary<string, object>();
                data["Account"] = account;
                data["Password"] = password;
                var result_str = Get(UrlConfig.USER_GETLOGINUSER, data);
                var result_user = StrToObject<User>(result_str);
                return result_user;
            }
            catch (Exception ex)
            {
                MessageBox.Show("服务器繁忙，请稍后。详情：" + ex.Message, "信息提示");
                return null;
                
            }

        }

        /// <summary>
        /// 判断是否存在该用户账号
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public static bool ExistAccount(string account)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["Account"] = account;
            var result = Get(UrlConfig.USER_EXISTACCOUNT, data);
            return int.Parse(result) != 0;
        }

        /// <summary>
        /// 根据用户的id获取到用户的角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static PageRequest<Role> GetUserRole(int id)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["id"] = id;
            var result_str = Get(UrlConfig.USER_GETUSERROLE, data);
            var result_data = StrToObject<PageRequest<Role>>(result_str);
            return result_data;
        }

        /// <summary>
        /// 新增用户角色
        /// </summary>
        /// <param name="userRole"></param>
        /// <returns></returns>
        public static bool AddUserRole(UserRole userRole)
        {
            var ret = Post<UserRole>(UrlConfig.USER_ADDUSERROLE, userRole);
            return int.Parse(ret) != 0;
        }
        /// <summary>
        /// 新增用户岗位
        /// </summary>
        /// <param name="userPost"></param>
        /// <returns></returns>
        public static bool AddUserPost(UserPost userPost)
        {
            var ret = Post<UserPost>(UrlConfig.USER_ADDUSERPOST, userPost);
            return int.Parse(ret) != 0;
        }
        /// <summary>
        /// 删除UserRole
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeleteUserRole(int user_id, int role_id)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["user_id"] = user_id.ToString();
            data["role_id"] = role_id.ToString();
            var ret = Delete(UrlConfig.USER_DELETEUSERROLE, data);
            return int.Parse(ret) != 0;
        }
        /// <summary>
        /// 根据用户的id获取到用户的岗位
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static PageRequest<Post> GetUserPost(int id)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["id"] = id;
            var str = Get(UrlConfig.USER_GETUSERPOST, data);
            var posts = StrToObject<PageRequest<Post>>(str);
            return posts;
        }
    }
}
