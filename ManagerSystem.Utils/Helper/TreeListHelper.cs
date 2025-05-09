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
            List<Menu> rootMenus = allMenuList.Where(t => t.parent_Id == 0).ToList(); // 获取根节点
            if (rootMenus.Count == 0 && allMenuList.Count != 0)
            {
                // 遍历所有菜单列表
                foreach (var ent in allMenuList)
                {
                    MenuBarModel treeNode = new MenuBarModel();
                    treeNode.Menu = ent;  // 菜单
                    treeNode.Menu.Icon = GlobalDic.iconDic[ent.Icon]; // 图标
                    treeNode.ChildMenuBarModel = GetChildrenTree(ent.Id, allMenuList); // 子菜单列表
                    treeNode.IsVisibility = treeNode.ChildMenuBarModel.Count == 0 ? Visibility.Collapsed : Visibility.Visible;
                    MenuList.Add(treeNode);
                }
            }
            else if (rootMenus.Count != 0 && allMenuList.Count != 0)
            {
                // 遍历根节点
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
            // 总数小于等于0，往下没有菜单了
            if (allNode == null || allNode.Count <= 0)
                return new List<MenuBarModel>();

            List<MenuBarModel> TreeList = new List<MenuBarModel>();
            // 获取当前节点的子节点菜单列表，根据当前节点的id查找
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
        /// 将传进来的部门转换成树状结构的部门数据
        /// </summary>
        /// <param name="allDepartmentList">所有部门的数据列表</param>
        /// <returns></returns>
        public static ObservableCollection<DepartmentDto> RefreshDeplist(List<Department> allDepartmentList)
        {
            ObservableCollection<DepartmentDto> tempDepartmentList = new ObservableCollection<DepartmentDto>();  // 存储转换后的树形结构数据
            List<Department> rootDep = allDepartmentList.Where(t => t.parent_id == 0).ToList(); // 筛选出所有根部门
            // 没有根部门
            if (rootDep.Count == 0 && allDepartmentList.Count != 0)
            {
                // 将每个部门设置为根部门，并为其添加子部门
                foreach (var ent in allDepartmentList)
                {
                    DepartmentDto treeNode = new DepartmentDto();
                    treeNode.Department = ent;
                    treeNode.ChildDepartmentList = GetChildrenTree(ent.Id, allDepartmentList);
                    treeNode.IsVisibility = treeNode.ChildDepartmentList.Count == 0 ? Visibility.Collapsed : Visibility.Visible;
                    tempDepartmentList.Add(treeNode);
                }
            }
            // 递归每个根部门，并构建每个根部门的子部门树
            else if (rootDep.Count != 0 && allDepartmentList.Count != 0)
            {
                foreach (var ent in rootDep)
                {
                    DepartmentDto treeNode = new DepartmentDto();
                    treeNode.Department = ent;
                    treeNode.ChildDepartmentList = GetChildrenTree(ent.Id, allDepartmentList); // 递归获取当前部门的所有子部门
                    treeNode.IsVisibility = treeNode.ChildDepartmentList.Count == 0 ? Visibility.Collapsed : Visibility.Visible;
                    tempDepartmentList.Add(treeNode);
                }
            }
            return tempDepartmentList;
        }
        /// <summary>
        /// 获取当前节点的节点树（筛选出 parent_id 等于当前部门 ID 的所有子部门。）
        /// </summary>
        /// <param name="curNodeId">部门 ID</param>
        /// <param name="allNode">所有部门列表</param>
        /// <returns></returns>
        public static List<DepartmentDto> GetChildrenTree(int curNodeId, List<Department> allNode)
        {
            if (allNode == null || allNode.Count <= 0)
                return new List<DepartmentDto>();

            List<DepartmentDto> TreeList = new List<DepartmentDto>();
            List<Department> children = allNode.Where(s => s.parent_id == curNodeId).ToList(); // 获取当前节点的子部门
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
