import React, { useState } from "react";
import './Home.css';
import Login from "./Login";
import { useNavigate } from "react-router-dom";

function Home() {

  const navigate = useNavigate();
  const [ user,setUser] = useState({
    "UserId":0,
    "EmailId":" ",
    "Role":"",
    "Token":""
  });

  var login=()=>{
    navigate("/Login");
  }
  return (
    <div className="home-container">
      
      {/* Navbar */}
      <nav className="navbar home-navbar navbar-light bg-white">
        <div className="container">
          <span className="navbar-brand home-navbar mb-0 h1">GoodHealth Hospitals</span>
        </div>
      </nav>
      
      <div className="bgIg-container">
      {/* Hero Section */}
      <div className="bgIg-container">
        <div className="home-hero text-white body-text text-center">
          <div className="container">
            <h1 className="home-hero-title fst-normal">Health is indeed wealth</h1>
            <p className="home-hero-subtitle fw-light">Get immense wealth with us</p>
            <button className="home-sign-in btn btn-dark text-white btn-lg" onClick={login}>
              Sign In
            </button>
          </div>
        </div>
        </div>
        </div>
      {/* Footer */}
      <footer className="footer bg-white text-center">
        <div className="footer-container">
          <p>&copy; 2023 GoodHealth hospitals. All rights reserved.</p>
        </div>
      </footer>
      
    </div>
  );
}

export default Home;
