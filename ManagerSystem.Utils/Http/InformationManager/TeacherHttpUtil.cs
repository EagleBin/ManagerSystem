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
    /// 教师Http请求类
    /// </summary>
    public class TeacherHttpUtil : HttpUtil
    {
        /// <summary>
        /// 添加教师
        /// </summary>
        /// <param name="teacher"></param>
        /// <returns></returns>
        public static bool AddTeacher(Teachers teacher)
        {
            var result = Post<Teachers>(UrlConfig.TEA_ADDTEA, teacher);
            return int.Parse(result) == 1 ? true : false;
        }

        /// <summary>
        /// 删除教师
        /// </summary>
        /// <param name="teacherId">教师ID</param>
        /// <returns></returns>
        public static bool DeleteTeacher(int teacherId)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["teacherId"] = teacherId.ToString();
            var result = Delete(UrlConfig.TEA_DELETETEA, data);
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
        /// <param name="teacherId"></param>
        /// <returns></returns>
        public static Teachers GetTeacher(int teacherId)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["teacherId"] = teacherId.ToString();
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
        public static PageRequest<Teachers> GetTeachers(string Name, string Age, string Phone, string Subject, bool IsHeadTeacher, int pageNum, int perPageSize)
        {
            var data = new Dictionary<string, object>();
            data["Name"] = Name;
            data["Age"] = Age;
            data["Phone"] = Phone;
            data["Subject"] = Subject;
            data["IsHeadTeacher"] = IsHeadTeacher ? 1 : 0;
            data["PageSize"] = perPageSize;
            data["PerPageNum"] = pageNum;
            var result = Get(UrlConfig.STU_GETSTUS, data);
            return HttpUtil.StrToObject<PageRequest<Teachers>>(result);
        }

    }
}
