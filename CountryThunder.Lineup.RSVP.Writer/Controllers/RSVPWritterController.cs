using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Steeltoe.Messaging.RabbitMQ.Core;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CountryThunder.Lineup.RSVP.Writer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RSVPWritterController : ControllerBase
    {
        public const string RECEIVE_AND_CONVERT_QUEUE = "steeltoe_message_queue";
        private readonly ILogger<RSVPWritterController> _logger;
        private readonly RabbitTemplate _rabbitTemplate;
        private readonly RabbitAdmin _rabbitAdmin;

        public RSVPWritterController(ILogger<RSVPWritterController> logger, RabbitTemplate rabbitTemplate, RabbitAdmin rabbitAdmin)
        {
            _logger = logger;
            _rabbitTemplate = rabbitTemplate;
            _rabbitAdmin = rabbitAdmin;
        }

        // GET: api/<RSVPWritterController>
        [HttpGet]
        //[Route("api/RSVPWritter")]
        public IEnumerable<string> Get()
        {
            for (int i = 0; i < 5; i++)
            {
                var msg = "{ \"Attendee\":\"Khusbu Shah\", \"Lineup\":\"DUSTIN LYNCH, OLD DOMINION, LUKE COMBS, ERIC CHURCH\" }";

                _rabbitTemplate.ConvertAndSend(RECEIVE_AND_CONVERT_QUEUE, msg);

                _logger.LogInformation($"Sending message '{msg}' to queue '{RECEIVE_AND_CONVERT_QUEUE}'");
            }

            yield return "Messages were sent to queue.";
        }

        // GET api/<RSVPWritterController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RSVPWritterController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RSVPWritterController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RSVPWritterController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
