
using ManagerSystem.Services;
using ManagerSystem.Services.Departments;
using ManagerSystem.Services.InformationManage.Classes;
using ManagerSystem.Services.InformationManage.Courses;
using ManagerSystem.Services.InformationManage.ExaminationServices;
using ManagerSystem.Services.InformationManage.Grades;
using ManagerSystem.Services.InformationManage.Scores;
using ManagerSystem.Services.InformationManage.Students;
using ManagerSystem.Services.InformationManage.Teachers;
using ManagerSystem.Services.Menus;
using ManagerSystem.Services.Notices;
using ManagerSystem.Services.Posts;
using ManagerSystem.Services.Roles;
using ManagerSystem.Services.Users;

namespace ManagerSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
           

            var builder = WebApplication.CreateBuilder(args);

            //builder.WebHost.UseUrls(new[] { "http://*:7040" });


            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IDepService, DepService>();
            builder.Services.AddScoped<IMenuService, MenuService>();
            builder.Services.AddScoped<IRoleService, RoleService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IPostService,  PostService>();   
            builder.Services.AddScoped<INoticeService,  NoticeService>();   
            builder.Services.AddScoped<IGradeService, GradeService>();
            builder.Services.AddScoped<IClassService, ClassService>();
            builder.Services.AddScoped<ITeacherService, TeacherService>();
            builder.Services.AddScoped<IStudentService, StudentService>();
            builder.Services.AddScoped<ICourseService, CourseService>();
            builder.Services.AddScoped<IScoreService, ScoreService>();
            builder.Services.AddScoped<IExaminationService, ExaminationService>();



        var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }

    }
}
