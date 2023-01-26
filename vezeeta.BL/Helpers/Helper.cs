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

public partial class Helper
{

    public static string getLnag()
    {
        return CultureInfo.CurrentCulture.Name.StartsWith("ar") ? "ar" : "en";
    }
    
    public static Dictionary<string, object>? jsonResult(object? obj, int? status = 200)
    {
        var result = new Dictionary<string, object>();
        result["status"] = status;
        result["data"] = obj;
        return result;
    }

}
