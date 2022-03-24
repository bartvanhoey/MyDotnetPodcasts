using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDotnetPodcasts.ViewModels
{
    [INotifyPropertyChanged]
    public partial class CategoriesViewModel
    {


        public async Task InitializeAsync()
        {
            //var categories = await showsService.GetAllCategories();

            //Categories = categories?.ToList();

            await Task.CompletedTask;
        }

    }
}
