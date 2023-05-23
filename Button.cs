using System;
using Microsoft.Xna.Framework;


public class Button 
{
	Vector2 pos;
	string text;
	Rectangle size;
	public bool Clicked;

	public Button(Vector2 pos, string text)
	{
		size = new Rectangle((int)pos.X, (int)pos.Y, 500, 500);
		this.text = text;
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
