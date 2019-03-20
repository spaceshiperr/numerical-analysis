import numpy as np

# Solve linear equations

a = np.array([[-401.46, 200.18], [201.08, -601.64]])
b1 = np.array([200, -600])
b2 = np.array([199, -601])

x1 = np.linalg.solve(a, b1)
x2 = np.linalg.solve(a, b2)

print('x1:', x1)
print('x2:', x2)

# Compute the condition number of a matrix

a_inv = np.linalg.inv(a)
a_norm = np.linalg.norm(a_inv)
a_inv_norm = np.linalg.norm(a)
cond = a_inv_norm * a_norm

print('cond:', cond)

# Relative Error

delta_x = np.linalg.norm(x2 - x1) / np.linalg.norm(x1)

print('delta_x:', delta_x)

# https://docs.scipy.org/doc/numpy/reference/routines.linalg.html