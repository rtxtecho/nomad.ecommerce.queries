using System.Linq;
using System.IO;
using System.Web.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Diagnostics;

using mvc.business;

namespace mvc.Controllers
{
    public class fileController : ApiController
    {
        [HttpPost()]
        public string UploadFiles()
        {
            string s240 = (char)240 + "";
            string cur = DateTime.Now.Ticks.ToString();
            int cnt = 0;

            string sPath = "";
            sPath = System.Web.Hosting.HostingEnvironment.MapPath("~/imgs/" + "stg/"
                                                                 );

            DirectoryInfo folder = new DirectoryInfo(sPath);

            string ext = "";

            if (!folder.Exists
                )
                folder.Create();

            System.Web.HttpFileCollection hfc = System.Web.HttpContext.Current.Request.Files;
            byte[] img = new byte[] { };
            for (int i = 0; i <= hfc.Count - 1; i++)
            {
                System.Web.HttpPostedFile hpf = hfc[i];

                if (hpf.ContentLength > 0)
                {
                    List<string> comps = hpf.FileName.Split('.').ToList();

                    comps.Reverse();

                    ext = comps[0].ToUpper();

                    if (ext == "BMP" || ext == "PNG" || ext == "JPG"
                        )
                    {
                    }
                    else
                        return 1 + s240 + "File format must be .bmp | png | jpg";

                    string store_to = cur + "." + ext;

                    int ii = hpf.ContentLength;
                    img = new byte[ii];
                    hpf.InputStream.Read(img, 0, ii
                                        );

                    img_stg_p r = new business.img_stg_p();

                    r.ID = cur;

                    r.img = img;

                    r.format = ext;

                    r.submit();

                    cnt++;
                }
            }

            if (cnt > 0)
            {
                return "0" + s240 + cur + s240 + ext + s240 + imgs.byte_to_base64(img, ext
                                                                                 );
            }
            else
            {
                return "Upload Failed";
            }
        }
    }
}