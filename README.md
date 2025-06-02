# ManagerSystem

#### 介绍
仿照若依管理系统界面进行界面设计，使用WPF+HandyControl+LiveCharts.WPF+MvvmLight编写的后台管理系统

#### 项目模块
- 1. **CompanyManagerSystem**：核心的管理系统项目，包含了应用程序的配置文件、界面相关的 XAML 文件和对应的 C# 代码文件。
    - App.config 和 App.xaml 以及 App.xaml.cs 是应用程序的入口和配置文件。
    - Themes 文件夹包含了界面样式的定义，如 PasswordBox.xaml、ListBox.xaml 和 CheckComboBox.xaml 等，用于定制控件的外观。
    - View 和 ViewModel 文件夹用于实现 MVVM 模式，分别存放视图和视图模型的代码。
- 2. **ManagerSystem.Entity**：这个项目主要负责实体相关的操作，包含数据传输对象（DTO）和系统管理相关的模型。
    - Dto 文件夹存放数据传输对象的定义。
- 3. **SystemManager**： 整个系统的WeP.API文件,负责处理业务逻辑和对外提供接口服务。 
    - Controllers 文件夹：包含多个控制器类，用来处理不同业务模块的HTTP请求。例如DepartmentController 控制器，用于处理部门信息的增删改查操作的接口。
    - Services 文件夹：包含多个服务类，用来负责具体的业务逻辑处理，这些服务类实现了相应的接口，例如：DepService 实现了 IDepService 接口，处理部门的数据库操作。
    - Data 文件夹：包含数据访问相关的类，例如MySqlHelper.cs，用于与数据库进行交互。
- 4. **ManagerSystem.Utils**：该项目提供了一些工具类和辅助功能，如转换器、全局设置和 HTTP 工具等。
    - Converter 文件夹存放数据转换器的实现。
    - HttpUtil.cs 是用于处理 HTTP 请求的工具类。


#### 安装教程

1.  导入mysql数据库文件，在ManagerSystem项目（API）中配置连接数据库。
2.  打开整个解决方案，将ManagerSystem项目设为启动项，启动后在浏览器的网站中获取端口（如5244）， 结束程序，在ManagerSystem.Utils项目中找到HttpUtil.cs文件，将获取到的端口替换掉absoluteUrl变量中的端口号。
3.  启动ManagerSystem项目(API)，然后启动CompanyManagerSystem项目(WPF)。

#### 项目截图

1.  登录界面
[![pV95A1K.png](https://s21.ax1x.com/2025/06/01/pV95A1K.png)](https://imgse.com/i/pV95A1K)
2.  登陆成功首页
[![pV95VXD.png](https://s21.ax1x.com/2025/06/01/pV95VXD.png)](https://imgse.com/i/pV95VXD)
3.  用户管理页面
[![pV95m0H.png](https://s21.ax1x.com/2025/06/01/pV95m0H.png)](https://imgse.com/i/pV95m0H)

#### 使用说明

1.  对于信息管理菜单，主要是对教师与学生信息进行管理。需要依次按照顺序进行数据插入，必须先存在“年级(Grade)”->“科目(Course)”->“教师(Teacher)”->“班级(Class)”->“学生(Student)”->“考次(Examination)”->“成绩(Course)”
2. 系统管理，主要是对用户，以及用户的权限，界面菜单，公告管理，部门管理，岗位管理的信息进行设置。
3.  首页部分数据绑定尚未完善。
4.  Teacher_Course表数据部分缺失，对于插入“成绩”数据存在影响。
5. 用户权限修改存在部分错误。

#### 后续

- github: https://github.com/EagleBin/ManagerSystem
- blog: https://eaglebin.github.io/

