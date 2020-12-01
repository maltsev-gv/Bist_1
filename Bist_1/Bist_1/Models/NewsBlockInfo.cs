using System;
using Bist_1.Interfaces;
using Bist_1.ViewModels;

namespace Bist_1.Models
{
    public class NewsBlockInfo : ObservableObject, INewsBlockInfo
    {
        public int NewsBlockId { get; set; }

        public int EnterpriseId { get; set; }

        public string Title
        {
            get => GetVal<string>();
            set => SetVal(value);
        }

        public string Text { get; set; }

        public string ImageUrl { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
