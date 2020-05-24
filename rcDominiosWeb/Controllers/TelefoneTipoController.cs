using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using rcDominiosWeb.Models;
using rcDominiosTransfers;

namespace rcDominiosWeb.Controllers
{
  public class TelefoneTipoController : Controller
    {
        [HttpGet, HttpPost]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Filtro()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Form(int id)
        {
            TelefoneTipoModel telefoneTipoModel;
            TelefoneTipoTransfer telefoneTipo;

            try {
                telefoneTipoModel = new TelefoneTipoModel();

                if (id > 0) {
                    telefoneTipo = await telefoneTipoModel.ConsultarPorId(id);
                } else {
                    telefoneTipo = null;
                }
            } catch {
                telefoneTipo = new TelefoneTipoTransfer();
                
                telefoneTipo.Validacao = false;
                telefoneTipo.Erro = true;
                telefoneTipo.IncluirErroMensagem("Erro em TelefoneTipoController Form");
            } finally {
                telefoneTipoModel = null;
            }

            return View(telefoneTipo);
        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            TelefoneTipoModel telefoneTipoModel;
            TelefoneTipoTransfer telefoneTipoLista;

            try {
                telefoneTipoModel = new TelefoneTipoModel();

                telefoneTipoLista = await telefoneTipoModel.Consultar(new TelefoneTipoTransfer());
            } catch (Exception ex) {
                telefoneTipoLista = new TelefoneTipoTransfer();

                telefoneTipoLista.Validacao = false;
                telefoneTipoLista.Erro = true;
                telefoneTipoLista.IncluirErroMensagem("Erro em TelefoneTipoController Lista [" + ex.Message + "]");
            } finally {
                telefoneTipoModel = null;
            }

            return View(telefoneTipoLista);
        }

        [HttpPost]
        public async Task<IActionResult> Consulta(TelefoneTipoTransfer telefoneTipoTransfer)
        {
            TelefoneTipoModel telefoneTipoModel;
            TelefoneTipoTransfer telefoneTipoLista;

            try {
                telefoneTipoModel = new TelefoneTipoModel();

                telefoneTipoLista = await telefoneTipoModel.Consultar(telefoneTipoTransfer);
            } catch (Exception ex) {
                telefoneTipoLista = new TelefoneTipoTransfer();

                telefoneTipoLista.Validacao = false;
                telefoneTipoLista.Erro = true;
                telefoneTipoLista.IncluirErroMensagem("Erro em TelefoneTipoController Consulta [" + ex.Message + "]");
            } finally {
                telefoneTipoModel = null;
            }

            if (telefoneTipoLista.Erro || !telefoneTipoLista.Validacao) {
                return View("Filtro", telefoneTipoLista);
            } else {
                return View("Lista", telefoneTipoLista);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Inclusao(TelefoneTipoTransfer telefoneTipoTransfer)
        {
            TelefoneTipoModel telefoneTipoModel;
            TelefoneTipoTransfer telefoneTipo;

            try {
                telefoneTipoModel = new TelefoneTipoModel();

                telefoneTipo = await telefoneTipoModel.Incluir(telefoneTipoTransfer);
            } catch (Exception ex) {
                telefoneTipo = new TelefoneTipoTransfer();

                telefoneTipo.Validacao = false;
                telefoneTipo.Erro = true;
                telefoneTipo.IncluirErroMensagem("Erro em TelefoneTipoController Inclusao [" + ex.Message + "]");
            } finally {
                telefoneTipoModel = null;
            }

            if (telefoneTipo.Erro || !telefoneTipo.Validacao) {
                return View("Form", telefoneTipo);
            } else {
                return RedirectToAction("Lista");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Alteracao(TelefoneTipoTransfer telefoneTipoTransfer)
        {
            TelefoneTipoModel telefoneTipoModel;
            TelefoneTipoTransfer telefoneTipo;

            try {
                telefoneTipoModel = new TelefoneTipoModel();

                telefoneTipo = await telefoneTipoModel.Alterar(telefoneTipoTransfer);
            } catch (Exception ex) {
                telefoneTipo = new TelefoneTipoTransfer();

                telefoneTipo.Validacao = false;
                telefoneTipo.Erro = true;
                telefoneTipo.IncluirErroMensagem("Erro em TelefoneTipoController Alteracao [" + ex.Message + "]");
            } finally {
                telefoneTipoModel = null;
            }

            if (telefoneTipo.Erro || !telefoneTipo.Validacao) {
                return View("Form", telefoneTipo);
            } else {
                return RedirectToAction("Lista");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Exclusao(int id)
        {
            TelefoneTipoModel telefoneTipoModel;
            TelefoneTipoTransfer telefoneTipo;

            try {
                telefoneTipoModel = new TelefoneTipoModel();

                telefoneTipo = await telefoneTipoModel.Excluir(id);
            } catch (Exception ex) {
                telefoneTipo = new TelefoneTipoTransfer();

                telefoneTipo.Validacao = false;
                telefoneTipo.Erro = true;
                telefoneTipo.IncluirErroMensagem("Erro em TelefoneTipoController Exclusao [" + ex.Message + "]");
            } finally {
                telefoneTipoModel = null;
            }

            if (telefoneTipo.Erro || !telefoneTipo.Validacao) {
                return View("Form", telefoneTipo);
            } else {
                return RedirectToAction("Lista");
            }
        }
    }
}
