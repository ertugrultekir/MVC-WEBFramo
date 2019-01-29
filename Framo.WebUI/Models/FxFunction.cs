using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Framo.WebUI.Models
{
    public enum Path
    {
        Users, Posters, Sliders
    }

    public class FxFunction
    {
        public static string ImageUpload(HttpPostedFileBase resim, Path path, out bool islemSonucu)
        {
            if (resim != null)
            {
                if (resim.ContentType.Contains("image"))
                {
                    if (resim.ContentLength < 2000000)
                    {
                        string benzersiz = Guid.NewGuid().ToString().Replace('-', '_').ToLower();
                        string posterPath = $"uploads/{path.ToString()}/{benzersiz}.{resim.ContentType.Split('/')[1]}";
                        resim.SaveAs(HttpContext.Current.Server.MapPath($"~/Content/{posterPath}"));
                        islemSonucu = true;
                        return posterPath;
                    }
                    else
                    {
                        islemSonucu = false;
                        return $"Lütfen 2 megabyte altında resim seçin.";
                    }
                }
                else
                {
                    islemSonucu = false;
                    return $"Lütfen sadece resim dosyası seçin.";
                }
            }
            else
            {
                islemSonucu = false;
                return $"Lütfen yüklemek için bir resim dosyası seçiniz.";
            }
        }
    }
}