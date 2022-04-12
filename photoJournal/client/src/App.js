import React from 'react';
import { BrowserRouter as Router } from "react-router-dom";
import { UserProfileProvider } from "./providers/UserProfileProvider";
// import Header from "./components/Header";
import ApplicationViews from "./Components/ApplicationViews";

function App() {
  return (
    <Router>
      <UserProfileProvider>
      <ApplicationViews />
      </UserProfileProvider>
    </Router>
  );
}

export default App;
