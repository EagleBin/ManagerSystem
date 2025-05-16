using ManagerSystem.Entity.InformationManager.Link;
using ManagerSystem.Entity.InformationManager;
using ManagerSystem.Utils.Helper;

namespace ManagerSystem.Services.InformationManage.Grades
{
    public interface IGradeService
    {

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public int AddGrade(Entity.InformationManager.Grades grade);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public int DeleteGrade(int id);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public int UpdateGrade(Entity.InformationManager.Grades grade);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Entity.InformationManager.Grades GetGrade(int id);

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        public PageRequest<Entity.InformationManager.Grades> GetAllGrade();

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="title"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public PageRequest<Entity.InformationManager.Grades> GetGrades(string? Name, int PerPageNum, int PageSize);

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public bool ExistName(string Name);
    }
}
