using System;
using System.Collections.Generic;

namespace SeuProjeto.Models
{
    public class ApontamentoHoras
    {
        public string Usuario { get; set; }
        public int QuantidadeHoras { get; set; }
        public DateTime PrimeiroDiaSemana { get; set; }
        public DateTime UltimoDiaSemana { get; set; }
        public string Status { get; set; }
        public List<string> Aprovadores { get; set; }
        public int Aprovado { get; set; }
        public int Id { get; internal set; }
    }
}
