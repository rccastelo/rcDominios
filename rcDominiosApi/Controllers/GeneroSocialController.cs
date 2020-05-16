using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rcDominiosApi.Models;
using rcDominiosDataTransfers;

namespace rcDominiosApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class GeneroSocialController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult Form(int id)
        {
            GeneroSocialModel generoSocialModel;
            GeneroSocialDataTransfer generoSocialForm;

            try {
                generoSocialModel = new GeneroSocialModel();

                if (id > 0) {
                    generoSocialForm = generoSocialModel.ConsultarPorId(id);
                } else {
                    generoSocialForm = null;
                }
            } catch (Exception ex) {
                generoSocialForm = new GeneroSocialDataTransfer();
                
                generoSocialForm.Validacao = false;
                generoSocialForm.Erro = true;
                generoSocialForm.ErroMensagens.Add("Erro em GeneroSocialController Form [" + ex.Message + "]");
            } finally {
                generoSocialModel = null;
            }

            if (generoSocialForm.Erro || !generoSocialForm.Validacao) {
                return BadRequest(generoSocialForm);
            } else {
                return Ok(generoSocialForm);
            }
        }

        [HttpGet]
        public IActionResult Lista()
        {
            GeneroSocialModel generoSocialModel;
            GeneroSocialDataTransfer generoSocialLista;

            try {
                generoSocialModel = new GeneroSocialModel();

                generoSocialLista = generoSocialModel.Listar();
            } catch (Exception ex) {
                generoSocialLista = new GeneroSocialDataTransfer();

                generoSocialLista.Validacao = false;
                generoSocialLista.Erro = true;
                generoSocialLista.ErroMensagens.Add("Erro em GeneroSocialController Lista [" + ex.Message + "]");
            } finally {
                generoSocialModel = null;
            }

            if (generoSocialLista.Erro || !generoSocialLista.Validacao) {
                return BadRequest(generoSocialLista);
            } else {
                return Ok(generoSocialLista);
            }
        }

        [HttpPost]
        public IActionResult Inclusao(GeneroSocialDataTransfer generoSocialDataTransfer)
        {
            GeneroSocialModel generoSocialModel;
            GeneroSocialDataTransfer generoSocialRetorno;

            try {
                generoSocialModel = new GeneroSocialModel();

                generoSocialRetorno = generoSocialModel.Incluir(generoSocialDataTransfer);
            } catch (Exception ex) {
                generoSocialRetorno = new GeneroSocialDataTransfer();

                generoSocialRetorno.Validacao = false;
                generoSocialRetorno.Erro = true;
                generoSocialRetorno.ErroMensagens.Add("Erro em GeneroSocialController Inclusao [" + ex.Message + "]");
            } finally {
                generoSocialModel = null;
            }

            if (generoSocialRetorno.Erro || !generoSocialRetorno.Validacao) {
                return BadRequest(generoSocialRetorno);
            } else {
                string uri = Url.Action("Form", new { id = generoSocialRetorno.GeneroSocial.Id });

                return Created(uri, generoSocialRetorno);
            }
        }

        [HttpPut]
        public IActionResult Alteracao(GeneroSocialDataTransfer generoSocialDataTransfer)
        {
            GeneroSocialModel generoSocialModel;
            GeneroSocialDataTransfer generoSocialRetorno;

            try {
                generoSocialModel = new GeneroSocialModel();

                generoSocialRetorno = generoSocialModel.Alterar(generoSocialDataTransfer);
            } catch (Exception ex) {
                generoSocialRetorno = new GeneroSocialDataTransfer();

                generoSocialRetorno.Validacao = false;
                generoSocialRetorno.Erro = true;
                generoSocialRetorno.ErroMensagens.Add("Erro em GeneroSocialController Alteracao [" + ex.Message + "]");
            } finally {
                generoSocialModel = null;
            }

            if (generoSocialRetorno.Erro || !generoSocialRetorno.Validacao) {
                return BadRequest(generoSocialRetorno);
            } else {
                return Ok(generoSocialRetorno);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Exclusao(int id)
        {
            GeneroSocialModel generoSocialModel;
            GeneroSocialDataTransfer generoSocialRetorno;

            try {
                generoSocialModel = new GeneroSocialModel();

                generoSocialRetorno = generoSocialModel.Excluir(id);
            } catch (Exception ex) {
                generoSocialRetorno = new GeneroSocialDataTransfer();

                generoSocialRetorno.Validacao = false;
                generoSocialRetorno.Erro = true;
                generoSocialRetorno.ErroMensagens.Add("Erro em GeneroSocialController Exclusao [" + ex.Message + "]");
            } finally {
                generoSocialModel = null;
            }

            if (generoSocialRetorno.Erro || !generoSocialRetorno.Validacao) {
                return BadRequest(generoSocialRetorno);
            } else {
                return NoContent();
            }
        }
    }
}
