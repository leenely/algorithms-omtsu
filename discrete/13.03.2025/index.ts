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
  const n = matrix.length
  const distance = matrix.map(row => [...row])

  for (let i = 0; i < n; i++) {
    for (let j = 0; j < n; j++) {
      for (let k = 0; k < n; k++) {
        let nowDistance = distance[j][i] + distance[i][k]

        if (nowDistance < distance[j][k]) {
          distance[j][k] = nowDistance
        }
      }
    }
  }
  return distance
}

let matrix = [
	[0, 5, 0, 10],
	[0, 0, 3, 0],
	[0, 0, 0, 1],
	[0, 0, 0, 0]
]

console.log(floyd(sortedMatrix(matrix)));