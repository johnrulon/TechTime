import random


class DieRollAfter:

    @classmethod
    def roll_a_sided_die(self, num_sides_of_die):
        """
        Roll a sided die
        """
        rolled_number = self.get_random_number_from_range(1, num_sides_of_die)
        print(f'Number rolled was: {rolled_number}')

    @classmethod
    def get_random_number_from_range(min_number, max_number) -> int:
        return random.randint(min_number, max_number)


"""
Design type: Refactoring
Design Pattern: Extract function

Notes: What other benefits do we gain from extracting this function?
"""
