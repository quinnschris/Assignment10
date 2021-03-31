using System;
namespace Assignment10.Models.ViewModels
{
    // Stores all information needed for numbering purposes. Cha ching

    public class PageNumberingInfo
    {
        public int NumItemsPerPage { get; set; }

        public int CurrentPage { get; set; }

        public int TotalNumItems { get; set; }

        // Calculate number of pages

        public int NumPages => (int)(Math.Ceiling((decimal)TotalNumItems / NumItemsPerPage)); 
    }
}
