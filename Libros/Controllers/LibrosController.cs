using Libros.Data;
using Libros.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Libros.Controllers
{
    public class LibrosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LibrosController( ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Libro> ListaLibros = _context.Libro;
            return View(ListaLibros);
        }


        public IActionResult Create()
        {
           
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Libro libro)
        {
            if(ModelState.IsValid)
            {
                _context.Libro.Add(libro);
                _context.SaveChanges();

                TempData["mensaje"] = "Inserpción Exitosa";
                return RedirectToAction("Index");
            }

            return View();
        }


        public IActionResult Edit( int? id)
        {

            if(id == null || id == 0)
            {
                return NotFound();
            }

            var libro = _context.Libro.Find(id);

            if (libro == null) 
            {
                return NotFound();
            }

            return View(libro);
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Libro libro)
        {
            if (ModelState.IsValid)
            {
                _context.Libro.Update(libro);
                _context.SaveChanges();

                TempData["mensaje"] = "Actualización Completada!";
                return RedirectToAction("Index");
            }

            return View();
        }


        public IActionResult Delete(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }

            var libro = _context.Libro.Find(id);

            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteLibro(int? id)
        {

            var libro = _context.Libro.Find(id);

            if(libro == null)
            {
                NotFound();
            }

                _context.Libro.Remove(libro);
                _context.SaveChanges();

                TempData["mensaje"] = "El Libro se ha Eiminado!";
                return RedirectToAction("Index");
      
        }



    }
}
