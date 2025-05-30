# Recipe App UI

.NET MAUI mobile app that displays cooking recipes. Recipes are pulled from a headless Umbraco app using the Content Delivery API. Umbraco app can be found [here](https://github.com/MylesB93/RecipeAppAPI).

## Overview
This is a cross-platform mobile application built using .NET MAUI (Multi-platform App UI) that allows users to browse and view cooking recipes. The app follows the MVVM (Model-View-ViewModel) architecture pattern and integrates with a headless Umbraco CMS backend for content management.

## Features
- Cross-platform support (iOS, Android)
- Recipe browsing and viewing
- Integration with Umbraco Content Delivery API
- Modern UI with custom fonts
- Secure API key management

## Project Structure
```
├── RecipeAppUI/              # Main UI project
│   ├── Views/                # XAML Views
│   ├── ViewModels/          # MVVM ViewModels
│   ├── Resources/           # App resources and assets
│   └── Platforms/           # Platform-specific code
├── RecipeAppUI.Core/        # Core business logic
│   ├── Services/            # Business services
│   ├── Models/              # Data models
│   ├── Interfaces/          # Service interfaces
│   └── Helpers/             # Utility classes
```

## Prerequisites
- .NET 9.0 or later
- Visual Studio 2022 with .NET MAUI workload
- Access to Umbraco Recipe API (API key required)

## Setup
1. Clone the repository
2. Create an `appsettings.json` file in the RecipeAppUI project with the following structure:
   ```json
   {
     "RecipeAPI": {
       "BaseUrl": "your_api_base_url"
     },
     "RecipeApp": {
       "APIKey": "your_api_key"
     }
   }
   ```
3. Build and run the application

## Dependencies
- CommunityToolkit.Maui - UI components and utilities
- Microsoft.Extensions.Configuration - Configuration management
- HttpClient - API communication

## Configuration
The application uses a combination of `appsettings.json` and user secrets for configuration. The base URL for the Umbraco API and the API key should be configured before running the application.

## Related Projects
- [Recipe App API](https://github.com/MylesB93/RecipeAppAPI) - Headless Umbraco backend for this application