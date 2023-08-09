using WebApplication2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Repo
{
    public class Orderclass : Iorder<OrderDetail>
    {
        private readonly WarehouseContext db;
       
        public Orderclass(WarehouseContext _db)
        {
            db = _db;
        }

        public string AddNewOrder(OrderDetail p)
        {
            string message;
            if (p != null)
            {
                db.OrderDetails.Add(p);
                db.SaveChanges();
                message = "Record Added";
                return message;
            }
            else
            {
                message = "Error";
                return message;
            }
            
        }

        public async Task<OrderDetail> DeleteOrder(int id)
        {
            OrderDetail customer = db.OrderDetails.Where(x => x.OrderId == id).SingleOrDefault();
            if (customer != null)
            {
                db.OrderDetails.Remove(customer);
                await db.SaveChangesAsync();
            }



            return customer;
        }



        public List<OrderDetail> GetAllOrder()
        {
            return  db.OrderDetails.ToList();
        }

        public async Task<OrderDetail> GetOrderById(int id)
        {
            OrderDetail g = await db.OrderDetails.FirstOrDefaultAsync(a => a.OrderId == id);
            return g;
        }

        public async Task UpdateOrder(int id, OrderDetail p)
        {

            db.OrderDetails.Update(p);
            await db.SaveChangesAsync();
        }
    }
}

