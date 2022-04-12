import React, { useContext } from "react";
import { Route, Routes, Navigate } from "react-router-dom";
import{ JournalPostList } from "./JournalPosts/JournalPostList";
import { PostProvider } from "../providers/JournalPostProvider";
import Login from "./Login";
import Register from "./Register";

import {
    UserProfileContext,
    UserProfileProvider,
  } from "../providers/UserProfileProvider"



export default function ApplicationViews() {
    const { isLoggedIn } = useContext(UserProfileContext);

  
    if (!isLoggedIn) {
      return (  
        <Routes>
          <Route path="/login" element={<Login />} />
          <Route path="/register" element={<Register />} />
          <Route path="*" element={<Navigate to="/login" />} />      
        </Routes> 
      );
    }
    else{
     return(
       <UserProfileProvider>
       <PostProvider> 
            <Routes>
            <Route path="/" element={<JournalPostList />} />     
            
          </Routes>
      </PostProvider>
      </UserProfileProvider>
  
  
     );
    }
  }