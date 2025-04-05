function mazeDraw(maze) {
  let string = ''
  for (let i = 0; i < maze.length; i++) {
    for (let j = 0; j < maze[i].length; j++) {
      if (maze[i][j] == Infinity) {
        string += ' -- '
      } else {
        string += `${maze[i][j]} `
      }

      if (j == maze[i].length - 1) {
        string += '\n'
      }
    }
  }
  console.log(string)
}

function wave(maze: number[][], startPos: number[], endPos: number[]) {
  const colsN = maze[0].length
  const rowsN = maze.length
  const moveDirections = [
    [-1, 0],
    [0, -1],
    [1, 0],
    [0, 1],
  ]
  const distances = Array.from({ length: rowsN }, () =>
    Array(colsN).fill(Infinity)
  )

  if (
    startPos[0] < 0 ||
    startPos[0] >= rowsN ||
    startPos[1] < 0 ||
    startPos[1] >= colsN ||
    endPos[0] < 0 ||
    endPos[0] >= rowsN ||
    endPos[1] < 0 ||
    endPos[1] >= colsN
  ) {
    throw new Error('Начальная точка лежит за пределами поля')
  }

  if (
    maze[startPos[0]][startPos[1]] === -1 ||
    maze[endPos[0]][endPos[1]] === -1
  ) {
    throw new Error('Начальная точка лежит в стене')
  }

  distances[startPos[0]][startPos[1]] = 0 // Фиксирование стартовой позиции
  let findQueue: number[][] = []
  findQueue.push(startPos)

  while (findQueue.length > 0) {
    let pos = findQueue.shift()

    for (const [directionX, directionY] of moveDirections) {
      if (typeof pos === 'object') {
        let newX = pos[0] + directionX
        let newY = pos[1] + directionY

        if (newX < rowsN && newY < colsN && newX >= 0 && newY >= 0) {
          if (maze[newX][newY] == 0) {
            if (distances[newX][newY] === Infinity) {
              distances[newX][newY] = distances[pos[0]][pos[1]] + 1

              if (newX == endPos[0] && newY == endPos[1]) {
                break
              }

              findQueue.push([newX, newY])
            }
          }
        }
      }
    }
  }

  mazeDraw(distances)
}

const maze = [
  [0, -1, 0, 0, 0, -1, 0, 0, 0, -1, 0, 0],
  [0, -1, 0, -1, 0, -1, 0, -1, 0, -1, 0, 0],
  [0, 0, 0, -1, 0, 0, 0, -1, 0, -1, -1, 0],
  [-1, -1, 0, -1, -1, -1, 0, -1, 0, 0, 0, 0],
  [0, 0, 0, 0, 0, -1, 0, -1, -1, -1, -1, 0],
  [0, -1, -1, -1, 0, -1, 0, 0, 0, 0, -1, 0],
  [0, -1, 0, 0, 0, -1, -1, -1, -1, 0, -1, 0],
  [0, -1, 0, -1, -1, -1, 0, 0, 0, 0, 0, 0],
  [0, 0, 0, -1, 0, 0, 0, -1, -1, -1, 0, -1],
  [0, -1, -1, -1, 0, -1, 0, 0, 0, 0, 0, 0],
]

wave(maze, [0, 0], [9, 11])
