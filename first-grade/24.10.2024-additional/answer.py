n = int(input('Введите количество фирм: '))
min_price_milk = 999999999999
fabrika = 0
for i in range(n):
    x1, x2, x3, y1, y2, y3, c1, c2 = list(map(float, input().split()))
    V1 = x1 * x2 * x3
    V2 = y1 * y2 * y3
    S1 = 2*(x1*x2 + x1*x3 + x2*x3)
    S2 = 2*(y1*y2 + y1*y3 + y2*y3)

    price_milk = (-c1 + (S1*c2)/S2)/(-((V1-S1)/1000) + (S1*((V2-S2)/1000))/S2)
    if min_price_milk > price_milk:
        min_price_milk = price_milk
        fabrika = i+1
print(fabrika, round(min_price_milk, 2))
