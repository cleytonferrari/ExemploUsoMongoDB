using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public struct Erro
    {
        public string Chave { get; set; }
        public string Valor { get; set; }
    }

    public class ObjetoRetorno<T> where T : class
    {
        public ObjetoRetorno()
        {
            ListaErros = new List<Erro>();
            TemErro = false;
        }

        public List<Erro> ListaErros { get; set; }
        public T Retorno { get; private set; }
        public bool TemErro { get; set; }

        public ObjetoRetorno<T> AdicionarUmErro(string chave, string mensagemDeErro)
        {
            ListaErros.Add( new Erro
                                {
                                    Chave = chave,
                                    Valor = mensagemDeErro
                                });
            TemErro = true;
            return this;
        }
        public ObjetoRetorno<T> SetRetorno(T retorno)
        {
            Retorno = retorno;
            return this;
        }
    }
}
