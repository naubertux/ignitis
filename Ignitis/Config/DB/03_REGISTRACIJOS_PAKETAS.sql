CREATE OR REPLACE PACKAGE REGISTRACIJOS AS 

   PROCEDURE get_reg_poz(c_reg_poz OUT SYS_REFCURSOR);
   
   PROCEDURE get_klasifik(c_klasifik OUT SYS_REFCURSOR);
   
   PROCEDURE store_reg_poz(p_reg_poz_id NUMBER, p_klasifik_id NUMBER, p_reg_poz_klasifik_id NUMBER);

END REGISTRACIJOS;
/


CREATE OR REPLACE PACKAGE BODY REGISTRACIJOS AS

  PROCEDURE get_reg_poz(c_reg_poz OUT SYS_REFCURSOR) IS
  BEGIN
     OPEN c_reg_poz FOR
     
        SELECT rp.reg_poz_id as RegPozId, 
               rp.pavadinimas as Pavadinimas,
               rp.tipas as Tipas,
               rpk.klasifik_id as KlasifikId,
               rpk.reg_poz_klasifik_id as RegPozKlasifikId
        FROM ignitis.reg_poz rp, 
             ignitis.reg_poz_klasifik rpk
        WHERE rp.reg_poz_id = rpk.reg_poz_id;     
  END get_reg_poz;
  
  PROCEDURE get_klasifik(c_klasifik OUT SYS_REFCURSOR) IS
  BEGIN
    OPEN c_klasifik FOR
        SELECT klasifik_id as KlasifikId, 
               pavadinimas as Pavadinimas,
               tipas as Tipas
        FROM ignitis.klasifik;
  END get_klasifik;
  
  PROCEDURE store_reg_poz(p_reg_poz_id NUMBER, p_klasifik_id NUMBER, p_reg_poz_klasifik_id NUMBER) IS
  BEGIN
    UPDATE ignitis.reg_poz_klasifik 
    SET    klasifik_id = p_klasifik_id
    WHERE reg_poz_klasifik_id = p_reg_poz_klasifik_id;
    
    commit;
  END store_reg_poz;
    

END REGISTRACIJOS;
/
