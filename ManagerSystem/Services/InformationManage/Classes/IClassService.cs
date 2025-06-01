using ManagerSystem.Entity.InformationManager;
using ManagerSystem.Entity.InformationManager.Link;
using ManagerSystem.Utils.Helper;
using System.Drawing.Printing;

namespace ManagerSystem.Services.InformationManage.Classes
{
    public interface IClassService
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="_class"></param>
        /// <returns></returns>
        public int AddClass(Entity.InformationManager.Classes _class);

        /// <summary>
        /// 添加班级教师
        /// </summary>
        /// <param name="tclass"></param>
        /// <returns></returns>
        public int AddTeachers_Classes(Teachers_Classes tclass);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="_class"></param>
        /// <returns></returns>
        public int DeleteClass(int id);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteClassGrade(int id);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="_class"></param>
        /// <returns></returns>
        public int UpdateClass(Entity.InformationManager.Classes _class);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Entity.InformationManager.Classes GetClass(int Id);

        /// <summary>
        /// 根据名称查询
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public Entity.InformationManager.Classes GetClassByName(string Name);

        /// <summary>
        /// 根据年级查询
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public PageRequest<Entity.InformationManager.Classes> GetClassByGrade(int Id);

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        public PageRequest<Entity.InformationManager.Classes> GetAllClass();

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="title"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public PageRequest<Entity.InformationManager.Classes> GetClasss(string? Name,string? GradeId,int ClassType, int PerPageNum, int  PageSize);

        /// <summary>
        /// 删除教师班级-中间表
        /// </summary>
        /// <param name="TeacherId"></param>
        /// <param name="ClassId"></param>
        /// <returns></returns>
        public int DeleteTeachers_Classes(int TeacherId, int ClassId);

        /// <summary>
        /// 根据班主任Id获取班级列表
        /// </summary>
        /// <param name="TeacherId"></param>
        /// <returns></returns>
        public PageRequest<Entity.InformationManager.Classes> GetClassByHeadTeacher(int Id);

        /// <summary>
        /// 通过 班级 获取 教师_班级
        /// </summary>
        /// <param name="ClassId"></param>
        /// <returns></returns>
        public Teachers_Classes GetTeachers_ClassesByClass(int ClassId);
    }
}
