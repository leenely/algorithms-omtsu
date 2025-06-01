function workWithMatrix(matrix: number[][]) {
    const n = matrix.length;
    let cost = 0;
    const newMatrix = matrix.map(row => [...row]);

    for (let i = 0; i < n; i++) {
        const finiteValues = newMatrix[i].filter(v => isFinite(v));
        if (finiteValues.length === 0) continue;

        const minRow = Math.min(...finiteValues);
        if (minRow > 0) {
            for (let j = 0; j < n; j++) {
                if (isFinite(newMatrix[i][j])) {
                    newMatrix[i][j] -= minRow;
                }
            }
            cost += minRow;
        }
    }

    for (let j = 0; j < n; j++) {
        let minCol = Infinity;
        for (let i = 0; i < n; i++) {
            if (isFinite(newMatrix[i][j]) && newMatrix[i][j] < minCol) {
                minCol = newMatrix[i][j];
            }
        }
        if (!isFinite(minCol) || minCol === 0) continue;

        for (let i = 0; i < n; i++) {
            if (isFinite(newMatrix[i][j])) {
                newMatrix[i][j] -= minCol;
            }
        }
        cost += minCol;
    }
    return [newMatrix, cost];
}

function findZeroPenalty(matrix: number[][]) {
    const n = matrix.length;
    let maxPenalty = -Infinity;
    let x = -1, y = -1;

    for (let i = 0; i < n; i++) {
        for (let j = 0; j < n; j++) {
            if (matrix[i][j] === 0) {
                let rowMin = Infinity;
                for (let k = 0; k < n; k++) {
                    if (k !== j && isFinite(matrix[i][k])) {
                        rowMin = Math.min(rowMin, matrix[i][k]);
                    }
                }

                let colMin = Infinity;
                for (let k = 0; k < n; k++) {
                    if (k !== i && isFinite(matrix[k][j])) {
                        colMin = Math.min(colMin, matrix[k][j]);
                    }
                }

                const penalty = (isFinite(rowMin) ? rowMin : 0) + (isFinite(colMin) ? colMin : 0);
                if (penalty > maxPenalty) {
                    maxPenalty = penalty;
                    x = i;
                    y = j;
                }
            }
        }
    }
    return [x, y, maxPenalty];
}

function littleTSP(matrix: number[][]): number {
    const n = matrix.length;
    let bestCost = Infinity;

    const stack: { mat: number[][]; b: number; level: number }[] = [];

    const [initMatrix, initBound] = workWithMatrix(matrix);
    stack.push({ mat: initMatrix, b: initBound, level: 0 });

    while (stack.length > 0) {
        const { mat, b, level } = stack.pop()!;

        if (level === n - 1) {
            bestCost = Math.min(bestCost, b);
            continue;
        }

        const [i, j, penalty] = findZeroPenalty(mat);

        if (i === -1 || j === -1) {
            continue;
        }

        const includeMatrix = mat.map(row => [...row]);
        const currentN = includeMatrix.length;
        for (let k = 0; k < currentN; k++) {
            includeMatrix[i][k] = Infinity;
            includeMatrix[k][j] = Infinity;
        }
        includeMatrix[j][i] = Infinity;

        const [reduced1, addedCost1] = workWithMatrix(includeMatrix);
        const newBound1 = b + addedCost1;

        if (newBound1 < bestCost) {
            stack.push({ mat: reduced1, b: newBound1, level: level + 1 });
        }
    }
    return bestCost;
}


const costMatrix = [
    [Infinity, 27, 43, 16, 30, 26],
    [7, Infinity, 16, 1, 30, 25],
    [20, 13, Infinity, 35, 5, 0],
    [21, 16, 25, Infinity, 18, 18],
    [12, 46, 27, 48, Infinity, 5],
    [23, 5, 5, 9, 5, Infinity]
]; // -> 63

console.log(littleTSP(costMatrix))

const graph = [
    [Infinity, 3, 5, 7],
    [3, Infinity, 6, 4],
    [5, 6, Infinity, 2],
    [7, 4, 2, Infinity]
];

console.log(littleTSP(graph)); // -> 12