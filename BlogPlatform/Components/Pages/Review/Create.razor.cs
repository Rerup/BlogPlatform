using System;
using Blazored.Toast.Services;
using BlogPlatform.Services.Contracts;
using Domain.BlogDomain;
using Microsoft.AspNetCore.Components;

namespace BlogPlatform.Components.Pages.Review;

public class CreateBase : ComponentBase
{

    [Parameter]
    public int BlogId { get; set; }

    public Blog Blog { get; set; }

    [Inject]
    private IClientBlogService _blogService { get; set; }

    [Inject]
    private IToastService _toastService { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Blog = await _blogService.GetBlogAsync(BlogId);
    }

    public async Task HandleRating(int rating)
    {

        Blog.Rating = rating;

        await _blogService.UpdateBlogAsync(Blog);

        _toastService.ShowSuccess("Rating updated!");

    }

}
