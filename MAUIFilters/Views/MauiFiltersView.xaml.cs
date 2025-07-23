using MAUIFilters.ViewModels;
using Microsoft.Maui.Controls.Shapes;
using Utilities;

namespace MAUIFilters.Views;

public partial class MauiFiltersView : ContentPage
{
	public MauiFiltersView()
	{
		InitializeComponent();
		BindingContext = new MauiFiltersViewModel();
	}

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
		var fromBackground =
			Overlay.Background as LinearGradientBrush;

		var toBackground =
			((sender as Grid).Children[1] as RoundRectangle).Fill as LinearGradientBrush;

		if(fromBackground == null)
		{
			fromBackground = new LinearGradientBrush
			{
				StartPoint = new Point(0, 0),
				EndPoint = new Point(1, 1),
				GradientStops =
				{
					new GradientStop(Colors.Transparent, 0),
                    new GradientStop(Colors.Transparent, 1),
                }
			};
		}


		Overlay.LinearGradientBrushTo(fromBackground, toBackground, length: 1000);

    }
}