USE MASTER

IF EXISTS (SELECT * FROM SYS.databases WHERE NAME = 'Acesso')
BEGIN
	ALTER DATABASE Acesso
	SET SINGLE_USER
	WITH ROLLBACK IMMEDIATE

	DROP DATABASE Acesso
END
	
CREATE DATABASE Acesso
GO

USE Acesso

CREATE TABLE Role
(
	RoleId INT IDENTITY PRIMARY KEY, 
	RoleNome VARCHAR(10) NOT NULL UNIQUE
)

CREATE TABLE Login
(
	LoginId INT IDENTITY PRIMARY KEY, 
	LoginNome VARCHAR(10) NOT NULL UNIQUE, 
	LoginSenha VARCHAR(10) NOT NULL
)

CREATE TABLE RoleLogin
(
    RoleId INT REFERENCES Role, 
    LoginId INT REFERENCES Login, 
    PRIMARY KEY(RoleId, LoginId)
)
 
INSERT Role VALUES ('ADMIN') --1
INSERT Role VALUES ('FINANCEIRO') --2
INSERT Role VALUES ('PRODUCAO') --3

INSERT Login VALUES ('ADMIN', 'ADMIN') --1
INSERT Login VALUES ('USUARIO', 'USUARIO') --2
INSERT Login VALUES ('ALEXANDRE', 'Pa$$w0rd') --3

INSERT RoleLogin VALUES (1, 1) --ADMIN X ADMIN
INSERT RoleLogin VALUES (3, 2) --PRODUCAO X USUARIO
