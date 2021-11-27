using AutoMapper;
using Saitynu_API.Data.Dtos;
using Saitynu_API.Data.Dtos.Auth;
using Saitynu_API.Data.Dtos.GameLevels;
using Saitynu_API.Data.Dtos.Messages;
using Saitynu_API.Data.Dtos.PlayerLevels;
using Saitynu_API.Data.Dtos.Players;
using Saitynu_API.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Saitynu_API.Data
{
    public class RestProfile : Profile
    {
        public RestProfile()
        {
            CreateMap<Player, PlayerDto>();
            CreateMap<CreatePlayerDto, Player>();
            CreateMap<UpdatePlayerDto, Player>();

            CreateMap<Message, MessageDto>();
            CreateMap<CreateMessageDto, Message>();
            CreateMap<UpdateMessageDto, Message>();

            CreateMap<GameLevel, GameLevelDto>();
            CreateMap<CreateGameLevelDto, GameLevel>();
            CreateMap<UpdateGameLevelDto, GameLevel>();

            CreateMap<PlayerLevel, PlayerLevelDto>();
            CreateMap<CreatePlayerLevelDto, PlayerLevel>();
            CreateMap<UpdatePlayerLevelDto, PlayerLevel>();

            CreateMap<RestUser, UserDto>();
        }
    }
}
