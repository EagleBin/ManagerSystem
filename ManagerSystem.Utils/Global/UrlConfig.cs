
namespace ManagerSystem.Utils.Global
{
    /// <summary>
    /// 全局API接口地址
    /// </summary>
    public class UrlConfig
    {
        //用户
        public static string USER_GETAllUSER = "api/User/GetAllUser";

        public static string USER_GETUSERS = "api/User/GetUsers";

        public static string USER_GETUSERROLE = "api/User/GetUserRole";

        public static string USER_ADDUSERROLE = "api/User/AddUserRole";

        public static string USER_ADDUSERPOST = "api/User/AddUserPost";

        public static string USER_DELETEUSERROLE = "api/User/DeleteUserRole";

        public static string USER_GETUSERPOST = "api/User/GetUserPost";

        public static string USER_EXISTACCOUNT = "api/User/ExistAccount";

        public static string USER_GETLOGINUSER = "api/User/GetLoginUser";

        public static string USER_ADDUSER = "api/User/AddUser";

        public static string USER_UPDATEUSER = "api/User/UpdateUser";

        public static string USER_DELETEUSER = "api/User/DeleteUser";

        public static string USER_GETUSER = "api/User/GetUser";

        //权限
        public static string ROLE_GETAllROLE = "api/Role/GetAllRole";

        public static string ROLE_GETROLES = "api/Role/GetRoles";

        public static string ROLE_GETROLEMENU = "api/Role/GetRoleMenu";

        public static string ROLE_ADDROLEMENU = "api/Role/AddRoleMenu";

        public static string USER_DELETEROLEMENU = "api/Role/DeleteRoleMenu";

        public static string ROLE_EXISTROLENAME = "api/Role/ExistRoleName";

        public static string ROLE_ADDROLE = "api/Role/AddRole";

        public static string ROLE_UPDATEROLE = "api/Role/UpdateRole";

        public static string ROLE_DELETEROLE = "api/Role/DeleteRole";

        public static string ROLE_GETROLE = "api/Role/GetRole";

        //菜单
        public static string MENU_GETAllMENU = "api/Menu/GetAllMenu";

        public static string MENU_GETMENUS = "api/Menu/GetMenus";

        public static string MENU_ADDMENU = "api/Menu/AddMenu";

        public static string MENU_UPDATEMENU = "api/Menu/UpdateMenu";

        public static string MENU_DELETEMENU = "api/Menu/DeleteMenu";

        public static string MENU_GETMENU = "api/Menu/GetMenu";

        //部门
        public static string DEP_GETAllDEP = "api/Department/GetAllDepartment";

        public static string DEP_GETDEPS = "api/Department/GetDepartments";

        public static string DEP_ADDDEP = "api/Department/AddDepartment";

        public static string DEP_UPDATEDEP = "api/Department/UpdateDepartment";

        public static string DEP_DELETEDEP = "api/Department/DeleteDepartment";

        public static string DEP_GETDEP = "api/Department/GetDepartment";

        //岗位
        public static string POST_GETAllPOST = "api/Post/GetAllPost";

        public static string POST_GETPOSTS = "api/Post/GetPosts";

        public static string POST_ADDPOST = "api/Post/AddPost";

        public static string POST_UPDATEPOST = "api/Post/UpdatePost";

        public static string POST_DELETEPOST = "api/Post/DeletePost";

        public static string POST_GETPOST = "api/Post/GetPost";
    }
}
