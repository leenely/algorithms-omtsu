const tests = [
  {
    matrix: [
      [0, 0],
      [0, 0],
    ],
    expectedAnswer: 2,
  },
  {
    matrix: [
      [0, 1, 0, 0],
      [1, 0, 0, 0],
      [0, 0, 0, 1],
      [0, 0, 1, 0],
    ],
    expectedAnswer: 2,
  },
  {
    matrix: [
      [0, 0, 0, 0],
      [0, 0, 0, 0],
      [0, 0, 0, 0],
      [0, 0, 0, 0],
    ],
    expectedAnswer: 4,
  },
  {
    matrix: [
      [0, 1, 1, 1],
      [1, 0, 1, 1],
      [1, 1, 0, 1],
      [1, 1, 1, 0],
    ],
    expectedAnswer: 1,
  },
]

function findComponents_1(matrix: number[][]) {
  const n = matrix.length
  let componentsCounter = 0
  let iteratedVertex: boolean[] = new Array(n).fill(false)

  // Обходим связанные вершины вглубь по рёбрам
  function visitComponent(vertex: number) {
    iteratedVertex[vertex] = true
    for (let j = 0; j < n; j++) {
      if (!iteratedVertex[j] && matrix[vertex][j] === 1) {
        visitComponent(j)
      }
    }
  }

  // Для каждой непосещенной вершины начинаем обход новой компоненты
  for (let i = 0; i < n; i++) {
    if (!iteratedVertex[i]) {
      componentsCounter++
      visitComponent(i)
    }
  }

  return componentsCounter
}

function findComponents_2(matrix: number[][]) {
  const n = matrix.length
  let componentsCounter = 0
  let iteratedVertex: boolean[] = new Array(n).fill(false)

  // Функция для проверки связи вершины с компонентой
  function isConnectedToComponent(vertex: number, componentVertices: number[]) {
    return componentVertices.some(v => matrix[vertex][v] === 1)
  }

  let currentComponent: number[] = []

  // Перебираем все вершины по порядку
  for (let i = 0; i < n; i++) {
    if (!iteratedVertex[i]) {
      if (
        currentComponent.length === 0 ||
        !isConnectedToComponent(i, currentComponent)
      ) {
        componentsCounter++
        currentComponent = []
      }
      currentComponent.push(i)
      iteratedVertex[i] = true
    }
  }

  return componentsCounter
}

// Тесты
for (const test of tests) {
  let result_1 = findComponents_1(test.matrix)
  result_1 == test.expectedAnswer
    ? console.log(`Тест 1 пройден`)
    : console.log(
        `Тест 1 не пройден (Ожидаемый ответ: ${test.expectedAnswer}. Результат: ${result_1})`
      )

  let result_2 = findComponents_2(test.matrix)
  result_2 == test.expectedAnswer
    ? console.log(`Тест 2 пройден`)
    : console.log(
        `Тест 2 не пройден (Ожидаемый ответ: ${test.expectedAnswer}. Результат: ${result_2})`
      )
}
