using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.MediaFoundation.DirectX;

public static class InputManager
{
	private static Vector2 _direction;
	public static Vector2 Direction => _direction;
	public static bool Released;

    static KeyboardState currentKeyState;
    static KeyboardState previousKeyState;
	public static Vector2 LastDirection;
    public static void Update()
	{



		GetState();

		var keyboardState = Keyboard.GetState();

		_direction = Vector2.Zero;

		if (keyboardState.IsKeyDown(Keys.A)) _direction = new(-1, 0);
		if (keyboardState.IsKeyDown(Keys.D)) _direction = new(1, 0);
		if (keyboardState.IsKeyDown(Keys.W)) _direction = new(0, -1);
		if (keyboardState.IsKeyDown(Keys.S)) _direction = new(0, 1);
		
		if ((Globals.PlayerPos.X + Globals.PlayerPos.Y) % 64 == 0 && _direction != Vector2.Zero)
		{


			LastDirection = _direction;
		} 

		//Diagonaler
		//if (_direction != Vector2.Zero)
		//{
		//	_direction.Normalize();
		//}

		if (keyboardState.GetPressedKeys().Length == 0) Released = true;
		else Released = false;

	}

    public static KeyboardState GetState()
    {
        previousKeyState = currentKeyState;
        currentKeyState = Keyboard.GetState();
        return currentKeyState;
    }

    public static bool IsPressed(Keys key)
    {
        return currentKeyState.IsKeyDown(key);
    }

    public static bool HasBeenPressed(Keys key)
    {
        return currentKeyState.IsKeyDown(key) && !previousKeyState.IsKeyDown(key);
    }


}
