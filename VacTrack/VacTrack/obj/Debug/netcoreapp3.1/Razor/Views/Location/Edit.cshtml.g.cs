#pragma checksum "C:\Users\rmari\Downloads\VacTrack\VacTrack\VacTrack\Views\Location\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "247e24077ac99dc5018629fd2d1e7d8fbc4b1922"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Location_Edit), @"mvc.1.0.view", @"/Views/Location/Edit.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"247e24077ac99dc5018629fd2d1e7d8fbc4b1922", @"/Views/Location/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0676d17497973631d09517be3d48cca1dca9263e", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Location_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<VacTrack.Models.Location.LocationModel>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("row"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\rmari\Downloads\VacTrack\VacTrack\VacTrack\Views\Location\Edit.cshtml"
  
    ViewData["Title"] = "Edit Location";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h2>Edit Location</h2>\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "247e24077ac99dc5018629fd2d1e7d8fbc4b19224154", async() => {
                WriteLiteral("\n    <div class=\"col-sm-6 mb-3\">\n        <label for=\"LocationName\" class=\"form-label\">Name</label>\n        <input type=\"text\" class=\"form-control\" id=\"LocationName\" name=\"LocationName\"");
                BeginWriteAttribute("value", " value=\"", 402, "\"", 429, 1);
#nullable restore
#line 9 "C:\Users\rmari\Downloads\VacTrack\VacTrack\VacTrack\Views\Location\Edit.cshtml"
WriteAttributeValue("", 410, Model.LocationName, 410, 19, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\n    </div>\n    <div class=\"col-sm-6 mb-3\">\n        <label for=\"Address\" class=\"form-label\">Last A</label>\n        <input type=\"text\" class=\"form-control\" id=\"Address\" name=\"Address\"");
                BeginWriteAttribute("value", " value=\"", 613, "\"", 635, 1);
#nullable restore
#line 13 "C:\Users\rmari\Downloads\VacTrack\VacTrack\VacTrack\Views\Location\Edit.cshtml"
WriteAttributeValue("", 621, Model.Address, 621, 14, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\n    </div>\n    <div class=\"col-sm-6 mb-3\">\n        <label for=\"City\" class=\"form-label\">City</label>\n        <input type=\"text\" class=\"form-control\" id=\"City\" name=\"City\"");
                BeginWriteAttribute("value", " value=\"", 808, "\"", 827, 1);
#nullable restore
#line 17 "C:\Users\rmari\Downloads\VacTrack\VacTrack\VacTrack\Views\Location\Edit.cshtml"
WriteAttributeValue("", 816, Model.City, 816, 11, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\n    </div>\n    <div class=\"col-sm-6 mb-3\">\n        <label for=\"State\" class=\"form-label\">State</label>\n        <input type=\"text\" class=\"form-control\" id=\"Age\" name=\"Age\"");
                BeginWriteAttribute("value", " value=\"", 1000, "\"", 1020, 1);
#nullable restore
#line 21 "C:\Users\rmari\Downloads\VacTrack\VacTrack\VacTrack\Views\Location\Edit.cshtml"
WriteAttributeValue("", 1008, Model.State, 1008, 12, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\n    </div>\n\n    <div class=\"col-sm-6 mb-3\">\n        <label for=\"ZipCode\" class=\"form-label\">Zip Code</label>\n        <input type=\"text\" class=\"form-control\" id=\"ZipCode\" name=\"ZipCode\" maxlength=\"5\"");
                BeginWriteAttribute("value", " value=\"", 1221, "\"", 1243, 1);
#nullable restore
#line 26 "C:\Users\rmari\Downloads\VacTrack\VacTrack\VacTrack\Views\Location\Edit.cshtml"
WriteAttributeValue("", 1229, Model.ZipCode, 1229, 14, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\n    </div>\n    <div class=\"col-sm-12\">\n        <button type=\"submit\" class=\"btn btn-primary\">Submit</button>\n        <a");
                BeginWriteAttribute("href", " href=\"", 1365, "\"", 1434, 1);
#nullable restore
#line 30 "C:\Users\rmari\Downloads\VacTrack\VacTrack\VacTrack\Views\Location\Edit.cshtml"
WriteAttributeValue("", 1372, Url.Action("Delete", "Location",new { id = Model.LocationID}), 1372, 62, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"btn btn-danger\">Delete</a>\n    </div>\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 6 "C:\Users\rmari\Downloads\VacTrack\VacTrack\VacTrack\Views\Location\Edit.cshtml"
AddHtmlAttributeValue("", 129, Url.Action("Edit", "Location", new { id = Model.LocationID}), 129, 61, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<VacTrack.Models.Location.LocationModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
