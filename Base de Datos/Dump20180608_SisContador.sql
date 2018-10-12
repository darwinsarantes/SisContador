CREATE DATABASE  IF NOT EXISTS `siscontador` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `siscontador`;
-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: localhost    Database: siscontador
-- ------------------------------------------------------
-- Server version	5.7.21

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
-- Table structure for table `categoriadecuenta`
--

DROP TABLE IF EXISTS `categoriadecuenta`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `categoriadecuenta` (
  `idCategoriaDeCuenta` int(11) NOT NULL,
  `DescCategoriaDeCuenta` varchar(500) DEFAULT NULL,
  `IdUsuarioDeCreacion` int(11) NOT NULL,
  `FechaDeCreacion` datetime NOT NULL,
  `IdUsuarioDeModificacion` int(11) DEFAULT NULL,
  `FechaDeModificacion` datetime DEFAULT NULL,
  `idGrupoDeCuentas` int(11) NOT NULL,
  PRIMARY KEY (`idCategoriaDeCuenta`,`idGrupoDeCuentas`),
  KEY `fk_CategoriaDeCuenta_GrupoDeCuentas1_idx` (`idGrupoDeCuentas`),
  CONSTRAINT `fk_CategoriaDeCuenta_GrupoDeCuentas1` FOREIGN KEY (`idGrupoDeCuentas`) REFERENCES `grupodecuentas` (`idGrupoDeCuentas`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categoriadecuenta`
--

LOCK TABLES `categoriadecuenta` WRITE;
/*!40000 ALTER TABLE `categoriadecuenta` DISABLE KEYS */;
INSERT INTO `categoriadecuenta` VALUES (1,'Activo Circulante',1,'2018-05-11 10:57:25',1,'2018-05-11 10:57:25',1),(2,'Activo Fijo',1,'2018-05-11 11:06:23',1,'2018-05-11 11:06:23',1),(3,'Acivo Diferido',1,'2018-05-11 11:07:20',1,'2018-05-11 11:18:31',1),(4,'Pasivo Circulante',1,'2018-05-11 11:26:21',1,'2018-05-11 11:26:21',2),(5,'Pasivo Fijo',1,'2018-05-11 11:29:37',1,'2018-05-11 11:29:37',2),(6,'Pasivo Diferido',1,'2018-05-11 11:41:34',1,'2018-05-11 11:41:34',2),(7,'Otros Pasivos',1,'2018-05-11 11:41:47',1,'2018-05-11 11:41:47',2),(8,'Capital',1,'2018-05-11 11:43:53',1,'2018-05-11 11:43:53',3),(9,'Ingresos',1,'2018-05-11 11:44:24',1,'2018-05-11 11:44:24',4),(10,'Otros Ingresos',1,'2018-05-11 11:46:15',1,'2018-05-11 11:46:15',4),(11,'Egresos',1,'2018-05-11 11:46:24',1,'2018-05-11 11:46:24',4),(12,'Otros Egresos',1,'2018-05-11 11:46:44',1,'2018-05-11 11:46:44',4);
/*!40000 ALTER TABLE `categoriadecuenta` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cierredeperiodo`
--

DROP TABLE IF EXISTS `cierredeperiodo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cierredeperiodo` (
  `idCierreDePeriodo` int(11) NOT NULL AUTO_INCREMENT,
  `idPeriodo` int(11) NOT NULL,
  `idUsuarioDeCierre` int(11) DEFAULT NULL,
  `FechaDeCierre` datetime DEFAULT NULL,
  `Descripcion` varchar(5000) DEFAULT NULL,
  PRIMARY KEY (`idCierreDePeriodo`,`idPeriodo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cierredeperiodo`
--

LOCK TABLES `cierredeperiodo` WRITE;
/*!40000 ALTER TABLE `cierredeperiodo` DISABLE KEYS */;
/*!40000 ALTER TABLE `cierredeperiodo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `configuracion`
--

DROP TABLE IF EXISTS `configuracion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `configuracion` (
  `IdConfiguracion` int(11) NOT NULL AUTO_INCREMENT,
  `RutaRespaldos` varchar(500) NOT NULL,
  `RutaRespaldosDeExcel` varchar(500) NOT NULL,
  `NivelesDeLaCuenta` int(11) NOT NULL DEFAULT '0',
  `PathMysSQLDump` varchar(5000) DEFAULT NULL,
  `PathMySQL` varchar(5000) DEFAULT NULL,
  `CuentaPrincipalDeBanco` varchar(45) DEFAULT '0',
  PRIMARY KEY (`IdConfiguracion`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `configuracion`
--

LOCK TABLES `configuracion` WRITE;
/*!40000 ALTER TABLE `configuracion` DISABLE KEYS */;
INSERT INTO `configuracion` VALUES (1,'D:\\dbpruebas','D:\\dbpruebas',3,'C:\\wamp64\\bin\\mysql\\mysql5.7.21\\bin\\','C:\\wamp64\\bin\\mysql\\mysql5.7.21\\bin\\','101');
/*!40000 ALTER TABLE `configuracion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cuenta`
--

DROP TABLE IF EXISTS `cuenta`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cuenta` (
  `idCuenta` varchar(18) NOT NULL,
  `DescCuenta` varchar(500) DEFAULT NULL,
  `SaldoCuenta` decimal(18,2) DEFAULT NULL,
  `NivelCuenta` int(11) DEFAULT NULL,
  `CuentaMadre` varchar(18) DEFAULT NULL,
  `IdUsuarioDeCreacion` int(11) NOT NULL,
  `FechaDeCreacion` datetime NOT NULL,
  `IdUsuarioDeModificacion` int(11) DEFAULT NULL,
  `FechaDeModificacion` datetime DEFAULT NULL,
  `idCategoriaDeCuenta` int(11) NOT NULL,
  `idTipoDeCuenta` int(11) NOT NULL,
  `NoCuenta` int(11) NOT NULL,
  PRIMARY KEY (`idCategoriaDeCuenta`,`idTipoDeCuenta`,`NoCuenta`),
  KEY `fk_Cuenta_CategoriaDeCuenta1_idx` (`idCategoriaDeCuenta`),
  KEY `fk_Cuenta_TipoDeCuenta1_idx` (`idTipoDeCuenta`),
  CONSTRAINT `fk_Cuenta_CategoriaDeCuenta1` FOREIGN KEY (`idCategoriaDeCuenta`) REFERENCES `categoriadecuenta` (`idCategoriaDeCuenta`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Cuenta_TipoDeCuenta1` FOREIGN KEY (`idTipoDeCuenta`) REFERENCES `tipodecuenta` (`idTipoDeCuenta`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cuenta`
--

LOCK TABLES `cuenta` WRITE;
/*!40000 ALTER TABLE `cuenta` DISABLE KEYS */;
INSERT INTO `cuenta` VALUES ('100','Caja',0.00,1,'0',1,'2018-05-15 16:31:06',1,'2018-05-15 16:31:06',1,1,1),('101','BANCO',0.00,1,'0',1,'2018-05-15 16:55:20',1,'2018-05-15 16:55:20',1,1,5),('110','INVENTARIO',0.00,1,'0',1,'2018-05-16 08:50:44',1,'2018-05-16 08:50:44',1,1,8),('120','CUENTAS POR COBRAR - CLIENTES',0.00,1,'0',1,'2018-05-17 09:52:16',1,'2018-05-17 09:52:16',1,1,9),('125','CUENTAS POR COBRAR DIVERSAS',0.00,1,'0',1,'2018-05-17 14:43:08',1,'2018-05-17 14:43:08',1,1,31),('130','DEUDORES VARIOS',0.00,1,'0',1,'2018-05-17 15:35:34',1,'2018-05-17 15:35:34',1,1,39),('100-00','CAJA PRINCIPAL',0.00,2,'1',1,'2018-05-15 16:49:15',1,'2018-05-15 16:49:15',1,2,2),('100-01','CAJA CHICA',0.00,2,'1',1,'2018-05-15 16:51:33',1,'2018-05-15 16:51:33',1,2,3),('100-02','CAJA CHICA GENERAL',0.00,2,'2',1,'2018-05-15 16:54:01',1,'2018-05-15 16:54:01',1,2,4),('101-00','BAC 00903094-1',0.00,2,'5',1,'2018-05-15 16:56:29',1,'2018-05-15 16:56:29',1,2,6),('101-01','BANPRO CTA. #1001-120-372707-3',0.00,2,'5',1,'2018-05-15 16:57:42',1,'2018-05-15 16:57:42',1,2,7),('120-00','ALBA YERANIA LORENTE FIALLOS',0.00,2,'9',1,'2018-05-17 11:35:06',1,'2018-05-17 11:35:06',1,2,10),('120-01','TEODORO LORENTE MORAN',0.00,2,'9',1,'2018-05-17 11:36:38',1,'2018-05-17 11:36:38',1,2,11),('120-02','CREDOMATIC',0.00,2,'9',1,'2018-05-17 11:37:11',1,'2018-05-17 11:37:11',1,2,12),('120-04','CHEQUES SIN FONDOS',0.00,2,'9',1,'2018-05-17 11:48:04',1,'2018-05-17 11:48:04',1,2,13),('120-05','CHEQUES POST-DATADOS',0.00,2,'9',1,'2018-05-17 11:49:06',1,'2018-05-17 11:49:06',1,2,14),('101-02','BANIC',0.00,2,'5',1,'2018-05-17 14:05:51',1,'2018-05-17 14:05:51',1,2,15),('110-00','SERVICIOS DE PISTA',0.00,2,'8',1,'2018-05-17 14:06:28',1,'2018-05-17 14:06:28',1,2,16),('110-01','SALA DE VENTAS',0.00,2,'8',1,'2018-05-17 14:07:04',1,'2018-05-17 14:07:04',1,2,17),('110-02','ENGRASES',0.00,2,'8',1,'2018-05-17 14:07:23',1,'2018-05-17 14:07:23',1,2,18),('110-03','COMBUSTIBLE',0.00,2,'8',1,'2018-05-17 14:08:03',1,'2018-05-17 14:08:03',1,2,19),('110-04','BODEGA',0.00,2,'8',1,'2018-05-17 14:08:19',1,'2018-05-17 14:08:19',1,2,20),('110-05','COMBUSTIBLE EN DEPOSITOS',0.00,2,'8',1,'2018-05-17 14:08:51',1,'2018-05-17 14:08:51',1,2,21),('120-03','EMPRESA PRIVADA',0.00,2,'9',1,'2018-05-17 14:09:26',1,'2018-05-17 14:09:26',1,2,22),('120-06','EVILING SOZA',0.00,2,'9',1,'2018-05-17 14:10:26',1,'2018-05-17 14:10:26',1,2,23),('120-07','EDY TEODORO LORENTE FIALLOS',0.00,2,'9',1,'2018-05-17 14:10:49',1,'2018-05-17 14:10:49',1,2,24),('120-08','TANIA CRUZ PERALTA TIENDA',0.00,2,'9',1,'2018-05-17 14:14:21',1,'2018-05-17 14:14:21',1,2,25),('120-09','RAMON IGNACIO CASTILLO',0.00,2,'9',1,'2018-05-17 14:18:19',1,'2018-05-17 14:18:19',1,2,26),('120-10','ALBA NIDYA FIALLOS GALEANO',0.00,2,'9',1,'2018-05-17 14:18:54',1,'2018-05-17 14:18:54',1,2,27),('120-11','LA QUINTA SAN JOSE',0.00,2,'9',1,'2018-05-17 14:25:17',1,'2018-05-17 14:25:17',1,2,28),('120-12','TRANSPORTISTAS',0.00,2,'9',1,'2018-05-17 14:41:37',1,'2018-05-17 14:41:37',1,2,29),('120-13','OTROS',0.00,2,'9',1,'2018-05-17 14:42:29',1,'2018-05-17 14:42:29',1,2,30),('125-00','CLIENTES',0.00,2,'31',1,'2018-05-17 14:43:37',1,'2018-05-17 14:43:37',1,2,32),('125-00-01','EDY TEODORO LORENTE FIALLOS',0.00,3,'32',1,'2018-05-17 14:44:12',1,'2018-05-17 14:44:12',1,2,33),('125-00-02','ALBA NIDIA FIALLOS GALEANO',0.00,3,'32',1,'2018-05-17 14:44:36',1,'2018-05-17 14:44:36',1,2,34),('125-00-03','TEODORO LORENTE MORAN',0.00,3,'32',1,'2018-05-17 14:45:01',1,'2018-05-17 14:45:01',1,2,35),('125-00-04','QUINTA SAN JOSE LORENTE',0.00,3,'32',1,'2018-05-17 14:46:02',1,'2018-05-17 14:46:02',1,2,36),('125-00-00','LESLY WISTON MAYORGA',0.00,3,'32',1,'2018-05-17 15:33:38',1,'2018-05-17 15:33:38',1,2,37),('125-02','ALBA YERANIA LORENTE FIALLOS',0.00,2,'31',1,'2018-05-17 15:35:02',1,'2018-05-17 15:35:02',1,2,38),('130-00','FALTANTESDE EFECTIVO',0.00,2,'39',1,'2018-05-17 15:35:52',1,'2018-05-17 15:35:52',1,2,40),('130-00-00','RAMON IGNACIO CASTILLO RIZO',0.00,3,'40',1,'2018-05-17 15:37:14',1,'2018-05-17 15:37:14',1,2,41),('130-00-01','EVELING SOZA TIENDA',0.00,3,'40',1,'2018-05-17 15:37:57',1,'2018-05-17 15:37:57',1,2,42),('130-00-02','JUAN PABLO HERNANDEZ',0.00,3,'40',1,'2018-05-17 15:39:06',1,'2018-05-17 15:39:06',1,2,43),('130-00-03','CARMEN MERCADO CH',0.00,3,'40',1,'2018-05-17 15:39:52',1,'2018-05-17 15:39:52',1,2,44),('130-00-04','TANIA DEAYANIRA CRUZ PERALTA TIENDA',0.00,3,'40',1,'2018-05-17 15:40:53',1,'2018-05-17 15:40:53',1,2,45),('130-00-05','RAFAEL HERNANDEZ',0.00,3,'40',1,'2018-05-17 15:41:11',1,'2018-05-17 15:41:11',1,2,46),('130-00-06','DANILO RIOS MAIRENA',0.00,3,'40',1,'2018-05-17 15:41:34',1,'2018-05-17 15:41:34',1,2,47),('130-00-07','LUIS MANUEL LUNA',0.00,3,'40',1,'2018-05-17 15:42:23',1,'2018-05-17 15:49:00',1,2,48),('130-00-08','LUIS ALFONSO BAYER',0.00,3,'40',1,'2018-05-17 15:49:46',1,'2018-05-17 15:49:46',1,2,49),('130-00-09','HERMES BORJAS GALLEGO',0.00,3,'40',1,'2018-05-17 15:50:09',1,'2018-05-17 15:50:09',1,2,50),('130-00-10','AXEL SANCHEZ',0.00,3,'40',1,'2018-05-17 15:50:45',1,'2018-05-17 15:50:45',1,2,51),('130-00-11','OTROS',0.00,3,'40',1,'2018-05-17 15:51:02',1,'2018-05-17 15:51:02',1,2,52),('130-00-12','SANTOS CALDERON HERNANDEZ',0.00,3,'40',1,'2018-05-17 15:51:17',1,'2018-05-17 15:51:17',1,2,53),('130-00-13','NELSON RIZO CASTILLO',0.00,3,'40',1,'2018-05-17 15:52:48',1,'2018-05-17 15:52:48',1,2,54),('130-00-14','RAMON IGNACIO CASTILLO',0.00,3,'40',1,'2018-05-18 15:59:43',1,'2018-05-18 15:59:43',1,2,55),('130-00-15','MARIA ANTONIA GALEANO',0.00,3,'40',1,'2018-05-18 16:00:02',1,'2018-05-18 16:00:02',1,2,56),('130-00-16','CORTESIA',0.00,3,'40',1,'2018-05-18 16:00:23',1,'2018-05-18 16:00:23',1,2,57),('130-00-17','CUPONES ESTATALES',0.00,3,'40',1,'2018-05-18 16:01:07',1,'2018-05-18 16:01:07',1,2,58),('130-00-18','JOEL GARCIA ESCORCIA',0.00,3,'40',1,'2018-05-18 16:01:24',1,'2018-05-18 16:01:24',1,2,59),('130-00-20','JORGE CASTILLO',0.00,3,'40',1,'2018-05-18 16:02:13',1,'2018-05-18 16:02:13',1,2,60),('130-00-21','ISELA GAMEZ',0.00,3,'40',1,'2018-05-18 16:02:30',1,'2018-05-18 16:02:30',1,2,61),('130-01','FALTANTES DE ARTICULOS',0.00,2,'39',1,'2018-05-18 16:02:52',1,'2018-05-18 16:02:52',1,2,62),('130-01-00','SANTOS CALDERON H.',0.00,3,'62',1,'2018-05-18 16:03:15',1,'2018-05-18 16:03:15',1,2,63),('130-01-01','CARMEN MERCADO CHAVARIA',0.00,3,'62',1,'2018-05-18 16:03:40',1,'2018-05-18 16:03:40',1,2,64),('130-01-02','VALENTIN F. GLN DE ACITE GOLD 02/12/85',0.00,3,'62',1,'2018-05-18 16:04:13',1,'2018-05-18 16:04:13',1,2,65),('130-02','COMISARIATO',0.00,2,'39',1,'2018-05-18 16:05:00',1,'2018-05-18 16:05:00',1,2,66),('130-03','EMPLEADOS',0.00,2,'39',1,'2018-05-18 16:05:19',1,'2018-05-18 16:05:19',1,2,67),('130-04','PRESTAMOS AL PERSONA',0.00,2,'39',1,'2018-05-18 16:05:35',1,'2018-05-18 16:05:35',1,2,68),('130-04-00','HERMES BORJAS GALLEGO',0.00,3,'68',1,'2018-05-18 16:06:48',1,'2018-05-18 16:06:48',1,2,69),('130-04-01','SANTOS CALDERON H.',0.00,3,'68',1,'2018-05-18 16:07:28',1,'2018-05-18 16:07:28',1,2,70),('130-04-02','MARTHA SEVILLA',0.00,3,'68',1,'2018-05-24 16:38:34',1,'2018-05-24 16:38:34',1,2,71);
/*!40000 ALTER TABLE `cuenta` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `empresa`
--

DROP TABLE IF EXISTS `empresa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `empresa` (
  `IdEmpresa` int(11) NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(500) NOT NULL,
  `Direccion` varchar(5000) NOT NULL,
  `Telefonos` varchar(100) DEFAULT NULL,
  `NRuc` varchar(50) NOT NULL,
  `Logo` blob,
  `Celular` varchar(45) DEFAULT NULL,
  `Email` varchar(200) DEFAULT NULL,
  `SitioWeb` varchar(200) DEFAULT NULL,
  `Descripcion` varchar(2000) DEFAULT NULL,
  PRIMARY KEY (`IdEmpresa`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `empresa`
--

LOCK TABLES `empresa` WRITE;
/*!40000 ALTER TABLE `empresa` DISABLE KEYS */;
INSERT INTO `empresa` VALUES (1,'ESTACI√ìN DE SERVICIOS \r\nSHELL - ESQUIPULAS, ESTELI','Frente a Edificio de operaciones de la policia nacional, esteli, Nicaragua','27133908','','âPNG\r\n\Z\n\0\0\0\rIHDR\0\0\0\·\0\0\0\·\0\0\0	m\"H\0\0\0gAMA\0\0±è¸a\0\0PLTEˇˇˇ\Ót!<ß\Ÿ#/\Ìl\0¯Àµ\Ìnˆ∏ñ\04•\09¶\0;ß\Ìj\0ˇ˛ˇjÄ¡\Ìh\0D©\0)°\07•\Ìt!\0-¢\01£\0$†\Óq\◊\0\Ìe\0âG\0(°\0\"†\ÿ&\◊\0\‰sy\⁄.8˝Ú\Î∑\¬\‡ÒëW˝Ù\Ô˙\‡\—\ÿ \ÓÚ¯ÚöhpáƒÖò\Àˆ\”‘ò©\‘ÙÆã¸\Ë\›˚\Ï\Ï\‚\ÊÚ_yø\„ioπªÛür\¬\Õ\Â˜√®˙\‚„õ¨\÷/SÆ\ﬂU[\⁄\·ßµ\⁄\œ\ÿ\ÏËáå\’\0\0¯œªKi∏\0ú\‡_e\€7?\ﬁJQÛ\ƒ\∆ÍîòÓ™≠J´Äê\«Rnπ¯\Ÿ\€Èëî\„pv;]¥åû\Œ\ÔÄ6Û¶~\0\0òÒì]äNı≤èî\∆p˛\0\0©IDATx^\Ìõ\r[\⁄\ ÄWDLâ	\—⁄¶h\n•\n∂∂(`•ßµ€ä=≠ˇˇØ‹ô\›≤ıú\€c®>Û∂è\Ÿl\»\Ï|\ÓB\√0\√0\√0\√0\√0\√0\√0\√0\√0\√0\√0\√0\√0\√0\√0\√0Ií£\„c¶\’\ÔçÛÉ°Èπûk/Û\„†KW\·QsPtm\◊33õJ¡\”1<\€Nµ{!\ry\»tõóN\Ÿs≤ Wú¨a\Ì>ç{†ÙG√≤\Îê@ä,AßF\È¨ıÅ∫i´1,¶$ãÜ\È∫v\…ˆ\”ÃöÜW.€ÆaÇ§NyL/x`ÉíG\‚9ûk\≈AΩ\Ÿ;\Í∂Z°§\’\Íù\—e\ƒ\Ã⁄ó\œ\√f™,ç\”4\\\€4z›õd\Ëˆ\⁄ÉÜL\ƒpTv1f:n≈®˜\ÓN\n¡≈á\‚CÚ\ƒpTÒdú,∑{-ÍªãV˛íZ>a£\ÏÅx•l˝\Ë´vJ\÷\Ë8hƒ£Û\«Fˇ\ÿ5=˚\"x¨Uhò/vq¨|\Ô1\ndm˚Ú—™tñˇP∫x\‡5\Ê˛ö\Œ\Ÿ\Ÿ\Ó3∫h~h´\ƒJ¨\—\≈lêg\‘\'Ÿï]˙`	º≥ºî4\Î[i\À*Æ~H	\∆c˝<\·,:≤ÇzÀ¢^`\Î≠\Ï\“Va\Î\ÍGÚR˛»¨\ƒ\ÿXYÒ3\È≠\'gÉKm}∞ÆçLœî¯¨@}à•D\–~¶pï¥åO|˙¯8~z\„å\∆(Ùπ\»\\S∑ªı!%˘õoS¯[Ø\‰àƒêü∫øÜIbs±A\›B¨•©I´æ\'∞~$ôvûE\Ôné\Ã\ZÜ\ƒF¶◊®_SÆOØ∏ım\ WìA≥∞y2øh\\\Ã€Äâ,B¸å\Ë\ÀWjèéë©\…Qâˆ\÷\…^\ŸHOù&>SÑ∏äHòYó]wM\‹zrf˙jQÃãRÿßëss\·OFÙÇ•¢\”7\”ˇ˝Û¸ñà Ò\“\»˘π∞T\ÿ‹è\Í\ÀRuMB7T ù`%g¶Ùâ∑∞Eâ/\Ím\nJgZ≤ê]˙`\ﬂ*XiüíÖ¢êXR¨\È\÷\‰˚Û*\ÕP\‡”ï QôAK\ÓîC¢É˝˚˚ªkœµO\"cN\0\Õ\¬V6^<ø*X1!\'\Ó∂ vX2aDì;\Ÿt-\ZJiä\ﬁD\'\"9	5ì≤\‘÷Æbß‘≤ª ˛´ÄÒ+\"aFÖ^-îí4z_bV™YE˙x©™\\\ÎlQtî\ÓtE\'Hö\Í\Ó\Ë`™\„4	©/¥ÚqZ•\Ë%WA∆ΩÖ•4\Ê˜\Zµ%§õ\Î\Ë`™\„¥yõï|˜M4Y\œRüVh\“|øÒÑ\ZLµËùìn^D]S\Â>MÖ\”tˇh\Œ5≠•ÙöK\Èpq)\rÜ≠ÖcKæ^åz\Œ\Ìæ\“CibÖ\È~TˇäzE-:\ﬂ\‰áQMEr Ü&\·¥\Ó÷≤E&]∞tO\Œ\ru\”yÆ:s1f∞3⁄ïYü∑µñãHòÅu†MúD∑çÙmtj\Èˆ\0]pX^‰¥¥íy;sT\–Z\‰=(\Zk9hSáø¥¯FëX x¥R¯\ÃL≠]j i™ª£Øüg∂^π¢\…:íÖµr\\\Âê\Ë\\ÄÑët5@™ªma\ÃHra°Öè\…R!f§™Úé\n\rﬁ∞5@©Oõ∏8˛FÇ\À_≠|úea-1PÑç.XéjU\ÊÑI4^î9\'§ü$( ‘öë{¡à\"˘©›ºÚN-†9\Î%;AE˙≥õM&MïaBhµ\Ì∞\Ï\∆\nÔ¥úrΩ®Do[¥t^∏Ö+2E&c≠\\\'ñ⁄≤=s˝lw˝IAøsJ!\⁄\\la¨5\ÊåQ≠¶Ù-ˇ	Ò¸\«\€\ƒS¢\Â#SÄ\“#¶_©P/•WdóV\“*(îjGu‹íXpì1&§∂a®ºM/\œ%eÉQN45\ÃssD 2T\»\ÈÜ¥üOß(\ZkÉßÖ\“2ò/cLSW-™\Ï\…2rn\≈\—wAµ\Â\‘dUΩ\Ó*˝Ã§~\‘\ÊbR˚\ƒv±@öWRB}w1±\rôE,\\∂\œ˝iÅ¨\Õ\≈Ù{µ\ÿn«§∞\’îÇœíXXóL\…\\\Õró6>u\ŒY9)WLu‹í∏≠|‘øY\”6g_\÷\ƒ6âIπ\⁄\∆tUΩn–∑Ùoj£ï*m\"±\∆°t˙\›\∆R∏\È0?≥ı+¢’ã\‹\‡\Õ5\ÎMà*ZB•‘ß\ÌΩ-9îne\ÊH[ñı|=^<\ÓGGnÅvC\√5\\Ø%÷¢,e\◊˙\‡\…\ÂRÿΩ^üc\ÌlQ\Ï{y\r9Ú\¬H•R\∆\0¢JÑke\ÿ˚\⁄\‡¯d=w¶©¨Mgèë¢î–°≥?ùˇusÆóÚ@\¬Rì\ŒˇtrΩ\'eø^.ˆ^\ŸQ«üOp|˜o∂\'ÙG\√^\Za\Î!˝JΩ˛˜è∏(áA=U™xq€ú\Í?bˇ\“Ú\’\‹\‰Ut§^˝Ùˇ\‰¢T6oUd+W\\∑lv~ÎÉñGæ\‰x%\'\ﬂ\Îœõ^´\ﬂk\Ïä\Ì9^ePß¢ûWå:¯\‚êŒÄf´M-D–±ﬁò=ÒçzΩ®ÛÉ√ùùù\√w\–˙ä≠q˛˛~ósô{˝m\ÁÙÛ9¥sù\Œ\ÔLoœÖ\Ëh∏∂k_å\∆\Õfß\”èG\ÌÀî\Áñ]\œIô^©ÿà=Ñê´\nœ≠4`*&ßFπL€Ü;K‘Ñ˜Üª\Ï∂Òâ7<Ø\„=üøØV´õß\–˙≤]≠\Ó}ßx¯àÒyss\⁄\Ô_\¬|vÇ˛\Ô∑∞nÀß}≤¶\„!.¸Û\‘SwY\«-\rGÛû\⁄/\√x¢\“ÅM\Ìîå1õ(ºQz∆°å\ÀX!Y˘XÕóΩU†\nµ\“)¥™;\‚∞\náC!\ﬁ}\‹\ƒ+´´õ\ÔDø\ﬂ8\nÇ˙§\«B\¬Òq…ù<≤é@\\∑î∫\Ë,Ù\—¿\≈!ÜzL®(:\Íf\ÁC´={∞\Õ\Ìı\‰Gv9ó†å∂J?î§¯\"§h{_\ƒ\'<úäÉU8*j¢4É\Ó\ÔIt;\Ì°Q*ª\€.\√¡®◊Ω\…¯®®l˛BNJE\‰e≠:j\0a±¨Ùõµ\Ìê;Ò∑¸\0E4á¢#t\\€ììXÍãø§ U0Àßp\‹<œ°ƒõØ•†´\’\Õ\Ìmi±çûh˛\'è√Ö≠£†\◊\ÎÙz¡Q+º’≥QQ\Ê1JZó(AI]\né∫E8\À˚GÅ∏Ñ)\0˘î\Èq(e˜¡QC\Í\÷kHπÄ\Ìó\‚=\ﬁm\√aÛ\Âk<T?û|=¸Ñoz\‘I˙Åñc∏s\'/*\«,\Ê§]gá≈¢#o§gò†\\p.D\›—®\À˘\ÍxA6ç∂@IPò\Ô9î∞ö;G\Ô\€>¯à*|*\'˘ˇ$NUê=n\—:ΩQ(5q…¨†≥tQU≤∞Q≤\ÏR^ØÙq^≤¶ºo9\∆\»E	Qè{_Q¥O*ÚTï&I∂[çÈæê˜±H™ÆM\"f6ÖYNû∫PÚ\nJ≥&\\0*\Õz!hëWº&™¨z\nNW\›≠Aïá©I¢\ÀCÖRâQ9¢PjW*pM≤¿2⁄´\n•à1\ÍäPZØzh\ÔBznˇ3®l\ÔÙ5 âä¸&N\‡®:0\ﬁ\09⁄òN)ÉY.ï*vÏ≤é\∆\ÍˆÒQYº*#´Çy…êõ¬ÄkÄ—Ü2í∫ê˘\√:ä°\Í;\nÙYÄ<\»$-ˆ≥\‘\·\Í\ﬁy\Ì\‡ı\«\ÂH\ÿ≤\√n∑€íN\"C©\—\0<ó\Ó&!\≈@î=ñPÅ≤AéKπ©°Å=)\–>&ê\ÎõÃäQk\ §Ñ´õ’Ω\Ì¸Ä\‰¡$\0ÅpÇ•)»£eF\ @•1™P\n¯!\ƒ÷û\ ˜&ñK`£cëC€ÑLAm\◊^¢Ñ\€_≈°-\ﬂ\'qBºEHfDKn\› 2E¥PsÇt<áf*≥mOF¶ú2,\≈P†˜`áh≠Äê¯>7+iî3&N´j∞ßãç~\Ÿ$dÆ;*AΩMÙ±e˜D\›Àö¶ÅZm\ÿ.º¶\„ñXÏûÉÑ\’UhH\›UOF\Ÿqi\ n®ªø\¬IÚN±X4¶ıxœÑSââ)¢Éß2ı\ÀqN_Ù\rºh`W´y1L\rcUÌæÆ>}∫˙∂NûB\ÎTÆ\¬\Ín\‡¸Ù\‰\‰\€rT¯ﬂ≥î§~\ﬂ<J°ÜaÜaÜaÜaÜaÜaÜaÜaÜaÜaÜaÜaÜaÜaÜa\Êè@àˇ^û+A\”>%§\0\0\0\0IENDÆB`Ç','84025008','serviciostrigger@gmail.com','','Servicios profecionales, en desarrollo web, analisis y dise√±o de sistemas, mantenimiento de equipos, reparacion, y ventas de equipos computaciones..');
/*!40000 ALTER TABLE `empresa` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `grupodecuentas`
--

DROP TABLE IF EXISTS `grupodecuentas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `grupodecuentas` (
  `idGrupoDeCuentas` int(11) NOT NULL,
  `DescGrupoDeCuentas` varchar(200) DEFAULT NULL,
  `Debitos` varchar(5) DEFAULT NULL,
  `Creditos` varchar(5) DEFAULT NULL,
  `IdUsuarioDeCreacion` int(11) NOT NULL,
  `FechaDeCreacion` datetime NOT NULL,
  `IdUsuarioDeModificacion` int(11) DEFAULT NULL,
  `FechaDeModificacion` datetime DEFAULT NULL,
  PRIMARY KEY (`idGrupoDeCuentas`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `grupodecuentas`
--

LOCK TABLES `grupodecuentas` WRITE;
/*!40000 ALTER TABLE `grupodecuentas` DISABLE KEYS */;
INSERT INTO `grupodecuentas` VALUES (1,'Activos','+','-',1,'2018-05-10 14:53:46',1,'2018-05-24 16:32:03'),(2,'Pasivos','-','+',1,'2018-05-10 15:00:07',1,'2018-05-24 16:32:23'),(3,'Capital','-','+',1,'2018-05-10 15:00:59',1,'2018-05-24 16:32:41'),(4,'Cuentas de Resultado (Ingresos)','-','+',1,'2018-05-10 15:07:17',1,'2018-05-24 16:33:02'),(5,'Egresos','+','-',1,'2018-05-10 16:30:33',1,'2018-05-24 16:33:19');
/*!40000 ALTER TABLE `grupodecuentas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `interfaz`
--

DROP TABLE IF EXISTS `interfaz`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `interfaz` (
  `idInterfaz` int(11) NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(200) NOT NULL,
  `NombreAMostrar` varchar(200) NOT NULL,
  `NombreDelControl` varchar(200) NOT NULL,
  `IdUsuarioDeCreacion` int(11) NOT NULL,
  `FechaDeCreacion` datetime NOT NULL,
  `IdUsuarioDeModificacion` int(11) DEFAULT NULL,
  `FechaDeModificacion` datetime DEFAULT NULL,
  PRIMARY KEY (`idInterfaz`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `interfaz`
--

LOCK TABLES `interfaz` WRITE;
/*!40000 ALTER TABLE `interfaz` DISABLE KEYS */;
INSERT INTO `interfaz` VALUES (1,'Usuario','Informaci√≥n de la interfaz','usuario',1,'2018-05-03 14:27:13',1,'2018-05-03 14:27:13'),(2,'Rol','Informaci√≥n de los tipos de cuentas','rol',1,'2018-05-03 14:27:13',1,'2018-05-03 14:27:13'),(3,'Configuracion','Informaci√≥n de las configuraciones generales','configuracion',1,'2018-05-03 14:27:13',1,'2018-05-03 14:27:13'),(4,'Empresa','Informaci√≥n de los datos generales de la empresas','empresa',1,'2018-05-03 14:27:13',1,'2018-05-03 14:27:13'),(5,'Respaldar','Informaci√≥n de respaldo de datos del sistema','respaldo',1,'2018-05-03 14:27:13',1,'2018-05-03 14:27:13'),(6,'Restaurar','Informaci√≥n de restauracion de datos del sistema','restaurar',1,'2018-05-03 14:27:13',1,'2018-05-03 14:27:13'),(7,'GrupoDecuentas','Administrar la clasificacion de cuentas','grupodecuentas',1,'2018-05-09 11:59:08',1,'2018-05-09 11:59:08'),(8,'CategoriaDeCuentas','Administrar la informacion de la categoria de las cuentas','categoriadecuenta',1,'2018-05-11 10:08:53',1,'2018-05-11 10:08:53'),(9,'Cuentas','Administraci√≥n y clasificaci√≥n de las cuentas contables','cuentas',1,'2018-05-15 09:44:15',1,'2018-05-15 09:44:15'),(10,'TipoDeTransaccion','Administrar los tipos de transacciones','tipodetransaccion',1,'2018-05-24 15:21:14',1,'2018-05-24 15:21:14'),(11,'Transacciones','Administrar las transacciones de las diferentes cuentas','transacciones',1,'2018-05-25 11:58:58',1,'2018-05-25 11:58:58');
/*!40000 ALTER TABLE `interfaz` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `modulo`
--

DROP TABLE IF EXISTS `modulo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `modulo` (
  `idModulo` int(11) NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(200) NOT NULL,
  `IdUsuarioDeCreacion` int(11) NOT NULL,
  `FechaDeCreacion` datetime NOT NULL,
  `IdUsuarioDeModificacion` int(11) DEFAULT NULL,
  `FechaDeModificacion` datetime DEFAULT NULL,
  PRIMARY KEY (`idModulo`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `modulo`
--

LOCK TABLES `modulo` WRITE;
/*!40000 ALTER TABLE `modulo` DISABLE KEYS */;
INSERT INTO `modulo` VALUES (1,'General',1,'2018-05-03 14:27:13',1,'2018-05-03 14:27:13'),(2,'Cuentas',1,'2018-05-09 11:56:52',1,'2018-05-09 11:56:52'),(3,'Transacciones',1,'2018-05-24 15:19:24',1,'2018-05-24 15:19:24');
/*!40000 ALTER TABLE `modulo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `modulointerfaz`
--

DROP TABLE IF EXISTS `modulointerfaz`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `modulointerfaz` (
  `idModuloInterfaz` int(11) NOT NULL AUTO_INCREMENT,
  `idModulo` int(11) NOT NULL,
  `idInterfaz` int(11) NOT NULL,
  `IdUsuarioDeCreacion` int(11) NOT NULL,
  `FechaDeCreacion` datetime NOT NULL,
  `IdUsuarioDeModificacion` int(11) DEFAULT NULL,
  `FechaDeModificacion` datetime DEFAULT NULL,
  PRIMARY KEY (`idModuloInterfaz`,`idModulo`,`idInterfaz`),
  KEY `fk_ModuloInterfaz_Modulo_idx` (`idModulo`),
  KEY `fk_ModuloInterfaz_Interfaz1_idx` (`idInterfaz`),
  CONSTRAINT `fk_ModuloInterfaz_Interfaz1` FOREIGN KEY (`idInterfaz`) REFERENCES `interfaz` (`idInterfaz`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_ModuloInterfaz_Modulo` FOREIGN KEY (`idModulo`) REFERENCES `modulo` (`idModulo`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `modulointerfaz`
--

LOCK TABLES `modulointerfaz` WRITE;
/*!40000 ALTER TABLE `modulointerfaz` DISABLE KEYS */;
INSERT INTO `modulointerfaz` VALUES (1,1,1,1,'2018-05-03 14:46:13',1,'2018-05-03 14:46:13'),(2,1,2,1,'2018-05-03 15:06:44',1,'2018-05-03 15:06:44'),(3,1,3,1,'2018-05-03 15:09:13',1,'2018-05-03 15:09:13'),(4,1,4,1,'2018-05-03 15:11:21',1,'2018-05-03 15:11:21'),(5,1,5,1,'2018-05-03 15:13:53',1,'2018-05-03 15:13:53'),(6,1,6,1,'2018-05-03 15:15:18',1,'2018-05-03 15:15:18'),(7,2,7,1,'2018-05-09 12:00:29',1,'2018-05-09 12:00:29'),(8,2,8,1,'2018-05-11 10:09:45',1,'2018-05-11 10:09:45'),(9,2,9,1,'2018-05-15 09:45:04',1,'2018-05-15 09:45:04'),(10,3,10,1,'2018-05-24 15:21:57',1,'2018-05-24 15:21:57'),(11,3,11,1,'2018-05-25 11:59:25',1,'2018-05-25 11:59:25');
/*!40000 ALTER TABLE `modulointerfaz` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `modulointerfazrol`
--

DROP TABLE IF EXISTS `modulointerfazrol`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `modulointerfazrol` (
  `idModuloInterfazRol` int(11) NOT NULL AUTO_INCREMENT,
  `idPrivilegio` int(11) NOT NULL,
  `idRol` int(11) NOT NULL,
  `Acceso` int(11) DEFAULT '0',
  `IdUsuarioDeCreacion` int(11) NOT NULL,
  `FechaDeCreacion` datetime NOT NULL,
  `IdUsuarioDeModificacion` int(11) DEFAULT NULL,
  `FechaDeModificacion` datetime DEFAULT NULL,
  PRIMARY KEY (`idModuloInterfazRol`,`idPrivilegio`,`idRol`),
  KEY `fk_ModuloInterfazRol_Privilegio1_idx` (`idPrivilegio`),
  KEY `fk_ModuloInterfazRol_Rol1_idx` (`idRol`),
  CONSTRAINT `fk_ModuloInterfazRol_Privilegio1` FOREIGN KEY (`idPrivilegio`) REFERENCES `privilegio` (`idPrivilegio`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_ModuloInterfazRol_Rol1` FOREIGN KEY (`idRol`) REFERENCES `rol` (`idRol`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=95 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `modulointerfazrol`
--

LOCK TABLES `modulointerfazrol` WRITE;
/*!40000 ALTER TABLE `modulointerfazrol` DISABLE KEYS */;
INSERT INTO `modulointerfazrol` VALUES (1,1,1,1,1,'2018-05-03 15:03:37',1,'2018-05-03 15:03:37'),(2,2,1,1,1,'2018-05-03 15:03:37',1,'2018-05-03 15:03:37'),(3,3,1,1,1,'2018-05-03 15:03:37',1,'2018-05-03 15:03:37'),(4,4,1,1,1,'2018-05-03 15:03:37',1,'2018-05-03 15:03:37'),(5,5,1,1,1,'2018-05-03 15:03:37',1,'2018-05-03 15:03:37'),(6,6,1,1,1,'2018-05-03 15:03:37',1,'2018-05-03 15:03:37'),(7,7,1,1,1,'2018-05-03 15:03:37',1,'2018-05-03 15:03:37'),(8,8,1,1,1,'2018-05-03 15:03:37',1,'2018-05-03 15:03:37'),(16,9,1,1,1,'2018-05-03 15:06:44',1,'2018-05-03 15:06:44'),(17,10,1,1,1,'2018-05-03 15:06:44',1,'2018-05-03 15:06:44'),(18,11,1,1,1,'2018-05-03 15:06:44',1,'2018-05-03 15:06:44'),(19,12,1,1,1,'2018-05-03 15:06:44',1,'2018-05-03 15:06:44'),(20,13,1,1,1,'2018-05-03 15:06:44',1,'2018-05-03 15:06:44'),(21,14,1,1,1,'2018-05-03 15:06:44',1,'2018-05-03 15:06:44'),(22,15,1,1,1,'2018-05-03 15:06:44',1,'2018-05-03 15:06:44'),(23,16,1,1,1,'2018-05-03 15:06:44',1,'2018-05-03 15:06:44'),(31,17,1,1,1,'2018-05-03 15:09:13',1,'2018-05-03 15:09:13'),(32,18,1,1,1,'2018-05-03 15:09:13',1,'2018-05-03 15:09:13'),(34,19,1,1,1,'2018-05-03 15:11:21',1,'2018-05-03 15:11:21'),(35,20,1,1,1,'2018-05-03 15:11:21',1,'2018-05-03 15:11:21'),(37,21,1,1,1,'2018-05-03 15:13:53',1,'2018-05-03 15:13:53'),(38,22,1,1,1,'2018-05-03 15:13:53',1,'2018-05-03 15:13:53'),(40,23,1,1,1,'2018-05-03 15:15:18',1,'2018-05-03 15:15:18'),(41,24,1,1,1,'2018-05-03 15:15:18',1,'2018-05-03 15:15:18'),(42,25,1,1,1,'2018-05-09 12:00:29',1,'2018-05-09 12:00:29'),(43,26,1,1,1,'2018-05-09 12:00:29',1,'2018-05-09 12:00:29'),(44,27,1,1,1,'2018-05-09 12:00:29',1,'2018-05-09 12:00:29'),(45,28,1,1,1,'2018-05-09 12:00:29',1,'2018-05-09 12:00:29'),(46,29,1,1,1,'2018-05-09 12:00:29',1,'2018-05-09 12:00:29'),(47,30,1,1,1,'2018-05-09 12:00:29',1,'2018-05-09 12:00:29'),(48,31,1,1,1,'2018-05-11 10:09:45',1,'2018-05-11 10:09:45'),(49,32,1,1,1,'2018-05-11 10:09:45',1,'2018-05-11 10:09:45'),(50,33,1,1,1,'2018-05-11 10:09:45',1,'2018-05-11 10:09:45'),(51,34,1,1,1,'2018-05-11 10:09:45',1,'2018-05-11 10:09:45'),(52,35,1,1,1,'2018-05-11 10:09:45',1,'2018-05-11 10:09:45'),(53,36,1,1,1,'2018-05-11 10:09:45',1,'2018-05-11 10:09:45'),(54,37,1,1,1,'2018-05-15 09:45:04',1,'2018-05-15 09:45:04'),(55,38,1,1,1,'2018-05-15 09:45:04',1,'2018-05-15 09:45:04'),(56,39,1,1,1,'2018-05-15 09:45:04',1,'2018-05-15 09:45:04'),(57,40,1,1,1,'2018-05-15 09:45:04',1,'2018-05-15 09:45:04'),(58,41,1,1,1,'2018-05-15 09:45:04',1,'2018-05-15 09:45:04'),(59,42,1,1,1,'2018-05-15 09:45:04',1,'2018-05-15 09:45:04'),(60,21,2,1,1,'2018-05-23 09:11:48',1,'2018-05-23 09:11:48'),(61,22,2,1,1,'2018-05-23 09:11:48',1,'2018-05-23 09:11:48'),(62,37,2,1,1,'2018-05-23 09:25:09',1,'2018-05-23 09:25:09'),(63,38,2,1,1,'2018-05-23 09:25:09',1,'2018-05-23 09:25:09'),(64,39,2,1,1,'2018-05-23 09:25:09',1,'2018-05-23 09:25:09'),(65,40,2,1,1,'2018-05-23 09:25:09',1,'2018-05-23 09:25:09'),(66,41,2,1,1,'2018-05-23 09:25:09',1,'2018-05-23 09:25:09'),(67,42,2,1,1,'2018-05-23 09:25:09',1,'2018-05-23 09:25:09'),(68,43,1,1,1,'2018-05-24 15:21:57',1,'2018-05-24 15:21:57'),(69,43,2,0,1,'2018-05-24 15:21:57',1,'2018-05-24 15:21:57'),(70,44,1,1,1,'2018-05-24 15:21:57',1,'2018-05-24 15:21:57'),(71,44,2,0,1,'2018-05-24 15:21:57',1,'2018-05-24 15:21:57'),(72,45,1,1,1,'2018-05-24 15:21:57',1,'2018-05-24 15:21:57'),(73,45,2,0,1,'2018-05-24 15:21:57',1,'2018-05-24 15:21:57'),(74,46,1,1,1,'2018-05-24 15:21:57',1,'2018-05-24 15:21:57'),(75,46,2,0,1,'2018-05-24 15:21:57',1,'2018-05-24 15:21:57'),(76,47,1,1,1,'2018-05-24 15:21:57',1,'2018-05-24 15:21:57'),(77,47,2,0,1,'2018-05-24 15:21:57',1,'2018-05-24 15:21:57'),(78,48,1,1,1,'2018-05-24 15:21:57',1,'2018-05-24 15:21:57'),(79,48,2,0,1,'2018-05-24 15:21:57',1,'2018-05-24 15:21:57'),(83,49,1,1,1,'2018-05-25 11:59:25',1,'2018-05-25 11:59:25'),(84,49,2,0,1,'2018-05-25 11:59:25',1,'2018-05-25 11:59:25'),(85,50,1,1,1,'2018-05-25 11:59:25',1,'2018-05-25 11:59:25'),(86,50,2,0,1,'2018-05-25 11:59:25',1,'2018-05-25 11:59:25'),(87,51,1,1,1,'2018-05-25 11:59:25',1,'2018-05-25 11:59:25'),(88,51,2,0,1,'2018-05-25 11:59:25',1,'2018-05-25 11:59:25'),(89,52,1,1,1,'2018-05-25 11:59:25',1,'2018-05-25 11:59:25'),(90,52,2,0,1,'2018-05-25 11:59:25',1,'2018-05-25 11:59:25'),(91,53,1,1,1,'2018-05-25 11:59:25',1,'2018-05-25 11:59:25'),(92,53,2,0,1,'2018-05-25 11:59:25',1,'2018-05-25 11:59:25'),(93,54,1,1,1,'2018-05-25 11:59:25',1,'2018-05-25 11:59:25'),(94,54,2,0,1,'2018-05-25 11:59:25',1,'2018-05-25 11:59:25');
/*!40000 ALTER TABLE `modulointerfazrol` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `modulointerfazusuario`
--

DROP TABLE IF EXISTS `modulointerfazusuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `modulointerfazusuario` (
  `idModuloInterfazUsuario` int(11) NOT NULL AUTO_INCREMENT,
  `idPrivilegio` int(11) NOT NULL,
  `idUsuario` int(11) NOT NULL,
  `Acceso` int(11) NOT NULL DEFAULT '0',
  `IdUsuarioDeCreacion` int(11) NOT NULL,
  `FechaDeCreacion` datetime NOT NULL,
  `IdUsuarioDeModificacion` int(11) DEFAULT NULL,
  `FechaDeModificacion` datetime DEFAULT NULL,
  PRIMARY KEY (`idModuloInterfazUsuario`,`idPrivilegio`,`idUsuario`),
  KEY `fk_ModuloInterfazUsuario_Privilegio1_idx` (`idPrivilegio`),
  KEY `fk_ModuloInterfazUsuario_Usuario1_idx` (`idUsuario`),
  CONSTRAINT `fk_ModuloInterfazUsuario_Privilegio1` FOREIGN KEY (`idPrivilegio`) REFERENCES `privilegio` (`idPrivilegio`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_ModuloInterfazUsuario_Usuario1` FOREIGN KEY (`idUsuario`) REFERENCES `usuario` (`idUsuario`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=129 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `modulointerfazusuario`
--

LOCK TABLES `modulointerfazusuario` WRITE;
/*!40000 ALTER TABLE `modulointerfazusuario` DISABLE KEYS */;
INSERT INTO `modulointerfazusuario` VALUES (1,1,1,1,1,'2018-05-03 15:03:37',1,'2018-05-03 15:03:37'),(2,2,1,1,1,'2018-05-03 15:03:37',1,'2018-05-03 15:03:37'),(3,3,1,1,1,'2018-05-03 15:03:37',1,'2018-05-03 15:03:37'),(4,4,1,1,1,'2018-05-03 15:03:37',1,'2018-05-03 15:03:37'),(5,5,1,1,1,'2018-05-03 15:03:37',1,'2018-05-03 15:03:37'),(6,6,1,1,1,'2018-05-03 15:03:37',1,'2018-05-03 15:03:37'),(7,7,1,1,1,'2018-05-03 15:03:37',1,'2018-05-03 15:03:37'),(8,8,1,1,1,'2018-05-03 15:03:37',1,'2018-05-03 15:03:37'),(16,9,1,1,1,'2018-05-03 15:06:44',1,'2018-05-03 15:06:44'),(17,10,1,1,1,'2018-05-03 15:06:44',1,'2018-05-03 15:06:44'),(18,11,1,1,1,'2018-05-03 15:06:44',1,'2018-05-03 15:06:44'),(19,12,1,1,1,'2018-05-03 15:06:44',1,'2018-05-03 15:06:44'),(20,13,1,1,1,'2018-05-03 15:06:44',1,'2018-05-03 15:06:44'),(21,14,1,1,1,'2018-05-03 15:06:44',1,'2018-05-03 15:06:44'),(22,15,1,1,1,'2018-05-03 15:06:44',1,'2018-05-03 15:06:44'),(23,16,1,1,1,'2018-05-03 15:06:44',1,'2018-05-03 15:06:44'),(31,17,1,1,1,'2018-05-03 15:09:13',1,'2018-05-03 15:09:13'),(32,18,1,1,1,'2018-05-03 15:09:13',1,'2018-05-03 15:09:13'),(34,19,1,1,1,'2018-05-03 15:11:21',1,'2018-05-03 15:11:21'),(35,20,1,1,1,'2018-05-03 15:11:21',1,'2018-05-03 15:11:21'),(37,21,1,1,1,'2018-05-03 15:13:53',1,'2018-05-03 15:13:53'),(38,22,1,1,1,'2018-05-03 15:13:53',1,'2018-05-03 15:13:53'),(40,23,1,1,1,'2018-05-03 15:15:18',1,'2018-05-03 15:15:18'),(41,24,1,1,1,'2018-05-03 15:15:18',1,'2018-05-03 15:15:18'),(42,25,1,1,1,'2018-05-09 12:00:29',1,'2018-05-09 12:00:29'),(43,26,1,1,1,'2018-05-09 12:00:29',1,'2018-05-09 12:00:29'),(44,27,1,1,1,'2018-05-09 12:00:29',1,'2018-05-09 12:00:29'),(45,28,1,1,1,'2018-05-09 12:00:29',1,'2018-05-09 12:00:29'),(46,29,1,1,1,'2018-05-09 12:00:29',1,'2018-05-09 12:00:29'),(47,30,1,1,1,'2018-05-09 12:00:29',1,'2018-05-09 12:00:29'),(48,31,1,1,1,'2018-05-11 10:09:45',1,'2018-05-11 10:09:45'),(49,32,1,1,1,'2018-05-11 10:09:45',1,'2018-05-11 10:09:45'),(50,33,1,1,1,'2018-05-11 10:09:45',1,'2018-05-11 10:09:45'),(51,34,1,1,1,'2018-05-11 10:09:45',1,'2018-05-11 10:09:45'),(52,35,1,1,1,'2018-05-11 10:09:45',1,'2018-05-11 10:09:45'),(53,36,1,1,1,'2018-05-11 10:09:45',1,'2018-05-11 10:09:45'),(54,37,1,1,1,'2018-05-15 09:45:04',1,'2018-05-15 09:45:04'),(55,38,1,1,1,'2018-05-15 09:45:04',1,'2018-05-15 09:45:04'),(56,39,1,1,1,'2018-05-15 09:45:04',1,'2018-05-15 09:45:04'),(57,40,1,1,1,'2018-05-15 09:45:04',1,'2018-05-15 09:45:04'),(58,41,1,1,1,'2018-05-15 09:45:04',1,'2018-05-15 09:45:04'),(59,42,1,1,1,'2018-05-15 09:45:04',1,'2018-05-15 09:45:04'),(60,21,2,1,1,'2018-05-23 09:26:48',1,'2018-05-23 09:26:48'),(61,22,2,1,1,'2018-05-23 09:26:48',1,'2018-05-23 09:26:48'),(62,37,2,1,1,'2018-05-23 09:26:48',1,'2018-05-23 09:26:48'),(63,38,2,1,1,'2018-05-23 09:26:48',1,'2018-05-23 09:26:48'),(64,39,2,1,1,'2018-05-23 09:26:48',1,'2018-05-23 09:26:48'),(65,40,2,1,1,'2018-05-23 09:26:48',1,'2018-05-23 09:26:48'),(66,41,2,1,1,'2018-05-23 09:26:48',1,'2018-05-23 09:26:48'),(67,42,2,1,1,'2018-05-23 09:26:48',1,'2018-05-23 09:26:48'),(68,1,2,0,1,'2018-05-23 09:26:48',1,'2018-05-23 09:26:48'),(69,2,2,0,1,'2018-05-23 09:26:48',1,'2018-05-23 09:26:48'),(70,3,2,0,1,'2018-05-23 09:26:48',1,'2018-05-23 09:26:48'),(71,4,2,0,1,'2018-05-23 09:26:48',1,'2018-05-23 09:26:48'),(72,5,2,0,1,'2018-05-23 09:26:48',1,'2018-05-23 09:26:48'),(73,6,2,0,1,'2018-05-23 09:26:48',1,'2018-05-23 09:26:48'),(74,7,2,0,1,'2018-05-23 09:26:48',1,'2018-05-23 09:26:48'),(75,8,2,0,1,'2018-05-23 09:26:48',1,'2018-05-23 09:26:48'),(76,9,2,0,1,'2018-05-23 09:26:48',1,'2018-05-23 09:26:48'),(77,10,2,0,1,'2018-05-23 09:26:48',1,'2018-05-23 09:26:48'),(78,11,2,0,1,'2018-05-23 09:26:48',1,'2018-05-23 09:26:48'),(79,12,2,0,1,'2018-05-23 09:26:48',1,'2018-05-23 09:26:48'),(80,13,2,0,1,'2018-05-23 09:26:48',1,'2018-05-23 09:26:48'),(81,14,2,0,1,'2018-05-23 09:26:48',1,'2018-05-23 09:26:48'),(82,15,2,0,1,'2018-05-23 09:26:48',1,'2018-05-23 09:26:48'),(83,16,2,0,1,'2018-05-23 09:26:48',1,'2018-05-23 09:26:48'),(84,17,2,0,1,'2018-05-23 09:26:48',1,'2018-05-23 09:26:48'),(85,18,2,0,1,'2018-05-23 09:26:48',1,'2018-05-23 09:26:48'),(86,19,2,0,1,'2018-05-23 09:26:48',1,'2018-05-23 09:26:48'),(87,20,2,0,1,'2018-05-23 09:26:48',1,'2018-05-23 09:26:48'),(88,23,2,0,1,'2018-05-23 09:26:48',1,'2018-05-23 09:26:48'),(89,24,2,0,1,'2018-05-23 09:26:48',1,'2018-05-23 09:26:48'),(90,25,2,0,1,'2018-05-23 09:26:48',1,'2018-05-23 09:26:48'),(91,26,2,0,1,'2018-05-23 09:26:48',1,'2018-05-23 09:26:48'),(92,27,2,0,1,'2018-05-23 09:26:48',1,'2018-05-23 09:26:48'),(93,28,2,0,1,'2018-05-23 09:26:48',1,'2018-05-23 09:26:48'),(94,29,2,0,1,'2018-05-23 09:26:48',1,'2018-05-23 09:26:48'),(95,30,2,0,1,'2018-05-23 09:26:48',1,'2018-05-23 09:26:48'),(96,31,2,0,1,'2018-05-23 09:26:48',1,'2018-05-23 09:26:48'),(97,32,2,0,1,'2018-05-23 09:26:48',1,'2018-05-23 09:26:48'),(98,33,2,0,1,'2018-05-23 09:26:48',1,'2018-05-23 09:26:48'),(99,34,2,0,1,'2018-05-23 09:26:48',1,'2018-05-23 09:26:48'),(100,35,2,0,1,'2018-05-23 09:26:48',1,'2018-05-23 09:26:48'),(101,36,2,0,1,'2018-05-23 09:26:48',1,'2018-05-23 09:26:48'),(102,43,1,1,1,'2018-05-24 15:21:57',1,'2018-05-24 15:21:57'),(103,43,2,0,1,'2018-05-24 15:21:57',1,'2018-05-24 15:21:57'),(104,44,1,1,1,'2018-05-24 15:21:57',1,'2018-05-24 15:21:57'),(105,44,2,0,1,'2018-05-24 15:21:57',1,'2018-05-24 15:21:57'),(106,45,1,1,1,'2018-05-24 15:21:57',1,'2018-05-24 15:21:57'),(107,45,2,0,1,'2018-05-24 15:21:57',1,'2018-05-24 15:21:57'),(108,46,1,1,1,'2018-05-24 15:21:57',1,'2018-05-24 15:21:57'),(109,46,2,0,1,'2018-05-24 15:21:57',1,'2018-05-24 15:21:57'),(110,47,1,1,1,'2018-05-24 15:21:57',1,'2018-05-24 15:21:57'),(111,47,2,0,1,'2018-05-24 15:21:57',1,'2018-05-24 15:21:57'),(112,48,1,1,1,'2018-05-24 15:21:57',1,'2018-05-24 15:21:57'),(113,48,2,0,1,'2018-05-24 15:21:57',1,'2018-05-24 15:21:57'),(117,49,1,1,1,'2018-05-25 11:59:25',1,'2018-05-25 11:59:25'),(118,49,2,0,1,'2018-05-25 11:59:25',1,'2018-05-25 11:59:25'),(119,50,1,1,1,'2018-05-25 11:59:25',1,'2018-05-25 11:59:25'),(120,50,2,0,1,'2018-05-25 11:59:25',1,'2018-05-25 11:59:25'),(121,51,1,1,1,'2018-05-25 11:59:25',1,'2018-05-25 11:59:25'),(122,51,2,0,1,'2018-05-25 11:59:25',1,'2018-05-25 11:59:25'),(123,52,1,1,1,'2018-05-25 11:59:25',1,'2018-05-25 11:59:25'),(124,52,2,0,1,'2018-05-25 11:59:25',1,'2018-05-25 11:59:25'),(125,53,1,1,1,'2018-05-25 11:59:25',1,'2018-05-25 11:59:25'),(126,53,2,0,1,'2018-05-25 11:59:25',1,'2018-05-25 11:59:25'),(127,54,1,1,1,'2018-05-25 11:59:25',1,'2018-05-25 11:59:25'),(128,54,2,0,1,'2018-05-25 11:59:25',1,'2018-05-25 11:59:25');
/*!40000 ALTER TABLE `modulointerfazusuario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `moneda`
--

DROP TABLE IF EXISTS `moneda`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `moneda` (
  `idMoneda` int(11) NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(200) DEFAULT NULL,
  `Abreviatura` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idMoneda`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `moneda`
--

LOCK TABLES `moneda` WRITE;
/*!40000 ALTER TABLE `moneda` DISABLE KEYS */;
/*!40000 ALTER TABLE `moneda` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `periodo`
--

DROP TABLE IF EXISTS `periodo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `periodo` (
  `idPeriodo` int(11) NOT NULL AUTO_INCREMENT,
  `Codigo` varchar(20) DEFAULT NULL,
  `Desde` datetime DEFAULT NULL,
  `Hasta` datetime DEFAULT NULL,
  `Nombre` varchar(500) DEFAULT NULL,
  `Obsevaciones` varchar(5000) DEFAULT NULL,
  `Estado` varchar(45) DEFAULT NULL,
  `IdUsuarioDeCreacion` int(11) NOT NULL,
  `FechaDeCreacion` datetime NOT NULL,
  `IdUsuarioDeModificacion` int(11) DEFAULT NULL,
  `FechaDeModificacion` datetime DEFAULT NULL,
  PRIMARY KEY (`idPeriodo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `periodo`
--

LOCK TABLES `periodo` WRITE;
/*!40000 ALTER TABLE `periodo` DISABLE KEYS */;
/*!40000 ALTER TABLE `periodo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `privilegio`
--

DROP TABLE IF EXISTS `privilegio`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `privilegio` (
  `idPrivilegio` int(11) NOT NULL AUTO_INCREMENT,
  `idModuloInterfaz` int(11) NOT NULL,
  `Nombre` varchar(200) DEFAULT NULL,
  `IdUsuarioDeCreacion` int(11) NOT NULL,
  `FechaDeCreacion` datetime NOT NULL,
  `IdUsuarioDeModificacion` int(11) DEFAULT NULL,
  `FechaDeModificacion` datetime DEFAULT NULL,
  PRIMARY KEY (`idPrivilegio`,`idModuloInterfaz`),
  KEY `fk_Privilegio_ModuloInterfaz1_idx` (`idModuloInterfaz`),
  CONSTRAINT `fk_Privilegio_ModuloInterfaz1` FOREIGN KEY (`idModuloInterfaz`) REFERENCES `modulointerfaz` (`idModuloInterfaz`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=55 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `privilegio`
--

LOCK TABLES `privilegio` WRITE;
/*!40000 ALTER TABLE `privilegio` DISABLE KEYS */;
INSERT INTO `privilegio` VALUES (1,1,'Acceso',1,'2018-05-03 14:46:13',1,'2018-05-03 14:46:13'),(2,1,'Agregar',1,'2018-05-03 14:46:13',1,'2018-05-03 14:46:13'),(3,1,'Actualizar',1,'2018-05-03 14:46:13',1,'2018-05-03 14:46:13'),(4,1,'Eliminar',1,'2018-05-03 14:46:13',1,'2018-05-03 14:46:13'),(5,1,'Visualizar',1,'2018-05-03 14:46:13',1,'2018-05-03 14:46:13'),(6,1,'Imprimir',1,'2018-05-03 14:46:13',1,'2018-05-03 14:46:13'),(7,1,'Nuevo',1,'2018-05-03 14:46:13',1,'2018-05-03 14:46:13'),(8,1,'Modificar privilegio',1,'2018-05-03 14:46:13',1,'2018-05-03 14:46:13'),(9,2,'Acceso',1,'2018-05-03 15:06:44',1,'2018-05-03 15:06:44'),(10,2,'Agregar',1,'2018-05-03 15:06:44',1,'2018-05-03 15:06:44'),(11,2,'Actualizar',1,'2018-05-03 15:06:44',1,'2018-05-03 15:06:44'),(12,2,'Eliminar',1,'2018-05-03 15:06:44',1,'2018-05-03 15:06:44'),(13,2,'Visualizar',1,'2018-05-03 15:06:44',1,'2018-05-03 15:06:44'),(14,2,'Imprimir',1,'2018-05-03 15:06:44',1,'2018-05-03 15:06:44'),(15,2,'Nuevo',1,'2018-05-03 15:06:44',1,'2018-05-03 15:06:44'),(16,2,'Modificar privilegio',1,'2018-05-03 15:06:44',1,'2018-05-03 15:06:44'),(17,3,'Acceso',1,'2018-05-03 15:09:13',1,'2018-05-03 15:09:13'),(18,3,'Actualizar',1,'2018-05-03 15:09:13',1,'2018-05-03 15:09:13'),(19,4,'Acceso',1,'2018-05-03 15:11:21',1,'2018-05-03 15:11:21'),(20,4,'Actualizar',1,'2018-05-03 15:11:21',1,'2018-05-03 15:11:21'),(21,5,'Acceso',1,'2018-05-03 15:13:53',1,'2018-05-03 15:13:53'),(22,5,'Respaldar',1,'2018-05-03 15:13:53',1,'2018-05-03 15:13:53'),(23,6,'Acceso',1,'2018-05-03 15:15:18',1,'2018-05-03 15:15:18'),(24,6,'Restaurar',1,'2018-05-03 15:15:18',1,'2018-05-03 15:15:18'),(25,7,'Acceso',1,'2018-05-09 12:00:29',1,'2018-05-09 12:00:29'),(26,7,'Actualizar',1,'2018-05-09 12:00:29',1,'2018-05-09 12:00:29'),(27,7,'Eliminar',1,'2018-05-09 12:00:29',1,'2018-05-09 12:00:29'),(28,7,'Visualizar',1,'2018-05-09 12:00:29',1,'2018-05-09 12:00:29'),(29,7,'Imprimir',1,'2018-05-09 12:00:29',1,'2018-05-09 12:00:29'),(30,7,'Nuevo',1,'2018-05-09 12:00:29',1,'2018-05-09 12:00:29'),(31,8,'Acceso',1,'2018-05-11 10:09:45',1,'2018-05-11 10:09:45'),(32,8,'Actualizar',1,'2018-05-11 10:09:45',1,'2018-05-11 10:09:45'),(33,8,'Eliminar',1,'2018-05-11 10:09:45',1,'2018-05-11 10:09:45'),(34,8,'Visualizar',1,'2018-05-11 10:09:45',1,'2018-05-11 10:09:45'),(35,8,'Imprimir',1,'2018-05-11 10:09:45',1,'2018-05-11 10:09:45'),(36,8,'Nuevo',1,'2018-05-11 10:09:45',1,'2018-05-11 10:09:45'),(37,9,'Acceso',1,'2018-05-15 09:45:04',1,'2018-05-15 09:45:04'),(38,9,'Actualizar',1,'2018-05-15 09:45:04',1,'2018-05-15 09:45:04'),(39,9,'Eliminar',1,'2018-05-15 09:45:04',1,'2018-05-15 09:45:04'),(40,9,'Visualizar',1,'2018-05-15 09:45:04',1,'2018-05-15 09:45:04'),(41,9,'Imprimir',1,'2018-05-15 09:45:04',1,'2018-05-15 09:45:04'),(42,9,'Nuevo',1,'2018-05-15 09:45:04',1,'2018-05-15 09:45:04'),(43,10,'Acceso',1,'2018-05-24 15:21:57',1,'2018-05-24 15:21:57'),(44,10,'Actualizar',1,'2018-05-24 15:21:57',1,'2018-05-24 15:21:57'),(45,10,'Eliminar',1,'2018-05-24 15:21:57',1,'2018-05-24 15:21:57'),(46,10,'Visualizar',1,'2018-05-24 15:21:57',1,'2018-05-24 15:21:57'),(47,10,'Imprimir',1,'2018-05-24 15:21:57',1,'2018-05-24 15:21:57'),(48,10,'Nuevo',1,'2018-05-24 15:21:57',1,'2018-05-24 15:21:57'),(49,11,'Acceso',1,'2018-05-25 11:59:25',1,'2018-05-25 11:59:25'),(50,11,'Actualizar',1,'2018-05-25 11:59:25',1,'2018-05-25 11:59:25'),(51,11,'Eliminar',1,'2018-05-25 11:59:25',1,'2018-05-25 11:59:25'),(52,11,'Visualizar',1,'2018-05-25 11:59:25',1,'2018-05-25 11:59:25'),(53,11,'Imprimir',1,'2018-05-25 11:59:25',1,'2018-05-25 11:59:25'),(54,11,'Nuevo',1,'2018-05-25 11:59:25',1,'2018-05-25 11:59:25');
/*!40000 ALTER TABLE `privilegio` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `rol`
--

DROP TABLE IF EXISTS `rol`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `rol` (
  `idRol` int(11) NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(200) DEFAULT NULL,
  `Descripcion` varchar(500) DEFAULT NULL,
  `Estado` varchar(45) DEFAULT NULL,
  `IdUsuarioDeCreacion` int(11) NOT NULL,
  `FechaDeCreacion` datetime NOT NULL,
  `IdUsuarioDeModificacion` int(11) DEFAULT NULL,
  `FechaDeModificacion` datetime DEFAULT NULL,
  PRIMARY KEY (`idRol`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rol`
--

LOCK TABLES `rol` WRITE;
/*!40000 ALTER TABLE `rol` DISABLE KEYS */;
INSERT INTO `rol` VALUES (1,'Administrador','','ACTIVO',1,'2018-05-03 09:26:34',1,'2018-05-03 09:26:34'),(2,'Usuario','Cuenta de usuario sin mucho privilegios','ACTIVO',1,'2018-05-23 09:11:48',1,'2018-05-23 09:25:07');
/*!40000 ALTER TABLE `rol` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tansacciondetalle_banco`
--

DROP TABLE IF EXISTS `tansacciondetalle_banco`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tansacciondetalle_banco` (
  `idTansaccionDetalle_Banco` int(11) NOT NULL AUTO_INCREMENT,
  `idTransaccionDetalle` int(11) NOT NULL,
  `ReferenciaBanco` varchar(100) NOT NULL,
  `DescBanco` varchar(500) DEFAULT NULL,
  `Debe` decimal(18,2) DEFAULT '0.00',
  `Haber` decimal(18,2) DEFAULT '0.00',
  `IdUsuarioDeCreacion` int(11) NOT NULL,
  `FechaDeCreacion` datetime NOT NULL,
  `IdUsuarioDeModificacion` int(11) DEFAULT NULL,
  `FechaDeModificacion` datetime DEFAULT NULL,
  PRIMARY KEY (`idTansaccionDetalle_Banco`),
  KEY `TransaccionDetallDeBanco_idx` (`idTransaccionDetalle`),
  CONSTRAINT `TransaccionDetallDeBanco` FOREIGN KEY (`idTransaccionDetalle`) REFERENCES `transacciondetalle` (`idTransaccionDetalle`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='vinculamos aquellas cuentas son de bancos y guardamos el vinculo con la parte superior, que es el detalle, donde se tiene el Debe y el Haber, y aqui dentro de la tabla guardamos, la referencia "Nota de debito, Nota de Credito, No. Cheque o un Deposito", ';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tansacciondetalle_banco`
--

LOCK TABLES `tansacciondetalle_banco` WRITE;
/*!40000 ALTER TABLE `tansacciondetalle_banco` DISABLE KEYS */;
/*!40000 ALTER TABLE `tansacciondetalle_banco` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tasadecambio`
--

DROP TABLE IF EXISTS `tasadecambio`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tasadecambio` (
  `idTasaDeCambio` int(11) NOT NULL AUTO_INCREMENT,
  `Fecha` datetime DEFAULT CURRENT_TIMESTAMP,
  `Cambio` decimal(10,4) DEFAULT NULL,
  PRIMARY KEY (`idTasaDeCambio`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tasadecambio`
--

LOCK TABLES `tasadecambio` WRITE;
/*!40000 ALTER TABLE `tasadecambio` DISABLE KEYS */;
/*!40000 ALTER TABLE `tasadecambio` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipodecuenta`
--

DROP TABLE IF EXISTS `tipodecuenta`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tipodecuenta` (
  `idTipoDeCuenta` int(11) NOT NULL,
  `DescTipoDeCuenta` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`idTipoDeCuenta`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipodecuenta`
--

LOCK TABLES `tipodecuenta` WRITE;
/*!40000 ALTER TABLE `tipodecuenta` DISABLE KEYS */;
INSERT INTO `tipodecuenta` VALUES (1,'Cuenta'),(2,'SubCuenta');
/*!40000 ALTER TABLE `tipodecuenta` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipodetransaccion`
--

DROP TABLE IF EXISTS `tipodetransaccion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tipodetransaccion` (
  `idTipoDeTransaccion` int(11) NOT NULL AUTO_INCREMENT,
  `DesTipoDeTransaccion` varchar(500) NOT NULL,
  `IdUsuarioDeCreacion` int(11) NOT NULL,
  `FechaDeCreacion` datetime NOT NULL,
  `IdUsuarioDeModificacion` int(11) DEFAULT NULL,
  `FechaDeModificacion` datetime DEFAULT NULL,
  PRIMARY KEY (`idTipoDeTransaccion`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipodetransaccion`
--

LOCK TABLES `tipodetransaccion` WRITE;
/*!40000 ALTER TABLE `tipodetransaccion` DISABLE KEYS */;
INSERT INTO `tipodetransaccion` VALUES (1,'Egreso',1,'2018-05-24 16:02:03',1,'2018-05-25 09:50:46'),(2,'Ingreso',1,'2018-05-24 16:06:53',1,'2018-05-24 16:06:53'),(3,'Diario',1,'2018-06-01 16:22:22',1,'2018-06-01 16:22:22');
/*!40000 ALTER TABLE `tipodetransaccion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `transaccion_cierre`
--

DROP TABLE IF EXISTS `transaccion_cierre`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `transaccion_cierre` (
  `idTransacciones` int(11) NOT NULL,
  `idCierreDePeriodo` int(11) NOT NULL,
  `idTipoDeTransaccion` int(11) NOT NULL,
  `NumeroDeTransaccion` varchar(45) DEFAULT NULL,
  `Fecha` datetime DEFAULT NULL,
  `Concepto` varchar(5000) DEFAULT NULL,
  `Valor` decimal(18,2) DEFAULT NULL,
  `Estado` varchar(45) DEFAULT NULL COMMENT 'Puede ser:\nPENDIENTE DE REVISION\nREVISADA\nANULADA\n',
  `IdUsuarioDeCreacion` int(11) NOT NULL,
  `FechaDeCreacion` datetime NOT NULL,
  `IdUsuarioDeModificacion` int(11) DEFAULT NULL,
  `FechaDeModificacion` datetime DEFAULT NULL,
  PRIMARY KEY (`idTransacciones`,`idCierreDePeriodo`,`idTipoDeTransaccion`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `transaccion_cierre`
--

LOCK TABLES `transaccion_cierre` WRITE;
/*!40000 ALTER TABLE `transaccion_cierre` DISABLE KEYS */;
/*!40000 ALTER TABLE `transaccion_cierre` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `transaccion_cierre_detalle`
--

DROP TABLE IF EXISTS `transaccion_cierre_detalle`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `transaccion_cierre_detalle` (
  `idTransaccionDetalle` int(11) NOT NULL,
  `idTransacciones` int(11) NOT NULL,
  `NoCuenta` int(11) NOT NULL,
  `Debe` decimal(18,2) NOT NULL,
  `Haber` decimal(18,2) NOT NULL DEFAULT '0.00',
  `IdUsuarioDeCreacion` int(11) NOT NULL,
  `FechaDeCreacion` datetime NOT NULL,
  `IdUsuarioDeModificacion` int(11) DEFAULT NULL,
  `FechaDeModificacion` datetime DEFAULT NULL,
  PRIMARY KEY (`idTransaccionDetalle`,`idTransacciones`,`NoCuenta`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `transaccion_cierre_detalle`
--

LOCK TABLES `transaccion_cierre_detalle` WRITE;
/*!40000 ALTER TABLE `transaccion_cierre_detalle` DISABLE KEYS */;
/*!40000 ALTER TABLE `transaccion_cierre_detalle` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `transacciondetalle`
--

DROP TABLE IF EXISTS `transacciondetalle`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `transacciondetalle` (
  `idTransaccionDetalle` int(11) NOT NULL AUTO_INCREMENT,
  `Debe` decimal(18,2) NOT NULL,
  `Haber` decimal(18,2) NOT NULL DEFAULT '0.00',
  `IdUsuarioDeCreacion` int(11) NOT NULL,
  `FechaDeCreacion` datetime NOT NULL,
  `IdUsuarioDeModificacion` int(11) DEFAULT NULL,
  `FechaDeModificacion` datetime DEFAULT NULL,
  `NoCuenta` int(11) NOT NULL,
  `idTransacciones` int(11) DEFAULT NULL,
  PRIMARY KEY (`idTransaccionDetalle`,`NoCuenta`),
  KEY `fk_transacciondetalle_Cuenta1_idx` (`NoCuenta`),
  KEY `fk_transacciondetalle_transacciones1_idx` (`idTransacciones`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `transacciondetalle`
--

LOCK TABLES `transacciondetalle` WRITE;
/*!40000 ALTER TABLE `transacciondetalle` DISABLE KEYS */;
INSERT INTO `transacciondetalle` VALUES (1,5000.00,0.00,1,'2018-06-05 15:51:08',1,'2018-06-05 15:51:08',41,1),(2,5000.00,0.00,1,'2018-06-05 15:51:08',1,'2018-06-05 15:51:08',42,1),(3,5000.00,0.00,1,'2018-06-05 15:51:08',1,'2018-06-05 15:51:08',43,1),(4,5000.00,0.00,1,'2018-06-05 15:51:08',1,'2018-06-05 15:51:08',44,1),(5,5000.00,0.00,1,'2018-06-05 15:51:08',1,'2018-06-05 15:51:08',45,1),(6,5000.00,0.00,1,'2018-06-05 15:51:08',1,'2018-06-05 15:51:08',46,1),(7,5000.00,0.00,1,'2018-06-05 15:51:08',1,'2018-06-05 15:51:08',47,1),(8,5000.00,0.00,1,'2018-06-05 15:51:08',1,'2018-06-05 15:51:08',48,1),(9,2000.00,0.00,1,'2018-06-06 16:00:43',1,'2018-06-07 11:32:33',41,2),(13,2000.00,0.00,1,'2018-06-07 11:32:33',1,'2018-06-07 11:32:33',42,2),(14,5000.00,0.00,1,'2018-06-07 15:11:37',1,'2018-06-07 15:15:03',42,2),(15,10000.00,0.00,1,'2018-06-07 15:31:21',1,'2018-06-07 15:50:43',52,2),(16,5000.00,0.00,1,'2018-06-07 15:49:34',1,'2018-06-07 15:50:01',54,2);
/*!40000 ALTER TABLE `transacciondetalle` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `transacciones`
--

DROP TABLE IF EXISTS `transacciones`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `transacciones` (
  `idTransacciones` int(11) NOT NULL AUTO_INCREMENT,
  `NumeroDeTransaccion` varchar(45) DEFAULT NULL,
  `Fecha` datetime DEFAULT NULL,
  `Concepto` varchar(5000) DEFAULT NULL,
  `Valor` decimal(18,2) DEFAULT NULL,
  `idTipoDeTransaccion` int(11) NOT NULL,
  `Estado` varchar(45) DEFAULT NULL COMMENT 'Puede ser:\nPENDIENTE DE REVISION\nREVISADA\nANULADA\n',
  `IdUsuarioDeCreacion` int(11) NOT NULL,
  `FechaDeCreacion` datetime NOT NULL,
  `IdUsuarioDeModificacion` int(11) DEFAULT NULL,
  `FechaDeModificacion` datetime DEFAULT NULL,
  PRIMARY KEY (`idTransacciones`,`idTipoDeTransaccion`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `transacciones`
--

LOCK TABLES `transacciones` WRITE;
/*!40000 ALTER TABLE `transacciones` DISABLE KEYS */;
INSERT INTO `transacciones` VALUES (1,'1','2018-06-05 15:46:52','pago',40000.00,1,'PENDIENTE',1,'2018-06-05 15:51:08',1,'2018-06-07 14:48:57'),(2,'1','2018-06-06 15:58:15','Movimientos del Dia',20000.00,3,'PENDIENTE',1,'2018-06-06 16:00:43',1,'2018-06-07 15:50:43');
/*!40000 ALTER TABLE `transacciones` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuario`
--

DROP TABLE IF EXISTS `usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `usuario` (
  `idUsuario` int(11) NOT NULL AUTO_INCREMENT,
  `idRol` int(11) NOT NULL,
  `Nombre` varchar(200) NOT NULL,
  `Login` varchar(200) NOT NULL,
  `Contrasena` varchar(200) NOT NULL,
  `Email` varchar(200) DEFAULT NULL,
  `Estado` varchar(45) NOT NULL,
  `IdUsuarioDeCreacion` int(11) NOT NULL,
  `FechaDeCreacion` datetime NOT NULL,
  `IdUsuarioDeModificacion` int(11) DEFAULT NULL,
  `FechaDeModificacion` datetime DEFAULT NULL,
  PRIMARY KEY (`idUsuario`,`idRol`),
  KEY `fk_Usuario_Rol1_idx` (`idRol`),
  CONSTRAINT `fk_Usuario_Rol1` FOREIGN KEY (`idRol`) REFERENCES `rol` (`idRol`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuario`
--

LOCK TABLES `usuario` WRITE;
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
INSERT INTO `usuario` VALUES (1,1,'Servicios TRIGGER','Administrador','wno5GbHqs4NgaI1WepvsaA==','trigger@cablenet.com.ni','ACTIVO',1,'2018-05-03 09:26:34',1,'2018-05-03 09:26:34'),(2,2,'Darwin Sarantes','darwinsarantes','2dP137VNVneIlrSomwCp9A==','darwinsarantes@gmail.com','ACTIVO',1,'2018-05-23 09:26:48',1,'2018-05-23 09:26:48');
/*!40000 ALTER TABLE `usuario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'siscontador'
--

--
-- Dumping routines for database 'siscontador'
--
/*!50003 DROP FUNCTION IF EXISTS `EvaLuarSiEsCuentaDeBanco` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_ALL_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_AUTO_CREATE_USER' */ ;
DELIMITER ;;
CREATE DEFINER=`STDataBase`@`%` FUNCTION `EvaLuarSiEsCuentaDeBanco`(NumeroDeCuenta int) RETURNS int(11)
BEGIN

	Set @CuentaPrincipalDeBanco = (Select CuentaPrincipalDeBanco from configuracion where IdConfiguracion = 1);
    set @CuentaPrincipalDeBanco = concat(@CuentaPrincipalDeBanco, '%');
    
    if (exists(Select NoCuenta from cuenta where NoCuenta = NumeroDeCuenta and idCuenta like @CuentaPrincipalDeBanco)) then
		return 1;
	else
		return 0;
    end if;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP FUNCTION IF EXISTS `EvaluarSiEsCuentaPrincipal` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_ALL_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_AUTO_CREATE_USER' */ ;
DELIMITER ;;
CREATE DEFINER=`STDataBase`@`%` FUNCTION `EvaluarSiEsCuentaPrincipal`(NumCuenta int) RETURNS int(11)
BEGIN

	if (exists(Select NoCuenta from cuenta where CuentaMadre = NumCuenta)) then
		return 1;
	else
		return 0;
    end if;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP FUNCTION IF EXISTS `IdentificadorDeCategoriaDeCuenta` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_ALL_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_AUTO_CREATE_USER' */ ;
DELIMITER ;;
CREATE DEFINER=`STDataBase`@`%` FUNCTION `IdentificadorDeCategoriaDeCuenta`() RETURNS int(11)
BEGIN

	set @Identificador = 0;
    
    if exists(select idCategoriaDeCuenta from categoriadecuenta) then
		set @Identificador = (Select max(idCategoriaDeCuenta) from categoriadecuenta order by idCategoriaDeCuenta desc);
        set @Identificador = @Identificador + 1;
	else
		set @Identificador = 1;
    end if;
    
    return @Identificador;

RETURN 1;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP FUNCTION IF EXISTS `IdentificadorDeLaCuenta` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_ALL_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_AUTO_CREATE_USER' */ ;
DELIMITER ;;
CREATE DEFINER=`STDataBase`@`%` FUNCTION `IdentificadorDeLaCuenta`() RETURNS int(11)
BEGIN

	set  @Identificador = 0;
    
    if exists(Select NoCuenta  from cuenta) then
		set  @Identificador = (Select max(NoCuenta) from  cuenta order by NoCuenta desc);
        set  @Identificador = @Identificador + 1; 
	else
		set  @Identificador = 1;    
    end if;
    
    return @Identificador;

RETURN 1;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP FUNCTION IF EXISTS `IdentificadorDeLaTransaccion` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_ALL_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_AUTO_CREATE_USER' */ ;
DELIMITER ;;
CREATE DEFINER=`STDataBase`@`%` FUNCTION `IdentificadorDeLaTransaccion`() RETURNS int(11)
BEGIN

	set  @Identificador = 0;
    
    if exists(Select idTransacciones  from transacciones) then
		set  @Identificador = (Select max(idTransacciones) from  transacciones order by idTransacciones desc);
        set  @Identificador = @Identificador + 1; 
	else
		set  @Identificador = 1;    
    end if;
    
    return @Identificador;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP FUNCTION IF EXISTS `IdentificadorDeLaTransaccionPorTipoDeTransaccion` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_ALL_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_AUTO_CREATE_USER' */ ;
DELIMITER ;;
CREATE DEFINER=`STDataBase`@`%` FUNCTION `IdentificadorDeLaTransaccionPorTipoDeTransaccion`(
_idTipoDeTransaccion int
) RETURNS int(11)
BEGIN

	set  @Identificador = 0;
    
    if exists(Select idTransacciones  from transacciones where idTipoDeTransaccion = _idTipoDeTransaccion) then
		set  @Identificador = (Select max(idTransacciones) from  transacciones where idTipoDeTransaccion = _idTipoDeTransaccion order by idTransacciones desc);
        set  @Identificador = @Identificador + 1; 
	else
		set  @Identificador = 01;    
    end if;
    
    return @Identificador;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP FUNCTION IF EXISTS `IdentificadorGrupoDeCuentas` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_ALL_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_AUTO_CREATE_USER' */ ;
DELIMITER ;;
CREATE DEFINER=`STDataBase`@`%` FUNCTION `IdentificadorGrupoDeCuentas`() RETURNS int(11)
BEGIN

	set @Identificador = 0;
    if exists( select idGrupoDeCuentas from  grupodecuentas limit 1 ) then    
		set @Identificador = (Select max(idGrupoDeCuentas) from grupodecuentas order by  idGrupoDeCuentas desc);
        set @Identificador = @Identificador + 1;
    else
		set @Identificador = 1;
    end if;
    
    return @Identificador;
	
RETURN 1;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP FUNCTION IF EXISTS `IdentificadorTipoDeCuenta` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_ALL_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_AUTO_CREATE_USER' */ ;
DELIMITER ;;
CREATE DEFINER=`STDataBase`@`%` FUNCTION `IdentificadorTipoDeCuenta`() RETURNS int(11)
BEGIN

	set @Identificador = 0;
    
    if exists(Select idTipoDeCuenta from tipodecuenta) then    
		set @Identificador = (Select max(idTipoDeCuenta) from tipodecuenta order by idTipoDeCuenta desc);
		set @Identificador = @Identificador + 1;
	else
		set @Identificador = 1;  
    end if;
    
    return @Identificador;

RETURN 1;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `ValidarSiElRegistroEstaVinculado` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_ALL_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_AUTO_CREATE_USER' */ ;
DELIMITER ;;
CREATE DEFINER=`STDataBase`@`%` PROCEDURE `ValidarSiElRegistroEstaVinculado`(
CampoABuscar_ VARCHAR(250),
ValorCampoABuscar INT, 
ExcluirTabla_ VARCHAR(100)
)
BEGIN

	DROP TABLE IF EXISTS TablasTemporal_;
	CREATE TEMPORARY TABLE TablasTemporal_(
		ID INT primary key NOT NULL AUTO_INCREMENT,
		NombreTabla VARCHAR(500), NombreColumna VARCHAR(100)
	);

	insert into TablasTemporal_
	Select 0,TableName, ColumnName from (
	SELECT table_name as 'TableName',column_name as 'ColumnName',
	referenced_table_name as 'ReferenceTableName',
	referenced_column_name as 'ReferenceColumnName'
	FROM information_schema.key_column_usage) as T
	WHERE upper( T.ReferenceColumnName) = upper(CampoABuscar_)  and upper( T.TableName ) <> upper(ExcluirTabla_) ;

	set @x = 1;
	SET @TablasAfectadas = 'NINGUNA';
    
    if exists(Select id from TablasTemporal_) then
    
		while @x <= (select MAX(ID) from TablasTemporal_ ) do 
			
			SET @NombreTabla = (SELECT NombreTabla FROM TablasTemporal_ WHERE ID = @x);
			SET @Campo = (SELECT NombreColumna FROM TablasTemporal_ WHERE ID = @x);
			#-------------------------------------------------------------------------------------------------
			set @Consulta = Concat("SET @NRegistros = IFNULL((SELECT COUNT(*) AS Total FROM ",  @NombreTabla, " WHERE " , @Campo , " = " , ValorCampoABuscar , "), 0)");
			
			prepare smtp from @Consulta;
			execute smtp;
			set @NRegistrosOptenidos = (select @NRegistros);
			
			if @NRegistrosOptenidos > 0 then
			
				if @TablasAfectadas = 'NINGUNA' then
					SET @TablasAfectadas = '';
				else
					SET @TablasAfectadas = concat(@TablasAfectadas , ', ');
                end if;
				
                SET @TablasAfectadas = concat(@TablasAfectadas , @NombreTabla);
				SET @NRegistros = 0;
                
			end if;
			
			#-------------------------------------------------------------------------------------------------
			set @x = @x + 1;
			
		end while;
    
    end if;
    
    Select @TablasAfectadas as 'TablasAfectadas';

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-06-08 16:39:07
