#pragma checksum "C:\Users\Avilash.Jha\source\repos\HospitalSystem_Core\HospitalSystem_Core\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e4d1dea658ce3232ca26e605eb17c4c2b44754ee"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e4d1dea658ce3232ca26e605eb17c4c2b44754ee", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"21693a210cd4dff1d3712d7969a7aa93901698ef", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<HospitalSystem_Core.ViewModels.DashboardVm>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Doctor", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ListOfDoctor", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("small-box-footer"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Patient", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "GetPatientData", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/bower_components/raphael/raphael.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Avilash.Jha\source\repos\HospitalSystem_Core\HospitalSystem_Core\Views\Home\Index.cshtml"
  
    var total = 0;
    total = Model.Patients_count + Model.Nurses_count + Model.Doctors_count;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e4d1dea658ce3232ca26e605eb17c4c2b44754ee5555", async() => {
                WriteLiteral("\r\n\r\n    <section class=\"content-header\">\r\n\r\n        <h1>\r\n            Dashboard\r\n            <small>Control panel</small>\r\n        </h1>\r\n        <ol class=\"breadcrumb\">\r\n            <li>Last login detail : ");
#nullable restore
#line 18 "C:\Users\Avilash.Jha\source\repos\HospitalSystem_Core\HospitalSystem_Core\Views\Home\Index.cshtml"
                               Write(Model.UserDetailVm.LoginDetail);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</li> &nbsp;&nbsp;
            <li><a href=""#""><i class=""fa fa-dashboard""></i> Home</a></li>
            <li class=""active"">Dashboard</li>
        </ol>
    </section>
    <!-- Main content -->
    <section class=""content"">
        <!-- Small boxes (Stat box) -->
        <div class=""row"">
            <div class=""col-lg-3 col-xs-6"">
                <!-- small box -->
                <div class=""small-box bg-aqua"">
                    <div class=""inner"">
                        <h3>");
#nullable restore
#line 31 "C:\Users\Avilash.Jha\source\repos\HospitalSystem_Core\HospitalSystem_Core\Views\Home\Index.cshtml"
                       Write(Model.Doctors_count);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h3>\r\n                        <p>Doctors</p>\r\n                    </div>\r\n                    <div class=\"icon\">\r\n                        <i class=\"fa fa-users\"></i>\r\n                    </div>\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e4d1dea658ce3232ca26e605eb17c4c2b44754ee7336", async() => {
                    WriteLiteral("More info <i class=\"fa fa-arrow-circle-right\"></i>");
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
                WriteLiteral(@"
                </div>
            </div>
            <!-- ./col -->
            <div class=""col-lg-3 col-xs-6"">
                <!-- small box -->
                <div class=""small-box bg-green"">
                    <div class=""inner"">
                        <h3>");
#nullable restore
#line 45 "C:\Users\Avilash.Jha\source\repos\HospitalSystem_Core\HospitalSystem_Core\Views\Home\Index.cshtml"
                       Write(Model.Nurses_count);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"<sup style=""font-size: 20px""></sup></h3>
                        <p>Nurses</p>
                    </div>
                    <div class=""icon"">
                        <i class=""fa fa-users""></i>
                    </div>
                    <a href=""#"" class=""small-box-footer"">More info <i class=""fa fa-arrow-circle-right""></i></a>
                </div>
            </div>
            <!-- ./col -->
            <div class=""col-lg-3 col-xs-6"">
                <!-- small box -->
                <div class=""small-box bg-yellow"">
                    <div class=""inner"">
                        <h3>");
#nullable restore
#line 59 "C:\Users\Avilash.Jha\source\repos\HospitalSystem_Core\HospitalSystem_Core\Views\Home\Index.cshtml"
                       Write(Model.Patients_count);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h3>\r\n                        <p>Patients</p>\r\n                    </div>\r\n                    <div class=\"icon\">\r\n                        <i class=\"ion ion-person\"></i>\r\n                    </div>\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e4d1dea658ce3232ca26e605eb17c4c2b44754ee10582", async() => {
                    WriteLiteral("More info <i class=\"fa fa-arrow-circle-right\"></i>");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
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
                WriteLiteral(@"
                </div>
            </div>
            <!-- ./col -->
            <div class=""col-lg-3 col-xs-6"">
                <!-- small box -->
                <div class=""small-box bg-red"">
                    <div class=""inner"">
                        <h3>");
#nullable restore
#line 73 "C:\Users\Avilash.Jha\source\repos\HospitalSystem_Core\HospitalSystem_Core\Views\Home\Index.cshtml"
                       Write(total);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</h3>
                        <p>This Month</p>
                    </div>
                    <div class=""icon"">
                        <i class=""ion ion-pie-graph""></i>
                    </div>
                    <a href=""#"" class=""small-box-footer"">More info <i class=""fa fa-arrow-circle-right""></i></a>
                </div>
            </div>
            <!-- ./col -->
        </div>
        <!-- /.row -->
        <!-- Main row -->
        <div class=""row"">
            <!-- Left col -->
            <section class=""col-lg-7 connectedSortable"">
                <!-- Custom tabs (Charts with tabs)-->
                <!-- DONUT CHART -->
                <div class=""box box-danger"">
                    <div class=""box-header with-border"">
                        <h3 class=""box-title"">Donut Chart</h3>
                        <div class=""box-tools pull-right"">
                            <button type=""button"" class=""btn btn-box-tool"" data-widget=""collapse"">
                             ");
                WriteLiteral(@"   <i class=""fa fa-minus""></i>
                            </button>
                            <button type=""button"" class=""btn btn-box-tool"" data-widget=""remove""><i class=""fa fa-times""></i></button>
                        </div>
                    </div>
                    <div class=""box-body chart-responsive"">
                        <div class=""chart"" id=""sales-chart"" style=""height: 300px; position: relative;""></div>
                    </div>
                    <!-- /.box-body -->
                </div>
                <!-- /.nav-tabs-custom -->
            </section>
            <!-- /.Left col -->
            <!-- right col (We are only adding the ID to make the widgets sortable)-->
            <section class=""col-lg-5 connectedSortable"">
                <!-- TO DO List -->
                <div class=""box box-primary"">
                    <div class=""box-header"">
                        <i class=""ion ion-clipboard""></i>
                        <h3 class=""box-title"">To Do List</");
                WriteLiteral(@"h3>
                        <div class=""box-tools pull-right"">
                            <ul class=""pagination pagination-sm inline"">
                                <li><a href=""#"">«</a></li>
                                <li><a href=""#"">1</a></li>
                                <li><a href=""#"">2</a></li>
                                <li><a href=""#"">3</a></li>
                                <li><a href=""#"">»</a></li>
                            </ul>
                        </div>
                    </div>
                    <!-- /.box-header -->
                    <div class=""box-body"">
                        <!-- See dist/js/pages/dashboard.js to activate the todoList plugin -->
                        <ul class=""todo-list"">
                            <li>
                                <!-- drag handle -->
                                <span class=""handle"">
                                    <i class=""fa fa-ellipsis-v""></i>
                                    <i class=");
                WriteLiteral("\"fa fa-ellipsis-v\"></i>\r\n                                </span>\r\n                                <!-- checkbox -->\r\n                                <input type=\"checkbox\"");
                BeginWriteAttribute("value", " value=\"", 6084, "\"", 6092, 0);
                EndWriteAttribute();
                WriteLiteral(@">
                                <!-- todo text -->
                                <span class=""text"">Patient 1 Check up Time</span>
                                <!-- Emphasis label -->
                                <small class=""label label-danger""><i class=""fa fa-clock-o""></i> 2 mins</small>
                                <!-- General tools such as edit or delete-->
                                <div class=""tools"">
                                    <i class=""fa fa-edit""></i>
                                    <i class=""fa fa-trash-o""></i>
                                </div>
                            </li>
                            <li>
                                <span class=""handle"">
                                    <i class=""fa fa-ellipsis-v""></i>
                                    <i class=""fa fa-ellipsis-v""></i>
                                </span>
                                <input type=""checkbox""");
                BeginWriteAttribute("value", " value=\"", 7061, "\"", 7069, 0);
                EndWriteAttribute();
                WriteLiteral(@">
                                <span class=""text"">Medicine for X Patient</span>
                                <small class=""label label-info""><i class=""fa fa-clock-o""></i> 4 hours</small>
                                <div class=""tools"">
                                    <i class=""fa fa-edit""></i>
                                    <i class=""fa fa-trash-o""></i>
                                </div>
                            </li>
                            <li>
                                <span class=""handle"">
                                    <i class=""fa fa-ellipsis-v""></i>
                                    <i class=""fa fa-ellipsis-v""></i>
                                </span>
                                <input type=""checkbox""");
                BeginWriteAttribute("value", " value=\"", 7849, "\"", 7857, 0);
                EndWriteAttribute();
                WriteLiteral(@">
                                <span class=""text"">New Patient Operation</span>
                                <small class=""label label-warning""><i class=""fa fa-clock-o""></i> 1 day</small>
                                <div class=""tools"">
                                    <i class=""fa fa-edit""></i>
                                    <i class=""fa fa-trash-o""></i>
                                </div>
                            </li>
                            <li>
                                <span class=""handle"">
                                    <i class=""fa fa-ellipsis-v""></i>
                                    <i class=""fa fa-ellipsis-v""></i>
                                </span>
                                <input type=""checkbox""");
                BeginWriteAttribute("value", " value=\"", 8637, "\"", 8645, 0);
                EndWriteAttribute();
                WriteLiteral(@">
                                <span class=""text"">Ward Visit</span>
                                <small class=""label label-success""><i class=""fa fa-clock-o""></i> 3 days</small>
                                <div class=""tools"">
                                    <i class=""fa fa-edit""></i>
                                    <i class=""fa fa-trash-o""></i>
                                </div>
                            </li>
                            <li>
                                <span class=""handle"">
                                    <i class=""fa fa-ellipsis-v""></i>
                                    <i class=""fa fa-ellipsis-v""></i>
                                </span>
                                <input type=""checkbox""");
                BeginWriteAttribute("value", " value=\"", 9415, "\"", 9423, 0);
                EndWriteAttribute();
                WriteLiteral(@">
                                <span class=""text"">Any other Activity</span>
                                <small class=""label label-primary""><i class=""fa fa-clock-o""></i> 1 week</small>
                                <div class=""tools"">
                                    <i class=""fa fa-edit""></i>
                                    <i class=""fa fa-trash-o""></i>
                                </div>
                            </li>
                            <li>
                                <span class=""handle"">
                                    <i class=""fa fa-ellipsis-v""></i>
                                    <i class=""fa fa-ellipsis-v""></i>
                                </span>
                                <input type=""checkbox""");
                BeginWriteAttribute("value", " value=\"", 10201, "\"", 10209, 0);
                EndWriteAttribute();
                WriteLiteral(@">
                                <span class=""text"">Any other Activity</span>
                                <small class=""label label-default""><i class=""fa fa-clock-o""></i> 1 month</small>
                                <div class=""tools"">
                                    <i class=""fa fa-edit""></i>
                                    <i class=""fa fa-trash-o""></i>
                                </div>
                            </li>
                        </ul>
                    </div>
                    <!-- /.box-body -->
                    <div class=""box-footer clearfix no-border"">
                        <button type=""button"" class=""btn btn-default pull-right""><i class=""fa fa-plus""></i> Add item</button>
                    </div>
                </div>
                <!-- /.box -->
            </section>
            <!-- right col -->
        </div>
        <!-- /.row (main row) -->
    </section>

    <!-- Morris.js charts http://code.jquery.com/jquery-1.11.3.min.js");
                WriteLiteral(" -->\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e4d1dea658ce3232ca26e605eb17c4c2b44754ee22310", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/morris.js/0.5.1/morris.min.js""></script>
    <script src=""http://code.jquery.com/jquery-1.11.3.min.js""></script>

    <script>
        var donut = null;
    $(function($) {
        ""use strict"";
        //DONUT CHART
        donut =Morris.Donut({
        element: 'sales-chart',
        resize: true,
        colors: [""#3c8dbc"", ""#f56954"", ""#00a65a""],
        data: [
        {label: ""Registered Doctors"", value: ");
#nullable restore
#line 242 "C:\Users\Avilash.Jha\source\repos\HospitalSystem_Core\HospitalSystem_Core\Views\Home\Index.cshtml"
                                        Write(Model.Doctors_count);

#line default
#line hidden
#nullable disable
                WriteLiteral("},\r\n        {label: \"Registered Nurses\", value: ");
#nullable restore
#line 243 "C:\Users\Avilash.Jha\source\repos\HospitalSystem_Core\HospitalSystem_Core\Views\Home\Index.cshtml"
                                       Write(Model.Nurses_count);

#line default
#line hidden
#nullable disable
                WriteLiteral("},\r\n        {label: \"Registered Patients\", value: ");
#nullable restore
#line 244 "C:\Users\Avilash.Jha\source\repos\HospitalSystem_Core\HospitalSystem_Core\Views\Home\Index.cshtml"
                                         Write(Model.Patients_count);

#line default
#line hidden
#nullable disable
                WriteLiteral("}\r\n        ],\r\n        hideHover: \'auto\'\r\n    });\r\n  });\r\n    </script>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<HospitalSystem_Core.ViewModels.DashboardVm> Html { get; private set; }
    }
}
#pragma warning restore 1591
