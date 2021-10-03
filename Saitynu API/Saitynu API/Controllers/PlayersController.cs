using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Saitynu_API.Controllers;
using Saitynu_API.Data.Repositories;
using Saitynu_API.Data.Entities;
using Saitynu_API.Data.Dtos.Players;
using AutoMapper;

namespace Saitynu_API.Controllers
{
    [ApiController]
    [Route("api/players")]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayersRepository _playersRepository;
        private readonly IMapper _mapper;

        public PlayersController(IPlayersRepository playersRepository, IMapper mapper)
        {
            _playersRepository = playersRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<PlayerDto>> GetAll()
        {
            return (await _playersRepository.GetAll()).Select(o => _mapper.Map<PlayerDto>(o));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PlayerDto>> Get(int id)
        {
            var player = await _playersRepository.Get(id);
            if (player == null)
                return NotFound("Player with id " + id + " not found.");

            return Ok(_mapper.Map<PlayerDto>(player));
        }

        [HttpPost]
        public async Task<ActionResult<PlayerDto>> Post(CreatePlayerDto playerDto)
        {
            var player = _mapper.Map<Player>(playerDto);

            await _playersRepository.Create(player);

            return Created($"/api/players/{player.Id}", _mapper.Map<PlayerDto>(player));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PlayerDto>> Put(int id, UpdatePlayerDto playerDto)
        {
            var player = await _playersRepository.Get(id);
            if (player == null)
                return NotFound("Player with id " + id + " not found.");

            //player.Nick = playerDto.Nick; jei tik viena keiciam kintamaji
            _mapper.Map(playerDto, player);

            await _playersRepository.Put(player);

            return Ok(_mapper.Map<PlayerDto>(player));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PlayerDto>> Delete(int id)
        {
            var player = await _playersRepository.Get(id);
            if (player == null)
                return NotFound("Player with id " + id + " not found.");

            await _playersRepository.Delete(player);

            return NoContent();
        }
    }
}
