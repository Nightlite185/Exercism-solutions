public static class ResistorColorDuo
{
    private static Dictionary<string, char>  colorNums = new()
    {
        ["black"]  =  '0',
        ["brown"]  =  '1',
        ["red"]    =  '2',
        ["orange"] =  '3',
        ["yellow"] =  '4',
        ["green"]  =  '5',
        ["blue"]   =  '6',
        ["violet"] =  '7',
        ["grey"]   =  '8',
        ["white"]  =  '9',
    };

    public static int Value(string[] colors)
    {
        if (!colors.Any(colorNums.ContainsKey))
            throw new ArgumentException("one of the elements in list is invalid");

        var strNumbers = new string([.. colors[0..2].Select(c => colorNums[c])]);

        return int.TryParse(strNumbers, out int result)
            ? result
            : throw new Exception("It's literally impossible to get to this line, so if you got this exception, well uhh.. good luck ;D");
    }
}