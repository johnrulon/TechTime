# Refactorings covered by Dice Roll and Levenshtein Distance
### Extract Function
- Replace comment with function
- Replace repeated code with function
- VS Code's "Refactor" tools
- Name functions based on _what_ they do, based on its purpose

### Pull up field
- Moving a field "up" from a sub-class to a parent class or a method to a class

### Replace inline code with function code

### Slide Statements

### Split Variable

### Extract Variable
- If there's not a lot of logic to abstract into a method, consider introducing a variable
### Rename Variable
- Rename variable to better describe what the variable contains

# Key takeaways
We spend the majority of our time reading code versus writing code. Therefore, prefer readability over condensed or "cool" code. 

Self-documenting code, that abstracts complexity into functions that have a single and focused reponsibility, will help with readability.

From Martin Fowler's Refactorings book:
>If you have to spend effort looking at a fragment of code and figuring out _what_ it's doing, then you should extract it into a function and name the function after the _what_. ... Name it by _what_ it does, not by _how_ it does it.

> Small functions only work if the names are good, so you need to pay good attention to naming. This takes practice—but once you get good at it, this approach can make code remarkably self-documenting.

> To me, any function with more than half-a-dozen lines of code starts to smell, and it's not unusual for me to have functions that are a single line of code.

