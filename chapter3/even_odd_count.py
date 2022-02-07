list1=[2,3,64,30,98,2,24]
even = 0
odd = 0
for i in list1:
    if i%2==0:
        even+=1
    elif i%2==1:
        odd+=1
    else:
        print('sorry')

print('total even numbers are {} and odd numbers are {}'.format(even,odd))
