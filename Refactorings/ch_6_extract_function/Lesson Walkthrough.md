# Steps for walking others through these examples

### Introduction
#### Start with the "Lesson Notes" markdown file to introduce the topics
Welcome!

This session today will cover some refactoring patterns from Martin Fowler's book: `Refactoring - Improving the design of existing code`. These patterns are most likely ones you already follow, but knowing them, being able to identify when you're following them, can help assert you're making a worthwhile refactor. 

We'll cover a few refactorings, but knowing that with each example, other refactorings are possible and not every refactor I'll show is what I'd considered a good change.

### Start with Die Roll
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

### Levenshtein Distance
With Levenshtein Distance, we again use 'Extract function' to start things out.

#### Steps:
- Open the file `lev_distance_before` and briefly walk them through the code
- Ask, "Is this code self-documenting code?"
    - Answer: no, because it requires comments to make the code quickly readable 
        - And sure, some of you could argure it's simple enough to "easily" read, but self-documenting code is code that doesn't require you to interpret the LOGIC of the code AND is simple enough for most developers to follow
- Explain that `comments` are the hint or the pattern we can see that informs us that we may want to extract a function, to extract the code into a function that is named in a way to replace the comment
- Select all the code from line 20 - 28 (the code under that first in-line comment)
    - Right click -> Refactor: shortcut is dependent upon whether you're using MacOS or Windows, but clicking Refactor gives us a hint to "Extract method"
- Click "Extract Method"
- Suggest that we use the comment as input to the name of the new method
    - So for this example, something like `set_max_and_diff_len`
- Explain that perhaps this isn't the best outcome - to have two return values from a method
- Undo the Refactor
- Rename (F2) `len_diff` to be `self.len_diff` (line 14 -> `self.len_diff = 0`)
- Do the same with `max_len` (line 17 -> `self.max_len = 0`)
- Now Redo that same Refactor and see that it doesn't return anything, but rather sets the value to those newly added class variables
    - Mention that perhaps we could instead now add a constructor that initializes those two fields to 0
    - Main takeway though is that sometimes a tiny refactor can help VS Code to create better auto refactorings
- Refactor next section of code (the first `for i range...` through the first `distance = 0`)
- Talk through how maybe this refactor isn't the best result, but still does make it self-documenting
    - The return value for `distance` on line 31 is not really needed and actually confusing because it's always going to be 0 like we want, but that feels really odd
    - Also, it passes in a lot variables as pass by reference and modifies them, and that can be ok, but let's try another way 
- Undo the Refactor
- Refactor the same section, but leaving off the line of `distance = 0`
    - Notice we at least no longer have the weird return value, and logic is clearer in the main method that we want distance to be reset to 0 following that method call
    - However, let's go back and try another refactor 
- Undo the Refactor
- Before we try that Refactor again, let's consider some other refactorings we can do first to potentially end up with a better auto extracted method
- Rename `distances` to `self.distances` 
    - Note that this is another example of "Pull up variable" to the scope of the class instead of method scope
- Refactor that same section again, leaving off the line of `distance = 0`
- Let's apply that same refactor to the reverse order for loop code
    - We now realize we can maybe do one other refactor because we're realizing that `distance` is not something that needs to live outside of that method
- Let's do a "Slide statement" refactor where we "slide" distance to be closer to the code that needs it (in this case, moving it inside the for loop)
- Comment out Line 16 (comment out `distance = 0`)
- Now "slide" what is now line 32 (`distance = 0`) down to the new method, right before the for loop


