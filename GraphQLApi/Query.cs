using HotChocolate.Execution;
using SharedLib;
using SharedLib.BusinessLayer.Customers;
using SharedLib.Models;
using System.Data.Entity;
using static System.Net.WebRequestMethods;
using HotChocolate;
using HotChocolate.Data;
using System.Collections.Generic;
using GreenDonut;
using Newtonsoft.Json;
using GraphQL;
using Microsoft.Extensions.FileProviders;

namespace GraphQLApi
{
    public class Query
    {


        [UseProjection]
        public async Task<CustomerFile> GetCustomerFileByNameAsync(string firstname, string lastname)
        {
            if (string.IsNullOrWhiteSpace(firstname) || string.IsNullOrEmpty(lastname))
            {
                throw new ExecutionError("Invalid customer firstname or lastname");
            }
            using (var client = new HttpClient())
            {
                var uri_file = "http://host.docker.internal:63498/api/customerfiles/";
                var result_file = string.Empty;
                HttpResponseMessage response_file = await client.GetAsync(uri_file + firstname + "/" + lastname);
                result_file = await response_file.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<CustomerFile>(result_file) ?? throw new ExecutionError("Invalid customer name");
            }
        }

        [UseProjection]
        public async Task<List<Customer>> GetCustomersAsync()
        {

            using (var client = new HttpClient())
            {
                var uri = "http://host.docker.internal:63494/api/customers";
                var result = string.Empty;
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Customer>>(result) ?? throw new ExecutionError("No customers in DB");
                }
                else
                {
                    throw new ExecutionError("No customers in DB");
                }
            }
        }

        [UseProjection]
        public async Task<List<Product>> GetProductsAsync()
        {

            using (var client = new HttpClient())
            {
                var uri = "http://host.docker.internal:63492/api/products";
                var result = string.Empty;
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Product>>(result) ?? throw new ExecutionError("No products in DB");
                }
                else
                {
                    throw new ExecutionError("No products in DB");
                }
            }
        }
    }
}
