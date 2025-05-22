using ManagerSystem.Data;
using ManagerSystem.Utils.Helper;
using ManagerSystem.Utils.Http.InformationManager;
using SqlSugar;

namespace ManagerSystem.Services.InformationManage.Courses
{
    public class CourseService : ICourseService
    {
        public int AddCourse(Entity.InformationManager.Courses courses)
        {
            return MySqlHelper<Entity.InformationManager.Courses>.GetInstance().CurrentDb.Insert(courses) ? 1 : 0;
        }

        public int DeleteCourse(int id)
        {
            return MySqlHelper<Entity.InformationManager.Courses>.GetInstance().CurrentDb.DeleteById(id) ? 1 : 0;
        }

        public PageRequest<Entity.InformationManager.Courses> GetAllCourse()
        {
            var list = MySqlHelper<Entity.InformationManager.Courses>.GetInstance().CurrentDb.GetListAsync().Result;
            return new PageRequest<Entity.InformationManager.Courses> { items = list, TotalCount = list.Count };
        }

        public Entity.InformationManager.Courses GetCourse(int id)
        {
            return MySqlHelper<Entity.InformationManager.Courses>.GetInstance().CurrentDb.GetById(id);
        }

        public Entity.InformationManager.Courses GetCourseByName(string Name)
        {
            return MySqlHelper<Entity.InformationManager.Courses>.GetInstance().CurrentDb.GetSingleAsync(c => c.Name == Name).Result;
        }

        public PageRequest<Entity.InformationManager.Courses> GetCourses(string? Name, int CourseType, int PerPageNum, int PageSize)
        {
            int totalCount = 0;
            var list = MySqlHelper<Entity.InformationManager.Courses>.GetInstance().Db.Queryable<Entity.InformationManager.Courses>()
                .WhereIF(!(string.IsNullOrEmpty(Name)), n => n.Name.Contains(Name ?? ""))
                .WhereIF(CourseType >= 0 && CourseType <= 2, t => t.CourseType == CourseType)
                .ToPageList(PerPageNum, PageSize, ref totalCount);
            return new PageRequest<Entity.InformationManager.Courses> { items = list, TotalCount = totalCount };
        }

        public int UpdateCourse(Entity.InformationManager.Courses course)
        {
            return MySqlHelper<Entity.InformationManager.Courses>.GetInstance().CurrentDb.Update(course) ? 1 : 0;
        }
    }
}
