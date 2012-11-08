using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using MongoDB.Driver.Linq;
using Repositorio;

namespace Aplicacao
{
    public class UsuarioAplicacao
    {
        private Repositorio<Usuario> usuarioRepositorio;

        public ICollection<Usuario> ListarUsuarioPorNome(string nome)
        {
            usuarioRepositorio = new Repositorio<Usuario>();
            return usuarioRepositorio.Collection.AsQueryable().Where(x => x.Nome.ToLower().Contains(nome.ToLower())).ToList();
        }

        public ICollection<Usuario> ListarUsuarioPorLogin(string login)
        {
            usuarioRepositorio = new Repositorio<Usuario>();
            return usuarioRepositorio.Collection.AsQueryable().Where(x => x.Login.ToLower().Contains(login.ToLower())).ToList();
        }

        public ICollection<Usuario> ListarUsuario()
        {
            usuarioRepositorio = new Repositorio<Usuario>();
            return usuarioRepositorio.Collection.FindAll().ToList();
        }

        public ObjetoRetorno<Usuario> Salvar(Usuario usuario)
        {
            var retorno = usuario.Verifica<Usuario>();
            retorno.SetRetorno(usuario);
            if (retorno.TemErro)
                return retorno;

            usuarioRepositorio = new Repositorio<Usuario>();
            usuarioRepositorio.Collection.Save(usuario);
            return retorno;
        }
    }
}
