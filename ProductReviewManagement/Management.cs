﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
namespace ProductReviewManagement
{
    class Management
    {
        ////Datatable for product records
        //public readonly DataTable dataTable = new DataTable();
        /// <summary>
        /// Top rated 3 products are selected from list
        /// </summary>
        /// <param name="listProductReview"></param>
        public void TopRecords(List<ProductReview> listProductReview)
        {
            var recordedData = (from productReviews in listProductReview
                                orderby productReviews.Rating descending
                                select productReviews).Take(3);
            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductID: " + list.ProductId + "UserId: " + list.UserId + "Rating: " + list.Rating
                    + "Review: " + list.Review + "IsLike: " + list.IsLike);
            }
        }
        /// <summary>
        /// Select specific records with id = 1, 4, 9 and rating > 3
        /// </summary>
        /// <param name="listProductReview"></param>
        public void SelectRecords(List<ProductReview> listProductReview)
        {
            var recordedData = (from productReviews in listProductReview
                                where (productReviews.ProductId == 1 || productReviews.ProductId == 4 || productReviews.ProductId == 9)
                                && productReviews.Rating > 3
                                select productReviews);
            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductID: " + list.ProductId + "UserId: " + list.UserId + "Rating: " + list.Rating
                    + "Review: " + list.Review + "IsLike: " + list.IsLike);
            }
        }
        /// <summary>
        /// Counts products by product id
        /// </summary>
        /// <param name="listProductReview"></param>
        public void RetrieveCountOfRecords(List<ProductReview> listProductReview)
        {
            var recordedData = listProductReview.GroupBy(x => x.ProductId).Select(x => new { ProductId = x.Key, Count = x.Count() });
            foreach (var list in recordedData)
            {
                Console.WriteLine(list.ProductId + "------" + list.Count);
            }
        }
        /// <summary>
        /// Retrieves product id and review of products
        /// </summary>
        /// <param name="listProductReview"></param>
        public void RetrieveProductIdAndReview(List<ProductReview> listProductReview)
        {
            var recordedData = from productReviews in listProductReview
                               select new
                               {
                                   productReviews.ProductId,
                                   productReviews.Review
                               };
            foreach (var list in recordedData)
            {
                Console.WriteLine("Product Id:- " + list.ProductId + " " + "Review: " + list.Review);
            }
        }
        /// <summary>
        /// Retrieves products from list by skipping top 5 records
        /// </summary>
        /// <param name="listProductReview"></param>
        public void RetrieveProductsBySkippingTop5(List<ProductReview> listProductReview)
        {
            var recordedData = (from productReviews in listProductReview
                                select productReviews).Skip(5);
            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductID: " + list.ProductId + "UserId: " + list.UserId + "Rating: " + list.Rating
                    + "Review: " + list.Review + "IsLike: " + list.IsLike);
            }
        }
        /// <summary>
        /// Adds data to the DataTable
        /// </summary>
        /// <param name="listProductReviews"></param>
        public DataTable AddToDataTable(List<ProductReview> listProductReviews)
        {
            DataTable table = new DataTable();
            table.Columns.Add("ProductId", typeof(int));
            table.Columns.Add("UserId", typeof(int));
            table.Columns.Add("Rating", typeof(double));
            table.Columns.Add("Review", typeof(string));
            table.Columns.Add("IsLike", typeof(bool));
            foreach (ProductReview product in listProductReviews)
            {
                table.Rows.Add(product.ProductId, product.UserId, product.Rating, product.Review, product.IsLike);
            }
            return table;
        }
        /// <summary>
        /// Retrieve all data from datatable
        /// </summary>
        /// <param name="table"></param>
        public void RetrieveData(DataTable table)
        {
            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn column in table.Columns)
                {
                    Console.Write(row[column] + "\t");
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Retrieves products with IsLike = true
        /// </summary>
        /// <param name="table"></param>
        public void RetrieveIsLikeTrueProductsFromDataTable(DataTable table)
        {
            var recordedData = from products in table.AsEnumerable()
                               where products.Field<bool>("IsLike") == true
                               select products;
            foreach (var row in recordedData)
            {
                Console.Write(row.Field<int>("ProductId") + "\t" + row.Field<int>("UserId") + "\t" + row.Field<double>("Rating") + "\t" + row.Field<string>("Review") + "\t" + row.Field<bool>("IsLike") + "\n");
            }
        }
        /// <summary>
        /// Gets average rating according to productId
        /// </summary>
        /// <param name="table"></param>
        public void GetAverageRatingByProductId(DataTable table)
        {
            var recordedData = from products in table.AsEnumerable()
                               group products by products.Field<int>("ProductId") into g
                               select new { ProductId = g.Key, Average = g.Average(a => a.Field<double>("Rating")) };
            foreach (var row in recordedData)
            {
                Console.Write(row.ProductId + "\t" + row.Average + "\n");
            }
        }
        /// <summary>
        /// Retrieves products which contain nice in their review
        /// </summary>
        /// <param name="table"></param>
        public void RetrieveNiceReviewProductsFromDataTable(DataTable table)
        {
            var recordedData = from products in table.AsEnumerable()
                               where products.Field<string>("Review").Contains("nice")
                               select products;
            foreach (var row in recordedData)
            {
                Console.Write(row.Field<int>("ProductId") + "\t" + row.Field<int>("UserId") + "\t" + row.Field<double>("Rating") + "\t" + row.Field<string>("Review") + "\t" + row.Field<bool>("IsLike") + "\n");
            }
        }
        public void OrderProductsByRating(int userId, DataTable table)
        {
            var recodedData = from products in table.AsEnumerable()
                              where products.Field<int>("UserId") == userId
                              orderby products.Field<double>("Rating")
                              select products;
            foreach (var row in recodedData)
            {
                Console.Write(row.Field<int>("ProductId") + "\t" + row.Field<int>("UserId") + "\t" + row.Field<double>("Rating") + "\t" + row.Field<string>("Review") + "\t" + row.Field<bool>("IsLike") + "\n");
            }
        }
    }
}
