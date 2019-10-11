using System.Runtime.Serialization;

namespace MVC_Core.Models
{
    /// <summary>
    /// Clase para poder obtener los datos de la respuesta de la Api.
    /// </summary>
    [DataContract]
    public class DatosBasicosUsuario
    {
        string nombre;
        string direccion;
        int edad;
        public DatosBasicosUsuario(){}


        [DataMember(Name = "Nombre")]
        public string Nombre { get => nombre; set => nombre = value; }
        
        [DataMember(Name = "Direccion")]
        public string Direccion { get => direccion; set => direccion = value; }
        
        [DataMember(Name = "Edad")]
        public int Edad { get => edad; set => edad = value; }
    }
}