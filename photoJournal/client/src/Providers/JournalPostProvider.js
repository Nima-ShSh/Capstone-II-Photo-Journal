import React, { useState, createContext } from "react";

export const PostContext = createContext();

export const PostProvider = (props) => {
    const [journalPosts, setJournalPosts] = useState([]);

const GetAllJournalPosts = () => {
    return fetch("https://localhost:44377/api/Post")
    .then((res) => res.json())
    .then(setJournalPosts);
};

return (
    <PostContext.Provider value={{ journalPosts, GetAllJournalPosts }}>
    {props.children}
  </PostContext.Provider>
);
};