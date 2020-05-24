﻿using System;
using rcDominiosTransfers;
using rcDominiosUtils;

namespace rcDominiosBusiness
{
    public class GeneroSocialBusiness
    {
        public GeneroSocialTransfer Validar(GeneroSocialTransfer generoSocialTransfer) 
        {
            GeneroSocialTransfer generoSocialValidacao;

            try  {
                generoSocialValidacao = new GeneroSocialTransfer(generoSocialTransfer);
                generoSocialValidacao.GeneroSocial.Descricao = Tratamento.TratarStringNuloBranco(generoSocialValidacao.GeneroSocial.Descricao);
                generoSocialValidacao.GeneroSocial.Codigo = Tratamento.TratarStringNuloBranco(generoSocialValidacao.GeneroSocial.Codigo);

                //-- Descrição do Tipo de Pessoa
                if (string.IsNullOrEmpty(generoSocialValidacao.GeneroSocial.Descricao)) {
                    generoSocialValidacao.IncluirValidacaoMensagem("Necessário informar a Descrição do Gênero Social");
                } else if (generoSocialValidacao.GeneroSocial.Descricao.Length > 100) {
                    generoSocialValidacao.IncluirValidacaoMensagem("Descrição deve ter no máximo 100 caracteres");
                } else if (!Validacao.ValidarCharAaBCcNT(generoSocialValidacao.GeneroSocial.Descricao)) {
                    generoSocialValidacao.IncluirValidacaoMensagem("Descrição possui caracteres inválidos");
                    generoSocialValidacao.IncluirValidacaoMensagem("Caracteres válidos: letras, acentos, números, traço e espaço em branco");
                }

                //-- Código do Tipo de Pessoa
                if (!string.IsNullOrEmpty(generoSocialValidacao.GeneroSocial.Codigo)) {
                    if (generoSocialValidacao.GeneroSocial.Codigo.Length > 10) {
                        generoSocialValidacao.IncluirValidacaoMensagem("Código deve ter no máximo 10 caracteres");
                    } else if(!Validacao.ValidarCharAaNT(generoSocialValidacao.GeneroSocial.Codigo)) {
                        generoSocialValidacao.IncluirValidacaoMensagem("Código possui caracteres inválidos");
                        generoSocialValidacao.IncluirValidacaoMensagem("Caracteres válidos: letras, números e traço");
                    }
                }

                generoSocialValidacao.Validacao = true;

                if (generoSocialValidacao.ValidacaoMensagens != null) {
                    if (generoSocialValidacao.ValidacaoMensagens.Count > 0) {
                        generoSocialValidacao.Validacao = false;
                    }
                }

                generoSocialValidacao.Erro = false;
            } catch (Exception ex) {
                generoSocialValidacao = new GeneroSocialTransfer();

                generoSocialValidacao.IncluirErroMensagem("Erro em GeneroSocialBusiness Validar [" + ex.Message + "]");
                generoSocialValidacao.Validacao = false;
                generoSocialValidacao.Erro = true;
            }

            return generoSocialValidacao;
        }

        public GeneroSocialTransfer ValidarConsulta(GeneroSocialTransfer generoSocialTransfer) 
        {
            GeneroSocialTransfer generoSocialValidacao;

            try  {
                generoSocialValidacao = new GeneroSocialTransfer(generoSocialTransfer);

                if (generoSocialValidacao != null) {
                    generoSocialValidacao.Descricao = Tratamento.TratarStringNuloBranco(generoSocialValidacao.Descricao);
                    generoSocialValidacao.Codigo = Tratamento.TratarStringNuloBranco(generoSocialValidacao.Codigo);

                    //-- Id
                    if ((generoSocialValidacao.IdDe <= 0) && (generoSocialValidacao.IdAte > 0)) {
                        generoSocialValidacao.IncluirValidacaoMensagem("Informe apenas o Id (De) para consultar um Id específico, ou os valores De e Até para consultar uma faixa de Id");
                    } else if ((generoSocialValidacao.IdDe > 0) && (generoSocialValidacao.IdAte > 0)) {
                        if (generoSocialValidacao.IdDe >= generoSocialValidacao.IdAte) {
                            generoSocialValidacao.IncluirValidacaoMensagem("O valor mínimo (De) do Id deve ser menor que o valor máximo (Até)");
                        }
                    }

                    //-- Descrição do Tipo de Pessoa
                    if (!string.IsNullOrEmpty(generoSocialValidacao.Descricao)) {
                        if (generoSocialValidacao.Descricao.Length > 100) {
                            generoSocialValidacao.IncluirValidacaoMensagem("Descrição deve ter no máximo 100 caracteres");
                        } else if (!Validacao.ValidarCharAaBCcNT(generoSocialValidacao.Descricao)) {
                            generoSocialValidacao.IncluirValidacaoMensagem("Descrição possui caracteres inválidos");
                            generoSocialValidacao.IncluirValidacaoMensagem("Caracteres válidos: letras, acentos, números, traço e espaço em branco");
                        }
                    }

                    //-- Código do Tipo de Pessoa
                    if (!string.IsNullOrEmpty(generoSocialValidacao.Codigo)) {
                        if (generoSocialValidacao.Codigo.Length > 10) {
                            generoSocialValidacao.IncluirValidacaoMensagem("Código deve ter no máximo 10 caracteres");
                        } else if(!Validacao.ValidarCharAaNT(generoSocialValidacao.Codigo)) {
                            generoSocialValidacao.IncluirValidacaoMensagem("Código possui caracteres inválidos");
                            generoSocialValidacao.IncluirValidacaoMensagem("Caracteres válidos: letras, números e traço");
                        }
                    }

                    //-- Data de Criação
                    if ((generoSocialValidacao.CriacaoDe == DateTime.MinValue) && (generoSocialValidacao.CriacaoAte != DateTime.MinValue)) {
                        generoSocialValidacao.IncluirValidacaoMensagem("Informe apenas a Data de Criação (De) para consultar uma data específica, ou os valores De e Até para consultar uma faixa de datas");
                    } else if ((generoSocialValidacao.CriacaoDe > DateTime.MinValue) && (generoSocialValidacao.CriacaoAte > DateTime.MinValue)) {
                        if (generoSocialValidacao.CriacaoDe >= generoSocialValidacao.CriacaoAte) {
                            generoSocialValidacao.IncluirValidacaoMensagem("O valor mínimo (De) da Data de Criação deve ser menor que o valor máximo (Até)");
                        }
                    }

                    //-- Data de Alteração
                    if ((generoSocialValidacao.AlteracaoDe == DateTime.MinValue) && (generoSocialValidacao.AlteracaoAte != DateTime.MinValue)) {
                        generoSocialValidacao.IncluirValidacaoMensagem("Informe apenas a Data de Alteração (De) para consultar uma data específica, ou os valores De e Até para consultar uma faixa de datas");
                    } else if ((generoSocialValidacao.AlteracaoDe > DateTime.MinValue) && (generoSocialValidacao.AlteracaoAte > DateTime.MinValue)) {
                        if (generoSocialValidacao.AlteracaoDe >= generoSocialValidacao.AlteracaoAte) {
                            generoSocialValidacao.IncluirValidacaoMensagem("O valor mínimo (De) da Data de Alteração deve ser menor que o valor máximo (Até)");
                        }
                    }
                } else {
                    generoSocialValidacao = new GeneroSocialTransfer();
                    generoSocialValidacao.IncluirValidacaoMensagem("É necessário informar os dados do Gênero Social");
                }

                generoSocialValidacao.Validacao = true;

                if (generoSocialValidacao.ValidacaoMensagens != null) {
                    if (generoSocialValidacao.ValidacaoMensagens.Count > 0) {
                        generoSocialValidacao.Validacao = false;
                    }
                }

                generoSocialValidacao.Erro = false;
            } catch (Exception ex) {
                generoSocialValidacao = new GeneroSocialTransfer();

                generoSocialValidacao.IncluirErroMensagem("Erro em GeneroSocialBusiness Validar [" + ex.Message + "]");
                generoSocialValidacao.Validacao = false;
                generoSocialValidacao.Erro = true;
            }

            return generoSocialValidacao;
        }
    }
}
