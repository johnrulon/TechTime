import random


class DieRoll:

    @classmethod
    def roll_a_sided_die(cls, num_sides_of_die):
        """
        Roll a sided die
        """
        rolled_number = cls.get_random_number_from_range(1, num_sides_of_die)
        print(f'Number rolled was: {rolled_number}')

    @classmethod
    def get_random_number_from_range(cls, min_number, max_number) -> int:
        return random.randint(min_number, max_number)


"""
Design type: Refactoring
Design Pattern: Extract function

Notes: What benefits do we gain from extracting this function?
"""
