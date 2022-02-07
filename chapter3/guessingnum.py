print("***************Number guessing game************************")


import random
target_num,guess_num=random.randint(10,15),0
while target_num != guess_num:
    guess_num = int(input('Guess a number between 10 to 15 until you get it right : '))
print('Well Guessed')
