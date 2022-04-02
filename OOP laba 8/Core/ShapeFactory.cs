namespace OOP_laba_8.Core
{
    public class ShapeFactory : Factory
    {
        public override Shape createShape(string name)
        {
            Shape shape;
            switch (name)
            {
                case "Circle":
                    shape = new Circle();
                    break;
                case "Group":
                    shape = new SGroup();
                    break;
                case "Polygon":
                    shape = new Polygon();
                    break;
                case "Star":
                    shape = new Star();
                    break;
                default:
                    shape = null;
                    break;
            }
            return shape;
        }
    }
}
