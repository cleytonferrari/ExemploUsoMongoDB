using System.Linq;
using Aplicacao;
using Dominio;

namespace UI.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            DesenhaMenu();
        }

        private static void DesenhaMenu()
        {
            System.Console.Clear();
            System.Console.WriteLine("MENU");
            System.Console.WriteLine("1 - Cadastrar Usuário");
            System.Console.WriteLine("2 - Pesquisar Usuário");
            System.Console.Write("Escolha uma opção: ");
            var opcao = System.Console.ReadLine();
            switch (opcao)
            {
                case "1": CadastrarUsuario();
                    break;
                case "2": ListarUsuario();
                    break;
                default: DesenhaMenu();
                    break;
            }
        }

        private static void ListarUsuario()
        {
            System.Console.Clear();
            var aplicacaoUsuario = new UsuarioAplicacao();
            System.Console.WriteLine("BUSCAR USUÁRIOS");
            System.Console.Write("Digite o nome: ");
            var nome = System.Console.ReadLine();
            var lista = aplicacaoUsuario.ListarUsuarioPorNome(nome);
            if (lista.Any())
            {
                foreach (var user in lista)
                    System.Console.WriteLine(user.Nome + " - " + user.Login);
            }
            else
            {
                System.Console.Write("\nNão foram encontrados resultados!");
            }


            System.Console.Write("\nDeseja pesquisar novamente? (1-Sim 2-Não): ");
            var opcao = System.Console.ReadLine();
            if (opcao == "1")
                ListarUsuario();

            DesenhaMenu();
        }

        private static void CadastrarUsuario()
        {
            System.Console.Clear();
            var usuario = new Usuario();
            System.Console.WriteLine("CADASTRO DE USUÁRIOS");
            System.Console.Write("Digite o nome: ");
            usuario.Nome = System.Console.ReadLine();
            System.Console.Write("Digite o Login: ");
            usuario.Login = System.Console.ReadLine();
            System.Console.Write("Digite a Senha: ");
            usuario.Senha = System.Console.ReadLine();

            var aplicacaoUsuario = new UsuarioAplicacao();
            var retorno = aplicacaoUsuario.Salvar(usuario);
            if (retorno.TemErro)
            {
                System.Console.WriteLine("\nOs seguintes erros foram encontrados:");
                foreach (var erro in retorno.ListaErros)
                    System.Console.WriteLine("\t" + erro.Valor);
            }
            else
            {
                System.Console.WriteLine("Registro Salvo com sucesso!");
            }
            System.Console.Write("\nDeseja cadastrar novamente? (1-Sim 2-Não): ");
            var opcao = System.Console.ReadLine();
            if (opcao == "1")
                CadastrarUsuario();

            DesenhaMenu();
        }
    }
}
