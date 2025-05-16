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
    public class ScoreHttpUtil : HttpUtil
    {
        /// <summary>
        /// 添加成绩
        /// </summary>
        /// <param name="score"></param>
        /// <returns></returns>
        public static bool AddScore(Scores score)
        {
            var result = Post<Scores>(UrlConfig.SCO_ADDSCO, score);
            return int.Parse(result) == 1 ? true : false;
        }

        /// <summary>
        /// 删除成绩
        /// </summary>
        /// <param name="scoreId">成绩ID</param>
        /// <returns></returns>
        public static bool DeleteScore(int scoreId)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["id"] = scoreId.ToString();
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
        /// <param name="scoreId"></param>
        /// <returns></returns>
        public static Scores GetScore(int scoreId)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["scoreId"] = scoreId.ToString();
            var result = Get(UrlConfig.SCO_GETSCO, data);
            return HttpUtil.StrToObject<Scores>(result); // 反序列化
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
        /// 分页查询
        /// </summary>
        /// <param name="scoreName"></param>
        /// <param name="gender"></param>
        /// <returns></returns>
        public static PageRequest<Scores> GetScores(string number, string studentId, string courseId, int PerPageNum, int PageSize)
        {
            var data = new Dictionary<string, object>();
            data["Number"] = number;
            data["StudentId"] = studentId;
            data["CourseId"] = courseId;
            data["PageSize"] = PageSize;
            data["PerPageNum"] = PerPageNum;
            var result = Get(UrlConfig.SCO_GETSCOS, data);
            return HttpUtil.StrToObject<PageRequest<Scores>>(result);
        }



    }
}
