import React, { useState, useEffect } from 'react'
import { getTodos, createTodo, updateTodo, deleteTodo } from "../../services/api"

const TodoItems = () => {
    const [todos, setTodos] = useState([])
    const [todo, setTodo] = useState({ id: null, taskName: "", isCompleted: false })
    const [editMode, setEditMode] = useState(false)

    useEffect(() => {
        fetchTodos()
    }, [])

    const fetchTodos = async () => {
        const response = await getTodos()
        setTodos(response.data)
    }

    const handleAdd = async (e) => {
        e.preventDefault()
        await createTodo(todo.taskName)
        setTodo({ id: null, taskName: "", isCompleted: false })
        fetchTodos()
    }

    const handleUpdate = async (e) => {
        e.preventDefault()
        await updateTodo(todo)
        setTodo({ id: null, taskName: "", isCompleted: false })
        setEditMode(false)
        fetchTodos();
    }

    const onEdit = async (todo) => {
        setEditMode(true)
        setTodo(todo)
    }

    const handleDelete = async (id) => {
        await deleteTodo(id)
        fetchTodos()
    }

    const toggleComplete = async (todo) => {
        await updateTodo(todo)
        fetchTodos()
    }

    return (
        <div className="todo-list">
            <h1 className="mb-3">Todo List</h1>

            {editMode ? (
                <form onSubmit={handleUpdate}>
                    <div className="input-group mb-3">
                        <input type="text" className="form-control" value={todo.taskName} onChange={(e) => setTodo({ ...todo, taskName: e.target.value })} required />
                        <button className="btn btn-primary" type="submit">Update</button>
                    </div>
                    <button className="btn btn-secondary" onClick={() => { setEditMode(false); setTodo({ id: null, taskName: "", isCompleted: false }); }}>Back</button>
                </form>
            ) : (
                <form onSubmit={handleAdd}>
                    <div className="input-group mb-3">
                        <input type="text" className="form-control" value={todo.taskName} onChange={(e) => setTodo({ ...todo, taskName: e.target.value })} placeholder="What to do" required />
                        <button className="btn btn-primary" type="submit">Add</button>
                    </div>
                </form >
            )}

            <ul className={`list-group ${editMode && " d-none"}`}>
                {
                    (todos.length > 0) ? (
                        todos.map((todo) =>
                            <li key={todo.id} className={`list-group-item list-group-item-action text-start ${todo.isCompleted && "text-decoration-line-through"}`}>
                                <p className="d-inline" style={{ cursor: "pointer" }} onClick={() => toggleComplete({ ...todo, isCompleted: !todo.isCompleted })}>{todo.taskName}</p>
                                <div className="btn-group float-end">
                                    <button className="btn btn-outline-secondary btn-sm" onClick={() => onEdit(todo)}><i class="bi bi-pen"></i></button>
                                    <button className="btn btn-outline-danger btn-sm float-end" onClick={() => window.confirm("Are you sure you want to delete this item?") && handleDelete(todo.id)}><i class="bi bi-trash"></i></button>
                                </div>
                            </li>)
                    ) : (
                        <div>Loading...</div>
                    )
                }
            </ul>
        </div>
    )
}

export default TodoItems