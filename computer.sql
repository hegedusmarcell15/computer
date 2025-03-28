
SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


CREATE DATABASE IF NOT EXISTS `computer` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `computer`;



DROP TABLE IF EXISTS `comp`;
CREATE TABLE IF NOT EXISTS `comp` (
  `ID` int(36) NOT NULL AUTO_INCREMENT,
  `brand` varchar(37) NOT NULL,
  `type` varchar(30) NOT NULL,
  `Display` double NOT NULL,
  `Memory` int(11) NOT NULL,
  `CreatedTime` datetime NOT NULL,
  `Osid` int(36) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `Osid` (`Osid`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb4;


INSERT INTO `comp` (`ID`, `brand`, `type`, `Display`, `Memory`, `CreatedTime`, `Osid`) VALUES
(1, 'sony', 'laptop', 1, 16, '2025-03-21 11:58:29', 1),
(8, 'Lenovo', 'asztali_PC', 0, 1046, '2024-08-05 23:38:10', 2),
(9, 'BLU', 'laptop', 1, 957, '2024-04-15 06:57:41', 1),
(11, 'LG', 'asztali_PC', 0, 75, '2024-11-23 01:20:32', 2),
(12, 'Infinix', 'laptop', 1, 424, '2024-10-09 14:17:51', 3),
(13, 'LG', 'laptop', 1, 697, '2025-03-17 12:12:51', 3),
(14, 'Nokia', 'asztali_PC', 1, 1165, '2024-09-17 23:42:14', 2),
(15, 'Philips', 'asztali_PC', 0, 236, '2024-04-07 17:38:32', 2),
(16, 'HP', 'asztali_PC', 1, 807, '2025-03-05 22:21:42', 1),
(17, 'vivo', 'laptop', 1, 234, '2024-10-07 05:08:37', 3);


DROP TABLE IF EXISTS `ossystem`;
CREATE TABLE IF NOT EXISTS `ossystem` (
  `name` varchar(27) NOT NULL,
  `CreatedTime` datetime NOT NULL,
  `ID` int(36) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4;



INSERT INTO `ossystem` (`name`, `CreatedTime`, `ID`) VALUES
('windows', '2025-03-02 11:57:46', 1),
('linux', '2016-08-17 12:01:40', 2),
('MacOS', '2016-12-07 12:01:40', 3);


ALTER TABLE `comp`
  ADD CONSTRAINT `comp_ibfk_1` FOREIGN KEY (`Osid`) REFERENCES `ossystem` (`ID`);
COMMIT;
