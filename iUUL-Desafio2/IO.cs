using System;
using System.Collections.Generic;

namespace iUUL_Desafio2
{
    public class IO
    {
        public string Origem { get; private set; }
        public string Destino { get; private set; }
        public string Valor { get; private set; }

        public void GetDados()
        {
            GetDados(null);
        }

        public void GetDados(IDictionary<Enum, string> erros)
        {
            if (erros != null)
            {
                Console.WriteLine("\n---------------------------- ERROS ---------------------------");
                foreach (KeyValuePair<Enum, string> erro in erros)
                {
                    Console.WriteLine("Erro: {0}", erro.Value);
                }
                Console.WriteLine("--------------------------------------------------------------\n");
            }

            if (erros == null || erros.ContainsKey(ErrosConversao.Origem))
            {
                Console.Write("Moeda origem: ");
                Origem = Console.ReadLine().ToUpper();
            }
            
            if (Origem != "")
            {
                if (erros == null || erros.ContainsKey(ErrosConversao.Destino))
                {
                    Console.Write("Moeda destino: ");
                    Destino = Console.ReadLine().ToUpper();
                }

                if (erros == null || erros.ContainsKey(ErrosConversao.Valor))
                {
                    Console.Write("Valor: ");
                    Valor = Console.ReadLine();
                }
            }
        }

        public void ImprimeConversao(Exchangerate exchangerate)
        {
            Console.WriteLine("\n{0} {1} => {2} {3}", Origem, Valor, Destino, exchangerate.Conversao);
            Console.WriteLine("Taxa: {0}\n", exchangerate.Info.Taxa);
        }

        public void MensagemErro(string erro)
        {
            Console.WriteLine("\nErro: {0}\n", erro);
        }
    }
}
