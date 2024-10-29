# Steps for walking others through these examples

### Introduction
Welcome!

This session today will cover some refactoring patterns from Martin Fowler's book: `Refactoring - Improving the design of existing code`. These patterns are most likely ones you already follow, but knowing them, being able to identify when you're following them, can help assert you're making a worthwhile refactor. 

We'll cover a few refactorings, but knowing that with each example, other refactorings are possible - I'll try to stay focused on the examples for today. 

### Start with Die Roll
With Die Roll, we introduce a simple 'Extract function' refactoring.

#### Steps:
- Open the file `die_roll_before` and briefly walk them through the code
- Explain that `Repeated code` is the hint to extract a function
- The repeated code being the calls to `random.randint()`
- Explain that we want to Extract a function that will generate a random number given a range
- Show the `die_roll_after` code and walk through the refactor that was done
- Ask, "What other benefits do we gain from extracting this function?"
    - Answer: this code can now generate roll of any number sided die
    - In the previous code we limited ourselves to 3 numbers because of our "switch" statement for 6, 8, or 12 sided die
    - This could actually be good OR bad - maybe we don't want to allow rolling oddly shaped dies

### Levenshtein Distance
With Levenshtein Distance, we again use 'Extract function' to start things out.

#### Steps:
- Open the file `lev_distance_before` and briefly walk them through the code
- Ask, "Is this code self-documenting code?"
    - Answer: no, because it requires comments to make the code quickly readable 
        - And sure, some of you could argure it's simple enough to "easily" read, but self-documenting code is code that doesn't require you to interpret the LOGIC of the code
- Explain that `comments` are the hint to extract a function, to extract the code into a function that is named in a way to replace the comment


