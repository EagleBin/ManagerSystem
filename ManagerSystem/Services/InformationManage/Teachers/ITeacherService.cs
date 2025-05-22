using ManagerSystem.Entity.InformationManager.Link;
using ManagerSystem.Entity.InformationManager;
using ManagerSystem.Utils.Helper;

namespace ManagerSystem.Services.InformationManage.Teachers
{
    public interface ITeacherService
    {

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="teacher"></param>
        /// <returns></returns>
        public int AddTeacher(Entity.InformationManager.Teachers teacher);



        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="teacher"></param>
        /// <returns></returns>
        public int DeleteTeacher(int id);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="teacher"></param>
        /// <returns></returns>
        public int UpdateTeacher(Entity.InformationManager.Teachers teacher);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Entity.InformationManager.Teachers GetTeacher(int id);

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        public PageRequest<Entity.InformationManager.Teachers> GetAllTeacher();

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="title"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public PageRequest<Entity.InformationManager.Teachers> GetTeachers(string? Name, string? Age, string? Phone, string? Subject, int IsHeadTeacher, int PageNum, int PageSize);

        /// <summary>
        /// 根据名称查询教师
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public Entity.InformationManager.Teachers GetTeacherByName(string Name);

    }
}
