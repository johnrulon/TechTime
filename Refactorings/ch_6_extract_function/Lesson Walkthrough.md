# Steps for walking others through these examples

## Refactorings covered by Dice Roll and Levenshtein Distance
### Extract Function
- Replace comment with function
- Replace repeated code with function
- VS Code's "Refactor" tools
- Name functions based on _what_ they do, not _how_

### Pull up field
- Moving a field "up" from a sub-class to a parent class or a method to a class

### Replace inline code with function code

### Slide Statements

### Split Variable

### Extract Variable
- If there's not a lot of logic to abstract into a method, consider introducing a variable
### Rename Variable
- Rename variable to better describe what the variable contains

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
- Show the `die_roll_after` code and walk through the refactor that was done
- Ask, "What other benefits do we gain from extracting this function?"
    - Answer: this code can now roll any number sided die
    - In the previous code we limited ourselves to 3 numbers because of our "switch" statement for 6, 8, or 12 sided die
    - This could actually be good OR bad - maybe we don't want to allow rolling oddly shaped dies

## Levenshtein Distance Example
With Levenshtein Distance, we again use 'Extract function' to start things out.

#### Steps:
- Open the file `lev_distance_before` and briefly walk them through the code
    - Ask, "Is this code self-documenting code?"
        - Answer: no, because it requires comments to make the code quickly readable (I know that can be subjective)
            - And sure, some of you could argure it's simple enough to "easily" read, but self-documenting code is code that doesn't require you to interpret the _LOGIC_ of the code, and is simple enough for most developers to follow
    - Explain that `comments` are the hint or the pattern we can see that informs us that we may want to extract a function, to extract the code into a function that is named in a way to replace the comment
- Select all the code from line 20 - 28 (the code under that first in-line comment)
    - Right click -> Refactor: shortcut is dependent upon whether you're using MacOS or Windows, but clicking Refactor gives us a hint to "Extract method"
    - Click "Extract Method"
    - Suggest that we use the comment as input to the name of the new method
        - So for this example, something like `set_len_diff_and_max_len`
    - Explain that perhaps this isn't the best outcome - to have two return values from a method
- Refactor next section of code (the first `for i range...` through the first `distance = 0`)
    - Call the method: `add_distance_of_words_in_order`
    - Talk through how maybe this refactor isn't the best result, but still does make it self-documenting
        - The return value for `distance` on line 31 is not really needed and actually confusing because it's always going to be 0 like we want, but that feels really odd
        - Also, it passes in a lot variables as pass by reference and modifies them, and that can be ok, but let's try another way 
- Undo the Refactor
- Refactor the same section, but leaving off the line of `distance = 0`
    - Notice we at least no longer have the weird return value, and logic is clearer in the main method that we want distance to be reset to 0 following that method call
    - However, let's go back and try another refactor
- Undo the Refactor
    -  Before we try that Refactor again, let's consider some other refactorings we can do first to potentially end up with a better auto extracted method
    - Rename `distances` to `self.distances` 
        - Note that this is another example of "Pull up variable" to the scope of the class instead of method scope
- Refactor that same section again, leaving off the line of `distance = 0`
- Let's apply that same refactor to the reverse order for loop code
    - Call the method: `add_distance_of_reverse_order`
    - We now realize we can maybe do one other refactor because `distance` is not used in the scope of our main method
- Let's do a "Slide statement" refactor 
    -  Perform a "slide" to make `distance` to be closer to the code that needs it (in this case, moving it inside the for loop)
    - Comment out Line 16 (comment out `distance = 0`)
    - Now "slide" `distance = 0` down to into each of the new methods, right before the for loops

#### Concluding thoughts
Going through that set of refactorings we see that our code is a bit more self-documenting.

One could argue however, there are other improvements that could be made:
- For example: in reading the code now, I don't know for certain "to what" our `add_distance...` methods are adding to
    - It's not obvious it's adding to our distances array
    - That refactor would include:
        - Changes `add_distance...` methods to return distance instead of adding it to an array
        - Move the `distances.append()` code back to the main method
        - Rename the methods to `calc` instead of `add` to indicate they are only calculating the distance, not storing/adding it


 Either way, the process led us to at least slightly better 'self-documenting' code and was a good excercise nonetheless...hopefully at least :) 


