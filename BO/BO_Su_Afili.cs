using Digitalware.Apps.Utilities.Su.DAO;
using Digitalware.Apps.Utilities.Su.Models;
using DigitalWare.Apps.Utilities.Gn.DAO;
using SevenFramework.DataBase;
using SevenFramework.TO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digitalware.Apps.Utilities.Su.BO
{
    public class BO_Su_Afili
    {

        public TOTransaction<Su_Afili> GetSuAfili(int emp_codi,string afi_docu)
        {
            try
            {
                var result = new DAO_Su_Afili().GetSuAfili(emp_codi, afi_docu);
                List<SQLParams> sQLParams = new List<SQLParams>()
                {
                    new SQLParams("MOD_CODI",189)
                };
                var modulAfili = DAO_Gn_Modul.GetGnModul(sQLParams);
                if (modulAfili.mod_inst == "S")
                {
                    return new TOTransaction<Su_Afili>() { ObjTransaction =  result.Where(t=>t.afi_tipo=="A").FirstOrDefault(),Retorno=0,TxtError="" };
                }
                else
                {
                    return new TOTransaction<Su_Afili>() { ObjTransaction = result.Where(t => t.afi_tipo == "C").FirstOrDefault(), Retorno = 0, TxtError = "" };
                }
             
            }
            catch (Exception ex)
            {

                return new TOTransaction<Su_Afili>() { ObjTransaction = null, Retorno = 1, TxtError = ex.Message };
            }
        }
    }
}
