namespace HtmxLab.Templates;

public record Parent(List<Child> Children);
public record Child(string FirstName, string LastName);
