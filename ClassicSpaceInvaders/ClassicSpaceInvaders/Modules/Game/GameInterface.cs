using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ClassicSpaceInvaders.Modules.Game
{
    public interface GameInterface
    {
        #region Public Functions

        /// <summary>
        /// Initialise called on creation of object
        /// </summary>
        abstract void Initialise();

        /// <summary>
        /// Loads the content at prior to full use
        /// </summary>
        abstract void LoadContent();

        /// <summary>
        /// Update allow logic and input etc to be handled
        /// </summary>
        /// <param name="gameTime"></param>
        abstract void Update( GameTime gameTime );

        /// <summary>
        /// Draws all objects to the screen
        /// </summary>
        /// <param name="gameTime"></param>
        abstract void Draw( GameTime gameTime );

        #endregion
    }
}
