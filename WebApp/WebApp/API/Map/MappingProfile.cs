using AutoMapper;
using WebApp.Data;

namespace WebApp.API.Map
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        { 
         CreateMap <BlogPosts, BlogPosts> ();
        }
    }
}
