from math import exp, expm1
# from typing import Dict, Any
import numpy as np



class NumericalDifferentiation:

    def __init__(self, func, interval, step):
        self.func = func
        self.interval = interval
        self.step = step

    def differentiate_forward(self):
        derivatives = {}  # type: Dict[float, float]

        for x in np.arange(interval[0], interval[1] + step, step):
            derivatives[x] = (func(x + step) - func(x)) / step
        return derivatives

    def differentiate_forward_backward(self):
        derivatives = {}

        for x in np.arange(interval[0], interval[1] + step, step):
            derivatives[x] = (func(x + step) - func(x - step)) / 2 / step
        return derivatives


    def calculate_error(self, expected, observed):
        if len(expected) != len(observed):
            raise ValueError("Argument exception")
        errors = []
        for i in range(0, len(expected)):
            errors.append(expected[i] - observed[i])
        return errors


    def calculate_function(self, func):
        values = {}

        for x in np.arange(interval[0], interval[1] + NumericalDifferentiation.step, NumericalDifferentiation.step):
            values[x] = func(x)
        return values


def func(x):
    return exp(3 * x)


def func_first_derivatve(x):
    return 3 * exp(3 * x)


def func_second_derivative(x):
    return 9 * exp(3 * x)


# differentiaion = NumericalDifferentiation(func, (0, 1), 0.1)
#
# derivatives = differentiaion.calculate_function(func_first_derivatve)
# approximate_derivates1 = differentiaion.differentiate_forward()
# approximate_derivates2 = differentiaion.differentiate_forward_backward()
# errors1 = differentiaion.calculate_error(list(derivatives.values()), list(approximate_derivates1.values()))
# errors2 = differentiaion.calculate_error(list(derivatives.values()), list(approximate_derivates2.values()))
#
# print(derivatives)
# print(approximate_derivates1)
# print(errors1)
# print(approximate_derivates2)
# print(errors2)

print(differentiaion.step)