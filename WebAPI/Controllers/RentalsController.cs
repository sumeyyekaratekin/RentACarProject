using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core.Aspects.Autofac.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private readonly IRentalService _rentalService;
        private readonly IPaymentService _paymentService;

        public RentalsController(IRentalService rentalService, IPaymentService paymentService)
        {
            _rentalService = rentalService;
            _paymentService = paymentService;
        }

        [HttpPost("add")]
        public IActionResult Add(Rental rental)
        {
            var result = _rentalService.Add(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult Update(Rental rental)
        {
            var result = _rentalService.Update(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(Rental rental)
        {
            var result = _rentalService.Delete(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _rentalService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _rentalService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getrentaldetails")]
        public IActionResult GetAllRentalDetails()
        {
            var result = _rentalService.GetRentalDetails();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("paymentadd")]
        [TransactionScopeAspect]
        public ActionResult PaymentAdd(RentalPaymentDto rentalPaymentDto)
        {
            var paymentResult = _paymentService.ReceivePayment(rentalPaymentDto.Payment);
            if (!paymentResult.Success)
            {
                return BadRequest(paymentResult);
            }
            var result = _rentalService.Add(rentalPaymentDto.Rental);

            if (result.Success)
                return Ok(result);
            else
            {
                throw new System.Exception(result.Message);
                //return BadRequest(result);                    
            }
        }

    }
}
