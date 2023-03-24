﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaLibrary
{
    public class Player
    {
        public string Name { get; set; }
        public int Score { get; set; }

        public Player(string playerName) 
        { 
            this.Name = playerName;
            this.Score = 0;
        }
    }
}
