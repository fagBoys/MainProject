#pragma checksum "C:\Users\suzan\Documents\GitHub\MainProject\CrestCouriers_Career\Views\Admin\AdminSetting.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f871d4c008d9de0a24b978c53c69d9fa501485f1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_AdminSetting), @"mvc.1.0.view", @"/Views/Admin/AdminSetting.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Admin/AdminSetting.cshtml", typeof(AspNetCore.Views_Admin_AdminSetting))]
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
#line 1 "C:\Users\suzan\Documents\GitHub\MainProject\CrestCouriers_Career\Views\_ViewImports.cshtml"
using CrestCouriers_Career;

#line default
#line hidden
#line 2 "C:\Users\suzan\Documents\GitHub\MainProject\CrestCouriers_Career\Views\_ViewImports.cshtml"
using CrestCouriers_Career.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f871d4c008d9de0a24b978c53c69d9fa501485f1", @"/Views/Admin/AdminSetting.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9f0e0bc3062d43907324b8a6cb008b8ff3cd964a", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_AdminSetting : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CrestCouriers_Career.Models.Admin>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(42, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\suzan\Documents\GitHub\MainProject\CrestCouriers_Career\Views\Admin\AdminSetting.cshtml"
  
    ViewData["Title"] = "AdminSetting";
    Layout = "~/Views/Shared/_SystemAdmin.cshtml";

#line default
#line hidden
            BeginContext(144, 200, true);
            WriteLiteral("\r\n\r\n    <div class=\"NewOrder-form\" style=\"margin:100px;\">\r\n\r\n        <div class=\"row\">\r\n\r\n            <div class=\"col-sm-6\">\r\n                <input type=\"text\" class=\"\" name=\"\" placeholder=\"Username\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 344, "\"", 381, 1);
#line 14 "C:\Users\suzan\Documents\GitHub\MainProject\CrestCouriers_Career\Views\Admin\AdminSetting.cshtml"
WriteAttributeValue("", 352, ViewData["myAdmin-UserName"], 352, 29, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(382, 253, true);
            WriteLiteral(">\r\n                <span class=\"text-danger field-validation-valid\" data-valmsg-for=\"Subject\" data-valmsg-replace=\"true\"></span>\r\n            </div>\r\n\r\n            <div class=\"col-sm-6\">\r\n                <input type=\"text\" name=\"\" placeholder=\"Password\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 635, "\"", 672, 1);
#line 19 "C:\Users\suzan\Documents\GitHub\MainProject\CrestCouriers_Career\Views\Admin\AdminSetting.cshtml"
WriteAttributeValue("", 643, ViewData["myAdmin-Password"], 643, 29, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(673, 221, true);
            WriteLiteral(">\r\n            </div>\r\n\r\n        </div>\r\n\r\n        <div class=\"row\">\r\n\r\n            <div class=\"col-sm-6\">\r\n                <div class=\"order-input\">\r\n                    <input type=\"text\" name=\"\" placeholder=\"Fristname\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 894, "\"", 932, 1);
#line 28 "C:\Users\suzan\Documents\GitHub\MainProject\CrestCouriers_Career\Views\Admin\AdminSetting.cshtml"
WriteAttributeValue("", 902, ViewData["myAdmin-FirstName"], 902, 30, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(933, 197, true);
            WriteLiteral(">\r\n                </div>\r\n            </div>\r\n\r\n            <div class=\"col-sm-6\">\r\n                <div class=\"order-input\">\r\n                    <input type=\"text\" name=\"\" placeholder=\"Lastname\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1130, "\"", 1167, 1);
#line 34 "C:\Users\suzan\Documents\GitHub\MainProject\CrestCouriers_Career\Views\Admin\AdminSetting.cshtml"
WriteAttributeValue("", 1138, ViewData["myAdmin-Lastname"], 1138, 29, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1168, 249, true);
            WriteLiteral(">\r\n                </div>\r\n            </div>\r\n\r\n        </div>\r\n\r\n\r\n        <div class=\"row\">\r\n\r\n            <div class=\"col-sm-6\">\r\n                <div class=\"order-input\">\r\n                    <input type=\"text\" name=\"\" placeholder=\"PhoneNumber\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1417, "\"", 1457, 1);
#line 45 "C:\Users\suzan\Documents\GitHub\MainProject\CrestCouriers_Career\Views\Admin\AdminSetting.cshtml"
WriteAttributeValue("", 1425, ViewData["myAdmin-PhoneNumber"], 1425, 32, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1458, 201, true);
            WriteLiteral(">\r\n                </div>\r\n            </div>\r\n\r\n            <div class=\"col-sm-6\">\r\n                <div class=\"order-input\">\r\n                    <input type=\"text\" name=\"\" placeholder=\"EmailAddress\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1659, "\"", 1700, 1);
#line 51 "C:\Users\suzan\Documents\GitHub\MainProject\CrestCouriers_Career\Views\Admin\AdminSetting.cshtml"
WriteAttributeValue("", 1667, ViewData["myAdmin-EmailAddress"], 1667, 33, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1701, 2139, true);
            WriteLiteral(@">
                </div>
            </div>

        </div>


        <div class=""row"">

            <div class=""col-sm-12"">
                <div class=""input-submit"">
                    <button type=""button"" class=""book-now-btn"" style=""color:white; padding-top:14px;"" name=""button"" data-toggle=""modal"" data-target="".confirmbox-admin-info""><h5>Update your information</h5></button>
                </div>
            </div>

        </div>

        <div id=""confirmbox-admin-info"" class=""modal fade confirmbox-admin-info"">
            <div class=""modal-dialog"">
                <div class=""modal-content"" style=""width:600px; padding:0px;"">

                    <div class=""modal-header"" style=""border-bottom-color:red;"">
                        <h2 class=""update-box-header"">Update information</h2>
                    </div>

                    <div class=""modal-body"">




                        <div class=""popup-admin-deactive"">

                            <div class=""NewOrder-form"">");
            WriteLiteral(@"

                                <div class=""row"">

                                    <div class=""col-sm-12"">
                                        <div class=""order-input"">
                                            <p>Your information has been updated.</p>
                                        </div>
                                    </div>

                                </div>

                                <div class=""row"">

                                    <div class=""col-sm-12"">
                                        <div class=""input-submit"">
                                            <button type=""button"" class=""book-now-btn"" style=""color:white; padding-top:14px; margin:0 auto; margin-top:20px;"" name=""button""><h5>Close</h5></button>
                                        </div>
                                    </div>


                                </div>

                            </div>

                        </div>

                    </div>");
            WriteLiteral("\n\r\n\r\n                </div>\r\n            </div>\r\n        </div>\r\n\r\n\r\n    </div>\r\n\r\n\r\n\r\n\r\n\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CrestCouriers_Career.Models.Admin> Html { get; private set; }
    }
}
#pragma warning restore 1591
