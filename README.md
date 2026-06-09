# Task Tracker CLI

A simple command-line task tracker built with C# and .NET.

This is a small educational pet project created as part of the roadmap.sh project ideas pool:  
https://roadmap.sh/projects/task-tracker

The application allows you to create, update, delete, mark, and list tasks.  
Tasks are stored in a local JSON file.

## Project Purpose

This project was built to practice:

- CLI input handling
- command parsing
- working with JSON files
- basic task state management
- simple project structure in C#

## Requirements

- .NET 10 SDK

Check installed SDKs:

```bash
dotnet --list-sdks
```

## Build

From the repository root:

```bash
dotnet build Tracker.App
```

## Run

From the repository root:

```bash
dotnet run --project Tracker.App
```

After startup, the application opens an interactive CLI session.

## Available Commands

### Add a task

Creates a new task with a unique id and `todo` status.

```text
add "Buy groceries"
```

Example:

```text
add "Buy groceries"
Task added: 1 - Buy groceries
```

---

### Update a task

Updates the description of an existing task by id.

```text
update 1 "Buy groceries and cook dinner"
```

Example:

```text
update 1 "Buy groceries and cook dinner"
Task updated: 1 - Buy groceries and cook dinner
```

---

### Delete a task

Deletes a task by id.

```text
delete 1
```

Example:

```text
delete 1
Task removed: 1 - Buy groceries and cook dinner
```

---

### Mark a task as in progress

```text
mark-in-progress 1
```

Example:

```text
mark-in-progress 1
Task marked as InProgress: 1 - Buy groceries
```

---

### Mark a task as done

```text
mark-done 1
```

Example:

```text
mark-done 1
Task marked as Done: 1 - Buy groceries
```

---

### Mark a task as todo

```text
mark-todo 1
```

Example:

```text
mark-todo 1
Task marked as Todo: 1 - Buy groceries
```

---

### List all tasks

```text
list
```

Example:

```text
list
1 - Buy groceries [Todo] {CreatedAt: 06/06/2026 18:10:00, UpdatedAt: 06/06/2026 18:10:00}
2 - Finish README [InProgress] {CreatedAt: 06/06/2026 18:12:00, UpdatedAt: 06/06/2026 18:20:00}
```

---

### List tasks by status

List completed tasks:

```text
list done
```

List todo tasks:

```text
list todo
```

List tasks in progress:

```text
list in-progress
```

---

### Help

Shows the list of supported commands.

```text
help
```

---

### Exit

Closes the application.

```text
exit
```

## Example Session

```text
add "Buy groceries"
Task added: 1 - Buy groceries

add "Write documentation"
Task added: 2 - Write documentation

mark-in-progress 2
Task marked as InProgress: 2 - Write documentation

list
1 - Buy groceries [Todo] {CreatedAt: 06/06/2026 18:10:00, UpdatedAt: 06/06/2026 18:10:00}
2 - Write documentation [InProgress] {CreatedAt: 06/06/2026 18:11:00, UpdatedAt: 06/06/2026 18:15:00}
```

## Storage

Tasks are stored in a JSON file named `tasks.json`.

Storage behavior:

- the file is created automatically if it does not exist
- tasks are read from the file when needed
- task changes are written back to the file after updates
- an empty file is handled safely as an empty task list

### File location

The file is created in the **current working directory** of the application.

If you run the project from an IDE, the file may appear inside the build output directory, for example:

```text
Tracker.App/bin/Debug/net10.0/tasks.json
```

If you run the app from another directory, the file will be created there instead.

## Notes

- This project uses only native .NET file system and JSON APIs
- No external libraries are required for task storage
