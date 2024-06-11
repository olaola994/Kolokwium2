using Kolokwium2.DTOs;

namespace Kolokwium2.Services;

public interface IService
{
    Task<CharacterDto> GetCharacter(int id);
    Task<List<BackpackItemDto>> AddItemsToBackpack(int id, int[] itemIds);
}