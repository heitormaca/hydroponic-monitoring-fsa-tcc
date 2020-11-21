import Axios from "axios";

export const API = 'http://localhost:5000/api';

const headers = {};

headers['Content-Type'] = 'application/json';
headers['Authorization'] = `Bearer ${localStorage.getItem('autenticarlogin')}`

const axiosInstance = Axios.create({
    baseURL: API,
    headers,
})

export default axiosInstance;