using System.Collections.Generic;

using System.Data.SqlClient;

using System.Data;

namespace mvc.business
{
    public class sql_code
    {
        public static SqlConnection get_conn(
                                           )
        {
            string conn_str = "Data Source=tcp:s20.winhost.com;Initial Catalog=DB_121607_nomad;User ID=DB_121607_nomad_user;Password=nomad;Integrated Security=False;";
            SqlConnection
            conn = new SqlConnection();

            conn.ConnectionString = conn_str;

            conn.Open();

            return conn;
        }

        public static int
                    get_i(SqlDataReader SDR, string column
                         )
        {
            try
            {
                string content = SDR[column].ToString();

                int i = int.Parse(content);

                return i;
            }
            catch
            {
                return 0;
            }
        }

        public static byte[] get_byte
            (SqlDataReader SDR, string column
            )
        {
            try
            {
                byte[] content = (byte[])SDR[column];

                return content;
            }
            catch
            {
                return new byte[] { };
            }
        }

        public static string
                    get_s(SqlDataReader SDR, string column
                         )
        {
            try
            {
                string content = SDR[column].ToString();

                return content;
            }
            catch
            {
                return "";
            }
        }

        public static SqlDataReader run_query(string query, ref SqlConnection conn
                                             )
        {
            sql_code.prms_p prms = new business.sql_code.prms_p();

            return run_query(query, prms, ref conn
                            );
        }

        public static SqlDataReader run_query(string query, sql_code.prms_p prms,
                                             ref SqlConnection conn
                                              )
        {
            conn = get_conn();

            SqlCommand cnt = new SqlCommand();

            cnt.Connection = conn;

            cnt.CommandText = query;

            foreach (prm_p prm in prms.curs
                    )
            {
                cnt.Parameters.Add("@" + prm.pseudo, prm.type
                                   );

                cnt.Parameters["@" + prm.pseudo].Value = prm.content;
            }

            SqlDataReader SDR = cnt.ExecuteReader();

            return SDR;
        }

        public static void run_non_query(string query
                                             )
        {
            run_non_query(query, null
                         );
        }

        public static void run_non_query(string query, prms_p prms
                                             )
        {
            SqlConnection
            conn = get_conn();

            SqlCommand cnt = new SqlCommand();

            cnt.Connection = conn;

            cnt.CommandText = query;

            if (prms == null
                )
            {
            }
            else
            prms.decompile(ref cnt);

            cnt.ExecuteNonQuery();

            cnt.Dispose();

            conn.Close();

            conn.Dispose();
        }

        public static int get_c_count(string tb, string col
                                     )
        {
            SqlConnection conn = get_conn();

            string sq = "select col_length('" + tb + "', '" + col + "'" +
                                          ") as c";

            SqlDataReader SDR = run_query(sq, ref conn
                                          );

            int c = 0;

            if (SDR.Read()
                )
                c = get_i(SDR, "c"
                          );

            SDR.Close();

            SDR.Dispose();

            conn.Close();

            conn.Dispose();

            return c;
        }

        public static void revise(string tb, string column, byte[] content, int ID
                                  )
        {
            string query = "update " + tb + " " +
                                     "set " + column + " = @content" +
                                          " where ID = " + ID;

            sql_code.prms_p prms = new prms_p();
            prms.enroll("content", content, SqlDbType.Binary
                       );
            run_non_query(query, prms
                         );
        }

        public static void revise(string tb, string column, string content, int ID
                                  )
        {
            string query = "update " + tb + " " +
                                     "set " + column + " = @content" +
                                          " where ID = " + ID;

            sql_code.prms_p prms = new prms_p();
            prms.enroll("content", content, SqlDbType.VarChar
                       );
            run_non_query(query, prms
                         );
        }

        public static void revise(string tb, string column, int content, int ID
                                  )
        {
            string query = "update " + tb + " " +
                                     "set " + column + " = " + content +
                                          " where ID = " + ID;

            sql_code.prms_p prms = new prms_p();

            run_non_query(query
                         );
        }

        public
    class prm_p
    {
        public
        string pseudo = "";
        public
        object content;
        public
        SqlDbType type;
    }

        public class prms_p
        {
            public
            List<prm_p>
                curs = new List<prm_p>();

            public void enroll(string pseudo, string content, SqlDbType type
                              )
            {
                prm_p prm = new prm_p();

                prm.pseudo = pseudo;

                prm.content = content;

                prm.type = type;

                curs.Add(prm);
            }

            public void enroll(string pseudo, byte[] content, SqlDbType type
                                 )
            {
                prm_p prm = new prm_p();

                prm.pseudo = pseudo;

                prm.content = content;

                prm.type = type;

                curs.Add(prm);
            }

            public void decompile(ref SqlCommand cmd
                                  )
            {
                foreach (prm_p prm in curs
                    )
                {
                    cmd.Parameters.Add("@" + prm.pseudo, prm.type
                                       );

                    cmd.Parameters["@" + prm.pseudo].Value = prm.content;
                }
            }
        }
        }
    }