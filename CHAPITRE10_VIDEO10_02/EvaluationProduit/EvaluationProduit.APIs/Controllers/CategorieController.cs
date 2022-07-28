using Microsoft.AspNetCore.Mvc;
using EvaluationProduit.Domaines.Services;
using Microsoft.AspNetCore.Cors;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EvaluationProduit.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class CategorieController : ControllerBase
    {
        private ICategorieService _categorieService;

        public CategorieController(ICategorieService categorieService)
        {
            this._categorieService = categorieService;
        }

        // GET: api/<CategorieController>
        [HttpGet]
        [EnableCors("AllowOrigin")]
        public ActionResult<IList<string>> Get()
        {
            var categories = _categorieService.CategorieList;
            if (categories == null)
                return NotFound();
            return categories.ToList();
        }

        // GET api/<CategorieController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CategorieController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CategorieController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategorieController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
