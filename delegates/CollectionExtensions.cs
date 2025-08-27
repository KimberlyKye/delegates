namespace delegates
{
    /// <summary>
    /// Статический класс, содержащий функции расширения для коллекций
    /// </summary>
    public static class CollectionExtensions
    {
        /// <summary>
        /// Находит и возвращает максимальный элемент коллекции на основе числового преобразования
        /// </summary>
        /// <typeparam name="T">Тип элементов коллекции (ссылочный тип)</typeparam>
        /// <param name="collection">Коллекция элементов</param>
        /// <param name="convertToNumber">Делегат для преобразования элемента в число</param>
        /// <returns>Максимальный элемент коллекции или null, если коллекция пуста</returns>
        /// <exception cref="ArgumentNullException">Выбрасывается, если collection или convertToNumber равны null</exception>
        public static T? GetMax<T>(this IEnumerable<T> collection, Func<T, float> convertToNumber) where T : class
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));

            if (convertToNumber == null)
                throw new ArgumentNullException(nameof(convertToNumber));

            if (!collection.Any())
                return null;

            T? maxItem = null;
            float maxValue = float.MinValue;

            foreach (var item in collection)
            {
                float currentValue = convertToNumber(item);
                if (currentValue > maxValue)
                {
                    maxValue = currentValue;
                    maxItem = item;
                }
            }

            return maxItem;
        }
    }
}