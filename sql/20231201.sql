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
CREATE DATABASE IF NOT EXISTS `StudentActivities` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci */;
USE `StudentActivities`;

-- Дамп структуры для таблица StudentActivities.Certificates
CREATE TABLE IF NOT EXISTS `Certificates` (
  `id_cert` int(11) NOT NULL AUTO_INCREMENT,
  `id_stu` int(11) NOT NULL DEFAULT '0',
  `diplom` varchar(500) COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '0',
  `dat` varchar(30) COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '0',
  PRIMARY KEY (`id_cert`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Дамп данных таблицы StudentActivities.Certificates: ~4 rows (приблизительно)
INSERT INTO `Certificates` (`id_cert`, `id_stu`, `diplom`, `dat`) VALUES
	(1, 2, 'пкщяф', '18.11.2023 0:00:00'),
	(2, 3, '321321', '23.11.2023 0:00:00'),
	(3, 5, 'Анализ Графиков', '29.11.2023 0:00:00'),
	(4, 4, 'Линейная функция', '29.11.2023 0:00:00');

-- Дамп структуры для таблица StudentActivities.Command_student
CREATE TABLE IF NOT EXISTS `Command_student` (
  `id_pro_stu` int(11) NOT NULL AUTO_INCREMENT,
  `id_pro` int(11) DEFAULT '0',
  `id_stu` int(11) DEFAULT '0',
  `form` int(11) DEFAULT '0',
  `name_teacher` int(11) DEFAULT '0',
  `subject` int(11) DEFAULT '0',
  PRIMARY KEY (`id_pro_stu`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Дамп данных таблицы StudentActivities.Command_student: ~1 rows (приблизительно)
INSERT INTO `Command_student` (`id_pro_stu`, `id_pro`, `id_stu`, `form`, `name_teacher`, `subject`) VALUES
	(2, 2, 1, 3, 4, 5),
	(3, 5, 5, 1, 23, 33);

-- Дамп структуры для таблица StudentActivities.Olympiada
CREATE TABLE IF NOT EXISTS `Olympiada` (
  `id_oly` int(11) NOT NULL AUTO_INCREMENT,
  `points` int(11) DEFAULT NULL,
  `season` varchar(50) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `Dat_event` varchar(50) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `Dats_event` varchar(50) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`id_oly`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Дамп данных таблицы StudentActivities.Olympiada: ~1 rows (приблизительно)
INSERT INTO `Olympiada` (`id_oly`, `points`, `season`, `Dat_event`, `Dats_event`) VALUES
	(6, 1, '2', '01.12.2023 0:00:00', '20231201'),
	(7, 200, 'Осень Физика 2023', '11.10.2023 0:00:00', '20231011');

-- Дамп структуры для таблица StudentActivities.Olymp_students
CREATE TABLE IF NOT EXISTS `Olymp_students` (
  `id_oly_stu` int(11) NOT NULL AUTO_INCREMENT,
  `id_oly` int(11) NOT NULL DEFAULT '0',
  `id_stu` int(11) NOT NULL DEFAULT '0',
  `form` varchar(200) COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '0',
  `name_teacher` varchar(200) COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '0',
  `subject` varchar(200) COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '0',
  `scores` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id_oly_stu`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Дамп данных таблицы StudentActivities.Olymp_students: ~6 rows (приблизительно)
INSERT INTO `Olymp_students` (`id_oly_stu`, `id_oly`, `id_stu`, `form`, `name_teacher`, `subject`, `scores`) VALUES
	(1, 3, 3, '11', '1', '2', 3),
	(2, 3, 1, '3', '4', '5', 6),
	(3, 3, 3, '44', 'fgh', 'dfg', 1),
	(4, 7, 5, '11', 'Жанат', 'Физика', 56),
	(5, 7, 4, '11', 'Жанат', 'Физика', 90),
	(6, 7, 6, '11', 'Баймен', 'Физика', 50);

-- Дамп структуры для таблица StudentActivities.Projects
CREATE TABLE IF NOT EXISTS `Projects` (
  `id_pro` int(11) NOT NULL AUTO_INCREMENT,
  `area_subj` varchar(500) COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '0',
  `topic` varchar(500) COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '0',
  `commands` varchar(500) COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '0',
  `dat_start` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '0',
  `dats_start` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '0',
  `dat_end` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '0',
  `dats_end` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '0',
  `finish` tinyint(1) NOT NULL DEFAULT '0',
  `docx` longblob NOT NULL,
  `docx_yes` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id_pro`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Дамп данных таблицы StudentActivities.Projects: ~7 rows (приблизительно)
INSERT INTO `Projects` (`id_pro`, `area_subj`, `topic`, `commands`, `dat_start`, `dats_start`, `dat_end`, `dats_end`, `finish`, `docx`, `docx_yes`) VALUES
	(5, 'Информатика', 'Линейная функция', '1', '23.11.2023 0:00:00', '20231123', '01.12.2023 0:00:00', '20231201', 1, _binary '', 1),
	(6, 'Информатика', 'Линейные уравнения', '2', '30.10.2023 0:00:00', '20231030', '01.12.2023 0:00:00', '01.12.2023 0:00:00', 0, _binary '', 0),
	(7, 'Информатика', 'Информатика как искусство', '4', '01.06.2023 0:00:00', '20230601', '22.12.2023 0:00:00', '20231222', 1, _binary '', 1),
	(8, 'Математика', 'Геометрия и теория чисел', '1', '01.12.2023 0:00:00', '20231201', '01.12.2023 0:00:00', '01.12.2023 0:00:00', 0, _binary '', 0),
	(9, 'Математика', 'Нобелевские лауреаты в области математика', '2', '08.08.2023 0:00:00', '20230808', '03.10.2023 0:00:00', '03.10.2023 0:00:00', 0, _binary '', 0),
	(10, 'Физика', 'Влияние температуры на жидкости, газы и твердые тела', '2', '06.04.2023 0:00:00', '20230406', '27.11.2023 0:00:00', '27.11.2023 0:00:00', 0, _binary '', 0),
	(11, 'Физика', 'Влияние электромагнитного поля на рост растений и здоровье человека', '4', '10.10.2023 0:00:00', '20231010', '21.12.2023 0:00:00', '21.12.2023 0:00:00', 0, _binary '', 0),
	(12, 'Физика', 'Термодинамика и Статистическая физика', '2', '15.11.2023 0:00:00', '20231115', '27.01.2024 0:00:00', '27.01.2024 0:00:00', 0, _binary '', 0),
	(13, 'Химия', 'Влияние видов химической связи на свойства веществ', '4', '07.11.2023 0:00:00', '20231107', '21.02.2024 0:00:00', '21.02.2024 0:00:00', 0, _binary '', 0),
	(14, 'Химия', 'Гальванопластика и гальваностегия', '2', '04.10.2023 0:00:00', '20231004', '28.02.2024 0:00:00', '28.02.2024 0:00:00', 0, _binary '', 0),
	(15, 'Химия', 'Гидролиз солей', '1', '12.04.2023 0:00:00', '20230412', '21.03.2024 0:00:00', '21.03.2024 0:00:00', 0, _binary '', 0);

-- Дамп структуры для таблица StudentActivities.Students
CREATE TABLE IF NOT EXISTS `Students` (
  `id_stu` int(11) NOT NULL AUTO_INCREMENT,
  `iin` varchar(12) COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '0',
  `name` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '0',
  `email` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '0',
  `phone` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '0',
  `name_lat` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '0',
  `password` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '0',
  PRIMARY KEY (`id_stu`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Дамп данных таблицы StudentActivities.Students: ~2 rows (приблизительно)
INSERT INTO `Students` (`id_stu`, `iin`, `name`, `email`, `phone`, `name_lat`, `password`) VALUES
	(4, '56923765299', 'Аружан', 'aruzhan@nurzhan.mail', '+777512349', 'aruzhan', 'qwerty123'),
	(5, '742797483465', 'Мурат', 'murat2023@nurzhanmail.', '+7702250123', 'murat', 'qwerty12345'),
	(6, '781853655415', 'Зорин Артём Кириллович', 'artem12345@mail.ru', '+7502601245', 'Artem', 'rosa123');

-- Дамп структуры для таблица StudentActivities.Users
CREATE TABLE IF NOT EXISTS `Users` (
  `ID_Users` int(8) NOT NULL AUTO_INCREMENT,
  `Login` varchar(50) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `Password` varchar(50) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `Name` varchar(50) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `Access` int(1) DEFAULT NULL,
  PRIMARY KEY (`ID_Users`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Дамп данных таблицы StudentActivities.Users: ~17 rows (приблизительно)
INSERT INTO `Users` (`ID_Users`, `Login`, `Password`, `Name`, `Access`) VALUES
	(1, 'Admin', 'Rosa123', 'Сидоров', 5),
	(2, 'Student', 'qwerty', 'Иванов', 1),
	(3, 'Student', '9867', 'Куат Нурарай Асхаткызы', 1),
	(4, 'Student', 'homo', 'Отепбергенова Жанайым Ғалымқызы', 1),
	(5, 'Student', 'jekinoff', 'Жалғасбаев Марк Бақытжанович', 1),
	(6, 'Student', 'qwerty123', 'Федорова Камила Вячеславовна', 1),
	(7, 'Student', 'asdw', 'Абдулаев Ғафур Захирович', 1),
	(8, 'Student', 'fasd', 'Хегай Анатолий Владимирович', 1),
	(9, 'Student', 'qqwwee', 'Касимов Ахмеджан Тажикович', 1),
	(10, 'Student', 'ihw', 'Абдимажитова Аружан Муратовна', 1),
	(11, 'Student', 'bon', 'Майоров Александр Александрович', 1),
	(12, 'Student', 'sigmaparol', 'Фадеева Екатерина Кирилловна', 1),
	(13, 'Student', 'gigaparol', 'Зайцева Малика Ярославовна', 1),
	(14, 'Student', 'gigachadparol', 'Ситникова Полина Леоновна', 1),
	(15, 'Student', 'amogus', 'Икари Альберт Перавич', 1),
	(16, 'Student', 'susparol', 'Ковальчук Борис Глебович', 1),
	(17, 'Student', 'ghrtqw', 'Попов Платон Дмитриевич', 1),
	(18, 'Student', 'qwerty12345', 'Лебедева Елизавета Максимовна', 1),
	(19, 'Student', 'asdqwerty', 'Зорин Артём Кириллович', 1);

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
