string line = @" "; // <- Строка, с которой необходимо работать

List<string> operations = [];
string[] lineArrayForm = line.Split('\n');

foreach(string currLine in lineArrayForm)
{
	string[] currentLine = currLine.Split(' ');
	string type = currentLine[0];
    string code = type == "DUST" ? "DT" : type == "WATER" ? "WT" : type == "FIRE" ? "FR" : "MX";
    string endCode = type == "DUST" ? "TD" : type == "WATER" ? "TW" : type == "FIRE" ? "RF" : "XM";
    string resString = code;


	for (int j = 1; j < currentLine.Length; j++)
    {
    if (int.TryParse(currentLine[j], out int number) && number - 1 >= 0 && number - 1 < operations.Count)
    {
        resString += operations[number - 1].Trim();
    }
    else
    {
        resString += currentLine[j].Trim();
    }
}

    resString += endCode;
    operations.Add(resString);
}

Console.WriteLine(operations[operations.Count - 1]);