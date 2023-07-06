import { Navigate } from "react-router-dom";

function ManageDoctorProc({token,children})
{
    token=localStorage.getItem("token");
    if(token!=null)
        return children;
    return <Navigate to='/'/>
}

export default ManageDoctorProc;