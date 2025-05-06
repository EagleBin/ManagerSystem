using SqlSugar;
namespace ManagerSystem.Entity.SystemManager
{
    [SugarTable("role")]
    public class Role : ModelBase
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string RoleName { get; set; }
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
