#pragma checksum "C:\Users\JASN\Desktop\SENIOR\ClonMVC\administracion_empleados\AdministracionEmpleados\Views\Movimientos\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "facdd5e57eb298f87debc1dca9d8e9c90ee3bafd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Movimientos_Index), @"mvc.1.0.view", @"/Views/Movimientos/Index.cshtml")]
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
#line 1 "C:\Users\JASN\Desktop\SENIOR\ClonMVC\administracion_empleados\AdministracionEmpleados\Views\_ViewImports.cshtml"
using AdministracionEmpleados;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\JASN\Desktop\SENIOR\ClonMVC\administracion_empleados\AdministracionEmpleados\Views\_ViewImports.cshtml"
using AdministracionEmpleados.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"facdd5e57eb298f87debc1dca9d8e9c90ee3bafd", @"/Views/Movimientos/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7c659c8db510273e24d5ab10452f6d5a28798abc", @"/Views/_ViewImports.cshtml")]
    public class Views_Movimientos_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<AdministracionEmpleados.Models.MovimientosModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\JASN\Desktop\SENIOR\ClonMVC\administracion_empleados\AdministracionEmpleados\Views\Movimientos\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 11 "C:\Users\JASN\Desktop\SENIOR\ClonMVC\administracion_empleados\AdministracionEmpleados\Views\Movimientos\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.IdEmpleado));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 14 "C:\Users\JASN\Desktop\SENIOR\ClonMVC\administracion_empleados\AdministracionEmpleados\Views\Movimientos\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.NombreEmpleado));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 17 "C:\Users\JASN\Desktop\SENIOR\ClonMVC\administracion_empleados\AdministracionEmpleados\Views\Movimientos\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Edad));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 20 "C:\Users\JASN\Desktop\SENIOR\ClonMVC\administracion_empleados\AdministracionEmpleados\Views\Movimientos\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Sexo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 23 "C:\Users\JASN\Desktop\SENIOR\ClonMVC\administracion_empleados\AdministracionEmpleados\Views\Movimientos\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.RolEmpleado));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 26 "C:\Users\JASN\Desktop\SENIOR\ClonMVC\administracion_empleados\AdministracionEmpleados\Views\Movimientos\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.TipoEmpleado));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 29 "C:\Users\JASN\Desktop\SENIOR\ClonMVC\administracion_empleados\AdministracionEmpleados\Views\Movimientos\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.BusquedaNombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <div class=\"form-group\">\r\n                    <input type=\"text\"  class=\"form-control\" />\r\n                </div>\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 38 "C:\Users\JASN\Desktop\SENIOR\ClonMVC\administracion_empleados\AdministracionEmpleados\Views\Movimientos\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 41 "C:\Users\JASN\Desktop\SENIOR\ClonMVC\administracion_empleados\AdministracionEmpleados\Views\Movimientos\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.IdEmpleado));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 44 "C:\Users\JASN\Desktop\SENIOR\ClonMVC\administracion_empleados\AdministracionEmpleados\Views\Movimientos\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.NombreEmpleado));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 47 "C:\Users\JASN\Desktop\SENIOR\ClonMVC\administracion_empleados\AdministracionEmpleados\Views\Movimientos\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Edad));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 50 "C:\Users\JASN\Desktop\SENIOR\ClonMVC\administracion_empleados\AdministracionEmpleados\Views\Movimientos\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Sexo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 53 "C:\Users\JASN\Desktop\SENIOR\ClonMVC\administracion_empleados\AdministracionEmpleados\Views\Movimientos\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.RolEmpleado));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 56 "C:\Users\JASN\Desktop\SENIOR\ClonMVC\administracion_empleados\AdministracionEmpleados\Views\Movimientos\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.TipoEmpleado));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 59 "C:\Users\JASN\Desktop\SENIOR\ClonMVC\administracion_empleados\AdministracionEmpleados\Views\Movimientos\Index.cshtml"
           Write(Html.ActionLink("Registrar Movimiento","RegistraMovimiento", new { id=item.IdEmpleado, nombre= item.NombreEmpleado}));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                ");
#nullable restore
#line 60 "C:\Users\JASN\Desktop\SENIOR\ClonMVC\administracion_empleados\AdministracionEmpleados\Views\Movimientos\Index.cshtml"
           Write(Html.ActionLink("Consultar Movimientos", "ConsultaMovimientos", new { id=item.IdEmpleado }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n \r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 64 "C:\Users\JASN\Desktop\SENIOR\ClonMVC\administracion_empleados\AdministracionEmpleados\Views\Movimientos\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<AdministracionEmpleados.Models.MovimientosModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
