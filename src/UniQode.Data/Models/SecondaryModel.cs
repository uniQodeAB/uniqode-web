namespace UniQode.Data.Models
{
    public class SecondaryModel : BaseModel<SecondaryModel>
    {
        public SecondaryModel(string nameOrConnectionString)
            : base(nameOrConnectionString, "secondary")
        {

        }

        public SecondaryModel()
            : this("name=DbContext")
        {

        }
    }
}