using Model.Queries.Interfaces;

namespace IProduct
{
    public class produc: IQueryDto,IModelDto
    {


        public long UserId { get; set; }
        public bool IsAdmin { get; set; }
        public long? LoggedUserId { get; set; }
        public string LoggedUserName { get; set; }
    }
}
