using WebApplication2.Models;
namespace WebApplication2.Repo
{
    public interface Iorder<OrderDetail>
    {
        List<OrderDetail> GetAllOrder();
        String AddNewOrder(OrderDetail p);
        Task<OrderDetail> DeleteOrder(int id);
        Task<OrderDetail> GetOrderById(int id);
        Task UpdateOrder(int id, OrderDetail p);
    }
}
