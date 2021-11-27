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
using Microsoft.AspNetCore.Authorization;
using Saitynu_API.Auth.Model;

namespace Saitynu_API.Controllers
{
    [ApiController]
    [Route("api/players")]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayersRepository _playersRepository;
        private readonly IMapper _mapper;
        private readonly IAuthorizationService _authorizationService;

        public PlayersController(IPlayersRepository playersRepository, IMapper mapper, IAuthorizationService authorizationService)
        {
            _playersRepository = playersRepository;
            _mapper = mapper;
            _authorizationService = authorizationService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Tester")]
        public async Task<IEnumerable<PlayerDto>> GetAll()
        {
            //return (await _playersRepository.GetAll()).Select(o => _mapper.Map<PlayerDto>(o));
            var players = await _playersRepository.GetAll();
            return players.Select(o => _mapper.Map<PlayerDto>(o));
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin, Tester, Player")]
        public async Task<ActionResult<PlayerDto>> Get(int id)
        {
            var player = await _playersRepository.Get(id);
            if (player == null)
                return NotFound("Player with id " + id + " not found.");

            var authorizationResult = await _authorizationService.AuthorizeAsync(User, player, PolicyNames.SameUser);
            if (!authorizationResult.Succeeded)
                return Forbid();

            return Ok(_mapper.Map<PlayerDto>(player));
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Tester, Player")]
        public async Task<ActionResult<PlayerDto>> Post(CreatePlayerDto playerDto)
        {
            var players = await _playersRepository.GetAll();
            var chosenPlayers = players.Where(o => o.UserId == User.FindFirst(CustomClaims.UserId).Value).Select(o => o.UserId);
            if (chosenPlayers.Count() > 0 && User.IsInRole(RestUserRoles.Player))
                return BadRequest("This user (player role) already has an existing player");

            var player = _mapper.Map<Player>(playerDto);
            var id = User.FindFirst("userId").Value;
            player.UserId = id;

            await _playersRepository.Create(player);

            return Created($"/api/players/{player.Id}", _mapper.Map<PlayerDto>(player));
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin, Tester, Player")]
        public async Task<ActionResult<PlayerDto>> Put(int id, UpdatePlayerDto playerDto)
        {
            var player = await _playersRepository.Get(id);
            if (player == null)
                return NotFound("Player with id " + id + " not found.");

            var authorizationResult = await _authorizationService.AuthorizeAsync(User, player, PolicyNames.SameUser);
            if (!authorizationResult.Succeeded)
                return Forbid();

            //player.Nick = playerDto.Nick; jei tik viena keiciam kintamaji
            _mapper.Map(playerDto, player);

            await _playersRepository.Put(player);

            return Ok(_mapper.Map<PlayerDto>(player));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin, Tester, Player")]
        public async Task<ActionResult<PlayerDto>> Delete(int id)
        {
            var player = await _playersRepository.Get(id);
            if (player == null)
                return NotFound("Player with id " + id + " not found.");

            var authorizationResult = await _authorizationService.AuthorizeAsync(User, player, PolicyNames.SameUser);
            if (!authorizationResult.Succeeded)
                return Forbid();

            await _playersRepository.Delete(player);

            return NoContent();
        }
    }
}
