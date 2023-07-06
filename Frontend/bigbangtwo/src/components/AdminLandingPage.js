import React from "react";
import './AdminLandingPage.css';
import { Link } from "react-router-dom";

function AdminLandingPage() {
  var logOut=()=>{ localStorage.clear()};
  return (
    <div className="AdminLand">
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



      {/* Content Section */}
      <section className="content py-5">
        <div className="container">
          <div className="row">
            <div className="col-lg-8 offset-lg-2 text-center">

              <h2>Welcome!</h2>
              <p>As an admin, you have access to the hospital management system to oversee various operations and ensure smooth functioning.</p>
              <p>With the "View Doctors" option, you can browse the list of doctors, their profiles, specialties, and availability. This allows you to monitor the doctors' schedules and make any necessary adjustments and also manage the doctors in your system.</p>
              <p>The "Add Doctors" option enables you to add new doctors to the system. You can enter their details, assign specialties, and set their availability. This helps in expanding the pool of available doctors in the hospital.</p>
              <p>Additionally, you have the option to logout from the system whenever necessary, ensuring the security of the admin account.</p>
              <p>Thank you for your dedicated service as an admin. Your contributions play a vital role in maintaining the efficiency and quality of healthcare services provided by our hospital.</p>
            </div>
          </div>
        </div>
      </section>

      {/* Footer */}
      <footer className="footer bg-dark text-white text-center">
        <div className="container">
          <p>&copy; 2023 GoodHealth hospitals. All rights reserved.</p>
        </div>
      </footer>
    </div>
  );
}

export default AdminLandingPage;
