using System.Collections.Generic;
using System.Text;
using HTMLSpitterLib.Attributes;
using HTMLSpitterLib.Css;

namespace HTMLSpitterLib.Tags
{
    public enum ElementEndTagType
    {
        EndTag,
        SelfEndTag
    }

    public enum ElementContentType
    {
        ContainsText,
        ContainsHtml,
        ContainsBoth, // this is absurd, We don't require it.
        ContainsNothing
    }


    public abstract class TagBase : CssProperties
    {
        protected List<TagAttribute> Attributes = new List<TagAttribute>();
        protected string TagName;

        public ElementEndTagType ElementEndTagType { get; set; }

        public ElementContentType ElementContentType { get; set; }


        public void AddAttribute(string lhs, string rhs)
        {
            Attributes.Add(new TagAttribute(lhs, rhs));
        }

        public abstract string Spit();

        protected string InitSpit()
        {
            var sb = new StringBuilder();
            sb.Append("<");
            sb.Append(TagName);
            foreach (var attr in Attributes)
            {
                sb.Append(" ");
                sb.Append(attr.LHS);
                sb.Append("=\"");
                sb.Append(attr.RHS);
                sb.Append("\"");
            }
            return sb.ToString();
        }
    }


    public class ContentTag : TagBase
    {
        private readonly List<TagBase> _children;
        private string _text;

        public ContentTag(string tagName,
            ElementContentType elementContentType = ElementContentType.ContainsHtml)
        {
            TagName = tagName;
            ElementEndTagType = ElementEndTagType.EndTag;
            ElementContentType = elementContentType;
            _children = new List<TagBase>();
            _text = "";
        }


        public override string Spit()
        {
            var sb = new StringBuilder(InitSpit());
            sb.Append(">");
            switch (ElementContentType)
            {
                case ElementContentType.ContainsHtml:
                    foreach (TagBase tag in _children)
                    {
                        sb.Append(tag.Spit());
                    }
                    break;
                case ElementContentType.ContainsText:
                    sb.Append(_text);
                    break;
            }

            sb.Append("</" + TagName + ">");
            return sb.ToString();
        }

        public void AddChild(TagBase tag)
        {
            _children.Add(tag);
        }

        public void AddText(string text)
        {
            if (ElementContentType == ElementContentType.ContainsText)
            {
                _text = text;
            }
        }
    }

    public class EmptyTag : TagBase
    {
        public EmptyTag(string tagName)
        {
            TagName = tagName;
            ElementContentType = ElementContentType.ContainsNothing;
            ElementEndTagType = ElementEndTagType.SelfEndTag;
        }

        public override string Spit()
        {
            var sb = new StringBuilder(InitSpit());
            sb.Append(" />");
            return sb.ToString();
        }
    }
}