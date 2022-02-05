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

            invaderSprite               = new InvaderSprite();
            invaderSprite.Position      = new Vector2( 300, 250 );
            invaderSprite.SourceRect    = new Rectangle( 1, 1, 15, 8 );
            invaderSprite.Origin        = Vector2.Zero;
            invaderSprite.Scale         = 3.0f;
            invaderSprite.Rotation      = 0.0f;
            invaderSprite.SpriteColour  = Color.LightBlue;
            invaderSprite.SpriteDepth   = 0.0f;
            invaderSprite.Effect        = SpriteEffects.None;
            invaderSprite.Speed         = -1.0f;

            SpriteManager.Add( invaderSprite );

            justTheSprite               = new Sprite();
            justTheSprite.Position      = new Vector2( 300, 220 );
            justTheSprite.SourceRect    = new Rectangle( 1, 1, 15, 8 );
            justTheSprite.Origin        = Vector2.Zero;
            justTheSprite.Scale         = 3.0f;
            justTheSprite.Rotation      = 0.0f;
            justTheSprite.SpriteColour  = Color.LightPink;
            justTheSprite.SpriteDepth   = 0.0f;
            justTheSprite.Effect        = SpriteEffects.None;
            justTheSprite.Speed         = -1.0f;

            SpriteManager.Add( justTheSprite );

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

            _spriteBatch.Draw( blankTexture, new Rectangle( 100, 100, 100, 200 ), Color.Crimson );
            _spriteBatch.Draw( blankTexture, new Rectangle( 150, 150, 300, 300 ), Color.RosyBrown );
            _spriteBatch.Draw( blankTexture, new Rectangle( 400, 370, 100, 100 ), Color.Yellow );


            _spriteBatch.Draw( invaderSpriteSheet, new Vector2( 400, 50 ), new Rectangle( 1, 1, 15, 8 ), Color.Aquamarine, 0.0f, Vector2.Zero, 4.0f, SpriteEffects.None, 0.0f );

            _spriteBatch.Draw( invaderSpriteSheet, new Vector2( 300, 300 ), new Rectangle( 1, 1, 15, 8 ), Color.LightCyan, 0.0f, Vector2.Zero, new Vector2( 3,3 ), SpriteEffects.None, 0.0f );
            _spriteBatch.Draw( invaderSpriteSheet, new Vector2( 300, 330 ), new Rectangle( 1, 11, 15, 8 ), Color.LightCyan, 0.0f, Vector2.Zero, new Vector2( 3,3 ), SpriteEffects.None, 0.0f );
            _spriteBatch.Draw( invaderSpriteSheet, new Vector2( 260, 300 ), new Rectangle( 19, 1, 15, 8 ), Color.LightCyan, 0.0f, Vector2.Zero, new Vector2( 3,3 ), SpriteEffects.None, 0.0f );
            _spriteBatch.Draw( invaderSpriteSheet, new Vector2( 260, 330 ), new Rectangle( 19, 11, 15, 8 ), Color.LightCyan, 0.0f, Vector2.Zero, new Vector2( 3,3 ), SpriteEffects.None, 0.0f );


            // draw sprites
            SpriteManager.Draw(gameTime);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        #endregion

    }
}
