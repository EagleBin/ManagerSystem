/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:CompanyManagerSystem"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using CommonServiceLocator;
using CompanyManagerSystem.View.subView;
using CompanyManagerSystem.ViewModel.subViewModel;
using CompanyManagerSystem.ViewModel.subViewModel.InformationManager;
using CompanyManagerSystem.ViewModel.subViewModel.SystemManager;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using System.Runtime.InteropServices;

namespace CompanyManagerSystem.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<LoginViewModel>();
            SimpleIoc.Default.Register<HomeViewModel>();
            SimpleIoc.Default.Register<NavigationViewModel>();
            SimpleIoc.Default.Register<PersonalViewModel>();
            SimpleIoc.Default.Register<ClassViewModel>();
            SimpleIoc.Default.Register<CourseViewModel>();
            SimpleIoc.Default.Register<GradeViewModel>();
            SimpleIoc.Default.Register<StudentViewModel>();
            SimpleIoc.Default.Register<DepartmentViewModel>();
            SimpleIoc.Default.Register<PostViewModel>();
            SimpleIoc.Default.Register<UserViewModel>();
            SimpleIoc.Default.Register<RoleViewModel>();
            SimpleIoc.Default.Register<MenuViewModel>();
            SimpleIoc.Default.Register<NoticeViewModel>();
        }

        public NoticeViewModel Notice
        {
            get
            {
                return ServiceLocator.Current.GetInstance<NoticeViewModel>();   
            }
        }

        public MenuViewModel Menu
        {
            get
            {
               return ServiceLocator.Current.GetInstance<MenuViewModel>();
            }
        }

        public RoleViewModel Role
        {
            get
            {
                return ServiceLocator.Current.GetInstance<RoleViewModel>();
            }
        }
        
        public UserViewModel User
        {
            get
            {
                return ServiceLocator.Current.GetInstance<UserViewModel>();
            }
        }

        public PostViewModel Post
        {
            get
            {
                return ServiceLocator.Current.GetInstance<PostViewModel>();
            }
        }
        
        public DepartmentViewModel Department
        {
            get
            {
                return ServiceLocator.Current.GetInstance<DepartmentViewModel>();
            }
        }
                public StudentViewModel Student
        {
            get
            {
                return ServiceLocator.Current.GetInstance<StudentViewModel>();
            }
        }

        public GradeViewModel Grade
        {
            get
            {
                return ServiceLocator.Current.GetInstance<GradeViewModel>();
            }
        }

        public CourseViewModel Course
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CourseViewModel>();
            }
        }

        public ClassViewModel Class
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ClassViewModel>();
            }
        }

        public PersonalViewModel Person
        {
            get
            {
                return ServiceLocator.Current.GetInstance<PersonalViewModel>();
            }
        }

        public NavigationViewModel Navigation
        {
            get
            {
                return ServiceLocator.Current.GetInstance<NavigationViewModel>();
            }
        }

        public HomeViewModel Home
        {
            get
            {
                return ServiceLocator.Current.GetInstance<HomeViewModel>();
            }
        }

        public LoginViewModel Login
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LoginViewModel>();
            }
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public static void Register()
        {
            // TODO Register the ViewModels
            SimpleIoc.Default.Register<NavigationViewModel>();
            SimpleIoc.Default.Register<MainViewModel>();
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
            SimpleIoc.Default.Unregister<NavigationViewModel>();
            SimpleIoc.Default.Unregister<MainViewModel>();
        }
    }
}