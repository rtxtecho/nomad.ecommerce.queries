using System;
using System.IO;
using System.Drawing;

namespace mvc.business
{
    public class imgs
    {
        public static
            string byte_to_base64(byte[] r, string format
                                  )
        {
            System.Drawing.Image img = null;
            string base64 =
            "data:image/" + format + ";base64,";

            using (MemoryStream ms = new MemoryStream(r))
            {
                try
                {
                img = Image.FromStream(ms);
                }
                catch
                {  return base64;
                }
            }

            using (MemoryStream m = new MemoryStream())
            {
                img.Save(m, img.RawFormat);
                byte[] imageBytes = m.ToArray();
                base64 += Convert.ToBase64String(imageBytes);
            }
            return base64;
        }
    }
}
