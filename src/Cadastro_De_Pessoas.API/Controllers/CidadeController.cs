using Cadastro_De_Pessoas.APPLICATION.Models.Request;
using Cadastro_De_Pessoas.APPLICATION.Services.CidadeService;
using Microsoft.AspNetCore.Mvc;

namespace Cadastro_De_Pessoas.API.Controllers
{
    [Route("api/[controller]")]
    public class CidadeController : ControllerBase
    {
        private readonly ICidadeService _service;
        public CidadeController(ICidadeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var returnValue = await _service.GetAllAsync();
                return Ok(returnValue);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var returnValue = await _service.GetByIdAsync(id);
                return Ok(returnValue);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CidadeRequest cidadeRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var returnValue = await _service.CreateAsync(cidadeRequest);
                    return Ok(returnValue);
                }
                else
                {
                    return NotFound(ModelState);
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CidadeRequest cidadeRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var returnValue = await _service.UpdateAsync(id, cidadeRequest);
                    return Ok(returnValue);
                }
                else
                {
                    return NotFound(ModelState);
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var returnValue = await _service.DeleteAsync(id);
                return Ok(returnValue);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
