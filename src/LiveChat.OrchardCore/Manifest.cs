using OrchardCore.Modules.Manifest;

[assembly: Module(
    Name = "Live Chat",
    Author = "David Hayden",
    Website = "http://www.davidhayden.me",
    Version = "2.0.0",
    Description = "Provides settings for adding live chat functionality to website.",
    Dependencies = new [] { "OrchardCore.Admin", "OrchardCore.Resources" },
    Category = "Content"
)]