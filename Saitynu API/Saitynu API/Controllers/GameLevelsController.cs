using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Saitynu_API.Data.Dtos;
using Saitynu_API.Data.Dtos.GameLevels;
using Saitynu_API.Data.Entities;
using Saitynu_API.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Saitynu_API.Controllers
{
    [ApiController]
    [Route("api/gameLevels")]
    public class GameLevelsController : ControllerBase
    {
        private readonly IGameLevelsRepository _gameLevelsRepository;
        private readonly IMapper _mapper;

        public GameLevelsController(IGameLevelsRepository gameLevelsRepository, IMapper mapper)
        {
            _gameLevelsRepository = gameLevelsRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<GameLevelDto>> GetAll()
        {
            return (await _gameLevelsRepository.GetAll()).Select(o => _mapper.Map<GameLevelDto>(o));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GameLevelDto>> Get(int id)
        {
            var gameLevel = await _gameLevelsRepository.Get(id);
            if (gameLevel == null)
                return NotFound("Game level with id " + id + " not found.");

            return Ok(_mapper.Map<GameLevelDto>(gameLevel));
        }

        [HttpPost]
        public async Task<ActionResult<GameLevelDto>> Post(CreateGameLevelDto gameLevelDto)
        {
            var gameLevel = _mapper.Map<GameLevel>(gameLevelDto);

            await _gameLevelsRepository.Create(gameLevel);

            return Created($"/api/players/{gameLevel.Id}", _mapper.Map<GameLevelDto>(gameLevel));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<GameLevelDto>> Put(int id, UpdateGameLevelDto gameLevelDto)
        {
            var gameLevel = await _gameLevelsRepository.Get(id);
            if (gameLevel == null)
                return NotFound("Game level with id " + id + " not found.");

            //player.Nick = playerDto.Nick; jei tik viena keiciam kintamaji
            _mapper.Map(gameLevelDto, gameLevel);

            await _gameLevelsRepository.Put(gameLevel);

            return Ok(_mapper.Map<GameLevelDto>(gameLevel));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<GameLevelDto>> Delete(int id)
        {
            var gameLevel = await _gameLevelsRepository.Get(id);
            if (gameLevel == null)
                return NotFound("Game level with id " + id + " not found.");

            await _gameLevelsRepository.Delete(gameLevel);

            return NoContent();
        }
    }
}