using Microsoft.Xna.Framework;

// Interface för det som kan flyttas på
public interface IBonkable
{
    public Vector2 Position { get; set; }
    public void AdvanceRound() { }

    //abstract void bonk { }
}
