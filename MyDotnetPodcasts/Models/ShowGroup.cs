using MyDotnetPodcasts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDotnetPodcasts.Models
{
    public class ShowGroup : List<ShowViewModel>
    {
        public ShowGroup(string name, List<ShowViewModel> showViewModels) : base(showViewModels)
        {
            Name=name;
        }

        public string Name { get; }
    }
}
