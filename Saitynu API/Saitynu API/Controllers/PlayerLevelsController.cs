using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Saitynu_API.Auth.Model;
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
        private readonly IAuthorizationService _authorizationService;

        public PlayerLevelsController(IPlayerLevelsRepository playerLevelsRepository, IPlayersRepository playersRepository, IMapper mapper, IAuthorizationService authorizationService)
        {
            _playerLevelsRepository = playerLevelsRepository;
            _playersRepository = playersRepository;
            _mapper = mapper;
            _authorizationService = authorizationService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Tester")]
        public async Task<IEnumerable<PlayerLevelDto>> GetAll(int playerId)
        {
            return (await _playerLevelsRepository.GetAll(playerId)).Select(o => _mapper.Map<PlayerLevelDto>(o));
        }

        [HttpGet("{playerLevelId}")]
        [Authorize(Roles = "Admin, Tester, Player")]
        public async Task<ActionResult<PlayerLevelDto>> Get(int playerId, int playerLevelId)
        {
            var player = await _playersRepository.Get(playerId);
            if (player == null)
                return NotFound("Player with Id " + playerId + " not found.");

            var playerLevel = await _playerLevelsRepository.Get(playerId, playerLevelId);
            if (playerLevel == null)
                return NotFound("PlayerLevel from player " + playerId + " where playerLevelId " + playerLevelId + " not found.");

            var authorizationResult = await _authorizationService.AuthorizeAsync(User, player, PolicyNames.SameUser);
            if (!authorizationResult.Succeeded)
                return Forbid();

            return Ok(_mapper.Map<PlayerLevelDto>(playerLevel));
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Tester, Player")]
        public async Task<ActionResult<PlayerLevelDto>> Post(int playerId, CreatePlayerLevelDto playerLevelDto)
        {
            var player = await _playersRepository.Get(playerId);
            if (player == null)
                return NotFound("Player with Id " + playerId + " not found.");

            var authorizationResult = await _authorizationService.AuthorizeAsync(User, player, PolicyNames.SameUser);
            if (!authorizationResult.Succeeded)
                return Forbid();

            var playerLevel = _mapper.Map<PlayerLevel>(playerLevelDto);
            playerLevel.PlayerId = playerId;

            await _playerLevelsRepository.Create(playerLevel);

            return Created($"/api/player/{playerId}/playerLevels/{playerLevel.Id}", _mapper.Map<PlayerLevelDto>(playerLevel));
        }

        [HttpPut("{playerLevelId}")]
        [Authorize(Roles = "Admin, Tester, Player")]
        public async Task<ActionResult<PlayerLevelDto>> Put(int playerId, int playerLevelId, UpdatePlayerLevelDto playerLevelDto)
        {
            var player = await _playersRepository.Get(playerId);
            if (player == null)
                return NotFound("Player with Id " + playerId + " not found.");

            var playerLevel = await _playerLevelsRepository.Get(playerId, playerLevelId);
            if (playerLevel == null)
                return NotFound("PlayerLevel from player " + playerId + " where playerLevelId " + playerLevelId + " not found.");

            var authorizationResult = await _authorizationService.AuthorizeAsync(User, player, PolicyNames.SameUser);
            if (!authorizationResult.Succeeded)
                return Forbid();

            _mapper.Map(playerLevelDto, playerLevel);

            await _playerLevelsRepository.Put(playerLevel);

            return Ok(_mapper.Map<PlayerLevelDto>(playerLevel));
        }

        [HttpDelete("{playerLevelId}")]
        [Authorize(Roles = "Admin, Tester, Player")]
        public async Task<ActionResult/*<PlayerLevelDto>*/> Delete(int playerId, int playerLevelId)
        {
            var player = await _playersRepository.Get(playerId);
            if (player == null)
                return NotFound("Player with Id " + playerId + " not found.");

            var playerLevel = await _playerLevelsRepository.Get(playerId, playerLevelId);
            if (playerLevel == null)
                return NotFound("PlayerLevel from player " + playerId + " where playerLevelId " + playerLevelId + " not found.");

            var authorizationResult = await _authorizationService.AuthorizeAsync(User, player, PolicyNames.SameUser);
            if (!authorizationResult.Succeeded)
                return Forbid();

            await _playerLevelsRepository.Delete(playerLevel);

            return NoContent();
        }
    }
}
