using BusinessManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BusinessManagementSystem.Controllers
{
    public class ClientesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClientesController(ApplicationDbContext context)
        {
            _context = context;
        }

        private bool VerificarSesion()
        {
            return HttpContext.Session.GetString("UsuarioEmail") != null;
        }

        public async Task<IActionResult> Index()
        {
            if (!VerificarSesion()) return RedirectToAction("Login", "Auth");
            var clientes = await _context.Clientes.ToListAsync();
            return View(clientes);
        }

        public IActionResult Crear()
        {
            if (!VerificarSesion()) return RedirectToAction("Login", "Auth");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Cliente cliente)
        {
            if (!VerificarSesion()) return RedirectToAction("Login", "Auth");
            cliente.CreatedAt = DateTime.Now;
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Editar(int id)
        {
            if (!VerificarSesion()) return RedirectToAction("Login", "Auth");
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null) return NotFound();
            return View(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Cliente cliente)
        {
            if (!VerificarSesion()) return RedirectToAction("Login", "Auth");
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Eliminar(int id)
        {
            if (!VerificarSesion()) return RedirectToAction("Login", "Auth");
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null) return NotFound();
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}