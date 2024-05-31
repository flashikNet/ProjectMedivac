using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface IDuelsRepository
{
    Task CreateDuelAsync(Duel duel);
}