using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI1.Models
{
    public interface IContatoRepositorio
    {
        IEnumerable<Contato> GetAll(int size, int page);
        Contato Get(string id);
        bool Add(Contato contato);
        bool Remove(string id);
        bool Update(string id, Contato contato);        
    }
}