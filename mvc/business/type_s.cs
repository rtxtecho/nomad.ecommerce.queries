using System.Data.SqlClient;
using System.Collections.Generic;

namespace mvc.business
{
    public class type_s
    {
        public static type_ get(SqlDataReader SDR
                                 )
        {
            type_ type = new mvc.business.type_();

            type.ID = sql_code.get_i(SDR, "ID"
                                   );

            type.type = sql_code.get_s(SDR, "type_"
                                       );

            return type;
        }

        public static type_ get(int ID
                                     )
        {
            string r = "select * from type_ " + "where " +
                       "ID = " + ID;

            SqlConnection conn = null;


            SqlDataReader SDR = sql_code.run_query(r, ref conn
                                                   );
            type_ type = null;

            if (SDR.Read()
                )
            {
                type = get(SDR);
            }

            SDR.Close();

            SDR.Dispose();

            conn.Close();

            conn.Dispose();

            return type;
        }

        public static List<type_> get()
        {
            string r = "select * from type_ ";

            SqlConnection conn = null;

            SqlDataReader SDR = sql_code.run_query(r, ref conn
                                                   );

            List<type_> types = new List<business.type_>();

            for (; SDR.Read();
                )
            {
                type_ type = get(SDR);

                types.Add(type);
            }

            SDR.Close();

            SDR.Dispose();

            conn.Close();

            conn.Dispose();

            return types;
        }
    }
}






