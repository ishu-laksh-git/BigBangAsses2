import React, { useState } from "react";
import { Link } from "react-router-dom";
import { useNavigate } from "react-router-dom";

function AddDoctors() {
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

  const doctorAdd = (event) => {
    event.preventDefault(); // Prevent form submission

    console.log(doctor);
    fetch("http://localhost:5184/api/Hospital/AddDoctor", {
      method: "POST",
      headers: {
        "Accept": "application/json",
        "Content-Type": "application/json",
        'Authorization': 'Bearer ' + localStorage.getItem('token')
      },
      body: JSON.stringify(doctor)
    })
      .then(async (response) => {
        if (response.status === 201) {
          const data = await response.json();
          console.log(data);
        } else {
          console.log("Error adding doctor");
        }
      })
      .catch((error) => {
        console.log(error);
      });
  };

  var logOut = () => {
    localStorage.clear();
  };

  return (
    <div>
      {/* Navbar */}
      <nav className="navbar navbar-expand-lg navbar-dark bg-primary">
        <div className="container">
          <Link className="navbar-brand" to="/adminhome">GoodHealth hospitals</Link>
          <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
            <span className="navbar-toggler-icon"></span>
          </button>
          <div className="collapse navbar-collapse" id="navbarNav">
            <ul className="navbar-nav ml-auto">
              <li className="nav-item">
                <Link className="nav-link" to="/admanagedoc">Manage Doctors</Link>
              </li>
              <li className="nav-item">
                <Link className="nav-link" to="/adddoc">Add Doctors</Link>
              </li>
              <li className="nav-item">
                <Link className="nav-link" to="/" onClick={logOut}>Logout</Link>
              </li>
            </ul>
          </div>
        </div>
      </nav>

      <div className="container py-5 h-100">
        <div className="row justify-content-center align-items-center h-100">
          <div className="col-12 col-lg-9 col-xl-7">
            <div className="card shadow-2-strong card-registration">
              <div className="card-body p-4 p-md-5">
                <h3 className="mb-4 pb-2 pb-md-0 mb-md-5">Add doctor</h3>
                <form onSubmit={doctorAdd}>
                  <div className="row">
                    <div className="col-md-6 mb-2">
                      <div className="form-outline">
                        <input
                          type="text"
                          id="firstName"
                          className="form-control form-control-md"
                          placeholder="Name"
                          value={doctor.name}
                          onChange={(e) => setDoctor({ ...doctor, name: e.target.value })}
                        />
                      </div>
                    </div>
                    <div className="col-md-6 mb-2">
                      <div className="form-outline">
                        <input
                          type="text"
                          id="lastName"
                          className="form-control form-control-md"
                          placeholder="Speciality"
                          value={doctor.speciality}
                          onChange={(e) => setDoctor({ ...doctor, speciality: e.target.value })}
                        />
                      </div>
                    </div>
                  </div>

                  <div className="row">
                    <div className="col-md-6 mb-2 d-flex align-items-center">
                      <div className="form-outline datepicker w-100">
                        <h6 className="mb-2 pb-1">Date of birth</h6>
                        <input
                          type="date"
                          className="form-control form-control-md"
                          id="birthdayDate"
                          value={doctor.dateOfBirth}
                          onChange={(e) => setDoctor({ ...doctor, dateOfBirth: e.target.value })}
                        />
                      </div>
                    </div>
                    <div className="col-md-6 mb-2">
                      <h6 className="mb-2 pb-1">Gender</h6>
                      <div className="form-check form-check-inline">
                        <input
                          className="form-check-input"
                          type="radio"
                          name="gender"
                          id="femaleGender"
                          value="female"
                          checked={doctor.gender === "female"}
                          onChange={(e) => setDoctor({ ...doctor, gender: e.target.value })}
                        />
                        <label className="form-check-label" htmlFor="femaleGender">Female</label>
                      </div>
                      <div className="form-check form-check-inline">
                        <input
                          className="form-check-input"
                          type="radio"
                          name="gender"
                          id="maleGender"
                          value="male"
                          checked={doctor.gender === "male"}
                          onChange={(e) => setDoctor({ ...doctor, gender: e.target.value })}
                        />
                        <label className="form-check-label" htmlFor="maleGender">Male</label>
                      </div>
                      <div className="form-check form-check-inline">
                        <input
                          className="form-check-input"
                          type="radio"
                          name="gender"
                          id="otherGender"
                          value="other"
                          checked={doctor.gender === "other"}
                          onChange={(e) => setDoctor({ ...doctor, gender: e.target.value })}
                        />
                        <label className="form-check-label" htmlFor="otherGender">Other</label>
                      </div>
                    </div>
                  </div>

                  <div className="row">
                    <div className="col-md-6 mb-2 pb-2">
                      <div className="form-outline">
                        <input
                          type="email"
                          id="emailAddress"
                          className="form-control form-control-md"
                          placeholder="Email"
                          value={doctor.email}
                          onChange={(e) => setDoctor({ ...doctor, email: e.target.value })}
                        />
                      </div>
                    </div>
                    <div className="col-md-6 mb-2 pb-2">
                      <div className="form-outline">
                        <input
                          type="tel"
                          id="phoneNumber"
                          className="form-control form-control-md"
                          placeholder="Phone"
                          value={doctor.phone}
                          onChange={(e) => setDoctor({ ...doctor, phone: e.target.value })}
                        />
                      </div>
                    </div>
                  </div>

                  <div className="row">
                    <div className="col-md-6 mb-2 pb-2">
                      <div className="form-outline">
                        <input
                          type="text"
                          id="city"
                          className="form-control form-control-md"
                          placeholder="City"
                          value={doctor.address}
                          onChange={(e) => setDoctor({ ...doctor, address: e.target.value })}
                        />
                      </div>
                    </div>
                    <div className="col-md-6 mb-2 pb-2">
                      <div className="form-outline">
                        <input
                          type="text"
                          id="specialty"
                          className="form-control form-control-md"
                          placeholder="Experience (in years)"
                          value={doctor.experience}
                          onChange={(e) => setDoctor({ ...doctor, experience: e.target.value })}
                        />
                      </div>
                    </div>
                  </div>
                  <div>
                    <input className="btn btn-primary btn-md" type="submit" value="Add" />
                  </div>
                </form>
              </div>
            </div>
          </div>
        </div>
      </div>

      {/* Footer */}
      <footer className="footer bg-dark text-white text-center">
        <div className="container">
          <p>&copy; 2023 GoodHealth hospitals. All rights reserved.</p>
        </div>
      </footer>
    </div>
  );
}

export default AddDoctors;
