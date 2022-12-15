using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormulaAirLine.API.Models;
using FormulaAirLine.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace FormulaAirLine.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingsController : ControllerBase
    {
        private readonly ILogger<BookingsController> _logger;
        private readonly IMessageProducer _messageProducer;
        private static List<Booking> _bookings= new();
        public BookingsController(ILogger<BookingsController> logger, 
                                    IMessageProducer messageProducer){
                                        _logger=logger;
                                        _messageProducer=messageProducer;

        }

        [HttpPost]
        public IActionResult CreateBooking (Booking booking){
            if(!ModelState.IsValid) return BadRequest();
            _bookings.Add(booking);
            _messageProducer.SendingMessage<Booking>(booking);

            return Ok(booking);
        }



    }
}