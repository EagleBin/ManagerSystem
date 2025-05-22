using ManagerSystem.Data;
using ManagerSystem.Entity.InformationManager;
using ManagerSystem.Entity.SystemManager;
using ManagerSystem.Utils.Helper;

namespace ManagerSystem.Services.InformationManage.Teachers
{
    public class TeacherService : ITeacherService
    {
        public int AddTeacher(Entity.InformationManager.Teachers teacher)
        {
            var result = MySqlHelper<Entity.InformationManager.Teachers>.GetInstance().CurrentDb.Insert(teacher);
            return result ? 1 : 0;
        }

        public int DeleteTeacher(int teacherId)
        {
            var result = MySqlHelper<Entity.InformationManager.Teachers>.GetInstance().CurrentDb.DeleteById(teacherId);
            return result ? 1 : 0;
        }

        public PageRequest<Entity.InformationManager.Teachers> GetAllTeacher()
        {
            var result = MySqlHelper<Entity.InformationManager.Teachers>.GetInstance().CurrentDb.GetListAsync().Result;
            return new PageRequest<Entity.InformationManager.Teachers>() { items = result, TotalCount = result.Count };
        }

        public Entity.InformationManager.Teachers GetTeacher(int id)
        {
            var result = MySqlHelper<Entity.InformationManager.Teachers>.GetInstance().CurrentDb.GetById(id);
            return result;
        }

        public PageRequest<Entity.InformationManager.Teachers> GetTeachers(string? Name, string? Age, string? Phone, string? Subject, int IsHeadTeacher, int PageNum, int PageSize)
        {
            // WhereIF(是否应用此查询条件)
            int totalCount = 0;
            var result = MySqlHelper<Entity.InformationManager.Teachers>.GetInstance().Db.Queryable<Entity.InformationManager.Teachers>()
                .WhereIF(!(string.IsNullOrEmpty(Name)), s => s.Name.Contains(Name ?? ""))
                .WhereIF(!(string.IsNullOrEmpty(Age)) && int.Parse(Age) > 18 && int.Parse(Age) < 120, a => a.Age == int.Parse(Age))
                .WhereIF(!(string.IsNullOrEmpty(Phone)), p=>p.Phone.Contains(Phone??""))
                .WhereIF(!(string.IsNullOrEmpty(Subject)), s=>s.Subject.Contains(Subject??""))
                .WhereIF(IsHeadTeacher != 2, h=>h.IsHeadTeacher == IsHeadTeacher)
                .ToPageList(PageNum, PageSize, ref totalCount);
            return new PageRequest<Entity.InformationManager.Teachers>() { items = result, TotalCount = totalCount };
        }

        public int UpdateTeacher(Entity.InformationManager.Teachers teacher)
        {
            var result = MySqlHelper<Entity.InformationManager.Teachers>.GetInstance().CurrentDb.Update(teacher);
            return result ? 1 : 0;
        }

        public Entity.InformationManager.Teachers GetTeacherByName(string Name)
        {
            return MySqlHelper<Entity.InformationManager.Teachers>.GetInstance().CurrentDb.GetSingleAsync(g => g.Name == Name).Result;
        }

    }
}
