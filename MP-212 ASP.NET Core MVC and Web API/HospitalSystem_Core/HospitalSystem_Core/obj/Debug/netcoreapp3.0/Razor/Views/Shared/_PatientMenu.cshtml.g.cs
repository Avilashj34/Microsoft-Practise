#pragma checksum "C:\Users\Avilash.Jha\source\repos\HospitalSystem_Core\HospitalSystem_Core\Views\Shared\_PatientMenu.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "252552a494b7bf1081e0ef123d44fcd0cbc38689"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__PatientMenu), @"mvc.1.0.view", @"/Views/Shared/_PatientMenu.cshtml")]
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
#line 3 "C:\Users\Avilash.Jha\source\repos\HospitalSystem_Core\HospitalSystem_Core\Views\_ViewImports.cshtml"
using HospitalSystem_Core.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"252552a494b7bf1081e0ef123d44fcd0cbc38689", @"/Views/Shared/_PatientMenu.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"21693a210cd4dff1d3712d7969a7aa93901698ef", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__PatientMenu : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<ul class=""sidebar-menu"" data-widget=""tree"">
   
    
    <li class=""treeview"">
        <a href=""#"">
            <i class=""fa fa-user""></i> <span>Patient</span>
            <span class=""pull-right-container"">
                <i class=""fa fa-angle-left pull-right""></i>
            </span>
        </a>
        <ul class=""treeview-menu"">
            <li><a href=""/Patient/AddPatient"">Add Patient</a></li>
            <li><a href=""/Patient/GetPatientData"">View Patient Record</a></li>
        </ul>
    </li>
</ul>
");
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