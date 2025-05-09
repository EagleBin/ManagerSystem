using SqlSugar;

namespace ManagerSystem.Entity.SystemManager
{
    /// <summary>
    /// 用户岗位
    /// </summary>
    [SugarTable("user_post")]
    public class UserPost:ModelBase
    {
        public int user_Id { get; set; }

        public int post_Id { get; set; }
    }
}
