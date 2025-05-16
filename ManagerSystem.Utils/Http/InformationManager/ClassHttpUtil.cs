using ManagerSystem.Entity.InformationManager;
using ManagerSystem.Entity.InformationManager.Link;
using ManagerSystem.Utils.Global;
using ManagerSystem.Utils.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerSystem.Utils.Http.InformationManager
{
    /// <summary>
    /// 班级Http请求类
    /// </summary>
    public class ClassHttpUtil : HttpUtil
    {
        /// <summary>
        /// 添加班级
        /// </summary>
        /// <param name="class"></param>
        /// <returns></returns>
        public static bool AddClass(Classes _class)
        {
            var result = Post<Classes>(UrlConfig.CLA_ADDCLA, _class);
            return int.Parse(result) == 1 ? true : false;
        }

        /// <summary>
        /// 添加班级年级
        /// </summary>
        /// <param name="cgrade"></param>
        /// <returns></returns>
        public static bool AddTeachers_Classes(Teachers_Classes tclass)
        {
            var result = Post<Teachers_Classes>(UrlConfig.CLA_ADDTEACLA, tclass);
            return int.Parse(result) == 1 ?true: false;
        }

        /// <summary>
        /// 删除班级
        /// </summary>
        /// <param name="id">班级ID</param>
        /// <returns></returns>
        public static bool DeleteClass(int id)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["id"] = id.ToString();
            var result = Delete(UrlConfig.CLA_DELETECLA, data);
            return int.Parse(result) == 1 ? true : false;
        }

        /// <summary>
        /// 修改班级信息
        /// </summary>
        /// <param name="class"></param>
        /// <returns></returns>
        public static bool UpdateClass(Classes _class)
        {
            var result = Put<Classes>(UrlConfig.CLA_UPDATECLA, _class);
            return int.Parse(result) == 1 ? true : false;
        }

        /// <summary>
        /// 查询单个班级信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Classes GetClass(int id)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["id"] = id.ToString();
            var result = Get(UrlConfig.CLA_GETCLA, data);
            return HttpUtil.StrToObject<Classes>(result); // 反序列化
        }

        /// <summary>
        /// 查询全部班级
        /// </summary>
        /// <returns></returns>
        public static PageRequest<Classes> GetAllClass()
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            var result = Get(UrlConfig.CLA_GETAllCLA, data);
            return HttpUtil.StrToObject<PageRequest<Classes>>(result);
        }

        /// <summary>
        /// 根据年级查询班级
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public static PageRequest<Classes> GetClassByGrade(int level)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["Level"] = level.ToString();
            var result = Get(UrlConfig.GRA_GETGRACLA, data);
            return HttpUtil.StrToObject<PageRequest<Classes>>(result); // 反序列化
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="className"></param>
        /// <param name="gender"></param>
        /// <returns></returns>
        public static PageRequest<Classes> GetClasses(string Name, int GradeId, int PerPageNum, int PageSize)
        {
            var data = new Dictionary<string, object>();
            data["Name"] = Name;
            data["GradeId"] = GradeId;
            data["PageSize"] = PageSize;
            data["PerPageNum"] = PerPageNum;
            var result = Get(UrlConfig.CLA_GETCLAS, data);
            return HttpUtil.StrToObject<PageRequest<Classes>>(result);
        }

    }
}
