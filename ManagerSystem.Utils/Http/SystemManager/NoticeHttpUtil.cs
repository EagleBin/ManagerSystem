using ManagerSystem.Entity.SystemManager;
using ManagerSystem.Utils.Global;
using ManagerSystem.Utils.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerSystem.Utils.Http.SystemManager
{
    /// <summary>
    /// 公告http请求类
    /// </summary>
    public class NoticeHttpUtil
    {
        /// <summary>
        /// 添加公告
        /// </summary>
        /// <param name="notice"></param>
        /// <returns></returns>
        public static bool AddNotice(Notice notice)
        {
            var result = HttpUtil.Post<Notice>(UrlConfig.NOTICE_ADDNOTICE, notice);
            return int.Parse(result) != 0;
        }

        /// <summary>
        /// 删除公告
        /// </summary>
        /// <param name="noticeId"></param>
        /// <returns></returns>
        public static bool DeleteNotice(int NoticeId)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["Id"] = NoticeId.ToString();
            var result = HttpUtil.Delete(UrlConfig.NoTICE_DELETENOTICE, data);
            return int.Parse(result) != 0;
        }

        /// <summary>
        /// 更新公告
        /// </summary>
        /// <param name="notice"></param>
        /// <returns></returns>
        public static bool UpdateNotice(Notice notice)
        {
            var result = HttpUtil.Put<Notice>(UrlConfig.NoTICE_UPDATENOTICE, notice);
            return int.Parse(result) != 0;
        }

        /// <summary>
        /// 获取单个公告
        /// </summary>
        /// <param name="noticeId"></param>
        /// <returns></returns>
        public static Notice GetNotice(int NoticeId)
        {
            var data = new Dictionary<string, object>();
            data["Id"] = NoticeId;
            var resultStr = HttpUtil.Get(UrlConfig.NoTICE_GETNOTICE, data);
            var resultObj = HttpUtil.StrToObject<Notice>(resultStr);
            return resultObj;
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="noticeTitle"></param>
        /// <param name="noticeStatus"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static PageRequest<Notice> GetNotices(string noticeTitle, string noticeStatus, string startDate, string endDate, int pageNum, int pageSize)
        {
            var data = new Dictionary<string, object>();
            data["NoticeTitle"] = noticeTitle;
            data["NoticeStatus"] = noticeStatus;
            data["StartDate"] = startDate;
            data["EndDate"] = endDate;
            data["PageNum"] = pageNum;
            data["PageSize"] = pageSize;

            var resultStr = HttpUtil.Get(UrlConfig.NOTICE_GETNOTICES, data);
            var resultObj = HttpUtil.StrToObject<PageRequest<Notice>>(resultStr);
            return resultObj;

        }

        /// <summary>
        /// 获取所有公告
        /// </summary>
        /// <returns></returns>
        public static PageRequest<Notice> GetAllNotice()
        {
            var data = new Dictionary<string, object>();
            var resultStr = HttpUtil.Get(UrlConfig.NoTICE_GETALLNOTICE, data);
            var resultObj = HttpUtil.StrToObject<PageRequest<Notice>>(resultStr);
            return resultObj;
        }

        /// <summary>
        /// 获取最新公告
        /// </summary>
        /// <returns></returns>
        public static Notice GetLatestNotice()
        {
            var date = new Dictionary<string, object>();
            var result = HttpUtil.Get(UrlConfig.NoTICE_GETLASNOTICE, date);
            return HttpUtil.StrToObject<Notice>(result);
        }

    }
}
