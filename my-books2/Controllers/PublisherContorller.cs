using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books2.ActionResults;
using my_books2.Data.Models;
using my_books2.Data.Services;
using my_books2.Data.ViewModels;
using my_books2.Exceptions;

namespace my_books2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private PublisherService _publisherService;
        public PublisherController(PublisherService publisherService)
        {
            _publisherService = publisherService;
        }


        [HttpGet("get-all-publishers")]
        public IActionResult getAllPublishers(string sortBy, string filter, int pageNumber)
        {
            try
            {
                var result = _publisherService.getAllPublishers(sortBy, filter, pageNumber);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Sorry, we could not load the publishers");
            }
        }

        [HttpPost]
        public IActionResult AddPublisher([FromBody] PublisherVM publisher)
        {
            try
            {
                var newPublisher = _publisherService.addPublisher(publisher);
                return Created(nameof(AddPublisher), newPublisher);
            }
            catch (PublisherNameException ex)
            {
                return BadRequest($"{ex.Message}, Publisher name {ex.publisherName}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-publisher-by-id/{id}")]
        public ActionResult<Publisher> getPublisherById(int id)
        //public CustomActionResult getPublisherById(int id)
        {
            //throw new Exception("This is an exception that will be handled by middleware");
            var response = _publisherService.getPublisherById(id);
            if (response != null)
            {
                return Ok(response);
                //var responseObj = new CustomActionResultVM()
                //{
                //    publisher = response
                //};
                //return new CustomActionResult(responseObj);
            }
            else
            {
                //var responseObj = new CustomActionResultVM()
                //{
                //    exception = new Exception("This is coming from publishers controller")
                //};
                //return new CustomActionResult(responseObj);
                return NotFound();
            }
        }

        [HttpGet("{id}")]
        public IActionResult getPublisher(int id)
        {
            var response = _publisherService.getPublisherData(id);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult deletePublishedById(int id)
        {
            try
            {
                //int x = 1;
                //int y = 0;
                //var z = x / y;
                _publisherService.deletePublisherById(id);
                return Ok();
            }
            //catch (ArithmeticException ex)
            //{
            //    return BadRequest(ex.Message);
            //}
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } 
    }
}
