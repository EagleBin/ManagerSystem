using ManagerSystem.Data;
using ManagerSystem.Entity.InformationManager;
using ManagerSystem.Entity.InformationManager.Link;
using ManagerSystem.Utils.Helper;
using SqlSugar;
using System.Drawing.Printing;

namespace ManagerSystem.Services.InformationManage.Classes
{

    public class ClassService : IClassService
    {
        public int AddClass(Entity.InformationManager.Classes _class)
        {
            return MySqlHelper<Entity.InformationManager.Classes>.GetInstance().CurrentDb.AsInsertable(_class).ExecuteReturnIdentity();
        }

        public int DeleteClass(int Id)
        {
            return MySqlHelper<Entity.InformationManager.Classes>.GetInstance().CurrentDb.DeleteById(Id) ? 1 : 0;
        }

        public int DeleteClassGrade(int Id)
        {
            return MySqlHelper<Entity.InformationManager.Classes>.GetInstance().CurrentDb.DeleteById(Id) ? 1 : 0;
        }

        public PageRequest<Entity.InformationManager.Classes> GetAllClass()
        {
            var list = MySqlHelper<Entity.InformationManager.Classes>.GetInstance().CurrentDb.GetListAsync().Result;
            return new PageRequest<Entity.InformationManager.Classes> { items = list, TotalCount = list.Count };

        }

        public PageRequest<Entity.InformationManager.Classes> GetClassByGrade(int Id)
        {
            int totalCount = 0;
            var list = MySqlHelper<Entity.InformationManager.Classes>.GetInstance().Db.Queryable<Entity.InformationManager.Classes>()
                .WhereIF(Id > 0, c=>c.GradeId == Id ).ToList();
            return new PageRequest<Entity.InformationManager.Classes> { items = list, TotalCount = totalCount };
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

        public PageRequest<Entity.InformationManager.Classes> GetClassByHeadTeacher(int Id)
        {
            var classList =  MySqlHelper<Entity.InformationManager.Classes>.GetInstance().CurrentDb.GetListAsync(c=>c.HeadTeacher_Id == Id).Result;
            return new PageRequest<Entity.InformationManager.Classes>() { items = classList, TotalCount = classList.Count };
        }

        public Teachers_Classes GetTeachers_ClassesByClass(int ClassId)
        {
            return MySqlHelper<Teachers_Classes>.GetInstance().CurrentDb.GetSingleAsync(tc=>tc.ClassId ==  ClassId).Result;
        }
    }
}
