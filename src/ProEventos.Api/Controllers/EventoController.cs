using Microsoft.AspNetCore.Mvc;
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

        public IEnumerable<Evento> Eventos = new Evento[]{
            new Evento()
                {
                    EventoId = 1,
                    Tema = "Tema 1",
                    Local = "Local 1",
                    Lote = "Lote 1",
                    QtdPessoas = 250,
                    DataEvento = DateTime.Now.AddDays(2).ToString(),
                    ImagemURL = "foto1.png"
                },
                new Evento()
                {
                        EventoId = 2,
                        Tema = "Tema 2",
                        Local = "Local 2",
                        Lote = "Lote 2",
                        QtdPessoas = 250,
                        DataEvento = DateTime.Now.AddDays(2).ToString(),
                        ImagemURL = "foto2.png"
                },
                new Evento()
                {
                    EventoId = 3,
                    Tema = "Tema 3",
                    Local = "Local 3",
                    Lote = "Lote 3",
                    QtdPessoas = 250,
                    DataEvento = DateTime.Now.AddDays(2).ToString(),
                    ImagemURL = "foto3.png"
                },

        };
        public EventoController()
        {

        }

        [HttpPost]
        public string Post()
        {
            return "Lucas Post";
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {


            return Eventos;
        }

        [HttpGet("{id}")]
        public Evento Get(int id)
        {



            return Eventos.FirstOrDefault(x => x.EventoId == id);

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
