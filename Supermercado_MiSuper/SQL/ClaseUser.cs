using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermercado_MiSuper.SQL
{
    public static class ClaseUser
    {
        private static int idEmpleado;
        private static string nombre;
        private static int idcliente;
        private static string nomcliente;
        private static string nivel;
        private static string correo;
        private static string nombrecorreo;
        private static string contracorreo;
        private static int id;

        //DATOS DEL CLIENTE
        private static int idecliente;
        private static string nombrecliente;
        private static int idfactura;
        

        public static int IdEmpleado { get => idEmpleado; set => idEmpleado = value; }
        public static string Nombre { get => nombre; set => nombre = value; }
        public static int Idcliente { get => idcliente; set => idcliente = value; }
        public static string Nomcliente { get => nomcliente; set => nomcliente = value; }
        public static string Nivel { get => nivel; set => nivel = value; }
        public static string Correo { get => correo; set => correo = value; }
        public static string Nombrecorreo { get => nombrecorreo; set => nombrecorreo = value; }
        public static string Contracorreo { get => contracorreo; set => contracorreo = value; }
        public static int Idecliente { get => idecliente; set => idecliente = value; }
        public static string Nombrecliente { get => nombrecliente; set => nombrecliente = value; }
        public static int Idfactura { get => idfactura; set => idfactura = value; }
        public static int Id { get => id; set => id = value; }
    }
}