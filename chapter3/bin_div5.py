binary_num=input("Enter binary's :").split(',')
num = str()
for i in binary_num:
    decimal = int(i,2)
    if decimal%5==0:
        print(i ,',' ,end="")
