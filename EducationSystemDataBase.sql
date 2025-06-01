
/*
 Navicat Premium Data Transfer

 Source Server         : MYSQL
 Source Server Type    : MySQL
 Source Server Version : 50726
 Source Host           : localhost:3306
 Source Schema         : managersystem

 Target Server Type    : MySQL
 Target Server Version : 50726
 File Encoding         : 65001

 Date: 05/18/2025 11:37:00
*/

use educationsysytem ;

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for department
-- ----------------------------
DROP TABLE IF EXISTS `department`;
CREATE TABLE `department`  (
  `id` int(11) NOT NULL AUTO_INCREMENT COMMENT '自增主键',
  `DepName` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '部门名称',
  `DepHead` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL COMMENT '部门负责人',
  `DepPhoneNum` varchar(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL COMMENT '联系电话',
  `DepMail` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL COMMENT '邮箱',
  `parent_id` int(11) NOT NULL COMMENT '父级菜单',
  `Status` tinyint(2) NOT NULL COMMENT '菜单状态 0：禁用，1启用',
  `Description` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL COMMENT '描述',
  `insertTime` timestamp NULL DEFAULT '2023-01-01 00:00:01' COMMENT '注册时间',
  `lastModified` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '最后修改时间',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 10 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of department
-- ----------------------------
INSERT INTO `department` VALUES (1, '和隆优化', '张三', '2131312', '23232@qq.com', 0, 1, NULL, '2023-01-01 00:00:01', '2023-01-01 00:00:01');
INSERT INTO `department` VALUES (2, '北京分公司', '李四', '3243223', '32432432@qq.com', 1, 1, NULL, '2023-01-01 00:00:01', '2023-01-01 00:00:01');
INSERT INTO `department` VALUES (3, '南京分公司', '王五', '321424232', '213131312@qq.com', 1, 1, NULL, '2024-03-14 15:27:35', '2024-03-14 15:27:35');
INSERT INTO `department` VALUES (4, '研发部门', '赵六', '321424232', '213131312@qq.com', 2, 1, NULL, '2024-03-14 15:28:59', '2024-03-14 15:28:59');
INSERT INTO `department` VALUES (5, '销售部门', '赵六', '321424232', '213131312@qq.com', 2, 1, NULL, '2024-03-14 15:28:59', '2024-03-14 15:28:59');
INSERT INTO `department` VALUES (6, '工程部门', '赵六', '321424232', '213131312@qq.com', 2, 1, NULL, '2024-03-14 15:28:59', '2024-03-14 15:28:59');
INSERT INTO `department` VALUES (7, '研发部门', '孙七', '321424232', '213131312@qq.com', 3, 1, NULL, '2024-03-14 15:29:17', '2024-03-14 15:29:17');
INSERT INTO `department` VALUES (8, '销售部门', '孙七', '321424232', '213131312@qq.com', 3, 1, NULL, '2024-03-14 15:29:17', '2024-03-14 15:29:17');
INSERT INTO `department` VALUES (9, '工程部门', '孙七', '321424232', '213131312@qq.com', 3, 1, NULL, '2024-03-14 15:29:17', '2024-03-14 15:29:17');

-- ----------------------------
-- Table structure for menu
-- ----------------------------
DROP TABLE IF EXISTS `menu`;
CREATE TABLE `menu`  (
  `id` int(11) NOT NULL AUTO_INCREMENT COMMENT '自增主键',
  `Title` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '菜单名称',
  `NameSpace` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '菜单路径',
  `Icon` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '菜单图标',
  `parent_id` int(11) NOT NULL COMMENT '父级菜单',
  `Status` tinyint(2) NOT NULL COMMENT '菜单状态 0：禁用，1启用',
  `insertTime` timestamp NULL DEFAULT '2023-01-01 00:00:01' COMMENT '注册时间',
  `lastModified` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '最后修改时间',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 14 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of menu
-- ----------------------------
INSERT INTO `menu` VALUES (1, '信息管理', '', 'ue615', 0, 1, '2024-03-01 14:20:25', '2024-03-15 17:28:52');
INSERT INTO `menu` VALUES (2, '学生管理', 'InformationManager.StudentView', 'ue67d', 1, 1, '2024-03-01 14:21:41', '2024-03-15 17:28:52');
INSERT INTO `menu` VALUES (3, '年级管理', 'InformationManager.GradeView', 'ue661', 1, 1, '2024-03-01 14:21:41', '2024-03-15 17:28:52');
INSERT INTO `menu` VALUES (4, '班级管理', 'InformationManager.ClassView', 'ue661', 1, 1, '2024-03-01 14:22:02', '2024-03-15 17:28:52');
INSERT INTO `menu` VALUES (5, '课程管理', 'InformationManager.CourseView', 'ue61f', 1, 1, '2024-03-01 14:23:23', '2024-03-15 17:28:52');
INSERT INTO `menu` VALUES (6, '成绩管理', 'InformationManager.ScoreView', 'ue601', 1, 1, '2024-03-01 14:23:37', '2024-03-15 17:28:52');
INSERT INTO `menu` VALUES (7, '教师管理', 'InformationManager.TeacherView', 'ue63b', 1, 1, '2024-03-01 14:23:37', '2024-03-15 17:28:52');

update menu set NameSpace = 'InformationManager.TeacherView' where id = 7; 

INSERT INTO `menu` VALUES (8, '系统管理', '', 'ue60d', 0, 1, '2024-03-01 14:24:30', '2024-03-15 17:28:52');
INSERT INTO `menu` VALUES (9, '用户管理', 'SystemManager.UserView', 'ue63b', 8, 1, '2024-03-01 14:24:52', '2024-03-15 17:28:52');
INSERT INTO `menu` VALUES (10, '角色管理', 'SystemManager.RoleView', 'ue62a', 8, 1, '2024-03-01 14:25:10', '2024-03-15 17:28:52');
INSERT INTO `menu` VALUES (11, '菜单管理', 'SystemManager.MenuView', 'ue654', 8, 1, '2024-03-01 14:25:26', '2024-03-15 17:28:52');
INSERT INTO `menu` VALUES (12, '部门管理', 'SystemManager.DepartmentView', 'ue61e', 8, 1, '2024-03-01 14:25:42', '2024-03-15 17:28:52');
INSERT INTO `menu` VALUES (13, '公告管理', 'SystemManager.NoticeView', 'ue649', 8, 1, '2024-03-01 14:26:24', '2024-03-21 13:56:01');
INSERT INTO `menu` VALUES (14, '日志管理', 'SystemManager.LogView', 'ue63e', 8, 1, '2024-03-01 14:26:56', '2024-03-21 13:55:52');
INSERT INTO `menu` VALUES (15, '岗位管理', 'SystemManager.PostView', 'ue61e', 8, 1, '2023-01-01 00:00:01', '2024-03-21 13:56:55');

-- ----------------------------
-- Table structure for post
-- ----------------------------
DROP TABLE IF EXISTS `post`;
CREATE TABLE `post`  (
  `id` int(11) NOT NULL AUTO_INCREMENT COMMENT '自增主键',
  `PostName` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '岗位名称',
  `Status` tinyint(2) NULL DEFAULT NULL COMMENT '岗位状态 0：禁用，1启用',
  `Description` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL COMMENT '描述',
  `insertTime` timestamp NULL DEFAULT '2023-01-01 00:00:01' COMMENT '注册时间',
  `lastModified` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '最后修改时间',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 5 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of post
-- ----------------------------
INSERT INTO `post` VALUES (1, '董事长', 1, 'ceo', '2023-01-01 00:00:01', '2024-03-21 13:50:13');
INSERT INTO `post` VALUES (2, '项目经理', 1, 'se', '2023-01-01 00:00:01', '2024-03-21 13:50:25');
INSERT INTO `post` VALUES (3, '人力资源', 1, 'hr', '2023-01-01 00:00:01', '2024-03-21 13:50:35');
INSERT INTO `post` VALUES (4, '普通员工', 1, 'user', '2023-01-01 00:00:01', '2024-03-21 13:50:44');

-- ----------------------------
-- Table structure for role
-- ----------------------------
DROP TABLE IF EXISTS `role`;
CREATE TABLE `role`  (
  `id` int(11) NOT NULL AUTO_INCREMENT COMMENT '自增主键',
  `RoleName` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '角色名称',
  `Status` tinyint(2) NULL DEFAULT NULL COMMENT '角色状态 0：禁用，1启用',
  `Description` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL COMMENT '描述',
  `insertTime` timestamp NULL DEFAULT '2023-01-01 00:00:01' COMMENT '注册时间',
  `lastModified` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '最后修改时间',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 3 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of role
-- ----------------------------
INSERT INTO `role` VALUES (1, '超级管理员', 1, '超级管理员', '2023-01-01 00:00:01', '2024-03-17 00:00:01');
INSERT INTO `role` VALUES (2, '普通用户', 1, '欧通用户', '2023-01-01 00:00:01', '2024-03-18 00:00:01');

-- ----------------------------
-- Table structure for role_menu
-- ----------------------------
DROP TABLE IF EXISTS `role_menu`;
CREATE TABLE `role_menu`  (
  `id` int(11) NOT NULL AUTO_INCREMENT COMMENT '自增主键',
  `role_id` int(11) NOT NULL COMMENT '角色id',
  `menu_id` int(11) NOT NULL COMMENT '菜单id',
  `insertTime` timestamp NULL DEFAULT '2023-01-01 00:00:01' COMMENT '注册时间',
  `lastModified` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '最后修改时间',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 18 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Fixed;

-- ----------------------------
-- Records of role_menu
-- ----------------------------
INSERT INTO `role_menu` VALUES (1, 1, 1, '2024-03-18 13:47:04', '2024-03-18 13:47:04');
INSERT INTO `role_menu` VALUES (2, 1, 2, '2024-03-18 13:47:18', '2024-03-18 13:47:18');
INSERT INTO `role_menu` VALUES (3, 1, 3, '2024-03-18 13:47:20', '2024-03-18 13:47:20');
INSERT INTO `role_menu` VALUES (4, 1, 4, '2024-03-18 13:47:22', '2024-03-18 13:47:22');
INSERT INTO `role_menu` VALUES (5, 1, 5, '2024-03-18 13:47:25', '2024-03-18 13:47:25');
INSERT INTO `role_menu` VALUES (6, 1, 6, '2024-03-18 13:47:27', '2024-03-18 13:47:27');
INSERT INTO `role_menu` VALUES (7, 1, 7, '2024-03-18 13:47:40', '2024-03-18 13:47:40');
INSERT INTO `role_menu` VALUES (8, 1, 8, '2024-03-18 13:47:52', '2024-03-18 13:47:52');
INSERT INTO `role_menu` VALUES (9, 1, 9, '2024-03-18 13:47:54', '2024-03-18 13:47:54');
INSERT INTO `role_menu` VALUES (10, 1, 10, '2024-03-18 13:47:58', '2024-03-18 13:47:58');
INSERT INTO `role_menu` VALUES (11, 1, 11, '2024-03-18 13:48:00', '2024-03-18 13:48:00');
INSERT INTO `role_menu` VALUES (12, 1, 12, '2024-03-18 13:48:02', '2024-03-18 13:48:02');
INSERT INTO `role_menu` VALUES (13, 2, 1, '2024-03-18 13:48:32', '2024-03-18 13:48:32');
INSERT INTO `role_menu` VALUES (14, 2, 2, '2024-03-18 13:48:34', '2024-03-18 13:48:34');
INSERT INTO `role_menu` VALUES (15, 2, 3, '2024-03-18 13:48:35', '2024-03-18 13:48:35');
INSERT INTO `role_menu` VALUES (16, 2, 4, '2024-03-18 13:48:38', '2024-03-18 13:48:38');
INSERT INTO `role_menu` VALUES (17, 2, 5, '2024-03-18 13:48:40', '2024-03-18 13:48:40');
INSERT INTO `role_menu` VALUES (18, 1, 13, '2024-03-18 13:48:40', '2024-03-18 13:48:40');
INSERT INTO `role_menu` VALUES (19, 1, 14, '2024-03-18 13:48:40', '2024-03-18 13:48:40');
INSERT INTO `role_menu` VALUES (20, 1, 15, '2024-03-18 13:48:40', '2024-03-18 13:48:40');

-- ----------------------------
-- Table structure for user
-- ----------------------------
DROP TABLE IF EXISTS `user`;
CREATE TABLE `user`  (
  `id` int(11) NOT NULL AUTO_INCREMENT COMMENT '自增主键',
  `Account` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '用户账号',
  `Password` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '用户密码',
  `UserName` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '用户昵称',
  `PhoneNum` varchar(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL COMMENT '手机号码',
  `Gender` varchar(2) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL COMMENT '性别',
  `Mail` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL COMMENT '邮箱',
  `Status` tinyint(2) NULL DEFAULT NULL COMMENT '用户状态 0：禁用，1启用',
  `Description` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL COMMENT '描述',
  `dep_id` int(11) NULL DEFAULT NULL COMMENT '用户所属部门id',
  `insertTime` timestamp NULL DEFAULT '2023-01-01 00:00:01' COMMENT '注册时间',
  `lastModified` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '最后修改时间',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 56 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of user
-- ----------------------------
INSERT INTO `user` VALUES (1, 'admin', 'admin', '超级管理员', '18834170000', '男', '1092793@qq.com', 1, '超级管理员账号', 1, '2024-03-01 14:14:52', '2024-03-21 17:04:20');
INSERT INTO `user` VALUES (3, 'user1', '123456', '普通用户', '3241431241', '女', '2141423@qq.com', 1, '测试员1', 6, '2024-03-01 14:15:20', '2024-03-21 17:04:17');
INSERT INTO `user` VALUES (4, 'user2', '123456', '普通用户', '3241431241', '男', '2141423@qq.com', 1, '测试员1', 6, '2024-03-01 14:15:24', '2024-03-21 17:04:17');
INSERT INTO `user` VALUES (5, 'user3', '123456', '普通用户', '3241431241', '女', '2141423@qq.com', 1, '测试员1', 6, '2024-03-01 14:15:31', '2024-03-21 17:04:17');
INSERT INTO `user` VALUES (6, 'user4', '123456', '普通用户', '3241431241', '女', '2141423@qq.com', 1, '测试员1', 6, '2024-03-01 14:15:33', '2024-03-21 17:04:17');
INSERT INTO `user` VALUES (7, 'user5', '123456', '普通用户', '3241431241', '女', '2141423@qq.com', 1, '测试员1', 6, '2024-03-01 14:15:35', '2024-03-21 17:04:17');
INSERT INTO `user` VALUES (8, 'user6', '123456', '普通用户', '3241431241', '女', '2141423@qq.com', 1, '测试员1', 6, '2024-03-01 14:15:38', '2024-03-21 17:04:17');
INSERT INTO `user` VALUES (9, 'user7', '123456', '普通用户', '3241431241', '女', '2141423@qq.com', 0, '测试员1', 6, '2024-03-01 14:15:40', '2024-03-21 17:04:17');
INSERT INTO `user` VALUES (10, 'user8', '123456', '普通用户', '3241431241', '男', '2141423@qq.com', 0, '测试员1', 6, '2024-03-01 14:15:44', '2024-03-21 17:04:17');
INSERT INTO `user` VALUES (11, 'user9', '123456', '普通用户', '3241431241', '男', '2141423@qq.com', 0, '测试员1', 6, '2024-03-01 14:15:47', '2024-03-21 17:04:17');
INSERT INTO `user` VALUES (12, 'user10', '123456', '普通用户10', '3241431241', '男', '2141423@qq.com', 0, '测试员', 6, '2024-03-01 14:14:52', '2024-03-21 17:04:17');
INSERT INTO `user` VALUES (13, 'user11', '123456', '普通用户10', '3241431241', '男', '2141423@qq.com', 0, '测试员', 6, '2024-03-01 14:14:52', '2024-03-21 17:04:17');
INSERT INTO `user` VALUES (14, 'user12', '123456', '普通用户10', '3241431241', '男', '2141423@qq.com', 0, '测试员', 6, '2024-03-01 14:14:52', '2024-03-21 17:04:17');
INSERT INTO `user` VALUES (15, 'user13', '123456', '普通用户10', '3241431241', '男', '2141423@qq.com', 0, '测试员', 6, '2024-03-01 14:14:52', '2024-03-21 17:04:17');
INSERT INTO `user` VALUES (16, 'user14', '123456', '普通用户10', '3241431241', '男', '2141423@qq.com', 0, '测试员', 6, '2024-03-01 14:14:52', '2024-03-21 17:04:17');
INSERT INTO `user` VALUES (17, 'user15', '123456', '普通用户10', '3241431241', '男', '2141423@qq.com', 0, '测试员', 6, '2024-03-01 14:14:52', '2024-03-21 17:04:17');
INSERT INTO `user` VALUES (18, 'user16', '123456', '普通用户10', '3241431241', '男', '2141423@qq.com', 0, '测试员', 6, '2024-03-01 14:14:52', '2024-03-21 17:04:17');
INSERT INTO `user` VALUES (19, 'user17', '123456', '普通用户10', '3241431241', '男', '2141423@qq.com', 0, '测试员', 6, '2024-03-01 14:14:52', '2024-03-21 17:04:17');
INSERT INTO `user` VALUES (20, 'user18', '123456', '普通用户10', '3241431241', '男', '2141423@qq.com', 0, '测试员', 6, '2024-03-01 14:14:52', '2024-03-21 17:04:17');
INSERT INTO `user` VALUES (21, 'user19', '123456', '普通用户10', '3241431241', '男', '2141423@qq.com', 0, '测试员', 6, '2024-03-01 14:14:52', '2024-03-21 17:04:17');
INSERT INTO `user` VALUES (22, 'user20', '123456', '普通用户10', '3241431241', '男', '2141423@qq.com', 0, '测试员', 6, '2024-03-01 14:14:52', '2024-03-21 17:04:17');
INSERT INTO `user` VALUES (23, 'user21', '123456', '普通用户10', '3241431241', '男', '2141423@qq.com', 0, '测试员', 6, '2024-03-01 14:14:52', '2024-03-21 17:04:17');
INSERT INTO `user` VALUES (24, 'user22', '123456', '普通用户10', '3241431241', '男', '2141423@qq.com', 0, '测试员', 6, '2024-03-01 14:14:52', '2024-03-21 17:04:17');
INSERT INTO `user` VALUES (25, 'user23', '123456', '普通用户10', '3241431241', '男', '2141423@qq.com', 0, '测试员', 6, '2024-03-01 14:14:52', '2024-03-21 17:04:17');
INSERT INTO `user` VALUES (26, 'user24', '123456', '普通用户10', '3241431241', '男', '2141423@qq.com', 0, '测试员', 6, '2024-03-01 14:14:52', '2024-03-21 17:04:17');
INSERT INTO `user` VALUES (27, 'user25', '123456', '普通用户10', '3241431241', '男', '2141423@qq.com', 0, '测试员', 6, '2024-03-01 14:14:52', '2024-03-21 17:04:17');
INSERT INTO `user` VALUES (28, 'user26', '123456', '普通用户10', '3241431241', '男', '2141423@qq.com', 0, '测试员', 6, '2024-03-01 14:14:52', '2024-03-21 17:04:17');
INSERT INTO `user` VALUES (29, 'user27', '123456', '普通用户10', '3241431241', '男', '2141423@qq.com', 0, '测试员', 6, '2024-03-01 14:14:52', '2024-03-21 17:04:17');
INSERT INTO `user` VALUES (30, 'user28', '123456', '普通用户10', '3241431241', '男', '2141423@qq.com', 0, '测试员', 6, '2024-03-01 14:14:52', '2024-03-21 17:04:17');
INSERT INTO `user` VALUES (31, 'user29', '123456', '普通用户10', '3241431241', '男', '2141423@qq.com', 0, '测试员', 6, '2024-03-01 14:14:52', '2024-03-21 17:04:17');
INSERT INTO `user` VALUES (32, 'user30', '123456', '普通用户10', '3241431241', '男', '2141423@qq.com', 0, '测试员', 6, '2024-03-01 14:14:52', '2024-03-21 17:04:17');
INSERT INTO `user` VALUES (33, 'user31', '123456', '普通用户10', '3241431241', '男', '2141423@qq.com', 0, '测试员', 6, '2024-03-01 14:14:52', '2024-03-21 17:04:17');
INSERT INTO `user` VALUES (34, 'user32', '123456', '普通用户10', '3241431241', '男', '2141423@qq.com', 0, '测试员', 6, '2024-03-01 14:14:52', '2024-03-21 17:04:17');
INSERT INTO `user` VALUES (35, 'user33', '123456', '普通用户10', '3241431241', '男', '2141423@qq.com', 0, '测试员', 6, '2024-03-01 14:14:52', '2024-03-21 17:04:17');
INSERT INTO `user` VALUES (36, 'user34', '123456', '普通用户10', '3241431241', '男', '2141423@qq.com', 0, '测试员', 6, '2024-03-01 14:14:52', '2024-03-21 17:04:17');
INSERT INTO `user` VALUES (37, 'user35', '123456', '普通用户10', '3241431241', '男', '2141423@qq.com', 0, '测试员', 6, '2024-03-01 14:14:52', '2024-03-21 17:04:17');
INSERT INTO `user` VALUES (38, 'user36', '123456', '普通用户10', '3241431241', '男', '2141423@qq.com', 0, '测试员', 6, '2024-03-01 14:14:52', '2024-03-21 17:04:17');
INSERT INTO `user` VALUES (39, 'user37', '123456', '普通用户10', '3241431241', '男', '2141423@qq.com', 0, '测试员', 6, '2024-03-01 14:14:52', '2024-03-21 17:04:17');
INSERT INTO `user` VALUES (40, 'user38', '123456', '普通用户10', '3241431241', '男', '2141423@qq.com', 0, '测试员', 6, '2024-03-01 14:14:52', '2024-03-21 17:04:17');
INSERT INTO `user` VALUES (41, 'user39', '123456', '普通用户10', '3241431241', '男', '2141423@qq.com', 0, '测试员', 6, '2024-03-01 14:14:52', '2024-03-21 17:04:17');
INSERT INTO `user` VALUES (42, 'user40', '123456', '普通用户10', '3241431241', '男', '2141423@qq.com', 0, '测试员', 6, '2024-03-01 14:14:52', '2024-03-21 17:04:17');
INSERT INTO `user` VALUES (43, 'user41', '123456', '普通用户10', '3241431241', '男', '2141423@qq.com', 0, '测试员', 6, '2024-03-01 14:14:52', '2024-03-21 17:04:17');
INSERT INTO `user` VALUES (44, 'user42', '123456', '普通用户10', '3241431241', '男', '2141423@qq.com', 0, '测试员', 6, '2024-03-01 14:14:52', '2024-03-21 17:04:17');
INSERT INTO `user` VALUES (45, 'user43', '123456', '普通用户10', '3241431241', '男', '2141423@qq.com', 0, '测试员', 6, '2024-03-01 14:14:52', '2024-03-21 17:04:17');
INSERT INTO `user` VALUES (46, 'user44', '123456', '普通用户10', '3241431241', '男', '2141423@qq.com', 0, '测试员', 6, '2024-03-01 14:14:52', '2024-03-21 17:04:17');
INSERT INTO `user` VALUES (47, 'user45', '123456', '普通用户10', '3241431241', '男', '2141423@qq.com', 0, '测试员', 6, '2024-03-01 14:14:52', '2024-03-21 17:04:17');
INSERT INTO `user` VALUES (48, 'user46', '123456', '普通用户10', '3241431241', '男', '2141423@qq.com', 0, '测试员', 6, '2024-03-01 14:14:52', '2024-03-21 17:04:17');
INSERT INTO `user` VALUES (49, 'user47', '123456', '普通用户10', '3241431241', '男', '2141423@qq.com', 0, '测试员', 6, '2024-03-01 14:14:52', '2024-03-21 17:04:17');
INSERT INTO `user` VALUES (50, 'test1', '123456', '测试员1', '12313213', '男', '2131231@qq.com', 1, 'ceshi', 6, '2024-03-21 06:13:34', '2024-03-21 17:04:17');
INSERT INTO `user` VALUES (51, 'string', 'string', 'string', 'string', '男', 'string', 1, 'string', 6, '2024-03-21 06:34:33', '2024-03-21 17:04:17');
INSERT INTO `user` VALUES (52, 'test1', '123', 'test1', '123', '男', '123', 1, '123', 6, '2024-03-21 14:49:01', '2024-03-21 17:04:17');
INSERT INTO `user` VALUES (53, 'test2', '123456', 'test2', '123', '男', '123', 1, 'test', 6, '2024-03-21 14:50:46', '2024-03-21 17:04:17');
INSERT INTO `user` VALUES (54, 'test3', 'test3', 'test3', '213', '男', '123', 1, '123', 6, '2024-03-21 14:55:18', '2024-03-21 17:04:17');

-- ----------------------------
-- Table structure for user_post
-- ----------------------------
DROP TABLE IF EXISTS `user_post`;
CREATE TABLE `user_post`  (
  `id` int(11) NOT NULL AUTO_INCREMENT COMMENT '自增主键',
  `user_id` int(11) NOT NULL COMMENT '用户id',
  `post_id` int(11) NOT NULL COMMENT '岗位id',
  `insertTime` timestamp NULL DEFAULT '2023-01-01 00:00:01' COMMENT '注册时间',
  `lastModified` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '最后修改时间',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 5 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Fixed;

-- ----------------------------
-- Records of user_post
-- ----------------------------
INSERT INTO `user_post` VALUES (1, 1, 1, '2023-01-01 00:00:01', '2024-03-22 15:20:58');
INSERT INTO `user_post` VALUES (2, 1, 2, '2023-01-01 00:00:01', '2024-03-22 15:21:36');
INSERT INTO `user_post` VALUES (3, 3, 3, '2023-01-01 00:00:01', '2024-03-22 15:21:44');
INSERT INTO `user_post` VALUES (4, 4, 4, '2023-01-01 00:00:01', '2024-03-22 15:22:07');

-- ----------------------------
-- Table structure for user_role
-- ----------------------------
DROP TABLE IF EXISTS `user_role`;
CREATE TABLE `user_role`  (
  `id` int(11) NOT NULL AUTO_INCREMENT COMMENT '自增主键',
  `user_id` int(11) NOT NULL COMMENT '用户id',
  `role_id` int(11) NOT NULL COMMENT '角色id',
  `insertTime` timestamp NULL DEFAULT '2023-01-01 00:00:01' COMMENT '注册时间',
  `lastModified` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '最后修改时间',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = MyISAM CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Fixed;

-- ----------------------------
-- Records of user_role
-- ----------------------------
INSERT INTO `user_role` VALUES (1, 1, 1, '2023-01-01 00:00:01', '2024-03-18 00:00:01');
INSERT INTO `user_role` VALUES (2, 3, 2, '2023-01-01 00:00:01', '2024-03-18 00:00:01');

SET FOREIGN_KEY_CHECKS = 1;


-- 创建公告表
CREATE TABLE Notice (
    NoticeId INT AUTO_INCREMENT PRIMARY KEY,
    NoticeTitle VARCHAR(50),
    NoticeContent VARCHAR(500),
    NoticeStatus int,
    InsertTime DATETIME
);


INSERT INTO Notice (NoticeTitle, NoticeContent, NoticeStatus, InsertTime)
VALUES 
('系统升级通知', '将于2025年5月15日22:00-次日02:00进行系统升级，期间暂停服务。', 1, '2025-05-01 10:30:00'),
('假期安排', '2025年端午节：6月10日至12日放假，共3天。', 1, '2025-05-02 09:15:00'),
('新功能上线', '数据分析模块V2.0已上线，支持多维报表导出。', 1, '2025-05-03 14:45:00'),
('安全提示', '近期发现钓鱼邮件，请不要点击不明链接。', 1, '2025-05-04 16:20:00'),
('员工培训', '5月20日下午14:00将举行数据安全培训，请准时参加。', 1, '2025-05-05 11:00:00'),
('设备更换', '即日起逐步更换办公电脑，请留意IT部门通知。', 1, '2025-05-06 10:10:00'),
('考勤系统调整', '考勤系统将于5月18日更新算法，请重新校准指纹。', 1, '2025-05-07 09:30:00'),
('福利政策更新', '补充商业保险方案已更新，详情见附件。', 1, '2025-05-08 15:20:00'),
('团建活动', '5月25日组织户外团建，请提前安排好工作。', 1, '2025-05-09 14:00:00'),
('食堂改造', '食堂将于5月30日至6月5日进行改造，期间提供简易餐食。', 0, '2025-05-10 11:45:00');

-- 年级表  0
CREATE TABLE IF NOT EXISTS Grades (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(50) NOT NULL,
    Level INT NOT NULL UNIQUE,
    insertTime DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP
);

-- 教师表
CREATE TABLE IF NOT EXISTS Teachers (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(50) NOT NULL,
    Age INT,
    Subject VARCHAR(50),
    Phone VARCHAR(20),
    IsHeadTeacher BOOLEAN NOT NULL DEFAULT FALSE,
    UserId INT,
    insertTime DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP
);


-- 班级表 0
CREATE TABLE IF NOT EXISTS Classes (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(50) NOT NULL,
    ClassType INT NOT NULL,
    HeadTeacher_Id INT,
    GradeId INT NOT NULL,
    insertTime DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (GradeId) REFERENCES Grades(Id) ON DELETE CASCADE,
    FOREIGN KEY (HeadTeacher_Id) REFERENCES Teachers(Id) ON DELETE SET NULL
);

-- 课程表
CREATE TABLE IF NOT EXISTS Courses (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(50) NOT NULL,
    CourseType INT NOT NULL,
    insertTime DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP
);


-- 学生表
CREATE TABLE IF NOT EXISTS Students (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(50) NOT NULL,
    Gender VARCHAR(10),
    ClassId INT NOT NULL,
    UserId INT,
    insertTime DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (ClassId) REFERENCES Classes(Id) ON DELETE CASCADE
);

-- 课程-教师关联表
CREATE TABLE IF NOT EXISTS Courses_Teachers (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    CourseId INT NOT NULL,
    TeacherId INT NOT NULL,
    insertTime DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (CourseId) REFERENCES Courses(Id) ON DELETE CASCADE,
    FOREIGN KEY (TeacherId) REFERENCES Teachers(Id) ON DELETE CASCADE,
    UNIQUE KEY unique_course_teacher (CourseId, TeacherId)
);

-- 教师-班级关联表
CREATE TABLE IF NOT EXISTS Teachers_Classes (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    TeacherId INT NOT NULL,
    ClassId INT NOT NULL,
    insertTime DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (TeacherId) REFERENCES Teachers(Id) ON DELETE CASCADE,
    FOREIGN KEY (ClassId) REFERENCES Classes(Id) ON DELETE CASCADE,
    UNIQUE KEY unique_teacher_class (TeacherId, ClassId)
);

-- 考试表
CREATE TABLE IF NOT EXISTS Examination (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(50) NOT NULL COMMENT '考试名称',
    ExamTime DATETIME NOT NULL COMMENT '考试时间',
    insertTime DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COMMENT '考试表';

-- 成绩表
CREATE TABLE IF NOT EXISTS Scores (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Number INT NOT NULL,
    StudentId INT NOT NULL,
    CourseId INT NOT NULL,
    TeacherId INT NOT NULL,
    insertTime DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (StudentId) REFERENCES Students(Id) ON DELETE CASCADE,
    FOREIGN KEY (CourseId) REFERENCES Courses(Id) ON DELETE CASCADE,
    FOREIGN KEY (TeacherId) REFERENCES Teachers(Id) ON DELETE CASCADE,
    UNIQUE KEY unique_student_course (StudentId, CourseId)
);
TRUNCATE TABLE scores;
alter table scores add column ClassId int not null;
alter table scores add column GradeId int not null;
alter table scores add column ExamId int not null;
alter table scores add constraint FK_Scores_Classes
	foreign key (ClassId) references Classes(Id);
alter table scores add constraint FK_Scores_Grades
	foreign key (GradeId) references Grades(Id);
alter table scores add constraint FK_Scores_Examination
	foreign key(ExamId) references Examination(Id);



-- 插入年级
INSERT INTO Grades (Name, Level) VALUES
('高一', 1),
('高二', 2),
('高三', 3);
SELECT * FROM Grades;

-- 插入教师
INSERT INTO Teachers (Name, Age, Subject, Phone, IsHeadTeacher, UserId) VALUES
-- 高一1班班主任（数学老师）
('张建国', 45, '数学', '13800138000', TRUE, 20),
-- 高一2班班主任（物理老师）
('李丽华', 42, '物理', '13900139000', TRUE, 21),
-- 高二1班班主任（历史老师，文科班）
('王海燕', 38, '历史', '13600136000', TRUE, 22),
-- 高二2班班主任（地理老师，文科班）
('赵光明', 40, '地理', '13700137000', TRUE, 23),
-- 高三1班班主任（化学老师）
('陈美娟', 48, '化学', '13500135000', TRUE, 24),
-- 普通教师（语文老师）
('周敏', 35, '语文', '13400134000', FALSE, 25),
-- 普通教师（英语老师）
('吴伟', 33, '英语', '13200132000', FALSE, 26);

-- 高一班主任
INSERT INTO Teachers (Name, Age, Subject, Phone, IsHeadTeacher, UserId) VALUES
-- 高一3班班主任（假设为数学老师）
('孙晓东', 40, '数学', '13800138003', TRUE, 27),
-- 高一4班班主任（假设为物理老师）
('刘悦', 38, '物理', '13900139004', TRUE, 28),
-- 高一5班班主任（假设为数学老师）
('杨明', 42, '数学', '13800138005', TRUE, 29),
-- 高一6班班主任（假设为物理老师）
('林芳', 36, '物理', '13900139006', TRUE, 30),
-- 高一7班班主任（假设为数学老师）
('郭强', 43, '数学', '13800138007', TRUE, 31),
-- 高一8班班主任（假设为历史老师）
('徐静', 35, '历史', '13600136008', TRUE, 32),
-- 高一9班班主任（假设为地理老师）
('马涛', 37, '地理', '13700137009', TRUE, 33),
-- 高一10班班主任（假设为历史老师）
('陈慧', 34, '历史', '13600136010', TRUE, 34);

-- 高二班主任
INSERT INTO Teachers (Name, Age, Subject, Phone, IsHeadTeacher, UserId) VALUES
-- 高二3班班主任（假设为物理老师）
('郑辉', 36, '物理', '13600136011', TRUE, 35),
-- 高二4班班主任（假设为化学老师）
('董丽', 33, '化学', '13700137012', TRUE, 36),
-- 高二5班班主任（假设为生物老师）
('谢峰', 38, '生物', '13600136013', TRUE, 37),
-- 高二6班班主任（假设为物理老师）
('吕佳', 32, '物理', '13700137014', TRUE, 38),
-- 高二7班班主任（假设为化学老师）
('江波', 39, '化学', '13600136015', TRUE, 39),
-- 高二8班班主任（假设为历史老师）
('卢敏', 34, '历史', '13500135016', TRUE, 40),
-- 高二9班班主任（假设为地理老师）
('傅勇', 36, '地理', '13700137017', TRUE, 41),
-- 高二10班班主任（假设为政治老师）
('崔瑶', 33, '政治', '13500135018', TRUE, 42);

-- 高三班主任
INSERT INTO Teachers (Name, Age, Subject, Phone, IsHeadTeacher, UserId) VALUES
-- 高三2班班主任（假设为化学老师）
('唐俊', 41, '化学', '13500135019', TRUE, 43),
-- 高三3班班主任（假设为数学老师）
('许娜', 39, '数学', '13800138011', TRUE, 44),
-- 高三4班班主任（假设为化学老师）
('潘晨', 40, '化学', '13500135020', TRUE, 45),
-- 高三5班班主任（假设为数学老师）
('苏畅', 38, '数学', '13800138012', TRUE, 46),
-- 高三6班班主任（假设为化学老师）
('魏然', 42, '化学', '13500135021', TRUE, 47),
-- 高三7班班主任（假设为数学老师）
('任翔', 44, '数学', '13800138013', TRUE, 48),
-- 高三8班班主任（假设为英语老师）
('蒋薇', 35, '英语', '13200132011', TRUE, 49),
-- 高三9班班主任（假设为历史老师）
('赵莹', 34, '历史', '13600136016', TRUE, 50),
-- 高三10班班主任（假设为英语老师）
('黄浩', 36, '英语', '13200132012', TRUE, 51);

-- 普通教师
INSERT INTO Teachers (Name, Age, Subject, Phone, IsHeadTeacher, UserId) VALUES
-- 普通教师（生物老师）
('田甜', 30, '生物', '13400134008', FALSE, 52),
-- 普通教师（政治老师）
('张磊', 32, '政治', '13100131009', FALSE, 53),
-- 普通教师（生物老师）
('吴珊', 29, '生物', '13400134010', FALSE, 54),
-- 普通教师（政治老师）
('李阳', 31, '政治', '13100131011', FALSE, 55),
-- 普通教师（生物老师）
('何冰', 33, '生物', '13400134012', FALSE, 56),
-- 普通教师（体育老师）
('周宇', 28, '体育', '13000130001', FALSE, 57),
-- 普通教师（体育老师）
('陈晨', 27, '体育', '13000130002', FALSE, 58),
-- 普通教师（音乐老师）
('赵雪', 26, '音乐', '13300133001', FALSE, 59),
-- 普通教师（美术老师）
('孙艺', 27, '美术', '13300133002', FALSE, 60);
INSERT INTO Teachers (Name, Age, Subject, Phone, IsHeadTeacher, UserId) VALUES
('李子', 27, '语文', '13300133002', FALSE, 60),
('苏西', 36, '语文', '13300133002', FALSE, 61),
('凯明', 27, '语文', '13300133002', FALSE, 62),
('贺正', 47, '语文', '13300133002', FALSE, 63),
('更其', 23, '语文', '13300133002', FALSE, 64),
('贾平', 34, '语文', '13300133002', FALSE, 65);

-- 继续插入普通教师（生物老师）
INSERT INTO Teachers (Name, Age, Subject, Phone, IsHeadTeacher, UserId) VALUES
('孟芳', 31, '生物', '13400134013', FALSE, 66),
('魏星', 30, '生物', '13400134014', FALSE, 67),
('杜宇', 32, '生物', '13400134015', FALSE, 68);
-- 继续插入普通教师（政治老师）
INSERT INTO Teachers (Name, Age, Subject, Phone, IsHeadTeacher, UserId) VALUES
('高磊', 33, '政治', '13100131012', FALSE, 69),
('林晓', 32, '政治', '13100131013', FALSE, 70),
('叶楠', 34, '政治', '13100131014', FALSE, 71);
-- 继续插入普通教师（体育老师）
INSERT INTO Teachers (Name, Age, Subject, Phone, IsHeadTeacher, UserId) VALUES
('江浩', 29, '体育', '13000130003', FALSE, 72),
('苏瑶', 28, '体育', '13000130004', FALSE, 73),
('许阳', 30, '体育', '13000130005', FALSE, 74);
-- 继续插入普通教师（音乐老师）
INSERT INTO Teachers (Name, Age, Subject, Phone, IsHeadTeacher, UserId) VALUES
('柳琴', 25, '音乐', '13300133003', FALSE, 75),
('陈韵', 26, '音乐', '13300133004', FALSE, 76),
('夏梦', 27, '音乐', '13300133005', FALSE, 77);
-- 继续插入普通教师（美术老师）
INSERT INTO Teachers (Name, Age, Subject, Phone, IsHeadTeacher, UserId) VALUES
('田甜', 26, '美术', '13300133006', FALSE, 78),
('何悦', 27, '美术', '13300133007', FALSE, 79),
('张琪', 28, '美术', '13300133008', FALSE, 80);
-- 继续插入普通教师（语文老师）
INSERT INTO Teachers (Name, Age, Subject, Phone, IsHeadTeacher, UserId) VALUES
('杨雪', 33, '语文', '13300133009', FALSE, 81),
('李诗', 34, '语文', '13300133010', FALSE, 82),
('周雨', 35, '语文', '13300133011', FALSE, 83);
-- 继续插入普通教师（数学老师）
INSERT INTO Teachers (Name, Age, Subject, Phone, IsHeadTeacher, UserId) VALUES
('赵阳', 36, '数学', '13800138014', FALSE, 84),
('孙辉', 37, '数学', '13800138015', FALSE, 85),
('吴迪', 38, '数学', '13800138016', FALSE, 86);
-- 继续插入普通教师（英语老师）
INSERT INTO Teachers (Name, Age, Subject, Phone, IsHeadTeacher, UserId) VALUES
('郑悦', 32, '英语', '13200132013', FALSE, 87),
('王晨', 33, '英语', '13200132014', FALSE, 88),
('陈希', 34, '英语', '13200132015', FALSE, 89);
-- 继续插入普通教师（物理老师）
INSERT INTO Teachers (Name, Age, Subject, Phone, IsHeadTeacher, UserId) VALUES
('徐明', 37, '物理', '13600136017', FALSE, 90),
('郭佳', 38, '物理', '13600136018', FALSE, 91),
('林泽', 39, '物理', '13600136019', FALSE, 92);
-- 继续插入普通教师（化学老师）
INSERT INTO Teachers (Name, Age, Subject, Phone, IsHeadTeacher, UserId) VALUES
('唐晓', 35, '化学', '13500135022', FALSE, 93),
('苏曼', 36, '化学', '13500135023', FALSE, 94),
('魏宇', 37, '化学', '13500135024', FALSE, 95);


-- 插入班级
INSERT INTO classes (name, ClassType, GradeId, HeadTeacher_Id) VALUES
('高一1班','0', 1, 1),
('高一2班','0', 1, 2),
('高一3班','0', 1, 8),
('高一4班','0', 1, 9),
('高一5班','0', 1, 10),
('高一6班','0', 1, 11),
('高一7班','0', 1, 12),
('高一8班', '1', 1, 13),
('高一9班', '1', 1, 14),
('高一10班', '1', 1, 15);
INSERT INTO classes (name, ClassType, GradeId, HeadTeacher_Id) VALUES
('高二1班', '0', 2, 3),
('高二2班', '0', 2, 4),
('高二3班','0', 2, 16),
('高二4班','0', 2, 17),
('高二5班','0', 2, 18),
('高二6班','0', 2, 17),
('高二7班','0', 2, 20),
('高二8班', '1', 2, 21),
('高二9班', '1', 2, 22),
('高二10班', '1', 2, 23);
INSERT INTO classes (name, ClassType, GradeId, HeadTeacher_Id) VALUES
('高三1班','0', 3, 5),
('高三2班','0', 3, 24),
('高三3班','0', 3, 25),
('高三4班','0', 3, 26),
('高三5班','0', 3, 27),
('高三6班','0', 3, 28),
('高三7班','0', 3, 29),
('高三8班', '1', 3, 30),
('高三9班', '1', 3, 31),
('高三10班', '1', 3, 32);

-- 一班教师
-- 高一语文
INSERT INTO Teachers_Classes (TeacherId, ClassId) VALUES (6, 1);   
INSERT INTO Teachers_Classes (TeacherId, ClassId) VALUES (42, 2); 
INSERT INTO Teachers_Classes (TeacherId, ClassId) VALUES (45, 3); 
INSERT INTO Teachers_Classes (TeacherId, ClassId) VALUES (45, 4); 
INSERT INTO Teachers_Classes (TeacherId, ClassId) VALUES (46, 5); 
INSERT INTO Teachers_Classes (TeacherId, ClassId) VALUES (47, 6); 
INSERT INTO Teachers_Classes (TeacherId, ClassId) VALUES (44, 7); 
INSERT INTO Teachers_Classes (TeacherId, ClassId) VALUES (43, 8); 
INSERT INTO Teachers_Classes (TeacherId, ClassId) VALUES (44, 9); 
INSERT INTO Teachers_Classes (TeacherId, ClassId) VALUES (47, 10); 
-- 高一数学
INSERT INTO Teachers_Classes (TeacherId, ClassId) VALUES (1, 1);   
INSERT INTO Teachers_Classes (TeacherId, ClassId) VALUES (1, 2); 
INSERT INTO Teachers_Classes (TeacherId, ClassId) VALUES (8, 3); 
INSERT INTO Teachers_Classes (TeacherId, ClassId) VALUES (8, 4); 
INSERT INTO Teachers_Classes (TeacherId, ClassId) VALUES (10, 5); 
INSERT INTO Teachers_Classes (TeacherId, ClassId) VALUES (10, 6); 
INSERT INTO Teachers_Classes (TeacherId, ClassId) VALUES (12, 7); 
INSERT INTO Teachers_Classes (TeacherId, ClassId) VALUES (25, 8); 
INSERT INTO Teachers_Classes (TeacherId, ClassId) VALUES (27, 9); 
INSERT INTO Teachers_Classes (TeacherId, ClassId) VALUES (29, 10); 
-- 高一英语
INSERT INTO Teachers_Classes (TeacherId, ClassId) VALUES (7, 1);   
INSERT INTO Teachers_Classes (TeacherId, ClassId) VALUES (7, 2); 
INSERT INTO Teachers_Classes (TeacherId, ClassId) VALUES (7, 3); 
INSERT INTO Teachers_Classes (TeacherId, ClassId) VALUES (30, 4); 
INSERT INTO Teachers_Classes (TeacherId, ClassId) VALUES (30, 5); 
INSERT INTO Teachers_Classes (TeacherId, ClassId) VALUES (30, 6); 
INSERT INTO Teachers_Classes (TeacherId, ClassId) VALUES (32, 7); 
INSERT INTO Teachers_Classes (TeacherId, ClassId) VALUES (32, 8); 
INSERT INTO Teachers_Classes (TeacherId, ClassId) VALUES (32, 9); 
INSERT INTO Teachers_Classes (TeacherId, ClassId) VALUES (30, 10); 

-- 为课程1（假设是语文）分配更多教师
INSERT INTO Courses_Teachers (CourseId, TeacherId) VALUES
(7, 81),
(7, 82),
(7, 83);
-- 为课程2（假设是数学）分配更多教师
INSERT INTO Courses_Teachers (CourseId, TeacherId) VALUES
(8, 84),
(8, 85),
(8, 86);
-- 为课程3（假设是英语）分配更多教师
INSERT INTO Courses_Teachers (CourseId, TeacherId) VALUES
(9, 87),
(9, 88),
(9, 89);
-- 为课程4（假设是物理）分配更多教师
INSERT INTO Courses_Teachers (CourseId, TeacherId) VALUES
(1, 90),
(1, 91),
(1, 92);
-- 为课程5（假设是化学）分配更多教师
INSERT INTO Courses_Teachers (CourseId, TeacherId) VALUES
(2, 93),
(2, 94),
(2, 95);
-- 为课程6（假设是生物）分配更多教师
INSERT INTO Courses_Teachers (CourseId, TeacherId) VALUES
(3, 66),
(3, 67),
(3, 68);
-- 为课程7（假设是历史）分配更多教师
INSERT INTO Courses_Teachers (CourseId, TeacherId) VALUES
(4, 43),
(4, 44),
(4, 47);
-- 为课程8（假设是地理）分配更多教师
INSERT INTO Courses_Teachers (CourseId, TeacherId) VALUES
(5, 45),
(5, 46),
(5, 14);
-- 为课程9（假设是政治）分配更多教师
INSERT INTO Courses_Teachers (CourseId, TeacherId) VALUES
(6, 69),
(6, 70),
(6, 71);
-- 为课程10（假设是体育）分配更多教师
INSERT INTO Courses_Teachers (CourseId, TeacherId) VALUES
(10, 72),
(10, 73),
(10, 74);
-- 为课程11（假设是音乐）分配更多教师
INSERT INTO Courses_Teachers (CourseId, TeacherId) VALUES
(11, 75),
(11, 76),
(11, 77);
-- 为课程12（假设是美术）分配更多教师
INSERT INTO Courses_Teachers (CourseId, TeacherId) VALUES
(12, 78),
(12, 79),
(12, 80);


-- 为高一1班分配更多教师
INSERT INTO Teachers_Classes (TeacherId, ClassId) VALUES
(81, 1),
(82, 1),
(83, 1);
-- 为高一2班分配更多教师
INSERT INTO Teachers_Classes (TeacherId, ClassId) VALUES
(84, 2),
(85, 2),
(86, 2);
-- 为高一3班分配更多教师
INSERT INTO Teachers_Classes (TeacherId, ClassId) VALUES
(87, 3),
(88, 3),
(89, 3);
-- 以此类推，为更多班级分配更多教师

insert into Examination(Name, ExamTime, insertTime) values
("2025年4月月考", "2025-04-15",Now()),
("2025年5月月考", "2025-05-15",Now()),
("2025年6月月考", "2025-06-15",Now()),
("2025年上学期期末考", "2025-07-01",Now()),
("2025年下学期入学考", "2025-09-01",Now()),
("2025年9月月考", "2025-09-15",Now()),
("2025年10月月考", "2025-10-15",Now()),
("2025年11月月考", "2025-11-15",Now()),
("2025年12月月考", "2025-12-15",Now()),
("2025年下学期期末考", "2026-01-10",Now());


-- 理科课程（CourseType=0）
INSERT INTO Courses (Name, CourseType) VALUES
('物理', 0),
('化学', 0),
('生物', 0);

-- 文科课程（CourseType=1）
INSERT INTO Courses (Name, CourseType) VALUES
('历史', 1),
('地理', 1),
('政治', 1);

-- 通用课程（CourseType=2）
INSERT INTO Courses (Name, CourseType) VALUES
('语文', 2),
('数学', 2),
('英语', 2),
('体育', 2),
('音乐', 2),
('美术', 2);
update courses set CourseType = 3 where id >= 10;

-- 插入学生数据（一班）
INSERT INTO students (Name, Gender, ClassId, UserId, insertTime) VALUES
('张三', 1, 1, 101, NOW()),
('李四', 1, 1, 102, NOW()),
('王五', 1, 1, 103, NOW()),
('赵六', 1, 1, 104, NOW()),
('孙七', 1, 1, 105, NOW()),
('周八', 2, 1, 106, NOW()),
('吴九', 2, 1, 107, NOW()),
('郑十', 2, 1, 108, NOW()),
('钱十一', 2, 1, 109, NOW()),
('孙十二', 2, 1, 110, NOW());

-- 插入学生数据（二班）
INSERT INTO students (Name, Gender, ClassId, UserId, insertTime) VALUES
('刘一', 1, 2, 201, NOW()),
('陈二', 1, 2, 202, NOW()),
('杨三', 1, 2, 203, NOW()),
('吴四', 1, 2, 204, NOW()),
('朱五', 1, 2, 205, NOW()),
('韩六', 2, 2, 206, NOW()),
('许七', 2, 2, 207, NOW()),
('邓八', 2, 2, 208, NOW()),
('冯九', 2, 2, 209, NOW()),
('曹十', 2, 2, 210, NOW());

-- 插入学生数据（三班）
INSERT INTO students (Name, Gender, ClassId, UserId, insertTime) VALUES
('彭一', 1, 3, 301, NOW()),
('吕二', 1, 3, 302, NOW()),
('施三', 1, 3, 303, NOW()),
('张四', 1, 3, 304, NOW()),
('孔五', 1, 3, 305, NOW()),
('严六', 2, 3, 306, NOW()),
('华七', 2, 3, 307, NOW()),
('金八', 2, 3, 308, NOW()),
('魏九', 2, 3, 309, NOW()),
('陶十', 2, 3, 310, NOW());

-- 以此类推，插入更多班级的学生数据

-- 插入考试
insert into Examination(Name, ExamTime, insertTime) values
("2025年1月月考", "2025-01-15",Now()),
("2025年2月月考", "2025-02-15",Now()),
("2025年3月月考", "2025-03-15",Now());


-- 插入成绩数据

-- 张三
INSERT INTO scores (Number, StudentId, CourseId, TeacherId,ClassId,GradeId,ExamId, insertTime) VALUES
(90, 1, 7, 6, 1,1,1,NOW()),  -- 语文
(85, 1, 8, 1,  1,1,1,NOW()),  -- 数学
(92, 1, 9, 7, 1,1,1, NOW()),  --  英语
(78, 1, 1, 2,  1,1,1,NOW()),  -- 物理
(88, 1, 2, 5,  1,1,1,NOW()),  -- 化学
(88, 1, 3, 18,  1,1,1,NOW());  -- 生物

-- 李四（班级1，年级1，ExamId=1）
INSERT INTO scores (Number, StudentId, CourseId, TeacherId, ClassId, GradeId, ExamId, insertTime) VALUES
(88, 2, 7, 6, 1, 1, 1, NOW()),  -- 语文
(82, 2, 8, 1, 1, 1, 1, NOW()),  -- 数学
(90, 2, 9, 7, 1, 1, 1, NOW()),  -- 英语
(75, 2, 1, 2, 1, 1, 1, NOW()),  -- 物理
(86, 2, 2, 5, 1, 1, 1, NOW()),  -- 化学
(85, 2, 3, 18, 1, 1, 1, NOW());  -- 生物

-- 王五（班级1，年级1，ExamId=1）
INSERT INTO scores (Number, StudentId, CourseId, TeacherId, ClassId, GradeId, ExamId, insertTime) VALUES
(92, 3, 7, 6, 1, 1, 1, NOW()),  -- 语文
(87, 3, 8, 1, 1, 1, 1, NOW()),  -- 数学
(93, 3, 9, 7, 1, 1, 1, NOW()),  -- 英语
(77, 3, 1, 2, 1, 1, 1, NOW()),  -- 物理
(87, 3, 2, 5, 1, 1, 1, NOW()),  -- 化学
(86, 3, 3, 18, 1, 1, 1, NOW());  -- 生物

-- 赵六（班级1，年级1，ExamId=1）
INSERT INTO scores (Number, StudentId, CourseId, TeacherId, ClassId, GradeId, ExamId, insertTime) VALUES
(86, 4, 7, 6, 1, 1, 1, NOW()),  -- 语文
(83, 4, 8, 1, 1, 1, 1, NOW()),  -- 数学
(89, 4, 9, 7, 1, 1, 1, NOW()),  -- 英语
(76, 4, 1, 2, 1, 1, 1, NOW()),  -- 物理
(85, 4, 2, 5, 1, 1, 1, NOW()),  -- 化学
(84, 4, 3, 18, 1, 1, 1, NOW());  -- 生物

-- 孙七（班级1，年级1，ExamId=1）
INSERT INTO scores (Number, StudentId, CourseId, TeacherId, ClassId, GradeId, ExamId, insertTime) VALUES
(91, 5, 7, 6, 1, 1, 1, NOW()),  -- 语文
(84, 5, 8, 1, 1, 1, 1, NOW()),  -- 数学
(91, 5, 9, 7, 1, 1, 1, NOW()),  -- 英语
(74, 5, 1, 2, 1, 1, 1, NOW()),  -- 物理
(84, 5, 2, 5, 1, 1, 1, NOW()),  -- 化学
(83, 5, 3, 18, 1, 1, 1, NOW());  -- 生物

-- 周八（班级1，年级1，ExamId=1）
INSERT INTO scores (Number, StudentId, CourseId, TeacherId, ClassId, GradeId, ExamId, insertTime) VALUES
(84, 6, 7, 6, 1, 1, 1, NOW()),  -- 语文
(81, 6, 8, 1, 1, 1, 1, NOW()),  -- 数学
(88, 6, 9, 7, 1, 1, 1, NOW()),  -- 英语
(73, 6, 1, 2, 1, 1, 1, NOW()),  -- 物理
(83, 6, 2, 5, 1, 1, 1, NOW()),  -- 化学
(82, 6, 3, 18, 1, 1, 1, NOW());  -- 生物

-- 吴九（班级1，年级1，ExamId=1）
INSERT INTO scores (Number, StudentId, CourseId, TeacherId, ClassId, GradeId, ExamId, insertTime) VALUES
(87, 7, 7, 6, 1, 1, 1, NOW()),  -- 语文
(82, 7, 8, 1, 1, 1, 1, NOW()),  -- 数学
(90, 7, 9, 7, 1, 1, 1, NOW()),  -- 英语
(75, 7, 1, 2, 1, 1, 1, NOW()),  -- 物理
(85, 7, 2, 5, 1, 1, 1, NOW()),  -- 化学
(84, 7, 3, 18, 1, 1, 1, NOW());  -- 生物

-- 郑十（班级1，年级1，ExamId=1）
INSERT INTO scores (Number, StudentId, CourseId, TeacherId, ClassId, GradeId, ExamId, insertTime) VALUES
(85, 8, 7, 6, 1, 1, 1, NOW()),  -- 语文
(80, 8, 8, 1, 1, 1, 1, NOW()),  -- 数学
(87, 8, 9, 7, 1, 1, 1, NOW()),  -- 英语
(72, 8, 1, 2, 1, 1, 1, NOW()),  -- 物理
(82, 8, 2, 5, 1, 1, 1, NOW()),  -- 化学
(81, 8, 3, 18, 1, 1, 1, NOW());  -- 生物

-- 钱十一（班级1，年级1，ExamId=1）
INSERT INTO scores (Number, StudentId, CourseId, TeacherId, ClassId, GradeId, ExamId, insertTime) VALUES
(86, 9, 7, 6, 1, 1, 1, NOW()),  -- 语文
(81, 9, 8, 1, 1, 1, 1, NOW()),  -- 数学
(88, 9, 9, 7, 1, 1, 1, NOW()),  -- 英语
(73, 9, 1, 2, 1, 1, 1, NOW()),  -- 物理
(83, 9, 2, 5, 1, 1, 1, NOW()),  -- 化学
(82, 9, 3, 18, 1, 1, 1, NOW());  -- 生物

-- 孙十二（班级1，年级1，ExamId=1）
INSERT INTO scores (Number, StudentId, CourseId, TeacherId, ClassId, GradeId, ExamId, insertTime) VALUES
(87, 10, 7, 6, 1, 1, 1, NOW()),  -- 语文
(82, 10, 8, 1, 1, 1, 1, NOW()),  -- 数学
(89, 10, 9, 7, 1, 1, 1, NOW()),  -- 英语
(74, 10, 1, 2, 1, 1, 1, NOW()),  -- 物理
(84, 10, 2, 5, 1, 1, 1, NOW()),  -- 化学
(83, 10, 3, 18, 1, 1, 1, NOW());  -- 生物




-- 为刘一插入成绩数据（班级2，年级1，ExamId根据实际考试情况选择）
INSERT INTO scores (Number, StudentId, CourseId, TeacherId, ClassId, GradeId, ExamId, insertTime) VALUES
(88, 11, 7, 6, 2, 1, 1, NOW()),  -- 语文
(83, 11, 8, 1, 2, 1, 1, NOW()),  -- 数学
(90, 11, 9, 7, 2, 1, 1, NOW()),  -- 英语
(76, 11, 1, 2, 2, 1, 1, NOW()),  -- 物理
(86, 11, 2, 5, 2, 1, 1, NOW()),  -- 化学
(85, 11, 3, 18, 2, 1, 1, NOW());  -- 生物

-- 为陈二插入成绩数据（班级2，年级1，ExamId根据实际考试情况选择）
INSERT INTO scores (Number, StudentId, CourseId, TeacherId, ClassId, GradeId, ExamId, insertTime) VALUES
(86, 12, 7, 6, 2, 1, 1, NOW()),  -- 语文
(82, 12, 8, 1, 2, 1, 1, NOW()),  -- 数学
(88, 12, 9, 7, 2, 1, 1, NOW()),  -- 英语
(75, 12, 1, 2, 2, 1, 1, NOW()),  -- 物理
(85, 12, 2, 5, 2, 1, 1, NOW()),  -- 化学
(84, 12, 3, 18, 2, 1, 1, NOW());  -- 生物

-- 以此类推，为更多学生插入成绩数据































-- 高一三班完整数据
-- 插入高中三班学生数据
INSERT INTO students (Name, Gender, ClassId, UserId, insertTime) VALUES
('张甲', 1, 3, 301, NOW()),
('李乙', 1, 3, 302, NOW()),
('王丙', 1, 3, 303, NOW()),
('赵丁', 1, 3, 304, NOW()),
('孙戊', 1, 3, 305, NOW()),
('周己', 2, 3, 306, NOW()),
('吴庚', 2, 3, 307, NOW()),
('郑辛', 2, 3, 308, NOW()),
('钱壬', 2, 3, 309, NOW()),
('冯癸', 2, 3, 310, NOW()),
('陈子', 1, 3, 311, NOW()),
('杨丑', 1, 3, 312, NOW()),
('朱寅', 1, 3, 313, NOW()),
('秦卯', 1, 3, 314, NOW()),
('尤辰', 1, 3, 315, NOW()),
('何巳', 2, 3, 316, NOW()),
('吕午', 2, 3, 317, NOW()),
('施未', 2, 3, 318, NOW()),
('张申', 2, 3, 319, NOW()),
('孔酉', 2, 3, 320, NOW()),
('严戌', 1, 3, 321, NOW()),
('华亥', 1, 3, 322, NOW()),
('金A', 1, 3, 323, NOW()),
('魏B', 1, 3, 324, NOW()),
('陶C', 1, 3, 325, NOW()),
('姜D', 2, 3, 326, NOW()),
('戚E', 2, 3, 327, NOW()),
('谢F', 2, 3, 328, NOW()),
('邹G', 2, 3, 329, NOW()),
('喻H', 2, 3, 330, NOW());

-- 插入语文教师（杨雪，ID=81）与三班的关联
INSERT INTO Teachers_Classes (TeacherId, ClassId) VALUES (81, 3);

-- 插入数学教师（赵阳，ID=84，兼班主任）与三班的关联
INSERT INTO Teachers_Classes (TeacherId, ClassId, IsHeadTeacher) VALUES (84, 3, 1);

-- 插入英语教师（郑悦，ID=87）与三班的关联
INSERT INTO Teachers_Classes (TeacherId, ClassId) VALUES (87, 3);

-- 插入物理教师（从现有教师中选择，例如郭佳，ID=85）
INSERT INTO Teachers_Classes (TeacherId, ClassId) VALUES (85, 3);

-- 插入化学教师（从现有教师中选择，例如苏曼，ID=88）
INSERT INTO Teachers_Classes (TeacherId, ClassId) VALUES (88, 3);

-- 插入生物教师（孟芳，ID=66）与三班的关联
INSERT INTO Teachers_Classes (TeacherId, ClassId) VALUES (66, 3);

-- 插入体育教师（江浩，ID=72）与三班的关联
INSERT INTO Teachers_Classes (TeacherId, ClassId) VALUES (72, 3);

-- 插入音乐教师（柳琴，ID=75）与三班的关联
INSERT INTO Teachers_Classes (TeacherId, ClassId) VALUES (75, 3);

-- 为高中三班30名学生插入成绩数据（ExamId = 1）
-- 注意：教师ID已调整为匹配最新的教师分配

-- 注意：教师ID已匹配现有教师表（如物理教师ID=85，化学教师ID=88等）

-- StudentId=25（彭一）
INSERT INTO scores (Number, StudentId, CourseId, TeacherId, ClassId, GradeId, ExamId, insertTime) VALUES
(85, 25, 7, 81, 3, 1, 1, NOW()),  -- 语文
(90, 25, 8, 84, 3, 1, 1, NOW()),  -- 数学
(88, 25, 9, 87, 3, 1, 1, NOW()),  -- 英语
(87, 25, 1, 85, 3, 1, 1, NOW()),  -- 物理
(90, 25, 2, 88, 3, 1, 1, NOW()),  -- 化学
(89, 25, 3, 66, 3, 1, 1, NOW());  -- 生物

-- StudentId=26（吕二）
INSERT INTO scores (Number, StudentId, CourseId, TeacherId, ClassId, GradeId, ExamId, insertTime) VALUES
(86, 26, 7, 81, 3, 1, 1, NOW()),
(88, 26, 8, 84, 3, 1, 1, NOW()),
(85, 26, 9, 87, 3, 1, 1, NOW()),
(89, 26, 1, 85, 3, 1, 1, NOW()),
(87, 26, 2, 88, 3, 1, 1, NOW()),
(86, 26, 3, 66, 3, 1, 1, NOW());

-- StudentId=27（施三）
INSERT INTO scores (Number, StudentId, CourseId, TeacherId, ClassId, GradeId, ExamId, insertTime) VALUES
(84, 27, 7, 81, 3, 1, 1, NOW()),
(89, 27, 8, 84, 3, 1, 1, NOW()),
(83, 27, 9, 87, 3, 1, 1, NOW()),
(88, 27, 1, 85, 3, 1, 1, NOW()),
(85, 27, 2, 88, 3, 1, 1, NOW()),
(87, 27, 3, 66, 3, 1, 1, NOW());

-- StudentId=28（张四）
INSERT INTO scores (Number, StudentId, CourseId, TeacherId, ClassId, GradeId, ExamId, insertTime) VALUES
(87, 28, 7, 81, 3, 1, 1, NOW()),
(86, 28, 8, 84, 3, 1, 1, NOW()),
(88, 28, 9, 87, 3, 1, 1, NOW()),
(85, 28, 1, 85, 3, 1, 1, NOW()),
(89, 28, 2, 88, 3, 1, 1, NOW()),
(86, 28, 3, 66, 3, 1, 1, NOW());

-- StudentId=29（孔五）
INSERT INTO scores (Number, StudentId, CourseId, TeacherId, GradeId, ClassId,ExamId, insertTime) VALUES
(83, 29, 7, 81, 3, 1, 1, NOW()),
(87, 29, 8, 84, 3, 1, 1, NOW()),
(84, 29, 9, 87, 3, 1, 1, NOW()),
(86, 29, 1, 85, 3, 1, 1, NOW()),
(85, 29, 2, 88, 3, 1, 1, NOW()),
(88, 29, 3, 66, 3, 1, 1, NOW());

-- StudentId=30（严六）
INSERT INTO scores (Number, StudentId, CourseId, TeacherId,ClassId, GradeId,ExamId, insertTime) VALUES
(82, 30, 7, 81, 3, 1, 1, NOW()),
(85, 30, 8, 84, 3, 1, 1, NOW()),
(83, 30, 9, 87, 3, 1, 1, NOW()),
(84, 30, 1, 85, 3, 1, 1, NOW()),
(86, 30, 2, 88, 3, 1, 1, NOW()),
(85, 30, 3, 66, 3, 1, 1, NOW());

-- 张甲（StudentId=31）
INSERT INTO scores (Number, StudentId, CourseId, TeacherId, ClassId, GradeId, ExamId, insertTime) VALUES
(85, 31, 7, 81, 3, 1, 1, NOW()),  -- 语文（杨雪，ID=81）
(92, 31, 8, 84, 3, 1, 1, NOW()),  -- 数学（赵阳，ID=84，班主任）
(88, 31, 9, 87, 3, 1, 1, NOW()),  -- 英语（郑悦，ID=87）
(87, 31, 1, 85, 3, 1, 1, NOW()),  -- 物理（郭佳，ID=85）
(90, 31, 2, 88, 3, 1, 1, NOW()),  -- 化学（苏曼，ID=88）
(89, 31, 3, 66, 3, 1, 1, NOW()),  -- 生物（孟芳，ID=66）
(75, 31, 10, 72, 3, 1, 1, NOW()), -- 体育（江浩，ID=72）
(82, 31, 11, 75, 3, 1, 1, NOW()), -- 音乐（柳琴，ID=75）
(78, 31, 12, 78, 3, 1, 1, NOW()); -- 美术（田甜，ID=78）

-- 李乙（StudentId=32）
INSERT INTO scores (Number, StudentId, CourseId, TeacherId, ClassId, GradeId, ExamId, insertTime) VALUES
(88, 32, 7, 81, 3, 1, 1, NOW()),  -- 语文
(87, 32, 8, 84, 3, 1, 1, NOW()),  -- 数学
(85, 32, 9, 87, 3, 1, 1, NOW()),  -- 英语
(91, 32, 1, 85, 3, 1, 1, NOW()),  -- 物理
(86, 32, 2, 88, 3, 1, 1, NOW()),  -- 化学
(83, 32, 3, 66, 3, 1, 1, NOW()),  -- 生物
(80, 32, 10, 72, 3, 1, 1, NOW()), -- 体育
(76, 32, 11, 75, 3, 1, 1, NOW()), -- 音乐
(81, 32, 12, 78, 3, 1, 1, NOW()); -- 美术

-- 王丙（StudentId=33）
INSERT INTO scores (Number, StudentId, CourseId, TeacherId, ClassId, GradeId, ExamId, insertTime) VALUES
(92, 33, 7, 81, 3, 1, 1, NOW()),  -- 语文
(85, 33, 8, 84, 3, 1, 1, NOW()),  -- 数学
(90, 33, 9, 87, 3, 1, 1, NOW()),  -- 英语
(84, 33, 1, 85, 3, 1, 1, NOW()),  -- 物理
(89, 33, 2, 88, 3, 1, 1, NOW()),  -- 化学
(91, 33, 3, 66, 3, 1, 1, NOW()),  -- 生物
(85, 33, 10, 72, 3, 1, 1, NOW()), -- 体育
(79, 33, 11, 75, 3, 1, 1, NOW()), -- 音乐
(77, 33, 12, 78, 3, 1, 1, NOW()); -- 美术

-- 赵丁（StudentId=34）
INSERT INTO scores (Number, StudentId, CourseId, TeacherId, ClassId, GradeId, ExamId, insertTime) VALUES
(84, 34, 7, 81, 3, 1, 1, NOW()),  -- 语文
(89, 34, 8, 84, 3, 1, 1, NOW()),  -- 数学
(83, 34, 9, 87, 3, 1, 1, NOW()),  -- 英语
(88, 34, 1, 85, 3, 1, 1, NOW()),  -- 物理
(85, 34, 2, 88, 3, 1, 1, NOW()),  -- 化学
(87, 34, 3, 66, 3, 1, 1, NOW()),  -- 生物
(78, 34, 10, 72, 3, 1, 1, NOW()), -- 体育
(83, 34, 11, 75, 3, 1, 1, NOW()), -- 音乐
(80, 34, 12, 78, 3, 1, 1, NOW()); -- 美术

-- 孙戊（StudentId=35）
INSERT INTO scores (Number, StudentId, CourseId, TeacherId, ClassId, GradeId, ExamId, insertTime) VALUES
(86, 35, 7, 81, 3, 1, 1, NOW()),  -- 语文
(83, 35, 8, 84, 3, 1, 1, NOW()),  -- 数学
(87, 35, 9, 87, 3, 1, 1, NOW()),  -- 英语
(85, 35, 1, 85, 3, 1, 1, NOW()),  -- 物理
(90, 35, 2, 88, 3, 1, 1, NOW()),  -- 化学
(84, 35, 3, 66, 3, 1, 1, NOW()),  -- 生物
(82, 35, 10, 72, 3, 1, 1, NOW()), -- 体育
(77, 35, 11, 75, 3, 1, 1, NOW()), -- 音乐
(83, 35, 12, 78, 3, 1, 1, NOW()); -- 美术

-- 周己（StudentId=36）
INSERT INTO scores (Number, StudentId, CourseId, TeacherId, ClassId, GradeId, ExamId, insertTime) VALUES
(81, 36, 7, 81, 3, 1, 1, NOW()),  -- 语文
(88, 36, 8, 84, 3, 1, 1, NOW()),  -- 数学
(82, 36, 9, 87, 3, 1, 1, NOW()),  -- 英语
(89, 36, 1, 85, 3, 1, 1, NOW()),  -- 物理
(86, 36, 2, 88, 3, 1, 1, NOW()),  -- 化学
(85, 36, 3, 66, 3, 1, 1, NOW()),  -- 生物
(79, 36, 10, 72, 3, 1, 1, NOW()), -- 体育
(81, 36, 11, 75, 3, 1, 1, NOW()), -- 音乐
(76, 36, 12, 78, 3, 1, 1, NOW()); -- 美术

-- 吴庚（StudentId=37）
INSERT INTO scores (Number, StudentId, CourseId, TeacherId, ClassId, GradeId, ExamId, insertTime) VALUES
(89, 37, 7, 81, 3, 1, 1, NOW()),  -- 语文
(86, 37, 8, 84, 3, 1, 1, NOW()),  -- 数学
(84, 37, 9, 87, 3, 1, 1, NOW()),  -- 英语
(83, 37, 1, 85, 3, 1, 1, NOW()),  -- 物理
(88, 37, 2, 88, 3, 1, 1, NOW()),  -- 化学
(90, 37, 3, 66, 3, 1, 1, NOW()),  -- 生物
(83, 37, 10, 72, 3, 1, 1, NOW()), -- 体育
(78, 37, 11, 75, 3, 1, 1, NOW()), -- 音乐
(82, 37, 12, 78, 3, 1, 1, NOW()); -- 美术

-- 郑辛（StudentId=38）
INSERT INTO scores (Number, StudentId, CourseId, TeacherId, ClassId, GradeId, ExamId, insertTime) VALUES
(83, 38, 7, 81, 3, 1, 1, NOW()),  -- 语文
(84, 38, 8, 84, 3, 1, 1, NOW()),  -- 数学
(89, 38, 9, 87, 3, 1, 1, NOW()),  -- 英语
(86, 38, 1, 85, 3, 1, 1, NOW()),  -- 物理
(84, 38, 2, 88, 3, 1, 1, NOW()),  -- 化学
(88, 38, 3, 66, 3, 1, 1, NOW()),  -- 生物
(80, 38, 10, 72, 3, 1, 1, NOW()), -- 体育
(82, 38, 11, 75, 3, 1, 1, NOW()), -- 音乐
(79, 38, 12, 78, 3, 1, 1, NOW()); -- 美术

-- 钱壬（StudentId=39）
INSERT INTO scores (Number, StudentId, CourseId, TeacherId, ClassId, GradeId, ExamId, insertTime) VALUES
(87, 39, 7, 81, 3, 1, 1, NOW()),  -- 语文
(82, 39, 8, 84, 3, 1, 1, NOW()),  -- 数学
(86, 39, 9, 87, 3, 1, 1, NOW()),  -- 英语
(85, 39, 1, 85, 3, 1, 1, NOW()),  -- 物理
(87, 39, 2, 88, 3, 1, 1, NOW()),  -- 化学
(83, 39, 3, 66, 3, 1, 1, NOW()),  -- 生物
(84, 39, 10, 72, 3, 1, 1, NOW()), -- 体育
(79, 39, 11, 75, 3, 1, 1, NOW()), -- 音乐
(77, 39, 12, 78, 3, 1, 1, NOW()); -- 美术

-- 冯癸（StudentId=40）
INSERT INTO scores (Number, StudentId, CourseId, TeacherId, ClassId, GradeId, ExamId, insertTime) VALUES
(85, 40, 7, 81, 3, 1, 1, NOW()),  -- 语文
(90, 40, 8, 84, 3, 1, 1, NOW()),  -- 数学
(85, 40, 9, 87, 3, 1, 1, NOW()),  -- 英语
(84, 40, 1, 85, 3, 1, 1, NOW()),  -- 物理
(89, 40, 2, 88, 3, 1, 1, NOW()),  -- 化学
(86, 40, 3, 66, 3, 1, 1, NOW()),  -- 生物
(81, 40, 10, 72, 3, 1, 1, NOW()), -- 体育
(80, 40, 11, 75, 3, 1, 1, NOW()), -- 音乐
(84, 40, 12, 78, 3, 1, 1, NOW()); -- 美术

-- 陈子（StudentId=41）
INSERT INTO scores (Number, StudentId, CourseId, TeacherId, ClassId, GradeId, ExamId, insertTime) VALUES
(82, 41, 7, 81, 3, 1, 1, NOW()),  -- 语文
(87, 41, 8, 84, 3, 1, 1, NOW()),  -- 数学
(83, 41, 9, 87, 3, 1, 1, NOW()),  -- 英语
(88, 41, 1, 85, 3, 1, 1, NOW()),  -- 物理
(85, 41, 2, 88, 3, 1, 1, NOW()),  -- 化学
(87, 41, 3, 66, 3, 1, 1, NOW()),  -- 生物
(79, 41, 10, 72, 3, 1, 1, NOW()), -- 体育
(83, 41, 11, 75, 3, 1, 1, NOW()), -- 音乐
(78, 41, 12, 78, 3, 1, 1, NOW()); -- 美术

-- 杨丑（StudentId=42）
INSERT INTO scores (Number, StudentId, CourseId, TeacherId, ClassId, GradeId, ExamId, insertTime) VALUES
(88, 42, 7, 81, 3, 1, 1, NOW()),  -- 语文
(85, 42, 8, 84, 3, 1, 1, NOW()),  -- 数学
(89, 42, 9, 87, 3, 1, 1, NOW()),  -- 英语
(83, 42, 1, 85, 3, 1, 1, NOW()),  -- 物理
(86, 42, 2, 88, 3, 1, 1, NOW()),  -- 化学
(84, 42, 3, 66, 3, 1, 1, NOW()),  -- 生物
(82, 42, 10, 72, 3, 1, 1, NOW()), -- 体育
(80, 42, 11, 75, 3, 1, 1, NOW()), -- 音乐
(81, 42, 12, 78, 3, 1, 1, NOW()); -- 美术

INSERT INTO scores (Number, StudentId, CourseId, TeacherId, ClassId, GradeId, ExamId, insertTime) VALUES
(84, 43, 7, 81, 3, 1, 1, NOW()),  -- 语文
(83, 43, 8, 84, 3, 1, 1, NOW()),  -- 数学
(87, 43, 9, 87, 3, 1, 1, NOW()),  -- 英语
(86, 43, 1, 85, 3, 1, 1, NOW()),  -- 物理
(84, 43, 2, 88, 3, 1, 1, NOW()),  -- 化学
(89, 43, 3, 66, 3, 1, 1, NOW()),  -- 生物
(85, 43, 10, 72, 3, 1, 1, NOW()), -- 体育
(77, 43, 11, 75, 3, 1, 1, NOW()), -- 音乐
(79, 43, 12, 78, 3, 1, 1, NOW()); -- 美术

INSERT INTO scores (Number, StudentId, CourseId, TeacherId, ClassId, GradeId, ExamId, insertTime) VALUES
(86, 44, 7, 81, 3, 1, 1, NOW()),  -- 语文
(89, 44, 8, 84, 3, 1, 1, NOW()),  -- 数学
(84, 44, 9, 87, 3, 1, 1, NOW()),  -- 英语
(85, 44, 1, 85, 3, 1, 1, NOW()),  -- 物理
(88, 44, 2, 88, 3, 1, 1, NOW()),  -- 化学
(85, 44, 3, 66, 3, 1, 1, NOW()),  -- 生物
(80, 44, 10, 72, 3, 1, 1, NOW()), -- 体育
(81, 44, 11, 75, 3, 1, 1, NOW()), -- 音乐
(83, 44, 12, 78, 3, 1, 1, NOW()); -- 美术

INSERT INTO scores (Number, StudentId, CourseId, TeacherId, ClassId, GradeId, ExamId, insertTime) VALUES
(81, 45, 7, 81, 3, 1, 1, NOW()),  -- 语文
(86, 45, 8, 84, 3, 1, 1, NOW()),  -- 数学
(82, 45, 9, 87, 3, 1, 1, NOW()),  -- 英语
(89, 45, 1, 85, 3, 1, 1, NOW()),  -- 物理
(86, 45, 2, 88, 3, 1, 1, NOW()),  -- 化学
(83, 45, 3, 66, 3, 1, 1, NOW()),  -- 生物
(83, 45, 10, 72, 3, 1, 1, NOW()), -- 体育
(79, 45, 11, 75, 3, 1, 1, NOW()), -- 音乐
(77, 45, 12, 78, 3, 1, 1, NOW()); -- 美术

INSERT INTO scores (Number, StudentId, CourseId, TeacherId, ClassId, GradeId, ExamId, insertTime) VALUES
(89, 46, 7, 81, 3, 1, 1, NOW()),  -- 语文
(84, 46, 8, 84, 3, 1, 1, NOW()),  -- 数学
(88, 46, 9, 87, 3, 1, 1, NOW()),  -- 英语
(84, 46, 1, 85, 3, 1, 1, NOW()),  -- 物理
(87, 46, 2, 88, 3, 1, 1, NOW()),  -- 化学
(86, 46, 3, 66, 3, 1, 1, NOW()),  -- 生物
(81, 46, 10, 72, 3, 1, 1, NOW()), -- 体育
(82, 46, 11, 75, 3, 1, 1, NOW()), -- 音乐
(80, 46, 12, 78, 3, 1, 1, NOW()); -- 美术

INSERT INTO scores (Number, StudentId, CourseId, TeacherId, ClassId, GradeId, ExamId, insertTime) VALUES
(83, 47, 7, 81, 3, 1, 1, NOW()),  -- 语文
(82, 47, 8, 84, 3, 1, 1, NOW()),  -- 数学
(86, 47, 9, 87, 3, 1, 1, NOW()),  -- 英语
(88, 47, 1, 85, 3, 1, 1, NOW()),  -- 物理
(85, 47, 2, 88, 3, 1, 1, NOW()),  -- 化学
(84, 47, 3, 66, 3, 1, 1, NOW()),  -- 生物
(84, 47, 10, 72, 3, 1, 1, NOW()), -- 体育
(78, 47, 11, 75, 3, 1, 1, NOW()), -- 音乐
(82, 47, 12, 78, 3, 1, 1, NOW()); -- 美术

INSERT INTO scores (Number, StudentId, CourseId, TeacherId, ClassId, GradeId, ExamId, insertTime) VALUES
(87, 48, 7, 81, 3, 1, 1, NOW()),  -- 语文
(88, 48, 8, 84, 3, 1, 1, NOW()),  -- 数学
(85, 48, 9, 87, 3, 1, 1, NOW()),  -- 英语
(83, 48, 1, 85, 3, 1, 1, NOW()),  -- 物理
(87, 48, 2, 88, 3, 1, 1, NOW()),  -- 化学
(89, 48, 3, 66, 3, 1, 1, NOW()),  -- 生物
(80, 48, 10, 72, 3, 1, 1, NOW()), -- 体育
(81, 48, 11, 75, 3, 1, 1, NOW()), -- 音乐
(79, 48, 12, 78, 3, 1, 1, NOW()); -- 美术

INSERT INTO scores (Number, StudentId, CourseId, TeacherId, ClassId, GradeId, ExamId, insertTime) VALUES
(85, 49, 7, 81, 3, 1, 1, NOW()),  -- 语文
(86, 49, 8, 84, 3, 1, 1, NOW()),  -- 数学
(83, 49, 9, 87, 3, 1, 1, NOW()),  -- 英语
(86, 49, 1, 85, 3, 1, 1, NOW()),  -- 物理
(84, 49, 2, 88, 3, 1, 1, NOW()),  -- 化学
(87, 49, 3, 66, 3, 1, 1, NOW()),  -- 生物
(85, 49, 10, 72, 3, 1, 1, NOW()), -- 体育
(77, 49, 11, 75, 3, 1, 1, NOW()), -- 音乐
(81, 49, 12, 78, 3, 1, 1, NOW()); -- 美术

INSERT INTO scores (Number, StudentId, CourseId, TeacherId, ClassId, GradeId, ExamId, insertTime) VALUES
(82, 50, 7, 81, 3, 1, 1, NOW()),  -- 语文
(84, 50, 8, 84, 3, 1, 1, NOW()),  -- 数学
(89, 50, 9, 87, 3, 1, 1, NOW()),  -- 英语
(85, 50, 1, 85, 3, 1, 1, NOW()),  -- 物理
(88, 50, 2, 88, 3, 1, 1, NOW()),  -- 化学
(85, 50, 3, 66, 3, 1, 1, NOW()),  -- 生物
(82, 50, 10, 72, 3, 1, 1, NOW()), -- 体育
(80, 50, 11, 75, 3, 1, 1, NOW()), -- 音乐
(83, 50, 12, 78, 3, 1, 1, NOW()); -- 美术

INSERT INTO scores (Number, StudentId, CourseId, TeacherId, ClassId, GradeId, ExamId, insertTime) VALUES
(88, 51, 7, 81, 3, 1, 1, NOW()),  -- 语文
(83, 51, 8, 84, 3, 1, 1, NOW()),  -- 数学
(87, 51, 9, 87, 3, 1, 1, NOW()),  -- 英语
(84, 51, 1, 85, 3, 1, 1, NOW()),  -- 物理
(86, 51, 2, 88, 3, 1, 1, NOW()),  -- 化学
(84, 51, 3, 66, 3, 1, 1, NOW()),  -- 生物
(83, 51, 10, 72, 3, 1, 1, NOW()), -- 体育
(79, 51, 11, 75, 3, 1, 1, NOW()), -- 音乐
(78, 51, 12, 78, 3, 1, 1, NOW()); -- 美术

INSERT INTO scores (Number, StudentId, CourseId, TeacherId, ClassId, GradeId, ExamId, insertTime) VALUES
(84, 52, 7, 81, 3, 1, 1, NOW()),  -- 语文
(89, 52, 8, 84, 3, 1, 1, NOW()),  -- 数学
(85, 52, 9, 87, 3, 1, 1, NOW()),  -- 英语
(83, 52, 1, 85, 3, 1, 1, NOW()),  -- 物理
(87, 52, 2, 88, 3, 1, 1, NOW()),  -- 化学
(88, 52, 3, 66, 3, 1, 1, NOW()),  -- 生物
(81, 52, 10, 72, 3, 1, 1, NOW()), -- 体育
(82, 52, 11, 75, 3, 1, 1, NOW()), -- 音乐
(80, 52, 12, 78, 3, 1, 1, NOW()); -- 美术

INSERT INTO scores (Number, StudentId, CourseId, TeacherId, ClassId, GradeId, ExamId, insertTime) VALUES
(86, 53, 7, 81, 3, 1, 1, NOW()),  -- 语文
(85, 53, 8, 84, 3, 1, 1, NOW()),  -- 数学
(84, 53, 9, 87, 3, 1, 1, NOW()),  -- 英语
(87, 53, 1, 85, 3, 1, 1, NOW()),  -- 物理
(85, 53, 2, 88, 3, 1, 1, NOW()),  -- 化学
(86, 53, 3, 66, 3, 1, 1, NOW()),  -- 生物
(84, 53, 10, 72, 3, 1, 1, NOW()), -- 体育
(78, 53, 11, 75, 3, 1, 1, NOW()), -- 音乐
(82, 53, 12, 78, 3, 1, 1, NOW()); -- 美术

INSERT INTO scores (Number, StudentId, CourseId, TeacherId, ClassId, GradeId, ExamId, insertTime) VALUES
(81, 54, 7, 81, 3, 1, 1, NOW()),  -- 语文
(87, 54, 8, 84, 3, 1, 1, NOW()),  -- 数学
(82, 54, 9, 87, 3, 1, 1, NOW()),  -- 英语
(89, 54, 1, 85, 3, 1, 1, NOW()),  -- 物理
(86, 54, 2, 88, 3, 1, 1, NOW()),  -- 化学
(85, 54, 3, 66, 3, 1, 1, NOW()),  -- 生物
(80, 54, 10, 72, 3, 1, 1, NOW()), -- 体育
(81, 54, 11, 75, 3, 1, 1, NOW()), -- 音乐
(79, 54, 12, 78, 3, 1, 1, NOW()); -- 美术

INSERT INTO scores (Number, StudentId, CourseId, TeacherId, ClassId, GradeId, ExamId, insertTime) VALUES
(89, 55, 7, 81, 3, 1, 1, NOW()),  -- 语文
(84, 55, 8, 84, 3, 1, 1, NOW()),  -- 数学
(88, 55, 9, 87, 3, 1, 1, NOW()),
(84, 55, 1, 85, 3, 1, 1, NOW()),  -- 物理
(87, 55, 2, 88, 3, 1, 1, NOW()),  -- 化学
(83, 55, 3, 66, 3, 1, 1, NOW()),  -- 生物
(85, 55, 10, 72, 3, 1, 1, NOW()), -- 体育
(77, 55, 11, 75, 3, 1, 1, NOW()), -- 音乐
(81, 55, 12, 78, 3, 1, 1, NOW()); -- 美术


INSERT INTO scores (Number, StudentId, CourseId, TeacherId, ClassId, GradeId, ExamId, insertTime) VALUES
(83, 56, 7, 81, 3, 1, 1, NOW()),  -- 语文
(82, 56, 8, 84, 3, 1, 1, NOW()),  -- 数学
(86, 56, 9, 87, 3, 1, 1, NOW()),  -- 英语
(88, 56, 1, 85, 3, 1, 1, NOW()),  -- 物理
(85, 56, 2, 88, 3, 1, 1, NOW()),  -- 化学
(89, 56, 3, 66, 3, 1, 1, NOW()),  -- 生物
(82, 56, 10, 72, 3, 1, 1, NOW()), -- 体育
(80, 56, 11, 75, 3, 1, 1, NOW()), -- 音乐
(83, 56, 12, 78, 3, 1, 1, NOW()); -- 美术

INSERT INTO scores (Number, StudentId, CourseId, TeacherId, ClassId, GradeId, ExamId, insertTime) VALUES
(87, 57, 7, 81, 3, 1, 1, NOW()),  -- 语文
(88, 57, 8, 84, 3, 1, 1, NOW()),  -- 数学
(85, 57, 9, 87, 3, 1, 1, NOW()),  -- 英语
(83, 57, 1, 85, 3, 1, 1, NOW()),  -- 物理
(87, 57, 2, 88, 3, 1, 1, NOW()),  -- 化学
(84, 57, 3, 66, 3, 1, 1, NOW()),  -- 生物
(80, 57, 10, 72, 3, 1, 1, NOW()), -- 体育
(81, 57, 11, 75, 3, 1, 1, NOW()), -- 音乐
(79, 57, 12, 78, 3, 1, 1, NOW()); -- 美术

INSERT INTO scores (Number, StudentId, CourseId, TeacherId, ClassId, GradeId, ExamId, insertTime) VALUES
(88, 60, 7, 81, 3, 1, 1, NOW()),  -- 语文
(83, 60, 8, 84, 3, 1, 1, NOW()),  -- 数学
(87, 60, 9, 87, 3, 1, 1, NOW()),  -- 英语
(84, 60, 1, 85, 3, 1, 1, NOW()),  -- 物理
(86, 60, 2, 88, 3, 1, 1, NOW()),  -- 化学
(84, 60, 3, 66, 3, 1, 1, NOW()),  -- 生物
(83, 60, 10, 72, 3, 1, 1, NOW()), -- 体育
(79, 60, 11, 75, 3, 1, 1, NOW()), -- 音乐
(78, 60, 12, 78, 3, 1, 1, NOW()); -- 美术
