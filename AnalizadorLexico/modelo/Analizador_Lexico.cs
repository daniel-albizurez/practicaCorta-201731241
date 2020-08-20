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
        // Constantes de conjuntos de caracteres aceptados
        private const string LETRAS = "abcdefghijklmnñopqrstuvwxyz";
        private const string NUMEROS = "0123456789";

        // Método analizar
        // Recibe un texto el cual es dividido en palabras (Separadas por un espacio)
        // Utiliza los métodos definidos abajo, para evaluar el tipo de lexema que recibe
        // Almacena el tipo y la palabra en un arreglo de tipo string de 2 dimensiones
        // Devuelve el arreglo
        public string[,] analizar(string texto)
        {
            string[] palabras = texto.Split(' ');
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
        // Método para evaluar si una palabra es un identificador
        // Recibe una palabra, la cual recorre caracter por caracter
        // Evalua que el caracter sea una letra
        // Devuelve true o false dependiendo si la palabra es un identificador
        public bool esIdentificador(string palabra)
        {
            bool identificador = true && palabra.Length > 0;
            foreach (char caracter in palabra.ToLower())
            {
                identificador &= LETRAS.Contains(caracter) ;
            }
            return identificador;
        }
        // Método para evaluar si una palabra, corresponde a un número entero
        // Recibe una palabra, la cual recorre caracter por caracter
        // Evalua que el caracter sea un número
        // Devuelve true o false dependiendo si la palabra es un número
        public bool esEntero(string palabra)
        {
            bool numero = true && palabra.Length > 0;
            foreach (char caracter in palabra)
            {
                numero &= NUMEROS.Contains(caracter);
            }
            return numero;
        }
        // Método para evaluar si una palabra, corresponde a un número decimal
        // Recibe una palabra, la cual es separada en partes, alrededor de un punto
        // Si las partes son 2 evalua que cada parte corresponda a un número entero
        // Devuelve true o false dependiendo si la palabra es un número decimal
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
        // Método para evaluar si una palabra, corresponde a una moneda
        // Recibe una palabra
        // Evalua que el primer caracter sea igual a Q
        // Luego evalua que el resto de la cadena sea un número
        // Devuelve true o false dependiendo si la palabra es una moneda
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
