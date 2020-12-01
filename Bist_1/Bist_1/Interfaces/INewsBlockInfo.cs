using System;

namespace Bist_1.Interfaces
{
    public interface INewsBlockInfo
    {
        int NewsBlockId { get; set; }
        int EnterpriseId { get; set; }
        string Title { get; set; }
        string Text { get; set; }
        string ImageUrl { get; set; }
        DateTime CreatedDate { get; set; }
    }
}
