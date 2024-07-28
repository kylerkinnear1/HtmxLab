namespace HtmxLab.Features;

public record PilotCard(int Skill, int Points);
public record ShipCard(PilotCard Pilot, ShipType Type, Dial Dial, int MaxHull, int MaxShields);

public enum ShipType
{
    T65,
    T70,
    Z95
}

public record Dial(IEnumerable<Maneuver> Maneuvers);

public enum Direction { Left, Right, Straight }
public enum Bearing { Hard, Bank, KTurn, Sloop, Stop, Reverse }
public record Maneuver(int Speed, Direction Direction, Bearing Bearing);