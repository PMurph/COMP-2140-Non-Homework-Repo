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

def insertion_sort(seq):
	for i in range(1,len(seq)):
		tmp = seq[i]
		index = i
		while index > 0 and seq[index-1] > tmp:
			seq[index] = seq[index-1]
			index -= 1
		seq[index] = tmp

def selection_sort(seq):
	for i in range(len(seq)):
		lowest = i
		for j in range(i, len(seq)):
			if seq[j] < seq[lowest]:
				lowest = j
		tmp = seq[i]
		seq[i] = seq[lowest]
		seq[lowest] = tmp

def quick_sort(seq):
	quick_sort_rec(seq, len(seq)-1, 0)
		
def quick_sort_rec(seq, max_v, min_v):
	if max_v > min_v:
		pivot = random.randint(min_v, max_v)
		tmp = seq[pivot]
		seq[pivot] = seq[min_v]
		seq[min_v] = tmp
		pivot = min_v
		small = min_v + 1
		big = min_v + 1
		for i in range(min_v+1, max_v+1):
			if seq[i] <= seq[pivot]:
				tmp = seq[big]
				seq[big] = seq[i]
				seq[i] = tmp
				big += 1
		tmp = seq[pivot]
		seq[pivot] = seq[big-1]
		seq[big-1] = tmp
		pivot = big - 1
		small -= 1
		quick_sort_rec(seq, pivot - 1, small)
		quick_sort_rec(seq, max_v, big)

def merge_sort(seq):
	merge_sort_rec(seq, 0, len(seq), [])
	
def merge_sort_rec(seq, min_v, max_v, tmp):
	if max_v > min_v + 1:
		mid_v = (max_v - min_v) / 2 + min_v
		merge_sort_rec(seq, min_v, mid_v, tmp)
		merge_sort_rec(seq, mid_v, max_v, tmp)
		merge(seq, min_v, mid_v, max_v, tmp)
		
def merge(seq, min_v, mid_v, max_v, tmp):
	curr_l = min_v
	curr_r = mid_v
	curr_t = min_v
	tmp = [ i for i in seq ]
	while curr_l < mid_v or curr_r < max_v:
		if seq[curr_l] <= seq[curr_r]:
			tmp[curr_t] = seq[curr_l]
			curr_l += 1
		else:
			tmp[curr_t] = seq[curr_r]
			curr_r += 1
		curr_t += 1
	if curr_l < mid_v:
		while curr_l < mid_v:
			tmp[curr_t] = seq[curr_l]
			curr_t += 1
			curr_l += 1
	elif curr_r < max_v:
		while curr_r < max_v:
			tmp[curr_t] = seq[curr_r]
			curr_t += 1
			curr_r += 1
	for i in range(max_v, len(seq)):
		tmp[i] = seq[i]
	seq = [ i for i in tmp ]
	

def generate_seq(max_v, min_v, length):
	to_return = []
	if max_v < min_v:
		tmp = max_v
		max_v = min_v
		min_v = tmp
	for i in range(length):
		to_return.append(random.randint(int(min_v), int(max_v)))
	return to_return