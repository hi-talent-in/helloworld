def chars_mix_up(a, b):
  new_a = b[:2] + a[2]
  new_b = a[:2] + b[2]

  return new_a + ' ' + new_b
print(chars_mix_up('abc', 'xyz'))




def change_char(str1):
  char = str1[0]
  str1 = str1.replace(char, '$')
  str1 = char + str1[1:]

  
  return str1

print(change_char('restart'))
