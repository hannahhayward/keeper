CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';
CREATE TABLE IF NOT EXISTS keeps(
  id INT AUTO_INCREMENT NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT ' Name',
  creatorId VARCHAR(255) COMMENT 'FK: accounts Id',
  description varchar(255) COMMENT ' description',
  img varchar(255) COMMENT ' img',
  views INT COMMENT 'views',
  shares INT COMMENT 'shares',
  keeps INT COMMENT 'keeps',
  FOREIGN KEY(creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';
CREATE TABLE IF NOT EXISTS vaults(
  id INT AUTO_INCREMENT NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT ' Name',
  creatorId VARCHAR(255) COMMENT 'FK: accounts Id',
  description varchar(255) COMMENT ' description',
  isPrivate TINYINT COMMENT 'privacy',
  FOREIGN KEY(creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';
CREATE TABLE IF NOT EXISTS vaultkeeps(
  id INT AUTO_INCREMENT NOT NULL primary key COMMENT 'primary key',
  creatorId VARCHAR(255) COMMENT 'FK: accounts Id',
  vaultId INT COMMENT 'FK: vaults Id',
  keepId INT COMMENT 'FK: keeps Id',
  FOREIGN KEY(creatorId) REFERENCES accounts(id) ON DELETE CASCADE,
  FOREIGN KEY(vaultId) REFERENCES vaults(id) ON DELETE CASCADE,
  FOREIGN KEY(keepId) REFERENCES keeps(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';
CREATE TABLE IF NOT EXISTS profiles(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';
 DROP Table vaults;
INSERT INTO accounts (name, picture, id)
VALUES ('unknownUser_1', 'https://bnaic2021.uni.lu/wp-content/uploads/sites/219/2021/04/avatars-fuFi52Szkbdm16Gg-arzAGQ-t500x500.jpg', 4);