#pragma checksum "F:\Practice\LampShade\LampShade\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "28b1549f16b94bdb02816f3a8f27bba7996d9871"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ServiceHost.Pages.Shared.Components.ProductCategoryWithProduct.Pages_Shared_Components_ProductCategoryWithProduct_Default), @"mvc.1.0.view", @"/Pages/Shared/Components/ProductCategoryWithProduct/Default.cshtml")]
namespace ServiceHost.Pages.Shared.Components.ProductCategoryWithProduct
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
#line 1 "F:\Practice\LampShade\LampShade\ServiceHost\Pages\_ViewImports.cshtml"
using ServiceHost;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"28b1549f16b94bdb02816f3a8f27bba7996d9871", @"/Pages/Shared/Components/ProductCategoryWithProduct/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d027006424b9e12b1709732f146fce9f1d78e6a1", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Shared_Components_ProductCategoryWithProduct_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<_01_LampshadeQuery.Contracts.ProductCategory.ProductCategoryQueryModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-fluid"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/Product", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/ProductCategory", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div class=""single-row-slider-tab-area section-space"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-lg-12"">
                <!--=======  section title  =======-->
                <div class=""section-title-wrapper text-center section-space--half"">
                    <h2 class=""section-title"">محصولات ما</h2>
                    <p class=""section-subtitle"">
                       محصولات ما را با بالاترین کیفیت تهیه نمایید
                    </p>
                </div>
                <!--=======  End of section title  =======-->
            </div>
        </div>
        <div class=""row"">
            <div class=""col-lg-12"">
                <!--=======  tab slider wrapper  =======-->

                <div class=""tab-slider-wrapper"">
                    <!--=======  tab product navigation  =======-->

                    <div class=""tab-product-navigation"">
                        <div class=""nav nav-tabs justify-content-center"" id=""nav-tab2"" role=""tabli");
            WriteLiteral("st\">\r\n");
#nullable restore
#line 30 "F:\Practice\LampShade\LampShade\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\Default.cshtml"
                             foreach (var item in Model)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <a");
            BeginWriteAttribute("class", " class=\"", 1368, "\"", 1434, 3);
            WriteAttributeValue("", 1376, "nav-item", 1376, 8, true);
            WriteAttributeValue(" ", 1384, "nav-link", 1385, 9, true);
#nullable restore
#line 32 "F:\Practice\LampShade\LampShade\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\Default.cshtml"
WriteAttributeValue(" ", 1393, Model.First() == item ? "active" : "", 1394, 40, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("id", " id=\"", 1435, "\"", 1460, 2);
            WriteAttributeValue("", 1440, "product-tab-", 1440, 12, true);
#nullable restore
#line 32 "F:\Practice\LampShade\LampShade\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\Default.cshtml"
WriteAttributeValue("", 1452, item.Id, 1452, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-toggle=\"tab\"");
            BeginWriteAttribute("href", "\r\n                                   href=\"", 1479, "\"", 1546, 2);
            WriteAttributeValue("", 1522, "#product-series-", 1522, 16, true);
#nullable restore
#line 33 "F:\Practice\LampShade\LampShade\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\Default.cshtml"
WriteAttributeValue("", 1538, item.Id, 1538, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" role=\"tab\" aria-selected=\"true\">");
#nullable restore
#line 33 "F:\Practice\LampShade\LampShade\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\Default.cshtml"
                                                                                              Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 34 "F:\Practice\LampShade\LampShade\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\Default.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                           \r\n\r\n\r\n");
            WriteLiteral("                        </div>\r\n                    </div>\r\n\r\n                    <!--=======  End of tab product navigation  =======-->\r\n                    <!--=======  tab product content  =======-->\r\n                    <div class=\"tab-content\">\r\n");
#nullable restore
#line 52 "F:\Practice\LampShade\LampShade\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\Default.cshtml"
                         foreach (var category in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div");
            BeginWriteAttribute("class", " class=\"", 2838, "\"", 2909, 4);
            WriteAttributeValue("", 2846, "tab-pane", 2846, 8, true);
            WriteAttributeValue(" ", 2854, "fade", 2855, 5, true);
            WriteAttributeValue(" ", 2859, "show", 2860, 5, true);
#nullable restore
#line 54 "F:\Practice\LampShade\LampShade\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\Default.cshtml"
WriteAttributeValue(" ", 2864, Model.First() == category ? "active" : "", 2865, 44, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("id", " id=\"", 2910, "\"", 2942, 2);
            WriteAttributeValue("", 2915, "product-series-", 2915, 15, true);
#nullable restore
#line 54 "F:\Practice\LampShade\LampShade\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\Default.cshtml"
WriteAttributeValue("", 2930, category.Id, 2930, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" role=\"tabpanel\"");
            BeginWriteAttribute("aria-labelledby", "\r\n                                 aria-labelledby=\"", 2959, "\"", 3035, 2);
            WriteAttributeValue("", 3011, "product-tab-", 3011, 12, true);
#nullable restore
#line 55 "F:\Practice\LampShade\LampShade\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\Default.cshtml"
WriteAttributeValue("", 3023, category.Id, 3023, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                            <!--=======  single row slider wrapper  =======-->
                            <div class=""single-row-slider-wrapper"">
                            <div class=""ht-slick-slider"" data-slick-setting='{
                                    ""slidesToShow"": 4,
                                    ""slidesToScroll"": 1,
                                    ""arrows"": true,
                                    ""autoplay"": false,
                                    ""autoplaySpeed"": 5000,
                                    ""speed"": 1000,
                                    ""infinite"": true,
                                    ""rtl"": true,
                                    ""prevArrow"": {""buttonClass"": ""slick-prev"", ""iconClass"": ""ion-chevron-left"" },
                                    ""nextArrow"": {""buttonClass"": ""slick-next"", ""iconClass"": ""ion-chevron-right"" }
                                }' data-slick-responsive='[
                                    {""breakpoint"":1501, ""sett");
            WriteLiteral(@"ings"": {""slidesToShow"": 4} },
                                    {""breakpoint"":1199, ""settings"": {""slidesToShow"": 4, ""arrows"": false} },
                                    {""breakpoint"":991, ""settings"": {""slidesToShow"": 3, ""arrows"": false} },
                                    {""breakpoint"":767, ""settings"": {""slidesToShow"": 2, ""arrows"": false} },
                                    {""breakpoint"":575, ""settings"": {""slidesToShow"": 2, ""arrows"": false} },
                                    {""breakpoint"":479, ""settings"": {""slidesToShow"": 1, ""arrows"": false} }
                                ]'>
");
#nullable restore
#line 77 "F:\Practice\LampShade\LampShade\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\Default.cshtml"
                             foreach (var product in category.Products)
                            {
         

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                            <div class=""col"">
                                                <!--=======  single grid product  =======-->
                                                <div class=""single-grid-product"">
                                                    <div class=""single-grid-product__image"">
");
#nullable restore
#line 84 "F:\Practice\LampShade\LampShade\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\Default.cshtml"
                                                         if (product.HasDiscount)
                                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                            <div class=\"single-grid-product__label\">\r\n                                                                <span class=\"sale\">-");
#nullable restore
#line 87 "F:\Practice\LampShade\LampShade\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\Default.cshtml"
                                                                               Write(product.DiscountRate);

#line default
#line hidden
#nullable disable
            WriteLiteral("%</span>\r\n                                                               \r\n                                                            </div>\r\n");
#nullable restore
#line 90 "F:\Practice\LampShade\LampShade\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\Default.cshtml"

                                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                       \r\n\r\n                                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "28b1549f16b94bdb02816f3a8f27bba7996d987114098", async() => {
                WriteLiteral("\r\n                                                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "28b1549f16b94bdb02816f3a8f27bba7996d987114414", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 5930, "~/ProductPictures/", 5930, 18, true);
#nullable restore
#line 95 "F:\Practice\LampShade\LampShade\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\Default.cshtml"
AddHtmlAttributeValue("", 5948, product.Picture, 5948, 16, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "alt", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 96 "F:\Practice\LampShade\LampShade\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\Default.cshtml"
AddHtmlAttributeValue("", 6055, product.PictureAlt, 6055, 19, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "title", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 96 "F:\Practice\LampShade\LampShade\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\Default.cshtml"
AddHtmlAttributeValue("", 6083, product.PictureTitle, 6083, 21, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "name", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 94 "F:\Practice\LampShade\LampShade\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\Default.cshtml"
AddHtmlAttributeValue("", 5814, product.Slug, 5814, 13, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 94 "F:\Practice\LampShade\LampShade\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\Default.cshtml"
                                                                                                      WriteLiteral(product.Slug);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"


                                                    </div>
                                                    <div class=""single-grid-product__content"">
                                                        <div class=""single-grid-product__category-rating"">
                                                            <span class=""category"">
                                                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "28b1549f16b94bdb02816f3a8f27bba7996d987120060", async() => {
#nullable restore
#line 104 "F:\Practice\LampShade\LampShade\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\Default.cshtml"
                                                                                                                               Write(product.Category);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 104 "F:\Practice\LampShade\LampShade\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\Default.cshtml"
                                                                                                 WriteLiteral(product.CategorySlug);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                                            </span>
                                                            <span class=""rating"">
                                                                <i class=""ion-android-star active""></i>
                                                                <i class=""ion-android-star active""></i>
                                                                <i class=""ion-android-star active""></i>
                                                                <i class=""ion-android-star active""></i>
                                                                <i class=""ion-android-star-outline""></i>
                                                            </span>
                                                        </div>

                                                        <h3 class=""single-grid-product__title"">
                                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "28b1549f16b94bdb02816f3a8f27bba7996d987123597", async() => {
                WriteLiteral("\r\n                                                                ");
#nullable restore
#line 117 "F:\Practice\LampShade\LampShade\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\Default.cshtml"
                                                           Write(product.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 116 "F:\Practice\LampShade\LampShade\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\Default.cshtml"
                                                                                     WriteLiteral(product.Slug);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                                        </h3>
                                                        
                                               
                                                        <p class=""single-grid-product__price"">
");
#nullable restore
#line 123 "F:\Practice\LampShade\LampShade\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\Default.cshtml"
                                                             if (product.HasDiscount)
                                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                                <span class=\"discounted-price\">");
#nullable restore
#line 125 "F:\Practice\LampShade\LampShade\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\Default.cshtml"
                                                                                          Write(product.PriceWithDiscount);

#line default
#line hidden
#nullable disable
            WriteLiteral(" تومان</span>\r\n                                                                <span class=\"main-price discounted\">$");
#nullable restore
#line 126 "F:\Practice\LampShade\LampShade\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\Default.cshtml"
                                                                                                Write(product.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(" تومان</span>\r\n");
#nullable restore
#line 127 "F:\Practice\LampShade\LampShade\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\Default.cshtml"

                                                            }
                                                            else
                                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                                <span class=\"main-price\">");
#nullable restore
#line 131 "F:\Practice\LampShade\LampShade\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\Default.cshtml"
                                                                                    Write(product.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(" تومان</span>\r\n");
#nullable restore
#line 132 "F:\Practice\LampShade\LampShade\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\Default.cshtml"
                                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                                            
                                                           
                                                        </p>
                                                    </div>
                                                </div>
                                                <!--=======  End of single grid product  =======-->
                                            </div>
");
#nullable restore
#line 140 "F:\Practice\LampShade\LampShade\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\Default.cshtml"

                                          



                                      

                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </div>\r\n                            </div>\r\n                            <!--=======  End of single row slider wrapper  =======-->\r\n                            </div>\r\n");
#nullable restore
#line 152 "F:\Practice\LampShade\LampShade\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\Default.cshtml"

                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                    </div>\r\n                    <!--=======  End of tab product content  =======-->\r\n                </div>\r\n\r\n                <!--=======  End of tab slider wrapper  =======-->\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<_01_LampshadeQuery.Contracts.ProductCategory.ProductCategoryQueryModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
