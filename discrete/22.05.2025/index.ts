function fordFulkerson(graph: number[][], s: number, t: number) {
  let n = graph.length + 1
  const newGraph: number[][] = Array.from({ length: n }, (_, i) => [
    ...graph[i],
  ])

  const parent: number[] = new Array(n)

  let maxFlow = 0

  const bfs = (): boolean => {
    const visited: boolean[] = new Array(n).fill(false)
    const queue: number[] = [s]

    visited[s] = true

    while (queue.length > 0) {
      const u = queue.shift()!

      for (let v = 0; v < n; v++) {
        if (!visited[v] && newGraph[u][v] > 0) {
          visited[v] = true
          parent[v] = u
          queue.push(v)

          if (v === t) return true
        }
      }
    }

    return false
  }

  while (bfs()) {
    let flow = Infinity
    let v = t

    while (v !== s) {
      const u = parent[v]
      flow = Math.min(flow, newGraph[u][v])
      v = parent[v]
    }

    v = t
    while (v !== s) {
      const u = parent[v]
      newGraph[u][v] -= flow
      newGraph[v][u] += flow
      v = parent[v]
    }

    maxFlow += flow
  }

  console.log('Максимальный поток: ', maxFlow)
}
