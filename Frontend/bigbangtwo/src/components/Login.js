import React, { useState } from "react";
import './Login.css';
import { Link, useNavigate } from "react-router-dom";

function Login() {
  const navigate = useNavigate();
  const [user, setUser] = useState({
    userId: 0,
    emailId: "",
    password: "",
    role: "",
    token: ""
  });

  const handleSubmit = (event) => {
    event.preventDefault(); // Prevent form submission

    fetch("http://localhost:5184/api/Hospital/Login", {
      method: "POST",
      headers: {
        "Accept": "text/plain",
        "Content-Type": "application/json"
      },
      body: JSON.stringify({ ...user, user: {} })
    })
      .then(async (data) => {
        if (data.status === 200) {
          var myData = await data.json();
          localStorage.setItem("token", myData.token.toString());
        
          
          if (myData.role === "Admin") {
            localStorage.setItem("User Id", myData.userId.toString());
            alert("success");
            navigate("/adminhome");
          } else if (myData.role === "Doctor") {
            localStorage.setItem("User Id", myData.userId.toString());
            navigate("/docHome");
          } else if (myData.role === "Patient") {
            localStorage.setItem("User Id", myData.userId.toString());
            navigate("/patienthome");
          }
        }
        else{
          alert("bad credentials");
        }
      })
      .catch((err) => {
        console.log(err.error);
        
      });
  };

  return (
    
    <section className=" gradient-custom">
      <nav className="navbar home-navbar navbar-light bg-white">
        <div className="container">
          <span className="navbar-brand home-navbar mb-0 h1">GoodHealth Hospitals</span>
        </div>
      </nav>
      <div className="container py-5 h-100">
        <div className="row d-flex justify-content-center align-items-center h-100">
          <div className="col-12 col-md-8 col-lg-6 col-xl-5">
            <div className="card bg-secondary text-white">
              <div className="card-body p-5 text-center">

                <div className="mb-md-5 mt-md-4 pb-5">

                  <h2 className="fw-bold mb-2 text-uppercase">Login</h2>
                  <p className="text-white-50 mb-5">Please enter your login and password!</p>

                  <form onSubmit={handleSubmit}>
                    <div className="form-outline form-white mb-3">
                      <label className="form-label text-start" htmlFor="userid">User ID</label>
                      <input type="number" id="userid" className="form-control form-control-lg" placeholder="User ID" onChange={(event) => {
                        setUser({ ...user, userId: event.target.value });
                      }} />
                    </div>

                    <div className="form-outline form-white mb-4">
                      <label className="form-label text-start" htmlFor="typePasswordX">Password</label>
                      <input type="password" id="typePasswordX" className="form-control form-control-lg" placeholder="Password" onChange={(event) => {
                        setUser({ ...user, password: event.target.value });
                      }} />
                    </div>

                    <button className="btn btn-outline-light btn-lg px-5" type="submit">Login</button>

                  </form>

                </div>

                <div>
                  <p className="mb-0">Don't have an account?
                    <Link to="/docReg" className="text-white-50 fw-bold"><br />Sign up as a doctor</Link><br />
                    <Link to="/patientReg" className="text-white-50 fw-bold"><br />Sign up as a patient</Link><br /></p>
                </div>
                

              </div>
            </div>
          </div>
        </div>
        
      </div>
      {/* Footer */}
      <footer className="footer bg-white text-center">
        <div className="footer-container">
          <p >&copy; 2023 GoodHealth hospitals. All rights reserved.</p>
        </div>
      </footer>
    </section>
  );
}

export default Login;
