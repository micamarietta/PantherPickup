#pragma checksum "C:\Users\jrrou\OneDrive\spring 2022\se 498\PantherPickup\VacTrack\VacTrack\Views\VaccinationLocation\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d5f4b0d3d331ca764beb88d08b22a1129afe826e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_VaccinationLocation_Index), @"mvc.1.0.view", @"/Views/VaccinationLocation/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\jrrou\OneDrive\spring 2022\se 498\PantherPickup\VacTrack\VacTrack\Views\_ViewImports.cshtml"
using PantherPickup;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\jrrou\OneDrive\spring 2022\se 498\PantherPickup\VacTrack\VacTrack\Views\_ViewImports.cshtml"
using PantherPickup.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d5f4b0d3d331ca764beb88d08b22a1129afe826e", @"/Views/VaccinationLocation/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9282971f47ac2b64b1dbb4eb9770b5d3c2cf08de", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_VaccinationLocation_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<PantherPickup.Models.VaccinationLocation.VaccinationLocationModel>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\jrrou\OneDrive\spring 2022\se 498\PantherPickup\VacTrack\VacTrack\Views\VaccinationLocation\Index.cshtml"
  
    ViewData["Title"] = "Locations";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<h2>Vaccination Locations</h2>
<div class=""alert alert-info"">The list of vaccination locations is below.</div>
<table class=""table"">
    <thead>
        <tr>
            <td>Vaccine</td>
            <td>Location</td>
            <td></td>
        </tr>
    </thead>
");
#nullable restore
#line 15 "C:\Users\jrrou\OneDrive\spring 2022\se 498\PantherPickup\VacTrack\VacTrack\Views\VaccinationLocation\Index.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>");
#nullable restore
#line 18 "C:\Users\jrrou\OneDrive\spring 2022\se 498\PantherPickup\VacTrack\VacTrack\Views\VaccinationLocation\Index.cshtml"
           Write(item.Vaccine.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 19 "C:\Users\jrrou\OneDrive\spring 2022\se 498\PantherPickup\VacTrack\VacTrack\Views\VaccinationLocation\Index.cshtml"
           Write(item.Location.LocationName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>\r\n                <a");
            BeginWriteAttribute("href", " href=\"", 583, "\"", 676, 1);
#nullable restore
#line 21 "C:\Users\jrrou\OneDrive\spring 2022\se 498\PantherPickup\VacTrack\VacTrack\Views\VaccinationLocation\Index.cshtml"
WriteAttributeValue("", 590, Url.Action("Details", "VaccinationLocation", new { id = item.VaccinationLocationID }), 590, 86, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-outline-primary\" role=\"button\">Info</a>\r\n                <a");
            BeginWriteAttribute("href", " href=\"", 752, "\"", 842, 1);
#nullable restore
#line 22 "C:\Users\jrrou\OneDrive\spring 2022\se 498\PantherPickup\VacTrack\VacTrack\Views\VaccinationLocation\Index.cshtml"
WriteAttributeValue("", 759, Url.Action("Edit", "VaccinationLocation", new { id = item.VaccinationLocationID }), 759, 83, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-outline-primary\" role=\"button\">Edit</a>\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 25 "C:\Users\jrrou\OneDrive\spring 2022\se 498\PantherPickup\VacTrack\VacTrack\Views\VaccinationLocation\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>\r\n\r\n<a");
            BeginWriteAttribute("href", " href=\"", 955, "\"", 1006, 1);
#nullable restore
#line 28 "C:\Users\jrrou\OneDrive\spring 2022\se 498\PantherPickup\VacTrack\VacTrack\Views\VaccinationLocation\Index.cshtml"
WriteAttributeValue("", 962, Url.Action("Create", "VaccinationLocation"), 962, 44, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary\" role=\"button\">Add Vaccination Location</a>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<PantherPickup.Models.VaccinationLocation.VaccinationLocationModel>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
