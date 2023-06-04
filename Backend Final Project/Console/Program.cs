using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Threading;
using Domain.Dtos;
using Domain.Entities;
using Microsoft.AspNetCore.SignalR.Client;
using Domain.Enums;

namespace ConsoleApp
{
    class Program
    {
        static async Task Main()
        {
            // var hubConnection = new HubConnectionBuilder()
            //     .WithUrl("http://localhost:5210/Hubs/SeleniumLogHub")
            //     .WithAutomaticReconnect()
            //     .Build();
            //
            // await hubConnection.StartAsync();
            //
            // await hubConnection.InvokeAsync("SendLogNotificationAsync", CreateLog("Bot started.", OrderStatus.BotStarted));

            IWebDriver driver = new ChromeDriver();

            DateTime rightNow = DateTime.Now;
            Console.WriteLine("Website logged in. --- " + rightNow.ToString("dd.MM.yyyy : HH:mm"));

            List<Product> productList = new List<Product>();

            string selection = "";
            while (selection != "1" && selection != "2" && selection != "3")
            {
                Console.WriteLine("What kind of products do you want to crawl?" +
                    "\n1-Sale Price Products \n2-Normal Price Products \n3-All Kind of Products)");
                selection = Console.ReadLine();
            }

            int amount = 0;
            while (amount <= 0)
            {
                Console.WriteLine("How many products do you want to crawl?");
                int.TryParse(Console.ReadLine(), out amount);
            }

            //await hubConnection.InvokeAsync("SendLogNotificationAsync", CreateLog("Crawling started", OrderStatus.CrawlingStarted));

            string url = "https://finalproject.dotnet.gg/?currentPage=";
            int itemsFetched = 0;
            int pageIndex = 1;

            List<Product> allProducts = new List<Product>();

            while (true)
            {
                driver.Navigate().GoToUrl(url + pageIndex);
                Thread.Sleep(1000);

                var products = driver.FindElements(By.XPath("/html/body/section/div/div/div/div/img"));
                var productCards = driver.FindElements(By.ClassName("card-body"));

                for (int i = 0; i < products.Count; i++)
                {
                    string pictureUrl = products[i].GetAttribute("src");
                    string name = productCards[i].FindElement(By.ClassName("product-name")).Text.Trim();

                    var priceElements = productCards[i].FindElements(By.CssSelector(".price, .sale-price"));


                    bool hasSale = false;
                    decimal SalePrice = 0;
                    decimal Price = 0;

                    foreach (var priceElement in priceElements)
                    {
                        if (priceElement.GetAttribute("class").Contains("sale-price"))
                        {
                            hasSale = true;
                            SalePrice = Decimal.Parse(priceElement.Text.Trim('$'));
                        }
                        else if (priceElement.GetAttribute("class").Contains("price"))
                        {
                            Price = Decimal.Parse(priceElement.Text.Trim('$'));
                        }

                    }

                    if ((selection == "1" && hasSale) || (selection == "2" && !hasSale) || selection == "3")
                    {
                        allProducts.Add(new Product(name, pictureUrl, SalePrice, Price));
                    }
                }

                if (products.Count == 0)
                {
                    break;
                }

                pageIndex++;

                //await hubConnection.InvokeAsync("SendLogNotificationAsync", CreateLog($"{pageIndex}. crawling completed.", OrderStatus.CrawlingCompleted));
            }

            allProducts = ApplyProductFilter(selection, allProducts);

            while (itemsFetched < amount && allProducts.Count > 0)
            {
                int randomIndex = new Random().Next(allProducts.Count);
                Product randomProduct = allProducts[randomIndex];
                productList.Add(randomProduct);
                allProducts.RemoveAt(randomIndex);
                itemsFetched++;
            }

            driver.Quit();

            Console.WriteLine($"Total {itemsFetched} products found");

            //await hubConnection.InvokeAsync("SendLogNotificationAsync", CreateLog("Crawling completed.", OrderStatus.CrawlingCompleted));

            foreach (Product product in productList)
            {
                Console.WriteLine("Product Name: " + product.Name);
                Console.WriteLine("Picture: " + product.Picture);
                Console.WriteLine("Price: " + product.Price);
                Console.WriteLine("Discound Price: " + product.SalePrice);
                Console.WriteLine();
            }

            //await hubConnection.InvokeAsync("SendLogNotificationAsync", CreateLog("Order completed.", OrderStatus.OrderCompleted));
        }

        static List<Product> ApplyProductFilter(string selection, List<Product> products)
        {
            switch (selection)
            {
                case "1":
                    return ProductFilter.FilterBySalePrice(products);
                case "2":
                    return ProductFilter.FilterByPrice(products);
                case "3":
                    return ProductFilter.FilterAll(products);
                default:
                    return products;
            }
        }

        static SeleniumLogDto CreateLog(string message, OrderStatus status) => new SeleniumLogDto(message, status);
    }
}

