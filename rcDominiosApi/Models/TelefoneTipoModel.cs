using System;
using rcDominiosBusiness;
using rcDominiosDataModels;
using rcDominiosDataTransfers;

namespace rcDominiosApi.Models
{
    public class TelefoneTipoModel
    {
        public TelefoneTipoDataTransfer Incluir(TelefoneTipoDataTransfer telefoneTipoDataTransfer)
        {
            TelefoneTipoDataModel telefoneTipoDataModel;
            TelefoneTipoBusiness telefoneTipoBusiness;
            TelefoneTipoDataTransfer telefoneTipoDTValidacao;
            TelefoneTipoDataTransfer telefoneTipoDTInclusao;

            try {
                telefoneTipoBusiness = new TelefoneTipoBusiness();
                telefoneTipoDataModel = new TelefoneTipoDataModel();

                telefoneTipoDataTransfer.TelefoneTipo.Criacao = DateTime.Today;
                telefoneTipoDataTransfer.TelefoneTipo.Alteracao = DateTime.Today;

                telefoneTipoDTValidacao = telefoneTipoBusiness.Validar(telefoneTipoDataTransfer);

                if (!telefoneTipoDTValidacao.Erro) {
                    if (telefoneTipoDTValidacao.Validacao) {
                        telefoneTipoDTInclusao = telefoneTipoDataModel.Incluir(telefoneTipoDTValidacao);
                    } else {
                        telefoneTipoDTInclusao = new TelefoneTipoDataTransfer(telefoneTipoDTValidacao);
                    }
                } else {
                    telefoneTipoDTInclusao = new TelefoneTipoDataTransfer(telefoneTipoDTValidacao);
                }
            } catch (Exception ex) {
                telefoneTipoDTInclusao = new TelefoneTipoDataTransfer();

                telefoneTipoDTInclusao.Validacao = false;
                telefoneTipoDTInclusao.Erro = true;
                telefoneTipoDTInclusao.ErroMensagens.Add("Erro em TelefoneTipoModel Incluir [" + ex.Message + "]");
            } finally {
                telefoneTipoDataModel = null;
                telefoneTipoBusiness = null;
                telefoneTipoDTValidacao = null;
            }

            return telefoneTipoDTInclusao;
        }

        public TelefoneTipoDataTransfer Alterar(TelefoneTipoDataTransfer telefoneTipoDataTransfer)
        {
            TelefoneTipoDataModel telefoneTipoDataModel;
            TelefoneTipoBusiness telefoneTipoBusiness;
            TelefoneTipoDataTransfer telefoneTipoDTValidacao;
            TelefoneTipoDataTransfer telefoneTipoDTAlteracao;

            try {
                telefoneTipoBusiness = new TelefoneTipoBusiness();
                telefoneTipoDataModel = new TelefoneTipoDataModel();

                telefoneTipoDataTransfer.TelefoneTipo.Alteracao = DateTime.Today;

                telefoneTipoDTValidacao = telefoneTipoBusiness.Validar(telefoneTipoDataTransfer);

                if (!telefoneTipoDTValidacao.Erro) {
                    if (telefoneTipoDTValidacao.Validacao) {
                        telefoneTipoDTAlteracao = telefoneTipoDataModel.Alterar(telefoneTipoDTValidacao);
                    } else {
                        telefoneTipoDTAlteracao = new TelefoneTipoDataTransfer(telefoneTipoDTValidacao);
                    }
                } else {
                    telefoneTipoDTAlteracao = new TelefoneTipoDataTransfer(telefoneTipoDTValidacao);
                }
            } catch (Exception ex) {
                telefoneTipoDTAlteracao = new TelefoneTipoDataTransfer();

                telefoneTipoDTAlteracao.Validacao = false;
                telefoneTipoDTAlteracao.Erro = true;
                telefoneTipoDTAlteracao.ErroMensagens.Add("Erro em TelefoneTipoModel Alterar [" + ex.Message + "]");
            } finally {
                telefoneTipoDataModel = null;
                telefoneTipoBusiness = null;
                telefoneTipoDTValidacao = null;
            }

            return telefoneTipoDTAlteracao;
        }

        public TelefoneTipoDataTransfer Excluir(int id)
        {
            TelefoneTipoDataModel telefoneTipoDataModel;
            TelefoneTipoDataTransfer telefoneTipoDTExclusao;

            try {
                telefoneTipoDataModel = new TelefoneTipoDataModel();

                telefoneTipoDTExclusao = telefoneTipoDataModel.Excluir(id);
            } catch (Exception ex) {
                telefoneTipoDTExclusao = new TelefoneTipoDataTransfer();

                telefoneTipoDTExclusao.Validacao = false;
                telefoneTipoDTExclusao.Erro = true;
                telefoneTipoDTExclusao.ErroMensagens.Add("Erro em TelefoneTipoModel Excluir [" + ex.Message + "]");
            } finally {
                telefoneTipoDataModel = null;
            }

            return telefoneTipoDTExclusao;
        }

        public TelefoneTipoDataTransfer Listar()
        {
            TelefoneTipoDataModel telefoneTipoDataModel;
            TelefoneTipoBusiness telefoneTipoBusiness;
            TelefoneTipoDataTransfer telefoneTipoDTLista;

            try {
                telefoneTipoBusiness = new TelefoneTipoBusiness();
                telefoneTipoDataModel = new TelefoneTipoDataModel();

                telefoneTipoDTLista = telefoneTipoDataModel.Listar();
            } catch (Exception ex) {
                telefoneTipoDTLista = new TelefoneTipoDataTransfer();

                telefoneTipoDTLista.Validacao = false;
                telefoneTipoDTLista.Erro = true;
                telefoneTipoDTLista.ErroMensagens.Add("Erro em TelefoneTipoModel Listar [" + ex.Message + "]");
            } finally {
                telefoneTipoDataModel = null;
                telefoneTipoBusiness = null;
            }

            return telefoneTipoDTLista;
        }

        public TelefoneTipoDataTransfer ConsultarPorId(int id)
        {
            TelefoneTipoDataModel telefoneTipoDataModel;
            TelefoneTipoDataTransfer telefoneTipoDTForm;
            
            try {
                telefoneTipoDataModel = new TelefoneTipoDataModel();

                telefoneTipoDTForm = telefoneTipoDataModel.ConsultarPorId(id);
            } catch (Exception ex) {
                telefoneTipoDTForm = new TelefoneTipoDataTransfer();

                telefoneTipoDTForm.Validacao = false;
                telefoneTipoDTForm.Erro = true;
                telefoneTipoDTForm.ErroMensagens.Add("Erro em TelefoneTipoModel ConsultarPorId [" + ex.Message + "]");
            } finally {
                telefoneTipoDataModel = null;
            }

            return telefoneTipoDTForm;
        }
    }
}
