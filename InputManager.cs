using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
//using System.Windows.Forms;

public static class InputManager
{
    //Hantera mänsklig input

    private static Vector2 _direction;
    public static Vector2 Direction => _direction;
    public static bool Released;

    static KeyboardState currentKeyState;
    static KeyboardState previousKeyState;
    public static Vector2 LastDirection;
    static MouseState mouseState;
    static Point LastClick;
    public static void Update()
    {
        //få tangen tbordets state
        GetState();
        var keyboardState = Keyboard.GetState();
        mouseState = Mouse.GetState();

        //BEstäm en riktning
        _direction = Vector2.Zero;

        if (keyboardState.IsKeyDown(Keys.A)) _direction = new(-1, 0);
        if (keyboardState.IsKeyDown(Keys.D)) _direction = new(1, 0);
        if (keyboardState.IsKeyDown(Keys.W)) _direction = new(0, -1);
        if (keyboardState.IsKeyDown(Keys.S)) _direction = new(0, 1);

        if ((Globals.PlayerPos.X + Globals.PlayerPos.Y) % 64 == 0 && _direction != Vector2.Zero)
        {
            LastDirection = _direction;
        }

        
        if (keyboardState.GetPressedKeys().Length == 0) Released = true;
        else Released = false;

        //musintegration

        if (mouseState.LeftButton == ButtonState.Pressed) { LastClick = new Point(mouseState.X, mouseState.Y); }

    }

    public static KeyboardState GetState()
    {
        previousKeyState = currentKeyState;
        currentKeyState = Keyboard.GetState();
        return currentKeyState;
    }

    public static Point LastClicked()
    {
        return LastClick;
    }

    public static bool HasBeenPressed(Keys key)
    {
        return currentKeyState.IsKeyDown(key) && !previousKeyState.IsKeyDown(key);
    }


}
