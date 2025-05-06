using SqlSugar;

namespace ManagerSystem.Entity.SystemManager
{
    [SugarTable("post")]
    public class Post:ModelBase
    {
        /// <summary>
        /// 名字
        /// </summary>
        public string PostName { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public bool Status { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

    }
}
