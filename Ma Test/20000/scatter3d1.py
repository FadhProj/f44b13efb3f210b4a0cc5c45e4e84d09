#image_path = "Example4.png"

import Tkinter as tk
#import tkFileDialog
from mpl_toolkits.mplot3d import Axes3D
from matplotlib import pyplot

from PIL import Image
import numpy as np


def main():

    '''Tkinter.Tk().withdraw() # Close the root window
    in_path = tkFileDialog.askopenfilename()
    print in_path'''

    fig = pyplot.figure(figsize=(10,8))
    axis = fig.add_subplot(111, projection="3d") # 3D plot with scalar values in each axis

    im = Image.open("D:/fadhlan/f44b13efb3f210b4a0cc5c45e4e84d09/MyProgram/MyProgram/bin/Debug/Hasil/Jun. 12, 2018 0-26-46/1.1 StreamImage.png")
    #p,q=im.getdata(0).size
    
    '''for j in range(5):
        b.append([(i,j) for i in range(10)])
    print(b)'''
    
    img =[]
    w,h = im.size

    #for i in range(0,h):
    #    img.append([ im.getpixel((i,j))[0] for j in range(0,w)])
    for i in range(w):
        a=[]
        for j in range(h):
            a.append(im.getpixel((i,j))[0] - im.getpixel((i - (i % 3),j - (j % 3)))[0])
        img.append(a)
    w,h = len(img),len(img)
    print(len(img))
    
    img = np.array(img,dtype=object)
    print(img)
    
    #print list(im.getdata(1))
    

    #x= np.linspace(0,w,w).astype(int)
    #y= np.linspace(0,h,h).astype(int)
    #xv,yv = np.meshgrid(x,y)
    x=[]
    y=[]
    for i in range(w):
        x.append([j for j in range(w)])
    for i in range(h):
        y.append([i for j in range(h)])
    
    xv = np.array(x,dtype=object)
    yv = np.array(y,dtype=object)
    print(type(xv))
    print(xv)
    print(yv)
    print(xv.size,yv.size,img.size)
    #x, y, b = list(xv, xv, list(im.getdata(0)))
    
    axis.scatter(xv, yv, img, c="skyblue", marker="o",s=10)
    axis.set_xlabel("X")
    axis.set_ylabel("Y")
    axis.set_zlabel("Pixel Value")
    pyplot.show()
    pyplot.close()


main()










