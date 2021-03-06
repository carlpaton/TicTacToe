﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GameUI.Models;

namespace GameUI.Models
{
    public class DummyContext : DbContext
    {
        public DummyContext (DbContextOptions<DummyContext> options)
            : base(options)
        {
        }

        public DbSet<GameUI.Models.GameViewModel> GameViewModel { get; set; }

        public DbSet<GameUI.Models.ApiGameMoveModel> ApiGameMoveModel { get; set; }
    }
}
