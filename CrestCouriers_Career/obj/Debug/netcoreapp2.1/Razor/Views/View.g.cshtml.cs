#pragma checksum "C:\Users\suzan\Documents\GitHub\MainProject\CrestCouriers_Career\Views\View.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "31abdffcd13affc4f9440e1d99a1908da35b1eae"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_View), @"mvc.1.0.view", @"/Views/View.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/View.cshtml", typeof(AspNetCore.Views_View))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"31abdffcd13affc4f9440e1d99a1908da35b1eae", @"/Views/View.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9f0e0bc3062d43907324b8a6cb008b8ff3cd964a", @"/Views/_ViewImports.cshtml")]
    public class Views_View : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("padding:50px; background-color:#e8e8e8;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 25, true);
            WriteLiteral("<!DOCTYPE html>\r\n<html>\r\n");
            EndContext();
            BeginContext(25, 1965, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2d97b27e8f5d4940b33a47ef0073f4ac", async() => {
                BeginContext(31, 1952, true);
                WriteLiteral(@"
    <meta name=""viewport"" content=""width=device-width"" />
    <meta charset=""utf-8"" />

    <link href=""https://fonts.googleapis.com/css?family=Raleway&display=swap"" rel=""stylesheet"">
    <title>Career register</title>


    <style>
        
        #email-title {
            padding: 30px;
            font-family: 'Raleway',sans-serif;
            color: white;
        }

        p {
            font-family: sans-serif;
        }

        #fields-row {
            width: 290px;
            float: left;
            margin: 30px;
            padding: 0px;
        }

        #top-info {
            height: 250px;
        }

        #user-icon {
            margin-top: 40px;
            margin-left: 40px;
            width: 200px;
            height: 200px;
            float: left;
            position: relative !important;
        }

        #toptext {
            padding-top: 80px;
            padding-left: 50px;
            width: 400px;
            margin: 0 auto;");
                WriteLiteral(@"
            float: left;
        }

        p {
            font-family: 'Raleway', sans-serif;
            font-size: 18px;
        }

        #li-style {
            list-style-type: none;
            height: 25px;
            font-family: 'Raleway', sans-serif;
            font-size: 14px;
        }
        #half-circle {

            position: absolute !important;
            width: 170px;
            height: 100px;
            background-color: #ff6363;
            border-top-right-radius: 100px;
            border-top-left-radius: 100px;
            margin-top: 0px;
            margin-left: 15px;
        }
        #circle {

          position: absolute !important;
          z-index: 10 !important;
          width:100px;
          height: 100px;
          background-color: #e8e8e8;
          border-radius: 100%;
          margin-left: 50px;

        }

    </style>


");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1990, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(1992, 2724, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f8e96eae7d1e49b385f9fc42e2360517", async() => {
                BeginContext(2046, 2663, true);
                WriteLiteral(@"

    <div>

        <div style=""        width: 700px;
        height: 100px;
        background-color: #ff3838;
        margin: 0 auto;"">
            <h1 id=""email-title"">Register for career</h1>
        </div>

        <div style=""width:700px; height:700px; background-color: white; margin:0 auto;"">
            <div id=""top-info"">

                <div id=""user-icon"">
                    <div id=""circle"">
                    </div>
                    <div id=""half-circle"">
                    </div>

                </div>

                <div id=""toptext"">
                    <p>
                        There is another registration for your careers.
                    </p>
                    <p>
                        Value00
                    </p>
                    <p>
                        You can find careers info as below.
                    </p>
                </div>

            </div>

            <div id=""fields-row"">
                <ul>
         ");
                WriteLiteral(@"           <li id=""li-style"">Firstname</li>
                    <li id=""li-style"">Lastname</li>
                    <li id=""li-style"">Gender</li>
                    <li id=""li-style"">Age</li>
                    <li id=""li-style"">State</li>
                    <li id=""li-style"">House number</li>
                    <li id=""li-style"">Road name</li>
                    <li id=""li-style"">City</li>
                    <li id=""li-style"">Post code</li>
                    <li id=""li-style"">Driver licence</li>
                    <li id=""li-style"">Accident</li>
                    <li id=""li-style"">DBS</li>
                    <li id=""li-style"">Phone number</li>
                    <li id=""li-style"">Email</li>
                </ul>
            </div>

            <div id=""fields-row"">
                <ul>
                    <li id=""li-style"">Value01</li>
                    <li id=""li-style"">Value02</li>
                    <li id=""li-style"">Value03</li>
                    <li id=""li-style"">");
                WriteLiteral(@"Value04</li>
                    <li id=""li-style"">Value05</li>
                    <li id=""li-style"">Value06</li>
                    <li id=""li-style"">Value07</li>
                    <li id=""li-style"">Value08</li>
                    <li id=""li-style"">Value09</li>
                    <li id=""li-style"">Value10</li>
                    <li id=""li-style"">Value11</li>
                    <li id=""li-style"">Value12</li>
                    <li id=""li-style"">Value13</li>
                    <li id=""li-style"">Value14</li>
                </ul>
            </div>



        </div>

    </div>

");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4716, 9, true);
            WriteLiteral("\r\n</html>");
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
