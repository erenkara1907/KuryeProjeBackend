using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiversController : ControllerBase
    {
        private IReceiverService _receiverService;

        public ReceiversController(IReceiverService receiverService)
        {
            _receiverService = receiverService;
        }

        [HttpGet("getbyid")]
        [Authorize]
        public IActionResult GetById(int receiverId)
        {
            var result = _receiverService.GetById(receiverId);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getall")]
        [Authorize]
        public IActionResult GetList()
        {

            var result = _receiverService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getlistbydelivery")]
        [Authorize]
        public IActionResult GetListByDelivery(int deliveryId)
        {
            var result = _receiverService.GetListByDelivery(deliveryId);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(Receiver receiver)
        {
            var result = _receiverService.Add(receiver);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        [Authorize]
        public IActionResult Update(Receiver receiver)
        {
            var result = _receiverService.Update(receiver);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        [Authorize]
        public IActionResult Delete(Receiver receiver)
        {
            var result = _receiverService.Delete(receiver);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("transaction")]
        [Authorize]
        public IActionResult TransactionTest(Receiver receiver)
        {
            var result = _receiverService.TransactionalOperation(receiver);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }
    }
}
