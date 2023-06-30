using BigBangAssesmemtTwo.Interfaces;
using BigBangAssesmemtTwo.Models;
using Microsoft.EntityFrameworkCore;

namespace BigBangAssesmemtTwo.Services
{
    public class DoctorRepo : IRepo<Doctor, int>
    {
        private readonly Context _context;
        public DoctorRepo(Context context)
        {
            _context = context;
        }
        public async Task<Doctor?> Add(Doctor item)
        {
            var doctor_id = _context.Doctors.SingleOrDefault(d => d.DoctorId == item.DoctorId);
            if (doctor_id == null)
            {
                try
                {
                    _context.Doctors.Add(item);
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

        public async Task<Doctor?> Delete(int id)
        {
            try
            {
                var doctor = await Get(id);
                if (doctor != null)
                {
                    _context.Doctors.Remove(doctor);
                    await _context.SaveChangesAsync();
                    return doctor;
                }
                return null;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<Doctor?> Get(int id)
        {
            try
            {
                var doctor = await _context.Doctors.SingleOrDefaultAsync(i => i.DoctorId == id);
                if (doctor == null)
                {
                    return null;
                }
                return doctor;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<ICollection<Doctor>?> GetAll()
        {
            try
            {
                var doctors = await _context.Doctors.ToListAsync();
                if (doctors != null)
                {
                    return doctors;
                }
                return null;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<Doctor?> Update(Doctor item)
        {
            var doctor = _context.Doctors.SingleOrDefault(d => d.DoctorId == item.DoctorId);
            if (doctor != null)
            {
                try
                {
                    doctor.Name = item.Name;
                    doctor.DateOfBirth = item.DateOfBirth;
                    doctor.Address = item.Address;
                    doctor.Email = item.Email;
                    doctor.Phone = item.Phone;
                    doctor.Gender = item.Gender;
                    doctor.Speciality = item.Speciality;
                    doctor.Experience = item.Experience;
                    await _context.SaveChangesAsync();
                    return doctor;
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
