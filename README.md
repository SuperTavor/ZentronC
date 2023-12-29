# ZentronC 🚀
*Documentation last updated December 29th*

**NOTE: ZentronC is a project I am doing for fun. It is very buggy at its current state and is updated almost daily**

ZentronC is a compiled scripting language that's faster than both Lua and Python. It is relatively lightweight and is written in C#.

## Dependencies
* G++ accessible from the command line

## How it works
ZentronC scripts are compiled before runtime. First, they are translated into C++ code and then into machine code with GCC. This compiler is dependent on GCC/G++.

## Sample script
This script asks for the user's name and repeats until the user enters a valid name.
```zentronC
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
```zentronC
say ['n' to print a newline afterwards and 'nnl' to not] [the content, wrapped in " if it's a literal, and prefixed by & if it's a variable]
```

So here is what a hello world with the `say` command might look like:
```zentronC
say n "Hello, world!"
```
to print variables, you need to write `&` and then the variable name. Example:
```zentronC
x = "Hello"
say n &x
```
for string formatting, you can print with the `say_fmt` command. Example:
```zentronC
name = "John"
age = "10"
say_fmt "a kid named " &name " is " &age " years old."
```
Keep in mind that unlike `say`, `say_fmt` doesn't print a newline, you have to do it manually:
```zentronC
say_fmt "hello, world\n"
```
To print a newline without anything else, you would use this syntax:
```zentronC
sayemptyline
```

### Declaring variables
To declare a variable, you can follow this syntax:

`[Variable_name] is [Value]`

To create an empty variable, you can specify a variable name and end it with a semicolon.

`[Variable_name];`
If we were to put "Hello, world" in a variable, this is how it would look:
```zentronC
x is "Hello, world"
say n &x
```

### Getting input
To get input from the user, you can use the following syntax:
```zentronC
input -> [Variable_name]
```
This code snippet will put the user input into the specified variable.

### Labels and jumps
You can declare a label with the following syntax:
```zentronC
mark [label_name]
```
You can jump to a mark with the following syntax:
```zentronC
jumptomark [label_name]
```

### Sleeping
To wait a few seconds, you can use the following syntax:
```zentronC
waitseconds [seconds_to_wait]
```

### Integer manipulation
At the moment, only basic addition, subtraction, division, multiplication, incrementation and decrementation are supported.
```zentronC
increment [variable_name] by [how_much]
decrement [variable_name] by [how_much]
add [value1] [value2] -> [variable_name]
subtract [value1] [value2] -> [variable_name]
multiply [value1] [value2] -> [variable_name]
divide [value1] [value2] -> [variable_name]
```

### Comments
You can use `//` for single-line comments.
```zentronC
// This is a comment!
```

### Conditional statements
Available operators for checks:
```zentronC
// more will be added in the near future
is
isnt
<
>
```
For `if` statements, you can use the following syntax:
```zentronC
if [value_1] [operator] [value_2]
  // do something
end
```
For an `else` statement, you can use the following syntax:
```zentronC
else
  // do something
end
```
**Remember: variable names need to be prefixed with an ampersand!**

### Exiting the program
To exit the program, you can use the following syntax:
```zentronC
exit
```

### Loops
There are two types of loops available at the moment: Infinite loops and `Until` loops.

* Until loops operate until a condition is met.
* Infinite loops run infinitely unless stopped.

For infinite loops, you can use the following syntax:
```zentronC
loop
  // do something
end
```
For until loops, you can use the following syntax:

```zentronC
until [value_1] [operator] [value_2]
  // do something
end
```
**Remember: variable names need to be prefixed with an ampersand!**

Here are some loop-related keywords:
```zentronC
// break - breaks out of the current loop
// continue - continues an iteration of the loop
```

### Compiler rules
At the moment, there is only one compiler rule.
```zentronC
// auto-declare - automatically declare variables mentioned in statements that set the variable value
```
To add a compiler rule to your script, you can use the following syntax:
```zentronC
#rule [compiler_rule]
```
