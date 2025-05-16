using ManagerSystem.Data;
using ManagerSystem.Entity.InformationManager;
using ManagerSystem.Entity.InformationManager.Link;
using ManagerSystem.Utils.Helper;
using SqlSugar;

namespace ManagerSystem.Services.InformationManage.Classes
{

    public class ClassService : IClassService
    {
        public int AddClass(Entity.InformationManager.Classes _class)
        {
            return MySqlHelper<Entity.InformationManager.Classes>.GetInstance().CurrentDb.Insert(_class) ? 1 : 0;
        }

        public int DeleteClass(int classId)
        {
            return MySqlHelper<Entity.InformationManager.Classes>.GetInstance().CurrentDb.DeleteById(classId) ? 1 : 0;
        }

        public int DeleteClassGrade(int classId)
        {
            return MySqlHelper<Entity.InformationManager.Classes>.GetInstance().CurrentDb.DeleteById(classId) ? 1 : 0;
        }

        public PageRequest<Entity.InformationManager.Classes> GetAllClass()
        {
            var list = MySqlHelper<Entity.InformationManager.Classes>.GetInstance().CurrentDb.GetListAsync().Result; 
            return new PageRequest<Entity.InformationManager.Classes> { items = list , TotalCount = list.Count};

        }

        public Entity.InformationManager.Classes GetClass(int classId)
        {

            return MySqlHelper<Entity.InformationManager.Classes>.GetInstance().CurrentDb.GetById(classId);
        }

        public PageRequest<Entity.InformationManager.Classes> GetClasss(string? Name,string? GradeId,  int PerPageNum , int PageSize)
        {
            int totalCount = 0;
            var list = MySqlHelper<Entity.InformationManager.Classes>.GetInstance().Db.Queryable<Entity.InformationManager.Classes>()
                .WhereIF(!string.IsNullOrEmpty(Name), n=> n.Name.Contains(Name))
                .WhereIF(!string.IsNullOrEmpty(GradeId),g=> g.Id == int.Parse(GradeId))
                .ToPageList(PerPageNum, PageSize, ref totalCount);
            return new PageRequest<Entity.InformationManager.Classes> { items= list , TotalCount = totalCount };

        }

        public int UpdateClass(Entity.InformationManager.Classes _class)
        {
            return MySqlHelper<Entity.InformationManager.Classes>.GetInstance().CurrentDb.Update(_class) ? 1 : 0;
        }
    }
}
