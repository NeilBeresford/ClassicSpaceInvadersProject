using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using ClassicSpaceInvaders.Modules.Utilities;
using ClassicSpaceInvaders.Modules.Sprites;
using ClassicSpaceInvaders.Modules.GameSprites;
using ClassicSpaceInvaders.Modules.Managers;


namespace ClassicSpaceInvaders
{
    public class ClassicSpaceInvaders : Game
    {
        #region Private Data

        private GraphicsDeviceManager   _graphics;
        private SpriteBatch             _spriteBatch;
        private SpriteFont              outerSpaceFont;
        private Texture2D               blankTexture;
        private Texture2D               invaderSpriteSheet;
        private InvaderSprite           invaderSprite;
        private Sprite                  justTheSprite;

        private TManager<GameObject>    SpriteManager = new TManager<GameObject>();

        #endregion

        #region Constructors

        public ClassicSpaceInvaders()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        #endregion

        #region Properties

        public SpriteBatch SprBatch
        {
            get
            {
                return( _spriteBatch );
            }
        }

        #endregion

        #region Public Functionality

        protected override void Initialize()
        {

            Global.Instance.CoreGame = this;


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch                        = new SpriteBatch(GraphicsDevice);
            outerSpaceFont                      = Content.Load<SpriteFont>( "OuterSpace" );
            blankTexture                        = Content.Load<Texture2D>( "Blank2x2" );
            invaderSpriteSheet                  = Content.Load<Texture2D>( "SpaceInvadersTransparent" );

            Global.Instance.InvaderSprTexture   = invaderSpriteSheet;

            SetupSpriteInvaders( 20.0f, 80.0f, 16, 8, 36, 28 );

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Sprites update
            SpriteManager.Update( gameTime );

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin( SpriteSortMode.Immediate, BlendState.AlphaBlend,
                                SamplerState.PointClamp, DepthStencilState.Default,
                                RasterizerState.CullNone );


            _spriteBatch.DrawString( outerSpaceFont, "CLASSIC SPACE INVADERS", new Vector2( 10, 10 ), Color.White );

            // draw sprites
            SpriteManager.Draw(gameTime);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        #endregion

        #region Private Functionality
        /// <summary>
        /// Setup the invader sprites for starting the game
        /// </summary>
        private void SetupSpriteInvaders( float fXStart, float fYStart, Int32 Width, Int32 Height, Int32 xInc, Int32 yInc )
        {

            // have a starting position, also we will need a reference start frame
            // this means we will need to create all our sprites as invader sprites, add animations

            Rectangle[] InvaderFrames   = { new Rectangle(1, 1, 15, 8), new Rectangle(1, 11, 15, 8) };
            Vector2 invPos              = new Vector2( fXStart, fYStart);
            Int32   sprStartFrame       = 0;


            // Create 'Height' rows of 'Width' invaders...
            for (Int32 nYpos = 0; nYpos < Height; nYpos++, invPos.Y = fYStart + (nYpos * yInc))
            {
                invPos.X = fXStart;
                for (Int32 nXpos = 0; nXpos < Width; nXpos++, invPos.X = fXStart + (nXpos * xInc))
                {
                    // Create the invader sprite...
                    InvaderSprite spr = new InvaderSprite(new Sprite( invPos,  InvaderFrames[ sprStartFrame ], Color.LightBlue, 3.0f, SpriteEffects.None, 0.0f));

                    // Anim invader...
                    spr.SetAnim( InvaderFrames, 0.250f, true);
                    spr.AnimActive = true;

                    // Add invader sprite to the manager...
                    SpriteManager.Add( spr );
                }

                // change the sprite image for the next row of invaders...
                sprStartFrame++;
                if ( sprStartFrame >= InvaderFrames.Length )
                {
                    sprStartFrame = 0;
                }

            }




        }

        #endregion



    }
}
