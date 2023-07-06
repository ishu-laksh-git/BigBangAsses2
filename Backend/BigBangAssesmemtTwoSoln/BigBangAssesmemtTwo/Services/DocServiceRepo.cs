using BigBangAssesmemtTwo.Interfaces;
using BigBangAssesmemtTwo.Models;
using Microsoft.EntityFrameworkCore;

namespace BigBangAssesmemtTwo.Services
{
    public class DocServiceRepo : IDocRepo<int, Doctor>
    {
        private readonly Context _context;
        public DocServiceRepo(Context context)
        {
            _context = context;
        }

        public async Task<Doctor?> DeleteDoc(int id)
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
                var doctor = await _context.Doctors.SingleOrDefaultAsync(i => i.DoctorId==id);
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
    }
}
