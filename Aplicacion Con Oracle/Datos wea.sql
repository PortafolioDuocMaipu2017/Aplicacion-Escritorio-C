DROP Table Actividad;
DROP Table Admin;
DROP Table Alumno;
DROP Table Apoderado;
DROP Table Colegio;
DROP Table Contrato;
DROP Table Cuidad;
DROP Table Curso;
DROP Table Deposito;
DROP Table Destino;
DROP Table Empresa_Servicio;
DROP Table Encargado_Venta;
DROP Table Pais;
DROP Table Rol;
DROP Table Sevicio;
DROP Table Rol;
DROP Table Tipo_Actividad;
DROP Table Tipo_Servicio;
DROP Table Usuario;


insert into Usuario (loginUsuario, pw, email, estado) values ('admin','admin', 'xxx', 1); 
insert into Usuario (loginUsuario, pw, email, estado)
values ('wea','wea', 'xxx', 1); 
commit;


insert into Tipo_Actividad (nombreTipoActividad) values ('cualquier wea'); 

insert into Tipo_Actividad (codigoTipoActividad, nombreTipoActividad)
values (GlobalSequence.NEXTVAL, 'cualquier wea'); 

update Tipo_Actividad set nombreTipoActividad = 'cosa' where codigoTipoActividad = 1;
commit;
SELECT * FROM Usuario;
select * from Tipo_Actividad;

---------------------------------------------------
CREATE TABLE tablawea (
  idwea INTEGER   NOT NULL ,
  wea VARCHAR(20)   NOT NULL,
PRIMARY KEY(idwea)    );

CREATE OR REPLACE TRIGGER AINC_wea
BEFORE INSERT  ON tablawea
FOR EACH ROW 
BEGIN 
  IF (:NEW.idwea IS NULL) THEN 
    SELECT GlobalSequence.NEXTVAL INTO :NEW.idwea FROM DUAL; 
  END IF; 
END; 
insert into tablawea (wea) values ('cualquier wea'); 
SELECT * FROM tablawea;
commit;