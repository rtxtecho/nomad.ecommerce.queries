using System.Collections.Generic;
using System.Data.SqlClient;

namespace nomad_ecommerce_query.business
{
    public class customers_p
    {
        public static customer_p get(SqlDataReader SDR
                                     )
        {
            customer_p c = new customer_p();

            c.ID = sql_code.get_i(SDR, "ID"
                                 );

            return c;
        }                        

        public static component_p get(int ID
                                      )
        {
            string r = "select * from component where ID = " + ID;

            SqlConnection conn = null;

            SqlDataReader SDR = sql_code.run_query(r, ref conn
                                                  );

            component_p comp = null;

            if (SDR.Read()
                )
           //   comp = get(SDR);

            SDR.Close();

            conn.Close();

            conn.Dispose();

            return comp;
        }

        public static component_p get(string name
                                      )
        {
            string r = "select * from component where name = @name";

            sql_code.prms_p prms = new sql_code.prms_p();
            prms.enroll("name", name, System.Data.SqlDbType.VarChar
                       );
            SqlConnection conn = null;

            SqlDataReader SDR = sql_code.run_query(r, prms, ref conn
                                                  );

            component_p comp = null;

            if (SDR.Read()
                )
           //   comp = get(SDR);

            SDR.Close();

            conn.Close();

            conn.Dispose();

            return comp;
        }

        public static List<customer_p
                           > get()
                                 
        {
            string r = "select * from customer";

            SqlConnection conn = null;

            SqlDataReader SDR = sql_code.run_query(r, ref conn
                                                  );

            List<customer_p
                > csts = new List<business.customer_p
                                   >();

            for (; SDR.Read();
                )
            {
                customer_p c = get(SDR);

                csts.Add(c);
            }

            SDR.Close();

            conn.Close();

            conn.Dispose();

            return csts;
        }

        public static List<component_p> search(string content
                                                     )
        {
            string r = "select * from component where name like @content";

            r += " order by upper(name), ID";
            sql_code.prms_p prms = new business.sql_code.prms_p();
            prms.enroll("content", "%" + content +
                                    "%", System.Data.SqlDbType.VarChar
                        );

            SqlConnection conn = null;

            SqlDataReader SDR = sql_code.run_query(r, prms,
                                                  ref conn
                                                  );
            List<component_p> comps = new List<business.component_p>();

            for (; SDR.Read();
                )
            {
          //    component_p c = get(SDR);

          //    comps.Add(c);
            }

            SDR.Close();

            conn.Close();

            conn.Dispose();

            return comps;
        }
        }
    }