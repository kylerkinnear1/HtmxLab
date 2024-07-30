namespace HtmxLab.Components.Pilot;

public record PilotDto(
    string Slug,
    string Name,
    string PilotCardUrl,
    ShipModel Model,
    int Skill,
    int Attack,
    int Agility,
    int Hull,
    int Shields,
    int Points);

public enum ShipModel
{
    XWing = 0,
    TieAdvanced = 1
    // TODO: remaining
}

public class PilotStateDto
{
    public int Skill { get; set; }
    public int Attack { get; set; }
    public int Agility { get; set; }
}

// TODO: Load by scanning
public static class PilotCards
{
    public static IEnumerable<PilotDto> All
    {
        get
        {
            yield return XWing.LukeSkywalker;
            yield return TieAdvanced.DarthVader;
        }
    }
    
    public static class XWing
    {
        public static PilotDto LukeSkywalker => new(
            "xwing-luke-skywalker", "Luke Skywalker", "./images/pilots/rebels/xwing/lukeskywalker.png", ShipModel.XWing, 8, 3, 2, 3, 2, 28);
    }

    public static class TieAdvanced
    {
        public static PilotDto DarthVader => new(
            "tieadvanced-darth-vader", "Darth Vader", "./images/pilots/imperial/tieadvanced/darthvader.png", ShipModel.TieAdvanced, 9, 2, 3, 3, 2, 29);
    }
}