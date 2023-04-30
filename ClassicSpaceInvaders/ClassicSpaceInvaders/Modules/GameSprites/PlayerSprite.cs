using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ClassicSpaceInvaders.Modules.Game;
using ClassicSpaceInvaders.Modules.Utilities;
using ClassicSpaceInvaders.Modules.Sprites;



namespace ClassicSpaceInvaders.Modules.GameSprites
{
    class PlayerSprite : AnimSprite
    {
        #region Data

        private bool bFired         = false;

        #endregion

        #region Constructors

        public PlayerSprite(Sprite inSprite) : base(inSprite)
        {
        }

        #endregion

        #region Public Functionality

        public override void Update(GameTime gameTime)
        {

            if (Keyboard.GetState().IsKeyDown(Keys.Z) == true)
            {
                // move player left...
                Vector2 pos = Position;
                pos.X       -= 2.0f;

                if ( pos.X < 10.0f )
                {
                    pos.X = 10.0f;
                }
                Position    = pos;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.X) == true)
            {
                // move player right...
                Vector2 pos = Position;
                pos.X       += 2.0f;
                if (pos.X > 800 - 58.0f )      // 24 is the width of the sprite plus another 10 to stop sprite going to the edge of the screen
                {
                    pos.X = 800 - 58.0f;
                }

                Position = pos;
            }

            // Fire bullet....
            if ( (Keyboard.GetState().IsKeyDown(Keys.Enter) == true) && (bFired == false) )
            {
                bFired = true;
                FireBullet();
            }
            if ( (Keyboard.GetState().IsKeyUp(Keys.Enter) == true) && (bFired == true) )
            {
                bFired = false;
            }



            base.Update(gameTime);

        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }

        #endregion

        #region Private Functionality

        private void FireBullet()
        {
            BulletSprite spr = new BulletSprite(new Sprite( new Vector2( Position.X + 11, Position.Y - 18 ), new Rectangle( 0, 20, 5, 7 ), Color.LightGray, 3.0f, SpriteEffects.None, 0.0f));
            
            Global.Instance.CoreGame.BulletController.Add( spr );
        }

        #endregion

    }
}
