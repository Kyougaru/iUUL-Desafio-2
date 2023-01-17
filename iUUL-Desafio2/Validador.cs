using System;
using System.Collections.Generic;
using System.Globalization;

namespace iUUL_Desafio2
{
    internal enum ErrosConversao
    {
        Origem,
        Destino,
        Valor
    }

    public class Validador
    {
        public IDictionary<Enum, string> ValidarConversao(string origem, string destino, string valor)
        {
            IDictionary<Enum, string> erros = new Dictionary<Enum, string>();

            //Origem
            if (origem.Length != 3)
            {
                erros.Add(ErrosConversao.Origem, "Moeda de origem deve ter exatamente 3 caracteres.");
            }

            //Destino
            if (destino.Length != 3)
            {
                erros.Add(ErrosConversao.Destino, "Moeda de destino deve ter exatamente 3 caracteres.");
            }

            //Origem e Destino
            if (origem == destino)
            {
                erros.Add(ErrosConversao.Origem, "Moeda de origem deve ser diferente da moeda de destino.");
                erros.Add(ErrosConversao.Destino, "Moeda de destino deve ser diferente da moeda de origem.");
            }
            
            //Valor
            if (!double.TryParse(valor, NumberStyles.Any, new CultureInfo("pt-BR"), out double valorValido))
            {
                erros.Add(ErrosConversao.Valor, "Valor deve ser um decimal válido.");
            } else if (valorValido <= 0)
            {
                erros.Add(ErrosConversao.Valor, "Valor a ser convertido deve ser maior que zero.");
            }

            return erros;
        }
    }
}
