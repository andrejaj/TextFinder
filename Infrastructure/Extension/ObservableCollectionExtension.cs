using System.Collections.ObjectModel;

namespace Infrastructure.Extension
{
    public static class ObservableCollectionExtension
    {
        /// <summary>
        /// taken from https://gist.github.com/brunossn/197f0ad0820258da27f54f917d11ac49
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lista"></param>
        /// <param name="items"></param>
        public static void AddRange<T>(this ObservableCollection<T> lista, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                lista.Add(item);
            }
        }
    }
}
