--Demesio: zemiau esantys skriptai praleidziami Oracle SYSTEM useryje!!!


--master schema, cia koduosime storintas
CREATE USER ignitis IDENTIFIED BY agurkas; 

--pametekime ignitis useriui pora teisiu
GRANT create session TO ignitis; 
GRANT unlimited tablespace TO ignitis;
GRANT create table TO ignitis;
grant create procedure to ignitis;