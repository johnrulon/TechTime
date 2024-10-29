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

        len_diff = 0
        distances = []
        distance = 0
        max_len = 0

        # compare lengths of each word to get the length_diff and max_length
        if word1_len > word2_len:
            len_diff = word1_len - word2_len
            max_len = word1_len
        elif word1_len < word2_len:
            len_diff = word2_len - word1_len
            max_len = word2_len
        else:
            len_diff = 0
            max_len = word1_len

        # compare the letters in each word in order
        for i in range(max_len - len_diff):
            if word1[i] != word2[i]:
                distance += 1

        # store the distance
        distances.append(distance)
        distance = 0

        # compare the letters in each word in reverse order
        for i in range(max_len - len_diff):
            if word1[-(i+1)] != word2[-(i+1)]:
                distance += 1

        # store the distance
        distances.append(distance)

        # return the calculated distance
        return len_diff + min(distances)


"""
Design type: Refactoring
Design Pattern: Extract function -> Replace comment with function

Notes: A comment is the hint to extract function

For comparing words in order and reverse order, the hint is repeated code
"""
