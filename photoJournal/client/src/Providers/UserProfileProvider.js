import React, { useState, useEffect, createContext } from "react";


export const UserProfileContext = createContext();

export const UserProfileProvider =(props) =>{

  const [userProfiles, setUserProfiles] = useState([]);
  const user = sessionStorage.getItem("user");
  const [isLoggedIn, setIsLoggedIn] = useState(user != null);




  const login = (userObject) => {
    return fetch(`https://localhost:44377/api/user/getbyemail?email=${userObject.email}`)
    .then((r) => r.json())
      .then((user) => {
        if(user.id){
          sessionStorage.setItem("user", JSON.stringify(user));
          setIsLoggedIn(true);
          return user
        }
        else{
          return undefined
        }
      });
  };


  const logout = () => {
        sessionStorage.clear()
        setIsLoggedIn(false);
  };

  const register = (userObject, password) => {
   
      return  fetch("https://localhost:44377/api/user", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(userObject),
    })
    .then((response) => response.json())
      .then((savedUserProfile) => {
        sessionStorage.setItem("userProfile", JSON.stringify(savedUserProfile))
        setIsLoggedIn(true);
      });

  };



  return (
    <UserProfileContext.Provider value={{ isLoggedIn, login, logout, register,
                                     userProfiles, user, setUserProfiles  }}>
       {props.children}
    </UserProfileContext.Provider>
  );
}