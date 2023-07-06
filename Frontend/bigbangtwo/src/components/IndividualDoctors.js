import React, { useState, useEffect } from "react";
import './IndividualDotor.css'

function IndividualDoctors(props) {
//   const [status, setStatus] = useState({
//     id: 1,
//     status: "Approved"
//   });

  const [doc, setDoc] = useState([props.user]);


  useEffect(() => {
    if (doc[0]) {
      localStorage.setItem("doctorId", doc[0].doctorId);
    }
  }, [doc]);

  const UpdateStatus = (doctorId, isApproved) => {
    const newStatus = isApproved === "Approved" ? "Disapproved" : "Approved";
  
    fetch("http://localhost:5184/api/Hospital/UpdateDoctorStatus", {
      method: "PUT",
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json",
        Authorization: "Bearer " + localStorage.getItem("token")
      },
      body: JSON.stringify({ doctorId, status: newStatus })
    })
      .then(async (response) => {
        if (response.status === 200) {
          const data = await response.json();
          setDoc([data]); // Update the doc state with the new data
        }
      })
      .catch((err) => {
        console.log(err);
      });
  };
  
  const handleDelete = (doctorId) => {
    fetch(`http://localhost:5184/api/Hospital/DeleteDoctor?id=${doctorId}`, {
      method: "DELETE",
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json",
        Authorization: "Bearer " + localStorage.getItem("token")
      }
    })
      .then(async (response) => {
        if (response.status === 200) {
          const deletedDoctor = await response.json();
          // Do something with the deleted doctor object if needed
          console.log("Doctor deleted:", deletedDoctor);
          alert("Deleted!")
        }
      })
      .catch((err) => {
        console.log(err);
      }
      );
      alert("Doctor deleted!")
  };
  return (
    <div>
      <div className="card card-body IndividualDoctor card text-white bg-primary mb-3 shadow p-3 mb-5 rounded">
        <h5 className="card-title">{doc[0].name}</h5>
        <br />
        <p className="card-text">
          <b>Email - </b>
          {doc[0].email}
        </p>
        <p className="card-text">
          <b>DOB - </b>
          {doc[0].dateOfBirth}
        </p>
        <p className="card-text">
          <b>Gender - </b>
          {doc[0].gender}
        </p>
        <p className="card-text">
          <b>Phone - </b>
          {doc[0].phone}
        </p>
        <p className="card-text">
          <b>City - </b>
          {doc[0].address}
        </p>
        <p className="card-text">
          <b>Speciality - </b>
          {doc[0].speciality}
        </p>
        <p className="card-text">
          <b>Experience - </b>
          {doc[0].experience}
        </p>
        <p className="card-text">
          <b>Status - </b>
          {doc[0].isApproved}
        </p>
        <button
          onClick={() => UpdateStatus(doc[0].doctorId, doc[0].isApproved)}
          className="card-link btn btn-secondary"
        >
          Change Status
        </button>
        <br />
        <button className="card-link btn btn-danger"
        onClick={() => handleDelete(doc[0].doctorId)}>Delete</button>
      </div>
    </div>
  );
}

export default IndividualDoctors;

//vishnu
//Vish#3