for num in range(100,999):
    sum = 0
    temp = num
    while temp > 0:
       digit = temp % 10
       sum += digit ** 3
       temp //= 10
       if num == sum:
           print(num)
