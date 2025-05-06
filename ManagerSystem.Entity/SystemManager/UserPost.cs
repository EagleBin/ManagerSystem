using SqlSugar;

namespace ManagerSystem.Entity.SystemManager
{
    [SugarTable("user_post")]
    public class UserPost:ModelBase
    {
        public int user_Id { get; set; }

        public int post_Id { get; set; }
    }
}
