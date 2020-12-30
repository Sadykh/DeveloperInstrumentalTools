using System;

namespace WebApplication.EFCore
{
    public class NewsDto
    {
        public DateTime TimeStamp { get; set; }

        public decimal Title { get; set; }

        public string User { get; set; }
    }
}