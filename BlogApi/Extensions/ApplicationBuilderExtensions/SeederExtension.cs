using BlogApi.Services.Data.Contract;

namespace BlogApi.Extensions.SeederExtension;

public static class SeederExtension
{

    public static void UseSeeder(this IApplicationBuilder app)
    {

        using var scope = app.ApplicationServices.CreateScope();

        var seeder = scope.ServiceProvider.GetRequiredService<ISeeder>();

        seeder.StartSeed();
    }

}
