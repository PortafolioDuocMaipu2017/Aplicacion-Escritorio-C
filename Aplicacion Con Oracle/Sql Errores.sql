CREATE SEQUENCE GlobalSequence;

CREATE TABLE Actividad (
  codigoActividad INTEGER   NOT NULL ,
  codigoTipoActividad INTEGER   NOT NULL ,
  fechaInicio DATE    ,
  fechaTermino DATE      ,
PRIMARY KEY(codigoActividad)  );


CREATE INDEX Actividad_FKIndex1 ON Actividad (codigoTipoActividad);


CREATE OR REPLACE TRIGGER AINC_Actividad
BEFORE INSERT  ON Actividad
FOR EACH ROW 
BEGIN 
  IF (:NEW.codigoActividad IS NULL) THEN 
    SELECT GlobalSequence.NEXTVAL INTO :NEW.codigoActividad FROM DUAL; 
  END IF; 
END; 

/

CREATE TABLE Alumno (
  rutAlumno VARCHAR(10)   NOT NULL ,
  loginUsuario VARCHAR(30)   NOT NULL ,
  codigoCurso INTEGER   NOT NULL ,
  rutApoderado VARCHAR(10)   NOT NULL ,
  dv VARCHAR(1)   NOT NULL ,
  nombre VARCHAR(50)    ,
  apellidoPaterno VARCHAR(50)    ,
  apellidoMaterno VARCHAR(50)    ,
  correo VARCHAR(50)      ,
PRIMARY KEY(rutAlumno)    );


CREATE INDEX Alumno_FKIndex1 ON Alumno (rutApoderado, loginUsuario);
CREATE INDEX Alumno_FKIndex2 ON Alumno (codigoCurso);



CREATE TABLE Apoderado (
  rutApoderado VARCHAR(10)   NOT NULL ,
  loginUsuario VARCHAR(30)   NOT NULL ,
  codigoActividad INTEGER   NOT NULL ,
  dv VARCHAR(1)   NOT NULL ,
  nombreCompleto VARCHAR(30)    ,
  apellidoPaterno VARCHAR(30)    ,
  apellidoMaterno VARCHAR(30)    ,
  esEncargado number(1)     ,
PRIMARY KEY(rutApoderado, loginUsuario)    );


CREATE INDEX Apoderado_FKIndex1 ON Apoderado (codigoActividad);
CREATE INDEX Apoderado_FKIndex2 ON Apoderado (loginUsuario);



CREATE TABLE Colegio (
  codigoColegio INTEGER   NOT NULL ,
  nombre VARCHAR(50)    ,
  direccion VARCHAR(50)    ,
  telefono INTEGER    ,
  email VARCHAR(50)      ,
PRIMARY KEY(codigoColegio));


CREATE OR REPLACE TRIGGER AINC_Colegio
BEFORE INSERT  ON Colegio
FOR EACH ROW 
BEGIN 
  IF (:NEW.codigoColegio IS NULL) THEN 
    SELECT GlobalSequence.NEXTVAL INTO :NEW.codigoColegio FROM DUAL; 
  END IF; 
END; 

/



CREATE TABLE Contrato (
  codigoContrato INTEGER   NOT NULL ,
  codigoEncargado INTEGER   NOT NULL ,
  codigoDestino INTEGER   NOT NULL ,
  codigoServicio INTEGER   NOT NULL ,
  fechaContrato DATE    ,
  pagoTotal DECIMAL(13,3)    ,
  fechaDestino DATE    ,
  nombreArchivoPDF VARCHAR(50)      ,
PRIMARY KEY(codigoContrato)      );


CREATE INDEX Contrato_FKIndex1 ON Contrato (codigoServicio);
CREATE INDEX Contrato_FKIndex2 ON Contrato (codigoDestino);
CREATE INDEX Contrato_FKIndex3 ON Contrato (codigoEncargado);


CREATE OR REPLACE TRIGGER AINC_Contrato
BEFORE INSERT  ON Contrato
FOR EACH ROW 
BEGIN 
  IF (:NEW.codigoContrato IS NULL) THEN 
    SELECT GlobalSequence.NEXTVAL INTO :NEW.codigoContrato FROM DUAL; 
  END IF; 
END; 

/


Drop Table Ciudad;
CREATE TABLE Ciudad (
  codigoCiudad INTEGER   NOT NULL ,
  codigoPais INTEGER   NOT NULL ,
  Ciudad VARCHAR(30)      ,
PRIMARY KEY(codigoCiudad, codigoPais)  );
CREATE INDEX Ciudad_FKIndex1 ON Ciudad (codigoPais);


CREATE OR REPLACE TRIGGER AINC_Ciudad
BEFORE INSERT  ON Ciudad
FOR EACH ROW 
BEGIN 
  IF (:NEW.codigoCiudad IS NULL) THEN 
    SELECT GlobalSequence.NEXTVAL INTO :NEW.codigoCiudad FROM DUAL; 
  END IF; 
END; 

/



CREATE TABLE Curso (
  codigoCurso INTEGER   NOT NULL ,
  codigoColegio INTEGER   NOT NULL ,
  nombreCurso VARCHAR(10)      ,
PRIMARY KEY(codigoCurso)  );


CREATE INDEX Curso_FKIndex1 ON Curso (codigoColegio);


CREATE OR REPLACE TRIGGER AINC_Curso
BEFORE INSERT  ON Curso
FOR EACH ROW 
BEGIN 
  IF (:NEW.codigoCurso IS NULL) THEN 
    SELECT GlobalSequence.NEXTVAL INTO :NEW.codigoCurso FROM DUAL; 
  END IF; 
END; 

/



CREATE TABLE Deposito (
  codigoDeposito INTEGER   NOT NULL ,
  loginUsuario VARCHAR(30)   NOT NULL ,
  rutApoderado VARCHAR(10)   NOT NULL ,
  tipoDeposito VARCHAR(30)    ,
  valorDeposito DECIMAL(13,3)    ,
  cuenta VARCHAR(30)      ,
PRIMARY KEY(codigoDeposito)  );


CREATE INDEX Deposito_FKIndex1 ON Deposito (rutApoderado, loginUsuario);


CREATE OR REPLACE TRIGGER AINC_Deposito
BEFORE INSERT  ON Deposito
FOR EACH ROW 
BEGIN 
  IF (:NEW.codigoDeposito IS NULL) THEN 
    SELECT GlobalSequence.NEXTVAL INTO :NEW.codigoDeposito FROM DUAL; 
  END IF; 
END; 

/



CREATE TABLE Destino (
  codigoDestino INTEGER   NOT NULL ,
  codigoPais INTEGER   NOT NULL ,
  codigoCiudad INTEGER   NOT NULL ,
  direccion VARCHAR(30)      ,
PRIMARY KEY(codigoDestino)    );


CREATE INDEX Destino_FKIndex1 ON Destino (codigoPais);
CREATE INDEX Destino_FKIndex2 ON Destino (codigoCiudad, codigoPais);


CREATE OR REPLACE TRIGGER AINC_Destino
BEFORE INSERT  ON Destino
FOR EACH ROW 
BEGIN 
  IF (:NEW.codigoDestino IS NULL) THEN 
    SELECT GlobalSequence.NEXTVAL INTO :NEW.codigoDestino FROM DUAL; 
  END IF; 
END; 

/



CREATE TABLE Empresa_Servicio (
  codigoEmpresa INTEGER   NOT NULL ,
  nombreEmpresa VARCHAR(50)    ,
  rubroEmpresa VARCHAR(30)      ,
PRIMARY KEY(codigoEmpresa));


CREATE OR REPLACE TRIGGER AINC_Empresa_Servicio
BEFORE INSERT  ON Empresa_Servicio
FOR EACH ROW 
BEGIN 
  IF (:NEW.codigoEmpresa IS NULL) THEN 
    SELECT GlobalSequence.NEXTVAL INTO :NEW.codigoEmpresa FROM DUAL; 
  END IF; 
END; 

/



CREATE TABLE Encargado_Venta (
  codigoEncargado INTEGER   NOT NULL ,
  loginUsuario VARCHAR(30)   NOT NULL ,
  nombre VARCHAR(50)    ,
  apellidoPaterno VARCHAR(50)    ,
  apellidoMaterno VARCHAR(50)    ,
  telefono INTEGER    ,
  direccion VARCHAR(50)    ,
  email VARCHAR(50)      ,
PRIMARY KEY(codigoEncargado)  );


CREATE INDEX Encargado_Venta_FKIndex1 ON Encargado_Venta (loginUsuario);


CREATE OR REPLACE TRIGGER AINC_Encargado_Venta
BEFORE INSERT  ON Encargado_Venta
FOR EACH ROW 
BEGIN 
  IF (:NEW.codigoEncargado IS NULL) THEN 
    SELECT GlobalSequence.NEXTVAL INTO :NEW.codigoEncargado FROM DUAL; 
  END IF; 
END; 

/


drop Table Pais;
CREATE TABLE Pais (
  codigoPais INTEGER NOT NULL ,
  nombrePais VARCHAR(30)      ,
PRIMARY KEY(codigoPais));
commit;

CREATE OR REPLACE TRIGGER AINC_Pais
BEFORE INSERT  ON Pais
FOR EACH ROW 
BEGIN 
  IF (:NEW.codigoPais IS NULL) THEN 
    SELECT GlobalSequence.NEXTVAL INTO :NEW.codigoPais FROM DUAL; 
  END IF; 
END; 

/



CREATE TABLE Rol (
  codigoRol INTEGER   NOT NULL ,
  loginUsuario VARCHAR(30)   NOT NULL ,
  nombreRol VARCHAR(30)   NOT NULL ,
PRIMARY KEY(loginUsuario));


CREATE INDEX Rol_FKIndex1 ON Rol (loginUsuario);
CREATE UNIQUE INDEX UNIQUE_KEY ON Rol (loginUsuario, nombreRol);


CREATE OR REPLACE TRIGGER AINC_Rol
BEFORE INSERT  ON Rol
FOR EACH ROW 
BEGIN 
  IF (:NEW.codigoRol IS NULL) THEN 
    SELECT GlobalSequence.NEXTVAL INTO :NEW.codigoRol FROM DUAL; 
  END IF; 
END; 

/


CREATE TABLE Servicio (
  codigoServicio INTEGER   NOT NULL ,
  codigoTipoServicio INTEGER   NOT NULL ,
  nombre VARCHAR(50)      ,
PRIMARY KEY(codigoServicio)  );


CREATE INDEX Servicio_FKIndex1 ON Servicio (codigoTipoServicio);


CREATE OR REPLACE TRIGGER AINC_Servicio
BEFORE INSERT  ON Servicio
FOR EACH ROW 
BEGIN 
  IF (:NEW.codigoServicio IS NULL) THEN 
    SELECT GlobalSequence.NEXTVAL INTO :NEW.codigoServicio FROM DUAL; 
  END IF; 
END; 

/



CREATE TABLE Tipo_Actividad (
  codigoTipoActividad INTEGER   NOT NULL ,
  nombreTipoActividad VARCHAR(30)   NOT NULL   ,
PRIMARY KEY(codigoTipoActividad));


CREATE OR REPLACE TRIGGER AINC_Tipo_Actividad
BEFORE INSERT  ON Tipo_Actividad
FOR EACH ROW 
BEGIN 
  IF (:NEW.codigoTipoActividad IS NULL) THEN 
    SELECT GlobalSequence.NEXTVAL INTO :NEW.codigoTipoActividad FROM DUAL; 
  END IF; 
END; 

/



CREATE TABLE Tipo_Servicio (
  codigoTipoServicio INTEGER   NOT NULL ,
  codigoEmpresa INTEGER   NOT NULL ,
  descripcionServicio VARCHAR(50)   NOT NULL ,
  valoresServicio DECIMAL(13,2)   NOT NULL   ,
PRIMARY KEY(codigoTipoServicio)  );


CREATE INDEX Tipo_Servicio_FKIndex1 ON Tipo_Servicio (codigoEmpresa);


CREATE OR REPLACE TRIGGER AINC_Tipo_Servicio
BEFORE INSERT  ON Tipo_Servicio
FOR EACH ROW 
BEGIN 
  IF (:NEW.codigoTipoServicio IS NULL) THEN 
    SELECT GlobalSequence.NEXTVAL INTO :NEW.codigoTipoServicio FROM DUAL; 
  END IF; 
END; 

/



CREATE TABLE Usuario (
  loginUsuario VARCHAR(30)   NOT NULL ,
  pw VARCHAR(30)   NOT NULL ,
  estado INTEGER   NOT NULL   ,
PRIMARY KEY(loginUsuario));


------------------------------------------------------

insert into rol (loginusuario,nombrerol )values ('pancho','admin');

insert into rol (loginusuario,nombrerol )values ('chobi','apoderado');

insert into rol (loginusuario,nombrerol )values ('jabuba','apoderado');

insert into rol (loginusuario,nombrerol )values ('joako','apoderado');

insert into rol (loginusuario,nombrerol)values ('mastermontero','apoderado');

insert into rol (loginusuario,nombrerol)values ('aldini','vendedor');



insert into empresa_servicio (nombreempresa,rubroempresa) values ('Fantasilandia','Entretención');

insert into empresa_servicio (nombreempresa,rubroempresa) values ('LAN','Viaje');

insert into empresa_servicio (nombreempresa,rubroempresa) values ('San Rafael','Hospital');

insert into empresa_servicio (nombreempresa,rubroempresa) values ('Rio Bueno','Comida');

insert into empresa_servicio (nombreempresa,rubroempresa) values ('Funny Toys','Entretención');

insert into Tipo_Servicio (codigoEmpresa,descripcionServicio,valoresServicio) values (7,'juegos y entretenimientos',30.000);

insert into Tipo_Servicio (codigoEmpresa,descripcionServicio,valoresServicio) values (8,'Viajes en avion',600.000);

insert into Tipo_Servicio (codigoEmpresa,descripcionServicio,valoresServicio) values (9,'Tratamiento y atención médica',40.000);

insert into Tipo_Servicio (codigoEmpresa,descripcionServicio,valoresServicio) values (10,'Servicio de comida rápida',15.000);

insert into Tipo_Servicio (codigoEmpresa,descripcionServicio,valoresServicio) values (11,'juegos y entretenimientos',20.000);

insert into Servicio (codigoTipoServicio, nombre) values (7,'juego');

insert into Servicio (codigoTipoServicio, nombre) values (8,'viaje');

insert into Servicio (codigoTipoServicio, nombre) values (9,'salud');

insert into Servicio (codigoTipoServicio, nombre) values (10,'comida');

insert into Servicio (codigoTipoServicio, nombre) values (11,'juegos');

insert into Pais (nombrepais) values ('Chile');

insert into Pais (nombrepais) values ('Argentina');

insert into Pais (nombrepais) values ('Brazil');

insert into Ciudad (codigopais, ciudad) values (106, 'santiago'); 
insert into Ciudad (codigopais, ciudad) values (107,'Bs Aires');
insert into Ciudad (codigopais, ciudad) values (108, 'Sao paulo');

insert into Destino(codigopais,codigociudad,direccion) values (106,113,'las rosas 23');
insert into Destino(codigopais,codigociudad,direccion) values (106,113,'las palmas 99');
insert into Destino(codigopais,codigociudad,direccion) values (106,113,'las vainas 787');
insert into Destino(codigopais,codigociudad,direccion) values (106,113,'cerro navia 22');
insert into Destino(codigopais,codigociudad,direccion) values (106,113,'pichidangui 1231');
insert into Destino(codigopais,codigociudad,direccion) values (106,113,'chuchunco city 2323');

insert into Usuario
(loginUsuario,pw,estado) values('pancho','123456789',1);
insert into Usuario
(loginUsuario,pw,estado) values('chobi','123456788',1);
insert into Usuario
(loginUsuario,pw,estado) values('jabuba','123456784',1);
insert into Usuario
(loginUsuario,pw,estado) values('joako','123456783',1);
insert into Usuario
(loginUsuario,pw,estado) values('mastermontero','123456782',1);
insert into Usuario
(loginUsuario,pw,estado) values('pipo','123456782',1);
----------------------------------Colegios----------------------
insert into Colegio (codigoColegio, nombre, direccion, telefono, email) values (1,'Insuco','Amunategi con Moneda 126',584561477,'insucoefm@gmail.com');
insert into Colegio (codigoColegio, nombre, direccion, telefono, email) values (2,'Insuco 2','Av. España 570',555698742,'insucoefm2@gmail.com');
insert into Colegio (codigoColegio, nombre, direccion, telefono, email) values (3,'Dario Salas','Av.España 585',584566545,'Dariosalas@gmail.com');
--------------------------------------Cursos------------------------

insert into Curso (codigoCurso,codigoColegio,nombreCurso) values(1,1,'3 medio a');
insert into Curso (codigoCurso,codigoColegio,nombreCurso) values(2,2,'4 medio b');
insert into Curso (codigoCurso,codigoColegio,nombreCurso) values(3,3,'3 medio c');
insert into Curso (codigoCurso,codigoColegio,nombreCurso) values(4,1,'4 medio a');
insert into Curso (codigoCurso,codigoColegio,nombreCurso) values(5,3,'4 medio d');
----------------------------------Alumnos----------------------------
insert into Alumno (rutAlumno,loginUsuario,codigoCurso,rutApoderado,dv,nombre,apellidoPaterno,
apellidoMaterno,correo) values ('18954548','juanito231',1,'9241779','2','Juan','Perez','Rodriguez','juanito290as@gmail.com');
insert into Alumno (rutAlumno,loginUsuario,codigoCurso,rutApoderado,dv,nombre,apellidoPaterno,
apellidoMaterno,correo) values ('19669997','rakolito213',1,'9247841','6','Mauro','Berrios','Molen','rakol290as@gmail.com');
insert into Alumno (rutAlumno,loginUsuario,codigoCurso,rutApoderado,dv,nombre,apellidoPaterno,
apellidoMaterno,correo) values ('18894561','Exviz892',1,'9889779','7','Fabian','Hormazabal','Bustamante','fabianHorma@gmail.com');
insert into Alumno (rutAlumno,loginUsuario,codigoCurso,rutApoderado,dv,nombre,apellidoPaterno,
apellidoMaterno,correo) values ('17894561','Insta23',1,'9123456','8','Manuel','Gomez','Enriquez','instaGram@gmail.com');
insert into Alumno (rutAlumno,loginUsuario,codigoCurso,rutApoderado,dv,nombre,apellidoPaterno,
apellidoMaterno,correo) values ('18994678','MatyDozPunto',1,'15204388','9','Matias','Espildora','Rivas','matyRivas@outlook.com');

-------------------------------Tipo Actividad------------------
insert into Tipo_Actividad(codigoTipoActividad,nombreTipoActividad)
values (1,'rifa');
insert into Tipo_Actividad(codigoTipoActividad,nombreTipoActividad)
values (2,'fiesta');
-------------------------------Actividad--------------------
insert into Actividad  (codigoActividad,codigoTipoActividad,fechaInicio,fechaTermino)
values (1,2,'07-AUG-17','08-AUG-17');
insert into Actividad  (codigoActividad,codigoTipoActividad,fechaInicio,fechaTermino)
values (2,1,'09-AUG-17','11-AUG-17');

----------------------------------------Apoderado-------------------------
insert into Apoderado
(rutApoderado,loginUsuario,codigoActividad,dv,nombreCompleto,apellidoPaterno,apellidoMaterno,esEncargado) values ('9241779','chobi',2,'1','Jaime','Torres','Coloma',0);
insert into Apoderado
(rutApoderado,loginUsuario,codigoActividad,dv,nombreCompleto,apellidoPaterno,apellidoMaterno,esEncargado) values ('9247841','jabuba',1,'5','MatiasAlberto','Espildora','Rojas',0);
insert into Apoderado
(rutApoderado,loginUsuario,codigoActividad,dv,nombreCompleto,apellidoPaterno,apellidoMaterno,esEncargado) values ('9889779','joako',1,'3','Mariela','Prades','Cardenas',1);
insert into Apoderado
(rutApoderado,loginUsuario,codigoActividad,dv,nombreCompleto,apellidoPaterno,apellidoMaterno,esEncargado) values ('9123456','mastermontero',5,'3','Ivan','Caballero','Jimenez',0);
insert into Apoderado
(rutApoderado,loginUsuario,codigoActividad,dv,nombreCompleto,apellidoPaterno,apellidoMaterno,esEncargado) values ('15204388','pipo',6,'3','Tomas','Gonzales','Perez',0);
------------------------------------Deposito--------------------------
insert into Deposito
(codigoDeposito,loginUsuario,rutApoderado,tipoDeposito,valorDeposito,cuenta) values
('215787541','joako','9889779','Cuenta Corriente',9000,'9889779-5');
insert into Deposito
(codigoDeposito,loginUsuario,rutApoderado,tipoDeposito,valorDeposito,cuenta) values
('215787530','jabuba','9123456','Cuenta Corriente',6000,'9889779-5');
insert into Deposito
(codigoDeposito,loginUsuario,rutApoderado,tipoDeposito,valorDeposito,cuenta) values
('215787559','chobi','15204388','Cuenta Corriente',8900,'9889779-5');
insert into Deposito
(codigoDeposito,loginUsuario,rutApoderado,tipoDeposito,valorDeposito,cuenta) values
('215787578','mastermontero','9241779','Cuenta Corriente',9000,'9889779-5');
insert into Deposito
(codigoDeposito,loginUsuario,rutApoderado,tipoDeposito,valorDeposito,cuenta) values
('215787591','joako','9889779','Cuenta Corriente',2000,'9889779-5');
///////////////////////////////////////////////////////
insert into Contrato(codigoEncargado,codigodestino, codigoservicio, fechacontrato, pagototal, fechadestino,nombrearchivopdf)
values (12,30,17,TO_DATE('01-03-2011','DD-MM-YYYY'),5000000,TO_DATE('01-03-2011','DD-MM-YYYY'),'cole1');
insert into Contrato(codigoEncargado,codigodestino, codigoservicio, fechacontrato, pagototal, fechadestino,nombrearchivopdf)
values (12,30,17,TO_DATE('01-10-2011','DD-MM-YYYY'),12000000,TO_DATE('01-03-2014','DD-MM-YYYY'),'cole2');
insert into Contrato(codigoEncargado,codigodestino, codigoservicio, fechacontrato, pagototal, fechadestino,nombrearchivopdf)
values (12,30,17,TO_DATE('01-11-2011','DD-MM-YYYY'),50000000,TO_DATE('01-03-2015','DD-MM-YYYY'),'cole3');
insert into Contrato(codigoEncargado,codigodestino, codigoservicio, fechacontrato, pagototal, fechadestino,nombrearchivopdf)
values (12,30,17,TO_DATE('12-03-2011','DD-MM-YYYY'),12000000,TO_DATE('01-03-2012','DD-MM-YYYY'),'cole4');

insert into Encargado_venta(loginUsuario,nombre,apellidopaterno,apellidomaterno,telefono,direccion,email)
values ('pancho','fernando','aguilera','ferrada',1231233,'av santa rosa 123', 'feñaAFerrada@gmail.com');
insert into Encargado_venta(loginUsuario,nombre,apellidopaterno,apellidomaterno,telefono,direccion,email)
values ('pancho','camilo','sesto','parada',7871233,'av ecuador 33', 'CamiloSestoParada@gmail.com');
insert into Encargado_venta(loginUsuario,nombre,apellidopaterno,apellidomaterno,telefono,direccion,email)
values ('chobi','constanza','aguilera','ferrada',46631233,'av alameda 123', 'ConyAFERR@gmail.com');
insert into Encargado_venta(loginUsuario,nombre,apellidopaterno,apellidomaterno,telefono,direccion,email)
values ('aldini','valeria','perez','perez',6256533,'av los guerreros 885', 'valePP@gmail.com');
insert into Encargado_venta(loginUsuario,nombre,apellidopaterno,apellidomaterno,telefono,direccion,email)
values ('joako','fernando','muñoz','garcia',5551233,'av santa rosa 123', 'FernaMG@gmail.com');

insert into Usuario
(loginUsuario,pw,estado) values('admin','admin',1);
insert into Usuario
(loginUsuario,pw,estado) values('wea','wea',0);
commit;


-----Crear denuevo Tabla Pais --------
drop Table Pais;
CREATE TABLE Pais (
  codigoPais INTEGER NOT NULL ,
  nombrePais VARCHAR(30)      ,
PRIMARY KEY(codigoPais));
commit;

CREATE OR REPLACE TRIGGER AINC_Pais
BEFORE INSERT  ON Pais
FOR EACH ROW 
BEGIN 
  IF (:NEW.codigoPais IS NULL) THEN 
    SELECT GlobalSequence.NEXTVAL INTO :NEW.codigoPais FROM DUAL; 
  END IF; 
END; 

Drop Table Ciudad;
CREATE TABLE Ciudad (
  codigoCiudad INTEGER   NOT NULL ,
  codigoPais INTEGER   NOT NULL ,
  Ciudad VARCHAR(30)      ,
PRIMARY KEY(codigoCiudad, codigoPais)  );
CREATE INDEX Ciudad_FKIndex1 ON Ciudad (codigoPais);


CREATE OR REPLACE TRIGGER AINC_Ciudad
BEFORE INSERT  ON Ciudad
FOR EACH ROW 
BEGIN 
  IF (:NEW.codigoCiudad IS NULL) THEN 
    SELECT GlobalSequence.NEXTVAL INTO :NEW.codigoCiudad FROM DUAL; 
  END IF; 
END; 
commit;
SELECT * FROM Ciudad WHERE codigopais = 106;
-----------------------------------------
drop TABLE destino;
CREATE TABLE Destino (
  codigoDestino INTEGER   NOT NULL ,
  codigoPais INTEGER   NOT NULL ,
  codigoCiudad INTEGER   NOT NULL ,
  direccion VARCHAR(30)      ,
PRIMARY KEY(codigoDestino)    );


CREATE INDEX Destino_FKIndex1 ON Destino (codigoPais);
CREATE INDEX Destino_FKIndex2 ON Destino (codigoCiudad, codigoPais);


CREATE OR REPLACE TRIGGER AINC_Destino
BEFORE INSERT  ON Destino
FOR EACH ROW 
BEGIN 
  IF (:NEW.codigoDestino IS NULL) THEN 
    SELECT GlobalSequence.NEXTVAL INTO :NEW.codigoDestino FROM DUAL; 
  END IF; 
END; 

insert into Pais (codigoPais, nombrepais) values (1,'Chile');

insert into Pais (codigoPais, nombrepais) values (2,'Argentina');

insert into Pais (codigoPais, nombrepais) values (3, 'Brazil');

insert into Ciudad (codigociudad, codigopais, ciudad) values (1,1, 'Santiago'); 
insert into Ciudad (codigociudad, codigopais, ciudad) values (2,2,'Bs Aires');
insert into Ciudad (codigociudad, codigopais, ciudad) values (3,3, 'Sao paulo');

insert into Destino(codigopais,codigociudad,direccion) values (1,1,'las rosas 23');
insert into Destino(codigopais,codigociudad,direccion) values (1,1,'las palmas 99');
insert into Destino(codigopais,codigociudad,direccion) values (1,1,'las vainas 787');
insert into Destino(codigopais,codigociudad,direccion) values (1,1,'cerro navia 22');
insert into Destino(codigopais,codigociudad,direccion) values (1,1,'pichidangui 1231');
insert into Destino(codigopais,codigociudad,direccion) values (1,1,'chuchunco city 2323');
commit;