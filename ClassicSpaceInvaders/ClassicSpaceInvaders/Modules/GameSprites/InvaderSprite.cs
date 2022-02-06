using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ClassicSpaceInvaders.Modules.Game;
using ClassicSpaceInvaders.Modules.Utilities;
using ClassicSpaceInvaders.Modules.Sprites;

namespace ClassicSpaceInvaders.Modules.GameSprites
{
    public class InvaderSprite : AnimSprite
    {
        #region Public Functionality

        public override void Update( GameTime gameTime )
        {
            Vector2 pos = Position;
            
            pos.X += Speed;
            
            if ( Position.X < 10.0f )
                Speed = 1.0f;
            if ( Position.X > 500.0f )
                Speed = -1.0f;
    
            Position = pos;

            base.Update( gameTime );

        }

        public override void Draw( GameTime gameTime )
        {
            base.Draw( gameTime );   
        }


        #endregion
    }
}
