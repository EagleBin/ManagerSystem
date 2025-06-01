using HandyControl.Controls;
using ManagerSystem.Entity.InformationManager;
using ManagerSystem.Entity.InformationManager.Link;
using ManagerSystem.Utils.Global;
using ManagerSystem.Utils.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ManagerSystem.Utils.Http.InformationManager
{
    /// <summary>
    /// 教师Http请求类
    /// </summary>
    public class TeacherHttpUtil : HttpUtil
    {
        /// <summary>
        /// 添加教师
        /// </summary>
        /// <param name="teacher"></param>
        /// <returns></returns>
        public static int AddTeacher(Teachers teacher)
        {
            var result = Post<Teachers>(UrlConfig.TEA_ADDTEA, teacher);
            return int.Parse(result);
        }

        /// <summary>
        /// 添加 课程_教师表
        /// </summary>
        /// <param name="courses_Teachers"></param>
        /// <returns></returns>
        public static int AddCourses_Teachers(Courses_Teachers courses_Teachers)
        {
            var result = Post<Courses_Teachers>(UrlConfig.TEA_ADDCOU_TEA, courses_Teachers);
            return int.Parse(result);
        }

        /// <summary>
        /// 删除教师
        /// </summary>
        /// <param name="teacherId">教师ID</param>
        /// <returns></returns>
        public static bool DeleteTeacher(int teacherId)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["Id"] = teacherId.ToString();
            var result = Delete(UrlConfig.TEA_DELETETEA, data);
            return int.Parse(result) == 1 ? true : false;
        }

        /// <summary>
        /// 删除 课程_教师 中间表
        /// </summary>
        /// <param name="CourseId"></param>
        /// <param name="TeacherId"></param>
        /// <returns></returns>
        public static bool DeleteCourses_Teachers(int CourseId, int TeacherId)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["CourseId"] = CourseId.ToString();
            data["TeacherId"] = TeacherId.ToString();
            var result = Delete(UrlConfig.TEA_DELETECOU_TEA, data);
            return int.Parse(result) == 1 ? true : false;
        }

        /// <summary>
        /// 修改教师信息
        /// </summary>
        /// <param name="teacher"></param>
        /// <returns></returns>
        public static bool UpdateTeacher(Teachers teacher)
        {
            var result = Put<Teachers>(UrlConfig.TEA_UPDATETEA, teacher);
            return int.Parse(result) == 1 ? true : false;
        }

        /// <summary>
        /// 查询单个教师信息
        /// </summary>
        /// <param name="teacherId">教师Id</param>
        /// <returns></returns>
        public static Teachers GetTeacher(int teacherId)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["Id"] = teacherId.ToString();
            var result = Get(UrlConfig.TEA_GETTEA, data);
            return HttpUtil.StrToObject<Teachers>(result); // 反序列化
        }

        /// <summary>
        /// 查询全部教师
        /// </summary>
        /// <returns></returns>
        public static PageRequest<Teachers> GetAllTeacher()
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            var result = Get(UrlConfig.TEA_GETAllTEA, data);
            return HttpUtil.StrToObject<PageRequest<Teachers>>(result);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="teacherName"></param>
        /// <param name="gender"></param>
        /// <returns></returns>
        public static PageRequest<Teachers> GetTeachers(string Name, string Age, string Phone, string Subject, int IsHeadTeacher, int pageNum, int perPageSize)
        {
            var data = new Dictionary<string, object>();
            data["Name"] = Name;
            data["Age"] = Age;
            data["Phone"] = Phone;
            data["Subject"] = Subject;
            data["IsHeadTeacher"] = IsHeadTeacher;
            data["PageNum"] = pageNum;
            data["PageSize"] = perPageSize;

            var result = Get(UrlConfig.TEA_GETTEAS, data);
            return HttpUtil.StrToObject<PageRequest<Teachers>>(result);
        }

        /// <summary>
        /// 根据名称查询教师
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public static Entity.InformationManager.Teachers GetTeacherByName(string Name)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["Name"] = Name;
            var result = Get(UrlConfig.TEA_GETTEABYNAME, data);
            return HttpUtil.StrToObject<Teachers>(result);
        }

        /// <summary>
        /// 根据 课程Id 查询 课程_教师表
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static Courses_Teachers GetTeacher_CourseByCourse(int Id)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["Id"] = Id;
            var result = Get(UrlConfig.TEA_GETTEA_COURBYCOU, data);
            return HttpUtil.StrToObject<Courses_Teachers>(result);
        }

        /// <summary>
        /// 根据课程名称获取教师列表
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public static PageRequest<Entity.InformationManager.Teachers> GetTeacherByCourse(string Name)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["Name"] = Name;
            var result = Get(UrlConfig.TEA_GETTEABYCOU, data);
            return HttpUtil.StrToObject<PageRequest<Entity.InformationManager.Teachers>>(result);
        }

    }
}
