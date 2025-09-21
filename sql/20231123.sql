-- --------------------------------------------------------
-- Хост:                         127.0.0.1
-- Версия сервера:               5.6.51 - MySQL Community Server (GPL)
-- Операционная система:         Win64
-- HeidiSQL Версия:              12.1.0.6537
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Дамп структуры базы данных StudentActivities
DROP DATABASE IF EXISTS `StudentActivities`;
CREATE DATABASE IF NOT EXISTS `StudentActivities` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci */;
USE `StudentActivities`;

-- Дамп структуры для таблица StudentActivities.Certificates
DROP TABLE IF EXISTS `Certificates`;
CREATE TABLE IF NOT EXISTS `Certificates` (
  `id_cert` int(11) NOT NULL AUTO_INCREMENT,
  `id_stu` int(11) NOT NULL DEFAULT '0',
  `diplom` varchar(500) COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '0',
  `dat` varchar(30) COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '0',
  PRIMARY KEY (`id_cert`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Дамп данных таблицы StudentActivities.Certificates: ~2 rows (приблизительно)
INSERT INTO `Certificates` (`id_cert`, `id_stu`, `diplom`, `dat`) VALUES
	(1, 2, 'пкщяф', '18.11.2023 0:00:00'),
	(2, 3, '321321', '23.11.2023 0:00:00');

-- Дамп структуры для таблица StudentActivities.Olympiada
DROP TABLE IF EXISTS `Olympiada`;
CREATE TABLE IF NOT EXISTS `Olympiada` (
  `id_oly` int(11) NOT NULL AUTO_INCREMENT,
  `points` int(11) DEFAULT NULL,
  `season` varchar(50) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `Dat_event` varchar(50) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `Dats_event` varchar(50) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`id_oly`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Дамп данных таблицы StudentActivities.Olympiada: ~2 rows (приблизительно)
INSERT INTO `Olympiada` (`id_oly`, `points`, `season`, `Dat_event`, `Dats_event`) VALUES
	(3, 12, 'sfg', '17.11.2023 0:00:00', '20231117'),
	(4, 100, 'Физика Осень 2023', '23.11.2023 0:00:00', '20231123');

-- Дамп структуры для таблица StudentActivities.Olymp_students
DROP TABLE IF EXISTS `Olymp_students`;
CREATE TABLE IF NOT EXISTS `Olymp_students` (
  `id_oly_stu` int(11) NOT NULL AUTO_INCREMENT,
  `id_oly` int(11) NOT NULL DEFAULT '0',
  `id_stu` int(11) NOT NULL DEFAULT '0',
  `form` varchar(200) COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '0',
  `name_teacher` varchar(200) COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '0',
  `subject` varchar(200) COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '0',
  `scores` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id_oly_stu`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Дамп данных таблицы StudentActivities.Olymp_students: ~0 rows (приблизительно)
INSERT INTO `Olymp_students` (`id_oly_stu`, `id_oly`, `id_stu`, `form`, `name_teacher`, `subject`, `scores`) VALUES
	(1, 3, 3, '11', '1', '2', 3),
	(2, 3, 1, '3', '4', '5', 6);

-- Дамп структуры для таблица StudentActivities.Projects
DROP TABLE IF EXISTS `Projects`;
CREATE TABLE IF NOT EXISTS `Projects` (
  `id_pro` int(11) NOT NULL AUTO_INCREMENT,
  `area_subj` varchar(500) COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '0',
  `topic` varchar(500) COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '0',
  `commands` int(11) NOT NULL DEFAULT '0',
  `dat_start` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '0',
  `dats_start` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '0',
  `dat_end` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '0',
  `dats_end` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '0',
  `finish` tinyint(1) NOT NULL DEFAULT '0',
  `docx` longblob NOT NULL,
  `docx_yes` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id_pro`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Дамп данных таблицы StudentActivities.Projects: ~1 rows (приблизительно)
INSERT INTO `Projects` (`id_pro`, `area_subj`, `topic`, `commands`, `dat_start`, `dats_start`, `dat_end`, `dats_end`, `finish`, `docx`, `docx_yes`) VALUES
	(2, '222', '2333', 3444, '09.11.2023 0:00:00', '20231109', '17.11.2023 0:00:00', '20231117', 0, _binary '', 1);

-- Дамп структуры для таблица StudentActivities.Students
DROP TABLE IF EXISTS `Students`;
CREATE TABLE IF NOT EXISTS `Students` (
  `id_stu` int(11) NOT NULL AUTO_INCREMENT,
  `iin` varchar(12) COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '0',
  `name` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '0',
  `email` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '0',
  `phone` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '0',
  `name_lat` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '0',
  `password` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '0',
  PRIMARY KEY (`id_stu`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Дамп данных таблицы StudentActivities.Students: ~2 rows (приблизительно)
INSERT INTO `Students` (`id_stu`, `iin`, `name`, `email`, `phone`, `name_lat`, `password`) VALUES
	(1, '1', '2', '3', '4', '5', '6'),
	(3, '0123789', 'Алдияр', 'grozatv583@gmail.com', '+756645', 'Aldiyar', 'grozatv');

-- Дамп структуры для таблица StudentActivities.Users
DROP TABLE IF EXISTS `Users`;
CREATE TABLE IF NOT EXISTS `Users` (
  `ID_Users` int(8) NOT NULL AUTO_INCREMENT,
  `Login` varchar(50) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `Password` varchar(50) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `Name` varchar(50) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `Access` int(1) DEFAULT NULL,
  PRIMARY KEY (`ID_Users`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Дамп данных таблицы StudentActivities.Users: ~2 rows (приблизительно)
INSERT INTO `Users` (`ID_Users`, `Login`, `Password`, `Name`, `Access`) VALUES
	(1, 'Admin', 'Rosa123', 'Сидоров', 5),
	(2, 'Student', 'qwerty', 'Иванов', 1);

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
