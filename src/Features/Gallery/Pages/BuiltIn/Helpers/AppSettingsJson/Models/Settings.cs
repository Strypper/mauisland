namespace MAUIsland;
public class Settings
{
    public int KeyOne { get; set; }
    public bool KeyTwo { get; set; }
    public NestedSettings KeyThree { get; set; } = null!;
}

public class NestedSettings
{
    public string Message { get; set; } = null!;
}