﻿using System;
using System.Collections.Generic;
using System.Data;

namespace ProductReviewManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to product review management");
            //Product Review List
            List<ProductReview> productReviewList = new List<ProductReview>()
            {
                new ProductReview() { ProductId = 1, UserId = 1, Rating = 2, Review = "Good", IsLike = true },
                new ProductReview() { ProductId = 2, UserId = 1, Rating = 4, Review = "Good", IsLike = true },
                new ProductReview() { ProductId = 3, UserId = 2, Rating = 5, Review = "Good", IsLike = true },
                new ProductReview() { ProductId = 4, UserId = 3, Rating = 6, Review = "Good", IsLike = false },
                new ProductReview() { ProductId = 5, UserId = 1, Rating = 2, Review = "nice", IsLike = true },
                new ProductReview() { ProductId = 6, UserId = 6, Rating = 1, Review = "bad", IsLike = true },
                new ProductReview() { ProductId = 8, UserId = 4, Rating = 1, Review = "Good", IsLike = false },
                new ProductReview() { ProductId = 8, UserId = 8, Rating = 9, Review = "nice", IsLike = true },
                new ProductReview() { ProductId = 2, UserId = 1, Rating = 10, Review = "Good", IsLike = true },
                new ProductReview() { ProductId = 10, UserId = 2, Rating = 8, Review = "Excellent", IsLike = true },
                new ProductReview() { ProductId = 11, UserId = 4, Rating = 3, Review = "nice", IsLike = true },
                new ProductReview() { ProductId = 8, UserId = 3, Rating = 5, Review = "nice", IsLike = true },
                new ProductReview() { ProductId = 9, UserId = 4, Rating = 2, Review = "bad", IsLike = false },
                new ProductReview() { ProductId = 2, UserId = 5, Rating = 7, Review = "Good", IsLike = true },
                new ProductReview() { ProductId = 4, UserId = 8, Rating = 3, Review = "bad", IsLike = true },
                new ProductReview() { ProductId = 11, UserId = 3, Rating = 6, Review = "nice", IsLike = false },
                new ProductReview() { ProductId = 7, UserId = 5, Rating = 8, Review = "Good", IsLike = true },
                new ProductReview() { ProductId = 6, UserId = 1, Rating = 7, Review = "nice", IsLike = false },
                new ProductReview() { ProductId = 4, UserId = 3, Rating = 7, Review = "nice", IsLike = false },
                new ProductReview() { ProductId = 9, UserId = 2, Rating = 4, Review = "bad", IsLike = true },
                new ProductReview() { ProductId = 3, UserId = 7, Rating = 6, Review = "nice", IsLike = true },
                new ProductReview() { ProductId = 1, UserId = 1, Rating = 8, Review = "nice", IsLike = false },
                new ProductReview() { ProductId = 8, UserId = 1, Rating = 9, Review = "Good", IsLike = false },
                new ProductReview() { ProductId = 5, UserId = 1, Rating = 4, Review = "bad", IsLike = true },
                new ProductReview() { ProductId = 10, UserId = 1, Rating = 7, Review = "nice", IsLike = true },
            };
            foreach (var list in productReviewList)
            {
                Console.WriteLine("ProductID: " + list.ProductId + "UserId: " + list.UserId + "Rating: " + list.Rating
                    + "Review: " + list.Review + "IsLike: " + list.IsLike);
            }
            Management management = new Management();
            //Getting Top 3 rated records
            management.TopRecords(productReviewList);
            //Select specific records with id = 1, 4, 9 and rating > 3
            management.SelectRecords(productReviewList);
            //Counts products by product id
            management.RetrieveCountOfRecords(productReviewList);
            //Gets Product id and reviews
            management.RetrieveProductIdAndReview(productReviewList);
            //Get all product records except top 5
            management.RetrieveProductsBySkippingTop5(productReviewList);
            //Converts list to table
            DataTable table = management.AddToDataTable(productReviewList);
            //Retrieves products with isLike = true
            management.RetrieveIsLikeTrueProductsFromDataTable(table);
            //Average of ratings grouped by productId
            management.GetAverageRatingByProductId(table);
            //nice review products retrieved
            management.RetrieveNiceReviewProductsFromDataTable(table);
            //Order products of user id = 1 by rating
            management.OrderProductsByRating(1, table);
        }
    }
}
