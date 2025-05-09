function dijkstra(matrix, start, end, n) {
  const distances = new Array(n + 1).fill(Infinity)
  distances[start] = 0

  const visitedNodes = new Array(n + 1).fill(false)

  const fetchedMatrix = matrix.map(row =>
    row.map(el => (el === 0 ? Infinity : el))
  )

  for (let i = 1; i <= n; i++) {
    let nodeNow = -1

    for (let j = 1; j <= n; j++) {
      if (!visitedNodes[j]) {
        if (nodeNow === -1 || distances[j] < distances[nodeNow]) {
          nodeNow = j
        }
      }
    }

    if (distances[nodeNow] === Infinity) break

    visitedNodes[nodeNow] = true

    for (let k = 1; k <= n; k++) {
      if (fetchedMatrix[nodeNow][k] !== Infinity && !visitedNodes[k]) {
        if (
          distances[nodeNow] + fetchedMatrix[nodeNow][k] <
          distances[k]
        ) {
          distances[k] = distances[nodeNow] + fetchedMatrix[nodeNow][k]
        }
      }
    }
  }

  return distances[end] === Infinity ? -1 : distances[end]
}


function findCompany(n, connections, start, end) {

  const matrixes = [
    Array.from({ length: n + 1 }, () => Array(n + 1).fill(Infinity)),
    Array.from({ length: n + 1 }, () => Array(n + 1).fill(Infinity)),
    Array.from({ length: n + 1 }, () => Array(n + 1).fill(Infinity)),
  ]

  for (const [u, v, a1, a2, a3] of connections) {
    matrixes[0][v][u] = Math.min(matrixes[0][v][u], a1)
    matrixes[0][u][v] = Math.min(matrixes[0][u][v], a1)

    matrixes[1][u][v] = Math.min(matrixes[1][u][v], a2)
    matrixes[1][v][u] = Math.min(matrixes[1][v][u], a2)

    matrixes[2][u][v] = Math.min(matrixes[2][u][v], a3)
    matrixes[2][v][u] = Math.min(matrixes[2][v][u], a3)
  }

  const costs = [
    dijkstra(matrixes[0], start, end, n),
    dijkstra(matrixes[1], start, end, n),
    dijkstra(matrixes[2], start, end, n),
  ]

  let minCost = Infinity
  let minCompanyIndex = -1

  for (let i = 0; i < 3; i++) {
    if (costs[i] < minCost) {
      minCost = costs[i]
      minCompanyIndex = i
    }
  }

  if (minCost === Infinity) {
    return -1
  } else {
    console.log(`${minCompanyIndex}: ${minCost}`)
  }
}

// Тестовые данные
const N = 6;
const connections: [number, number, number, number, number][] = [
    [1, 2, 8, 12, 15],
    [2, 3, 10, 5, 7],
    [1, 3, 20, 8, 10],
    [3, 4, 15, 10, 12],
    [2, 4, 25, 20, 18],
    [4, 5, 5, 8, 10]
];
const startStation = 1;
const endStation = 5;

// const N = 5
// const connections: [number, number, number, number, number][] = [
//   [1, 2, 10, 15, 20],
//   [2, 3, 5, 10, 15],
//   [1, 3, 20, 10, 5],
//   [3, 4, 10, 15, 20],
//   [2, 4, 30, 25, 20],
// ]
// const startStation = 1
// const endStation = 4

findCompany(N, connections, startStation, endStation)
