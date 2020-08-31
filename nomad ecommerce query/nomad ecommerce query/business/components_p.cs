using System.Collections.Generic;
using System.Data.SqlClient;

namespace nomad_ecommerce_query.business
{
    public class components_p
    {
        public static component_p get(SqlDataReader SDR
                                     )
        {
            component_p component = new business.component_p();

            component.ID = sql_code.get_i(SDR, "ID"
                                  );

            component.component = sql_code.get_s(SDR, "component"
                                      );

            component.stoc_qty = sql_code.get_n(SDR, "stoc_qty"
                                          );

            component.tag = sql_code.get_s(SDR, "tag"
                                      );

            component.tag_set_name = sql_code.get_s(SDR, "tag_set_name"
                                              );

            component.base_cost = sql_code.get_n(SDR, "base_cost"
                                         );

            return component;
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
                comp = get(SDR);

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
                comp = get(SDR);

            SDR.Close();

            conn.Close();

            conn.Dispose();

            return comp;
        }

        public static List<component_p> get_sub_comps(int comp
                                                     )
        {
            string r = "select * from component where super_comp = " + comp;

            r += " order by upper(name), ID";

            SqlConnection conn = null;

            SqlDataReader SDR = sql_code.run_query(r, ref conn
                                                  );

            List<component_p> comps = new List<business.component_p>();

            for (; SDR.Read();
                )
            {
                component_p c = get(SDR);

                comps.Add(c);
            }

            SDR.Close();

            conn.Close();

            conn.Dispose();

            return comps;
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
                component_p c = get(SDR);

                comps.Add(c);
            }

            SDR.Close();

            conn.Close();

            conn.Dispose();

            return comps;
        }
        }
    }
        