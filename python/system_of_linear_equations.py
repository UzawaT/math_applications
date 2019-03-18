import numpy
import numpy.matlib

#ask the user for number of variables
n = int(input("Enter number of variables: "))
l_side = numpy.matlib.zeros((n, n))
r_side = numpy.matlib.zeros((n, 1))

#ask the user to enter values for the left side of the equation
print("Enter values for left side")
for row in range(0, n):
    for col in range(0, n):
        l_side[row, col] = float(input("Enter value for row " + str(row + 1) + " column " + str(col + 1) + ": "))

#show left side
print(l_side)

#ask the user to enter values for the right side of the equation
print("Enter the values for right side")
for row in range(0, n):
    r_side[row, 0] = float(input("Enter value for row " + str(row + 1) + ": " ))

#show right side
print(r_side)

#solve the equation
result = numpy.linalg.solve(l_side, r_side)

#show answer
print("Answer")
print(result)