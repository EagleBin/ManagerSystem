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
            return new PageRequest<Entity.InformationManager.Classes> { items = list, TotalCount = list.Count };

        }

        public Entity.InformationManager.Classes GetClass(int Id)
        {

            return MySqlHelper<Entity.InformationManager.Classes>.GetInstance().CurrentDb.GetById(Id);
        }

        public PageRequest<Entity.InformationManager.Classes> GetClasss(string? Name, string? GradeId,int ClassType, int PerPageNum, int PageSize)
        {
            int totalCount = 0;
            var list = MySqlHelper<Entity.InformationManager.Classes>.GetInstance().Db.Queryable<Entity.InformationManager.Classes>()
                .WhereIF(!string.IsNullOrEmpty(Name), n => n.Name.Contains(Name))
                .WhereIF(!string.IsNullOrEmpty(GradeId) && GradeId != "0", g => g.GradeId == int.Parse(GradeId))
                .WhereIF(ClassType != 2, g => g.ClassType == ClassType)
                .ToPageList(PerPageNum, PageSize, ref totalCount);
            return new PageRequest<Entity.InformationManager.Classes> { items = list, TotalCount = totalCount };

        }

        public int UpdateClass(Entity.InformationManager.Classes _class)
        {
            return MySqlHelper<Entity.InformationManager.Classes>.GetInstance().CurrentDb.Update(_class) ? 1 : 0;
        }


        public int AddTeachers_Classes(Teachers_Classes tclass)
        {
            return MySqlHelper<Teachers_Classes>.GetInstance().CurrentDb.Insert(tclass) ? 1 : 0;
        }

        public int DeleteTeachers_Classes(int TeacherId, int ClassId)
        {
            return MySqlHelper<Teachers_Classes>.GetInstance().Db.Deleteable<Teachers_Classes>().Where(tc=>tc.TeacherId == TeacherId && tc.ClassId == ClassId).ExecuteCommand();
        }

        public Entity.InformationManager.Classes GetClassByName(string Name)
        {
           return MySqlHelper<Entity.InformationManager.Classes>.GetInstance().CurrentDb.GetSingleAsync(n=>n.Name == Name).Result;
        }
    }
}
