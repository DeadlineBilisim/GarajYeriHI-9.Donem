using GarajYeriHI.Business.Abstract;
using GarajYeriHI.Business.Concrete;
using GarajYeriHI.Repository.Shared.Abstract;
using GarajYeriHI.Repository.Shared.Concrete;
using static System.Net.Mime.MediaTypeNames;

namespace GarajYeriHI.Web
{
    public static class Helper
    {
        public static string Buyut(this string s)
        {
            return s.ToUpper();
        }
        public static string ToTitleCase(this string s)
        {
            return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(s);
        }

        public static void ServisleriEkle(this IServiceCollection services)
        {
           
        }
    }
}
