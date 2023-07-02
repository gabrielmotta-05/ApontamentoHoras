using System;

namespace SeuProjeto.Controllers
{
    internal class UsuarioApontamentoViewModel
    {
        public string Usuario { get; set; }
        public string Status { get; set; }
        public DateTime DataSemanaEspecifica { get; internal set; }
    }
}