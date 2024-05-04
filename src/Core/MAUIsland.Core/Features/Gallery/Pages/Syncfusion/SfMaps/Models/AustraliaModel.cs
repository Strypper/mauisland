namespace MAUIsland.Core;
public class AustraliaModel
{
    public AustraliaModel(string state, int size)
    {
        State = state;
        Size = size;
    }

    public string State
    {
        get;
        set;
    }

    public int Size
    {
        get;
        set;
    }
}