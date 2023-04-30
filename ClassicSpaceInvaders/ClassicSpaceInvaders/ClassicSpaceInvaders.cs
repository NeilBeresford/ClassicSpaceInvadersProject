using System;
using System.Diagnostics;
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
        #region Constants
        
        // Starting invader setup values
        private readonly float fConstXStartPos  = 20.0f;
        private readonly float fConstYStartPos  = 80.0f;
        private readonly Int32 nConstInvsAcross = 16;
        private readonly Int32 nConstInvsDown   = 8;
        private readonly Int32 nConstInvsXOff   = 36;
        private readonly Int32 nConstInvsYOff   = 28;
        private readonly float fConstInvsSpeed  = 1.500f;

        #endregion


        #region Private Data

        private GraphicsDeviceManager   _graphics;
        private SpriteBatch             _spriteBatch;
        private SpriteFont              outerSpaceFont;
        private Texture2D               blankTexture;
        private Texture2D               invaderSpriteSheet;
        private InvaderSprite           invaderSprite;
        private Sprite                  justTheSprite;

        private TManager<GameObject> SpriteManager = new TManager<GameObject>();
        private TManager<GameObject> PlayerManager = new TManager<GameObject>();
        private TManager<GameObject> BulletManager = new TManager<GameObject>();

        #endregion

        #region Constructors

        public ClassicSpaceInvaders()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            _graphics.PreferredBackBufferWidth  = 800;
            _graphics.PreferredBackBufferHeight = 600;

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

        public TManager<GameObject> BulletController
        {
            get
            {
                return( BulletManager );
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

            SetupSpriteInvaders( fConstXStartPos, fConstYStartPos, nConstInvsAcross, nConstInvsDown, nConstInvsXOff, nConstInvsYOff, fConstInvsSpeed );
            SetupSpritePlayer();

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Sprites update
            SpriteManager.Update( gameTime );
            PlayerManager.Update( gameTime );
            BulletManager.Update( gameTime );

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
            BulletManager.Draw(gameTime);
            PlayerManager.Draw(gameTime);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public bool CheckInvaderCollision( Rectangle otherObjectRect )
        {
            bool bRet = false;

            // Check the collision with the active invader objects...
            if ( SpriteManager.ObjectCount > 0 )
            {
                for( Int32 nIndex = 0; nIndex < SpriteManager.ObjectCount; nIndex++ )
                {
                    Sprite spr = (Sprite)SpriteManager[ nIndex ];

                    if ( spr.CheckCollison( otherObjectRect ) == true )
                    {
                        // collision...
                        SpriteManager.Kill( spr.BaseID );
                        bRet = true;
                        break;
                    }
                }
            }

            return( bRet );
        }


        #endregion

        #region Private Functionality

        private void SetupSpritePlayer()
        {
            // need to create a player sprite, position and add to the playerManager.
            // We also needd to monitor the keyboard keys and then move the player
            // within the limits of the screen (x only)
            PlayerSprite spr = new PlayerSprite(new Sprite( new Vector2( 400, 550 ), new Rectangle( 3, 48, 14, 8 ), Color.LightPink, 3.0f, SpriteEffects.None, 0.0f));

            PlayerManager.Add( spr );

        }


        /// <summary>
        /// Setup the invader sprites for starting the game
        /// </summary>
        private void SetupSpriteInvaders( float fXStart, float fYStart, Int32 Width, Int32 Height, Int32 xInc, Int32 yInc, float Speed )
        {

            // have a starting position, also we will need a reference start frame
            // this means we will need to create all our sprites as invader sprites, add animations

            Rectangle[] InvaderFrames   =   {
                                                new Rectangle(1, 1, 15, 8), new Rectangle(1, 11, 15, 8),        // Invader one frames
                                                new Rectangle(20, 1, 15, 8), new Rectangle(20, 11, 15, 8),      // Invader two frames
                                            };
            Color[] InvaderColours      =   {
                                                new Color( 0x40, 0x40, 0xC8 ),                                  // Colour row one
                                                new Color( 0x48, 0x48, 0xD0 ),                                  // Colour row two
                                                new Color( 0x50, 0x50, 0xD8 ),                                  // Colour row three
                                                new Color( 0x58, 0x58, 0xE0 ),                                  // Colour row four
                                                new Color( 0x60, 0x60, 0xE8 ),                                  // Colour row five
                                                new Color( 0x68, 0x68, 0xF0 ),                                  // Colour row six
                                                new Color( 0x70, 0x70, 0xF8 ),                                  // Colour row seven
                                                new Color( 0x78, 0x78, 0xFF ),                                  // Colour row eigth
                                            };

            Vector2 invPos              = new Vector2( fXStart, fYStart);
            Int32 sprStartFrame     = 0;
            Int32 sprInvaderType    = 1;


            // Create 'Height' rows of 'Width' invaders...
            for (Int32 nYpos = 0; nYpos < Height; nYpos++, invPos.Y = fYStart + (nYpos * yInc))
            {
                // monitor and change invader type
                if ( nYpos == 4 )
                {
                    sprInvaderType = 0;
                }

                invPos.X = fXStart;
                for (Int32 nXpos = 0; nXpos < Width; nXpos++, invPos.X = fXStart + (nXpos * xInc))
                {
                    // Create the invader sprite...
                    InvaderSprite spr = new InvaderSprite(new Sprite( invPos,  InvaderFrames[ (sprInvaderType * 2) + sprStartFrame ], Color.LightBlue, 3.0f, SpriteEffects.None, 0.0f));

                    // Anim invader... ( added starting index and total number of frame which is hard coded to be 2
                    spr.SetAnim( InvaderFrames, (sprInvaderType * 2), 2, Speed, true);
                    spr.SpriteColour    = InvaderColours[ nYpos ];
                    spr.AnimActive      = true;

                    // Add invader sprite to the manager...
                    SpriteManager.Add( spr );
                }

                // change the sprite image for the next row of invaders...
                sprStartFrame++;
                if ( sprStartFrame >= 2 )
                {
                    sprStartFrame = 0;
                }

            }

        }

        #endregion



    }
}
