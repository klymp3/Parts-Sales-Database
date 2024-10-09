namespace WebApplication1.Classes
{
    public class ViewOrder
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public string NameProvider { get; set; }
        public string FIOClient { get; set; }
        public int VendorСode { get; set; }
        public DateTime DateOfConclusion { get; set; }
        public DateTime DeliveryDeadline { get; set; }
        int i = 0;
        public ViewOrder() { }
        public ViewOrder(int amount, string nameProvider, string fioClient, int vendorСode, DateTime dateOfConclusion, DateTime deliveryDeadline)
        {
            Id = ++i;
            Amount = amount;
            NameProvider = nameProvider;
            FIOClient = fioClient;
            VendorСode = vendorСode;
            DateOfConclusion = dateOfConclusion;
            DeliveryDeadline = deliveryDeadline;
        }
    }
}
