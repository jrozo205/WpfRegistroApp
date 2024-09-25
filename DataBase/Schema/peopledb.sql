CREATE DATABASE  IF NOT EXISTS `peopledb` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `peopledb`;
-- MySQL dump 10.13  Distrib 8.0.38, for Win64 (x86_64)
--
-- Host: localhost    Database: peopledb
-- ------------------------------------------------------
-- Server version	9.0.1

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `area`
--

DROP TABLE IF EXISTS `area`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `area` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `area`
--

LOCK TABLES `area` WRITE;
/*!40000 ALTER TABLE `area` DISABLE KEYS */;
INSERT INTO `area` VALUES (1,'Recursos Humanos'),(2,'Finanzas'),(3,'Tecnología'),(4,'Marketing'),(5,'Ventas'),(6,'Atención al Cliente'),(7,'Legal'),(8,'Operaciones'),(9,'Logística'),(10,'Investigación y Desarrollo'),(11,'Producción'),(12,'Compras'),(13,'Calidad'),(14,'Seguridad'),(15,'Administración');
/*!40000 ALTER TABLE `area` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `IdUser` int NOT NULL,
  `Id_area` int NOT NULL,
  `Name` varchar(50) DEFAULT NULL,
  `LastName` varchar(50) DEFAULT NULL,
  `Address` varchar(100) DEFAULT NULL,
  `Phone` varchar(30) DEFAULT NULL,
  `Email` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `Id_area` (`Id_area`),
  CONSTRAINT `user_ibfk_1` FOREIGN KEY (`Id_area`) REFERENCES `area` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (1,1001,1,'Juan','Pérez','Carrera 10 #23-45, Bogotá','3205678901','juan.perez@example.com'),(2,1002,2,'María','Rodríguez','Calle 100 #15-60, Medellín','3102345678','maria.rodriguez@example.com'),(3,1003,3,'Carlos','López','Avenida 30 #45-20, Cali','3159876543','carlos.lopez@example.com'),(4,1004,4,'Ana','García','Carrera 50 #12-34, Barranquilla','3115678902','ana.garcia@example.com'),(5,1005,5,'Luis','Martínez','Calle 70 #20-15, Bucaramanga','3123456789','luis.martinez@example.com'),(6,1006,6,'Sofía','Torres','Carrera 30 #55-90, Cartagena','3107654321','sofia.torres@example.com'),(7,1007,7,'Andrés','Ramírez','Avenida 80 #32-45, Cúcuta','3209876543','andres.ramirez@example.com'),(8,1008,8,'Paula','Hernández','Carrera 15 #100-20, Ibagué','3186543210','paula.hernandez@example.com'),(9,1009,9,'Jorge','Mendoza','Calle 80 #40-60, Manizales','3129876543','jorge.mendoza@example.com'),(10,1010,10,'Camila','Morales','Avenida 68 #20-70, Pereira','3201234567','camila.morales@example.com'),(11,1011,11,'Sebastián','Gómez','Calle 50 #25-30, Villavicencio','3134567890','sebastian.gomez@example.com'),(12,1012,12,'Laura','Castro','Carrera 90 #12-34, Santa Marta','3195678902','laura.castro@example.com'),(13,1013,13,'Mateo','Jiménez','Avenida 40 #33-45, Pasto','3112345678','mateo.jimenez@example.com'),(14,1014,14,'Valentina','Salazar','Calle 10 #50-60, Montería','3154567890','valentina.salazar@example.com'),(15,1015,15,'Tomás','Álvarez','Carrera 77 #88-99, Popayán','123456','tomas.alvarez@example.com'),(16,9874563,4,'Pepe','Aguilar',NULL,'96325874','Pepe@example.com');
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-09-25 12:03:31
