using ManagerSystem.Data;
using ManagerSystem.Entity.SystemManager;
using ManagerSystem.Utils.Helper;
using MySqlConnector;

namespace ManagerSystem.Services.Users
{
    public class UserService : IUserService
    {
        public int AddUser(User user)
        {
            return MySqlHelper<User>.GetInstance().CurrentDb.Insert(user) ? 1 : 0;
        }

        public int AddUserPost(UserPost userPost)
        {
            userPost.insertTime = DateTime.Now;
            return MySqlHelper<UserPost>.GetInstance().CurrentDb.Insert(userPost) ? 1 : 0;
        }

        public int AddUserRole(UserRole userRole)
        {
            return MySqlHelper<UserRole>.GetInstance().CurrentDb.Insert(userRole) ? 1 : 0;
        }

        public int DeleteUser(int id)
        {
            return MySqlHelper<Role>.GetInstance().CurrentDb.DeleteById(id) ? 1 : 0;
        }

        public int DeleteUserRole(int user_id, int role_id)
        {
            return MySqlHelper<UserRole>.GetInstance().Db.Deleteable<UserRole>().
                Where(ur => ur.role_Id == role_id && ur.user_Id == user_id).ExecuteCommand();
        }

        public int ExistAccount(string account)
        {
            return MySqlHelper<User>.GetInstance().CurrentDb.GetSingleAsync(t => t.Account == account).Result != null ? 1 : 0;
        }

        public PageRequest<User> GetAllUser()
        {
            List<User> users = MySqlHelper<User>.GetInstance().CurrentDb.GetListAsync().Result;
            return new PageRequest<User> { items = users, TotalCount = users.Count };
        }

        public int GetLoginUser(string Account, string Password)
        {
            return MySqlHelper<User>.GetInstance().CurrentDb.GetSingleAsync(t => t.Account == Account && t.Password == Password).Result != null ? 1 : 0;
        }

        public User GetUser(int id)
        {
            return MySqlHelper<User>.GetInstance().CurrentDb.GetById(id);
        }

        public PageRequest<Post> GetUserPost(int id)
        {
            List<Post> posts = MySqlHelper<User>.GetInstance().Db.Queryable<UserPost>().LeftJoin<Post>((up, p) => up.post_Id == p.Id).Where(up => up.user_Id == id).Select((up, p) => p).ToList();
            return new PageRequest<Post>() { TotalCount = posts.Count, items = posts };
        }

        public PageRequest<Role> GetUserRole(int id)
        {
            List<Role> roles = MySqlHelper<User>.GetInstance().Db.Queryable<UserRole>().
                LeftJoin<Role>((ur, r) => ur.user_Id == r.Id).
                Where(ur => ur.user_Id == id).
                Select((ur, r) => r).ToList();
            return new PageRequest<Role>() { TotalCount = roles.Count, items = roles };
        }

        public PageRequest<User> GetUsers(string? account, string? phoneNum, string? status, string? startDate, string? endDate, int pageNum, int pageSize, int depId)
        {
            int TotalCount = 0;
            DateTime StartDate = DateTime.Parse(startDate ?? DateTime.MinValue.ToShortDateString()).Date;
            DateTime EndDate = DateTime.Parse(endDate ?? DateTime.MaxValue.ToShortDateString()).Date;

            //获取depId所有的下属部门
            List<Department> departmentList = MySqlHelper<Department>.GetInstance().Db.Queryable<Department>().ToChildList(t => t.parent_id, depId);
            List<User> users = MySqlHelper<User>.GetInstance().Db.Queryable<User>()
                .WhereIF(departmentList != null && departmentList.Count > 0, t => departmentList.Any(r => t.dep_id == r.Id))
                .WhereIF(!string.IsNullOrEmpty(account), t => t.Account.Contains(account ?? ""))
                .WhereIF(!string.IsNullOrEmpty(phoneNum), t => t.PhoneNum.Contains(phoneNum ?? ""))
                .WhereIF(!string.IsNullOrEmpty(status), t => t.Status == ((status ?? "").Contains("启用") ? true : false))
                .WhereIF(!string.IsNullOrEmpty(startDate), t => t.insertTime.Date >= StartDate)
                .WhereIF(!string.IsNullOrEmpty(endDate), t => t.insertTime.Date <= EndDate)
                .ToPageList((int)pageNum, (int)pageSize, ref TotalCount);

            //List<User> users = MySQLHelper<User>.GetInstance().Db.Queryable<User>().ToPageList(pageNum, pageSize, ref TotalCount);
            return new PageRequest<User>() { TotalCount = TotalCount, items = users };
        }

        public int UpdateUser(User user)
        {
            return MySqlHelper<User>.GetInstance().CurrentDb.Update(user) ? 1 : 0;
        }
    }
}
