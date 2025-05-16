using ManagerSystem.Data;
using ManagerSystem.Entity.InformationManager;
using ManagerSystem.Entity.InformationManager.Link;
using ManagerSystem.Utils.Helper;

namespace ManagerSystem.Services.InformationManage.Scores
{
    public class ScoreService : IScoreService
    {
        public int AddScore(Entity.InformationManager.Scores score)
        {
            return MySqlHelper<Entity.InformationManager.Scores>.GetInstance().CurrentDb.Insert(score) ? 1 : 0;
        }

        public int DeleteScore(int id)
        {
            return MySqlHelper<Entity.InformationManager.Scores>.GetInstance().CurrentDb.DeleteById(id) ? 1 : 0;
        }

        public PageRequest<Entity.InformationManager.Scores> GetAllScore()
        {
            var list = MySqlHelper<Entity.InformationManager.Scores>.GetInstance().CurrentDb.GetListAsync().Result;
            return new PageRequest<Entity.InformationManager.Scores> { items = list, TotalCount = list.Count };

        }

        public Entity.InformationManager.Scores GetScore(int id)
        {
            return MySqlHelper<Entity.InformationManager.Scores>.GetInstance().CurrentDb.GetById(id);
        }

        public PageRequest<Entity.InformationManager.Scores> GetScores(string? Number, string? StudentId, string? CourseId, int PerPageNum, int PageSize)
        {
            int totalCount = 0;
            var list = MySqlHelper<Entity.InformationManager.Scores>.GetInstance().Db.Queryable<Entity.InformationManager.Scores>()
                .WhereIF(!string.IsNullOrEmpty(Number), n => n.Number == int.Parse(Number))
                .WhereIF(!string.IsNullOrEmpty(StudentId), n => n.StudentId == int.Parse(StudentId))
                .WhereIF(!string.IsNullOrEmpty(CourseId), n => n.StudentId == int.Parse(CourseId))
                .ToPageList(PerPageNum, PageSize, ref totalCount);
            return new PageRequest<Entity.InformationManager.Scores> { items = list, TotalCount = totalCount };

        }

        public int UpdateScore(Entity.InformationManager.Scores _score)
        {
            return MySqlHelper<Entity.InformationManager.Scores>.GetInstance().CurrentDb.Update(_score) ? 1 : 0;
        }
    }
}
