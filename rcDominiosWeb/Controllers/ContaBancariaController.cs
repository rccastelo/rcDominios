using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using rcDominiosWeb.Models;
using rcDominiosTransfers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace rcDominiosWeb.Controllers
{
    [Authorize]
    public class ContaBancariaController : ControllerDominios
    {
        public ContaBancariaController(IHttpContextAccessor accessor)
            :base(accessor)
        {
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewData["Usuario"] = UsuarioNome;

            return View();
        }

        [HttpGet]
        public IActionResult Filtro()
        {
            ViewData["Usuario"] = UsuarioNome;

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Form(int id)
        {
            ContaBancariaModel contaBancariaModel;
            ContaBancariaTransfer contaBancaria;

            try {
                contaBancariaModel = new ContaBancariaModel(httpContext);

                if (id > 0) {
                    contaBancaria = await contaBancariaModel.ConsultarPorId(id);
                } else {
                    contaBancaria = null;
                }
            } catch {
                contaBancaria = new ContaBancariaTransfer();
                
                contaBancaria.Validacao = false;
                contaBancaria.Erro = true;
                contaBancaria.IncluirMensagem("Erro em ContaBancariaController Form");
            } finally {
                contaBancariaModel = null;
            }

            ViewData["Usuario"] = UsuarioNome;

            return View(contaBancaria);
        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            ContaBancariaModel contaBancariaModel;
            ContaBancariaTransfer contaBancariaLista;

            try {
                contaBancariaModel = new ContaBancariaModel(httpContext);

                contaBancariaLista = await contaBancariaModel.Consultar(new ContaBancariaTransfer());
            } catch (Exception ex) {
                contaBancariaLista = new ContaBancariaTransfer();

                contaBancariaLista.Validacao = false;
                contaBancariaLista.Erro = true;
                contaBancariaLista.IncluirMensagem("Erro em ContaBancariaController Lista [" + ex.Message + "]");
            } finally {
                contaBancariaModel = null;
            }

            ViewData["Usuario"] = UsuarioNome;

            return View(contaBancariaLista);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Consulta(ContaBancariaTransfer contaBancariaTransfer)
        {
            ContaBancariaModel contaBancariaModel;
            ContaBancariaTransfer contaBancariaLista;

            try {
                contaBancariaModel = new ContaBancariaModel(httpContext);

                contaBancariaLista = await contaBancariaModel.Consultar(contaBancariaTransfer);
            } catch (Exception ex) {
                contaBancariaLista = new ContaBancariaTransfer();

                contaBancariaLista.Validacao = false;
                contaBancariaLista.Erro = true;
                contaBancariaLista.IncluirMensagem("Erro em ContaBancariaController Consulta [" + ex.Message + "]");
            } finally {
                contaBancariaModel = null;
            }

            ViewData["Usuario"] = UsuarioNome;
            
            if (contaBancariaLista.Erro || !contaBancariaLista.Validacao) {
                return View("Filtro", contaBancariaLista);
            } else {
                return View("Lista", contaBancariaLista);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Inclusao(ContaBancariaTransfer contaBancariaTransfer)
        {
            ContaBancariaModel contaBancariaModel;
            ContaBancariaTransfer contaBancaria;

            try {
                contaBancariaModel = new ContaBancariaModel(httpContext);

                contaBancaria = await contaBancariaModel.Incluir(contaBancariaTransfer);
            } catch (Exception ex) {
                contaBancaria = new ContaBancariaTransfer();

                contaBancaria.Validacao = false;
                contaBancaria.Erro = true;
                contaBancaria.IncluirMensagem("Erro em ContaBancariaController Inclusao [" + ex.Message + "]");
            } finally {
                contaBancariaModel = null;
            }

            ViewData["Usuario"] = UsuarioNome;

            if (contaBancaria.Erro || !contaBancaria.Validacao) {
                return View("Form", contaBancaria);
            } else {
                return RedirectToAction("Lista");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Alteracao(ContaBancariaTransfer contaBancariaTransfer)
        {
            ContaBancariaModel contaBancariaModel;
            ContaBancariaTransfer contaBancaria;

            try {
                contaBancariaModel = new ContaBancariaModel(httpContext);

                contaBancaria = await contaBancariaModel.Alterar(contaBancariaTransfer);
            } catch (Exception ex) {
                contaBancaria = new ContaBancariaTransfer();

                contaBancaria.Validacao = false;
                contaBancaria.Erro = true;
                contaBancaria.IncluirMensagem("Erro em ContaBancariaController Alteracao [" + ex.Message + "]");
            } finally {
                contaBancariaModel = null;
            }

            ViewData["Usuario"] = UsuarioNome;

            if (contaBancaria.Erro || !contaBancaria.Validacao) {
                return View("Form", contaBancaria);
            } else {
                return RedirectToAction("Lista");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Exclusao(int id)
        {
            ContaBancariaModel contaBancariaModel;
            ContaBancariaTransfer contaBancaria;

            try {
                contaBancariaModel = new ContaBancariaModel(httpContext);

                contaBancaria = await contaBancariaModel.Excluir(id);
            } catch (Exception ex) {
                contaBancaria = new ContaBancariaTransfer();

                contaBancaria.Validacao = false;
                contaBancaria.Erro = true;
                contaBancaria.IncluirMensagem("Erro em ContaBancariaController Exclusao [" + ex.Message + "]");
            } finally {
                contaBancariaModel = null;
            }

            ViewData["Usuario"] = UsuarioNome;

            if (contaBancaria.Erro || !contaBancaria.Validacao) {
                return View("Form", contaBancaria);
            } else {
                return RedirectToAction("Lista");
            }
        }
    }
}
