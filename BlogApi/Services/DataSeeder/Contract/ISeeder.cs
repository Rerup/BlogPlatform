using System;

namespace BlogApi.Services.DataSeeder.Contract;

public interface ISeeder
{
    public Task StartSeed();
}
