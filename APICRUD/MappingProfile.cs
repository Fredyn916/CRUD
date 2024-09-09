using APICRUD._01___Entidades.DTOs.Aluno;
using APICRUD._01___Entidades.DTOs.Cidade;
using APICRUD._01___Entidades.DTOs.Time;
using AutoMapper;
using CRUD.Entidades;

namespace APICRUD
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateAlunoDTO, Aluno>().ReverseMap();
            CreateMap<CreateCidadeDTO, Cidade>().ReverseMap();
            CreateMap<CreateTimeDTO, Time>().ReverseMap();
        }
    }
}
