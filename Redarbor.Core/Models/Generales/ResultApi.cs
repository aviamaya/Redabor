using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Redarbor.Core.Models.Generales
{
    public class ResultApi
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        /// <summary>
        /// Almacena el objeto de respuesta retornado por la petición exitosa.
        /// </summary>
        public object Result { get; set; }
        public HttpStatusCode EstadoPeticion { get; set; }
    }

    public class CustomResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }

    public class DocumentoEncontrado
    {
        public short TipoDocumento { get; set; }
        public string GestorId { get; set; }
        public bool? Valido { get; set; }
        public string Observaciones { get; set; }
        public DateTime? FechaRevision { get; set; }
    }
}
