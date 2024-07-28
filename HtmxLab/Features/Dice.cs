using static HtmxLab.Features.AttackDiceFace;
using static HtmxLab.Features.DefenseDiceFace;

namespace HtmxLab.Features;

public record Dice<TFace>(IEnumerable<TFace> Faces);
public enum AttackDiceFace { Hit, Miss, Crit, Focus }
public enum DefenseDiceFace { Evade, Miss, Focus }

public record Dice
{
    public static readonly Dice<AttackDiceFace> Attack = new(new[]
    {
        Hit, Hit, AttackDiceFace.Miss, AttackDiceFace.Miss, AttackDiceFace.Focus, Crit
    });

    public static readonly Dice<DefenseDiceFace> Defense = new(new[]
    {
        Evade, Evade, Evade, DefenseDiceFace.Miss, DefenseDiceFace.Miss, DefenseDiceFace.Focus
    });
}