#pragma checksum "C:\Users\mjn110\Documents\GitHub\MainProject\CrestCouriers_Career\Views\Admin\UserAccounts.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5b32e31f2863ebcfc06433318f5a06133d573acf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_UserAccounts), @"mvc.1.0.view", @"/Views/Admin/UserAccounts.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Admin/UserAccounts.cshtml", typeof(AspNetCore.Views_Admin_UserAccounts))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5b32e31f2863ebcfc06433318f5a06133d573acf", @"/Views/Admin/UserAccounts.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9f0e0bc3062d43907324b8a6cb008b8ff3cd964a", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_UserAccounts : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<CrestCouriers_Career.Models.User>>
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
            BeginContext(54, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\mjn110\Documents\GitHub\MainProject\CrestCouriers_Career\Views\Admin\UserAccounts.cshtml"
  
    ViewData["Title"] = "UserAccounts";
    Layout = "~/Views/Shared/_SystemAdmin.cshtml";

#line default
#line hidden
            BeginContext(156, 1885, true);
            WriteLiteral(@"

<div class=""list-title"">
    <div class=""user-list-title-item"">
        <h5 class=""list-title-item-text"">
            Username
        </h5>
    </div>

    <div class=""user-list-title-item"">
        <h5 class=""list-title-item-text"">
            Password
        </h5>
    </div>

    <div class=""user-list-title-item"">
        <h5 class=""list-title-item-text"">
            First name
        </h5>
    </div>

    <div class=""user-list-title-item"">
        <h5 class=""list-title-item-text"">
            Last name
        </h5>
    </div>

    <div class=""user-list-title-item"">
        <h5 class=""list-title-item-text"">
            Phone number
        </h5>
    </div>

    <div class=""user-list-title-item"">
        <h5 class=""list-title-item-text"">
            Email address
        </h5>
    </div>

    <div class=""user-list-title-item"">
        <h5 class=""list-title-item-text"">
            Active
        </h5>
    </div>
</div>

<hr style=""width:90%; border-color:red");
            WriteLiteral(@";"">

<div class=""list-order"">

    <div class=""user-list-title-item"">
        <p>
            mjn110
        </p>
    </div>

    <div class=""user-list-title-item"">
        <p>
            mjn110
        </p>
    </div>

    <div class=""user-list-title-item"">
        <p>
            Mohammad Javad
        </p>
    </div>

    <div class=""user-list-title-item"">
        <p>
            Najafi
        </p>
    </div>

    <div class=""user-list-title-item"">
        <p>
            09386955901
        </p>
    </div>

    <div class=""user-list-title-item"">
        <p>
            mjn220@gmail.com
        </p>
    </div>

    <div class=""user-list-title-item"">
        <p>
            Yes
        </p>
    </div>

    <div class=""list-record-button"" data-toggle=""modal"" data-target="".confirmbox-delete"">
        ");
            EndContext();
            BeginContext(2041, 69, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "ac2d571ce4134009a5dde51a482ee556", async() => {
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
            BeginContext(2110, 108, true);
            WriteLiteral("\r\n    </div>\r\n\r\n    <div class=\"list-record-button\" data-toggle=\"modal\" data-target=\".confirmbox\">\r\n        ");
            EndContext();
            BeginContext(2218, 67, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "32c9249783c54715b0d40e090cf93398", async() => {
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
            BeginContext(2285, 5887, true);
            WriteLiteral(@"
    </div>

</div>


<div id=""confirmbox-delete"" class=""modal fade confirmbox-delete"">
    <div class=""modal-dialog"">
        <div class=""modal-content"" style=""width:600px; padding:0px;"">

            <div class=""modal-header"" style=""border-bottom-color:red;"">
                <h2 class=""update-box-header"">Delete user</h2>
            </div>

            <div class=""modal-body"">




                <div class=""popup-admin-deactive"">

                    <div class=""NewOrder-form"">

                        <div class=""row"">

                            <div class=""col-sm-12"">
                                <div class=""order-input"">
                                    <p>Are you sure? You realy want to delete this user account?</p>
                                </div>
                            </div>

                        </div>

                        <div class=""row"">

                            <div class=""col-sm-6"">
                                <div class=""in");
            WriteLiteral(@"put-submit"">
                                    <button type=""button"" class=""book-now-btn"" style=""color:white; padding-top:14px; float:right;"" name=""button""><h5>Delete</h5></button>
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
                <h");
            WriteLiteral(@"2 class=""update-box-header"">Change user account</h2>
            </div>

            <div class=""modal-body"">




                <div class=""popup-user-update"">

                    <div class=""NewOrder-form"">

                        <div class=""row"">
                            <div class=""col-lg-12"">
                                <div class=""order-input"">
                                    <input type=""text"" class="""" name="""" placeholder=""User name"">
                                    <span class=""text-danger field-validation-valid"" data-valmsg-for=""Subject"" data-valmsg-replace=""true""></span>
                                </div>
                            </div>
                        </div>

                        <div class=""row"">
                            <div class=""col-lg-12"">
                                <div class=""order-input"">
                                    <input type=""text"" class="""" name="""" placeholder=""First name"">
                                    ");
            WriteLiteral(@"<span class=""text-danger field-validation-valid"" data-valmsg-for=""Subject"" data-valmsg-replace=""true""></span>
                                </div>
                            </div>
                        </div>

                        <div class=""row"">
                            <div class=""col-lg-12"">
                                <div class=""order-input"">
                                    <input type=""text"" class="""" name="""" placeholder=""Last name"">
                                    <span class=""text-danger field-validation-valid"" data-valmsg-for=""Subject"" data-valmsg-replace=""true""></span>
                                </div>
                            </div>
                        </div>

                        <div class=""row"">
                            <div class=""col-lg-12"">
                                <div class=""order-input"">
                                    <input type=""text"" class="""" name="""" placeholder=""Phone number"">
                                    <");
            WriteLiteral(@"span class=""text-danger field-validation-valid"" data-valmsg-for=""Subject"" data-valmsg-replace=""true""></span>
                                </div>
                            </div>
                        </div>

                        <div class=""row"">
                            <div class=""col-lg-12"">
                                <div class=""order-input"">
                                    <input type=""text"" class="""" name="""" placeholder=""Email address"">
                                    <span class=""text-danger field-validation-valid"" data-valmsg-for=""Subject"" data-valmsg-replace=""true""></span>
                                </div>
                            </div>
                        </div>

                        <div class=""row"">
                            <div class=""col-lg-12"">
                                <div class=""order-input"">
                                    <input type=""text"" class="""" name="""" placeholder=""Active"">
                                    <spa");
            WriteLiteral(@"n class=""text-danger field-validation-valid"" data-valmsg-for=""Subject"" data-valmsg-replace=""true""></span>
                                </div>
                            </div>
                        </div>

                        <div class=""row"">

                            <div class=""col-sm-12"">
                                <div class=""input-submit"">
                                    <button type=""button"" class=""book-now-btn"" style=""color:white; padding-top:14px;"" name=""button""><h5>Update</h5></button>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<CrestCouriers_Career.Models.User>> Html { get; private set; }
    }
}
#pragma warning restore 1591
