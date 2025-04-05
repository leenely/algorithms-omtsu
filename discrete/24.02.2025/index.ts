const tests = [
  {
    matrix: [
      [0, 0],
      [0, 0],
    ],
    expectedAnswer: [],
  },
  {
    matrix: [
      [0, 1],
      [1, 0],
    ],
    expectedAnswer: [[0, 1]],
  },
  {
    matrix: [
      [0, 1, 0],
      [1, 0, 1],
      [0, 1, 0],
    ],
    expectedAnswer: [
      [0, 1],
      [1, 2],
    ],
  },
  {
    matrix: [
      [0, 0, 0],
      [0, 0, 0],
      [0, 0, 0],
    ],
    expectedAnswer: [],
  },
  {
    matrix: [
      [0, 1, 1, 0, 0, 0, 0],
      [1, 0, 0, 1, 0, 0, 0],
      [1, 0, 0, 1, 0, 0, 0],
      [0, 1, 1, 0, 1, 0, 0],
      [0, 0, 0, 1, 0, 1, 1],
      [0, 0, 0, 0, 1, 0, 0],
      [0, 0, 0, 0, 1, 0, 0],
    ],
    expectedAnswer: [
      [3, 4],
      [4, 5],
      [4, 6],
    ],
  },
]

function countComponents(matrix): number {
  const visited = new Set<number>()
  let componentCount = 0

  const dfs = (node: number) => {
    visited.add(node)
    for (let neighbor = 0; neighbor < matrix[node].length; neighbor++) {
      if (matrix[node][neighbor] === 1 && !visited.has(neighbor)) {
        dfs(neighbor)
      }
    }
  }

  for (let i = 0; i < matrix.length; i++) {
    if (!visited.has(i)) {
      dfs(i)
      componentCount++
    }
  }

  return componentCount
}

function findBridges(matrix) {
  const bridges = []
  const n = matrix.length

  for (let u = 0; u < n; u++) {
    for (let v = u + 1; v < n; v++) {
      if (matrix[u][v] === 1) {
        // Удаляем ребро
        matrix[u][v] = 0
        matrix[v][u] = 0

        const componentCount = countComponents(matrix)
        if (componentCount > 1) {
          bridges.push([u, v])
        }

        // Восстанавливаем ребро
        matrix[u][v] = 1
        matrix[v][u] = 1
      }
    }
  }

  return bridges
}

// Тесты

function compareArrays(arr1: any[], arr2: any[]): boolean {
  if (arr1.length !== arr2.length) return false

  for (let i = 0; i < arr1.length; i++) {
    const elem1 = arr1[i]
    const elem2 = arr2[i]

    if (Array.isArray(elem1) && Array.isArray(elem2)) {
      if (!compareArrays(elem1, elem2)) return false
    } else if (Array.isArray(elem1) || Array.isArray(elem2)) {
      return false
    } else if (elem1 !== elem2) {
      return false
    }
  }

  return true
}

for (const test of tests) {
  let result = findBridges(test.matrix)
  compareArrays(result, test.expectedAnswer)
    ? console.log(`Тест пройден`)
    : console.log(
        `Тест не пройден (Ожидаемый ответ: ${test.expectedAnswer}. Результат: ${result})`
      )
}
