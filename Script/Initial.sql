CREATE DATABASE Devops;

Use Devops;

CREATE TABLE Usuario (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Nome VARCHAR(100) NOT NULL,
    Sobrenome VARCHAR(100) NOT NULL,
    Idade INT NOT NULL,
    Genero ENUM('Masculino', 'Feminino', 'Outro') NOT NULL
);
