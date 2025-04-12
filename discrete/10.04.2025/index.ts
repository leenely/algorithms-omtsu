function workWithMatrix(matrix, cost) {
  let minSum = 0
  const rows = matrix.length
  const columns = matrix[0].length

  const workWithRows = matrix.map(row => {
    const minValue =
      Math.min(...row.filter(item => item !== Infinity)) ?? Infinity
    if (minValue < Infinity && minValue > 0) {
      minSum += minValue
      console.log("Строка:", minValue)
      return row.map(item => (item !== Infinity ? item - minValue : Infinity))
    }

    return row
  })

  const workWithColumns = workWithRows.map(row =>
    row.map((item, index) => {
      const column = workWithRows.map(row => row[index])
      console.log(column)
      const minValue = Math.min(...column.filter(item => item !== Infinity))

      if (minValue < Infinity && minValue > 0) {
        minSum += minValue
        return item !== Infinity ? item - minValue : Infinity
      }

      return item
    })
  )

  console.log(minSum)
  console.table(workWithColumns)
  return { newMatrix: workWithColumns, newCost: cost + minSum }
}

function findEdgeWithMaxZero(matrix) {
  const rows = matrix.length
  const columns = matrix[0].length

  let edge = { i: 0, j: 0, cost: -1 }

  for (let i = 0; i < rows; i++) {
    for (let j = 0; j < columns; j++) {
      if (matrix[i][j] === 0) {
        const rowCost = Math.min(
          ...matrix[i].filter((_, colIndex) => colIndex !== j)
        )
        const columnCost = Math.min(
          ...matrix.map(row => row[j]).filter((_, rowIndex) => rowIndex !== i)
        )

        const crossCost = rowCost + columnCost
        console.log(`Текущий 0: (${i}, ${j}) - ${crossCost}`)
        if (crossCost > edge.cost) {
          edge = { i, j, cost: crossCost }
        }
      }
    }
  }
  return edge
}

function little(matrix, path: number[], cost) {
  const n = matrix.length

  if (path.length === n - 1) {
    const start = path[0]
    const end = path[path.length - 1]
    if (matrix[end][start] !== Infinity) {
      return { path, cost: cost + matrix[end][start] }
    }
    return { path: [], cost: Infinity }
  }

  const { newMatrix, newCost } = workWithMatrix(matrix, cost)
  const edge = findEdgeWithMaxZero(newMatrix)
  console.log(`Выбранный 0: (${edge.i}, ${edge.j}) - ${edge.cost}`)

  // Проверка на путь
  if (edge.i === -1 || edge.j === -1) {
    return path
  }

  const updatedMatrix = newMatrix.map(row =>
    row.map((val, colIndex) => (colIndex === edge.j ? Infinity : val))
  )

  for (let i = 0; i < n; i++) {
    updatedMatrix[i][edge.j] = Infinity
    updatedMatrix[edge.i][i] = Infinity
  }

  console.log(`Стоимость: ${newCost}`)
  return little(updatedMatrix, [...path, edge.j], newCost)
}

const matrix = [
  [Infinity, 27, 43, 16, 30, 26],
  [7, Infinity, 16, 1, 30, 25],
  [20, 13, Infinity, 35, 5, 0],
  [21, 16, 25, Infinity, 18, 18],
  [12, 46, 27, 48, Infinity, 5],
  [23, 5, 5, 9, 5, Infinity],
]

// console.table(little(matrix, [], 0))

console.table(workWithMatrix(matrix, 0))
