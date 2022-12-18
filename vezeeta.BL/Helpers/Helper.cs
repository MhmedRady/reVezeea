using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.Extensions.Localization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace vezeeta.BL;

public class Helper
{

    public static string getLnag()
    {
        return CultureInfo.CurrentCulture.Name.StartsWith("ar") ? "ar" : "en";
    }

    public static int RandomNum(int min = 1000, int max = 9999)
    {
        var random = new Random();
        return random.Next(min, max);
    }

    public static string? cutString(string value, int maxLength)
    {
        if (string.IsNullOrEmpty(value)) return value;
        return value.Length <= maxLength ? value : value.Substring(0, maxLength) + "...";
    }

    public static string? uploadeFile(IFormFile img, string? dirName)
    {
        Random rand = new Random();
        var r = rand.Next(1000, int.Parse(DateTime.Now.ToString("yyyyyMMmmss"))).ToString();
        string uniqueImge = r + "." + img.FileName.Split(".")[1];
        if (!System.IO.Directory.Exists(@$".\wwwroot\images\uploaded\{dirName}"))
        {
            System.IO.Directory.CreateDirectory(@$".\wwwroot\images\uploaded\{dirName}");
        }
        using (var obj = new FileStream(@$".\wwwroot\images\uploaded\{dirName}\" + uniqueImge, FileMode.Create))
        {
            img.CopyTo(obj);
        }
        return dirName != null ? @$"{dirName}/{uniqueImge}" : uniqueImge;
    }

    public static string? imageUrl(string? image)
    {
        if (image == null)
            return @"/images/DefaultImage.png";
        if (image.StartsWith("http") || image.StartsWith("https"))
        {
            return image;
        }
        return $@"/images/uploaded/{image}";
    }

    public static string? nameWithLang(string? name_ar, string? name_en)
    {
        return getLnag() == "ar" ? name_ar : name_en;
    }

    public static Dictionary<string, object>? jsonResult(object? obj, int? status = 200)
    {
        var result = new Dictionary<string, object>();
        result["status"] = 200;
        result["data"] = obj;
        return result;
    }

}
