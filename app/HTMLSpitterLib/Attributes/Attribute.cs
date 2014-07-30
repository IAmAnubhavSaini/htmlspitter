namespace HTMLSpitterLib.Attributes
{
    public class TagAttribute
    {
        public string LHS;
        public string RHS;

        public TagAttribute(string lhs, string rhs = "")
        {
            LHS = lhs;
            RHS = rhs;
        }
    }
}