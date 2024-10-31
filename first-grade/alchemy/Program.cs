string line = @"DUST UHQNzrGlBWgOJFjQNHKI ofVKEv PC iUBgztjcYSJp oylCamnzcELA
MIX tQdKuleBLALFdHMa Skvm
FIRE ony c cXiHjGaVBrPs bnTtkVomsAaJlJL
DUST GRIQFxhbxIBqqQJHeHR VqjttwRETOwwflOhopN VsqSpaKs YonVaZX aEQSgqApq B qIIWsHzEXLGfGfA
WATER jXpTYlQEezkK HiM dFdTPhr 2 nv MBLRshRIMajAnw nt YHMMEa Ev
WATER 3 t eZzJo MzWSYxpLHdIQ
WATER eLHgEEeR UekRjVD xgsySJxovuCfvVVhBb W v 1 GoaTfvX XhQiKiE ZuwUkBfDqLzjrcKpY dMuEXYmCDwHuIgd
DUST Thj ispDFgNvR nzenfPXTLUrEXc 6 stBPuNQbYTCgYRc gEjGoqQEKLdE
FIRE vNCXvSoTf 6
MIX 4 5 7 8 9";

List<string> operations = new List<string>();

string Wrapper(string resString, int numberOperation)
{
    return resString + operations[numberOperation - 1];
}

string[] lineArrayForm = line.Split('\n');

foreach (string currentLine in lineArrayForm)
{
    string[] parts = currentLine.Split(' '); 

    List<string> cleanedParts = new List<string>();

    foreach (var part in parts) // Элемент может быть либо типа string, либо типа number
    {
        if (!string.IsNullOrWhiteSpace(part))
        {
            cleanedParts.Add(part);
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