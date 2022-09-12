-- phpMyAdmin SQL Dump
-- version 4.9.7
-- https://www.phpmyadmin.net/
--
-- Máy chủ: localhost:3306
-- Thời gian đã tạo: Th8 25, 2022 lúc 09:02 PM
-- Phiên bản máy phục vụ: 10.3.35-MariaDB-cll-lve
-- Phiên bản PHP: 7.4.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Cơ sở dữ liệu: `tantuanh_inventory`
--

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `Customer`
--

CREATE TABLE `Customer` (
  `ID` bigint(20) NOT NULL,
  `CustomerCode` varchar(50) DEFAULT NULL,
  `Name` varchar(100) NOT NULL,
  `Phone` varchar(11) DEFAULT NULL,
  `Address` varchar(150) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Đang đổ dữ liệu cho bảng `Customer`
--

INSERT INTO `Customer` (`ID`, `CustomerCode`, `Name`, `Phone`, `Address`) VALUES
(1, 'KH_VANGLAI', 'Khách Vãng Lai', NULL, NULL),
(2, 'KH_1', 'Test', '0123456789', '156 duong so 1'),
(3, 'KH_2', 'Test 2', '0777234510', 'Binh chanh'),
(4, 'KH_3', 'Gia Cường', '0777234510', '152 gò xoài'),
(5, 'KH_4', 'Gia Phát', '940324342', 'Bình chánh'),
(6, 'KH8182022_132159', 'Gia Phú', 'Chưa thêm S', 'Chưa có địa chỉ'),
(7, 'KH8182022_132756', 'Bảo Huy', 'Chưa thêm S', 'Chưa có địa chỉ'),
(8, 'KH8182022_132943', 'Bảo Thi', 'Chưa thêm S', 'Chưa có địa chỉ'),
(9, 'KH8182022_133328', 'Hoài Bảo', 'Chưa thêm S', 'Chưa có địa chỉ'),
(10, 'KH8182022_133751', 'Gia Khánh', 'Chưa thêm S', 'Chưa có địa chỉ'),
(11, 'KH8252022_103704', 'Test 25/8/2022', 'Chưa thêm S', 'Chưa có địa chỉ'),
(12, 'KH8252022_110010', 'test lan 2 25/8/2022', 'Chưa thêm S', 'Chưa có địa chỉ'),
(13, 'KH8252022_111405', 'Test phieu tra 25/8/2022', 'Chưa thêm S', 'Chưa có địa chỉ');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `Export`
--

CREATE TABLE `Export` (
  `ID` bigint(20) NOT NULL,
  `Code` varchar(50) NOT NULL,
  `CustomerCode` varchar(50) DEFAULT NULL,
  `Time` datetime NOT NULL,
  `Delivery` varchar(100) DEFAULT NULL,
  `Status` tinyint(1) NOT NULL,
  `Note` text DEFAULT NULL,
  `UserID` bigint(20) NOT NULL,
  `ExportDelete` tinyint(1) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Đang đổ dữ liệu cho bảng `Export`
--

INSERT INTO `Export` (`ID`, `Code`, `CustomerCode`, `Time`, `Delivery`, `Status`, `Note`, `UserID`, `ExportDelete`) VALUES
(1, 'EP822022_02044', 'KH_1', '2022-08-02 12:20:00', 'Cuong', 0, 'fsdgdfghdfh', 1, 0),
(2, 'EP822022_150307', 'KH_1', '2022-08-02 15:02:00', 'dfsfsdfsd', 0, 'gfdgdfgfd', 1, 0),
(3, 'EP822022_150921', 'KH_2', '2022-08-02 15:09:00', 'dsafas', 0, 'dfsfds', 1, 0),
(4, 'EP822022_150943', 'KH_2', '2022-08-01 15:09:00', 'fgdgdf', 0, '45343gdfdf', 1, 0),
(5, 'EP822022_163417', 'KH_2', '2022-08-02 16:33:00', 'fdsfds', 0, 'fdsfsd', 1, 0),
(6, 'EP822022_164108', 'KH_1', '2022-08-01 16:34:00', 'dfsfds', 0, 'fdss', 1, 0),
(7, 'EP822022_164128', 'KH_2', '2022-08-02 16:41:00', '432423', 0, 'fbgfdgdf', 1, 0),
(8, 'EP822022_164411', 'KH_2', '2022-08-01 16:43:00', 'fafsdfdsf', 0, 'bcbvcbcvb', 1, 0),
(9, 'EP822022_164858', 'KH_1', '2022-07-02 16:48:00', 'fasfdsa', 0, 'fdsfsd', 1, 0),
(10, 'EP842022_115256', 'KH_2', '2022-08-04 11:52:00', 'sdacvx', 0, 'fdsfds', 1, 0),
(11, 'EP842022_170754', 'KH_2', '2022-08-04 17:05:00', 'sfdsfds', 0, NULL, 1, 0),
(12, 'EP852022_134600', 'KH_1', '2022-08-05 13:45:00', NULL, 0, NULL, 1, 0),
(13, 'EP852022_134736', 'KH_1', '2022-08-05 01:47:00', NULL, 1, NULL, 1, 0),
(14, 'EP862022_05301', 'KH_1', '2022-08-06 12:52:00', NULL, 1, NULL, 1, 0),
(15, 'EP862022_130128', 'KH_2', '2022-08-06 13:01:00', NULL, 0, NULL, 1, 0),
(16, 'EP8112022_133300', 'KH_2', '2022-08-11 13:32:00', 'fdafds', 0, 'fdsfds', 1, 0),
(17, 'EP8112022_135233', 'KH_1', '2022-08-10 13:52:00', 'fdsfds', 0, 'fds', 1, 0),
(18, 'EP8172022_214036', 'KH_2', '2022-08-17 21:39:00', NULL, 0, NULL, 1, 0),
(19, 'EP8172022_215529', 'KH_VANGLAI', '2022-08-17 21:55:00', NULL, 0, NULL, 1, 0),
(20, 'EP8182022_024708', 'KH_3', '2022-08-18 02:47:00', '543534', 0, '543', 1, 0),
(21, 'EP8182022_024808', 'KH_3', '2022-08-18 02:47:00', 'sdadsa', 0, 'fdsfdsfds', 1, 0),
(22, 'EP8182022_024913', 'KH_2', '2022-08-18 02:49:00', 'sdadas', 0, 'dsadsa', 1, 0),
(23, 'EP8182022_130919', 'KH_1', '2022-08-18 13:09:00', 'SDALKJDS', 0, 'SDALKJDS', 1, 0),
(24, 'EP8182022_131459', 'KH_3', '2022-08-18 13:13:00', 'ssda', 0, 'dasdsa', 1, 0),
(25, 'EP8182022_131623', 'KH_2', '2022-08-18 13:16:00', 'sdasdas', 0, 'sdadsa', 1, 0),
(26, 'EP8182022_131827', 'KH_VANGLAI', '2022-08-18 13:17:00', 'dsadsa', 0, 'dsadsa', 1, 0),
(27, 'EP8182022_132014', 'KH_VANGLAI', '2022-08-18 13:19:00', 'sdadsa', 0, 'dsadsa', 1, 0),
(28, 'EP8182022_132112', 'KH_2', '2022-08-18 13:20:00', 'dsadsa', 0, 'dsads', 1, 0),
(29, 'EP8182022_132148', 'KH8182022_132159', '2022-08-18 01:21:00', 'Phú', 0, 'dsa', 1, 0),
(30, 'EP8182022_132729', 'KH_3', '2022-08-18 01:25:00', 'Phắt', 1, 'new', 1, 0),
(31, 'EP8182022_132756', 'KH8182022_132756', '2022-08-18 01:27:00', 'Ken', 0, 'abc', 1, 0),
(32, 'EP8182022_132925', 'KH8182022_132756', '2022-08-18 01:28:00', 'Phú', 1, 'abcdef', 1, 0),
(33, 'EP8182022_132943', 'KH8182022_132943', '2022-08-18 01:29:00', NULL, 1, NULL, 1, 0),
(34, 'EP8182022_133719', 'KH_VANGLAI', '2022-08-18 01:36:00', 'Thuận', 1, 'âbasdadsa', 1, 0),
(35, 'EP8182022_133751', 'KH8182022_133751', '2022-08-18 01:37:00', 'abc', 1, 'dsadasd', 1, 0),
(36, 'EP8182022_140620', 'KH_3', '2022-08-18 02:05:00', 'sadsad', 1, 'heelo', 1, 0),
(37, 'EP8182022_173800', 'KH8182022_133328', '2022-08-18 05:37:00', 'Ken', 0, 'abc', 1, 0),
(38, 'EP8252022_104424', 'KH_2', '2022-08-25 10:43:00', 'TEST', 0, 'TEST', 1, 0),
(39, 'EP8252022_105733', 'KH8252022_103704', '2022-08-25 10:57:00', 'test 2', 1, 'abcdef', 1, 0),
(40, 'EP8252022_110010', 'KH8252022_110010', '2022-08-25 10:59:00', 'cuong', 1, 'abcdef', 1, 0),
(41, 'EP8252022_110031', 'KH8252022_103704', '2022-08-25 11:00:00', 'Phắt', 1, 'test', 1, 0),
(42, 'EP8252022_04122', 'KH_VANGLAI', '2022-08-25 12:41:00', 'abcd', 1, 'ef', 2, 0),
(43, 'EP8252022_204333', 'KH_4', '2022-08-06 20:43:00', 'abc', 0, NULL, 1, 0),
(44, 'EP8252022_204848', 'KH8252022_110010', '2022-07-25 08:43:00', 'Phắt', 0, NULL, 1, 0);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `ExportDetail`
--

CREATE TABLE `ExportDetail` (
  `ID` bigint(20) NOT NULL,
  `ExportCode` varchar(50) CHARACTER SET utf8 NOT NULL,
  `ProductCode` varchar(30) NOT NULL,
  `Price` decimal(18,0) NOT NULL,
  `Quantity` bigint(20) NOT NULL,
  `UnitID` bigint(20) DEFAULT NULL,
  `ExportDetailDelete` tinyint(1) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Đang đổ dữ liệu cho bảng `ExportDetail`
--

INSERT INTO `ExportDetail` (`ID`, `ExportCode`, `ProductCode`, `Price`, `Quantity`, `UnitID`, `ExportDetailDelete`) VALUES
(68, 'EP8112022_133300', 'SP-2', '453543', 43, 0, 0),
(69, 'EP8112022_135233', 'SP-3', '543534', 34, 0, 0),
(70, 'EP8112022_135233', 'SP-2', '53443', 544, 0, 0),
(71, 'EP8172022_214036', 'SP-3', '342432', 32, 0, 0),
(72, 'EP8172022_215529', 'SP-4', '45343', 43, 0, 0),
(73, 'EP8182022_024708', 'SP-4', '345534', 3443, 0, 0),
(74, 'EP8182022_024808', 'SP-2', '54343', 3434, 0, 0),
(75, 'EP8182022_024913', 'SP-4', '45343', 43, 0, 0),
(76, 'EP8182022_130919', 'SP-4', '342433', 342, 0, 0),
(77, 'EP8182022_131459', 'SP-2', '432342', 32, 0, 0),
(78, 'EP8182022_131623', 'SP-3', '43223', 32, 0, 0),
(79, 'EP8182022_131827', 'SP-3', '453543', 3443, 0, 0),
(80, 'EP8182022_132014', 'SP-5', '432423', 32, 0, 0),
(81, 'EP8182022_132112', 'SP-4', '42332', 23, 0, 0),
(82, 'EP8182022_132112', 'SP-5', '432432', 32, 0, 0),
(110, 'EP8182022_140620', 'SP-2', '432432', 3232, 0, 0),
(111, 'EP8182022_140620', 'SP-5', '3000', 30, 0, 0),
(112, 'EP8182022_140620', 'SP-3', '34232', 32, 1, 0),
(116, 'EP8182022_133751', 'SP-3', '32322', 23, 0, 0),
(118, 'EP8182022_132943', 'SP-2', '32324', 23, 0, 0),
(120, 'EP8182022_132756', 'SP-3', '32343', 32, 0, 1),
(121, 'EP8182022_132756', 'SP-1', '34223', 32, 0, 1),
(122, 'EP8182022_133719', 'SP-3', '43232', 323, 0, 0),
(124, 'EP8182022_132925', 'SP-4', '23342', 32, 0, 0),
(125, 'EP8182022_132148', 'SP-3', '42332', 3232, 0, 0),
(126, 'EP8182022_132729', 'SP-3', '3000', 3232, 0, 0),
(127, 'EP8182022_132729', 'SP-2', '321312', 2112, 1, 0),
(130, 'EP8192022_145156', 'SP-4', '50000', 50, 1, 0),
(131, 'EP8192022_145339', 'SP-4', '50000', 5, 1, 0),
(141, 'EP8222022_221511', 'SP-5', '7000', 5, 1, 0),
(142, 'EP8192022_145625', 'SP-1', '50000', 50, 1, 0),
(143, 'EP8192022_145625', 'SP-2', '50000', 50, 1, 0),
(144, 'EP8192022_153913', 'SP-1', '50000', 982, 1, 0),
(145, 'EP8192022_153913', 'SP-2', '50000', 5, 1, 0),
(146, 'EP8242022_205545', 'SP-2', '50000', 555, 1, 0),
(147, 'EP8242022_205545', 'SP-1', '50000', 54, 1, 0),
(153, 'EP8242022_214622', 'SP-1', '50000', 55, 1, 0),
(154, 'EP8242022_214622', 'SP-2', '50000', 555, 1, 0),
(155, 'EP8242022_214622', 'SP-3', '50000', 500, 1, 0),
(156, 'EP8242022_214622', 'SP-5', '7000', 544, 1, 0),
(157, 'EP8182022_173800', 'SP-4', '34232', 32, 1, 0),
(158, 'EP8182022_173800', 'SP-5', '32432', 3223, 1, 0),
(159, 'EP8182022_173800', 'SP-1', '50000', 545, 1, 0),
(160, 'EP8252022_104424', 'SP-1', '50000', 555, 1, 0),
(161, 'EP8252022_104424', 'SP-2', '50000', 555, 1, 0),
(170, 'EP8252022_110010', 'SP-1', '50000', 555, 1, 0),
(171, 'EP8252022_110010', 'SP-2', '50000', 423, 1, 0),
(172, 'EP8252022_110031', 'SP-5', '7000', 55, 1, 0),
(173, 'EP8252022_110031', 'SP-1', '50000', 55, 1, 0),
(174, 'EP8252022_110031', 'SP-6', '43000', 555, 1, 0),
(175, 'EP8252022_110031', 'SP-7', '23000', 55, 1, 0),
(176, 'EP8252022_105733', 'SP-4', '50000', 555, 1, 0),
(178, 'EP8252022_04122', 'SP-3', '50000', 5, 1, 0),
(179, 'EP8252022_204333', 'SP-1', '50000', 2561, 1, 0),
(180, 'EP8252022_204333', 'SP-8', '7000', 2313, 1, 0),
(182, 'EP8252022_204848', 'SP-6', '4500000', 445, 1, 0);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `History`
--

CREATE TABLE `History` (
  `ID` bigint(20) NOT NULL,
  `Text` mediumtext NOT NULL,
  `Date` datetime NOT NULL,
  `ActionKey` varchar(50) NOT NULL,
  `UserName` varchar(50) DEFAULT NULL,
  `Object` varchar(100) DEFAULT NULL,
  `ReceiptCode` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Đang đổ dữ liệu cho bảng `History`
--

INSERT INTO `History` (`ID`, `Text`, `Date`, `ActionKey`, `UserName`, `Object`, `ReceiptCode`) VALUES
(1, '\'admin\' v?a thêm m?i \'danh m?c s?n ph?m \' tên \'X?p den\'', '2022-07-10 20:21:30', 'insert', '', '', NULL),
(2, '\'admin\' v?a thêm m?i \'danh m?c s?n ph?m \' tên \'X?p h?ng\'', '2022-07-10 20:21:37', 'insert', '', '', NULL),
(3, '\'admin\' v?a thêm m?i \'danh m?c s?n ph?m \' tên \'X?p Vàng\'', '2022-07-10 20:30:12', 'insert', '', '', NULL),
(4, '\'admin\' v?a thêm m?i \'danh m?c s?n ph?m \' tên \'X?p Tr?ng\'', '2022-07-10 20:37:30', 'insert', '', '', NULL),
(5, '\'admin\' v?a thêm m?i \'danh m?c s?n ph?m \' tên \'X?p ??\'', '2022-07-10 20:55:55', 'insert', '', '', NULL),
(6, '\'admin\' v?a xóa \'Danh m?c s?n ph?m\'  tên \'X?p Tr?ng\'', '2022-07-10 20:58:35', 'delete', '', '', NULL),
(7, '\'admin\' vừa thêm mới \'danh mục sản phẩm \' | Thêm tên tài khoản \'damgiaphat\'', '2022-07-11 01:45:52', 'insert', '', '', NULL),
(8, '\'admin\' vừa thêm mới \'danh mục sản phẩm \' | Thêm tên tài khoản \'giacuong\'', '2022-07-11 09:03:51', 'insert', '', '', NULL),
(9, '\'admin\' vừa cập nhật \'danh mục sản phẩm \' | Cập nhật tên danh mục từ \'X?p V?ng\' thành \'Xốp Vàng\'', '2022-07-11 16:42:45', 'update', '', '', NULL),
(10, '\'admin\' vừa cập nhật \'danh mục sản phẩm \' | Cập nhật tên danh mục từ \'X?p h?ng\' thành \'Xốp hồng\'', '2022-07-11 16:42:57', 'update', '', '', NULL),
(11, '\'admin\' vừa cập nhật \'danh mục sản phẩm \' | Cập nhật tên danh mục từ \'X?p den\' thành \'Xốp đen\'', '2022-07-11 16:43:05', 'update', '', '', NULL),
(12, '\'admin\' vừa cập nhật \'người dùng\'  | Cập nhật trạng thái từ \'True\' thành \'True\'', '2022-07-11 16:49:57', 'update', '', '', NULL),
(13, '\'admin\' vừa cập nhật \'sản phẩm\' | Cập nhật tên danh mục từ Xốp hồng thành \'InventoryManagerment.Models.EF.ProductCategory\'', '2022-07-14 22:12:02', 'update', '', '', NULL),
(14, '\'admin\' vừa xóa \'người dùng \'  | Xóa tên \'Test\'', '2022-07-14 23:12:52', 'delete', '', '', NULL),
(15, '\'admin\' vừa xóa \'đơn vị tính\'  | Xóa đơn vị tính \'Cu?n\'', '2022-07-15 02:38:04', 'delete', '', '', NULL),
(16, '\'admin\' vừa thêm mới \'đơn vị tính \' | Thêm đơn vị tính \'Cây\'', '2022-07-15 02:44:54', 'insert', '', '', NULL),
(17, '\'admin\' vừa xóa \'đơn vị tính\'  | Xóa đơn vị tính \'Cây\'', '2022-07-15 02:45:02', 'delete', '', '', NULL),
(18, '\'admin\' vừa thêm mới \'đơn vị tính \' | Thêm đơn vị tính \'Test\'', '2022-07-15 02:45:47', 'insert', '', '', NULL),
(19, '\'admin\' vừa thêm mới \'đơn vị tính \' | Thêm đơn vị tính \'Cuộn\'', '2022-07-15 02:45:58', 'insert', '', '', NULL),
(20, '\'admin\' vừa thêm mới \'chức vuj \' | Thêm chức vụ \'Quản lý kho\'', '2022-07-15 22:23:39', 'insert', '', '', NULL),
(21, '\'admin\' vừa thêm mới \'sản phẩm cung cấp \' | Thêm sản phẩm \'San pham 6\' của nhà cung cấp \'PESICO\'', '2022-07-16 15:06:29', 'insert', '', '', NULL),
(22, '\'admin\' vừa thêm mới \'nhà cung cấp \' | Thêm nhà cung cấp \'Pepsi\'', '2022-07-16 15:06:56', 'insert', '', '', NULL),
(23, '\'admin\' vừa thêm mới \'sản phẩm cung cấp \' | Thêm sản phẩm \'San pham 2\' của nhà cung cấp \'Pepsi\'', '2022-07-16 15:07:08', 'insert', '', '', NULL),
(24, '\'admin\' vừa thêm mới \'sản phẩm cung cấp \' | Thêm sản phẩm \'San pham 9\' của nhà cung cấp \'PESICO\'', '2022-07-16 17:58:39', 'insert', '', '', NULL),
(25, '\'admin\' vừa thêm mới \'sản phẩm cung cấp \' | Thêm sản phẩm \'San pham 9\' của nhà cung cấp \'Pepsi\'', '2022-07-16 17:59:10', 'insert', '', '', NULL),
(26, '\'admin\' vừa thêm mới \'sản phẩm cung cấp \' | Thêm sản phẩm \'San pham 6\' của nhà cung cấp \'PESICO\'', '2022-07-17 01:46:20', 'insert', '', '', NULL),
(27, '\'admin\' vừa cập nhật \'sản phẩm cung cấp\' | Cập nhật mã sản phẩm từ \'SP_2000\' thành \'SP-4\'', '2022-07-17 01:51:17', 'update', '', '', NULL),
(28, '\'admin\' vừa cập nhật \'sản phẩm cung cấp\' | Cập nhật mã sản phẩm từ \'SP-9\' thành \'SP-6\'', '2022-07-17 02:26:40', 'update', '', '', NULL),
(29, '\'admin\' vừa cập nhật \'nhà cung cấp \' | Cập nhật tên nhà cung cấp từ \'Pepsi\' thành \'PEPSICO\'', '2022-07-17 09:40:02', 'update', '', '', NULL),
(30, '\'admin\' vừa cập nhật \'sản phẩm cung cấp\' | Cập nhật mã sản phẩm từ \'SP-4\' thành \'SP-8\'', '2022-07-17 09:41:38', 'update', '', '', NULL),
(31, '\'admin\' vừa thêm mới \'nhà cung cấp \' | Thêm nhà cung cấp \'Công ty ABC\'', '2022-07-17 10:53:31', 'insert', '', '', NULL),
(32, '\'admin\' vừa thêm mới \'sản phẩm cung cấp \' | Thêm sản phẩm \'San pham 2\' của nhà cung cấp \'Công ty ABC\'', '2022-07-17 10:54:16', 'insert', '', '', NULL),
(33, '\'admin\' vừa thêm mới \'sản phẩm cung cấp \' | Thêm sản phẩm \'San pham 4\' của nhà cung cấp \'Công ty ABC\'', '2022-07-17 11:23:16', 'insert', '', '', NULL),
(34, '\'admin\' vừa thêm mới \'sản phẩm cung cấp \' | Thêm sản phẩm \'San pham 6\' của nhà cung cấp \'Công ty ABC\'', '2022-07-17 11:23:30', 'insert', '', '', NULL),
(35, '\'admin\' vừa cập nhật \'sản phẩm cung cấp\' | Cập nhật mã sản phẩm từ \'SP-8\' thành \'SP-3\'', '2022-07-17 14:17:34', 'update', '', '', NULL),
(36, '\'admin\' vừa cập nhật \'sản phẩm cung cấp\' | Cập nhật mã sản phẩm từ \'SP-6\' thành \'SP-8\'', '2022-07-17 14:17:45', 'update', '', '', NULL),
(37, '\'admin\' vừa thêm mới \'nhà cung cấp \' | Thêm nhà cung cấp \'Công ty XYZ\'', '2022-07-17 14:33:31', 'insert', '', '', NULL),
(38, '\'admin\' vừa thêm mới \'sản phẩm cung cấp \' | Thêm sản phẩm \'San pham 5\' của nhà cung cấp \'Công ty XYZ\'', '2022-07-17 14:50:29', 'insert', '', '', NULL),
(39, '\'admin\' vừa thêm mới \'sản phẩm cung cấp \' | Thêm sản phẩm \'San pham 7\' của nhà cung cấp \'Công ty XYZ\'', '2022-07-17 14:50:35', 'insert', '', '', NULL),
(40, '\'admin\' vừa xóa \'nhà cung cấp\'  | Xóa nhà cung cấp \'PEPSICO\' ', '2022-07-17 23:59:16', 'delete', '', '', NULL),
(41, '\'admin\' vừa xóa \'đơn vị tính\'  | Xóa đơn vị tính \'Test\'', '2022-07-29 08:50:31', 'delete', '', '', NULL),
(42, '\'admin\' vừa thêm mới \'danh mục sản phẩm \' | Thêm tên danh mục sản phẩm \'Xốp xịn\'', '2022-08-06 13:34:50', 'insert', '', '', NULL),
(43, '\'admin\' vừa cập nhật \'sản phẩm\' ', '2022-08-06 13:40:54', 'update', '', '', NULL),
(44, '\'admin\' vừa cập nhật \'sản phẩm\' ', '2022-08-06 13:41:11', 'update', '', '', NULL),
(45, '\'admin\' vừa cập nhật \'sản phẩm\' | Cập nhật số lượng tối thiểu từ 5000 thành \'5000\'', '2022-08-06 13:44:50', 'update', '', '', NULL),
(46, '\'admin\' vừa cập nhật \'sản phẩm\' | Cập nhật số lượng tối thiểu từ 300 thành \'300\'', '2022-08-06 13:46:20', 'update', '', '', NULL),
(47, '\'admin\' vừa cập nhật \'sản phẩm\' | Cập nhật số lượng tối thiểu từ 150 thành \'150\'', '2022-08-06 13:46:27', 'update', '', '', NULL),
(48, '\'admin\' vừa thêm mới \'Cách đóng gói \' | Thêm cách đóng gói \'Full box\'', '2022-08-06 18:55:05', 'insert', '', '', NULL),
(49, '\'admin\' vừa cập nhật \'nhà cung cấp \' ', '2022-08-06 18:55:54', 'update', '', '', NULL),
(50, '\'admin\' vừa xóa \'cách đóng gói\'  | Xóa cách đóng gói tên \'Full box\'', '2022-08-06 18:55:59', 'delete', '', '', NULL),
(51, '\'admin\' vừa thêm mới \'Cách đóng gói \' | Thêm cách đóng gói \'fdsfsd\'', '2022-08-06 19:02:20', 'insert', '', '', NULL),
(52, '\'admin\' vừa thêm mới \'Cách đóng gói \' | Thêm cách đóng gói \'fdsdfsbcv\'', '2022-08-06 19:02:22', 'insert', '', '', NULL),
(53, '\'admin\' vừa thêm mới \'Cách đóng gói \' | Thêm cách đóng gói \'dsffsd\'', '2022-08-06 19:02:23', 'insert', '', '', NULL),
(54, '\'admin\' vừa xóa \'cách đóng gói\'  | Xóa cách đóng gói tên \'dsffsd\'', '2022-08-06 19:09:02', 'delete', '', '', NULL),
(55, '\'admin\' vừa xóa \'cách đóng gói\'  | Xóa cách đóng gói tên \'fdsdfsbcv\'', '2022-08-06 19:09:06', 'delete', '', '', NULL),
(56, '\'admin\' vừa xóa \'cách đóng gói\'  | Xóa cách đóng gói tên \'fdsfsd\'', '2022-08-06 19:10:37', 'delete', '', '', NULL),
(57, '\'admin\' vừa thêm mới \'Cách đóng gói \' | Thêm cách đóng gói \'Full box\'', '2022-08-06 19:10:41', 'insert', '', '', NULL),
(58, '\'admin\' vừa thêm mới \'Cách đóng gói \' | Thêm cách đóng gói \'full box\'', '2022-08-06 19:10:55', 'insert', '', '', NULL),
(59, '\'admin\' vừa xóa \'cách đóng gói\'  | Xóa cách đóng gói tên \'full box\'', '2022-08-06 19:12:18', 'delete', '', '', NULL),
(60, '\'admin\' vừa thêm mới \'Cách đóng gói \' | Thêm cách đóng gói \'test\'', '2022-08-06 19:12:30', 'insert', '', '', NULL),
(61, '\'admin\' vừa thêm mới \'đơn vị tính \' | Thêm đơn vị tính \'test\'', '2022-08-06 19:17:02', 'insert', '', '', NULL),
(62, '\'admin\' vừa xóa \'đơn vị tính\'  | Xóa đơn vị tính \'test\'', '2022-08-06 19:17:05', 'delete', '', '', NULL),
(63, '\'admin\' vừa thêm mới \'đơn vị tính \' | Thêm đơn vị tính \'test\'', '2022-08-06 19:17:41', 'insert', '', '', NULL),
(64, '\'admin\' vừa xóa \'đơn vị tính\'  | Xóa đơn vị tính \'test\'', '2022-08-06 19:17:44', 'delete', '', '', NULL),
(65, '\'admin\' vừa xóa \'Danh mục sản phẩm\'  | Xóa tên danh mục \'Xốp xịn\'', '2022-08-06 19:31:07', 'delete', '', '', NULL),
(66, '\'admin\' vừa thêm mới \'danh mục sản phẩm \' | Thêm tên sản phẩm \'San pham 10\'', '2022-08-06 19:32:02', 'insert', '', '', NULL),
(67, '\'admin\' vừa thêm mới \'danh mục sản phẩm \' | Thêm tên sản phẩm \'San pham 11\'', '2022-08-06 19:34:09', 'insert', '', '', NULL),
(68, '\'admin\' vừa thêm mới \'danh mục sản phẩm \' | Thêm tên danh mục sản phẩm \'Test\'', '2022-08-06 20:11:57', 'insert', '', '', NULL),
(69, '\'admin\' vừa xóa \'Danh mục sản phẩm\'  | Xóa tên danh mục \'Test\'', '2022-08-06 20:13:12', 'delete', '', '', NULL),
(70, '\'admin\' vừa thêm mới \'danh mục sản phẩm \' | Thêm tên danh mục sản phẩm \'Test\'', '2022-08-06 20:13:49', 'insert', '', '', NULL),
(71, '\'admin\' vừa cập nhật \'danh mục sản phẩm \' | Cập nhật tên danh mục từ \'Test\' thành \'Test2\'', '2022-08-06 20:13:53', 'update', '', '', NULL),
(72, '\'admin\' vừa thêm mới \'danh mục sản phẩm \' | Thêm tên sản phẩm \'San pham 12\'', '2022-08-06 20:29:37', 'insert', '', '', NULL),
(73, '\'admin\' vừa thêm mới \'nhà cung cấp \' | Thêm nhà cung cấp \'Test\'', '2022-08-09 12:09:39', 'insert', '', '', NULL),
(74, '\'admin\' vừa thêm mới \'sản phẩm cung cấp \' | Thêm sản phẩm \'San pham 2\' của nhà cung cấp \'Test\'', '2022-08-09 12:12:26', 'insert', '', '', NULL),
(75, '\'admin\' vừa cập nhật \'nhà cung cấp \' | Cập nhật tên nhà cung cấp từ \'Test\' thành \'Test 2\'', '2022-08-09 12:13:28', 'update', '', '', NULL),
(76, '\'admin\' vừa xóa \'nhà cung cấp\'  | Xóa nhà cung cấp \'Test 2\' ', '2022-08-09 12:51:38', 'delete', '', '', NULL),
(77, '\'admin\' vừa thêm mới \'nhà cung cấp \' | Thêm nhà cung cấp \'Test\'', '2022-08-09 12:51:56', 'insert', '', '', NULL),
(78, '\'admin\' vừa thêm mới \'sản phẩm cung cấp \' | Thêm sản phẩm \'San pham 2\' của nhà cung cấp \'Test\'', '2022-08-09 12:52:02', 'insert', '', '', NULL),
(79, '\'admin\' vừa thêm mới \'sản phẩm cung cấp \' | Thêm sản phẩm \'San pham 1\' của nhà cung cấp \'Test\'', '2022-08-09 12:52:06', 'insert', '', '', NULL),
(80, '\'admin\' vừa thêm mới \'người dùng \' | Thêm tên tài khoản \'test\'', '2022-08-09 22:37:36', 'insert', '', '', NULL),
(81, '\'admin\' vừa xóa \'người dùng \'  | Xóa tên \'test\'', '2022-08-09 22:40:59', 'delete', '', '', NULL),
(82, '\'admin\' vừa thêm mới \'người dùng \' | Thêm tên tài khoản \'test\'', '2022-08-10 02:08:30', 'insert', '', '', NULL),
(83, '\'admin\' vừa thêm mới \'chức vuj \' | Thêm chức vụ \'test\'', '2022-08-10 02:08:42', 'insert', '', '', NULL),
(84, '\'admin\' vừa xóa \'chức vụ\'  | Xóa đơn vị tính \'test\'', '2022-08-10 02:08:46', 'delete', '', '', NULL),
(85, '\'admin\' vừa thêm mới \'chức vuj \' | Thêm chức vụ \'test\'', '2022-08-10 02:09:16', 'insert', '', '', NULL),
(86, '\'admin\' vừa xóa \'chức vụ\'  | Xóa đơn vị tính \'test\'', '2022-08-10 02:09:19', 'delete', '', '', NULL),
(87, '\'admin\' vừa cập nhật \'sản phẩm\' | Cập nhật số lượng tối thiểu từ 300 thành \'300\'', '2022-08-11 14:41:18', 'update', '', '', NULL),
(88, '\'admin\' vừa cập nhật \'sản phẩm\' | Cập nhật số lượng tối thiểu từ 300 thành \'300\'', '2022-08-11 14:41:24', 'update', '', '', NULL),
(89, '\'admin\' vừa cập nhật \'sản phẩm\' | Cập nhật số lượng tối thiểu từ 150 thành \'150\'', '2022-08-11 14:41:28', 'update', '', '', NULL),
(90, '\'admin\' vừa cập nhật \'sản phẩm\' | Cập nhật số lượng tối thiểu từ 150 thành \'150\'', '2022-08-11 14:41:35', 'update', '', '', NULL),
(91, '\'admin\' vừa cập nhật \'sản phẩm\' | Cập nhật số lượng tối thiểu từ 150 thành \'150\'', '2022-08-11 14:41:43', 'update', '', '', NULL),
(92, '\'admin\' vừa cập nhật \'sản phẩm\' | Cập nhật số lượng tối thiểu từ 300 thành \'300\'', '2022-08-11 14:41:48', 'update', '', '', NULL),
(93, '\'admin\' vừa cập nhật \'sản phẩm\' | Cập nhật số lượng tối thiểu từ 200 thành \'200\'', '2022-08-11 15:19:25', 'update', '', '', NULL),
(94, '\'admin\' vừa cập nhật \'sản phẩm\' | Cập nhật số lượng tối thiểu từ 500 thành \'500\'', '2022-08-11 15:20:32', 'update', '', '', NULL),
(95, '\'admin\' vừa cập nhật \'sản phẩm\' | Cập nhật số lượng tối thiểu từ 1000 thành \'1000\'', '2022-08-11 15:22:11', 'update', '', '', NULL),
(96, '\'admin\' vừa cập nhật \'sản phẩm\' | Cập nhật số lượng tối thiểu từ 200 thành \'200\'', '2022-08-11 15:22:43', 'update', '', '', NULL),
(97, '\'admin\' vừa cập nhật \'sản phẩm\' | Cập nhật số lượng tối thiểu từ 200 thành \'200\'', '2022-08-11 15:23:44', 'update', '', '', NULL),
(98, '\'admin\' vừa xóa \'sản phẩm cung cấp\'  | Xóa sản phẩm \'San pham 6\' khỏi nhà cung cấp \'PESICO\'', '2022-08-11 18:01:35', 'delete', '', '', NULL),
(99, '\'admin\' vừa xóa \'sản phẩm cung cấp\'  | Xóa sản phẩm \'San pham 6\' khỏi nhà cung cấp \'PESICO\'', '2022-08-11 18:02:17', 'delete', '', '', NULL),
(100, '\'admin\' vừa thêm mới \'sản phẩm cung cấp \' | Thêm sản phẩm \'San pham 11\' của nhà cung cấp \'Công ty ABC\'', '2022-08-11 18:03:02', 'insert', '', '', NULL),
(101, '\'admin\' vừa thêm mới \'sản phẩm cung cấp \' | Thêm sản phẩm \'San pham 8\' của nhà cung cấp \'Công ty ABC\'', '2022-08-11 18:03:09', 'insert', '', '', NULL),
(102, '\'admin\' vừa thêm mới \'nhà cung cấp \' | Thêm nhà cung cấp \'Nhà cung cấp HCP\'', '2022-08-11 18:07:43', 'insert', '', '', NULL),
(103, '\'admin\' vừa thêm mới \'sản phẩm cung cấp \' | Thêm sản phẩm \'San pham 1\' của nhà cung cấp \'Nhà cung cấp HCP\'', '2022-08-11 18:08:04', 'insert', '', '', NULL),
(104, '\'admin\' vừa thêm mới \'sản phẩm cung cấp \' | Thêm sản phẩm \'San pham 9\' của nhà cung cấp \'Nhà cung cấp HCP\'', '2022-08-11 22:41:32', 'insert', '', '', NULL),
(105, '\'admin\' vừa thêm mới \'người dùng \' | Thêm tên tài khoản \'saddsa\'', '2022-08-12 16:32:23', 'insert', '', '', NULL),
(106, '\'admin\' vừa thêm mới \'khách hàng \' | Thêm khách hàng tên \'Gia Cường\'', '2022-08-15 18:45:23', 'insert', '', '', NULL),
(107, '\'admin\' vừa xóa \'khách hàng\'  | Xóa khách hàng tên \'Gia Cường\'', '2022-08-15 18:55:04', 'delete', '', '', NULL),
(108, '\'admin\' vừa thêm mới \'khách hàng \' | Thêm khách hàng tên \'Gia Cường\'', '2022-08-15 18:55:19', 'insert', '', '', NULL),
(109, '\'admin\' vừa thêm mới \'khách hàng \' | Thêm khách hàng tên \'Gia Phát\'', '2022-08-15 18:56:20', 'insert', '', '', NULL),
(110, '\'admin\' vừa cập nhật \' khách hàng \' | Cập nhật địa chỉ khách hàng \'Gia Phát\' từ \'dálkvvvxcs\' thành \'Bình chánh\'', '2022-08-15 19:02:30', 'update', '', '', NULL),
(111, '\'admin\' vừa thêm mới \'khách hàng \' | Thêm khách hàng tên \'dsadvcx\'', '2022-08-18 11:49:35', 'insert', '', '', NULL),
(112, '\'admin\' vừa thêm mới \'khách hàng \' | Thêm khách hàng tên \'huy\'', '2022-08-18 11:57:06', 'insert', '', '', NULL),
(113, '\'admin\' vừa thêm mới \'khách hàng \' | Thêm khách hàng tên \'cxvcxcv\'', '2022-08-18 11:59:35', 'insert', '', '', NULL),
(114, '\'admin\' vừa thêm mới \'khách hàng \' | Thêm khách hàng tên \'Gia Phú\'', '2022-08-18 13:22:02', 'insert', '', '', NULL),
(115, '\'admin\' vừa cập nhật \' khách hàng \' | Cập nhật số điện thoại khách hàng \'Gia Phú\' từ \'Chưa thêm s\' thành \'Chưa thêm SĐT\'', '2022-08-18 13:23:39', 'update', '', '', NULL),
(116, '\'admin\' vừa thêm mới \'khách hàng \' | Thêm khách hàng tên \'Bảo Huy\'', '2022-08-18 13:27:56', 'insert', '', '', NULL),
(117, '\'admin\' vừa thêm mới \'khách hàng \' | Thêm khách hàng tên \'Bảo Thi\'', '2022-08-18 13:29:43', 'insert', '', '', NULL),
(118, '\'admin\' vừa thêm mới \'khách hàng \' | Thêm khách hàng tên \'Bảo Thi\'', '2022-08-18 13:30:02', 'insert', '', '', NULL),
(119, '\'admin\' vừa xóa \'khách hàng\'  | Xóa khách hàng tên \'Bảo Thi\'', '2022-08-18 13:30:18', 'delete', '', '', NULL),
(120, '\'admin\' vừa thêm mới \'khách hàng \' | Thêm khách hàng tên \'Hoài Bảo\'', '2022-08-18 13:33:28', 'insert', '', '', NULL),
(121, '\'admin\' vừa thêm mới \'khách hàng \' | Thêm khách hàng tên \'Gia Khánh\'', '2022-08-18 13:37:51', 'insert', '', '', NULL),
(122, '\'admin\' vừa thêm mới \'khách hàng \' | Thêm khách hàng tên \'Test 8/19/2022\'', '2022-08-19 14:51:56', 'insert', '', '', NULL),
(123, '\'admin\' vừa thêm mới \'nhà cung cấp \' | Thêm nhà cung cấp \'Kho nhà\'', '2022-08-19 17:33:08', 'insert', '', '', NULL),
(124, '\'admin\' vừa thêm mới \'khách hàng \' | Thêm khách hàng tên \'Test 23/8/2022\'', '2022-08-23 02:28:03', 'insert', '', '', NULL),
(125, '\'admin\' vừa thêm mới \'khách hàng \' | Thêm khách hàng tên \'Test 24/8/2022\'', '2022-08-24 20:55:45', 'insert', NULL, NULL, NULL),
(126, '\'admin\' vừa thêm mới \'phiếu xuất\' với mã phiếu \'EP8242022_205545\'', '2022-08-24 20:55:45', 'insert', 'admin', 'phiếu xuất', 'EP8242022_205545'),
(127, '\'admin\' vừa thêm mới \'phiếu xuất\' với mã phiếu \'EP8242022_214622\'', '2022-08-24 21:46:22', 'insert', 'admin', 'phiếu xuất', 'EP8242022_214622'),
(128, '\'admin\' vừa thêm mới \'phiếu nhập\' với mã phiếu \'IP8242022_214735\'', '2022-08-24 21:47:35', 'insert', 'admin', 'phiếu nhập', 'IP8242022_214735'),
(129, '\'admin\' vừa thêm mới \'phiếu trả hàng\' với mã phiếu \'EP8242022_215016\'', '2022-08-24 21:50:16', 'insert', 'admin', 'phiếu trả hàng', 'EP8242022_215016'),
(134, '\'admin\' vừa thêm mới \'phiếu nhập\' với mã phiếu \'IP8252022_101525\'', '2022-08-25 10:15:25', 'insert', 'admin', 'phiếu nhập', 'IP8252022_101525'),
(135, '\'admin\' vừa cập nhật \'phiếu nhập\' | \'Thay đổi danh sách| TỪ |Tên: San pham 1, SL: 555, Giá: 199,512, ĐVT: Kg |Tên: San pham 5, SL: 555, Giá: 56,454, ĐVT: Kg | THÀNH| Tên: San pham 1, SL: 555, Giá: 199,512, ĐVT: Kg |Tên: San pham 5, SL: 555, Giá: 56,454, ĐVT: Kg |\'với mã phiếu \'IP8252022_101525\'', '2022-08-25 10:24:55', 'update', 'admin', 'phiếu nhập', 'IP8252022_101525'),
(136, '\'admin\' vừa thêm mới \'phiếu nhập\' với mã phiếu \'IP8252022_103234\'', '2022-08-25 10:32:34', 'insert', 'admin', 'phiếu nhập', 'IP8252022_103234'),
(137, '\'admin\' vừa cập nhật \'phiếu trả hàng\' | \'Thay đổi danh sách| TỪ |Tên: San pham 2, SL: 55, Giá: 50,000, ĐVT: Kg |Tên: San pham 1, SL: 500, Giá: 50,000, ĐVT: Kg | THÀNH Tên: San pham 2, SL: 55, Giá: 50,000, ĐVT: Kg |Tên: San pham 1, SL: 500, Giá: 50,000, ĐVT: Kg |\'với mã phiếu \'EP8242022_215016\'', '2022-08-25 10:32:56', 'update', 'admin', 'phiếu trả hàng', 'EP8242022_215016'),
(138, '\'admin\' vừa cập nhật \'phiếu trả hàng\' | \'Thay đổi danh sách| TỪ |Tên: San pham 2, SL: 555, Giá: 50,000, ĐVT: Kg |Tên: San pham 1, SL: 555, Giá: 50,000, ĐVT: Kg | THÀNH Tên: San pham 2, SL: 555, Giá: 50,000, ĐVT: Kg |Tên: San pham 1, SL: 555, Giá: 50,000, ĐVT: Kg |\'với mã phiếu \'EP8232022_05604\'', '2022-08-25 10:33:11', 'update', 'admin', 'phiếu trả hàng', 'EP8232022_05604'),
(139, '\'admin\' vừa thêm mới \'khách hàng \' | Thêm khách hàng tên \'Test 25/8/2022\'', '2022-08-25 10:37:04', 'insert', NULL, NULL, NULL),
(140, '\'admin\' vừa thêm mới \'phiếu xuất\' với mã phiếu \'EP8252022_104424\'', '2022-08-25 10:46:16', 'insert', 'admin', 'phiếu xuất', 'EP8252022_104424'),
(141, '\'admin\' vừa thêm mới \'phiếu xuất\' với mã phiếu \'EP8252022_105733\'', '2022-08-25 10:57:33', 'insert', 'admin', 'phiếu xuất', 'EP8252022_105733'),
(142, '\'admin\' vừa thêm mới \'khách hàng \' | Thêm khách hàng tên \'test lan 2 25/8/2022\'', '2022-08-25 11:00:10', 'insert', NULL, NULL, NULL),
(143, '\'admin\' vừa thêm mới \'phiếu xuất\' với mã phiếu \'EP8252022_110010\'', '2022-08-25 11:00:10', 'insert', 'admin', 'phiếu xuất', 'EP8252022_110010'),
(144, '\'admin\' vừa thêm mới \'phiếu xuất\' với mã phiếu \'EP8252022_110031\'', '2022-08-25 11:00:31', 'insert', 'admin', 'phiếu xuất', 'EP8252022_110031'),
(145, '\'admin\' vừa cập nhật \'phiếu xuất\' | \'Thay đổi danh sách| TỪ |Tên: San pham 5, SL: 55, Giá: 7,000, ĐVT: Kg |Tên: San pham 1, SL: 55, Giá: 50,000, ĐVT: Kg | THÀNH Tên: San pham 5, SL: 55, Giá: 7,000, ĐVT: Kg |Tên: San pham 1, SL: 55, Giá: 50,000, ĐVT: Kg |Tên: San pham 6, SL: 555, Giá: 43,000, ĐVT: Kg |\'với mã phiếu \'EP8252022_110031\'', '2022-08-25 11:01:34', 'update', 'admin', 'phiếu xuất', 'EP8252022_110031'),
(146, '\'admin\' vừa cập nhật \'phiếu xuất\' | \'Thay đổi trạng thái từ \'Chưa duyệt\' thành \'Đã duyệt\' | Thay đổi danh sách| TỪ |Tên: San pham 1, SL: 555, Giá: 50,000, ĐVT: Kg |Tên: San pham 2, SL: 423, Giá: 50,000, ĐVT: Kg | THÀNH Tên: San pham 1, SL: 555, Giá: 50,000, ĐVT: Kg |Tên: San pham 2, SL: 423, Giá: 50,000, ĐVT: Kg |\'với mã phiếu \'EP8252022_110010\'', '2022-08-25 11:03:18', 'update', 'admin', 'phiếu xuất', 'EP8252022_110010'),
(147, '\'admin\' vừa cập nhật \'phiếu xuất\' | \'Thay đổi ghi chú từ \'abccd\' thành \'test\' | Thay đổi tên khách hàng từ \'test lan 2 25/8/2022\' thành \'Test 25/8/2022\' | Thay đổi trạng thái từ \'Chưa duyệt\' thành \'Đã duyệt\' | Thay đổi danh sách| TỪ |Tên: San pham 5, SL: 55, Giá: 7,000, ĐVT: Kg |Tên: San pham 1, SL: 55, Giá: 50,000, ĐVT: Kg |Tên: San pham 6, SL: 555, Giá: 43,000, ĐVT: Kg | THÀNH Tên: San pham 5, SL: 55, Giá: 7,000, ĐVT: Kg |Tên: San pham 1, SL: 55, Giá: 50,000, ĐVT: Kg |Tên: San pham 6, SL: 555, Giá: 43,000, ĐVT: Kg |Tên: San pham 7, SL: 55, Giá: 23,000, ĐVT: Kg |\'với mã phiếu \'EP8252022_110031\'', '2022-08-25 11:03:46', 'update', 'admin', 'phiếu xuất', 'EP8252022_110031'),
(148, '\'admin\' vừa cập nhật \'phiếu xuất\' | Thay đổi ghi chú từ \'test\' thành \'abcdef\' | Thay đổi NV giao từ \'test\' thành \'test 2\' | Thay đổi trạng thái từ \'Chưa duyệt\' thành \'Đã duyệt\' | Thay đổi danh sách| TỪ |Tên: San pham 4, SL: 555, Giá: 50,000, ĐVT: Kg | THÀNH |Tên: San pham 4, SL: 555, Giá: 50,000, ĐVT: Kg |với mã phiếu \'EP8252022_105733\'', '2022-08-25 11:06:58', 'update', 'admin', 'phiếu xuất', 'EP8252022_105733'),
(149, '\'admin\' vừa thêm mới \'phiếu nhập\' với mã phiếu \'IP8252022_110849\'', '2022-08-25 11:08:50', 'insert', 'admin', 'phiếu nhập', 'IP8252022_110849'),
(150, '\'admin\' vừa cập nhật \'phiếu nhập\' | Thay đổi ghi chú từ \'hello\' thành \'test pheu nhap\'Thay đổi NCC từ \'Nhà cung cấp HCP\' thành \'Công ty ABC\' Thay đổi danh sách| TỪ |Tên: San pham 1, SL: 555, Giá: 247,797, ĐVT: Kg |Tên: San pham 2, SL: 5000, Giá: 239,806, ĐVT: Kg |Tên: San pham 3, SL: 555, Giá: 199,922, ĐVT: Kg | THÀNH| Tên: San pham 1, SL: 555, Giá: 247,797, ĐVT: Kg |Tên: San pham 3, SL: 555, Giá: 199,922, ĐVT: Kg |với mã phiếu \'IP8252022_110849\'', '2022-08-25 11:09:22', 'update', 'admin', 'phiếu nhập', 'IP8252022_110849'),
(151, '\'admin\' vừa cập nhật \'phiếu nhập\' | Thay đổi ghi chú từ \'test pheu nhap\' thành \'test pheu nhap LAN 2\'|Thay đổi NCC từ \'Công ty ABC\' thành \'Test\' |Thay đổi thời gian từ \'8/25/2022 11:08:00 AM\' thành \'8/24/2022 11:08:00 AM\'|Thay đổi danh sách| TỪ |Tên: San pham 1, SL: 555, Giá: 247,797, ĐVT: Kg |Tên: San pham 3, SL: 555, Giá: 199,922, ĐVT: Kg | THÀNH| Tên: San pham 1, SL: 555, Giá: 247,797, ĐVT: Kg |Tên: San pham 3, SL: 555, Giá: 199,922, ĐVT: Kg |với mã phiếu \'IP8252022_110849\'', '2022-08-25 11:11:16', 'update', 'admin', 'phiếu nhập', 'IP8252022_110849'),
(152, '\'admin\' vừa cập nhật \'phiếu nhập\' | Thay đổi thời gian từ \'24/08/2022 11:08\' thành \'26/11/2022 11:11\'|Thay đổi danh sách| TỪ |Tên: San pham 1, SL: 555, Giá: 247,797, ĐVT: Kg |Tên: San pham 3, SL: 555, Giá: 199,922, ĐVT: Kg | THÀNH| Tên: San pham 1, SL: 555, Giá: 247,797, ĐVT: Kg |Tên: San pham 3, SL: 555, Giá: 199,922, ĐVT: Kg |với mã phiếu \'IP8252022_110849\'', '2022-08-25 11:12:42', 'update', 'admin', 'phiếu nhập', 'IP8252022_110849'),
(153, '\'admin\' vừa thêm mới \'khách hàng \' | Thêm khách hàng tên \'Test phieu tra 25/8/2022\'', '2022-08-25 11:14:05', 'insert', NULL, NULL, NULL),
(154, '\'admin\' vừa thêm mới \'phiếu trả hàng\' với mã phiếu \'EP8252022_111405\'', '2022-08-25 11:14:05', 'insert', 'admin', 'phiếu trả hàng', 'EP8252022_111405'),
(155, '\'admin\' vừa cập nhật \'phiếu trả hàng\' | Thay đổi danh sách| TỪ |Tên: San pham 1, SL: 555, Giá: 50,000, ĐVT: Kg |Tên: San pham 4, SL: 555, Giá: 50,000, ĐVT: Kg | THÀNH Tên: San pham 1, SL: 555, Giá: 50,000, ĐVT: Kg |Tên: San pham 4, SL: 555, Giá: 50,000, ĐVT: Kg |Tên: San pham 2, SL: 555, Giá: 50,000, ĐVT: Kg |với mã phiếu \'EP8252022_111405\'', '2022-08-25 11:15:26', 'update', 'admin', 'phiếu trả hàng', 'EP8252022_111405'),
(156, '\'admin\' vừa cập nhật \'phiếu trả hàng\' | Thay đổi danh sách| TỪ |Tên: San pham 1, SL: 555, Giá: 50,000, ĐVT: Kg |Tên: San pham 4, SL: 555, Giá: 50,000, ĐVT: Kg |Tên: San pham 2, SL: 555, Giá: 50,000, ĐVT: Kg | THÀNH Tên: San pham 1, SL: 555, Giá: 50,000, ĐVT: Kg |Tên: San pham 4, SL: 555, Giá: 50,000, ĐVT: Kg |Tên: San pham 2, SL: 555, Giá: 50,000, ĐVT: Kg |Tên: San pham 3, SL: 55, Giá: 50,000, ĐVT: Kg |với mã phiếu \'EP8252022_111405\'', '2022-08-25 11:19:23', 'update', 'admin', 'phiếu trả hàng', 'EP8252022_111405'),
(157, '\'damgiaphat\' vừa thêm mới \'phiếu trả hàng\' với mã phiếu \'EP8252022_03640\'', '2022-08-25 12:36:40', 'insert', 'damgiaphat', 'phiếu trả hàng', 'EP8252022_03640'),
(158, '\'damgiaphat\' vừa thêm mới \'phiếu xuất\' với mã phiếu \'EP8252022_04122\'', '2022-08-25 12:41:22', 'insert', 'damgiaphat', 'phiếu xuất', 'EP8252022_04122'),
(159, '\'admin\' vừa cập nhật \'phiếu xuất\' | Thay đổi ghi chú từ \'\' thành \'ef\' | Thay đổi NV giao từ \'\' thành \'abcd\' | Thay đổi trạng thái từ \'Chưa duyệt\' thành \'Đã duyệt\' | Thay đổi danh sách| TỪ |Tên: San pham 3, SL: 5, Giá: 50,000, ĐVT: Kg | THÀNH |Tên: San pham 3, SL: 5, Giá: 50,000, ĐVT: Kg |với mã phiếu \'EP8252022_04122\'', '2022-08-25 13:55:15', 'update', 'admin', 'phiếu xuất', 'EP8252022_04122'),
(160, '\'admin\' vừa thêm mới \'phiếu xuất\' với mã phiếu \'EP8252022_204333\'', '2022-08-25 20:43:33', 'insert', 'admin', 'phiếu xuất', 'EP8252022_204333'),
(161, '\'admin\' vừa thêm mới \'phiếu xuất\' với mã phiếu \'EP8252022_204848\'', '2022-08-25 20:48:48', 'insert', 'admin', 'phiếu xuất', 'EP8252022_204848'),
(162, '\'admin\' vừa cập nhật \'phiếu xuất\' | Thay đổi thời gian từ \'8/25/2022 8:43:00 PM\' thành \'7/25/2022 8:43:00 AM\' | Thay đổi danh sách| TỪ |Tên: San pham 6, SL: 445, Giá: 4,500,000, ĐVT: Kg | THÀNH |Tên: San pham 6, SL: 445, Giá: 4,500,000, ĐVT: Kg |với mã phiếu \'EP8252022_204848\'', '2022-08-25 20:49:13', 'update', 'admin', 'phiếu xuất', 'EP8252022_204848');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `Import`
--

CREATE TABLE `Import` (
  `ID` bigint(20) NOT NULL,
  `Code` varchar(50) NOT NULL,
  `SupplierID` bigint(20) NOT NULL,
  `Time` datetime NOT NULL,
  `Note` text DEFAULT NULL,
  `ImportDelete` tinyint(1) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Đang đổ dữ liệu cho bảng `Import`
--

INSERT INTO `Import` (`ID`, `Code`, `SupplierID`, `Time`, `Note`, `ImportDelete`) VALUES
(19, 'IP7282022_031028', 4, '2022-07-30 12:00:00', 'dsdfs', 0),
(21, 'IP7282022_130951', 1, '2022-07-30 12:00:00', 'hello', 0),
(22, 'IP7292022_084915', 1, '2022-07-29 08:48:00', 'Hello', 0),
(23, 'IP7292022_085244', 3, '2022-07-29 08:52:00', NULL, 0),
(24, 'IP7302022_021304', 3, '2022-07-29 21:02:00', 'dsadsa', 0),
(25, 'IP7302022_021325', 1, '2022-07-30 03:00:00', 'abcdef', 0),
(27, 'IP7312022_152136', 1, '2022-07-31 15:21:00', 'ewrewew', 0),
(29, 'IP7312022_152937', 1, '2022-07-31 03:29:00', 'dfsfsd', 0),
(30, 'IP7312022_153045', 3, '2022-07-31 15:30:00', 'drfds', 0),
(31, 'IP7312022_153157', 3, '2022-07-31 15:31:00', 'dsffds', 0),
(32, 'IP7312022_153302', 3, '2022-07-31 15:32:00', 'gfdgdfg', 0),
(33, 'IP7312022_172257', 3, '2022-07-31 17:22:00', 'sdffsdfsd', 0),
(34, 'IP7312022_172448', 4, '2022-07-31 17:24:00', 'dfsfsdfds', 0),
(36, 'IP7312022_221819', 1, '2022-07-31 22:18:00', 'sadfdsfds', 0),
(39, 'IP862022_04628', 1, '2022-08-06 12:46:00', 'dsfdsffdsdfs', 0),
(40, 'IP862022_130616', 3, '2022-08-06 13:05:00', 'asddfgsdfg', 0),
(41, 'IP862022_130713', 3, '2022-08-06 13:07:00', 'dfsfds', 0),
(42, 'IP8112022_134815', 3, '2022-08-11 13:48:00', 'dsadasf', 0),
(43, 'IP8112022_134852', 3, '2022-08-11 13:48:00', 'fdssdf', 0),
(44, 'IP8112022_135641', 3, '2022-08-10 13:56:00', 'dfsfsd', 0),
(45, 'IP8112022_153826', 1, '2022-08-11 15:38:00', 'dsadas', 0),
(46, 'IP8112022_153916', 4, '2022-08-11 15:39:00', 'fsafsa', 0),
(48, 'IP8112022_154250', 1, '2022-08-11 15:42:00', 'fsafas', 0),
(49, 'IP8112022_154326', 4, '2022-08-11 15:42:00', 'fdsfsd', 0),
(50, 'IP8112022_154448', 4, '2022-08-11 15:44:00', 'fdsfsd', 0),
(51, 'IP8112022_160127', 3, '2022-08-11 16:00:00', 'fsafas', 0),
(52, 'IP8112022_221956', 4, '2022-08-11 22:19:00', 'dfsfds', 0),
(53, 'IP8152022_214517', 1, '2022-08-15 21:44:00', 'Hello', 0),
(54, 'IP8152022_214604', 1, '2022-08-15 21:45:00', 'fsdfds', 0),
(55, 'IP8152022_214804', 3, '2022-08-15 21:47:00', 'gfdgfdgfd', 0),
(56, 'IP8152022_221338', 7, '2022-08-15 22:13:00', 'fdadsf', 0),
(57, 'IP8152022_221630', 7, '2022-08-15 22:16:00', NULL, 0),
(58, 'IP8152022_221709', 7, '2022-08-15 22:16:00', NULL, 0),
(59, 'IP8152022_221832', 7, '2022-08-15 22:17:00', NULL, 0),
(60, 'IP8152022_221911', 7, '2022-08-15 22:18:00', NULL, 0),
(61, 'IP8152022_222011', 7, '2022-08-15 22:19:00', NULL, 0),
(62, 'IP8152022_222619', 7, '2022-08-15 22:24:00', NULL, 0),
(63, 'IP8152022_225439', 7, '2022-08-15 22:54:00', NULL, 0),
(64, 'IP8162022_222434', 1, '2022-08-16 22:23:00', NULL, 0),
(65, 'IP8172022_161509', 7, '2022-08-17 16:14:00', NULL, 0),
(66, 'IP8172022_161522', 7, '2022-08-17 16:14:00', NULL, 0),
(67, 'IP8172022_174717', 4, '2022-08-17 17:06:00', NULL, 0),
(68, 'IP8172022_182105', 4, '2022-08-17 18:27:00', NULL, 0),
(69, 'IP8192022_130808', 3, '2022-08-19 13:07:00', 'abcdef', 0),
(70, 'IP8192022_154142', 1, '2022-08-19 15:40:00', 'Test', 0),
(71, 'IP8192022_172010', 6, '2022-08-19 17:19:00', NULL, 0),
(72, 'IP8202022_00000', 4, '2022-08-20 11:59:00', NULL, 0),
(73, 'IP8202022_00021', 6, '2022-08-20 12:00:00', 'test', 0),
(74, 'IP8242022_214735', 8, '2022-08-24 09:47:00', 'ABCDEF', 0),
(75, 'IP8252022_101525', 4, '2022-08-25 10:15:00', 'hello', 0),
(76, 'IP8252022_103234', 1, '2022-08-25 10:32:00', 'abcd', 0),
(77, 'IP8252022_110849', 6, '2022-08-26 11:11:00', 'test pheu nhap LAN 2', 0);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `ImportDetail`
--

CREATE TABLE `ImportDetail` (
  `ID` bigint(20) NOT NULL,
  `ImportCode` varchar(50) NOT NULL,
  `ImportPrice` decimal(18,0) NOT NULL,
  `ProductCode` varchar(50) NOT NULL,
  `Quantity` bigint(20) NOT NULL,
  `UnitID` bigint(20) NOT NULL,
  `ImportDetailDelete` tinyint(1) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Đang đổ dữ liệu cho bảng `ImportDetail`
--

INSERT INTO `ImportDetail` (`ID`, `ImportCode`, `ImportPrice`, `ProductCode`, `Quantity`, `UnitID`, `ImportDetailDelete`) VALUES
(18, 'IP7292022_084915', '2332', 'SP-2', 32, 0, 0),
(19, 'IP7292022_084915', '3232', 'SP-6', 3121, 0, 0),
(20, 'IP7292022_085244', '32432', 'SP-3', 2332, 0, 0),
(21, 'IP7292022_085244', '23432', 'SP-5', 23, 0, 0),
(42, 'IP7302022_021304', '4532', 'SP-3', 23, 0, 0),
(43, 'IP7302022_021304', '23432', 'SP-5', 23, 0, 0),
(44, 'IP7302022_021304', '34234', 'SP-7', 2323, 0, 0),
(52, 'IP7302022_021325', '54334', 'SP-3', 43534, 0, 0),
(53, 'IP7302022_021325', '435345', 'SP-1', 4343, 0, 0),
(60, 'IP7282022_031028', '4334', 'SP-6', 34, 0, 0),
(61, 'IP7282022_031028', '543', 'SP-2', 433, 0, 0),
(62, 'IP7282022_031028', '435', 'SP-4', 343, 0, 0),
(63, 'IP7282022_031028', '435453', 'SP-3', 3434, 0, 0),
(67, 'IP7312022_152136', '45334', 'SP-4', 4343, 0, 0),
(68, 'IP7312022_152136', '453243', 'SP-1', 43, 0, 0),
(72, 'IP7312022_153045', '4343', 'SP-4', 3434, 0, 0),
(73, 'IP7312022_153045', '34543', 'SP-3', 343, 0, 0),
(74, 'IP7312022_153157', '345345', 'SP-2', 433, 0, 0),
(75, 'IP7312022_153302', '546465', 'SP-4', 654, 0, 0),
(76, 'IP7312022_153302', '5656', 'SP-4', 6556, 0, 0),
(77, 'IP7312022_172257', '233243', 'SP-4', 2323, 0, 0),
(78, 'IP7312022_172448', '425245', 'SP-3', 22332, 0, 0),
(80, 'IP7312022_221819', '454343', 'SP-4', 4343, 0, 0),
(86, 'IP7282022_130951', '4334', 'SP-3', 43, 0, 0),
(87, 'IP7282022_130951', '423432', 'SP-3', 33, 0, 0),
(88, 'IP7282022_130951', '23432', 'SP-4', 2323, 0, 0),
(89, 'IP7282022_130951', '53443', 'SP-4', 4343, 0, 0),
(90, 'IP7312022_152937', '4343', 'SP-3', 34, 0, 0),
(91, 'IP7312022_152937', '34543', 'SP-4', 43343, 0, 0),
(94, 'IP862022_130616', '234324', 'SP-4', 2323, 0, 0),
(95, 'IP862022_130616', '23432', 'SP-5', 23, 0, 0),
(96, 'IP862022_130616', '342', 'SP-1', 342, 0, 0),
(97, 'IP862022_130713', '3342432', 'SP-3', 322, 0, 0),
(102, 'IP862022_04628', '342432', 'SP-1', 23, 0, 0),
(103, 'IP862022_04628', '432423', 'SP-3', 3223, 0, 0),
(104, 'IP8112022_134815', '342432', 'SP-3', 2, 0, 0),
(105, 'IP8112022_134852', '342432', 'SP-4', 32, 0, 0),
(106, 'IP8112022_135641', '3423', 'SP-2', 32, 0, 0),
(107, 'IP8112022_135641', '3454343', 'SP-1', 34, 0, 0),
(108, 'IP8112022_153826', '432423', 'SP-7', 200, 0, 0),
(109, 'IP8112022_153916', '54543', 'SP-7', 200, 0, 0),
(111, 'IP8112022_154250', '453354', 'SP-7', 500, 0, 0),
(112, 'IP8112022_154326', '43232', 'SP-3', 500, 0, 0),
(113, 'IP8112022_154448', '35235', 'SP-7', 500, 0, 0),
(114, 'IP8112022_160127', '43232', 'SP-4', 23, 0, 0),
(115, 'IP8112022_160127', '32432', 'SP-7', 500, 0, 0),
(116, 'IP8112022_221956', '5113', 'SP-1', 50000, 0, 0),
(117, 'IP8152022_214517', '24000', 'SP-1', 500, 0, 0),
(118, 'IP8152022_214604', '50000', 'SP-3', 500, 0, 0),
(119, 'IP8152022_214804', '50000', 'SP-2', 5434, 0, 0),
(120, 'IP8152022_221338', '43000', 'SP-5', 50000, 1, 0),
(121, 'IP8152022_221630', '50000', 'SP-1', 50, 1, 0),
(122, 'IP8152022_221709', '3000', 'SP-1', 50, 1, 0),
(123, 'IP8152022_221709', '5000', 'SP-5', 50, 1, 0),
(124, 'IP8152022_221832', '5000', 'SP-1', 5, 1, 0),
(125, 'IP8152022_221832', '6000', 'SP-5', 5, 1, 0),
(126, 'IP8152022_221911', '5000', 'SP-1', 5, 1, 0),
(127, 'IP8152022_222011', '6090', 'SP-5', 7, 1, 0),
(128, 'IP8152022_222619', '5000', 'SP-1', 700, 1, 0),
(129, 'IP8152022_225439', '45000', 'SP-1', 5, 1, 0),
(130, 'IP8152022_225439', '7800', 'SP-5', 5, 2, 0),
(131, 'IP8162022_222434', '50000', 'SP-6', 500, 2, 0),
(132, 'IP8162022_222434', '50000', 'SP-4', 20, 1, 0),
(133, 'IP8172022_161509', '543534', 'SP-3', 4334, 1, 0),
(134, 'IP8172022_161509', '56454', 'SP-5', 5445, 2, 0),
(135, 'IP8172022_161509', '432433', 'SP862022_193202', 543534, 2, 0),
(136, 'IP8172022_174717', '543534', 'SP-2', 3434, 2, 0),
(137, 'IP8172022_174717', '543535', 'SP-1', 3434, 1, 0),
(139, 'IP8172022_182105', '500', 'SP-3', 500, 0, 0),
(140, 'IP8192022_130808', '45343', 'SP-4', 100, 1, 0),
(141, 'IP8192022_154142', '10000', 'SP-1', 1000, 1, 0),
(142, 'IP8192022_154142', '12000', 'SP-2', 1000, 1, 0),
(143, 'IP8192022_154142', '13000', 'SP-3', 1000, 1, 0),
(144, 'IP8192022_154142', '14000', 'SP-4', 1000, 1, 0),
(145, 'IP8192022_172010', '100000', 'SP-7', 1000, 2, 0),
(146, 'IP8192022_172010', '43000', 'SP-9', 500, 1, 0),
(147, 'IP8202022_00000', '56454', 'SP-5', 5, 1, 0),
(155, 'IP8202022_00021', '7000', 'SP-8', 2313, 0, 0),
(156, 'IP8202022_00021', '80000', 'SP-6', 1000, 0, 0),
(157, 'IP8202022_00021', '24000', 'SP-1', 100, 0, 0),
(160, 'IP8242022_214735', '199512', 'SP-1', 500, 1, 0),
(161, 'IP8242022_214735', '201845', 'SP-2', 500, 1, 0),
(162, 'IP8242022_214735', '5000', 'SP-5', 500, 1, 0),
(165, 'IP8252022_101525', '199512', 'SP-1', 555, 1, 0),
(166, 'IP8252022_101525', '56454', 'SP-5', 555, 1, 0),
(167, 'IP8252022_103234', '238140', 'SP-1', 5, 1, 0),
(168, 'IP8252022_103234', '201845', 'SP-2', 23, 1, 0),
(176, 'IP8252022_110849', '247797', 'SP-1', 555, 1, 0),
(177, 'IP8252022_110849', '199922', 'SP-3', 555, 1, 0);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `Package`
--

CREATE TABLE `Package` (
  `ID` bigint(20) NOT NULL,
  `Name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Đang đổ dữ liệu cho bảng `Package`
--

INSERT INTO `Package` (`ID`, `Name`) VALUES
(1, 'No box'),
(6, 'Full box'),
(8, 'test');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `Product`
--

CREATE TABLE `Product` (
  `ID` bigint(20) NOT NULL,
  `Code` varchar(50) DEFAULT NULL,
  `Name` varchar(100) NOT NULL,
  `Quantity` bigint(20) NOT NULL DEFAULT 0,
  `UnitID` bigint(20) NOT NULL,
  `Price` decimal(18,0) NOT NULL,
  `CategoryID` bigint(20) DEFAULT NULL,
  `ProductID` bigint(20) DEFAULT NULL,
  `PackageID` bigint(20) DEFAULT NULL,
  `QuantityAlert` bigint(20) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Đang đổ dữ liệu cho bảng `Product`
--

INSERT INTO `Product` (`ID`, `Code`, `Name`, `Quantity`, `UnitID`, `Price`, `CategoryID`, `ProductID`, `PackageID`, `QuantityAlert`) VALUES
(2, 'SP-1', 'San pham 1', 0, 1, '50000', 1, NULL, 1, 500),
(3, 'SP-2', 'San pham 2', 560, 1, '50000', 4, NULL, 1, 200),
(4, 'SP-3', 'San pham 3', 1142, 1, '50000', 1, NULL, 1, 150),
(5, 'SP-4', 'San pham 4', 1077, 1, '50000', 2, NULL, 1, 1000),
(6, 'SP-5', 'San pham 5', 4234, 1, '7000', 1, NULL, 1, 300),
(7, 'SP-6', 'San pham 6', 0, 1, '43000', 1, NULL, 1, 150),
(8, 'SP-7', 'San pham 7', 945, 1, '23000', 1, NULL, 1, 150),
(9, 'SP-8', 'San pham 8', 0, 1, '7000', 1, NULL, 1, 200),
(11, 'SP-9', 'San pham 9', 500, 1, '43000', 1, NULL, 1, 300),
(12, 'SP862022_193202', 'San pham 10', 555, 1, '23000', 4, NULL, 6, 5000),
(13, 'SP862022_193409', 'San pham 11', 0, 1, '3424', 2, NULL, 1, 436),
(14, 'SP862022_202937', 'San pham 12', 0, 1, '50000', 4, NULL, 6, 300);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `ProductCategory`
--

CREATE TABLE `ProductCategory` (
  `ID` bigint(20) NOT NULL,
  `Name` varchar(100) CHARACTER SET utf8 NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Đang đổ dữ liệu cho bảng `ProductCategory`
--

INSERT INTO `ProductCategory` (`ID`, `Name`) VALUES
(1, 'PE'),
(2, 'PP'),
(3, 'Xốp đen'),
(4, 'Xốp hồng'),
(5, 'Xốp Vàng'),
(7, 'Xốp Đỏ'),
(10, 'Test2');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `Refund`
--

CREATE TABLE `Refund` (
  `ID` bigint(20) NOT NULL,
  `Code` varchar(50) NOT NULL,
  `CustomerCode` varchar(50) NOT NULL,
  `UserID` bigint(20) NOT NULL,
  `RefundDelete` tinyint(1) NOT NULL DEFAULT 0,
  `Note` text DEFAULT NULL,
  `Status` tinyint(1) NOT NULL,
  `Time` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Đang đổ dữ liệu cho bảng `Refund`
--

INSERT INTO `Refund` (`ID`, `Code`, `CustomerCode`, `UserID`, `RefundDelete`, `Note`, `Status`, `Time`) VALUES
(1, 'EP8232022_022753', 'KH8232022_022800', 1, 0, 'abcdef', 0, '2022-08-23 02:27:00'),
(2, 'EP8232022_023316', 'KH8232022_022800', 1, 0, 'test', 0, '2022-08-23 02:32:00'),
(3, 'EP8232022_04133', 'KH_2', 1, 1, '5', 0, '2022-08-23 12:41:00'),
(4, 'EP8232022_05604', 'KH8182022_133751', 1, 0, NULL, 0, '2022-08-23 12:55:00'),
(5, 'EP8232022_05814', 'KH_3', 1, 0, 'test', 0, '2022-08-23 12:57:00'),
(6, 'EP8242022_215016', 'KH_2', 1, 0, 'abcdef', 0, '2022-08-24 09:49:00'),
(7, 'EP8252022_111405', 'KH8252022_103704', 1, 0, 'test chinh sua phieu tra 25/8/2022', 1, '2022-08-25 11:13:00'),
(8, 'EP8252022_03640', 'KH_VANGLAI', 2, 0, 'test ', 0, '2022-08-25 12:36:00');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `RefundDetail`
--

CREATE TABLE `RefundDetail` (
  `ID` bigint(11) NOT NULL,
  `RefundCode` varchar(50) NOT NULL,
  `RefundDetailDelete` tinyint(1) NOT NULL DEFAULT 0,
  `ProductCode` varchar(50) NOT NULL,
  `Price` decimal(18,0) NOT NULL,
  `Quantity` bigint(20) NOT NULL,
  `UnitID` bigint(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Đang đổ dữ liệu cho bảng `RefundDetail`
--

INSERT INTO `RefundDetail` (`ID`, `RefundCode`, `RefundDetailDelete`, `ProductCode`, `Price`, `Quantity`, `UnitID`) VALUES
(1, 'EP8232022_022753', 0, 'SP-3', '50000', 5, 1),
(2, 'EP8232022_023316', 0, 'SP-1', '50000', 1000, 1),
(3, 'EP8232022_04133', 1, 'SP-2', '50000', 5, 1),
(10, 'EP8232022_05814', 0, 'SP-5', '7000', 555, 1),
(11, 'EP8232022_05814', 0, 'SP862022_193202', '23000', 555, 1),
(14, 'EP8242022_215016', 0, 'SP-2', '50000', 55, 1),
(15, 'EP8242022_215016', 0, 'SP-1', '50000', 500, 1),
(16, 'EP8232022_05604', 0, 'SP-2', '50000', 555, 1),
(17, 'EP8232022_05604', 0, 'SP-1', '50000', 555, 1),
(23, 'EP8252022_111405', 0, 'SP-1', '50000', 555, 1),
(24, 'EP8252022_111405', 0, 'SP-4', '50000', 555, 1),
(25, 'EP8252022_111405', 0, 'SP-2', '50000', 555, 1),
(26, 'EP8252022_111405', 0, 'SP-3', '50000', 55, 1),
(27, 'EP8252022_03640', 0, 'SP-2', '50000', 5, 1),
(28, 'EP8252022_03640', 0, 'SP-1', '50000', 55, 1);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `Role`
--

CREATE TABLE `Role` (
  `ID` int(11) NOT NULL,
  `Name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Đang đổ dữ liệu cho bảng `Role`
--

INSERT INTO `Role` (`ID`, `Name`) VALUES
(1, 'Admin'),
(2, 'Nhân viên'),
(3, 'Quản lý kho');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `Supplier`
--

CREATE TABLE `Supplier` (
  `ID` bigint(20) NOT NULL,
  `Name` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Đang đổ dữ liệu cho bảng `Supplier`
--

INSERT INTO `Supplier` (`ID`, `Name`) VALUES
(1, 'PESICO'),
(3, 'Công ty ABC'),
(4, 'Công ty XYZ'),
(6, 'Test'),
(7, 'Nhà cung cấp HCP'),
(8, 'Kho nhà');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `SupplyDetail`
--

CREATE TABLE `SupplyDetail` (
  `ID` bigint(20) NOT NULL,
  `SupplierID` bigint(20) NOT NULL,
  `ProductCode` varchar(50) NOT NULL,
  `UnitID` bigint(20) NOT NULL,
  `Price` decimal(18,0) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Đang đổ dữ liệu cho bảng `SupplyDetail`
--

INSERT INTO `SupplyDetail` (`ID`, `SupplierID`, `ProductCode`, `UnitID`, `Price`) VALUES
(19, 1, 'SP-3', 1, '199922'),
(20, 3, 'SP-2', 1, '201845'),
(21, 7, 'SP-5', 1, '56454'),
(22, 7, 'SP-1', 1, '247797'),
(23, 1, 'SP-6', 2, '50000'),
(24, 1, 'SP-4', 1, '14000'),
(25, 7, 'SP-3', 1, '543534'),
(26, 7, 'SP862022_193202', 2, '432433'),
(27, 4, 'SP-2', 2, '543534'),
(28, 4, 'SP-1', 1, '543535'),
(29, 4, 'SP-3', 1, '43232'),
(30, 3, 'SP-4', 1, '45343'),
(31, 1, 'SP-1', 1, '10000'),
(32, 1, 'SP-2', 1, '12000'),
(33, 6, 'SP-7', 2, '100000'),
(34, 6, 'SP-9', 1, '43000'),
(35, 4, 'SP-5', 1, '56454'),
(36, 6, 'SP-8', 1, '7000'),
(37, 8, 'SP-1', 1, '199512'),
(38, 8, 'SP-2', 1, '201845'),
(39, 8, 'SP-5', 1, '56454'),
(40, 7, 'SP-2', 1, '239806');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `Unit`
--

CREATE TABLE `Unit` (
  `ID` bigint(20) NOT NULL,
  `Name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Đang đổ dữ liệu cho bảng `Unit`
--

INSERT INTO `Unit` (`ID`, `Name`) VALUES
(1, 'Kg'),
(2, 'Cây'),
(6, 'Cuộn');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `User`
--

CREATE TABLE `User` (
  `ID` bigint(20) NOT NULL,
  `UserName` varchar(50) NOT NULL,
  `Password` varchar(50) NOT NULL,
  `RoleID` bigint(20) DEFAULT NULL,
  `Name` varchar(70) DEFAULT NULL,
  `Status` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Đang đổ dữ liệu cho bảng `User`
--

INSERT INTO `User` (`ID`, `UserName`, `Password`, `RoleID`, `Name`, `Status`) VALUES
(1, 'admin', 'admin', 1, 'Gia Cường', 1),
(2, 'damgiaphat', '123', 2, 'Gia Phát', 1),
(5, 'test', 'test', 1, 'cuong', 1),
(6, 'saddsa', 'saffsa', 1, 'Test', 1);

--
-- Chỉ mục cho các bảng đã đổ
--

--
-- Chỉ mục cho bảng `Customer`
--
ALTER TABLE `Customer`
  ADD PRIMARY KEY (`ID`);

--
-- Chỉ mục cho bảng `Export`
--
ALTER TABLE `Export`
  ADD PRIMARY KEY (`ID`);

--
-- Chỉ mục cho bảng `ExportDetail`
--
ALTER TABLE `ExportDetail`
  ADD PRIMARY KEY (`ID`);

--
-- Chỉ mục cho bảng `History`
--
ALTER TABLE `History`
  ADD PRIMARY KEY (`ID`);

--
-- Chỉ mục cho bảng `Import`
--
ALTER TABLE `Import`
  ADD PRIMARY KEY (`ID`);

--
-- Chỉ mục cho bảng `ImportDetail`
--
ALTER TABLE `ImportDetail`
  ADD PRIMARY KEY (`ID`);

--
-- Chỉ mục cho bảng `Package`
--
ALTER TABLE `Package`
  ADD PRIMARY KEY (`ID`);

--
-- Chỉ mục cho bảng `Product`
--
ALTER TABLE `Product`
  ADD PRIMARY KEY (`ID`);

--
-- Chỉ mục cho bảng `ProductCategory`
--
ALTER TABLE `ProductCategory`
  ADD PRIMARY KEY (`ID`);

--
-- Chỉ mục cho bảng `Refund`
--
ALTER TABLE `Refund`
  ADD PRIMARY KEY (`ID`);

--
-- Chỉ mục cho bảng `RefundDetail`
--
ALTER TABLE `RefundDetail`
  ADD PRIMARY KEY (`ID`);

--
-- Chỉ mục cho bảng `Role`
--
ALTER TABLE `Role`
  ADD PRIMARY KEY (`ID`);

--
-- Chỉ mục cho bảng `Supplier`
--
ALTER TABLE `Supplier`
  ADD PRIMARY KEY (`ID`);

--
-- Chỉ mục cho bảng `SupplyDetail`
--
ALTER TABLE `SupplyDetail`
  ADD PRIMARY KEY (`ID`);

--
-- Chỉ mục cho bảng `Unit`
--
ALTER TABLE `Unit`
  ADD PRIMARY KEY (`ID`);

--
-- Chỉ mục cho bảng `User`
--
ALTER TABLE `User`
  ADD PRIMARY KEY (`ID`);

--
-- AUTO_INCREMENT cho các bảng đã đổ
--

--
-- AUTO_INCREMENT cho bảng `Customer`
--
ALTER TABLE `Customer`
  MODIFY `ID` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT cho bảng `Export`
--
ALTER TABLE `Export`
  MODIFY `ID` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=45;

--
-- AUTO_INCREMENT cho bảng `ExportDetail`
--
ALTER TABLE `ExportDetail`
  MODIFY `ID` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=183;

--
-- AUTO_INCREMENT cho bảng `History`
--
ALTER TABLE `History`
  MODIFY `ID` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=163;

--
-- AUTO_INCREMENT cho bảng `Import`
--
ALTER TABLE `Import`
  MODIFY `ID` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=78;

--
-- AUTO_INCREMENT cho bảng `ImportDetail`
--
ALTER TABLE `ImportDetail`
  MODIFY `ID` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=178;

--
-- AUTO_INCREMENT cho bảng `Package`
--
ALTER TABLE `Package`
  MODIFY `ID` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT cho bảng `Product`
--
ALTER TABLE `Product`
  MODIFY `ID` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT cho bảng `ProductCategory`
--
ALTER TABLE `ProductCategory`
  MODIFY `ID` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT cho bảng `Refund`
--
ALTER TABLE `Refund`
  MODIFY `ID` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT cho bảng `RefundDetail`
--
ALTER TABLE `RefundDetail`
  MODIFY `ID` bigint(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=29;

--
-- AUTO_INCREMENT cho bảng `Role`
--
ALTER TABLE `Role`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT cho bảng `Supplier`
--
ALTER TABLE `Supplier`
  MODIFY `ID` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT cho bảng `SupplyDetail`
--
ALTER TABLE `SupplyDetail`
  MODIFY `ID` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=41;

--
-- AUTO_INCREMENT cho bảng `Unit`
--
ALTER TABLE `Unit`
  MODIFY `ID` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT cho bảng `User`
--
ALTER TABLE `User`
  MODIFY `ID` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
