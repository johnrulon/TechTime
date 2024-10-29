class Before:

    @classmethod
    def levenshtein_distance(self, word1, word2):
        """
        Determine the Levenshtein Distance between two words
        """
        word1 = word1.lower()
        word2 = word2.lower()

        word1_len = len(word1)
        word2_len = len(word2)

        self.distances = []

        len_diff, max_len = self.get_diff_and_max_len(word1_len, word2_len)

        self.add_distance_of_words_in_order(word1, word2, len_diff, max_len)

        self.add_distance_of_reverese_order(word1, word2, len_diff, max_len)

        return self.determine_lev_distance(len_diff)

    @classmethod
    def determine_lev_distance(self, len_diff):
        return len_diff + min(self.distances)

    @classmethod
    def add_distance_of_words_in_order(self, word1, word2, len_diff, max_len):
        distance = 0

        for i in range(max_len - len_diff):
            if word1[i] != word2[i]:
                distance += 1

        self.distances.append(distance)

    @classmethod
    def add_distance_of_reverese_order(self, word1, word2, len_diff, max_len):
        distance = 0

        for i in range(max_len - len_diff):
            if word1[i] != word2[i]:
                distance += 1

        self.distances.append(distance)

    @classmethod
    def get_diff_and_max_len(self, first_word_length, second_word_length):
        if first_word_length > second_word_length:
            length_diff = first_word_length - second_word_length
            max_length = first_word_length
        elif first_word_length < second_word_length:
            length_diff = second_word_length - first_word_length
            max_length = second_word_length
        else:
            length_diff = 0
            max_length = first_word_length
        return length_diff, max_length


"""
Design type: Refactoring
Design Pattern: Extract function -> Replace comment with function

Notes: A comment is the hint to extract function

For comparing words in order and reverse order, the hint is also repeated code

For line 16: using VS Code's 'Extract method' refactoring option,
we replaced this comment with a method
and now have a self describing method name
For line 16: we could also 'Slide variable' up to be a class variable so the 
function doesn't have to return 2 items

For line 22: we could instead just simply 'extract variable' instead
of extracting a method
Using a new variable called "calculated_distance" is another way
to self document what the code is doing
"""
