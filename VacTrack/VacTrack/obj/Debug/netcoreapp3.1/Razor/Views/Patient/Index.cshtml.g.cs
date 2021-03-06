#pragma checksum "C:\Users\rmari\Downloads\VacTrack\VacTrack\VacTrack\Views\Patient\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "18525dbbc73bd7eb2296d8a46f63cb54db7e9216"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Patient_Index), @"mvc.1.0.view", @"/Views/Patient/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"18525dbbc73bd7eb2296d8a46f63cb54db7e9216", @"/Views/Patient/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0676d17497973631d09517be3d48cca1dca9263e", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Patient_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "POST", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\rmari\Downloads\VacTrack\VacTrack\VacTrack\Views\Patient\Index.cshtml"
  
    ViewData["Title"] = "Patients";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h2>Patients</h2>\n<div class=\"alert alert-info\">The list of patients is below.</div>\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "18525dbbc73bd7eb2296d8a46f63cb54db7e92163840", async() => {
                WriteLiteral(@"
    <div class=""input-group mb-3"">
        <input type=""text"" class=""form-control"" placeholder=""Patient Name"" aria-label=""Patient Name"" aria-describedby=""button-addon2"" id=""Query"" name=""Query"">
        <input type=""submit"" class=""btn btn-outline-secondary"" id=""button-addon2"" value=""Search"" />
    </div>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 6 "C:\Users\rmari\Downloads\VacTrack\VacTrack\VacTrack\Views\Patient\Index.cshtml"
AddHtmlAttributeValue("", 140, Url.Action("Index", "Patient"), 140, 31, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n<table class=\"table\">\n    <thead>\n        <tr>\n            <td>Patient ID</td>\n            <td>Patient Name</td>\n            <td>Age</td>\n            <td>Zip Code</td>\n            <td></td>\n        </tr>\n    </thead>\n");
#nullable restore
#line 22 "C:\Users\rmari\Downloads\VacTrack\VacTrack\VacTrack\Views\Patient\Index.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <tr>\n        <td>");
#nullable restore
#line 25 "C:\Users\rmari\Downloads\VacTrack\VacTrack\VacTrack\Views\Patient\Index.cshtml"
       Write(item.PatientID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n        <td>");
#nullable restore
#line 26 "C:\Users\rmari\Downloads\VacTrack\VacTrack\VacTrack\Views\Patient\Index.cshtml"
       Write(item.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 26 "C:\Users\rmari\Downloads\VacTrack\VacTrack\VacTrack\Views\Patient\Index.cshtml"
                       Write(item.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n        <td>");
#nullable restore
#line 27 "C:\Users\rmari\Downloads\VacTrack\VacTrack\VacTrack\Views\Patient\Index.cshtml"
       Write(item.Age);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n        <td>");
#nullable restore
#line 28 "C:\Users\rmari\Downloads\VacTrack\VacTrack\VacTrack\Views\Patient\Index.cshtml"
       Write(item.ZipCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n        <td>\n            <a");
            BeginWriteAttribute("href", " href=\"", 932, "\"", 1001, 1);
#nullable restore
#line 30 "C:\Users\rmari\Downloads\VacTrack\VacTrack\VacTrack\Views\Patient\Index.cshtml"
WriteAttributeValue("", 939, Url.Action("Details", "Patient", new { id = item.PatientID }), 939, 62, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-outline-primary\" role=\"button\">Info</a>\n            <a");
            BeginWriteAttribute("href", " href=\"", 1072, "\"", 1138, 1);
#nullable restore
#line 31 "C:\Users\rmari\Downloads\VacTrack\VacTrack\VacTrack\Views\Patient\Index.cshtml"
WriteAttributeValue("", 1079, Url.Action("Edit", "Patient", new { id = item.PatientID }), 1079, 59, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-outline-primary\" role=\"button\">Edit</a>\n        </td>\n    </tr>\n");
#nullable restore
#line 34 "C:\Users\rmari\Downloads\VacTrack\VacTrack\VacTrack\Views\Patient\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>\n\n<a");
            BeginWriteAttribute("href", " href=\"", 1237, "\"", 1276, 1);
#nullable restore
#line 37 "C:\Users\rmari\Downloads\VacTrack\VacTrack\VacTrack\Views\Patient\Index.cshtml"
WriteAttributeValue("", 1244, Url.Action("Create", "Patient"), 1244, 32, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary\" role=\"button\">Add Patient</a>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
