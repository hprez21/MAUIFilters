# MAUIFilters

A .NET MAUI application designed to practice and demonstrate **Markup Extensions** concepts through a photo filter interface with custom gradient effects.

<img width="848" height="478" alt="l-9" src="https://github.com/user-attachments/assets/19bf0171-79c0-4bb8-b8ca-299b2ffed3a4" />

## 📋 Project Overview

MAUIFilters is an educational project that showcases the power of **XAML Markup Extensions** in .NET MAUI. The application features a photo filtering interface where users can take photos and apply various gradient filters to them. The main focus is on demonstrating how to create and use custom markup extensions to simplify XAML code and create reusable components.

### Key Learning Objectives:
- Understanding XAML Markup Extensions in .NET MAUI
- Creating custom markup extensions for reusable UI components
- Implementing gradient brushes programmatically
- Working with photo capture and display in MAUI
- MVVM pattern implementation with CommunityToolkit.Mvvm

## 🏗️ Project Structure

The project follows the standard .NET MAUI structure with additional organization for educational purposes:

### Core Components

#### **Extensions/** 
- `GradientsExtension.cs` - Custom markup extension for creating linear gradient brushes

#### **Views/**
- `MauiFiltersView.xaml/.cs` - Main UI displaying photo and filter options

#### **ViewModels/**
- `MauiFiltersViewModel.cs` - MVVM implementation handling photo capture and display logic

#### **Resources/**
- `Images/` - Contains placeholder images and app resources
- `Styles/` - XAML styles and color definitions
- `Fonts/` - Custom fonts (OpenSans)

#### **Platforms/**
- Platform-specific configurations for Android, iOS, Windows, MacCatalyst, and Tizen

### Key Files Breakdown

**GradientsExtension.cs** - The heart of the markup extension learning:
```csharp
public class GradientsExtension : IMarkupExtension<LinearGradientBrush>
{
    public string Colors { get; set; }
    public string Direction { get; set; }
    // Implementation handles color parsing and gradient creation
}
```

**XAML Usage Examples:**
```xml
<!-- Simple two-color gradient -->
<RoundRectangle Fill="{extension:Gradients Colors='#0000FF,#FF0000', Direction=d}" />

<!-- Multi-color gradient -->
<RoundRectangle Fill="{extension:Gradients Colors='#D16BA5,#86A8E7,#5FFBF1', Direction=U}" />
```

### Features Demonstrated

1. **Custom Markup Extension Creation**
   - Implementing `IMarkupExtension<T>` interface
   - Parameter validation and error handling
   - Dynamic gradient generation

2. **Direction Support**
   - `U` - Up (bottom to top)
   - `D` - Down (top to bottom) 
   - `L` - Left (right to left)
   - `R` - Right (left to right)

3. **Color Parsing**
   - Hex color format validation (#FFFFFF)
   - Automatic gradient stop calculation
   - Multi-color gradient support

4. **Photo Integration**
   - Camera capture functionality
   - Image display with overlay effects
   - Tap-to-capture interaction

## 📱 Project Images

### Main Interface
The application features a clean, dark-themed interface with:
- Full-screen photo display area
- Grid of gradient filter options below
- Each filter shows a preview with descriptive names

### Filter Examples
The app includes several pre-defined gradient filters:

1. **BluRedient** - Blue to Red vertical gradient (`#0000FF,#FF0000`)
2. **Sunflare** - Yellow to Red upward gradient (`#FFFF00,#FF0000`) 
3. **LimeLight** - Green to Yellow upward gradient (`#00FF00,#FFFF00`)
4. **Multi-color gradients** - Complex gradients with 3+ colors

### UI Features
- Rounded rectangle containers with shadows
- Responsive grid layout (3 columns × 3 rows)
- Interactive tap gestures for filter selection
- Smooth gradient transitions
- Professional styling with proper spacing and typography

### Technical Highlights
- Clean separation of concerns with MVVM pattern
- Reusable markup extension reducing XAML redundancy
- Cross-platform compatibility
- Modern MAUI UI controls and styling

This project serves as an excellent learning resource for developers wanting to understand how markup extensions can simplify XAML development and create more maintainable, reusable UI components in .NET MAUI applications.
