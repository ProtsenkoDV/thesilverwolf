import bs4, re
res = open('./bill.html',encoding='utf-8')
result = open('bill.csv',"w")
bill = bs4.BeautifulSoup(res,"html.parser")
allNum = bill.select("table")
fileArray = ["Абонент;Услуга;Количество;Сумма\n"]
for num in allNum:
    pattern = re.compile(r's(\d){2}-([A-Z0-9]){32}')
    numpatt = re.compile(r'(\d){11}')
    items = num.findAll('td',{'class': pattern})
    if len(items)>15:
        for i in range(15,len(items)-3,3):
            abonent = numpatt.search(items[9].getText())
            if type(abonent) != type(None):
                row = abonent[0]+";"+items[i].getText()+";"+items[i+1].getText()+";"+items[i+2].getText()+"\n"
                fileArray.append(row)

for ab in fileArray:
    result.write(ab)
result.close()