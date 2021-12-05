using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HogwartsApi.Domain.Entities
{
    /// <summary>
    /// Solicitud de ingreso
    /// </summary>
    public class Solicitud
    {
        /// <summary>
        /// Identificador solicitud
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Nombre solicitante
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Apellido solicitante
        /// </summary>
        public string Apellido { get; set; }
        /// <summary>
        /// Número de identificación solicitante
        /// </summary>
        public long Identificacion { get; set; }
        /// <summary>
        /// Edad del solcitante
        /// </summary>
        public Int16 Edad { get; set; }
        /// <summary>
        /// Casa a la que aspira pertenecer
        /// 0 => Gryffindor
        /// 1 => Hufflepuff
        /// 2 => Ravenclaw
        /// 3 => Slytherin
        /// </summary>
        public Casas Casa { get; set; }

    }

    /// <summary>
    /// Casas
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Casas
    {
        /// <summary>
        /// Gryffindor
        /// </summary>
        [EnumMember(Value = "Gryffindor")]
        gryffindor,
        /// <summary>
        /// Hufflepuff
        /// </summary>
        [EnumMember(Value = "Hufflepuff")]
        hufflepuff,
        /// <summary>
        /// Ravenclaw
        /// </summary>
        [EnumMember(Value = "Ravenclaw")]
        ravenclaw,
        /// <summary>
        /// Slytherin
        /// </summary>
        [EnumMember(Value = "Slytherin")]
        slytherin
    }
}
