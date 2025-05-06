using ManagerSystem.Entity.Dto;
using ManagerSystem.Entity.SystemManager;
using ManagerSystem.Utils.Global;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace ManagerSystem.Utils.Helper
{
    public static class TreeListHelper
    {
        /// <summary>
        /// 刷新菜单列表
        /// </summary>
        public static ObservableCollection<MenuBarModel> RefreshMenulist(List<Menu> allMenuList)
        {
            ObservableCollection<MenuBarModel> MenuList = new ObservableCollection<MenuBarModel>();
            List<Menu> rootMenus = allMenuList.Where(t => t.parent_Id == 0).ToList();
            if (rootMenus.Count == 0 && allMenuList.Count != 0)
            {
                foreach (var ent in allMenuList)
                {
                    MenuBarModel treeNode = new MenuBarModel();
                    treeNode.Menu = ent;
                    treeNode.Menu.Icon = GlobalDic.iconDic[ent.Icon];
                    treeNode.ChildMenuBarModel = GetChildrenTree(ent.Id, allMenuList);
                    treeNode.IsVisibility = treeNode.ChildMenuBarModel.Count == 0 ? Visibility.Collapsed : Visibility.Visible;
                    MenuList.Add(treeNode);
                }
            }
            else if (rootMenus.Count != 0 && allMenuList.Count != 0)
            {
                foreach (var ent in rootMenus)
                {
                    MenuBarModel treeNode = new MenuBarModel();
                    treeNode.Menu = ent;
                    treeNode.Menu.Icon = GlobalDic.iconDic[ent.Icon];
                    treeNode.ChildMenuBarModel = GetChildrenTree(ent.Id, allMenuList);
                    treeNode.IsVisibility = treeNode.ChildMenuBarModel.Count == 0 ? Visibility.Collapsed : Visibility.Visible;
                    MenuList.Add(treeNode);
                }
            }

            return MenuList;
        }

        /// <summary>
        /// 获取当前节点的节点树
        /// </summary>
        /// <param name="curNodeId"></param>
        /// <param name="allNode"></param>
        /// <returns></returns>
        public static List<MenuBarModel> GetChildrenTree(int curNodeId, List<Menu> allNode)
        {
            if (allNode == null || allNode.Count <= 0)
                return new List<MenuBarModel>();

            List<MenuBarModel> TreeList = new List<MenuBarModel>();
            List<Menu> children = allNode.Where(s => s.parent_Id == curNodeId).ToList();
            foreach (var ent in children)
            {
                MenuBarModel treeNode = new MenuBarModel();
                treeNode.Menu = ent;
                treeNode.Menu.Icon = GlobalDic.iconDic[ent.Icon];
                treeNode.ChildMenuBarModel = GetChildrenTree(ent.Id, allNode);
                treeNode.IsVisibility = treeNode.ChildMenuBarModel.Count == 0 ? Visibility.Collapsed : Visibility.Visible;
                TreeList.Add(treeNode);
            }
            return TreeList;
        }

        /// <summary>
        /// 刷新菜单列表
        /// </summary>
        public static ObservableCollection<DepartmentDto> RefreshDeplist(List<Department> allDepartmentList)
        {
            ObservableCollection<DepartmentDto> tempDepartmentList = new ObservableCollection<DepartmentDto>();
            List<Department> rootMenus = allDepartmentList.Where(t => t.parent_id == 0).ToList();
            if (rootMenus.Count == 0 && allDepartmentList.Count != 0)
            {
                foreach (var ent in allDepartmentList)
                {
                    DepartmentDto treeNode = new DepartmentDto();
                    treeNode.Department = ent;
                    treeNode.ChildDepartmentList = GetChildrenTree(ent.Id, allDepartmentList);
                    treeNode.IsVisibility = treeNode.ChildDepartmentList.Count == 0 ? Visibility.Collapsed : Visibility.Visible;
                    tempDepartmentList.Add(treeNode);
                }
            }
            else if (rootMenus.Count != 0 && allDepartmentList.Count != 0)
            {
                foreach (var ent in rootMenus)
                {
                    DepartmentDto treeNode = new DepartmentDto();
                    treeNode.Department = ent;
                    treeNode.ChildDepartmentList = GetChildrenTree(ent.Id, allDepartmentList);
                    treeNode.IsVisibility = treeNode.ChildDepartmentList.Count == 0 ? Visibility.Collapsed : Visibility.Visible;
                    tempDepartmentList.Add(treeNode);
                }
            }
            return tempDepartmentList;
        }
        /// <summary>
        /// 获取当前节点的节点树
        /// </summary>
        /// <param name="curNodeId"></param>
        /// <param name="allNode"></param>
        /// <returns></returns>
        public static List<DepartmentDto> GetChildrenTree(int curNodeId, List<Department> allNode)
        {
            if (allNode == null || allNode.Count <= 0)
                return new List<DepartmentDto>();

            List<DepartmentDto> TreeList = new List<DepartmentDto>();
            List<Department> children = allNode.Where(s => s.parent_id == curNodeId).ToList();
            foreach (var ent in children)
            {
                DepartmentDto treeNode = new DepartmentDto();
                treeNode.Department = ent;
                treeNode.ChildDepartmentList = GetChildrenTree(ent.Id, allNode);
                treeNode.IsVisibility = treeNode.ChildDepartmentList.Count == 0 ? Visibility.Collapsed : Visibility.Visible;
                TreeList.Add(treeNode);
            }
            return TreeList;
        }
    }
}
