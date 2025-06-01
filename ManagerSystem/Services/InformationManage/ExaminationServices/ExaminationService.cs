using ManagerSystem.Data;
using ManagerSystem.Utils.Helper;

namespace ManagerSystem.Services.InformationManage.ExaminationServices
{
    public class ExaminationService : IExaminationService
    {

        public int AddExamination(Entity.InformationManager.Examination grade)
        {
            return MySqlHelper<Entity.InformationManager.Examination>.GetInstance().CurrentDb.AsInsertable(grade).ExecuteReturnIdentity();
        }

        public int DeleteExamination(int id)
        {
            return MySqlHelper<Entity.InformationManager.Examination>.GetInstance().CurrentDb.DeleteById(id) ? 1 : 0;
        }

        public PageRequest<Entity.InformationManager.Examination> GetAllExamination()
        {
            var list = MySqlHelper<Entity.InformationManager.Examination>.GetInstance().CurrentDb.GetListAsync().Result;
            return new PageRequest<Entity.InformationManager.Examination> { items = list, TotalCount = list.Count };

        }

        public Entity.InformationManager.Examination GetExamination(int Id)
        {
            return MySqlHelper<Entity.InformationManager.Examination>.GetInstance().CurrentDb.GetById(Id);
        }

        public PageRequest<Entity.InformationManager.Examination> GetExaminations(string? Name,string? ExamStartTime, string? ExamEndTime,  int PerPageNum, int PageSize)
        {
            int totalCount = 0;
            DateTime StartTime = DateTime.Parse(ExamStartTime ?? DateTime.MinValue.ToShortDateString()).Date;
            DateTime EndTime = DateTime.Parse(ExamEndTime ?? DateTime.MaxValue.ToShortDateString()).Date;
            var list = MySqlHelper<Entity.InformationManager.Examination>.GetInstance().Db.Queryable<Entity.InformationManager.Examination>()
                .WhereIF(!string.IsNullOrEmpty(Name), n => n.Name.Contains(Name ?? ""))
                .WhereIF(!string.IsNullOrEmpty(ExamStartTime), s=>s.ExamTime.Date >= StartTime)
                .WhereIF(!string.IsNullOrEmpty(ExamEndTime), s=>s.ExamTime.Date <= EndTime)
                .ToPageList(PerPageNum, PageSize, ref totalCount);
            return new PageRequest<Entity.InformationManager.Examination> { items = list, TotalCount = totalCount };

        }

        public int UpdateExamination(Entity.InformationManager.Examination _grade)
        {
            return MySqlHelper<Entity.InformationManager.Examination>.GetInstance().CurrentDb.Update(_grade) ? 1 : 0;
        }

        public Entity.InformationManager.Examination GetExaminationByName(string Name)
        {
            return MySqlHelper<Entity.InformationManager.Examination>.GetInstance().CurrentDb.GetSingleAsync(g => g.Name == Name).Result;
        }
    }
}
