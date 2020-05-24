using System;
using rcDominiosBusiness;
using rcDominiosDataModels;
using rcDominiosTransfers;

namespace rcDominiosApi.Models
{
    public class EnderecoTipoModel
    {
        public EnderecoTipoTransfer Incluir(EnderecoTipoTransfer enderecoTipoTransfer)
        {
            EnderecoTipoDataModel enderecoTipoDataModel;
            EnderecoTipoBusiness enderecoTipoBusiness;
            EnderecoTipoTransfer enderecoTipoValidacao;
            EnderecoTipoTransfer enderecoTipoInclusao;

            try {
                enderecoTipoBusiness = new EnderecoTipoBusiness();
                enderecoTipoDataModel = new EnderecoTipoDataModel();

                enderecoTipoTransfer.EnderecoTipo.Criacao = DateTime.Today;
                enderecoTipoTransfer.EnderecoTipo.Alteracao = DateTime.Today;

                enderecoTipoValidacao = enderecoTipoBusiness.Validar(enderecoTipoTransfer);

                if (!enderecoTipoValidacao.Erro) {
                    if (enderecoTipoValidacao.Validacao) {
                        enderecoTipoInclusao = enderecoTipoDataModel.Incluir(enderecoTipoValidacao);
                    } else {
                        enderecoTipoInclusao = new EnderecoTipoTransfer(enderecoTipoValidacao);
                    }
                } else {
                    enderecoTipoInclusao = new EnderecoTipoTransfer(enderecoTipoValidacao);
                }
            } catch (Exception ex) {
                enderecoTipoInclusao = new EnderecoTipoTransfer();

                enderecoTipoInclusao.Validacao = false;
                enderecoTipoInclusao.Erro = true;
                enderecoTipoInclusao.IncluirErroMensagem("Erro em EnderecoTipoModel Incluir [" + ex.Message + "]");
            } finally {
                enderecoTipoDataModel = null;
                enderecoTipoBusiness = null;
                enderecoTipoValidacao = null;
            }

            return enderecoTipoInclusao;
        }

        public EnderecoTipoTransfer Alterar(EnderecoTipoTransfer enderecoTipoTransfer)
        {
            EnderecoTipoDataModel enderecoTipoDataModel;
            EnderecoTipoBusiness enderecoTipoBusiness;
            EnderecoTipoTransfer enderecoTipoValidacao;
            EnderecoTipoTransfer enderecoTipoAlteracao;

            try {
                enderecoTipoBusiness = new EnderecoTipoBusiness();
                enderecoTipoDataModel = new EnderecoTipoDataModel();

                enderecoTipoTransfer.EnderecoTipo.Alteracao = DateTime.Today;

                enderecoTipoValidacao = enderecoTipoBusiness.Validar(enderecoTipoTransfer);

                if (!enderecoTipoValidacao.Erro) {
                    if (enderecoTipoValidacao.Validacao) {
                        enderecoTipoAlteracao = enderecoTipoDataModel.Alterar(enderecoTipoValidacao);
                    } else {
                        enderecoTipoAlteracao = new EnderecoTipoTransfer(enderecoTipoValidacao);
                    }
                } else {
                    enderecoTipoAlteracao = new EnderecoTipoTransfer(enderecoTipoValidacao);
                }
            } catch (Exception ex) {
                enderecoTipoAlteracao = new EnderecoTipoTransfer();

                enderecoTipoAlteracao.Validacao = false;
                enderecoTipoAlteracao.Erro = true;
                enderecoTipoAlteracao.IncluirErroMensagem("Erro em EnderecoTipoModel Alterar [" + ex.Message + "]");
            } finally {
                enderecoTipoDataModel = null;
                enderecoTipoBusiness = null;
                enderecoTipoValidacao = null;
            }

            return enderecoTipoAlteracao;
        }

        public EnderecoTipoTransfer Excluir(int id)
        {
            EnderecoTipoDataModel enderecoTipoDataModel;
            EnderecoTipoTransfer enderecoTipo;

            try {
                enderecoTipoDataModel = new EnderecoTipoDataModel();

                enderecoTipo = enderecoTipoDataModel.Excluir(id);
            } catch (Exception ex) {
                enderecoTipo = new EnderecoTipoTransfer();

                enderecoTipo.Validacao = false;
                enderecoTipo.Erro = true;
                enderecoTipo.IncluirErroMensagem("Erro em EnderecoTipoModel Excluir [" + ex.Message + "]");
            } finally {
                enderecoTipoDataModel = null;
            }

            return enderecoTipo;
        }

        public EnderecoTipoTransfer ConsultarPorId(int id)
        {
            EnderecoTipoDataModel enderecoTipoDataModel;
            EnderecoTipoTransfer enderecoTipo;
            
            try {
                enderecoTipoDataModel = new EnderecoTipoDataModel();

                enderecoTipo = enderecoTipoDataModel.ConsultarPorId(id);
            } catch (Exception ex) {
                enderecoTipo = new EnderecoTipoTransfer();

                enderecoTipo.Validacao = false;
                enderecoTipo.Erro = true;
                enderecoTipo.IncluirErroMensagem("Erro em EnderecoTipoModel ConsultarPorId [" + ex.Message + "]");
            } finally {
                enderecoTipoDataModel = null;
            }

            return enderecoTipo;
        }

        public EnderecoTipoTransfer Consultar(EnderecoTipoTransfer enderecoTipoListaTransfer)
        {
            EnderecoTipoDataModel enderecoTipoDataModel;
            EnderecoTipoBusiness enderecoTipoBusiness;
            EnderecoTipoTransfer enderecoTipoValidacao;
            EnderecoTipoTransfer enderecoTipoLista;

            try {
                enderecoTipoBusiness = new EnderecoTipoBusiness();
                enderecoTipoDataModel = new EnderecoTipoDataModel();

                enderecoTipoValidacao = enderecoTipoBusiness.ValidarConsulta(enderecoTipoListaTransfer);

                if (!enderecoTipoValidacao.Erro) {
                    if (enderecoTipoValidacao.Validacao) {
                        enderecoTipoLista = enderecoTipoDataModel.Consultar(enderecoTipoValidacao);

                        if (enderecoTipoLista != null) {
                            if (enderecoTipoLista.TotalRegistros > 0) {
                                if (enderecoTipoLista.RegistrosPorPagina < 1) {
                                    enderecoTipoLista.RegistrosPorPagina = 30;
                                } else if (enderecoTipoLista.RegistrosPorPagina > 200) {
                                    enderecoTipoLista.RegistrosPorPagina = 30;
                                }
                                enderecoTipoLista.PaginaAtual = (enderecoTipoListaTransfer.PaginaAtual < 1 ? 1 : enderecoTipoListaTransfer.PaginaAtual);
                                enderecoTipoLista.TotalPaginas = 
                                    Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(enderecoTipoLista.TotalRegistros) 
                                    / @Convert.ToDecimal(enderecoTipoLista.RegistrosPorPagina)));
                            }
                        }
                    } else {
                        enderecoTipoLista = new EnderecoTipoTransfer(enderecoTipoValidacao);
                    }
                } else {
                    enderecoTipoLista = new EnderecoTipoTransfer(enderecoTipoValidacao);
                }
            } catch (Exception ex) {
                enderecoTipoLista = new EnderecoTipoTransfer();

                enderecoTipoLista.Validacao = false;
                enderecoTipoLista.Erro = true;
                enderecoTipoLista.IncluirErroMensagem("Erro em EnderecoTipoModel Consultar [" + ex.Message + "]");
            } finally {
                enderecoTipoDataModel = null;
                enderecoTipoBusiness = null;
                enderecoTipoValidacao = null;
            }

            return enderecoTipoLista;
        }
    }
}
