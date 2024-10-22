CREATE TABLE
  IF NOT EXISTS accounts (
    id VARCHAR(255) NOT NULL PRIMARY key COMMENT 'primary key',
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
    name VARCHAR(255) COMMENT 'User Name',
    email VARCHAR(255) UNIQUE COMMENT 'User Email',
    picture VARCHAR(255) COMMENT 'User Picture'
  ) DEFAULT charset utf8mb4 COMMENT '';

CREATE TABLE
  cryptids (
    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    name TINYTEXT NOT NULL,
    threatLevel TINYINT UNSIGNED NOT NULL,
    imgUrl TEXT NOT NULL,
    origin ENUM (
      'extra-terrestrial',
      'subterranean',
      'aquatic',
      'lab-grown',
      'suburban',
      'cross-dimensional'
    ) NOT NULL,
    size ENUM ('rodent', 'humanoid', 'giant', 'colossal') NOT NULL,
    cryptidCode TINYTEXT NOT NULL,
    discovererId VARCHAR(255) NOT NULL,
    FOREIGN KEY (discovererId) REFERENCES accounts (id) ON DELETE CASCADE
  );

CREATE TABLE
  trackedCryptids (
    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    cryptidId INT NOT NULL,
    accountId VARCHAR(255) NOT NULL,
    FOREIGN KEY (cryptidId) REFERENCES cryptids (id) ON DELETE CASCADE,
    FOREIGN KEY (accountId) REFERENCES accounts (id) ON DELETE CASCADE,
    UNIQUE (cryptidId, accountId)
  );

SELECT
  trackedCryptids.*,
  accounts.*
FROM
  trackedCryptids
  JOIN accounts ON accounts.id = trackedCryptids.accountId
WHERE
  trackedCryptids.id = 9;