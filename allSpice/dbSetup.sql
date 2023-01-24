CREATE TABLE
    IF NOT EXISTS accounts(
        id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'User Name',
        email varchar(255) COMMENT 'User Email',
        picture varchar(255) COMMENT 'User Picture'
    ) default charset utf8 COMMENT '';

CREATE TABLE
    recipes(
        id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        title VARCHAR(50) NOT NULL,
        instructions TEXT NOT NULL,
        img VARCHAR(255) NOT NULL DEFAULT 'https://i.natgeofe.com/k/c3acb8e8-eb30-4b53-8fc5-4ae9f0de9c4c/ww-funny-animal-faces-hippopotamus_3x2.jpg',
        category VARCHAR(50) NOT NULL,
        creatorId VARCHAR(255) NOT NULL,
        Foreign Key (creatorId) REFERENCES accounts (id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';

DROP TABLE recipes;

CREATE TABLE
    ingredient(
        id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
        name VARCHAR(50),
        quantity TEXT NOT NULL,
        recipeId INT NOT NULL,
        creatorId VARCHAR(255),
        FOREIGN KEY (creatorId) REFERENCES accounts (id),
        FOREIGN KEY (recipeId) REFERENCES recipes (id)
    ) default charset utf8 COMMENT '';

DROP TABLE ingredient;

CREATE TABLE
    favorites(
        id INT AUTO_INCREMENT PRIMARY KEY,
        recipeId INT NOT NULL,
        accountId VARCHAR(255) NOT NULL,
        FOREIGN KEY (recipeId) REFERENCES recipes(id) ON DELETE CASCADE,
        FOREIGN KEY (accountId) REFERENCES accounts(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';

DROP TABLE favorite;

--

SELECT * FROM recipes WHERE category LIKE '%%';

SELECT * FROM favorites WHERE id = 7;