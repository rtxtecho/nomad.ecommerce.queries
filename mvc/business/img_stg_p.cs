using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvc.business
{
    public class img_stg_p
    {
        public
        string ID = "";

        public
        byte[] img = new byte[] { };

        public string format = "";


























        public void submit()
        {
            string r = "insert into " +
                "img_stg";

            r += " (ID, img" + ", format" +
                  ")";

            r += " values (@ID, @img" + ", @format" +
                         ")";

            sql_code.
            prms_p prms = new business.sql_code.prms_p();

            prms.enroll("ID", ID, System.Data.SqlDbType.Text
                       );

            prms.enroll("img", img, System.Data.SqlDbType.Binary
                       );

            prms.enroll("format", format, System.Data.SqlDbType.Text
                       );

            sql_code.run_non_query(r, prms
                                 );
        }











        public void purge()
        {
            string r = "delete from img_stg where " +
                                "ID = @ID";

            sql_code.prms_p prms = new mvc.business.sql_code.prms_p();

            prms.enroll("ID", ID, System.Data.SqlDbType.VarChar
                       );

            sql_code.run_non_query(r, prms
                                   );
        }
    }
}
