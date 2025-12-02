
namespace CSC
{
    /// <summary>
    /// Something that can be randomly selected using weight
    /// </summary>
    public interface IWeighted
    {
        /// <summary>
        /// A value that indicates how likely it is that this object will be selected randomly using <see cref="WeightedSelect{TCollection, TElement}"/>
        /// </summary>
        public int Weight
        {
            get;
        }
    }
}