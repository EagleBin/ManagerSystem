using ManagerSystem.Entity.InformationManager;
using ManagerSystem.Entity.InformationManager.Link;
using ManagerSystem.Utils.Helper;

namespace ManagerSystem.Services.InformationManage.Scores
{
    public interface IScoreService
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public int AddScore(Entity.InformationManager.Scores score);



        /// <summary>
        /// 删除
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public int DeleteScore(int id);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public int UpdateScore(Entity.InformationManager.Scores score);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Entity.InformationManager.Scores GetScore(int id);

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        public PageRequest<Entity.InformationManager.Scores> GetAllScore();

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="title"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public PageRequest<Entity.InformationManager.Scores> GetScores(string? Number, string? StudentId, string? CourseId, int PerPageNum, int PageSize);

    }
}
