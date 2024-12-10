let isMinCounterUsed = false;
function checkMinCounter(minCounter: number, counter: number, flag: boolean): number {
	if (!flag) {
		minCounter = counter;
        isMinCounterUsed = true;
	}

	if (counter < minCounter && counter !== 0) {
		minCounter = counter;
	}

	return minCounter;
}

function findMinLengthDecreasingSubsequence(arr: number[]): number {
	if (arr.length < 2) {
		return 0;
	}

	let difference = -1000000; // Берём такой флаг для первой итерации
	let counter = 2;
	let minCounter = 0;

	for (let i = 1; i < arr.length; i++) {
		let tempDifference = arr[i] - arr[i - 1];

		if (difference === -1000000) {
			difference = tempDifference;
			continue;
		}

		if (arr[i] - arr[i - 1] > 0) {
			difference = tempDifference;
			minCounter = checkMinCounter(minCounter, counter, isMinCounterUsed);
			counter = 0;
			continue;
		}

		if (tempDifference === difference) {
			counter++;
		} else {
			difference = tempDifference;
            minCounter = checkMinCounter(minCounter, counter, isMinCounterUsed);
			counter = 2;
		}
	}
    minCounter = checkMinCounter(minCounter, counter, isMinCounterUsed);
	isMinCounterUsed = false;
	return minCounter;
}
// допустим
console.log(findMinLengthDecreasingSubsequence([3, 2, 1])); // 3 (3)
console.log(findMinLengthDecreasingSubsequence([3, 2, 1, 2, 1])); // 2 (2)
console.log(findMinLengthDecreasingSubsequence([3, 2, 1, 2])); // 0 (3)
console.log(findMinLengthDecreasingSubsequence([3, 2, 1, 7, 5])); // 2 (2)
console.log(findMinLengthDecreasingSubsequence([3, 2, 1, 0, 0, 7, 5])); // 2 (2)
console.log(findMinLengthDecreasingSubsequence([2, 1])); // 2 (2)
console.log(findMinLengthDecreasingSubsequence([1])); // 0 (0)
console.log(findMinLengthDecreasingSubsequence([3, 2, 1, 2, 3, 2])); // 2 (2)

