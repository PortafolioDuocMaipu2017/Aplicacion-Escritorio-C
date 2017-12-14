Select Usuario.NOMBREUSUARIO, Usuario.PW, Usuario.ESTADO, Rol.NOMBREROL from Usuario
INNER JOIN Rol
ON Usuario.NOMBREUSUARIO = Rol.USUARIO_NOMBREUSUARIO
where Usuario.NOMBREUSUARIO = "" and Usuario.PW = "";

Select * from Rol;


INSERT INTO USUARIO VALUES ('wea','wea','1');
INSERT INTO ROL VALUES (3, 'administrador','wea');
INSERT INTO DESTINO VALUES(1, 'Brazil',1,250000);
select * from destino;
commit;