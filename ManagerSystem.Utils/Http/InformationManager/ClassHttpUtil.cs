using ManagerSystem.Entity.InformationManager;
using ManagerSystem.Entity.InformationManager.Link;
using ManagerSystem.Utils.Global;
using ManagerSystem.Utils.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

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
        public static int AddClass(Classes _class)
        {
            var result = Post<Classes>(UrlConfig.CLA_ADDCLA, _class);
            return int.Parse(result);
        }

        /// <summary>
        /// 添加班级教师
        /// </summary>
        /// <param name="tclass"></param>
        /// <returns></returns>
        public static bool AddTeachers_Classes(Teachers_Classes tclass)
        {
            var result = Post<Teachers_Classes>(UrlConfig.CLA_ADDTEACLA, tclass);
            return int.Parse(result) == 1 ? true : false;
        }

        /// <summary>
        /// 删除班级
        /// </summary>
        /// <param name="id">班级ID</param>
        /// <returns></returns>
        public static bool DeleteClass(int Id)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["Id"] = Id.ToString();
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
        public static Classes GetClass(int Id)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["Id"] = Id.ToString();
            var result = Get(UrlConfig.CLA_GETCLA, data);
            return HttpUtil.StrToObject<Classes>(result); // 反序列化
        }

        /// <summary>
        /// 根据名称获取班级
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public static Classes GetClassByName(string Name)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["Name"] = Name;
            var result = Get(UrlConfig.CLA_GETCLABYNAME, data);
            return HttpUtil.StrToObject<Classes>(result);
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
        public static PageRequest<Classes> GetClassByGrade(int Id)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["Id"] = Id;
            var result = Get(UrlConfig.CLA_GETCLABYGRA, data);
            return HttpUtil.StrToObject<PageRequest<Classes>>(result); // 反序列化
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="className"></param>
        /// <param name="gender"></param>
        /// <returns></returns>
        public static PageRequest<Classes> GetClasses(string Name, string GradeId, int ClassType, int PerPageNum, int PageSize)
        {
            var data = new Dictionary<string, object>();
            data["Name"] = Name;
            data["GradeId"] = GradeId;
            data["ClassType"] = ClassType;
            data["PerPageNum"] = PerPageNum;
            data["PageSize"] = PageSize;
            var result = Get(UrlConfig.CLA_GETCLAS, data);
            return HttpUtil.StrToObject<PageRequest<Classes>>(result);
        }

        /// <summary>
        /// 删除 教师-班级表
        /// </summary>
        /// <param name="TeacherId"></param>
        /// <param name="ClassId"></param>
        /// <returns></returns>
        public static int DeleteTeachers_Classes(int TeacherId, int ClassId)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["TeacherId"] = TeacherId.ToString();
            data["ClassId"] = ClassId.ToString();
            var result = Delete(UrlConfig.CLA_DELTEACLA, data);
            return int.Parse(result);
        }

        /// <summary>
        /// 根据班主任Id获取班级列表
        /// </summary>
        /// <param name="Id">班主任Id</param>
        /// <returns></returns>
        public static PageRequest<Classes> GetClassByHeadTeacher(int Id)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["Id"] = Id.ToString();
            var result = Get(UrlConfig.CLA_GETCLABYTEA, data);
            return HttpUtil.StrToObject<PageRequest<Classes>>(result);
        }

        /// <summary>
        /// 通过 班级 获取 教师_班级
        /// </summary>
        /// <param name="ClassId">班级Id</param>
        /// <returns></returns>
        public static Teachers_Classes GetTeachers_ClassesByClass(int ClassId)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["ClassId"] = ClassId.ToString();
            var result = Get(UrlConfig.CLA_GETTEACLABYCLA, data);
            return HttpUtil.StrToObject<Teachers_Classes>(result);
        }
    }
}
