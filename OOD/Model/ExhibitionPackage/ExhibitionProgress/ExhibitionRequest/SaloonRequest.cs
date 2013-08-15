namespace OOD.Model.ExhibitionPackage.ExhibitionProgress.ExhibitionRequest
{
    public class SaloonRequest : Request
    {
        public int Area { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Name { get; set; }
    }
}