using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using rcDominiosTransfers;
using rcDominiosUtils;

namespace rcDominiosWeb.Services
{
  public class ProfissaoService
    {
        private string enderecoServico = Settings.GetSetting(Dominios.servicoApiEndereco.ToString());
        private string nomeServico = "Profissao";
        private HttpClient httpClient = null;
        AutenticaService autenticaService = null;

        public ProfissaoService()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new System.Uri(enderecoServico);
            autenticaService = new AutenticaService();
        }

        public async Task<ProfissaoTransfer> Incluir(ProfissaoTransfer profissaoTransfer, string autorizacao)
        {
            ProfissaoTransfer profissao = null;
            HttpResponseMessage resposta = null;
            string mensagemRetono = null;
            
            try {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorizacao);

                resposta = await httpClient.PostAsJsonAsync($"{nomeServico}", profissaoTransfer);

                if (resposta.IsSuccessStatusCode) {
                    profissao = resposta.Content.ReadAsAsync<ProfissaoTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    profissao = resposta.Content.ReadAsAsync<ProfissaoTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
                    mensagemRetono = $"Acesso ao serviço {nomeServico} Incluir não autorizado";
                } else {
                    mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} Incluir";
                }

                if (!string.IsNullOrEmpty(mensagemRetono)) {
                    profissao = new ProfissaoTransfer();
                    
                    profissao.Validacao = false;
                    profissao.Erro = true;
                    profissao.IncluirMensagem(mensagemRetono);
                }
            } catch (Exception ex) {
                profissao = new ProfissaoTransfer();

                profissao.Validacao = false;
                profissao.Erro = true;
                profissao.IncluirMensagem("Erro em ProfissaoService Incluir [" + ex.Message + "]");
            } finally {
                resposta = null;
            }

            return profissao;
        }

        public async Task<ProfissaoTransfer> Alterar(ProfissaoTransfer profissaoTransfer, string autorizacao)
        {
            ProfissaoTransfer profissao = null;
            HttpResponseMessage resposta = null;
            string mensagemRetono = null;
            
            try {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorizacao);

                resposta = await httpClient.PutAsJsonAsync($"{nomeServico}", profissaoTransfer);

                if (resposta.IsSuccessStatusCode) {
                    profissao = resposta.Content.ReadAsAsync<ProfissaoTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    profissao = resposta.Content.ReadAsAsync<ProfissaoTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
                    mensagemRetono = $"Acesso ao serviço {nomeServico} Alterar não autorizado";
                } else {
                    mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} Alterar";
                }

                if (!string.IsNullOrEmpty(mensagemRetono)) {
                    profissao = new ProfissaoTransfer();
                    
                    profissao.Validacao = false;
                    profissao.Erro = true;
                    profissao.IncluirMensagem(mensagemRetono);
                }
            } catch (Exception ex) {
                profissao = new ProfissaoTransfer();

                profissao.Validacao = false;
                profissao.Erro = true;
                profissao.IncluirMensagem("Erro em ProfissaoService Alterar [" + ex.Message + "]");
            } finally {
                resposta = null;
            }

            return profissao;
        }

        public async Task<ProfissaoTransfer> Excluir(int id, string autorizacao)
        {
            ProfissaoTransfer profissao = null;
            HttpResponseMessage resposta = null;
            string mensagemRetono = null;
            
            try {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorizacao);

                resposta = await httpClient.DeleteAsync($"{nomeServico}/{id}");

                if (resposta.IsSuccessStatusCode) {
                    profissao = resposta.Content.ReadAsAsync<ProfissaoTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    profissao = resposta.Content.ReadAsAsync<ProfissaoTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
                    mensagemRetono = $"Acesso ao serviço {nomeServico} Excluir não autorizado";
                } else {
                    mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} Excluir";
                }

                if (!string.IsNullOrEmpty(mensagemRetono)) {
                    profissao = new ProfissaoTransfer();
                    
                    profissao.Validacao = false;
                    profissao.Erro = true;
                    profissao.IncluirMensagem(mensagemRetono);
                }
            } catch (Exception ex) {
                profissao = new ProfissaoTransfer();

                profissao.Validacao = false;
                profissao.Erro = true;
                profissao.IncluirMensagem("Erro em ProfissaoService Excluir [" + ex.Message + "]");
            } finally {
                resposta = null;
            }

            return profissao;
        }

        public async Task<ProfissaoTransfer> ConsultarPorId(int id, string autorizacao)
        {
            ProfissaoTransfer profissao = null;
            HttpResponseMessage resposta = null;
            string mensagemRetono = null;
            
            try {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorizacao);

                resposta = await httpClient.GetAsync($"{nomeServico}/{id}");

                if (resposta.IsSuccessStatusCode) {
                    profissao = resposta.Content.ReadAsAsync<ProfissaoTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    profissao = resposta.Content.ReadAsAsync<ProfissaoTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
                    mensagemRetono = $"Acesso ao serviço {nomeServico} ConsultarPorId não autorizado";
                } else {
                    mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} ConsultarPorId";
                }

                if (!string.IsNullOrEmpty(mensagemRetono)) {
                    profissao = new ProfissaoTransfer();
                    
                    profissao.Validacao = false;
                    profissao.Erro = true;
                    profissao.IncluirMensagem(mensagemRetono);
                }
            } catch (Exception ex) {
                profissao = new ProfissaoTransfer();

                profissao.Validacao = false;
                profissao.Erro = true;
                profissao.IncluirMensagem("Erro em ProfissaoService ConsultarPorId [" + ex.Message + "]");
            } finally {
                resposta = null;
            }

            return profissao;
        }

        public async Task<ProfissaoTransfer> Consultar(ProfissaoTransfer profissaoListaTransfer, string autorizacao)
        {
            ProfissaoTransfer profissaoLista = null;
            HttpResponseMessage resposta = null;
            string mensagemRetono = null;
            
            try {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorizacao);

                resposta = await httpClient.PostAsJsonAsync($"{nomeServico}/lista", profissaoListaTransfer);

                if (resposta.IsSuccessStatusCode) {
                    profissaoLista = resposta.Content.ReadAsAsync<ProfissaoTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    profissaoLista = resposta.Content.ReadAsAsync<ProfissaoTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
                    mensagemRetono = $"Acesso ao serviço {nomeServico} Consultar não autorizado";
                } else {
                    mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} Consultar";
                }

                if (!string.IsNullOrEmpty(mensagemRetono)) {
                    profissaoLista = new ProfissaoTransfer();
                    
                    profissaoLista.Validacao = false;
                    profissaoLista.Erro = true;
                    profissaoLista.IncluirMensagem(mensagemRetono);
                }
            } catch (Exception ex) {
                profissaoLista = new ProfissaoTransfer();

                profissaoLista.Validacao = false;
                profissaoLista.Erro = true;
                profissaoLista.IncluirMensagem("Erro em ProfissaoService Consultar [" + ex.Message + "]");
            } finally {
                resposta = null;
            }

            return profissaoLista;
        }
    }
}
