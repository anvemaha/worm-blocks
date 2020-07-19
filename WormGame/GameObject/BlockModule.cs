﻿using Otter.Graphics;
using Otter.Graphics.Drawables;
using Otter.Utility.MonoGame;
using WormGame.Core;
using WormGame.Static;
using WormGame.Pooling;

namespace WormGame.GameObject
{
    public class BlockModule : PoolableObject
    {
        private readonly Collision field;

        public BlockModule Next { get; set; }

        public Image Graphic { get; private set; }

        public override bool Enabled { get { return enabled; } set { enabled = value; Graphic.Visible = value; } }
        private bool enabled;


        public BlockModule(Config config)
        {
            field = config.field;
            Graphic = Image.CreateRectangle(config.imageSize);
            Graphic.Scale = (float)config.size / config.imageSize;
            Graphic.CenterOrigin();
        }

        public bool CopyWorm(Worm worm, WormModule wormModule, Block brick, Pooler<BlockModule> brickModules, bool disable = false)
        {
            Next = brickModules.Enable();
            Next.Next = null;
            Next.Graphic.X = wormModule.Target.X - worm.Position.X;
            Next.Graphic.Y = wormModule.Target.Y - worm.Position.Y;
            brick.AddGraphic(Next.Graphic);
            field.Set(brick, wormModule.Target);
            if (!disable)
                disable = NeighbourCheck(brick, worm.Color, field.X(wormModule.Target.X), field.Y(wormModule.Target.Y));
            if (wormModule.Next != null)
                return Next.CopyWorm(worm, wormModule.Next, brick, brickModules, disable);
            return disable;
        }

        private bool NeighbourCheck(Block parent, Color color, int positionX, int positionY)
        {
            if (Check(parent, color, positionX + 1, positionY)) return true;
            if (Check(parent, color, positionX - 1, positionY)) return true;
            if (Check(parent, color, positionX, positionY + 1)) return true;
            if (Check(parent, color, positionX, positionY - 1)) return true;
            return false;
        }

        private bool Check(Block parent, Color color, int positionX, int positionY)
        {
            int checkX = positionX;
            int checkY = positionY;
            if (field.Check(checkX, checkY) == 2)
            {
                Block brick = (Block)field.Get(checkX, checkY);
                if (brick.Id != parent.Id && Help.ColorCheck(color, brick.Color))
                {
                    brick.Disable();
                    return true;
                }
            }
            return false;
        }

        public void SetColor(Color color)
        {
            if (Next != null)
                Next.SetColor(color);
            Graphic.Color = color;
        }

        public void Disable(Vector2 parentPosition)
        {
            field.Set(null, parentPosition.X + Graphic.X, parentPosition.Y + Graphic.Y);
            Graphic.Visible = false;
            Enabled = false;
            if (Next != null)
                Next.Disable(parentPosition);
        }
    }
}