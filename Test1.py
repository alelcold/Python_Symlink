#!/usr/bin/python
# -*- coding: UTF-8 -*-

import os, sys
from os import walk
from pathlib import Path # 路徑
import re  # 正規
import shutil  # 判斷目錄
import pprint

cwd = os.getcwd()
print(cwd)

src = cwd + '/Test1.py'
dst = cwd + '/test1Link'
csDir = cwd + '/CsDir'
LinkDir = cwd + '/LinkDir'
mypath = Path(cwd + '/LinkDir')
if(mypath.exists()):
    for fileName in os.listdir(mypath): 
        print(fileName)  
        if(os.path.islink(LinkDir+'/'+fileName)):
            os.remove(LinkDir+'/'+fileName)
    print('======' + '/LinkDir is exists , Clear')
else:
    print('======' + '/LinkDir is Null')
    os.makedirs(cwd + '//LinkDir')

# if(Path(dst).exists()):
#     print(mypath + '//DestDir is exists')
# else:
#     os.symlink(mypath, dst)   
# 创建软链接
#os.symlink(src, dst)
# for fileName in os.listdir(csDir):
#     print(fileName)
# 创建的目录
#os.mkdir( path, 0755 );
#刪除所有LsybolicLink
# for root, dirs, files in walk(csDir):
#     print('路徑', root)
#     print('Dir', dirs)
#     print('file', files)
    
    # extension = os.path.splitext(root+'/'+fil)
    # print(extension)

for fileName in os.listdir(csDir):
    extension = os.path.splitext(csDir+'/'+fileName)
    #print(extension[0])
    #print(extension[1])
    # if(extension[1] == '.cs'):
    #     print(fileName + ' is cs')
    os.symlink(csDir+'/'+fileName, LinkDir+'/'+fileName)    
    # if(os.path.islink(cwd+'/'+fileName)):
    #     os.remove(cwd+'/'+fileName)
    # else:
    #     print(fileName)
        


#print ""