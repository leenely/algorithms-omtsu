const line: string = `DUST aa
FIRE 1`;

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
		if (isNaN(parseInt(currentLine[j]))) {
			resString += currentLine[j];
		} else {
			resString += operations[parseInt(currentLine[j]) - 1];
		}
	}

	resString += endCode;
	operations.push(resString);

	console.log(operations);
});