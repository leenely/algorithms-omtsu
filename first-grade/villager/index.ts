function countCombinations(MaxN: number): number {
	let count = 0;
	let Z = 1;
	while (true) {
		const power = 2 ** Z; // 2^Z
		const denominator = power - 1; // 2^Z - 1

		if (denominator > MaxN) {
			break;
		}
		
		const max_N_for_K = Math.floor(MaxN / denominator);
		count += Math.max(0, max_N_for_K);
		Z++;
	}

	return count;
}

const MaxN = parseInt(prompt('Введите MaxN:') || '0', 10);
console.log(countCombinations(MaxN));
