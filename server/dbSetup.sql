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