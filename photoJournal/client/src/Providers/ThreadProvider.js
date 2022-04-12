import React, { useState, createContext } from "react";

export const ThreadContext = createContext();

export const ThreadProvider = (props) => {
    const [threads, setThreads] = useState([]);

const GetAllThreads = () => {
    return fetch("https://localhost:44377/api/Post")
    .then((res) => res.json())
    .then(setThreads);
};

return (
    <ThreadContext.Provider value={{ threads, GetAllThreads }}>
    {props.children}
  </ThreadContext.Provider>
);
};