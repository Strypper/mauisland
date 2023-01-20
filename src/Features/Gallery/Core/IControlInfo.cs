namespace MAUIsland;

public interface IControlInfo
{
    ImageSource ControlIcon { get; }
    string ControlName { get; }
    string ControlDetail { get; }
    string ControlRoute { get; }
    string GitHubUrl { get; }
    string DocumentUrl { get; }
    string GroupName { get; }
}
