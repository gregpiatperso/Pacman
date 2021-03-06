﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Diagnostics;

namespace Pacman
{
    public class Ghost : Entity
    {
        private static int ID = 0;      
        private Stopwatch watch;

        private int id;
        private int timeChange;
        private bool firstChange;

        private static Dictionary<int, string> Textures(String color)
        {
            Dictionary<int, string> textures = new Dictionary<int, string>();
            if (color == "red")
            {
                textures.Add(1, "Images\\fantomeRouge");
            }
            if (color == "blue")
            {
                textures.Add(1, "Images\\fantomeBleu");
            }
            if (color == "pink")
            {
                textures.Add(1, "Images\\fantomeRose");
            }
            if (color == "green")
            {
                textures.Add(1, "Images\\fantomeVert");
            }
            textures.Add(2, "Images\\FantomePeur0");
            textures.Add(3, "Images\\FantomePeur1");

            return textures;
        }

        
        override public void respawn() {
            base.respawn();
            firstChange = true;
            direction = 4;
        }

        public Ghost(Game game, string name)
            : base(game, Textures(name))
        {
            watch = Stopwatch.StartNew();
            direction = 4;
            id = ++ID;
            timeChange = 600 + id * 300;
            firstChange = true;
        }

        public override void Initialize()
        {
            positionInit = new Vector2(280f, 260f);
            base.Initialize();            
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        override protected void changeDirection()
        {
            if (direction == 0 || watch.ElapsedMilliseconds > timeChange)
            {
                Random random = new Random();
                direction = random.Next(1, (firstChange)?3:5);
                watch.Restart();
                firstChange = false;
            }

        }

        

        override
        protected void textureUpdate()
        {
            entity.Texture = Game.Content.Load<Texture2D>(textures[2]);
        }
    }
}
