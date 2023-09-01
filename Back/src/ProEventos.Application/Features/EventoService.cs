using ProEventos.Application.Contratcts;
using ProEventos.Domain.Models;
using ProEventos.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Application.Features
{
    public class EventoService : IEventoService
    {
        private readonly IGeralRepository _geralRepository;
        private readonly IEventoRepository _eventoRepository;

        public EventoService(IGeralRepository geralRepository, IEventoRepository eventoRepository)
        {
            _geralRepository = geralRepository; 
            _eventoRepository = eventoRepository;
        }

        public async Task<Evento> AddEvento(Evento model)
        {
            try
            {
                _geralRepository.Add(model);
                if(await _geralRepository.SaveChangesAsync())
                    return await _eventoRepository.GetEventoByIdAsync(model.Id, false);

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> UpdateEvento(int id, Evento model)
        {
            try { 
                var evento = await _eventoRepository.GetEventoByIdAsync(id, false);

                if (evento == null)
                    return null;

                model.Id = evento.Id;   

                _geralRepository.Update(model);    

                if (await _geralRepository.SaveChangesAsync())
                    return await _eventoRepository.GetEventoByIdAsync(evento.Id, false);

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEvento(int id)
        {
            try
            {
                var evento = await _eventoRepository.GetEventoByIdAsync(id, false);

                if (evento == null)
                    throw new Exception("Evento para delete não encontrado");

                _geralRepository.Delete(evento);

                return await _geralRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoRepository.GetAllEventosAsync(includePalestrantes);
                if(eventos == null)
                {
                    return null; 
                }
                return eventos; 
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);   
            }
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoRepository.GetAllEventosByTemaAsync(tema, includePalestrantes);
                if (eventos == null)
                {
                    return null;
                }
                return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> GetEventoByIdAsync(int id, bool includePalestrantes = false)
        {
            try
            {
                var evento = await _eventoRepository.GetEventoByIdAsync(id, includePalestrantes);
                if (evento == null)
                {
                    return null;
                }
                return evento;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
