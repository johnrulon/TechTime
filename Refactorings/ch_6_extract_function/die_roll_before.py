import random


class DieRoll:

    @classmethod
    def roll_a_sided_die(self, num_sides_of_die):
        """
        Roll a 6, 8, or 12 sided die
        """
        rolled_number = 0

        if num_sides_of_die == 6:
            rolled_number = random.randint(1, 6)
        elif num_sides_of_die == 8:
            rolled_number = random.randint(1, 8)
        elif num_sides_of_die == 12:
            rolled_number = random.randint(1, 12)
        else:
            print('Must choose a sided die of 6, 8, or 12')

        print(f'Number rolled was: {rolled_number}')


"""
Design type: Refactoring
Design Pattern: Extract function

Notes: Repeated code is the hint to extract a function
"""
