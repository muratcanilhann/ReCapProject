﻿using Core.Entities.Concrete;

namespace Business.Abstract;

public interface IUserService
{
    List<OperaitonClaim> GetClaims(User user);
    void Add(User user);
    User GetByMail(string email);
}
