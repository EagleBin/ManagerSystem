using ManagerSystem.Entity.InformationManager.Link;
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
    public class ExaminationHttpUtil : HttpUtil
    {

        /// <summary>
        /// 添加考次
        /// </summary>
        /// <param name="examination"></param>
        /// <returns></returns>
        public static int AddExamination(Examination examination)
        {
            var result = Post<Examination>(UrlConfig.EXAM_ADDEXAM, examination);
            return int.Parse(result);
        }

        /// <summary>
        /// 删除考次
        /// </summary>
        /// <param name="id">考次ID</param>
        /// <returns></returns>
        public static bool DeleteExamination(int Id)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["Id"] = Id.ToString();
            var result = Delete(UrlConfig.EXAM_DELETEEXAM, data);
            return int.Parse(result) == 1 ? true : false;
        }

        /// <summary>
        /// 修改考次信息
        /// </summary>
        /// <param name="examination"></param>
        /// <returns></returns>
        public static bool UpdateExamination(Examination examination)
        {
            var result = Put<Examination>(UrlConfig.EXAM_UPDATEEXAM, examination);
            return int.Parse(result) == 1 ? true : false;
        }

        /// <summary>
        /// 查询单个考次信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Examination GetExamination(int Id)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["Id"] = Id.ToString();
            var result = Get(UrlConfig.EXAM_GETEXAM, data);
            return HttpUtil.StrToObject<Examination>(result); // 反序列化
        }

        /// <summary>
        /// 查询全部考次
        /// </summary>
        /// <returns></returns>
        public static PageRequest<Examination> GetAllExamination()
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            var result = Get(UrlConfig.EXAM_GETAllEXAM, data);
            return HttpUtil.StrToObject<PageRequest<Examination>>(result);
        }



        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="examinationName"></param>
        /// <param name="gender"></param>
        /// <returns></returns>
        public static PageRequest<Examination> GetExamination(string Name, string ExamStartTime, string ExamEndTiem, int PerPageNum, int PageSize)
        {
            var data = new Dictionary<string, object>();
            data["Name"] = Name;
            data["ExamStartTime"] = ExamStartTime;
            data["ExamEndTiem"] = ExamEndTiem;
            data["PageSize"] = PageSize;
            data["PerPageNum"] = PerPageNum;
            var result = Get(UrlConfig.EXAM_GETEXAMS, data);
            return HttpUtil.StrToObject<PageRequest<Examination>>(result);
        }

        ///// <summary>
        ///// 查找名称是否已经存在
        ///// </summary>
        ///// <param name="Name"></param>
        ///// <returns></returns>
        //public static bool ExistName(string Name)
        //{
        //    Dictionary<string, object> data = new Dictionary<string, object>();
        //    data["Name"] = Name;
        //    return Get(UrlConfig.EXAM_ExistName, data) == "true" ? true : false;

        //}

        /// <summary>
        /// 根据名称查找
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public static Examination GetExaminationByName(string Name)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["Name"] = Name;
            var result = Get(UrlConfig.EXAM_GETEXAMBYNAME, data);
            return HttpUtil.StrToObject<Examination>(result);
        }


    }
}
