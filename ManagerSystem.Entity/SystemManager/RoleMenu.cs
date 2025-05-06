using SqlSugar;

namespace ManagerSystem.Entity.SystemManager
{
    [SugarTable("role_menu")]
    public class RoleMenu:ModelBase
    {
        public int role_Id { get; set; }

        public int memu_Id { get; set; }

    }
}
