using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class VerificaErros
    {
        public ObjetoRetorno<T> Verifica<T>() where T : class
        {
            var objetoRetorno = new ObjetoRetorno<T>();
            var resultados = new List<ValidationResult>();
            var isvalid = Validator.TryValidateObject(this, new ValidationContext(this, null, null), resultados, true);
            if (!isvalid)
            {
                foreach (var item in resultados)
                {
                    foreach (var r in item.MemberNames)
                        objetoRetorno.AdicionarUmErro(typeof (T).Name + "." + r, item.ErrorMessage);
                }
            }
            return objetoRetorno;
        }
    }
}
