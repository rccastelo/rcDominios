using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using rcDominiosTransfers;

namespace rcDominiosWeb.Services
{
  public class PessoaTipoService
    {
        private string enderecoServico = "http://localhost:5600/";
        private string nomeServico = "PessoaTipo";
        private HttpClient httpClient = null;
        AutenticaService autenticaService = null;
        private string autorizacao = null;

        public PessoaTipoService()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new System.Uri(enderecoServico);
            autenticaService = new AutenticaService();
        }

        public async Task<PessoaTipoTransfer> Incluir(PessoaTipoTransfer pessoaTipoTransfer)
        {
            PessoaTipoTransfer pessoaTipo = null;
            HttpResponseMessage resposta = null;
            string mensagemRetono = null;
            
            try {
                autorizacao = await autenticaService.Autorizar();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorizacao);

                resposta = await httpClient.PostAsJsonAsync($"{nomeServico}", pessoaTipoTransfer);

                if (resposta.IsSuccessStatusCode) {
                    pessoaTipo = resposta.Content.ReadAsAsync<PessoaTipoTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    pessoaTipo = resposta.Content.ReadAsAsync<PessoaTipoTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
                    mensagemRetono = $"Acesso ao serviço {nomeServico} Incluir não autorizado";
                } else {
                    mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} Incluir";
                }

                if (!string.IsNullOrEmpty(mensagemRetono)) {
                    pessoaTipo = new PessoaTipoTransfer();
                    
                    pessoaTipo.Validacao = false;
                    pessoaTipo.Erro = true;
                    pessoaTipo.IncluirErroMensagem(mensagemRetono);
                }
            } catch (Exception ex) {
                pessoaTipo = new PessoaTipoTransfer();

                pessoaTipo.Validacao = false;
                pessoaTipo.Erro = true;
                pessoaTipo.IncluirErroMensagem("Erro em PessoaTipoService Incluir [" + ex.Message + "]");
            } finally {
                resposta = null;
            }

            return pessoaTipo;
        }

        public async Task<PessoaTipoTransfer> Alterar(PessoaTipoTransfer pessoaTipoTransfer)
        {
            PessoaTipoTransfer pessoaTipo = null;
            HttpResponseMessage resposta = null;
            string mensagemRetono = null;
            
            try {
                autorizacao = await autenticaService.Autorizar();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorizacao);

                resposta = await httpClient.PutAsJsonAsync($"{nomeServico}", pessoaTipoTransfer);

                if (resposta.IsSuccessStatusCode) {
                    pessoaTipo = resposta.Content.ReadAsAsync<PessoaTipoTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    pessoaTipo = resposta.Content.ReadAsAsync<PessoaTipoTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
                    mensagemRetono = $"Acesso ao serviço {nomeServico} Alterar não autorizado";
                } else {
                    mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} Alterar";
                }

                if (!string.IsNullOrEmpty(mensagemRetono)) {
                    pessoaTipo = new PessoaTipoTransfer();
                    
                    pessoaTipo.Validacao = false;
                    pessoaTipo.Erro = true;
                    pessoaTipo.IncluirErroMensagem(mensagemRetono);
                }
            } catch (Exception ex) {
                pessoaTipo = new PessoaTipoTransfer();

                pessoaTipo.Validacao = false;
                pessoaTipo.Erro = true;
                pessoaTipo.IncluirErroMensagem("Erro em PessoaTipoService Alterar [" + ex.Message + "]");
            } finally {
                resposta = null;
            }

            return pessoaTipo;
        }

        public async Task<PessoaTipoTransfer> Excluir(int id)
        {
            PessoaTipoTransfer pessoaTipo = null;
            HttpResponseMessage resposta = null;
            string mensagemRetono = null;
            
            try {
                autorizacao = await autenticaService.Autorizar();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorizacao);

                resposta = await httpClient.DeleteAsync($"{nomeServico}/{id}");

                if (resposta.IsSuccessStatusCode) {
                    pessoaTipo = resposta.Content.ReadAsAsync<PessoaTipoTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    pessoaTipo = resposta.Content.ReadAsAsync<PessoaTipoTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
                    mensagemRetono = $"Acesso ao serviço {nomeServico} Excluir não autorizado";
                } else {
                    mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} Excluir";
                }

                if (!string.IsNullOrEmpty(mensagemRetono)) {
                    pessoaTipo = new PessoaTipoTransfer();
                    
                    pessoaTipo.Validacao = false;
                    pessoaTipo.Erro = true;
                    pessoaTipo.IncluirErroMensagem(mensagemRetono);
                }
            } catch (Exception ex) {
                pessoaTipo = new PessoaTipoTransfer();

                pessoaTipo.Validacao = false;
                pessoaTipo.Erro = true;
                pessoaTipo.IncluirErroMensagem("Erro em PessoaTipoService Excluir [" + ex.Message + "]");
            } finally {
                resposta = null;
            }

            return pessoaTipo;
        }

        public async Task<PessoaTipoTransfer> ConsultarPorId(int id)
        {
            PessoaTipoTransfer pessoaTipo = null;
            HttpResponseMessage resposta = null;
            string mensagemRetono = null;
            
            try {
                autorizacao = await autenticaService.Autorizar();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorizacao);

                resposta = await httpClient.GetAsync($"{nomeServico}/{id}");

                if (resposta.IsSuccessStatusCode) {
                    pessoaTipo = resposta.Content.ReadAsAsync<PessoaTipoTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    pessoaTipo = resposta.Content.ReadAsAsync<PessoaTipoTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
                    mensagemRetono = $"Acesso ao serviço {nomeServico} ConsultarPorId não autorizado";
                } else {
                    mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} ConsultarPorId";
                }

                if (!string.IsNullOrEmpty(mensagemRetono)) {
                    pessoaTipo = new PessoaTipoTransfer();
                    
                    pessoaTipo.Validacao = false;
                    pessoaTipo.Erro = true;
                    pessoaTipo.IncluirErroMensagem(mensagemRetono);
                }
            } catch (Exception ex) {
                pessoaTipo = new PessoaTipoTransfer();

                pessoaTipo.Validacao = false;
                pessoaTipo.Erro = true;
                pessoaTipo.IncluirErroMensagem("Erro em PessoaTipoService ConsultarPorId [" + ex.Message + "]");
            } finally {
                resposta = null;
            }

            return pessoaTipo;
        }

        public async Task<PessoaTipoTransfer> Consultar(PessoaTipoTransfer pessoaTipoListaTransfer)
        {
            PessoaTipoTransfer pessoaTipoLista = null;
            HttpResponseMessage resposta = null;
            string mensagemRetono = null;
            
            try {
                autorizacao = await autenticaService.Autorizar();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorizacao);

                resposta = await httpClient.PostAsJsonAsync($"{nomeServico}/lista", pessoaTipoListaTransfer);

                if (resposta.IsSuccessStatusCode) {
                    pessoaTipoLista = resposta.Content.ReadAsAsync<PessoaTipoTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    pessoaTipoLista = resposta.Content.ReadAsAsync<PessoaTipoTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
                    mensagemRetono = $"Acesso ao serviço {nomeServico} Consultar não autorizado";
                } else {
                    mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} Consultar";
                }

                if (!string.IsNullOrEmpty(mensagemRetono)) {
                    pessoaTipoLista = new PessoaTipoTransfer();
                    
                    pessoaTipoLista.Validacao = false;
                    pessoaTipoLista.Erro = true;
                    pessoaTipoLista.IncluirErroMensagem(mensagemRetono);
                }
            } catch (Exception ex) {
                pessoaTipoLista = new PessoaTipoTransfer();

                pessoaTipoLista.Validacao = false;
                pessoaTipoLista.Erro = true;
                pessoaTipoLista.IncluirErroMensagem("Erro em PessoaTipoService Consultar [" + ex.Message + "]");
            } finally {
                resposta = null;
            }

            return pessoaTipoLista;
        }
    }
}
