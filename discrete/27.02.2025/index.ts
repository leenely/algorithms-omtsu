export function Dijkstra(matrix: number[][], start: number, end: number) {
	const n = matrix.length;
	start = start - 1
	end = end - 1
	
	const fetchedMatrix = matrix.map((row) => {
		return row.map((el) => {
			if (el === 0) return Infinity
			return el
		})
	})
	
	const distances = new Array(n).fill(Infinity)
	const visitedNodes = new Array(n).fill(false)
	distances[start] = 0

	for (let i = 0; i < n; i++) {
		let minDistance = Infinity
		let nodeNow = -1

		for (let j = 0; j < n; j++) {
			if (!visitedNodes[j] && distances[j] < minDistance) {
				minDistance = distances[j]
				nodeNow = j
			}
		}

		if (nodeNow === -1) break;
		visitedNodes[nodeNow] = true

		for (let k = 0; k < n; k++) {
			if (fetchedMatrix[nodeNow][k] !== Infinity && !visitedNodes[k]) {
				if (distances[nodeNow] + fetchedMatrix[nodeNow][k] < distances[k]) {
					distances[k] = distances[nodeNow] + fetchedMatrix[nodeNow][k]
				}
			}
		}
	}
	
	if (distances[end] === Infinity) return -1;
	return distances[end]
}
