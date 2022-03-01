-- MySQL Administrator dump 1.4
--
-- ------------------------------------------------------
-- Server version	5.0.27-community-nt


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


--
-- Create schema crm
--

CREATE DATABASE IF NOT EXISTS crm;
USE crm;

--
-- Temporary table structure for view `currentsalesview`
--
DROP TABLE IF EXISTS `currentsalesview`;
DROP VIEW IF EXISTS `currentsalesview`;
CREATE TABLE `currentsalesview` (
  `dyname` char(12),
  `salesum` decimal(41,4)
);

--
-- Temporary table structure for view `jfview`
--
DROP TABLE IF EXISTS `jfview`;
DROP VIEW IF EXISTS `jfview`;
CREATE TABLE `jfview` (
  `id` int(10),
  `vipnum` char(5),
  `xfjf` int(10),
  `vipname` char(8),
  `viptel` char(11),
  `vipmob` char(11),
  `vipwork` varchar(100),
  `viphome` varchar(100)
);

--
-- Temporary table structure for view `reportxiaofei`
--
DROP TABLE IF EXISTS `reportxiaofei`;
DROP VIEW IF EXISTS `reportxiaofei`;
CREATE TABLE `reportxiaofei` (
  `id` int(10),
  `VipNum` char(5),
  `XfDZ` varchar(30),
  `ObNameDm` char(5),
  `UnitPrice` double,
  `XfNum` int(10),
  `XfSuM` double,
  `dmdm` char(2),
  `obname` varchar(50),
  `d` varchar(10),
  `h` varchar(2),
  `splb` varchar(1)
);

--
-- Definition of table `callcenter`
--

DROP TABLE IF EXISTS `callcenter`;
CREATE TABLE `callcenter` (
  `ID` int(10) NOT NULL auto_increment,
  `VipNum` char(5) default NULL,
  `CallNum` char(12) default NULL,
  `CallDate` datetime default NULL,
  `CallTime` char(5) default NULL,
  `CallText` varchar(100) default NULL,
  PRIMARY KEY  (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `callcenter`
--

/*!40000 ALTER TABLE `callcenter` DISABLE KEYS */;
/*!40000 ALTER TABLE `callcenter` ENABLE KEYS */;


--
-- Definition of table `currentsales`
--

DROP TABLE IF EXISTS `currentsales`;
CREATE TABLE `currentsales` (
  `Id` int(10) NOT NULL auto_increment,
  `dyname` char(12) NOT NULL,
  `salesum` decimal(19,4) default NULL,
  `saledate` datetime default NULL,
  PRIMARY KEY  (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `currentsales`
--

/*!40000 ALTER TABLE `currentsales` DISABLE KEYS */;
INSERT INTO `currentsales` (`Id`,`dyname`,`salesum`,`saledate`) VALUES 
 (1,'caihexin','160.0000','2009-11-10 14:28:13'),
 (2,'caihexin','165.5000','2009-11-10 14:29:23'),
 (3,'caihexin','340.0000','2009-11-10 14:32:02'),
 (4,'caihexin','11.0000','2009-11-10 14:32:24'),
 (5,'caihexin','285.0000','2009-11-10 14:36:09'),
 (6,'caihexin','20.0000','2009-11-11 15:43:22'),
 (7,'caihexin','45.0000','2009-11-11 15:43:28'),
 (8,'caihexin','11.0000','2009-11-16 17:32:03'),
 (9,'caihexin','122.0000','2009-11-17 18:06:19'),
 (10,'caihexin','60.0000','2009-11-17 18:16:58'),
 (11,'caihexin','120.0000','2009-11-18 17:12:59'),
 (12,'caihexin','200.0000','2009-11-18 17:27:42'),
 (13,'caihexin','235.0000','2009-11-18 17:40:04'),
 (14,'caihexin','170.5000','2009-11-22 08:29:33'),
 (15,'caihexin','100.0000','2009-11-22 09:33:20'),
 (16,'caihexin','200.0000','2009-11-22 09:35:07'),
 (17,'caihexin','220.0000','2009-11-22 09:40:54'),
 (18,'caihexin','70.0000','2009-11-22 10:01:11'),
 (19,'caihexin','140.5000','2009-11-22 10:43:29'),
 (20,'caihexin','35.0000','2009-11-24 12:39:05');
INSERT INTO `currentsales` (`Id`,`dyname`,`salesum`,`saledate`) VALUES 
 (21,'caihexin','120.0000','2009-11-24 13:18:33'),
 (22,'caihexin','143.0000','2009-11-24 13:20:41'),
 (23,'caihexin','34.0000','2009-11-24 13:35:23'),
 (24,'caihexin','30.0000','2009-11-24 13:36:48'),
 (25,'caihexin','190.0000','2009-11-24 13:44:51'),
 (26,'caihexin','68.0000','2009-11-24 13:45:46'),
 (27,'caihexin','42.0000','2009-11-24 13:58:24'),
 (28,'caihexin','23.0000','2009-12-30 09:54:26'),
 (29,'caihexin','32.0000','2009-12-30 09:58:24'),
 (30,'caihexin','32.0000','2009-12-30 10:01:00'),
 (31,'caihexin','32.0000','2009-12-30 10:03:10'),
 (32,'caihexin','33.0000','2009-12-30 10:05:43'),
 (33,'caihexin','12.0000','2009-12-30 10:06:20'),
 (34,'caihexin','24.0000','2009-12-30 10:06:38'),
 (35,'caihexin','26.3400','2009-12-30 10:16:09'),
 (36,'caihexin','55.0000','2010-02-25 22:21:33'),
 (37,'caihexin','1212.0000','2010-02-27 11:02:15'),
 (38,'caihexin','1200.0000','2010-02-27 11:40:17'),
 (39,'caihexin','120.0000','2010-02-27 11:40:35'),
 (40,'caihexin','120.0000','2010-02-27 11:40:53');
INSERT INTO `currentsales` (`Id`,`dyname`,`salesum`,`saledate`) VALUES 
 (41,'caihexin','110.0000','2010-02-27 11:41:06'),
 (42,'caihexin','10.0000','2010-02-27 15:11:11'),
 (43,'caihexin','10.0000','2010-02-27 15:13:03'),
 (44,'caihexin','11.0000','2010-02-27 16:00:18'),
 (45,'caihexin','175.0000','2010-04-12 21:34:18'),
 (46,'caihexin','704.0000','2010-04-12 21:34:48'),
 (47,'caihexin','140.0000','2010-04-12 22:04:50');
/*!40000 ALTER TABLE `currentsales` ENABLE KEYS */;


--
-- Definition of table `historyinout`
--

DROP TABLE IF EXISTS `historyinout`;
CREATE TABLE `historyinout` (
  `Id` int(10) NOT NULL,
  `storedmOut` char(2) default NULL,
  `storedmIn` char(2) default NULL,
  `obnamedm` char(5) default NULL,
  `obNum` int(10) default NULL,
  `obDetail` varchar(20) default NULL,
  `ygout` char(8) default NULL,
  `ygin` char(8) default NULL,
  `inNum` int(10) default NULL,
  `outTime` char(5) default NULL,
  `inTime` char(5) default NULL,
  `outdate` datetime default NULL,
  `indate` datetime default NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `historyinout`
--

/*!40000 ALTER TABLE `historyinout` DISABLE KEYS */;
/*!40000 ALTER TABLE `historyinout` ENABLE KEYS */;


--
-- Definition of table `icmoney`
--

DROP TABLE IF EXISTS `icmoney`;
CREATE TABLE `icmoney` (
  `id` int(10) unsigned NOT NULL auto_increment,
  `saledate` datetime NOT NULL,
  `dyname` char(12) NOT NULL,
  `dmdm` char(2) NOT NULL,
  `icvalue` double NOT NULL,
  `balance` varchar(12) NOT NULL,
  `icnum` varchar(15) NOT NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `icmoney`
--

/*!40000 ALTER TABLE `icmoney` DISABLE KEYS */;
INSERT INTO `icmoney` (`id`,`saledate`,`dyname`,`dmdm`,`icvalue`,`balance`,`icnum`) VALUES 
 (4,'2010-05-05 00:00:00','caihexin','1',100,'50','10001'),
 (5,'2010-05-05 00:00:00','caihexin','1',100,'50','10002'),
 (6,'2010-05-04 00:00:00','caihexin','1',100,'50','10002');
/*!40000 ALTER TABLE `icmoney` ENABLE KEYS */;


--
-- Definition of table `inoutstore`
--

DROP TABLE IF EXISTS `inoutstore`;
CREATE TABLE `inoutstore` (
  `Id` int(10) NOT NULL auto_increment,
  `storedmOut` char(2) default NULL,
  `storedmIn` char(2) default NULL,
  `obnamedm` char(5) default NULL,
  `obNum` int(10) default NULL,
  `obDetail` varchar(20) default NULL,
  `ygout` char(8) default NULL,
  `ygin` char(8) default NULL,
  `inNum` int(10) default NULL,
  `outTime` char(5) default NULL,
  `inTime` char(5) default NULL,
  `outdate` datetime default NULL,
  `indate` datetime default NULL,
  PRIMARY KEY  (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `inoutstore`
--

/*!40000 ALTER TABLE `inoutstore` DISABLE KEYS */;
/*!40000 ALTER TABLE `inoutstore` ENABLE KEYS */;


--
-- Definition of table `insidebase`
--

DROP TABLE IF EXISTS `insidebase`;
CREATE TABLE `insidebase` (
  `ID` int(10) NOT NULL auto_increment,
  `DyName` char(12) NOT NULL,
  `Dysecure` char(8) NOT NULL,
  `DySFZ` char(18) default NULL,
  `DyEmail` char(50) default NULL,
  `DyTel` char(11) default NULL,
  `DyMob` char(11) default NULL,
  `DyHome` char(100) default NULL,
  `rulename` char(10) NOT NULL,
  `Birthday` datetime default NULL,
  `Dmdm` char(2) NOT NULL,
  PRIMARY KEY  (`ID`),
  UNIQUE KEY `skey` (`DyName`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `insidebase`
--

/*!40000 ALTER TABLE `insidebase` DISABLE KEYS */;
INSERT INTO `insidebase` (`ID`,`DyName`,`Dysecure`,`DySFZ`,`DyEmail`,`DyTel`,`DyMob`,`DyHome`,`rulename`,`Birthday`,`Dmdm`) VALUES 
 (50,'caihexin','12345','321025740908681','caihexin@gmail.com','52150331','13905179400','kis123jsafdss12','2','2006-11-16 00:00:00','1'),
 (51,'xhy','12345','','','','','','3',NULL,'1'),
 (52,'cx','12345','','','','','','2',NULL,'1');
/*!40000 ALTER TABLE `insidebase` ENABLE KEYS */;


--
-- Definition of table `insiderole`
--

DROP TABLE IF EXISTS `insiderole`;
CREATE TABLE `insiderole` (
  `ID` int(10) NOT NULL auto_increment,
  `RuleName` char(10) default NULL,
  `RuleNum` int(10) default NULL,
  PRIMARY KEY  (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `insiderole`
--

/*!40000 ALTER TABLE `insiderole` DISABLE KEYS */;
/*!40000 ALTER TABLE `insiderole` ENABLE KEYS */;


--
-- Definition of table `insiderule`
--

DROP TABLE IF EXISTS `insiderule`;
CREATE TABLE `insiderule` (
  `ID` int(10) NOT NULL auto_increment,
  `RuleNum` int(10) default NULL,
  PRIMARY KEY  (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `insiderule`
--

/*!40000 ALTER TABLE `insiderule` DISABLE KEYS */;
/*!40000 ALTER TABLE `insiderule` ENABLE KEYS */;


--
-- Definition of table `instore`
--

DROP TABLE IF EXISTS `instore`;
CREATE TABLE `instore` (
  `id` int(11) NOT NULL auto_increment,
  `storeDm` char(2) NOT NULL,
  `obNameDm` char(5) NOT NULL,
  `num` int(11) NOT NULL,
  `inTime` datetime NOT NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `instore`
--

/*!40000 ALTER TABLE `instore` DISABLE KEYS */;
/*!40000 ALTER TABLE `instore` ENABLE KEYS */;


--
-- Definition of table `jifenbase`
--

DROP TABLE IF EXISTS `jifenbase`;
CREATE TABLE `jifenbase` (
  `ID` int(10) NOT NULL auto_increment,
  `JFleibi` varchar(20) default NULL,
  `JFSum` int(10) default NULL,
  PRIMARY KEY  (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `jifenbase`
--

/*!40000 ALTER TABLE `jifenbase` DISABLE KEYS */;
/*!40000 ALTER TABLE `jifenbase` ENABLE KEYS */;


--
-- Definition of table `ob`
--

DROP TABLE IF EXISTS `ob`;
CREATE TABLE `ob` (
  `ID` int(10) NOT NULL auto_increment,
  `obnamedm` char(5) NOT NULL,
  `obname` varchar(50) default NULL,
  `unitprice` decimal(19,4) default NULL,
  PRIMARY KEY  USING BTREE (`ID`),
  UNIQUE KEY `Index_2` (`obnamedm`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `ob`
--

/*!40000 ALTER TABLE `ob` DISABLE KEYS */;
INSERT INTO `ob` (`ID`,`obnamedm`,`obname`,`unitprice`) VALUES 
 (56,'112','A1','11.0000'),
 (57,'1111','A1','11.0000'),
 (58,'1122','A1','110000.0000'),
 (59,'2112','A1','11.0000'),
 (60,'4214','A1','11.0000'),
 (61,'214','A1','123.0000'),
 (62,'1010','abcd','15.0000'),
 (63,'198','âµÍ·','1000.0000'),
 (64,'10011','113','13.0000'),
 (65,'1110','as','1000.0000'),
 (66,'555','555','0.0000'),
 (67,'666','asd','666.0000'),
 (68,'77','sd','77.0000'),
 (69,'118','222','333.0000'),
 (70,'120','123','23.0000'),
 (71,'122','321','111.0000'),
 (72,'119','2cai','33.0000'),
 (73,'111','123','12.0000'),
 (74,'132','','0.0000'),
 (75,'231','µçÊÓ»ú','300.0000'),
 (76,'100','sd1','123.0000'),
 (77,'1011','222','22.0000'),
 (78,'11111','11','11.0000'),
 (79,'567','df45','23.0000'),
 (80,'10013','112','12.0000'),
 (81,'12221','caihexin','123.0000'),
 (82,'10102','Ð¡ÈÈ¹·Ãæ°ü','1.0000'),
 (83,'10100','Ä«Î÷¸çÃæ°ü','2.0000'),
 (84,'10101','Ð¡ÈÈ¹·Ãæ°ü','1.0000'),
 (85,'15100','Ò®ÄÌÃæ°ü','1.5000'),
 (86,'1445','A122','14.0000');
INSERT INTO `ob` (`ID`,`obnamedm`,`obname`,`unitprice`) VALUES 
 (87,'19802','cdf','13.0000'),
 (88,'10118','wer1','23.0000'),
 (89,'10119','cf','24.0000'),
 (90,'10211','w23','23.0000'),
 (91,'88','dog1','20.0000'),
 (92,'89','dog2','20.0000'),
 (93,'899','dog3','20.0000'),
 (94,'898','wei','30.0000'),
 (95,'888','ji','300.0000'),
 (96,'878','wang','45.0000'),
 (97,'10041','Å£ÄÌ','12.0000'),
 (98,'17171','test','23.0000'),
 (99,'12897','ma','10002.0000'),
 (100,'10456','Test5','112.3500'),
 (101,'10545','news1','120.5000'),
 (102,'11115','dfdf','130.0000'),
 (103,'30001','ÆäÈ¡ÓÑ±Ø¶ËÒÓ','10.0000'),
 (104,'45000','´ó±¾Óª','20.0000');
/*!40000 ALTER TABLE `ob` ENABLE KEYS */;


--
-- Definition of table `rebates`
--

DROP TABLE IF EXISTS `rebates`;
CREATE TABLE `rebates` (
  `id` int(10) unsigned NOT NULL auto_increment,
  `dyname` varchar(12) NOT NULL,
  `saledate` datetime NOT NULL,
  `vipnum` varchar(5) NOT NULL,
  `dmdm` varchar(2) NOT NULL,
  `rebates` double NOT NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='折扣';

--
-- Dumping data for table `rebates`
--

/*!40000 ALTER TABLE `rebates` DISABLE KEYS */;
INSERT INTO `rebates` (`id`,`dyname`,`saledate`,`vipnum`,`dmdm`,`rebates`) VALUES 
 (1,'caihexin','2009-11-10 00:00:00','10001','1',0),
 (2,'caihexin','2009-11-10 00:00:00','10001','1',0),
 (3,'caihexin','2009-11-10 00:00:00','10001','1',0),
 (4,'caihexin','2009-11-10 00:00:00','10002','1',0),
 (5,'caihexin','2009-11-10 00:00:00','10001','1',0),
 (6,'caihexin','2009-11-11 00:00:00','10002','1',0),
 (7,'caihexin','2009-11-11 00:00:00','10001','1',0),
 (8,'caihexin','2009-11-16 00:00:00','10001','1',0),
 (9,'caihexin','2009-11-17 00:00:00','10001','1',0),
 (10,'caihexin','2009-11-17 00:00:00','10001','1',0),
 (11,'caihexin','2009-11-18 00:00:00','10001','1',0),
 (12,'caihexin','2009-11-18 00:00:00','10001','1',0),
 (13,'caihexin','2009-11-18 00:00:00','10001','1',0),
 (14,'caihexin','2009-11-22 00:00:00','10001','1',0),
 (15,'caihexin','2009-11-22 00:00:00','10001','1',0),
 (16,'caihexin','2009-11-22 00:00:00','10002','1',0),
 (17,'caihexin','2009-11-22 00:00:00','10001','1',0),
 (18,'caihexin','2009-11-22 00:00:00','10001','1',0),
 (19,'caihexin','2009-11-22 00:00:00','10001','1',0);
INSERT INTO `rebates` (`id`,`dyname`,`saledate`,`vipnum`,`dmdm`,`rebates`) VALUES 
 (20,'caihexin','2009-11-24 00:00:00','10001','1',0),
 (21,'caihexin','2009-11-24 00:00:00','10002','1',0),
 (22,'caihexin','2009-11-24 00:00:00','10001','1',0),
 (23,'caihexin','2009-11-24 00:00:00','10001','1',0),
 (24,'caihexin','2009-11-24 00:00:00','10001','1',0),
 (25,'caihexin','2009-11-24 00:00:00','10001','1',0),
 (26,'caihexin','2009-11-24 00:00:00','10001','1',0),
 (27,'caihexin','2009-11-24 00:00:00','10002','1',0),
 (28,'caihexin','2009-12-30 00:00:00','10001','1',0),
 (29,'caihexin','2009-12-30 00:00:00','10001','1',0),
 (30,'caihexin','2009-12-30 00:00:00','10001','1',0),
 (31,'caihexin','2009-12-30 00:00:00','10002','1',0),
 (32,'caihexin','2009-12-30 00:00:00','10002','1',0),
 (33,'caihexin','2009-12-30 00:00:00','10003','1',0),
 (34,'caihexin','2009-12-30 00:00:00','10004','1',0),
 (35,'caihexin','2009-12-30 00:00:00','10001','1',0),
 (36,'caihexin','2010-02-25 00:00:00','10001','1',0),
 (37,'caihexin','2010-02-27 00:00:00','10001','1',0);
INSERT INTO `rebates` (`id`,`dyname`,`saledate`,`vipnum`,`dmdm`,`rebates`) VALUES 
 (38,'caihexin','2010-02-27 00:00:00','10001','1',0),
 (39,'caihexin','2010-02-27 00:00:00','10001','1',0),
 (40,'caihexin','2010-02-27 00:00:00','10001','1',0),
 (41,'caihexin','2010-02-27 00:00:00','10002','1',0),
 (42,'caihexin','2010-02-27 00:00:00','10001','1',0),
 (43,'caihexin','2010-02-27 00:00:00','10001','1',0),
 (44,'caihexin','2010-02-27 00:00:00','10001','1',0),
 (45,'caihexin','2010-04-12 00:00:00','10001','1',0),
 (46,'caihexin','2010-04-12 00:00:00','10001','1',0),
 (47,'caihexin','2010-04-12 00:00:00','10001','1',0);
/*!40000 ALTER TABLE `rebates` ENABLE KEYS */;


--
-- Definition of table `storeproperty`
--

DROP TABLE IF EXISTS `storeproperty`;
CREATE TABLE `storeproperty` (
  `ID` int(10) NOT NULL auto_increment,
  `storeDm` char(2) NOT NULL,
  `StoreName` varchar(50) NOT NULL,
  `StoreAddress` varchar(50) default NULL,
  `storeTel` char(11) default NULL,
  `linkName` char(8) default NULL,
  PRIMARY KEY  (`ID`),
  UNIQUE KEY `skey` (`storeDm`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `storeproperty`
--

/*!40000 ALTER TABLE `storeproperty` DISABLE KEYS */;
INSERT INTO `storeproperty` (`ID`,`storeDm`,`StoreName`,`StoreAddress`,`storeTel`,`linkName`) VALUES 
 (31,'1','cfifkufif','vjvjvj','vvv','vvv');
/*!40000 ALTER TABLE `storeproperty` ENABLE KEYS */;


--
-- Definition of table `storeroom`
--

DROP TABLE IF EXISTS `storeroom`;
CREATE TABLE `storeroom` (
  `ID` int(10) NOT NULL auto_increment,
  `storeDm` char(2) NOT NULL,
  `obNameDm` char(5) NOT NULL,
  `Num` int(10) default NULL,
  PRIMARY KEY  (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `storeroom`
--

/*!40000 ALTER TABLE `storeroom` DISABLE KEYS */;
INSERT INTO `storeroom` (`ID`,`storeDm`,`obNameDm`,`Num`) VALUES 
 (1,'1','10001',35),
 (2,'1','100',240),
 (3,'1','10013',30),
 (4,'1','10011',60),
 (5,'1','1010',84),
 (6,'1','10211',90),
 (7,'1','12897',-5),
 (8,'1','10100',22),
 (9,'1','1011',70),
 (10,'1','10118',20),
 (11,'1','111',-572),
 (12,'1','112',-30),
 (13,'1','10041',-10),
 (14,'1','88',-20),
 (15,'1','1111',-86),
 (16,'1','89',-1),
 (17,'1','11115',-2),
 (18,'1','898',-1),
 (19,'1','878',-4),
 (20,'1','10545',-3),
 (21,'1','899',-6),
 (22,'1','17171',-6),
 (23,'1','30001',-57),
 (24,'1','45000',-11),
 (25,'1','11111',-1),
 (26,'1','A12',-1),
 (27,'1','tes44',-1),
 (28,'1','ASDD1',-1),
 (29,'1','test1',-1),
 (30,'1','888',-2);
/*!40000 ALTER TABLE `storeroom` ENABLE KEYS */;


--
-- Definition of table `tmpxiaofei`
--

DROP TABLE IF EXISTS `tmpxiaofei`;
CREATE TABLE `tmpxiaofei` (
  `id` int(10) NOT NULL auto_increment,
  `VipNum` char(5) default NULL,
  `XfDZ` varchar(30) default NULL,
  `ObNameDm` char(5) default NULL,
  `UnitPrice` decimal(19,4) default NULL,
  `XfNum` int(10) default NULL,
  `XfSuM` decimal(19,4) default NULL,
  `dmdm` char(2) default NULL,
  `obname` varchar(50) default NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tmpxiaofei`
--

/*!40000 ALTER TABLE `tmpxiaofei` DISABLE KEYS */;
INSERT INTO `tmpxiaofei` (`id`,`VipNum`,`XfDZ`,`ObNameDm`,`UnitPrice`,`XfNum`,`XfSuM`,`dmdm`,`obname`) VALUES 
 (1,'10002','2009-12-30-10:05:0910002','111','12.0000',1,'12.0000','1','123'),
 (2,'10002','2009-12-30-10:05:0910002','A12','21.0000',1,'21.0000','1','1test'),
 (3,'10003','2009-12-30-10:05:5610003','111','12.0000',1,'12.0000','1','123'),
 (4,'10004','2009-12-30-10:06:2410004','tes44','24.0000',1,'24.0000','1','shdfhks'),
 (5,'10001','2009-12-30-10:15:3010001','111','12.0000',1,'12.0000','1','123'),
 (6,'10001','2009-12-30-10:15:3010001','ASDD1','2.0000',1,'2.0000','1','testas'),
 (7,'10001','2009-12-30-10:15:3010001','test1','12.3400',1,'12.3400','1','test56'),
 (8,'10001','2010-02-25-22:21:2310001','30001','10.0000',1,'10.0000','1','ÆäÈ¡ÓÑ±Ø¶ËÒÓ'),
 (9,'10001','2010-02-25-22:21:2310001','878','45.0000',1,'45.0000','1','wang'),
 (10,'10001','2010-02-27-11:01:5010001','111','12.0000',1,'12.0000','1','123'),
 (11,'10001','2010-02-27-11:01:5010001','111','12.0000',100,'1200.0000','1','123'),
 (12,'10001','2010-02-27-11:34:3910001','111','12.0000',100,'1200.0000','1','123');
INSERT INTO `tmpxiaofei` (`id`,`VipNum`,`XfDZ`,`ObNameDm`,`UnitPrice`,`XfNum`,`XfSuM`,`dmdm`,`obname`) VALUES 
 (13,'10001','2010-02-27-11:38:2710001','111','12.0000',100,'1200.0000','1','123'),
 (14,'10001','2010-02-27-11:40:0510001','111','12.0000',100,'1200.0000','1','123'),
 (15,'10001','2010-02-27-11:40:2110001','111','12.0000',10,'120.0000','1','123'),
 (16,'10001','2010-02-27-11:40:3910001','111','12.0000',10,'120.0000','1','123'),
 (17,'10002','2010-02-27-11:40:5610002','1111','11.0000',10,'110.0000','1','A1'),
 (18,'10001','2010-02-27-15:10:4610001','111','12.0000',1,'12.0000','1','123'),
 (19,'10001','2010-02-27-15:11:1710001','111','12.0000',1,'12.0000','1','123'),
 (20,'10001','2010-02-27-15:44:2210001','111','12.0000',10,'120.0000','1','123'),
 (21,'10001','2010-02-27-15:48:5310001','111','12.0000',10,'120.0000','1','123'),
 (22,'10001','2010-02-27-15:48:5310001','111','12.0000',10,'120.0000','1','123'),
 (23,'10001','2010-02-27-15:53:3310001','111','12.0000',1,'12.0000','1','123'),
 (24,'10001','2010-02-27-15:57:1010001','111','12.0000',1,'12.0000','1','123');
INSERT INTO `tmpxiaofei` (`id`,`VipNum`,`XfDZ`,`ObNameDm`,`UnitPrice`,`XfNum`,`XfSuM`,`dmdm`,`obname`) VALUES 
 (25,'10001','2010-02-27-16:00:0210001','111','12.0000',1,'12.0000','1','123'),
 (26,'10001','2010-04-12-21:33:5910001','111','12.0000',10,'120.0000','1','123'),
 (27,'10001','2010-04-12-21:33:5910001','1111','11.0000',5,'55.0000','1','A1'),
 (28,'10001','2010-04-12-21:34:2410001','111','12.0000',2,'24.0000','1','123'),
 (29,'10001','2010-04-12-21:34:2410001','888','300.0000',2,'600.0000','1','ji'),
 (30,'10001','2010-04-12-21:34:2410001','899','20.0000',4,'80.0000','1','dog3'),
 (31,'10001','2010-04-12-22:04:3510001','111','12.0000',10,'120.0000','1','123'),
 (32,'10001','2010-04-12-22:04:3510001','899','20.0000',1,'20.0000','1','dog3');
/*!40000 ALTER TABLE `tmpxiaofei` ENABLE KEYS */;


--
-- Definition of table `vipbase`
--

DROP TABLE IF EXISTS `vipbase`;
CREATE TABLE `vipbase` (
  `ID` int(10) NOT NULL auto_increment,
  `VipNum` char(5) NOT NULL,
  `VipName` char(8) NOT NULL,
  `VipSfz` char(18) default NULL,
  `VipTel` char(11) default NULL,
  `VipMob` char(11) default NULL,
  `VipWork` varchar(100) default NULL,
  `VipEmail` varchar(50) default NULL,
  `VipHome` varchar(100) default NULL,
  `VipBirthday` datetime default NULL,
  `BirthdayPp` char(1) default NULL,
  PRIMARY KEY  USING BTREE (`ID`),
  UNIQUE KEY `skey` USING BTREE (`VipNum`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `vipbase`
--

/*!40000 ALTER TABLE `vipbase` DISABLE KEYS */;
INSERT INTO `vipbase` (`ID`,`VipNum`,`VipName`,`VipSfz`,`VipTel`,`VipMob`,`VipWork`,`VipEmail`,`VipHome`,`VipBirthday`,`BirthdayPp`) VALUES 
 (1,'20011','2new','89327459375','374737','321743721','','','','1974-04-10 00:00:00','0'),
 (2,'10116','new116','','','','','','','1974-09-08 00:00:00','0'),
 (3,'10091','new9','','','','','','','1974-04-10 00:00:00','0'),
 (4,'10086','new7','','','','','','',NULL,''),
 (5,'10084','new56','','','','','','',NULL,''),
 (6,'10802','new4','','','','','','','2002-12-01 00:00:00','0'),
 (7,'10800','new3','','','0','','','','1974-09-08 00:00:00','0'),
 (8,'10899','new2','','','','','','','1974-09-08 00:00:00','0'),
 (9,'10888','new1','','','','','','',NULL,''),
 (10,'10256','cdf','','','','','','',NULL,'1'),
 (11,'10063','','','','','','','',NULL,'1'),
 (12,'10062','','','','','','','',NULL,'1'),
 (13,'10061','','','','','','','',NULL,'1'),
 (14,'10252','caihexin','','','','','','',NULL,'1'),
 (15,'10251','caihexin','','','','','','',NULL,'1'),
 (16,'10250','','','','','','','',NULL,'1'),
 (17,'10249','caihexin','','','','','','',NULL,'1');
INSERT INTO `vipbase` (`ID`,`VipNum`,`VipName`,`VipSfz`,`VipTel`,`VipMob`,`VipWork`,`VipEmail`,`VipHome`,`VipBirthday`,`BirthdayPp`) VALUES 
 (18,'10239','','','','','','','',NULL,'1'),
 (19,'10238','','','','','','','',NULL,'1'),
 (20,'10237','','','','','','','',NULL,'1'),
 (21,'10236','','','','','','','',NULL,'1'),
 (22,'10235','','','','','','','',NULL,'1'),
 (23,'10234','','','','','','','',NULL,'1'),
 (24,'10032','','','','','','','',NULL,'1'),
 (25,'8005','tom21','','','','','','','2000-11-13 00:00:00','1'),
 (26,'8008','tomas3','123','213','','','','','2002-01-12 00:00:00','1'),
 (27,'20008','','','','','','','','2004-01-01 00:00:00','1'),
 (28,'20007','','','','','','','','2005-01-01 00:00:00','1'),
 (29,'20006','','','','','','','','2008-01-01 00:00:00','1'),
 (30,'20005','','','','','','','','2017-01-01 00:00:00','1'),
 (31,'2004','²Ì5','','','','','','','2006-01-01 00:00:00','1'),
 (32,'20003','cai4','','','','','','','2005-12-31 00:00:00','1'),
 (33,'20002','²Ì3','321000000000000','','','','','','2004-12-31 00:00:00','1'),
 (34,'20001','²Ì','3210000','','','','','','2004-12-31 00:00:00','1');
INSERT INTO `vipbase` (`ID`,`VipNum`,`VipName`,`VipSfz`,`VipTel`,`VipMob`,`VipWork`,`VipEmail`,`VipHome`,`VipBirthday`,`BirthdayPp`) VALUES 
 (35,'1312','213','123','124','1412','142','c@si.com','124','2004-12-31 00:00:00','1'),
 (36,'55555','555','55','55','55','55','c@si.com','dfs','2004-12-31 00:00:00','1'),
 (37,'10023','tomas9','123456789012345678','','','','','',NULL,'1'),
 (38,'10022','tomas8','3838210975','','','','','',NULL,'1'),
 (39,'10021','²ÌºÍÐÂ','12345','','','','','',NULL,'1'),
 (40,'10020','tomas7','2387430275372352','','','','','',NULL,'1'),
 (41,'10019','tomas6','346392403275309380','','','','','','1979-11-23 00:00:00','1'),
 (42,'10018','tomas5','','','','','','','1975-09-08 00:00:00','1'),
 (43,'10017','tomas4','123456789012345678','','','','','','1976-09-26 00:00:00','1'),
 (44,'10016','tomas3','','','','','','','1974-12-01 00:00:00','1'),
 (45,'10015','tomas2','123456789','','','','','','2002-08-09 00:00:00','1'),
 (46,'10014','tomas2','56789','','','','','','2003-11-01 00:00:00','1'),
 (47,'10011','A7','123456','','1305179400','safsafsafsafsafasf123455566346436fjhgfjfgcxbxc242','','','2004-07-07 00:00:00','0');
INSERT INTO `vipbase` (`ID`,`VipNum`,`VipName`,`VipSfz`,`VipTel`,`VipMob`,`VipWork`,`VipEmail`,`VipHome`,`VipBirthday`,`BirthdayPp`) VALUES 
 (48,'10010','a6','','','','','','',NULL,'1'),
 (49,'10009','a5','','','','','','',NULL,'1'),
 (50,'1008','a4','','','','','','',NULL,'1'),
 (51,'10007','a3','','','','','','',NULL,'1'),
 (52,'10006','a2','23456789','','','','','',NULL,'1'),
 (53,'10005','a1','123456789','','','','','',NULL,'0'),
 (54,'10004','tomas','','','','','','',NULL,'1'),
 (55,'10003','ÐìÐ¡ÏÐ','','','','','','',NULL,'0'),
 (56,'10002','ÐìÑà','','','','','xuyan@163.com','',NULL,'0'),
 (57,'10001','²ÌºÍÐÂ','','','13905179400','','','','2007-10-07 00:00:00','0'),
 (58,'54321','xiuyan','','','','½­ËÕÄÏ¾©½­Äþ','','',NULL,'0'),
 (59,'12345','caihexin','1230123','','','','','',NULL,'0'),
 (60,'1','h11','123456','233','','','','','2007-11-23 00:00:00','1'),
 (61,'2','h12','123456','233','','','','',NULL,'1'),
 (62,'3','h12','123456','233','','','','',NULL,'1'),
 (66,'22228','cf','','','','','','','2000-12-31 00:00:00','1');
INSERT INTO `vipbase` (`ID`,`VipNum`,`VipName`,`VipSfz`,`VipTel`,`VipMob`,`VipWork`,`VipEmail`,`VipHome`,`VipBirthday`,`BirthdayPp`) VALUES 
 (67,'313','dd','','','','','','','2000-12-30 00:00:00','1'),
 (68,'3131','dd','','','','','','','2000-12-31 00:00:00','1'),
 (69,'34','df','122333','','','','','','1974-12-31 00:00:00','1'),
 (70,'12354','df2','4567','','','','','','2000-12-30 00:00:00','1'),
 (71,'12678','dds','','','','','','','1974-08-09 00:00:00','1'),
 (72,'1112','23','','','','','','','1976-12-12 00:00:00','1'),
 (73,'890','fgh','','','','','','','1964-08-07 00:00:00','1'),
 (74,'232','ww','','','','','','','2000-12-13 00:00:00','1'),
 (75,'2321','caihexin','','','','','','','1976-06-12 00:00:00','0');
/*!40000 ALTER TABLE `vipbase` ENABLE KEYS */;


--
-- Definition of table `vipextend`
--

DROP TABLE IF EXISTS `vipextend`;
CREATE TABLE `vipextend` (
  `ID` int(10) NOT NULL,
  `VipNum` char(5) NOT NULL,
  `FBirthday` datetime default NULL,
  `MBirthday` datetime default NULL,
  `GFBirthday` datetime default NULL,
  `GMBirthday` datetime default NULL,
  `SonBirthday` datetime default NULL,
  `DBirthday` datetime default NULL,
  PRIMARY KEY  (`VipNum`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `vipextend`
--

/*!40000 ALTER TABLE `vipextend` DISABLE KEYS */;
INSERT INTO `vipextend` (`ID`,`VipNum`,`FBirthday`,`MBirthday`,`GFBirthday`,`GMBirthday`,`SonBirthday`,`DBirthday`) VALUES 
 (15,'1000',NULL,NULL,NULL,NULL,NULL,NULL),
 (16,'10001','2004-12-31 00:00:00','2005-11-13 00:00:00','2004-12-31 00:00:00','2005-01-12 00:00:00','1974-12-12 00:00:00',NULL),
 (20,'10061',NULL,NULL,NULL,NULL,NULL,NULL),
 (21,'10062','2004-12-31 00:00:00',NULL,NULL,NULL,NULL,NULL),
 (22,'10063','2004-12-31 00:00:00',NULL,NULL,NULL,NULL,NULL),
 (17,'10250',NULL,NULL,NULL,NULL,NULL,NULL),
 (18,'10251',NULL,NULL,NULL,NULL,NULL,NULL),
 (19,'10252',NULL,NULL,NULL,NULL,NULL,NULL),
 (23,'10256','2004-12-31 00:00:00',NULL,NULL,NULL,NULL,NULL),
 (1,'20001',NULL,NULL,NULL,'1994-04-21 00:00:00',NULL,NULL),
 (2,'20002',NULL,NULL,NULL,NULL,NULL,NULL),
 (3,'20003',NULL,NULL,NULL,NULL,NULL,NULL),
 (5,'20005',NULL,NULL,NULL,NULL,NULL,NULL),
 (6,'20006','2006-02-01 00:00:00',NULL,NULL,NULL,NULL,NULL),
 (7,'20007','2006-02-01 00:00:00','2004-12-31 00:00:00',NULL,NULL,NULL,NULL),
 (8,'20008','2006-02-01 00:00:00','2004-12-31 00:00:00',NULL,NULL,NULL,NULL),
 (4,'2004',NULL,NULL,NULL,NULL,NULL,NULL);
INSERT INTO `vipextend` (`ID`,`VipNum`,`FBirthday`,`MBirthday`,`GFBirthday`,`GMBirthday`,`SonBirthday`,`DBirthday`) VALUES 
 (9,'8005',NULL,NULL,NULL,NULL,NULL,NULL),
 (10,'8006',NULL,NULL,NULL,NULL,NULL,NULL),
 (14,'8008','2004-12-31 00:00:00','2005-11-13 00:00:00',NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `vipextend` ENABLE KEYS */;


--
-- Definition of table `vipxiaofei`
--

DROP TABLE IF EXISTS `vipxiaofei`;
CREATE TABLE `vipxiaofei` (
  `id` int(10) NOT NULL auto_increment,
  `VipNum` char(5) default NULL,
  `XfDZ` varchar(30) default NULL,
  `ObNameDm` char(5) default NULL,
  `UnitPrice` double default NULL,
  `XfNum` int(10) default NULL,
  `XfSuM` double default NULL,
  `dmdm` char(2) default NULL,
  `obname` varchar(50) default NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `vipxiaofei`
--

/*!40000 ALTER TABLE `vipxiaofei` DISABLE KEYS */;
/*!40000 ALTER TABLE `vipxiaofei` ENABLE KEYS */;


--
-- Definition of table `vipxiaofeijifen`
--

DROP TABLE IF EXISTS `vipxiaofeijifen`;
CREATE TABLE `vipxiaofeijifen` (
  `ID` int(10) NOT NULL auto_increment,
  `VipNum` char(5) NOT NULL,
  `XfJf` int(10) NOT NULL,
  PRIMARY KEY  (`ID`),
  UNIQUE KEY `skey` (`VipNum`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `vipxiaofeijifen`
--

/*!40000 ALTER TABLE `vipxiaofeijifen` DISABLE KEYS */;
INSERT INTO `vipxiaofeijifen` (`ID`,`VipNum`,`XfJf`) VALUES 
 (1,'10001',17),
 (2,'10002',1);
/*!40000 ALTER TABLE `vipxiaofeijifen` ENABLE KEYS */;


--
-- Definition of table `vipxiaofeiliushui`
--

DROP TABLE IF EXISTS `vipxiaofeiliushui`;
CREATE TABLE `vipxiaofeiliushui` (
  `ID` int(10) NOT NULL auto_increment,
  `vipnum` char(5) NOT NULL,
  `salesdate` datetime NOT NULL,
  `jifen` int(10) NOT NULL,
  PRIMARY KEY  (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `vipxiaofeiliushui`
--

/*!40000 ALTER TABLE `vipxiaofeiliushui` DISABLE KEYS */;
INSERT INTO `vipxiaofeiliushui` (`ID`,`vipnum`,`salesdate`,`jifen`) VALUES 
 (1,'10001','2010-02-27 15:53:43',1),
 (2,'10001','2010-02-27 16:00:11',1);
/*!40000 ALTER TABLE `vipxiaofeiliushui` ENABLE KEYS */;


--
-- Definition of table `zkou`
--

DROP TABLE IF EXISTS `zkou`;
CREATE TABLE `zkou` (
  `id` int(10) unsigned NOT NULL auto_increment,
  `zk` varchar(4) character set latin1 collate latin1_bin NOT NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `zkou`
--

/*!40000 ALTER TABLE `zkou` DISABLE KEYS */;
INSERT INTO `zkou` (`id`,`zk`) VALUES 
 (1,0x31),
 (2,0x302E38),
 (3,0x302E39),
 (4,0x302E3838),
 (5,0x302E3935);
/*!40000 ALTER TABLE `zkou` ENABLE KEYS */;


--
-- Definition of procedure `DataXiaoFei`
--

DROP PROCEDURE IF EXISTS `DataXiaoFei`;

DELIMITER $$

CREATE DEFINER=`root`@`localhost` PROCEDURE `DataXiaoFei`()
BEGIN
      select * from vipxiaofei;

END $$

DELIMITER ;

--
-- Definition of procedure `icmoneyinsert`
--

DROP PROCEDURE IF EXISTS `icmoneyinsert`;

DELIMITER $$

CREATE DEFINER=`root`@`localhost` PROCEDURE `icmoneyinsert`(
_saledate char(20),
_dyname  char(12),
_dmdm char(2),
_icvalue double,
_balance char(12),
_icnum char(15)

)
BEGIN
      if not exists (select * from icmoney where saledate=_saledate and icnum=_icnum and dyname=_dyname) then
             insert into icmoney(saledate,dyname,dmdm,icvalue,balance,icnum) values(_saledate,_dyname,_dmdm,_icvalue,_balance,_icnum);
      end if ;
END $$

DELIMITER ;

--
-- Definition of procedure `insertIcMoney`
--

DROP PROCEDURE IF EXISTS `insertIcMoney`;

DELIMITER $$

CREATE DEFINER=`root`@`localhost` PROCEDURE `insertIcMoney`(
_saledate char(12),
_dyname char(12),
_dmdm char(2),
_icvalue double
)
BEGIN

    insert into icmoney(saledate,dyname,dmdm,icvalue) values(_saledate,_dyname,_dmdm,_icvalue);


END $$

DELIMITER ;

--
-- Definition of procedure `insidebaseInsert`
--

DROP PROCEDURE IF EXISTS `insidebaseInsert`;

DELIMITER $$

CREATE DEFINER=`root`@`localhost` PROCEDURE `insidebaseInsert`(
 _dyname char(12),
 _dysecure char(8),
 _dysfz char(18),
 _dyemail char(50),
 _dytel char(11),
 _dymob char(11),
 _dyhome char(100),
 _rulename char(10),
 _birthday char(20),
 _dmdm char(2)
)
BEGIN
       if (_birthday='') then

        set _birthday=null ;

       end if;
       if not exists( select * from insidebase where dyname=_dyname)    then


       insert into insidebase(dyname,dysecure,dysfz,dyemail,dytel,dymob,dyhome,rulename,birthday ,dmdm)
               values( _dyname,_dysecure,_dysfz,_dyemail,_dytel,_dymob,_dyhome,_rulename,_birthday ,_dmdm ) ;

       else
           update insidebase set dysecure=_dysecure,dysfz=_dysfz,dyemail=_dyemail,dytel=_dytel,dymob=_dymob ,
           dyhome=_dyhome ,rulename=_rulename,birthday=_birthday,dmdm=_dmdm
            where dyname=_dyname  ;

       end if ;

END $$

DELIMITER ;

--
-- Definition of procedure `InstoreToRoom`
--

DROP PROCEDURE IF EXISTS `InstoreToRoom`;

DELIMITER $$

CREATE DEFINER=`root`@`localhost` PROCEDURE `InstoreToRoom`(
  _storeDm char(2) ,
  _obNameDm char(5) ,
  _num int(11) ,
  _inTime datetime 

    )
BEGIN

       insert into instore(storeDm,obNameDm,num,intime)
               values( _storeDm,_obNameDm,_num,_inTime ) ;


       if not exists( select * from storeroom where obnameDm = _obnameDm and storeDm=_storeDm )   then


         insert into storeroom(storeDm,obNameDm,num)
               values( _storeDm,_obNameDm,_num ) ;


       else

         update storeroom set num=num+_num where   obnameDm = _obnameDm and storeDm=_storeDm  ;



       end if ;





END $$

DELIMITER ;

--
-- Definition of procedure `obInsert`
--

DROP PROCEDURE IF EXISTS `obInsert`;

DELIMITER $$

CREATE DEFINER=`root`@`localhost` PROCEDURE `obInsert`(
in _obnamedm char(5),
in _obname char(50),
in _unitprice decimal(19,4)
)
BEGIN


   if not exists (select * from ob where obnamedm=_obnamedm ) then

   insert into ob(obnamedm,obname,unitprice) values(_obnamedm,_obname,_unitprice);

   else

   update ob set  obname=_obname , unitprice =_unitprice   where   obnamedm=_obnamedm ;

   end if;

END $$

DELIMITER ;

--
-- Definition of procedure `UpdateStoreRoom`
--

DROP PROCEDURE IF EXISTS `UpdateStoreRoom`;

DELIMITER $$

CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateStoreRoom`(

  _storeDm char(2) ,
  _obNameDm char(5) ,
  _num int(11) 

    )
BEGIN



       if not exists( select * from storeroom where obnameDm = _obnameDm and storeDm=_storeDm )   then


         insert into storeroom(storeDm,obNameDm,num)
               values( _storeDm,_obNameDm,-_num ) ;


       else

         update storeroom set num=num-_num where   obnameDm = _obnameDm and storeDm=_storeDm  ;



       end if ;

END $$

DELIMITER ;

--
-- Definition of procedure `UpdateXfJiFen`
--

DROP PROCEDURE IF EXISTS `UpdateXfJiFen`;

DELIMITER $$

CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateXfJiFen`(_vipnum char(5),_xfjf int(10))
BEGIN 

             if  not exists (select * from vipxiaofeijifen where vipnum =_vipnum)  then  

             		 insert into vipxiaofeijifen(vipnum,xfjf) values(_vipnum,_xfjf);

             else 

             		 update vipxiaofeijifen set xfjf=xfjf + _xfjf where vipnum=_vipnum ;

             end if  ;

END $$

DELIMITER ;

--
-- Definition of procedure `vipbaseInsert`
--

DROP PROCEDURE IF EXISTS `vipbaseInsert`;

DELIMITER $$

CREATE DEFINER=`root`@`localhost` PROCEDURE `vipbaseInsert`(
_vipnum char(5),
_vipname char(8),
_vipsfz char(18),
_viptel char(11),
_vipmob char(11),
_vipwork char(100),
_vipemail char(50),
_viphome char(100),
_vipbirthday char(20),
_birthdayPp char(1)
 )
BEGIN
        if (_vipbirthday ='')  then
           
               set _vipbirthday=null ;

        end if   ;


        if not exists(select * from vipbase where vipnum =_vipnum) then

                insert into vipbase(vipnum,vipname,vipsfz,viptel,vipmob,vipwork,vipemail,viphome,vipbirthday,birthdaypp)
                 values(_vipnum,_vipname,_vipsfz,_viptel,_vipmob,_vipwork,_vipemail,_viphome,_vipbirthday,_birthdaypp);



        else



                update vipbase  set
                 vipname=_vipname , vipsfz=_vipsfz , vipmob=_vipmob ,vipwork=_vipwork ,vipemail=_vipemail,
                 viphome=_viphome ,vipbirthday=_vipbirthday ,birthdaypp=_birthdaypp
                  where vipnum=_vipnum ;



        end if;

END $$

DELIMITER ;

--
-- Definition of procedure `vipxiaofeiInsert`
--

DROP PROCEDURE IF EXISTS `vipxiaofeiInsert`;

DELIMITER $$

CREATE DEFINER=`root`@`localhost` PROCEDURE `vipxiaofeiInsert`(
_vipnum char(5),
_xfdz char(30),
_obnamedm char(5),
_unitprice double,
_xfnum int(10),
_xfsum double,
_dmdm char(2),
_obname char(50)
)
BEGIN
      if not exists (select * from vipxiaofei where vipnum=_vipnum and xfdz=_xfdz and obnamedm=_obnamedm) then
             insert into vipxiaofei(vipnum,xfdz,obnamedm,unitprice,xfnum,xfsum,dmdm,obname)
              values(_vipnum,_xfdz,_obnamedm,_unitprice,_xfnum,_xfsum,_dmdm,_obname);
      end if ;
END $$

DELIMITER ;

--
-- Definition of procedure `vipxiaofeijifenInsert`
--

DROP PROCEDURE IF EXISTS `vipxiaofeijifenInsert`;

DELIMITER $$

CREATE DEFINER=`root`@`localhost` PROCEDURE `vipxiaofeijifenInsert`(
_vipnum char(5),
_xfjf int(10)

)
BEGIN

             if  not exists (select * from vipxiaofeijifen where vipnum =_vipnum) then

             insert into vipxiaofeijifen(vipnum,xfjf) values(_vipnum,_xfjf);

             else

             update vipxiaofeijifen set xfjf=_xfjf where vipnum=_vipnum ;

             end if ;







END $$

DELIMITER ;

--
-- Definition of view `currentsalesview`
--

DROP TABLE IF EXISTS `currentsalesview`;
DROP VIEW IF EXISTS `currentsalesview`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `currentsalesview` AS select `currentsales`.`dyname` AS `dyname`,sum(`currentsales`.`salesum`) AS `salesum` from `currentsales` where (`currentsales`.`saledate` > curdate()) group by `currentsales`.`dyname`;

--
-- Definition of view `jfview`
--

DROP TABLE IF EXISTS `jfview`;
DROP VIEW IF EXISTS `jfview`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `jfview` AS select `a`.`ID` AS `id`,`a`.`VipNum` AS `vipnum`,`a`.`XfJf` AS `xfjf`,`b`.`VipName` AS `vipname`,`b`.`VipTel` AS `viptel`,`b`.`VipMob` AS `vipmob`,`b`.`VipWork` AS `vipwork`,`b`.`VipHome` AS `viphome` from (`vipxiaofeijifen` `a` join `vipbase` `b`) where (`a`.`VipNum` = `b`.`VipNum`) order by `a`.`XfJf` desc;

--
-- Definition of view `reportxiaofei`
--

DROP TABLE IF EXISTS `reportxiaofei`;
DROP VIEW IF EXISTS `reportxiaofei`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `reportxiaofei` AS select `vipxiaofei`.`id` AS `id`,`vipxiaofei`.`VipNum` AS `VipNum`,`vipxiaofei`.`XfDZ` AS `XfDZ`,`vipxiaofei`.`ObNameDm` AS `ObNameDm`,`vipxiaofei`.`UnitPrice` AS `UnitPrice`,`vipxiaofei`.`XfNum` AS `XfNum`,`vipxiaofei`.`XfSuM` AS `XfSuM`,`vipxiaofei`.`dmdm` AS `dmdm`,`vipxiaofei`.`obname` AS `obname`,substr(`vipxiaofei`.`XfDZ`,1,10) AS `d`,substr(`vipxiaofei`.`XfDZ`,12,2) AS `h`,substr(`vipxiaofei`.`ObNameDm`,1,1) AS `splb` from `vipxiaofei`;



/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
