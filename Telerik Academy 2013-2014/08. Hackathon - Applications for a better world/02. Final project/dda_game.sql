-- phpMyAdmin SQL Dump
-- version 4.1.14
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: 
-- Версия на сървъра: 5.6.17
-- PHP Version: 5.5.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `dda_game`
--
CREATE DATABASE dda_game;
-- --------------------------------------------------------

--
-- Структура на таблица `answers`
--

CREATE TABLE IF NOT EXISTS `answers` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `q_id` int(10) unsigned NOT NULL,
  `a_text` varchar(250) NOT NULL,
  `is_correct` tinyint(1) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `q_id` (`q_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=117 ;

--
-- Схема на данните от таблица `answers`
--

INSERT INTO `answers` (`id`, `q_id`, `a_text`, `is_correct`) VALUES
(1, 1, 'Bulgaria', 0),
(2, 1, 'Sweden', 0),
(3, 1, 'Italy', 0),
(4, 1, 'Brazil', 1),
(5, 2, 'Uruguay', 1),
(6, 2, 'Italy', 0),
(7, 2, 'France', 0),
(8, 2, 'Brazil', 0),
(9, 3, 'Cuba', 0),
(10, 3, 'Italy', 0),
(11, 3, 'Russia', 0),
(12, 3, 'Brazil', 1),
(13, 4, 'Bernard Tomic', 0),
(14, 4, 'Henri Kontinen', 0),
(15, 4, 'Grigor Dimitrov', 1),
(16, 4, 'Filip Krajinovic', 0),
(17, 5, 'Floyd Mayweather', 1),
(18, 5, 'Cristiano Ronaldo', 0),
(19, 5, 'Lionel Messi', 0),
(20, 5, 'LeBron James', 0),
(21, 6, 'Allies', 0),
(22, 6, 'Axis', 1),
(23, 6, 'Central Powers', 0),
(24, 6, 'Entente', 0),
(25, 7, 'Boris Yeltsin', 0),
(26, 7, 'Barack Obama', 0),
(27, 7, 'John Kennedy', 1),
(28, 7, 'Todor Zhivkov', 0),
(29, 8, 'Michael I Rangabe', 0),
(30, 8, 'Leo V the Armenian', 0),
(31, 8, 'Nikephoros I', 1),
(32, 8, 'None of these', 0),
(33, 9, 'Hiroshima and Nagasaki', 1),
(34, 9, 'Only Hiroshima', 0),
(35, 9, 'Only Nagasaki', 0),
(36, 9, 'None of these', 0),
(37, 10, '1018', 0),
(38, 10, '681', 1),
(39, 10, '781', 0),
(40, 10, '1185', 0),
(41, 11, '270', 0),
(42, 11, '206', 1),
(43, 11, '256', 0),
(44, 11, '512', 0),
(45, 12, 'Animals', 0),
(46, 12, 'Fungi', 0),
(47, 12, 'Plants', 0),
(48, 12, 'All are Kingdoms', 1),
(49, 13, 'Human', 0),
(50, 13, 'Spider', 0),
(51, 13, 'Microbe', 0),
(52, 13, 'All can Sense Light', 1),
(53, 14, '150', 0),
(54, 14, '1 500', 0),
(55, 14, '150 000', 0),
(56, 14, 'More than 1 500 000', 1),
(57, 15, 'Plants', 1),
(58, 15, 'Animals', 0),
(59, 15, 'Humans', 0),
(60, 15, 'None of these', 0),
(61, 16, 'One', 1),
(62, 16, 'Two', 0),
(63, 16, 'Three', 0),
(64, 16, 'Four', 0),
(65, 17, 'Three', 0),
(66, 17, 'One', 0),
(67, 17, 'Two', 0),
(68, 17, 'Zero', 1),
(69, 18, 'Absolute Metric Unit', 0),
(70, 18, 'Actual Make Up', 0),
(71, 18, 'Atomic Mass Unit', 1),
(72, 18, 'None of the Above', 0),
(73, 19, 'One', 0),
(74, 19, 'Two', 0),
(75, 19, 'Three', 1),
(76, 19, 'Four', 0),
(77, 20, 'Go up', 1),
(78, 20, 'Go down', 0),
(79, 20, 'Stay the same', 0),
(80, 20, 'It depends on the pressure', 0),
(81, 21, 'C#', 0),
(82, 21, 'Java', 0),
(83, 21, 'Python', 0),
(84, 21, 'Pascal', 1),
(85, 22, 'AG(16)', 0),
(86, 22, '157(8)', 1),
(87, 22, '111(16)', 0),
(88, 22, '110111(2)', 0),
(89, 23, '.rtf (Rich Text Format)', 0),
(90, 23, '.odt (OpenDocument Text)', 1),
(91, 23, '.doc (Microsoft Word Document)', 0),
(92, 23, 'All of the above formats can', 0),
(93, 24, 'Network model', 0),
(94, 24, 'Relational model', 1),
(95, 24, 'Object oriented model', 0),
(96, 24, 'Associative model', 0),
(97, 25, 'Media Player Classic', 0),
(98, 25, 'Audacity', 0),
(99, 25, 'QuickTime', 1),
(100, 25, 'Flash Player', 0),
(101, 26, 'Bill Gates', 0),
(102, 26, 'Barack Obama', 0),
(103, 26, 'John Atanasov', 1),
(104, 26, 'Steve Wozniak', 0),
(105, 27, 'Computer key-what?', 0),
(106, 27, 'The thing I''m writing with', 1),
(107, 27, 'New type of cumputer', 0),
(108, 27, 'Type of cat', 0),
(109, 28, 'The thing to cumicate with the computer', 1),
(110, 28, 'Real mouse which can work with computer', 0),
(111, 28, 'Just mouse', 0),
(112, 28, 'None of the above', 0),
(113, 29, 'Very small and soft windows', 0),
(114, 29, 'Computer part', 0),
(115, 29, 'Operating Systems series', 1),
(116, 29, 'Window to the world', 0);

-- --------------------------------------------------------

--
-- Структура на таблица `information`
--

CREATE TABLE IF NOT EXISTS `information` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `q_id` int(10) unsigned NOT NULL,
  `text` varchar(500) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `q_id` (`q_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=10 ;

--
-- Схема на данните от таблица `information`
--

INSERT INTO `information` (`id`, `q_id`, `text`) VALUES
(1, 21, 'Pascal is an influential imperative and procedural programming language, designed in 1968-1969 and published in 1970 by Niklaus Wirth as a small and efficient language intended to encourage good programming practices using structured programming and data structuring.'),
(2, 22, 'In mathematics and computing, hexadecimal (also base 16, or hex) is a positional numeral system with a radix, or base, of 16. It uses sixteen distinct symbols, most often the symbols 0-9 to represent values zero to nine, and A,B,C,D,E,F (or alternatively a-f) to represent values ten to fifteen.'),
(3, 23, 'OpenDocument is an XML-based file format for spreadsheets, charts, presentations and word processing documents.'),
(4, 24, 'The relational model for database management is a database model based on first-order predicate logic, first formulated and proposed in 1969 by Edgar F. Codd.In the relational model of a database, all data is represented in terms of tuples, grouped into relations. A database organized in terms of the relational model is a relational database.'),
(5, 25, 'QuickTime is an extensible multimedia framework developed by Apple Inc., capable of handling various formats of digital video, picture, sound, panoramic images, and interactivity.'),
(6, 26, 'The first digital computer was invented by John Vincent Atanasoff in 1930s'),
(7, 27, 'In computing, a keyboard is a typewriter-style device, which uses an arrangement of buttons or keys, to act as mechanical levers or electronic switches.'),
(8, 28, 'In computing, a mouse is a pointing device that detects two-dimensional motion relative to a surface.'),
(9, 29, 'Microsoft Windows is a series of graphical interface operating systems developed, marketed, and sold by Microsoft.');

-- --------------------------------------------------------

--
-- Структура на таблица `questions`
--

CREATE TABLE IF NOT EXISTS `questions` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `t_id` int(10) unsigned NOT NULL,
  `q_text` varchar(250) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `t_id` (`t_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=30 ;

--
-- Схема на данните от таблица `questions`
--

INSERT INTO `questions` (`id`, `t_id`, `q_text`) VALUES
(1, 1, 'Which country won 1994 FIFA World Cup?'),
(2, 1, 'Where was the first FIFA World Cup held?'),
(3, 1, 'Which country won most titles on FIVB Volleyball World League?'),
(4, 1, 'Who won 2008 Wimbledon Championships - Boy''s Singles?'),
(5, 1, 'Which athlete is the highest-paid athlete in the world for 2013?'),
(6, 2, 'Which side did Bulgaria at World War II compete on?'),
(7, 2, 'Which of the following presidents was shot and died afterwards?'),
(8, 2, 'Who was defeated in the Battle of Varbitsa Pass by Krum the Fearsome?'),
(9, 2, 'Which city/ies was/were bombed during World War II?'),
(10, 2, 'Which year is the First Bulgarian Empire established?'),
(11, 3, 'How many bones are in the human body by adulthood?'),
(12, 3, 'Which of these is not a Kingdom?'),
(13, 3, 'Which of the following organisms can sense light?'),
(14, 3, 'How many species are known on Earth?'),
(15, 3, 'Which organisms has Photosynthesis as characteristic?'),
(16, 4, 'How many electrons in a Hydrogen (H) atom?'),
(17, 4, 'How many neutrons in a Hydrogen (H) atom?'),
(18, 4, 'What do the letters "amu" stand for?'),
(19, 4, 'If an atom has 13 electrons, how many shells will have electrons?'),
(20, 4, 'What will happen to the pressure inside of a sealed tube if you raise the temperature?'),
(21, 5, 'Which of the following programming languages is non object-oriented?'),
(22, 5, 'How much is FA(16) - 10001011(2)?'),
(23, 5, 'Which of the following text formats cannot containt images?'),
(24, 5, 'Which of the following is the most commonly used type of database system model?'),
(25, 5, 'Which of the following is a media player and is not a Microsoft product?'),
(26, 5, 'Who invented the first digital computer?'),
(27, 5, 'What is computer keyboard?'),
(28, 5, 'What is computer mouse?'),
(29, 5, 'What is Microsoft Windows?');

-- --------------------------------------------------------

--
-- Структура на таблица `subjects`
--

CREATE TABLE IF NOT EXISTS `subjects` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `title` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=6 ;

--
-- Схема на данните от таблица `subjects`
--

INSERT INTO `subjects` (`id`, `title`) VALUES
(1, 'Sport'),
(2, 'History'),
(3, 'Biology'),
(4, 'Chemistry'),
(5, 'Programming');

--
-- Ограничения за дъмпнати таблици
--

--
-- Ограничения за таблица `answers`
--
ALTER TABLE `answers`
  ADD CONSTRAINT `answers_ibfk_1` FOREIGN KEY (`q_id`) REFERENCES `questions` (`id`);

--
-- Ограничения за таблица `information`
--
ALTER TABLE `information`
  ADD CONSTRAINT `information_ibfk_1` FOREIGN KEY (`q_id`) REFERENCES `questions` (`id`);

--
-- Ограничения за таблица `questions`
--
ALTER TABLE `questions`
  ADD CONSTRAINT `questions_ibfk_1` FOREIGN KEY (`t_id`) REFERENCES `subjects` (`id`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
