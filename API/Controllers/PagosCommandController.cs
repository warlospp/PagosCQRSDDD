using Microsoft.AspNetCore.Mvc;
using PagosCQRSDDD.Application.Commands;
using PagosCQRSDDD.Infrastructure.Persistence;
using PagosCQRSDDD.Infrastructure.Repositories;

[ApiController]
[Route("api/[controller]")]
public class PagosCommandController : ControllerBase
{
    private readonly PagarCommandHandler _pagoHandler;
    private readonly IPagoMongoRepository _mongoRepository;

    public PagosCommandController(PagarCommandHandler handler, IPagoMongoRepository mongoRepository)
    {
        _pagoHandler = handler;
        _mongoRepository = mongoRepository;
    }

    [HttpPost]
    public async Task<IActionResult> CrearPago([FromBody] PagarCommand command)
    {
        var id = await _pagoHandler.HandleAsync(command);
        return CreatedAtAction(nameof(CrearPago), new { id }, command);
    } 

    [HttpGet("{id}")]
    public async Task<IActionResult> ObtenerPagoPorIdId(int id)
    {
        var pago = await _mongoRepository.ObtenerPagoPorIdAsync(id);
        if (pago == null)
            return NotFound();

        return Ok(pago);
    } 
}