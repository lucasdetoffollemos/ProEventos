using Microsoft.AspNetCore.Mvc;
using ProEventos.Api.Data;
using ProEventos.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProEventos.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        public DataContext DataContext { get; set; }

        public EventoController(DataContext context)
        {
            DataContext = context;
        }

        [HttpPost]
        public string Post()
        {
            return "Lucas Post";
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {


            return DataContext.Eventos;
        }

        [HttpGet("{id}")]
        public Evento Get(int id)
        {
            return DataContext.Eventos.FirstOrDefault(x => x.EventoId == id);

        }

        [HttpPut("{id}")]
        public string Put(int id)
        {
            return $"Lucas Put com id = {id}";
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return $"Lucas Delete com id = {id}";
        }
    }
}
