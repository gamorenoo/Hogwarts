using AutoMapper;
using HogwartsApi.Domain.Entities;
using HogwartsApi.DTOs;

namespace HogwartsApi.Automapper
{
    /// <summary>
    /// Automapper
    /// </summary>
    public class GlobalMapperProfile : Profile
    {
        /// <summary>
        /// Inicia una nueva instancia del perfil
        /// </summary>
        public GlobalMapperProfile() : base()
        {
            CreateMap<SolicitudDto, Solicitud>()
                .ForMember(d => d.Casa, o => o.Ignore() );

            CreateMap<Solicitud, SolicitudDto>();
        }
    }
}
