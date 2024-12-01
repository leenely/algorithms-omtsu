string line = @" "; // <- Строка, с которой необходимо работать

List<string> operations = new List<string>();

string Wrapper(string resString, int numberOperation)
{
    return resString + operations[numberOperation - 1];
}

string[] lineArrayForm = line.Split('\n');

for (int i = 0; i < lineArrayForm.Length; i++)
{
    string[] parts = lineArrayForm[i].Split(' ');

    List<string> cleanedParts = new List<string>();

    for (int k = 0; k < parts.Length; k++)
    {
        if (!string.IsNullOrWhiteSpace(parts[k]))
        {
            cleanedParts.Add(parts[k]);
        }
    }

    string type = cleanedParts[0];
    string code = type == "DUST" ? "DT" : type == "WATER" ? "WT" : type == "FIRE" ? "FR" : "MX";
    string endCode = type == "DUST" ? "TD" : type == "WATER" ? "TW" : type == "FIRE" ? "RF" : "XM";
    string resString = code;

    for (int j = 1; j < cleanedParts.Count; j++)
    {
        if (int.TryParse(cleanedParts[j], out int number))
        {
            resString = Wrapper(resString, number);
        }
        else
        {
            resString += cleanedParts[j];
        }
    }

    resString += endCode;
    operations.Add(resString);
}

Console.WriteLine(operations[operations.Count - 1]);
