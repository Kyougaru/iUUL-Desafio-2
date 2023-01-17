using System;
using System.Text.Json.Serialization;

namespace iUUL_Desafio2
{
    public class Info
    {
        private double taxa;
        [property: JsonPropertyName("rate")] public double Taxa { 
            get { return taxa; }
            set { taxa = Math.Round(value, 6); }
        }
    }
}