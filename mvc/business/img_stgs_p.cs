using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvc.business
{
    public class img_stgs_p
    {
        public static img_stg_p get(SqlDataReader SDR
                                 )
        {
            img_stg_p ims = new mvc.business.img_stg_p();

            ims.ID = sql_code.get_s(SDR, "ID"
                                   );

            ims.img = sql_code.get_byte(SDR, "img"
                                        );

            ims.format = sql_code.get_s(SDR, "format"
                                      );

            return ims;
        }

        public static img_stg_p get(string ID
                                   )

        {
            string r = "select * from img_stg " +
                                                    " where " +
                       "ID = @ID";

            sql_code.prms_p prms = new mvc.business.sql_code.prms_p();

            prms.enroll("ID", ID, System.Data.SqlDbType.VarChar
                        );

            SqlConnection conn = null;

            SqlDataReader SDR = sql_code.run_query(r, prms, ref conn
                                                  );

            img_stg_p ims = null;


            if (SDR.Read()
                )
                ims = get(SDR);

            SDR.Close();

            SDR.Dispose();

            conn.Close();

            conn.Dispose();

            return ims;
        }
    }
}