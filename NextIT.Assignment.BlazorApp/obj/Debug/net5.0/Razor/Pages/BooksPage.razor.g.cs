#pragma checksum "C:\Users\anton\source\repos\NextIT.Assignment\NextIT.Assignment.BlazorApp\Pages\BooksPage.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1c7d6bed59833aa131eaa1c40d1942946510caa8"
// <auto-generated/>
#pragma warning disable 1591
namespace NextIT.Assignment.BlazorApp.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\anton\source\repos\NextIT.Assignment\NextIT.Assignment.BlazorApp\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\anton\source\repos\NextIT.Assignment\NextIT.Assignment.BlazorApp\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\anton\source\repos\NextIT.Assignment\NextIT.Assignment.BlazorApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\anton\source\repos\NextIT.Assignment\NextIT.Assignment.BlazorApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\anton\source\repos\NextIT.Assignment\NextIT.Assignment.BlazorApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\anton\source\repos\NextIT.Assignment\NextIT.Assignment.BlazorApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\anton\source\repos\NextIT.Assignment\NextIT.Assignment.BlazorApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\anton\source\repos\NextIT.Assignment\NextIT.Assignment.BlazorApp\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\anton\source\repos\NextIT.Assignment\NextIT.Assignment.BlazorApp\_Imports.razor"
using NextIT.Assignment.BlazorApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\anton\source\repos\NextIT.Assignment\NextIT.Assignment.BlazorApp\_Imports.razor"
using NextIT.Assignment.BlazorApp.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\anton\source\repos\NextIT.Assignment\NextIT.Assignment.BlazorApp\Pages\BooksPage.razor"
using NextIT.Assignment.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\anton\source\repos\NextIT.Assignment\NextIT.Assignment.BlazorApp\Pages\BooksPage.razor"
using NextIT.Assignment.BlazorApp.Data;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/books")]
    public partial class BooksPage : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h1>Books</h1>\r\n\r\n");
            __builder.AddMarkupContent(1, "<p>This page displays books</p>");
#nullable restore
#line 14 "C:\Users\anton\source\repos\NextIT.Assignment\NextIT.Assignment.BlazorApp\Pages\BooksPage.razor"
 if (_filteredBooks == null || !_filteredBooks.Any())
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(2, "<h3>No books to display</h3>");
#nullable restore
#line 17 "C:\Users\anton\source\repos\NextIT.Assignment\NextIT.Assignment.BlazorApp\Pages\BooksPage.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(3, "table");
            __builder.AddAttribute(4, "class", "table");
            __builder.AddMarkupContent(5, @"<thead><tr><th colspan=""2"">Book</th>
            <th colspan=""4"">Borrowed to</th></tr>
        <tr><th>Book Name</th>
            <th>Book Author</th>
            <th>First Name</th>
            <th>Last Name</th>
            <th>Borrowed From</th>
            <th>Borrow/Free</th></tr></thead>
        ");
            __builder.OpenElement(6, "tbody");
#nullable restore
#line 36 "C:\Users\anton\source\repos\NextIT.Assignment\NextIT.Assignment.BlazorApp\Pages\BooksPage.razor"
         foreach (var book in _filteredBooks)
        {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(7, "tr");
            __builder.OpenElement(8, "td");
            __builder.AddContent(9, 
#nullable restore
#line 39 "C:\Users\anton\source\repos\NextIT.Assignment\NextIT.Assignment.BlazorApp\Pages\BooksPage.razor"
                     book.Name

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(10, "\r\n                ");
            __builder.OpenElement(11, "td");
            __builder.AddContent(12, 
#nullable restore
#line 40 "C:\Users\anton\source\repos\NextIT.Assignment\NextIT.Assignment.BlazorApp\Pages\BooksPage.razor"
                     book.Author

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
#nullable restore
#line 41 "C:\Users\anton\source\repos\NextIT.Assignment\NextIT.Assignment.BlazorApp\Pages\BooksPage.razor"
                 if (book.Borrowed != null)
                {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(13, "td");
            __builder.AddContent(14, 
#nullable restore
#line 43 "C:\Users\anton\source\repos\NextIT.Assignment\NextIT.Assignment.BlazorApp\Pages\BooksPage.razor"
                         book.Borrowed.FirstName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(15, "\r\n                    ");
            __builder.OpenElement(16, "td");
            __builder.AddContent(17, 
#nullable restore
#line 44 "C:\Users\anton\source\repos\NextIT.Assignment\NextIT.Assignment.BlazorApp\Pages\BooksPage.razor"
                         book.Borrowed.LastName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(18, "\r\n                    ");
            __builder.OpenElement(19, "td");
            __builder.AddContent(20, 
#nullable restore
#line 45 "C:\Users\anton\source\repos\NextIT.Assignment\NextIT.Assignment.BlazorApp\Pages\BooksPage.razor"
                         book.Borrowed.From

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(21, "\r\n                    ");
            __builder.OpenElement(22, "td");
            __builder.AddAttribute(23, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 46 "C:\Users\anton\source\repos\NextIT.Assignment\NextIT.Assignment.BlazorApp\Pages\BooksPage.razor"
                                    async () => await OnFreeClickAsync(book.Id)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(24, "<span class=\"oi oi-x\"></span>Free");
            __builder.CloseElement();
#nullable restore
#line 47 "C:\Users\anton\source\repos\NextIT.Assignment\NextIT.Assignment.BlazorApp\Pages\BooksPage.razor"
                }
                else
                {

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(25, "<td colspan=\"3\">Free to borrow</td>\r\n                    ");
            __builder.OpenElement(26, "td");
            __builder.AddAttribute(27, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 51 "C:\Users\anton\source\repos\NextIT.Assignment\NextIT.Assignment.BlazorApp\Pages\BooksPage.razor"
                                    async () => await OnBorrowClickAsync(book.Id)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(28, "<span class=\"oi oi-arrow-circle-right\"></span>Borrow");
            __builder.CloseElement();
#nullable restore
#line 52 "C:\Users\anton\source\repos\NextIT.Assignment\NextIT.Assignment.BlazorApp\Pages\BooksPage.razor"
                }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
#nullable restore
#line 54 "C:\Users\anton\source\repos\NextIT.Assignment\NextIT.Assignment.BlazorApp\Pages\BooksPage.razor"
        }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 57 "C:\Users\anton\source\repos\NextIT.Assignment\NextIT.Assignment.BlazorApp\Pages\BooksPage.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 60 "C:\Users\anton\source\repos\NextIT.Assignment\NextIT.Assignment.BlazorApp\Pages\BooksPage.razor"
       
    private IList<Book> _allBooks;
    private IList<Book> _filteredBooks;

    protected async override Task OnInitializedAsync()
    {
        base.OnInitializedAsync();
        await SetBooksAsync();
    }

    private async Task SetBooksAsync()
    {
        _allBooks = await BookService.GetAllBooksAsync();
        _filteredBooks = _allBooks;
    }

    private async Task OnFreeClickAsync(int bookId)
    {
        await BookService.FreeBookAsync(bookId);
        await SetBooksAsync();
    }

    private async Task OnBorrowClickAsync(int bookId)
    {
        NavManager.NavigateTo($"books/{bookId}");
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IBookService BookService { get; set; }
    }
}
#pragma warning restore 1591
