using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvc.business
{
    public class clis_p
    {
        public static
            cli_p get(SqlDataReader SDR
                      )
        {
            cli_p c = new mvc.business.cli_p();

            c.cli = sql_code.get_s(SDR, "cli"
                                   );

            c.group_ = sql_code.get_i(SDR, "group_"
                                      );

            return c;
        }

        public static cli_p
            get(string cli, string pcode
                )
        {
            cli = cli.ToUpper();

            string r = "select * from cli " +
                                                " where " +
                       "not (cli <> @cli or " +
                            "pcode <> @pcode" +
                            ")";

            sql_code.prms_p prms = new sql_code.prms_p();

            prms.enroll("cli", cli, System.Data.SqlDbType.VarChar
                        );

            prms.enroll("pcode", pcode, System.Data.SqlDbType.VarChar
                        );

            SqlConnection conn = null;

            SqlDataReader SDR = sql_code.run_query(r, prms, ref conn
                                                  );

            cli_p c = null;

            if (SDR.Read()
               )
            {
                c = get(SDR);
            }

            SDR.Close();

            SDR.Dispose();

            conn.Close();

            conn.Dispose();

            return c;
        }
    }
}

