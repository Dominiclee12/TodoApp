import axios from "axios";

const API_URL = "https://localhost:7179/api/todo";

export const getTodos = () => axios.get(API_URL);
export const createTodo = (taskName) => axios.post(API_URL, { taskName: taskName });
export const updateTodo = (todo) => axios.put(`${API_URL}/${todo.id}`, todo);
export const deleteTodo = (id) => axios.delete(`${API_URL}/${id}`);