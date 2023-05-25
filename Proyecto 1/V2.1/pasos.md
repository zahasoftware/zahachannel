**Es el mismo comando del video 2 (V2), pero usando ruta local del equipo en vez de volumen**

```ps
> docker run --name mi_postgresql -p 5432:5432 -e POSTGRES_PASSWORD=contraseña -v c\ZC\V2\data:/var/lib/postgresql/data -d postgres
```

**Validando que el contendor se encuentre en ejecución**
```ps
> docker ps 
```

**Validando que se encuentre puerto escuchando en equipo local**
```ps
> netstat -n -a -p tcp | findstr "5432"
```