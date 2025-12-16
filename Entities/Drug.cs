using System;

namespace DrugInfo.Api.Entities
{
    public class Drug
    {
        public int DrugId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Manufacturer { get; set; } = string.Empty;
        public string DosageForm { get; set; } = string.Empty;
        public DateTime ApprovalDate { get; set; }

        public ICollection<DrugIngredient> DrugIngredients { get; set; }
            = new List<DrugIngredient>();
    }
}
