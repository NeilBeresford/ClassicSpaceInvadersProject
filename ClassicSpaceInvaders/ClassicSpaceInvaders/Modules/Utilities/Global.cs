using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ClassicSpaceInvaders.Modules.Game;


namespace ClassicSpaceInvaders.Modules.Utilities
{
    public sealed class Global
    {
        #region Singleton

        private static readonly Global mInstance = new Global();
        
        static Global()
        {
        }

        public static Global Instance
        {
            get { return( mInstance ); }
        }

        #endregion

        #region Properties

        public ClassicSpaceInvaders CoreGame            {  get; set; }

        public Texture2D            InvaderSprTexture   {  get; set; }

        #endregion


    }
}
