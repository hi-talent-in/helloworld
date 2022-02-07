lines = []
while True:
    l = input("=>")
    if l:
        lines.append(l.upper())
    else:
        break;

for l in lines:
    print(l)


