using System;

namespace iUUL_Desafio2
{
    public class Controlador
    {
        public static void Start()
        {
            IO io = new();
            Validador validaConversao = new();

            while (true)
            {
                io.GetDados();
                if (io.Origem == "")
                    break;

                var erros = validaConversao.ValidarConversao(io.Origem, io.Destino, io.Valor);

                if (erros.Count == 0)
                {
                    try
                    {
                        var exchangerate = HttpRequest.Converter(io.Origem, io.Destino, io.Valor);
                        exchangerate.Wait();
                        io.ImprimeConversao(exchangerate.Result);
                    }
                    catch (Exception e)
                    {
                        io.MensagemErro(e.Message);
                    }
                } else
                {
                    io.GetDados(erros);
                }
            }
        }
    }
}
