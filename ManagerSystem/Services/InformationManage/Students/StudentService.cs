using ManagerSystem.Utils.Helper;
using ManagerSystem.Entity.InformationManager;
using MySqlConnector;
using ManagerSystem.Data;
using System.Drawing.Printing;
using ManagerSystem.Entity.InformationManager.Link;

namespace ManagerSystem.Services.InformationManage.Students
{
    public class StudentService : IStudentService
    {
        public int AddStudent(Entity.InformationManager.Students student)
        {
            return MySqlHelper<Entity.InformationManager.Students>.GetInstance().CurrentDb.Insert(student) ? 1 : 0;
        }
     
        public int DeleteStudent(int id)
        {
            return MySqlHelper<Entity.InformationManager.Students>.GetInstance().CurrentDb.DeleteById(id) ? 1 : 0;
        }

        
        public PageRequest<Entity.InformationManager.Students> GetAllStudent()
        {
            var result = MySqlHelper<Entity.InformationManager.Students>.GetInstance().CurrentDb.GetListAsync().Result;
            return new PageRequest<Entity.InformationManager.Students>() { items = result, TotalCount = result.Count };
        }

        public Entity.InformationManager.Students GetStudent(int id)
        {
            var result = MySqlHelper<Entity.InformationManager.Students>.GetInstance().CurrentDb.GetById(id);
            return result;
        }

        public PageRequest<Entity.InformationManager.Students> GetStudents(string? Name, string? Gender, int ClassId, int PerPageNum, int PageSize)
        {
            int totalCount = 0;
            var result = MySqlHelper<Entity.InformationManager.Students>.GetInstance().Db.Queryable<Entity.InformationManager.Students>()
                .WhereIF(!(string.IsNullOrEmpty(Name)), s => s.Name.Contains(Name ?? ""))
                .WhereIF(!(string.IsNullOrEmpty(Gender)), s => s.Gender.Contains(Gender ?? ""))
                .WhereIF(ClassId > 0, s => s.ClassId == ClassId)
                .ToPageList(PerPageNum, PageSize, ref totalCount);
            return new PageRequest<Entity.InformationManager.Students>() { items = result, TotalCount = totalCount };
        }

        public int UpdateStudent(Entity.InformationManager.Students student)
        {
            var result = MySqlHelper<Entity.InformationManager.Students>.GetInstance().CurrentDb.Update(student);
            return result ? 1 : 0;
        }
    }
}
