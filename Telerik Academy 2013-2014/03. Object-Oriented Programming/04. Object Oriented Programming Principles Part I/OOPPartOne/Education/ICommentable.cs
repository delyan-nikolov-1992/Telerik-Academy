namespace Education
{
    using System.Collections.Generic;

    public interface ICommentable
    {
        // all classes that implements this interface have list of strings 
        // and can use all the functionalities of the list (including all methods)
        List<string> Comments { get; set; }
    }
}