const line: string = `DUST UHQNzrGlBWgOJFjQNHKI ofVKEv PC iUBgztjcYSJp oylCamnzcELA
MIX tQdKuleBLALFdHMa Skvm
FIRE ony c cXiHjGaVBrPs bnTtkVomsAaJlJL
DUST GRIQFxhbxIBqqQJHeHR VqjttwRETOwwflOhopN VsqSpaKs YonVaZX aEQSgqApq B qIIWsHzEXLGfGfA
WATER jXpTYlQEezkK HiM dFdTPhr 2 nv MBLRshRIMajAnw nt YHMMEa Ev
WATER 3 t eZzJo MzWSYxpLHdIQ
WATER eLHgEEeR UekRjVD xgsySJxovuCfvVVhBb W v 1 GoaTfvX XhQiKiE ZuwUkBfDqLzjrcKpY dMuEXYmCDwHuIgd
DUST Thj ispDFgNvR nzenfPXTLUrEXc 6 stBPuNQbYTCgYRc gEjGoqQEKLdE
FIRE vNCXvSoTf 6
MIX 4 5 7 8 9`;

let operations: string[] = [];

function Wrapper(resString: string, numberOperation: number): string {
	return resString + operations[numberOperation - 1];
}

let lineArrayForm: string[] = line.split('\n');

lineArrayForm.forEach(line => {
	let currentLine: string[] = line.split(' ');
	let type: string = currentLine[0];
	let code: string =
		type === 'DUST' ? 'DT' : type === 'WATER' ? 'WT' : type === 'FIRE' ? 'FR' : 'MX';
	let endCode: string =
		type === 'DUST' ? 'TD' : type === 'WATER' ? 'TW' : type === 'FIRE' ? 'RF' : 'XM';

	let resString: string = code;

	for (let j = 1; j < currentLine.length; j++) {
		if (isNaN(Number(currentLine[j]))) {
			resString += currentLine[j];
		} else {
			resString = Wrapper(resString, Number(currentLine[j]));
		}
	}

	resString += endCode;
	operations.push(resString);

	console.log(operations);
});
