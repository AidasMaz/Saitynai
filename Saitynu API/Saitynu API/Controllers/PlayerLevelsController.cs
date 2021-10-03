using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Saitynu_API.Data.Dtos.PlayerLevels;
using Saitynu_API.Data.Entities;
using Saitynu_API.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Saitynu_API.Controllers
{
    [ApiController]
    [Route("api/players/{playerId}/playerLevels")]
    public class PlayerLevelsController : ControllerBase
    {
        private readonly IPlayerLevelsRepository _playerLevelsRepository;
        private readonly IPlayersRepository _playersRepository;
        private readonly IMapper _mapper;

        public PlayerLevelsController(IPlayerLevelsRepository playerLevelsRepository, IPlayersRepository playersRepository, IMapper mapper)
        {
            _playerLevelsRepository = playerLevelsRepository;
            _playersRepository = playersRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<PlayerLevelDto>> GetAll(int playerId)
        {
            return (await _playerLevelsRepository.GetAll(playerId)).Select(o => _mapper.Map<PlayerLevelDto>(o));
        }

        [HttpGet("{playerLevelId}")]
        public async Task<ActionResult<PlayerLevelDto>> Get(int playerId, int playerLevelId)
        {
            var playerLevel = await _playerLevelsRepository.Get(playerId, playerLevelId);
            if (playerLevel == null)
                return NotFound("PlayerLevel with playerId " + playerId + " and playerLevelID " + playerLevelId + " not found.");

            return Ok(_mapper.Map<PlayerLevelDto>(playerLevel));
        }

        [HttpPost]
        public async Task<ActionResult<PlayerLevelDto>> Post(int playerId, CreatePlayerLevelDto playerLevelDto)
        {
            var playerLevel = _mapper.Map<PlayerLevel>(playerLevelDto);

            await _playerLevelsRepository.Create(playerLevel);

            return Created($"/api/player/{playerId}/playerLevels/{playerLevel.Id}", _mapper.Map<PlayerLevelDto>(playerLevel));
        }

        [HttpPut("{playerLevelId}")]
        public async Task<ActionResult<PlayerLevelDto>> Put(int playerId, int playerLevelId, UpdatePlayerLevelDto playerLevelDto)
        {
            var playerLevel = await _playerLevelsRepository.Get(playerId, playerLevelId);
            if (playerLevel == null)
                return NotFound("PlayerLevel with playerId " + playerId + " and playerLevelID " + playerLevelId + " not found.");

            //player.Nick = playerDto.Nick; jei tik viena keiciam kintamaji
            _mapper.Map(playerLevelDto, playerLevel);

            await _playerLevelsRepository.Put(playerLevel);

            return Ok(_mapper.Map<PlayerLevelDto>(playerLevel));
        }

        [HttpDelete("{playerLevelId}")]
        public async Task<ActionResult<PlayerLevelDto>> Delete(int playerId, int playerLevelId)
        {
            var playerLevel = await _playerLevelsRepository.Get(playerId, playerLevelId);
            if (playerLevel == null)
                return NotFound("PlayerLevel with playerId " + playerId + " and playerLevelID " + playerLevelId + " not found.");

            await _playerLevelsRepository.Delete(playerLevel);

            return NoContent();
        }
    }
}
