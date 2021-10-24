struct Point3D
{
    public double x, y, z;
    private readonly string name;
    public double distanceOrigin;

    public Point3D(double x, double y, double z, string name="[P]")
    {
        this.name = name;
        this.x = x;
        this.y = y;
        this.z = z;
        this.distanceOrigin = System.Math.Round(System.Math.Pow((x * x) + (y * y) + (z * z), 0.5), 4);
    }

    /// <summary>
    /// Very small brain swapping method to swap two data structure of Point3D. 
    /// </summary>
    /// <param name="p1">A Point3D we want to swap coordinates with the second parameter</param>
    /// <param name="p2">A Point3D we want to swap coordinates with the first parameter</param>
    /// <returns>A list containing the two swapped Point3D</returns>
    public static (Point3D p1, Point3D p2) SwapPoints(Point3D p1, Point3D p2)
    {
        return (new Point3D(p2.x, p2.y, p2.z, p1.name), new Point3D(p1.x, p1.y, p1.z, p2.name));
    }

    public override string ToString()
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("|Point3D " + this.name + ":|  x  |  y  |  z  |  distance  |\n");
        sb.Append("|------------------------------------------|\n");
        sb.Append("|           | ");
        sb.Append(this.x + " | ");
        sb.Append(this.y + " | ");
        sb.Append(this.z + " |   ");
        sb.Append(this.distanceOrigin + "   |\n\n");
        return sb.ToString();
    }
}