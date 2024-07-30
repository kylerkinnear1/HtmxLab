using HtmxLab.Components.Pilot;

namespace HtmxLab.Components.Home;

public record HomeDto(
    List<PilotDto> AllPilots);