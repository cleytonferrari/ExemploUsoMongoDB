using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacao;
using Dominio;

namespace UI.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var usuario = new Usuario();
            System.Console.Write("Digite o nome:");
            usuario.Nome = System.Console.ReadLine();
            System.Console.Write("Digite o Login:");
            usuario.Login = System.Console.ReadLine();
            System.Console.Write("Digite a Senha:");
            usuario.Senha = System.Console.ReadLine();

            var aplicacaoUsuario = new UsuarioAplicacao();
            var retorno = aplicacaoUsuario.Salvar(usuario);
            if (retorno.TemErro)
            {
                foreach (var erro in retorno.ListaErros)
                    System.Console.WriteLine(erro.Valor);

            }
            else
            {
                System.Console.WriteLine("Registro Salvo com sucesso");
            }

            System.Console.Write("Digite o nome:");
            var nome = System.Console.ReadLine();
            var lista = aplicacaoUsuario.ListarUsuarioPorNome(nome);
            foreach (var user in lista)
                System.Console.WriteLine(user.Nome + " - " + user.Login);

            System.Console.ReadKey();
        }
    }
}
