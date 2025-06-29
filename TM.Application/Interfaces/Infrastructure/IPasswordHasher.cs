﻿namespace TM.Application.Interfaces.Infrastructure;

public interface IPasswordHasher
{
    byte[] GenerateSalt();
    byte[] HashPassword(string password, byte[] salt);
}