using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Domain.Models
{
    public class Palestrante
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descricao { get; set; }
        public string ImagemUrl { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public IEnumerable<RedeSocial> RedeSocials { get; set; }
        public IEnumerable<PalestranteEvento> PalestranteEventos { get; set; }
    }
}
