﻿using System;
using rcDominiosDataTransfers;
using rcDominiosUtils;

namespace rcDominiosBusiness
{
    public class CorBusiness
    {
        public CorDataTransfer Validar(CorDataTransfer corDataTransfer) 
        {
            CorDataTransfer corValidacao;

            try  {
                corValidacao = new CorDataTransfer(corDataTransfer);
                corValidacao.Cor.Descricao = Tratamento.TratarStringNuloBranco(corValidacao.Cor.Descricao);
                corValidacao.Cor.Codigo = Tratamento.TratarStringNuloBranco(corValidacao.Cor.Codigo);

                //-- Descrição do Tipo de Pessoa
                if (string.IsNullOrEmpty(corValidacao.Cor.Descricao)) {
                    corValidacao.IncluirValidacaoMensagem("Necessário informar a Descrição da Cor");
                } else if (corValidacao.Cor.Descricao.Length > 100) {
                    corValidacao.IncluirValidacaoMensagem("Descrição deve ter no máximo 100 caracteres");
                } else if (!Validacao.ValidarCharAaBCcNT(corValidacao.Cor.Descricao)) {
                    corValidacao.IncluirValidacaoMensagem("Descrição possui caracteres inválidos");
                    corValidacao.IncluirValidacaoMensagem("Caracteres válidos: letras, acentos, números, traço e espaço em branco");
                }

                //-- Código do Tipo de Pessoa
                if (!string.IsNullOrEmpty(corValidacao.Cor.Codigo)) {
                    if (corValidacao.Cor.Codigo.Length > 10) {
                        corValidacao.IncluirValidacaoMensagem("Código deve ter no máximo 10 caracteres");
                    } else if(!Validacao.ValidarCharAaNT(corValidacao.Cor.Codigo)) {
                        corValidacao.IncluirValidacaoMensagem("Código possui caracteres inválidos");
                        corValidacao.IncluirValidacaoMensagem("Caracteres válidos: letras, números e traço");
                    }
                }

                corValidacao.Validacao = true;

                if (corValidacao.ValidacaoMensagens != null) {
                    if (corValidacao.ValidacaoMensagens.Count > 0) {
                        corValidacao.Validacao = false;
                    }
                }

                corValidacao.Erro = false;
            } catch (Exception ex) {
                corValidacao = new CorDataTransfer();

                corValidacao.IncluirErroMensagem("Erro em CorBusiness Validar [" + ex.Message + "]");
                corValidacao.Validacao = false;
                corValidacao.Erro = true;
            }

            return corValidacao;
        }

        public CorDataTransfer ValidarConsulta(CorDataTransfer corDataTransfer) 
        {
            CorDataTransfer corValidacao;

            try  {
                corValidacao = new CorDataTransfer(corDataTransfer);
                corValidacao.Cor.Descricao = Tratamento.TratarStringNuloBranco(corValidacao.Cor.Descricao);
                corValidacao.Cor.Codigo = Tratamento.TratarStringNuloBranco(corValidacao.Cor.Codigo);

                //-- Id
                if ((corValidacao.IdDe <= 0) && (corValidacao.IdAte > 0)) {
                    corValidacao.IncluirValidacaoMensagem("Informe apenas o Id (De) para consultar um Id específico, ou os valores De e Até para consultar uma faixa de Id");
                } else if ((corValidacao.IdDe > 0) && (corValidacao.IdAte > 0)) {
                    if (corValidacao.IdDe >= corValidacao.IdAte) {
                        corValidacao.IncluirValidacaoMensagem("O valor mínimo (De) do Id deve ser menor que o valor máximo (Até)");
                    }
                }

                //-- Descrição do Tipo de Pessoa
                if (!string.IsNullOrEmpty(corValidacao.Cor.Descricao)) {
                    if (corValidacao.Cor.Descricao.Length > 100) {
                        corValidacao.IncluirValidacaoMensagem("Descrição deve ter no máximo 100 caracteres");
                    } else if (!Validacao.ValidarCharAaBCcNT(corValidacao.Cor.Descricao)) {
                        corValidacao.IncluirValidacaoMensagem("Descrição possui caracteres inválidos");
                        corValidacao.IncluirValidacaoMensagem("Caracteres válidos: letras, acentos, números, traço e espaço em branco");
                    }
                }

                //-- Código do Tipo de Pessoa
                if (!string.IsNullOrEmpty(corValidacao.Cor.Codigo)) {
                    if (corValidacao.Cor.Codigo.Length > 10) {
                        corValidacao.IncluirValidacaoMensagem("Código deve ter no máximo 10 caracteres");
                    } else if(!Validacao.ValidarCharAaNT(corValidacao.Cor.Codigo)) {
                        corValidacao.IncluirValidacaoMensagem("Código possui caracteres inválidos");
                        corValidacao.IncluirValidacaoMensagem("Caracteres válidos: letras, números e traço");
                    }
                }

                //-- Data de Criação
                if ((corValidacao.CriacaoDe == DateTime.MinValue) && (corValidacao.CriacaoAte != DateTime.MinValue)) {
                    corValidacao.IncluirValidacaoMensagem("Informe apenas a Data de Criação (De) para consultar uma data específica, ou os valores De e Até para consultar uma faixa de datas");
                } else if ((corValidacao.CriacaoDe > DateTime.MinValue) && (corValidacao.CriacaoAte > DateTime.MinValue)) {
                    if (corValidacao.CriacaoDe >= corValidacao.CriacaoAte) {
                        corValidacao.IncluirValidacaoMensagem("O valor mínimo (De) da Data de Criação deve ser menor que o valor máximo (Até)");
                    }
                }

                //-- Data de Alteração
                if ((corValidacao.AlteracaoDe == DateTime.MinValue) && (corValidacao.AlteracaoAte != DateTime.MinValue)) {
                    corValidacao.IncluirValidacaoMensagem("Informe apenas a Data de Alteração (De) para consultar uma data específica, ou os valores De e Até para consultar uma faixa de datas");
                } else if ((corValidacao.AlteracaoDe > DateTime.MinValue) && (corValidacao.AlteracaoAte > DateTime.MinValue)) {
                    if (corValidacao.AlteracaoDe >= corValidacao.AlteracaoAte) {
                        corValidacao.IncluirValidacaoMensagem("O valor mínimo (De) da Data de Alteração deve ser menor que o valor máximo (Até)");
                    }
                }

                corValidacao.Validacao = true;

                if (corValidacao.ValidacaoMensagens != null) {
                    if (corValidacao.ValidacaoMensagens.Count > 0) {
                        corValidacao.Validacao = false;
                    }
                }

                corValidacao.Erro = false;
            } catch (Exception ex) {
                corValidacao = new CorDataTransfer();

                corValidacao.IncluirErroMensagem("Erro em CorBusiness Validar [" + ex.Message + "]");
                corValidacao.Validacao = false;
                corValidacao.Erro = true;
            }

            return corValidacao;
        }
    }
}
