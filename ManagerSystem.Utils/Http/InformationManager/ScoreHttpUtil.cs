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
    public class ScoreHttpUtil : HttpUtil
    {
        /// <summary>
        /// 添加成绩
        /// </summary>
        /// <param name="score"></param>
        /// <returns></returns>
        public static int AddScore(Scores score)
        {
            var result = Post<Scores>(UrlConfig.SCO_ADDSCO, score);
            return int.Parse(result);
        }

        /// <summary>
        /// 删除成绩
        /// </summary>
        /// <param name="Id">成绩ID</param>
        /// <returns></returns>
        public static bool DeleteScore(int Id)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["Id"] = Id.ToString();
            var result = Delete(UrlConfig.SCO_DELETESCO, data);
            return int.Parse(result) == 1 ? true : false;
        }

        /// <summary>
        /// 修改成绩信息
        /// </summary>
        /// <param name="score"></param>
        /// <returns></returns>
        public static bool UpdateScore(Scores score)
        {
            var result = Put<Scores>(UrlConfig.SCO_UPDATESCO, score);
            return int.Parse(result) == 1 ? true : false;
        }

        /// <summary>
        /// 查询单个成绩信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static Scores GetScore(int Id)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["Id"] = Id.ToString();
            var result = Get(UrlConfig.SCO_GETSCO, data);
            return HttpUtil.StrToObject<Scores>(result); // 反序列化
        }

        /// <summary>
        /// 根据学生姓名 获取 学生成绩
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public static PageRequest<Scores> GetScoreByStudentName(string Name)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["Name"] = Name;
            var result = Get(UrlConfig.SCO_GETSCOBYSTU, data);
            return HttpUtil.StrToObject<PageRequest<Scores>>(result);
        }

        /// <summary>
        /// 根据 课程名称 获取 学生成绩
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public static PageRequest<Scores> GetScoreByCourse(string Name)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["Name"] = Name;
            var result = Get(UrlConfig.SCO_GETSCOBYCOU, data);
            return HttpUtil.StrToObject<PageRequest<Scores>>(result);
        }

        /// <summary>
        /// 根据学生Id,课程Id,考次Id获取单个成绩
        /// </summary>
        /// <param name="StudentId"></param>
        /// <param name="CourseId"></param>
        /// <returns></returns>
        public static Scores GetScoreByStuAndCourse(int StudentId, int CourseId, int ExamId)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["StudentId"] = StudentId;
            data["CourseId"] = CourseId;
            data["ExamId"] = ExamId;
            var result = Get(UrlConfig.SCO_GETSCOBYSTUANDCOUR, data);
            return HttpUtil.StrToObject<Scores>(result);
        }


        /// <summary>
        /// 查询全部成绩
        /// </summary>
        /// <returns></returns>
        public static PageRequest<Scores> GetAllScore()
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            var result = Get(UrlConfig.SCO_GETAllSCO, data);
            return HttpUtil.StrToObject<PageRequest<Scores>>(result);
        }

        /// <summary>
        /// 全科成绩
        /// </summary>
        /// <param name="number"></param>
        /// <param name="studentName"></param>
        /// <param name="className"></param>
        /// <param name="gradeName"></param>
        /// <param name="examName"></param>
        /// <param name="PerPageNum"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public static PageRequest<Scores> GetScoresAll(string number, string studentName, string className, string gradeName, string examName, int PerPageNum, int PageSize)
        {
            var data = new Dictionary<string, object>();
            data["Number"] = number;
            data["StudentName"] = studentName;
            data["ClassName"] = className;
            data["GradeName"] = gradeName;
            data["ExamName"] = examName;
            data["PerPageNum"] = PerPageNum;
            data["PageSize"] = PageSize;
            var result = Get(UrlConfig.SCO_GETSCOSALL, data);
            return HttpUtil.StrToObject<PageRequest<Scores>>(result);
        }

        /// <summary>
        /// 单科成绩
        /// </summary>
        /// <param name="Number"></param>
        /// <param name="StudentName"></param>
        /// <param name="CourseName"></param>
        /// <param name="ClassName"></param>
        /// <param name="GradeName"></param>
        /// <param name="ExamName"></param>
        /// <param name="PerPageNum"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public static PageRequest<Scores> GetScoresSingle(string Number, string StudentName, string CourseName, string ClassName, string GradeName, string ExamName, int PerPageNum, int PageSize)
        {
            var data = new Dictionary<string, object>();
            data["Number"] = Number;
            data["StudentName"] = StudentName;
            data["CourseName"] = CourseName;
            data["ClassName"] = ClassName;
            data["GradeName"] = GradeName;
            data["ExamName"] = ExamName;
            data["PerPageNum"] = PerPageNum;
            data["PageSize"] = PageSize;
            var result = Get(UrlConfig.SCO_GETSCOSSINGLE, data);
            return HttpUtil.StrToObject<PageRequest<Scores>>(result);
        }


        /// <summary>
        /// 根据学生ID删除所有相关成绩
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static int DeleteAllScoreByStudent(int Id)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["Id"] = Id.ToString();
            var result = Delete(UrlConfig.SCO_DELETESCOBYSTU, data);
            return int.Parse(result); // 返回删除的行数
        }

    }
}
