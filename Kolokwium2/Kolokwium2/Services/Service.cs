using Kolokwium2.Data;
using Kolokwium2.DTOs;
using Kolokwium2.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2.Services;

public class Service : IService
{
    private readonly Context _context;

    public Service(Context context)
    {
        _context = context;
    }
    public async Task<List<Items>> GetItemsAsync()
    {
        return await _context.Items2.ToListAsync();
    }

    public async Task<CharacterDto> GetCharacter(int id)
    {
        var character = await _context.Characters2
            .Include(c => c.BackpacksCollection)
            .ThenInclude(b => b.Items)
            .Include(c => c.CharacterTitlesCollection)
            .ThenInclude(ct => ct.Titles)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (character == null)
        {
            return null;
        }

        var characterDto = new CharacterDto
        {
            FirstName = character.FirstName,
            LastName = character.LastName,
            CurrentWeight = character.CurrentWeight,
            MaxWeight = character.MaxWeight,
            BackpackItems = character.BackpacksCollection.Select(b => new BackpackItemDto
            {
                ItemName = b.Items.Name,
                ItemWeight = b.Items.Weight,
                Amount = b.Amount
            }).ToList(),
            Titles = character.CharacterTitlesCollection.Select(t => new TitleDto
            {
                Title = t.Titles.Name,
                AcquiredAt = t.AcquiredAt
            }).ToList()
        };

        return characterDto;
    }
    public async Task<List<BackpackItemDto>> AddItemsToBackpack(int id, int[] itemIds)
    {
        var character = await _context.Characters2.Include(c => c.BackpacksCollection).FirstOrDefaultAsync(c => c.Id == id);
        if (character == null)
        {
            throw new Exception("Character not found");
        }

        var items = await _context.Items2.Where(i => itemIds.Contains(i.Id)).ToListAsync();
        if (items.Count != itemIds.Length)
        {
            throw new Exception("items dont exist");
        }

        var fullWeight = items.Sum(i => i.Weight);
        if (character.CurrentWeight + fullWeight > character.MaxWeight)
        {
            throw new Exception("Character cannot carry more weight.");
        }

        foreach (var i in items)
        {
            var backpackItem = character.BackpacksCollection.FirstOrDefault(b => b.ItemId == i.Id);
            if (backpackItem != null)
            {
                backpackItem.Amount++;
            }
            else
            {
                character.BackpacksCollection.Add(new Backpacks
                {
                    CharacterId = id,
                    ItemId = i.Id,
                    Amount = 1
                });
            }
        }

        character.CurrentWeight += fullWeight;
        await _context.SaveChangesAsync();

        var newItem = character.
            BackpacksCollection.
            Select(b => new  BackpackItemDto 
                { ItemName = b.Items.Name,
                    ItemWeight = b.Items.Weight,
                    Amount = b.Amount }).ToList();
        return newItem;
    }
}
    