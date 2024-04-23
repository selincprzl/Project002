using AutoMapper;
using Project002.Repository.DTOs;
using Project002.Repository.Interfaces;
using Project002.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project002.Repository.Services
{
    //mapping is transfering data
    public class MappingService : Profile
    {
       public MappingService() 
       {
            CreateMap<Samurai, SamuraiDTO>();
            CreateMap<SamuraiDTO, Samurai>();
       }

    }
}
