using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebEmpresa.Data;
using WebEmpresa.Entities;

namespace WebEmpresa.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientesController : ControllerBase
{
    private readonly Conexiones _context;

    public ClientesController(Conexiones context)
    {
        _context = context;
    }


    // GET: api/Clientes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Clientes>>> GetClientes()
    {
        return await _context.Clientes
            .OrderBy(c => c.Id_cliente)
            .ToListAsync();
    }


    // GET: api/Clientes/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Clientes>> GetCliente(int id)
    {
        var cliente = await _context.Clientes.FindAsync(id);

        if (cliente == null)
        {
            return NotFound();
        }

        return cliente;
    }


    // POST: api/Clientes
    [HttpPost]
    public async Task<ActionResult<Clientes>> PostCliente(Clientes cliente)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.Clientes.Add(cliente);

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            return BadRequest(new
            {
                mensaje = "No fue posible registrar el cliente. Verifique que el CUI y NIT no estén repetidos.",
                detalle = ex.InnerException?.Message
            });
        }

        return CreatedAtAction(
            nameof(GetCliente),
            new { id = cliente.Id_cliente },
            cliente
        );
    }


    // PUT: api/Clientes/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCliente(
        int id,
        Clientes cliente)
    {
        if (id != cliente.Id_cliente)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.Entry(cliente).State =
            EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ClienteExiste(id))
            {
                return NotFound();
            }

            throw;
        }
        catch (DbUpdateException ex)
        {
            return BadRequest(new
            {
                mensaje = "No fue posible actualizar el cliente. Verifique CUI y NIT.",
                detalle = ex.InnerException?.Message
            });
        }

        return NoContent();
    }


    // DELETE: api/Clientes/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCliente(int id)
    {
        var cliente =
            await _context.Clientes.FindAsync(id);

        if (cliente == null)
        {
            return NotFound();
        }

        _context.Clientes.Remove(cliente);

        await _context.SaveChangesAsync();

        return NoContent();
    }


    private bool ClienteExiste(int id)
    {
        return _context.Clientes
            .Any(e => e.Id_cliente == id);
    }
}