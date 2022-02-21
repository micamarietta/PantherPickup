#pragma checksum "C:\Users\rmari\Downloads\VacTrack\VacTrack\VacTrack\Views\Appointment\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a25d8647925fea7dfc8f1d84203d83f9b9f30fb4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Appointment_Edit), @"mvc.1.0.view", @"/Views/Appointment/Edit.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a25d8647925fea7dfc8f1d84203d83f9b9f30fb4", @"/Views/Appointment/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0676d17497973631d09517be3d48cca1dca9263e", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Appointment_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<VacTrack.Models.Appointment.AppointmentModel>
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\rmari\Downloads\VacTrack\VacTrack\VacTrack\Views\Appointment\Edit.cshtml"
  
    ViewData["Title"] = "Edit Appointment";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h2>Edit Appointment</h2>\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a25d8647925fea7dfc8f1d84203d83f9b9f30fb44316", async() => {
                WriteLiteral("\n    <div class=\"col-sm-6 mb-3\">\n        <label for=\"PatientID\" class=\"form-label\">Patient</label>\n        <select class=\"form-select\" aria-label=\"Default select example\" id=\"PatientID\" name=\"PatientID\">\n");
#nullable restore
#line 10 "C:\Users\rmari\Downloads\VacTrack\VacTrack\VacTrack\Views\Appointment\Edit.cshtml"
              
                foreach (var patient in Model.Patients)
                {
                    if (Model.PatientID == patient.PatientID)
                    {
                        

#line default
#line hidden
#nullable disable
                WriteLiteral("\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a25d8647925fea7dfc8f1d84203d83f9b9f30fb45219", async() => {
#nullable restore
#line 16 "C:\Users\rmari\Downloads\VacTrack\VacTrack\VacTrack\Views\Appointment\Edit.cshtml"
                                                                   Write(patient.FirstName);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 16 "C:\Users\rmari\Downloads\VacTrack\VacTrack\VacTrack\Views\Appointment\Edit.cshtml"
                               WriteLiteral(patient.PatientID);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n                        ");
#nullable restore
#line 17 "C:\Users\rmari\Downloads\VacTrack\VacTrack\VacTrack\Views\Appointment\Edit.cshtml"
                               
                    }
                    else
                    {
                        

#line default
#line hidden
#nullable disable
                WriteLiteral("\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a25d8647925fea7dfc8f1d84203d83f9b9f30fb47831", async() => {
#nullable restore
#line 22 "C:\Users\rmari\Downloads\VacTrack\VacTrack\VacTrack\Views\Appointment\Edit.cshtml"
                                                          Write(patient.FirstName);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 22 "C:\Users\rmari\Downloads\VacTrack\VacTrack\VacTrack\Views\Appointment\Edit.cshtml"
                               WriteLiteral(patient.PatientID);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n                        ");
#nullable restore
#line 23 "C:\Users\rmari\Downloads\VacTrack\VacTrack\VacTrack\Views\Appointment\Edit.cshtml"
                               
                    }

                }
            

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
        </select>
    </div>
    <div class=""col-sm-6 mb-3"">
        <label for=""VaccinationLocationID"" class=""form-label"">Vaccination Location</label>
        <select class=""form-select"" aria-label=""Default select example"" id=""VaccinationLocationID"" name=""VaccinationLocationID"">
");
#nullable restore
#line 34 "C:\Users\rmari\Downloads\VacTrack\VacTrack\VacTrack\Views\Appointment\Edit.cshtml"
              
                foreach (var vaccLocation in Model.VaccinationLocations)
                {
                    if (Model.VaccinationLocationID == vaccLocation.VaccinationLocationID)
                    {
                        

#line default
#line hidden
#nullable disable
                WriteLiteral("\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a25d8647925fea7dfc8f1d84203d83f9b9f30fb410811", async() => {
#nullable restore
#line 40 "C:\Users\rmari\Downloads\VacTrack\VacTrack\VacTrack\Views\Appointment\Edit.cshtml"
                                                                                    Write(vaccLocation.Location.LocationName);

#line default
#line hidden
#nullable disable
                    WriteLiteral(" ");
#nullable restore
#line 40 "C:\Users\rmari\Downloads\VacTrack\VacTrack\VacTrack\Views\Appointment\Edit.cshtml"
                                                                                                                        Write(vaccLocation.Vaccine.Name);

#line default
#line hidden
#nullable disable
                    WriteLiteral(" ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 40 "C:\Users\rmari\Downloads\VacTrack\VacTrack\VacTrack\Views\Appointment\Edit.cshtml"
                               WriteLiteral(vaccLocation.VaccinationLocationID);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n                        ");
#nullable restore
#line 41 "C:\Users\rmari\Downloads\VacTrack\VacTrack\VacTrack\Views\Appointment\Edit.cshtml"
                               
                    }
                    else
                    {
                        

#line default
#line hidden
#nullable disable
                WriteLiteral("\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a25d8647925fea7dfc8f1d84203d83f9b9f30fb413873", async() => {
#nullable restore
#line 46 "C:\Users\rmari\Downloads\VacTrack\VacTrack\VacTrack\Views\Appointment\Edit.cshtml"
                                                                           Write(vaccLocation.Location.LocationName);

#line default
#line hidden
#nullable disable
                    WriteLiteral(" ");
#nullable restore
#line 46 "C:\Users\rmari\Downloads\VacTrack\VacTrack\VacTrack\Views\Appointment\Edit.cshtml"
                                                                                                               Write(vaccLocation.Vaccine.Name);

#line default
#line hidden
#nullable disable
                    WriteLiteral(" ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 46 "C:\Users\rmari\Downloads\VacTrack\VacTrack\VacTrack\Views\Appointment\Edit.cshtml"
                               WriteLiteral(vaccLocation.VaccinationLocationID);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n                        ");
#nullable restore
#line 47 "C:\Users\rmari\Downloads\VacTrack\VacTrack\VacTrack\Views\Appointment\Edit.cshtml"
                               
                    }

                }
            

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
        </select>
    </div>
    <div class=""col-sm-6 mb-3"">
        <label for=""DateTime"" class=""form-label"">Date</label>
        <input type=""datetime-local"" class=""form-control"" id=""Date"" name=""DateTime"">
    </div>
    <div class=""col-sm-12"">
        <button type=""submit"" class=""btn btn-primary"">Submit</button>
        <a");
                BeginWriteAttribute("href", " href=\"", 2448, "\"", 2523, 1);
#nullable restore
#line 61 "C:\Users\rmari\Downloads\VacTrack\VacTrack\VacTrack\Views\Appointment\Edit.cshtml"
WriteAttributeValue("", 2455, Url.Action("Delete", "Appointment",new { id = Model.AppointmentID}), 2455, 68, false);

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
#line 6 "C:\Users\rmari\Downloads\VacTrack\VacTrack\VacTrack\Views\Appointment\Edit.cshtml"
AddHtmlAttributeValue("", 141, Url.Action("Edit", "Appointment", new { id = Model.AppointmentID}), 141, 67, false);

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<VacTrack.Models.Appointment.AppointmentModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
