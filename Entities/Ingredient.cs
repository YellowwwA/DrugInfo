namespace DrugInfo.Api.Entities
{
    public class Ingredient
    {
        public int IngredientId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Pharmacology { get; set; } = string.Empty;

        public ICollection<DrugIngredient> DrugIngredients { get; set; }
            = new List<DrugIngredient>();
    }
}
