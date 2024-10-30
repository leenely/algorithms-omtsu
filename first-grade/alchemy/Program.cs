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

bool IsConvertibleToNumber(string value)
{
    // Проверка на null или пустую строку
    if (string.IsNullOrEmpty(value))
    {
        return false;
    }

    // Попробуем конвертировать в int
    if (int.TryParse(value, out _))
    {
        return true;
    }

    // Попробуем конвертировать в double
    if (double.TryParse(value, out _))
    {
        return true;
    }

    // Если не удалось преобразовать в ни один из типов
    return false;
}



string[] operations = new string[line.Length];

string Wrapper(string resString, number numberOperation) {
	resString += operations[numberOperation - 1];
	return resString;
}

string[] lineArrayForm = line.Split('\n');

for(int i = 0; i < lineArrayForm.Length; i++) {
	string[] currentLine = lineArrayForm[i].Split(' ');

	string resString = "";

	switch (currentLine[0]) {
		case "DUST":
			Console.WriteLine($"--- dust ---");

			resString += "DT";

			for (int j = 1; j < currentLine.Length; j++) {
				string currentEntry = currentLine[j];
				if (!IsConvertibleToNumber(currentLine[j])) {
					resString += currentLine[j];
				} else {
					resString = Wrapper(resString, int.Parse(currentLine[j]));
				}
			}
			resString += 'TD';
			operations[operations.length] = resString;
			resString = '';

			console.log(operations);
			break;

		case 'WATER':
			console.log('--- water ---');

			resString += 'WT';

			for (let j = 1; j < currentLine.length; j++) {
				if (isNaN(currentLine[j])) {
					resString += currentLine[j];
				} else {
					resString = Wrapper(resString, currentLine[j]);
				}
			}
			resString += 'TW';
			operations[operations.length] = resString;
			resString = '';

			console.log(operations);
			break;

		case "FIRE":
			console.log('--- fire ---');

			resString += 'FR';

			for (let j = 1; j < currentLine.length; j++) {
				if (isNaN(currentLine[j])) {
					resString += currentLine[j];
				} else {
					resString = Wrapper(resString, currentLine[j]);
				}
			}
			resString += 'RF';
			operations[operations.length] = resString;
			resString = '';

			console.log(operations);
			break;
		
		case "MIX":
			console.log('--- water ---');

			resString += 'MX';

			for (let j = 1; j < currentLine.length; j++) {
				if (isNaN(currentLine[j])) {
					resString += currentLine[j];
				} else {
					resString = Wrapper(resString, currentLine[j]);
				}
			}
			resString += 'XM';
			operations[operations.length] = resString;
			resString = '';

			console.log(operations);
			break;
	}
	console.log(resString);
}

