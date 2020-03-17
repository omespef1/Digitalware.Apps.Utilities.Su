using Digitalware.Apps.Utilities.Su.Models;
using SevenFramework.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digitalware.Apps.Utilities.Su.DAO
{
    public class DAO_Su_Traye
    {

        public List<Su_Traye> GetSuTraye(int emp_codi, int afi_cont)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("  SELECT TRA.TRA_SALB, TRA.TRA_SSAL, APO.APO_RAZS, DSU.DSU_DIRE, PAI.PAI_NOMB, DSU.MUN_CODI, DSU.REG_CODI,DSU.PAI_CODI,DSU.PAI_CODI , MUN.MUN_NOMB, ");
            sql.Append("  DEP.DEP_CODI, MUN.MUN_CODI,DSU.DSU_TELE,TIP.TIP_CLAS, ITC.ITE_CONT  ITE_CARG,ITC.ITE_NOMB ITN_CARG  ");
            sql.Append("   FROM   SU_TRAYE TRA                                         ");
            sql.Append("   INNER JOIN AR_APOVO APO                                     ");
            sql.Append("   ON TRA.EMP_CODI = APO.EMP_CODI                              ");
            sql.Append("   AND TRA.APO_CONT = APO.APO_CONT                             ");
            sql.Append("   INNER JOIN AR_SUCUR AS SUC                                  ");
            sql.Append("   ON  SUC.EMP_CODI = APO.EMP_CODI                             ");
            sql.Append("   AND SUC.APO_CONT = APO.APO_CONT                             ");
            sql.Append("   AND SUC.SUC_PRIC = 'S'                                      ");
            sql.Append("   INNER JOIN AR_DSUCU DSU                                     ");
            sql.Append("   ON SUC.EMP_CODI = DSU.EMP_CODI                              ");
            sql.Append("   AND SUC.SUC_CONT = DSU.SUC_CONT                             ");
            sql.Append("   INNER JOIN AR_TIPDI TIP                                     ");
            sql.Append("   ON DSU.EMP_CODI = TIP.EMP_CODI                              ");
            sql.Append("   AND DSU.TIP_CODI = TIP.TIP_CODI                             ");
            sql.Append("   INNER JOIN GN_PAISE PAI                                     ");
            sql.Append("   ON DSU.PAI_CODI = PAI.PAI_CODI                              ");
            sql.Append(" INNER JOIN GN_REGIO REG ON  DSU.PAI_CODI = REG.PAI_CODI AND DSU.REG_CODI = REG.REG_CODI ");
            sql.Append("   INNER JOIN GN_DEPAR DEP                                     ");
            sql.Append("   ON DSU.PAI_CODI = DEP.PAI_CODI                              ");
            sql.Append("   AND DSU.DEP_CODI = DEP.DEP_CODI AND DSU.REG_CODI = DEP.REG_CODI   ");
            sql.Append("   INNER JOIN GN_MUNIC MUN                                     ");
            sql.Append("   ON DSU.PAI_CODI = MUN.PAI_CODI                              ");
            sql.Append("   AND DSU.DEP_CODI = MUN.DEP_CODI                             ");
            sql.Append("   AND DSU.MUN_CODI = MUN.MUN_CODI    AND DSU.REG_CODI = MUN.REG_CODI                           ");
            sql.Append("  INNER JOIN GN_ITEMS ITC                                         ");
            sql.Append("  ON TRA.ITE_CARG = ITC.ITE_CONT                                  ");
            sql.Append("  WHERE TRA.AFI_CONT = @AFI_CONT  AND TRA.EMP_CODI = @EMP_CODI ");
            sql.Append("  AND TRA_PRIN = 'S'                                      ");

            List<SQLParams> sQLParams = new List<SQLParams>();
            sQLParams.Add(new SQLParams("EMP_CODI", emp_codi));
            sQLParams.Add(new SQLParams("AFI_CONT", afi_cont));
            return new DbConnection().GetList<Su_Traye>(sql.ToString(),sQLParams);


        }
    }
}
