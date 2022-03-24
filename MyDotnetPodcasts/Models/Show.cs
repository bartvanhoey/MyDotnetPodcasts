using CommunityToolkit.Mvvm.ComponentModel;
using MyDotnetPodcasts.Models.Responses;
using MyDotnetPodcasts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDotnetPodcasts.Models
{
    public class Show : ObservableObject
    {
        public Show(ShowResponse response, ListenLaterService listenLaterService)
        {
            Id = response.Id;
            Title = response.Title;
            Author = response.Author;
            Description = response.Description;
            Image = response.Image;
            Updated = response.Updated;
            Episodes = response.Episodes?.Select(resp => new Episode(resp, listenLaterService));
            Categories = response.Categories?.Select(resp => new Category(resp));
        }


        public Guid Id { get; set; }
        public string Title { get; set; }

        public string Author { get; set; }

        public string Description { get; set; }

        public Uri Image { get; set; }

        public DateTime Updated { get; set; }

        public IEnumerable<Episode> Episodes { get; set; }
        public IEnumerable<Category> Categories{ get; set; }



    }
}
