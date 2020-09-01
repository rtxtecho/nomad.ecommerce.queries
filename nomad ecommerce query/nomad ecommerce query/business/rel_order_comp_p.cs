using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nomad_ecommerce_query.business
{
    public class rel_order_comp_p
    {
        public int ID = 0;

        public int order = 0;
        public int comp = 0;
        public double cost = 0;
        public double qty = 0;











        public void submit()
        {
            string r = "insert into ";

            r += "rel_order_comp";
            r += " (order_, comp, cost, qty" +
                  ")";

            r += " values (" + order + ", " + comp + ", " + cost + ", " + qty +
                         ")";

            sql_code.run_non_query(r
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
