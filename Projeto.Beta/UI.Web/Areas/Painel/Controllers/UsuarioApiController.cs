using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Aplicacao;
using Dominio;

namespace UI.Web.Areas.Painel.Controllers
{
    public class UsuarioApiController : ApiController
    {
        private UsuarioAplicacao usuarioAplicacao;

        public ICollection<Usuario> Get(string filtro = "", string busca = "")
        {
            usuarioAplicacao = new UsuarioAplicacao();

            if (string.IsNullOrEmpty(busca))
                return usuarioAplicacao.ListarUsuario();
            switch (filtro.ToLower())
            {
                case "nome":
                    return usuarioAplicacao.ListarUsuarioPorNome(busca);
                case "login":
                    return usuarioAplicacao.ListarUsuarioPorLogin(busca);
                default:
                    return usuarioAplicacao.ListarUsuario();
            }
        }
    }
}
