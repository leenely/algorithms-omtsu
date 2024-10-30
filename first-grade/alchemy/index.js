let line = `DUST UHQNzrGlBWgOJFjQNHKI ofVKEv PC iUBgztjcYSJp oylCamnzcELA
MIX tQdKuleBLALFdHMa Skvm
FIRE ony c cXiHjGaVBrPs bnTtkVomsAaJlJL
DUST GRIQFxhbxIBqqQJHeHR VqjttwRETOwwflOhopN VsqSpaKs YonVaZX aEQSgqApq B qIIWsHzEXLGfGfA
WATER jXpTYlQEezkK HiM dFdTPhr 2 nv MBLRshRIMajAnw nt YHMMEa Ev
WATER 3 t eZzJo MzWSYxpLHdIQ
WATER eLHgEEeR UekRjVD xgsySJxovuCfvVVhBb W v 1 GoaTfvX XhQiKiE ZuwUkBfDqLzjrcKpY dMuEXYmCDwHuIgd
DUST Thj ispDFgNvR nzenfPXTLUrEXc 6 stBPuNQbYTCgYRc gEjGoqQEKLdE
FIRE vNCXvSoTf 6
MIX 4 5 7 8 9`;

let operations = [];

function Wrapper(resString, numberOperation) {
	resString += operations[numberOperation - 1];
	return resString;
}

let lineArrayForm = line.split('\n');

for (let i = 0; i < lineArrayForm.length; i++) {
	let currentLine = lineArrayForm[i].split(' ');

	let resString = '';

	switch (currentLine[0]) {
		case 'DUST':
			console.log('--- dust ---');

			resString += 'DT';

			for (let j = 1; j < currentLine.length; j++) {
				if (isNaN(currentLine[j])) {
					resString += currentLine[j];
				} else {
					resString = Wrapper(resString, currentLine[j]);
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

