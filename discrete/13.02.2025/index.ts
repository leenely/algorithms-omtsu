const tests = [
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
	{
		matrix: [
			[0, 0, 0],
			[0, 0, 0],
			[0, 0, 0],
		],
		expectedAnswer: 0,
	},
	{
		matrix: [
			[0, 1],
			[1, 0],
		],
		expectedAnswer: 1,
	},
	{
		matrix: [
			[0, 4, 0, 0, 0, 0, 0, 8, 0, 0],  
			[4, 0, 8, 0, 0, 0, 0, 11, 0, 0], 
			[0, 8, 0, 7, 0, 4, 0, 0, 2, 0],  
			[0, 0, 7, 0, 9, 14, 0, 0, 0, 0], 
			[0, 0, 0, 9, 0, 10, 0, 0, 0, 0], 
			[0, 0, 4, 14, 10, 0, 2, 0, 0, 0],
			[0, 0, 0, 0, 0, 2, 0, 1, 6, 0],  
			[8, 11, 0, 0, 0, 0, 1, 0, 7, 0], 
			[0, 0, 2, 0, 0, 0, 6, 7, 0, 1],  
			[0, 0, 0, 0, 0, 0, 0, 0, 1, 0]   
	],
		expectedAnswer: 38,
	},
]

function prim(graph: number[][]) {
	let visited: number[] = []

	let result: number[][] = []
	let summedResult: number = 0
	let unvisited: number[] = []
	graph.forEach((array, index) => {
		if (array.some(el => el != 0)) {
			unvisited.push(index)
		}
	})

	// Если нет связных вершин, возвращаем пустой результат
	if (unvisited.length === 0) {
		return [[0, 0, 0, 0]]
	}

	visited.push(unvisited[0])

	while (visited.length < graph.length) {
		let minWeight = Math.max(...graph[0]) + 1
		let vertexNow = 0
		let vertexPast = 0
		let foundPath = false

		// Среди посещённых находим ребро с минимальным весом к непосещённым
		for (let vertex of visited) {
			for (let v = 0; v < graph.length; v++) {
				const isContains = visited.includes(v)

				if (
					!isContains &&
					graph[vertex] &&
					graph[vertex][v] < minWeight &&
					graph[vertex][v] !== 0
				) {
					vertexNow = v
					vertexPast = vertex
					minWeight = graph[vertex][v]
					foundPath = true
				}
			}
		}

		if (!foundPath) {
			break // Если не нашли путь, прерываем цикл
		}

		summedResult += minWeight
		visited.push(vertexNow)
		result.push([vertexPast + 1, vertexNow + 1, minWeight, summedResult])
	}

	if (result.length === 0) {
		return [[0, 0, 0, 0]]
	}

	return result
}

function kruskal(graph: number[][]) {
	let edges: number[][] = []

	// Запись связей
	for (let i = 0; i < graph.length; i++) {
		for (let j = i + 1; j < graph.length; j++) {
			if (graph[i][j] !== 0) {
				edges.push([i, j, graph[i][j]])
			}
		}
	}
	
	// Если нет рёбер, возвращаем 0
	if (edges.length === 0) {
		return 0
	}

	// Сортировка рёбер по весу
	edges.sort((a, b) => a[2] - b[2])

	// Создаём компонент связности
	let components: number[] = []
	for (let i = 0; i < graph.length; i++) {
		components.push(i)
	}

	let weight = 0

	// Проходим по рёбрам и объединяем компоненты
	for (const edge of edges) {
		let u = edge[0]
		let v = edge[1]

		if (components[u] !== components[v]) {
			weight += edge[2]
			let oldComponent = components[u]
			let newComponent = components[v]

			// Обновление компонент
			for (let i = 0; i < components.length; i++) {
				if (components[i] === oldComponent) {
					components[i] = newComponent
				}
			}
		}
	}

	return weight
}

// Тесты
for (const test of tests) {
	let answer_prim = prim(test.matrix)
	let answer_kruskal = kruskal(test.matrix)
	answer_prim[answer_prim.length - 1][3] == test.expectedAnswer &&
	answer_kruskal == test.expectedAnswer
		? console.log(`Тест пройден`)
		: console.log(
				`Тест не пройден (Ожидаемый ответ: ${test.expectedAnswer}. Прима: ${
					answer_prim[answer_prim.length - 1][3]
				}, Крускала: ${answer_kruskal})`
		  )
}
