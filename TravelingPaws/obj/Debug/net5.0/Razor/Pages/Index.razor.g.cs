#pragma checksum "C:\Users\kirthomas\source\repos\ket2310\TravelingPaws\TravelingPaws\Pages\Index.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0b82deb6a0c7af394c5844e1eade5a23955d1654"
// <auto-generated/>
#pragma warning disable 1591
namespace TravelingPaws.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\kirthomas\source\repos\ket2310\TravelingPaws\TravelingPaws\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\kirthomas\source\repos\ket2310\TravelingPaws\TravelingPaws\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\kirthomas\source\repos\ket2310\TravelingPaws\TravelingPaws\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\kirthomas\source\repos\ket2310\TravelingPaws\TravelingPaws\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\kirthomas\source\repos\ket2310\TravelingPaws\TravelingPaws\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\kirthomas\source\repos\ket2310\TravelingPaws\TravelingPaws\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\kirthomas\source\repos\ket2310\TravelingPaws\TravelingPaws\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\kirthomas\source\repos\ket2310\TravelingPaws\TravelingPaws\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\kirthomas\source\repos\ket2310\TravelingPaws\TravelingPaws\_Imports.razor"
using TravelingPaws;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\kirthomas\source\repos\ket2310\TravelingPaws\TravelingPaws\_Imports.razor"
using TravelingPaws.Shared;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Index : IndexBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h1>Quotes List</h1>");
#nullable restore
#line 7 "C:\Users\kirthomas\source\repos\ket2310\TravelingPaws\TravelingPaws\Pages\Index.razor"
 if (Quotes == null)
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(1, "<p><em>Loading...</em></p>");
#nullable restore
#line 10 "C:\Users\kirthomas\source\repos\ket2310\TravelingPaws\TravelingPaws\Pages\Index.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(2, "table");
            __builder.AddAttribute(3, "class", "table");
            __builder.AddMarkupContent(4, "<thead><tr><th>Name</th>\r\n                <th>Email</th>\r\n                <th>Phone Number</th>\r\n                <th>Cell Number</th></tr></thead>\r\n        ");
            __builder.OpenElement(5, "tbody");
#nullable restore
#line 23 "C:\Users\kirthomas\source\repos\ket2310\TravelingPaws\TravelingPaws\Pages\Index.razor"
             foreach (var q in Quotes)
            {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(6, "tr");
            __builder.OpenElement(7, "td");
            __builder.AddContent(8, 
#nullable restore
#line 26 "C:\Users\kirthomas\source\repos\ket2310\TravelingPaws\TravelingPaws\Pages\Index.razor"
                          q.petOwner.FirstName + " " +@q.petOwner.LastName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(9, "\r\n                    ");
            __builder.OpenElement(10, "td");
            __builder.AddContent(11, 
#nullable restore
#line 27 "C:\Users\kirthomas\source\repos\ket2310\TravelingPaws\TravelingPaws\Pages\Index.razor"
                         q.petOwner.Email

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(12, "\r\n                    ");
            __builder.OpenElement(13, "td");
            __builder.AddContent(14, 
#nullable restore
#line 28 "C:\Users\kirthomas\source\repos\ket2310\TravelingPaws\TravelingPaws\Pages\Index.razor"
                         q.petOwner.PhoneNumber

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(15, "\r\n                    ");
            __builder.OpenElement(16, "td");
            __builder.AddContent(17, 
#nullable restore
#line 29 "C:\Users\kirthomas\source\repos\ket2310\TravelingPaws\TravelingPaws\Pages\Index.razor"
                         q.petOwner.CellNumber

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(18, "\r\n                    ");
            __builder.OpenElement(19, "td");
            __builder.OpenElement(20, "a");
            __builder.AddAttribute(21, "href", 
#nullable restore
#line 31 "C:\Users\kirthomas\source\repos\ket2310\TravelingPaws\TravelingPaws\Pages\Index.razor"
                                   $"quotedetails/{q.QuoteId}"

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(22, "class", "btn btn-primary m-1");
            __builder.AddContent(23, "View");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(24, "\r\n                    ");
            __builder.OpenElement(25, "td");
            __builder.OpenElement(26, "a");
            __builder.AddAttribute(27, "href", 
#nullable restore
#line 34 "C:\Users\kirthomas\source\repos\ket2310\TravelingPaws\TravelingPaws\Pages\Index.razor"
                                   $"quotecomponent/{q.QuoteId}"

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(28, "class", "btn btn-primary m-1");
            __builder.AddContent(29, "Edit");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(30, "\r\n                    ");
            __builder.AddMarkupContent(31, "<td><a href=\"#\" class=\"btn btn-danger m-1\">Delete</a></td>");
            __builder.CloseElement();
#nullable restore
#line 40 "C:\Users\kirthomas\source\repos\ket2310\TravelingPaws\TravelingPaws\Pages\Index.razor"
            }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(32, "\r\n    <hr>");
#nullable restore
#line 44 "C:\Users\kirthomas\source\repos\ket2310\TravelingPaws\TravelingPaws\Pages\Index.razor"

    
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
