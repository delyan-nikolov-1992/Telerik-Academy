//-----------------------------------------------------------------------
// <copyright file="IMotherboard.cs" company="Telerik Academy">
//     Company copyright tag.
// </copyright>
// <summary>This is the IMotherboard interface.</summary>
//-----------------------------------------------------------------------
namespace Computers
{
    /// <summary>
    /// The interface IMotherboard binds all components into object and is used to
    /// generate computers with these components. 
    /// </summary>
    public interface IMotherboard
    {
        /// <summary>
        /// Loads all values from the RAM.
        /// </summary>
        /// <returns>All values that where loaded from the RAM.</returns>
        int LoadRamValue();

        /// <summary>
        /// Saves a given value to the RAM.
        /// </summary>
        /// <param name="value">The given value to be saved to the RAM.</param>
        void SaveRamValue(int value);

        /// <summary>
        /// Draw a given text on the video card.
        /// </summary>
        /// <param name="data">The given text to be drawn on the video card.</param>
        void DrawOnVideoCard(string data);
    }
}