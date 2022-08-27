using LinqGroupBy.DTO;
using LinqGroupBy.Models;

namespace LinqGroupBy
{
    internal class SqlLinq
    {
        IEnumerable<User> _users;

        public SqlLinq() => FillUsers();


        public void GroupBy(string groupName)
        {
            var result =
                from user in _users
                group user by user.GetType().GetProperty(groupName).GetValue(user) into gr
                where gr.Key != null
                select new KeyValuesDTO
                {
                    PropertyName = groupName,
                    PropertyValue = gr.Key.ToString(),
                    Users = gr,
                    UsersToStrings = from groupedUser in gr
                                     select groupedUser.ToString(),
                };

            ShowList(result);

            //sql linq
            //var getAllQuery =
            //    from transportOrder in _repository.GetAll()
            //    join relation in _relationRepository.GetAll() on transportOrder.RelationId equals relation.Id
            //    where (input.DateRange == null || (transportOrder.OrderDate >= input.DateRange.From /* && ...*/))
            //    group relation by relation.GetType().GetProperty(input.GroupName).GetValue(relation) into gr
            //    where gr.Key != null
            //    select new DTO
            //    {
            //        PropertyName = input.GroupName, // not required
            //        PropertyValue = gr.Key, // the key by which the entities are grouped. Some value from the property
            //        Entities = gr // all entities with a common key
            //    };

            //method  linq
            //var getAllQuery = _repository.GetAll()
            //                             .Include(x => x.Relation)
            //                             .Where(x => input.DateRange == null || (transportOrder.OrderDate >= input.DateRange.From /* && ...*/))
            //                             .GroupBy(x => x.GetType().GetProperty(input.GroupName).GetValue(x))
            //                             .Where(x => x.Key != null)
            //                             .Select(x => new DTO
            //                             {
            //                                 PropertyName = input.GroupName, // not required
            //                                 PropertyValue = gr.Key, // the key by which the entities are grouped. Some value from the property
            //                                 Entities = gr // all entities with a common key
            //                             });
        }

        void ShowList(IEnumerable<KeyValuesDTO> keyValues)
        {
            foreach (var item in keyValues)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{nameof(item.PropertyValue)}: {item.PropertyName}");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{nameof(item.PropertyValue)}: {item.PropertyValue}");

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"{nameof(item.UsersToStrings)}:");
                Console.ResetColor();
                var strs = string.Join('\n', item.UsersToStrings.Select((x, index) => $"{index + 1} {x}"));
                Console.WriteLine(strs);

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        void FillUsers()
        {
            _users = new[]
            {
                new User
                {
                    FirstName = "Harry",
                    LastName = "Potter",
                    Age = 11
                },
                new User
                {
                    FirstName = "Ron",
                    LastName = "Weasley",
                    Age = 11
                },
                new User
                {
                    FirstName = "Hermione",
                    LastName = "Granger",
                    Age = 11
                }
            };
        }
    }
}
