using AutoMapper;
using HogwartsApi.Domain.Entities;
using HogwartsApi.Domain.Services;
using HogwartsApi.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogwartsApi.Application
{
    /// <summary>
    /// Servicio de aplicación para la administracion de solicitudes
    /// </summary>
    public class SolicitudAppService
    {
        #region Propiedades
        /// <summary>
        /// Mapper
        /// </summary>
        private readonly IMapper _mapper;
        /// <summary>
        /// Servicio de dominio de solicitudes
        /// </summary>
        private readonly SolicitudDomainService _solicitudDomainService;
        #endregion

        #region Propiedades
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="solicitudDomainService"></param>
        /// <param name="mapper"></param>
        public SolicitudAppService(SolicitudDomainService solicitudDomainService, IMapper mapper)
        {
            _mapper = mapper;
            _solicitudDomainService = solicitudDomainService;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Crea/Registra una solicitud
        /// </summary>
        /// <returns></returns>
        public async Task<SolicitudDto> Add(SolicitudDto solicitudDto)
        {
            Casas casa = (Casas)Enum.Parse(typeof(Casas), solicitudDto.Casa);

            var solicitud = _mapper.Map<Solicitud>(solicitudDto);
            solicitud.Casa = casa;

            solicitudDto = _mapper.Map<SolicitudDto>(await _solicitudDomainService.Add(solicitud));
            
            return solicitudDto;
        }

        /// <summary>
        /// Actualiza una solicitud
        /// </summary>
        /// <returns></returns>
        public async Task<SolicitudDto> Update(SolicitudDto solicitudDto)
        {
            Casas casa = (Casas)Enum.Parse(typeof(Casas), solicitudDto.Casa);

            var solicitud = _mapper.Map<Solicitud>(solicitudDto);
            solicitud.Casa = casa;
            
            solicitudDto = _mapper.Map<SolicitudDto>(await _solicitudDomainService.Update(solicitud));
            
            return solicitudDto;
        }

        /// <summary>
        /// Obtiene una solicitud por su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<SolicitudDto> Get(Guid id)
        {
            var solicitud = await _solicitudDomainService.Get(id);

            return _mapper.Map<SolicitudDto>(solicitud);
        }

        /// <summary>
        /// Obtiene todas las solicitudes
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<SolicitudDto>> Get()
        {
            var listaSolicitudes = await _solicitudDomainService.Get();

            return _mapper.Map<IEnumerable<SolicitudDto>>(listaSolicitudes);
        }

        /// <summary>
        /// Elimina una solicitud
        /// </summary>
        /// <returns></returns>
        public async Task<bool> Delete(Guid id)
        {
            var result = await _solicitudDomainService.Delete(id);

            return result;
        }

        #endregion

    }
}
