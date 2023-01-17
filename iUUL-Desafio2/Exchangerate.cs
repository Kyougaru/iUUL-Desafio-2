using System;
using System.Text.Json.Serialization;

namespace iUUL_Desafio2
{
    public class Exchangerate
    {
        private double conversao;
        [property: JsonPropertyName("result")] public double Conversao {
            get { return conversao; }
            set { conversao = Math.Round(value, 2); }
        }
        [property: JsonPropertyName("info")] public Info Info { get; set; }
    }
}
