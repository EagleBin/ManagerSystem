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
        /// <param name="Name">姓名</param>
        /// <param name="Gender">性别</param>
        /// <param name="ClassId">班级ID</param>
        /// <param name="PerPageNum">当前页码</param>
        /// <param name="PageSize">页容量</param>
        /// <returns></returns>
        public PageRequest<Students> GetStudents(string? Name, int Gender,int ClassId, int PerPageNum, int PageSize);

        /// <summary>
        /// 根据名称获取学生
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public Students GetStudentByName(string Name);

        /// <summary>
        /// 根据班级获取学生
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public PageRequest<Students> GetStudentByClass(int Id);

        /// <summary>
        /// 获取同班同名学生的个数
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="ClassId"></param>
        /// <returns></returns>

        public int GetClassExistStudentName(string Name, int ClassId);

    }
}
