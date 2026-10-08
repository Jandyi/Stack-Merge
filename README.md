# Stack Merge

A C#/.NET 8 console application that implements a custom integer stack and demonstrates two ways of merging stacks: preserving duplicates and removing duplicates.

The project is built around a manually implemented stack data structure rather than the built-in .NET collection types.

## Features

- Custom integer stack implementation
- `Push`, `Pop`, `Size`, `IsEmpty`, and `IsFull` operations
- Merge two stacks while preserving duplicates
- Merge two stacks while removing duplicates
- Descending-order insertion during merging
- Duplicate detection
- Stack copying and restoration
- Interactive console input and output

## Technologies

- **C#**
- **.NET 8**
- **Console Application**
- Data Structures & Algorithms

## How It Works

The program asks the user to enter two integer stacks.

It then produces two results:

1. **Merge with duplicates** — every value from both stacks is included.
2. **Merge without duplicates** — repeated values are included only once.

The merged stacks are maintained in descending order.

### Example

Given:

```text
Stack 1: [ 8 5 3 ]
Stack 2: [ 7 5 2 ]
```

The results are conceptually:

```text
With duplicates:
[ 8 7 5 5 3 2 ]

Without duplicates:
[ 8 7 5 3 2 ]
```

## Stack Implementation

The project defines a custom `IntStack` class backed by an integer array.

The stack supports:

- `Push()` — add an element
- `Pop()` — remove and return the top element
- `Size()` — return the number of elements
- `IsEmpty()` — check whether the stack is empty
- `IsFull()` — check whether the stack has reached its capacity

Temporary stacks are used when traversing or rearranging the data so that the original stack contents can be restored.

## Merge Algorithms

### Merge With Duplicates

Both input stacks are traversed and every value is inserted into the result stack.

Values are inserted using a helper method that maintains descending order.

### Merge Without Duplicates

The same merging process is used, but each value is checked against the result stack before insertion.

If the value already exists, it is skipped.

## Project Structure

```text
Stack-Merge/
├── README.md
├── .gitignore
├── Stack Merge.sln
└── Stack Merge/
    ├── Stack Merge.csproj
    └── StackMerge.cs
```

### `StackMerge.cs`

Contains the custom stack implementation, stack operations, merge algorithms, duplicate detection, input handling, and console output.

## Requirements

- .NET 8 SDK
- Visual Studio 2022 or another C# IDE supporting .NET 8

## Running the Project

Open:

```text
Stack Merge.sln
```

in Visual Studio.

Build and run the project.

The application will ask for the size and elements of each stack and then display both merge results.

## Project Information

- **Status:** Completed
- **Developed:** 2026
