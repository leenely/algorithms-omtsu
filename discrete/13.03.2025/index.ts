function sortedMatrix(matrix: number[][]) {
  const newMatrix = matrix.map(row => {
    return row.map(el => {
      if (el === 0) return Infinity
      return el
    })
  })
  return newMatrix
}

function floyd(matrix: number[][]) {
  matrix = sortedMatrix(matrix)
  const n = matrix.length
  const distance = matrix.map(row => [...row])

  for (let i = 0; i < n; i++) {
    for (let u = 0; u < n; u++) {
      for (let v = 0; v < n; v++) {
        distance[u][v] = Math.min(distance[u][v], distance[u][i] + distance[i][v])
        }
      }
  }
  return distance
}

let matrix = [
  [0, 5, 0, 10],
  [0, 0, 3, 0],
  [0, 0, 0, 1],
  [0, 0, 0, 0],
]

console.log(floyd(matrix))
