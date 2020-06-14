using System;
using System.Collections.Generic;
using System.Linq;
using rcDominiosDatabase;
using rcDominiosTransfers;
using rcDominiosEntities;

namespace rcDominiosDatas
{
    public class ProfissaoData : Data<ProfissaoEntity>
    {
        public ProfissaoData(DominiosDbContext contexto) 
            : base(contexto)
        {
        }

        public ProfissaoTransfer Consultar(ProfissaoTransfer profissaoTransfer)
        {
            IQueryable<ProfissaoEntity> query = _contexto.Set<ProfissaoEntity>();
            ProfissaoTransfer profissaoLista = new ProfissaoTransfer(profissaoTransfer);
            IList<ProfissaoEntity> lista = new List<ProfissaoEntity>();

            int pular = 0;
            int registrosPorPagina = 0;
            int totalRegistros = 0;

            //-- Se IdAte não informado, procura Id específico
            if (profissaoTransfer.Filtro.IdAte <= 0) {
                if (profissaoTransfer.Filtro.IdDe > 0) {
                    query = query.Where(et => et.Id == profissaoTransfer.Filtro.IdDe);
                }
            } else {
                //-- Se IdDe e IdAte informados, procura faixa de Id
                if (profissaoTransfer.Filtro.IdDe > 0) {
                    query = query.Where(et => et.Id >= profissaoTransfer.Filtro.IdDe);
                    query = query.Where(et => et.Id <= profissaoTransfer.Filtro.IdAte);
                }
            }

            //-- Descrição
            if (!string.IsNullOrEmpty(profissaoTransfer.Filtro.Descricao)) {
                query = query.Where(et => et.Descricao.Contains(profissaoTransfer.Filtro.Descricao));
            }

            //-- Código
            if (!string.IsNullOrEmpty(profissaoTransfer.Filtro.Codigo)) {
                query = query.Where(et => et.Codigo.Contains(profissaoTransfer.Filtro.Codigo));
            }
            
            //-- Ativo
            if (!string.IsNullOrEmpty(profissaoTransfer.Filtro.Ativo)) {
                bool ativo = true;

                if (profissaoTransfer.Filtro.Ativo == "false") {
                    ativo = false;
                }

                query = query.Where(et => et.Ativo == ativo);
            }

            //-- Se CriacaoAte não informado, procura Data de Criação específica
            if (profissaoTransfer.Filtro.CriacaoAte == DateTime.MinValue) {
                if (profissaoTransfer.Filtro.CriacaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Criacao == profissaoTransfer.Filtro.CriacaoDe);
                }
            } else {
                //-- Se CriacaoDe e CriacaoAte informados, procura faixa de Data de Criação
                if (profissaoTransfer.Filtro.CriacaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Criacao >= profissaoTransfer.Filtro.CriacaoDe);
                    query = query.Where(et => et.Criacao <= profissaoTransfer.Filtro.CriacaoAte);
                }
            }

            //-- Se AlteracaoAte não informado, procura Data de Alteração específica
            if (profissaoTransfer.Filtro.AlteracaoAte == DateTime.MinValue) {
                if (profissaoTransfer.Filtro.AlteracaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Alteracao == profissaoTransfer.Filtro.AlteracaoDe);
                }
            } else {
                //-- Se AlteracaoDe e AlteracaoAte informados, procura faixa de Data de Alteração
                if (profissaoTransfer.Filtro.AlteracaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Alteracao >= profissaoTransfer.Filtro.AlteracaoDe);
                    query = query.Where(et => et.Alteracao <= profissaoTransfer.Filtro.AlteracaoAte);
                }
            }
            
            if (profissaoTransfer.Paginacao.RegistrosPorPagina < 1) {
                registrosPorPagina = 30;
            } else if (profissaoTransfer.Paginacao.RegistrosPorPagina > 200) {
                registrosPorPagina = 30;
            } else {
                registrosPorPagina = profissaoTransfer.Paginacao.RegistrosPorPagina;
            }

            pular = (profissaoTransfer.Paginacao.PaginaAtual < 2 ? 0 : profissaoTransfer.Paginacao.PaginaAtual - 1);
            pular *= registrosPorPagina;
            
            totalRegistros = query.Count();
            lista = query.Skip(pular).Take(registrosPorPagina).ToList();

            profissaoLista.Paginacao.RegistrosPorPagina = registrosPorPagina;
            profissaoLista.Paginacao.TotalRegistros = totalRegistros;
            profissaoLista.Lista = lista;

            return profissaoLista;
        }
    }
}
