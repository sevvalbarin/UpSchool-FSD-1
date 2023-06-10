import React, { useState } from "react";
import { Icon, Button, Form, Input, List, Segment } from "semantic-ui-react";
import "./App.css";

interface Todo {
  id: number;
  task: string;
  isCompleted: boolean;
  createdDate: Date;
}

function App() {
  const [todos, setTodos] = useState<Todo[]>([]);
  const [newTodo, setNewTodo] = useState("");

  const handleAddTodo = () => {
    if (newTodo.trim() === "") return;

    const todo: Todo = {
      id: todos.length + 1,
      task: newTodo,
      isCompleted: false,
      createdDate: new Date(),
    };

    setTodos([...todos, todo]);
    setNewTodo("");
  };

  const handleToggleCompletion = (id: number) => {
    setTodos((prevTodos) =>
      prevTodos.map((todo) =>
        todo.id === id ? { ...todo, isCompleted: !todo.isCompleted } : todo
      )
    );
  };

  const handleDeleteTodo = (id: number) => {
    setTodos((prevTodos) => prevTodos.filter((todo) => todo.id !== id));
  };

  const handleSortByDate = (order: "asc" | "desc") => {
    const sortedTodos = [...todos].sort((a, b) =>
      order === "asc"
        ? a.createdDate.getTime() - b.createdDate.getTime()
        : b.createdDate.getTime() - a.createdDate.getTime()
    );
    setTodos(sortedTodos);
  };

  return (
    <>
      <div className="app-container">
        <h1>Todos</h1>

        <div className="add-todo-container">
          <Form onSubmit={handleAddTodo}>
            <Input
              value={newTodo}
              onChange={(e) => setNewTodo(e.target.value)}
              placeholder="Add a new todo..."
            />
            <Button type="submit" disabled={!newTodo.trim()}>
              Add
            </Button>
          </Form>
        </div>
        <div className="todo-list-container">
          <List divided relaxed>
            {todos.map((todo) => (
              <List.Item
                key={todo.id}
                className={todo.isCompleted ? "completed" : ""}
                onDoubleClick={() => handleToggleCompletion(todo.id)}
              >
                <List.Content>
                  <div className="todo-item">
                    <input
                      type="checkbox"
                      className="checkbox"
                      checked={todo.isCompleted}
                      onChange={() => handleToggleCompletion(todo.id)}
                    />
                    <List.Header>{todo.task}</List.Header>
                    <List.Description>
                      {/* || Created: {todo.createdDate.toISOString()} 
                   
                   CSS kısmını ayarlayamadığım için bunu eklediğimde notlar ile çok yapışık durdu.
                      
                   */}
                      <Button  
                      key={todo.id}
                      onClick={() => handleDeleteTodo(todo.id)}>🗑️</Button>
                    </List.Description>
                  </div>
                </List.Content>
              </List.Item>
            ))}
          </List>
        </div>
        <div className="sort-buttons-container">
          <Button onClick={() => handleSortByDate("asc")}>
            Sort by Creation Date (Ascending)
          </Button>
          <Button onClick={() => handleSortByDate("desc")}>
            Sort by Creation Date (Descending)
          </Button>
        </div>
      </div>
      <Segment>
        <Icon
          name="trash alternate"
          size="big"
          color="black"
          //onClick={() => handleDeleteTodo(todo.id)}
        />
      </Segment>
    </>
  );
}

export default App;
