using ManagerSystem.Entity.SystemManager;
using ManagerSystem.Services.Notices;
using ManagerSystem.Utils.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagerSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NoticeController : ControllerBase
    {
        private readonly ILogger<NoticeController> _logger;
        private readonly INoticeService _noticeService;

        public NoticeController(ILogger<NoticeController> logger, INoticeService noticeService)
        {
            _logger = logger;
            _noticeService = noticeService;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="notice"></param>
        /// <returns></returns>
        [HttpPost]
        public int AddNotice(Notice notice)
        {
            return _noticeService.AddNotice(notice);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="notice"></param>
        /// <returns></returns>
        [HttpPut]
        public int UpdateNotice(Notice notice)
        {
            return _noticeService.UpdateNotice(notice);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="noticeId"></param>
        /// <returns></returns>
        [HttpDelete]
        public int DeleteNotice(int Id)
        {
            return _noticeService.DeleteNotice(Id);
        }

        /// <summary>
        /// 查询单个
        /// </summary>
        /// <param name="noticeId"></param>
        /// <returns></returns>
        [HttpGet]
        public Notice GetNotice(int Id)
        {
            return _noticeService.GetNotice(Id);
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public PageRequest<Notice> GetAllNotice()
        {
            return _noticeService.GetAllNotice();
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="noticeTitle"></param>
        /// <param name="noticeStatus"></param>
        /// <param name="starDate"></param>
        /// <param name="endDate"></param>
        /// <param name="pageNum"></param>
        /// <param name="perpage"></param>
        /// <returns></returns>
        [HttpGet]
        public PageRequest<Notice> GetNotices(string? noticeTitle, string? noticeStatus, string? starDate, string? endDate, int PageNum, int PageSize)
        {
            return _noticeService.GetNotices(noticeTitle, noticeStatus, starDate, endDate, PageNum, PageSize);
        }

        /// <summary>
        /// 获取最新公告
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public Notice GetLatestNotice()
        {
            return _noticeService.GetLatestNotice();
        }

    }
}
