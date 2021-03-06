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
-- Dumping data for table `categoriadecuenta`
--

LOCK TABLES `categoriadecuenta` WRITE;
/*!40000 ALTER TABLE `categoriadecuenta` DISABLE KEYS */;
INSERT INTO `categoriadecuenta` VALUES (1,'Activo Circulante',1,'2018-05-11 10:57:25',1,'2018-05-11 10:57:25',1),(2,'Activo Fijo',1,'2018-05-11 11:06:23',1,'2018-05-11 11:06:23',1),(3,'Acivo Diferido',1,'2018-05-11 11:07:20',1,'2018-05-11 11:18:31',1),(4,'Pasivo Circulante',1,'2018-05-11 11:26:21',1,'2018-05-11 11:26:21',2),(5,'Pasivo Fijo',1,'2018-05-11 11:29:37',1,'2018-05-11 11:29:37',2),(6,'Pasivo Diferido',1,'2018-05-11 11:41:34',1,'2018-05-11 11:41:34',2),(7,'Otros Pasivos',1,'2018-05-11 11:41:47',1,'2018-05-11 11:41:47',2),(8,'Capital',1,'2018-05-11 11:43:53',1,'2018-05-11 11:43:53',3),(9,'Ingresos',1,'2018-05-11 11:44:24',1,'2018-05-11 11:44:24',4),(10,'Otros Ingresos',1,'2018-05-11 11:46:15',1,'2018-05-11 11:46:15',4),(11,'Egresos',1,'2018-05-11 11:46:24',1,'2018-05-11 11:46:24',4),(12,'Otros Egresos',1,'2018-05-11 11:46:44',1,'2018-05-11 11:46:44',4);
/*!40000 ALTER TABLE `categoriadecuenta` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `cierredeperiodo`
--

LOCK TABLES `cierredeperiodo` WRITE;
/*!40000 ALTER TABLE `cierredeperiodo` DISABLE KEYS */;
/*!40000 ALTER TABLE `cierredeperiodo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `configuracion`
--

LOCK TABLES `configuracion` WRITE;
/*!40000 ALTER TABLE `configuracion` DISABLE KEYS */;
INSERT INTO `configuracion` VALUES (1,'D:\\dbpruebas','D:\\dbpruebas',3,'C:\\wamp64\\bin\\mysql\\mysql5.7.21\\bin\\','C:\\wamp64\\bin\\mysql\\mysql5.7.21\\bin\\','101');
/*!40000 ALTER TABLE `configuracion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `cuenta`
--

LOCK TABLES `cuenta` WRITE;
/*!40000 ALTER TABLE `cuenta` DISABLE KEYS */;
/*!40000 ALTER TABLE `cuenta` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `empresa`
--

LOCK TABLES `empresa` WRITE;
/*!40000 ALTER TABLE `empresa` DISABLE KEYS */;
INSERT INTO `empresa` VALUES (1,'ESTACIÓN DE SERVICIOS \r\nSHELL - ESQUIPULAS, ESTELI','Frente a Edificio de operaciones de la policia nacional, esteli, Nicaragua','27133908','','�PNG\r\n\Z\n\0\0\0\rIHDR\0\0\0\�\0\0\0\�\0\0\0	m\"H\0\0\0gAMA\0\0���a\0\0PLTE���\�t!<�\�#/\�l\0�˵\�n���\04�\09�\0;�\�j\0���j��\�h\0D�\0)�\07�\�t!\0-�\01�\0$�\�q\�\0\�e\0��G\0(�\0\"�\�&\�\0\�sy\�.8��\�\�\��W��\��\�\�\� \����hp�ą�\��\�Ԙ�\�����\�\��\�\�\�\��_y�\�io��r\�\�\��è�\�㛬\�/S�\�U[\�\��\�\�\�\�臌\�\0\0�ϻKi�\0�\�_e\�7?\�JQ�\�\�ꔘJ���\�Rn��\�\�鑔\�pv;]���\�\�6�~\0\0��]��N����\�p�\0\0�IDATx^\�\r[\�\��WDL�	\�ڦh\n�\n��(`���ۊ=����ܙ\����\�c�>�\�l\�\�|\�B\�0\�0\�0\�0\�0\�0\�0\�0\�0\�0\�0\�0\�0\�0\�0\�0I��\�c�\�\��鹞k/�\�KW\�QsPtm\�33�J�\�1<\�N�{!\ry\�t��N\�s� W��a\�>�{��Gò\�@�,A�F\�����i�1,�$��\�v\��\�̚�W.ۮa��NyL/x`��G\�9�k\�A�\�;\�Z��\�\��\�e\�\�ڗ\�\�f�,�\�4\\\�4zݛd\��\���L\�pTv1f:nŨ�\�N\n�Ň\�C�\�pT�d�,�{-껋V��Z>a�\�x�l�\��vJ\�\�8hģ�\�F�\�5=�\"x�Uh�/vq�|\�1\ndm��Ѫt��P�x\�5\���\�\�\�\�3�h~h�\�J�\�\�l�g\�\'ٕ]�`	����4\�[i\�*�~H	\�c�<\�,:���zˢ^`\�\�\�Va\�\�G�R�Ȭ\�\�XY�3\�\'g�Km}���Lϔ��@}��D\�~�p���O|��8~z\�\�(��\�\\S���!%��oS�[�\�Đ�����Ibs�A\�B���I��\'�~$�v�E\�n�\�\Z�\�F�ר_S�O���m\�W�A��y2�h\\\�ۀ�,B��\�\�Wj����\�Q���\�\�^\�HO�&>S���H�Y�]wM\�zrf�jQ̋Rا�ss\�OF􂥢\�7\������� �\�\����T\�܏\�\�RuMB7T �`%g�􉷰E�/\�m\nJgZ��]�`\�*Xi�����XR�\�\�\���*\�P\�ӕ Q�AK\�C������kϵO\"cN\0\�\�V6^<�*X1!\'\� vX2aD�;\�t-\ZJi�\�D\'\"9	5��\�֮b�Բ� ����+\"aF�^-��4z_bV�YE�x��\\\�lQt�\�tE\'H�\�\�\�`�\�4	�/��qZ�\�%WAƽ��4\��\Z�%��\�\�`�\�y��|�M4Y\�R�Vh\�|���\ZL�蝓n^D]S\�>M�\�t�h\�5����K\�pq)\r���cK�^�z\�\��\�Cib�\�~T��zE-:\�\�QMErʆ&\�\�ֲE&]�tO\�\ru\�y�:s1f�3ڕY�����H��u�M�D����mtj\��\0]pX^䴴�y;sT\�Z\�=(\Zk9hS����F�X x�R�\�L�]j i�����g�^��\�:���r\\\�\�\\���t5@��ma\�Hra���\�R!f���\n\rް5@�O��8�F�\�_�|�ea-1P��.X�jU\�I4^�9\'��$( Ԛ�{��\"��ݼ�N-�9\�%;AE���M&M�aBh�\��\�\�\nﴜr��Do[�t^��+2E&c�\\\'�ڲ=s�lw�IA�sJ!\�\\la�5\�Q���-�	��\�\�\�S�\�#S�\�#�_�P/�Wd�V\�*(�jGuܒXp�1&��a��M/\�%e�QN45\�ssD 2T\�\����O�(\Zk���\�2�/cLSW-�\�\�2rn\�\�wA�\�\�dU�\�*�̤~\�\�bR�\�v�@�WRB}w1�\r�E,\\�\���i��\�\��{�\�nǤ�\���ϒXX�L\�\\\�r�6>u\�Y9)WLuܒ��|ԿY\�6g_\�\�6�I�\�\�tU�nз�oj��*m\"�\��t�\�\�R�\�0?��+�Ջ\�\�\�5\�M�*ZB�ԧ\��-9�ne\�H[��|=^<\�GGn�vC\�5\\�%֢,e\��\�\�\�Rؽ^�c\�lQ\�{y\r9�\�H�R\�\0�J�ke\��\�\��d=�w���Mg����С�?��us���@\�R�\��tr�\'e�^.�^\�QǟOp|�o�\'�G\�^\Za\�!�J�����(�A=U�xqۜ\�?b�\��\��\�\�Ut�^���\�T6oUd+W\\�lv~냖G�\�x%\'\�\�ϛ^�\�k\�\�9^eP���W�:�\�΀f�M-Dбޘ=��z���Ý��\�w\����q��~�s�{�m\���9�s�\�\�Loυ\�h��k_�\�\�f�\��G\�˔\�]\�I�^�؈=���\nϭ4`*&�F�Lۆ;KԄ���\��7<�\�=���V���\���]�\�}�x���yss\�\�_\�|v��\���n˧}��\�!.��\�SwY\�-\rG�\�/\�x�\��M\��1�(�Qzơ�\�X!Y�X͗�U�\n�\�)��;\�\n�C!\�}\�\�+���\�D�\�8\n���\�B\��qɝ<��@\\���\�,�\��\�!�zL�(:\�f\�C�={�\�\��\�Gv9����J?���\"�h{_\�\'<���U8*j�4�\�\�It;\��Q*�\�.\���׽\����l�BNJE\�e�:j\0a�����\��;���\0E4��#t\\ۓ�Xꋿ� U0˧p\�<ϡě����\�\�\�mi���h�\'�Å���\�\��z�Q+�ճQQ\�1JZ�(AI]\n��E8\��G���)\0��\�q(e��QC\�\�kH��\�\�=\�m\�a�\�k<T?�|=��oz\�I���c�s\'/*\�,\�]g�Ţ#o�g��\\p.D\�Ѩ\���\�xA6��@IP�\�9���;G\�\�>��*|*\'��$NU�=n\�:�Q(5qɬ��tQU��Q�\��R^��q^���o9\�\�E	Q�{_Q�O*�T�&I�[�龐��H��M\"f6�YN��P�\nJ�&\\0*\�z!h�W�&��z\nNW\��A���I�\�C�R�Q9�PjW*pM��2ګ\n��1\�PZ�zh\�Bzn�3�l\��5ʉ��&N\�:0\�\09ژN)�Y.�*v첎\�\���QY�*#��yɐ�k�ц2����\�:��\�;\n�Y�<\�$-��\�\�\�\�y\�\��\�\�H\��\�n�ےN\"C�\�\0<�\�&!\�@�=�P��A�K����=)\�>&�\�̊Qk\�����ս\���\��$\0�p��)ȣeF\�@�1�P\n�!\�֞\��&�K`�c�CۄLAm\�^��\�_š-\�\'qB�EHfDKn\� 2E�Ps�t<�f*�mOF��2,\�P��`�h����>7+i�3&N�j����~\�$d�;*A�M��e�D\�˚��Zm\�.��\�X잃�\�UhH\�UOF\�q�i\�n���\�I�N�X4��xτS��)���2�\�qN_�\r�h`W�y1L\rcU���>}���N�B\�T�\�\�n\���\�\��\�rT�߳��~\�<J��a�a�a�a�a�a�a�a�a�a�a�a�a�a�a\�@��^�+A\�>%�\0\0\0\0IEND�B`�','84025008','serviciostrigger@gmail.com','','Servicios profecionales, en desarrollo web, analisis y diseño de sistemas, mantenimiento de equipos, reparacion, y ventas de equipos computaciones..');
/*!40000 ALTER TABLE `empresa` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `grupodecuentas`
--

LOCK TABLES `grupodecuentas` WRITE;
/*!40000 ALTER TABLE `grupodecuentas` DISABLE KEYS */;
INSERT INTO `grupodecuentas` VALUES (1,'Activos','+','-',1,'2018-05-10 14:53:46',1,'2018-05-24 16:32:03'),(2,'Pasivos','-','+',1,'2018-05-10 15:00:07',1,'2018-05-24 16:32:23'),(3,'Capital','-','+',1,'2018-05-10 15:00:59',1,'2018-05-24 16:32:41'),(4,'Cuentas de Resultado (Ingresos)','-','+',1,'2018-05-10 15:07:17',1,'2018-05-24 16:33:02'),(5,'Egresos','+','-',1,'2018-05-10 16:30:33',1,'2018-05-24 16:33:19');
/*!40000 ALTER TABLE `grupodecuentas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `interfaz`
--

LOCK TABLES `interfaz` WRITE;
/*!40000 ALTER TABLE `interfaz` DISABLE KEYS */;
INSERT INTO `interfaz` VALUES (1,'Usuario','Información de la interfaz','usuario',1,'2018-05-03 14:27:13',1,'2018-05-03 14:27:13'),(2,'Rol','Información de los tipos de cuentas','rol',1,'2018-05-03 14:27:13',1,'2018-05-03 14:27:13'),(3,'Configuracion','Información de las configuraciones generales','configuracion',1,'2018-05-03 14:27:13',1,'2018-05-03 14:27:13'),(4,'Empresa','Información de los datos generales de la empresas','empresa',1,'2018-05-03 14:27:13',1,'2018-05-03 14:27:13'),(5,'Respaldar','Información de respaldo de datos del sistema','respaldo',1,'2018-05-03 14:27:13',1,'2018-05-03 14:27:13'),(6,'Restaurar','Información de restauracion de datos del sistema','restaurar',1,'2018-05-03 14:27:13',1,'2018-05-03 14:27:13'),(7,'GrupoDecuentas','Administrar la clasificacion de cuentas','grupodecuentas',1,'2018-05-09 11:59:08',1,'2018-05-09 11:59:08'),(8,'CategoriaDeCuentas','Administrar la informacion de la categoria de las cuentas','categoriadecuenta',1,'2018-05-11 10:08:53',1,'2018-05-11 10:08:53'),(9,'Cuentas','Administración y clasificación de las cuentas contables','cuentas',1,'2018-05-15 09:44:15',1,'2018-05-15 09:44:15'),(10,'TipoDeTransaccion','Administrar los tipos de transacciones','tipodetransaccion',1,'2018-05-24 15:21:14',1,'2018-05-24 15:21:14'),(11,'Transacciones','Administrar las transacciones de las diferentes cuentas','transacciones',1,'2018-05-25 11:58:58',1,'2018-05-25 11:58:58');
/*!40000 ALTER TABLE `interfaz` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `modulo`
--

LOCK TABLES `modulo` WRITE;
/*!40000 ALTER TABLE `modulo` DISABLE KEYS */;
INSERT INTO `modulo` VALUES (1,'General',1,'2018-05-03 14:27:13',1,'2018-05-03 14:27:13'),(2,'Cuentas',1,'2018-05-09 11:56:52',1,'2018-05-09 11:56:52'),(3,'Transacciones',1,'2018-05-24 15:19:24',1,'2018-05-24 15:19:24');
/*!40000 ALTER TABLE `modulo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `modulointerfaz`
--

LOCK TABLES `modulointerfaz` WRITE;
/*!40000 ALTER TABLE `modulointerfaz` DISABLE KEYS */;
INSERT INTO `modulointerfaz` VALUES (1,1,1,1,'2018-05-03 14:46:13',1,'2018-05-03 14:46:13'),(2,1,2,1,'2018-05-03 15:06:44',1,'2018-05-03 15:06:44'),(3,1,3,1,'2018-05-03 15:09:13',1,'2018-05-03 15:09:13'),(4,1,4,1,'2018-05-03 15:11:21',1,'2018-05-03 15:11:21'),(5,1,5,1,'2018-05-03 15:13:53',1,'2018-05-03 15:13:53'),(6,1,6,1,'2018-05-03 15:15:18',1,'2018-05-03 15:15:18'),(7,2,7,1,'2018-05-09 12:00:29',1,'2018-05-09 12:00:29'),(8,2,8,1,'2018-05-11 10:09:45',1,'2018-05-11 10:09:45'),(9,2,9,1,'2018-05-15 09:45:04',1,'2018-05-15 09:45:04'),(10,3,10,1,'2018-05-24 15:21:57',1,'2018-05-24 15:21:57'),(11,3,11,1,'2018-05-25 11:59:25',1,'2018-05-25 11:59:25');
/*!40000 ALTER TABLE `modulointerfaz` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `modulointerfazrol`
--

LOCK TABLES `modulointerfazrol` WRITE;
/*!40000 ALTER TABLE `modulointerfazrol` DISABLE KEYS */;
INSERT INTO `modulointerfazrol` VALUES (1,1,1,1,1,'2018-05-03 15:03:37',1,'2018-05-03 15:03:37'),(2,2,1,1,1,'2018-05-03 15:03:37',1,'2018-05-03 15:03:37'),(3,3,1,1,1,'2018-05-03 15:03:37',1,'2018-05-03 15:03:37'),(4,4,1,1,1,'2018-05-03 15:03:37',1,'2018-05-03 15:03:37'),(5,5,1,1,1,'2018-05-03 15:03:37',1,'2018-05-03 15:03:37'),(6,6,1,1,1,'2018-05-03 15:03:37',1,'2018-05-03 15:03:37'),(7,7,1,1,1,'2018-05-03 15:03:37',1,'2018-05-03 15:03:37'),(8,8,1,1,1,'2018-05-03 15:03:37',1,'2018-05-03 15:03:37'),(16,9,1,1,1,'2018-05-03 15:06:44',1,'2018-05-03 15:06:44'),(17,10,1,1,1,'2018-05-03 15:06:44',1,'2018-05-03 15:06:44'),(18,11,1,1,1,'2018-05-03 15:06:44',1,'2018-05-03 15:06:44'),(19,12,1,1,1,'2018-05-03 15:06:44',1,'2018-05-03 15:06:44'),(20,13,1,1,1,'2018-05-03 15:06:44',1,'2018-05-03 15:06:44'),(21,14,1,1,1,'2018-05-03 15:06:44',1,'2018-05-03 15:06:44'),(22,15,1,1,1,'2018-05-03 15:06:44',1,'2018-05-03 15:06:44'),(23,16,1,1,1,'2018-05-03 15:06:44',1,'2018-05-03 15:06:44'),(31,17,1,1,1,'2018-05-03 15:09:13',1,'2018-05-03 15:09:13'),(32,18,1,1,1,'2018-05-03 15:09:13',1,'2018-05-03 15:09:13'),(34,19,1,1,1,'2018-05-03 15:11:21',1,'2018-05-03 15:11:21'),(35,20,1,1,1,'2018-05-03 15:11:21',1,'2018-05-03 15:11:21'),(37,21,1,1,1,'2018-05-03 15:13:53',1,'2018-05-03 15:13:53'),(38,22,1,1,1,'2018-05-03 15:13:53',1,'2018-05-03 15:13:53'),(40,23,1,1,1,'2018-05-03 15:15:18',1,'2018-05-03 15:15:18'),(41,24,1,1,1,'2018-05-03 15:15:18',1,'2018-05-03 15:15:18'),(42,25,1,1,1,'2018-05-09 12:00:29',1,'2018-05-09 12:00:29'),(43,26,1,1,1,'2018-05-09 12:00:29',1,'2018-05-09 12:00:29'),(44,27,1,1,1,'2018-05-09 12:00:29',1,'2018-05-09 12:00:29'),(45,28,1,1,1,'2018-05-09 12:00:29',1,'2018-05-09 12:00:29'),(46,29,1,1,1,'2018-05-09 12:00:29',1,'2018-05-09 12:00:29'),(47,30,1,1,1,'2018-05-09 12:00:29',1,'2018-05-09 12:00:29'),(48,31,1,1,1,'2018-05-11 10:09:45',1,'2018-05-11 10:09:45'),(49,32,1,1,1,'2018-05-11 10:09:45',1,'2018-05-11 10:09:45'),(50,33,1,1,1,'2018-05-11 10:09:45',1,'2018-05-11 10:09:45'),(51,34,1,1,1,'2018-05-11 10:09:45',1,'2018-05-11 10:09:45'),(52,35,1,1,1,'2018-05-11 10:09:45',1,'2018-05-11 10:09:45'),(53,36,1,1,1,'2018-05-11 10:09:45',1,'2018-05-11 10:09:45'),(54,37,1,1,1,'2018-05-15 09:45:04',1,'2018-05-15 09:45:04'),(55,38,1,1,1,'2018-05-15 09:45:04',1,'2018-05-15 09:45:04'),(56,39,1,1,1,'2018-05-15 09:45:04',1,'2018-05-15 09:45:04'),(57,40,1,1,1,'2018-05-15 09:45:04',1,'2018-05-15 09:45:04'),(58,41,1,1,1,'2018-05-15 09:45:04',1,'2018-05-15 09:45:04'),(59,42,1,1,1,'2018-05-15 09:45:04',1,'2018-05-15 09:45:04'),(60,21,2,1,1,'2018-05-23 09:11:48',1,'2018-05-23 09:11:48'),(61,22,2,1,1,'2018-05-23 09:11:48',1,'2018-05-23 09:11:48'),(62,37,2,1,1,'2018-05-23 09:25:09',1,'2018-05-23 09:25:09'),(63,38,2,1,1,'2018-05-23 09:25:09',1,'2018-05-23 09:25:09'),(64,39,2,1,1,'2018-05-23 09:25:09',1,'2018-05-23 09:25:09'),(65,40,2,1,1,'2018-05-23 09:25:09',1,'2018-05-23 09:25:09'),(66,41,2,1,1,'2018-05-23 09:25:09',1,'2018-05-23 09:25:09'),(67,42,2,1,1,'2018-05-23 09:25:09',1,'2018-05-23 09:25:09'),(68,43,1,1,1,'2018-05-24 15:21:57',1,'2018-05-24 15:21:57'),(69,43,2,0,1,'2018-05-24 15:21:57',1,'2018-05-24 15:21:57'),(70,44,1,1,1,'2018-05-24 15:21:57',1,'2018-05-24 15:21:57'),(71,44,2,0,1,'2018-05-24 15:21:57',1,'2018-05-24 15:21:57'),(72,45,1,1,1,'2018-05-24 15:21:57',1,'2018-05-24 15:21:57'),(73,45,2,0,1,'2018-05-24 15:21:57',1,'2018-05-24 15:21:57'),(74,46,1,1,1,'2018-05-24 15:21:57',1,'2018-05-24 15:21:57'),(75,46,2,0,1,'2018-05-24 15:21:57',1,'2018-05-24 15:21:57'),(76,47,1,1,1,'2018-05-24 15:21:57',1,'2018-05-24 15:21:57'),(77,47,2,0,1,'2018-05-24 15:21:57',1,'2018-05-24 15:21:57'),(78,48,1,1,1,'2018-05-24 15:21:57',1,'2018-05-24 15:21:57'),(79,48,2,0,1,'2018-05-24 15:21:57',1,'2018-05-24 15:21:57'),(83,49,1,1,1,'2018-05-25 11:59:25',1,'2018-05-25 11:59:25'),(84,49,2,0,1,'2018-05-25 11:59:25',1,'2018-05-25 11:59:25'),(85,50,1,1,1,'2018-05-25 11:59:25',1,'2018-05-25 11:59:25'),(86,50,2,0,1,'2018-05-25 11:59:25',1,'2018-05-25 11:59:25'),(87,51,1,1,1,'2018-05-25 11:59:25',1,'2018-05-25 11:59:25'),(88,51,2,0,1,'2018-05-25 11:59:25',1,'2018-05-25 11:59:25'),(89,52,1,1,1,'2018-05-25 11:59:25',1,'2018-05-25 11:59:25'),(90,52,2,0,1,'2018-05-25 11:59:25',1,'2018-05-25 11:59:25'),(91,53,1,1,1,'2018-05-25 11:59:25',1,'2018-05-25 11:59:25'),(92,53,2,0,1,'2018-05-25 11:59:25',1,'2018-05-25 11:59:25'),(93,54,1,1,1,'2018-05-25 11:59:25',1,'2018-05-25 11:59:25'),(94,54,2,0,1,'2018-05-25 11:59:25',1,'2018-05-25 11:59:25'),(95,55,1,1,1,'2018-06-11 09:57:35',1,'2018-06-11 09:57:35'),(96,55,2,0,1,'2018-06-11 09:57:35',1,'2018-06-11 09:57:35');
/*!40000 ALTER TABLE `modulointerfazrol` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `modulointerfazusuario`
--

LOCK TABLES `modulointerfazusuario` WRITE;
/*!40000 ALTER TABLE `modulointerfazusuario` DISABLE KEYS */;
INSERT INTO `modulointerfazusuario` VALUES (1,1,1,1,1,'2018-05-03 15:03:37',1,'2018-05-03 15:03:37'),(2,2,1,1,1,'2018-05-03 15:03:37',1,'2018-05-03 15:03:37'),(3,3,1,1,1,'2018-05-03 15:03:37',1,'2018-05-03 15:03:37'),(4,4,1,1,1,'2018-05-03 15:03:37',1,'2018-05-03 15:03:37'),(5,5,1,1,1,'2018-05-03 15:03:37',1,'2018-05-03 15:03:37'),(6,6,1,1,1,'2018-05-03 15:03:37',1,'2018-05-03 15:03:37'),(7,7,1,1,1,'2018-05-03 15:03:37',1,'2018-05-03 15:03:37'),(8,8,1,1,1,'2018-05-03 15:03:37',1,'2018-05-03 15:03:37'),(16,9,1,1,1,'2018-05-03 15:06:44',1,'2018-05-03 15:06:44'),(17,10,1,1,1,'2018-05-03 15:06:44',1,'2018-05-03 15:06:44'),(18,11,1,1,1,'2018-05-03 15:06:44',1,'2018-05-03 15:06:44'),(19,12,1,1,1,'2018-05-03 15:06:44',1,'2018-05-03 15:06:44'),(20,13,1,1,1,'2018-05-03 15:06:44',1,'2018-05-03 15:06:44'),(21,14,1,1,1,'2018-05-03 15:06:44',1,'2018-05-03 15:06:44'),(22,15,1,1,1,'2018-05-03 15:06:44',1,'2018-05-03 15:06:44'),(23,16,1,1,1,'2018-05-03 15:06:44',1,'2018-05-03 15:06:44'),(31,17,1,1,1,'2018-05-03 15:09:13',1,'2018-05-03 15:09:13'),(32,18,1,1,1,'2018-05-03 15:09:13',1,'2018-05-03 15:09:13'),(34,19,1,1,1,'2018-05-03 15:11:21',1,'2018-05-03 15:11:21'),(35,20,1,1,1,'2018-05-03 15:11:21',1,'2018-05-03 15:11:21'),(37,21,1,1,1,'2018-05-03 15:13:53',1,'2018-05-03 15:13:53'),(38,22,1,1,1,'2018-05-03 15:13:53',1,'2018-05-03 15:13:53'),(40,23,1,1,1,'2018-05-03 15:15:18',1,'2018-05-03 15:15:18'),(41,24,1,1,1,'2018-05-03 15:15:18',1,'2018-05-03 15:15:18'),(42,25,1,1,1,'2018-05-09 12:00:29',1,'2018-05-09 12:00:29'),(43,26,1,1,1,'2018-05-09 12:00:29',1,'2018-05-09 12:00:29'),(44,27,1,1,1,'2018-05-09 12:00:29',1,'2018-05-09 12:00:29'),(45,28,1,1,1,'2018-05-09 12:00:29',1,'2018-05-09 12:00:29'),(46,29,1,1,1,'2018-05-09 12:00:29',1,'2018-05-09 12:00:29'),(47,30,1,1,1,'2018-05-09 12:00:29',1,'2018-05-09 12:00:29'),(48,31,1,1,1,'2018-05-11 10:09:45',1,'2018-05-11 10:09:45'),(49,32,1,1,1,'2018-05-11 10:09:45',1,'2018-05-11 10:09:45'),(50,33,1,1,1,'2018-05-11 10:09:45',1,'2018-05-11 10:09:45'),(51,34,1,1,1,'2018-05-11 10:09:45',1,'2018-05-11 10:09:45'),(52,35,1,1,1,'2018-05-11 10:09:45',1,'2018-05-11 10:09:45'),(53,36,1,1,1,'2018-05-11 10:09:45',1,'2018-05-11 10:09:45'),(54,37,1,1,1,'2018-05-15 09:45:04',1,'2018-05-15 09:45:04'),(55,38,1,1,1,'2018-05-15 09:45:04',1,'2018-05-15 09:45:04'),(56,39,1,1,1,'2018-05-15 09:45:04',1,'2018-05-15 09:45:04'),(57,40,1,1,1,'2018-05-15 09:45:04',1,'2018-05-15 09:45:04'),(58,41,1,1,1,'2018-05-15 09:45:04',1,'2018-05-15 09:45:04'),(59,42,1,1,1,'2018-05-15 09:45:04',1,'2018-05-15 09:45:04'),(60,21,2,1,1,'2018-05-23 09:26:48',1,'2018-06-12 09:04:38'),(61,22,2,1,1,'2018-05-23 09:26:48',1,'2018-06-12 09:04:38'),(62,37,2,1,1,'2018-05-23 09:26:48',1,'2018-06-12 09:04:38'),(63,38,2,1,1,'2018-05-23 09:26:48',1,'2018-06-12 09:04:38'),(64,39,2,1,1,'2018-05-23 09:26:48',1,'2018-06-12 09:04:38'),(65,40,2,1,1,'2018-05-23 09:26:48',1,'2018-06-12 09:04:38'),(66,41,2,1,1,'2018-05-23 09:26:48',1,'2018-06-12 09:04:38'),(67,42,2,1,1,'2018-05-23 09:26:48',1,'2018-06-12 09:04:38'),(68,1,2,0,1,'2018-05-23 09:26:48',1,'2018-06-12 09:04:38'),(69,2,2,0,1,'2018-05-23 09:26:48',1,'2018-06-12 09:04:38'),(70,3,2,0,1,'2018-05-23 09:26:48',1,'2018-06-12 09:04:38'),(71,4,2,0,1,'2018-05-23 09:26:48',1,'2018-06-12 09:04:38'),(72,5,2,0,1,'2018-05-23 09:26:48',1,'2018-06-12 09:04:38'),(73,6,2,0,1,'2018-05-23 09:26:48',1,'2018-06-12 09:04:38'),(74,7,2,0,1,'2018-05-23 09:26:48',1,'2018-06-12 09:04:38'),(75,8,2,0,1,'2018-05-23 09:26:48',1,'2018-06-12 09:04:38'),(76,9,2,0,1,'2018-05-23 09:26:48',1,'2018-06-12 09:04:38'),(77,10,2,0,1,'2018-05-23 09:26:48',1,'2018-06-12 09:04:38'),(78,11,2,0,1,'2018-05-23 09:26:48',1,'2018-06-12 09:04:38'),(79,12,2,0,1,'2018-05-23 09:26:48',1,'2018-06-12 09:04:38'),(80,13,2,0,1,'2018-05-23 09:26:48',1,'2018-06-12 09:04:38'),(81,14,2,0,1,'2018-05-23 09:26:48',1,'2018-06-12 09:04:38'),(82,15,2,0,1,'2018-05-23 09:26:48',1,'2018-06-12 09:04:38'),(83,16,2,0,1,'2018-05-23 09:26:48',1,'2018-06-12 09:04:38'),(84,17,2,0,1,'2018-05-23 09:26:48',1,'2018-06-12 09:04:38'),(85,18,2,0,1,'2018-05-23 09:26:48',1,'2018-06-12 09:04:38'),(86,19,2,0,1,'2018-05-23 09:26:48',1,'2018-06-12 09:04:38'),(87,20,2,0,1,'2018-05-23 09:26:48',1,'2018-06-12 09:04:38'),(88,23,2,0,1,'2018-05-23 09:26:48',1,'2018-06-12 09:04:38'),(89,24,2,0,1,'2018-05-23 09:26:48',1,'2018-06-12 09:04:38'),(90,25,2,0,1,'2018-05-23 09:26:48',1,'2018-06-12 09:04:38'),(91,26,2,0,1,'2018-05-23 09:26:48',1,'2018-06-12 09:04:38'),(92,27,2,0,1,'2018-05-23 09:26:48',1,'2018-06-12 09:04:38'),(93,28,2,0,1,'2018-05-23 09:26:48',1,'2018-06-12 09:04:38'),(94,29,2,0,1,'2018-05-23 09:26:48',1,'2018-06-12 09:04:38'),(95,30,2,0,1,'2018-05-23 09:26:48',1,'2018-06-12 09:04:38'),(96,31,2,0,1,'2018-05-23 09:26:48',1,'2018-06-12 09:04:38'),(97,32,2,0,1,'2018-05-23 09:26:48',1,'2018-06-12 09:04:38'),(98,33,2,0,1,'2018-05-23 09:26:48',1,'2018-06-12 09:04:38'),(99,34,2,0,1,'2018-05-23 09:26:48',1,'2018-06-12 09:04:38'),(100,35,2,0,1,'2018-05-23 09:26:48',1,'2018-06-12 09:04:38'),(101,36,2,0,1,'2018-05-23 09:26:48',1,'2018-06-12 09:04:38'),(102,43,1,1,1,'2018-05-24 15:21:57',1,'2018-05-24 15:21:57'),(103,43,2,0,1,'2018-05-24 15:21:57',1,'2018-06-12 09:04:38'),(104,44,1,1,1,'2018-05-24 15:21:57',1,'2018-05-24 15:21:57'),(105,44,2,0,1,'2018-05-24 15:21:57',1,'2018-06-12 09:04:38'),(106,45,1,1,1,'2018-05-24 15:21:57',1,'2018-05-24 15:21:57'),(107,45,2,0,1,'2018-05-24 15:21:57',1,'2018-06-12 09:04:38'),(108,46,1,1,1,'2018-05-24 15:21:57',1,'2018-05-24 15:21:57'),(109,46,2,0,1,'2018-05-24 15:21:57',1,'2018-06-12 09:04:38'),(110,47,1,1,1,'2018-05-24 15:21:57',1,'2018-05-24 15:21:57'),(111,47,2,0,1,'2018-05-24 15:21:57',1,'2018-06-12 09:04:38'),(112,48,1,1,1,'2018-05-24 15:21:57',1,'2018-05-24 15:21:57'),(113,48,2,0,1,'2018-05-24 15:21:57',1,'2018-06-12 09:04:38'),(117,49,1,1,1,'2018-05-25 11:59:25',1,'2018-05-25 11:59:25'),(118,49,2,0,1,'2018-05-25 11:59:25',1,'2018-06-12 09:04:38'),(119,50,1,1,1,'2018-05-25 11:59:25',1,'2018-05-25 11:59:25'),(120,50,2,0,1,'2018-05-25 11:59:25',1,'2018-06-12 09:04:38'),(121,51,1,1,1,'2018-05-25 11:59:25',1,'2018-05-25 11:59:25'),(122,51,2,0,1,'2018-05-25 11:59:25',1,'2018-06-12 09:04:38'),(123,52,1,1,1,'2018-05-25 11:59:25',1,'2018-05-25 11:59:25'),(124,52,2,0,1,'2018-05-25 11:59:25',1,'2018-06-12 09:04:38'),(125,53,1,1,1,'2018-05-25 11:59:25',1,'2018-05-25 11:59:25'),(126,53,2,0,1,'2018-05-25 11:59:25',1,'2018-06-12 09:04:38'),(127,54,1,1,1,'2018-05-25 11:59:25',1,'2018-05-25 11:59:25'),(128,54,2,0,1,'2018-05-25 11:59:25',1,'2018-06-12 09:04:38'),(129,55,1,1,1,'2018-06-11 09:57:35',1,'2018-06-11 09:57:35'),(130,55,2,0,1,'2018-06-11 09:57:35',1,'2018-06-12 09:04:38');
/*!40000 ALTER TABLE `modulointerfazusuario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `moneda`
--

LOCK TABLES `moneda` WRITE;
/*!40000 ALTER TABLE `moneda` DISABLE KEYS */;
/*!40000 ALTER TABLE `moneda` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `periodo`
--

LOCK TABLES `periodo` WRITE;
/*!40000 ALTER TABLE `periodo` DISABLE KEYS */;
/*!40000 ALTER TABLE `periodo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `privilegio`
--

LOCK TABLES `privilegio` WRITE;
/*!40000 ALTER TABLE `privilegio` DISABLE KEYS */;
INSERT INTO `privilegio` VALUES (1,1,'Acceso',1,'2018-05-03 14:46:13',1,'2018-05-03 14:46:13'),(2,1,'Agregar',1,'2018-05-03 14:46:13',1,'2018-05-03 14:46:13'),(3,1,'Actualizar',1,'2018-05-03 14:46:13',1,'2018-05-03 14:46:13'),(4,1,'Eliminar',1,'2018-05-03 14:46:13',1,'2018-05-03 14:46:13'),(5,1,'Visualizar',1,'2018-05-03 14:46:13',1,'2018-05-03 14:46:13'),(6,1,'Imprimir',1,'2018-05-03 14:46:13',1,'2018-05-03 14:46:13'),(7,1,'Nuevo',1,'2018-05-03 14:46:13',1,'2018-05-03 14:46:13'),(8,1,'Modificar privilegio',1,'2018-05-03 14:46:13',1,'2018-05-03 14:46:13'),(9,2,'Acceso',1,'2018-05-03 15:06:44',1,'2018-05-03 15:06:44'),(10,2,'Agregar',1,'2018-05-03 15:06:44',1,'2018-05-03 15:06:44'),(11,2,'Actualizar',1,'2018-05-03 15:06:44',1,'2018-05-03 15:06:44'),(12,2,'Eliminar',1,'2018-05-03 15:06:44',1,'2018-05-03 15:06:44'),(13,2,'Visualizar',1,'2018-05-03 15:06:44',1,'2018-05-03 15:06:44'),(14,2,'Imprimir',1,'2018-05-03 15:06:44',1,'2018-05-03 15:06:44'),(15,2,'Nuevo',1,'2018-05-03 15:06:44',1,'2018-05-03 15:06:44'),(16,2,'Modificar privilegio',1,'2018-05-03 15:06:44',1,'2018-05-03 15:06:44'),(17,3,'Acceso',1,'2018-05-03 15:09:13',1,'2018-05-03 15:09:13'),(18,3,'Actualizar',1,'2018-05-03 15:09:13',1,'2018-05-03 15:09:13'),(19,4,'Acceso',1,'2018-05-03 15:11:21',1,'2018-05-03 15:11:21'),(20,4,'Actualizar',1,'2018-05-03 15:11:21',1,'2018-05-03 15:11:21'),(21,5,'Acceso',1,'2018-05-03 15:13:53',1,'2018-05-03 15:13:53'),(22,5,'Respaldar',1,'2018-05-03 15:13:53',1,'2018-05-03 15:13:53'),(23,6,'Acceso',1,'2018-05-03 15:15:18',1,'2018-05-03 15:15:18'),(24,6,'Restaurar',1,'2018-05-03 15:15:18',1,'2018-05-03 15:15:18'),(25,7,'Acceso',1,'2018-05-09 12:00:29',1,'2018-05-09 12:00:29'),(26,7,'Actualizar',1,'2018-05-09 12:00:29',1,'2018-05-09 12:00:29'),(27,7,'Eliminar',1,'2018-05-09 12:00:29',1,'2018-05-09 12:00:29'),(28,7,'Visualizar',1,'2018-05-09 12:00:29',1,'2018-05-09 12:00:29'),(29,7,'Imprimir',1,'2018-05-09 12:00:29',1,'2018-05-09 12:00:29'),(30,7,'Nuevo',1,'2018-05-09 12:00:29',1,'2018-05-09 12:00:29'),(31,8,'Acceso',1,'2018-05-11 10:09:45',1,'2018-05-11 10:09:45'),(32,8,'Actualizar',1,'2018-05-11 10:09:45',1,'2018-05-11 10:09:45'),(33,8,'Eliminar',1,'2018-05-11 10:09:45',1,'2018-05-11 10:09:45'),(34,8,'Visualizar',1,'2018-05-11 10:09:45',1,'2018-05-11 10:09:45'),(35,8,'Imprimir',1,'2018-05-11 10:09:45',1,'2018-05-11 10:09:45'),(36,8,'Nuevo',1,'2018-05-11 10:09:45',1,'2018-05-11 10:09:45'),(37,9,'Acceso',1,'2018-05-15 09:45:04',1,'2018-05-15 09:45:04'),(38,9,'Actualizar',1,'2018-05-15 09:45:04',1,'2018-05-15 09:45:04'),(39,9,'Eliminar',1,'2018-05-15 09:45:04',1,'2018-05-15 09:45:04'),(40,9,'Visualizar',1,'2018-05-15 09:45:04',1,'2018-05-15 09:45:04'),(41,9,'Imprimir',1,'2018-05-15 09:45:04',1,'2018-05-15 09:45:04'),(42,9,'Nuevo',1,'2018-05-15 09:45:04',1,'2018-05-15 09:45:04'),(43,10,'Acceso',1,'2018-05-24 15:21:57',1,'2018-05-24 15:21:57'),(44,10,'Actualizar',1,'2018-05-24 15:21:57',1,'2018-05-24 15:21:57'),(45,10,'Eliminar',1,'2018-05-24 15:21:57',1,'2018-05-24 15:21:57'),(46,10,'Visualizar',1,'2018-05-24 15:21:57',1,'2018-05-24 15:21:57'),(47,10,'Imprimir',1,'2018-05-24 15:21:57',1,'2018-05-24 15:21:57'),(48,10,'Nuevo',1,'2018-05-24 15:21:57',1,'2018-05-24 15:21:57'),(49,11,'Acceso',1,'2018-05-25 11:59:25',1,'2018-05-25 11:59:25'),(50,11,'Actualizar',1,'2018-05-25 11:59:25',1,'2018-05-25 11:59:25'),(51,11,'Eliminar',1,'2018-05-25 11:59:25',1,'2018-05-25 11:59:25'),(52,11,'Visualizar',1,'2018-05-25 11:59:25',1,'2018-05-25 11:59:25'),(53,11,'Imprimir',1,'2018-05-25 11:59:25',1,'2018-05-25 11:59:25'),(54,11,'Nuevo',1,'2018-05-25 11:59:25',1,'2018-05-25 11:59:25'),(55,11,'Grabar Datos',1,'2018-06-11 09:57:35',1,'2018-06-11 09:57:35');
/*!40000 ALTER TABLE `privilegio` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `rol`
--

LOCK TABLES `rol` WRITE;
/*!40000 ALTER TABLE `rol` DISABLE KEYS */;
INSERT INTO `rol` VALUES (1,'Administrador','','ACTIVO',1,'2018-05-03 09:26:34',1,'2018-05-03 09:26:34'),(2,'Usuario','Cuenta de usuario sin mucho privilegios','ACTIVO',1,'2018-05-23 09:11:48',1,'2018-05-23 09:25:07');
/*!40000 ALTER TABLE `rol` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `tansacciondetalle_banco`
--

LOCK TABLES `tansacciondetalle_banco` WRITE;
/*!40000 ALTER TABLE `tansacciondetalle_banco` DISABLE KEYS */;
/*!40000 ALTER TABLE `tansacciondetalle_banco` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `tasadecambio`
--

LOCK TABLES `tasadecambio` WRITE;
/*!40000 ALTER TABLE `tasadecambio` DISABLE KEYS */;
/*!40000 ALTER TABLE `tasadecambio` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `tipodecuenta`
--

LOCK TABLES `tipodecuenta` WRITE;
/*!40000 ALTER TABLE `tipodecuenta` DISABLE KEYS */;
INSERT INTO `tipodecuenta` VALUES (1,'Cuenta'),(2,'SubCuenta');
/*!40000 ALTER TABLE `tipodecuenta` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `tipodetransaccion`
--

LOCK TABLES `tipodetransaccion` WRITE;
/*!40000 ALTER TABLE `tipodetransaccion` DISABLE KEYS */;
INSERT INTO `tipodetransaccion` VALUES (1,'Egreso',1,'2018-05-24 16:02:03',1,'2018-05-25 09:50:46'),(2,'Ingreso',1,'2018-05-24 16:06:53',1,'2018-05-24 16:06:53'),(3,'Diario',1,'2018-06-01 16:22:22',1,'2018-06-01 16:22:22');
/*!40000 ALTER TABLE `tipodetransaccion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `transaccion_cierre`
--

LOCK TABLES `transaccion_cierre` WRITE;
/*!40000 ALTER TABLE `transaccion_cierre` DISABLE KEYS */;
/*!40000 ALTER TABLE `transaccion_cierre` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `transaccion_cierre_detalle`
--

LOCK TABLES `transaccion_cierre_detalle` WRITE;
/*!40000 ALTER TABLE `transaccion_cierre_detalle` DISABLE KEYS */;
/*!40000 ALTER TABLE `transaccion_cierre_detalle` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `transacciondetalle`
--

LOCK TABLES `transacciondetalle` WRITE;
/*!40000 ALTER TABLE `transacciondetalle` DISABLE KEYS */;
/*!40000 ALTER TABLE `transacciondetalle` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `transacciones`
--

LOCK TABLES `transacciones` WRITE;
/*!40000 ALTER TABLE `transacciones` DISABLE KEYS */;
/*!40000 ALTER TABLE `transacciones` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `usuario`
--

LOCK TABLES `usuario` WRITE;
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
INSERT INTO `usuario` VALUES (1,1,'Servicios TRIGGER','Administrador','wno5GbHqs4NgaI1WepvsaA==','trigger@cablenet.com.ni','ACTIVO',1,'2018-05-03 09:26:34',1,'2018-05-03 09:26:34'),(2,2,'Usuario Gasolinera Esquipulas','Ugasolinera','2dP137VNVneIlrSomwCp9A==','gasolinera@gmail.com','ACTIVO',1,'2018-05-23 09:26:48',1,'2018-06-12 09:04:36');
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
/*!50003 DROP PROCEDURE IF EXISTS `GrabarDatos` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_ALL_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_AUTO_CREATE_USER' */ ;
DELIMITER ;;
CREATE DEFINER=`STDataBase`@`%` PROCEDURE `GrabarDatos`(IdCuenta_ int)
BEGIN

DECLARE EXIT handler for sqlexception
BEGIN
	rollback;
END;

DECLARE EXIT handler for sqlwarning
begin
	rollback;
end;

start transaction;

	DROP TABLE IF EXISTS tmpTransaccion;

	create temporary table tmpTransaccion(
    ID INT primary key NOT NULL AUTO_INCREMENT,
    idTransaccionDetalle int, idTansaccionDetalle_Banco int, 
    NoCuenta int, idTransacciones int, idCuenta varchar(50),
    DescCuenta varchar(5000), Debe Decimal(18,2), Haber Decimal(18,2),
	ReferenciaBanco varchar(100), DescBanco varchar(5000),
    EsCuentaDeBanco int , NivelDeLaCuenta int
    );
    
    insert into tmpTransaccion
    Select 0,
	tt.idTransaccionDetalle, ifnull( tdb.idTansaccionDetalle_Banco, 0) as 'idTansaccionDetalle_Banco', tt.NoCuenta, tt.idTransacciones, c.idCuenta,c.DescCuenta, tt.Debe, tt.Haber,
	ifnull(tdb.ReferenciaBanco, '') as 'RefBanco', ifnull(tdb.DescBanco, '') as 'ConceptoDeBanco',
	EvaLuarSiEsCuentaDeBanco(c.NoCuenta) as 'EsCuentaDeBanco', c.NivelCuenta
	from transacciondetalle as tt
	inner join transacciones as t on t.idTransacciones = tt.idTransacciones
	inner join cuenta as c on c.NoCuenta = tt.NoCuenta
	left join tansacciondetalle_banco as tdb on tdb.idTransaccionDetalle = tt.idTransaccionDetalle
	where tt.idTransacciones = IdCuenta_;
    
    set @x = 1;
    
    while @x <= (Select max(id) from tmpTransaccion) do
    
		set @NoCuenta = (select NoCuenta from tmpTransaccion where ID = @x);
        
        set @x = @x + 1;
    
    end while;
    
    Select * from tmpTransaccion;

commit;
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

-- Dump completed on 2018-06-12  9:58:39
