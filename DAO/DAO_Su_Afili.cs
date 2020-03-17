using Digitalware.Apps.Utilities.Su.Models;
using SevenFramework.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digitalware.Apps.Utilities.Su.DAO
{
    public class DAO_Su_Afili
    {

        public List<Su_Afili> GetSuAfili(int emp_codi, string afi_docu)
        {

            StringBuilder sql = new StringBuilder();
            sql.Append("     SELECT AFI.AFI_DOCU,                                                                        ");
            sql.Append("     AFI.TIP_CODI,                                                                               ");
            sql.Append("     AFI.AFI_DIRE,                                                                               ");
            sql.Append("     AFI.AFI_TELE,                                                                               ");
            sql.Append("     AFI.AFI_CELU,                                                                               ");
            sql.Append("     AFI.AFI_MAIL,                                                                               ");
            sql.Append("     AFI.AFI_GENE,                                                                               ");
            sql.Append("     AFI.AFI_NOM1 + ' ' + AFI.AFI_NOM2 + ' ' + AFI.AFI_APE1 + ' ' + AFI.AFI_APE2 AFI_NOCO ,      ");
            sql.Append("                                                                                                 ");
            sql.Append("     AFI.AFI_CATE,                                                                              ");
            sql.Append("    TIP.TIP_NOMB,                                                                        ");
            sql.Append("    ITE.ITE_CONT DCL_ICAC,                                                               ");
            sql.Append("    'A' AFI_TIPO ,  AFI.AFI_CONT   , AFI.CLI_CODI                                                                        ");
            sql.Append("    FROM   SU_AFILI AFI                                                                  ");
            sql.Append("    INNER JOIN GN_TIPDO TIP                                                              ");
            sql.Append("    ON TIP.TIP_CODI = AFI.TIP_CODI                                                       ");
            sql.Append("    INNER JOIN GN_ITEMS ITE ON AFI.AFI_CATE = ITE.ITE_COHO                               ");
            sql.Append("    AND ITE.TIT_CONT = 284                                                               ");
            sql.Append("     WHERE AFI.AFI_DOCU = @AFI_DOCU AND AFI.EMP_CODI = @EMP_CODI                                      ");
            sql.Append("                                                                                                 ");
            sql.Append("     UNION                                                                                       ");
            sql.Append("                                                                                                 ");
            sql.Append("     SELECT CLI.CLI_CODA,                                                                        ");
            sql.Append("     CLI.TIP_CODI,DCL.DCL_DIRE,DCL.DCL_NTEL,DCL.DCL_NFAX,DCL.DCL_MAIL,CLI.CLI_GENE,                  ");
            sql.Append("     CLI.CLI_NOCO, ITE.ITE_NOMB, ");
            sql.Append("      TIP.TIP_NOMB,       ");
            sql.Append("      DCL.DCL_ICAC,       ");
            sql.Append("     'C' AFI_TIPO    , 0  ,CLI.CLI_CODI     ");
            sql.Append("     FROM   FA_CLIEN CLI                                                                         ");
            sql.Append("     INNER JOIN FA_DCLIE DCL                                                                     ");
            sql.Append("     ON CLI.EMP_CODI = DCL.EMP_CODI                                                              ");
            sql.Append("     AND CLI.CLI_CODI = DCL.CLI_CODI                                                             ");
            sql.Append("     AND DCL.DCL_CODD = 1                                                                        ");
            sql.Append("     INNER JOIN GN_ITEMS ITE ON DCL.DCL_ICAC = ITE.ITE_CONT                                      ");
            sql.Append("     INNER JOIN GN_TIPDO TIP ON CLI.TIP_CODI = TIP.TIP_CODI                                      ");
            sql.Append("                                                                                                 ");
            sql.Append("                                                                                                 ");
            sql.Append("                                                                                                 ");
            sql.Append("     WHERE CLI.CLI_CODA = @AFI_DOCU AND DCL.EMP_CODI = @EMP_CODI                ORDER BY AFI_TIPO                      ");
            List<SQLParams> sQLParams = new List<SQLParams>();
            sQLParams.Add(new SQLParams("EMP_CODI", emp_codi));
            sQLParams.Add(new SQLParams("AFI_DOCU", afi_docu));
            return new DbConnection().GetList<Su_Afili>(sql.ToString(), sQLParams);
        }
    }
}
