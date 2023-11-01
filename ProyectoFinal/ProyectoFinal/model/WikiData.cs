using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.model
{
    public class WikiData
    {
        public Guid IdWiki { get; set; }
        public string Name { get; set; }
        public string ScientificName { get; set; }
        public string Species { get; set; }
        public string SubSpecies { get; set; }
        public string GeographicalDistribution { get; set; }
        public string Habitat { get; set; }
        public string AverageSizeWeight { get; set; }
        public string Behavior { get; set; }
        public string Reproduction { get; set; }
        public string Diet { get; set; }
        public string AnatomyCharacteristics { get; set; }
        public string StateConservation { get; set; }
        public string Curiosities { get; set; }
        public string ConservationThreats { get; set; }
        public string Image { get; set; }
    }
}
