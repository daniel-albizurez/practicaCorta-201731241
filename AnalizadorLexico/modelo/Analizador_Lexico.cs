using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AnalizadorLexico.modelo
{
    class Analizador_Lexico
    {
        private string letras = "abcdefghijklmnñopqrstuvwxyz";
        private string numeros = "0123456789";
        public string[,] analizar(string fila)
        {
            string[] palabras = fila.Split(' ');
            string[,] resultado = new string[palabras.Length, 2];
            string tipo;
            for (int i = 0; i < palabras.Length; i++)
            {
                string palabra = palabras[i];
                tipo = (esMoneda(palabra)) ? "Moneda" :
                    (esIdentificador(palabra)) ? "Identificador" :
                    (esEntero(palabra)) ? "Entero" :
                    (esDecimal(palabra)) ? "Decimal" : "Error"
                    ;
                resultado[i, 0] = tipo;
                resultado[i, 1] = palabra;
            }
            return resultado;
        }

        public bool esIdentificador(string palabra)
        {
            bool identificador = true && palabra.Length > 0;
            foreach (char caracter in palabra.ToLower())
            {
                identificador &= letras.Contains(caracter) ;
            }
            return identificador;
        }

        public bool esEntero(string palabra)
        {
            bool numero = true && palabra.Length > 0;
            foreach (char caracter in palabra)
            {
                numero &= numeros.Contains(caracter);
            }
            return numero;
        }

        public bool esDecimal(string palabra)
        {
            string[] parte = palabra.Split('.');
            if (parte.Length == 2)
            {
                return esEntero(parte[0]) && esEntero(parte[1]);
            } else if (parte.Length == 1)
            {
                return esEntero(parte[0]);
            } 
            else
            {
                return false;
            }

        }

        public bool esMoneda(string palabra)
        {
            if (palabra.StartsWith("Q"))
            {
                return esDecimal(palabra.Remove(0, 1));
            } else
            {
                return false;
            }
        }
    }
}
