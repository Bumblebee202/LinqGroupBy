// See https://aka.ms/new-console-template for more information

using LinqGroupBy;

var sqlLinq = new SqlLinq();
sqlLinq.GroupBy("Age");

sqlLinq.GroupBy("FirstName");

sqlLinq.GroupBy("LastName");