#pragma checksum "C:\Users\Sirzesx\Downloads\BTN1\src\Views\Request\RequestSparql.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d1b2d62e921b5afc0bcb9b2ab1153c908fcf68f9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Request_RequestSparql), @"mvc.1.0.view", @"/Views/Request/RequestSparql.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Request/RequestSparql.cshtml", typeof(AspNetCore.Views_Request_RequestSparql))]
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
#line 1 "C:\Users\Sirzesx\Downloads\BTN1\src\Views\_ViewImports.cshtml"
using BTN1;

#line default
#line hidden
#line 2 "C:\Users\Sirzesx\Downloads\BTN1\src\Views\_ViewImports.cshtml"
using BTN1.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d1b2d62e921b5afc0bcb9b2ab1153c908fcf68f9", @"/Views/Request/RequestSparql.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"31172fb63d6bf649a1430dcdf385f94c033463ba", @"/Views/_ViewImports.cshtml")]
    public class Views_Request_RequestSparql : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 3 "C:\Users\Sirzesx\Downloads\BTN1\src\Views\Request\RequestSparql.cshtml"
  
   
    ViewData["Title"] = "Request SPARQL";

#line default
#line hidden
            BeginContext(59, 195, true);
            WriteLiteral("\r\n<table>\r\n\r\n     <tr>\r\n            <th style=\"border:solid\" > Nom  </th>\r\n            <th style=\"border:solid\" > genre </th>\r\n            <th style=\"border:solid\" > URL </th>\r\n    </tr> \r\n    \r\n");
            EndContext();
#line 16 "C:\Users\Sirzesx\Downloads\BTN1\src\Views\Request\RequestSparql.cshtml"
 foreach ( Data data in @Model){



#line default
#line hidden
            BeginContext(292, 52, true);
            WriteLiteral("        <tr>\r\n            <td style=\"border:solid\"> ");
            EndContext();
            BeginContext(345, 9, false);
#line 20 "C:\Users\Sirzesx\Downloads\BTN1\src\Views\Request\RequestSparql.cshtml"
                                 Write(data.Name);

#line default
#line hidden
            EndContext();
            BeginContext(354, 46, true);
            WriteLiteral(" </td>\r\n            <td style=\"border:solid\"> ");
            EndContext();
            BeginContext(401, 10, false);
#line 21 "C:\Users\Sirzesx\Downloads\BTN1\src\Views\Request\RequestSparql.cshtml"
                                 Write(data.genre);

#line default
#line hidden
            EndContext();
            BeginContext(411, 46, true);
            WriteLiteral(" </td>\r\n            <td style=\"border:solid\"> ");
            EndContext();
            BeginContext(458, 8, false);
#line 22 "C:\Users\Sirzesx\Downloads\BTN1\src\Views\Request\RequestSparql.cshtml"
                                 Write(data.URL);

#line default
#line hidden
            EndContext();
            BeginContext(466, 37, true);
            WriteLiteral(" </td>\r\n            \r\n        </tr>\r\n");
            EndContext();
#line 25 "C:\Users\Sirzesx\Downloads\BTN1\src\Views\Request\RequestSparql.cshtml"
}

#line default
#line hidden
            BeginContext(506, 10, true);
            WriteLiteral("\r\n</table>");
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
