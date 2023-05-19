NOTA: En el video no aparece -p 5432:5432, para que lo consideren
```ps
> docker volume create mi_postgresql_data
> docker volume ls

> docker run --name mi_postgresql -p 5432:5432 -e POSTGRES_PASSWORD=contraseña -v mi_postgresql_data:/var/lib/postgresql/data -d postgres

#Pueden crearlo sin volumen y en ruta local (Ver: -v c:\<ruta>:/var/lib/postgresql/data)
docker run --name mi_postgresql -p 5432:5432 -e POSTGRES_PASSWORD=contraseña -v c:\<ruta>:/var/lib/postgresql/data 

> docker ps
```

```SQL
CREATE TABLE clientes (
  id SERIAL PRIMARY KEY,
  nombre VARCHAR(100),
  direccion VARCHAR(200),
  telefono VARCHAR(20)
);

CREATE TABLE productos (
  id SERIAL PRIMARY KEY,
  nombre VARCHAR(100),
  precio DECIMAL(10, 2),
  descripcion TEXT
);

CREATE TABLE facturas (
  id SERIAL PRIMARY KEY,
  fecha DATE,
  cliente_id INTEGER REFERENCES clientes(id)
);

CREATE TABLE detalles_facturas (
  id SERIAL PRIMARY KEY,
  factura_id INTEGER REFERENCES facturas(id),
  producto_id INTEGER REFERENCES productos(id),
  cantidad INTEGER,
  precio DECIMAL(10, 2)
);
```

```ps
docker exec -it mi_postgresql psql -U postgres
CREATE DATABASE mi_proyecto;
\q

***El script pueden ejecutarlo en bash o powershell de la siguiente forma:***

#bash
docker exec -i mi_postgresql psql -U postgres mi_proyecto < /ruta/al/script_facturas.sql

#powershell
cat /ruta/al/script_facturas.sql | docker exec -i mi_postgresql psql -U postgres mi_proyecto


docker exec -it mi_postgresql psql -U postgres
\l
\c mi_proyecto
\dt
```




