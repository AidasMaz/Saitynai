using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Saitynu_API.Data.Dtos.Messages;
using Saitynu_API.Data.Entities;
using Saitynu_API.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Saitynu_API.Controllers
{
    [ApiController]
    [Route("api/messages")]
    public class MessagesController : ControllerBase
    {
        private readonly IMessagesRepository _messagesRepository;
        private readonly IMapper _mapper;

        public MessagesController(IMessagesRepository messagesRepository, IMapper mapper)
        {
            _messagesRepository = messagesRepository;
            _mapper = mapper;
        }

        [Authorize(Roles = "Admin, Tester, Player")]
        [HttpGet]
        public async Task<IEnumerable<MessageDto>> GetAll()
        {
            //return (await _messagesRepository.GetAll()).Select(o => _mapper.Map<MessageDto>(o));
            var messages = await _messagesRepository.GetAll();
            return messages.Select(o => _mapper.Map<MessageDto>(o));
        }

        [Authorize(Roles = "Admin, Tester, Player")]
        [HttpGet("{id}")]
        public async Task<ActionResult<MessageDto>> Get(int id)
        {
            var message = await _messagesRepository.Get(id);
            if (message == null)
                return NotFound("Message with id " + id + " not found.");

            return Ok(_mapper.Map<MessageDto>(message));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<MessageDto>> Post(CreateMessageDto messageDto)
        {
            var message = _mapper.Map<Message>(messageDto);

            await _messagesRepository.Create(message);

            return Created($"/api/messages/{message.Id}", _mapper.Map<MessageDto>(message));
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult<MessageDto>> Put(int id, UpdateMessageDto messageDto)
        {
            var message = await _messagesRepository.Get(id);
            if (message == null)
                return NotFound("Message with id " + id + " not found.");

            //player.Nick = playerDto.Nick; pvz, jei tik viena dalyka noretume keisti
            _mapper.Map(messageDto, message);

            await _messagesRepository.Put(message);

            return Ok(_mapper.Map<MessageDto>(message));
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<MessageDto>> Delete(int id)
        {
            var message = await _messagesRepository.Get(id);
            if (message == null)
                return NotFound("Message with id " + id + " not found.");

            await _messagesRepository.Delete(message);

            return NoContent();
        }
    }
}
