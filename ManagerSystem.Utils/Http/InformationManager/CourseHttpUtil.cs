using ManagerSystem.Entity.InformationManager;
using ManagerSystem.Entity.InformationManager.Link;
using ManagerSystem.Utils.Global;
using ManagerSystem.Utils.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ManagerSystem.Utils.Http.InformationManager
{
    public class CourseHttpUtil : HttpUtil
    {
        /// <summary>
        /// 添加课程
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        public static int AddCourse(Courses course)
        {
            var result = Post<Courses>(UrlConfig.COURSE_ADDCOURSE, course);
            return int.Parse(result);
        }

        /// <summary>
        /// 删除课程
        /// </summary>
        /// <param name="id">课程ID</param>
        /// <returns></returns>
        public static bool DeleteCourse(int id)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["id"] = id.ToString();
            var result = Delete(UrlConfig.COURSE_DELETECOURSE, data);
            return int.Parse(result) == 1 ? true : false;
        }

        /// <summary>
        /// 修改课程信息
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        public static bool UpdateCourse(Courses course)
        {
            var result = Put<Courses>(UrlConfig.COURSE_UPDATECOURSE, course);
            return int.Parse(result) == 1 ? true : false;
        }

        /// <summary>
        /// 查询单个课程信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Courses GetCourse(int id)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["id"] = id.ToString();
            var result = Get(UrlConfig.COURSE_GETCOURSE, data);
            return HttpUtil.StrToObject<Courses>(result); // 反序列化
        }

        /// <summary>
        /// 查询全部课程
        /// </summary>
        /// <returns></returns>
        public static PageRequest<Courses> GetAllCourse()
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            var result = Get(UrlConfig.COURSE_GETAllCOURSE, data);
            return HttpUtil.StrToObject<PageRequest<Courses>>(result);
        }

        /// <summary>
        /// 查询指定课程的教师列表
        /// </summary>
        /// <param name="id">课程Id</param>
        /// <returns></returns>
        public static PageRequest<Teachers> GetTeacherByCourse(int id)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["id"] = id.ToString();
            var result = Get(UrlConfig.COURSE_GETCOURSESTEA, data);
            return HttpUtil.StrToObject<PageRequest<Teachers>>(result);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="courseName"></param>
        /// <param name="gender"></param>
        /// <returns></returns>
        public static PageRequest<Courses> GetCourses(string courseName, int courseType, int PerPageNum, int PageSize)
        {
            var data = new Dictionary<string, object>();
            data["Name"] = courseName;
            data["CourseType"] = courseType;
            data["PageSize"] = PageSize;
            data["PerPageNum"] = PerPageNum;
            var result = Get(UrlConfig.COURSE_GETCOURSES, data);
            return HttpUtil.StrToObject<PageRequest<Courses>>(result);
        }

        /// <summary>
        /// 根据名称查询
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public static Courses GetCourseByName(string Name)
        {
            var data = new Dictionary<String, object>();
            data["Name"] = Name;
            var result = Get(UrlConfig.COURSE_GETCOURSEBYNAME, data);
            return HttpUtil.StrToObject<Courses>(result);
        }

        /// <summary>
        /// 获取班级类型的课程
        /// </summary>
        /// <param name="ClassType"></param>
        /// <returns></returns>
        public static PageRequest<Entity.InformationManager.Courses> GetCourseByClassType(int ClassType)
        {
            var data = new Dictionary<String, object>();
            data["ClassType"] = ClassType.ToString();
            var result = Get(UrlConfig.COURSE_GETCOURSEBYCLASSTYPE, data);
            return HttpUtil.StrToObject<PageRequest<Courses>>(result);

        }

        /// <summary>
        /// 获取文理科的课程
        /// </summary>
        /// <param name="CourseType"></param>
        /// <returns></returns>
        public static List<Entity.InformationManager.Courses> GetCourseByType(int CourseType)
        {
            var data = new Dictionary<string,  object>();
            data["CourseType"] = CourseType.ToString();
            var result = Get(UrlConfig.COURSE_GETCOURSEBYType, data);
            return HttpUtil.StrToObject<List<Courses>>(result);
        }

    }
}
