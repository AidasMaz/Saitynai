using Microsoft.EntityFrameworkCore;
using Saitynu_API.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Saitynu_API.Data.Repositories
{
    public interface IMessagesRepository
    {
        Task/*<Message>*/ Create(Message message);

        Task<IEnumerable<Message>> GetAll();

        Task<Message> Get(int id);

        Task/*<Message>*/ Put(Message message);

        Task Delete(Message message);
    }

    public class MessagesRepository : IMessagesRepository
    {
        private readonly RestContext _restContext;

        public MessagesRepository(RestContext restContext)
        {
            _restContext = restContext;
        }

        public async Task<IEnumerable<Message>> GetAll()
        {
            return await _restContext.Messages.Where(o => o.Id != 0).ToListAsync();

            //return new List<Message>
            //{
            //    new Message()
            //    {
            //        Title = "Happy summer!",
            //        Text = "We hope you will have a great summer!",
            //        StartDate = DateTime.UtcNow,
            //        EndDate = DateTime.UtcNow.AddDays(15)
            //    },
            //    new Message()
            //    {
            //        Title = "Happy Holidays!",
            //        Text = "We wish you a Merry Cristmas!",
            //        StartDate = new DateTime(2021, 12, 24),
            //        EndDate = new DateTime(2021, 12, 24).AddDays(5)
            //    }
            //};
        }

        public async Task<Message> Get(int id)
        {
            return await _restContext.Messages.FirstOrDefaultAsync(o => o.Id == id);

            //return new Message()
            //{
            //    Title = "Happy summer!",
            //    Text = "We hope you will have a great summer!",
            //    StartDate = DateTime.UtcNow,
            //    EndDate = DateTime.UtcNow.AddDays(15)
            //};
        }

        public async Task/*<Message>*/ Create(Message message)
        {
            _restContext.Messages.Add(message);
            await _restContext.SaveChangesAsync();

            //return new Message()
            //{
            //    Title = "Happy summer!",
            //    Text = "We hope you will have a great summer!",
            //    StartDate = DateTime.UtcNow,
            //    EndDate = DateTime.UtcNow.AddDays(15)
            //};
        }

        public async Task/*<Message>*/ Put(Message message)
        {
            _restContext.Messages.Update(message);
            await _restContext.SaveChangesAsync();

            //return new Message()
            //{
            //    Title = "Happy summer!",
            //    Text = "We hope you will have a great summer!",
            //    StartDate = DateTime.UtcNow,
            //    EndDate = DateTime.UtcNow.AddDays(15)
            //};
        }

        public async Task Delete(Message message)
        {
            _restContext.Messages.Remove(message);
            await _restContext.SaveChangesAsync();
        }
    }
}
