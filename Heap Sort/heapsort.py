import random

max_length = 1000
max_value = 100000

def checkrep(l):
    to_return = True
    for i in range(0, len(l)):
        if len(l) > (i * 2 + 1) and l[i*2 + 1] > l[i]:
            to_return = False
            break
        if len(l) > (i * 2 + 2) and l[i*2 + 2] > l[i]:
            to_return = False
            break
    return to_return

def genSequence():
    to_return = []
    length = random.randint(1, max_length+1)
    for i in range(length):
        to_return.append(random.randint(0, max_value+1))
    return to_return

def heapSort(l):
    for i in range(len(l)):
        siftup(l, len(l) - i - 1)
        siftdown(l, len(l) - i - 1)
        

def siftup(l, index):
    while index > 0 and l[index] > l[(index - 1)/2]:
        tmp = l[(index - 1)/2]
        l[(index - 1)/2] = l[index]
        l[index] = tmp
        index = (index-1)/2

def siftdown(l, index):
    while ((index*2 + 1) < len(l) and l[index] < l[index*2 + 1]) or ((index*2 + 2) < len(l) and l[index] < l[index*2 + 2]):
        if (index*2 + 2) < len(l) and l[index] < l[index*2+2]:
            if l[index*2 + 2] > l[index*2 + 1]:
                toswitch = index*2 + 2
            else:
                toswitch = index*2 + 1
            tmp = l[toswitch]
            l[toswitch] = l[index]
            l[index] = tmp
            index = toswitch
        elif l[index] < l[index*2 + 1]:
            tmp = l[index*2 + 1]
            l[index*2+1] = l[index]
            l[index] = tmp
            index = index*2 + 1

print "How many simulations would you like to run: "
entered = False

while not entered:
    try:
        num_runs = int(raw_input())
        entered = True
    except:
        print "Please enter an integer representing the number of simulations you want to run: "

failed = 0		

for i in range(num_runs):
    print "Run #" + str(i)
    to_sort = genSequence()
    #print to_sort
    heapSort(to_sort)
    #print to_sort
    worked = checkrep(to_sort)
    print "Simulation Passed: " + str(worked)
    if not worked:
        failed += 1

print "Failed Simulations: " + str(failed)