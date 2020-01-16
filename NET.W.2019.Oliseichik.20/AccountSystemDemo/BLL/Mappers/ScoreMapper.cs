using BLL.Interface.Entities;
using DAL.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappers
{
    public static class ScoreMapper
    {
        public static DTO_Score ConvertToDTO(this Score score)
        {
            return new DTO_Score
            { 
                bonusPoints = score.bonusPoints,
                client = score.client,
                Id = score.Id,
                balance = score.balance,
                Status = score.Status,
                ScoreType = score.ScoreType,
            };
        }

        public static Score ConvertToBankAccount(this DTO_Score dtoAccount)
        {
            return dtoAccount.ScoreType switch
            {

                ScoreType.Base => new BaseCart(
                        //dtoAccount.Id,
                        dtoAccount.client,
                        dtoAccount.ScoreType,
                        dtoAccount.Status,
                        dtoAccount.balance,
                        dtoAccount.bonusPoints),

                ScoreType.Gold => new GoldCart(
                        //dtoAccount.Id,
                        dtoAccount.client,
                        dtoAccount.ScoreType,
                        dtoAccount.Status,
                        dtoAccount.balance,
                        dtoAccount.bonusPoints),

                ScoreType.Platinum => new PlatinumCart(
                        //dtoAccount.Id,
                        dtoAccount.client,
                        dtoAccount.ScoreType,
                        dtoAccount.Status,
                        dtoAccount.balance,
                        dtoAccount.bonusPoints),

                _ => null,
            };
        }
    }
}
