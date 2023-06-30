using BigBangAssesmemtTwo.Interfaces;
using BigBangAssesmemtTwo.Models;
using Microsoft.EntityFrameworkCore;

namespace BigBangAssesmemtTwo.Services
{
    public class PatientRepo : IRepo<Patient, int>
    {
        private readonly Context _context;
        public PatientRepo(Context context)
        {

            _context = context;

        }
        public async Task<Patient?> Add(Patient item)
        {
            var patient_id = _context.Patients.SingleOrDefault(p => p.PatientId == item.PatientId);
            if (patient_id == null)
            {
                try
                {
                    _context.Patients.Add(item);
                    await _context.SaveChangesAsync();
                    return item;
                }
                catch (Exception)
                {
                    throw new Exception();
                }
            }
            return null;
        }

        public async Task<Patient?> Delete(int id)
        {
            try
            {
                var patient = await Get(id);
                if (patient != null)
                {
                    _context.Patients.Remove(patient);
                    await _context.SaveChangesAsync();
                    return patient;
                }
                return null;
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }


        public async Task<Patient?> Get(int id)
        {
            try
            {
                var patient = await _context.Patients.SingleOrDefaultAsync(i => i.PatientId == id);
                if(patient == null)
                {
                    return null;
                }
                return patient;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<ICollection<Patient>?> GetAll()
        {
            try
            {
                var patients = await _context.Patients.ToListAsync();
                if (patients != null)
                {
                    return patients;
                }
                return null;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        

        public async Task<Patient?> Update(Patient item)
        {
            var patient = _context.Patients.SingleOrDefault(p=>p.PatientId == item.PatientId);
            if(patient != null)
            {
                try
                {
                    patient.Name = item.Name;
                    patient.DateOfBirth= item.DateOfBirth;
                    patient.Address=item.Address;
                    patient.Email=item.Email;
                    patient.Phone=item.Phone;
                    patient.Gender=item.Gender;
                    patient.HealthIssue=item.HealthIssue;
                    await _context.SaveChangesAsync();
                    return patient;
                }
                catch (Exception)
                {
                    throw new Exception();
                }
            }
            return null;
        }
    }
}
