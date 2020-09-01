using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace nomad_ecommerce_query.business
{
    public class orders_p
    {
        public static order_p get(SqlDataReader SDR
                                  )
        {
            order_p order = new business.order_p();

            order.ID = sql_code.get_i(SDR, "ID"
                                   );

            order.customer = sql_code.get_i(SDR, "customer"
                                        );

            long
             ordered = sql_code.get_n_l(SDR, "ordered"
                                        );

            order.ordered = new DateTime(ordered);

            return order;
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

        public static List<order_p
                           > get()
                                 
        {
            string r = "select * from order_";

            SqlConnection conn = null;

            SqlDataReader SDR = sql_code.run_query(r, ref conn
                                                  );

            List<order_p
               > orders = new List<business.order_p
                                   >();

            for (; SDR.Read();
                )
            {
                order_p c = get(SDR);

                orders.Add(c);
            }

            SDR.Close();

            conn.Close();

            conn.Dispose();

            return orders;
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