# ZentronC
ZentronC is a compiled scripting language that's faster than both Lua and Python. It is extremely lightweight, and it written in C#.

## Dependencies
* GCC accessible from command line

## How it works
ZentronC scripts are compiled before runtime; First, they are translated into C code, and then into machine code with GCC. This compiler is dependent on gcc.

## Available commands and syntax
### Printing to the screen
to print things to the console, you can use the following syntax:
```
say ['n' to print a newline afterwards and 'nnl' to not] [the content, wrapped in " if it's a literal, and prefixed by & if it's a variable]
```

so here is what a hello world with the `say` command might look like:

```
say n "Hello, world!"
```

if we were to put "Hello, world" in a variable, this is how it would look:

```
x = "Hello, world"
say n &x
```

### Declaring variables
to declare a variable, you can follow this syntax:

`[Variable_name] = [Value]`

to create an empty variable, you can specify a variable name and end it with a semicolon.

`[Variable_name];`

### Getting input
to get input from the user, you can use the following syntax:
```
input -> [Variable_name]
```
this code snippet will put the user input into the specified variable.
### 
