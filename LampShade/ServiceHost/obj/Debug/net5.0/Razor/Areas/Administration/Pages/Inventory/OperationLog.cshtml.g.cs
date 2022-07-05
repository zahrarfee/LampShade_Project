#pragma checksum "F:\Practice\LampShade\LampShade\ServiceHost\Areas\Administration\Pages\Inventory\OperationLog.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e43b1e23d3f490454be4991e69c1ba3401fa9a56"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ServiceHost.Areas.Administration.Pages.Inventory.Areas_Administration_Pages_Inventory_OperationLog), @"mvc.1.0.view", @"/Areas/Administration/Pages/Inventory/OperationLog.cshtml")]
namespace ServiceHost.Areas.Administration.Pages.Inventory
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
#line 1 "F:\Practice\LampShade\LampShade\ServiceHost\Areas\Administration\Pages\_ViewImports.cshtml"
using ServiceHost;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e43b1e23d3f490454be4991e69c1ba3401fa9a56", @"/Areas/Administration/Pages/Inventory/OperationLog.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"017e7b82f93da93e475c4b977fb8d8c18cf84a07", @"/Areas/Administration/Pages/_ViewImports.cshtml")]
    public class Areas_Administration_Pages_Inventory_OperationLog : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<InventoryManagement.Application.Contract.Inventory.InventoryOperationViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"

<div class=""modal-header"">
    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-hidden=""true"">×</button>
    <h4 class=""modal-title"">  سوابق گردش انبار</h4>
</div>


<div class=""modal-body"">
    <table id=""datatable"" class=""table table-bordered"">
        <thead>
            <tr>
                <th>شناسه</th>
                <th>تعداد</th>
                <th>تاریخ</th>
                <th>عملیات</th>
                <th>موجودی فعلی</th>
                <th>عملگر</th>
                <th>توضیحات</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 29 "F:\Practice\LampShade\LampShade\ServiceHost\Areas\Administration\Pages\Inventory\OperationLog.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr");
            BeginWriteAttribute("class", " class=\"", 881, "\"", 948, 2);
            WriteAttributeValue("", 889, "text-warning", 889, 12, true);
#nullable restore
#line 31 "F:\Practice\LampShade\LampShade\ServiceHost\Areas\Administration\Pages\Inventory\OperationLog.cshtml"
WriteAttributeValue(" ", 901, item.Operation ? "bg-success" : "bg-danger", 902, 46, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                <td>");
#nullable restore
#line 32 "F:\Practice\LampShade\LampShade\ServiceHost\Areas\Administration\Pages\Inventory\OperationLog.cshtml"
               Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 33 "F:\Practice\LampShade\LampShade\ServiceHost\Areas\Administration\Pages\Inventory\OperationLog.cshtml"
               Write(item.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 34 "F:\Practice\LampShade\LampShade\ServiceHost\Areas\Administration\Pages\Inventory\OperationLog.cshtml"
               Write(item.OperationDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>\r\n");
#nullable restore
#line 36 "F:\Practice\LampShade\LampShade\ServiceHost\Areas\Administration\Pages\Inventory\OperationLog.cshtml"
                     if (item.Operation)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span>افزایش</span>\r\n");
#nullable restore
#line 39 "F:\Practice\LampShade\LampShade\ServiceHost\Areas\Administration\Pages\Inventory\OperationLog.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span>کاهش </span>\r\n");
#nullable restore
#line 43 "F:\Practice\LampShade\LampShade\ServiceHost\Areas\Administration\Pages\Inventory\OperationLog.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n                <td>");
#nullable restore
#line 45 "F:\Practice\LampShade\LampShade\ServiceHost\Areas\Administration\Pages\Inventory\OperationLog.cshtml"
               Write(item.CurrentCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 46 "F:\Practice\LampShade\LampShade\ServiceHost\Areas\Administration\Pages\Inventory\OperationLog.cshtml"
               Write(item.Operator);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 47 "F:\Practice\LampShade\LampShade\ServiceHost\Areas\Administration\Pages\Inventory\OperationLog.cshtml"
               Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n\r\n\r\n\r\n            </tr>\r\n");
#nullable restore
#line 53 "F:\Practice\LampShade\LampShade\ServiceHost\Areas\Administration\Pages\Inventory\OperationLog.cshtml"

        }

#line default
#line hidden
#nullable disable
            WriteLiteral("       \r\n        </tbody>\r\n    </table>\r\n\r\n</div>\r\n    <div class=\"modal-footer\">\r\n        <button type=\"button\" class=\"btn btn-default waves-effect\" data-dismiss=\"modal\">بستن</button>\r\n     \r\n    </div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<InventoryManagement.Application.Contract.Inventory.InventoryOperationViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
