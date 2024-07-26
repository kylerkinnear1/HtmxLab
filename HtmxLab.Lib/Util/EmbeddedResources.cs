using System.Reflection;
using System.Text;

namespace HtmxLab.Lib.Util;

public static class EmbeddedResources
{
    public static async ValueTask<string> LoadStringFileAsync(this string filename, Assembly? assembly = null)
    {
        assembly ??= Assembly.GetExecutingAssembly();
        await using var stream = assembly
            .GetManifestResourceStream($"{assembly.GetName().Name!}.{filename}")!;
        using var streamReader = new StreamReader(stream, Encoding.UTF8);
        return await streamReader.ReadToEndAsync();
    }
}