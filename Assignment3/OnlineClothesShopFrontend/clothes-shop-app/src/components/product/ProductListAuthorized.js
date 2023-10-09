import React, { useState, useEffect } from "react";
import axios from "axios";
import { useAuth } from "../AuthContext";

function ProductListAuthorized() {
  const [products, setProducts] = useState([]);
  const { isLoggedIn } = useAuth();

  useEffect(() => {
    if (isLoggedIn) {
      fetchProducts();
    }
  }, [isLoggedIn]);

  const fetchProducts = async () => {
    try {
      const token = localStorage.getItem("token");
      console.log("fetched", token);
      const response = await axios.get("http://localhost:7081/Product/Get", {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      });

      setProducts(response.data);
    } catch (error) {
      console.error("Failed to fetch products:", error);
    }
  };

  const sortedProducts = [...products].sort((a, b) => {
    if (a.title && b.title) {
      return a.title.localeCompare(b.title);
    }
    return 0;
  });

  return (
    <div className="product-frame">
      <div className="frame-content">
        <h2>Product List</h2>
        <ul>
          {sortedProducts.map((product) => (
            <li key={product.id}>{product.title}</li>
          ))}
        </ul>
      </div>
    </div>
  );
}

export default ProductListAuthorized;
