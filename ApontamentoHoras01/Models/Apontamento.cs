using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApontamentoHoras01.Models
{
    public class Apontamento
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        // Outras propriedades do apontamento

        // Construtor da classe
        public Apontamento()
        {
            // Inicialize as propriedades conforme necessário
        }
    }
}