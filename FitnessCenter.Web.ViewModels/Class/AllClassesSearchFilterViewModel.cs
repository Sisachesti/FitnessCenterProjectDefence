using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter.Web.ViewModels.Class
{
    public class AllClassesSearchFilterViewModel
    {
        public IEnumerable<AllClassesIndexViewModel>? Classes { get; set; }
        public string? SearchQuery { get; set; }
        public int? CurrentPage { get; set; } = 1;
        public int? EntitiesPerPage { get; set; } = 5;
        public int? TotalPages { get; set; }
    }
}
