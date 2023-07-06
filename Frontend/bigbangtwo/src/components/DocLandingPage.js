import React, { useState } from "react";
import './DoctorLandingPage.css';
import { Link } from "react-router-dom";

function DoctorLandingPage() {
  var logOut=()=>{ localStorage.clear()};
  const [doctor, setDoctor] = useState([]);
  const [isButtonClicked, setIsButtonClicked] = useState(false);

  const getDoc = async (doctorId) => {
    fetch(`http://localhost:5184/api/Hospital/GetDoctor?id=${doctorId}`, {
      method: "POST",
      headers: {
        accept: "text/plain",
        "Content-Type": "application/json",
        Authorization: "Bearer " + localStorage.getItem("token"),
      },
    })
    .then(async (response) => {
      if (!response.ok) {
        throw new Error(`HTTP error! Status: ${response.status}`);
      }
      const myData = await response.json();
      console.log(myData);
      setDoctor(myData);
      localStorage.setItem("Doc state", myData.isApproved);
      localStorage.setItem("doc name",myData.name);
      console.log(doctor);
      setIsButtonClicked(true);
    })
    .catch((error) => {
      console.error('Error fetching data:', error);
    });
  }

  return (
    <div className="doctor-landing-page d-flex flex-column">
      {/* Navbar */}
      <nav className="navbar navbar-expand-lg navbar-dark bg-primary">
        <div className="container">
          <Link className="navbar-brand" to="/dochome">Hospital Management System</Link>
          <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
            <span className="navbar-toggler-icon"></span>
          </button>
          <div className="collapse navbar-collapse" id="navbarNav">
            <ul className="navbar-nav ml-auto">
              <li className="nav-item">
                <Link className="nav-link" to="/" onClick={logOut}>Logout</Link>
              </li>
            </ul>
          </div>
        </div>
      </nav>

      {/* Doctor Status */}
      <div className="doctor-status text-black text-center">
        <div className="container d-flex align-items-center justify-content-center h-100">
          <div>
            <br/>
            
            <h2>Name:</h2> 
             <h3>{localStorage.getItem("doc name")}</h3>
            <h3>State:</h3>
            {isButtonClicked && <h3>{localStorage.getItem("Doc state")}</h3>}
            <button className="btn btn-secondary" onClick={() => getDoc(localStorage.getItem("User Id"))}>View status</button>

          </div>
        </div>
      </div>

      {/* Footer */}
      <footer className="footer bg-dark text-white text-center mt-auto">
        <div className="container">
          <p>&copy; 2023 GoodHealth hospitals. All rights reserved.</p>
        </div>
      </footer>
    </div>
  );
}

export default DoctorLandingPage;
