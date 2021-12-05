using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HogwartsApi.Application;
using HogwartsApi.Domain.Entities;
using HogwartsApi.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HogwartsApi.Controllers
{
    /// <summary>
    /// Controlador de solicitudes
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class SolicitudController : ControllerBase
    {
        #region Fields
        /// <summary>
        /// Servicio de aplicacion de prestamos
        /// </summary>
        private readonly SolicitudAppService _solicitudAppService;
        #endregion

        #region Builders
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="solicitudAppService"></param>
        public SolicitudController(SolicitudAppService solicitudAppService)
        {
            _solicitudAppService = solicitudAppService;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Obtiene las solicitudes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var result = await _solicitudAppService.Get();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Obtiene un solicitud por su id
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("{idSolicitud}")]
        public async Task<ActionResult> Get(Guid idSolicitud)
        {
            try
            {
                var result = await _solicitudAppService.Get(idSolicitud);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Crea una solicitud
        /// </summary>
        /// <param name="solicitud"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Post(SolicitudDto solicitud)
        {
            try
            {
                var result = await _solicitudAppService.Add(solicitud);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Actualiza una solicitud
        /// </summary>
        /// <param name="solicitud"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> Put(SolicitudDto solicitud)
        {
            try
            {
                var result = await _solicitudAppService.Update(solicitud);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Elimina una solicitud
        /// </summary>
        /// <param name="idSolicitud"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{idSolicitud}")]
        public async Task<ActionResult> Delete(Guid idSolicitud)
        {
            try
            {
                var result = await _solicitudAppService.Delete(idSolicitud);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion
    }
}
