using Microsoft.EntityFrameworkCore;
using ProEventos.Domain.Models;
using ProEventos.Persistence.Context;
using ProEventos.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Persistence.Features
{
    public class PalestranteRepository : IPalestranteRepository
    {
        private readonly ProEventosContext _context;

        public PalestranteRepository(ProEventosContext context)
        {
            _context = context;
        }

        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes.Include(p => p.RedeSocials);

            if (includeEventos) query = query.Include(p => p.PalestranteEventos).ThenInclude(pe => pe.Evento);

            query = query.AsNoTracking().OrderBy(p => p.Id).Where(p => p.Name.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes.Include(p => p.RedeSocials);

            if (includeEventos) query = query.Include(p => p.PalestranteEventos).ThenInclude(pe => pe.Evento);

            query = query.AsNoTracking().OrderBy(p => p.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante> GetPalestranteByIdAsync(int id, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes.Include(p => p.RedeSocials);

            if (includeEventos) query = query.Include(p => p.PalestranteEventos).ThenInclude(pe => pe.Evento);

            query = query.AsNoTracking().OrderBy(p => p.Id).Where(p => p.Id == id);

            return await query.FirstOrDefaultAsync();
        }
    }
}
