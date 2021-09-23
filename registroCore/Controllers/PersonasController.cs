using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using registroCore.Data;
using registroCore.Models;
//using System.Threading.Tasks;

namespace registroCore.Controllers
{
    public class PersonasController : Controller
    {

        private readonly personaDbContext _context;

        public PersonasController(personaDbContext context)
        {
            _context = context;
        }
        //Http Get Index
        public IActionResult Index()
        {
            IEnumerable<Persona> ListaPersonas = _context.Persona;
            return View(ListaPersonas);
        }
        //Http Get Create
        public IActionResult Create()
        {
           return View();
        }
        //Http Post Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        // ValidateAntiForgeryToken se usa para protejer los formularios

        public IActionResult Create(Persona persona)
        {
            if(ModelState.IsValid)
            {
                _context.Persona.Add(persona);
                _context.SaveChanges();
                TempData["mensaje"] = "Persona registrada con exito";
                return RedirectToAction("Index");
            }
            return View();
        }
        //Http Get Edit
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            //Obtener persona
            var persona = _context.Persona.Find(id);
            if (persona == null)
            {
                return NotFound();

            }
            return View(persona);
        }
        //Http Post Edit
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(Persona persona)
        {
            if (ModelState.IsValid)
            {
                _context.Persona.Update(persona);
                _context.SaveChanges();
                TempData["mensaje"] = "Actualizacion exitosa";
                return RedirectToAction("Index");
            }
            return View();
        }
        //Http Get delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //Obtener persona
            var persona = _context.Persona.Find(id);
            if (persona == null)
            {
                return NotFound();

            }
            return View(persona);
        }
        //Http Get Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePersona(int? id)
        {
            //Obterner persona por id
            var persona = _context.Persona.Find(id);
            
            if (persona == null)
            {
                return NotFound();
               
            }
            _context.Persona.Remove(persona);
            _context.SaveChanges();
            TempData["mensaje"] = "Registro borrado con exito";
            return RedirectToAction("Index");
        }
    }
    }
