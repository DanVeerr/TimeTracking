#pragma checksum "C:\Users\danii\source\repos\TimeTracking\TimeTracking\Views\Tracking\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7a1e641f55ef4e05143c6a6b8976433ba6f80d43"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Tracking_Details), @"mvc.1.0.view", @"/Views/Tracking/Details.cshtml")]
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
#line 1 "C:\Users\danii\source\repos\TimeTracking\TimeTracking\Views\_ViewImports.cshtml"
using TimeTracking;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\danii\source\repos\TimeTracking\TimeTracking\Views\_ViewImports.cshtml"
using TimeTracking.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7a1e641f55ef4e05143c6a6b8976433ba6f80d43", @"/Views/Tracking/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6cefd5390d3227cbe5b42cd25cf50bd209565c0a", @"/Views/_ViewImports.cshtml")]
    public class Views_Tracking_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TimeTracking.Models.Report>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\danii\source\repos\TimeTracking\TimeTracking\Views\Tracking\Details.cshtml"
  
    ViewBag.Title = "Отчет";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div>\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>Идентификатор</dt>\r\n        <dd>");
#nullable restore
#line 9 "C:\Users\danii\source\repos\TimeTracking\TimeTracking\Views\Tracking\Details.cshtml"
       Write(Model.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n        <dt>Примечание</dt>\r\n        <dd>");
#nullable restore
#line 11 "C:\Users\danii\source\repos\TimeTracking\TimeTracking\Views\Tracking\Details.cshtml"
       Write(Model.Notes);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n        <dt>Количество часов</dt>\r\n        <dd>");
#nullable restore
#line 13 "C:\Users\danii\source\repos\TimeTracking\TimeTracking\Views\Tracking\Details.cshtml"
       Write(Model.Hours);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n");
#nullable restore
#line 14 "C:\Users\danii\source\repos\TimeTracking\TimeTracking\Views\Tracking\Details.cshtml"
         if (ViewBag.OwnerSurname != null)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <dt>Пользователь</dt>\r\n            <dd>");
#nullable restore
#line 17 "C:\Users\danii\source\repos\TimeTracking\TimeTracking\Views\Tracking\Details.cshtml"
           Write(ViewBag.OwnerSurmame);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n");
#nullable restore
#line 18 "C:\Users\danii\source\repos\TimeTracking\TimeTracking\Views\Tracking\Details.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <dt>Дата</dt>\r\n        <dd>");
#nullable restore
#line 20 "C:\Users\danii\source\repos\TimeTracking\TimeTracking\Views\Tracking\Details.cshtml"
       Write(Model.Date.ToLongDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n\r\n    </dl>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TimeTracking.Models.Report> Html { get; private set; }
    }
}
#pragma warning restore 1591
