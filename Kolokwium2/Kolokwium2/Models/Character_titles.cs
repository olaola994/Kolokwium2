﻿using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2.Models;

[PrimaryKey(nameof(CharacterId), nameof(TitleId))]
public class Character_titles
{
    public int CharacterId { get; set; }
    public int TitleId { get; set; }
    public DateTime AcquiredAt { get; set; }
    
    [ForeignKey(nameof(CharacterId))] 
    public Characters Characters { get; set; } = null;
    [ForeignKey(nameof(TitleId))] 
    public Titles Titles { get; set; } = null;
}