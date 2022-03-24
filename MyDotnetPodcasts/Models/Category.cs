using MyDotnetPodcasts.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDotnetPodcasts.Models
{
    public class Category
    {
        public Category(CategoryResponse response)
        {
           
        }

        public Guid Id { get; set; }

        public string Genre { get; set; }
    }
}
