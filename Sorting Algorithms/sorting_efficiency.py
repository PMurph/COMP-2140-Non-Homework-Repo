#Sorting algorithms for integers in pytong
import random
import time

def run_time(fnc, *args):
	init_time = time.clock()
	fnc(*args)
	print time.clock() - init_time

def bubble_sort(seq):
	for i in range(len(seq)):
		for j in range(len(seq)-i-1):
			if seq[j] > seq[j + 1]:
				tmp = seq[j]
				seq[j] = seq[j+1]
				seq[j+1] = tmp

def generate_seq(max_v, min_v, length):
	to_return = []
	if max_v < min_v:
		tmp = max_v
		max_v = min_v
		min_v = tmp
	for i in range(length):
		to_return.append(random.randint(int(min_v), int(max_v)))
	return to_return