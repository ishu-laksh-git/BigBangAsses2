import React, { useState } from "react";
import './Register.css';
import { useNavigate } from "react-router-dom";

function Docregister() {
  const navigate = useNavigate();
  const [doctor, setDoctor] = useState({
    doctorId: 0,
    name: "",
    dateOfBirth: "",
    gender: "",
    phone: "",
    email: "",
    address: "",
    isApproved: "",
    speciality: "",
    experience: 0,
    users: {
      userId: 0,
      emailId: "",
      role: "",
      passwordHash: "",
      passwordKey: ""
    },
    passwordClear: ""
  });

  const doctorRegister = (event) => {
    event.preventDefault(); // Prevent form submission

    console.log(doctor);
    fetch("http://localhost:5184/api/Hospital/RegisterDoc", {
      method: "POST",
      headers: {
        "Accept": "application/json",
        "Content-Type": "application/json"
      },
      body: JSON.stringify(doctor)
    })
      .then(async (response) => {
        if (response.status === 201) {
          const data = await response.json();
          console.log(data);
          localStorage.setItem("token", data.token.toString());
          localStorage.setItem("DoctorId", data.userId);
          navigate("/");
        } else {
          console.log("Error registering doctor");
        }
      })
      .catch((error) => {
        console.log(error);
      });
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
                <h3 className="mb-4 pb-2 pb-md-0 mb-md-5">Doctor Registration Form</h3>
                <form onSubmit={doctorRegister}>
                  <div className="row">
                    <div className="col-md-6 mb-2">
                      <div className="form-outline">
                        <input type="text" id="Name" className="form-control form-control-md" placeholder="Name" onChange={(event) => {
                          setDoctor({ ...doctor, name: event.target.value })
                        }} />
                      </div>
                    </div>
                    <div className="col-md-6 mb-2">
                      <div className="form-outline">
                        <input type="text" id="Speciality" className="form-control form-control-md" placeholder="Speciality" onChange={(event) => {
                          setDoctor({ ...doctor, speciality: event.target.value })
                        }} />
                      </div>
                    </div>
                  </div>

                  <div className="row">
                    <div className="col-md-6 mb-2">
                      <div className="form-outline">
                        <input type="date" id="DateOfBirth" className="form-control form-control-md" placeholder="Date of Birth" onChange={(event) => {
                          setDoctor({ ...doctor, dateOfBirth: event.target.value })
                        }} />
                      </div>
                    </div>
                    <div className="col-md-6 mb-2">
                      <div className="form-outline">
                        <select id="Gender" className="form-control form-control-md" onChange={(event) => {
                          setDoctor({ ...doctor, gender: event.target.value })
                        }}>
                          <option value="">Select Gender</option>
                          <option value="male">Male</option>
                          <option value="female">Female</option>
                          <option value="other">Other</option>
                        </select>
                      </div>
                    </div>
                  </div>

                  <div className="row">
                    <div className="col-md-6 mb-2">
                      <div className="form-outline">
                        <input type="email" id="Email" className="form-control form-control-md" placeholder="Email" onChange={(event) => {
                          setDoctor({ ...doctor, email: event.target.value })
                        }} />
                      </div>
                    </div>
                    <div className="col-md-6 mb-2">
                      <div className="form-outline">
                        <input type="tel" id="Phone" className="form-control form-control-md" placeholder="Phone" onChange={(event) => {
                          setDoctor({ ...doctor, phone: event.target.value })
                        }} />
                      </div>
                    </div>
                  </div>

                  <div className="row">
                    <div className="col-md-6 mb-2">
                      <div className="form-outline">
                        <input type="text" id="Address" className="form-control form-control-md" placeholder="Address" onChange={(event) => {
                          setDoctor({ ...doctor, address: event.target.value })
                        }} />
                      </div>
                    </div>
                    <div className="col-md-6 mb-2">
                      <div className="form-outline">
                        <input type="number" id="Experience" className="form-control form-control-md" placeholder="Experience (in years)" onChange={(event) => {
                          setDoctor({ ...doctor, experience: event.target.value })
                        }} />
                      </div>
                    </div>
                  </div>

                  <div className="row">
                    <div className="col-md-6 mb-2">
                      <div className="form-outline">
                        <input type="password" id="Password" className="form-control form-control-md" placeholder="Password" onChange={(event) => {
                          setDoctor({ ...doctor, passwordClear: event.target.value })
                        }} />
                      </div>
                    </div>
                    <div className="col-md-6 mb-2">
                      <div className="form-outline">
                        <input type="password" id="ConfirmPassword" className="form-control form-control-md" placeholder="Confirm Password" />
                      </div>
                    </div>
                  </div>

                  <div>
                    <input className="btn btn-primary btn-md" type="submit" value="Register" />
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

export default Docregister;
