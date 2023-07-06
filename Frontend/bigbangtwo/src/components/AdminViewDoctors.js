import { useState,useCallback ,useEffect} from "react";
import './AdminViewDoctors.css';
import { Link } from "react-router-dom";
import IndividualDoctors from './IndividualDoctors';

function AdminViewDoctors() {
  var logOut=()=>{ localStorage.clear()};


  const [doctors, setDoctors] = useState([]);
  const [id, setId] = useState("");
  const [isApproved, setIsApproved] = useState("");

  useEffect(()=>{
    getDoctors();
  },[]);


  const getDoctors = () => {
    fetch("http://localhost:5184/api/Hospital/GetDoctors", {
  method: 'GET',
  headers: {
    accept: 'text/plain',
    'Content-Type': 'application/json',
    'Authorization': 'Bearer ' + localStorage.getItem('token')
  },
  
    })
  .then(async (response) => {
    if (!response.ok) {
      throw new Error(`HTTP error! Status: ${response.status}`);
    }
    const myData = await response.json();
    console.log(myData);
    setDoctors(myData);
    console.log(doctors);
  })
  .catch((error) => {
    console.error('Error fetching data:', error);
  });
  }

  
        


  

  return (
    <div className="admin-view-doctors">
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

      {/* Doctor List */}
      <br/>
      <b className="text-center">All doctors in our clinic</b>
<br/>


<div className="GetAll">
  {
    doctors.map((doctor,index)=>{
      return(<IndividualDoctors key={index} user = {doctor}/>)
    })
  }
</div>
     

      {/* Footer */}
      <footer className="footer bg-dark text-white text-center mt-auto">
        <div className="container">
          <p>&copy; 2023 Hospital Management System. All rights reserved.</p>
        </div>
      </footer>
    </div>
  );
}

export default AdminViewDoctors;
