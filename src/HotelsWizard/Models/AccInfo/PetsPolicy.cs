
namespace HotelsWizard.Models.AccInfo
{
    public class PetsPolicy
    {
        public int PetsAllowed;
        public bool PetsAllowedOnRequest;
        public string PetsSurcharge;

        public PetsPolicy()
        {
            this.PetsAllowed = 0;
            this.PetsAllowedOnRequest = false;
            this.PetsSurcharge = "";
        }
    }
}