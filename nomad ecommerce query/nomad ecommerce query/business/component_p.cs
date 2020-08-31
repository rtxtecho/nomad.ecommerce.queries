using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nomad_ecommerce_query.business
{
    public class component_p
    {
        public int ID = 0;

        public string component = "";

        public double stoc_qty = 0;

        public string tag = "";

        public string tag_set_name = "";

        public double base_cost = 0;



    public void submit()
    {
        string r = "insert into component ";

        r += " (component, stoc_qty, tag, tag_set_name, base_cost" +
              ")";

        r += " values (@component, " + stoc_qty + ", @tag, @tag_set_name, " + base_cost +
                     ")";

        sql_code.
        prms_p prms = new business.sql_code.prms_p();

        prms.enroll("component", component, System.Data.SqlDbType.VarChar
                   );

            prms.enroll("tag", tag, System.Data.SqlDbType.VarChar
                       );

            prms.enroll("tag_set_name", tag_set_name, System.Data.SqlDbType.VarChar
                       );

            sql_code.run_non_query(r, prms
                                  );
            }
        








        public void revise(string column, string content
                                 )
        {
            sql_code.revise("component", column, content, ID
                            );
        }

        public void revise(string column, int content
                                        )
        {
            sql_code.revise("component", column, content, ID
                            );
        }

        public void revise(string column, byte[] content
                          )
        {
            sql_code.revise("component", column, content, ID
                            );
        }

        public void purge()
        {
            string r = "delete from component " +
                                                    " where " +
                              "ID = " + ID;

            sql_code.run_non_query(r);
        }
        }
    }
