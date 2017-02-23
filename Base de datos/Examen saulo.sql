--Examen de playas--
--1--
select count(playas.Id), Municipios.Nombre
from Playas
inner join  Municipios
on Municipios.Id=Playas.MunicipioId
inner join Imagenes 
on Imagenes.IdPlaya=playas.MunicipioId
where  Imagenes.Id is not null
group by Municipios.Nombre
having Municipios.Nombre='Arona'
go

select  count(Playas.Id) as sumaplayas, Imagenes.Id
from Municipios
inner join  Playas
on Municipios.Id=Playas.MunicipioId
right join Imagenes 
on Imagenes.IdPlaya=Playas.Id
where  Municipios.Nombre='Arona'
group by Imagenes.Id
go

--2--
select count(categorias.id) as CuantasCategorias, count(puntuaciones.Id) as CuantasPuntuaciones, Playas.Nombre
from Categorias
full join CategoriasPlayas
on CategoriasPlayas.CategoriaId=Categorias.Id
full join Playas
on Playas.Id=CategoriasPlayas.PlayaId
full join Puntuaciones
on Puntuaciones.PlayaId=playas.Id
full join Municipios
on Municipios.Id=Playas.MunicipioId
where Municipios.Nombre='Arona'
group by Playas.Nombre


--3--

select Municipios.Nombre, Playas.id
from Municipios
left join Playas
on Playas.MunicipioId=Municipios.Id
where Playas.id is null 






--4--

select count(Puntuaciones.Id), Playas.Nombre
from Playas
inner join Puntuaciones
on Puntuaciones.PlayaId=playas.Id
group by  Playas.Nombre
having count(Puntuaciones.Id)>1
order by Playas.Nombre






--5--



select sum(Longitud)
from Playas
inner join Zonas
on zonas.Id=Playas.ZonaId
left join Imagenes
on Imagenes.IdPlaya=Playas.Id
where Zonas.Nombre='Sur'and Imagenes.Id is null




--6--

select count(Comentarios.Id) as SumComentario, Zonas.Nombre
from Comentarios
inner join Playas
on Comentarios.PlayaId=Playas.Id
inner join Zonas
on zonas.Id=Playas.ZonaId
where datename(dw, comentarios.fecha)='Sábado' 
group by Zonas.Nombre



--7--

select top 4 with ties  Playas.Nombre
from Playas
inner join Zonas
on Playas.ZonaId=Zonas.Id
where Zonas.Nombre='Sur'
order by Longitud desc

--8--

select Categorias.Nombre, count(Playas.Id) as Nplayas, count(imagenes.id) as Nimagen, count(comentarios.id) as Ncoment
from Categorias
full join CategoriasPlayas
on Categorias.Id=CategoriasPlayas.CategoriaId
full join Playas
on playas.Id=CategoriasPlayas.PlayaId
full join Imagenes
on Imagenes.IdPlaya=playas.Id
full join Comentarios
on Comentarios.PlayaId=Playas.Id
group by Categorias.Nombre


--9--

select aspnet_Users.UserName
from aspnet_Users
inner join Puntuaciones
on Puntuaciones.UserId=aspnet_Users.UserId
inner join comentarios
on Comentarios.UserId=aspnet_Users.UserId
group by aspnet_Users.UserName
having (count(Comentarios.Id)=0 or count(Comentarios.Id)=1) and avg(puntuaciones.nota)>5




--20--
select Playas.Nombre
from Playas
inner join Municipios
on Municipios.Id=playas.MunicipioId
where Municipios.Nombre =  (select top 1 Municipios.Nombre
							from Municipios
							inner join Playas
							on Playas.MunicipioId=Municipios.Id
							group by Municipios.Nombre
							order by count(playas.id) desc)


--11--
select count(playas.id)
from playas
inner join Municipios
on Municipios.Id=playas.MunicipioId
where Municipios.Nombre in (select Municipios.Nombre
							from Municipios
							inner join playas
							on playas.MunicipioId=Municipios.Id
							group by Municipios.Nombre
							having sum(Playas.Longitud)>1000)



--12--

select Municipios.Nombre
from Municipios
inner join (select Municipios.Id, playas.Nombre, count(categorias.Id) as sumCategoria
			from Municipios
			inner join playas
			on playas.MunicipioId=Municipios.Id
			inner join CategoriasPlayas
			on playas.Id=CategoriasPlayas.PlayaId
			inner join Categorias
			on Categorias.Id=CategoriasPlayas.CategoriaId
			group by Municipios.Id, Playas.Nombre
			having count(categorias.id)>1
			) as resultante
on resultante.Id=Municipios.Id