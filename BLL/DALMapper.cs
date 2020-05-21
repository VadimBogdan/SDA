using AutoMapper;

namespace BLL
{
    class DALMapper
    {
        private static readonly DALMapper instance = new DALMapper();
        private IMapper mapper;

        public static DALMapper Instance => instance;

        private DALMapper()
        {
            var config = new MapperConfiguration(cfg =>
             {
                cfg.CreateMap<DTO.User, DAL.Model.User>();
                cfg.CreateMap<DTO.Advertisement, DAL.Model.Advertisement>();
                cfg.CreateMap<DTO.Category, DAL.Model.Category>();
                cfg.CreateMap<DTO.Subcategory, DAL.Model.Subcategory>();
                cfg.CreateMap<DTO.Rubric, DAL.Model.Rubric>();

                cfg.CreateMap<DAL.Model.User, DTO.User>();
                cfg.CreateMap<DAL.Model.Advertisement, DTO.Advertisement>();
                cfg.CreateMap<DAL.Model.Category, DTO.Category>();
                cfg.CreateMap<DAL.Model.Subcategory, DTO.Subcategory>();
                cfg.CreateMap<DAL.Model.Rubric, DTO.Rubric>();
            });
            mapper = config.CreateMapper();
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return mapper.Map<TDestination>(source);
        }
    }
}
