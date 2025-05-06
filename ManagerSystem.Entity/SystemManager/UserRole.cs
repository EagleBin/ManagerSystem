using SqlSugar;

namespace ManagerSystem.Entity.SystemManager
{
    [SugarTable("user_role")]
    public class UserRole:ModelBase
    {
        public int user_Id { get; set; }

        public int role_Id { get; set; }
    }
}
