using System.Text.Json;

internal class Program
{
    private static HttpClient httpClient = new HttpClient();
    private static async Task Main(string[] args)
    {
        List<Employee> employees = new List<Employee>
        {
            new Employee{FirstName = "Mahmoud",LastName = "Hassan",ID = 1,Title="Backend Developer",Skills = new string[]{ "HTML","CSS","JS","C#"} },
            new Employee{FirstName = "John",LastName = "Doe",ID = 2,Title="Frontend Developer",Skills = new string[]{ "HTML","CSS","JS"} },
            new Employee{FirstName = "Jane",LastName = "Doe",ID = 3,Title="Full-stack Developer",Skills = new string[]{ "HTML","CSS","JS","C#","SQL"} },
            new Employee{FirstName = "Alice",LastName = "Smith",ID = 4,Title="Software Engineer",Skills = new string[]{ "Java","Python","C++"} },
            new Employee{FirstName = "Bob",LastName = "Johnson",ID = 5,Title="Data Analyst",Skills = new string[]{ "SQL","Excel","Python"} },
            new Employee{FirstName = "Sarah",LastName = "Lee",ID = 6,Title="UX Designer",Skills = new string[]{ "UI Design","Wireframing","Prototyping"} },
            new Employee{FirstName = "Alex",LastName = "Kim",ID = 7,Title="Project Manager",Skills = new string[]{ "Agile","Scrum","Leadership"} },
            new Employee{FirstName = "Emily",LastName = "Wong",ID = 8,Title="Marketing Specialist",Skills = new string[]{ "SEO","Social Media","Content Writing"} },
            new Employee{FirstName = "David",LastName = "Chen",ID = 9,Title="QA Engineer",Skills = new string[]{ "Testing","Automation","Bug Tracking"} },
            new Employee{FirstName = "Grace",LastName = "Liu",ID = 10,Title="Technical Writer",Skills = new string[]{ "Technical Writing","Documentation","Editing"} },
        };
        string jsonContent = "";
        foreach (Employee emp in employees)
        {
            jsonContent += JsonSerializer.Serialize(emp, new JsonSerializerOptions { WriteIndented = true });
        }
        File.WriteAllText("jsonContent.json", jsonContent); // create a json file

        // DeSerialize
        var todosJsonContent = await httpClient.GetStreamAsync("https://jsonplaceholder.typicode.com/todos");
        var todos = JsonSerializer.Deserialize<List<Todo>>(todosJsonContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        foreach (Todo todo in todos)
        {
            Console.WriteLine(todo);
        }
    }
}

internal class Todo
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Title { get; set; }
    public bool Completed { get; set; }
    public override string ToString()
    {
        return $"{Id}\n{UserId}\n{Title}\n{(Completed ? "Completed" : "Not Completed")}\n";
    }

}


internal class Employee
{
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public int ID { get; set; }
    public string Title { get; set; } = "";
    public string[] Skills { get; set; }

}