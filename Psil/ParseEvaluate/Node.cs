
// Not Used as of now 
// Schema has the potential to be used for Extension
namespace Psil.Parsing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Schema for AST Representation For PSIL
    /// </summary>
    public class Node
    {

        public enum NodeType
        {
            Operator,
            Value
        }
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Node()
        {
        }

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="label"></param>
        /// <param name="input"></param>
        public Node(int begin, string label, string input)
        {
            if (label == null)
                throw new ArgumentNullException();
            Begin = begin;
            Label = label;
            Input = input;
        }

        /// <summary>
        /// Constructs an AstNode from a label and a collection of AstNodes
        /// </summary>
        /// <param name="label"></param>
        /// <param name="content"></param>
        public Node(string label, IEnumerable<Node> content)
        {
            Label = label;
            Nodes = content.ToList();
        }

        /// <summary>
        /// Constructs an AstNode from a label and an arbitrary number of parameters.
        /// </summary>
        /// <param name="label"></param>
        /// <param name="content"></param>
        public Node(string label, params Node[] content)
            : this(label, content as IEnumerable<Node>)
        {
        }

        /// <summary>
        /// Constructs a leaf AstNode with the specified text content.
        /// </summary>
        /// <param name="label"></param>
        /// <param name="content"></param>
        public Node(string label, string content)
        {
            Label = label;
            Input = content;
            Begin = 0;
            End = Input.Length;
        }


        /// <summary>
        /// Input string used to create AST node.
        /// </summary>
        public string Input;

        /// <summary>
        /// Index where AST content starts within Input.
        /// </summary>
        public int Begin;

        /// <summary>
        /// Index where AST content ends within Input .
        /// </summary>
        public int End;

        /// <summary>
        /// The name of the associated rule.
        /// </summary>
        public string Label;

        /// <summary>
        /// List of child nodes.
        /// </summary>
        public List<Node> Nodes = new List<Node>();

        /// <summary>
        /// Length of associated text. 
        /// </summary>
        public int Length { get { return End > Begin ? End - Begin : 0; } }

        /// <summary>
        /// Text associated with the parse result.
        /// </summary>
        public string Text { get { return Input.Substring(Begin, Length); } }

        /// <summary>
        /// Indicates whether there are any children nodes or not. 
        /// </summary>
        public bool IsLeaf { get { return Nodes.Count == 0; } }

        /// <summary>
        /// Returns all child nodes with the given label
        /// </summary>
        /// <param name="label"></param>
        /// <returns></returns>
        public IEnumerable<Node> GetNodes(string label)
        {
            return Nodes.Where(n => n.Label == label);
        }

        /// <summary>
        /// Returns the first child node with the given label.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Node GetNode(string label)
        {
            return GetNodes(label).First();
        }

        /// <summary>
        /// Returns the first child node with the given label.
        /// </summary>
        /// <param name="label"></param>
        /// <returns></returns>
        public Node this[string label]
        {
            get { return GetNode(label); }
        }

        /// <summary>
        /// Returns the nth child node.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public Node this[int n]
        {
            get { return Nodes[n]; }
        }

        /// <summary>
        /// Returns the count child nodes.
        /// </summary>
        public int Count
        {
            get { return Nodes.Count; }
        }

        /// <summary>
        /// Returns a string representation. 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("{0}:{1}", Label, Text);
        }
    }
}
