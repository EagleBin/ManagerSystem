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
        public Entity.InformationManager.Classes GetClass(int id);

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
        public PageRequest<Entity.InformationManager.Classes> GetClasss(string? Name,string GradeId, int PerPageNum, int  PageSize);



    }
}
