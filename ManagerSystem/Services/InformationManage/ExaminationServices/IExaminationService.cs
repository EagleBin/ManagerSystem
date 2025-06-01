using ManagerSystem.Utils.Helper;

namespace ManagerSystem.Services.InformationManage.ExaminationServices
{
    public interface IExaminationService
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public int AddExamination(Entity.InformationManager.Examination examination);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public int DeleteExamination(int id);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public int UpdateExamination(Entity.InformationManager.Examination examination);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Entity.InformationManager.Examination GetExamination(int Id);

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        public PageRequest<Entity.InformationManager.Examination> GetAllExamination();

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="title"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public PageRequest<Entity.InformationManager.Examination> GetExaminations(string? Name, string? ExamStartTime, string? ExamEndTime, int PerPageNum, int PageSize);


        /// <summary>
        /// 根据名称查询
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public Entity.InformationManager.Examination GetExaminationByName(string Name);

    }
}
