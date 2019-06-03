using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WevoMVC.Factory;
using WevoMVC.Models;

namespace WevoMVC.Controllers
{
    public class UsuarioController : Controller
    {

        private readonly IOptions<MySettingsModel> appSettings;

        public UsuarioController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ApplicationSettings.WebApiUrl = appSettings.Value.WebApiBaseUrl;
        }

        public IActionResult Cadastro(Usuario u)
        {
            return View(u);
        }

        [HttpPost]
        public async Task<IActionResult> PostCadastro(Usuario u)
        {
            try
            {
                var response = await ApiClientFactory.Instance.cadastra(u);
                u = new Usuario();
                if(response.Data.Id > 0)
                {
                    TempData["Mensagem"] = "Cadastro realizado com sucesso";
                }
                else
                {
                    throw new Exception("Ocorreu um erro. Por favor, contate o administrador do sistema");
                }
                
                return RedirectToAction("Cadastro", u);
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Cadastro", u);
            }
            

            
        }
        
    }
}