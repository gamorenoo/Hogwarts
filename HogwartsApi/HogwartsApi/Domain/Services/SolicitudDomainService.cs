using HogwartsApi.DataAccess.Repositories.IRepositories;
using HogwartsApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogwartsApi.Domain.Services
{
    /// <summary>
    /// Servicio de dominio para la administracion de solicitudes
    /// </summary>
    public class SolicitudDomainService
    {
        #region Propiedades
        /// <summary>
        /// Repositorio de solicitudes
        /// </summary>
        private readonly IGenericRepository<Solicitud> _solicitudRepository;

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="solicitudRepository"></param>
        public SolicitudDomainService(IGenericRepository<Solicitud> solicitudRepository)
        {
            _solicitudRepository = solicitudRepository;
        }

        #endregion

        #region Metodos publicos
        /// <summary>
        /// Crea/Registra una solicitud
        /// </summary>
        /// <param name="solicitud"></param>
        /// <returns></returns>
        public async Task<Solicitud> Add(Solicitud solicitud)
        {
            return await _solicitudRepository.Add(solicitud);
        }

        /// <summary>
        /// Actualiza una solicitud
        /// </summary>
        /// <param name="solicitud"></param>
        /// <returns></returns>
        public async Task<Solicitud> Update(Solicitud solicitud)
        {
            if(solicitud.Id == null || solicitud.Id == Guid.Empty)
            {
                throw new Exception("El Id de la solicitud es requerido.");
            }
            return await _solicitudRepository.Update(solicitud);
        }

        /// <summary>
        /// Obtiene las solicitudes
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Solicitud>> Get()
        {
            return await _solicitudRepository.GetList();
        }

        /// <summary>
        /// Obtiene una solicitud por su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Solicitud> Get(Guid id)
        {
            var result = await _solicitudRepository.GetList(s => s.Id.Equals(id));
            if (result.Count == 0)
            {
                throw new Exception("La solicitud con id " + id.ToString() + " no existe");
            }

            return result.FirstOrDefault();
        }

        /// <summary>
        /// Elimina una solicitud
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> Delete(Guid id)
        {
            var result = await _solicitudRepository.GetList(s => s.Id.Equals(id));
            if (result.Count == 0)
            {
                throw new Exception("La solicitud con id " + id.ToString() + " no existe");
            }
            var solicitud = result.FirstOrDefault();
            await _solicitudRepository.Delete(solicitud);

            return true;
        }
        #endregion

        #region Metodos privados
        /// <summary>
        /// Valida que la identificacion tenga de 10 digitos o menos
        /// </summary>
        /// <param name="Identificacion">Numero a valida</param>
        /// <returns></returns>
        private bool validarIdentificacion(long Identificacion)
        {
            if (Identificacion == 0) return false;

            var cantidadDigitos = Math.Floor(Math.Log10(Identificacion) + 1);

            return cantidadDigitos <= 10;
        }

        /// <summary>
        /// Valida que la identificacion tenga de 10 digitos o menos
        /// </summary>
        /// <param name="Edad">Numero a valida</param>
        /// <returns></returns>
        private bool validarEdad(Int16 Edad)
        {
            if (Edad == 0) return false;

            var cantidadDigitos = Math.Floor(Math.Log10(Edad) + 1);

            return cantidadDigitos <= 2;
        }
        #endregion
    }
}
