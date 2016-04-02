namespace UniQode.Data.Models
{
    public class PrimaryModel : BaseModel<PrimaryModel>
    {
        public PrimaryModel(string nameOrConnectionString)
            : base(nameOrConnectionString, "primary")
        {

        }

        public PrimaryModel()
            : this("name=DbContext")
        {

        }
    }
}