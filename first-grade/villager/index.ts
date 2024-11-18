function countCombinations(MaxN: number): number {
	let count = 0;
	let z = 1;
	while (true) {
		const power = 2 ** z; // 2^z
		const denominator = power - 1; // 2^z - 1

		if (denominator > maxN) {
			break;
		}

		const maxNForK = Math.floor(MaxN / denominator);
		count += Math.max(0, maxNForK);
		z++;
	}

	return count;
}

const maxN = parseInt(prompt('Введите maxN:') || '0', 10);
console.log(countCombinations(maxN));
