using O2GOBackEnd.Models;

namespace O2GOBackEnd.Services
{
    public interface IInsuranceService
    {
        List<Insurance> GetInsurances();

        Insurance CreateInsurance(Insurance insurance);

        Insurance UpdateInsurance(Insurance insurance);

        Insurance RemoveInsurance(Insurance inurance);
    }
}
