using Xunit.Sdk;

public static class PlayAnalyzer
{
    public static string AnalyzeOnField(int shirtNum)
    {
        return shirtNum switch
        {
            1 => "goalie",
            2 => "left back",
            3 or 4 => "center back",
            5 => "right back",
            6 or 7 or 8 => "midfielder",
            9 => "left wing",
            10 => "striker",
            11 => "right wing",

            _ => "UNKNOWN",
        };

    }

    public static string AnalyzeOffField(object report)
    {
        
        return report switch
        {
            int => $"There are {report} supporters at the match.",
            string => (string)report,
            Foul foul => foul.GetDescription(),
            Injury inj => $"Oh no! {inj.GetDescription()} Medics are on the field.",
            Incident => "An incident happened.",
            Manager manager =>
                manager.Club == null ? $"{manager.Name}" :
                $"{manager.Name} ({manager.Club})",

            _ => ""
        };
        
        
    }
}
