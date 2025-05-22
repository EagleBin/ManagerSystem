
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
INSERT INTO `menu` VALUES (6, '成绩管理', 'InformationManager.GradeView', 'ue601', 1, 1, '2024-03-01 14:23:37', '2024-03-15 17:28:52');
INSERT INTO `menu` VALUES (7, '教师管理', 'InformationManager.TeacherView', 'ue63b', 1, 1, '2024-03-01 14:23:37', '2024-03-15 17:28:52');


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

