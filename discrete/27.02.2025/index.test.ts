import { expect, test } from 'bun:test'
import { Dijkstra } from './index'

test('Пустой граф', () => {
	const matrix = [
		[0, 0],
		[0, 0],
	]
	const result = Dijkstra(matrix, 1, 2)
	expect(result).toBe(-1)
})

test('Граф на трёх вершинах', () => {
	const matrix = [
		[0, 1, 4],
		[0, 0, 2],
		[1, 2, 0],
	]
	const result = Dijkstra(matrix, 1, 3)
	expect(result).toBe(3)
})

test('Граф на пяти вершинах', () => {
	const matrix = [
		[0, 23, 0, 45, 0],
		[0, 0, 7, 0, 57],
		[789, 0, 0, 0, 0],
		[0, 56, 0, 0, 65],
		[45, 0, 86, 908, 0],
	]
	const result = Dijkstra(matrix, 3, 5)
	expect(result).toBe(869)
})

test('Граф на шести вершинах', () => {
	const matrix = [
		[0, 5, 10, 13, 0, 0, 0],
		[0, 0, 8, 9, 13, 0],
		[0, 0, 0, 5, 3, 6],
		[0, 0, 0, 0, 8, 10],
		[0, 0, 0, 0, 0, 9],
		[0, 0, 0, 0, 0, 0],
	]
	const result = Dijkstra(matrix, 1, 6)
	expect(result).toBe(16)
})
