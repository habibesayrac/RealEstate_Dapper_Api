﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ProductDetailDtos;
using RealEstate_Dapper_UI.Dtos.ProductDtos;

namespace RealEstate_Dapper_UI.Controllers
{
    public class PropertyController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PropertyController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44352/api/Products/ProductListWithCategory");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> PropertyListWithSearch(string searchKeyValue, int productCategoryId, string city)
        {
            ViewBag.v = TempData["word"];
            ViewBag.y = TempData["word1"];

            searchKeyValue = "daire";
            productCategoryId = 1;
            city = "izmir";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44352/api/Products/ResultProductWithSearchList?searchKeyValue=[searchKeyValue]&productCategoryId=[productCategoryId]&city=[city]");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductWithSearchListDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> PropertySingle(int id)
        {
            id = 8;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44352/api/Products/GetProductByProductId?id=" + id);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<ResultProductDto>(jsonData);

            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("https://localhost:44352/api/ProductDetails/GetProductDetailByProductId?id=" + id);
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            var values2 = JsonConvert.DeserializeObject<GetProductDetailByIdDto>(jsonData2);


            ViewBag.productId = values.productID;
            ViewBag.price = values.price;
            ViewBag.city = values.city;
            ViewBag.district = values.district;
            ViewBag.address = values.address;
            ViewBag.type = values.type;
            ViewBag.description = values.description;

            ViewBag.bathCount = values2.bathCount;
            ViewBag.bedCount = values2.bedRoomCount;
            ViewBag.size = values2.productSize;
            ViewBag.roomCount = values2.roomCount;
            ViewBag.garageCount = values2.garageSize;
            ViewBag.buildYear = values2.buildYear;
            ViewBag.date = values2.advertisementDate;
            ViewBag.location = values2.location;
            ViewBag.videoUrl = values2.videoUrl;

            DateTime date1 =DateTime.Now;
            DateTime date2 = values.advertisementDate;
            TimeSpan timeSpan = date1 - date2;
            int month = timeSpan.Days;

            ViewBag.datediff = month / 30;
          
            return View();

        }
    }
}