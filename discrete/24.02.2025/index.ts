export function findBridges(matrix: number[][]): [number, number][] {
	const n = matrix.length
	const bridges: [number, number][] = []

	for (let v = 0; v < n; v++) {
		for (let u = v + 1; u < n; u++) {
			if (matrix[v][u] === 1) {
				matrix[v][u] = matrix[u][v] = 0

				if (!isConnected(matrix, v, u)) {
					bridges.push([v, u])
				}

				matrix[v][u] = matrix[u][v] = 1
			}
		}
	}

	return bridges
}

function isConnected(matrix: number[][], start: number, end: number): boolean {
	const n = matrix.length
	const visited = new Array(n).fill(false)
	const queue: number[] = [start]
	visited[start] = true

	while (queue.length > 0) {
		const current = queue.shift()!
		if (current === end) return true

		for (let next = 0; next < n; next++) {
			if (matrix[current][next] === 1 && !visited[next]) {
				visited[next] = true
				queue.push(next)
			}''
		}
	}

	return false
}