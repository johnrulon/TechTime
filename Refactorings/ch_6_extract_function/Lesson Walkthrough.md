# Steps for walking others through these examples

## Refactorings covered by Dice Roll and Levenshtein Distance
### Extract Function
- Replace comment with function
- Replace repeated code with function
- VS Code's "Refactor" tools
- Name functions based on _what_ they do, not _how_

### Slide Statements

### Split Variable

### Extract Variable
- If there's not a lot of logic to abstract into a method, consider introducing a variable
### Rename Variable
- Rename variable to better describe what the variable contains

### Pull up field
- Moving a field "up" from a sub-class to a parent class or a method to a class

## Key takeaways
We spend the majority of our time reading code versus writing code. Therefore, prefer readability over condensed or "cool" code. 

Self-documenting code, that abstracts complexity into functions that have a single and focused reponsibility, will help with readability.

From Martin Fowler's Refactorings book:
>If you have to spend effort looking at a fragment of code and figuring out _what_ it's doing, then you should extract it into a function and name the function after the _what_. ... Name it by _what_ it does, not by _how_ it does it.

> Small functions only work if the names are good, so you need to pay good attention to naming. This takes practice—but once you get good at it, this approach can make code remarkably self-documenting.

> To me, any function with more than half-a-dozen lines of code starts to smell, and it's not unusual for me to have functions that are a single line of code.

This session today will cover some refactoring patterns from Martin Fowler's book: `Refactoring - Improving the design of existing code`. These patterns are most likely ones you already follow, but knowing them, being able to identify when you're following them, can help assert you're making a worthwhile refactor. 

We'll cover a few refactorings, but knowing that with each example, other refactorings are possible and not every refactor I'll show is what I'd considered a good change.

## Die Roll Example
With Die Roll, we introduce a simple 'Extract function' refactoring.

#### Steps:
- Open the file `die_roll_before` and briefly walk them through the code
- Explain that `Repeated code` is the hint to extract a function
- The repeated code being the calls to `random.randint()`
- Explain that we want to Extract a function that will generate a random number given a range
    - Code: `@classmethod
            def get_random_number_from_range(min_number, max_number) -> int:
                return random.randint(min_number, max_number)`
    - New Code in main method: `rolled_number = self.get_random_number_from_range(1, num_sides_of_die)
        print(f'Number rolled was: {rolled_number}')`
- Show the `die_roll_after` code side by side with old so everyone can see the refactor
- Ask, "What benefits do we gain from extracting this function?"
    - Answer: this code can now roll any number sided die
    - In the previous code we limited ourselves to 3 numbers because of our "switch" statement for 6, 8, or 12 sided die
    - This could actually be good OR bad
        - Given business rules, maybe we don't want to allow rolling oddly shaped dies - maybe only allowing even sided die was a concious decision and we just broke the business rules
- Closed die_roll files

## Levenshtein Distance Example
With Levenshtein Distance, we again use 'Extract function' to start things out.

#### Steps:
- Open the file `lev_distance_before` and briefly walk them through the code
    - Ask, "Is this code self-documenting code?"
        - Answer: no, because it requires comments to make the code quickly readable (I know that can be subjective)
            - And sure, some of you could argure it's simple enough to "easily" read, but self-documenting code is code that doesn't require you to interpret the _LOGIC_ of the code, and is simple enough for most developers to follow
    - Explain that `comments` are the hint or the pattern we can see that informs us that we may want to extract a function, to extract the code into a function that is named in a way to replace the comment
- Select all the code from line 21 - 29 (the code under that first in-line comment)
    - Right click -> Refactor: shortcut is dependent upon whether you're using MacOS or Windows, but clicking Refactor gives us a hint to "Extract method"
    - Click "Extract Method"
    - Suggest that we use the comment as input to the name of the new method
        - So for this example, something like `get_len_diff_and_max_len`
    - Explain that perhaps this isn't the best outcome - to have two return values from a method
- Refactor next section of code (the first `for i range...` through the first `distance = 0`)
    - Call the method: `add_distance_of_words_in_order`
    - Talk through how maybe this refactor isn't the best result
        - We instantiate `distance` to zero on Line 18, pass it into this method, use it in our for loop, and then reset it back to 0 just so we can return a 0 for the next for loop to use
        - Poor outcome, so let's undo that refactor and look for other refactors we can do prior to make this extract function have a better result 
- Undo the Refactor
- As we look at the code we want to extract, we notice that distance is used by each for loop in a way that it is "local" to those for loops, but our code is not written in that way
    - That hint could lead us to other Refactorings called: Slide Statement and Split Variable
        - They're exactly what they sound like: "slide" a statement up or down in code, and "split" a variable in two
        - So, looking at the code we're trying to refactor, let's introduce a more "local" variable to our for loop
        - Let's "slide" `distance` to the top of our for loop we're trying to extract (line 24)
        - Recognize that we also would need to "split" `distance` or else it will "live" outside of the scope that we really need it to live (which is just the scope of this single for loop)
        - So let's split `distance` variable into two, creating a new one called `temp_distance`
            - We'll then update `distance += 1` to use `temp_distance` instead, and also update the append statement to use `temp_distance`
            - We can also remove that reset of `distance = 0` following the append statement
    - By doing a couple smaller Refactorings first, we made it easier to now perform the overall Refactoring that we wanted to Extract function"
        - Perform the "Extract function" 
    - Note: we have now set up the next Refactor - the next for loop
- Refactor the last commented section
    - "Slide" `distance` closer to the code where it's needed
    - Rename `distance` to `temp_distance`
    - Refactor: call the method: `add_distance_of_reverse_order`
- Now review the overall code in the main method
    - Remember, the pattern we noticed of comments, and our goal to "Replace comment with function"
    - Let's remove the comments and see how it reads
    - Notice that perhaps the return might not be considered as self-documenting! 
        - Refactor that return statement by selecting `len_diff + min(distances)`
        - Notice the "Extract Variable" option: perform that action
            - Name the variable something descriptive like `calculated_distance_between_words`
        - With that change, I'd argue that the logic to calculate the distance is now abstracted away and, by performing this "Extract variable" refactoring, the code is now self-documenting

### Concluding thoughts
Going through that set of refactorings we see that our code is a bit more self-documenting.

One could argue however, there are other improvements that could be made:
- For example: in reading the code now, I don't know for certain "to what" our `add_distance...` methods are adding to
    - It's not obvious it's adding to our distances array
    - That refactor would include:
        - Changes `add_distance...` methods to return distance instead of adding it to an array
        - Move the `distances.append()` code back to the main method
        - Rename the methods to `calc` or `get` instead of `add` to indicate they are only calculating the distance, not storing/adding it
    - See `lev_distance_after_2.py` for this additional refactor
- We could also perform a "Pull up variable" Refactoring to make `distances` array, `word1`, `word2`, `len_diff`, and `max_len`  class members
    - If that's what I wanted or needed from my code, great


 Either way, these extra potential refactorings or not, the process led us to at least slightly better 'self-documenting' code and was a good excercise nonetheless...hopefully at least :) 

 # Challenge
In code bases you work with frequently, find an example where the code could benefit from the `Extract function` refactoring.

Look for hints of either comments that can be replaced by a self-documenting method OR repeated code to extract into a shared, reusable function.


