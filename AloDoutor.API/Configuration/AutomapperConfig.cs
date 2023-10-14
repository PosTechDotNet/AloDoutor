using AloDoutor.Api.Application.DTO;
using AloDoutor.Domain.Entity;
using AutoMapper;

namespace AloDoutor.Api.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<AgendamentoDTO, Agendamento>();
            CreateMap<PacienteDTO, Paciente>();
            CreateMap<MedicoDTO, Medico>();
            CreateMap<EspecialidadeDTO, Especialidade>();
            CreateMap<EspecialidadeMedicoDTO, EspecialidadeMedico>();
        }
    }
}
