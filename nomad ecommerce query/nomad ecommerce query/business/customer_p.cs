using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nomad_ecommerce_query.business
{
    public class customer_p
    {
        public int ID = 0;

        public string customer = "";
        public string street = "";
        public string city = "";
        public string state = "";
        public string zip = "";










        public void submit()
        {
            string r = "insert into ";

            r += "customer";
            r += " (customer, street, city, state, zip" +
                  ")";

            r += " values (@customer, @street, @city, @state, @zip" +
                         ")";

            sql_code.
            prms_p prms = new business.sql_code.prms_p();
            prms.enroll("customer", customer, System.Data.SqlDbType.VarChar
                         );

            prms.enroll("street", street, System.Data.SqlDbType.VarChar
                       );

            prms.enroll("city", city, System.Data.SqlDbType.VarChar
                      );

            prms.enroll("state", state, System.Data.SqlDbType.VarChar
                       );

            prms.enroll("zip", zip, System.Data.SqlDbType.VarChar
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
