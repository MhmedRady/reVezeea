using Microsoft.AspNetCore.Http;

namespace vezeeta.BL;

public partial class Helper
{
    public static string? uploadeFile(IFormFile img, string? dirName)
    {
        Random rand = new Random();
        var r = rand.Next(1000, int.Parse(DateTime.Now.ToString("yyyyyMMmmss"))).ToString();
        var format_ext_image = Path.GetExtension(img.FileName).ToLower();
        string[] format_images = new string[] { ".jpg", ".jpeg", ".png" };
        if (!format_images.Contains(format_ext_image))
        {
            return "there is problem in extention of image";
        }
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

}