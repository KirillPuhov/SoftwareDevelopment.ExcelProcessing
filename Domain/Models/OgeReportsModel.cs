namespace Domain.Models
{
    public sealed class OgeReportsModel
    {
        private int _id { get; set; }
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }


        private string _fullName { get; set; }
        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; }
        }


        private string _className { get; set; }
        public string ClassName
        {
            get { return _className; }
            set { _className = value; }
        }

        private int _audienceNumber { get; set; }
        public int AudienceNumber
        {
            get { return _audienceNumber; }
            set { _audienceNumber = value; }
        }


        private int _points { get; set; }
        public int Points
        {
            get { return _points; }
            set { _points = value; }
        }
    }
}
