using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendadorOperaCloud.Models
{
    public class LogsMdl
    {
        public string? ID { get; set; }
        public string? ID_JOB { get; set; }
        public string? RESORT { get; set; }
        public string? TIPOARQUIVO { get; set; }
        public string? LOG { get; set; }
        public string? ERRO { get; set; }
        public string? TEMPO_INTEGRACAO { get; set; }
        public string? DATA_EXECUCAO { get; set; }
        public string? HORA_EXECUCAO { get; set; }
    }
}
