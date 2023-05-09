﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.MediaFoundation.DirectX;

public static class InputManager
{
	private static Vector2 _direction;
	public static Vector2 Direction => _direction;
	public static bool Released;
	
	public static void Update()
	{
		var keyboardState = Keyboard.GetState();

		_direction = Vector2.Zero;

		if (keyboardState.IsKeyDown(Keys.A)) _direction = new(-1, 0);
		if (keyboardState.IsKeyDown(Keys.D)) _direction = new(1, 0);
		if (keyboardState.IsKeyDown(Keys.W)) _direction = new(0, -1);
		if (keyboardState.IsKeyDown(Keys.S)) _direction = new(0, 1);
		
		if (_direction != Vector2.Zero)
		{
			_direction.Normalize();
		}

		if (keyboardState.GetPressedKeys().Length == 0) Released = true;
		else Released = false;

	}

}