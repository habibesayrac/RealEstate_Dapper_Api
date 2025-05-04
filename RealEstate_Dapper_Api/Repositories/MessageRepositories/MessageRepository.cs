using Dapper;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_Api.Models.Dtos.MessageDtos;

namespace RealEstate_Dapper_Api.Repositories.MessageRepositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly Context _context;

        public MessageRepository(Context context)
        {
            _context = context;
        }
          public async Task<List<ResultInBoxMessageDto>> GetInBoxLast3MessageListByReceiver(int id)
        {
            string query = "Select Top(3) MessageId,Name,Subject,Detail,SendDate,IsRead From Message Inner Join AppUser On Message.Sender=AppUser.UserId Where Receiver=1 Order By MessageId Desc";
            //var parameters = new DynamicParameters();
            //parameters.Add("@receiverId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultInBoxMessageDto>(query);
                return values.ToList();
            }
        }
    }
}
