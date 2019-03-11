import datetime
import time
import vk
import os

search_page = '-1' #Страница для поиска
find_id = 1#Чьи записи ищем
access_token = ''
first_post = 0 #С какой записи начинаем
last_post = 6000 #С какой записи заканчиваем

api = vk.API(vk.Session(access_token))
name = api.users.get(user_ids=find_id)
name_dir = name[0]['first_name']+' '+name[0]['last_name']
if not os.path.exists('wall'): os.mkdir('wall')
if not os.path.exists('wall/'+name_dir): os.mkdir('wall/'+name_dir)

while first_post < last_post:
    s = api.wall.get(owner_id=search_page, offset=first_post, count=100)
    i = 1
    while i < len(s):

        if 'signer_id' in s[i]:
            parse_id = s[i]['signer_id']
        else:
            if 'from_id' in s[i]:
                parse_id = s[i]['from_id']
            else:
                parse_id = '0'
        if (parse_id == find_id):
            print("Что-то найдено, сохраняем")
            log = open('./wall/' + name_dir + '/post' + str(s[i]['id']) + '.txt', "a", encoding='utf8')
            link = 'https://vk.com/wall' + str(search_page) + '_' + str(s[i]['id'])
            time_stamp = datetime.datetime.fromtimestamp(int(s[i]['date'])).strftime('%d-%m-%Y %H:%M')
            log.write(time_stamp + ' ' + s[i]['text'] + '\n' + link+'\n')
            log.close()
        i = i + 1
    time.sleep(0.5)
    first_post = first_post + 100
    print('Записи: ' + str(first_post) + ' из ' + str(last_post))
    time.sleep(0.3)