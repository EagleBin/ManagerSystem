using ManagerSystem.Entity.InformationManager;
using ManagerSystem.Utils.Helper;

namespace ManagerSystem.Services.InformationManage.Courses
{
    public interface ICourseService
    {
        /// <summary>
        /// 添加课程
        /// </summary>
        /// <param name="courses"></param>
        /// <returns></returns>
        public int AddCourse(Entity.InformationManager.Courses courses);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteCourse(int id);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        public int UpdateCourse(Entity.InformationManager.Courses course);


        /// <summary>
        /// 根据id查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Entity.InformationManager.Courses GetCourse(int id);

        /// <summary>
        /// 获取所有
        /// </summary>
        /// <returns></returns>
        public PageRequest<Entity.InformationManager.Courses> GetAllCourse();

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="CourseType"></param>
        /// <param name="PerPageNum"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public PageRequest<Entity.InformationManager.Courses> GetCourses(string? Name, int CourseType, int PerPageNum, int PageSize);

        /// <summary>
        /// 根据名字查询
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public Entity.InformationManager.Courses GetCourseByName(string Name);
    }
}
