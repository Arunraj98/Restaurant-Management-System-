/*
SQLyog Ultimate v13.1.1 (64 bit)
MySQL - 8.0.26 : Database - feast
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`feast` /*!40100 DEFAULT CHARACTER SET utf8 */ /*!80016 DEFAULT ENCRYPTION='N' */;

USE `feast`;

/*Table structure for table `address` */

DROP TABLE IF EXISTS `address`;

CREATE TABLE `address` (
  `addressid` int NOT NULL AUTO_INCREMENT,
  `address` varchar(100) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `phone` bigint DEFAULT NULL,
  `photo` varchar(100) DEFAULT NULL,
  `pid` int DEFAULT NULL,
  `stock` int DEFAULT NULL,
  `nos` int DEFAULT NULL,
  `place` varchar(20) DEFAULT NULL,
  `zone` varchar(20) DEFAULT NULL,
  `quantity` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`addressid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

/*Data for the table `address` */

/*Table structure for table `addresscart` */

DROP TABLE IF EXISTS `addresscart`;

CREATE TABLE `addresscart` (
  `addressid` int NOT NULL AUTO_INCREMENT,
  `address` varchar(100) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `zone` varchar(20) DEFAULT NULL,
  `phone` bigint DEFAULT NULL,
  `place` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`addressid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

/*Data for the table `addresscart` */

/*Table structure for table `customerregisration` */

DROP TABLE IF EXISTS `customerregisration`;

CREATE TABLE `customerregisration` (
  `cust_id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(50) DEFAULT NULL,
  `address` varchar(100) DEFAULT NULL,
  `place` varchar(50) DEFAULT NULL,
  `phoneno` bigint DEFAULT NULL,
  `emailid` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`cust_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `customerregisration` */

/*Table structure for table `feedback` */

DROP TABLE IF EXISTS `feedback`;

CREATE TABLE `feedback` (
  `fid` int NOT NULL AUTO_INCREMENT,
  `fname` varchar(50) DEFAULT NULL,
  `lname` varchar(50) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `phone` varchar(50) DEFAULT NULL,
  `comment` varchar(100) DEFAULT NULL,
  `date` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`fid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `feedback` */

/*Table structure for table `login` */

DROP TABLE IF EXISTS `login`;

CREATE TABLE `login` (
  `username` varchar(50) NOT NULL,
  `password` varchar(50) DEFAULT NULL,
  `role` varchar(30) DEFAULT NULL,
  `status` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`username`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `login` */

insert  into `login`(`username`,`password`,`role`,`status`) values 
('afsalabbasna@gmail.com','afs','Order management manager','Approved'),
('aryammini19@gmail.com','ary','Delivery staff','Approved'),
('drisyadvs@gmail.com','dri','Packing manager','Approved'),
('jancychandra98@gmail.com','2009','Packing manager','Block'),
('rajaarun384@gmail.com','arj','Production manager','Approved'),
('rmsminiproject@gmail.com','rms','admin','Approved');

/*Table structure for table `pay` */

DROP TABLE IF EXISTS `pay`;

CREATE TABLE `pay` (
  `payid` int NOT NULL AUTO_INCREMENT,
  `amount` int DEFAULT NULL,
  `pcode` int DEFAULT NULL,
  `date` varchar(30) DEFAULT NULL,
  `ddate` varchar(30) DEFAULT NULL,
  `name` varchar(30) DEFAULT NULL,
  `address` varchar(100) DEFAULT NULL,
  `place` varchar(30) DEFAULT NULL,
  `phone` varchar(30) DEFAULT NULL,
  `zone` varchar(30) DEFAULT NULL,
  `status` varchar(50) DEFAULT NULL,
  `mode` varchar(30) DEFAULT NULL,
  `email` varchar(50) DEFAULT NULL,
  `bstatus` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`payid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

/*Data for the table `pay` */

/*Table structure for table `place` */

DROP TABLE IF EXISTS `place`;

CREATE TABLE `place` (
  `zid` int NOT NULL AUTO_INCREMENT,
  `place` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`zid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

/*Data for the table `place` */

/*Table structure for table `product` */

DROP TABLE IF EXISTS `product`;

CREATE TABLE `product` (
  `pid` int NOT NULL AUTO_INCREMENT,
  `pname` varchar(50) DEFAULT NULL,
  `photoname` varchar(50) DEFAULT NULL,
  `price` double DEFAULT NULL,
  `stock` int DEFAULT NULL,
  `ptype` varchar(50) DEFAULT NULL,
  `quantity` varchar(50) DEFAULT NULL,
  `pstype` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`pid`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

/*Data for the table `product` */

insert  into `product`(`pid`,`pname`,`photoname`,`price`,`stock`,`ptype`,`quantity`,`pstype`) values 
(1,'Samosa','product/samosa.jpg',15,27,'Vegetarian','1 piece ','snacks'),
(2,'chicken biriyani','product/chicken biriyani.jpg',120,48,'Non Vegetarian','1 plate','Biriyani'),
(3,'cappuccino ','product/cappuccino.jpg',35,38,'Drinks','1 cup','coffee ');

/*Table structure for table `reservation` */

DROP TABLE IF EXISTS `reservation`;

CREATE TABLE `reservation` (
  `payid` int NOT NULL AUTO_INCREMENT,
  `amount` int DEFAULT NULL,
  `date` varchar(30) DEFAULT NULL,
  `name` varchar(30) DEFAULT NULL,
  `phone` varchar(30) DEFAULT NULL,
  `status` varchar(50) DEFAULT NULL,
  `mode` varchar(30) DEFAULT NULL,
  `email` varchar(50) DEFAULT NULL,
  `bstatus` varchar(50) DEFAULT NULL,
  `no_of_seats` varchar(50) DEFAULT NULL,
  `time` varchar(20) DEFAULT NULL,
  `rdate` varchar(20) DEFAULT NULL,
  `hours` varchar(20) DEFAULT NULL,
  `type` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`payid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

/*Data for the table `reservation` */

/*Table structure for table `reserve` */

DROP TABLE IF EXISTS `reserve`;

CREATE TABLE `reserve` (
  `rid` int NOT NULL AUTO_INCREMENT,
  `no_of_seats` int DEFAULT NULL,
  `amount` int DEFAULT NULL,
  PRIMARY KEY (`rid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

/*Data for the table `reserve` */

/*Table structure for table `sales` */

DROP TABLE IF EXISTS `sales`;

CREATE TABLE `sales` (
  `paymentid` int NOT NULL AUTO_INCREMENT,
  `name` varchar(50) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `address` varchar(100) DEFAULT NULL,
  `phone` varchar(100) DEFAULT NULL,
  `productname` varchar(100) DEFAULT NULL,
  `photoname` varchar(100) DEFAULT NULL,
  `status` varchar(100) DEFAULT NULL,
  `amount` int DEFAULT NULL,
  `mode` varchar(100) DEFAULT NULL,
  `date` varchar(40) DEFAULT NULL,
  `pcode` varchar(40) DEFAULT NULL,
  `buystatus` varchar(20) DEFAULT NULL,
  `quantity` varchar(20) DEFAULT NULL,
  `nos` varchar(20) DEFAULT NULL,
  `pid` int DEFAULT NULL,
  `type` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`paymentid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `sales` */

/*Table structure for table `staffregistration` */

DROP TABLE IF EXISTS `staffregistration`;

CREATE TABLE `staffregistration` (
  `staffid` int NOT NULL AUTO_INCREMENT,
  `name` varchar(50) DEFAULT NULL,
  `dob` varchar(50) DEFAULT NULL,
  `gender` varchar(20) DEFAULT NULL,
  `address` varchar(100) DEFAULT NULL,
  `phone` bigint DEFAULT NULL,
  `mailid` varchar(50) DEFAULT NULL,
  `qualification` varchar(50) DEFAULT NULL,
  `salary` double DEFAULT NULL,
  `photo` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`staffid`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

/*Data for the table `staffregistration` */

insert  into `staffregistration`(`staffid`,`name`,`dob`,`gender`,`address`,`phone`,`mailid`,`qualification`,`salary`,`photo`) values 
(1,'Arunraj','1998-05-25','Male','14/ 176 Mundoor house, kanjikode',9605334293,'BBA','rajaarun384@gmail.com',0,'memberphoto/rajaarun384@gmail.comimg1.jpg'),
(2,'Afsal','1998-08-15','Male','16/186 Palakkad',9876543210,'MBA','afsalabbasna@gmail.com',0,'memberphoto/afsalabbasna@gmail.comimg2.jpg'),
(3,'Drisya','1999-05-08','Male','19/188 Palakkad',8975864153,'BBA','drisyadvs@gmail.com',0,'memberphoto/drisyadvs@gmail.comimg8.jpg'),
(4,'Arya','1998-10-19','Male','14/198 Palakkad',9875486217,'BBA','aryammini19@gmail.com',0,'memberphoto/aryammini19@gmail.comimg10.jpg'),
(5,'jancy','1998-06-17','Female','palakkad',9856124357,'MCA','jancychandra98@gmail.com',0,'memberphoto/jancychandra98@gmail.comimg7.jpg');

/*Table structure for table `subcat` */

DROP TABLE IF EXISTS `subcat`;

CREATE TABLE `subcat` (
  `scid` int NOT NULL AUTO_INCREMENT,
  `subcat` varchar(30) DEFAULT NULL,
  `cat` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`scid`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb3;

/*Data for the table `subcat` */

insert  into `subcat`(`scid`,`subcat`,`cat`) values 
(1,'snacks','Vegetarian'),
(2,'Biriyani','Non Vegetarian'),
(3,'coffee ','Drinks');

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
