using Api_monopoly.Apps.Client.Dtos.Chat;
using Api_monopoly.Apps.Client.Dtos.ChatDtos;
using Api_monopoly.Apps.Client.Dtos.GameFieldUserDto;
using Api_monopoly.Apps.Client.Dtos.GameFieldUserDtos;
using Api_monopoly.Apps.Client.Dtos.GameLogDtos;
using Api_monopoly.Apps.Client.Dtos.gameRoomDtos;
using Api_monopoly.Apps.Client.Dtos.GameRoomUserDtos;
using Api_monopoly.Apps.Client.Dtos.Product;
using Api_monopoly.Apps.Client.Dtos.Slider;
using Api_monopoly.Apps.Client.Dtos.Task;
using AutoMapper;
using Core.Entities.Chat;
using Core.Entities.gameRoom;
using Core.Entities.Product;
using Core.Entities.Slider;

namespace Api_monopoly.Profiles
{
    public class MapProfile:Profile
    {


        public MapProfile()
        {
            //Createmap<Brand,BrandGetAllItem>()builder servise add auto mapper opt addprofile new profilemizi
            //CONTROLLERDE IMapper cagirib register elediyimiz mapi inject eliyirik
            //var dto= _mapper.Map<BRandGetDto-yane bu oyekte cevir>(brand) bu obyekti
            //_mapper.Map <List<ProductDto>>(_context.Brand.ToList())
            //Formember(d=d-destination.ProductCount, s=>.MapForm(x=>xProduct.Count)



            CreateMap<Chat, ChatGetAllDto>();
            CreateMap<Chat, ChatGetDto>();
            CreateMap<Chat, ChatDto>();
            CreateMap<ChatDto, Chat>();
            CreateMap<Chat, ChatDto>();
            CreateMap<Chat, ChatDto>();

            //================================
            CreateMap<gameRoom, GameRoomGetAllDto>();
            CreateMap<gameRoom, GameRoomGetDto>();
            CreateMap<gameRoom, GameRoomPostDto>();
            CreateMap<gameRoom, GameRoomUpdateDto>();


            //=====================
            CreateMap<gameLog, GameLogGetAllDto>();
            CreateMap<gameLog, GameLogGetDto>();
            CreateMap<gameLog, GameLogPostDto>();
            CreateMap<gameLog, GameLogUpdateDto>();


            //================================
            CreateMap<gameRoomUser, GameRoomUserGetAllDto>();
            CreateMap<gameRoomUser, GameRoomUserGetDto>();
            CreateMap<gameRoomUser, GameRoomUserPostDto>();
            CreateMap<gameRoomUser, GameRoomUserUpdateDto>();


            //==========================================
            CreateMap<Product, ProductGetAllDto>();
            CreateMap<Product, ProductGetDto>();
            CreateMap<Product, ProductPostDto>();
            CreateMap<Product, ProductUpdateDto>();

            //================================

            CreateMap<Slider, SliderGetAllDto>();
            CreateMap<Slider, SliderGetDto>();
            CreateMap<Slider, SliderPostDto>();
            CreateMap<Slider, SliderUpdateDto>();



            //====================
            CreateMap<Task, TaskGetAllDto>();
            CreateMap<Task, TaskGetDto>();
            CreateMap<Task, TaskPostDto>();
            CreateMap<Task, TaskPostDto>();
            CreateMap<TaskPostDto, Task>();


            //=================================
            CreateMap<gameFeeldUser, GameFieldUserGetAllDto>();
            CreateMap<gameFeeldUser, GameFieldUserGetDto>();
            CreateMap<gameFeeldUser, GameFieldUserPostDto>();
            CreateMap<gameFeeldUser, GameFieldUserUpdateDto>();


        }
    }
}
