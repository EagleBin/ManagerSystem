using ManagerSystem.Entity.InformationManager;
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
    /// 年级Http请求类
    /// </summary>
    public class GradeHttpUtil : HttpUtil
    {
        /// <summary>
        /// 添加年级
        /// </summary>
        /// <param name="grade"></param>
        /// <returns></returns>
        public static int AddGrade(Grades grade)
        {
            var result = Post<Grades>(UrlConfig.GRA_ADDGRA, grade);
            return int.Parse(result);
        }

        /// <summary>
        /// 删除年级
        /// </summary>
        /// <param name="id">年级ID</param>
        /// <returns></returns>
        public static bool DeleteGrade(int Id)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["Id"] = Id.ToString();
            var result = Delete(UrlConfig.GRA_DELETEGRA, data);
            return int.Parse(result) == 1 ? true : false;
        }

        /// <summary>
        /// 修改年级信息
        /// </summary>
        /// <param name="grade"></param>
        /// <returns></returns>
        public static bool UpdateGrade(Grades grade)
        {
            var result = Put<Grades>(UrlConfig.GRA_UPDATEGRA, grade);
            return int.Parse(result) == 1 ? true : false;
        }

        /// <summary>
        /// 查询单个年级信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Grades GetGrade(int Id)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["Id"] = Id.ToString();
            var result = Get(UrlConfig.GRA_GETGRA, data);
            return HttpUtil.StrToObject<Grades>(result); // 反序列化
        }

        /// <summary>
        /// 查询全部年级
        /// </summary>
        /// <returns></returns>
        public static PageRequest<Grades> GetAllGrade()
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            var result = Get(UrlConfig.GRA_GETAllGRA, data);
            return HttpUtil.StrToObject<PageRequest<Grades>>(result);
        }



        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="gradeName"></param>
        /// <param name="gender"></param>
        /// <returns></returns>
        public static PageRequest<Grades> GetGrades(string Name, int PerPageNum, int PageSize)
        {
            var data = new Dictionary<string, object>();
            data["Name"] = Name;
            data["PageSize"] = PageSize;
            data["PerPageNum"] = PerPageNum;
            var result = Get(UrlConfig.GRA_GETGRAS, data);
            return HttpUtil.StrToObject<PageRequest<Grades>>(result);
        }

        /// <summary>
        /// 查找名称是否已经存在
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public static bool ExistName(string Name)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["Name"] = Name;
            return Get(UrlConfig.GRA_ExistName, data) == "true" ? true : false;

        }

        /// <summary>
        /// 根据名称查找
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public static Grades GetGradeByName(string Name)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["Name"] = Name;
            var result = Get(UrlConfig.GRA_GETGRABYNAME, data);
            return HttpUtil.StrToObject<Grades>(result);
        }

    }
}
