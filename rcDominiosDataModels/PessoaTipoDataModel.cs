﻿using System;
using rcDominiosDatas;
using rcDominiosTransfers;
using rcDominiosEntities;

namespace rcDominiosDataModels
{
    public class PessoaTipoDataModel : DataModel
    {
        public PessoaTipoTransfer Incluir(PessoaTipoTransfer pessoaTipoTransfer)
        {
            PessoaTipoData pessoaTipoData;
            PessoaTipoTransfer pessoaTipo;

            try {
                pessoaTipoData = new PessoaTipoData(_contexto);
                pessoaTipo = new PessoaTipoTransfer(pessoaTipoTransfer);

                pessoaTipoData.Incluir(pessoaTipoTransfer.PessoaTipo);

                _contexto.SaveChanges();

                pessoaTipo.PessoaTipo = new PessoaTipoEntity(pessoaTipoTransfer.PessoaTipo);
                pessoaTipo.Validacao = true;
                pessoaTipo.Erro = false;
            } catch (Exception ex) {
                pessoaTipo = new PessoaTipoTransfer();

                pessoaTipo.Validacao = false;
                pessoaTipo.Erro = true;
                pessoaTipo.IncluirMensagem("Erro em PessoaTipoDataModel Incluir [" + ex.Message + "]");
            } finally {
                pessoaTipoData = null;
            }

            return pessoaTipo;
        }

        public PessoaTipoTransfer Alterar(PessoaTipoTransfer pessoaTipoTransfer)
        {
            PessoaTipoData pessoaTipoData;
            PessoaTipoTransfer pessoaTipo;

            try {
                pessoaTipoData = new PessoaTipoData(_contexto);
                pessoaTipo = new PessoaTipoTransfer();

                pessoaTipoData.Alterar(pessoaTipoTransfer.PessoaTipo);

                _contexto.SaveChanges();

                pessoaTipo.PessoaTipo = new PessoaTipoEntity(pessoaTipoTransfer.PessoaTipo);
                pessoaTipo.Validacao = true;
                pessoaTipo.Erro = false;
            } catch (Exception ex) {
                pessoaTipo = new PessoaTipoTransfer();

                pessoaTipo.Validacao = false;
                pessoaTipo.Erro = true;
                pessoaTipo.IncluirMensagem("Erro em PessoaTipoDataModel Alterar [" + ex.Message + "]");
            } finally {
                pessoaTipoData = null;
            }

            return pessoaTipo;
        }

        public PessoaTipoTransfer Excluir(int id)
        {
            PessoaTipoData pessoaTipoData;
            PessoaTipoTransfer pessoaTipo;

            try {
                pessoaTipoData = new PessoaTipoData(_contexto);
                pessoaTipo = new PessoaTipoTransfer();

                pessoaTipo.PessoaTipo = pessoaTipoData.ConsultarPorId(id);
                pessoaTipoData.Excluir(pessoaTipo.PessoaTipo);

                _contexto.SaveChanges();

                pessoaTipo.Validacao = true;
                pessoaTipo.Erro = false;
            } catch (Exception ex) {
                pessoaTipo = new PessoaTipoTransfer();

                pessoaTipo.Validacao = false;
                pessoaTipo.Erro = true;
                pessoaTipo.IncluirMensagem("Erro em PessoaTipoDataModel Excluir [" + ex.Message + "]");
            } finally {
                pessoaTipoData = null;
            }

            return pessoaTipo;
        }

        public PessoaTipoTransfer ConsultarPorId(int id)
        {
            PessoaTipoData pessoaTipoData;
            PessoaTipoTransfer pessoaTipo;

            try {
                pessoaTipoData = new PessoaTipoData(_contexto);
                pessoaTipo = new PessoaTipoTransfer();

                pessoaTipo.PessoaTipo = pessoaTipoData.ConsultarPorId(id);
                pessoaTipo.Validacao = true;
                pessoaTipo.Erro = false;
            } catch (Exception ex) {
                pessoaTipo = new PessoaTipoTransfer();

                pessoaTipo.Validacao = false;
                pessoaTipo.Erro = true;
                pessoaTipo.IncluirMensagem("Erro em PessoaTipoDataModel ConsultarPorId [" + ex.Message + "]");
            } finally {
                pessoaTipoData = null;
            }

            return pessoaTipo;
        }

        public PessoaTipoTransfer Consultar(PessoaTipoTransfer pessoaTipoTransfer)
        {
            PessoaTipoData pessoaTipoData;
            PessoaTipoTransfer pessoaTipoLista;

            try {
                pessoaTipoData = new PessoaTipoData(_contexto);

                pessoaTipoLista = pessoaTipoData.Consultar(pessoaTipoTransfer);
                pessoaTipoLista.Validacao = true;
                pessoaTipoLista.Erro = false;
            } catch (Exception ex) {
                pessoaTipoLista = new PessoaTipoTransfer();

                pessoaTipoLista.Validacao = false;
                pessoaTipoLista.Erro = true;
                pessoaTipoLista.IncluirMensagem("Erro em PessoaTipoDataModel Consultar [" + ex.Message + "]");
            } finally {
                pessoaTipoData = null;
            }

            return pessoaTipoLista;
        }
    }
}
