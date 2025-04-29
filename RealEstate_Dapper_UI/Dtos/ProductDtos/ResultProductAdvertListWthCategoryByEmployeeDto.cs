namespace RealEstate_Dapper_UI.Dtos.ProductDtos
{
    public class ResultProductAdvertListWthCategoryByEmployeeDto
    {
        public int productID { get; set; }
        public string title { get; set; }
        public decimal price { get; set; }
        public string city { get; set; }
        public string district { get; set; }
        public int categoryName { get; set; }
        public string coverimage { get; set; }
        public string type { get; set; }
        public string address { get; set; }
        public bool dealOfTheDay { get; set; }
    }
}
