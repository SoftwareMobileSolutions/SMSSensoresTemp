namespace mtemp.Models
{
    public class publicTemperaturaInfoModel
    {
        public class temp_Areas
        {
            public byte[] img {get; set;}
            public string nombrearea { set; get;}
        }
        public class temp_TempCoord
        {
            public int mobileid { set; get; }
            public string sensor { set; get; }
            public float y { set; get; }
            public float x { set; get; }
        }
        public class temp_sensors
        {
            public string dategps { set; get; }
            public float s1 { set; get; }
            public float s2 { set; get; }
            public float s3 { set; get; }
            public float s4 { set; get; }
            public float s5 { set; get; }
            public float s6 { set; get; }
        }
    }
}
