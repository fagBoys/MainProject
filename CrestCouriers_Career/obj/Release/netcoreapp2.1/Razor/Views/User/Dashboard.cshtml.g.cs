#pragma checksum "C:\Users\mjn110\Documents\GitHub\MainProject\CrestCouriers_Career\Views\User\Dashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ef56a1f9809031a12e9dd206ed951f71e6090345"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_Dashboard), @"mvc.1.0.view", @"/Views/User/Dashboard.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/User/Dashboard.cshtml", typeof(AspNetCore.Views_User_Dashboard))]
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
#line 1 "C:\Users\mjn110\Documents\GitHub\MainProject\CrestCouriers_Career\Views\_ViewImports.cshtml"
using CrestCouriers_Career;

#line default
#line hidden
#line 2 "C:\Users\mjn110\Documents\GitHub\MainProject\CrestCouriers_Career\Views\_ViewImports.cshtml"
using CrestCouriers_Career.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ef56a1f9809031a12e9dd206ed951f71e6090345", @"/Views/User/Dashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9f0e0bc3062d43907324b8a6cb008b8ff3cd964a", @"/Views/_ViewImports.cshtml")]
    public class Views_User_Dashboard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<CrestCouriers_Career.Models.Order>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/System/remove.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("35px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("35px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/System/edit.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(55, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\mjn110\Documents\GitHub\MainProject\CrestCouriers_Career\Views\User\Dashboard.cshtml"
  
    ViewData["Title"] = "Dashboard";
    Layout = "~/Views/Shared/_System.cshtml";

#line default
#line hidden
            BeginContext(149, 1243, true);
            WriteLiteral(@"
<div class=""list-title"">
    <div class=""list-title-item"">
        <h5 class=""list-title-item-text"">
            Order date
        </h5>
    </div>

    <div class=""list-title-item"">
        <h5 class=""list-title-item-text"">
            Origin
        </h5>
    </div>

    <div class=""list-title-item"">
        <h5 class=""list-title-item-text"">
            Destination
        </h5>
    </div>

    <div class=""list-title-item"">
        <h5 class=""list-title-item-text"">
            ReceiveDate
        </h5>
    </div>

    <div class=""list-title-item"">
        <h5 class=""list-title-item-text"">
            DeliveryDate
        </h5>
    </div>

    <div class=""list-title-item"">
        <h5 class=""list-title-item-text"">
            CarType
        </h5>
    </div>

    <div class=""list-title-item"">
        <h5 class=""list-title-item-text"">
            Userid
        </h5>
    </div>

    <div class=""list-title-item"">
        <h5 class=""list-title-item-text"">
        ");
            WriteLiteral("    Price\r\n        </h5>\r\n    </div>\r\n\r\n    <div class=\"list-title-item\">\r\n        <h5 class=\"list-title-item-text\">\r\n            State\r\n        </h5>\r\n    </div>\r\n</div>\r\n\r\n<hr style=\"width:90%; border-color:red;\">\r\n\r\n");
            EndContext();
#line 66 "C:\Users\mjn110\Documents\GitHub\MainProject\CrestCouriers_Career\Views\User\Dashboard.cshtml"
 foreach (var item in Model)
{

#line default
#line hidden
            BeginContext(1425, 104, true);
            WriteLiteral("    <div class=\"list-order\">\r\n\r\n        <div class=\"list-title-item\">\r\n            <p>\r\n                ");
            EndContext();
            BeginContext(1530, 44, false);
#line 72 "C:\Users\mjn110\Documents\GitHub\MainProject\CrestCouriers_Career\Views\User\Dashboard.cshtml"
           Write(Html.DisplayFor(modelItem => item.OrderDate));

#line default
#line hidden
            EndContext();
            BeginContext(1574, 110, true);
            WriteLiteral("\r\n            </p>\r\n        </div>\r\n\r\n        <div class=\"list-title-item\">\r\n            <p>\r\n                ");
            EndContext();
            BeginContext(1685, 41, false);
#line 78 "C:\Users\mjn110\Documents\GitHub\MainProject\CrestCouriers_Career\Views\User\Dashboard.cshtml"
           Write(Html.DisplayFor(modelItem => item.Origin));

#line default
#line hidden
            EndContext();
            BeginContext(1726, 110, true);
            WriteLiteral("\r\n            </p>\r\n        </div>\r\n\r\n        <div class=\"list-title-item\">\r\n            <p>\r\n                ");
            EndContext();
            BeginContext(1837, 46, false);
#line 84 "C:\Users\mjn110\Documents\GitHub\MainProject\CrestCouriers_Career\Views\User\Dashboard.cshtml"
           Write(Html.DisplayFor(modelItem => item.Destination));

#line default
#line hidden
            EndContext();
            BeginContext(1883, 110, true);
            WriteLiteral("\r\n            </p>\r\n        </div>\r\n\r\n        <div class=\"list-title-item\">\r\n            <p>\r\n                ");
            EndContext();
            BeginContext(1994, 46, false);
#line 90 "C:\Users\mjn110\Documents\GitHub\MainProject\CrestCouriers_Career\Views\User\Dashboard.cshtml"
           Write(Html.DisplayFor(modelItem => item.ReceiveDate));

#line default
#line hidden
            EndContext();
            BeginContext(2040, 110, true);
            WriteLiteral("\r\n            </p>\r\n        </div>\r\n\r\n        <div class=\"list-title-item\">\r\n            <p>\r\n                ");
            EndContext();
            BeginContext(2151, 47, false);
#line 96 "C:\Users\mjn110\Documents\GitHub\MainProject\CrestCouriers_Career\Views\User\Dashboard.cshtml"
           Write(Html.DisplayFor(modelItem => item.DeliveryDate));

#line default
#line hidden
            EndContext();
            BeginContext(2198, 110, true);
            WriteLiteral("\r\n            </p>\r\n        </div>\r\n\r\n        <div class=\"list-title-item\">\r\n            <p>\r\n                ");
            EndContext();
            BeginContext(2309, 42, false);
#line 102 "C:\Users\mjn110\Documents\GitHub\MainProject\CrestCouriers_Career\Views\User\Dashboard.cshtml"
           Write(Html.DisplayFor(modelItem => item.CarType));

#line default
#line hidden
            EndContext();
            BeginContext(2351, 110, true);
            WriteLiteral("\r\n            </p>\r\n        </div>\r\n\r\n        <div class=\"list-title-item\">\r\n            <p>\r\n                ");
            EndContext();
            BeginContext(2462, 41, false);
#line 108 "C:\Users\mjn110\Documents\GitHub\MainProject\CrestCouriers_Career\Views\User\Dashboard.cshtml"
           Write(Html.DisplayFor(modelItem => item.UserId));

#line default
#line hidden
            EndContext();
            BeginContext(2503, 110, true);
            WriteLiteral("\r\n            </p>\r\n        </div>\r\n\r\n        <div class=\"list-title-item\">\r\n            <p>\r\n                ");
            EndContext();
            BeginContext(2614, 40, false);
#line 114 "C:\Users\mjn110\Documents\GitHub\MainProject\CrestCouriers_Career\Views\User\Dashboard.cshtml"
           Write(Html.DisplayFor(modelItem => item.Price));

#line default
#line hidden
            EndContext();
            BeginContext(2654, 110, true);
            WriteLiteral("\r\n            </p>\r\n        </div>\r\n\r\n        <div class=\"list-title-item\">\r\n            <p>\r\n                ");
            EndContext();
            BeginContext(2765, 40, false);
#line 120 "C:\Users\mjn110\Documents\GitHub\MainProject\CrestCouriers_Career\Views\User\Dashboard.cshtml"
           Write(Html.DisplayFor(modelItem => item.State));

#line default
#line hidden
            EndContext();
            BeginContext(2805, 145, true);
            WriteLiteral("\r\n            </p>\r\n        </div>\r\n\r\n        <div class=\"list-record-button\" data-toggle=\"modal\" data-target=\".confirmbox-delete\">\r\n            ");
            EndContext();
            BeginContext(2950, 69, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "f2ce2b580ab84ebc9c76b5fb03310873", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3019, 120, true);
            WriteLiteral("\r\n        </div>\r\n\r\n        <div class=\"list-record-button\" data-toggle=\"modal\" data-target=\".confirmbox\">\r\n            ");
            EndContext();
            BeginContext(3139, 67, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "8b8006b5e5544fc2bbe93bf50324c745", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3206, 32, true);
            WriteLiteral("\r\n        </div>\r\n\r\n    </div>\r\n");
            EndContext();
#line 133 "C:\Users\mjn110\Documents\GitHub\MainProject\CrestCouriers_Career\Views\User\Dashboard.cshtml"
}

#line default
#line hidden
            BeginContext(3241, 5385, true);
            WriteLiteral(@"



<div id=""confirmbox-delete"" class=""modal fade confirmbox-delete"">
    <div class=""modal-dialog"">
        <div class=""modal-content"" style=""width:600px; padding:0px;"">

            <div class=""modal-header"" style=""border-bottom-color:red;"">
                <h2 class=""update-box-header"">Delete order</h2>
            </div>

            <div class=""modal-body"">




                <div class=""popup-admin-deactive"">

                    <div class=""NewOrder-form"">

                        <div class=""row"">

                            <div class=""col-sm-12"">
                                <div class=""order-input"">
                                    <p>Are you sure? You realy want to delete this order?</p>
                                </div>
                            </div>

                        </div>

                        <div class=""row"">

                            <div class=""col-sm-6"">
                                <div class=""input-submit"">
            ");
            WriteLiteral(@"                        <button type=""button"" class=""book-now-btn"" style=""color:white; padding-top:14px; float:right;"" name=""button""><h5>Delete</h5></button>
                                </div>
                            </div>

                            <div class=""col-sm-6"">
                                <div class=""input-submit"">
                                    <button type=""button"" class=""book-now-btn"" style=""color:white; padding-top:14px; float:left;"" name=""button""><h5>Cancel</h5></button>
                                </div>
                            </div>

                        </div>

                    </div>

                </div>

            </div>


        </div>
    </div>
</div>

<div id=""confirmbox"" class=""modal fade confirmbox"">
    <div class=""modal-dialog"">
        <div class=""modal-content"" style=""width:600px; padding:0px;"">

            <div class=""modal-header"" style=""border-bottom-color:red;"">
                <h2 class=""update-box-header");
            WriteLiteral(@""">Change order</h2>
            </div>

            <div class=""modal-body"">

                <div class=""popup-order-update"">

                    <div class=""NewOrder-form"">

                        <div class=""row"">
                            <div class=""col-lg-12"">
                                <div class=""order-input"">
                                    <input type=""text"" class="""" name="""" placeholder=""Origin"">
                                    <span class=""text-danger field-validation-valid"" data-valmsg-for=""Subject"" data-valmsg-replace=""true""></span>
                                </div>
                            </div>
                        </div>

                        <div class=""row"">
                            <div class=""col-lg-12"">
                                <div class=""order-input"">
                                    <input type=""text"" class=""form-control2"" name="""" placeholder=""Destination"">
                                    <span class=""text-danger fi");
            WriteLiteral(@"eld-validation-valid"" data-valmsg-for=""Subject"" data-valmsg-replace=""true""></span>
                                </div>
                            </div>
                        </div>

                        <div class=""row"">
                            <div class=""col-lg-12"">
                                <div class=""order-input"">
                                    <input type=""text"" class=""form-control2"" name="""" placeholder=""Receive date"">
                                    <span class=""text-danger field-validation-valid"" data-valmsg-for=""Subject"" data-valmsg-replace=""true""></span>
                                </div>
                            </div>
                        </div>

                        <div class=""row"">
                            <div class=""col-lg-12"">
                                <div class=""order-input"">
                                    <input type=""text"" class=""form-control2"" name="""" placeholder=""Delivery date"">
                                  ");
            WriteLiteral(@"  <span class=""text-danger field-validation-valid"" data-valmsg-for=""Subject"" data-valmsg-replace=""true""></span>
                                </div>
                            </div>
                        </div>

                        <div class=""row"">
                            <div class=""col-lg-12"">
                                <div class=""order-input"">
                                    <input type=""text"" class=""form-control2"" name="""" placeholder=""Car type"">
                                    <span class=""text-danger field-validation-valid"" data-valmsg-for=""Subject"" data-valmsg-replace=""true""></span>
                                </div>
                            </div>
                        </div>

                        <div class=""row"">

                            <div class=""col-sm-12"">
                                <div class=""input-submit"">
                                    <button type=""button"" class=""book-now-btn"" style=""color:white; padding-top:14px;"" nam");
            WriteLiteral(@"e=""button""><h5>Update</h5></button>
                                </div>
                            </div>

                        </div>

                    </div>

                </div>

            </div>


        </div>
    </div>
</div>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<CrestCouriers_Career.Models.Order>> Html { get; private set; }
    }
}
#pragma warning restore 1591