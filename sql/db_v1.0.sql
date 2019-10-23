-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               10.4.7-MariaDB - mariadb.org binary distribution
-- Server OS:                    Win64
-- HeidiSQL Version:             10.2.0.5599
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

-- Dumping structure for table rumah_scarlett.barang
CREATE TABLE IF NOT EXISTS `barang` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `tipe_id` int(10) unsigned NOT NULL,
  `sub_tipe_id` int(10) unsigned NOT NULL,
  `supplier_id` int(10) unsigned NOT NULL,
  `satuan_id` int(10) unsigned NOT NULL,
  `kode` varchar(255) NOT NULL,
  `nama` varchar(255) NOT NULL,
  `hpp` decimal(19,0) NOT NULL,
  `harga_jual` decimal(19,0) NOT NULL,
  `harga_lama` decimal(19,0) NOT NULL,
  `stok` int(11) NOT NULL DEFAULT 0,
  `minimal_stok` int(11) NOT NULL DEFAULT 0,
  PRIMARY KEY (`id`),
  UNIQUE KEY `kode` (`kode`),
  UNIQUE KEY `nama` (`nama`),
  KEY `fk_barang_sub_tipe_id` (`sub_tipe_id`),
  KEY `fk_barang_supplier_id` (`supplier_id`),
  KEY `fk_barang_tipe_id` (`tipe_id`),
  KEY `fk_stauan_satuan_id_idx` (`satuan_id`),
  CONSTRAINT `fk_barang_satuan_id` FOREIGN KEY (`satuan_id`) REFERENCES `satuan` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_barang_sub_tipe_id` FOREIGN KEY (`sub_tipe_id`) REFERENCES `sub_tipe` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_barang_supplier_id` FOREIGN KEY (`supplier_id`) REFERENCES `supplier` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_barang_tipe_id` FOREIGN KEY (`tipe_id`) REFERENCES `tipe` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table rumah_scarlett.barang: ~0 rows (approximately)
/*!40000 ALTER TABLE `barang` DISABLE KEYS */;
/*!40000 ALTER TABLE `barang` ENABLE KEYS */;

-- Dumping structure for table rumah_scarlett.databasechangelog
CREATE TABLE IF NOT EXISTS `databasechangelog` (
  `ID` varchar(255) NOT NULL,
  `AUTHOR` varchar(255) NOT NULL,
  `FILENAME` varchar(255) NOT NULL,
  `DATEEXECUTED` datetime NOT NULL,
  `ORDEREXECUTED` int(11) NOT NULL,
  `EXECTYPE` varchar(10) NOT NULL,
  `MD5SUM` varchar(35) DEFAULT NULL,
  `DESCRIPTION` varchar(255) DEFAULT NULL,
  `COMMENTS` varchar(255) DEFAULT NULL,
  `TAG` varchar(255) DEFAULT NULL,
  `LIQUIBASE` varchar(20) DEFAULT NULL,
  `CONTEXTS` varchar(255) DEFAULT NULL,
  `LABELS` varchar(255) DEFAULT NULL,
  `DEPLOYMENT_ID` varchar(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table rumah_scarlett.databasechangelog: ~87 rows (approximately)
/*!40000 ALTER TABLE `databasechangelog` DISABLE KEYS */;
INSERT INTO `databasechangelog` (`ID`, `AUTHOR`, `FILENAME`, `DATEEXECUTED`, `ORDEREXECUTED`, `EXECTYPE`, `MD5SUM`, `DESCRIPTION`, `COMMENTS`, `TAG`, `LIQUIBASE`, `CONTEXTS`, `LABELS`, `DEPLOYMENT_ID`) VALUES
	('1571472428398-1', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:34', 1, 'EXECUTED', '7:1ebff8fa4763beed9bb31e975b746fed', 'createTable tableName=barang', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-2', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:34', 2, 'EXECUTED', '7:571957f9c0c08e4381a5a50fedc35245', 'createTable tableName=form_action', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-3', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:35', 3, 'EXECUTED', '7:4b0dffa8580b42e3f8c29732c994548d', 'createTable tableName=hutang_operasional', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-4', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:35', 4, 'EXECUTED', '7:a171feeb7f13bab1c85cba55e9dc6f12', 'createTable tableName=kas_awal', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-5', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:35', 5, 'EXECUTED', '7:823682c92e488d10e3d624a286b37830', 'createTable tableName=pelanggan', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-6', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:35', 6, 'EXECUTED', '7:d46efd6842cdf2d701c8e14f36e9a09a', 'createTable tableName=pembelian', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-7', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:36', 7, 'EXECUTED', '7:55ddb8449723673351a022b1324dec12', 'createTable tableName=pembelian_detail', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-8', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:36', 8, 'EXECUTED', '7:65dd291a8604181146be0691e5247e38', 'createTable tableName=pembelian_return', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-9', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:36', 9, 'EXECUTED', '7:f5ef49510f54fb415087945f46f7e62d', 'createTable tableName=pembelian_return_detail', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-10', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:36', 10, 'EXECUTED', '7:4073d9c41ee4f0d5316d884b86649f8d', 'createTable tableName=pengeluaran', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-11', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:36', 11, 'EXECUTED', '7:77582e93abe1249a717d8468b68ff982', 'createTable tableName=penjualan', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-12', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:36', 12, 'EXECUTED', '7:e4451929e526f1e073390a1872db6386', 'createTable tableName=penjualan_detail', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-13', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:36', 13, 'EXECUTED', '7:40192ec081b44cb90eb9c4c70ccccc62', 'createTable tableName=penjualan_return', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-14', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:37', 14, 'EXECUTED', '7:61cf6948631263f603c9f73edfdf2afd', 'createTable tableName=penjualan_return_detail', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-15', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:37', 15, 'EXECUTED', '7:cbb7509863cd82bcc892a9af5dc3472e', 'createTable tableName=penyesuaian_stok', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-16', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:37', 16, 'EXECUTED', '7:56d172cd88d6b5581b923cee084d1447', 'createTable tableName=role', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-17', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:37', 17, 'EXECUTED', '7:7164a6cf318ee7e6a1277cb9a72adab1', 'createTable tableName=role_detail', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-18', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:38', 18, 'EXECUTED', '7:af073406b9381c809e9e8629e754e2ca', 'createTable tableName=satuan', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-19', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:38', 19, 'EXECUTED', '7:85d83d70ccab32e90049209f2fc2b189', 'createTable tableName=status_barang', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-20', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:38', 20, 'EXECUTED', '7:9d7d44de08e1bede8247a6816cfb4027', 'createTable tableName=sub_tipe', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-21', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:38', 21, 'EXECUTED', '7:89fc531e645aa8d29a3670cccb336990', 'createTable tableName=supplier', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-22', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:38', 22, 'EXECUTED', '7:eafa56713878159305cb7200b0e5be49', 'createTable tableName=tipe', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-23', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:39', 23, 'EXECUTED', '7:ba3b8e2d691be545021c4da4cc3a5bc4', 'createTable tableName=user', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-24', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:39', 24, 'EXECUTED', '7:568c22ab572477e25b2577efe0742fca', 'addUniqueConstraint constraintName=form_name_UNIQUE, tableName=form_action', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-25', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:39', 25, 'EXECUTED', '7:b80e6d2ef2effd08d8ca9ee2373e65cd', 'addUniqueConstraint constraintName=kode, tableName=barang', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-26', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:40', 26, 'EXECUTED', '7:a76ef56e574dc8487d6fe5534f6ff5cc', 'addUniqueConstraint constraintName=kode, tableName=role', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-27', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:40', 27, 'EXECUTED', '7:faf599b25f15c4107d59aec8febadb1f', 'addUniqueConstraint constraintName=login_id_UNIQUE, tableName=user', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-28', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:40', 28, 'EXECUTED', '7:8f92a6a5480195be0275f2e6b3b211f8', 'addUniqueConstraint constraintName=nama, tableName=barang', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-29', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:40', 29, 'EXECUTED', '7:cdf4686a2f3f0d498cdea22b1a434937', 'addUniqueConstraint constraintName=nama, tableName=sub_tipe', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-30', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:40', 30, 'EXECUTED', '7:d4813456129f56445fb9df6dc2bc9d63', 'addUniqueConstraint constraintName=nama, tableName=supplier', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-31', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:40', 31, 'EXECUTED', '7:50f78b919610989e798c32722ebaa322', 'addUniqueConstraint constraintName=nama, tableName=tipe', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-32', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:41', 32, 'EXECUTED', '7:945e634749fea386288d75eb9ad51a28', 'addUniqueConstraint constraintName=nama_UNIQUE, tableName=satuan', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-33', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:41', 33, 'EXECUTED', '7:045c8b8aac92fee27dfc883adc173510', 'addUniqueConstraint constraintName=no_nota, tableName=pembelian', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-34', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:41', 34, 'EXECUTED', '7:b8879e8d9ffed064ea827aa08bac33db', 'addUniqueConstraint constraintName=no_nota, tableName=pembelian_return', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-35', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:41', 35, 'EXECUTED', '7:d1a26aaff9e9dd48c92a3eec2a425bdc', 'addUniqueConstraint constraintName=no_nota, tableName=penjualan', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-36', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:41', 36, 'EXECUTED', '7:1798b95d530cd9e520fde39d09fe6409', 'addUniqueConstraint constraintName=no_nota, tableName=penjualan_return', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-37', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:42', 37, 'EXECUTED', '7:50be788ddca6f02ed0c4b97c5735a489', 'addUniqueConstraint constraintName=tanggal, tableName=kas_awal', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-38', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:42', 38, 'EXECUTED', '7:b1e6f02e65a6193f29c5aa51ed91e1e5', 'createIndex indexName=fk_barang_sub_tipe_id, tableName=barang', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-39', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:42', 39, 'EXECUTED', '7:d97e634dd5236f36825242d734ffa71f', 'createIndex indexName=fk_barang_supplier_id, tableName=barang', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-40', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:43', 40, 'EXECUTED', '7:ecf856d7687f645c9c2bea990e3f774e', 'createIndex indexName=fk_barang_tipe_id, tableName=barang', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-41', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:43', 41, 'EXECUTED', '7:d84412315b16bf92fe3577c6ec42cc14', 'createIndex indexName=fk_pembelian_barang_id, tableName=pembelian_detail', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-42', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:43', 42, 'EXECUTED', '7:08047ca60419200c5b6c85204146a62f', 'createIndex indexName=fk_pembelian_pembelian_id, tableName=pembelian_detail', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-43', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:43', 43, 'EXECUTED', '7:afe200233a06c2e0f4afabe6190cda69', 'createIndex indexName=fk_pembelian_return_detail_barang_id, tableName=pembelian_return_detail', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-44', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:43', 44, 'EXECUTED', '7:573e0963ba31506e9421755a5da8982e', 'createIndex indexName=fk_pembelian_return_detail_pembelian_return_id, tableName=pembelian_return_detail', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-45', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:44', 45, 'EXECUTED', '7:e346d1c5a5504f7a0502d48e0ca0fec3', 'createIndex indexName=fk_pembelian_return_pembelian_id, tableName=pembelian_return', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-46', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:44', 46, 'EXECUTED', '7:df3f964f33e3ae6889d6ba974eefdaba', 'createIndex indexName=fk_pembelian_supplier_id, tableName=pembelian', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-47', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:44', 47, 'EXECUTED', '7:2246eedb3b4a47b3986f78557fef640b', 'createIndex indexName=fk_penjualan_barang_id, tableName=penjualan_detail', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-48', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:44', 48, 'EXECUTED', '7:a58a9abf4f5e24b179eb6d03fad01fae', 'createIndex indexName=fk_penjualan_pelangan_id, tableName=penjualan', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-49', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:44', 49, 'EXECUTED', '7:89cb10800c890a1fc5860c69566e68b0', 'createIndex indexName=fk_penjualan_penjualan_id, tableName=penjualan_detail', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-50', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:44', 50, 'EXECUTED', '7:22b6201a4222df93dd233bdeae260cd4', 'createIndex indexName=fk_penjualan_return_detail_barang_id, tableName=penjualan_return_detail', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-51', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:45', 51, 'EXECUTED', '7:dc1166fed2eb70d490b753626b3c34c9', 'createIndex indexName=fk_penjualan_return_detail_penjualan_return_id, tableName=penjualan_return_detail', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-52', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:45', 52, 'EXECUTED', '7:d451100d2199eb326bc9357498c6566b', 'createIndex indexName=fk_penjualan_return_penjualan_id, tableName=penjualan_return', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-53', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:45', 53, 'EXECUTED', '7:e67ee811442510efd8c87ee95c216970', 'createIndex indexName=fk_penyesuaian_stok_barang_id, tableName=penyesuaian_stok', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-54', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:45', 54, 'EXECUTED', '7:a5de6594f2a7963f6ed12b0b3806d01f', 'createIndex indexName=fk_penyesuaian_stok_satuan_id, tableName=penyesuaian_stok', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-55', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:45', 55, 'EXECUTED', '7:106184c63a9b747694ab670e142d1064', 'createIndex indexName=fk_role_detail_role_kode, tableName=role_detail', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-56', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:45', 56, 'EXECUTED', '7:fcb91165defae72c2a8bd4ea59434a8e', 'createIndex indexName=fk_status_barang_pembelian_id, tableName=status_barang', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-57', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:46', 57, 'EXECUTED', '7:1d6fcf9ce76f28abf50e4302a1ec72d5', 'createIndex indexName=fk_status_barang_pembelian_return_id, tableName=status_barang', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-58', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:46', 58, 'EXECUTED', '7:19d544464fe704b77dd461471942418d', 'createIndex indexName=fk_status_barang_penjualan_id, tableName=status_barang', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-59', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:46', 59, 'EXECUTED', '7:c69e5f0a23b036f0728334e7ba807fbc', 'createIndex indexName=fk_status_barang_penjualan_return_id, tableName=status_barang', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-60', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:46', 60, 'EXECUTED', '7:a4ceaa1b45904407f57f4d436e6f2ab5', 'createIndex indexName=fk_status_barang_penyesuaian_stok_d_idx, tableName=status_barang', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-61', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:46', 61, 'EXECUTED', '7:0d2032ec8bc5717121b5ce20f3b63c31', 'createIndex indexName=fk_stauan_satuan_id_idx, tableName=barang', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-62', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:47', 62, 'EXECUTED', '7:2acb7faefe2933a9313069f2f22c8307', 'createIndex indexName=fk_user_role_kode, tableName=user', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-63', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:48', 63, 'EXECUTED', '7:69bc61273005a63414b44bdce385013d', 'addForeignKeyConstraint baseTableName=barang, constraintName=fk_barang_satuan_id, referencedTableName=satuan', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-64', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:49', 64, 'EXECUTED', '7:b19f557e7d20a41f61907df972b7bfc7', 'addForeignKeyConstraint baseTableName=barang, constraintName=fk_barang_sub_tipe_id, referencedTableName=sub_tipe', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-65', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:50', 65, 'EXECUTED', '7:e1d5a43396aef3c10a084b21806b9a77', 'addForeignKeyConstraint baseTableName=barang, constraintName=fk_barang_supplier_id, referencedTableName=supplier', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-66', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:51', 66, 'EXECUTED', '7:1852c3e15995637ebafcaaadea58f0da', 'addForeignKeyConstraint baseTableName=barang, constraintName=fk_barang_tipe_id, referencedTableName=tipe', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-67', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:52', 67, 'EXECUTED', '7:82190f12d3ce6e7b713a1309c5a098b2', 'addForeignKeyConstraint baseTableName=pembelian_detail, constraintName=fk_pembelian_barang_id, referencedTableName=barang', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-68', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:53', 68, 'EXECUTED', '7:f0123ca8d28c1b2525c344ee1b5b55fe', 'addForeignKeyConstraint baseTableName=pembelian_detail, constraintName=fk_pembelian_pembelian_id, referencedTableName=pembelian', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-69', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:54', 69, 'EXECUTED', '7:372ac40c83793d7a46460dd1d26a6c3c', 'addForeignKeyConstraint baseTableName=pembelian_return_detail, constraintName=fk_pembelian_return_detail_barang_id, referencedTableName=barang', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-70', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:54', 70, 'EXECUTED', '7:68f9c37e60b8afca2ffea0f69782c6fd', 'addForeignKeyConstraint baseTableName=pembelian_return_detail, constraintName=fk_pembelian_return_detail_pembelian_return_id, referencedTableName=pembelian_return', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-71', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:55', 71, 'EXECUTED', '7:cdbcbb2f1a6ea70a925e6397dbbf1e91', 'addForeignKeyConstraint baseTableName=pembelian_return, constraintName=fk_pembelian_return_pembelian_id, referencedTableName=pembelian', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-72', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:56', 72, 'EXECUTED', '7:5db555dd1676363df824aa04007b337c', 'addForeignKeyConstraint baseTableName=pembelian, constraintName=fk_pembelian_supplier_id, referencedTableName=supplier', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-73', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:57', 73, 'EXECUTED', '7:c5d5e61ced245ead89472aeb863f2ecc', 'addForeignKeyConstraint baseTableName=penjualan_detail, constraintName=fk_penjualan_barang_id, referencedTableName=barang', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-74', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:58', 74, 'EXECUTED', '7:003a5713cc4c2c225de26ad4b928cf8a', 'addForeignKeyConstraint baseTableName=penjualan, constraintName=fk_penjualan_pelangan_id, referencedTableName=pelanggan', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-75', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:22:59', 75, 'EXECUTED', '7:4de62e4d40eea236c112841729f63d35', 'addForeignKeyConstraint baseTableName=penjualan_detail, constraintName=fk_penjualan_penjualan_id, referencedTableName=penjualan', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-76', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:23:00', 76, 'EXECUTED', '7:4265c3249f8e5f5d40f5a83a8c8e03de', 'addForeignKeyConstraint baseTableName=penjualan_return_detail, constraintName=fk_penjualan_return_detail_barang_id, referencedTableName=barang', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-77', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:23:02', 77, 'EXECUTED', '7:3581076e081d7f4c5813a5c950bde182', 'addForeignKeyConstraint baseTableName=penjualan_return_detail, constraintName=fk_penjualan_return_detail_penjualan_return_id, referencedTableName=penjualan_return', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-78', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:23:04', 78, 'EXECUTED', '7:7e9c6c21f96e7c8629ac117da31c7b26', 'addForeignKeyConstraint baseTableName=penjualan_return, constraintName=fk_penjualan_return_penjualan_id, referencedTableName=penjualan', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-79', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:23:05', 79, 'EXECUTED', '7:ed452f06b464b1903cfd5cf78748aa33', 'addForeignKeyConstraint baseTableName=penyesuaian_stok, constraintName=fk_penyesuaian_stok_barang_id, referencedTableName=barang', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-80', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:23:06', 80, 'EXECUTED', '7:5361dc1d6568dbf6b4483c85e7aef7ff', 'addForeignKeyConstraint baseTableName=penyesuaian_stok, constraintName=fk_penyesuaian_stok_satuan_id, referencedTableName=satuan', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-81', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:23:07', 81, 'EXECUTED', '7:7d4e27ad192597b5f0cd4d7b26fefdbb', 'addForeignKeyConstraint baseTableName=role_detail, constraintName=fk_role_detail_role_kode, referencedTableName=role', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-82', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:23:08', 82, 'EXECUTED', '7:769d4fa50c23ef7d70f3701a8effd80d', 'addForeignKeyConstraint baseTableName=status_barang, constraintName=fk_status_barang_pembelian_id, referencedTableName=pembelian', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-83', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:23:08', 83, 'EXECUTED', '7:1b0c68950fcad681ed685850159d447b', 'addForeignKeyConstraint baseTableName=status_barang, constraintName=fk_status_barang_pembelian_return_id, referencedTableName=pembelian_return', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-84', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:23:10', 84, 'EXECUTED', '7:db77f47db7560b7dcb8f4ed0bdbb49d0', 'addForeignKeyConstraint baseTableName=status_barang, constraintName=fk_status_barang_penjualan_id, referencedTableName=penjualan', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-85', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:23:10', 85, 'EXECUTED', '7:abb264048af25a71f43c8197cd59b2db', 'addForeignKeyConstraint baseTableName=status_barang, constraintName=fk_status_barang_penjualan_return_id, referencedTableName=penjualan_return', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-86', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:23:12', 86, 'EXECUTED', '7:3f53eed47d678fdf916fbc6dc0e0212a', 'addForeignKeyConstraint baseTableName=status_barang, constraintName=fk_status_barang_penyesuaian_stok_d, referencedTableName=penyesuaian_stok', '', NULL, '3.5.3', NULL, NULL, '1804553827'),
	('1571472428398-87', 'User (generated)', '../../xml_db_schema/db.changelog-1.0.xml', '2019-10-23 12:23:14', 87, 'EXECUTED', '7:43219843533548f1bd2a00376ccbb981', 'addForeignKeyConstraint baseTableName=user, constraintName=fk_user_role_kode, referencedTableName=role', '', NULL, '3.5.3', NULL, NULL, '1804553827');
/*!40000 ALTER TABLE `databasechangelog` ENABLE KEYS */;

-- Dumping structure for table rumah_scarlett.databasechangeloglock
CREATE TABLE IF NOT EXISTS `databasechangeloglock` (
  `ID` int(11) NOT NULL,
  `LOCKED` bit(1) NOT NULL,
  `LOCKGRANTED` datetime DEFAULT NULL,
  `LOCKEDBY` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table rumah_scarlett.databasechangeloglock: ~0 rows (approximately)
/*!40000 ALTER TABLE `databasechangeloglock` DISABLE KEYS */;
INSERT INTO `databasechangeloglock` (`ID`, `LOCKED`, `LOCKGRANTED`, `LOCKEDBY`) VALUES
	(1, b'0', NULL, NULL);
/*!40000 ALTER TABLE `databasechangeloglock` ENABLE KEYS */;

-- Dumping structure for table rumah_scarlett.form_action
CREATE TABLE IF NOT EXISTS `form_action` (
  `form_name` varchar(100) NOT NULL,
  `form_text` varchar(100) DEFAULT NULL,
  `act_1` varchar(50) DEFAULT NULL,
  `act_2` varchar(50) DEFAULT NULL,
  `act_3` varchar(50) DEFAULT NULL,
  `act_4` varchar(50) DEFAULT NULL,
  `act_5` varchar(50) DEFAULT NULL,
  `act_6` varchar(50) DEFAULT NULL,
  `act_7` varchar(50) DEFAULT NULL,
  `act_8` varchar(50) DEFAULT NULL,
  `act_9` varchar(50) DEFAULT NULL,
  `act_10` varchar(50) DEFAULT NULL,
  `act_11` varchar(50) DEFAULT NULL,
  `act_12` varchar(50) DEFAULT NULL,
  `act_13` varchar(50) DEFAULT NULL,
  `act_14` varchar(50) DEFAULT NULL,
  `act_15` varchar(50) DEFAULT NULL,
  UNIQUE KEY `form_name_UNIQUE` (`form_name`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table rumah_scarlett.form_action: ~22 rows (approximately)
/*!40000 ALTER TABLE `form_action` DISABLE KEYS */;
INSERT INTO `form_action` (`form_name`, `form_text`, `act_1`, `act_2`, `act_3`, `act_4`, `act_5`, `act_6`, `act_7`, `act_8`, `act_9`, `act_10`, `act_11`, `act_12`, `act_13`, `act_14`, `act_15`) VALUES
	('BarangView', 'Barang', 'Tambah', 'Ubah', 'Hapus', 'Cetak', 'Penyesuain Stok', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
	('GrafikBarangTerjualView', 'Grafik Barang Terjual', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
	('HutangOperasionalView', 'Hutang Operasional', 'Tambah', 'Ubah', 'Hapus', 'Cetak', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
	('LaporanPembelianView', 'Laporan Pembelian', 'Hapus', 'Cetak', 'Detail', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
	('LaporanPengeluaranView', 'Laporan Pengeluaran', 'Hapus', 'Cetak', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
	('LaporanPenjualanView', 'Laporan Penjualan', 'Hapus', 'Cetak', 'Detail', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
	('LaporanReturnPembelianView', 'Laporan Return Pembelian', 'Hapus', 'Cetak', 'Detail', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
	('LaporanReturnPenjualanView', 'Laporan Return Penjualan', 'Hapus', 'Cetak', 'Detail', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
	('LaporanStatusPerBarangView', 'Laporan Status Per Barang', 'Cetak', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
	('PelangganView', 'Pelanggan', 'Tambah', 'Ubah', 'Hapus', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
	('PembelianView', 'Pembelian Barang', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
	('PengeluaranView', 'Pengeluaran', 'Tambah', 'Ubah', 'Hapus', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
	('PenjualanView', 'Penjualan Barang', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
	('PenyesuaianStokView', 'Penyesuaian Stok', 'Tambah', 'Ubah', 'Hapus', 'Cetak', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
	('ReturnPembelianView', 'Return Pembelian', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
	('ReturnPenjualanView', 'Return Penjualan', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
	('RoleView', 'Role', 'Update', 'Tambah', 'Ubah', 'Hapus', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
	('SatuanView', 'Satuan', 'Tambah', 'Ubah', 'Hapus', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
	('SubTipeView', 'Sub Tipe', 'Tambah', 'Ubah', 'Hapus', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
	('SupplierView', 'Supplier', 'Tambah', 'Ubah', 'Hapus', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
	('TipeView', 'Tipe', 'Tambah', 'Ubah', 'Hapus', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
	('UserView', 'User', 'Tambah', 'Ubah', 'Hapus', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);
/*!40000 ALTER TABLE `form_action` ENABLE KEYS */;

-- Dumping structure for table rumah_scarlett.hutang_operasional
CREATE TABLE IF NOT EXISTS `hutang_operasional` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `tanggal` date NOT NULL,
  `jumlah` decimal(19,0) NOT NULL DEFAULT 0,
  `keterangan` varchar(255) DEFAULT NULL,
  `status_hutang` bit(3) NOT NULL DEFAULT b'0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table rumah_scarlett.hutang_operasional: ~0 rows (approximately)
/*!40000 ALTER TABLE `hutang_operasional` DISABLE KEYS */;
/*!40000 ALTER TABLE `hutang_operasional` ENABLE KEYS */;

-- Dumping structure for table rumah_scarlett.kas_awal
CREATE TABLE IF NOT EXISTS `kas_awal` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `tanggal` date NOT NULL,
  `total` decimal(19,0) NOT NULL DEFAULT 0,
  PRIMARY KEY (`id`),
  UNIQUE KEY `tanggal` (`tanggal`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table rumah_scarlett.kas_awal: ~0 rows (approximately)
/*!40000 ALTER TABLE `kas_awal` DISABLE KEYS */;
/*!40000 ALTER TABLE `kas_awal` ENABLE KEYS */;

-- Dumping structure for table rumah_scarlett.pelanggan
CREATE TABLE IF NOT EXISTS `pelanggan` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `nama` varchar(255) NOT NULL,
  `alamat` varchar(255) DEFAULT NULL,
  `telpon` varchar(50) DEFAULT NULL,
  `keterangan` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table rumah_scarlett.pelanggan: ~0 rows (approximately)
/*!40000 ALTER TABLE `pelanggan` DISABLE KEYS */;
/*!40000 ALTER TABLE `pelanggan` ENABLE KEYS */;

-- Dumping structure for table rumah_scarlett.pembelian
CREATE TABLE IF NOT EXISTS `pembelian` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `supplier_id` int(10) unsigned NOT NULL,
  `tanggal` datetime(6) NOT NULL,
  `no_nota` varchar(255) NOT NULL,
  `diskon` decimal(19,0) NOT NULL DEFAULT 0,
  PRIMARY KEY (`id`),
  UNIQUE KEY `no_nota` (`no_nota`),
  KEY `fk_pembelian_supplier_id` (`supplier_id`),
  CONSTRAINT `fk_pembelian_supplier_id` FOREIGN KEY (`supplier_id`) REFERENCES `supplier` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table rumah_scarlett.pembelian: ~0 rows (approximately)
/*!40000 ALTER TABLE `pembelian` DISABLE KEYS */;
/*!40000 ALTER TABLE `pembelian` ENABLE KEYS */;

-- Dumping structure for table rumah_scarlett.pembelian_detail
CREATE TABLE IF NOT EXISTS `pembelian_detail` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `pembelian_id` int(10) unsigned NOT NULL,
  `barang_id` int(10) unsigned NOT NULL,
  `qty` int(11) NOT NULL,
  `qty_return` int(11) NOT NULL DEFAULT 0,
  `hpp` decimal(19,0) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_pembelian_barang_id` (`barang_id`),
  KEY `fk_pembelian_pembelian_id` (`pembelian_id`),
  CONSTRAINT `fk_pembelian_barang_id` FOREIGN KEY (`barang_id`) REFERENCES `barang` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_pembelian_pembelian_id` FOREIGN KEY (`pembelian_id`) REFERENCES `pembelian` (`id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table rumah_scarlett.pembelian_detail: ~0 rows (approximately)
/*!40000 ALTER TABLE `pembelian_detail` DISABLE KEYS */;
/*!40000 ALTER TABLE `pembelian_detail` ENABLE KEYS */;

-- Dumping structure for table rumah_scarlett.pembelian_return
CREATE TABLE IF NOT EXISTS `pembelian_return` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `tanggal` datetime(6) NOT NULL,
  `no_nota` varchar(255) NOT NULL,
  `pembelian_id` int(10) unsigned NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `no_nota` (`no_nota`),
  KEY `fk_pembelian_return_pembelian_id` (`pembelian_id`),
  CONSTRAINT `fk_pembelian_return_pembelian_id` FOREIGN KEY (`pembelian_id`) REFERENCES `pembelian` (`id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table rumah_scarlett.pembelian_return: ~0 rows (approximately)
/*!40000 ALTER TABLE `pembelian_return` DISABLE KEYS */;
/*!40000 ALTER TABLE `pembelian_return` ENABLE KEYS */;

-- Dumping structure for table rumah_scarlett.pembelian_return_detail
CREATE TABLE IF NOT EXISTS `pembelian_return_detail` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `pembelian_return_id` int(10) unsigned NOT NULL,
  `barang_id` int(10) unsigned NOT NULL,
  `qty` int(11) NOT NULL,
  `hpp` decimal(19,0) NOT NULL,
  `status` tinyint(3) NOT NULL DEFAULT 0,
  `keterangan` varchar(255) DEFAULT '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''',
  PRIMARY KEY (`id`),
  KEY `fk_pembelian_return_detail_barang_id` (`barang_id`),
  KEY `fk_pembelian_return_detail_pembelian_return_id` (`pembelian_return_id`),
  CONSTRAINT `fk_pembelian_return_detail_barang_id` FOREIGN KEY (`barang_id`) REFERENCES `barang` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_pembelian_return_detail_pembelian_return_id` FOREIGN KEY (`pembelian_return_id`) REFERENCES `pembelian_return` (`id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table rumah_scarlett.pembelian_return_detail: ~0 rows (approximately)
/*!40000 ALTER TABLE `pembelian_return_detail` DISABLE KEYS */;
/*!40000 ALTER TABLE `pembelian_return_detail` ENABLE KEYS */;

-- Dumping structure for table rumah_scarlett.pengeluaran
CREATE TABLE IF NOT EXISTS `pengeluaran` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `tanggal` datetime(6) NOT NULL,
  `nama` varchar(255) NOT NULL,
  `jumlah` decimal(19,0) NOT NULL,
  `keterangan` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table rumah_scarlett.pengeluaran: ~0 rows (approximately)
/*!40000 ALTER TABLE `pengeluaran` DISABLE KEYS */;
/*!40000 ALTER TABLE `pengeluaran` ENABLE KEYS */;

-- Dumping structure for table rumah_scarlett.penjualan
CREATE TABLE IF NOT EXISTS `penjualan` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `tanggal` datetime(6) NOT NULL,
  `no_nota` varchar(255) NOT NULL,
  `status_pembayaran` bit(3) NOT NULL DEFAULT b'0',
  `pelanggan_id` int(10) unsigned DEFAULT NULL,
  `diskon` decimal(19,0) NOT NULL DEFAULT 0,
  `jumlah_bayar` decimal(19,0) NOT NULL DEFAULT 0,
  PRIMARY KEY (`id`),
  UNIQUE KEY `no_nota` (`no_nota`),
  KEY `fk_penjualan_pelangan_id` (`pelanggan_id`),
  CONSTRAINT `fk_penjualan_pelangan_id` FOREIGN KEY (`pelanggan_id`) REFERENCES `pelanggan` (`id`) ON DELETE SET NULL ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table rumah_scarlett.penjualan: ~0 rows (approximately)
/*!40000 ALTER TABLE `penjualan` DISABLE KEYS */;
/*!40000 ALTER TABLE `penjualan` ENABLE KEYS */;

-- Dumping structure for table rumah_scarlett.penjualan_detail
CREATE TABLE IF NOT EXISTS `penjualan_detail` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `penjualan_id` int(10) unsigned NOT NULL,
  `barang_id` int(10) unsigned NOT NULL,
  `qty` int(11) NOT NULL,
  `qty_return` int(11) DEFAULT 0,
  `hpp` decimal(19,0) NOT NULL,
  `harga_jual` decimal(19,0) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_penjualan_barang_id` (`barang_id`),
  KEY `fk_penjualan_penjualan_id` (`penjualan_id`),
  CONSTRAINT `fk_penjualan_barang_id` FOREIGN KEY (`barang_id`) REFERENCES `barang` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_penjualan_penjualan_id` FOREIGN KEY (`penjualan_id`) REFERENCES `penjualan` (`id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table rumah_scarlett.penjualan_detail: ~0 rows (approximately)
/*!40000 ALTER TABLE `penjualan_detail` DISABLE KEYS */;
/*!40000 ALTER TABLE `penjualan_detail` ENABLE KEYS */;

-- Dumping structure for table rumah_scarlett.penjualan_return
CREATE TABLE IF NOT EXISTS `penjualan_return` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `tanggal` datetime(6) NOT NULL,
  `no_nota` varchar(255) NOT NULL,
  `penjualan_id` int(10) unsigned NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `no_nota` (`no_nota`),
  KEY `fk_penjualan_return_penjualan_id` (`penjualan_id`),
  CONSTRAINT `fk_penjualan_return_penjualan_id` FOREIGN KEY (`penjualan_id`) REFERENCES `penjualan` (`id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table rumah_scarlett.penjualan_return: ~0 rows (approximately)
/*!40000 ALTER TABLE `penjualan_return` DISABLE KEYS */;
/*!40000 ALTER TABLE `penjualan_return` ENABLE KEYS */;

-- Dumping structure for table rumah_scarlett.penjualan_return_detail
CREATE TABLE IF NOT EXISTS `penjualan_return_detail` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `penjualan_return_id` int(10) unsigned NOT NULL,
  `barang_id` int(10) unsigned NOT NULL,
  `qty` int(11) NOT NULL,
  `hpp` decimal(19,0) NOT NULL,
  `harga_jual` decimal(19,0) NOT NULL,
  `status` tinyint(3) NOT NULL DEFAULT 0,
  `keterangan` varchar(255) DEFAULT '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''',
  PRIMARY KEY (`id`),
  KEY `fk_penjualan_return_detail_barang_id` (`barang_id`),
  KEY `fk_penjualan_return_detail_penjualan_return_id` (`penjualan_return_id`),
  CONSTRAINT `fk_penjualan_return_detail_barang_id` FOREIGN KEY (`barang_id`) REFERENCES `barang` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_penjualan_return_detail_penjualan_return_id` FOREIGN KEY (`penjualan_return_id`) REFERENCES `penjualan_return` (`id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table rumah_scarlett.penjualan_return_detail: ~0 rows (approximately)
/*!40000 ALTER TABLE `penjualan_return_detail` DISABLE KEYS */;
/*!40000 ALTER TABLE `penjualan_return_detail` ENABLE KEYS */;

-- Dumping structure for table rumah_scarlett.penyesuaian_stok
CREATE TABLE IF NOT EXISTS `penyesuaian_stok` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `barang_id` int(10) unsigned NOT NULL,
  `satuan_id` int(10) unsigned NOT NULL,
  `tanggal` datetime(6) NOT NULL,
  `qty` int(11) NOT NULL,
  `hpp` decimal(19,0) NOT NULL,
  `keterangan` varchar(255) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_penyesuaian_stok_barang_id` (`barang_id`),
  KEY `fk_penyesuaian_stok_satuan_id` (`satuan_id`),
  CONSTRAINT `fk_penyesuaian_stok_barang_id` FOREIGN KEY (`barang_id`) REFERENCES `barang` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_penyesuaian_stok_satuan_id` FOREIGN KEY (`satuan_id`) REFERENCES `satuan` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table rumah_scarlett.penyesuaian_stok: ~0 rows (approximately)
/*!40000 ALTER TABLE `penyesuaian_stok` DISABLE KEYS */;
/*!40000 ALTER TABLE `penyesuaian_stok` ENABLE KEYS */;

-- Dumping structure for table rumah_scarlett.role
CREATE TABLE IF NOT EXISTS `role` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `kode` varchar(255) NOT NULL,
  `nama` varchar(255) NOT NULL,
  `keterangan` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `kode` (`kode`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

-- Dumping data for table rumah_scarlett.role: ~2 rows (approximately)
/*!40000 ALTER TABLE `role` DISABLE KEYS */;
INSERT INTO `role` (`id`, `kode`, `nama`, `keterangan`) VALUES
	(1, 'adm', 'Administrator', NULL),
	(2, 'opr', 'Operator', '');
/*!40000 ALTER TABLE `role` ENABLE KEYS */;

-- Dumping structure for table rumah_scarlett.role_detail
CREATE TABLE IF NOT EXISTS `role_detail` (
  `role_kode` varchar(255) NOT NULL,
  `menu_name` varchar(255) NOT NULL,
  `menu_parent` varchar(255) DEFAULT NULL,
  `form_action` varchar(255) DEFAULT NULL,
  `tag` varchar(255) NOT NULL,
  KEY `fk_role_detail_role_kode` (`role_kode`),
  CONSTRAINT `fk_role_detail_role_kode` FOREIGN KEY (`role_kode`) REFERENCES `role` (`kode`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table rumah_scarlett.role_detail: ~0 rows (approximately)
/*!40000 ALTER TABLE `role_detail` DISABLE KEYS */;
INSERT INTO `role_detail` (`role_kode`, `menu_name`, `menu_parent`, `form_action`, `tag`) VALUES
	('adm', 'Tambah', 'Master', 'UserView', 'action'),
	('adm', 'Ubah', 'Master', 'UserView', 'action'),
	('adm', 'Hapus', 'Master', 'UserView', 'action'),
	('adm', 'Tambah', 'Master', 'SubTipeView', 'action'),
	('adm', 'Ubah', 'Master', 'SubTipeView', 'action'),
	('adm', 'Hapus', 'Master', 'SubTipeView', 'action'),
	('adm', 'Tambah', 'Master', 'TipeView', 'action'),
	('adm', 'Ubah', 'Master', 'TipeView', 'action'),
	('adm', 'Hapus', 'Master', 'TipeView', 'action'),
	('adm', 'Tambah', 'Master', 'SupplierView', 'action'),
	('adm', 'Ubah', 'Master', 'SupplierView', 'action'),
	('adm', 'Hapus', 'Master', 'SupplierView', 'action'),
	('adm', 'Tambah', 'Master', 'SatuanView', 'action'),
	('adm', 'Ubah', 'Master', 'SatuanView', 'action'),
	('adm', 'Hapus', 'Master', 'SatuanView', 'action'),
	('adm', 'Update', 'Master', 'RoleView', 'action'),
	('adm', 'Tambah', 'Master', 'RoleView', 'action'),
	('adm', 'Ubah', 'Master', 'RoleView', 'action'),
	('adm', 'Hapus', 'Master', 'RoleView', 'action'),
	('adm', 'Tambah', 'Data', 'PenyesuaianStokView', 'action'),
	('adm', 'Ubah', 'Data', 'PenyesuaianStokView', 'action'),
	('adm', 'Hapus', 'Data', 'PenyesuaianStokView', 'action'),
	('adm', 'Cetak', 'Data', 'PenyesuaianStokView', 'action'),
	('adm', 'Hapus', 'Laporan', 'LaporanPenjualanView', 'action'),
	('adm', 'Cetak', 'Laporan', 'LaporanPenjualanView', 'action'),
	('adm', 'Detail', 'Laporan', 'LaporanPenjualanView', 'action'),
	('adm', 'Hapus', 'Laporan', 'LaporanReturnPenjualanView', 'action'),
	('adm', 'Cetak', 'Laporan', 'LaporanReturnPenjualanView', 'action'),
	('adm', 'Detail', 'Laporan', 'LaporanReturnPenjualanView', 'action'),
	('adm', 'Hapus', 'Laporan', 'LaporanPengeluaranView', 'action'),
	('adm', 'Cetak', 'Laporan', 'LaporanPengeluaranView', 'action'),
	('adm', 'Tambah', 'Transaksi', 'PengeluaranView', 'action'),
	('adm', 'Ubah', 'Transaksi', 'PengeluaranView', 'action'),
	('adm', 'Hapus', 'Transaksi', 'PengeluaranView', 'action'),
	('adm', 'Hapus', 'Laporan', 'LaporanPembelianView', 'action'),
	('adm', 'Cetak', 'Laporan', 'LaporanPembelianView', 'action'),
	('adm', 'Detail', 'Laporan', 'LaporanPembelianView', 'action'),
	('adm', 'Hapus', 'Laporan', 'LaporanReturnPembelianView', 'action'),
	('adm', 'Cetak', 'Laporan', 'LaporanReturnPembelianView', 'action'),
	('adm', 'Detail', 'Laporan', 'LaporanReturnPembelianView', 'action'),
	('adm', 'Tambah', 'Master', 'PelangganView', 'action'),
	('adm', 'Ubah', 'Master', 'PelangganView', 'action'),
	('adm', 'Hapus', 'Master', 'PelangganView', 'action'),
	('adm', 'Cetak', 'Laporan', 'LaporanStatusPerBarangView', 'action'),
	('adm', 'Tambah', 'Data', 'HutangOperasionalView', 'action'),
	('adm', 'Ubah', 'Data', 'HutangOperasionalView', 'action'),
	('adm', 'Hapus', 'Data', 'HutangOperasionalView', 'action'),
	('adm', 'Cetak', 'Data', 'HutangOperasionalView', 'action'),
	('adm', 'Tambah', 'Master', 'BarangView', 'action'),
	('adm', 'Ubah', 'Master', 'BarangView', 'action'),
	('adm', 'Hapus', 'Master', 'BarangView', 'action'),
	('adm', 'Cetak', 'Master', 'BarangView', 'action'),
	('adm', 'Penyesuain Stok', 'Master', 'BarangView', 'action'),
	('adm', 'Master', 'Master', NULL, 'menu'),
	('adm', 'Tipe', 'Master', NULL, 'menu'),
	('adm', 'TipeView', 'Master', NULL, 'menuForm'),
	('adm', 'SubTipeView', 'Master', NULL, 'menuForm'),
	('adm', 'SupplierView', 'Master', NULL, 'menuForm'),
	('adm', 'SatuanView', 'Master', NULL, 'menuForm'),
	('adm', 'BarangView', 'Master', NULL, 'menuForm'),
	('adm', 'PelangganView', 'Master', NULL, 'menuForm'),
	('adm', 'UserView', 'Master', NULL, 'menuForm'),
	('adm', 'RoleView', 'Master', NULL, 'menuForm'),
	('adm', 'Data', 'Data', NULL, 'menu'),
	('adm', 'PenyesuaianStokView', 'Data', NULL, 'menuForm'),
	('adm', 'HutangOperasionalView', 'Data', NULL, 'menuForm'),
	('adm', 'Transaksi', 'Transaksi', NULL, 'menu'),
	('adm', 'KasAwalView', 'Transaksi', NULL, 'menuForm'),
	('adm', 'PenjualanView', 'Transaksi', NULL, 'menuForm'),
	('adm', 'PembelianView', 'Transaksi', NULL, 'menuForm'),
	('adm', 'PengeluaranView', 'Transaksi', NULL, 'menuForm'),
	('adm', 'Return', 'Transaksi', NULL, 'menu'),
	('adm', 'ReturnPenjualanView', 'Transaksi', NULL, 'menuForm'),
	('adm', 'ReturnPembelianView', 'Transaksi', NULL, 'menuForm'),
	('adm', 'Laporan', 'Laporan', NULL, 'menu'),
	('adm', 'LaporanPenjualanView', 'Laporan', NULL, 'menuForm'),
	('adm', 'LaporanPembelianView', 'Laporan', NULL, 'menuForm'),
	('adm', 'LaporanPengeluaranView', 'Laporan', NULL, 'menuForm'),
	('adm', 'Return', 'Laporan', NULL, 'menu'),
	('adm', 'LaporanReturnPenjualanView', 'Laporan', NULL, 'menuForm'),
	('adm', 'LaporanReturnPembelianView', 'Laporan', NULL, 'menuForm'),
	('adm', 'Status Barang', 'Laporan', NULL, 'menu'),
	('adm', 'LaporanStatusBarangView', 'Laporan', NULL, 'menuForm'),
	('adm', 'LaporanStatusPerBarangView', 'Laporan', NULL, 'menuForm'),
	('adm', 'Grafik', 'Laporan', NULL, 'menu'),
	('adm', 'GrafikBarangTerjualView', 'Laporan', NULL, 'menuForm'),
	('adm', 'LaporanLabaRugiView', 'Laporan', NULL, 'menuForm'),
	('adm', 'Database', 'Database', NULL, 'menu'),
	('adm', 'Alat', 'Alat', NULL, 'menu'),
	('adm', 'PengaturanView', 'Alat', NULL, 'menuForm');
/*!40000 ALTER TABLE `role_detail` ENABLE KEYS */;

-- Dumping structure for table rumah_scarlett.satuan
CREATE TABLE IF NOT EXISTS `satuan` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `nama` varchar(255) NOT NULL,
  `keterangan` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `nama_UNIQUE` (`nama`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table rumah_scarlett.satuan: ~0 rows (approximately)
/*!40000 ALTER TABLE `satuan` DISABLE KEYS */;
/*!40000 ALTER TABLE `satuan` ENABLE KEYS */;

-- Dumping structure for table rumah_scarlett.status_barang
CREATE TABLE IF NOT EXISTS `status_barang` (
  `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `tanggal` datetime(6) NOT NULL,
  `pembelian_id` int(10) unsigned DEFAULT NULL,
  `penjualan_id` int(10) unsigned DEFAULT NULL,
  `penyesuaian_stok_id` int(10) unsigned DEFAULT NULL,
  `pembelian_return_id` int(10) unsigned DEFAULT NULL,
  `penjualan_return_id` int(10) unsigned DEFAULT NULL,
  `stok_awal` int(11) NOT NULL DEFAULT 0,
  `stok_masuk` int(11) DEFAULT 0,
  `stok_terjual` int(11) DEFAULT 0,
  `penyesuaian_stok` int(11) DEFAULT 0,
  `pembelian_return_qty` int(11) DEFAULT 0,
  `penjualan_return_qty` int(11) DEFAULT 0,
  `stok_akhir` int(11) NOT NULL DEFAULT 0,
  PRIMARY KEY (`id`),
  KEY `fk_status_barang_pembelian_id` (`pembelian_id`),
  KEY `fk_status_barang_pembelian_return_id` (`pembelian_return_id`),
  KEY `fk_status_barang_penjualan_id` (`penjualan_id`),
  KEY `fk_status_barang_penjualan_return_id` (`penjualan_return_id`),
  KEY `fk_status_barang_penyesuaian_stok_d_idx` (`penyesuaian_stok_id`),
  CONSTRAINT `fk_status_barang_pembelian_id` FOREIGN KEY (`pembelian_id`) REFERENCES `pembelian` (`id`) ON DELETE CASCADE ON UPDATE NO ACTION,
  CONSTRAINT `fk_status_barang_pembelian_return_id` FOREIGN KEY (`pembelian_return_id`) REFERENCES `pembelian_return` (`id`) ON DELETE CASCADE ON UPDATE NO ACTION,
  CONSTRAINT `fk_status_barang_penjualan_id` FOREIGN KEY (`penjualan_id`) REFERENCES `penjualan` (`id`) ON DELETE CASCADE ON UPDATE NO ACTION,
  CONSTRAINT `fk_status_barang_penjualan_return_id` FOREIGN KEY (`penjualan_return_id`) REFERENCES `penjualan_return` (`id`) ON DELETE CASCADE ON UPDATE NO ACTION,
  CONSTRAINT `fk_status_barang_penyesuaian_stok_d` FOREIGN KEY (`penyesuaian_stok_id`) REFERENCES `penyesuaian_stok` (`id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table rumah_scarlett.status_barang: ~0 rows (approximately)
/*!40000 ALTER TABLE `status_barang` DISABLE KEYS */;
/*!40000 ALTER TABLE `status_barang` ENABLE KEYS */;

-- Dumping structure for table rumah_scarlett.sub_tipe
CREATE TABLE IF NOT EXISTS `sub_tipe` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `nama` varchar(255) NOT NULL,
  `keterangan` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `nama` (`nama`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table rumah_scarlett.sub_tipe: ~0 rows (approximately)
/*!40000 ALTER TABLE `sub_tipe` DISABLE KEYS */;
/*!40000 ALTER TABLE `sub_tipe` ENABLE KEYS */;

-- Dumping structure for table rumah_scarlett.supplier
CREATE TABLE IF NOT EXISTS `supplier` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `nama` varchar(255) NOT NULL,
  `alamat` varchar(255) DEFAULT NULL,
  `telpon` varchar(50) DEFAULT NULL,
  `fax` varchar(50) DEFAULT NULL,
  `email` varchar(255) DEFAULT NULL,
  `website` varchar(255) DEFAULT NULL,
  `contact_person` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `nama` (`nama`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table rumah_scarlett.supplier: ~0 rows (approximately)
/*!40000 ALTER TABLE `supplier` DISABLE KEYS */;
/*!40000 ALTER TABLE `supplier` ENABLE KEYS */;

-- Dumping structure for table rumah_scarlett.tipe
CREATE TABLE IF NOT EXISTS `tipe` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `nama` varchar(255) NOT NULL,
  `keterangan` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `nama` (`nama`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table rumah_scarlett.tipe: ~0 rows (approximately)
/*!40000 ALTER TABLE `tipe` DISABLE KEYS */;
/*!40000 ALTER TABLE `tipe` ENABLE KEYS */;

-- Dumping structure for table rumah_scarlett.user
CREATE TABLE IF NOT EXISTS `user` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `login_id` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  `role_kode` varchar(255) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `login_id_UNIQUE` (`login_id`),
  KEY `fk_user_role_kode` (`role_kode`),
  CONSTRAINT `fk_user_role_kode` FOREIGN KEY (`role_kode`) REFERENCES `role` (`kode`) ON DELETE NO ACTION ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

-- Dumping data for table rumah_scarlett.user: ~0 rows (approximately)
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` (`id`, `login_id`, `password`, `role_kode`) VALUES
	(1, 'admin', '1000:+rQ2d9EsKMK5of62nL0ct10skO2kg//+:d7K5beDiXstpiezFXK+OoOcNYZMl1Q8e', 'adm'),
	(2, 'user1', '1000:QVxNKaVPRl/c+mOLdx1N2FsiO4j9iFfZ:/ZrdstTWqdmiqQOVgQRnrZeMUaSzc5+y', 'opr'),
	(3, 'user2', '1000:thY+CEvbeWwOWntvB94ds1OCC0Erlmqk:DPjI2U1RfVxI6XactbnBRbK+/XT74yRv', 'opr'),
	(4, 'user3', '1000:hR6lQldXOwZIPhFn82aZQN3NLCPlcQBB:P6xKPgvLir7pGzQnZnqjQJ49jDYTwoLk', 'opr');
/*!40000 ALTER TABLE `user` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
