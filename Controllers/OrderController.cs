using log4net.Config;
using log4net.Core;
using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using WebApplication2.Models;
using WebApplication2.Repo;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private void LogError(string message)
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
            ILog _logger = LogManager.GetLogger(typeof(LoggerManager));
            _logger.Info(message);
        }
        private readonly Iorder<OrderDetail> transaction;
        public OrderController(Iorder<OrderDetail> _transaction)
        {
            transaction = _transaction;
        }


        [HttpGet]



        public ActionResult<List<OrderDetail>> GetTransactionDetails()
        {
            List<OrderDetail> t = transaction.GetAllOrder();
            return Ok(t);
        }

        [HttpPost]
        public IActionResult AddOrder(OrderDetail g)
        {
            transaction.AddNewOrder(g);
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult> Edit(int id, OrderDetail g)
        {
            LogError($"OrderDetails #{id}: {g.OrderId},{g.Status}");
            transaction.UpdateOrder(id, g);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please Enter the ID");
            }
            OrderDetail customer = await transaction.DeleteOrder(id);
            if (customer == null)
                return NotFound();
            else
                //custrepo.DeleteCustomer(id);
                return Ok();
        }
        [HttpGet]
        [Route("GetOrderById")]

        public async Task<ActionResult> GetorderbyId(int id)
        {
            LogError(id + "is retrieved");
            OrderDetail g = await transaction.GetOrderById(id);
            return Ok(g);
        }
    }
}
