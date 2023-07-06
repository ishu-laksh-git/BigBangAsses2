import logo from './logo.svg';
import './App.css';
import 'bootstrap/dist/css/bootstrap.css';
import Login from './components/Login';
import Docregister from './components/Docregister';
import Patientregister from './components/Patientregister';
import Home from './components/Home';
import PatientLandingPage from './components/Patientlanding';
import AdminLandingPage from './components/AdminLandingPage';
import DoctorLandingPage from './components/DocLandingPage';
import PatientViewDoctors from './components/Viewdoctors';
import AdminViewDoctors from './components/AdminViewDoctors';
import AddDoctors from './components/AddDoctors';
import AdminLanding from './ProtectedRoutes/AdminLanding';
import DoctorLanding from './ProtectedRoutes/DoctorLanding';
import PatientLanding from './ProtectedRoutes/PatientLanding';
import AddDoctorProc from './ProtectedRoutes/AddDoctorProc';
import viewdocProc from './ProtectedRoutes/viewdocProc';
import ManageDoctorProc from './ProtectedRoutes/ManageDoctorProc';
import { BrowserRouter, Route, Routes } from 'react-router-dom';

function App() {
  return (
    
    <BrowserRouter>
    
    <div>
    
      <Routes>
        <Route path='/' element={<Home/>}/>
        <Route path='docReg' element={<Docregister/>}/>
        <Route path='patientReg' element={<Patientregister/>}/>
        <Route path="Login" element={<Login/>}/>
        <Route path="AdminHome" element={
          <AdminLanding>
            <AdminLandingPage/>
          </AdminLanding>}/>
        <Route path="DocHome" element={
          <DoctorLanding>
            <DoctorLandingPage/>
            </DoctorLanding>}/>
        <Route path='PatientHome' element={
          <PatientLanding>
            <PatientLandingPage/>
          </PatientLanding>}/>
        <Route path='adManageDoc' element={
          <ManageDoctorProc>
            <AdminViewDoctors/>
            </ManageDoctorProc>}/>
        <Route path='addDoc' element={
          <AddDoctorProc>
            <AddDoctors/>
          </AddDoctorProc>
        }/>
        <Route path="viewDoc" element={
        <viewdocProc>
          <PatientViewDoctors/>
        </viewdocProc>}/>
      </Routes>
    </div>
    </BrowserRouter>
  );
}

export default App;
