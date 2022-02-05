using HonasGame.Assets;
using HonasGame.ECS;
using HonasGame.ECS.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectKnight.Entities.Knight
{
    public class Knight : Entity
    {
        public Knight()
        {
            new Transform2D(this);
            SpriteRenderer renderer = new SpriteRenderer(this) { Sprite = AssetLibrary.GetAsset<Sprite>("sprKnight") };
            renderer.Animation = "idle";
            renderer.CenterOrigin();
        }
    }
}
