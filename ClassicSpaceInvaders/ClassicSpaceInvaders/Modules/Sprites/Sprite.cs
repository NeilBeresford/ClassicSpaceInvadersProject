using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ClassicSpaceInvaders.Modules.Game;
using ClassicSpaceInvaders.Modules.Utilities;
using ClassicSpaceInvaders.Modules.Managers;
using System;

namespace ClassicSpaceInvaders.Modules.Sprites
{
    public class Sprite : GameObject
    {
        #region Private Data

        private Vector2 position;
        private Rectangle sourceRect;
        private float fScale;
        private Vector2 origin;
        private float fRotation;
        private Color spriteColour;
        private SpriteEffects effect;
        private float sprDepth;

        private float fSpeed;

        private Int32 nSpriteID;

        #endregion

        #region Constructors etc

        public Sprite()
        {
            Reset();
        }

        public Sprite(Vector2 inPosition, Rectangle inSourceRect)
        {
            Reset();
            position = inPosition;
            sourceRect = inSourceRect;
        }

        public Sprite(Vector2 inPosition, Rectangle inSourceRect, Color inColour, float inScale, SpriteEffects inEffects, float inSpeed)
        {
            Reset();
            position = inPosition;
            sourceRect = inSourceRect;
            spriteColour = inColour;
            fScale = inScale;
            effect = inEffects;
            fSpeed = inSpeed;
        }


        #endregion

        #region Properties

        public Vector2 Position
        {
            get { return (position); }
            set { position = value; }
        }
        public Rectangle SourceRect
        {
            get { return (sourceRect); }
            set { sourceRect = value; }
        }

        public float Scale
        {
            get { return (fScale); }
            set { fScale = value; }
        }

        public Vector2 Origin
        {
            get { return (origin); }
            set { origin = value; }
        }
        public float Rotation
        {
            get { return (fRotation); }
            set { fRotation = value; }
        }

        public Color SpriteColour
        {
            get { return (spriteColour); }
            set { spriteColour = value; }
        }

        public SpriteEffects Effect
        {
            get { return (effect); }
            set { effect = value; }
        }

        public float SpriteDepth
        {
            get { return (sprDepth); }
            set { sprDepth = value; }
        }

        public float Speed
        {
            get { return (fSpeed); }
            set { fSpeed = value; }
        }

        public Int32 SpriteID
        {
            get { return( nSpriteID ); }
            set { nSpriteID = value; }
        }

    #endregion

    #region Public Functionality

    public override void Initialise()
        {
        }

        public override void LoadContent()
        {
        }

        public override void Update(GameTime gameTime)
        {
        }
        public override void Draw(GameTime gameTime)
        {
            Global.Instance.CoreGame.SprBatch.Draw( Global.Instance.InvaderSprTexture, Position, SourceRect, SpriteColour, Rotation, Origin, Scale, Effect, SpriteDepth );            
        }


        public Vector2 GetSpriteSize()
        {
            return( new Vector2( SourceRect.Width * Scale, sourceRect.Height * Scale ) );
        }


        public Rectangle GetSpriteRectScaled()
        {
            return( new Rectangle( (Int32)Position.X, (Int32)Position.Y, (Int32)(SourceRect.Width * Scale), (Int32)(SourceRect.Height * Scale) ) );
        }

        public bool CheckCollison( Rectangle otherObjectRect )
        {
            bool bRet = false;

            bRet = otherObjectRect.Intersects( GetSpriteRectScaled() );

            return( bRet );
        }

        #endregion

        #region Private Functionality

        private void Reset()
        {
            position = new Vector2(0.0f);
            sourceRect = new Rectangle(0, 0, 8, 8);
            spriteColour = Color.White;

            fSpeed = 0.0f;
            origin = new Vector2(0.0f);
            fRotation = 0.0f;
            fScale = 1.0f;
            sprDepth = 0.0f;
            effect = SpriteEffects.None;
        }

        #endregion

    }
}
