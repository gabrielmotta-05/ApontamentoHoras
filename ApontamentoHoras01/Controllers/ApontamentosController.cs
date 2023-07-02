using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ApontamentoHoras01.Models;
using SeuProjeto.Models;
using SeuProjeto.ViewModels;


namespace SeuProjeto.Controllers
{
    public class ApontamentosController : Controller
    {
        public ActionResult Index()
        {
            // Dados de exemplo
            var apontamentos = new List<ApontamentoHoras>
            {
                new ApontamentoHoras
                {
                    Usuario = "Usuário 1",
                    QuantidadeHoras = 35,
                    PrimeiroDiaSemana = DateTime.Today,
                    UltimoDiaSemana = DateTime.Today.AddDays(6),
                    Status = "Aguardando",
                    Aprovadores = new List<string> { "Aprovador 1", "Aprovador 2" }
                },
                new ApontamentoHoras
                {
                    Usuario = "Usuário 2",
                    QuantidadeHoras = 20,
                    PrimeiroDiaSemana = DateTime.Today,
                    UltimoDiaSemana = DateTime.Today.AddDays(6),
                    Status = "Aprovado",
                    Aprovadores = new List<string> { "Aprovador 1", "Aprovador 3" }
                },
                new ApontamentoHoras
                {
                    Usuario = "Usuário 3",
                    QuantidadeHoras = 10,
                    PrimeiroDiaSemana = DateTime.Today,
                    UltimoDiaSemana = DateTime.Today.AddDays(6),
                    Status = "Reprovado",
                    Aprovadores = new List<string> { "Aprovador 2", "Aprovador 3" }
                }
            };

            // Crie a ViewModel com os dados dos apontamentos
            var viewModel = new List<ApontamentoHorasViewModel>();
            foreach (var apontamento in apontamentos)
            {
                viewModel.Add(new ApontamentoHorasViewModel
                {
                    Usuario = apontamento.Usuario,
                    QuantidadeHoras = apontamento.QuantidadeHoras,
                    PrimeiroDiaSemana = apontamento.PrimeiroDiaSemana,
                    UltimoDiaSemana = apontamento.UltimoDiaSemana,
                    Status = apontamento.Status,
                    Aprovadores = apontamento.Aprovadores
                });
            }
            if (viewModel == null)
            {
                viewModel = new List<ApontamentoHorasViewModel>();
            }


            return View("~/Views/Apontamentos/Index.cshtml", viewModel);

        }

        public ActionResult ValidaStatus(DateTime dataSemanaEspecifica)
        {
            var apontamentos = new List<ApontamentoHoras>
    {
        new ApontamentoHoras
        {
            Usuario = "Usuário 1",
            QuantidadeHoras = 35,
            PrimeiroDiaSemana = DateTime.Today,
            UltimoDiaSemana = DateTime.Today.AddDays(6),
            Aprovado = 1
        },
        new ApontamentoHoras
        {
            Usuario = "Usuário 2",
            QuantidadeHoras = 20,
            PrimeiroDiaSemana = DateTime.Today,
            UltimoDiaSemana = DateTime.Today.AddDays(6),
            Aprovado = 1
        },
        new ApontamentoHoras
        {
            Usuario = "Usuário 3",
            QuantidadeHoras = 10,
            PrimeiroDiaSemana = DateTime.Today,
            UltimoDiaSemana = DateTime.Today.AddDays(6),
            Aprovado = 1
        }
    };

            var viewModel = new List<UsuarioApontamentoViewModel>();

            foreach (var apontamento in apontamentos)
            {
                var status = "";
                if (apontamento.Status.Contains("1"))
                {
                    status = "Aprovado";
                }
                else if (apontamento.Status.Contains("2"))
                {
                    status = "Aguardando";
                }
                else
                {
                    status = "Rejeitado";
                }

                var usuarioApontamento = new UsuarioApontamentoViewModel
                {
                    Usuario = apontamento.Usuario,
                    Status = status
                };

                // Verifica se a data da semana específica está dentro do intervalo do apontamento
                if (dataSemanaEspecifica >= apontamento.PrimeiroDiaSemana && dataSemanaEspecifica <= apontamento.UltimoDiaSemana)
                {
                    usuarioApontamento.DataSemanaEspecifica = dataSemanaEspecifica;
                }

                viewModel.Add(usuarioApontamento);
            }

            return View(viewModel);
        }



        public ActionResult PesquisaData(DateTime? dataInicio, DateTime? dataFim)
        {
            if (!dataInicio.HasValue)
                dataInicio = DateTime.MinValue;
            if (!dataFim.HasValue)
                dataFim = DateTime.MaxValue;

            ViewBag.DataInicio = dataInicio.Value.ToString("yyyy-MM-dd");
            ViewBag.DataFim = dataFim.Value.ToString("yyyy-MM-dd");

            List<ApontamentoHoras> apontamentosFiltrados = ObterApontamentosFiltrados(dataInicio.Value, dataFim.Value);

            var viewModel = new List<UsuarioApontamentoViewModel>();

            foreach (var apontamento in apontamentosFiltrados)
            {
                var status = "";
                if (status == "1")
                {
                    status = "Aprovado";
                }
                else
                {
                    status = "Rejeitado";
                }

                var usuarioApontamento = new UsuarioApontamentoViewModel
                {
                    Usuario = apontamento.Usuario,
                    Status = status
                };

                // Verifica se a data da semana específica está dentro do intervalo do apontamento
                if (apontamento.PrimeiroDiaSemana <= dataFim.Value && apontamento.UltimoDiaSemana >= dataInicio.Value)
                {
                    usuarioApontamento.DataSemanaEspecifica = dataInicio.Value;
                }

                viewModel.Add(usuarioApontamento);
            }

            return View(viewModel);
        }

        private List<ApontamentoHoras> ObterApontamentosFiltrados(DateTime dataInicio, DateTime dataFim)
        {
            // Substitua esta implementação fictícia pela lógica real para buscar os apontamentos do banco de dados
            // ou de qualquer outra fonte de dados.
            // Retorne uma lista de objetos Apontamento filtrados com base nas datas fornecidas.

            List<ApontamentoHoras> apontamentos = new List<ApontamentoHoras>();

            // Exemplo fictício de criação de alguns apontamentos
            apontamentos.Add(new ApontamentoHoras { Id = 1, PrimeiroDiaSemana = DateTime.Parse("2023-06-28"), UltimoDiaSemana = DateTime.Parse("2023-07-04"), Aprovado = 1 });
            apontamentos.Add(new ApontamentoHoras { Id = 2, PrimeiroDiaSemana = DateTime.Parse("2023-07-05"), UltimoDiaSemana = DateTime.Parse("2023-07-11"), Aprovado = 2 });
            apontamentos.Add(new ApontamentoHoras { Id = 3, PrimeiroDiaSemana = DateTime.Parse("2023-07-12"), UltimoDiaSemana = DateTime.Parse("2023-07-18"), Aprovado = 3 });

            // Filtrar os apontamentos com base nas datas de início e fim
            List<ApontamentoHoras> apontamentosFiltrados = apontamentos.Where(a => a.PrimeiroDiaSemana >= dataInicio && a.UltimoDiaSemana <= dataFim).ToList();

            return apontamentosFiltrados;
        }

    }
}
