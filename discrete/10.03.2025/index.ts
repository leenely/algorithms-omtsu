function sortedMatrix(matrix: number[][]) {
  const newMatrix = matrix.map(row => {
    return row.map(el => {
      if (el === 0) return Infinity
      return el
    })
  })

  return newMatrix
}

function displayResult(distances: number[]) {
  console.log("Длина минимального пути из вершины в вершину:")

  for (let i = 0; i < distances.length; i++) {
    console.log(`${i + 1} -> ${i + 1}  -  ${distances[i]}`)
  }
}


function fordBellman(matrix: number[][], startPos: number) {
  matrix = sortedMatrix(matrix)
  const n = matrix.length

  const distances = Array(n).fill(Infinity)
  distances[startPos] = 0

  for (let i = 0; i < n - 1; i++) {
    for (let j = 0; j < n; j++) {
      for (let k = 0; k < n; k++) {
        let tempDistance = distances[j] + matrix[j][k]

        if (matrix[j][k] !== Infinity) {
          if (tempDistance < distances[k]) {
            distances[k] = tempDistance
          }
        }
      }
    }
  }

  return distances
}

let matrix = [
  [0, 1, 0, 0, 3],
  [0, 0, 8, 7, 1],
  [0, 0, 0, 1, -5],
  [0, 0, 2, 0, 0],
  [0, 0, 0, 4, 0],
]

displayResult(fordBellman(matrix, 0));
