CREATE DATABASE  IF NOT EXISTS `univesity` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `univesity`;
-- MySQL dump 10.13  Distrib 5.6.24, for Win64 (x86_64)
--
-- Host: localhost    Database: univesity
-- ------------------------------------------------------
-- Server version	5.6.27-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `courses`
--

DROP TABLE IF EXISTS `courses`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `courses` (
  `CoursesId` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) NOT NULL,
  `Departments_DepartmentsID` int(11) NOT NULL,
  PRIMARY KEY (`CoursesId`),
  UNIQUE KEY `idCourses_UNIQUE` (`CoursesId`),
  KEY `fk_Courses_Departments1_idx` (`Departments_DepartmentsID`),
  CONSTRAINT `fk_Courses_Departments1` FOREIGN KEY (`Departments_DepartmentsID`) REFERENCES `departments` (`DepartmentsID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `courses`
--

LOCK TABLES `courses` WRITE;
/*!40000 ALTER TABLE `courses` DISABLE KEYS */;
INSERT INTO `courses` VALUES (1,'DSA',1),(2,'Database',2),(3,'JavaScript',2);
/*!40000 ALTER TABLE `courses` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `courses_has_professors`
--

DROP TABLE IF EXISTS `courses_has_professors`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `courses_has_professors` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Courses_CoursesId` int(11) NOT NULL,
  `Professors_ProfessorsId` int(10) unsigned NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Id_UNIQUE` (`Id`),
  KEY `fk_Courses_has_Professors_Professors1_idx` (`Professors_ProfessorsId`),
  KEY `fk_Courses_has_Professors_Courses1_idx` (`Courses_CoursesId`),
  CONSTRAINT `fk_Courses_has_Professors_Courses1` FOREIGN KEY (`Courses_CoursesId`) REFERENCES `courses` (`CoursesId`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Courses_has_Professors_Professors1` FOREIGN KEY (`Professors_ProfessorsId`) REFERENCES `professors` (`ProfessorsId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `courses_has_professors`
--

LOCK TABLES `courses_has_professors` WRITE;
/*!40000 ALTER TABLE `courses_has_professors` DISABLE KEYS */;
INSERT INTO `courses_has_professors` VALUES (1,1,1),(2,1,2),(3,2,2),(4,3,2);
/*!40000 ALTER TABLE `courses_has_professors` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `departments`
--

DROP TABLE IF EXISTS `departments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `departments` (
  `DepartmentsID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) NOT NULL,
  `Faculties_FacultiesId` int(11) NOT NULL,
  PRIMARY KEY (`DepartmentsID`),
  UNIQUE KEY `idDepartments_UNIQUE` (`DepartmentsID`),
  KEY `fk_Departments_Faculties_idx` (`Faculties_FacultiesId`),
  CONSTRAINT `fk_Departments_Faculties` FOREIGN KEY (`Faculties_FacultiesId`) REFERENCES `faculties` (`FacultiesId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `departments`
--

LOCK TABLES `departments` WRITE;
/*!40000 ALTER TABLE `departments` DISABLE KEYS */;
INSERT INTO `departments` VALUES (1,'Web',1),(2,'Mobile',1),(3,'QA',2);
/*!40000 ALTER TABLE `departments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `faculties`
--

DROP TABLE IF EXISTS `faculties`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `faculties` (
  `FacultiesId` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) NOT NULL,
  `univesity_univesityId` int(11) NOT NULL,
  PRIMARY KEY (`FacultiesId`),
  UNIQUE KEY `idFaculties_UNIQUE` (`FacultiesId`),
  KEY `fk_Faculties_univesity1_idx` (`univesity_univesityId`),
  CONSTRAINT `fk_Faculties_univesity1` FOREIGN KEY (`univesity_univesityId`) REFERENCES `univesity` (`univesityId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `faculties`
--

LOCK TABLES `faculties` WRITE;
/*!40000 ALTER TABLE `faculties` DISABLE KEYS */;
INSERT INTO `faculties` VALUES (1,'Dev',1),(2,'QA',1);
/*!40000 ALTER TABLE `faculties` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `professors`
--

DROP TABLE IF EXISTS `professors`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `professors` (
  `ProfessorsId` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `FirstName` varchar(50) DEFAULT NULL,
  `LastName` varchar(50) NOT NULL,
  `Departments_DepartmentsID` int(11) NOT NULL,
  PRIMARY KEY (`ProfessorsId`),
  KEY `fk_Professors_Departments1_idx` (`Departments_DepartmentsID`),
  CONSTRAINT `fk_Professors_Departments1` FOREIGN KEY (`Departments_DepartmentsID`) REFERENCES `departments` (`DepartmentsID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `professors`
--

LOCK TABLES `professors` WRITE;
/*!40000 ALTER TABLE `professors` DISABLE KEYS */;
INSERT INTO `professors` VALUES (1,'Nikolay','Kostov',1),(2,'Doncho ','Minkov',2),(3,'Ivailo','Kenov',1),(4,NULL,'Cuki',2),(5,'Evlogi','Hristov',3);
/*!40000 ALTER TABLE `professors` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `professors_has_titles`
--

DROP TABLE IF EXISTS `professors_has_titles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `professors_has_titles` (
  `Professors_ProfessorsId` int(10) unsigned NOT NULL,
  `Titles_TitlesId` int(11) NOT NULL,
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Id_UNIQUE` (`Id`),
  KEY `fk_Professors_has_Titles_Titles1_idx` (`Titles_TitlesId`),
  KEY `fk_Professors_has_Titles_Professors1_idx` (`Professors_ProfessorsId`),
  CONSTRAINT `fk_Professors_has_Titles_Professors1` FOREIGN KEY (`Professors_ProfessorsId`) REFERENCES `professors` (`ProfessorsId`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Professors_has_Titles_Titles1` FOREIGN KEY (`Titles_TitlesId`) REFERENCES `titles` (`TitlesId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `professors_has_titles`
--

LOCK TABLES `professors_has_titles` WRITE;
/*!40000 ALTER TABLE `professors_has_titles` DISABLE KEYS */;
INSERT INTO `professors_has_titles` VALUES (1,1,1),(1,2,2),(2,1,3),(2,2,4),(3,3,5),(4,3,6),(5,3,7);
/*!40000 ALTER TABLE `professors_has_titles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `students`
--

DROP TABLE IF EXISTS `students`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `students` (
  `StudentsId` int(11) NOT NULL AUTO_INCREMENT,
  `FirstName` varchar(50) DEFAULT NULL,
  `LastName` varchar(50) NOT NULL,
  `Faculties_FacultiesId` int(11) NOT NULL,
  PRIMARY KEY (`StudentsId`),
  UNIQUE KEY `StudentsId_UNIQUE` (`StudentsId`),
  KEY `fk_Students_Faculties1_idx` (`Faculties_FacultiesId`),
  CONSTRAINT `fk_Students_Faculties1` FOREIGN KEY (`Faculties_FacultiesId`) REFERENCES `faculties` (`FacultiesId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `students`
--

LOCK TABLES `students` WRITE;
/*!40000 ALTER TABLE `students` DISABLE KEYS */;
INSERT INTO `students` VALUES (1,'Pesho','Peshov',1),(2,'Stamat','STamatov',2),(3,'John','Atanasov',2);
/*!40000 ALTER TABLE `students` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `students_has_courses`
--

DROP TABLE IF EXISTS `students_has_courses`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `students_has_courses` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Students_StudentsId` int(11) NOT NULL,
  `Courses_CoursesId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Id_UNIQUE` (`Id`),
  KEY `fk_Students_has_Courses_Courses1_idx` (`Courses_CoursesId`),
  KEY `fk_Students_has_Courses_Students1_idx` (`Students_StudentsId`),
  CONSTRAINT `fk_Students_has_Courses_Courses1` FOREIGN KEY (`Courses_CoursesId`) REFERENCES `courses` (`CoursesId`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Students_has_Courses_Students1` FOREIGN KEY (`Students_StudentsId`) REFERENCES `students` (`StudentsId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `students_has_courses`
--

LOCK TABLES `students_has_courses` WRITE;
/*!40000 ALTER TABLE `students_has_courses` DISABLE KEYS */;
INSERT INTO `students_has_courses` VALUES (1,1,1),(2,1,2),(3,2,2),(4,3,2);
/*!40000 ALTER TABLE `students_has_courses` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `titles`
--

DROP TABLE IF EXISTS `titles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `titles` (
  `TitlesId` int(11) NOT NULL AUTO_INCREMENT,
  `Title` varchar(50) NOT NULL,
  PRIMARY KEY (`TitlesId`),
  UNIQUE KEY `TitlesId_UNIQUE` (`TitlesId`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `titles`
--

LOCK TABLES `titles` WRITE;
/*!40000 ALTER TABLE `titles` DISABLE KEYS */;
INSERT INTO `titles` VALUES (1,'Ph. D'),(2,'Academician'),(3,'Senior assistant');
/*!40000 ALTER TABLE `titles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `univesity`
--

DROP TABLE IF EXISTS `univesity`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `univesity` (
  `univesityId` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) NOT NULL,
  PRIMARY KEY (`univesityId`),
  UNIQUE KEY `univesityId_UNIQUE` (`univesityId`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `univesity`
--

LOCK TABLES `univesity` WRITE;
/*!40000 ALTER TABLE `univesity` DISABLE KEYS */;
INSERT INTO `univesity` VALUES (1,'Telerik Academy');
/*!40000 ALTER TABLE `univesity` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2015-10-07 23:55:26
