-- phpMyAdmin SQL Dump
-- version 4.9.1
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le :  jeu. 03 fév. 2022 à 13:49
-- Version du serveur :  5.7.14
-- Version de PHP :  5.6.25

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données :  `onlineclicker`
--

-- --------------------------------------------------------

--
-- Structure de la table `ground_save`
--

DROP TABLE IF EXISTS `ground_save`;
CREATE TABLE IF NOT EXISTS `ground_save` (
  `ground_save_id` int(11) NOT NULL AUTO_INCREMENT,
  `user_save_token` char(6) COLLATE utf8_unicode_ci NOT NULL,
  `tile_index` int(11) NOT NULL,
  `is_free` tinyint(1) NOT NULL DEFAULT '1',
  `tree_gameobject` varchar(50) COLLATE utf8_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`ground_save_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table `user_save`
--

DROP TABLE IF EXISTS `user_save`;
CREATE TABLE IF NOT EXISTS `user_save` (
  `user_save_id` int(11) NOT NULL AUTO_INCREMENT,
  `user_score` int(11) NOT NULL,
  `user_click_level` int(11) NOT NULL,
  `user_auto_gatherer_level` int(11) NOT NULL,
  `user_save_token` char(6) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`user_save_id`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Déchargement des données de la table `user_save`
--

INSERT INTO `user_save` (`user_save_id`, `user_score`, `user_click_level`, `user_auto_gatherer_level`, `user_save_token`) VALUES
(17, 11, 0, 1, 'KK2Mrm');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
