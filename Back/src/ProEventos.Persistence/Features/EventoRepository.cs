using ProEventos.Persistence.Contracts;
using ProEventos.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProEventos.Domain.Models;
using Microsoft.EntityFrameworkCore;
using ProEventos.Persistence.Context;

namespace ProEventos.Persistence.Features
{
    public class EventoRepository : IEventoRepository
    {
        private readonly ProEventosContext _context;

        public EventoRepository(ProEventosContext context)
        {
            _context = context;
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos.Include(e => e.Lotes).Include(e => e.RedesSociais);

            if (includePalestrantes) query = query.Include(e => e.PalestranteEventos).ThenInclude(pe => pe.Palestrante);

            query = query.AsNoTracking().OrderBy(e => e.Id).Where(e => e.Tema.ToLower().Contains(tema.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos.Include(e => e.Lotes).Include(e => e.RedesSociais);

            if (includePalestrantes) query = query.Include(e => e.PalestranteEventos).ThenInclude(pe => pe.Palestrante);

            query = query.AsNoTracking().OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Evento> GetEventoByIdAsync(int id, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos.Include(e => e.Lotes).Include(e => e.RedesSociais);

            if (includePalestrantes) query = query.Include(e => e.PalestranteEventos).ThenInclude(pe => pe.Palestrante);

            query = query.AsNoTracking().OrderBy(e => e.Id).Where(e => e.Id == id);

            return await query.FirstOrDefaultAsync();
        }
    }
}
