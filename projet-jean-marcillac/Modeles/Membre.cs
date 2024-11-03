using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projet_jean_marcillac.Modeles
{
    public abstract class Membre
    {
        public int Id {get; set;}
        public string? Nom {get; set;}
        public string? Prenom {get; set;}
    }
}