using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;


public class Button 
{
	Vector2 pos;
	string text;
	Rectangle size;
	public bool Clicked;

	public Button(Vector2 pos, string text)
	{
		size = new Rectangle((int)pos.X, (int)pos.Y, 110, 20);
		this.text = text;
		this.pos = pos;
	}
	public void Update()

	{
		if (this.size.Contains(InputManager.LastClicked())) Clicked = true;
	}

	public void Draw()
	{
		Globals.spriteBatch.DrawString(Globals.font, text, pos, Color.White);
		
	}
}
