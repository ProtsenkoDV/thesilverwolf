import numpy as np
import matplotlib.pyplot as plt
import math
import pylab
from mpl_toolkits.mplot3d import Axes3D
import copy

myArray = [[-3,2,3],[3,2,3],[1,2,-3],[1,2,-1],[-1,2,-1],[-1,2,-3],[-3,2,3]]
rotateArray = copy.deepcopy(myArray)
resizeArray = copy.deepcopy(myArray)
mirrorArray = copy.deepcopy(myArray)
changeArray = copy.deepcopy(myArray)

def getX(getArrayX):
    i = 0
    xarray = []
    while i < len(getArrayX):
        xarray.append(getArrayX[i][0])         
        i=i+1  
    return xarray
def getY(getArrayY):
    i = 0
    xarray = []
    while i < len(getArrayY):
        xarray.append(getArrayY[i][1])         
        i=i+1  
    return xarray
def getZ(getArrayZ):
    i = 0
    zarray = []
    while i < len(getArrayZ):
        zarray.append(getArrayZ[i][2])         
        i=i+1  
    return zarray

#Опишем функцию отрисовки 
def showPlot(newArray):
    fig = pylab.figure()
    axes = Axes3D(fig)
    axes.plot(getX(newArray),getY(newArray),getZ(newArray))
    pylab.show()

#Опишем функцию умножения матриц    
def AxB(fA,sA):
    i = 0
    nA = fA
    while i < len(fA):
        iS = 0
        while iS < len(nA[i]):
            nA[i][iS] =( fA[i][0]*sA[iS][0] ) + ( fA[i][1]*sA[iS][1] ) +( fA[i][2]*sA[iS][2])
            iS = iS + 1
        i = i + 1
    return nA

#Опишем матрицу поворота
grad = 75
matrixRotate = [[math.cos(math.radians(grad)),-math.sin(math.radians(grad)),0],[math.sin(math.radians(grad)),math.cos(math.radians(grad)),0],[0,0,1]]
#Опишем матрицу масштабирования
a = 2
b = 2
matrixResize = [[a,0,0],[0,b,0],[0,0,1]]
#Опишем матрицу отражения
matrixMirror = [[1,0,0],[0,-1,0],[0,0,1]]
#Опишем матрицу переноса
c = 2
d = 2
matrixMove = [[1,0,c],[0,1,d],[0,0,1]]

showPlot(myArray)
showPlot(AxB(copy.deepcopy(myArray),matrixRotate))
showPlot(AxB(copy.deepcopy(myArray),matrixResize))
showPlot(AxB(copy.deepcopy(myArray),matrixMirror))
showPlot(AxB(copy.deepcopy(myArray),matrixMove))