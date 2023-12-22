using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Xml.Linq;


namespace LinQSnippets
{
    public class Snippets
    {

        //Paging with Skip and Take
        static public IEnumerable<T> GetPage<T>(IEnumerable<T> collection, int pageNumber, int resultsPerPage) {

            int startIndex = (pageNumber - 1) * resultsPerPage;

            return collection.Skip(startIndex).Take(resultsPerPage);

        }

        //Variables

        static public void LinqVariables()
        {

            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var avobeAverige = from number in numbers
                               let average = numbers.Average()
                               let nSquare = Math.Pow(number, 2)
                               where nSquare > average
                               select number;

            Console.WriteLine("Average: {0} ", numbers.Average());

            foreach (int number in avobeAverige)
            {
                Console.WriteLine("Query: {0}  Square {1} ", number, Math.Pow(number, 2));
            }
        }

        //ZIP

        static public void ZipLinq()
        {

            int[] numbers = { 1, 2, 3, 4, 5 };
            string[] stringNumbers = { "one", "two", "three", "four", "five" };

            IEnumerable<string> ZipNumbers = numbers.Zip(stringNumbers, (number, word) => number + " = " + word);

            //  { "1 = one", "2 = two", ...}
        }

        // Repeat & Range

        static public void RepeatRangeLinq()
        {
            // Generate collection from 1 - 1000 --> RANGE

            IEnumerable<int> first1000 = Enumerable.Range(1, 1000);

            // Repeat a value N times

            IEnumerable<string> fiveXs = Enumerable.Repeat("X", 5); // {"X","X","X","X","X"}


        }

        static public void studentsLinq()
        {
            var classRoom = new[]
            {
                new Student
                {
                    Id = 1,
                    Name = "Gabriel",
                    Grade = 90,
                    Certified = true
                },
                new Student
                {
                    Id = 2,
                    Name = "Vicky",
                    Grade = 50,
                    Certified = false
                },
                new Student
                {
                    Id = 3,
                    Name = "Vero",
                    Grade = 96,
                    Certified = true
                },
                new Student
                {
                    Id = 4,
                    Name = "Seba",
                    Grade = 10,
                    Certified = false
                },
                new Student
                {
                    Id = 5,
                    Name = "Abril",
                    Grade = 60,
                    Certified = true
                },
            };

            var certifiedStudents = from student in classRoom
                                    where student.Certified
                                    select student;

            var notCertifiedStudents = from student in classRoom
                                       where student.Certified == false
                                       select student;

            var aprooveStudents = from student in classRoom
                                  where student.Grade >= 60 && student.Certified
                                  select student.Name;

        }

        // All

        static public void AllLinq()
        {
            var numbers = new List<int>() { 1, 2, 3, 4, 5, };

            bool allAreSmallerThan10 = numbers.All(x => x < 10); //true

            bool allAreBiggerOrEqualThan2 = numbers.All(x => x >= 2); //false

            var emptyList = new List<int>();

            bool allNumbersAreGreaterThan0 = emptyList.All(x => x >= 0); // true

        }

        //Aggregate

        static public void aggregateQueries()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            
            int sum = numbers.Aggregate((prevSum, current) => prevSum + current);

            string[] words = { "hello,", "my", "name", "is", "Gabriel" };

            string greeting = words.Aggregate((prevGreeting, current) => prevGreeting + current);


        }

        // Distinct

        static public void disctintValues()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 5, 4, 3, 2, 1 };

            IEnumerable<int> disctintValues = numbers.Distinct();

        }

        // GroupBy

        static public void groupByExample()
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            //Obtain only even numbers and generate two groups

            var grouped = numbers.GroupBy(x => x % 2 == 0);

            // We will two groups:
            // 1. The group that doesn't fit the condition
            // 2. The group that fits the condition


            foreach (var group in grouped)
            {
                foreach(var value in group)
                {
                    Console.WriteLine(value); //1, 3, 5, 7, 9 .... 2, 4, 6, 8
                }
            }

            var classRoom = new[]
            {
                new Student
                {
                    Id = 1,
                    Name = "Gabriel",
                    Grade = 90,
                    Certified = true
                },
                new Student
                {
                    Id = 2,
                    Name = "Vicky",
                    Grade = 50,
                    Certified = false
                },
                new Student
                {
                    Id = 3,
                    Name = "Vero",
                    Grade = 96,
                    Certified = true
                },
                new Student
                {
                    Id = 4,
                    Name = "Seba",
                    Grade = 10,
                    Certified = false
                },
                new Student
                {
                    Id = 5,
                    Name = "Abril",
                    Grade = 60,
                    Certified = true
                },
            };

            var certifiedQuery = classRoom.GroupBy(student => student.Certified && student.Grade >= 60);

            foreach(var certified in certifiedQuery)
            {
                Console.WriteLine("------------- {0} -------------", certified.Key);
                foreach (var student in certified)
                {
                    Console.WriteLine(student.Name);
                }
            }

        }


        static public void relationsLinq()
        {
            List<Post> posts = new List<Post>()
            {
                new Post()
                {
                    Id=1,
                    Title="My first post",
                    Content = "My first content",
                    Created = DateTime.Now,
                    Comments = new List<Comment>()
                    {
                        new Comment()
                        {
                            Id = 1,
                            Created = DateTime.Now,
                            Title = "My first Comment",
                            Content = "My Content"
                        },
                        new Comment()
                        {
                            Id = 2,
                            Created = DateTime.Now,
                            Title = "My second Comment",
                            Content = "My Other Content"
                        },
                    }
                },
                 new Post()
                {
                    Id=2,
                    Title="My second post",
                    Content = "My second content",
                    Created = DateTime.Now,
                    Comments = new List<Comment>()
                    {
                        new Comment()
                        {
                            Id = 3,
                            Created = DateTime.Now,
                            Title = "My other Comment",
                            Content = "My new Content"
                        },
                        new Comment()
                        {
                            Id = 4,
                            Created = DateTime.Now,
                            Title = "My other new Comment",
                            Content = "My new Content"
                        },
                    }
                }
            };

            var commentWithContent = posts.SelectMany(
                post => post.Comments,
                    (post, comment) => new { PostId = post.Id, CommentContent = comment.Content }
                );


        }
    }
}