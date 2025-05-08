function findMaxEmptyRectangle(
  line1: string,
  line2: string,
  linesK: string[]
): number {
  const [N, M] = line1.split(' ').map(Number)
  const K = parseInt(line2)

  const grid: boolean[][] = Array.from({ length: M }, () =>
    Array(N).fill(false)
  )

  for (let i = 0; i < K; i++) {
    const [x, y] = linesK[i].split(' ').map(Number)
    if (y >= 1 && y <= M && x >= 1 && x <= N) {
      grid[y - 1][x - 1] = true
    }
  }

  let maxArea = 0

  for (let x_1 = 0; x_1 < N; x_1++) {
    for (let y_1 = 0; y_1 < M; y_1++) {
      for (let x_2 = x_1 + 1; x_2 <= N; x_2++) {
        for (let y_2 = y_1 + 1; y_2 <= M; y_2++) {
          let isRed = false

          for (let i = y_1; i < y_2; i++) {
            for (let j = x_1; j < x_2; j++) {
              if (grid[i][j]) {
                isRed = true
                break
              }
            }
            if (isRed) break
          }

          if (!isRed) {
            const area = (x_2 - x_1) * (y_2 - y_1)
            maxArea = Math.max(maxArea, area)
          }
        }
      }
    }
  }

  return maxArea
}
