using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Repository;
using Repository.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ODataPOC.Controllers
{
    public class AuthorsController : ODataController
    {
        private readonly AuthorsRepository authorsRepository;

        public AuthorsController(AuthorsRepository authorsRepository)
        {
            this.authorsRepository = authorsRepository;
        }

        [EnableQuery]
        public async Task<ActionResult<Author>> Post([FromBody] Author author)
        {
            var result = await this.authorsRepository.CreateAuthor(author);
            return result;
        }

        [EnableQuery]
        public async Task<IActionResult> Get()
        {
            var result = await this.authorsRepository.FindAuthors();
            return Ok(result);
        }
    }
}
