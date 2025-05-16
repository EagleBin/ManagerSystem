using Azure.Core;
using ManagerSystem.Data;
using ManagerSystem.Entity.SystemManager;
using ManagerSystem.Utils.Helper;
using MySqlConnector;

namespace ManagerSystem.Services.Notices
{
    /// <summary>
    /// 公告服务类
    /// </summary>
    public class NoticeService : INoticeService
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="notice"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int AddNotice(Notice notice)
        {
            notice.insertTime = DateTime.Now;
            return MySqlHelper<Notice>.GetInstance().CurrentDb.Insert(notice) ? 1 : 0;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="noticeId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int DeleteNotice(int noticeId)
        {
            return MySqlHelper<Notice>.GetInstance().CurrentDb.DeleteById(noticeId) ? 1 : 0;
        }

        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public PageRequest<Notice> GetAllNotice()
        {
            List<Notice> data = MySqlHelper<Notice>.GetInstance().CurrentDb.GetListAsync().Result;
            return new PageRequest<Notice>() { items = data, TotalCount = data.Count };
        }

        /// <summary>
        /// 查询单个
        /// </summary>
        /// <param name="noticeId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Notice GetNotice(int noticeId)
        {
            return MySqlHelper<Notice>.GetInstance().CurrentDb.GetById(noticeId);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="noticeTitle"></param>
        /// <param name="noticeStatus"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="pageNum">当前页码</param>
        /// <param name="pageSize">页容量</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public PageRequest<Notice> GetNotices(string? noticeTitle, string? noticeStatus, string? startDate, string? endDate, int pageNum, int pageSize)
        {
            int totalCount = 0;
            DateTime StarDate = DateTime.Parse(startDate ?? DateTime.MinValue.ToShortDateString()).Date;
            DateTime EndDate = DateTime.Parse(endDate ?? DateTime.MaxValue.ToShortDateString()).Date;

            List<Notice> data = MySqlHelper<Notice>.GetInstance().Db.Queryable<Notice>()
                .WhereIF(!string.IsNullOrEmpty(noticeTitle), n => n.NoticeTitle.Contains(noticeTitle ?? ""))
                .WhereIF(!string.IsNullOrEmpty(noticeStatus), n => n.NoticeStatus == ((noticeStatus ?? "").Contains("正常") ? true : false))
                .WhereIF(!string.IsNullOrEmpty(startDate), n => n.insertTime.Date >= StarDate)
                .WhereIF(!string.IsNullOrEmpty(endDate), n => n.insertTime.Date <= EndDate)
                .ToPageList(pageNum, pageSize, ref totalCount);

            return new PageRequest<Notice>() { items = data, TotalCount = totalCount };

        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="notice"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int UpdateNotice(Notice notice)
        {
            return MySqlHelper<Notice>.GetInstance().CurrentDb.Update(notice) ? 1 : 0;
        }
    }
}
