


truncate table PremioxPersona

UPDATE premios set cantidad=3 where intId=1
UPDATE premios set cantidad=2 where intId=2
UPDATE premios set cantidad=1 where intId=3


-- 
declare @msj varchar(50)=''
exec AsignarPremio @msj OUTPUT
select @msj