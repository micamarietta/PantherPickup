#pragma checksum "C:\Users\rmari\Downloads\VacTrack\VacTrack\VacTrack\Views\VaccinationLocation\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e2b57e15019b458bc57b98e94c56382c13299aae"
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
#line 1 "C:\Users\rmari\Downloads\VacTrack\VacTrack\VacTrack\Views\_ViewImports.cshtml"
using VacTrack;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\rmari\Downloads\VacTrack\VacTrack\VacTrack\Views\_ViewImports.cshtml"
using VacTrack.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e2b57e15019b458bc57b98e94c56382c13299aae", @"/Views/VaccinationLocation/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0676d17497973631d09517be3d48cca1dca9263e", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_VaccinationLocation_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<VacTrack.Models.VaccinationLocation.VaccinationLocationModel>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\rmari\Downloads\VacTrack\VacTrack\VacTrack\Views\VaccinationLocation\Index.cshtml"
  
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
#line 15 "C:\Users\rmari\Downloads\VacTrack\VacTrack\VacTrack\Views\VaccinationLocation\Index.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\n            <td>");
#nullable restore
#line 18 "C:\Users\rmari\Downloads\VacTrack\VacTrack\VacTrack\Views\VaccinationLocation\Index.cshtml"
           Write(item.Vaccine.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            <td>");
#nullable restore
#line 19 "C:\Users\rmari\Downloads\VacTrack\VacTrack\VacTrack\Views\VaccinationLocation\Index.cshtml"
           Write(item.Location.LocationName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            <td>\n                <a");
            BeginWriteAttribute("href", " href=\"", 558, "\"", 651, 1);
#nullable restore
#line 21 "C:\Users\rmari\Downloads\VacTrack\VacTrack\VacTrack\Views\VaccinationLocation\Index.cshtml"
WriteAttributeValue("", 565, Url.Action("Details", "VaccinationLocation", new { id = item.VaccinationLocationID }), 565, 86, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-outline-primary\" role=\"button\">Info</a>\n                <a");
            BeginWriteAttribute("href", " href=\"", 726, "\"", 816, 1);
#nullable restore
#line 22 "C:\Users\rmari\Downloads\VacTrack\VacTrack\VacTrack\Views\VaccinationLocation\Index.cshtml"
WriteAttributeValue("", 733, Url.Action("Edit", "VaccinationLocation", new { id = item.VaccinationLocationID }), 733, 83, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-outline-primary\" role=\"button\">Edit</a>\n            </td>\n        </tr>\n");
#nullable restore
#line 25 "C:\Users\rmari\Downloads\VacTrack\VacTrack\VacTrack\Views\VaccinationLocation\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>\n\n<a");
            BeginWriteAttribute("href", " href=\"", 923, "\"", 974, 1);
#nullable restore
#line 28 "C:\Users\rmari\Downloads\VacTrack\VacTrack\VacTrack\Views\VaccinationLocation\Index.cshtml"
WriteAttributeValue("", 930, Url.Action("Create", "VaccinationLocation"), 930, 44, false);

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<VacTrack.Models.VaccinationLocation.VaccinationLocationModel>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
