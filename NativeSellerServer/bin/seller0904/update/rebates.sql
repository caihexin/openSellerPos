
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
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='уш©ш';

--
-- Dumping data for table `rebates`
--