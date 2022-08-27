using LinqGroupBy.Models;

namespace LinqGroupBy.DTO
{
    internal class KeyValuesDTO
    {
        public string PropertyName { get; set; }
        public string PropertyValue { get; set; }
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<string> UsersToStrings { get; set; }
    }
}
