let tests = [
	{
		matrix: [
			[0, 2, 7],
			[2, 0, 0],
			[7, 0, 0],
		],
		expectedAnswer: 9,
	},
	{
		matrix: [
			[0, 2, 7, 0],
			[2, 0, 0, 3],
			[7, 0, 0, 1],
			[0, 3, 1, 0],
		],
		expectedAnswer: 6,
	},
	{
		matrix: [
			[0, 4, 0, 0, 0, 0],
			[4, 0, 8, 0, 0, 5],
			[0, 8, 0, 7, 9, 0],
			[0, 0, 7, 0, 12, 0],
			[0, 0, 9, 12, 0, 3],
			[0, 5, 0, 0, 3, 0],
		],
		expectedAnswer: 27,
	},
	{
		matrix: [
			[0, 2, 0, 2, 0, 0, 0],
			[2, 0, 7, 3, 0, 0, 0],
			[0, 7, 0, 0, 0, 9, 0],
			[2, 3, 0, 0, 0, 0, 5],
			[0, 0, 0, 0, 0, 3, 10],
			[0, 0, 9, 0, 3, 0, 0],
			[0, 0, 0, 5, 10, 0, 0],
		],
		expectedAnswer: 28,
	},
]

function prim(graph: number[][]) {
	let visited: number[] = []

	let result: number[][] = []
	let summedResult: number = 0
	// generate unvisited
	let unvisited: number[] = []
	graph.forEach((array, index) => {
		if (array.some(el => el != 0)) {
			unvisited.push(index)
		}
	})

	visited.push(unvisited[0])

	while (visited.length < graph.length) {
		let minWeight = 10000000
		let vertexNow = 0
		let vertexPast = 0

		// Среди посещённых находим ребро с минимальным весом к непосещённым
		for (let vertex of visited) {
			for (let v = 0; v < graph.length; v++) {
				const isContains = visited.includes(v)

				if (
					!isContains &&
					graph[vertex][v] < minWeight &&
					0 < graph[vertex][v]
				) {
					vertexNow = v
					vertexPast = vertex
					minWeight = graph[vertex][v]
				}
			}
		}

		if (vertexNow !== 0) {
			summedResult += minWeight
			visited.push(vertexNow)
			result.push([vertexPast + 1, vertexNow + 1, minWeight, summedResult])
		}
	}

	return result
}

function kruskal(graph: number[][]) {
	let edges: number[][] = [];
	
	// Запись связей
	for(let i = 0; i < graph.length; i++) {
		for(let j = i + 1; j < graph.length; j++) {
			console.log(graph[i][j])
			
			if (graph[i][j] !== 0) {
				edges.push([i, j, graph[i][j]])
			}
		}
	}
	edges.sort((a,b) => a[2] - b[2])
	
	const result: number = 0;
	let weight = 0;
	
	for (const edge of edges) {
		const u = edge[0]
		const v = edge[1]
	}
	
	return edges
}

// tests
// for (const test of tests) {
// 	let answer = prim(test.matrix)
// 	answer[answer.length - 1][3] == test.expectedAnswer
// 		? console.log(`Тест пройден`)
// 		: console.log(
// 				`Тест не пройден (expected: ${test.expectedAnswer}, got: ${
// 					answer[answer.length - 1][3]
// 				})`
// 			)
// }

console.log(kruskal(tests[3].matrix))
