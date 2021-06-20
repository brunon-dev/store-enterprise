using Microsoft.AspNetCore.Mvc;
using SE.WebApp.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SE.WebApp.MVC.Controllers
{
    public class MainController : Controller
    {
        protected bool ResponsePossuiErros(ResponseResult resposta)
        {
            if(resposta != null && resposta.Errors.Mensagens.Any())
            {
                return true;
            }
            return false;
        }
    }
}
