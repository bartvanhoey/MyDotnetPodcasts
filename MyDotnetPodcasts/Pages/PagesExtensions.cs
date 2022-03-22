using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDotnetPodcasts.Pages
{
    public static class PagesExtensions
    {

        public static MauiAppBuilder ConfigurePages(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<DiscoverPage>();
                       
            
            return builder;
        }


    }
}
