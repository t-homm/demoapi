using NetTopologySuite.Geometries;
public class Location
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Point GeographicalPoint { get;  set; }
    public string Address { get; set; }
    public string Tel { get; set; }
}