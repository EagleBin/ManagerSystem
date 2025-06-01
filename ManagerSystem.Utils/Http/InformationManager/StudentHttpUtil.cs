using GalaSoft.MvvmLight;
using ManagerSystem.Entity.InformationManager;
using ManagerSystem.Entity.InformationManager.Link;
using ManagerSystem.Utils.Global;
using ManagerSystem.Utils.Helper;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace ManagerSystem.Utils.Http.InformationManager
{
    /// <summary>
    /// 学生Http请求类
    /// </summary>
    public class StudentHttpUtil : HttpUtil
    {
        /// <summary>
        /// 添加学生
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public static int AddStudent(Students student)
        {
            var result = Post<Students>(UrlConfig.STU_ADDSTU, student);
            return int.Parse(result);
        }
        
        /// <summary>
        /// 删除学生
        /// </summary>
        /// <param name="id">学生ID</param>
        /// <returns></returns>
        public static bool DeleteStudent(int id)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["id"] = id.ToString();
            var result = Delete(UrlConfig.STU_DELETESTU, data);
            return int.Parse(result) == 1 ? true : false;
        }

        /// <summary>
        /// 修改学生信息
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public static bool UpdateStudent(Students student)
        {
            var result = Put<Students>(UrlConfig.STU_UPDATESTU, student);
            return int.Parse(result) == 1 ? true : false;
        }

        /// <summary>
        /// 查询单个学生信息
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public static Students GetStudent(int Id)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["Id"] = Id.ToString();
            var result = Get(UrlConfig.STU_GETSTU, data);
            return HttpUtil.StrToObject<Students>(result); // 反序列化
        }

        public static PageRequest<Students> GetStudentByClass(int Id)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["Id"] = Id.ToString();
            var result = Get(UrlConfig.STU_GETSTUBYCLA, data);
            return HttpUtil.StrToObject<PageRequest<Students>>(result); // 反序列化
        }

        /// <summary>
        /// 查询全部学生
        /// </summary>
        /// <returns></returns>
        public static PageRequest<Students> GetAllStudent()
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            var result = Get(UrlConfig.STU_GETAllSTU, data);
            return HttpUtil.StrToObject<PageRequest<Students>>(result);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="studentName"></param>
        /// <param name="gender"></param>
        /// <returns></returns>
        public static PageRequest<Students> GetStudents(string Name, int gender,int classId, int PerPageNum, int PageSize)
        {
            var data = new Dictionary<string, object>();
            data["Name"] = Name;
            data["Gender"] = gender;
            data["ClassId"] = classId;
            data["PageSize"] = PageSize;
            data["PerPageNum"] = PerPageNum;
            
            var result = Get(UrlConfig.STU_GETSTUS, data);
            return HttpUtil.StrToObject<PageRequest<Students>>(result);
        }

        /// <summary>
        /// 根据名称查询
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public static Students GetStudentByName(string Name)
        {
           Dictionary<string, object> data = new Dictionary<string, object>();
            data["Name"] = Name;
            var result = Get(UrlConfig.STU_GETSTUBYNAME, data);
            return HttpUtil.StrToObject<Students>(result);
        }

        /// <summary>
        /// 获取同名学生数量
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public static int GetClassExistStudentName(string Name, int ClassId)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["Name"] = Name;
            data["ClassId"] = ClassId;
            var result = Get(UrlConfig.STU_GETSTUNAMECOUNT, data);
            return int.Parse(result);
        }

    }
}
