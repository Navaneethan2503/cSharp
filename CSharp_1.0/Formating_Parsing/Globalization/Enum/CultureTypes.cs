using System;
using System.Globalization;
/**

Name	Value	Description
NeutralCultures	1	Cultures that are associated with a language but are not specific to a country/region.
SpecificCultures	2	Cultures that are specific to a country/region.
AllCultures	7	All cultures that are recognized by .NET, including neutral and specific cultures and custom cultures created by the user.

**/
namespace GlobalizationEnum{
    class CultureTypesEnum{
        public static void Main(){
            Console.WriteLine("Globalization Culture Types.");
            // Get and enumerate all cultures.
            var allCultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            foreach (var ci in allCultures)
            {
                // Display the name of each culture.
                if(ci.EnglishName.Contains("India")){
                    Console.Write($"{ci.EnglishName} ({ci.Name}): ");
                    // Indicate the culture type.
                    if (ci.CultureTypes.HasFlag(CultureTypes.NeutralCultures))
                    Console.Write(" NeutralCulture");
                    if (ci.CultureTypes.HasFlag(CultureTypes.SpecificCultures))
                    Console.Write(" SpecificCulture");
                    Console.WriteLine();
                }
                
            }
        }
    }
}