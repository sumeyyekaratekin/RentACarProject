using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IFakeCardService : IEntityServiceBase<FakeCard>
    {
        IDataResult<List<FakeCard>> GetByCardNumber(string cardNumber);
        IResult IsCardExist(FakeCard fakeCard);
    }
}
