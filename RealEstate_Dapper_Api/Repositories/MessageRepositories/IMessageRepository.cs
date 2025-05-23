﻿using RealEstate_Dapper_Api.Models.Dtos.MessageDtos;

namespace RealEstate_Dapper_Api.Repositories.MessageRepositories
{
    public interface IMessageRepository
    {
        Task<List<ResultInBoxMessageDto>> GetInBoxLast3MessageListByReceiver(int id);
    }
}
