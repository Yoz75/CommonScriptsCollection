using UnityEngine;

namespace CSC
{
    /// <summary>
    /// Something that can hold props
    /// </summary>
    public interface IReadOnlyPropsHolder
    {
        /// <summary>
        /// Get copy of props
        /// </summary>
        /// <returns>copy of props as base class <see cref="Props"/></returns>
        public Props GetCopyOfRawProps();
    }

    /// <summary>
    /// Something that can hold props
    /// </summary>
    public interface IPropsHolder : IReadOnlyPropsHolder
    {
        /// <summary>
        /// Get props
        /// </summary>
        /// <returns>props as base class <see cref="Props"/></returns>
        public Props GetRawProps();
    }

    /// <summary>
    /// <see cref="IPropsHolder"/>, but generic
    /// </summary>
    /// <typeparam name="T">type of props</typeparam>
    public interface IReadOnlyPropsHolder<T> : IPropsHolder where T : Props
    {
        /// <summary>
        /// Get copy of props
        /// </summary>
        /// <returns>copy of props</returns>
        public T GetCopyOfProps();
    }

    /// <summary>
    /// <see cref="IPropsHolder"/>, but generic
    /// </summary>
    /// <typeparam name="T">type of props</typeparam>
    public interface IPropsHolder<T> : IReadOnlyPropsHolder<T> where T : Props
    {
        /// <summary>
        /// Get props
        /// </summary>
        /// <returns>copy of props</returns>
        public T GetProps();
    }

    /// <summary>
    /// <see cref="IPropsHolder"/>, but mono behavior 
    /// </summary>
    public abstract class PropsHolder : MonoBehaviour, IPropsHolder
    {
        public abstract Props GetRawProps();

        public abstract Props GetCopyOfRawProps();
    }

    /// <summary>
    /// <see cref="IPropsHolder{T}"/>, but mono behaviour
    /// </summary>
    /// <typeparam name="T">type of props</typeparam>
    public abstract class PropsHolder<T> : PropsHolder, IPropsHolder<T> where T : Props
    {
        /// <summary>
        /// The instance of T
        /// </summary>
        [SerializeField] protected T Props;

        public T GetProps() => Props;
        public override Props GetRawProps() => Props;

        public T GetCopyOfProps() => (T) Props.Clone();

        public override Props GetCopyOfRawProps() => (Props) Props.Clone();
    }
}