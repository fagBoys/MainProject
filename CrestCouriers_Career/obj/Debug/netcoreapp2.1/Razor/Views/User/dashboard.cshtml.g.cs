#pragma checksum "C:\Users\Mohammad Javad\Documents\GitHub\CrestCouriers\CrestCouriers_Career\Views\User\dashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "35378e77143e9314f826c4a5b1dd64f4bf560b6f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_dashboard), @"mvc.1.0.view", @"/Views/User/dashboard.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/User/dashboard.cshtml", typeof(AspNetCore.Views_User_dashboard))]
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
#line 6 "C:\Users\Mohammad Javad\Documents\GitHub\CrestCouriers\CrestCouriers_Career\Views\_ViewImports.cshtml"
using CrestCouriers_Career;

#line default
#line hidden
#line 3 "C:\Users\Mohammad Javad\Documents\GitHub\CrestCouriers\CrestCouriers_Career\Views\User\dashboard.cshtml"
using CrestCouriers_Career.Models;

#line default
#line hidden
#line 2 "C:\Users\Mohammad Javad\Documents\GitHub\CrestCouriers\CrestCouriers_Career\Views\User\dashboard.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 8 "C:\Users\Mohammad Javad\Documents\GitHub\CrestCouriers\CrestCouriers_Career\Views\_ViewImports.cshtml"
using CrestCouriers_Career.ViewModels.AccountViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"35378e77143e9314f826c4a5b1dd64f4bf560b6f", @"/Views/User/dashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2f0b61efe94e64c8835198418e3a1ed250bb1328", @"/Views/_ViewImports.cshtml")]
    public class Views_User_dashboard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<CrestCouriers_Career.Models.Order>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "User", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Dashboard", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("menu-option-link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Order", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "UserInformation", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Logout", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/System/remove.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("35px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("35px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("submit"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("background-color: transparent; border: none;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_12 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_13 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/System/edit.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_14 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_15 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("background-color:transparent; border:none;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 6 "C:\Users\Mohammad Javad\Documents\GitHub\CrestCouriers\CrestCouriers_Career\Views\User\dashboard.cshtml"
  
    ViewData["Title"] = "Dashboard";
    Layout = "~/Views/Shared/_System.cshtml";

#line default
#line hidden
            BeginContext(309, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("UserMenu", async() => {
                BeginContext(329, 36, true);
                WriteLiteral("\r\n    <ul class=\"menu-ul\">\r\n        ");
                EndContext();
                BeginContext(365, 199, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "48001f80d5564ca8b17247b2542070e8", async() => {
                    BeginContext(438, 122, true);
                    WriteLiteral("\r\n            <div class=\"panel-option-active\">\r\n                <li><h5>Dashboard</h5></li>\r\n            </div>\r\n        ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(564, 10, true);
                WriteLiteral("\r\n        ");
                EndContext();
                BeginContext(574, 184, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4a39fd22e8b343ea822eabcff39bdd56", async() => {
                    BeginContext(643, 111, true);
                    WriteLiteral("\r\n            <div class=\"panel-option\">\r\n                <li><h5>Order</h5></li>\r\n            </div>\r\n        ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(758, 10, true);
                WriteLiteral("\r\n        ");
                EndContext();
                BeginContext(768, 193, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a96810dff5ed4bd3a785e09c0a579ff7", async() => {
                    BeginContext(847, 110, true);
                    WriteLiteral("\r\n            <div class=\"panel-option\">\r\n                <li><h5>User</h5></li>\r\n            </div>\r\n        ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(961, 10, true);
                WriteLiteral("\r\n        ");
                EndContext();
                BeginContext(971, 186, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3bd606ee55a94d51a6e78c5fe648ac10", async() => {
                    BeginContext(1041, 112, true);
                    WriteLiteral("\r\n            <div class=\"panel-option\">\r\n                <li><h5>Logout</h5></li>\r\n            </div>\r\n        ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1157, 13, true);
                WriteLiteral("\r\n    </ul>\r\n");
                EndContext();
            }
            );
            BeginContext(1173, 1243, true);
            WriteLiteral(@"
<div class=""list-title"">
    <div class=""list-title-item"">
        <h6 class=""list-title-item-text"">
            Order date
        </h6>
    </div>

    <div class=""list-title-item"">
        <h6 class=""list-title-item-text"">
            Origin
        </h6>
    </div>

    <div class=""list-title-item"">
        <h6 class=""list-title-item-text"">
            Destination
        </h6>
    </div>

    <div class=""list-title-item"">
        <h6 class=""list-title-item-text"">
            ReceiveDate
        </h6>
    </div>

    <div class=""list-title-item"">
        <h6 class=""list-title-item-text"">
            DeliveryDate
        </h6>
    </div>

    <div class=""list-title-item"">
        <h6 class=""list-title-item-text"">
            CarType
        </h6>
    </div>

    <div class=""list-title-item"">
        <h6 class=""list-title-item-text"">
            Userid
        </h6>
    </div>

    <div class=""list-title-item"">
        <h6 class=""list-title-item-text"">
        ");
            WriteLiteral("    Price\r\n        </h6>\r\n    </div>\r\n\r\n    <div class=\"list-title-item\">\r\n        <h6 class=\"list-title-item-text\">\r\n            State\r\n        </h6>\r\n    </div>\r\n</div>\r\n\r\n<hr style=\"width:90%; border-color:red;\">\r\n\r\n");
            EndContext();
#line 94 "C:\Users\Mohammad Javad\Documents\GitHub\CrestCouriers\CrestCouriers_Career\Views\User\dashboard.cshtml"
 foreach (var item in Model)
{
    using (Html.BeginForm("Delete", "User", new { id = item.OrderId }))
    {

#line default
#line hidden
            BeginContext(2529, 120, true);
            WriteLiteral("        <div class=\"list-order\">\r\n\r\n            <div class=\"list-title-item\">\r\n                <p>\r\n                    ");
            EndContext();
            BeginContext(2650, 44, false);
#line 102 "C:\Users\Mohammad Javad\Documents\GitHub\CrestCouriers\CrestCouriers_Career\Views\User\dashboard.cshtml"
               Write(Html.DisplayFor(modelItem => item.OrderDate));

#line default
#line hidden
            EndContext();
            BeginContext(2694, 130, true);
            WriteLiteral("\r\n                </p>\r\n            </div>\r\n\r\n            <div class=\"list-title-item\">\r\n                <p>\r\n                    ");
            EndContext();
            BeginContext(2825, 41, false);
#line 108 "C:\Users\Mohammad Javad\Documents\GitHub\CrestCouriers\CrestCouriers_Career\Views\User\dashboard.cshtml"
               Write(Html.DisplayFor(modelItem => item.Origin));

#line default
#line hidden
            EndContext();
            BeginContext(2866, 130, true);
            WriteLiteral("\r\n                </p>\r\n            </div>\r\n\r\n            <div class=\"list-title-item\">\r\n                <p>\r\n                    ");
            EndContext();
            BeginContext(2997, 46, false);
#line 114 "C:\Users\Mohammad Javad\Documents\GitHub\CrestCouriers\CrestCouriers_Career\Views\User\dashboard.cshtml"
               Write(Html.DisplayFor(modelItem => item.Destination));

#line default
#line hidden
            EndContext();
            BeginContext(3043, 130, true);
            WriteLiteral("\r\n                </p>\r\n            </div>\r\n\r\n            <div class=\"list-title-item\">\r\n                <p>\r\n                    ");
            EndContext();
            BeginContext(3174, 49, false);
#line 120 "C:\Users\Mohammad Javad\Documents\GitHub\CrestCouriers\CrestCouriers_Career\Views\User\dashboard.cshtml"
               Write(Html.DisplayFor(modelItem => item.CollectionDate));

#line default
#line hidden
            EndContext();
            BeginContext(3223, 130, true);
            WriteLiteral("\r\n                </p>\r\n            </div>\r\n\r\n            <div class=\"list-title-item\">\r\n                <p>\r\n                    ");
            EndContext();
            BeginContext(3354, 47, false);
#line 126 "C:\Users\Mohammad Javad\Documents\GitHub\CrestCouriers\CrestCouriers_Career\Views\User\dashboard.cshtml"
               Write(Html.DisplayFor(modelItem => item.DeliveryDate));

#line default
#line hidden
            EndContext();
            BeginContext(3401, 130, true);
            WriteLiteral("\r\n                </p>\r\n            </div>\r\n\r\n            <div class=\"list-title-item\">\r\n                <p>\r\n                    ");
            EndContext();
            BeginContext(3532, 42, false);
#line 132 "C:\Users\Mohammad Javad\Documents\GitHub\CrestCouriers\CrestCouriers_Career\Views\User\dashboard.cshtml"
               Write(Html.DisplayFor(modelItem => item.CarType));

#line default
#line hidden
            EndContext();
            BeginContext(3574, 110, true);
            WriteLiteral("\r\n                </p>\r\n            </div>\r\n\r\n            <div class=\"list-title-item\">\r\n                <p>\r\n");
            EndContext();
#line 138 "C:\Users\Mohammad Javad\Documents\GitHub\CrestCouriers\CrestCouriers_Career\Views\User\dashboard.cshtml"
                     if (SignInManager.IsSignedIn(User))
                    {
                        

#line default
#line hidden
            BeginContext(3790, 29, false);
#line 140 "C:\Users\Mohammad Javad\Documents\GitHub\CrestCouriers\CrestCouriers_Career\Views\User\dashboard.cshtml"
                   Write(UserManager.GetUserName(User));

#line default
#line hidden
            EndContext();
#line 140 "C:\Users\Mohammad Javad\Documents\GitHub\CrestCouriers\CrestCouriers_Career\Views\User\dashboard.cshtml"
                                                      
                    }

#line default
#line hidden
            BeginContext(3844, 128, true);
            WriteLiteral("                </p>\r\n            </div>\r\n\r\n            <div class=\"list-title-item\">\r\n                <p>\r\n                    ");
            EndContext();
            BeginContext(3973, 40, false);
#line 147 "C:\Users\Mohammad Javad\Documents\GitHub\CrestCouriers\CrestCouriers_Career\Views\User\dashboard.cshtml"
               Write(Html.DisplayFor(modelItem => item.Price));

#line default
#line hidden
            EndContext();
            BeginContext(4013, 130, true);
            WriteLiteral("\r\n                </p>\r\n            </div>\r\n\r\n            <div class=\"list-title-item\">\r\n                <p>\r\n                    ");
            EndContext();
            BeginContext(4144, 40, false);
#line 153 "C:\Users\Mohammad Javad\Documents\GitHub\CrestCouriers\CrestCouriers_Career\Views\User\dashboard.cshtml"
               Write(Html.DisplayFor(modelItem => item.State));

#line default
#line hidden
            EndContext();
            BeginContext(4184, 48, true);
            WriteLiteral("\r\n                </p>\r\n            </div>\r\n\r\n\r\n");
            EndContext();
            BeginContext(4302, 62, true);
            WriteLiteral("            <div class=\"list-record-button\">\r\n                ");
            EndContext();
            BeginContext(4364, 224, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fd9b992793dd4463b64c93dddcca60ea", async() => {
                BeginContext(4510, 69, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "b5ea5570d64f426284da0a59e3df4044", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_11);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Action = (string)__tagHelperAttribute_12.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_12);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 160 "C:\Users\Mohammad Javad\Documents\GitHub\CrestCouriers\CrestCouriers_Career\Views\User\dashboard.cshtml"
                                                                                                                                       WriteLiteral(item.OrderId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4588, 113, true);
            WriteLiteral("\r\n            </div>\r\n\r\n            <div class=\"list-record-button\" data-toggle=\"modal\" data-target=\".confirmbox\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 4701, "\"", 4832, 13);
            WriteAttributeValue("", 4711, "getValues(\'", 4711, 11, true);
#line 163 "C:\Users\Mohammad Javad\Documents\GitHub\CrestCouriers\CrestCouriers_Career\Views\User\dashboard.cshtml"
WriteAttributeValue("", 4722, item.OrderId, 4722, 13, false);

#line default
#line hidden
            WriteAttributeValue("", 4735, "\',\'", 4735, 3, true);
#line 163 "C:\Users\Mohammad Javad\Documents\GitHub\CrestCouriers\CrestCouriers_Career\Views\User\dashboard.cshtml"
WriteAttributeValue("", 4738, item.Origin, 4738, 12, false);

#line default
#line hidden
            WriteAttributeValue("", 4750, "\',\'", 4750, 3, true);
#line 163 "C:\Users\Mohammad Javad\Documents\GitHub\CrestCouriers\CrestCouriers_Career\Views\User\dashboard.cshtml"
WriteAttributeValue("", 4753, item.Destination, 4753, 17, false);

#line default
#line hidden
            WriteAttributeValue("", 4770, "\',\'", 4770, 3, true);
#line 163 "C:\Users\Mohammad Javad\Documents\GitHub\CrestCouriers\CrestCouriers_Career\Views\User\dashboard.cshtml"
WriteAttributeValue("", 4773, item.CollectionDate, 4773, 20, false);

#line default
#line hidden
            WriteAttributeValue("", 4793, "\',\'", 4793, 3, true);
#line 163 "C:\Users\Mohammad Javad\Documents\GitHub\CrestCouriers\CrestCouriers_Career\Views\User\dashboard.cshtml"
WriteAttributeValue("", 4796, item.DeliveryDate, 4796, 18, false);

#line default
#line hidden
            WriteAttributeValue("", 4814, "\',\'", 4814, 3, true);
#line 163 "C:\Users\Mohammad Javad\Documents\GitHub\CrestCouriers\CrestCouriers_Career\Views\User\dashboard.cshtml"
WriteAttributeValue("", 4817, item.CarType, 4817, 13, false);

#line default
#line hidden
            WriteAttributeValue("", 4830, "\')", 4830, 2, true);
            EndWriteAttribute();
            BeginContext(4833, 19, true);
            WriteLiteral(">\r\n                ");
            EndContext();
            BeginContext(4852, 244, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "79b621bb4ba24a159612e822ab142435", async() => {
                BeginContext(4980, 22, true);
                WriteLiteral("\r\n                    ");
                EndContext();
                BeginContext(5002, 67, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "d07fc652619941fb9e43e2947c89d1c9", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_13);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(5069, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Action = (string)__tagHelperAttribute_14.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_14);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 164 "C:\Users\Mohammad Javad\Documents\GitHub\CrestCouriers\CrestCouriers_Career\Views\User\dashboard.cshtml"
                                                                  WriteLiteral(item.OrderId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_15);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5096, 40, true);
            WriteLiteral("\r\n            </div>\r\n\r\n        </div>\r\n");
            EndContext();
            BeginContext(5140, 2056, true);
            WriteLiteral(@"        <div id=""confirmbox-delete"" class=""modal fade confirmbox-delete"">
            <div class=""modal-dialog"">
                <div class=""modal-content"" style=""        width: 600px;
        padding: 0px;
"">

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

                            ");
            WriteLiteral(@"    <div class=""row"">

                                    <div class=""col-sm-6"">
                                        <div class=""input-submit"">
                                            <button type=""submit"" class=""book-now-btn"" style=""color:white; padding-top:14px; float:right;"" name=""button""><h5>Delete</h5></button>
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
        ");
            WriteLiteral("</div>\r\n");
            EndContext();
#line 306 "C:\Users\Mohammad Javad\Documents\GitHub\CrestCouriers\CrestCouriers_Career\Views\User\dashboard.cshtml"
                    


    }
}

#line default
#line hidden
            BeginContext(11593, 444, true);
            WriteLiteral(@"
<script>
    function getValues(Orderid,Origin, Destination, ReceiveDate, DeliveryDate, CarType) {

        document.getElementById(""Origin"").value = Origin;
        document.getElementById(""Destination"").value = Destination;
        document.getElementById(""ReceiveDate"").value = ReceiveDate;
        document.getElementById(""DeliveryDate"").value = DeliveryDate;
        document.getElementById(""CarType"").value = CarType;

        ");
            EndContext();
            BeginContext(12038, 19, false);
#line 321 "C:\Users\Mohammad Javad\Documents\GitHub\CrestCouriers\CrestCouriers_Career\Views\User\dashboard.cshtml"
   Write(ViewData["Orderid"]);

#line default
#line hidden
            EndContext();
            BeginContext(12057, 33, true);
            WriteLiteral(" = Orderid;\r\n    }\r\n</script>\r\n\r\n");
            EndContext();
            BeginContext(12328, 2, true);
            WriteLiteral("\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<Account> UserManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<Account> SignInManager { get; private set; }
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
