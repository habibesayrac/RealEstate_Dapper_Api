﻿namespace RealEstate_Dapper_Api.Models.Dtos.ProductImageDtos
{
    public class GetProductImageByProductIdDto
    {
        public int ProductImageId { get; set; }
        public string ImageUrl { get; set; }
        public int ProductId { get; set; }
    }
}
