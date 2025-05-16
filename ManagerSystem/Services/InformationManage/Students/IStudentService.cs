using ManagerSystem.Entity.InformationManager;
using ManagerSystem.Entity.InformationManager.Link;
using ManagerSystem.Utils.Helper;

namespace ManagerSystem.Services
{
    public interface IStudentService
    {

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public int AddStudent(Students student);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public int DeleteStudent(int id);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public int UpdateStudent(Students student);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Students GetStudent(int id);

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        public PageRequest<Students> GetAllStudent();

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="title"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public PageRequest<Students> GetStudents(string? Name, string? Gender,int ClassId, int PageSize, int PerPageNum);

    }
}
