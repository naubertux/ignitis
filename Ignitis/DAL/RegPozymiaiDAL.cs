using Dapper;
using Dapper.Oracle;
using Ignitis.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace Ignitis.DAL
{
    public class RegPozymiaiDAL
    {
        //string conString = "User Id=ignitis;Password=agurkas;Data Source=localhost/xe;";
        string conString = ConfigurationManager.ConnectionStrings["IGNITIS"].ToString();

        /// <summary>
        /// Gauname eilutes registracijos požymių
        /// </summary>
        /// <returns></returns>
        public List<RegPozVM> GetRegPoz()
        {
            List<RegPozVM> registracijosPozymiai = new List<RegPozVM>();

            using (OracleConnection con = new OracleConnection(conString))
            {
                try
                {
                    OracleDynamicParameters dynamicParameters = new OracleDynamicParameters();
                    dynamicParameters.Add("c_reg_poz", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
                    registracijosPozymiai = con.Query<RegPozVM>("ignitis.registracijos.get_reg_poz", param: dynamicParameters, commandType: CommandType.StoredProcedure).ToList();

                    dynamicParameters = new OracleDynamicParameters();
                    dynamicParameters.Add("c_klasifik", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
                    var klasifikatoriai = con.Query<Klasifik>("ignitis.registracijos.get_klasifik", param: dynamicParameters, commandType: CommandType.StoredProcedure).ToList();

                    foreach (var rp in registracijosPozymiai)
                    {
                        rp.Klasifikatorius = klasifikatoriai.Where(k => k.Tipas == rp.Tipas).ToList();
                    }

                    // Čia pajungiau List<Klasifik> tiesioginiu būdų, bet alternatyva būtų iš DB vienu selektu pasiimti išplokštinta reprezentacija (negrupuotus / su pasikartojančiomis eilutėmis)
                    // visus reikiamus duomenis, o grupavimą padaryti jau C# pusėje per LINQ, kad formuoti įdėtinį List<Klasifik>, bet tam reikėtų dar vieno modelio 
                    // (plokščios struktūros reprezentacijai), ko nenoriu.

                }
                catch (Exception ex)
                {
                    //Realiam scenarijuje paloginam į failą (NLog) ir kažką suprantamo grąžiname useriui kaip pranešimą
                    //logger.Error(ex);
                    //errors.Add(new Error { description = "Vidinė klaida" });
                }

                return registracijosPozymiai;
            }
        }

        public void StoreRegPoz(List<RegPozVM> regPozymiai)
        {
            using (OracleConnection con = new OracleConnection(conString))
            {
                try
                {
                    foreach (var p in regPozymiai)
                    {
                        OracleDynamicParameters dynamicParameters = new OracleDynamicParameters();
                        dynamicParameters.Add("p_reg_poz_id", p.RegPozId);
                        dynamicParameters.Add("p_klasifik_id", p.KlasifikId);
                        dynamicParameters.Add("p_reg_poz_klasifik_id", p.RegPozKlasifikId);
                        con.Execute("ignitis.registracijos.store_reg_poz", dynamicParameters, commandType: CommandType.StoredProcedure);
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }
    }
}