using System;

namespace TM.Domain.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow.ToUniversalTime();
    public DateTime UpdatedAt { get; init; } = DateTime.UtcNow.ToUniversalTime();
}