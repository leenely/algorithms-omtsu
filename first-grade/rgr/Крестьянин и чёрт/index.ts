function countCombinations(maxN: number): number {
	let count = 0;

	for (let z = 1; ; z++) {
			const pow = Math.pow(2, z);
			const div = pow - 1;

			if (div > maxN) break;

			const maxNForK = Math.floor(maxN / div);

			count += Math.max(0, maxNForK);
	}

	return count;
}

const maxN = parseInt(prompt('Введите maxN:') || '0', 10);
console.log(countCombinations(maxN));