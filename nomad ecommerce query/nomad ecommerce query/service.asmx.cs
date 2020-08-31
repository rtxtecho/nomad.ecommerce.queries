using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        }
    }
}




