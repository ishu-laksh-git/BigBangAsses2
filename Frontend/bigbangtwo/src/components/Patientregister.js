import React, { useState } from "react";
import './Register.css';
import { useNavigate } from "react-router-dom";

function Patientregister() {
  const navigate = useNavigate();
  const [patient, setPatient] = useState({
    "patientId": 0,
    "name": "",
    "dateOfBirth": "",
    "gender": "",
    "phone": "",
    "email": "",
    "address": "",
    "healthIssue": "",
    "users": {
      "userId": 0,
      "emailId": "",
      "role": "",
      "passwordHash": "",
      "passwordKey": ""
    },
    "passwordClear": ""
  });

  const registerPatient = async (event) => {
    event.preventDefault(); // Prevent default form submission

    try {
      const response = await fetch("http://localhost:5184/api/Hospital/RegisterPatient", {
        method: "POST",
        headers: {
          "accept": "text/plain",
          "Content-Type": "application/json"
        },
        body: JSON.stringify({
          ...patient,
          "patient": {}
        })
      });

      if (response.status === 201) {
        const data = await response.json();
        console.log(data);
        localStorage.setItem("token", data.token.toString());
        localStorage.setItem("Patient Id", data.userId);
        navigate("/patienthome");
      } else {
        console.log("Error registering patient");
      }
    } catch (error) {
      console.log(error);
    }
  };

  return (
    <section className="vh-100 gradient-custom">
      {/* Navbar */}
      <nav className="navbar home-navbar navbar-light bg-white">
        <div className="container">
          <span className="navbar-brand home-navbar mb-0 h1">GoodHealth Hospitals</span>
        </div>
      </nav>
      <div className="container py-5 h-100">
        <div className="row justify-content-center align-items-center h-100">
          <div className="col-12 col-lg-9 col-xl-7">
            <div className="card shadow-2-strong card-registration">
              <div className="card-body p-4 p-md-5">
                <h3 className="mb-4 pb-2 pb-md-0 mb-md-5">Patient Registration Form</h3>
                <form>
                  <div className="row">
                    <div className="col-md-6 mb-2">
                      <div className="form-outline">
                        <input type="text" id="Name" className="form-control form-control-md" placeholder="Name" onChange={(event) => {
                          setPatient({ ...patient, "name": event.target.value })
                        }} />
                      </div>
                    </div>
                    <div className="col-md-6 mb-2">
                      <div className="form-outline">
                        <input type="text" id="healthIssue" className="form-control form-control-md" placeholder="Health issue" onChange={(event) => {
                          setPatient({ ...patient, "healthIssue": event.target.value })
                        }} />
                      </div>
                    </div>
                  </div>

                  <div className="row">
                    <div className="col-md-6 mb-2">
                      <div className="form-outline">
                        <input type="date" id="dateOfBirth" className="form-control form-control-md" placeholder="Date of Birth" onChange={(event) => {
                          setPatient({ ...patient, "dateOfBirth": event.target.value })
                        }} />
                      </div>
                    </div>
                    <div className="col-md-6 mb-2">
                      <div className="form-check form-check-inline">
                        <input className="form-check-input" type="radio" name="gender" id="femaleGender" value="Female" onChange={(event) => {
                          setPatient({ ...patient, "gender": event.target.value })
                        }} />
                        <label className="form-check-label" htmlFor="femaleGender">Female</label>
                      </div>
                      <div className="form-check form-check-inline">
                        <input className="form-check-input" type="radio" name="gender" id="maleGender" value="Male" onChange={(event) => {
                          setPatient({ ...patient, "gender": event.target.value })
                        }} />
                        <label className="form-check-label" htmlFor="maleGender">Male</label>
                      </div>
                      <div className="form-check form-check-inline">
                        <input className="form-check-input" type="radio" name="gender" id="otherGender" value="Other" onChange={(event) => {
                          setPatient({ ...patient, "gender": event.target.value })
                        }} />
                        <label className="form-check-label" htmlFor="otherGender">Other</label>
                      </div>
                    </div>
                  </div>

                  <div className="row">
                    <div className="col-md-6 mb-2">
                      <div className="form-outline">
                        <input type="email" id="email" className="form-control form-control-md" placeholder="Email" onChange={(event) => {
                          setPatient({ ...patient, "email": event.target.value })
                        }} />
                      </div>
                    </div>
                    <div className="col-md-6 mb-2">
                      <div className="form-outline">
                        <input type="tel" id="phone" className="form-control form-control-md" placeholder="Phone" onChange={(event) => {
                          setPatient({ ...patient, "phone": event.target.value })
                        }} />
                      </div>
                    </div>
                  </div>

                  <div className="row">
                    <div className="col-md-6 mb-2">
                      <div className="form-outline">
                        <input type="text" id="address" className="form-control form-control-md" placeholder="Address" onChange={(event) => {
                          setPatient({ ...patient, "address": event.target.value })
                        }} />
                      </div>
                    </div>
                    <div className="col-md-6 mb-2">
                      <div className="form-outline">
                        <input type="password" id="password" className="form-control form-control-md" placeholder="Password" onChange={(event) => {
                          setPatient({ ...patient, "passwordClear": event.target.value })
                        }} />
                      </div>
                    </div>
                  </div>

                  <div>
                    <button className="btn btn-primary btn-md" type="submit" onClick={registerPatient}>Register</button>
                  </div>
                </form>
              </div>
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
    </section>
  );
}

export default Patientregister;
