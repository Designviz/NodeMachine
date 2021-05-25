using ImGuiNET;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using MonoGame.ImGui;
using Num = System.Numerics;
namespace NodeMachine
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public ImGUIRenderer GuiRenderer; //This is the ImGuiRenderer
        private Texture2D _xnaTexture;
        private IntPtr _imGuiTexture;

        public Game1()
        {
            
            _graphics = new GraphicsDeviceManager(this);
            
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            

        }

        protected override void Initialize()
        {

            GuiRenderer = new ImGUIRenderer(this).Initialize().RebuildFontAtlas();
            // TODO: Add your initialization logic here
            _xnaTexture = Content.Load<Texture2D>("Skins/NodeEditor/RegularNode_body");
            _imGuiTexture = GuiRenderer.BindTexture(_xnaTexture);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            //Your regular Game draw calls
            _spriteBatch.End();


            base.Draw(gameTime);

            GuiRenderer.BeginLayout(gameTime);
            ImGui.Begin("Widget");
            ImGui.Text("Hello, world!");
            ImGui.Image(_imGuiTexture, new Num.Vector2(300, 150), Num.Vector2.Zero, Num.Vector2.One, Num.Vector4.One, Num.Vector4.One);
            ImGui.End();
            //Insert Your ImGui code

            GuiRenderer.EndLayout();
        }
    }
}
