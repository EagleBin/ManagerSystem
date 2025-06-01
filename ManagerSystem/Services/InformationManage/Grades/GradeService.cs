using ManagerSystem.Data;
using ManagerSystem.Entity.InformationManager;
using ManagerSystem.Entity.InformationManager.Link;
using ManagerSystem.Entity.SystemManager;
using ManagerSystem.Utils.Helper;


namespace ManagerSystem.Services.InformationManage.Grades
{
    public class GradeService : IGradeService
    {
        public int AddGrade(Entity.InformationManager.Grades grade)
        {
            return MySqlHelper<Entity.InformationManager.Grades>.GetInstance().CurrentDb.AsInsertable(grade).ExecuteReturnIdentity();
        }

        public int DeleteGrade(int id)
        {
            return MySqlHelper<Entity.InformationManager.Grades>.GetInstance().CurrentDb.DeleteById(id) ? 1 : 0;
        }

        public PageRequest<Entity.InformationManager.Grades> GetAllGrade()
        {
            var list = MySqlHelper<Entity.InformationManager.Grades>.GetInstance().CurrentDb.GetListAsync().Result;
            return new PageRequest<Entity.InformationManager.Grades> { items = list, TotalCount = list.Count };

        }

        public Entity.InformationManager.Grades GetGrade(int id)
        {
            return MySqlHelper<Entity.InformationManager.Grades>.GetInstance().CurrentDb.GetById(id);
        }

        public PageRequest<Entity.InformationManager.Grades> GetGrades(string? Name, int PerPageNum, int PageSize)
        {
            int totalCount = 0;
            var list = MySqlHelper<Entity.InformationManager.Grades>.GetInstance().Db.Queryable<Entity.InformationManager.Grades>()
                .WhereIF(!string.IsNullOrEmpty(Name), n => n.Name.Contains(Name ?? ""))
                .ToPageList(PerPageNum, PageSize, ref totalCount);
            return new PageRequest<Entity.InformationManager.Grades> { items = list, TotalCount = totalCount };

        }

        public int UpdateGrade(Entity.InformationManager.Grades _grade)
        {
            return MySqlHelper<Entity.InformationManager.Grades>.GetInstance().CurrentDb.Update(_grade) ? 1 : 0;
        }


        public bool ExistName(string Name)
        {
            return MySqlHelper<Entity.InformationManager.Grades>.GetInstance().CurrentDb.GetSingleAsync(g=>g.Name == Name).Result != null ? true : false;
                
        }

        public Entity.InformationManager.Grades GetGradeByName(string Name)
        {
            return MySqlHelper<Entity.InformationManager.Grades>.GetInstance().CurrentDb.GetSingleAsync(g => g.Name == Name).Result;
        }
    }
}
