using Digitalware.Apps.Utilities.Su.DAO;
using Digitalware.Apps.Utilities.Su.Models;
using SevenFramework.TO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digitalware.Apps.Utilities.Su.BO
{
    public class BO_Su_Traye
    {


        public TOTransaction<Su_Traye> GetSuTraye(int emp_codi, int afi_cont)
        {

            try
            {
                var result = new DAO_Su_Traye().GetSuTraye(emp_codi, afi_cont);
                return new TOTransaction<Su_Traye>() { ObjTransaction = result.Any(t => t.tip_clas == "L") ? result.FirstOrDefault(t => t.tip_clas == "L") : result.FirstOrDefault(), Retorno = 0, TxtError = "" };
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
