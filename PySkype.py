
# -*- coding: utf-8 -*-
# """
# Created on Thu May  25 10:24:00 2021.

# @author: howardliu
# """
from skpy import Skype, SkypeChats


# 搜尋目的房間的 ID
def search_sk_id(sk, target_room):
    # 最後回傳的 SK ID
    re_id = ''
    # 分辨聊天室類型 --> 預設：-1 / 單人：0 / 群組：1
    room_type_check = 0

    skc = SkypeChats(sk)
    count =0
    for each_chat in skc.recent().values():
        count += 1
        print(count)
        room_type_check = 1
        room_name = getattr(each_chat, 'topic', 'no attr')
        re_id = getattr(each_chat, 'id', 'no id')

        if room_name == 'no attr':
            room_type_check = 0
            room_name = str(getattr(each_chat, 'user').name)  # 在這邊 get 到的 name 其實是 class，故要轉型
            re_id = getattr(each_chat, 'id')
        
        # test print code----------------------
        print(room_name, '  ', type(room_name))
        print(target_room, '  ', type(target_room))
        print(re_id)
        print(room_name == target_room)
        print('------------')
        # test print code----------------------

        if room_name == target_room:
            return re_id
        else:
            continue

    return 0


if __name__ == '__main__':
    # 本區塊用來進行測試使用，執行後 bot 會自動在 SK 群組中發布測試訊息
    id = ''
    pw = ''
    # 登入測試帳號
    sk = Skype(id, pw)

    # 建立 SK 物件
    skc = SkypeChats(sk)

    # 指定發送訊息的目的聊天室(可以是群組 or 個人)
    cht_name = "RD4 Bonuswinner"
    # cht_name = "Howard Liu"

    # 搜尋聊天室 ID
    target_id = search_sk_id(sk, cht_name)
    #print(f'target_id {target_id})
    # 聊天功能匯入「聊天室ID」
    
    ch = sk.chats[target_id]

    # 發送訊息測試 -- 文字、特殊字元、全形符號
    msg = ch.sendMsg(
        """【System Testing】\nThis is a test message from Autoscreenshot bot by Skype API......\n空格 空格 測試 測試\n特殊字元測試：~#$%^&?><{}[]()\n全形特殊字元測試：【】。，！""")

    # 發送測試訊息 -- 圖片
    # msg = ch.sendMsg("【圖片訊息上傳測試】")
    # with open(r"testing_img.png", "rb") as f:
    #     ch.sendFile(f, "testing_img.png", image=True)
    # 測試完成訊息
    msg = ch.sendMsg("Skype API testing success !")
#view rawsk_api_demo.py hosted with ❤ by GitHub