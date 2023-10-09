import React, { useEffect } from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import CreateNavbar from "./components/navbar/navbar";
import Home from "./components/pages/home";
import About from "./components/pages/about";
import ProductListAuthorized from "./components/product/ProductListAuthorized";
import ProductListUnauthorized from "./components/product/ProductListUnauthorized";
import ProductForm from "./components/product/ProductForm";
import ProductFormUnauthorized from "./components/product/ProductFormUnauthirized";
import Sales from "./components/pages/sales";
import Login from "./components/pages/login";
import MyOrders from "./components/pages/myorders";
import Registration from "./components/pages/register";
import RegistrationAdmin from "./components/pages/registeradmin";
import { useAuth } from "./components/AuthContext";
import { createTheme, ThemeProvider } from "@mui/material/styles";

// Making a theme for a website: need to check, not working now
const themeOptions = {
  palette: {
    mode: "light",
    primary: {
      main: "#1976d2",
    },
    secondary: {
      main: "#9c27b0",
    },
    background: {
      default: "#fff",
      paper: "#fff",
    },
  },
};

const theme = createTheme(themeOptions);

function App() {
  const { isLoggedIn, updateIsLoggedIn } = useAuth();

  useEffect(() => {
    // Calls isAuthenticated API endpoint with the access token
    const accessToken = localStorage.getItem("token");

    async function checkAuthentication() {
      try {
        const response = await fetch(
          `http://localhost:7081/api/Authenticate/isAuthenticated?accessToken=${accessToken}`
        );
        const isAuthenticated = await response.json();
        updateIsLoggedIn(isAuthenticated);
      } catch (error) {
        updateIsLoggedIn(false);
      }
    }

    if (accessToken) {
      checkAuthentication();
    } else {
      updateIsLoggedIn(false);
    }
  }, []);

  return (
    <ThemeProvider theme={theme}>
      <Router>
        <CreateNavbar />
        <Routes>
          <Route path="/" exact element={<Home />} />
          <Route path="/about" element={<About />} />
          <Route path="/myorders" element={<MyOrders />} />
          <Route path="/sales" element={<Sales />} />
          {/* Use conditional rendering based on isLoggedIn */}

          {/* not to show pages (like form) when user is not authorized */}
          <Route
            path="/products"
            element={
              isLoggedIn ? (
                <ProductListAuthorized />
              ) : (
                <ProductListUnauthorized />
              )
            }
          />
          {/* Continue with other routes */}
          <Route
            path="/productsform"
            element={isLoggedIn ? <ProductForm /> : <ProductFormUnauthorized />}
          />
          <Route path="/login" element={<Login />} />
          <Route path="/register" element={<Registration />} />
          <Route path="/registeradmin" element={<RegistrationAdmin />} />
        </Routes>
      </Router>
    </ThemeProvider>
  );
}

export default App;
