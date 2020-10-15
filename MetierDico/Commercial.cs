using System;
using System.Collections.Generic;
using System.Text;

namespace MetierDico
{
    class Commercial
    {
        private string nomCommercial;
        private List<Vente> lesVentes;

        public Commercial(string unNom)
        {
            NomCommercial = unNom;
            LesVentes = new List<Vente>();
        }

        public string NomCommercial { get => nomCommercial; set => nomCommercial = value; }
        public List<Vente> LesVentes { get => lesVentes; set => lesVentes = value; }

        public void AjouterVente(Vente uneVente)
        {
            LesVentes.Add(uneVente);
        }
    }
}
