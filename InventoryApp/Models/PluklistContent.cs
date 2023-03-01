﻿using InventoryApp.Pages.Pluklist;

namespace InventoryApp.Models
{
    public class PluklistContent
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Forsendelse { get; set; }
        public string Adresse { get; set; }
        public ICollection<Item> Lines { get; set; }
    }
}