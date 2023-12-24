# ZentronC 🚀
*Documentation last updated December 24th*
**NOTE: ZentronC is a project I am doing for fun. It is very buggy at its current state and is updated almost daily**

ZentronC is a compiled scripting language that's faster than both Lua and Python. It is relatively lightweight and is written in C#.

## Dependencies
* GCC accessible from the command line

## How it works
ZentronC scripts are compiled before runtime. First, they are translated into C code and then into machine code with GCC. This compiler is dependent on GCC.

## Sample script
This script asks for the user's name and repeats until the user enters a valid name.
```
name;
say n "What is your name"
loop 
    input -> name
    if &name is ""
        say n "Please enter a name"
        continue
    end
    else
        break
    end
end

say nnl "Your name is "
say nnl &name
```

## Available commands and syntax
### Printing to the screen
To print things to the console, you can use the following syntax:
```
say ['n' to print a newline afterwards and 'nnl' to not] [the content, wrapped in " if it's a literal, and prefixed by & if it's a variable]
```

So here is what a hello world with the `say` command might look like:
```
say n "Hello, world!"
```

If we were to put "Hello, world" in a variable, this is how it would look:
```
x is "Hello, world"
say n &x
```
To print a newline, you would use this syntax:
```
sayemptyline
```

### Declaring variables
To declare a variable, you can follow this syntax:

`[Variable_name] is [Value]`

To create an empty variable, you can specify a variable name and end it with a semicolon.

`[Variable_name];`

### Getting input
To get input from the user, you can use the following syntax:
```
input -> [Variable_name]
```
This code snippet will put the user input into the specified variable.

### Labels and jumps
You can declare a label with the following syntax:
```
mark [label_name]
```
You can jump to a mark with the following syntax:
```
jumptomark [label_name]
```

### Sleeping
To wait a few seconds, you can use the following syntax:
```
waitseconds [seconds_to_wait]
```

### Integer manipulation
While arithmetic operations are not supported yet, you can use the following syntax to decrement and increment variables:
```
increment [variable_name] by [how_much]
decrement [variable_name] by [how_much]
```

### Comments
You can use `//` for single-line comments.
```
// This is a comment!
```

### Conditional statements
Available operators for checks:
```
// more will be added in the near future
is
isnt
<
>
```
For `if` statements, you can use the following syntax:
```
if [value_1] [operator] [value_2]
  // do something
end
```
For an `else` statement, you can use the following syntax:
```
else
  // do something
end
```
**Remember: variable names need to be prefixed with an ampersand!**

### Exiting the program
To exit the program, you can use the following syntax:
```
exit
```

### Loops
There are two types of loops available at the moment: Infinite loops and `Until` loops.

* Until loops operate until a condition is met.
* Infinite loops run infinitely unless stopped.

For infinite loops, you can use the following syntax:
```
loop
  // do something
end
```
For until loops, you can use the following syntax:

```
until [value_1] [operator] [value_2]
  // do something
end
```
**Remember: variable names need to be prefixed with an ampersand!**

Here are some loop-related keywords:
```
// break - breaks out of the current loop
// continue - continues an iteration of the loop
```

### Compiler rules
At the moment, there is only one compiler rule.
```
// auto-declare - automatically declare variables mentioned in statements that set the variable value
```
To add a compiler rule to your script, you can use the following syntax:
```
#rule [compiler_rule]
```
