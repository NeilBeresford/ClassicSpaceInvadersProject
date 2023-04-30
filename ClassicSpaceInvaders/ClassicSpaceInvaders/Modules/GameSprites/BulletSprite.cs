using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ClassicSpaceInvaders.Modules.Game;
using ClassicSpaceInvaders.Modules.Utilities;
using ClassicSpaceInvaders.Modules.Sprites;

namespace ClassicSpaceInvaders.Modules.GameSprites
{
    class BulletSprite : AnimSprite
    {
        #region Data

        private Single      fAcc    = -1.5f;

        #endregion

        #region Constructors

        public BulletSprite(Sprite inSprite) : base(inSprite)
        {
        }

        #endregion
        #region Public Functionality

        public override void Update(GameTime gameTime)
        {
            if ( Position.Y < -30.0f )
            {
                // kill bullet...
                Global.Instance.CoreGame.BulletController.Kill( BaseID ); 
            }
            else
            {
                Vector2 pos = Position;

                pos.Y += fAcc;

                fAcc -= 0.03f;

                Position = pos;
            }

            if ( Global.Instance.CoreGame.CheckInvaderCollision( GetSpriteRectScaled() ) == true )
            {
                Global.Instance.CoreGame.BulletController.Kill( BaseID ); 
            }

            base.Update(gameTime);

        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }

        #endregion



    }
}
