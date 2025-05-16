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

        public PageRequest<Entity.InformationManager.Teachers> GetTeachers(string? Name, string? Age, int PerPageNum, int PageSize)
        {
            // WhereIF(是否应用此查询条件)
            var depList = MySqlHelper<Department>.GetInstance().CurrentDb.GetListAsync().Result;
            int totalCount = 0;
            var result = MySqlHelper<Entity.InformationManager.Teachers>.GetInstance().Db.Queryable<Entity.InformationManager.Teachers>()
                .WhereIF(!(string.IsNullOrEmpty(Name)), s => s.Name.Contains(Name ?? ""))
                .WhereIF(!(string.IsNullOrEmpty(Age)), a=> a.Age == int.Parse(Age))
                .ToPageList(PerPageNum, PageSize, ref totalCount);
            return new PageRequest<Entity.InformationManager.Teachers>() { items = result, TotalCount = totalCount };
        }

        public int UpdateTeacher(Entity.InformationManager.Teachers teacher)
        {
            var result = MySqlHelper<Entity.InformationManager.Teachers>.GetInstance().CurrentDb.Update(teacher);
            return result ? 1 : 0;
        }

    }
}
