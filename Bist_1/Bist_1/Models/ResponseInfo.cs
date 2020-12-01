using System.Collections.Generic;

namespace Bist_1.Models
{
    public class ResponseInfo
    {
        public bool IsSuccess => StatusCode >= 200 && StatusCode < 300;
        public int StatusCode { get; set; }
        public string Content { get; set; }
        public byte[] BinaryContent { get; set; }
        public Dictionary<string, string> Headers { get; set; }
    }
}