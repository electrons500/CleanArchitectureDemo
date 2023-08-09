using AutoMapper;
using PropertyToday.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyToday.Application.Dtos
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<NewPropertyRequest, Property>();
            CreateMap<UpdatePropertyRequest, Property>();
            CreateMap<Property, GetPropertyQuery>();
           
        }
    }
}
