using System.Collections.Generic;
using System.Data.SqlClient;

namespace mvc.business
{
    public class components_p
    {
        public static component_p get(SqlDataReader SDR
                                     )
        {
            component_p comp = new business.component_p();

            comp.ID = sql_code.get_i(SDR, "ID"
                                    );

            comp.name = sql_code.get_s(SDR, "name"
                                    );

            comp.comp_type = sql_code.get_i(SDR, "comp_type"
                                           );

            comp.super_comp = sql_code.get_i(SDR, "super_comp"
                                             );
            comp.img = sql_code.get_byte(SDR, "img"
                                            );
            comp.format = sql_code.get_s(SDR, "format"
                                        );

            return comp;
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
        