class Before:

    @classmethod
    def levenshtein_distance(cls, word1, word2):
        """
        Determine the Levenshtein Distance between two words
        """
        word1 = word1.lower()
        word2 = word2.lower()

        word1_len = len(word1)
        word2_len = len(word2)

        len_diff = 0
        max_len = 0

        distances = []

        len_diff, max_len = cls.set_len_diff_and_max_len(word1_len, word2_len)

        cls.add_distance_of_words_in_order(word1, word2, len_diff, max_len, distances)

        cls.add_distance_of_reverse_order(word1, word2, len_diff, max_len, distances)

        calculated_distance_between_words = len_diff + min(distances)
        return calculated_distance_between_words

    @classmethod
    def add_distance_of_reverse_order(cls, word1, word2, len_diff, max_len, distances):
        temp_distance = 0
        for i in range(max_len - len_diff):
            if word1[-(i+1)] != word2[-(i+1)]:
                temp_distance += 1

        distances.append(temp_distance)

    @classmethod
    def add_distance_of_words_in_order(cls, word1, word2, len_diff, max_len, distances):
        temp_distance = 0
        for i in range(max_len - len_diff):
            if word1[i] != word2[i]:
                temp_distance += 1

        distances.append(temp_distance)

    @classmethod
    def set_len_diff_and_max_len(cls, word1_len, word2_len):
        if word1_len > word2_len:
            len_diff = word1_len - word2_len
            max_len = word1_len
        elif word1_len < word2_len:
            len_diff = word2_len - word1_len
            max_len = word2_len
        else:
            len_diff = 0
            max_len = word1_len
        return len_diff, max_len


"""
Design type: Refactoring
Design Pattern: Extract function -> Replace comment with function

Notes: A comment is the hint to extract function
"""
