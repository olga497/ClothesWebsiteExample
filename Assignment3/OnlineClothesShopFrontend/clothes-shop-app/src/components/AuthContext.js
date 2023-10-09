import React, { createContext, useState, useContext, useEffect } from "react";
import axios from "axios";
import jwt from "jsonwebtoken";

//import { useNavigate } from 'react-router-dom';

const AuthContext = createContext();

export function AuthProvider({ children, navigate }) {
  const [isLoggedIn, setIsLoggedIn] = useState(false);
  const [productsFetched, setProductsFetched] = useState(false);
  const [isAdmin, setIsAdmin] = useState(false);

  useEffect(
    function () {
      const token1 = localStorage.getItem("token");
      if (token1 == null) {
        updateIsLoggedIn(false);
        setIsAdmin(true);
        console.log("i am here");
      } else {
        handleIsLoggedIn();
      }

      //handleIsLoggedIn();
      // const response = axios.get('http://localhost:7081/api/Authenticate/isAuthenticated', {token})
      // .then(response => {console.log("is Authenticated ", response.data);});
      //}
      //const { isAuthenticated } = response.data;  // it will be true or false
      //console.log("is Authenticated ", isAuthenticated)
      if (isLoggedIn && !productsFetched) {
        setProductsFetched(true); // Prevent further fetch attempts
      }
    },
    [isLoggedIn, productsFetched]
  );

  const updateIsLoggedIn = (status) => {
    setIsLoggedIn(status);
  };

  async function handleIsLoggedIn() {
    try {
      const token = localStorage.getItem("token");
      console.log("my token", token);
      const response = await axios.get(
        "http://localhost:7081/api/Authenticate/isAuthenticated",
        {
          params: { accessToken: token }, // Pass the token as a parameter
        }
      );
      //const { isAuthenticated } = response.data;  // it will be true or false
      console.log("is Authenticated ", response.data);

      // Decoding the token
      const decodedToken = jwt.decode(token);
      console.log("decoded token: ", decodedToken.role);

      if (decodedToken) {
        // Accessing the role from the decoded token's payload
        const role = decodedToken.role; // Change 'role' to the actual key in the payload
        if (role == "Admin") {
          setIsAdmin(true);
          console.log("is admin here", isAdmin);
        }
      }
      if (response.data === true) {
        updateIsLoggedIn(true);
      } else {
        localStorage.removeItem("token");
        localStorage.clear();
        updateIsLoggedIn(false);
        //Error appeared due to navigate, do not understand why it is not working.
        //No issues without navigate
        //const navigate = useNavigate();
        //navigate('/');
      }
    } catch (error) {
      console.error("Smth failed:", error);
    }
  }

  return (
    <AuthContext.Provider
      value={{ isLoggedIn, updateIsLoggedIn, isAdmin, setIsAdmin }}
    >
      {children}
    </AuthContext.Provider>
  );
}

export function useAuth() {
  return useContext(AuthContext);
}
