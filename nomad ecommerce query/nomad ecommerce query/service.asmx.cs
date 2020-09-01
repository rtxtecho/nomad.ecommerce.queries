using System;
using System.IO;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using nomad_ecommerce_query.business;

namespace nomad_ecommerce_query
{
    /// <summary>
    /// Summary description for service
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(!true)
    ]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class service : System.Web.Services.WebService
    {
        [WebMethod]
        public void create_components()
        {
            List<int> components = new List<int>();

            List<int> tag = new List<int>();

            List<int> tag_set_name = new List<int>();

            Random r = new Random();

            int ii = 0;
            /*
            for (int i = 0; i < 400; i++
                )
            {
                component_p res = new component_p();

                ii = r.Next(1000);

                for (; components.Contains(ii);
                    )
                {
                    ii = r.Next(1000);
                }

                components.Add(ii);

                res.component = "component " + ii;

                ii = r.Next(1000);

                for (; tag.Contains(ii);
                    )
                {
                    ii = r.Next(1000);
                }

                tag.Add(ii);

                res.tag = "tag " + ii;

                ii = r.Next(1000);

                for (; tag_set_name.Contains(ii);
                    )
                {
                    ii = r.Next(1000);
                }

                tag_set_name.Add(ii);

                res.tag_set_name = "tag set name " + ii;

                res.base_cost = r.Next(4, 1000
                                     );

                res.stoc_qty = r.Next(4, 1000
                                      );

                res.submit();
            }
            List<int> customers = new List<int>();
            //customers
            for (int i = 0; i < 400; i++
               )
            {
                customer_p res = new business.customer_p();

                ii = r.Next(1000);

                for (; customers.Contains(ii);
                    )
                {
                    ii = r.Next(1000);
                }

                customers.Add(ii);

                res.customer = "customer " + ii;

                ii = r.Next(1000, 10000);

                res.street = "street " + ii;

                ii = r.Next(100);

                res.city = "city " + ii;

                ii = r.Next(47);

                res.state = "state " + ii;

                ii = r.Next(10000, 88888
                           );
                res.zip = "" + ii;

                res.submit();
            }
            //orders
            List<customer_p
                > custs = customers_p.get();

            foreach (customer_p c in custs
               )
            {
                int mx = r.Next(1, 17
                             );

                for (int i = 0; i < mx; i++
                    )
                {
                    ii = r.Next(3600);

                    DateTime cur = new DateTime(1800, 1, 4
                                                  );

                    cur = cur.AddDays(ii);

                    List<int> no = new int[] { 3, 1, 9, 4
                                             }.ToList();

                    for (bool ignore = true; ignore;
                        )
                    {
                        if (no.Contains(cur.Month
                                         )
                            )
                        {
                            cur = cur.AddMonths(1);

                        }
                        else
                            ignore = !true;
                    }

                    order_p order = new order_p();

                    order.customer = c.ID;

                    order.ordered = cur;

                    order.submit();
                }
            }
            */
            List<component_p
                > cmps = components_p.get();

            List<order_p
                > ords = orders_p.get();

            foreach (order_p op in ords
                     )
            {
                int mx = r.Next(1, 17
                                );
                List<int> cur_cmps = new List<int>();

                for (int i = 0; i < mx; i++
                    )
                {
                    rel_order_comp_p rel = new rel_order_comp_p();

                    rel.order = op.ID;

                    int c = r.Next(1, cmps.Count - 1
                                  );

                    for (; cur_cmps.Contains(c);
                        )
                    {
                        c = r.Next(1, cmps.Count - 1
                                 );
                    }

                    rel.comp = cmps[c].ID;

                    int
                       lo_cost = (int)cmps[c].base_cost - 10;

                    if (lo_cost < 1
                        )
                        lo_cost = 1;

                    int
                     m_cost = (int)cmps[c].base_cost + 10;

                    rel.cost = r.Next(lo_cost, m_cost
                                   );

                    rel.qty = r.Next(1, 100);

                    rel.submit();
                }
            }
        }

        struct unique_price
        {
            public
            string component;
            public
            double price;
            public
            int count;
        }

        [WebMethod]
        public string unique_prices()
        {
            string r = Properties.Resources.query_unique_price;

            SqlConnection conn = null;

            SqlDataReader SDR = sql_code.run_query(r, ref conn
                                                  );

            SortedList<string, List<unique_price
                                    >
                > prices = new SortedList<string, List<unique_price
                                                       >
                                          >();

            for (; SDR.Read();
                )
            {
                unique_price u = new nomad_ecommerce_query.service.unique_price();
                string comp =
                 sql_code.get_s(SDR, "component"
                               );

                u.component = comp;

                u.price = sql_code.get_n(SDR, "cost"
                                        );

                u.count = sql_code.get_i(SDR, "c"
                                        );

                if (!prices.ContainsKey(comp)
                    )
                    prices.Add(comp, new List<unique_price
                                            >()
                               );

                prices[comp].Add(u);
            }

            string res = "";

            foreach (string comp in prices.Keys
                     )
            {
                res +=
                 "<b>" + comp +
                    "</b>";

                res +=
                "<div " +
                              "style = 'margin-left: 17px;" +
                                      "'" +
                      ">";

                Table tb = new Table();

                {
                    TableRow tr = new TableRow();

                    TableCell c1 = new TableCell();

                    c1.Text = "Price";

                    tr.Cells.Add(c1);

                    TableCell c2 = new TableCell();

                    c2.Text = "Count";

                    tr.Cells.Add(c2);

                    tb.Rows.Add(tr);
                }

                foreach (unique_price u in prices[comp]
                        )
                {
                    TableRow tr = new TableRow();

                    TableCell c1 = new TableCell();

                    c1.Text = "$" + u.price;

                    tr.Cells.Add(c1);

                    TableCell c2 = new TableCell();

                    c2.Text = "" + u.count;

                    tr.Cells.Add(c2);

                    tb.Rows.Add(tr);
                }

                StringBuilder sb = new StringBuilder();

                StringWriter sr = new StringWriter(sb);

                HtmlTextWriter hsr = new HtmlTextWriter(sr);

                tb.RenderControl(hsr);

                res += sb.ToString();
            }

            return res;
        }
    }
}

                    