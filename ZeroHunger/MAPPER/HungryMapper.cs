using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using ZeroHunger.DTOS;
using ZeroHunger.EF;

namespace ZeroHunger.MAPPER
{
    public class HungryMapper
    {
        public Restaurant DTOToRestaurant(RestaurantDTO restaurantDTO)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RestaurantDTO, Restaurant>();
            });
            var mapper = config.CreateMapper();
            return new Restaurant()
            {
                id = restaurantDTO.id,
                restaurantName = restaurantDTO.restaurantName,
                location = restaurantDTO.location,
                contactPersonName = restaurantDTO.contactPersonName,
                contactPersonNumber = restaurantDTO.contactPersonNumber,
                contactPersonDesignation = restaurantDTO.contactPersonDesignation,
                restaurantType = restaurantDTO.restaurantType,
                email = restaurantDTO.email,
                userID = restaurantDTO.userID
            };
        }

        public RestaurantDTO RestaurantToDTO(Restaurant restaurant)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Restaurant, RestaurantDTO>();
            });

            var mapper = config.CreateMapper();
            return new RestaurantDTO()
            {
                id = restaurant.id,
                restaurantName = restaurant.restaurantName,
                location = restaurant.location,
                contactPersonName = restaurant.contactPersonName,
                contactPersonNumber = restaurant.contactPersonNumber,
                contactPersonDesignation = restaurant.contactPersonDesignation,
                restaurantType = restaurant.restaurantType,
                email = restaurant.email,
                userID = restaurant.userID

            };
        }

        public List<RestaurantDTO> RestaurantListToDTO(List<Restaurant> restaurants)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Restaurant, RestaurantDTO>();
            });

            var mapper = config.CreateMapper();
            return mapper.Map<List<RestaurantDTO>>(restaurants);
        }


        public User DTOToUserRestaurant(RestaurantDTO restaurantDTO)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RestaurantDTO, User>();
            });
            var mapper = config.CreateMapper();
            return new User()
            {
                username = restaurantDTO.username,
                password = restaurantDTO.password
            };
        }


        public User DTOToUser(UserDTO userDTO)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RestaurantDTO, User>();
            });
            var mapper = config.CreateMapper();
            return new User()
            {
                username = userDTO.username,
                password = userDTO.password
            };
        }


        public UserDTO UserToDTO(User user)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>();
            });

            var mapper = config.CreateMapper();
            UserDTO userDTO = mapper.Map<UserDTO>(user);

            return userDTO;
        }



        public List<FoodCollectRequestDTO> FoodCollectRequestListToDTO(List<FoodCollectRequest> foodCollectRequests)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<FoodCollectRequest, FoodCollectRequestDTO>();
            });

            var mapper = config.CreateMapper();
            return mapper.Map<List<FoodCollectRequestDTO>>(foodCollectRequests);
        }

        public FoodCollectRequestDTO FoodCollectRequestToDTO(FoodCollectRequest foodCollectRequest)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<FoodCollectRequest, FoodCollectRequestDTO>();
            });

            var mapper = config.CreateMapper();
            return mapper.Map<FoodCollectRequestDTO>(foodCollectRequest);
        }

        public FoodCollectRequest DTOToFoodCollectRequest(FoodCollectRequestDTO foodCollectRequestDTO)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<FoodCollectRequestDTO, FoodCollectRequest>();
            });

            var mapper = config.CreateMapper();
            return mapper.Map<FoodCollectRequest>(foodCollectRequestDTO);
        }


        public List<RestaurantFoodCollectRequestDTO> RestaurantFoodCollectRequestListDTO(List<Restaurant> restaurants)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<FoodCollectRequest, FoodCollectRequestDTO>();
                cfg.CreateMap<Restaurant, RestaurantFoodCollectRequestDTO>();
            });

            var mapper = config.CreateMapper();

            var result = (from r in restaurants
                          select new RestaurantFoodCollectRequestDTO
                          {
                              restaurantName = r.restaurantName,
                              FoodCollectRequests = (from fcr in r.FoodCollectRequests
                                                     where fcr.statusType == "Request Pending"
                                                     orderby fcr.expiryDate ascending
                                                     select mapper.Map<FoodCollectRequestDTO>(fcr)).ToList()
                          }).ToList();
            return result;
        }




        public RestaurantFoodCollectRequestDTO RestaurantFoodCollectRequestToDTO(Restaurant restaurant, int id)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<FoodCollectRequest, FoodCollectRequestDTO>();
                cfg.CreateMap<Restaurant, RestaurantFoodCollectRequestDTO>();
            });

            var mapper = config.CreateMapper();

            var result = new RestaurantFoodCollectRequestDTO
            {
                restaurantName = restaurant.restaurantName,
                FoodCollectRequests = (from fcr in restaurant.FoodCollectRequests
                                       where fcr.id == id
                                       orderby fcr.expiryDate ascending
                                       select mapper.Map<FoodCollectRequestDTO>(fcr)).ToList()
            };

            return result;
        }


        public Collector DTOToCollector(CollectorDTO collector)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CollectorDTO, Collector>();
            });
            var mapper = config.CreateMapper();
            return new Collector()
            {
                id = collector.id,
                name = collector.name,
                contactNumber = collector.contactNumber,
                email = collector.email,
                vehicleType = collector.vehicleType,
                userID = collector.userID
            };
        }
        public CollectorDTO CollectorToDTO(Collector collector)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Collector, CollectorDTO>();
            });
            var mapper = config.CreateMapper();

            return new CollectorDTO()
            {
                id = collector.id,
                name = collector.name,
                contactNumber = collector.contactNumber,
                email = collector.email,
                vehicleType = collector.vehicleType,
                userID = collector.userID,
            };
        }
        public User DTOToCollectorUser(CollectorDTO collectorDTO)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CollectorDTO, User>();
            });
            var mapper = config.CreateMapper();
            return new User()
            {
                username = collectorDTO.username,
                password = collectorDTO.password
            };
        }


        public Distributor DTOToDistributor(DistributorDTO distributor)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DistributorDTO, Distributor>();
            });

            var mapper = config.CreateMapper();

            return new Distributor()
            {
                id = distributor.id,
                name = distributor.name,
                contactNumber = distributor.contactNumber,
                email = distributor.email,
                area = distributor.area,
                userID = distributor.userID,
            };
        }

        public DistributorDTO DistributorToDTO(Distributor distributor)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Distributor, DistributorDTO>();
            });

            var mapper = config.CreateMapper();

            return new DistributorDTO()
            {
                id = distributor.id,
                name = distributor.name,
                contactNumber = distributor.contactNumber,
                email = distributor.email,
                area = distributor.area,
                userID = distributor.userID,
            };
        }

        public User DTOToDistributorUser(DistributorDTO distributorDTO)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DistributorDTO, User>();
            });
            var mapper = config.CreateMapper();
            return new User()
            {
                username = distributorDTO.username,
                password = distributorDTO.password
            };
        }

        //----------------------Collect Pending -----------------------------------------------
        public List<RestaurantFoodCollectRequestDTO> RestaurantFoodCollectRequestCollectorListDTO(List<Restaurant> restaurants)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<FoodCollectRequest, FoodCollectRequestDTO>();
                cfg.CreateMap<Restaurant, RestaurantFoodCollectRequestDTO>();
            });

            var mapper = config.CreateMapper();

            var result = (from r in restaurants
                          select new RestaurantFoodCollectRequestDTO
                          {
                              restaurantName = r.restaurantName,
                              FoodCollectRequests = (from fcr in r.FoodCollectRequests
                                                     where fcr.statusType == "Collector Comming Soon"
                                                     orderby fcr.expiryDate ascending
                                                     select mapper.Map<FoodCollectRequestDTO>(fcr)).ToList()
                          }).ToList();
            return result;
        }


        //----------------------Distributor Area -----------------------------------------------
        public List<FoodCollectRequestProcessingDTO> FoodCollectRequestProcessingListDTO(List<Restaurant> restaurants)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<FoodCollectRequest, FoodCollectRequestDTO>();
                cfg.CreateMap<Restaurant, RestaurantFoodCollectRequestDTO>();
            });

            var mapper = config.CreateMapper();

            var result = (from r in restaurants
                          select new RestaurantFoodCollectRequestDTO
                          {
                              restaurantName = r.restaurantName,
                              FoodCollectRequests = (from fcr in r.FoodCollectRequests
                                                     where fcr.statusType == "Request Pending"
                                                     orderby fcr.expiryDate ascending
                                                     select mapper.Map<FoodCollectRequestDTO>(fcr)).ToList()
                          }).ToList();
            return result;
        }

    }
}