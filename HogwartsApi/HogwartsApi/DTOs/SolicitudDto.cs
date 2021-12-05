using HogwartsApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HogwartsApi.DTOs
{
    /// <summary>
    /// DTO de Solicitudes
    /// </summary>
    public class SolicitudDto
    {
        /// <summary>
        /// Identificador solicitud
        /// </summary>
        public Guid? Id { get; set; }
        /// <summary>
        /// Nombre solicitante
        /// </summary>
        [Required]
        [StringLength(20, ErrorMessage = "El nombre no puede tener más de 20 caracteres.")]
        public string Nombre { get; set; }
        /// <summary>
        /// Apellido solicitante
        /// </summary>
        [Required]
        [StringLength(20, ErrorMessage = "El apellido no puede tener más de 20 caracteres.")]
        public string Apellido { get; set; }
        /// <summary>
        /// Número de identificación solicitante
        /// </summary>
        [Required]
        [Range(1, 9999999999, ErrorMessage = "La identificación debe tener solo 10 digitos")]
        public long Identificacion { get; set; }
        /// <summary>
        /// Edad del solcitante
        /// </summary>
        [Required]
        [Range(1, 99, ErrorMessage = "La edad debe tener solo 2 digitos")]
        public Int16 Edad { get; set; }
        /// <summary>
        /// Casa a la que aspira pertenecer
        /// 0 => Gryffindor
        /// 1 => Hufflepuff
        /// 2 => Ravenclaw
        /// 3 => Slytherin
        /// </summary>
        [Required]
        public String Casa { get; set; }
    }
}
