#pragma checksum "C:\Users\jrrou\OneDrive\spring 2022\se 498\PantherPickup\VacTrack\VacTrack\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c5e2b5173abc301c331c418115e6bf92c31fac7d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c5e2b5173abc301c331c418115e6bf92c31fac7d", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9282971f47ac2b64b1dbb4eb9770b5d3c2cf08de", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PantherPickup.Models.Home.HomeModel>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\jrrou\OneDrive\spring 2022\se 498\PantherPickup\VacTrack\VacTrack\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<section class=""vh-100"" style=""background-color: #508bfc;"">
  <div class=""container py-5 h-100"">
    <div class=""row d-flex justify-content-center align-items-center h-100"">
      <div class=""col-12 col-md-8 col-lg-6 col-xl-5"">
        <div class=""card shadow-2-strong"" style=""border-radius: 1rem;"">
          <div class=""card-body p-5 text-center"">

            <h3 class=""mb-5"">Sign in</h3>

            <div class=""form-outline mb-4"">
              <input type=""email"" id=""typeEmailX-2"" class=""form-control form-control-lg"" />
              <label class=""form-label"" for=""typeEmailX-2"">Email</label>
            </div>

            <div class=""form-outline mb-4"">
              <input type=""password"" id=""typePasswordX-2"" class=""form-control form-control-lg"" />
              <label class=""form-label"" for=""typePasswordX-2"">Password</label>
            </div>

            <!-- Checkbox -->
            <div class=""form-check d-flex justify-content-start mb-4"">
              <input
                ");
            WriteLiteral("class=\"form-check-input\"\r\n                type=\"checkbox\"");
            BeginWriteAttribute("value", "\r\n                value=\"", 1170, "\"", 1195, 0);
            EndWriteAttribute();
            WriteLiteral(@"
                id=""form1Example3""
              />
              <label class=""form-check-label"" for=""form1Example3""> Remember password </label>
            </div>

            <button class=""btn btn-primary btn-lg btn-block"" type=""submit"">Login</button>

            <hr class=""my-4"">

            <button class=""btn btn-lg btn-block btn-primary"" style=""background-color: #dd4b39;"" type=""submit""><i class=""fab fa-google me-2""></i> Sign in with google</button>
            <button class=""btn btn-lg btn-block btn-primary mb-2"" style=""background-color: #3b5998;"" type=""submit""><i class=""fab fa-facebook-f me-2""></i>Sign in with facebook</button>

          </div>
        </div>
      </div>
    </div>
  </div>
</section>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PantherPickup.Models.Home.HomeModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
