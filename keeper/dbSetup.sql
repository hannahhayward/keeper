CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';
CREATE TABLE IF NOT EXISTS keeps(
  id INT NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT ' Name',
  creatorId VARCHAR(255) NOT NULL COMMENT 'FK: accounts Id',
  description varchar(255) COMMENT ' description',
  img varchar(255) COMMENT ' img',
  views INT NOT NULL COMMENT 'views',
  shares INT NOT NULL COMMENT 'shares',
  keeps INT NOT NULL COMMENT 'keeps',
  FOREIGN KEY(creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';
