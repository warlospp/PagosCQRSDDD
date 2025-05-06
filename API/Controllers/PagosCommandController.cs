using Microsoft.AspNetCore.Mvc;
using PagosCQRSDDD.Application.Commands;

[ApiController]
[Route("api/[controller]")]
public class PagosCommandController : ControllerBase
{
    private readonly PagarCommandHandler _handler;

    public PagosCommandController(PagarCommandHandler handler)
    {
        _handler = handler;
    }

    [HttpPost]
    public async Task<IActionResult> CrearPago([FromBody] PagarCommand command)
    {
        var id = await _handler.HandleAsync(command);
        return CreatedAtAction(nameof(CrearPago), new { id }, command);
    }
}