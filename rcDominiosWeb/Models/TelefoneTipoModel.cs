using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using rcDominiosTransfers;
using rcDominiosWeb.Services;

namespace rcDominiosWeb.Models
{
    public class TelefoneTipoModel
    {
        private readonly IHttpContextAccessor httpContext;

        public TelefoneTipoModel(IHttpContextAccessor accessor)
        {
            httpContext = accessor;
        }

        public async Task<TelefoneTipoTransfer> Incluir(TelefoneTipoTransfer telefoneTipoTransfer)
        {
            TelefoneTipoService telefoneTipoService;
            TelefoneTipoTransfer telefoneTipo;
            AutenticaModel autenticaModel;
            string autorizacao;

            try {
                telefoneTipoService = new TelefoneTipoService();
                autenticaModel = new AutenticaModel(httpContext);

                autorizacao = autenticaModel.ObterToken();

                telefoneTipoTransfer.TelefoneTipo.Criacao = DateTime.Today;
                telefoneTipoTransfer.TelefoneTipo.Alteracao = DateTime.Today;

                telefoneTipo = await telefoneTipoService.Incluir(telefoneTipoTransfer, autorizacao);
            } catch (Exception ex) {
                telefoneTipo = new TelefoneTipoTransfer();

                telefoneTipo.Validacao = false;
                telefoneTipo.Erro = true;
                telefoneTipo.IncluirMensagem("Erro em TelefoneTipoModel Incluir [" + ex.Message + "]");
            } finally {
                telefoneTipoService = null;
                autenticaModel = null;
            }

            return telefoneTipo;
        }

        public async Task<TelefoneTipoTransfer> Alterar(TelefoneTipoTransfer telefoneTipoTransfer)
        {
            TelefoneTipoService telefoneTipoService;
            TelefoneTipoTransfer telefoneTipo;
            AutenticaModel autenticaModel;
            string autorizacao;

            try {
                telefoneTipoService = new TelefoneTipoService();
                autenticaModel = new AutenticaModel(httpContext);

                autorizacao = autenticaModel.ObterToken();

                telefoneTipoTransfer.TelefoneTipo.Alteracao = DateTime.Today;

                telefoneTipo = await telefoneTipoService.Alterar(telefoneTipoTransfer, autorizacao);
            } catch (Exception ex) {
                telefoneTipo = new TelefoneTipoTransfer();

                telefoneTipo.Validacao = false;
                telefoneTipo.Erro = true;
                telefoneTipo.IncluirMensagem("Erro em TelefoneTipoModel Alterar [" + ex.Message + "]");
            } finally {
                telefoneTipoService = null;
                autenticaModel = null;
            }

            return telefoneTipo;
        }

        public async Task<TelefoneTipoTransfer> Excluir(int id)
        {
            TelefoneTipoService telefoneTipoService;
            TelefoneTipoTransfer telefoneTipo;
            AutenticaModel autenticaModel;
            string autorizacao;

            try {
                telefoneTipoService = new TelefoneTipoService();
                autenticaModel = new AutenticaModel(httpContext);

                autorizacao = autenticaModel.ObterToken();

                telefoneTipo = await telefoneTipoService.Excluir(id, autorizacao);
            } catch (Exception ex) {
                telefoneTipo = new TelefoneTipoTransfer();

                telefoneTipo.Validacao = false;
                telefoneTipo.Erro = true;
                telefoneTipo.IncluirMensagem("Erro em TelefoneTipoModel Excluir [" + ex.Message + "]");
            } finally {
                telefoneTipoService = null;
                autenticaModel = null;
            }

            return telefoneTipo;
        }

        public async Task<TelefoneTipoTransfer> ConsultarPorId(int id)
        {
            TelefoneTipoService telefoneTipoService;
            TelefoneTipoTransfer telefoneTipo;
            AutenticaModel autenticaModel;
            string autorizacao;
            
            try {
                telefoneTipoService = new TelefoneTipoService();
                autenticaModel = new AutenticaModel(httpContext);

                autorizacao = autenticaModel.ObterToken();

                telefoneTipo = await telefoneTipoService.ConsultarPorId(id, autorizacao);
            } catch (Exception ex) {
                telefoneTipo = new TelefoneTipoTransfer();

                telefoneTipo.Validacao = false;
                telefoneTipo.Erro = true;
                telefoneTipo.IncluirMensagem("Erro em TelefoneTipoModel ConsultarPorId [" + ex.Message + "]");
            } finally {
                telefoneTipoService = null;
                autenticaModel = null;
            }

            return telefoneTipo;
        }

        public async Task<TelefoneTipoTransfer> Consultar(TelefoneTipoTransfer telefoneTipoListaTransfer)
        {
            TelefoneTipoService telefoneTipoService;
            TelefoneTipoTransfer telefoneTipoLista;
            AutenticaModel autenticaModel;
            string autorizacao;
            int dif = 0;
            int qtdExibe = 5;

            try {
                telefoneTipoService = new TelefoneTipoService();
                autenticaModel = new AutenticaModel(httpContext);

                autorizacao = autenticaModel.ObterToken();

                telefoneTipoLista = await telefoneTipoService.Consultar(telefoneTipoListaTransfer, autorizacao);

                if (telefoneTipoLista != null) {
                    if (telefoneTipoLista.TotalRegistros > 0) {
                        if (telefoneTipoLista.RegistrosPorPagina < 1) {
                            telefoneTipoLista.RegistrosPorPagina = 30;
                        } else if (telefoneTipoLista.RegistrosPorPagina > 200) {
                            telefoneTipoLista.RegistrosPorPagina = 30;
                        }

                        telefoneTipoLista.PaginaAtual = (telefoneTipoLista.PaginaAtual < 1 ? 1 : telefoneTipoLista.PaginaAtual);
                        telefoneTipoLista.TotalPaginas = 
                            Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(telefoneTipoLista.TotalRegistros) 
                            / @Convert.ToDecimal(telefoneTipoLista.RegistrosPorPagina)));
                        telefoneTipoLista.TotalPaginas = (telefoneTipoLista.TotalPaginas < 1 ? 1 : telefoneTipoLista.TotalPaginas);

                        qtdExibe = (qtdExibe > telefoneTipoLista.TotalPaginas ? telefoneTipoLista.TotalPaginas : qtdExibe);

                        telefoneTipoLista.PaginaInicial = telefoneTipoLista.PaginaAtual - (Convert.ToInt32(Math.Floor(qtdExibe / 2.0)));
                        telefoneTipoLista.PaginaFinal = telefoneTipoLista.PaginaAtual + (Convert.ToInt32(Math.Floor(qtdExibe / 2.0)));
                        telefoneTipoLista.PaginaFinal = ((qtdExibe % 2) == 0 ? (telefoneTipoLista.PaginaFinal - 1) : telefoneTipoLista.PaginaFinal);

                        if (telefoneTipoLista.PaginaInicial < 1) {
                            dif = 1 - telefoneTipoLista.PaginaInicial;
                            telefoneTipoLista.PaginaInicial += dif;
                            telefoneTipoLista.PaginaFinal += dif;
                        }

                        if (telefoneTipoLista.PaginaFinal > telefoneTipoLista.TotalPaginas) {
                            dif = telefoneTipoLista.PaginaFinal - telefoneTipoLista.TotalPaginas;
                            telefoneTipoLista.PaginaInicial -= dif;
                            telefoneTipoLista.PaginaFinal -= dif;
                        }

                        telefoneTipoLista.PaginaInicial = (telefoneTipoLista.PaginaInicial < 1 ? 1 : telefoneTipoLista.PaginaInicial);
                        telefoneTipoLista.PaginaFinal = (telefoneTipoLista.PaginaFinal > telefoneTipoLista.TotalPaginas ? 
                            telefoneTipoLista.TotalPaginas : telefoneTipoLista.PaginaFinal);
                    }
                }
            } catch (Exception ex) {
                telefoneTipoLista = new TelefoneTipoTransfer();

                telefoneTipoLista.Validacao = false;
                telefoneTipoLista.Erro = true;
                telefoneTipoLista.IncluirMensagem("Erro em TelefoneTipoModel Consultar [" + ex.Message + "]");
            } finally {
                telefoneTipoService = null;
                autenticaModel = null;
            }

            return telefoneTipoLista;
        }
    }
}
