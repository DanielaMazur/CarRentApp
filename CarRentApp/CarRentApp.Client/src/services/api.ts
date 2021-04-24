import axios from "axios";

const API = axios.create({
  baseURL: `https://localhost:44359/api`,
});

export { API };
