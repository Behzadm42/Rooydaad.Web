using AutoMapper;
namespace Rooydaad.Web.Infrustructure
{
    public class AutoMapperProfile: AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Models.Event,Models.EventViewModel>();
        }
    }
}
