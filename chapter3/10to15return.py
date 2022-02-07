def sum(x, y):
    sum = x + y
    if sum in range(15, 20):
        return 20
    else:
        return sum
print(sum(10, 6))
print(sum(10, 2))
print(sum(10, 12))
