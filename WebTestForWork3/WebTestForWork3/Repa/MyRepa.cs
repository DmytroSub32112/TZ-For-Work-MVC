using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTestForWork3.Entety;
using WebTestForWork3.Models;

namespace WebTestForWork3.Repa
{
    public static class MyRepa 
    {
        public static void MapCreate(string name, string nameorders, int price,int quantity)
        {
            using(var db = new Context())
            {
                if (name != null || nameorders != null || price != 0 || quantity != 0)
                {
                    var random = new Random();
                    var rm = random.Next(100000);
                    var order = new Order();
                    order.Amount = price * quantity;
                    order.Date = DateTime.Now.ToLongDateString();
                    order.NameOfTheClient = name;
                    order.NumberForOrder = rm;
                    var position = new OrderPosition();
                    position.Name = nameorders;
                    position.Quantity = quantity;
                    position.Price = price;
                    position.Order = order;
                    db.Orders.Add(order);
                    db.OrderPositions.Add(position);
                    db.SaveChanges();
                }
                else { db.SaveChanges(); }
            }
        }
        public static List<Order> MapGet()
        {
            using (var db = new Context())
            {
                var modelsOrderd = db.Orders.Include(c => c.Positions).ToList();
                
                return modelsOrderd;
            }
        }
        public static void MapDeleteForNumber(int number)
        {
            using (var db = new Context())
            {             
              var order = db.Orders.Where(c => c.Id == number).FirstOrDefault();
              
                if (order != null)
                {
                    db.Orders.Remove(order);
                    db.SaveChanges();
                }
            }
        }
        public static void MapUpdate( int Id,string positionName, int price, int quantity)
        {
            using (var db = new Context())
            {
                var order = db.Orders.Include(c => c.Positions).Where(c => c.Id == Id).FirstOrDefault();

                if (order != null) 
                {
                    if (positionName != null && price != 0 && quantity != 0)
                    {
                        order.Amount = price;
                        foreach (var item in order.Positions)
                        {
                            item.Name = positionName;
                            item.Price = price;
                            item.Quantity = quantity;
                        }
                        db.SaveChanges();
                    }
                    if (positionName != null && price != 0 )
                    {
                        order.Amount = price;
                        foreach (var item in order.Positions)
                        {
                            item.Name = positionName;
                            item.Price = price;
                        }
                        db.SaveChanges();
                    }
                    if (positionName != null)
                    {
                        order.Amount = price;
                        foreach (var item in order.Positions)
                        {
                            item.Name = positionName;
                        }
                        db.SaveChanges();
                    }
                    else
                    {
                        db.SaveChanges();
                    }
                }
            }          
        }
        public static void MapAddPosition( int Id,string name, int price, int quantity )
        {
            using (var db = new Context())
            {
                var order = db.Orders.Include(c => c.Positions).Where(c => c.Id == Id).FirstOrDefault();

                if (order != null)
                {
                    db.OrderPositions.Include(c => c.OrderId);
                    var orderPosition = new OrderPosition();
                    orderPosition.Name = name;
                    orderPosition.Price = price;
                    orderPosition.Quantity = quantity;
                    orderPosition.OrderId = Id;
                    db.OrderPositions.Add(orderPosition);
                    var amount = 0;
                   
                    foreach (var item in order.Positions)
                    {
                        amount += item.Price * item.Quantity;
                    }
                    order.Amount = amount;
                    if (amount != 0)
                    {
                        db.SaveChanges();
                    }
                }
            }
        }
        public static List<Order> MapSort(string str)
        {
            using (var db = new Context())
            {                
                if (str == "Id")
                {
                    var order = db.Orders.Include(c => c.Positions).OrderBy(c => c.Id).ToList();
                    return order;
                }
                if (str == "Date")
                {
                    var order = db.Orders.Include(c => c.Positions).OrderBy(c => c.Date).ToList();
                    return order;
                }
                if (str == "Amount")
                {
                    var order = db.Orders.Include(c => c.Positions).OrderBy(c => c.Amount).ToList();
                    return order;
                }
                if (str == "Name")
                {
                    var order = db.Orders.Include(c => c.Positions).OrderBy(c => c.NameOfTheClient).ToList();
                    return order;
                }
                else { return null; }
            }
        }
    }
}
