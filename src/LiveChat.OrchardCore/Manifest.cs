using OrchardCore.Modules.Manifest;

[assembly: Module(
    Name = "Live Chat",
    Author = "David Hayden",
    Website = "https://www.davidhayden.me",
    Version = "1.0.0-rc2",
    Description = "Provides settings for adding live chat functionality to website.",
    Dependencies = new [] { "OrchardCore.Admin", "OrchardCore.Resources" },
    Category = "Content"
)]