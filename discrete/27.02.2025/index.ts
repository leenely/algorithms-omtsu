export function Dijkstra(matrix, start, end) {
  const n = matrix.length
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
      if (fetchedMatrix[nodeNow - 1][k - 1] !== Infinity && !visitedNodes[k]) {
        if (
          distances[nodeNow] + fetchedMatrix[nodeNow - 1][k - 1] <
          distances[k]
        ) {
          distances[k] = distances[nodeNow] + fetchedMatrix[nodeNow - 1][k - 1]
        }
      }
    }
  }

  return distances[end] === Infinity ? -1 : distances[end]
}
