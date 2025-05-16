using ManagerSystem.Entity.SystemManager;
using ManagerSystem.Utils.Helper;

namespace ManagerSystem.Services.Notices
{
    public interface INoticeService
    {
        /// <summary>
        /// 添加公告
        /// </summary>
        /// <param name="notice"></param>
        /// <returns></returns>
        public int AddNotice(Notice notice);

        /// <summary>
        /// 更新公告
        /// </summary>
        /// <param name="notice"></param>
        /// <returns></returns>
        public int UpdateNotice(Notice notice);

        /// <summary>
        /// 删除公告
        /// </summary>
        /// <param name="notice"></param>
        /// <returns></returns>
        public int DeleteNotice(int noticeId);

        /// <summary>
        /// 查询单个公告
        /// </summary>
        /// <param name="noticeId"></param>
        /// <returns></returns>
        public Notice GetNotice(int noticeId);

        /// <summary>
        /// 查询所有公告
        /// </summary>
        /// <returns></returns>
        public PageRequest<Notice> GetAllNotice();

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
        public PageRequest<Notice> GetNotices(string? noticeTitle, string? noticeStatus, string? startDate, string? endDate, int pageNum, int pageSize);

    }
}
