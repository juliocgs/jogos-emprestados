namespace Infra.Extension
{
    public static class BooleanExtensions
    {
        public static string ToYesNoString(this bool value)
        {
            return value ? "Sim" : "Não";
        }
    }
}
