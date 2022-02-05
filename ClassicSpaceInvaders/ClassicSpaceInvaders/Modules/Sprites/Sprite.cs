using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ClassicSpaceInvaders.Modules.Game;
using ClassicSpaceInvaders.Modules.Utilities;


namespace ClassicSpaceInvaders.Modules.Sprites
{
    public class Sprite : GameInterface
    {
        #region Private Data

        private Vector2         position;
        private Rectangle       sourceRect;
        private float           fScale;
        private Vector2         origin;
        private float           fRotation;
        private Color           spriteColour;
        private SpriteEffects   effect;
        private float           sprDepth;

        private float           fSpeed;

        #endregion

        #region Constructors etc
        #endregion

        #region Properties

        public Vector2 Position
        {
            get { return( position ); }
            set { position = value; }
        }
        public Rectangle SourceRect
        {
            get { return( sourceRect ); }
            set { sourceRect = value; }
        }

        public float Scale
        {
            get { return( fScale ); }
            set { fScale = value; }
        }

        public Vector2 Origin
        {
            get { return( origin ); }
            set { origin = value; }
        }
        public float Rotation
        {
            get { return( fRotation ); }
            set { fRotation = value; }
        }

        public Color SpriteColour
        {
            get { return( spriteColour ); }
            set { spriteColour = value; }
        }

        public SpriteEffects Effect
        {
            get { return( effect ); }
            set { effect = value; }
        }

        public float SpriteDepth
        {
            get { return( sprDepth ); }
            set { sprDepth = value; }
        }

        public float Speed
        {
            get {  return( fSpeed ); }
            set {  fSpeed = value; }
        }


        #endregion

        #region Public Functionality

        public virtual void Initialise()
        {
        }

        public virtual void LoadContent()
        {
        }

        public virtual void Update(GameTime gameTime)
        {
        }
        public virtual void Draw(GameTime gameTime)
        {
            Global.Instance.CoreGame.SprBatch.Draw( Global.Instance.InvaderSprTexture, Position, SourceRect, SpriteColour, Rotation, Origin, Scale, Effect, SpriteDepth );            
        }

        #endregion

        #region Private Functionality

        #endregion

    }
}
