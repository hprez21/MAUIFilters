using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIFilters.ViewModels
{
    public partial class MauiFiltersViewModel : ObservableObject
    {

        [ObservableProperty]
        ImageSource _currentImage;

        public MauiFiltersViewModel()
        {
            CurrentImage = ImageSource.FromFile("placeholder.jpg");
        }


        [RelayCommand]
        public async Task TakePhoto()
        {
            if (MediaPicker.Default.IsCaptureSupported)
            {
                FileResult photo = await MediaPicker.Default.CapturePhotoAsync();

                if (photo != null)
                {
                    // save the file into local storage
                    string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);

                    using Stream sourceStream = await photo.OpenReadAsync();
                    using FileStream localFileStream = File.OpenWrite(localFilePath);

                    await sourceStream.CopyToAsync(localFileStream);

                    CurrentImage = ImageSource.FromFile(localFilePath);

                }
            }
        }
    }
}
