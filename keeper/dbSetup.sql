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
CREATE TABLE IF NOT EXISTS comments(
  id INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
  body VARCHAR(255) NOT NULL,
  creatorId VARCHAR(255) COMMENT 'FK: accounts Id',
  keepId INT NOT NULL COMMENT 'fk: keeps id',
  FOREIGN KEY(keepId) REFERENCES keeps(id) ON DELETE CASCADE,
  FOREIGN KEY(creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) DEFAULT charset utf8 COMMENT '';
 DROP Table comments;
INSERT INTO comments (body, keepId, creatorId, id)
VALUES ('omg i just died a little', 2, '60cd2121284bdd8665f4b926', 1);