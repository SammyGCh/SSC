using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace LogicaDominio
{
    public static class ValidadorTexto
    {
        private static Regex expresionRegular;
        private const int LONGITUD_MINIMA = 10;
        private const int LONGITUD_MINIMA_NOMBRE = 2;

        public static bool EsExpresionCorrecta(string texto)
        {
            expresionRegular = new Regex(@"[a-zA-Z]");

            return expresionRegular.IsMatch(texto);
        }

        public static bool EsNumeroPersonal(string numeroPersonal)
        {
            expresionRegular = new Regex(@"\b{1}S\d{8}");

            return expresionRegular.IsMatch(numeroPersonal);
        }

        public static bool EsNumero(string numero)
        {
            expresionRegular = new Regex(@"\d");

            return expresionRegular.IsMatch(numero);
        }

        public static bool EsCURP(string curp)
        {
            expresionRegular = new Regex(@"([A-Z][AEIOUX][A-Z]{2}\d{2}(?:0[1-9]|1[0-2])(?:0[1-9]|[12]\d|3[01])[HM](?:AS|B[CS]|C[CLMSH]|D[FG]|G[TR]|HG|JC|M[CNS]|N[ETL]|OC|PL|Q[TR]|S[PLR]|T[CSL]|VZ|YN|ZS)[B-DF-HJ-NP-TV-Z]{3}[A-Z\d])(\d)");

            return expresionRegular.IsMatch(curp);
        }

        public static bool EsRFC(string rfc)
        {
            expresionRegular = new Regex(@"([A-ZÑ&]{3,4}) ?(?:- ?)?(\d{2}(?:0[1-9]|1[0-2])(?:0[1-9]|[12]\d|3[01])) ?(?:- ?)?([A-Z\d]{2})([A\d])");

            return expresionRegular.IsMatch(rfc);
        }

        public static bool EsCorreoElectronico(string correoElectronico)
        {
            expresionRegular = new Regex(@"^(?("")("".+?(?<!\\)"")|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$");

            return expresionRegular.IsMatch(correoElectronico);
        }

        public static bool EsTextoCorrecto(string textoAValidar)
        {
            bool esCorrecto = false;

            if (EsExpresionCorrecta(textoAValidar) && textoAValidar.Length > LONGITUD_MINIMA)
            {
                esCorrecto = true;
            }

            return esCorrecto;
        }

        public static bool EsNombreCorrecto(string nombre)
        {
            bool esCorrecto = false;

            if (EsExpresionCorrecta(nombre) && nombre.Length > LONGITUD_MINIMA_NOMBRE)
            {
                esCorrecto = true;
            }

            return esCorrecto;
        }

        public static bool EsNumeroValido(string numero)
        {
            bool esValido = false;

            if (EsNumero(numero))
            {
                int numeroEntero = int.Parse(numero);
                esValido =  (numeroEntero > 0);
            }

            return esValido;
        }
    }
}
