import React from "react";
import Nav from "react-bootstrap/Nav";
import Navbar from "react-bootstrap/Navbar";
import NavDropdown from "react-bootstrap/NavDropdown";
import { Form, FormControl, Button } from "react-bootstrap";
import { Link } from "react-router-dom";
import { useAuth } from "../AuthContext"; // Import the useAuth hook

function CreateNavbar() {
  const { isLoggedIn, updateIsLoggedIn, isAdmin, setIsAdmin } = useAuth(); // Get isLoggedIn and updateIsLoggedIn from the AuthContext
  const handleLogout = () => {
    // Clear the token and update isLoggedIn state to false when logging out
    localStorage.removeItem("token");
    localStorage.clear();
    updateIsLoggedIn(false);
    setIsAdmin(false);
  };

  return (
    <Navbar bg="light" expand="lg">
      <Navbar.Brand as={Link} to="/">
        Clothes Shop
      </Navbar.Brand>
      <Navbar.Toggle aria-controls="basic-navbar-nav" />
      <Navbar.Collapse id="basic-navbar-nav">
        <Nav className="mr-auto">
          <Nav.Link as={Link} to="/">
            {" "}
            Home{" "}
          </Nav.Link>
          <Nav.Link as={Link} to="/about">
            {" "}
            About{" "}
          </Nav.Link>
          {isLoggedIn ? (
            <>
              <Nav.Link as={Link} to="/myorders">
                {" "}
                My Orders{" "}
              </Nav.Link>
            </>
          ) : (
            <></>
          )}

          <NavDropdown title="Products" id="basic-nav-dropdown">
            <NavDropdown.Item as={Link} to="/products">
              {" "}
              Product List{" "}
            </NavDropdown.Item>
            <NavDropdown.Item as={Link} to="/productsform">
              {" "}
              Product Form{" "}
            </NavDropdown.Item>
          </NavDropdown>

          <div className="d-flex align-items-center">
            <Form className="mr-3">
              <FormControl
                type="text"
                placeholder="Search"
                className="mr-sm-2"
              />
            </Form>
            <Button variant="outline-success">Search</Button>
          </div>

          {isLoggedIn ? (
            // Show username and "Logout" link if the user is logged in
            <>
              <Nav.Link disabled>
                {" "}
                Welcome, {localStorage.getItem("username")}{" "}
              </Nav.Link>
              <Nav.Item className="ml-auto">
                <Nav.Link onClick={handleLogout}> Logout </Nav.Link>
              </Nav.Item>

              {isAdmin ? (
                <>
                  <Nav.Link as={Link} to="/registeradmin">
                    {" "}
                    RegisterAdmin
                  </Nav.Link>
                </>
              ) : (
                <></>
              )}
            </>
          ) : (
            // Show "Register" and "Login" links if the user is not logged in
            <>
              <Nav.Link as={Link} to="/register">
                {" "}
                Register{" "}
              </Nav.Link>

              <Nav.Link as={Link} to="/login">
                {" "}
                Login{" "}
              </Nav.Link>
            </>
          )}
        </Nav>
      </Navbar.Collapse>
    </Navbar>
  );
}

export default CreateNavbar;
