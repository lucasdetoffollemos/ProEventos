using ProEventos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Application.Contratcts
{
    public interface IEventoService
    {
        Task<Evento> AddEvento(Evento model);

        Task<Evento> UpdateEvento(int id, Evento model);

        Task<bool> DeleteEvento(int id);

        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false);
        Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false);
        Task<Evento> GetEventoByIdAsync(int id, bool includePalestrantes = false);
    }
}
