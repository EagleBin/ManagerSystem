using Microsoft.SqlServer.Server;
using SqlSugar;
using System;
using System.Collections.Generic;
namespace ManagerSystem.Entity.SystemManager
{
    /// <summary>
    /// 公告类
    /// </summary>
    [SugarTable("notice")]
    public class Notice : ModelBase
    {
        /// <summary>
        /// 公告标题
        /// </summary>
        public string NoticeTitle { get; set; }
        /// <summary>
        /// 公告内容
        /// </summary>
        public string NoticeContent { get; set; }
        /// <summary>
        /// 公告状态
        /// </summary>
        public bool NoticeStatus { get; set; }
    }
}
