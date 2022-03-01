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



/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
