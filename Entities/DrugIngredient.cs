namespace DrugInfo.Api.Entities
{
    public class DrugIngredient
    {
        public int DrugId { get; set; }
        public Drug? Drug { get; set; }

        public int IngredientId { get; set; }
        public Ingredient? Ingredient { get; set; }
    }
}
