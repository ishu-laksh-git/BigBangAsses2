import React from "react";
import './PatientLandingPage.css';
import { Link } from "react-router-dom";

function PatientLandingPage() {
  var logOut=()=>{ localStorage.clear()};
  return (
    <div>
      {/* Navbar */}
      <nav className="navbar navbar-expand-lg navbar-dark bg-primary">
        <div className="container">
          <Link className="navbar-brand nav-link" to="/PatientHome">GoodHealth hospitals</Link>
          <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
            <span className="navbar-toggler-icon"></span>
          </button>
          <div className="collapse navbar-collapse" id="navbarNav">
            <ul className="navbar-nav ml-auto">
              <li className="nav-item">
                <Link className="nav-link" to="/viewDoc">View Doctors</Link>
              </li>
              <li className="nav-item">
                <Link className="nav-link" to="/" onClick={logOut}>Logout</Link>
              </li>
            </ul>
          </div>
        </div>
      </nav>

      

      {/* Content Section */}
      <section className="content py-5">
        <div className="container">
          <div className="row">
            <div className="col-lg-8 offset-lg-2 text-center">
            <h3>Welcome!</h3>
              <h5>Our Experienced Team of Doctors</h5>
              <p>We are proud to have a team of highly skilled and compassionate doctors who are dedicated to providing exceptional care to our patients. Our doctors have extensive experience and expertise in their respective fields.</p>
              <p>With a patient-centered approach, our doctors listen to your concerns, diagnose medical conditions, and develop personalized treatment plans. They stay up-to-date with the latest advancements in medicine to ensure the best possible outcomes for our patients.</p>
              <p>Our hospital offers a wide range of specialties, including cardiology, neurology, orthopedics, pediatrics, oncology, and more. Each specialty is supported by a team of dedicated healthcare professionals who work together to deliver comprehensive and integrated care.</p>
              <p>Whether you need routine check-ups, specialized consultations, or complex surgical procedures, our doctors are committed to providing you with the highest quality of care. Your well-being is our top priority.</p>
              <p>In addition to our experienced medical team, we strive to provide a comfortable and supportive environment for our patients. Our hospital is equipped with state-of-the-art facilities, advanced medical technology, and a caring staff to ensure your stay with us is as pleasant as possible.</p>
              <p>Thank you for choosing our hospital. We are honored to be a part of your healthcare journey and look forward to providing you with exceptional medical care.</p>
            </div>
          </div>
        </div>
      </section>

      {/* Footer */}
      <footer className="footer bg-dark text-white text-center">
        <div className="container">
          <p>&copy; 2023 Hospital Management System. All rights reserved.</p>
        </div>
      </footer>
    </div>
  );
}

export default PatientLandingPage;
