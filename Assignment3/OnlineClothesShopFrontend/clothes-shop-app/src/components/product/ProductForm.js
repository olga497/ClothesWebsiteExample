import React, { useState } from "react";
import { Button } from "react-bootstrap";
import "../../App.css";

function ProductForm({ fetchProducts }) {
  const [product, setProduct] = useState({
    Title: "",
    Size: "",
    Material: "",
    Description: "",
    Brand: "",
    GlobalCategory: "",
    Category: "",
    Subcategory: "",
    TargetAudience: "",
  });

  const handleChange = (event) => {
    const { name, value } = event.target;
    setProduct((prevProduct) => ({ ...prevProduct, [name]: value }));
  };

  const handleCreate = async (event) => {
    try {
      event.preventDefault();
      const token = localStorage.getItem("token");
      console.log("here is the token: ", token);
      const requestOptions = {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
          Authorization: `Bearer ${token}`,
        },
        body: JSON.stringify(product),
      };

      const response = await fetch(
        `${process.env.REACT_APP_BACKEND_URL}/Product/Insert`,
        //        "http://localhost:7081/Product/Insert",
        requestOptions
      ); // this is our product

      if (!response.ok) {
        throw new Error("Network response was not ok");
      }

      //const data = await response;
      console.log("Response data: ", response);

      setProduct({
        Title: "",
        Size: "",
        Material: "",
        Description: "",
        Brand: "",
        GlobalCategory: "",
        Category: "",
        Subcategory: "",
        TargetAudience: "",
      });
    } catch (error) {
      console.error(error);
    }
  };

  return (
    <div className="product-frame">
      <div className="frame-content">
        <h2>Add Product</h2>
        <form onSubmit={handleCreate}>
          <div className="row form-group">
            <label className="col-sm-3">
              Title:
              <input
                type="text"
                name="Title"
                value={product.Title}
                onChange={handleChange}
              />
            </label>
            <br />
          </div>

          <div className="form-group">
            <label className="col-sm-3">
              Size:
              <input
                type="text"
                name="Size"
                value={product.Size}
                onChange={handleChange}
              />
            </label>
            <br />
          </div>

          <div className="row form-group">
            <label className="col-sm-3">
              Material:
              <input
                type="text"
                name="Material"
                value={product.Material}
                onChange={handleChange}
              />
            </label>
            <br />
          </div>

          <div className="form-group">
            <label className="col-sm-3">
              Description:
              <input
                type="text"
                name="Description"
                value={product.Description}
                onChange={handleChange}
              />
            </label>
            <br />
          </div>

          <div className="row form-group">
            <label className="col-sm-3">
              Brand:
              <input
                type="text"
                name="Brand"
                value={product.Brand}
                onChange={handleChange}
              />
            </label>
            <br />
          </div>

          <div className="row form-group">
            <label className="col-sm-3">
              Global Category:
              <input
                type="text"
                name="GlobalCategory"
                value={product.GlobalCategory}
                onChange={handleChange}
              />
            </label>
            <br />
          </div>

          <div className="row form-group">
            <label className="col-sm-3">
              Category:
              <input
                type="text"
                name="Category"
                value={product.Category}
                onChange={handleChange}
              />
            </label>
            <br />
          </div>

          <div className="row form-group">
            <label className="col-sm-3">
              Subcategory:
              <input
                type="text"
                name="Subcategory"
                value={product.Subcategory}
                onChange={handleChange}
              />
            </label>
            <br />
          </div>

          <div className="row form-group">
            <label className="col-sm-3">
              Target Audience:
              <input
                type="text"
                name="TargetAudience"
                value={product.TargetAudience}
                onChange={handleChange}
              />
            </label>
            <br />
          </div>

          <Button variant="outline-dark" type="submit">
            Add
          </Button>
        </form>
      </div>
    </div>
  );
}

export default ProductForm;
