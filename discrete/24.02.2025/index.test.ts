import { expect, test } from 'bun:test'
import { findBridges } from './index'

test('empty graph', () => {
	const emptyGraph = [
		[0, 0],
		[0, 0],
	]
	const bridges = findBridges(emptyGraph)
	expect(bridges).toEqual([[0, 1]])
})

test('graph with one edge', () => {
	const graphWithOneEdge = [
		[0, 1],
		[1, 0],
	]
	const bridges = findBridges(graphWithOneEdge)
	expect(bridges).toEqual([])
})

test('graph with three edges', () => {
	const graphWithTwoEdges = [
		[0, 1, 0],
		[1, 0, 1],
		[0, 1, 0],
	]
	const bridges = findBridges(graphWithTwoEdges)
	expect(bridges).toEqual([[0, 1], [1, 2], [2, 0]])
})

test('graph without edges', () => {
	const graphWithoutEdges = [
		[0, 0, 0],
		[0, 0, 0],
		[0, 0, 0],
	]
	const bridges = findBridges(graphWithoutEdges)
	expect(bridges).toEqual([])
})

test('where two graphs are connected', () => {
	const graphWithTwoComponents = [
		[0, 1, 1, 0, 0, 0, 0],
		[1, 0, 0, 1, 0, 0, 0],
		[1, 0, 0, 1, 0, 0, 0],
		[0, 1, 1, 0, 1, 0, 0],
		[0, 0, 0, 1, 0, 1, 1],
		[0, 0, 0, 0, 1, 0, 0],
		[0, 0, 0, 0, 1, 0, 0],
	]
	const bridges = findBridges(graphWithTwoComponents)
	expect(bridges).toEqual([[3, 4]])
})
