using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.Mvc;
using mvc.business;
using System.Drawing;

namespace mvc.Controllers
{
    public class HomeController : Controller
    {
        static
        SortedList<string,
        SortedList<int,
                  List<component_p
                      >
                  >
                  >
            comps_pgt = new
            SortedList<string,
        SortedList<int,
                  List<component_p
                      >
                  >
                  >();

        static SortedList<string, string
                          > search_cur = new SortedList<string, string
                                                       >();

        static SortedList<string, cli_p
                          > clis = new SortedList<string, cli_p
                                                  >();

        public string s240 = "" + (char)240;
        public string s241 = "" + (char)241;
        public string s242 = "" + (char)242;
        public string ni = "<i>Not Identified</i>";
        public string logon()
        {
            return Properties.Resources.logon;
        }

        public string logon2(string cli, string pcode
                            )
        {
            cli_p c = clis_p.get(cli, pcode
                                   );

            if (c == null
                )
            {
                string r = "Either the logon or passocde is not correct";

                return "4" + s240 + r;
            }
            string u = DateTime.Now.Ticks.ToString();
            clis.Add(u, c
                    );

            return "0" + s240 + u;
        }

        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public ActionResult Index()
        {
            return View();
        }

        public string get_record(
                                 string nomencl,
                                 string summary,
                                 string method,
                                 string id
                                 )
        {
            return get_record(
                              nomencl,
                              summary,
                              method,
                              id,
                              true
                              );
        }

        public string get_record(
                                 string nomencl,
                                 string summary,
                                 string method,
                                 string id,
                                 bool edit
                                )
        {
            string cls = "";
            if (!edit
                )
                method = "";
            else
                cls = "edit";

            string r = Properties.Resources.ht_rec.Replace("//nomencl//", nomencl
                                                           )
                                                   .Replace("//summary//", summary
                                                           )
                                                   .Replace("//method//", method
                                                           )
                                                   .Replace("//id//", id
                                                           )
                                                   .Replace("//cls//", cls
                                                           );
            return r;
        }

        public string edit_comps(int c_serv
                                 )
        {
            return Properties.Resources.ht_edit_comps;
        }

        public string get_comp(int comp, string client,
                                    int c_serv
                                   )
        {
            string cur = client;

            cli_p c = clis[cur];
            bool edit = !true;
            if (c.group_ == 1
                )
                edit = true;

            component_p comp_ = components_p.get(comp
                                               );

            string type = type_s.get(comp_.comp_type
                                    ).type;

            string r = "";

            r += get_record("Name", comp_.name, "edit_comp_name(" + comp +
                                                                  ");", "edit_comp_name", edit
                           );

            r += get_record("Type", type, "edit_comp_type(" + comp +
                                                                 ");", "edit_comp_type", edit
                          );
            string edit_img = "";

            if (edit
                )
            edit_img = Properties.Resources.ht_edit_img_choose.Replace("//comp//", comp.ToString()
                                                                           );
            string resu = Properties.Resources.ht_edit_comp.Replace("//content//", r
                                                                   )
                                                           .Replace("//src//", imgs.byte_to_base64(comp_.img, comp_.format
                                                                                              )
                                                                   )
                                                           .Replace("//edit img//", edit_img
                                                                   );
            return resu;
        }

        public string get_sub_comps(
                                    int comp, int pgt_cur, string client, string search,
                                    int c_serv
                                   )
        {
            string cur = client;
            cli_p c_ = clis[cur];
            List<component_p
                > comps = null;
            string pgt = "";
            string mx = "";
            if (comp == 0
                )
            {
                search = search.Trim();
                {
                    search = search.ToUpper();
                    if (!search_cur.ContainsKey(client
                                              )
                        )
                    {
                        search_cur.Add(client, search
                                       );
                        if (comps_pgt.ContainsKey(client
                                                 )
                            )
                            comps_pgt.Remove(client);
                    }
                    else
                    {
                        if (search == search_cur[client]
                            )
                        {
                        }
                        else
                        {
                            search_cur[client] =
                                search;
                            if (comps_pgt.ContainsKey(client
                                                     )
                                )
                                comps_pgt.Remove(client);
                        }
                    }
                }

                if (!comps_pgt.ContainsKey(client
                                         )
                    )
                { List<component_p
                      >
                  compss = null;

                    if (search == ""
                        ) compss =
                        components_p.get_sub_comps(0);
                    else compss =
                        components_p.search(search);

                    int i = 17;
                    int cur_i = 0;
                    comps_pgt.Add(client, new SortedList<int, List<component_p
                                                                   >
                                                         >()
                                  );
                    foreach (component_p c in compss
                              )
                    {
                        i++;

                        if (17 < i
                            )
                        {
                            i = 1;

                            cur_i++;

                            comps_pgt[client].Add(cur_i, new List<component_p
                                                          >()
                                                 );
                        }
                        comps_pgt[client][cur_i].Add(c);
                    }
                    pgt = Properties.Resources.ht_pgt;
                }

                if (comps_pgt[client].Count == 0
                    )
                    comps_pgt[client].Add(1, new List<business.component_p
                                                      >()
                                         );
                mx = comps_pgt[client]
                  .Count.ToString();
                comps = comps_pgt[client][pgt_cur];
            }
            else
                comps = components_p.get_sub_comps(comp);

            string r = "";
            string filter_content = "";

            foreach (component_p c in comps
                      )
            {
                if (!filter_content.Equals("")
                    )
                    filter_content += s242;
                r += "<div " +
                              "class = ''" +
                              "id = 'comp_prim_" + c.ID +
                                   "'" +
                    ">";
                filter_content += c.ID + s241 + c.name;
                r += "<div " +
                           "class = 'get_sub' " +
                           "onclick = 'get_sub_comps(" + c.ID +
                                                   ");" +
                                     "'" +
                     ">";

                r += "<img class = 'get_comp_img" +
                                  "'" +
                   "src='" + "../imgs/get_subs.png" +
                              "'" +
                      " id = 'get_comp_img_" + c.ID +
                            "'" +
                            " xpnd = '0'" +
                      "/>";

                r += "</div>";

                r += "<div " +
                            "class = 'comp'" +
                           "id = 'comp_" + c.ID +
                                "'" +
                      ">";
                if (c_.group_ == 1
                    )
                {
                    r += "<div " +
                               "class = 'get_sub' " +
                               "title = 'Create Sub Component" +
                                       "' " +
                               "onclick = 'create_sub_comp(" + c.ID +
                                                          ");" +
                                         "'" +
                         ">";

                    r += "<img src='" + "../imgs/create_sub.png" +
                                  "'" +
                          "/>";

                    r += "</div>";

                    r += "<div " +
                               "class = 'get_sub' " +
                               "title='Delete Component" +
                                      "' " +
                               "onclick = 'purge_comp(" + c.ID +
                                                          ");" +
                                         "'" +
                         ">";

                    r += "<img src='../imgs/reject.png" +
                                  "'" +
                          "/>";

                    r += "</div>";
                }

                r += "<div " +
                           "class = 'l'" +
                           "onclick = 'get_comp(" + c.ID +
                                              ")" +
                                     "'" +
                     ">";
                r += "<div " +
                           "class = 'l'" +
                       ">";
                r += "<img class = 'comp_img" +
                                   "'" +
                           "id = 'comp_img_" + c.ID +
                                "'" +
                            "src = '" + imgs.byte_to_base64(c.img, c.format
                                                           ) +
                                   "'" +
                     "/>";

                r += "</div>";
                r += "<div " +
                           "class = 'l'" +
                           " id='comp_name_" + c.ID +
                               "'" +
                      ">";
                r += c.name;

                r += "</div>";

                r += "<div " +
                           "class = 'cls'" +
                     ">";
                r += "</div>";

                r += "</div>";

                r += "<div " +
                           "class = 'cls'" +
                     ">";
                r += "</div>";

                r += "</div>";

                r += "<div " +
                           "class = 'cls'" +
                     ">";
                r += "</div>";

                r += "<div " +
                            "class = 'sub_comps" +
                                    "'" + " " +
                            "id = 'sub_comps_" + c.ID +
                                  "'" +
                     ">";

                r += "</div>";
                r += "</div>";
            }
            if (r == ""
                )
                r = "<i>" + "No Sub Components" +
                      "</i>";

            return r + s240 + comp + s240 + pgt + s240 + mx + s240 + filter_content;
        }

        public string get_t_bo(
                               string id,
                               string cur,
                               int mx
                               )
        {
            int c_cur = cur.Length;

            string r = Properties.Resources.ht_t_bo.Replace("//id//", id
                                                           )
                                                    .Replace("//cur//", cur
                                                           )
                                                    .Replace("//c_cur//", c_cur.ToString()
                                                           )
                                                    .Replace("//c_mx//", mx.ToString()
                                                           );

            return r;
        }
        public string purge_comp(int comp, string client,
                                  int c_serv
                                )
        {
            int sub_comps = components_p.get_sub_comps(comp).Count;

            if (sub_comps == 0
                )
            {
                component_p c = components_p.get(comp);

                c.purge();
                purge_comp_from_pgt(c, client
                                   );
                return "0" + s240 + c.super_comp;
            }

            string r = "There are sub components associated to this." + "<br>" + "<br>";

            r += get_record("Purge sub components", "Purge this & each sub component",
                            "purge_comp_subs(" + comp +
                            ");", ""
                            );
            r += get_record("Promote sub components", "Purge this, but promote each sub component",
                              "purge_comp_promote(" + comp +
                                                ");", ""
                            );

            string topic = "Sub Components";

            return "2" + s240 + r + s240 + topic;
        }

        public string purge_comp_subs(int comp, string client,
                                  int c_serv
                                    )
        {
            component_p c = components_p.get(comp);

            purge_comp_subs_recurs(c);

            return c.super_comp.ToString();
        }

        public void purge_comp_subs_recurs(component_p comp
                                          )
        {
            comp.purge();

            List<component_p
                > subs = components_p.get_sub_comps(comp.ID
                                                    );

            foreach (component_p r in subs
                    )
            {
                purge_comp_subs_recurs(r);
            }
        }
        public string purge_comp_promote(int comp, string client,
                                  int c_serv
                                           )
        {
            component_p c = components_p.get(comp);
            c.purge();

            List<component_p
                > subs = components_p.get_sub_comps(comp);

            foreach (component_p r in subs
                    )
            {
                r.revise("super_comp", c.super_comp
                       );
            }

            return c.super_comp.ToString();
        }

        public void purge_comp_from_pgt(component_p comp, string client
                                         )
        {
            if (comp.super_comp > 0
                )
                return;

            foreach (int i in comps_pgt[client].Keys
                    )
            {
                component_p c = comps_pgt[client][i].Find(p => p.ID == comp.ID
                                                             );

                if (c == null
                    )
                {
                }
                else
                {
                    comps_pgt[client][i].Remove(c);

                    break;
                }
            }
        }

        public string create_sub_comp(
                                    int comp, int c_serv
                                   )
        {
            string img = Properties.Resources.ht_create_sub_comp_img;
            string r = "";

            r += get_record("Name", ni, "create_sub_comp_name();", "create_sub_comp_name"
                            );

            r += get_record("Type", ni, "create_sub_comp_type();", "create_sub_comp_type"
                            );

            r += get_record("Image", img,
                "create_sub_comp_img();", "create_sub_comp_img"
                            );

            r += "<br><br>";

            r += get_record("Store", "Store this component", "create_sub_comp2(" + comp +
                                                                             ");", ""
                           );

            string topic = "Create Component";

            if (comp > 0
                )
            {
                topic = "Create Sub Component for: ";

                component_p comp_ =
                    components_p.get(comp);

                topic += comp_.name;
            }

            r += s240 + topic;

            return r;
        }

        public string create_sub_comp2(
                                    string name, int type, int super_comp, string img_stg, string client,
                                    int c_serv
                                   )
        {
            string r = "";

            name = name.Trim();

            if (name == ""
                )
                r += "You must provide the <i>name</i> for this component" + "<br>";

            if (type == 0
                )
                r += "<i>Type</i> is required for this component" + "<br>";
            if (img_stg == ""
                )
                r += "<i>Image</i> is required for this component" + "<br>";

            img_stg_p ims = img_stgs_p.get(img_stg
                                          );
            if (ims == null
                )
                r += "Could not locate the image" + "<br>";

            if (!r.Equals("")
                )
                //2 = error
                return "2" + s240 + r;

            ims.purge();
            string cur = DateTime.Now.Ticks.ToString();

            component_p comp = new component_p();

            comp.name = name;
            if (super_comp == 0
                )
                comp.name = cur;

            comp.comp_type = type;

            comp.super_comp = super_comp;

            comp.img = ims.img;
            comp.format = ims.format;
            comp.submit();

            if (super_comp == 0
                )
            {
                comp = components_p.get(cur);
                comp.name = name;
                comp.revise("name", name
                           );

                int i = comps_pgt[client].Count;
                comps_pgt[client][i].Add(comp
                                          );
                }
            
            return "0" + s240 + super_comp;
            }

        public string create_sub_comp_name(int c_serv
                                          )
        {
            string method = "create_sub_comp_name2();";

            return edit_comp_name_generic("", method
                                          );
        }


        public string edit_comp_name(int comp, int c_serv
                                            )
        {
            component_p comp_ = components_p.get(comp);

            string cur = comp_.name;

            string method = "edit_comp_name2(" + comp +
                                            ");";

            return edit_comp_name_generic(cur, method
                                           );
        }

        public string edit_comp_name2(int comp, string cur, int c_serv
                                      )
        {
            component_p comp_ = components_p.get(comp);
            comp_.revise("name", cur
                           );

            return comp + s240 + cur;
        }

        public string edit_comp_name_generic(string cur, string method
                                            )
        {

            int c = sql_code.get_c_count("component", "name"
                                        );

            string r = "<br>";

            r += get_t_bo("t_bo_edit_comp_name", cur, c
                         );

            r += "<br><br>";

            r += get_record("Store", "Store this name", method, ""
                           );

            string topic = "Component Name";

            r += s240 + topic;

            return r;
        }

        public string create_sub_comp_type(int c_serv
                                          )
        {
            string method = "create_sub_comp_type2";

            return edit_comp_type_generic(method, ""
                                           );
        }

        public string edit_comp_type(int comp, int c_serv
                                          )
        {
            string method = "edit_comp_type2";

            return edit_comp_type_generic(method, comp.ToString()
                                          );
        }

        public string edit_comp_type2(int comp, int type, int c_serv
                                          )
        {
            component_p c = components_p.get(comp);

            c.revise("comp_type", type
                    );

            type_ r = type_s.get(type);

            return comp + s240 + r.type;
        }

        public string edit_comp_type_generic(string method, string prms
                                          )
        {
            List<type_> types = type_s.get();

            string r = "<br>";

            foreach (type_ ty in types
                    )
            {
                string prms2 = ty.ID + ",'" + ty.type +
                                         "'";

                if (!prms.Equals("")
                    )
                    prms2 += ", " +
                          prms;

                r += Properties.Resources.ht_srs.Replace("//method//", method
                                                        )
                                                .Replace("//prms//", prms2
                                                        )
                                                .Replace("//content//", ty.type
                                                        );
            }

            string topic = "Choose the type";

            return r + s240 + topic;
        }

        public string create_sub_comp_img(int c_serv
                                          )
        {
            string r = Properties.Resources.ht_fi.Replace("//method//", "create_sub_comp_img2"
                                                         )
                                                  .Replace("//prms//", ""
                                                        );
            string topic = "Choose the Image [.png, .bmp, .jpg]";

            return r + s240 + topic;
        }

        public string edit_comp_img(int comp, int c_serv
                                          )
        {
            string r = Properties.Resources.ht_fi.Replace("//method//", "edit_comp_img2"
                                                         )
                                                 .Replace("//prms//", ", " + comp
                                                          );

            string topic = "Choose the Image [.png, .bmp, .jpg]";

            return r + s240 + topic;
        }

        public string edit_comp_img2(
                                   string img_stg,
                                   int comp,
                                   int c_serv
                                    )

        {
            img_stg_p ims = img_stgs_p.get(img_stg
                                             );
            string r = "";
            if (ims == null
                )
                r += "Could not locate the image" + "<br>";

            if (!r.Equals("")
                )
                //2 = error
                return "2" + s240 + r;
            ims.purge();

            component_p c = components_p.get(comp
                                             );

            c.revise("img", ims.img
                     );

            c.revise("format", ims.format
                     );

            return "0" + s240 + comp + s240 + imgs.byte_to_base64(ims.img, ims.format
                                                               );
        }
        
        }
    }