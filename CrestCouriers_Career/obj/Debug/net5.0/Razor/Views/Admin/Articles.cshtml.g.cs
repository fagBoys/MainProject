#pragma checksum "D:\SoftwareEngineering\Site\CrestCouriers\CrestCouriers_Career\Views\Admin\Articles.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0fa84ba4d9db99be88380b6c9e43bdfd2a12a72e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Articles), @"mvc.1.0.view", @"/Views/Admin/Articles.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Admin/Articles.cshtml", typeof(AspNetCore.Views_Admin_Articles))]
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
#line 5 "D:\SoftwareEngineering\Site\CrestCouriers\CrestCouriers_Career\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 6 "D:\SoftwareEngineering\Site\CrestCouriers\CrestCouriers_Career\Views\_ViewImports.cshtml"
using CrestCouriers_Career;

#line default
#line hidden
#line 7 "D:\SoftwareEngineering\Site\CrestCouriers\CrestCouriers_Career\Views\_ViewImports.cshtml"
using CrestCouriers_Career.Models;

#line default
#line hidden
#line 8 "D:\SoftwareEngineering\Site\CrestCouriers\CrestCouriers_Career\Views\_ViewImports.cshtml"
using CrestCouriers_Career.ViewModels.AccountViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0fa84ba4d9db99be88380b6c9e43bdfd2a12a72e", @"/Views/Admin/Articles.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2f0b61efe94e64c8835198418e3a1ed250bb1328", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_Articles : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Dashboard", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("menu-option-link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Order", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AdminSetting", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AdminAccounts", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "User", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "UserAccounts", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Articles", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Logout", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/article/post-image22.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width:100%; opacity:0%;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_12 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "D:\SoftwareEngineering\Site\CrestCouriers\CrestCouriers_Career\Views\Admin\Articles.cshtml"
  

    Layout = "_SystemAdmin";


#line default
#line hidden
            BeginContext(41, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("AdminMenu", async() => {
                BeginContext(62, 36, true);
                WriteLiteral("\r\n    <ul class=\"menu-ul\">\r\n        ");
                EndContext();
                BeginContext(98, 193, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0fa84ba4d9db99be88380b6c9e43bdfd2a12a72e8308", async() => {
                    BeginContext(172, 115, true);
                    WriteLiteral("\r\n            <div class=\"panel-option\">\r\n                <li><h5>Dashboard</h5></li>\r\n            </div>\r\n        ");
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
                BeginContext(291, 10, true);
                WriteLiteral("\r\n        ");
                EndContext();
                BeginContext(301, 185, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0fa84ba4d9db99be88380b6c9e43bdfd2a12a72e10197", async() => {
                    BeginContext(371, 111, true);
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
                BeginContext(486, 10, true);
                WriteLiteral("\r\n        ");
                EndContext();
                BeginContext(496, 200, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0fa84ba4d9db99be88380b6c9e43bdfd2a12a72e12083", async() => {
                    BeginContext(573, 119, true);
                    WriteLiteral("\r\n            <div class=\"panel-option\">\r\n                <li><h5>Admin setting</h5></li>\r\n            </div>\r\n        ");
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
                BeginContext(696, 10, true);
                WriteLiteral("\r\n        ");
                EndContext();
                BeginContext(706, 202, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0fa84ba4d9db99be88380b6c9e43bdfd2a12a72e13977", async() => {
                    BeginContext(784, 120, true);
                    WriteLiteral("\r\n            <div class=\"panel-option\">\r\n                <li><h5>Admin accounts</h5></li>\r\n            </div>\r\n        ");
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
                BeginContext(908, 10, true);
                WriteLiteral("\r\n        ");
                EndContext();
                BeginContext(918, 199, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0fa84ba4d9db99be88380b6c9e43bdfd2a12a72e15872", async() => {
                    BeginContext(994, 119, true);
                    WriteLiteral("\r\n            <div class=\"panel-option\">\r\n                <li><h5>User accounts</h5></li>\r\n            </div>\r\n        ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_6.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_7.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1117, 10, true);
                WriteLiteral("\r\n        ");
                EndContext();
                BeginContext(1127, 198, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0fa84ba4d9db99be88380b6c9e43bdfd2a12a72e17768", async() => {
                    BeginContext(1200, 121, true);
                    WriteLiteral("\r\n            <div class=\"panel-option-active\">\r\n                <li><h5>Articles</h5></li>\r\n            </div>\r\n        ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_8.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1325, 10, true);
                WriteLiteral("\r\n        ");
                EndContext();
                BeginContext(1335, 187, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0fa84ba4d9db99be88380b6c9e43bdfd2a12a72e19667", async() => {
                    BeginContext(1406, 112, true);
                    WriteLiteral("\r\n            <div class=\"panel-option\">\r\n                <li><h5>Logout</h5></li>\r\n            </div>\r\n        ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_9.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1522, 13, true);
                WriteLiteral("\r\n    </ul>\r\n");
                EndContext();
            }
            );
            BeginContext(1538, 326, true);
            WriteLiteral(@"<br />
<br />
<div class=""card mb-3"" style=""margin-left:50px;margin-right:50px;margin-top:10px;"">
    <div class=""row g-0"">

        <div class=""col-lg-3"">
            <div style=""background-image: url(../img/article/post-image22.jpg); background-position:center; background-size:cover; height: 100%;"">
                ");
            EndContext();
            BeginContext(1864, 83, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "0fa84ba4d9db99be88380b6c9e43bdfd2a12a72e22023", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_11);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_12);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1947, 22, true);
            WriteLiteral("\r\n            </div>\r\n");
            EndContext();
            BeginContext(2117, 1634, true);
            WriteLiteral(@"        </div>

        <div class=""col-lg-7"" style="""">
            <div class=""card-body float-left "" style=""text-align:left; position:relative;overflow:auto;height:100%"">
                <h5 class=""card-title"">Article title</h5>
                <p class=""card-text"">Article short description and first line caption.</p>
                <p class=""card-text""><small class=""text-muted"">Last updated 3 mins ago</small></p>
                <div class=""card-footer bg-transparent border-0"" style=""text-align:center;bottom:0;position:absolute;background-color:aqua;"">
                    <a href=""#"" style=""text-decoration:none!important; color:inherit;margin-right:10px;"">Author name</a>
                    <a href=""#"" style=""text-decoration:none!important; color:inherit;margin-right:10px;"">Creation date</a>
                </div>

            </div>
        </div>

        <div class=""col-lg-2"">
            <div style=""position: absolute; text-align: center; bottom: 0px; right: 0px; margin-right:20px;marg");
            WriteLiteral(@"in-bottom:5px;"">
                <a href=""#"" class=""btn btn-primary "" style=""background-color:red;border-color:red;"">Edit</a>
                <a href=""#"" class=""btn btn-primary "" style=""background-color:red;border-color:red;"">Delete</a>
            </div>
        </div>

    </div>
</div>

<div class=""card mb-3"" style=""margin-left:50px;margin-right:50px;margin-top:10px;"">
    <div class=""row g-0"">

        <div class=""col-lg-3"">
            <div style=""background-image: url(../img/article/post-image22.jpg); background-position:center; background-size:cover; height: 100%;"">
                ");
            EndContext();
            BeginContext(3751, 83, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "0fa84ba4d9db99be88380b6c9e43bdfd2a12a72e25210", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_11);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_12);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3834, 22, true);
            WriteLiteral("\r\n            </div>\r\n");
            EndContext();
            BeginContext(4004, 1634, true);
            WriteLiteral(@"        </div>

        <div class=""col-lg-7"" style="""">
            <div class=""card-body float-left "" style=""text-align:left; position:relative;overflow:auto;height:100%"">
                <h5 class=""card-title"">Article title</h5>
                <p class=""card-text"">Article short description and first line caption.</p>
                <p class=""card-text""><small class=""text-muted"">Last updated 3 mins ago</small></p>
                <div class=""card-footer bg-transparent border-0"" style=""text-align:center;bottom:0;position:absolute;background-color:aqua;"">
                    <a href=""#"" style=""text-decoration:none!important; color:inherit;margin-right:10px;"">Author name</a>
                    <a href=""#"" style=""text-decoration:none!important; color:inherit;margin-right:10px;"">Creation date</a>
                </div>

            </div>
        </div>

        <div class=""col-lg-2"">
            <div style=""position: absolute; text-align: center; bottom: 0px; right: 0px; margin-right:20px;marg");
            WriteLiteral(@"in-bottom:5px;"">
                <a href=""#"" class=""btn btn-primary "" style=""background-color:red;border-color:red;"">Edit</a>
                <a href=""#"" class=""btn btn-primary "" style=""background-color:red;border-color:red;"">Delete</a>
            </div>
        </div>

    </div>
</div>

<div class=""card mb-3"" style=""margin-left:50px;margin-right:50px;margin-top:10px;"">
    <div class=""row g-0"">

        <div class=""col-lg-3"">
            <div style=""background-image: url(../img/article/post-image22.jpg); background-position:center; background-size:cover; height: 100%;"">
                ");
            EndContext();
            BeginContext(5638, 83, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "0fa84ba4d9db99be88380b6c9e43bdfd2a12a72e28397", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_11);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_12);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5721, 22, true);
            WriteLiteral("\r\n            </div>\r\n");
            EndContext();
            BeginContext(5891, 1488, true);
            WriteLiteral(@"        </div>

        <div class=""col-lg-7"" style="""">
            <div class=""card-body float-left "" style=""text-align:left; position:relative;overflow:auto;height:100%"">
                <h5 class=""card-title"">Article title</h5>
                <p class=""card-text"">Article short description and first line caption.</p>
                <p class=""card-text"" style=""""><small class=""text-muted"">Last updated 3 mins ago</small></p>
                <div class=""card-footer bg-transparent border-0"" style=""text-align:center;bottom:0;position:absolute;background-color:aqua;"">
                    <a href=""#"" style=""text-decoration:none!important; color:inherit;margin-right:10px;"">Author name</a>
                    <a href=""#"" style=""text-decoration:none!important; color:inherit;margin-right:10px;"">Creation date</a>
                </div>

            </div>
        </div>

        <div class=""col-lg-2"">
            <div style=""position: absolute; text-align: center; bottom: 0px; right: 0px; margin-right:");
            WriteLiteral(@"20px;margin-bottom:5px;"">
                <a href=""#"" class=""btn btn-primary "" style=""background-color:red;border-color:red;"">Edit</a>
                <a href=""#"" class=""btn btn-primary "" style=""background-color:red;border-color:red;"">Delete</a>
            </div>
        </div>

    </div>
</div>
<div class=""col-lg-12"">
    <br />
    <br />
    <br />
    <div style=""position: center; text-align: center; bottom: 0px; left: 0px;margin-top:5px;"">
");
            EndContext();
            BeginContext(7491, 1184, true);
            WriteLiteral(@"
        <nav aria-label=""..."" style=""position:center;text-align:center;color:red;"">
            <ul class=""pagination justify-content-center "" style=""position:center;text-align:center;"" >
                <li class=""page-item disabled"">
                    <a class=""page-link"" href=""#"" tabindex=""-1"" aria-disabled=""true"">Previous</a>
                </li>
                <li class=""page-item""><a class=""page-link"" href=""#"" style=""color: red;"">1</a></li>
                <li class=""page-item active"" aria-current=""page"">
                    <a class=""page-link"" href=""#"" style=""background-color: red;border-color:red;"">2</a>
                </li>
                <li class=""page-item""><a class=""page-link"" href=""#"" style=""color: red;"">3</a></li>
                <li class=""page-item"">
                    <a class=""page-link"" href=""#"" style=""color: red;"">Next</a>
                </li>
            </ul>
        </nav>

    </div>
    <div style=""position: absolute; text-align: center; bottom: 0px; left:");
            WriteLiteral(" 0px; margin-left:50px;\">\r\n        <a href=\"#\" class=\"btn btn-primary \" style=\"background-color:red;border-color:red;\">Create new</a>\r\n    </div>\r\n   \r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
