import vk
import time
from antigate import AntiGate
import requests

def getArrayFave(xtype,xcount):
    xoffset=0
    prexfaves=['Hello man!']
    xfaves=[]
    while len(prexfaves)!= 0:
        try:
            unit_to_multiplier = {
                'post': api.fave.getPosts(offset=xoffset, count=xcount),
                'photos': api.fave.getPhotos(offset=xoffset, count=xcount),
                'videos': api.fave.getVideos(offset=xoffset, count=xcount),
            }
            prexfaves = unit_to_multiplier[xtype]
            del(prexfaves[0])
            xfaves += prexfaves
            xoffset += xcount
            time.sleep(0.35)
        except vk.exceptions.VkAPIError as e:
            time.sleep(0.35)
            print(e)
    print(str(len(xfaves)) +" "+ str(xtype) +" like find")
    return xfaves

def deleteLike(xfaves,xtype):
    print('Deleting...')
    getOwner = {
        'post': 'to_id',
        'photo': 'owner_id',
        'video': 'owner_id',
    }
    getId = {
        'post': 'id',
        'photo': 'pid',
        'video': 'vid',
    }
    i = 0
    while i < len(xfaves):
        try:
            api.likes.delete(type=xtype, owner_id=str(xfaves[i][getOwner[xtype]]), item_id=xfaves[i][getId[xtype]])
            time.sleep(0.35)
            i += 1
        except vk.exceptions.VkAPIError as e:
            xcaptcha_sid = e.captcha_sid
            xcaptcha_img = e.captcha_img
            p = requests.get(xcaptcha_img)
            out = open("img.jpg", "wb")
            out.write(p.content)
            out.close()
            xcaptcha_text = str(AntiGate(' ', 'img.jpg')) #Ввести ключ антийгет
            try:
                api.likes.delete(type=xtype, owner_id=str(xfaves[i][getOwner[xtype]]), item_id=xfaves[i][getId[xtype]],
                                 captcha_sid=xcaptcha_sid, captcha_key=xcaptcha_text)
                print("Была решена капча: " + xcaptcha_text + ", все в порядке.")
            except vk.exceptions.VkAPIError as e:
                print("Что-то пошло не так, наверно уменьшил время ожидания?")
                i += 1
        except TypeError:
            print("Что-то пошло не так, типы поломались, пробуем перейти к другой закладке")
            i += 1

access_token = '' №Токен с правами на стену и друзей
session = vk.Session(access_token)
api = vk.API(session)

photoFaves = getArrayFave('photos',50)
if len(photoFaves) != 0:
    deleteLike(photoFaves,'photo')
    del(photoFaves)

postFaves = getArrayFave('post',100)
if len(postFaves) != 0:
    deleteLike(postFaves,'post')
    del(postFaves)

videoFaves = getArrayFave('videos',50)
if len(videoFaves) != 0:
    deleteLike(videoFaves,'video')
    del(videoFaves)