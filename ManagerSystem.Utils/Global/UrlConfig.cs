
namespace ManagerSystem.Utils.Global
{
    /// <summary>
    /// 全局API接口地址
    /// </summary>
    public class UrlConfig
    {

        //用户
        #region 用户 

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

        #endregion


        //权限
        #region 权限

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

        #endregion

        //菜单
        #region 菜单

        public static string MENU_GETAllMENU = "api/Menu/GetAllMenu";

        public static string MENU_GETMENUS = "api/Menu/GetMenus";

        public static string MENU_ADDMENU = "api/Menu/AddMenu";

        public static string MENU_UPDATEMENU = "api/Menu/UpdateMenu";

        public static string MENU_DELETEMENU = "api/Menu/DeleteMenu";

        public static string MENU_GETMENU = "api/Menu/GetMenu";

        #endregion


        //部门
        #region 部门

        public static string DEP_GETAllDEP = "api/Department/GetAllDepartment";

        public static string DEP_GETDEPS = "api/Department/GetDepartments";

        public static string DEP_ADDDEP = "api/Department/AddDepartment";

        public static string DEP_UPDATEDEP = "api/Department/UpdateDepartment";

        public static string DEP_DELETEDEP = "api/Department/DeleteDepartment";

        public static string DEP_GETDEP = "api/Department/GetDepartment";

        #endregion


        //岗位
        #region 岗位

        public static string POST_GETAllPOST = "api/Post/GetAllPost";

        public static string POST_GETPOSTS = "api/Post/GetPosts";

        public static string POST_ADDPOST = "api/Post/AddPost";

        public static string POST_UPDATEPOST = "api/Post/UpdatePost";

        public static string POST_DELETEPOST = "api/Post/DeletePost";

        public static string POST_GETPOST = "api/Post/GetPost";

        #endregion


        // 公告
        #region 公告

        public static string NoTICE_GETNOTICE = "api/Notice/GetNotice";

        public static string NOTICE_GETNOTICES = "api/Notice/GetNotices";

        public static string NoTICE_GETALLNOTICE = "api/Notice/GetAllNotice";

        public static string NOTICE_ADDNOTICE = "api/Notice/AddNotice";

        public static string NoTICE_UPDATENOTICE = "api/Notice/UpdateNotice";

        public static string NoTICE_DELETENOTICE = "api/Notice/DeleteNotice";


        #endregion

        // 学生
        #region 学生

        public static string STU_GETAllSTU = "api/Student/GetAllStudent";

        public static string STU_GETSTUS = "api/Student/GetStudents";

        public static string STU_ADDSTU = "api/Student/AddStudent";

        public static string STU_UPDATESTU = "api/Student/UpdateStudent";

        public static string STU_DELETESTU = "api/Student/DeleteStudent";

        public static string STU_GETSTU = "api/Student/GetStudent";


        #endregion

        // 教师
        #region 教师

        public static string TEA_GETAllTEA = "api/Teacher/GetAllTeacher";

        public static string TEA_GETTEAS = "api/Teacher/GetTeachers";

        public static string TEA_ADDTEA = "api/Teacher/AddTeacher";

        public static string TEA_UPDATETEA = "api/Teacher/UpdateTeacher";

        public static string TEA_DELETETEA = "api/Teacher/DeleteTeacher";

        public static string TEA_GETTEA = "api/Teacher/GetTeacher";

        #endregion

        // 班级
        #region 班级

        public static string CLA_GETAllCLA = "api/Class/GetAllClass";
                             
        public static string CLA_GETCLAS = "api/Class/GetClasss";
                             
        public static string CLA_ADDCLA = "api/Class/AddClass";

        public static string CLA_ADDTEACLA = "api/Class/AddTeachers_Classes";
                             
        public static string CLA_UPDATECLA = "api/Class/UpdateClass";
                             
        public static string CLA_DELETECLA = "api/Class/DeleteClass";
                             
        public static string CLA_GETCLA = "api/Class/GetClass";



        #endregion

        // 年级
        #region 年级

        public static string GRA_GETAllGRA = "api/Grade/GetAllGrade";

        public static string GRA_GETGRAS = "api/Grade/GetGrades";

        public static string GRA_ADDGRA = "api/Grade/AddGrade";

        public static string GRA_UPDATEGRA = "api/Grade/UpdateGrade";

        public static string GRA_DELETEGRA = "api/Grade/DeleteGrade";

        public static string GRA_GETGRA = "api/Grade/GetGrade";

        public static string GRA_GETGRACLA = "api/Grade/GetGradeClass";

        public static string GRA_ExistName = "api/Grade/ExistName";

        #endregion

        // 课程
        #region 课程

        public static string COURSE_GETAllCOURSE = "api/Course/GetAllCourse";

        public static string COURSE_GETCOURSES = "api/Course/GetCourses";

        public static string COURSE_GETCOURSESTEA = "api/Course/GetCourses_Teachers";

        public static string COURSE_ADDCOURSE = "api/Course/AddCourse";

        public static string COURSE_UPDATECOURSE = "api/Course/UpdateCourse";

        public static string COURSE_DELETECOURSE = "api/Course/DeleteCourse";

        public static string COURSE_GETCOURSE = "api/Course/GetCourse";

        #endregion

        // 分数
        #region 分数

        public static string SCO_GETAllSCO = "api/Score/GetAllScore";

        public static string SCO_GETSCOS = "api/Score/GetScores";

        public static string SCO_ADDSCO = "api/Score/AddScore";

        public static string SCO_ADDCOUSCO = "api/Score/AddCOUScore";

        public static string SCO_UPDATESCO = "api/Score/UpdateScore";

        public static string SCO_DELETESCO = "api/Score/DeleteScore";

        public static string SCO_GETSCO = "api/Score/GetScore";


        #endregion

    }
}
