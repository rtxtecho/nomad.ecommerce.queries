using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nomad_ecommerce_query
{
    public partial class query : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            script_m.Services.Add(new ServiceReference("~/service.asmx"
                                                      )
                                  );
        }
    }
}
